using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace UrQuanMastersSaveEditor
{
	partial class GameState
	{
		public static GameState Instance = new GameState();

		public string Date = "";
		public string SaveName;
		public byte SaveVersion = 0;

		public void Open(string fileToLoadName) {

			using (var reader = new ByteStreamReader(fileToLoadName) )
			{
				var offsets = ByteOffsetsPick(SaveVersion);
				// Save Checker			
				var loadChecker = reader.ReadIntegerFromOffset32BitSigned(offsets.SaveChecker);
				if (loadChecker == Constants.SaveFileTag)
					SaveVersion = 3;
				else if (loadChecker == Constants.MegaModTag)
					SaveVersion = 2;
				else if (loadChecker == Constants.SaveTagHD)
					SaveVersion = 1;
				else
					SaveVersion = 0;

				ReadCoordinates(reader);
				ReadSummary(reader);
			}
		}

		public void Save(string fileToWriteToName, Main window)
		{
			using (var writer = new ByteStreamWriter(fileToWriteToName) )
			{
				var controller = new UserInterfaceController(window, this);
				controller.PopulateGameStateFromControl();
				SaveSummary(writer);
				SaveCoordinates(writer);
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

		private void ReadCoordinates(ByteStreamReader reader)
		{
			var offsets = ByteOffsetsPick(SaveVersion);

			decimal LogX = LogXToUniverse(
				reader.ReadIntegerFromOffset32BitSigned(offsets.LogX)
			);
			UniverseX = LogX / 10;

			decimal LogY = LogYToUniverse(
				reader.ReadIntegerFromOffset32BitSigned(offsets.LogY)
			);
			UniverseY = LogY / 10;

			var statusAsByte = reader.ReadByteFromOffset(offsets.Status);

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
					reader.ReadBytesFromOffsetWithLength(
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

		private void SaveCoordinates(ByteStreamWriter writer)
		{
			var universeX = UniverseX * 10;
			var offsets = ByteOffsetsPick(SaveVersion);
			var xOrY = UniverseToLogX(decimal.ToInt32(universeX));
			writer.WriteDecimalToOffsetWithLengthAndMaxSigned32Bit(
				valueToWrite: xOrY,
				offsets.LogX,
				valueMax: 159735
			);

			var universeY = UniverseY * 10;
			xOrY = UniverseToLogY(decimal.ToInt32(universeY));
			writer.WriteDecimalToOffsetWithLengthAndMaxSigned32Bit(
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

		private void ReadSummary(ByteStreamReader reader)
		{
			var offsets = ByteOffsetsPick(SaveVersion);

			if (SaveVersion >= 2)
			{
				var magic = reader.ReadIntegerFromOffset32BitSigned(offsets.SaveNameMagic);
				var nameSize = (magic - 160);

				SaveName = Encoding.Default.GetString(
					reader.ReadBytesFromOffsetWithLength(
						offsets.SaveName,
						nameSize
					)
				);
			}
			else if (SaveVersion == 1)
			{
				SaveName = Encoding.Default.GetString(
					reader.ReadBytesFromOffsetWithLength(
						offsets.SaveName,
						lengthInBytes: 31
					)
				);
			}
			else
			{
				SaveName = "Saved Game - Date: ";
			}

			ResourceUnits = reader.ReadIntegerFromOffset32BitSigned(offsets.ResourceUnits);

			var fuel = reader.ReadIntegerFromOffset32BitSigned(offsets.Fuel);
			const int fuelMax = 160100;
			fuel = fuel > fuelMax ? fuelMax : fuel;
			ShipFuel = fuel / 100;

			FlagshipCrew = reader.ReadIntegerFromOffsetWithLength16BitUnsigned(
				offsets.FlagshipCrew,
				lengthInBytes: 4
			);

			BioData = reader.ReadIntegerFromOffsetWithLength16BitUnsigned(
				offsets.BioData,
				lengthInBytes: 2
			);

			var flagshipModulesAsBytes =
				reader.ReadBytesFromOffsetWithLength(
					offsets.ModuleSlots,
					lengthInBytes: 16
				);

			FlagshipModulesAtPositions =
				flagshipModulesAsBytes.Select(x => FlagshipModule.ByCode(x)).ToArray();

			var thrustersAsBytes =
				reader.ReadBytesFromOffsetWithLength(
					offsets.ThrusterSlots[0],
					lengthInBytes: 11
				);

			ThrustersArePresentAtPositions =
				thrustersAsBytes.Select(x => x == 1).ToArray();

			var turningJetsAsBytes =
				reader.ReadBytesFromOffsetWithLength(
					offsets.TurningJetSlots[0],
					lengthInBytes: 8
				);

			TurningJetsArePresentAtPositions =
				turningJetsAsBytes.Select(x => x == 2).ToArray();

			LandersCount = reader.ReadByteFromOffset(offsets.LandersCount);

			// Cargo.
			Minerals_CommonElements =
				reader.ReadIntegerFromOffsetWithLength16BitUnsigned(
					offsets.Minerals_CommonElements,
					lengthInBytes: 2
				);

			Minerals_Corrosives =
				reader.ReadIntegerFromOffsetWithLength16BitUnsigned(
					offsets.Minerals_Corrosives,
					lengthInBytes: 2
				);

			Minerals_BaseMetals =
				reader.ReadIntegerFromOffsetWithLength16BitUnsigned(
					offsets.Minerals_BaseMetals,
					lengthInBytes: 2
				);

			Minerals_NobleGases =
				reader.ReadIntegerFromOffsetWithLength16BitUnsigned(
					offsets.Minerals_NobleGases,
					lengthInBytes: 2
				);

			Minerals_RareEarths =
				reader.ReadIntegerFromOffsetWithLength16BitUnsigned(
					offsets.Minerals_RareEarths,
					lengthInBytes: 2
				);

			Minerals_PreciousMetals =
				reader.ReadIntegerFromOffsetWithLength16BitUnsigned(
					offsets.Minerals_PreciousMetals,
					lengthInBytes: 2
				);

			Minerals_Radioactives =
				reader.ReadIntegerFromOffsetWithLength16BitUnsigned(
					offsets.Minerals_Radioactives,
					lengthInBytes: 2
				);

			Minerals_Exotics =
				reader.ReadIntegerFromOffsetWithLength16BitUnsigned(
					offsets.Minerals_Exotics,
					lengthInBytes: 2
				);

			ShipName =
				Encoding.Default.GetString(
					reader.ReadBytesFromOffsetWithLength(
						offsets.ShipName,
						lengthInBytes: 16
					)
				);

			CommanderName =
				Encoding.Default.GetString(
					reader.ReadBytesFromOffsetWithLength(
						offsets.CaptainName,
						lengthInBytes: 16
					)
				);

			//  Lander Mods
			byte landerModificationsAsByte =
				reader.ReadByteFromOffset(offsets.LanderModifications);
			var landerModifications = LanderModifications.fromByte(landerModificationsAsByte);

			_LanderModifications = landerModifications;

			// Time & Date
			var day = reader.ReadByteFromOffset(offsets.Date[0]);
			var month = reader.ReadByteFromOffset(offsets.Date[1]);
			var year = reader.ReadIntegerFromOffsetWithLength16BitUnsigned(
				offsets.Date[2],
				lengthInBytes: 2
			);

			Date =
				CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(month).ToUpper()
				+ " " + day
				+ "·" + year;

			Credits = reader.ReadIntegerFromOffsetWithLength16BitUnsigned(
				offsets.Credits,
				lengthInBytes: 2
			);

			var escortShipsCountAsRead = reader.ReadByteFromOffset(offsets.Escorts[0]);
			var escortShipsAsBytes =
				reader.ReadBytesFromOffsetWithLength(
					offsets.Escorts[1],
					escortShipsCountAsRead
				);

			EscortShipsAsBytes = escortShipsAsBytes;

			var devicesCount = reader.ReadByteFromOffset(offsets.Devices[0]);

			var devicesAsObjects = new object[devicesCount];
			var devicesAsBytes =
				reader.ReadBytesFromOffsetWithLength(
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
					reader.ReadByteFromOffset(offsets.Difficulty);

				Extended =
					Convert.ToBoolean(reader.ReadByteFromOffset(offsets.Extended) );

				Nomad =
					Convert.ToBoolean(reader.ReadByteFromOffset(offsets.Nomad) );

				CustomSeed =
					reader.ReadIntegerFromOffset32BitSigned(offsets.CustomSeed);
			}
		}

		private void SaveSummary(ByteStreamWriter writer)
		{
			var offsets = ByteOffsetsPick(SaveVersion);

			writer.WriteDecimalToOffsetWithLengthAndMaxUnsigned32Bit(
				valueToWrite: ResourceUnits,
				offsets.ResourceUnits,
				valueMax: 0xFFFFFFFF
			);

			writer.WriteDecimalToOffsetWithLengthAndMaxUnsigned32Bit(
				valueToWrite: ShipFuel,
				offsets.Fuel,
				valueMax: 161000
			);

			writer.WriteDecimalToOffsetWithLengthAndMaxUnsigned16Bit(
				valueToWrite: FlagshipCrew,
				offsets.FlagshipCrew,
				valueMax: 800
			);

			writer.WriteDecimalToOffsetWithLengthAndMaxUnsigned16Bit(
				valueToWrite: Minerals_Total,
				offsets.TotalMinerals,
				valueMax: 8000
			);

			writer.WriteDecimalToOffsetWithLengthAndMaxUnsigned16Bit(
				valueToWrite: BioData,
				offsets.BioData,
				valueMax: 0xFFFF
			);

			var modulesAsBytes = FlagshipModulesAtPositions.Select(x => x.Code).ToArray();
			writer.WriteBytesToOffset(modulesAsBytes, offsets.ModuleSlots);

			var thrustersAsBytes =
				ThrustersArePresentAtPositions.Select(x => x ? (byte)1 : (byte)20).ToArray();
			writer.WriteBytesToOffset(thrustersAsBytes, offsets.ThrusterSlots[0]);

			var turningJetsAsBytes =
				TurningJetsArePresentAtPositions.Select(x => x ? (byte)2 : (byte)21).ToArray();
			writer.WriteBytesToOffset(turningJetsAsBytes, offsets.TurningJetSlots[0]);

			writer.WriteDecimalToOffsetWithLengthAndMaxSigned(
				LandersCount,
				offsets.LandersCount,
				lengthInBytes: 1,
				valueMax: 10
			);

			// Cargo.
			writer.WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
				Minerals_CommonElements,
				offsets.Minerals_CommonElements,
				valueMax: 0xFFFF
			);

			writer.WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
				Minerals_Corrosives,
				offsets.Minerals_Corrosives,
				valueMax: 0xFFFF
			);

			writer.WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
				Minerals_BaseMetals,
				offsets.Minerals_BaseMetals,
				valueMax: 0xFFFF
			);

			writer.WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
				Minerals_NobleGases,
				offsets.Minerals_NobleGases,
				valueMax: 0xFFFF
			);

			writer.WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
				Minerals_RareEarths,
				offsets.Minerals_RareEarths,
				valueMax: 0xFFFF
			);

			writer.WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
				Minerals_PreciousMetals,
				offsets.Minerals_PreciousMetals,
				valueMax: 0xFFFF
			);

			writer.WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
				Minerals_Radioactives,
				offsets.Minerals_Radioactives,
				valueMax: 0xFFFF
			);

			writer.WriteDecimalToOffsetWithLengthAndMaxSigned16Bit(
				Minerals_Exotics,
				offsets.Minerals_Exotics,
				valueMax: 0xFFFF
			);

			writer.WriteStringToOffsetWithLength(
				ShipName,
				offsets.ShipName,
				lengthInBytes: 16
			);

			writer.WriteStringToOffsetWithLength(
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

		// Controls.


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