using System.Collections.Generic;
using System.Windows.Forms;

namespace UQMEdit
{
	class UserInterfaceController
	{
		private Main _window;
		private UrQuanMastersGameState _uqmsf;

		public UserInterfaceController(Main window, UrQuanMastersGameState uqmsf)
		{
			_window = window;
			_uqmsf = uqmsf;
		}

		public void PopulateControlFromGameState()
		{
			_window.UniverseX.Value = _uqmsf.UniverseX;
			_window.UniverseY.Value = _uqmsf.UniverseY;
			_window.CurrentStatus.SelectedIndex = _uqmsf.CurrentStatus;
			_window.NearestPlanet.Text = _uqmsf.NearestPlanet;
			_window.ResourceUnits.Value = _uqmsf.ResourceUnits;
			_window.ShipFuel.Value = _uqmsf.ShipFuel;
			_window.FlagshipCrew.Value = _uqmsf.FlagshipCrew;
			_window.BioData.Value = _uqmsf.BioData;

			var flagshipModuleCount = 0;
			var flagshipModulesAtPositions = _uqmsf.FlagshipModulesAtPositions;
			foreach (var modulesControl in _window.ModulesBox.Controls)
			{
				if (modulesControl is ComboBox)
				{
					var modulesComboBox = modulesControl as ComboBox;
					var isNotEmpty =
						flagshipModulesAtPositions[flagshipModuleCount] != UrQuanMastersGameState.FlagshipModule.Instances.Empty;
					if (isNotEmpty)
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
						_uqmsf.ThrustersArePresentAtPositions[thrustersCount];
					thrustersCount++;
				}
			}

			var turningJetsCount = 0;
			foreach (var turningJetControl in _window.TurningJetsBox.Controls)
			{
				if (turningJetControl is CheckBox)
				{
					(turningJetControl as CheckBox).Checked =
						_uqmsf.TurningJetsArePresentAtPositions[turningJetsCount];
					turningJetsCount++;
				}
			}

			_window.LanderCount.Value = _uqmsf.LandersCount;

			_window.Minerals_CommonElements.Value = _uqmsf.Minerals_CommonElements;
			_window.Minerals_Corrosives.Value = _uqmsf.Minerals_Corrosives;
			_window.Minerals_NobleGases.Value = _uqmsf.Minerals_NobleGases;
			_window.Minerals_RareEarths.Value = _uqmsf.Minerals_RareEarths;
			_window.Minerals_BaseMetals.Value = _uqmsf.Minerals_BaseMetals;
			_window.Minerals_PreciousMetals.Value = _uqmsf.Minerals_PreciousMetals;
			_window.Minerals_Radioactives.Value = _uqmsf.Minerals_Radioactives;
			_window.Minerals_Exotics.Value = _uqmsf.Minerals_Exotics;
			_window.ShipName.Text = _uqmsf.ShipName;
			_window.CommanderName.Text = _uqmsf.CommanderName;

			var landerModifications = _uqmsf._LanderModifications;

			_window.LanderModifications_BioShield.Checked = landerModifications.BioShield;
			_window.LanderModifications_QuakeShield.Checked = landerModifications.QuakeShield;
			_window.LanderModifications_LightningShield.Checked = landerModifications.LightningShield;
			_window.LanderModifications_HeatShield.Checked = landerModifications.HeatShield;
			_window.LanderModifications_DoubleSpeed.Checked = landerModifications.DoubleSpeed;
			_window.LanderModifications_DoubleCargo.Checked = landerModifications.DoubleCargo;
			_window.LanderModifications_RapidFire.Checked = landerModifications.RapidFire;
			_window.LanderModifications_DisplacedByBomb.Checked = landerModifications.DisplacedByBomb;

			_window.Credits.Text = _uqmsf.Credits.ToString();

			var escortShipsAsBytes = _uqmsf.EscortShipsAsBytes;
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
			_window.Devices.Items.AddRange(_uqmsf.DevicesAsObjects);

			_window.difficultyBox.SelectedIndex = _uqmsf.Difficulty;
			_window.extendedCheckBox.Checked = _uqmsf.Extended;
			_window.nomadCheckBox.Checked = _uqmsf.Nomad;
			_window.CustomSeed.Text = _uqmsf.CustomSeed.ToString();

		}

		public void PopulateGameStateFromControl()
		{
			_uqmsf.ResourceUnits = (int)_window.ResourceUnits.Value;
			_uqmsf.ShipFuel = _window.ShipFuel.Value; // */ 100
			_uqmsf.FlagshipCrew = _window.FlagshipCrew.Value;
			_uqmsf.Minerals_Total = (int)(_window.Minerals_Total.Value);
			_uqmsf.BioData = _window.BioData.Value;

			var modulesPresent = new List<UrQuanMastersGameState.FlagshipModule>();
			foreach (var modulesControl in _window.ModulesBox.Controls)
			{
				if (modulesControl is ComboBox)
				{
					var moduleAsComboBox = modulesControl as ComboBox;
					var modulePresent =
						moduleAsComboBox.SelectedItem as UrQuanMastersGameState.FlagshipModule;
					modulesPresent.Add(modulePresent);
				}
			}
			_uqmsf.FlagshipModulesAtPositions = modulesPresent.ToArray();

			var thrusterControls = _window.ThrusterBox.Controls;
			var i = 0;
			foreach (var thrusterControl in thrusterControls)
			{
				if (thrusterControl is CheckBox)
				{
					var thrusterIsPresent = (thrusterControl as CheckBox).Checked;
					_uqmsf.ThrustersArePresentAtPositions[i] = thrusterIsPresent;
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
					_uqmsf.TurningJetsArePresentAtPositions[i] = turningJetIsPresent;
					i++;
				}
			}

			_uqmsf.LandersCount = (byte)(_window.LanderCount.Value);

			_uqmsf.Minerals_CommonElements = (int)_window.Minerals_CommonElements.Value;
			_uqmsf.Minerals_Corrosives = (int)_window.Minerals_Corrosives.Value;
			_uqmsf.Minerals_BaseMetals = (int)_window.Minerals_BaseMetals.Value;
			_uqmsf.Minerals_NobleGases = (int)_window.Minerals_NobleGases.Value;
			_uqmsf.Minerals_PreciousMetals = (int)_window.Minerals_PreciousMetals.Value;
			_uqmsf.Minerals_Radioactives = (int)_window.Minerals_Radioactives.Value;
			_uqmsf.Minerals_Total = (int)_window.Minerals_Total.Value;

			_uqmsf.ShipName = _window.ShipName.Text;

			_uqmsf.CommanderName = _window.CommanderName.Text;
		}

	}
}