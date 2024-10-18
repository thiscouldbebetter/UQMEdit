using System;
using System.Linq;

namespace UQMEdit
{
	public interface IOffsets
	{
		byte SaveChecker { get; }
		byte SaveNameMagic { get;}
		byte SaveName { get; }
		byte LogX { get; }
		byte LogY { get; }
		byte ResourceUnits { get; }
		byte Fuel { get; }
		byte FlagshipCrew { get; }
		byte TotalMinerals { get; }
		byte BioData { get; }
		byte ModuleSlots { get; }
		byte[] ThrusterSlots { get; }
		byte[] TurningJetSlots { get; }
		byte LandersCount { get; }
		byte Minerals_CommonElements { get; }
		byte Minerals_Corrosives { get; }
		byte Minerals_BaseMetals { get; }
		byte Minerals_NobleGases { get; }
		byte Minerals_RareEarths { get; }
		byte Minerals_PreciousMetals { get; }
		byte Minerals_Radioactives { get; }
		byte Minerals_Exotics { get; }
		byte[] Minerals { get; }
		byte ShipName { get; }
		byte CaptainName { get; }
		byte NearestPlanet { get; }
		byte Difficulty { get; }
		byte Extended { get; }
		byte Nomad { get; }
		byte CustomSeed { get; }
		byte Status { get; }
		byte LanderModifications { get; }
		byte[] Date { get; }
		byte Credits { get; }
		byte[] Escorts { get; }
		byte[] Devices { get; }
		byte ResFactor { get; }
	}

	class OffsetsHighDefinitionRemasterMinus48 : IOffsets
	{
		private const byte _48 = 48;

		public static OffsetsHighDefinitionRemasterMinus48 Instance
			= new OffsetsHighDefinitionRemasterMinus48(OffsetsHighDefinitionRemaster.Instance);

		private OffsetsHighDefinitionRemaster _offsetsInner;


		public OffsetsHighDefinitionRemasterMinus48(OffsetsHighDefinitionRemaster offsetsInner)
		{
			_offsetsInner = offsetsInner;
		}

        public byte SaveChecker { get; } = 0; // todo
        public byte SaveNameMagic { get; } = 8;
		public byte SaveName { get; } = 16;
		public byte LogX { get => (byte)(_offsetsInner.LogX - _48); }
		public byte LogY { get => (byte)(_offsetsInner.LogY - _48); }
		public byte ResourceUnits { get => (byte)(_offsetsInner.ResourceUnits - _48); }
		public byte Fuel { get => (byte)(_offsetsInner.Fuel - _48); }
		public byte FlagshipCrew { get => (byte)(_offsetsInner.FlagshipCrew - _48); }
		public byte TotalMinerals { get => (byte)(_offsetsInner.TotalMinerals - _48); }
		public byte BioData { get => (byte)(_offsetsInner.BioData - _48); }
		public byte ModuleSlots { get => (byte)(_offsetsInner.ModuleSlots - _48); }
		public byte[] ThrusterSlots { get => _offsetsInner.ThrusterSlots.Select(x => (byte)(x - 48) ).ToArray(); }
		public byte[] TurningJetSlots { get => _offsetsInner.TurningJetSlots.Select(x => (byte)(x - 48)).ToArray(); }
		public byte LandersCount { get => (byte)(_offsetsInner.LandersCount - _48); }
		public byte Minerals_CommonElements { get => (byte)(_offsetsInner.Minerals_CommonElements - _48); }
		public byte Minerals_Corrosives { get => (byte)(_offsetsInner.Minerals_Corrosives - _48); }
		public byte Minerals_BaseMetals { get => (byte)(_offsetsInner.Minerals_BaseMetals - _48); }
		public byte Minerals_NobleGases { get => (byte)(_offsetsInner.Minerals_NobleGases - _48); }
		public byte Minerals_RareEarths { get => (byte)(_offsetsInner.Minerals_RareEarths - _48); }
		public byte Minerals_PreciousMetals { get => (byte)(_offsetsInner.Minerals_PreciousMetals - _48); }
		public byte Minerals_Radioactives { get => (byte)(_offsetsInner.Minerals_Radioactives - _48); }
		public byte Minerals_Exotics { get => (byte)(_offsetsInner.Minerals_Exotics - _48); }
		public byte[] Minerals { get => _offsetsInner.Minerals.Select(x => (byte)(x - 48)).ToArray(); }
		public byte ShipName { get => (byte)(_offsetsInner.ShipName - _48); }
		public byte CaptainName { get => (byte)(_offsetsInner.CaptainName - _48); }
		public byte NearestPlanet { get => (byte)(_offsetsInner.NearestPlanet - _48); }
		public byte Status { get => (byte)(_offsetsInner.Status - _48); }
		public byte LanderModifications { get => (byte)(_offsetsInner.LanderModifications - _48); }

