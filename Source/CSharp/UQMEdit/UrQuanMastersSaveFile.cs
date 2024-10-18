using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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
					var fileSize = (int)_fileStream.Length;
					_fileBuffer = new byte[fileSize];
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

					ReadCoordinates();
					ReadSummary();
					PopulateControlFromFields(_window);
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

				PopulateFieldsFromControl(_window);
				SaveSummary();
				SaveCoordinates();
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

		private void ReadCoordinates()
		{
			var offsets = ByteOffsetsPick(SaveVersion);

			decimal LogX = LogXToUniverse(
				ReadIntegerFromOffset32BitSigned(offsets.LogX)
			);
			UniverseX = LogX / 10;

			decimal LogY = LogYToUniverse(
				ReadIntegerFromOffset32BitSigned(offsets.LogY)
			);
			UniverseY = LogY / 10;

			var statusAsByte = ReadByteFromOffset(offsets.Status);

			if (statusAsByte < 0 || statusAsByte >= Constants.StatusNames.Length)
			{
				CurrentStatus = 9;
			}
			else
			{
				CurrentStatus = statusAsByte;
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
				NearestPlanet = planet;
			}
			else
			{
				NearestPlanet = "Not In Orbit";
			}
		}

		private void SaveCoordinates()
		{
			var universeX = UniverseX * 10;
			var offsets = ByteOffsetsPick(SaveVersion);
			var xOrY = UniverseToLogX(decimal.ToInt32(universeX));
			WriteDecimalToOffsetWithLengthAndMaxSigned32Bit(
				valueToWrite: xOrY,
				offsets.LogX,
				valueMax: 159735
			);

			var universeY = UniverseY * 10;
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
			var bytesRead = new byte[lengthInBytes];
			_fileStream.Seek(offsetInBytes, SeekOrigin.Begin);
			for (var i = 0; i < lengthInBytes; i++)
			{
				bytesRead[i] = (byte)(_fileStream.ReadByte());
			}
			return bytesRead;
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

		public decimal UniverseX, UniverseY;
		public byte CurrentStatus;
		public string NearestPlanet;
		public int ResourceUnits;
		public decimal ShipFuel, FlagshipCrew, BioData;
		public FlagshipModule[] FlagshipModulesAtPositions;
		public bool[] ThrustersArePresentAtPositions;
		public byte LandersCount;
		public int
			Minerals_CommonElements,
			Minerals_Corrosives,
			Minerals_BaseMetals,
			Minerals_NobleGases,
			Minerals_RareEarths,
			Minerals_PreciousMetals,
			Minerals_Radioactives,
			Minerals_Exotics,
			Minerals_Total;
		public string
			ShipName,
			CommanderName;
		public LanderModifications _LanderModifications;
		public int Credits;
		public byte[] EscortShipsAsBytes;
		public object[] DevicesAsObjects;
		public bool[] TurningJetsArePresentAtPositions;
		public byte Difficulty;
		public bool Extended;
		public bool Nomad;
		public int CustomSeed;

		private void ReadSummary()
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

			ResourceUnits = ReadIntegerFromOffset32BitSigned(offsets.ResourceUnits);

			var fuel = ReadIntegerFromOffset32BitSigned(offsets.Fuel);
			const int fuelMax = 160100;
			fuel = fuel > fuelMax ? fuelMax : fuel;
			ShipFuel = fuel / 100;

			FlagshipCrew = ReadIntegerFromOffsetWithLength16BitUnsigned(
				offsets.FlagshipCrew,
				lengthInBytes: 4
			);

			BioData = ReadIntegerFromOffsetWithLength16BitUnsigned(
				offsets.BioData,
				lengthInBytes: 2
			);

			var flagshipModulesAsBytes =
				ReadBytesFromOffsetWithLength(
					offsets.ModuleSlots,
					lengthInBytes: 16
				);

			FlagshipModulesAtPositions =
				flagshipModulesAsBytes.Select(x => FlagshipModule.ByCode(x)).ToArray();

			var thrustersAsBytes =
				ReadBytesFromOffsetWithLength(
					offsets.ThrusterSlots[0],
					lengthInBytes: 11
				);

			ThrustersArePresentAtPositions =
				thrustersAsBytes.Select(x => x == 1).ToArray();

			var turningJetsAsBytes =
				ReadBytesFromOffsetWithLength(
					offsets.TurningJetSlots[0],
					lengthInBytes: 8
				);

			TurningJetsArePresentAtPositions =
				turningJetsAsBytes.Select(x => x == 2).ToArray();

			LandersCount = ReadByteFromOffset(offsets.LandersCount);

			// Cargo.
			Minerals_CommonElements =
				ReadIntegerFromOffsetWithLength16BitUnsigned(
					offsets.Minerals_CommonElements,
					lengthInBytes: 2
				);

			Minerals_Corrosives =
				ReadIntegerFromOffsetWithLength16BitUnsigned(
					offsets.Minerals_Corrosives,
					lengthInBytes: 2
				);

			Minerals_BaseMetals =
				ReadIntegerFromOffsetWithLength16BitUnsigned(
					offsets.Minerals_BaseMetals,
					lengthInBytes: 2
				);

			Minerals_NobleGases =
				ReadIntegerFromOffsetWithLength16BitUnsigned(
					offsets.Minerals_NobleGases,
					lengthInBytes: 2
				);

			Minerals_RareEarths =
				ReadIntegerFromOffsetWithLength16BitUnsigned(
					offsets.Minerals_RareEarths,
					lengthInBytes: 2
				);

			Minerals_PreciousMetals =
				ReadIntegerFromOffsetWithLength16BitUnsigned(
					offsets.Minerals_PreciousMetals,
					lengthInBytes: 2
				);

			Minerals_Radioactives =
				ReadIntegerFromOffsetWithLength16BitUnsigned(
					offsets.Minerals_Radioactives,
					lengthInBytes: 2
				);

			Minerals_Exotics =
				ReadIntegerFromOffsetWithLength16BitUnsigned(
					offsets.Minerals_Exotics,
					lengthInBytes: 2
				);

			ShipName =
				Encoding.Default.GetString(
					ReadBytesFromOffsetWithLength(
						offsets.ShipName,
						lengthInBytes: 16
					)
				);

			CommanderName =
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

			_LanderModifications = landerModifications;

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

			Credits = ReadIntegerFromOffsetWithLength16BitUnsigned(
				offsets.Credits,
				lengthInBytes: 2
			);

			var escortShipsCountAsRead = ReadByteFromOffset(offsets.Escorts[0]);
			var escortShipsAsBytes =
				ReadBytesFromOffsetWithLength(
					offsets.Escorts[1],
					escortShipsCountAsRead
				);

			EscortShipsAsBytes = escortShipsAsBytes;

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
			DevicesAsObjects = devicesAsObjects;

			// Custom Seed
			if (SaveVersion == 2)
			{
				Difficulty =
					ReadByteFromOffset(offsets.Difficulty);

				Extended =
					Convert.ToBoolean(ReadByteFromOffset(offsets.Extended) );

				Nomad =
					Convert.ToBoolean(ReadByteFromOffset(offsets.Nomad) );

				CustomSeed =
					ReadIntegerFromOffset32BitSigned(offsets.CustomSeed);
			}
		}

		private void PopulateFieldsFromControl(Main _window)
		{
			ResourceUnits = (int)_window.ResourceUnits.Value;
			ShipFuel = _window.ShipFuel.Value; // */ 100
			FlagshipCrew = _window.FlagshipCrew.Value;
			Minerals_Total = (int)(_window.Minerals_Total.Value);
			BioData = _window.BioData.Value;

			var modulesPresent = new List<FlagshipModule>();
			foreach (var modulesControl in _window.ModulesBox.Controls)
			{
				if (modulesControl is ComboBox)
				{
					var moduleAsComboBox = modulesControl as ComboBox;
					var modulePresent =
						moduleAsComboBox.SelectedItem as FlagshipModule;
					modulesPresent.Add(modulePresent);
				}
			}

			var thrusterControls = _window.ThrusterBox.Controls;
			var i = 0;
			foreach (var thrusterControl in thrusterControls)
			{
				if (thrusterControl is CheckBox)
				{
					var thrusterIsPresent = (thrusterControl as CheckBox).Checked;
					ThrustersArePresentAtPositions[i] = thrusterIsPresent;
					i++;
				}
			}

			var turningJetControls = _window.TurningJetsBox.Controls;
			i = 0;
			foreach (var turningJetControl in turningJetControls)
			{
				if (turningJetControl is CheckBox)
				{
					var turningJetIsPresent = (turningJetControl as CheckBox).Checked;
					TurningJetsArePresentAtPositions[i] = turningJetIsPresent;
					i++;
				}
			}

			LandersCount = (byte)(_window.LanderCount.Value);

			Minerals_CommonElements = (int)_window.Minerals_CommonElements.Value;
			Minerals_Corrosives = (int)_window.Minerals_Corrosives.Value;
			Minerals_BaseMetals = (int)_window.Minerals_BaseMetals.Value;
			Minerals_NobleGases = (int)_window.Minerals_NobleGases.Value;
			Minerals_PreciousMetals = (int)_window.Minerals_PreciousMetals.Value;
			Minerals_Radioactives = (int)_window.Minerals_Radioactives.Value;
			Minerals_Total = (int)_window.Minerals_Total.Value;

			ShipName = _window.ShipName.Text;

			CommanderName = _window.CommanderName.Text;
		}

		private void SaveSummary()
		{
			var offsets = ByteOffsetsPick(SaveVersion);

			WriteDecimalToOffsetWithLengthAndMaxUnsigned32Bit(
				valueToWrite: ResourceUnits,
				offsets.ResourceUnits,
				valueMax: 0xFFFFFFFF
			);

			WriteDecimalToOffsetWithLengthAndMaxUnsigned32Bit(
				valueToWrite: ShipFuel,
				offsets.Fuel,
				valueMax: 161000
			);

			WriteDecimalToOffsetWithLengthAndMaxUnsigned16Bit(
				valueToWrite: FlagshipCrew,
				offsets.FlagshipCrew,
				valueMax: 800
			);

			WriteDecimalToOffsetWithLengthAndMaxUnsigned16Bit(
				valueToWrite: Minerals_Total,
				offsets.TotalMinerals,
				valueMax: 8000
			);

			WriteDecimalToOffsetWithLengthAndMaxUnsigned16Bit(
				valueToWrite: BioData,
				offsets.BioData,
				valueMax: 0xFFFF
			);

			var modulesAsBytes = FlagshipModulesAtPositions.Select(x => x.Code).ToArray();
			WriteBytesToOffset(modulesAsBytes, offsets.ModuleSlots);

			var thrustersAsBytes =
				ThrustersArePresentAtPositions.Select(x => x ? (byte)1 : (byte)20).ToArray();
			WriteBytesToOffset(thrustersAsBytes, offsets.ThrusterSlots[0]);

			var turningJetsAsBytes =
				TurningJetsArePresentAtPositions.Select(x => x ? (byte)2 : (byte)21).ToArray();
			WriteBytesToOffset(turningJetsAsBytes, offsets.TurningJetSlots[0]);

			WriteDecimalToOffsetWithLengthAndMaxSigned(
				LandersCount,
				offsets.LandersCount,
				lengthInBytes: 1,
				valueMax: 10
			);

			// Cargo.
			WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
				Minerals_CommonElements,
				offsets.Minerals_CommonElements,
				valueMax: 0xFFFF
			);

			WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
				Minerals_Corrosives,
				offsets.Minerals_Corrosives,
				valueMax: 0xFFFF
			);

			WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
				Minerals_BaseMetals,
				offsets.Minerals_BaseMetals,
				valueMax: 0xFFFF
			);

			WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
				Minerals_NobleGases,
				offsets.Minerals_NobleGases,
				valueMax: 0xFFFF
			);

			WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
				Minerals_RareEarths,
				offsets.Minerals_RareEarths,
				valueMax: 0xFFFF
			);

			WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
				Minerals_PreciousMetals,
				offsets.Minerals_PreciousMetals,
				valueMax: 0xFFFF
			);

			WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
				Minerals_Radioactives,
				offsets.Minerals_Radioactives,
				valueMax: 0xFFFF
			);

			WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
				Minerals_Exotics,
				offsets.Minerals_Exotics,
				valueMax: 0xFFFF
			);

			WriteStringToOffsetWithLength(
				ShipName,
				offsets.ShipName,
				lengthInBytes: 16
			);

			WriteStringToOffsetWithLength(
				CommanderName,
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

		private void WriteBytesToOffset(
			byte[] bytesToWrite,
			int offsetToWriteToInBytes
		)
		{
			_fileStream.Seek(offsetToWriteToInBytes, SeekOrigin.Begin);
			foreach (var byteToWrite in bytesToWrite)
			{
				_fileStream.WriteByte(byteToWrite);
			}
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

		// Controls.

		private void PopulateControlFromFields(Main _window)
		{
			_window.UniverseX.Value = UniverseX;
			_window.UniverseY.Value = UniverseY;
			_window.CurrentStatus.SelectedIndex = CurrentStatus;
			_window.NearestPlanet.Text = NearestPlanet;
			_window.ResourceUnits.Value = ResourceUnits;
			_window.ShipFuel.Value = ShipFuel;
			_window.FlagshipCrew.Value = FlagshipCrew;
			_window.BioData.Value = BioData;

			var flagshipModuleCount = 0;
			var flagshipModulesAtPositions = FlagshipModulesAtPositions;
			foreach (var modulesControl in _window.ModulesBox.Controls)
			{
				if (modulesControl is ComboBox)
				{
					var modulesComboBox = modulesControl as ComboBox;
					if (flagshipModulesAtPositions[flagshipModuleCount] != FlagshipModule.Instances.Empty)
					{
						modulesComboBox.SelectedIndex =
							flagshipModulesAtPositions[flagshipModuleCount].Code - 2;
					}
					else
					{
						modulesComboBox.SelectedIndex = 0;
					}
					flagshipModuleCount++;
				}
			}

			var thrustersCount = 0;
			foreach (var thrustersControl in _window.ThrusterBox.Controls)
			{
				if (thrustersControl is CheckBox)
				{
					(thrustersControl as CheckBox).Checked =
						(ThrustersArePresentAtPositions[thrustersCount]);
					thrustersCount++;
				}
			}

			var turningJetsCount = 0;
			foreach (var turningJetControl in _window.TurningJetsBox.Controls)
			{
				if (turningJetControl is CheckBox)
				{
					(turningJetControl as CheckBox).Checked =
						(TurningJetsArePresentAtPositions[turningJetsCount]);
					turningJetsCount++;
				}
			}

			_window.LanderCount.Value = LandersCount;

			_window.Minerals_CommonElements.Value = Minerals_CommonElements;
			_window.Minerals_Corrosives.Value = Minerals_Corrosives;
			_window.Minerals_BaseMetals.Value = Minerals_BaseMetals;
			_window.Minerals_NobleGases.Value = Minerals_NobleGases;
			_window.Minerals_RareEarths.Value = Minerals_RareEarths;
			_window.Minerals_PreciousMetals.Value = Minerals_PreciousMetals;
			_window.Minerals_Radioactives.Value = Minerals_Radioactives;
			_window.Minerals_Exotics.Value = Minerals_Exotics;
			_window.ShipName.Text = ShipName;
			_window.CommanderName.Text = CommanderName;

			var landerModifications = _LanderModifications;

			_window.LanderModifications_BioShield.Checked = landerModifications.BioShield;
			_window.LanderModifications_QuakeShield.Checked = landerModifications.QuakeShield;
			_window.LanderModifications_LightningShield.Checked = landerModifications.LightningShield;
			_window.LanderModifications_HeatShield.Checked = landerModifications.HeatShield;
			_window.LanderModifications_DoubleSpeed.Checked = landerModifications.DoubleSpeed;
			_window.LanderModifications_DoubleCargo.Checked = landerModifications.DoubleCargo;
			_window.LanderModifications_RapidFire.Checked = landerModifications.RapidFire;
			_window.LanderModifications_DisplacedByBomb.Checked = landerModifications.DisplacedByBomb;

			_window.Credits.Text = Credits.ToString();

			var escortShipsAsBytes = EscortShipsAsBytes;
			var escortShipsCountAsRead = escortShipsAsBytes.Length; // todo

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

			_window.Devices.Items.Clear();
			_window.Devices.Items.AddRange(DevicesAsObjects);

			_window.difficultyBox.SelectedIndex = Difficulty;
			_window.extendedCheckBox.Checked = Extended;
			_window.nomadCheckBox.Checked = Nomad;
			_window.CustomSeed.Text = CustomSeed.ToString();

		}

		// Inner classes.

		public class FlagshipModule
		{
			public byte Code;
			public string Name;

			public FlagshipModule(byte code, string name)
			{
				Code = code;
				Name = name;
			}

			public static class Instances
			{
				public static FlagshipModule
					Empty						= new FlagshipModule(22, "Empty"),
					CrewPod						= new FlagshipModule(3, "Crew Pod"),
					StorageBay					= new FlagshipModule(4, "Storage Bay"),
					FuelTank					= new FlagshipModule(5, "Fuel Tank"),
					HighEfficiencyFuelSystem	= new FlagshipModule(6, "High-Eff FuelSys"),
					DynamoUnit					= new FlagshipModule(7, "Dynamo Unit"),
					ShivaFurnace				= new FlagshipModule(8, "Shiva Furnace"),
					IonBoltGun					= new FlagshipModule(9, "Ion-Bolt Gun"),
					FusionBlaster				= new FlagshipModule(10, "Fusion Blaster"),
					HellboreCannon				= new FlagshipModule(11, "Hellbore Cannon"),
					TrackingSystem				= new FlagshipModule(12, "Tracking System"),
					PointDefense				= new FlagshipModule(13, "Point Defense"),

					BombPart1					= new FlagshipModule(14, "Bomb Part 1"),
					BombPart2					= new FlagshipModule(15, "Bomb Part 2"),
					CrystalPart1				= new FlagshipModule(16, "Crystal Part 1"),
					CrystalPart2				= new FlagshipModule(17, "Crystal Part 2"),
					CrystalPart3				= new FlagshipModule(18, "Crystal Part 3"),
					CrystalPart4				= new FlagshipModule(19, "Crystal Part 4");


				public static FlagshipModule[] _All = new FlagshipModule[]
				{
					Empty,
					CrewPod,
					StorageBay,
					FuelTank,
					HighEfficiencyFuelSystem,
					DynamoUnit,
					ShivaFurnace,
					IonBoltGun,
					FusionBlaster,
					HellboreCannon,
					TrackingSystem,
					PointDefense,

					BombPart1,
					BombPart2,
					CrystalPart1,
					CrystalPart2,
					CrystalPart3,
					CrystalPart4,
				};

			}

			public static FlagshipModule ByCode(byte code)
			{
				return Instances._All.Single(x => x.Code == code);
			}
		}

		public class LanderModifications
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
}