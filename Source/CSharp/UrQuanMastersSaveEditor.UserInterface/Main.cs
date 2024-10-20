using System.Globalization;
using UrQuanMastersSaveEditor.Common;

namespace UrQuanMastersSaveEditor
{
	public partial class Main : Form
	{
		private string _currentDir;
		private string _currentFile = "";
		private object[] _shipModules;

		public Main() {
			InitializeComponent();
			Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
			_shipModules = Modules.CreateModules();

			foreach (var shipsControl in ShipsBox.Controls) {
				var shipsComboBox = shipsControl as ComboBox;
				if (shipsComboBox != null)
				{
					shipsComboBox.Items.AddRange(Constants.ShipNames);
				}
			}
			foreach (var modulesControl in ModulesBox.Controls)
			{
				var modulesComboBox = modulesControl as ComboBox;
				if (modulesComboBox != null)
				{
					modulesComboBox.Items.AddRange(_shipModules);
				}
			}
			CurrentStatus.Items.AddRange(Constants.StatusNames);
			difficultyBox.Items.AddRange(Constants.DifficultyLevels);
			Spoilers.Checked = false;

			string PathVanilla, PathHD, PathMegaMod, PathRemix, PathDesired;
			var PathAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			PathVanilla = PathAppData + "\\uqm\\save";
			PathHD = PathAppData + "\\uqmhd\\save";
			PathRemix = PathAppData + "\\uqmhdremix\\save";
			PathMegaMod = PathAppData + "\\UQM-MegaMod\\save";

			if (Directory.Exists(PathMegaMod))
			{
				PathDesired = PathMegaMod;
			}
			else if (Directory.Exists(PathRemix))
			{
				PathDesired = PathRemix;
			}
			else if (Directory.Exists(PathHD))
			{
				PathDesired = PathHD;
			}
			else if (Directory.Exists(PathVanilla))
			{
				PathDesired = PathVanilla;
			}
			else
			{
				PathDesired = Directory.GetCurrentDirectory();
			}

			_currentDir = PathDesired;
			StarList.Items.AddRange(ParseStars.LoadStars(false));
		}

		private void Open_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog()
			{
				Title = "Open Ur-Quan Masters Save File",
				Filter = "UQM Save Files | *starcon2.*; *uqmsave.*",
				InitialDirectory = _currentDir
			};

			if (openFileDialog.ShowDialog() == DialogResult.OK) {
				_currentFile = openFileDialog.FileName;
				Reload.Enabled = true;
				Save.Enabled = true;
				Tabs.Enabled = true;

				var saveFile = GameState.Instance;

				if (!File.Exists(_currentFile))
				{
					MessageBox.Show("Could not find file at path: " + _currentFile);
				}
				else
				{
					GameStateLoad();
				}

				var TitleText = "The Ur-Quan Masters Save Editor";
				SeedBox.Visible = false;
				megaModModes.Visible = false;
				TitleText += GameState.Instance.GetTitleText();

				if (TitleText.Contains("MegaMod") )
				{
					SeedBox.Visible = true;
					megaModModes.Visible = true;
				}

				Text =
					TitleText
					+
					(
						saveFile.SaveVersion > 0
						? (saveFile.Date + ": " + saveFile.SaveName)
						: (saveFile.SaveName + saveFile.Date)
					);

				_currentDir = _currentFile;
			}
		}

		private void Reload_Click(object sender, EventArgs e) {
			GameStateLoad();
		}

		private void GameStateLoad()
		{
			var gameState = GameState.Instance;
			gameState.Open(_currentFile);
			var userInterface = new UserInterfaceController(this, gameState);
			userInterface.PopulateControlFromGameState();
		}

		private void MineralsValueChanged(object sender, EventArgs e) {
			Minerals_Total.Value = 0;
			Minerals_Total.Value =
				Minerals_CommonElements.Value
				+ Minerals_Corrosives.Value
				+ Minerals_BaseMetals.Value
				+ Minerals_NobleGases.Value
				+ Minerals_RareEarths.Value
				+ Minerals_PreciousMetals.Value
				+ Minerals_Radioactives.Value
				+ Minerals_Exotics.Value;
        }

		private void Save_Click(object sender, EventArgs e) {
			var gameState = GameState.Instance;
            var controller = new UserInterfaceController(this, gameState);
            controller.PopulateGameStateFromControl();
            gameState.Save(_currentFile);
        }

        private void Main_Shown(object sender, EventArgs e) {
			UniverseY.Text = "";
			UniverseX.Text = "";
			NearestStar.Text = "";
		}