		public byte[] Date { get => _offsetsInner.Date.Select(x => (byte)(x - 48)).ToArray(); }

		public byte Credits { get => (byte)(_offsetsInner.Credits - _48); }

		public byte[] Escorts { get => _offsetsInner.Escorts.Select(x => (byte)(x - 48)).ToArray(); }

		public byte[] Devices { get => _offsetsInner.Devices.Select(x => (byte)(x - 48)).ToArray(); }

		public byte ResFactor { get => (byte)(_offsetsInner.ResFactor - _48); }

		public byte Difficulty => throw new NotImplementedException();

		public byte Extended => throw new NotImplementedException();

		public byte Nomad => throw new NotImplementedException();

		public byte CustomSeed => throw new NotImplementedException();
	}

	class OffsetsHighDefinitionRemaster : IOffsets
	{
		public static OffsetsHighDefinitionRemaster Instance = new OffsetsHighDefinitionRemaster();

		public byte SaveChecker { get; } = 0;
		public byte SaveNameMagic { get; } = 8;
		public byte SaveName { get; } = 16;
		public byte LogX { get; } = 48;
		public byte LogY { get; } =52;
		public byte ResourceUnits { get; } = 56;
		public byte Fuel { get; } = 60;
		public byte FlagshipCrew { get; } = 64;
		public byte TotalMinerals { get; } = 66;
		public byte BioData { get; } = 68;
		public byte ModuleSlots { get; } = 70;
		public byte[] ThrusterSlots { get; } = { 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96 };
		public byte[] TurningJetSlots { get; } = { 97, 98, 99, 100, 101, 102, 103, 104 };
		public byte LandersCount { get; } = 105;
		public byte Minerals_CommonElements { get; } = 106;
		public byte Minerals_Corrosives { get; } = 108;
		public byte Minerals_BaseMetals { get; } = 110;
		public byte Minerals_NobleGases { get; } = 112;
		public byte Minerals_RareEarths { get; } = 114;
		public byte Minerals_PreciousMetals { get; } = 116;
		public byte Minerals_Radioactives { get; } = 118;
		public byte Minerals_Exotics { get; } =120;
		public byte[] Minerals { get; } = { 106, 108, 110, 112, 114, 116, 118, 120 };
		public byte ShipName { get; } = 122;
		public byte CaptainName { get; } = 138;
		public byte NearestPlanet { get; } = 154;
		public byte Status { get; } = 172;
		public byte LanderModifications { get; } = 173;

		public byte[] Date { get; } = { 174, 175, 176 };

		public byte Credits { get; } = 178;

		public byte[] Escorts { get; } = { 180, 182 };

		public byte[] Devices { get; } = { 181, 194 };

		public byte ResFactor { get; } = 210;

		public byte Difficulty => throw new NotImplementedException();

		public byte Extended => throw new NotImplementedException();

		public byte Nomad => throw new NotImplementedException();

		public byte CustomSeed => throw new NotImplementedException();
	}

	class OffsetsMegaMod : IOffsets
	{
		public static OffsetsMegaMod Instance = new OffsetsMegaMod();

