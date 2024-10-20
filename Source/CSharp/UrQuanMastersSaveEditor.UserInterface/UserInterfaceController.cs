using UrQuanMastersSaveEditor.Common;

namespace UrQuanMastersSaveEditor
{
	class UserInterfaceController
	{
		private Main _window;
		private GameState _gameState;

		public UserInterfaceController(Main window, GameState uqmsf)
		{
			_window = window;
			_gameState = uqmsf;
		}

		public void PopulateControlFromGameState()
		{
			_window.UniverseX.Value = _gameState.UniverseX;
			_window.UniverseY.Value = _gameState.UniverseY;
			_window.CurrentStatus.SelectedIndex = _gameState.CurrentStatus;
			_window.NearestPlanet.Text = _gameState.NearestPlanet;
			_window.ResourceUnits.Value = _gameState.ResourceUnits;
			_window.ShipFuel.Value = _gameState.ShipFuel;
			_window.FlagshipCrew.Value = _gameState.FlagshipCrew;
			_window.BioData.Value = _gameState.BioData;

			var flagshipModuleCount = 0;
			var flagshipModulesAtPositions = _gameState.FlagshipModulesAtPositions;
			foreach (var modulesControl in _window.ModulesBox.Controls)
			{
				var modulesComboBox = modulesControl as ComboBox;
				if (modulesComboBox != null)
				{
					var isNotEmpty =
						flagshipModulesAtPositions[flagshipModuleCount] != GameState.FlagshipModule.Instances.Empty;
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
				var thrusterCheckBox = thrustersControl as CheckBox;
				if (thrusterCheckBox != null)
				{
					thrusterCheckBox.Checked =
						_gameState.ThrustersArePresentAtPositions[thrustersCount];
					thrustersCount++;
				}
			}

			var turningJetsCount = 0;
			foreach (var turningJetControl in _window.TurningJetsBox.Controls)
			{
				var turningJetCheckBox = turningJetControl as CheckBox;
				if (turningJetCheckBox != null)
				{
					turningJetCheckBox.Checked =
						_gameState.TurningJetsArePresentAtPositions[turningJetsCount];
					turningJetsCount++;
				}
			}

			_window.LanderCount.Value = _gameState.LandersCount;

			_window.Minerals_CommonElements.Value = _gameState.Minerals_CommonElements;
			_window.Minerals_Corrosives.Value = _gameState.Minerals_Corrosives;
			_window.Minerals_NobleGases.Value = _gameState.Minerals_NobleGases;
			_window.Minerals_RareEarths.Value = _gameState.Minerals_RareEarths;
			_window.Minerals_BaseMetals.Value = _gameState.Minerals_BaseMetals;
			_window.Minerals_PreciousMetals.Value = _gameState.Minerals_PreciousMetals;
			_window.Minerals_Radioactives.Value = _gameState.Minerals_Radioactives;
			_window.Minerals_Exotics.Value = _gameState.Minerals_Exotics;
			_window.ShipName.Text = _gameState.ShipName;
			_window.CommanderName.Text = _gameState.CommanderName;

			var landerModifications = _gameState._LanderModifications;

			_window.LanderModifications_BioShield.Checked = landerModifications.BioShield;
			_window.LanderModifications_QuakeShield.Checked = landerModifications.QuakeShield;
			_window.LanderModifications_LightningShield.Checked = landerModifications.LightningShield;
			_window.LanderModifications_HeatShield.Checked = landerModifications.HeatShield;
			_window.LanderModifications_DoubleSpeed.Checked = landerModifications.DoubleSpeed;
			_window.LanderModifications_DoubleCargo.Checked = landerModifications.DoubleCargo;
			_window.LanderModifications_RapidFire.Checked = landerModifications.RapidFire;
			_window.LanderModifications_DisplacedByBomb.Checked = landerModifications.DisplacedByBomb;

			_window.Credits.Text = _gameState.Credits.ToString();

			var escortShipsAsBytes = _gameState.EscortShipsAsBytes;
			var escortShipsCountAsRead = escortShipsAsBytes.Length; // todo

			var escortShipsCountAsCounted = 0;
			foreach (var shipsControl in _window.ShipsBox.Controls)
			{
				var shipsComboBox = shipsControl as ComboBox;
				if (shipsComboBox != null)
				{
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
			_window.Devices.Items.AddRange(_gameState.DevicesAsObjects);

			_window.difficultyBox.SelectedIndex = _gameState.Difficulty;
			_window.extendedCheckBox.Checked = _gameState.Extended;
			_window.nomadCheckBox.Checked = _gameState.Nomad;
			_window.CustomSeed.Text = _gameState.CustomSeed.ToString();

		}

		public void PopulateGameStateFromControl()
		{
			_gameState.ResourceUnits = (int)_window.ResourceUnits.Value;
			_gameState.ShipFuel = _window.ShipFuel.Value; // */ 100
			_gameState.FlagshipCrew = _window.FlagshipCrew.Value;
			_gameState.Minerals_Total = (int)(_window.Minerals_Total.Value);
			_gameState.BioData = _window.BioData.Value;

			var modulesPresent = new List<GameState.FlagshipModule>();
			foreach (var moduleControl in _window.ModulesBox.Controls)
			{
				var moduleComboBox = moduleControl as ComboBox;
				if (moduleComboBox != null)
				{
					var modulePresent =
						(moduleComboBox.SelectedItem as GameState.FlagshipModule) ?? GameState.FlagshipModule.Empty();
					modulesPresent.Add(modulePresent);
				}
			}
			_gameState.FlagshipModulesAtPositions = modulesPresent.ToArray();

			var thrusterControls = _window.ThrusterBox.Controls;
			var i = 0;
			foreach (var thrusterControl in thrusterControls)
			{
				var thrusterCheckBox = thrusterControl as CheckBox;
				if (thrusterCheckBox != null)
				{
					var thrusterIsPresent = thrusterCheckBox.Checked;
					_gameState.ThrustersArePresentAtPositions[i] = thrusterIsPresent;
					i++;
				}
			}

			var turningJetControls = _window.TurningJetsBox.Controls;
			i = 0;
			foreach (var turningJetControl in turningJetControls)
			{
				var turningJetCheckBox = turningJetControl as CheckBox;
				if (turningJetCheckBox != null)
				{
					var turningJetIsPresent = turningJetCheckBox.Checked;
					_gameState.TurningJetsArePresentAtPositions[i] = turningJetIsPresent;
					i++;
				}
			}

			_gameState.LandersCount = (byte)(_window.LanderCount.Value);

			_gameState.Minerals_CommonElements = (int)_window.Minerals_CommonElements.Value;
			_gameState.Minerals_Corrosives = (int)_window.Minerals_Corrosives.Value;
			_gameState.Minerals_BaseMetals = (int)_window.Minerals_BaseMetals.Value;
			_gameState.Minerals_NobleGases = (int)_window.Minerals_NobleGases.Value;
			_gameState.Minerals_PreciousMetals = (int)_window.Minerals_PreciousMetals.Value;
			_gameState.Minerals_Radioactives = (int)_window.Minerals_Radioactives.Value;
			_gameState.Minerals_Total = (int)_window.Minerals_Total.Value;

			_gameState.ShipName = _window.ShipName.Text;

			_gameState.CommanderName = _window.CommanderName.Text;
		}

	}
}