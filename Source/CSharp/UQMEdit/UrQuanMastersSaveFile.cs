using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace UQMEdit
{
	partial class UrQuanMastersSaveFile
	{
		public static UrQuanMastersSaveFile Instance = new UrQuanMastersSaveFile();

		public string Date = "";
		private byte[] _fileBuffer;
		public string SaveName;
		public byte SaveVersion = 0;
		private FileStream _fileStream;
		private Main _window;

		public void Open(string fileToLoadName, Main window) {

			if (!File.Exists(fileToLoadName))
			{
				MessageBox.Show("Could not find file at path: " + fileToLoadName);
			}
			else
			{

				using (_fileStream = new FileStream(fileToLoadName, FileMode.Open))
				{
					var fileSize = (int)_fileStream.Length;  // get file length
					_fileBuffer = new byte[fileSize];    // create buffer
					_window = window;

					var offsets = ByteOffsetsPick(SaveVersion);
					// Save Checker			
					var loadChecker = ReadIntegerFromOffset32BitSigned(offsets.SaveChecker);
					if (loadChecker == Constants.SaveFileTag)
						SaveVersion = 3;
					else if (loadChecker == Constants.MegaModTag)
						SaveVersion = 2;
					else if (loadChecker == Constants.SaveTagHD)
						SaveVersion = 1;
					else
						SaveVersion = 0;

					CoordinatesRead();
					SummaryRead();
				}
			}
		}

		public void Save(string fileToWriteToName, Main window)
		{
			using (_fileStream = new FileStream(fileToWriteToName, FileMode.OpenOrCreate))
			{
				var fileSize = (int)_fileStream.Length;  // get file length
				_fileBuffer = new byte[fileSize];    // create buffer
				_window = window;

				SummaryWrite();
				CoordinatesWrite();
			}
		}

		// Helpers.

		private IOffsets ByteOffsetsPick(byte saveVersion)
		{
			switch (saveVersion)
			{
				case 0:
					return OffsetsHighDefinitionRemasterMinus48.Instance;
				case 1:
					return OffsetsHighDefinitionRemaster.Instance;
				case 2:
					return OffsetsMegaMod.Instance;
				case 3:
					return OffsetsCore.Instance;
				default:
					return OffsetsHighDefinitionRemasterMinus48.Instance;
			}
		}

		private void CoordinatesRead()
		{
			var offsets = ByteOffsetsPick(SaveVersion);

			decimal LogX = LogXToUniverse(
				ReadIntegerFromOffset32BitSigned(
					offsets.LogX
				)
			);
			_window.UniverseX.Value = LogX / 10;

			decimal LogY = LogYToUniverse(
				ReadIntegerFromOffset32BitSigned(
					offsets.LogY
				)
			);
			_window.UniverseY.Value = LogY / 10;

			var statusAsByte = ReadByteFromOffset(offsets.Status);

			if (statusAsByte < 0 || statusAsByte >= Constants.StatusNames.Length)
			{
				_window.CurrentStatus.SelectedIndex = 9;
			}
			else
			{
				_window.CurrentStatus.SelectedIndex = statusAsByte;
			}

			// Planet Orbit
			if (statusAsByte == 7 || statusAsByte == 8)
			{
				var planet = Encoding.Default.GetString(
					ReadBytesFromOffsetWithLength(
						offsets.NearestPlanet,
						16
					)
				);
				_window.NearestPlanet.Text = planet;
			}
			else
			{
				_window.NearestPlanet.Text = "Not In Orbit";
			}
		}

		private void CoordinatesWrite()
		{
			var universeX = _window.UniverseX.Value * 10;
			var offsets = ByteOffsetsPick(SaveVersion);
			var xOrY = UniverseToLogX(decimal.ToInt32(universeX));
			WriteDecimalToOffsetWithLengthAndMaxSigned32Bit(
				valueToWrite: xOrY,
				offsets.LogX,
				valueMax: 159735
			);

			var universeY = _window.UniverseY.Value * 10;
			xOrY = UniverseToLogY(decimal.ToInt32(universeY));
			WriteDecimalToOffsetWithLengthAndMaxSigned32Bit(
				valueToWrite: xOrY,
				offsets.LogY,
				valueMax: 191990
			);
		}

		public string GetTitleText()
		{
			string returnValue;

			switch (SaveVersion)
			{
				case 0:
					returnValue = ": Core v0.7.0 - ";
					break;
				case 1:
					returnValue = ": HD-mod v0.7.0 - ";
					break;
				case 2:
					returnValue = ": MegaMod v0.8.0.85 - ";
					break;
				case 3:
					returnValue = ": Core v0.8.0 - ";
					break;
				default:
					returnValue = "";
					break;
			}
			return returnValue;
		}

	private byte[] StringToByteArray(string stringToConvert, int maxLength)
		{
			var charArr = stringToConvert.ToCharArray();
			var bytes = new byte[maxLength];
			for (var i = 0; i < maxLength; i++)
			{
				bytes[i] =
					(i < charArr.Length)
					? Convert.ToByte(charArr[i])
					: (byte)0;
			}
			return bytes;
		}

		private int ChooseBewtweenValuesBasedOnSaveVersion(int valueOld, int valueNew)
		{
			return
				(SaveVersion == 0 || SaveVersion == 3)
				? valueOld
				: valueNew;
		}

		private int LogXToUniverse(int logX)
		{
			var universeUnits = ChooseBewtweenValuesBasedOnSaveVersion(
				Constants.UniverseUnitsOld, Constants.UniverseUnits
			);
			var logUnits = ChooseBewtweenValuesBasedOnSaveVersion(
				Constants.LogUnitsXOld, Constants.LogUnits
			);
			return (logX * universeUnits + RoundIntegerDown(logUnits)) / logUnits;
		}
		private int LogYToUniverse(int logY)
		{
			int logUnits =
				ChooseBewtweenValuesBasedOnSaveVersion(
					Constants.LogUnitsYOld, Constants.LogUnits
				);

			var returnValue =
				Constants.MaxUniverse
				-
				(
					(logY * Constants.UniverseUnits + RoundIntegerDown(logUnits))
					/ logUnits
				);

			return returnValue;
		}

		private byte ReadByteFromOffset(int offsetInBytes)
		{
			return ReadBytesFromOffsetWithLength(offsetInBytes, 1)[0];
		}

		private byte[] ReadBytesFromOffsetWithLength(
			int offsetInBytes, int lengthInBytes
		)
		{
			_fileStream.Seek(offsetInBytes, SeekOrigin.Begin);
			_fileStream.Read(_fileBuffer, 0, lengthInBytes);
			return _fileBuffer;
		}

		private int ReadIntegerFromOffsetWithLength(
			int offsetInBytes,
			int lengthInBytes,
			bool convertToUnsigned16BitNotSigned32BitInteger = false
		)
		{
			var bytesRead = ReadBytesFromOffsetWithLength(offsetInBytes, lengthInBytes);
			int query =
				convertToUnsigned16BitNotSigned32BitInteger
				? BitConverter.ToUInt16(bytesRead, 0)
				: BitConverter.ToInt32(bytesRead, 0);
			return query;
		}

		private int ReadIntegerFromOffsetWithLength16BitUnsigned(
			int offsetInBytes,
			int lengthInBytes
		)
		{
			return ReadIntegerFromOffsetWithLength(
				offsetInBytes, lengthInBytes, convertToUnsigned16BitNotSigned32BitInteger: true
			);
		}

		private int ReadIntegerFromOffset32BitSigned(
			int offsetInBytes
		)
		{
			return ReadIntegerFromOffsetWithLength(
				offsetInBytes, lengthInBytes: 4, convertToUnsigned16BitNotSigned32BitInteger: false
			);
		}

		private int RoundIntegerDown(int integerToRound)
		{
			return (integerToRound >> 1);
		}

		private void SummaryRead()
		{
			var offsets = ByteOffsetsPick(SaveVersion);

			if (SaveVersion >= 2)
			{
				var magic = ReadIntegerFromOffset32BitSigned(offsets.SaveNameMagic);
				var nameSize = (magic - 160);

				SaveName = Encoding.Default.GetString(
					ReadBytesFromOffsetWithLength(
						offsets.SaveName,
						nameSize
					)
				);
			}
			else if (SaveVersion == 1)
			{
				SaveName = Encoding.Default.GetString(
					ReadBytesFromOffsetWithLength(
						offsets.SaveName,
						lengthInBytes: 31
					)
				);
			}
			else
			{
				SaveName = "Saved Game - Date: ";
			}

			_window.ResourceUnits.Value = ReadIntegerFromOffset32BitSigned(offsets.ResourceUnits);

			var fuel = ReadIntegerFromOffset32BitSigned(offsets.Fuel);
			const int fuelMax = 160100;
			fuel = fuel > fuelMax ? fuelMax : fuel;
			_window.ShipFuel.Value = fuel / 100;

			_window.FlagshipCrew.Value = ReadIntegerFromOffsetWithLength16BitUnsigned(
				offsets.FlagshipCrew,
				lengthInBytes: 4
			);

			_window.BioData.Value = ReadIntegerFromOffsetWithLength16BitUnsigned(
				offsets.BioData,
				lengthInBytes: 2
			);

			// Modules
			var modules =
				ReadBytesFromOffsetWithLength(
					offsets.ModuleSlots,
					lengthInBytes: 16
				);
			var moduleCount = 0;
			foreach (var modulesControl in _window.ModulesBox.Controls)
			{
				if (modulesControl is ComboBox)
				{
					var modulesComboBox = modulesControl as ComboBox;
					if (modules[moduleCount] < 20)
					{
						modulesComboBox.SelectedIndex = modules[moduleCount] - 2;
					}
					else
					{
						modulesComboBox.SelectedIndex = 0;
					}
					moduleCount++;
				}
			}

			var thrustersAsBytes =
				ReadBytesFromOffsetWithLength(
					offsets.ThrusterSlots[0],
					lengthInBytes: 11
				);

			var thrustersCount = 0;
			foreach (var thrustersControl in _window.ThrusterBox.Controls)
			{
				if (thrustersControl is CheckBox)
				{
					(thrustersControl as CheckBox).Checked =
						(thrustersAsBytes[thrustersCount] == 1);
					thrustersCount++;
				}
			}

			var turningJetsAsBytes =
				ReadBytesFromOffsetWithLength(
					offsets.TurningJetSlots[0],
					lengthInBytes: 8
				);

			var turningJetsCount = 0;
			foreach (var turningJetsControl in _window.JetsBox.Controls)
			{
				if (turningJetsControl is CheckBox)
				{
					(turningJetsControl as CheckBox).Checked =
						(turningJetsAsBytes[turningJetsCount] == 2);
					turningJetsCount++;
				}
			}

			_window.Landers.Value = ReadByteFromOffset(offsets.Landers);

			// Cargo.
			_window.Minerals_CommonElements.Value =
				ReadIntegerFromOffsetWithLength16BitUnsigned(
					offsets.Minerals_CommonElements,
					lengthInBytes: 2
				);

			_window.Minerals_Corrosives.Value =
				ReadIntegerFromOffsetWithLength16BitUnsigned(
					offsets.Minerals_Corrosives,
					lengthInBytes: 2
				);

			_window.Minerals_BaseMetals.Value =
				ReadIntegerFromOffsetWithLength16BitUnsigned(
					offsets.Minerals_BaseMetals,
					lengthInBytes: 2
				);

			_window.Minerals_NobleGases.Value =
				ReadIntegerFromOffsetWithLength16BitUnsigned(
					offsets.Minerals_NobleGases,
					lengthInBytes: 2
				);

			_window.Minerals_RareEarths.Value =
				ReadIntegerFromOffsetWithLength16BitUnsigned(
					offsets.Minerals_RareEarths,
					lengthInBytes: 2
				);

			_window.Minerals_PreciousMetals.Value =
				ReadIntegerFromOffsetWithLength16BitUnsigned(
					offsets.Minerals_PreciousMetals,
					lengthInBytes: 2
				);

			_window.Minerals_Radioactives.Value =
				ReadIntegerFromOffsetWithLength16BitUnsigned(
					offsets.Minerals_Radioactives,
					lengthInBytes: 2
				);

			_window.Minerals_Exotics.Value =
				ReadIntegerFromOffsetWithLength16BitUnsigned(
					offsets.Minerals_Exotics,
					lengthInBytes: 2
				);

			_window.ShipName.Text =
				Encoding.Default.GetString(
					ReadBytesFromOffsetWithLength(
						offsets.ShipName,
						lengthInBytes: 16
					)
				);

			_window.CommanderName.Text =
				Encoding.Default.GetString(
					ReadBytesFromOffsetWithLength(
						offsets.CaptainName,
						lengthInBytes: 16
					)
				);

			//  Lander Mods
			byte landerModificationsAsByte =
				ReadByteFromOffset(offsets.LanderModifications);
			var landerModifications = LanderModifications.fromByte(landerModificationsAsByte);

			_window.LanderModifications_BioShield.Checked = landerModifications.BioShield;
			_window.LanderModifications_QuakeShield.Checked = landerModifications.QuakeShield;
			_window.LanderModifications_LightningShield.Checked = landerModifications.LightningShield;
			_window.LanderModifications_HeatShield.Checked = landerModifications.HeatShield;
			_window.LanderModifications_DoubleSpeed.Checked = landerModifications.DoubleSpeed;
			_window.LanderModifications_DoubleCargo.Checked = landerModifications.DoubleCargo;
			_window.LanderModifications_RapidFire.Checked = landerModifications.RapidFire;
			_window.LanderModifications_DisplacedByBomb.Checked = landerModifications.DisplacedByBomb;

			// Time & Date
			var day = ReadByteFromOffset(offsets.Date[0]);
			var month = ReadByteFromOffset(offsets.Date[1]);
			var year = ReadIntegerFromOffsetWithLength16BitUnsigned(
				offsets.Date[2],
				lengthInBytes: 2
			);

			Date =
				CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(month).ToUpper()
				+ " " + day
				+ "·" + year;

			_window.Credits.Text = ReadIntegerFromOffsetWithLength16BitUnsigned(
				offsets.Credits,
				lengthInBytes: 2
			).ToString();

			var escortShipsCountAsRead = ReadByteFromOffset(offsets.Escorts[0]);
			var escortShipsAsBytes =
				ReadBytesFromOffsetWithLength(
					offsets.Escorts[1],
					escortShipsCountAsRead
				);

			var escortShipsCountAsCounted = 0;
			foreach (var shipsControl in _window.ShipsBox.Controls)
			{
				if (shipsControl is ComboBox)
				{
					var shipsComboBox = shipsControl as ComboBox;

					if (escortShipsCountAsCounted < escortShipsCountAsRead)
					{
						if
						(
							escortShipsAsBytes[escortShipsCountAsCounted] < Constants.ShipNames.Length
							&& escortShipsAsBytes[escortShipsCountAsCounted] >= 0
						)
						{
							shipsComboBox.SelectedIndex =
								escortShipsAsBytes[escortShipsCountAsCounted];
						}
						else
						{
							shipsComboBox.SelectedIndex = 24;
						}
						escortShipsCountAsCounted++;
					}
					else
					{
						shipsComboBox.SelectedIndex = 24;
					}
				}
			}

			var devicesCount = ReadByteFromOffset(offsets.Devices[0]);

			var devicesAsObjects = new object[devicesCount];
			var devicesAsBytes =
				ReadBytesFromOffsetWithLength(
					offsets.Devices[1],
					devicesCount
				);

			for (var i = 0; i < devicesCount; i++)
			{
				if (devicesAsBytes[i] < 0 || devicesAsBytes[i] >= Constants.DeviceNames.Length)
				{
					devicesAsObjects[i] = "Please report this [0x" + devicesAsBytes[i].ToString("X2") + "]";
				}
				else
				{
					devicesAsObjects[i] = Constants.DeviceNames[devicesAsBytes[i]];
				}
			}
			_window.Devices.Items.Clear();
			_window.Devices.Items.AddRange(devicesAsObjects);

			// Custom Seed
			if (SaveVersion == 2)
			{
				_window.difficultyBox.SelectedIndex =
					ReadByteFromOffset(offsets.Difficulty);

				_window.extendedCheckBox.Checked =
					Convert.ToBoolean(
						ReadByteFromOffset(offsets.Extended)
					);

				_window.nomadCheckBox.Checked =
					Convert.ToBoolean(
						ReadByteFromOffset(offsets.Nomad)
					);

				_window.CustomSeed.Text = ReadIntegerFromOffset32BitSigned(
					offsets.CustomSeed
				).ToString();
			}
		}

		private void SummaryWrite()
		{
			var offsets = ByteOffsetsPick(SaveVersion);

			WriteDecimalToOffsetWithLengthAndMaxUnsigned32Bit(
				valueToWrite: _window.ResourceUnits.Value,
				offsets.ResourceUnits,
				valueMax: 0xFFFFFFFF
			);

			var fuel = _window.ShipFuel.Value * 100;
			WriteDecimalToOffsetWithLengthAndMaxUnsigned32Bit(
				valueToWrite: decimal.ToUInt32(fuel),
				offsets.Fuel,
				valueMax: 161000
			);

			WriteDecimalToOffsetWithLengthAndMaxUnsigned16Bit(
				valueToWrite: _window.FlagshipCrew.Value,
				offsets.FlagshipCrew,
				valueMax: 800
			);

			WriteDecimalToOffsetWithLengthAndMaxUnsigned16Bit(
				valueToWrite: _window.TotalMinerals.Value,
				offsets.TotalMinerals,
				valueMax: 8000
			);

			WriteDecimalToOffsetWithLengthAndMaxUnsigned16Bit(
				valueToWrite: _window.BioData.Value,
				offsets.BioData,
				valueMax: 0xFFFF
			);

			// Modules
			byte moduleAsByte, i = 0;
			foreach (var modulesControl in _window.ModulesBox.Controls)
			{
				if (modulesControl is ComboBox)
				{
					int modulePresentCode = (modulesControl as ComboBox).SelectedIndex;
					if (modulePresentCode > 0)
					{
						moduleAsByte = (byte)(modulePresentCode + 2);
					}
					else
					{
						moduleAsByte = 22;
					}
					WriteDecimalToOffsetWithLengthAndMaxUnsigned(
						valueToWrite: moduleAsByte,
						offsets.ModuleSlots + i,
						lengthInBytes: 1,
						valueMax: 22
					);
					i++;
				}
			}

			// Thrusters
			byte thrustersAsByte, j = 0;
			foreach (var thrusterControl in _window.ThrusterBox.Controls)
			{
				if (thrusterControl is CheckBox)
				{
					var thrusterIsPresent = (thrusterControl as CheckBox).Checked;
					thrustersAsByte = (byte)(thrusterIsPresent ? 1 : 20);
					WriteDecimalToOffsetWithLengthAndMaxUnsigned(
						offsets.ThrusterSlots[j],
						thrustersAsByte,
						lengthInBytes: 1,
						valueMax: 20
					);
					j++;
				}
			}

			byte turningJetAsByte, k = 0;
			foreach (var turningJetControl in _window.JetsBox.Controls)
			{
				if (turningJetControl is CheckBox)
				{
					var turningJetIsPresent = (turningJetControl as CheckBox).Checked;
					turningJetAsByte = (byte)(turningJetIsPresent ? 2 : 21);
					WriteDecimalToOffsetWithLengthAndMaxUnsigned(
						offsets.TurningJetSlots[k],
						turningJetAsByte,
						lengthInBytes: 1,
						valueMax: 21
					);
					k++;
				}
			}

			WriteDecimalToOffsetWithLengthAndMaxSigned(
				_window.Landers.Value,
				offsets.Landers,
				lengthInBytes: 1,
				valueMax: 10
			);

			// Cargo.
			WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
				_window.Minerals_CommonElements.Value,
				offsets.Minerals_CommonElements,
				valueMax: 0xFFFF
			);

			WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
				_window.Minerals_Corrosives.Value,
				offsets.Minerals_Corrosives,
				valueMax: 0xFFFF
			);

			WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
				_window.Minerals_BaseMetals.Value,
				offsets.Minerals_BaseMetals,
				valueMax: 0xFFFF
			);

			WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
				_window.Minerals_NobleGases.Value,
				offsets.Minerals_NobleGases,
				valueMax: 0xFFFF
			);

			WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
				_window.Minerals_RareEarths.Value,
				offsets.Minerals_RareEarths,
				valueMax: 0xFFFF
			);

			WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
				_window.Minerals_PreciousMetals.Value,
				offsets.Minerals_PreciousMetals,
				valueMax: 0xFFFF
			);

			WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
				_window.Minerals_Radioactives.Value,
				offsets.Minerals_Radioactives,
				valueMax: 0xFFFF
			);

			WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
				_window.Minerals_Exotics.Value,
				offsets.Minerals_Exotics,
				valueMax: 0xFFFF
			);

			WriteStringToOffsetWithLength(
				_window.ShipName.Text,
				offsets.ShipName,
				lengthInBytes: 16
			);

			WriteStringToOffsetWithLength(
				_window.CommanderName.Text,
				offsets.CaptainName,
				lengthInBytes: 16
			);
		}

		private int UniverseToLogX(int universeX)
		{
			universeX -= ChooseBewtweenValuesBasedOnSaveVersion(3, 0);
			var returnValue =
				(
					universeX * Constants.LogUnits
					+ RoundIntegerDown(Constants.UniverseUnits)
				)
				/ Constants.UniverseUnits;
			return returnValue;
		}
		private int UniverseToLogY(int universeY)
		{
			int logUnits = ChooseBewtweenValuesBasedOnSaveVersion(
				Constants.LogUnitsYOld, Constants.LogUnits
			);
			var returnValue =
				(
					(Constants.MaxUniverse - universeY)
					* logUnits
					+ RoundIntegerDown(Constants.UniverseUnits)
				)
				/ Constants.UniverseUnits;
			return returnValue;
		}

		private void WriteDecimalToOffsetWithLengthAndMax(
			decimal valueToWrite,
			int offsetToWriteToInBytes,
			int lengthInBytes,
			uint valueMax,
			bool isUnsignedNotSigned = false
		)
		{
			_fileStream.Seek(offsetToWriteToInBytes, SeekOrigin.Begin);
			if (isUnsignedNotSigned)
			{
				var valueToWriteAsUnsignedInt = decimal.ToUInt32(valueToWrite);
				if (valueToWriteAsUnsignedInt >= valueMax)
				{
					valueToWriteAsUnsignedInt = valueMax;
				}
				_fileBuffer = BitConverter.GetBytes(valueToWriteAsUnsignedInt);
			}
			else
			{
				var valueToWriteAsSignedInt = decimal.ToInt32(valueToWrite);
				if (valueToWriteAsSignedInt >= valueMax)
				{
					valueToWriteAsSignedInt = (int)valueMax;
				}
				_fileBuffer = BitConverter.GetBytes(valueToWriteAsSignedInt);
			}
			_fileStream.Write(_fileBuffer, 0, lengthInBytes);
		}

		private void WriteDecimalToOffsetWithLengthAndMaxSigned(
			decimal valueToWrite,
			int offsetInBytesToWriteTo,
			int lengthInBytes,
			uint valueMax
		)
		{
			WriteDecimalToOffsetWithLengthAndMax(
				valueToWrite, offsetInBytesToWriteTo, lengthInBytes, valueMax, isUnsignedNotSigned: false
			);
		}

		private void WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
			decimal valueToWrite,
			int offsetInBytesToWriteTo,
			uint valueMax
		)
		{
			WriteDecimalToOffsetWithLengthAndMaxSigned(
				valueToWrite, offsetInBytesToWriteTo, lengthInBytes: 2, valueMax
			);
		}

		private void WriteDecimalToOffsetWithLengthAndMaxSigned32Bit(
			decimal valueToWrite,
			int offsetInBytesToWriteTo,
			uint valueMax
		)
		{
			WriteDecimalToOffsetWithLengthAndMaxSigned(
				valueToWrite, offsetInBytesToWriteTo, lengthInBytes: 4, valueMax
			);
		}

		private void WriteDecimalToOffsetWithLengthAndMaxUnsigned(
			decimal valueToWrite,
			int offsetInBytesToWriteTo,
			int lengthInBytes,
			uint valueMax
		)
		{
			WriteDecimalToOffsetWithLengthAndMax(
				valueToWrite, offsetInBytesToWriteTo, lengthInBytes, valueMax, isUnsignedNotSigned: true
			);
		}

		private void WriteDecimalToOffsetWithLengthAndMaxUnsigned16Bit(
			decimal valueToWrite,
			int offsetInBytesToWriteTo,
			uint valueMax
		)
		{
			WriteDecimalToOffsetWithLengthAndMaxUnsigned(
				valueToWrite, offsetInBytesToWriteTo, lengthInBytes: 2, valueMax
			);
		}

		private void WriteDecimalToOffsetWithLengthAndMaxUnsigned32Bit(
			decimal valueToWrite,
			int offsetInBytesToWriteTo,
			uint valueMax
		)
		{
			WriteDecimalToOffsetWithLengthAndMaxUnsigned(
				valueToWrite, offsetInBytesToWriteTo, lengthInBytes: 4, valueMax
			);
		}


		public void WriteStringToOffsetWithLength(
			string stringToWrite, int offset, int lengthInBytes
		)
		{
			_fileStream.Seek(offset, SeekOrigin.Begin);
			_fileBuffer = StringToByteArray(stringToWrite, lengthInBytes);
			_fileStream.Write(_fileBuffer, 0, lengthInBytes);
		}
	}

	class LanderModifications
	{
		public bool
			BioShield,
			QuakeShield,
			LightningShield,
			HeatShield,
			DoubleSpeed, 
			DoubleCargo,
			RapidFire,
			DisplacedByBomb;

		public static LanderModifications fromByte(byte landerModificationsAsByte)
		{
			return new LanderModifications()
			{
				BioShield = ParseModificationFlag(landerModificationsAsByte, 0),
				QuakeShield = ParseModificationFlag(landerModificationsAsByte, 1),
				LightningShield = ParseModificationFlag(landerModificationsAsByte, 2),
				HeatShield = ParseModificationFlag(landerModificationsAsByte, 3),
				DoubleSpeed = ParseModificationFlag(landerModificationsAsByte, 4),
				DoubleCargo = ParseModificationFlag(landerModificationsAsByte, 5),
				RapidFire = ParseModificationFlag(landerModificationsAsByte, 6),
				DisplacedByBomb = ParseModificationFlag(landerModificationsAsByte, 7, isBomb: true)
			};
		}

		private static bool ParseModificationFlag(
			byte landerModificationsAsByte, int flagOffsetInBits, bool isBomb = false
		)
		{
			var bitAsMask = (int)Math.Pow(2, flagOffsetInBits);
			return
				isBomb == false
				? ((landerModificationsAsByte | 128) & bitAsMask) != 0
				: (landerModificationsAsByte & bitAsMask) != 0;
		}


	}
}