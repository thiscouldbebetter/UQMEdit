using System.Windows.Forms;

namespace UQMEdit
{
	partial class Write
	{
		public static void Summary() {
			// Resource Units
			Functions.WriteOffset(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.ResUnits,
					Offsets.MegaModFieldOffsets.ResUnits
				),
				valueFromControl: Window.ResUnits.Value,
				lengthInBytes: 4,
				valueMax: 0xFFFFFFFF,
				isUnsignedNotSigned: true
			);

			var ShipFuel = Window.ShipFuel.Value * 100;
			Functions.WriteOffset(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.Fuel,
					Offsets.MegaModFieldOffsets.Fuel
				),
				valueFromControl: decimal.ToUInt32(ShipFuel),
				lengthInBytes: 4,
				valueMax: 161000,
				isUnsignedNotSigned: true
			);

			Functions.WriteOffset(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.SiSCrew, 
					Offsets.MegaModFieldOffsets.SiSCrew
				),
				valueFromControl: Window.ShipCrew.Value,
				lengthInBytes: 2,
				valueMax: 800,
				isUnsignedNotSigned: true
			);

			Functions.WriteOffset(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.TotalMinerals,
					Offsets.MegaModFieldOffsets.TotalMinerals
				),
				valueFromControl: Window.TotalMinerals.Value,
				lengthInBytes: 2,
				valueMax: 8000,
				isUnsignedNotSigned: true
			);

			Functions.WriteOffset(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.BioData,
					Offsets.MegaModFieldOffsets.BioData
				),
				valueFromControl: Window.BioData.Value,
				lengthInBytes: 2,
				valueMax: 0xFFFF,
				isUnsignedNotSigned: true
			);

			// Modules
			byte moduleAsByte, i = 0;
			foreach (var modulesControl in Window.ModulesBox.Controls) {
				if (modulesControl is ComboBox) {
					int modulePresentCode = (modulesControl as ComboBox).SelectedIndex;
					if (modulePresentCode > 0) {
						moduleAsByte = (byte)(modulePresentCode + 2);
					} else {
						moduleAsByte = 22;
					}
					Functions.WriteOffset(
						Functions.ByteOffsetsPick(
							Offsets.HighDefinitionRemaster.ModuleSlots + i,
							Offsets.MegaModFieldOffsets.ModuleSlots + i
						),
						valueFromControl: moduleAsByte,
						lengthInBytes: 1,
						valueMax: 22,
						isUnsignedNotSigned: true
					);
					i++;
				}
			}

			// Thrusters
			byte thrustersAsByte, j = 0;
			foreach (var thrusterControl in Window.ThrusterBox.Controls)
			{
				if (thrusterControl is CheckBox)
				{
					var thrusterIsPresent = (thrusterControl as CheckBox).Checked;
					thrustersAsByte = (byte)(thrusterIsPresent ? 1 : 20);
					Functions.WriteOffset(
						Functions.ByteOffsetsPick(
							Offsets.HighDefinitionRemaster.DriveSlots[j],
							Offsets.MegaModFieldOffsets.DriveSlots[j]
						),
						thrustersAsByte,
						lengthInBytes: 1,
						valueMax: 20,
						isUnsignedNotSigned: true
					);
					j++;
				}
			}

			byte turningJetAsByte, k = 0;
			foreach (var turningJetControl in Window.JetsBox.Controls)
			{
				if (turningJetControl is CheckBox)
				{
					var turningJetIsPresent = (turningJetControl as CheckBox).Checked;
					turningJetAsByte = (byte)(turningJetIsPresent ? 2 : 21);
					Functions.WriteOffset(
						Functions.ByteOffsetsPick(
							Offsets.HighDefinitionRemaster.JetSlots[k],
							Offsets.MegaModFieldOffsets.JetSlots[k]
						),
						turningJetAsByte,
						lengthInBytes: 1,
						valueMax: 21,
						isUnsignedNotSigned: true
					);
					k++;
				}
			}

			Functions.WriteOffset(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.Landers,
					Offsets.MegaModFieldOffsets.Landers
				),
				Window.Landers.Value,
				lengthInBytes: 1,
				valueMax: 10
			);

			// Cargo.
			Functions.WriteOffset(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.Common,
					Offsets.MegaModFieldOffsets.Common
				),
				Window.Common.Value,
				lengthInBytes: 2,
				valueMax: 0xFFFF
			);

			Functions.WriteOffset(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.Corrosive,
					Offsets.MegaModFieldOffsets.Corrosive
				),
				Window.Corrosive.Value,
				lengthInBytes: 2,
				valueMax: 0xFFFF
			);

			Functions.WriteOffset(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.BaseMetal,
					Offsets.MegaModFieldOffsets.BaseMetal
				),
				Window.BaseMetal.Value,
				lengthInBytes: 2,
				valueMax: 0xFFFF
			);

			Functions.WriteOffset(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.NobleGas,
					Offsets.MegaModFieldOffsets.NobleGas
				),
				Window.NobleGas.Value,
				lengthInBytes: 2,
				valueMax: 0xFFFF
			);

			Functions.WriteOffset(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.RareEarth,
					Offsets.MegaModFieldOffsets.RareEarth
				),
				Window.RareEarth.Value,
				lengthInBytes: 2,
				valueMax: 0xFFFF
			);

			Functions.WriteOffset(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.Precious,
					Offsets.MegaModFieldOffsets.Precious
				),
				Window.Precious.Value,
				lengthInBytes: 2,
				valueMax: 0xFFFF
			);

			Functions.WriteOffset(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.Radioactive,
					Offsets.MegaModFieldOffsets.Radioactive
				),
				Window.Radioactive.Value,
				lengthInBytes: 2,
				valueMax: 0xFFFF
			);

			Functions.WriteOffset(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.Exotic,
					Offsets.MegaModFieldOffsets.Exotic
				),
				Window.Exotic.Value,
				lengthInBytes: 2,
				valueMax: 0xFFFF
			);

			Functions.WriteOffsetString(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.ShipName,
					Offsets.MegaModFieldOffsets.ShipName
				),
				Window.ShipName.Text,
				lengthInBytes: 16
			);

			Functions.WriteOffsetString(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.CaptainName,
					Offsets.MegaModFieldOffsets.CaptainName
				),
				Window.CommanderName.Text,
				lengthInBytes: 16
			);
		}
	}
}