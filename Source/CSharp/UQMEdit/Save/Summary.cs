using System.Windows.Forms;

namespace UQMEdit
{
	partial class Write
	{
		public static void Summary()
		{
			var f = Functions.Instance;

			var offsets = f.ByteOffsetsPick();

			// Resource Units
			f.WriteOffset(
				offsets.ResUnits,
				valueFromControl: Window.ResUnits.Value,
				lengthInBytes: 4,
				valueMax: 0xFFFFFFFF,
				isUnsignedNotSigned: true
			);

			var fuel = Window.ShipFuel.Value * 100;
			f.WriteOffset(
				offsets.Fuel,
				valueFromControl: decimal.ToUInt32(fuel),
				lengthInBytes: 4,
				valueMax: 161000,
				isUnsignedNotSigned: true
			);

			f.WriteOffset(
				offsets.SiSCrew, 
				valueFromControl: Window.ShipCrew.Value,
				lengthInBytes: 2,
				valueMax: 800,
				isUnsignedNotSigned: true
			);

			f.WriteOffset(
				offsets.TotalMinerals,
				valueFromControl: Window.TotalMinerals.Value,
				lengthInBytes: 2,
				valueMax: 8000,
				isUnsignedNotSigned: true
			);

			f.WriteOffset(
				offsets.BioData,
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
					f.WriteOffset(
						offsets.ModuleSlots + i,
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
					f.WriteOffset(
						offsets.ThrusterSlots[j],
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
					f.WriteOffset(
						offsets.TurningJetSlots[k],
						turningJetAsByte,
						lengthInBytes: 1,
						valueMax: 21,
						isUnsignedNotSigned: true
					);
					k++;
				}
			}

			f.WriteOffset(
				offsets.Landers,
				Window.Landers.Value,
				lengthInBytes: 1,
				valueMax: 10
			);

			// Cargo.
			f.WriteOffset(
				offsets.Minerals_CommonElements,
				Window.Minerals_CommonElements.Value,
				lengthInBytes: 2,
				valueMax: 0xFFFF
			);

			f.WriteOffset(
				offsets.Minerals_Corrosives,
				Window.Minerals_Corrosives.Value,
				lengthInBytes: 2,
				valueMax: 0xFFFF
			);

			f.WriteOffset(
				offsets.Minerals_BaseMetals,
				Window.Minerals_BaseMetals.Value,
				lengthInBytes: 2,
				valueMax: 0xFFFF
			);

			f.WriteOffset(
				offsets.Minerals_NobleGases,
				Window.Minerals_NobleGases.Value,
				lengthInBytes: 2,
				valueMax: 0xFFFF
			);

			f.WriteOffset(
				offsets.Minerals_RareEarths,
				Window.Minerals_RareEarths.Value,
				lengthInBytes: 2,
				valueMax: 0xFFFF
			);

			f.WriteOffset(
				offsets.Minerals_PreciousMetals,
				Window.Minerals_PreciousMetals.Value,
				lengthInBytes: 2,
				valueMax: 0xFFFF
			);

			f.WriteOffset(
				offsets.Minerals_Radioactives,
				Window.Minerals_Radioactives.Value,
				lengthInBytes: 2,
				valueMax: 0xFFFF
			);

			f.WriteOffset(
				offsets.Minerals_Exotics,
				Window.Minerals_Exotics.Value,
				lengthInBytes: 2,
				valueMax: 0xFFFF
			);

			f.WriteOffsetString(
				offsets.ShipName,
				Window.ShipName.Text,
				lengthInBytes: 16
			);

			f.WriteOffsetString(
				offsets.CaptainName,
				Window.CommanderName.Text,
				lengthInBytes: 16
			);
		}
	}
}