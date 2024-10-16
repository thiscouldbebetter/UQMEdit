using System;
using System.Text;
using System.Globalization;
using System.Windows.Forms;

namespace UQMEdit
{
	partial class Read
	{
		public static string SaveName;
		public static string Date = "";

		public static void Summary()
		{

			var f = Functions.Instance;

			var offsets = f.ByteOffsetsPick();

			if (SaveVersion >= 2)
			{
				var magic = f.ReadOffsetToInt(offsets.SaveNameMagic, 4);
				var nameSize = (magic - 160);

				SaveName = Encoding.Default.GetString(
					f.ReadBytesFromOffsetToLength(
						offsets.SaveName,
						nameSize
					)
				);
			}
			else if (SaveVersion == 1)
			{
				SaveName = Encoding.Default.GetString(
					f.ReadBytesFromOffsetToLength(
						offsets.SaveName,
						lengthInBytes: 31
					)
				);
			} else {
				SaveName = "Saved Game - Date: ";
			}

			Window.ResUnits.Value = f.ReadOffsetToInt(
				offsets.ResUnits,
				lengthInBytes: 4
			);

			var fuel = f.ReadOffsetToInt(
				offsets.Fuel,
				lengthInBytes: 4
			);
			fuel = fuel > 160100 ? 160100 : fuel;
			Window.ShipFuel.Value = fuel / 100;

			Window.ShipCrew.Value = f.ReadOffsetToInt(
				offsets.SiSCrew,
				lengthInBytes: 4,
				bitWidth: 16
			);

			Window.BioData.Value = f.ReadOffsetToInt(
				offsets.BioData,
				lengthInBytes: 2,
				bitWidth: 16);

			// Modules
			var modules =
				f.ReadBytesFromOffsetToLength(
					offsets.ModuleSlots,
					lengthInBytes: 16
				);
			var moduleCount = 0;
			foreach (var modulesControl in Window.ModulesBox.Controls) {
				if (modulesControl is ComboBox) {
					if (modules[moduleCount] < 20) {
						(modulesControl as ComboBox).SelectedIndex = modules[moduleCount] - 2;
					} else {
						(modulesControl as ComboBox).SelectedIndex = 0;
					}
					moduleCount++;
				}
			}

			var thrustersAsBytes =
				f.ReadBytesFromOffsetToLength(
					offsets.ThrusterSlots[0],
					lengthInBytes: 11
				);

			var thrustersCount = 0;
			foreach (var thrustersControl in Window.ThrusterBox.Controls) {
				if (thrustersControl is CheckBox)
				{
					(thrustersControl as CheckBox).Checked =
						(thrustersAsBytes[thrustersCount] == 1);
					thrustersCount++;
				}
			}

			var turningJetsAsBytes =
				f.ReadBytesFromOffsetToLength(
					offsets.TurningJetSlots[0],
					lengthInBytes: 8
				);

			var turningJetsCount = 0;
			foreach (var turningJetsControl in Window.JetsBox.Controls) {
				if (turningJetsControl is CheckBox) {
					(turningJetsControl as CheckBox).Checked =
						(turningJetsAsBytes[turningJetsCount] == 2);
					turningJetsCount++;
				}
			}

			Window.Landers.Value =
				f.ReadBytesFromOffsetToLength(
					offsets.Landers,
					1
				)[0];

			// Cargo.
			Window.Minerals_CommonElements.Value =
				f.ReadOffsetToInt(
					offsets.Minerals_CommonElements,
					lengthInBytes: 2,
					bitWidth: 16
				);

			Window.Minerals_Corrosives.Value =
				f.ReadOffsetToInt(
					offsets.Minerals_Corrosives,
					lengthInBytes: 2,
					bitWidth: 16
				);

			Window.Minerals_BaseMetals.Value =
				f.ReadOffsetToInt(
					offsets.Minerals_BaseMetals,
					lengthInBytes: 2,
					16
				);

			Window.Minerals_NobleGases.Value =
				f.ReadOffsetToInt(
					offsets.Minerals_NobleGases,
					lengthInBytes: 2,
					bitWidth: 16
				);

			Window.Minerals_RareEarths.Value =
				f.ReadOffsetToInt(
					offsets.Minerals_RareEarths,
					lengthInBytes: 2,
					bitWidth: 16
				);

			Window.Minerals_PreciousMetals.Value =
				f.ReadOffsetToInt(
					offsets.Minerals_PreciousMetals,
					lengthInBytes: 2,
					bitWidth: 16
				);

			Window.Minerals_Radioactives.Value =
				f.ReadOffsetToInt(
					offsets.Minerals_Radioactives,
					lengthInBytes: 2,
					bitWidth: 16
				);

			Window.Minerals_Exotics.Value =
				f.ReadOffsetToInt(
					offsets.Minerals_Exotics,
					lengthInBytes: 2,
					bitWidth: 16
				);

			Window.ShipName.Text =
				Encoding.Default.GetString(
					f.ReadBytesFromOffsetToLength(
						offsets.ShipName,
						lengthInBytes: 16
					)
				);

			Window.CommanderName.Text =
				Encoding.Default.GetString(
					f.ReadBytesFromOffsetToLength(
						offsets.CaptainName,
						lengthInBytes: 16
					)
				);

			//  Lander Mods
			byte landerModificationsAsByte =
				f.ReadBytesFromOffsetToLength(
					offsets.LanderModifications,
					lengthInBytes: 1
				)[0];

			bool LanderModsBool(int otherValue, bool isBomb = false)
			{
				return
					!isBomb
					? (((landerModificationsAsByte | 128) & otherValue) != 0)
					: ((landerModificationsAsByte & otherValue) != 0);
			}

			Window.LanderModifications_DisplacedByBomb.Checked = LanderModsBool(128, isBomb: true);
			Window.LanderModifications_BioShield.Checked = LanderModsBool(1);
			Window.LanderModifications_QuakeShield.Checked = LanderModsBool(2);
			Window.LanderModifications_LightningShield.Checked = LanderModsBool(4);
			Window.LanderModifications_HeatShield.Checked = LanderModsBool(8);
			Window.LanderModifications_DoubleSpeed.Checked = LanderModsBool(16);
			Window.LanderModifications_DoubleCargo.Checked = LanderModsBool(32);
			Window.LanderModifications_RapidFire.Checked = LanderModsBool(64);

			// Time & Date
			var day = f.ReadBytesFromOffsetToLength(
				offsets.Date[0],
				lengthInBytes: 1
			)[0];

			var month = f.ReadBytesFromOffsetToLength(
				offsets.Date[1],
				lengthInBytes: 1
			)[0];

			var year = f.ReadOffsetToInt(
				offsets.Date[2],
				lengthInBytes: 2,
				bitWidth: 16
			);

			Date =
				CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(month).ToUpper()
				+ " " + day
				+ "·" + year;

			Window.Credits.Text = f.ReadOffsetToInt(
				offsets.Credits,
				lengthInBytes: 2,
				bitWidth: 16
			).ToString();

			var escortShipsCountAsRead = f.ReadBytesFromOffsetToLength(
				offsets.Escorts[0],
				lengthInBytes: 1
			)[0];
			var escortShipsAsBytes =
				f.ReadBytesFromOffsetToLength(
					offsets.Escorts[1],
					escortShipsCountAsRead
				);

			var escortShipsCountAsCounted = 0;
			foreach (var shipsControl in Window.ShipsBox.Controls)
			{
				if (shipsControl is ComboBox)
				{
					if (escortShipsCountAsCounted < escortShipsCountAsRead)
					{
						if
						(
							escortShipsAsBytes[escortShipsCountAsCounted] < Constants.ShipNames.Length
							&& escortShipsAsBytes[escortShipsCountAsCounted] >= 0
						)
						{
							(shipsControl as ComboBox).SelectedIndex = escortShipsAsBytes[escortShipsCountAsCounted];
						}
						else
						{
							(shipsControl as ComboBox).SelectedIndex = 24;
						}
						escortShipsCountAsCounted++;
					}
					else
					{
						(shipsControl as ComboBox).SelectedIndex = 24;
					}
				}
			}

			var devicesCount =
				f.ReadBytesFromOffsetToLength(
					offsets.Devices[0],
					lengthInBytes: 1
				)[0];

			var devicesAsObjects = new object[devicesCount];
			var devicesAsBytes =
				f.ReadBytesFromOffsetToLength(
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
			Window.Devices.Items.Clear();
			Window.Devices.Items.AddRange(devicesAsObjects);

			// Custom Seed
			if (SaveVersion == 2)
			{
				Window.difficultyBox.SelectedIndex =
					f.ReadBytesFromOffsetToLength(
						offsets.Difficulty,
						lengthInBytes: 1
					)[0];

				Window.extendedCheckBox.Checked =
					Convert.ToBoolean(
						f.ReadBytesFromOffsetToLength(
							offsets.Extended,
							lengthInBytes: 1
						)[0]
					);

				Window.nomadCheckBox.Checked =
					Convert.ToBoolean(
						f.ReadBytesFromOffsetToLength(
							offsets.Nomad, lengthInBytes: 1
						)[0]
					);

				Window.CustomSeed.Text = f.ReadOffsetToInt(
					offsets.CustomSeed,
					lengthInBytes: 4,
					bitWidth: 32
				).ToString();
			}
		}
	}
}