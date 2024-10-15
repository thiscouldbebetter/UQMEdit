namespace UQMEdit
{
	class Offsets
	{
		public const byte SaveChecker = 0;
		public const byte SaveNameMagic = 8;

		public class HighDefinitionRemaster
		{
			public const byte
				SaveName = 16,

				LogX = 48,
				LogY = 52,

				ResUnits = 56,
				Fuel = 60,
				SiSCrew = 64,

				TotalMinerals = 66,

				BioData = 68,

				ModuleSlots = 70;

			public static byte[]
				DriveSlots = { 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96 },
				JetSlots = { 97, 98, 99, 100, 101, 102, 103, 104 };

			public const byte
				Landers = 105,

				Minerals_CommonElements = 106,
				Minerals_Corrosives = 108,
				Minerals_BaseMetal = 110,
				Minerals_NobleGases = 112,
				Minerals_RareEarths = 114,
				Minerals_PreciousMetals = 116,
				Radioactives = 118,
				Exotic = 120;
			public static byte[] Minerals = { 106, 108, 110, 112, 114, 116, 118, 120 };

			public const byte
				ShipName = 122,
				CaptainName = 138,

				NearestPlanet = 154,
				Status = 172,

				LanderModifications = 173;

			public static byte[] Date = { 174, 175, 176 };

			public const byte Credits = 178;

			public static byte[] Escorts = { 180, 182 };

			public static byte[] Devices = { 181, 194 };

			public const byte ResFactor = 210;
		}

		public class MegaModFieldOffsets
		{
			public const byte
				LogX = 12,
				LogY = 16,

				ResUnits = 20,
				Fuel = 24,
				SiSCrew = 28,

				TotalMinerals = 30,
				BioData = 32,

				ModuleSlots = 34;
			public static byte[] DriveSlots = { 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60 };
			public static byte[] JetSlots = { 61, 62, 63, 64, 65, 66, 67, 68 };

			public const byte
				Landers = 69,

				Minerals_CommonElements = 70,
				Minerals_Corrosives = 72,
				Minerals_BaseMetal = 74,
				Minerals_NobleGases = 76,
				Minerals_RareEarths = 78,
				Minerals_PreciousMetals = 80,
				Radioactives = 82,
				Exotic = 84;
			public static byte[] Minerals = { 70, 72, 74, 76, 78, 80, 82, 84 };

			public const byte
				ShipName = 86,
				CaptainName = 102,
				NearestPlanet = 118,

				Difficulty = 134,
				Extended = 135,
				Nomad = 136,
				CustomSeed = 137,

				Status = 141,

				LanderModificiations = 142;

			public static byte[] Date = { 143, 144, 145 };

			public const byte Credits = 147;

			public static byte[] Escorts = { 149, 151 };

			public static byte[] Devices = { 150, 163 };

			public const byte
				ResFactor = 179,
				SaveName = 180;
		}

		public class Core
		{
			public const byte Status = 134;

			public const byte LanderModifications = 135;

			public static byte[] Date = { 136, 137, 138 };

			public const byte Credits = 140;

			public static byte[] Escorts = { 142, 144 };

			public static byte[] Devices = { 143, 156 };

			public static byte SaveName = 172;
		}
	}
}