		public byte SaveChecker { get; } = 0;
		public byte SaveNameMagic { get; } = 8;
		public byte LogX { get; } = 12;
		public byte LogY { get; } = 16;
		public byte ResourceUnits { get; } = 20;
		public byte Fuel { get; } = 24;
		public byte FlagshipCrew { get; } = 28;
		public byte TotalMinerals { get; } = 30;
		public byte BioData { get; } = 32;
		public byte ModuleSlots { get; } = 34;
		public byte[] ThrusterSlots { get; } = { 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60 };
		public byte[] TurningJetSlots { get; } = { 61, 62, 63, 64, 65, 66, 67, 68 };
		public byte LandersCount { get; } = 69;
		public byte Minerals_CommonElements { get; } = 70;
		public byte Minerals_Corrosives { get; } = 72;
		public byte Minerals_BaseMetals { get; } = 74;
		public byte Minerals_NobleGases { get; } = 76;
		public byte Minerals_RareEarths { get; } = 78;
		public byte Minerals_PreciousMetals { get; } = 80;
		public byte Minerals_Radioactives { get; } = 82;
		public byte Minerals_Exotics { get; } = 84;
		public byte[] Minerals { get; } = { 70, 72, 74, 76, 78, 80, 82, 84 };
		public byte ShipName { get; } = 86;
		public byte CaptainName { get; } = 102;
		public byte NearestPlanet { get; } = 118;
		public byte Difficulty { get; } = 134;
		public byte Extended { get; } = 135;
		public byte Nomad { get; } = 136;
		public byte CustomSeed { get; } = 137;
		public byte Status { get; } = 141;
		public byte LanderModifications { get; } = 142;
		public byte[] Date { get; } = { 143, 144, 145 };
		public byte Credits { get; } = 147;
		public byte[] Escorts { get; } = { 149, 151 };
		public byte[] Devices { get; } = { 150, 163 };
		public byte ResFactor { get; } = 179;
		public byte SaveName { get; } = 180;
	}

	class OffsetsCore : IOffsets
	{
		public static OffsetsCore Instance = new OffsetsCore(OffsetsMegaMod.Instance);

		private OffsetsMegaMod _offsetsInner;


		public OffsetsCore(OffsetsMegaMod offsetsInner)
		{
			_offsetsInner = offsetsInner;
		}

		public byte SaveChecker { get => _offsetsInner.SaveChecker; }
		public byte SaveNameMagic { get => _offsetsInner.SaveNameMagic; }
		public byte SaveName { get; } = 172;
		public byte LogX { get => _offsetsInner.LogX; }
		public byte LogY { get => _offsetsInner.LogY; }
		public byte ResourceUnits { get => _offsetsInner.ResourceUnits; }
		public byte Fuel { get => _offsetsInner.Fuel; }
		public byte FlagshipCrew { get => _offsetsInner.FlagshipCrew; }
		public byte TotalMinerals { get => _offsetsInner.TotalMinerals; }
		public byte BioData { get => _offsetsInner.BioData; }
		public byte ModuleSlots { get => _offsetsInner.ModuleSlots; }
		public byte[] ThrusterSlots { get => _offsetsInner.ThrusterSlots; }
		public byte[] TurningJetSlots { get => _offsetsInner.TurningJetSlots; }
		public byte LandersCount { get => _offsetsInner.LandersCount; }
		public byte Minerals_CommonElements { get => _offsetsInner.Minerals_CommonElements; }
		public byte Minerals_Corrosives { get => _offsetsInner.Minerals_Corrosives; }
		public byte Minerals_BaseMetals { get => _offsetsInner.Minerals_BaseMetals; }
		public byte Minerals_NobleGases { get => _offsetsInner.Minerals_NobleGases; }
		public byte Minerals_RareEarths { get => _offsetsInner.Minerals_RareEarths; }
		public byte Minerals_PreciousMetals { get => _offsetsInner.Minerals_PreciousMetals; }
		public byte Minerals_Radioactives { get => _offsetsInner.Minerals_Radioactives; }
		public byte Minerals_Exotics { get => _offsetsInner.Minerals_Exotics; }
		public byte[] Minerals { get => _offsetsInner.Minerals; }
		public byte ShipName { get => _offsetsInner.ShipName; }
		public byte CaptainName { get => _offsetsInner.CaptainName; }
		public byte NearestPlanet { get => _offsetsInner.NearestPlanet; }
		public byte Status { get; } = 134;

		public byte LanderModifications { get; } = 135;

		public byte[] Date { get; } = { 136, 137, 138 };

		public byte Credits { get; } = 140;

		public byte[] Escorts { get; } = { 142, 144 };

		public byte[] Devices { get; } = { 143, 156 };

		public byte ResFactor { get => _offsetsInner.ResFactor; }

		public byte Difficulty => throw new NotImplementedException();

		public byte Extended => throw new NotImplementedException();

		public byte Nomad => throw new NotImplementedException();

		public byte CustomSeed => throw new NotImplementedException();
	}
}