		private void Spoilers_CheckedChanged(object sender, EventArgs e) {
			var selectedIndex = StarList.SelectedIndex;
			var starListItems = StarList.Items;
			starListItems.Clear();
			starListItems.AddRange(ParseStars.LoadStars(Spoilers.Checked));
			if (starListItems.Count >= selectedIndex) {
				if (starListItems.Count >= selectedIndex + 23) {
					StarList.SelectedIndex = selectedIndex + 23;
				}
				StarList.SelectedIndex = selectedIndex;
			}
		}

		private void Universe_TextChanged(object sender, EventArgs e) {
			double num, num2;
			var couldNumBeParsed =
				double.TryParse(UniverseX.Text.Replace(',', '.'), out num);
			var couldNum2BeParsed =
				double.TryParse(UniverseY.Text.Replace(',', '.'), out num2);

			if (couldNumBeParsed && couldNum2BeParsed)
			{
				if (num <= 1500.0 && num2 <= 1500.0 && num >= -1500.0 && num2 >= -1500.0)
				{
					NearestStar.Text = Stars.NearestStarToPosXY(num, num2);
					return;
				}
				NearestStar.Text = "";
			}
		}

		private void StarList_SelectedIndexChanged(object sender, EventArgs e)
		{
			var selectedItem = StarList.SelectedItem;
			if (StarList.SelectedIndex > 0)
			{
				if (selectedItem != null)
				{
					var selectedItemAsString = selectedItem.ToString() ?? "";
					var array = selectedItemAsString
						.Split(['\t'])[4]
						.Replace(" ", "")
						.Replace("[", "")
						.Replace("]", "")
						.Split([':']);
					UniverseX.Text = array[0];
					UniverseY.Text = array[1];
				}
			}
		}

		private void UpgradeToMax_Click(object sender, EventArgs e) {
			byte[] modulesArray = { 4, 1, 1, 2, 11, 10, 10, 10, 5, 5, 5, 6, 6, 6, 9, 9 };
			byte[] modulesArrayBomb = { 16, 17, 15, 13, 12, 13, 15, 16, 17, 14, 4, 1, 11, 10, 9, 10 };
			byte i = 0;
			foreach (object moduleControl in ModulesBox.Controls)
			{
				var moduleComboBox = moduleControl as ComboBox;
				if (moduleComboBox != null) {
					moduleComboBox.SelectedIndex =
						LanderModifications_DisplacedByBomb.Checked ? modulesArrayBomb[i] : modulesArray[i];
					i++;
				}
			}
		}

		private void MaxThrusters_Click(object sender, EventArgs e)
		{
			foreach (var thrusterControl in ThrusterBox.Controls)
			{
				var thrusterCheckBox = thrusterControl as CheckBox;
				if (thrusterCheckBox != null)
				{
					thrusterCheckBox.Checked = true;
				}
			}
		}

		private void MaxJets_Click(object sender, EventArgs e)
		{
			foreach (var turningJetsControl in TurningJetsBox.Controls)
			{
				var turningJetsCheckBox = turningJetsControl as CheckBox;
				if (turningJetsCheckBox != null)
				{
					turningJetsCheckBox.Checked = true;
				}
			}
		}

		private void Module_SelectedIndexChanged(object sender, EventArgs e) {
			int maxStorage = 0, maxFuel = 10, maxCrew = 0;
			foreach (var moduleControl in ModulesBox.Controls)
			{
				var moduleComboBox = moduleControl as ComboBox;
				if (moduleComboBox != null)
				{
					int index = moduleComboBox.SelectedIndex;
					maxCrew += index == 1 ? 50 : 0;
					maxStorage += index == 2 ? 500 : 0;
					maxFuel += index == 3 ? 50 : (index == 4 ? 100 : 0);
				}
			}
			CrewLabel.Text = "Crew " + ("[" + maxCrew + "]");
			FuelLabel.Text = "Fuel  " + ("[" + maxFuel + "]");
			TotalLabel.Text = "Total  " + ("[" + maxStorage + "]");
			MaxLimits.SetToolTip(CrewLabel, "Please fill only to max value as shown.");
			MaxLimits.SetToolTip(FuelLabel, "Please fill only to max value as shown.");
			MaxLimits.SetToolTip(TotalLabel, "Please fill only to max value as shown.");
			// These are commented out because they sometimes cause errors when loading.
			//ShipFuel.Maximum = MaxFuel;
			//ShipCrew.Maximum = MaxCrew;
		}
	}
}