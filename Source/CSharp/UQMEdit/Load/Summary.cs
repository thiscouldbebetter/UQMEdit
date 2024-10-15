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

		public static void Summary() {

			if (SaveVersion >= 2)
			{
				var magic = Functions.ReadOffsetToInt(Offsets.SaveNameMagic, 4);
                var nameSize = (magic - 160);

                SaveName = Encoding.Default.GetString(
					Functions.ReadBytesFromOffsetToLength(
						SaveVersion == 3
						? Offsets.Core.SaveName
						: Offsets.MegaModFieldOffsets.SaveName,
						nameSize
					)
				);
			}
			else if (SaveVersion == 1)
			{
				SaveName = Encoding.Default.GetString(
					Functions.ReadBytesFromOffsetToLength(
						Offsets.HighDefinitionRemaster.SaveName,
						lengthInBytes: 31
					)
				);
			} else {
				SaveName = "Saved Game - Date: ";
			}

			Window.ResUnits.Value = Functions.ReadOffsetToInt(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.ResUnits,
					Offsets.MegaModFieldOffsets.ResUnits
				),
				lengthInBytes: 4
			);

			var fuel = Functions.ReadOffsetToInt(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.Fuel,
					Offsets.MegaModFieldOffsets.Fuel
				),
				lengthInBytes: 4
			);
			fuel = fuel > 160100 ? 160100 : fuel;
			Window.ShipFuel.Value = fuel / 100;

			Window.ShipCrew.Value = Functions.ReadOffsetToInt(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.SiSCrew,
					Offsets.MegaModFieldOffsets.SiSCrew
				),
				lengthInBytes: 4,
				bitWidth: 16
			);

			Window.BioData.Value = Functions.ReadOffsetToInt(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.BioData,
					Offsets.MegaModFieldOffsets.BioData
				),
				lengthInBytes: 2,
				bitWidth: 16);

			// Modules
			var modules =
				Functions.ReadBytesFromOffsetToLength(
					Functions.ByteOffsetsPick(
						Offsets.HighDefinitionRemaster.ModuleSlots,
						Offsets.MegaModFieldOffsets.ModuleSlots
					),
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

			var thrustersArray =
				Functions.ReadBytesFromOffsetToLength(
					Functions.ByteOffsetsPick(
						Offsets.HighDefinitionRemaster.DriveSlots[0],
						Offsets.MegaModFieldOffsets.DriveSlots[0]
					),
					lengthInBytes: 11
				);

			var thrustersCount = 0;
			foreach (var thrustersControl in Window.ThrusterBox.Controls) {
				if (thrustersControl is CheckBox)
				{
					(thrustersControl as CheckBox).Checked =
						(thrustersArray[thrustersCount] == 1);
					thrustersCount++;
				}
			}

			var turningJets =
				Functions.ReadBytesFromOffsetToLength(
					Functions.ByteOffsetsPick(
						Offsets.HighDefinitionRemaster.JetSlots[0],
						Offsets.MegaModFieldOffsets.JetSlots[0]
					),
					lengthInBytes: 8
				);

			var turningJetsCount = 0;
			foreach (var turningJetsControl in Window.JetsBox.Controls) {
				if (turningJetsControl is CheckBox) {
					(turningJetsControl as CheckBox).Checked =
						(turningJets[turningJetsCount] == 2);
					turningJetsCount++;
				}
			}

			Window.Landers.Value =
				Functions.ReadBytesFromOffsetToLength(
					Functions.ByteOffsetsPick(
						Offsets.HighDefinitionRemaster.Landers,
						Offsets.MegaModFieldOffsets.Landers
					),
					1
				)[0];

			// Cargo.
			Window.Common.Value =
				Functions.ReadOffsetToInt(
					Functions.ByteOffsetsPick(
						Offsets.HighDefinitionRemaster.Common,
						Offsets.MegaModFieldOffsets.Common
					),
					lengthInBytes: 2,
					bitWidth: 16
				);
			Window.Corrosive.Value =
				Functions.ReadOffsetToInt(
					Functions.ByteOffsetsPick(
						Offsets.HighDefinitionRemaster.Corrosive,
						Offsets.MegaModFieldOffsets.Corrosive
					),
					lengthInBytes: 2,
					bitWidth: 16
				);
			Window.BaseMetal.Value = Functions.ReadOffsetToInt(Functions.ByteOffsetsPick(Offsets.HighDefinitionRemaster.BaseMetal, Offsets.MegaModFieldOffsets.BaseMetal), 2, 16);
			Window.NobleGas.Value = Functions.ReadOffsetToInt(Functions.ByteOffsetsPick(Offsets.HighDefinitionRemaster.NobleGas, Offsets.MegaModFieldOffsets.NobleGas), 2, 16);
			Window.RareEarth.Value = Functions.ReadOffsetToInt(Functions.ByteOffsetsPick(Offsets.HighDefinitionRemaster.RareEarth, Offsets.MegaModFieldOffsets.RareEarth), 2, 16);
			Window.Precious.Value = Functions.ReadOffsetToInt(Functions.ByteOffsetsPick(Offsets.HighDefinitionRemaster.Precious, Offsets.MegaModFieldOffsets.Precious), 2, 16);
			Window.Radioactive.Value = Functions.ReadOffsetToInt(Functions.ByteOffsetsPick(Offsets.HighDefinitionRemaster.Radioactive, Offsets.MegaModFieldOffsets.Radioactive), 2, 16);
			Window.Exotic.Value = Functions.ReadOffsetToInt(Functions.ByteOffsetsPick(Offsets.HighDefinitionRemaster.Exotic, Offsets.MegaModFieldOffsets.Exotic), 2, 16);

			Window.ShipName.Text =
				Encoding.Default.GetString(
					Functions.ReadBytesFromOffsetToLength(
						Functions.ByteOffsetsPick(
							Offsets.HighDefinitionRemaster.ShipName,
							Offsets.MegaModFieldOffsets.ShipName
						),
						lengthInBytes: 16
					)
				);

			Window.CommanderName.Text =
				Encoding.Default.GetString(
					Functions.ReadBytesFromOffsetToLength(
						Functions.ByteOffsetsPick(
							Offsets.HighDefinitionRemaster.CaptainName,
							Offsets.MegaModFieldOffsets.CaptainName
						),
						lengthInBytes: 16
					)
				);

			//  Lander Mods
			byte landerModificationsAsByte =
				Functions.ReadBytesFromOffsetToLength(
					Functions.ByteOffsetsPick(
						Offsets.HighDefinitionRemaster.LanderModifications,
						Offsets.MegaModFieldOffsets.LanderModificiations,
						Offsets.Core.LanderModifications
					),
					lengthInBytes: 1
				)[0];

			bool LanderModsBool(int otherValue, bool isBomb = false)
			{
				return
					!isBomb
					? (((landerModificationsAsByte | 128) & otherValue) != 0)
					: ((landerModificationsAsByte & otherValue) != 0);
			}

			Window.IsBomb.Checked = LanderModsBool(128, true);
			Window.BioShield.Checked = LanderModsBool(1);
			Window.QuakeShield.Checked = LanderModsBool(2);
			Window.LightningShield.Checked = LanderModsBool(4);
			Window.HeatShield.Checked = LanderModsBool(8);
			Window.DblSpeed.Checked = LanderModsBool(16);
			Window.DblCargo.Checked = LanderModsBool(32);
			Window.RapidFire.Checked = LanderModsBool(64);

			// Time & Date
			var day = Functions.ReadBytesFromOffsetToLength(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.Date[0],
					Offsets.MegaModFieldOffsets.Date[0],
					Offsets.Core.Date[0]
				),
				lengthInBytes: 1
			)[0];

			var month = Functions.ReadBytesFromOffsetToLength(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.Date[1],
					Offsets.MegaModFieldOffsets.Date[1],
					Offsets.Core.Date[1]
				),
				lengthInBytes: 1
			)[0];

			var year = Functions.ReadOffsetToInt(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.Date[2],
					Offsets.MegaModFieldOffsets.Date[2],
					Offsets.Core.Date[2]
				),
				lengthInBytes: 2,
				bitWidth: 16
			);

			Date =
				CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(month).ToUpper()
				+ " " + day
				+ "·" + year;

			Window.Credits.Text = Functions.ReadOffsetToInt(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.Credits,
					Offsets.MegaModFieldOffsets.Credits,
					Offsets.Core.Credits
				),
				lengthInBytes: 2,
				bitWidth: 16
			).ToString();

			var escortShipsCountAsRead = Functions.ReadBytesFromOffsetToLength(
				Functions.ByteOffsetsPick(
					Offsets.HighDefinitionRemaster.Escorts[0],
					Offsets.MegaModFieldOffsets.Escorts[0],
					Offsets.Core.Escorts[0]
				),
				lengthInBytes: 1
			)[0];
			var escortShipsAsBytes =
				Functions.ReadBytesFromOffsetToLength(
					Functions.ByteOffsetsPick(
						Offsets.HighDefinitionRemaster.Escorts[1],
						Offsets.MegaModFieldOffsets.Escorts[1],
						Offsets.Core.Escorts[1]
					),
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
				Functions.ReadBytesFromOffsetToLength(
					Functions.ByteOffsetsPick(
						Offsets.HighDefinitionRemaster.Devices[0],
						Offsets.MegaModFieldOffsets.Devices[0],
						Offsets.Core.Devices[0]
					),
					lengthInBytes: 1
				)[0];

			var devicesAsObjects = new object[devicesCount];
			var devicesAsBytes =
				Functions.ReadBytesFromOffsetToLength(
					Functions.ByteOffsetsPick(
						Offsets.HighDefinitionRemaster.Devices[1],
						Offsets.MegaModFieldOffsets.Devices[1],
						Offsets.Core.Devices[1]
					),
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
					Functions.ReadBytesFromOffsetToLength(
						Offsets.MegaModFieldOffsets.Difficulty,
						lengthInBytes: 1
					)[0];

				Window.extendedCheckBox.Checked =
					Convert.ToBoolean(
						Functions.ReadBytesFromOffsetToLength(
							Offsets.MegaModFieldOffsets.Extended,
							lengthInBytes: 1
						)[0]
					);

				Window.nomadCheckBox.Checked =
					Convert.ToBoolean(
						Functions.ReadBytesFromOffsetToLength(
							Offsets.MegaModFieldOffsets.Nomad, lengthInBytes: 1
						)[0]
					);

				Window.CustomSeed.Text = Functions.ReadOffsetToInt(
					Offsets.MegaModFieldOffsets.CustomSeed,
					lengthInBytes: 4,
					bitWidth: 32
				).ToString();
			}
		}
	}
}