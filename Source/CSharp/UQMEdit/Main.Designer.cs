using System.Drawing;
using System.Windows.Forms;

namespace UQMEdit
{
	partial class Main
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.toolStrip1 = new ToolStrip();
            this.Open = new ToolStripButton();
            this.Reload = new ToolStripButton();
            this.Save = new ToolStripButton();
            this.version = new ToolStripLabel();
            this.Tabs = new TabControl();
            this.Summary = new TabPage();
            this.DevicesBox = new GroupBox();
            this.Devices = new ListBox();
            this.TotalMinerals = new NumericUpDown();
            this.ThrusterBox = new GroupBox();
            this.MaxThrustLabel = new Label();
            this.MaxThrusters = new Button();
            this.Thruster10 = new CheckBox();
            this.Thruster9 = new CheckBox();
            this.Thruster8 = new CheckBox();
            this.Thruster7 = new CheckBox();
            this.Thruster6 = new CheckBox();
            this.Thruster5 = new CheckBox();
            this.Thruster4 = new CheckBox();
            this.Thruster3 = new CheckBox();
            this.Thruster2 = new CheckBox();
            this.Thruster1 = new CheckBox();
            this.Thruster0 = new CheckBox();
            this.JetsBox = new GroupBox();
            this.MaxJetsLabel = new Label();
            this.Jets7 = new CheckBox();
            this.MaxJets = new Button();
            this.Jets6 = new CheckBox();
            this.Jets5 = new CheckBox();
            this.Jets4 = new CheckBox();
            this.Jets3 = new CheckBox();
            this.Jets2 = new CheckBox();
            this.Jets1 = new CheckBox();
            this.Jets0 = new CheckBox();
            this.SeedBox = new GroupBox();
            this.CustomSeed = new TextBox();
            this.ShipNameBox = new GroupBox();
            this.ShipName = new TextBox();
            this.CaptainBox = new GroupBox();
            this.CommanderName = new TextBox();
            this.ShipsBox = new GroupBox();
            this.Ship01 = new ComboBox();
            this.Ship02 = new ComboBox();
            this.Ship03 = new ComboBox();
            this.Ship04 = new ComboBox();
            this.Ship05 = new ComboBox();
            this.Ship06 = new ComboBox();
            this.Ship07 = new ComboBox();
            this.Ship08 = new ComboBox();
            this.Ship09 = new ComboBox();
            this.Ship10 = new ComboBox();
            this.Ship11 = new ComboBox();
            this.Ship12 = new ComboBox();
            this.ShipLabel01 = new Label();
            this.ShipLabel12 = new Label();
            this.ShipLabel02 = new Label();
            this.ShipLabel11 = new Label();
            this.ShipLabel10 = new Label();
            this.ShipLabel03 = new Label();
            this.ShipLabel09 = new Label();
            this.ShipLabel08 = new Label();
            this.ShipLabel04 = new Label();
            this.ShipLabel07 = new Label();
            this.ShipLabel06 = new Label();
            this.ShipLabel05 = new Label();
            this.ModulesBox = new GroupBox();
            this.MaxModulesLabel = new Label();
            this.UpgradeToMax = new Button();
            this.Module16 = new ComboBox();
            this.Module15 = new ComboBox();
            this.Module14 = new ComboBox();
            this.Module13 = new ComboBox();
            this.Module12 = new ComboBox();
            this.Module11 = new ComboBox();
            this.Module10 = new ComboBox();
            this.Module09 = new ComboBox();
            this.Module08 = new ComboBox();
            this.Module07 = new ComboBox();
            this.Module06 = new ComboBox();
            this.ModuleLabel01 = new Label();
            this.ModuleLabel02 = new Label();
            this.Module05 = new ComboBox();
            this.ModuleLabel03 = new Label();
            this.Module04 = new ComboBox();
            this.ModuleLabel04 = new Label();
            this.Module03 = new ComboBox();
            this.ModuleLabel05 = new Label();
            this.Module02 = new ComboBox();
            this.ModuleLabel06 = new Label();
            this.Module01 = new ComboBox();
            this.ModuleLabel07 = new Label();
            this.ModuleLabel16 = new Label();
            this.ModuleLabel08 = new Label();
            this.ModuleLabel15 = new Label();
            this.ModuleLabel09 = new Label();
            this.ModuleLabel14 = new Label();
            this.ModuleLabel10 = new Label();
            this.ModuleLabel13 = new Label();
            this.ModuleLabel11 = new Label();
            this.ModuleLabel12 = new Label();
            this.ShipStatusBox = new GroupBox();
            this.Credits = new TextBox();
            this.label58 = new Label();
            this.LandersLabel = new Label();
            this.BioDataLabel = new Label();
            this.RULabel = new Label();
            this.FuelLabel = new Label();
            this.LanderUpgradesBox = new GroupBox();
            this.LanderModifications_DisplacedByBomb = new CheckBox();
            this.LanderModifications_QuakeShield = new CheckBox();
            this.LanderModifications_RapidFire = new CheckBox();
            this.LanderModifications_BioShield = new CheckBox();
            this.LanderModifications_DoubleCargo = new CheckBox();
            this.LanderModifications_DoubleSpeed = new CheckBox();
            this.LanderModifications_LightningShield = new CheckBox();
            this.LanderModifications_HeatShield = new CheckBox();
            this.CrewLabel = new Label();
            this.Landers = new NumericUpDown();
            this.BioData = new NumericUpDown();
            this.ResourceUnits = new NumericUpDown();
            this.ShipFuel = new NumericUpDown();
            this.FlagshipCrew = new NumericUpDown();
            this.CargoBox = new GroupBox();
            this.TotalLabel = new Label();
            this.ExoticsLabel = new Label();
            this.RadioactivsLabel = new Label();
            this.PreciousMetalsLabel = new Label();
            this.RareEarthsLabel = new Label();
            this.NoblesGasesLabel = new Label();
            this.BaseMetalsLabel = new Label();
            this.CorrosiveLabel = new Label();
            this.CommonLabel = new Label();
            this.Minerals_Exotics = new NumericUpDown();
            this.Minerals_Radioactives = new NumericUpDown();
            this.Minerals_PreciousMetals = new NumericUpDown();
            this.Minerals_RareEarths = new NumericUpDown();
            this.Minerals_NobleGases = new NumericUpDown();
            this.Minerals_BaseMetals = new NumericUpDown();
            this.Minerals_Corrosives = new NumericUpDown();
            this.Minerals_CommonElements = new NumericUpDown();
            this.Coordinates = new TabPage();
            this.Spoilers = new CheckBox();
            this.StatusBox = new GroupBox();
            this.CurrentStatus = new ComboBox();
            this.OrbitBox = new GroupBox();
            this.NearestPlanet = new TextBox();
            this.NearestStarBox = new GroupBox();
            this.NearestStar = new TextBox();
            this.HSCoordsBox = new GroupBox();
            this.UniYLabel = new Label();
            this.UniXLabel = new Label();
            this.UniverseY = new NumericUpDown();
            this.UniverseX = new NumericUpDown();
            this.StarList = new ListBox();
            this.ReadOnly = new ToolTip(this.components);
            this.MaxLimits = new ToolTip(this.components);
            this.megaModModes = new GroupBox();
            this.difficultyBox = new ComboBox();
            this.difficultyLabel = new Label();
            this.extendedCheckBox = new CheckBox();
            this.nomadCheckBox = new CheckBox();
            this.toolStrip1.SuspendLayout();
            this.Tabs.SuspendLayout();
            this.Summary.SuspendLayout();
            this.DevicesBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TotalMinerals)).BeginInit();
            this.ThrusterBox.SuspendLayout();
            this.JetsBox.SuspendLayout();
            this.SeedBox.SuspendLayout();
            this.ShipNameBox.SuspendLayout();
            this.CaptainBox.SuspendLayout();
            this.ShipsBox.SuspendLayout();
            this.ModulesBox.SuspendLayout();
            this.ShipStatusBox.SuspendLayout();
            this.LanderUpgradesBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Landers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BioData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResourceUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipFuel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlagshipCrew)).BeginInit();
            this.CargoBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Minerals_Exotics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minerals_Radioactives)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minerals_PreciousMetals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minerals_RareEarths)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minerals_NobleGases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minerals_BaseMetals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minerals_Corrosives)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minerals_CommonElements)).BeginInit();
            this.Coordinates.SuspendLayout();
            this.StatusBox.SuspendLayout();
            this.OrbitBox.SuspendLayout();
            this.NearestStarBox.SuspendLayout();
            this.HSCoordsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UniverseY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UniverseX)).BeginInit();
            this.megaModModes.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new ToolStripItem[] {
            this.Open,
            this.Reload,
            this.Save,
            this.version});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(873, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Open
            // 
            this.Open.Image = new Bitmap("Resources/Open.Image.png"); // global::UQMEdit.Properties.Resources.Open_Image;
            this.Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(56, 22);
            this.Open.Text = "Open";
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Reload
            // 
            this.Reload.Enabled = false;
            this.Reload.Image = new Bitmap("Resources/Reload.Image.png");// global::UQMEdit.Properties.Resources.Reload_Image;
            this.Reload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Reload.Name = "Reload";
            this.Reload.Size = new System.Drawing.Size(63, 22);
            this.Reload.Text = "Reload";
            this.Reload.Click += new System.EventHandler(this.Reload_Click);
            // 
            // Save
            // 
            this.Save.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.Save.Enabled = false;
            this.Save.Image = new Bitmap("Resources/Save.Image.png"); // global::UQMEdit.Properties.Resources.Save_Image;
            this.Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(23, 22);
            this.Save.Text = "Save";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // version
            // 
            this.version.Alignment = ToolStripItemAlignment.Right;
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(37, 22);
            this.version.Text = "v1.0.0";
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.Summary);
            this.Tabs.Controls.Add(this.Coordinates);
            this.Tabs.Enabled = false;
            this.Tabs.Location = new System.Drawing.Point(2, 28);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(871, 500);
            this.Tabs.TabIndex = 1;
            // 
            // Summary
            // 
            this.Summary.Controls.Add(this.megaModModes);
            this.Summary.Controls.Add(this.DevicesBox);
            this.Summary.Controls.Add(this.TotalMinerals);
            this.Summary.Controls.Add(this.ThrusterBox);
            this.Summary.Controls.Add(this.JetsBox);
            this.Summary.Controls.Add(this.SeedBox);
            this.Summary.Controls.Add(this.ShipNameBox);
            this.Summary.Controls.Add(this.CaptainBox);
            this.Summary.Controls.Add(this.ShipsBox);
            this.Summary.Controls.Add(this.ModulesBox);
            this.Summary.Controls.Add(this.ShipStatusBox);
            this.Summary.Controls.Add(this.CargoBox);
            this.Summary.Location = new System.Drawing.Point(4, 22);
            this.Summary.Name = "Summary";
            this.Summary.Padding = new Padding(3);
            this.Summary.Size = new System.Drawing.Size(863, 474);
            this.Summary.TabIndex = 0;
            this.Summary.Text = "Summary";
            this.Summary.UseVisualStyleBackColor = true;
            // 
            // DevicesBox
            // 
            this.DevicesBox.Controls.Add(this.Devices);
            this.DevicesBox.Location = new System.Drawing.Point(6, 267);
            this.DevicesBox.Name = "DevicesBox";
            this.DevicesBox.Size = new System.Drawing.Size(172, 148);
            this.DevicesBox.TabIndex = 78;
            this.DevicesBox.TabStop = false;
            this.DevicesBox.Text = "Devices";
            // 
            // Devices
            // 
            this.Devices.FormattingEnabled = true;
            this.Devices.Location = new System.Drawing.Point(6, 19);
            this.Devices.Name = "Devices";
            this.Devices.SelectionMode = SelectionMode.None;
            this.Devices.Size = new System.Drawing.Size(160, 121);
            this.Devices.TabIndex = 1;
            // 
            // TotalMinerals
            // 
            this.TotalMinerals.Location = new System.Drawing.Point(96, 233);
            this.TotalMinerals.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.TotalMinerals.Name = "TotalMinerals";
            this.TotalMinerals.ReadOnly = true;
            this.TotalMinerals.Size = new System.Drawing.Size(76, 20);
            this.TotalMinerals.TabIndex = 16;
            this.TotalMinerals.TextAlign = HorizontalAlignment.Center;
            // 
            // ThrusterBox
            // 
            this.ThrusterBox.Controls.Add(this.MaxThrustLabel);
            this.ThrusterBox.Controls.Add(this.MaxThrusters);
            this.ThrusterBox.Controls.Add(this.Thruster10);
            this.ThrusterBox.Controls.Add(this.Thruster9);
            this.ThrusterBox.Controls.Add(this.Thruster8);
            this.ThrusterBox.Controls.Add(this.Thruster7);
            this.ThrusterBox.Controls.Add(this.Thruster6);
            this.ThrusterBox.Controls.Add(this.Thruster5);
            this.ThrusterBox.Controls.Add(this.Thruster4);
            this.ThrusterBox.Controls.Add(this.Thruster3);
            this.ThrusterBox.Controls.Add(this.Thruster2);
            this.ThrusterBox.Controls.Add(this.Thruster1);
            this.ThrusterBox.Controls.Add(this.Thruster0);
            this.ThrusterBox.Location = new System.Drawing.Point(727, 6);
            this.ThrusterBox.Name = "ThrusterBox";
            this.ThrusterBox.Size = new System.Drawing.Size(65, 272);
            this.ThrusterBox.TabIndex = 77;
            this.ThrusterBox.TabStop = false;
            this.ThrusterBox.Text = "AntiMat Thrusters";
            // 
            // MaxThrustLabel
            // 
            this.MaxThrustLabel.AutoSize = true;
            this.MaxThrustLabel.Location = new System.Drawing.Point(26, 252);
            this.MaxThrustLabel.Name = "MaxThrustLabel";
            this.MaxThrustLabel.Size = new System.Drawing.Size(27, 13);
            this.MaxThrustLabel.TabIndex = 2;
            this.MaxThrustLabel.Text = "Max";
            // 
            // MaxThrusters
            // 
            this.MaxThrusters.Location = new System.Drawing.Point(5, 251);
            this.MaxThrusters.Name = "MaxThrusters";
            this.MaxThrusters.Size = new System.Drawing.Size(15, 14);
            this.MaxThrusters.TabIndex = 1;
            this.MaxThrusters.UseVisualStyleBackColor = true;
            this.MaxThrusters.Click += new System.EventHandler(this.MaxThrusters_Click);
            // 
            // Thruster10
            // 
            this.Thruster10.AutoSize = true;
            this.Thruster10.Location = new System.Drawing.Point(6, 231);
            this.Thruster10.Name = "Thruster10";
            this.Thruster10.Size = new System.Drawing.Size(15, 14);
            this.Thruster10.TabIndex = 0;
            this.Thruster10.UseVisualStyleBackColor = true;
            // 
            // Thruster9
            // 
            this.Thruster9.AutoSize = true;
            this.Thruster9.Location = new System.Drawing.Point(6, 211);
            this.Thruster9.Name = "Thruster9";
            this.Thruster9.Size = new System.Drawing.Size(15, 14);
            this.Thruster9.TabIndex = 0;
            this.Thruster9.UseVisualStyleBackColor = true;
            // 
            // Thruster8
            // 
            this.Thruster8.AutoSize = true;
            this.Thruster8.Location = new System.Drawing.Point(6, 191);
            this.Thruster8.Name = "Thruster8";
            this.Thruster8.Size = new System.Drawing.Size(15, 14);
            this.Thruster8.TabIndex = 0;
            this.Thruster8.UseVisualStyleBackColor = true;
            // 
            // Thruster7
            // 
            this.Thruster7.AutoSize = true;
            this.Thruster7.Location = new System.Drawing.Point(6, 171);
            this.Thruster7.Name = "Thruster7";
            this.Thruster7.Size = new System.Drawing.Size(15, 14);
            this.Thruster7.TabIndex = 0;
            this.Thruster7.UseVisualStyleBackColor = true;
            // 
            // Thruster6
            // 
            this.Thruster6.AutoSize = true;
            this.Thruster6.Location = new System.Drawing.Point(6, 151);
            this.Thruster6.Name = "Thruster6";
            this.Thruster6.Size = new System.Drawing.Size(15, 14);
            this.Thruster6.TabIndex = 0;
            this.Thruster6.UseVisualStyleBackColor = true;
            // 
            // Thruster5
            // 
            this.Thruster5.AutoSize = true;
            this.Thruster5.Location = new System.Drawing.Point(6, 131);
            this.Thruster5.Name = "Thruster5";
            this.Thruster5.Size = new System.Drawing.Size(15, 14);
            this.Thruster5.TabIndex = 0;
            this.Thruster5.UseVisualStyleBackColor = true;
            // 
            // Thruster4
            // 
            this.Thruster4.AutoSize = true;
            this.Thruster4.Location = new System.Drawing.Point(6, 111);
            this.Thruster4.Name = "Thruster4";
            this.Thruster4.Size = new System.Drawing.Size(15, 14);
            this.Thruster4.TabIndex = 0;
            this.Thruster4.UseVisualStyleBackColor = true;
            // 
            // Thruster3
            // 
            this.Thruster3.AutoSize = true;
            this.Thruster3.Location = new System.Drawing.Point(6, 91);
            this.Thruster3.Name = "Thruster3";
            this.Thruster3.Size = new System.Drawing.Size(15, 14);
            this.Thruster3.TabIndex = 0;
            this.Thruster3.UseVisualStyleBackColor = true;
            // 
            // Thruster2
            // 
            this.Thruster2.AutoSize = true;
            this.Thruster2.Location = new System.Drawing.Point(6, 71);
            this.Thruster2.Name = "Thruster2";
            this.Thruster2.Size = new System.Drawing.Size(15, 14);
            this.Thruster2.TabIndex = 0;
            this.Thruster2.UseVisualStyleBackColor = true;
            // 
            // Thruster1
            // 
            this.Thruster1.AutoSize = true;
            this.Thruster1.Location = new System.Drawing.Point(6, 51);
            this.Thruster1.Name = "Thruster1";
            this.Thruster1.Size = new System.Drawing.Size(15, 14);
            this.Thruster1.TabIndex = 0;
            this.Thruster1.UseVisualStyleBackColor = true;
            // 
            // Thruster0
            // 
            this.Thruster0.AutoSize = true;
            this.Thruster0.Location = new System.Drawing.Point(6, 31);
            this.Thruster0.Name = "Thruster0";
            this.Thruster0.Size = new System.Drawing.Size(15, 14);
            this.Thruster0.TabIndex = 0;
            this.Thruster0.UseVisualStyleBackColor = true;
            // 
            // JetsBox
            // 
            this.JetsBox.Controls.Add(this.MaxJetsLabel);
            this.JetsBox.Controls.Add(this.Jets7);
            this.JetsBox.Controls.Add(this.MaxJets);
            this.JetsBox.Controls.Add(this.Jets6);
            this.JetsBox.Controls.Add(this.Jets5);
            this.JetsBox.Controls.Add(this.Jets4);
            this.JetsBox.Controls.Add(this.Jets3);
            this.JetsBox.Controls.Add(this.Jets2);
            this.JetsBox.Controls.Add(this.Jets1);
            this.JetsBox.Controls.Add(this.Jets0);
            this.JetsBox.Location = new System.Drawing.Point(798, 6);
            this.JetsBox.Name = "JetsBox";
            this.JetsBox.Size = new System.Drawing.Size(57, 211);
            this.JetsBox.TabIndex = 77;
            this.JetsBox.TabStop = false;
            this.JetsBox.Text = "Turning Jets";
            // 
            // MaxJetsLabel
            // 
            this.MaxJetsLabel.AutoSize = true;
            this.MaxJetsLabel.Location = new System.Drawing.Point(26, 192);
            this.MaxJetsLabel.Name = "MaxJetsLabel";
            this.MaxJetsLabel.Size = new System.Drawing.Size(27, 13);
            this.MaxJetsLabel.TabIndex = 2;
            this.MaxJetsLabel.Text = "Max";
            // 
            // Jets7
            // 
            this.Jets7.AutoSize = true;
            this.Jets7.Location = new System.Drawing.Point(6, 171);
            this.Jets7.Name = "Jets7";
            this.Jets7.Size = new System.Drawing.Size(15, 14);
            this.Jets7.TabIndex = 0;
            this.Jets7.UseVisualStyleBackColor = true;
            // 
            // MaxJets
            // 
            this.MaxJets.Location = new System.Drawing.Point(5, 191);
            this.MaxJets.Name = "MaxJets";
            this.MaxJets.Size = new System.Drawing.Size(15, 14);
            this.MaxJets.TabIndex = 1;
            this.MaxJets.UseVisualStyleBackColor = true;
            this.MaxJets.Click += new System.EventHandler(this.MaxJets_Click);
            // 
            // Jets6
            // 
            this.Jets6.AutoSize = true;
            this.Jets6.Location = new System.Drawing.Point(6, 151);
            this.Jets6.Name = "Jets6";
            this.Jets6.Size = new System.Drawing.Size(15, 14);
            this.Jets6.TabIndex = 0;
            this.Jets6.UseVisualStyleBackColor = true;
            // 
            // Jets5
            // 
            this.Jets5.AutoSize = true;
            this.Jets5.Location = new System.Drawing.Point(6, 131);
            this.Jets5.Name = "Jets5";
            this.Jets5.Size = new System.Drawing.Size(15, 14);
            this.Jets5.TabIndex = 0;
            this.Jets5.UseVisualStyleBackColor = true;
            // 
            // Jets4
            // 
            this.Jets4.AutoSize = true;
            this.Jets4.Location = new System.Drawing.Point(6, 111);
            this.Jets4.Name = "Jets4";
            this.Jets4.Size = new System.Drawing.Size(15, 14);
            this.Jets4.TabIndex = 0;
            this.Jets4.UseVisualStyleBackColor = true;
            // 
            // Jets3
            // 
            this.Jets3.AutoSize = true;
            this.Jets3.Location = new System.Drawing.Point(6, 91);
            this.Jets3.Name = "Jets3";
            this.Jets3.Size = new System.Drawing.Size(15, 14);
            this.Jets3.TabIndex = 0;
            this.Jets3.UseVisualStyleBackColor = true;
            // 
            // Jets2
            // 
            this.Jets2.AutoSize = true;
            this.Jets2.Location = new System.Drawing.Point(6, 71);
            this.Jets2.Name = "Jets2";
            this.Jets2.Size = new System.Drawing.Size(15, 14);
            this.Jets2.TabIndex = 0;
            this.Jets2.UseVisualStyleBackColor = true;
            // 
            // Jets1
            // 
            this.Jets1.AutoSize = true;
            this.Jets1.Location = new System.Drawing.Point(6, 51);
            this.Jets1.Name = "Jets1";
            this.Jets1.Size = new System.Drawing.Size(15, 14);
            this.Jets1.TabIndex = 0;
            this.Jets1.UseVisualStyleBackColor = true;
            // 
            // Jets0
            // 
            this.Jets0.AutoSize = true;
            this.Jets0.Location = new System.Drawing.Point(6, 31);
            this.Jets0.Name = "Jets0";
            this.Jets0.Size = new System.Drawing.Size(15, 14);
            this.Jets0.TabIndex = 0;
            this.Jets0.UseVisualStyleBackColor = true;
            // 
            // SeedBox
            // 
            this.SeedBox.Controls.Add(this.CustomSeed);
            this.SeedBox.Location = new System.Drawing.Point(6, 421);
            this.SeedBox.Name = "SeedBox";
            this.SeedBox.Size = new System.Drawing.Size(172, 47);
            this.SeedBox.TabIndex = 76;
            this.SeedBox.TabStop = false;
            this.SeedBox.Text = "Seed";
            this.SeedBox.Visible = false;
            // 
            // CustomSeed
            // 
            this.CustomSeed.Location = new System.Drawing.Point(6, 19);
            this.CustomSeed.Name = "CustomSeed";
            this.CustomSeed.ReadOnly = true;
            this.CustomSeed.Size = new System.Drawing.Size(160, 20);
            this.CustomSeed.TabIndex = 70;
            this.CustomSeed.TextAlign = HorizontalAlignment.Center;
            this.ReadOnly.SetToolTip(this.CustomSeed, "Read Only");
            // 
            // ShipNameBox
            // 
            this.ShipNameBox.Controls.Add(this.ShipName);
            this.ShipNameBox.Location = new System.Drawing.Point(184, 60);
            this.ShipNameBox.Name = "ShipNameBox";
            this.ShipNameBox.Size = new System.Drawing.Size(164, 47);
            this.ShipNameBox.TabIndex = 75;
            this.ShipNameBox.TabStop = false;
            this.ShipNameBox.Text = "Ship\'s Name";
            // 
            // ShipName
            // 
            this.ShipName.Location = new System.Drawing.Point(6, 19);
            this.ShipName.MaxLength = 16;
            this.ShipName.Name = "ShipName";
            this.ShipName.Size = new System.Drawing.Size(152, 20);
            this.ShipName.TabIndex = 0;
            this.ShipName.TextAlign = HorizontalAlignment.Center;
            // 
            // CaptainBox
            // 
            this.CaptainBox.Controls.Add(this.CommanderName);
            this.CaptainBox.Location = new System.Drawing.Point(184, 6);
            this.CaptainBox.Name = "CaptainBox";
            this.CaptainBox.Size = new System.Drawing.Size(164, 48);
            this.CaptainBox.TabIndex = 74;
            this.CaptainBox.TabStop = false;
            this.CaptainBox.Text = "Captain\'s Name";
            // 
            // CommanderName
            // 
            this.CommanderName.Location = new System.Drawing.Point(6, 19);
            this.CommanderName.MaxLength = 16;
            this.CommanderName.Name = "CommanderName";
            this.CommanderName.Size = new System.Drawing.Size(152, 20);
            this.CommanderName.TabIndex = 1;
            this.CommanderName.TextAlign = HorizontalAlignment.Center;
            // 
            // ShipsBox
            // 
            this.ShipsBox.Controls.Add(this.Ship01);
            this.ShipsBox.Controls.Add(this.Ship02);
            this.ShipsBox.Controls.Add(this.Ship03);
            this.ShipsBox.Controls.Add(this.Ship04);
            this.ShipsBox.Controls.Add(this.Ship05);
            this.ShipsBox.Controls.Add(this.Ship06);
            this.ShipsBox.Controls.Add(this.Ship07);
            this.ShipsBox.Controls.Add(this.Ship08);
            this.ShipsBox.Controls.Add(this.Ship09);
            this.ShipsBox.Controls.Add(this.Ship10);
            this.ShipsBox.Controls.Add(this.Ship11);
            this.ShipsBox.Controls.Add(this.Ship12);
            this.ShipsBox.Controls.Add(this.ShipLabel01);
            this.ShipsBox.Controls.Add(this.ShipLabel12);
            this.ShipsBox.Controls.Add(this.ShipLabel02);
            this.ShipsBox.Controls.Add(this.ShipLabel11);
            this.ShipsBox.Controls.Add(this.ShipLabel10);
            this.ShipsBox.Controls.Add(this.ShipLabel03);
            this.ShipsBox.Controls.Add(this.ShipLabel09);
            this.ShipsBox.Controls.Add(this.ShipLabel08);
            this.ShipsBox.Controls.Add(this.ShipLabel04);
            this.ShipsBox.Controls.Add(this.ShipLabel07);
            this.ShipsBox.Controls.Add(this.ShipLabel06);
            this.ShipsBox.Controls.Add(this.ShipLabel05);
            this.ShipsBox.Location = new System.Drawing.Point(562, 6);
            this.ShipsBox.Name = "ShipsBox";
            this.ShipsBox.Size = new System.Drawing.Size(159, 343);
            this.ShipsBox.TabIndex = 73;
            this.ShipsBox.TabStop = false;
            this.ShipsBox.Text = "Ships";
            // 
            // Ship01
            // 
            this.Ship01.BackColor = System.Drawing.SystemColors.Menu;
            this.Ship01.DisplayMember = "Text";
            this.Ship01.DropDownStyle = ComboBoxStyle.Simple;
            this.Ship01.FormattingEnabled = true;
            this.Ship01.Location = new System.Drawing.Point(28, 19);
            this.Ship01.Name = "Ship01";
            this.Ship01.Size = new System.Drawing.Size(125, 21);
            this.Ship01.TabIndex = 0;
            this.Ship01.ValueMember = "HexCode";
            // 
            // Ship02
            // 
            this.Ship02.BackColor = System.Drawing.SystemColors.Menu;
            this.Ship02.DisplayMember = "Text";
            this.Ship02.DropDownStyle = ComboBoxStyle.Simple;
            this.Ship02.FormattingEnabled = true;
            this.Ship02.Location = new System.Drawing.Point(28, 46);
            this.Ship02.Name = "Ship02";
            this.Ship02.Size = new System.Drawing.Size(125, 21);
            this.Ship02.TabIndex = 1;
            this.Ship02.ValueMember = "HexCode";
            // 
            // Ship03
            // 
            this.Ship03.BackColor = System.Drawing.SystemColors.Menu;
            this.Ship03.DisplayMember = "Text";
            this.Ship03.DropDownStyle = ComboBoxStyle.Simple;
            this.Ship03.FormattingEnabled = true;
            this.Ship03.Location = new System.Drawing.Point(28, 73);
            this.Ship03.Name = "Ship03";
            this.Ship03.Size = new System.Drawing.Size(125, 21);
            this.Ship03.TabIndex = 2;
            this.Ship03.ValueMember = "HexCode";
            // 
            // Ship04
            // 
            this.Ship04.BackColor = System.Drawing.SystemColors.Menu;
            this.Ship04.DisplayMember = "Text";
            this.Ship04.DropDownStyle = ComboBoxStyle.Simple;
            this.Ship04.FormattingEnabled = true;
            this.Ship04.Location = new System.Drawing.Point(28, 100);
            this.Ship04.Name = "Ship04";
            this.Ship04.Size = new System.Drawing.Size(125, 21);
            this.Ship04.TabIndex = 3;
            this.Ship04.ValueMember = "HexCode";
            // 
            // Ship05
            // 
            this.Ship05.BackColor = System.Drawing.SystemColors.Menu;
            this.Ship05.DisplayMember = "Text";
            this.Ship05.DropDownStyle = ComboBoxStyle.Simple;
            this.Ship05.FormattingEnabled = true;
            this.Ship05.Location = new System.Drawing.Point(28, 127);
            this.Ship05.Name = "Ship05";
            this.Ship05.Size = new System.Drawing.Size(125, 21);
            this.Ship05.TabIndex = 4;
            this.Ship05.ValueMember = "HexCode";
            // 
            // Ship06
            // 
            this.Ship06.BackColor = System.Drawing.SystemColors.Menu;
            this.Ship06.DisplayMember = "Text";
            this.Ship06.DropDownStyle = ComboBoxStyle.Simple;
            this.Ship06.FormattingEnabled = true;
            this.Ship06.Location = new System.Drawing.Point(28, 154);
            this.Ship06.Name = "Ship06";
            this.Ship06.Size = new System.Drawing.Size(125, 21);
            this.Ship06.TabIndex = 5;
            this.Ship06.ValueMember = "HexCode";
            // 
            // Ship07
            // 
            this.Ship07.BackColor = System.Drawing.SystemColors.Menu;
            this.Ship07.DisplayMember = "Text";
            this.Ship07.DropDownStyle = ComboBoxStyle.Simple;
            this.Ship07.FormattingEnabled = true;
            this.Ship07.Location = new System.Drawing.Point(28, 180);
            this.Ship07.Name = "Ship07";
            this.Ship07.Size = new System.Drawing.Size(125, 21);
            this.Ship07.TabIndex = 6;
            this.Ship07.ValueMember = "HexCode";
            // 
            // Ship08
            // 
            this.Ship08.BackColor = System.Drawing.SystemColors.Menu;
            this.Ship08.DisplayMember = "Text";
            this.Ship08.DropDownStyle = ComboBoxStyle.Simple;
            this.Ship08.FormattingEnabled = true;
            this.Ship08.Location = new System.Drawing.Point(28, 207);
            this.Ship08.Name = "Ship08";
            this.Ship08.Size = new System.Drawing.Size(125, 21);
            this.Ship08.TabIndex = 7;
            this.Ship08.ValueMember = "HexCode";
            // 
            // Ship09
            // 
            this.Ship09.BackColor = System.Drawing.SystemColors.Menu;
            this.Ship09.DisplayMember = "Text";
            this.Ship09.DropDownStyle = ComboBoxStyle.Simple;
            this.Ship09.FormattingEnabled = true;
            this.Ship09.Location = new System.Drawing.Point(28, 234);
            this.Ship09.Name = "Ship09";
            this.Ship09.Size = new System.Drawing.Size(125, 21);
            this.Ship09.TabIndex = 8;
            this.Ship09.ValueMember = "HexCode";
            // 
            // Ship10
            // 
            this.Ship10.BackColor = System.Drawing.SystemColors.Menu;
            this.Ship10.DisplayMember = "Text";
            this.Ship10.DropDownStyle = ComboBoxStyle.Simple;
            this.Ship10.FormattingEnabled = true;
            this.Ship10.Location = new System.Drawing.Point(28, 261);
            this.Ship10.Name = "Ship10";
            this.Ship10.Size = new System.Drawing.Size(125, 21);
            this.Ship10.TabIndex = 9;
            this.Ship10.ValueMember = "HexCode";
            // 
            // Ship11
            // 
            this.Ship11.BackColor = System.Drawing.SystemColors.Menu;
            this.Ship11.DisplayMember = "Text";
            this.Ship11.DropDownStyle = ComboBoxStyle.Simple;
            this.Ship11.FormattingEnabled = true;
            this.Ship11.Location = new System.Drawing.Point(28, 288);
            this.Ship11.Name = "Ship11";
            this.Ship11.Size = new System.Drawing.Size(125, 21);
            this.Ship11.TabIndex = 10;
            this.Ship11.ValueMember = "HexCode";
            // 
            // Ship12
            // 
            this.Ship12.BackColor = System.Drawing.SystemColors.Menu;
            this.Ship12.DisplayMember = "Text";
            this.Ship12.DropDownStyle = ComboBoxStyle.Simple;
            this.Ship12.FormattingEnabled = true;
            this.Ship12.Location = new System.Drawing.Point(28, 315);
            this.Ship12.Name = "Ship12";
            this.Ship12.Size = new System.Drawing.Size(125, 21);
            this.Ship12.TabIndex = 11;
            this.Ship12.ValueMember = "HexCode";
            // 
            // ShipLabel01
            // 
            this.ShipLabel01.AutoSize = true;
            this.ShipLabel01.Location = new System.Drawing.Point(3, 22);
            this.ShipLabel01.Name = "ShipLabel01";
            this.ShipLabel01.Size = new System.Drawing.Size(19, 13);
            this.ShipLabel01.TabIndex = 8;
            this.ShipLabel01.Text = "01";
            // 
            // ShipLabel12
            // 
            this.ShipLabel12.AutoSize = true;
            this.ShipLabel12.Location = new System.Drawing.Point(2, 318);
            this.ShipLabel12.Name = "ShipLabel12";
            this.ShipLabel12.Size = new System.Drawing.Size(19, 13);
            this.ShipLabel12.TabIndex = 23;
            this.ShipLabel12.Text = "12";
            // 
            // ShipLabel02
            // 
            this.ShipLabel02.AutoSize = true;
            this.ShipLabel02.Location = new System.Drawing.Point(3, 49);
            this.ShipLabel02.Name = "ShipLabel02";
            this.ShipLabel02.Size = new System.Drawing.Size(19, 13);
            this.ShipLabel02.TabIndex = 9;
            this.ShipLabel02.Text = "02";
            // 
            // ShipLabel11
            // 
            this.ShipLabel11.AutoSize = true;
            this.ShipLabel11.Location = new System.Drawing.Point(2, 291);
            this.ShipLabel11.Name = "ShipLabel11";
            this.ShipLabel11.Size = new System.Drawing.Size(19, 13);
            this.ShipLabel11.TabIndex = 21;
            this.ShipLabel11.Text = "11";
            // 
            // ShipLabel10
            // 
            this.ShipLabel10.AutoSize = true;
            this.ShipLabel10.Location = new System.Drawing.Point(2, 264);
            this.ShipLabel10.Name = "ShipLabel10";
            this.ShipLabel10.Size = new System.Drawing.Size(19, 13);
            this.ShipLabel10.TabIndex = 19;
            this.ShipLabel10.Text = "10";
            // 
            // ShipLabel03
            // 
            this.ShipLabel03.AutoSize = true;
            this.ShipLabel03.Location = new System.Drawing.Point(3, 76);
            this.ShipLabel03.Name = "ShipLabel03";
            this.ShipLabel03.Size = new System.Drawing.Size(19, 13);
            this.ShipLabel03.TabIndex = 10;
            this.ShipLabel03.Text = "03";
            // 
            // ShipLabel09
            // 
            this.ShipLabel09.AutoSize = true;
            this.ShipLabel09.Location = new System.Drawing.Point(3, 237);
            this.ShipLabel09.Name = "ShipLabel09";
            this.ShipLabel09.Size = new System.Drawing.Size(19, 13);
            this.ShipLabel09.TabIndex = 17;
            this.ShipLabel09.Text = "09";
            // 
            // ShipLabel08
            // 
            this.ShipLabel08.AutoSize = true;
            this.ShipLabel08.Location = new System.Drawing.Point(3, 210);
            this.ShipLabel08.Name = "ShipLabel08";
            this.ShipLabel08.Size = new System.Drawing.Size(19, 13);
            this.ShipLabel08.TabIndex = 15;
            this.ShipLabel08.Text = "08";
            // 
            // ShipLabel04
            // 
            this.ShipLabel04.AutoSize = true;
            this.ShipLabel04.Location = new System.Drawing.Point(3, 103);
            this.ShipLabel04.Name = "ShipLabel04";
            this.ShipLabel04.Size = new System.Drawing.Size(19, 13);
            this.ShipLabel04.TabIndex = 11;
            this.ShipLabel04.Text = "04";
            // 
            // ShipLabel07
            // 
            this.ShipLabel07.AutoSize = true;
            this.ShipLabel07.Location = new System.Drawing.Point(3, 183);
            this.ShipLabel07.Name = "ShipLabel07";
            this.ShipLabel07.Size = new System.Drawing.Size(19, 13);
            this.ShipLabel07.TabIndex = 14;
            this.ShipLabel07.Text = "07";
            // 
            // ShipLabel06
            // 
            this.ShipLabel06.AutoSize = true;
            this.ShipLabel06.Location = new System.Drawing.Point(3, 157);
            this.ShipLabel06.Name = "ShipLabel06";
            this.ShipLabel06.Size = new System.Drawing.Size(19, 13);
            this.ShipLabel06.TabIndex = 13;
            this.ShipLabel06.Text = "06";
            // 
            // ShipLabel05
            // 
            this.ShipLabel05.AutoSize = true;
            this.ShipLabel05.Location = new System.Drawing.Point(3, 130);
            this.ShipLabel05.Name = "ShipLabel05";
            this.ShipLabel05.Size = new System.Drawing.Size(19, 13);
            this.ShipLabel05.TabIndex = 12;
            this.ShipLabel05.Text = "05";
            // 
            // ModulesBox
            // 
            this.ModulesBox.Controls.Add(this.MaxModulesLabel);
            this.ModulesBox.Controls.Add(this.UpgradeToMax);
            this.ModulesBox.Controls.Add(this.Module16);
            this.ModulesBox.Controls.Add(this.Module15);
            this.ModulesBox.Controls.Add(this.Module14);
            this.ModulesBox.Controls.Add(this.Module13);
            this.ModulesBox.Controls.Add(this.Module12);
            this.ModulesBox.Controls.Add(this.Module11);
            this.ModulesBox.Controls.Add(this.Module10);
            this.ModulesBox.Controls.Add(this.Module09);
            this.ModulesBox.Controls.Add(this.Module08);
            this.ModulesBox.Controls.Add(this.Module07);
            this.ModulesBox.Controls.Add(this.Module06);
            this.ModulesBox.Controls.Add(this.ModuleLabel01);
            this.ModulesBox.Controls.Add(this.ModuleLabel02);
            this.ModulesBox.Controls.Add(this.Module05);
            this.ModulesBox.Controls.Add(this.ModuleLabel03);
            this.ModulesBox.Controls.Add(this.Module04);
            this.ModulesBox.Controls.Add(this.ModuleLabel04);
            this.ModulesBox.Controls.Add(this.Module03);
            this.ModulesBox.Controls.Add(this.ModuleLabel05);
            this.ModulesBox.Controls.Add(this.Module02);
            this.ModulesBox.Controls.Add(this.ModuleLabel06);
            this.ModulesBox.Controls.Add(this.Module01);
            this.ModulesBox.Controls.Add(this.ModuleLabel07);
            this.ModulesBox.Controls.Add(this.ModuleLabel16);
            this.ModulesBox.Controls.Add(this.ModuleLabel08);
            this.ModulesBox.Controls.Add(this.ModuleLabel15);
            this.ModulesBox.Controls.Add(this.ModuleLabel09);
            this.ModulesBox.Controls.Add(this.ModuleLabel14);
            this.ModulesBox.Controls.Add(this.ModuleLabel10);
            this.ModulesBox.Controls.Add(this.ModuleLabel13);
            this.ModulesBox.Controls.Add(this.ModuleLabel11);
            this.ModulesBox.Controls.Add(this.ModuleLabel12);
            this.ModulesBox.Location = new System.Drawing.Point(354, 6);
            this.ModulesBox.Name = "ModulesBox";
            this.ModulesBox.Size = new System.Drawing.Size(202, 456);
            this.ModulesBox.TabIndex = 72;
            this.ModulesBox.TabStop = false;
            this.ModulesBox.Text = "Modules";
            // 
            // MaxModulesLabel
            // 
            this.MaxModulesLabel.AutoSize = true;
            this.MaxModulesLabel.Location = new System.Drawing.Point(149, 9);
            this.MaxModulesLabel.Name = "MaxModulesLabel";
            this.MaxModulesLabel.Size = new System.Drawing.Size(27, 13);
            this.MaxModulesLabel.TabIndex = 32;
            this.MaxModulesLabel.Text = "Max";
            // 
            // UpgradeToMax
            // 
            this.UpgradeToMax.Location = new System.Drawing.Point(182, 8);
            this.UpgradeToMax.Name = "UpgradeToMax";
            this.UpgradeToMax.Size = new System.Drawing.Size(15, 14);
            this.UpgradeToMax.TabIndex = 0;
            this.UpgradeToMax.UseVisualStyleBackColor = true;
            this.UpgradeToMax.Click += new System.EventHandler(this.UpgradeToMax_Click);
            // 
            // Module16
            // 
            this.Module16.DisplayMember = "Text";
            this.Module16.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Module16.FlatStyle = FlatStyle.System;
            this.Module16.FormattingEnabled = true;
            this.Module16.Location = new System.Drawing.Point(74, 428);
            this.Module16.Name = "Module16";
            this.Module16.Size = new System.Drawing.Size(122, 21);
            this.Module16.TabIndex = 15;
            this.Module16.ValueMember = "HexCode";
            this.Module16.SelectedIndexChanged += new System.EventHandler(this.Module_SelectedIndexChanged);
            // 
            // Module15
            // 
            this.Module15.DisplayMember = "Text";
            this.Module15.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Module15.FlatStyle = FlatStyle.System;
            this.Module15.FormattingEnabled = true;
            this.Module15.Location = new System.Drawing.Point(74, 401);
            this.Module15.Name = "Module15";
            this.Module15.Size = new System.Drawing.Size(122, 21);
            this.Module15.TabIndex = 14;
            this.Module15.ValueMember = "HexCode";
            this.Module15.SelectedIndexChanged += new System.EventHandler(this.Module_SelectedIndexChanged);
            // 
            // Module14
            // 
            this.Module14.DisplayMember = "Text";
            this.Module14.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Module14.FlatStyle = FlatStyle.System;
            this.Module14.FormattingEnabled = true;
            this.Module14.Location = new System.Drawing.Point(74, 374);
            this.Module14.Name = "Module14";
            this.Module14.Size = new System.Drawing.Size(122, 21);
            this.Module14.TabIndex = 13;
            this.Module14.ValueMember = "HexCode";
            this.Module14.SelectedIndexChanged += new System.EventHandler(this.Module_SelectedIndexChanged);
            // 
            // Module13
            // 
            this.Module13.DisplayMember = "Text";
            this.Module13.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Module13.FlatStyle = FlatStyle.System;
            this.Module13.FormattingEnabled = true;
            this.Module13.Location = new System.Drawing.Point(74, 347);
            this.Module13.Name = "Module13";
            this.Module13.Size = new System.Drawing.Size(122, 21);
            this.Module13.TabIndex = 12;
            this.Module13.ValueMember = "HexCode";
            this.Module13.SelectedIndexChanged += new System.EventHandler(this.Module_SelectedIndexChanged);
            // 
            // Module12
            // 
            this.Module12.DisplayMember = "Text";
            this.Module12.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Module12.FlatStyle = FlatStyle.System;
            this.Module12.FormattingEnabled = true;
            this.Module12.Location = new System.Drawing.Point(74, 320);
            this.Module12.Name = "Module12";
            this.Module12.Size = new System.Drawing.Size(122, 21);
            this.Module12.TabIndex = 11;
            this.Module12.ValueMember = "HexCode";
            this.Module12.SelectedIndexChanged += new System.EventHandler(this.Module_SelectedIndexChanged);
            // 
            // Module11
            // 
            this.Module11.DisplayMember = "Text";
            this.Module11.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Module11.FlatStyle = FlatStyle.System;
            this.Module11.FormattingEnabled = true;
            this.Module11.Location = new System.Drawing.Point(74, 293);
            this.Module11.Name = "Module11";
            this.Module11.Size = new System.Drawing.Size(122, 21);
            this.Module11.TabIndex = 10;
            this.Module11.ValueMember = "HexCode";
            this.Module11.SelectedIndexChanged += new System.EventHandler(this.Module_SelectedIndexChanged);
            // 
            // Module10
            // 
            this.Module10.DisplayMember = "Text";
            this.Module10.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Module10.FlatStyle = FlatStyle.System;
            this.Module10.FormattingEnabled = true;
            this.Module10.Location = new System.Drawing.Point(74, 266);
            this.Module10.Name = "Module10";
            this.Module10.Size = new System.Drawing.Size(122, 21);
            this.Module10.TabIndex = 9;
            this.Module10.ValueMember = "HexCode";
            this.Module10.SelectedIndexChanged += new System.EventHandler(this.Module_SelectedIndexChanged);
            // 
            // Module09
            // 
            this.Module09.DisplayMember = "Text";
            this.Module09.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Module09.FlatStyle = FlatStyle.System;
            this.Module09.FormattingEnabled = true;
            this.Module09.Location = new System.Drawing.Point(74, 239);
            this.Module09.Name = "Module09";
            this.Module09.Size = new System.Drawing.Size(122, 21);
            this.Module09.TabIndex = 8;
            this.Module09.ValueMember = "HexCode";
            this.Module09.SelectedIndexChanged += new System.EventHandler(this.Module_SelectedIndexChanged);
            // 
            // Module08
            // 
            this.Module08.DisplayMember = "Text";
            this.Module08.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Module08.FlatStyle = FlatStyle.System;
            this.Module08.FormattingEnabled = true;
            this.Module08.Location = new System.Drawing.Point(74, 212);
            this.Module08.Name = "Module08";
            this.Module08.Size = new System.Drawing.Size(122, 21);
            this.Module08.TabIndex = 7;
            this.Module08.ValueMember = "HexCode";
            this.Module08.SelectedIndexChanged += new System.EventHandler(this.Module_SelectedIndexChanged);
            // 
            // Module07
            // 
            this.Module07.DisplayMember = "Text";
            this.Module07.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Module07.FlatStyle = FlatStyle.System;
            this.Module07.FormattingEnabled = true;
            this.Module07.Location = new System.Drawing.Point(74, 185);
            this.Module07.Name = "Module07";
            this.Module07.Size = new System.Drawing.Size(122, 21);
            this.Module07.TabIndex = 6;
            this.Module07.ValueMember = "HexCode";
            this.Module07.SelectedIndexChanged += new System.EventHandler(this.Module_SelectedIndexChanged);
            // 
            // Module06
            // 
            this.Module06.DisplayMember = "Text";
            this.Module06.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Module06.FlatStyle = FlatStyle.System;
            this.Module06.FormattingEnabled = true;
            this.Module06.Location = new System.Drawing.Point(74, 158);
            this.Module06.Name = "Module06";
            this.Module06.Size = new System.Drawing.Size(122, 21);
            this.Module06.TabIndex = 5;
            this.Module06.ValueMember = "HexCode";
            this.Module06.SelectedIndexChanged += new System.EventHandler(this.Module_SelectedIndexChanged);
            // 
            // ModuleLabel01
            // 
            this.ModuleLabel01.AutoSize = true;
            this.ModuleLabel01.Location = new System.Drawing.Point(3, 26);
            this.ModuleLabel01.Name = "ModuleLabel01";
            this.ModuleLabel01.Size = new System.Drawing.Size(53, 13);
            this.ModuleLabel01.TabIndex = 8;
            this.ModuleLabel01.Text = "01 [Nose]";
            // 
            // ModuleLabel02
            // 
            this.ModuleLabel02.AutoSize = true;
            this.ModuleLabel02.Location = new System.Drawing.Point(3, 53);
            this.ModuleLabel02.Name = "ModuleLabel02";
            this.ModuleLabel02.Size = new System.Drawing.Size(62, 13);
            this.ModuleLabel02.TabIndex = 9;
            this.ModuleLabel02.Text = "02 [Spread]";
            // 
            // Module05
            // 
            this.Module05.DisplayMember = "Text";
            this.Module05.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Module05.FlatStyle = FlatStyle.System;
            this.Module05.FormattingEnabled = true;
            this.Module05.Location = new System.Drawing.Point(74, 131);
            this.Module05.Name = "Module05";
            this.Module05.Size = new System.Drawing.Size(122, 21);
            this.Module05.TabIndex = 4;
            this.Module05.ValueMember = "HexCode";
            this.Module05.SelectedIndexChanged += new System.EventHandler(this.Module_SelectedIndexChanged);
            // 
            // ModuleLabel03
            // 
            this.ModuleLabel03.AutoSize = true;
            this.ModuleLabel03.Location = new System.Drawing.Point(3, 78);
            this.ModuleLabel03.Name = "ModuleLabel03";
            this.ModuleLabel03.Size = new System.Drawing.Size(49, 13);
            this.ModuleLabel03.TabIndex = 10;
            this.ModuleLabel03.Text = "03 [Side]";
            // 
            // Module04
            // 
            this.Module04.DisplayMember = "Text";
            this.Module04.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Module04.FlatStyle = FlatStyle.System;
            this.Module04.FormattingEnabled = true;
            this.Module04.Location = new System.Drawing.Point(74, 104);
            this.Module04.Name = "Module04";
            this.Module04.Size = new System.Drawing.Size(122, 21);
            this.Module04.TabIndex = 3;
            this.Module04.ValueMember = "HexCode";
            this.Module04.SelectedIndexChanged += new System.EventHandler(this.Module_SelectedIndexChanged);
            // 
            // ModuleLabel04
            // 
            this.ModuleLabel04.AutoSize = true;
            this.ModuleLabel04.Location = new System.Drawing.Point(3, 107);
            this.ModuleLabel04.Name = "ModuleLabel04";
            this.ModuleLabel04.Size = new System.Drawing.Size(19, 13);
            this.ModuleLabel04.TabIndex = 11;
            this.ModuleLabel04.Text = "04";
            // 
            // Module03
            // 
            this.Module03.DisplayMember = "Text";
            this.Module03.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Module03.FlatStyle = FlatStyle.System;
            this.Module03.FormattingEnabled = true;
            this.Module03.Location = new System.Drawing.Point(74, 77);
            this.Module03.Name = "Module03";
            this.Module03.Size = new System.Drawing.Size(122, 21);
            this.Module03.TabIndex = 2;
            this.Module03.ValueMember = "HexCode";
            this.Module03.SelectedIndexChanged += new System.EventHandler(this.Module_SelectedIndexChanged);
            // 
            // ModuleLabel05
            // 
            this.ModuleLabel05.AutoSize = true;
            this.ModuleLabel05.Location = new System.Drawing.Point(3, 134);
            this.ModuleLabel05.Name = "ModuleLabel05";
            this.ModuleLabel05.Size = new System.Drawing.Size(19, 13);
            this.ModuleLabel05.TabIndex = 12;
            this.ModuleLabel05.Text = "05";
            // 
            // Module02
            // 
            this.Module02.DisplayMember = "Text";
            this.Module02.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Module02.FlatStyle = FlatStyle.System;
            this.Module02.FormattingEnabled = true;
            this.Module02.Location = new System.Drawing.Point(74, 50);
            this.Module02.Name = "Module02";
            this.Module02.Size = new System.Drawing.Size(122, 21);
            this.Module02.TabIndex = 1;
            this.Module02.ValueMember = "HexCode";
            this.Module02.SelectedIndexChanged += new System.EventHandler(this.Module_SelectedIndexChanged);
            // 
            // ModuleLabel06
            // 
            this.ModuleLabel06.AutoSize = true;
            this.ModuleLabel06.Location = new System.Drawing.Point(3, 161);
            this.ModuleLabel06.Name = "ModuleLabel06";
            this.ModuleLabel06.Size = new System.Drawing.Size(19, 13);
            this.ModuleLabel06.TabIndex = 13;
            this.ModuleLabel06.Text = "06";
            // 
            // Module01
            // 
            this.Module01.DisplayMember = "Text";
            this.Module01.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Module01.FlatStyle = FlatStyle.System;
            this.Module01.FormattingEnabled = true;
            this.Module01.Location = new System.Drawing.Point(74, 23);
            this.Module01.Name = "Module01";
            this.Module01.Size = new System.Drawing.Size(122, 21);
            this.Module01.TabIndex = 0;
            this.Module01.ValueMember = "HexCode";
            this.Module01.SelectedIndexChanged += new System.EventHandler(this.Module_SelectedIndexChanged);
            // 
            // ModuleLabel07
            // 
            this.ModuleLabel07.AutoSize = true;
            this.ModuleLabel07.Location = new System.Drawing.Point(3, 188);
            this.ModuleLabel07.Name = "ModuleLabel07";
            this.ModuleLabel07.Size = new System.Drawing.Size(19, 13);
            this.ModuleLabel07.TabIndex = 14;
            this.ModuleLabel07.Text = "07";
            // 
            // ModuleLabel16
            // 
            this.ModuleLabel16.AutoSize = true;
            this.ModuleLabel16.Location = new System.Drawing.Point(2, 431);
            this.ModuleLabel16.Name = "ModuleLabel16";
            this.ModuleLabel16.Size = new System.Drawing.Size(45, 13);
            this.ModuleLabel16.TabIndex = 31;
            this.ModuleLabel16.Text = "16 [Tail]";
            // 
            // ModuleLabel08
            // 
            this.ModuleLabel08.AutoSize = true;
            this.ModuleLabel08.Location = new System.Drawing.Point(3, 215);
            this.ModuleLabel08.Name = "ModuleLabel08";
            this.ModuleLabel08.Size = new System.Drawing.Size(19, 13);
            this.ModuleLabel08.TabIndex = 15;
            this.ModuleLabel08.Text = "08";
            // 
            // ModuleLabel15
            // 
            this.ModuleLabel15.AutoSize = true;
            this.ModuleLabel15.Location = new System.Drawing.Point(2, 404);
            this.ModuleLabel15.Name = "ModuleLabel15";
            this.ModuleLabel15.Size = new System.Drawing.Size(19, 13);
            this.ModuleLabel15.TabIndex = 29;
            this.ModuleLabel15.Text = "15";
            // 
            // ModuleLabel09
            // 
            this.ModuleLabel09.AutoSize = true;
            this.ModuleLabel09.Location = new System.Drawing.Point(3, 242);
            this.ModuleLabel09.Name = "ModuleLabel09";
            this.ModuleLabel09.Size = new System.Drawing.Size(19, 13);
            this.ModuleLabel09.TabIndex = 17;
            this.ModuleLabel09.Text = "09";
            // 
            // ModuleLabel14
            // 
            this.ModuleLabel14.AutoSize = true;
            this.ModuleLabel14.Location = new System.Drawing.Point(2, 377);
            this.ModuleLabel14.Name = "ModuleLabel14";
            this.ModuleLabel14.Size = new System.Drawing.Size(19, 13);
            this.ModuleLabel14.TabIndex = 27;
            this.ModuleLabel14.Text = "14";
            // 
            // ModuleLabel10
            // 
            this.ModuleLabel10.AutoSize = true;
            this.ModuleLabel10.Location = new System.Drawing.Point(2, 269);
            this.ModuleLabel10.Name = "ModuleLabel10";
            this.ModuleLabel10.Size = new System.Drawing.Size(19, 13);
            this.ModuleLabel10.TabIndex = 19;
            this.ModuleLabel10.Text = "10";
            // 
            // ModuleLabel13
            // 
            this.ModuleLabel13.AutoSize = true;
            this.ModuleLabel13.Location = new System.Drawing.Point(2, 350);
            this.ModuleLabel13.Name = "ModuleLabel13";
            this.ModuleLabel13.Size = new System.Drawing.Size(19, 13);
            this.ModuleLabel13.TabIndex = 25;
            this.ModuleLabel13.Text = "13";
            // 
            // ModuleLabel11
            // 
            this.ModuleLabel11.AutoSize = true;
            this.ModuleLabel11.Location = new System.Drawing.Point(2, 296);
            this.ModuleLabel11.Name = "ModuleLabel11";
            this.ModuleLabel11.Size = new System.Drawing.Size(19, 13);
            this.ModuleLabel11.TabIndex = 21;
            this.ModuleLabel11.Text = "11";
            // 
            // ModuleLabel12
            // 
            this.ModuleLabel12.AutoSize = true;
            this.ModuleLabel12.Location = new System.Drawing.Point(2, 323);
            this.ModuleLabel12.Name = "ModuleLabel12";
            this.ModuleLabel12.Size = new System.Drawing.Size(19, 13);
            this.ModuleLabel12.TabIndex = 23;
            this.ModuleLabel12.Text = "12";
            // 
            // ShipStatusBox
            // 
            this.ShipStatusBox.Controls.Add(this.Credits);
            this.ShipStatusBox.Controls.Add(this.label58);
            this.ShipStatusBox.Controls.Add(this.LandersLabel);
            this.ShipStatusBox.Controls.Add(this.BioDataLabel);
            this.ShipStatusBox.Controls.Add(this.RULabel);
            this.ShipStatusBox.Controls.Add(this.FuelLabel);
            this.ShipStatusBox.Controls.Add(this.LanderUpgradesBox);
            this.ShipStatusBox.Controls.Add(this.CrewLabel);
            this.ShipStatusBox.Controls.Add(this.Landers);
            this.ShipStatusBox.Controls.Add(this.BioData);
            this.ShipStatusBox.Controls.Add(this.ResourceUnits);
            this.ShipStatusBox.Controls.Add(this.ShipFuel);
            this.ShipStatusBox.Controls.Add(this.FlagshipCrew);
            this.ShipStatusBox.Location = new System.Drawing.Point(184, 113);
            this.ShipStatusBox.Name = "ShipStatusBox";
            this.ShipStatusBox.Size = new System.Drawing.Size(164, 355);
            this.ShipStatusBox.TabIndex = 3;
            this.ShipStatusBox.TabStop = false;
            this.ShipStatusBox.Text = "Ship Status";
            // 
            // Credits
            // 
            this.Credits.Location = new System.Drawing.Point(70, 149);
            this.Credits.MaxLength = 16;
            this.Credits.Name = "Credits";
            this.Credits.ReadOnly = true;
            this.Credits.Size = new System.Drawing.Size(88, 20);
            this.Credits.TabIndex = 16;
            this.Credits.TextAlign = HorizontalAlignment.Center;
            this.ReadOnly.SetToolTip(this.Credits, "Read Only");
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(6, 152);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(39, 13);
            this.label58.TabIndex = 15;
            this.label58.Text = "Credits";
            // 
            // LandersLabel
            // 
            this.LandersLabel.AutoSize = true;
            this.LandersLabel.Location = new System.Drawing.Point(6, 125);
            this.LandersLabel.Name = "LandersLabel";
            this.LandersLabel.Size = new System.Drawing.Size(45, 13);
            this.LandersLabel.TabIndex = 14;
            this.LandersLabel.Text = "Landers";
            // 
            // BioDataLabel
            // 
            this.BioDataLabel.AutoSize = true;
            this.BioDataLabel.Location = new System.Drawing.Point(6, 99);
            this.BioDataLabel.Name = "BioDataLabel";
            this.BioDataLabel.Size = new System.Drawing.Size(48, 13);
            this.BioDataLabel.TabIndex = 13;
            this.BioDataLabel.Text = "Bio Data";
            // 
            // RULabel
            // 
            this.RULabel.AutoSize = true;
            this.RULabel.Location = new System.Drawing.Point(6, 73);
            this.RULabel.Name = "RULabel";
            this.RULabel.Size = new System.Drawing.Size(29, 13);
            this.RULabel.TabIndex = 12;
            this.RULabel.Text = "R.U.";
            // 
            // FuelLabel
            // 
            this.FuelLabel.AutoSize = true;
            this.FuelLabel.Location = new System.Drawing.Point(6, 47);
            this.FuelLabel.Name = "FuelLabel";
            this.FuelLabel.Size = new System.Drawing.Size(27, 13);
            this.FuelLabel.TabIndex = 11;
            this.FuelLabel.Text = "Fuel";
            // 
            // LanderUpgradesBox
            // 
            this.LanderUpgradesBox.Controls.Add(this.LanderModifications_DisplacedByBomb);
            this.LanderUpgradesBox.Controls.Add(this.LanderModifications_QuakeShield);
            this.LanderUpgradesBox.Controls.Add(this.LanderModifications_RapidFire);
            this.LanderUpgradesBox.Controls.Add(this.LanderModifications_BioShield);
            this.LanderUpgradesBox.Controls.Add(this.LanderModifications_DoubleCargo);
            this.LanderUpgradesBox.Controls.Add(this.LanderModifications_DoubleSpeed);
            this.LanderUpgradesBox.Controls.Add(this.LanderModifications_LightningShield);
            this.LanderUpgradesBox.Controls.Add(this.LanderModifications_HeatShield);
            this.LanderUpgradesBox.Location = new System.Drawing.Point(6, 175);
            this.LanderUpgradesBox.Name = "LanderUpgradesBox";
            this.LanderUpgradesBox.Size = new System.Drawing.Size(152, 172);
            this.LanderUpgradesBox.TabIndex = 60;
            this.LanderUpgradesBox.TabStop = false;
            this.LanderUpgradesBox.Text = "Lander Upgrades";
            // 
            // IsBomb
            // 
            this.LanderModifications_DisplacedByBomb.AutoCheck = false;
            this.LanderModifications_DisplacedByBomb.AutoSize = true;
            this.LanderModifications_DisplacedByBomb.Enabled = false;
            this.LanderModifications_DisplacedByBomb.Location = new System.Drawing.Point(82, 83);
            this.LanderModifications_DisplacedByBomb.Name = "IsBomb";
            this.LanderModifications_DisplacedByBomb.Size = new System.Drawing.Size(64, 17);
            this.LanderModifications_DisplacedByBomb.TabIndex = 8;
            this.LanderModifications_DisplacedByBomb.Text = "Is Bomb";
            this.LanderModifications_DisplacedByBomb.UseVisualStyleBackColor = true;
            // 
            // QuakeShield
            // 
            this.LanderModifications_QuakeShield.AutoCheck = false;
            this.LanderModifications_QuakeShield.AutoSize = true;
            this.LanderModifications_QuakeShield.Enabled = false;
            this.LanderModifications_QuakeShield.Location = new System.Drawing.Point(6, 106);
            this.LanderModifications_QuakeShield.Name = "QuakeShield";
            this.LanderModifications_QuakeShield.Size = new System.Drawing.Size(90, 17);
            this.LanderModifications_QuakeShield.TabIndex = 7;
            this.LanderModifications_QuakeShield.Text = "Quake Shield";
            this.LanderModifications_QuakeShield.UseVisualStyleBackColor = true;
            // 
            // RapidFire
            // 
            this.LanderModifications_RapidFire.AutoCheck = false;
            this.LanderModifications_RapidFire.AutoSize = true;
            this.LanderModifications_RapidFire.Enabled = false;
            this.LanderModifications_RapidFire.Location = new System.Drawing.Point(6, 83);
            this.LanderModifications_RapidFire.Name = "RapidFire";
            this.LanderModifications_RapidFire.Size = new System.Drawing.Size(74, 17);
            this.LanderModifications_RapidFire.TabIndex = 6;
            this.LanderModifications_RapidFire.Text = "Rapid Fire";
            this.LanderModifications_RapidFire.UseVisualStyleBackColor = true;
            // 
            // BioShield
            // 
            this.LanderModifications_BioShield.AutoCheck = false;
            this.LanderModifications_BioShield.AutoSize = true;
            this.LanderModifications_BioShield.Enabled = false;
            this.LanderModifications_BioShield.Location = new System.Drawing.Point(6, 37);
            this.LanderModifications_BioShield.Name = "BioShield";
            this.LanderModifications_BioShield.Size = new System.Drawing.Size(73, 17);
            this.LanderModifications_BioShield.TabIndex = 5;
            this.LanderModifications_BioShield.Text = "Bio-Shield";
            this.LanderModifications_BioShield.UseVisualStyleBackColor = true;
            // 
            // DblCargo
            // 
            this.LanderModifications_DoubleCargo.AutoCheck = false;
            this.LanderModifications_DoubleCargo.AutoSize = true;
            this.LanderModifications_DoubleCargo.Enabled = false;
            this.LanderModifications_DoubleCargo.Location = new System.Drawing.Point(6, 60);
            this.LanderModifications_DoubleCargo.Name = "DblCargo";
            this.LanderModifications_DoubleCargo.Size = new System.Drawing.Size(91, 17);
            this.LanderModifications_DoubleCargo.TabIndex = 4;
            this.LanderModifications_DoubleCargo.Text = "Double Cargo";
            this.LanderModifications_DoubleCargo.UseVisualStyleBackColor = true;
            // 
            // DblSpeed
            // 
            this.LanderModifications_DoubleSpeed.AutoCheck = false;
            this.LanderModifications_DoubleSpeed.AutoSize = true;
            this.LanderModifications_DoubleSpeed.Enabled = false;
            this.LanderModifications_DoubleSpeed.Location = new System.Drawing.Point(6, 14);
            this.LanderModifications_DoubleSpeed.Name = "DblSpeed";
            this.LanderModifications_DoubleSpeed.Size = new System.Drawing.Size(94, 17);
            this.LanderModifications_DoubleSpeed.TabIndex = 3;
            this.LanderModifications_DoubleSpeed.Text = "Double Speed";
            this.LanderModifications_DoubleSpeed.UseVisualStyleBackColor = true;
            // 
            // LightningShield
            // 
            this.LanderModifications_LightningShield.AutoCheck = false;
            this.LanderModifications_LightningShield.AutoSize = true;
            this.LanderModifications_LightningShield.Enabled = false;
            this.LanderModifications_LightningShield.Location = new System.Drawing.Point(6, 129);
            this.LanderModifications_LightningShield.Name = "LightningShield";
            this.LanderModifications_LightningShield.Size = new System.Drawing.Size(101, 17);
            this.LanderModifications_LightningShield.TabIndex = 2;
            this.LanderModifications_LightningShield.Text = "Lightning Shield";
            this.LanderModifications_LightningShield.UseVisualStyleBackColor = true;
            // 
            // HeatShield
            // 
            this.LanderModifications_HeatShield.AutoCheck = false;
            this.LanderModifications_HeatShield.AutoSize = true;
            this.LanderModifications_HeatShield.Enabled = false;
            this.LanderModifications_HeatShield.Location = new System.Drawing.Point(6, 152);
            this.LanderModifications_HeatShield.Name = "HeatShield";
            this.LanderModifications_HeatShield.Size = new System.Drawing.Size(81, 17);
            this.LanderModifications_HeatShield.TabIndex = 1;
            this.LanderModifications_HeatShield.Text = "Heat Shield";
            this.LanderModifications_HeatShield.UseVisualStyleBackColor = true;
            // 
            // CrewLabel
            // 
            this.CrewLabel.AutoSize = true;
            this.CrewLabel.Location = new System.Drawing.Point(6, 21);
            this.CrewLabel.Name = "CrewLabel";
            this.CrewLabel.Size = new System.Drawing.Size(31, 13);
            this.CrewLabel.TabIndex = 10;
            this.CrewLabel.Text = "Crew";
            // 
            // Landers
            // 
            this.Landers.Location = new System.Drawing.Point(70, 123);
            this.Landers.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.Landers.Name = "Landers";
            this.Landers.Size = new System.Drawing.Size(88, 20);
            this.Landers.TabIndex = 6;
            this.Landers.TextAlign = HorizontalAlignment.Center;
            // 
            // BioData
            // 
            this.BioData.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.BioData.Location = new System.Drawing.Point(70, 97);
            this.BioData.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.BioData.Name = "BioData";
            this.BioData.Size = new System.Drawing.Size(88, 20);
            this.BioData.TabIndex = 5;
            this.BioData.TextAlign = HorizontalAlignment.Center;
            // 
            // ResUnits
            // 
            this.ResourceUnits.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.ResourceUnits.Location = new System.Drawing.Point(70, 71);
            this.ResourceUnits.Maximum = new decimal(new int[] {
            42949672,
            0,
            0,
            0});
            this.ResourceUnits.Name = "ResUnits";
            this.ResourceUnits.Size = new System.Drawing.Size(88, 20);
            this.ResourceUnits.TabIndex = 4;
            this.ResourceUnits.TextAlign = HorizontalAlignment.Center;
            // 
            // ShipFuel
            // 
            this.ShipFuel.DecimalPlaces = 2;
            this.ShipFuel.Increment = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.ShipFuel.Location = new System.Drawing.Point(70, 45);
            this.ShipFuel.Maximum = new decimal(new int[] {
            1610,
            0,
            0,
            0});
            this.ShipFuel.Name = "ShipFuel";
            this.ShipFuel.Size = new System.Drawing.Size(88, 20);
            this.ShipFuel.TabIndex = 3;
            this.ShipFuel.TextAlign = HorizontalAlignment.Center;
            // 
            // ShipCrew
            // 
            this.FlagshipCrew.Location = new System.Drawing.Point(70, 19);
            this.FlagshipCrew.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.FlagshipCrew.Name = "ShipCrew";
            this.FlagshipCrew.Size = new System.Drawing.Size(88, 20);
            this.FlagshipCrew.TabIndex = 2;
            this.FlagshipCrew.TextAlign = HorizontalAlignment.Center;
            // 
            // CargoBox
            // 
            this.CargoBox.Controls.Add(this.TotalLabel);
            this.CargoBox.Controls.Add(this.ExoticsLabel);
            this.CargoBox.Controls.Add(this.RadioactivsLabel);
            this.CargoBox.Controls.Add(this.PreciousMetalsLabel);
            this.CargoBox.Controls.Add(this.RareEarthsLabel);
            this.CargoBox.Controls.Add(this.NoblesGasesLabel);
            this.CargoBox.Controls.Add(this.BaseMetalsLabel);
            this.CargoBox.Controls.Add(this.CorrosiveLabel);
            this.CargoBox.Controls.Add(this.CommonLabel);
            this.CargoBox.Controls.Add(this.Minerals_Exotics);
            this.CargoBox.Controls.Add(this.Minerals_Radioactives);
            this.CargoBox.Controls.Add(this.Minerals_PreciousMetals);
            this.CargoBox.Controls.Add(this.Minerals_RareEarths);
            this.CargoBox.Controls.Add(this.Minerals_NobleGases);
            this.CargoBox.Controls.Add(this.Minerals_BaseMetals);
            this.CargoBox.Controls.Add(this.Minerals_Corrosives);
            this.CargoBox.Controls.Add(this.Minerals_CommonElements);
            this.CargoBox.Location = new System.Drawing.Point(6, 6);
            this.CargoBox.Name = "CargoBox";
            this.CargoBox.Size = new System.Drawing.Size(172, 255);
            this.CargoBox.TabIndex = 2;
            this.CargoBox.TabStop = false;
            this.CargoBox.Text = "Cargo";
            // 
            // TotalLabel
            // 
            this.TotalLabel.AutoSize = true;
            this.TotalLabel.Location = new System.Drawing.Point(6, 229);
            this.TotalLabel.Name = "TotalLabel";
            this.TotalLabel.Size = new System.Drawing.Size(31, 13);
            this.TotalLabel.TabIndex = 17;
            this.TotalLabel.Text = "Total";
            // 
            // ExoticsLabel
            // 
            this.ExoticsLabel.AutoSize = true;
            this.ExoticsLabel.ForeColor = System.Drawing.Color.Purple;
            this.ExoticsLabel.Location = new System.Drawing.Point(6, 203);
            this.ExoticsLabel.Name = "ExoticsLabel";
            this.ExoticsLabel.Size = new System.Drawing.Size(41, 13);
            this.ExoticsLabel.TabIndex = 15;
            this.ExoticsLabel.Text = "Exotics";
            // 
            // RadioactivsLabel
            // 
            this.RadioactivsLabel.AutoSize = true;
            this.RadioactivsLabel.ForeColor = System.Drawing.Color.Orange;
            this.RadioactivsLabel.Location = new System.Drawing.Point(6, 177);
            this.RadioactivsLabel.Name = "RadioactivsLabel";
            this.RadioactivsLabel.Size = new System.Drawing.Size(69, 13);
            this.RadioactivsLabel.TabIndex = 14;
            this.RadioactivsLabel.Text = "Radioactives";
            // 
            // PreciousMetalsLabel
            // 
            this.PreciousMetalsLabel.AutoSize = true;
            this.PreciousMetalsLabel.ForeColor = System.Drawing.Color.Gold;
            this.PreciousMetalsLabel.Location = new System.Drawing.Point(6, 151);
            this.PreciousMetalsLabel.Name = "PreciousMetalsLabel";
            this.PreciousMetalsLabel.Size = new System.Drawing.Size(82, 13);
            this.PreciousMetalsLabel.TabIndex = 13;
            this.PreciousMetalsLabel.Text = "Precious Metals";
            // 
            // RareEarthsLabel
            // 
            this.RareEarthsLabel.AutoSize = true;
            this.RareEarthsLabel.ForeColor = System.Drawing.Color.Green;
            this.RareEarthsLabel.Location = new System.Drawing.Point(6, 125);
            this.RareEarthsLabel.Name = "RareEarthsLabel";
            this.RareEarthsLabel.Size = new System.Drawing.Size(63, 13);
            this.RareEarthsLabel.TabIndex = 12;
            this.RareEarthsLabel.Text = "Rare Earths";
            // 
            // NoblesGasesLabel
            // 
            this.NoblesGasesLabel.AutoSize = true;
            this.NoblesGasesLabel.ForeColor = System.Drawing.Color.Blue;
            this.NoblesGasesLabel.Location = new System.Drawing.Point(6, 99);
            this.NoblesGasesLabel.Name = "NoblesGasesLabel";
            this.NoblesGasesLabel.Size = new System.Drawing.Size(68, 13);
            this.NoblesGasesLabel.TabIndex = 11;
            this.NoblesGasesLabel.Text = "Noble Gases";
            // 
            // BaseMetalsLabel
            // 
            this.BaseMetalsLabel.AutoSize = true;
            this.BaseMetalsLabel.ForeColor = System.Drawing.Color.Gray;
            this.BaseMetalsLabel.Location = new System.Drawing.Point(6, 73);
            this.BaseMetalsLabel.Name = "BaseMetalsLabel";
            this.BaseMetalsLabel.Size = new System.Drawing.Size(65, 13);
            this.BaseMetalsLabel.TabIndex = 10;
            this.BaseMetalsLabel.Text = "Base Metals";
            // 
            // CorrosiveLabel
            // 
            this.CorrosiveLabel.AutoSize = true;
            this.CorrosiveLabel.ForeColor = System.Drawing.Color.Red;
            this.CorrosiveLabel.Location = new System.Drawing.Point(6, 47);
            this.CorrosiveLabel.Name = "CorrosiveLabel";
            this.CorrosiveLabel.Size = new System.Drawing.Size(51, 13);
            this.CorrosiveLabel.TabIndex = 9;
            this.CorrosiveLabel.Text = "Corrosive";
            // 
            // CommonLabel
            // 
            this.CommonLabel.AutoSize = true;
            this.CommonLabel.ForeColor = System.Drawing.Color.Cyan;
            this.CommonLabel.Location = new System.Drawing.Point(6, 21);
            this.CommonLabel.Name = "CommonLabel";
            this.CommonLabel.Size = new System.Drawing.Size(48, 13);
            this.CommonLabel.TabIndex = 8;
            this.CommonLabel.Text = "Common";
            // 
            // Exotic
            // 
            this.Minerals_Exotics.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Minerals_Exotics.Location = new System.Drawing.Point(90, 201);
            this.Minerals_Exotics.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Minerals_Exotics.Name = "Exotic";
            this.Minerals_Exotics.Size = new System.Drawing.Size(76, 20);
            this.Minerals_Exotics.TabIndex = 7;
            this.Minerals_Exotics.TextAlign = HorizontalAlignment.Center;
            this.Minerals_Exotics.ValueChanged += new System.EventHandler(this.MineralsValueChanged);
            // 
            // Radioactive
            // 
            this.Minerals_Radioactives.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Minerals_Radioactives.Location = new System.Drawing.Point(90, 175);
            this.Minerals_Radioactives.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Minerals_Radioactives.Name = "Radioactive";
            this.Minerals_Radioactives.Size = new System.Drawing.Size(76, 20);
            this.Minerals_Radioactives.TabIndex = 6;
            this.Minerals_Radioactives.TextAlign = HorizontalAlignment.Center;
            this.Minerals_Radioactives.ValueChanged += new System.EventHandler(this.MineralsValueChanged);
            // 
            // Precious
            // 
            this.Minerals_PreciousMetals.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Minerals_PreciousMetals.Location = new System.Drawing.Point(90, 149);
            this.Minerals_PreciousMetals.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Minerals_PreciousMetals.Name = "Precious";
            this.Minerals_PreciousMetals.Size = new System.Drawing.Size(76, 20);
            this.Minerals_PreciousMetals.TabIndex = 5;
            this.Minerals_PreciousMetals.TextAlign = HorizontalAlignment.Center;
            this.Minerals_PreciousMetals.ValueChanged += new System.EventHandler(this.MineralsValueChanged);
            // 
            // RareEarth
            // 
            this.Minerals_RareEarths.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Minerals_RareEarths.Location = new System.Drawing.Point(90, 123);
            this.Minerals_RareEarths.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Minerals_RareEarths.Name = "RareEarth";
            this.Minerals_RareEarths.Size = new System.Drawing.Size(76, 20);
            this.Minerals_RareEarths.TabIndex = 4;
            this.Minerals_RareEarths.TextAlign = HorizontalAlignment.Center;
            this.Minerals_RareEarths.ValueChanged += new System.EventHandler(this.MineralsValueChanged);
            // 
            // NobleGas
            // 
            this.Minerals_NobleGases.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Minerals_NobleGases.Location = new System.Drawing.Point(90, 97);
            this.Minerals_NobleGases.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Minerals_NobleGases.Name = "NobleGas";
            this.Minerals_NobleGases.Size = new System.Drawing.Size(76, 20);
            this.Minerals_NobleGases.TabIndex = 3;
            this.Minerals_NobleGases.TextAlign = HorizontalAlignment.Center;
            this.Minerals_NobleGases.ValueChanged += new System.EventHandler(this.MineralsValueChanged);
            // 
            // BaseMetal
            // 
            this.Minerals_BaseMetals.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Minerals_BaseMetals.Location = new System.Drawing.Point(90, 71);
            this.Minerals_BaseMetals.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Minerals_BaseMetals.Name = "BaseMetal";
            this.Minerals_BaseMetals.Size = new System.Drawing.Size(76, 20);
            this.Minerals_BaseMetals.TabIndex = 2;
            this.Minerals_BaseMetals.TextAlign = HorizontalAlignment.Center;
            this.Minerals_BaseMetals.ValueChanged += new System.EventHandler(this.MineralsValueChanged);
            // 
            // Corrosive
            // 
            this.Minerals_Corrosives.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Minerals_Corrosives.Location = new System.Drawing.Point(90, 45);
            this.Minerals_Corrosives.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Minerals_Corrosives.Name = "Corrosive";
            this.Minerals_Corrosives.Size = new System.Drawing.Size(76, 20);
            this.Minerals_Corrosives.TabIndex = 1;
            this.Minerals_Corrosives.TextAlign = HorizontalAlignment.Center;
            this.Minerals_Corrosives.ValueChanged += new System.EventHandler(this.MineralsValueChanged);
            // 
            // Common
            // 
            this.Minerals_CommonElements.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.Minerals_CommonElements.Location = new System.Drawing.Point(90, 19);
            this.Minerals_CommonElements.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Minerals_CommonElements.Name = "Common";
            this.Minerals_CommonElements.Size = new System.Drawing.Size(76, 20);
            this.Minerals_CommonElements.TabIndex = 0;
            this.Minerals_CommonElements.TextAlign = HorizontalAlignment.Center;
            this.Minerals_CommonElements.ValueChanged += new System.EventHandler(this.MineralsValueChanged);
            // 
            // Coordinates
            // 
            this.Coordinates.Controls.Add(this.Spoilers);
            this.Coordinates.Controls.Add(this.StatusBox);
            this.Coordinates.Controls.Add(this.OrbitBox);
            this.Coordinates.Controls.Add(this.NearestStarBox);
            this.Coordinates.Controls.Add(this.HSCoordsBox);
            this.Coordinates.Controls.Add(this.StarList);
            this.Coordinates.Location = new System.Drawing.Point(4, 22);
            this.Coordinates.Name = "Coordinates";
            this.Coordinates.Padding = new Padding(3);
            this.Coordinates.Size = new System.Drawing.Size(863, 474);
            this.Coordinates.TabIndex = 1;
            this.Coordinates.Text = "Coordinates";
            this.Coordinates.UseVisualStyleBackColor = true;
            // 
            // Spoilers
            // 
            this.Spoilers.AutoSize = true;
            this.Spoilers.Location = new System.Drawing.Point(48, 239);
            this.Spoilers.Name = "Spoilers";
            this.Spoilers.Size = new System.Drawing.Size(63, 17);
            this.Spoilers.TabIndex = 70;
            this.Spoilers.Text = "Spoilers";
            this.Spoilers.UseVisualStyleBackColor = true;
            this.Spoilers.CheckedChanged += new System.EventHandler(this.Spoilers_CheckedChanged);
            // 
            // StatusBox
            // 
            this.StatusBox.Controls.Add(this.CurrentStatus);
            this.StatusBox.Location = new System.Drawing.Point(6, 186);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(159, 47);
            this.StatusBox.TabIndex = 69;
            this.StatusBox.TabStop = false;
            this.StatusBox.Text = "Current Status";
            // 
            // CurrentStatus
            // 
            this.CurrentStatus.BackColor = System.Drawing.SystemColors.Menu;
            this.CurrentStatus.DropDownStyle = ComboBoxStyle.Simple;
            this.CurrentStatus.FormattingEnabled = true;
            this.CurrentStatus.Location = new System.Drawing.Point(6, 19);
            this.CurrentStatus.Name = "CurrentStatus";
            this.CurrentStatus.Size = new System.Drawing.Size(147, 21);
            this.CurrentStatus.TabIndex = 65;
            this.ReadOnly.SetToolTip(this.CurrentStatus, "Read Only");
            // 
            // OrbitBox
            // 
            this.OrbitBox.Controls.Add(this.NearestPlanet);
            this.OrbitBox.Location = new System.Drawing.Point(6, 134);
            this.OrbitBox.Name = "OrbitBox";
            this.OrbitBox.Size = new System.Drawing.Size(159, 46);
            this.OrbitBox.TabIndex = 68;
            this.OrbitBox.TabStop = false;
            this.OrbitBox.Text = "Orbiting";
            // 
            // NearestPlanet
            // 
            this.NearestPlanet.Location = new System.Drawing.Point(6, 19);
            this.NearestPlanet.Name = "NearestPlanet";
            this.NearestPlanet.ReadOnly = true;
            this.NearestPlanet.Size = new System.Drawing.Size(147, 20);
            this.NearestPlanet.TabIndex = 66;
            this.ReadOnly.SetToolTip(this.NearestPlanet, "Read Only");
            // 
            // NearestStarBox
            // 
            this.NearestStarBox.Controls.Add(this.NearestStar);
            this.NearestStarBox.Location = new System.Drawing.Point(6, 82);
            this.NearestStarBox.Name = "NearestStarBox";
            this.NearestStarBox.Size = new System.Drawing.Size(159, 46);
            this.NearestStarBox.TabIndex = 67;
            this.NearestStarBox.TabStop = false;
            this.NearestStarBox.Text = "Nearest Star";
            // 
            // NearestStar
            // 
            this.NearestStar.Location = new System.Drawing.Point(6, 19);
            this.NearestStar.Name = "NearestStar";
            this.NearestStar.ReadOnly = true;
            this.NearestStar.Size = new System.Drawing.Size(147, 20);
            this.NearestStar.TabIndex = 2;
            this.ReadOnly.SetToolTip(this.NearestStar, "Read Only");
            // 
            // HSCoordsBox
            // 
            this.HSCoordsBox.Controls.Add(this.UniYLabel);
            this.HSCoordsBox.Controls.Add(this.UniXLabel);
            this.HSCoordsBox.Controls.Add(this.UniverseY);
            this.HSCoordsBox.Controls.Add(this.UniverseX);
            this.HSCoordsBox.Location = new System.Drawing.Point(6, 6);
            this.HSCoordsBox.Name = "HSCoordsBox";
            this.HSCoordsBox.Size = new System.Drawing.Size(159, 70);
            this.HSCoordsBox.TabIndex = 3;
            this.HSCoordsBox.TabStop = false;
            this.HSCoordsBox.Text = "Hyperspace Coordinates";
            // 
            // UniYLabel
            // 
            this.UniYLabel.AutoSize = true;
            this.UniYLabel.Location = new System.Drawing.Point(3, 46);
            this.UniYLabel.Name = "UniYLabel";
            this.UniYLabel.Size = new System.Drawing.Size(14, 13);
            this.UniYLabel.TabIndex = 9;
            this.UniYLabel.Text = "Y";
            // 
            // UniXLabel
            // 
            this.UniXLabel.AutoSize = true;
            this.UniXLabel.Location = new System.Drawing.Point(3, 22);
            this.UniXLabel.Name = "UniXLabel";
            this.UniXLabel.Size = new System.Drawing.Size(14, 13);
            this.UniXLabel.TabIndex = 8;
            this.UniXLabel.Text = "X";
            // 
            // UniverseY
            // 
            this.UniverseY.DecimalPlaces = 1;
            this.UniverseY.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            131072});
            this.UniverseY.Location = new System.Drawing.Point(53, 43);
            this.UniverseY.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            65536});
            this.UniverseY.Name = "UniverseY";
            this.UniverseY.Size = new System.Drawing.Size(100, 20);
            this.UniverseY.TabIndex = 1;
            this.UniverseY.TextChanged += new System.EventHandler(this.Universe_TextChanged);
            // 
            // UniverseX
            // 
            this.UniverseX.DecimalPlaces = 1;
            this.UniverseX.Increment = new decimal(new int[] {
            10000,
            0,
            0,
            131072});
            this.UniverseX.Location = new System.Drawing.Point(53, 19);
            this.UniverseX.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            65536});
            this.UniverseX.Name = "UniverseX";
            this.UniverseX.Size = new System.Drawing.Size(100, 20);
            this.UniverseX.TabIndex = 0;
            this.UniverseX.TextChanged += new System.EventHandler(this.Universe_TextChanged);
            // 
            // StarList
            // 
            this.StarList.BorderStyle = BorderStyle.FixedSingle;
            this.StarList.FormattingEnabled = true;
            this.StarList.Location = new System.Drawing.Point(171, 6);
            this.StarList.Name = "StarList";
            this.StarList.Size = new System.Drawing.Size(684, 457);
            this.StarList.TabIndex = 0;
            this.StarList.SelectedIndexChanged += new System.EventHandler(this.StarList_SelectedIndexChanged);
            // 
            // megaModModes
            // 
            this.megaModModes.Controls.Add(this.nomadCheckBox);
            this.megaModModes.Controls.Add(this.extendedCheckBox);
            this.megaModModes.Controls.Add(this.difficultyLabel);
            this.megaModModes.Controls.Add(this.difficultyBox);
            this.megaModModes.Location = new System.Drawing.Point(562, 353);
            this.megaModModes.Name = "megaModModes";
            this.megaModModes.Size = new System.Drawing.Size(110, 86);
            this.megaModModes.TabIndex = 79;
            this.megaModModes.TabStop = false;
            this.megaModModes.Text = "Modes";
            this.megaModModes.Visible = false;
            // 
            // difficultyBox
            // 
            this.difficultyBox.BackColor = System.Drawing.SystemColors.Menu;
            this.difficultyBox.DisplayMember = "Text";
            this.difficultyBox.DropDownStyle = ComboBoxStyle.Simple;
            this.difficultyBox.FormattingEnabled = true;
            this.difficultyBox.Location = new System.Drawing.Point(58, 14);
            this.difficultyBox.Name = "difficultyBox";
            this.difficultyBox.Size = new System.Drawing.Size(45, 21);
            this.difficultyBox.TabIndex = 1;
            this.difficultyBox.ValueMember = "HexCode";
            // 
            // difficultyLabel
            // 
            this.difficultyLabel.AutoSize = true;
            this.difficultyLabel.Location = new System.Drawing.Point(5, 17);
            this.difficultyLabel.Name = "difficultyLabel";
            this.difficultyLabel.Size = new System.Drawing.Size(47, 13);
            this.difficultyLabel.TabIndex = 9;
            this.difficultyLabel.Text = "Difficulty";
            // 
            // extendedCheckBox
            // 
            this.extendedCheckBox.AutoCheck = false;
            this.extendedCheckBox.AutoSize = true;
            this.extendedCheckBox.Enabled = false;
            this.extendedCheckBox.Location = new System.Drawing.Point(8, 41);
            this.extendedCheckBox.Name = "extendedCheckBox";
            this.extendedCheckBox.Size = new System.Drawing.Size(95, 17);
            this.extendedCheckBox.TabIndex = 10;
            this.extendedCheckBox.Text = "Extended Lore";
            this.extendedCheckBox.UseVisualStyleBackColor = true;
            // 
            // nomadCheckBox
            // 
            this.nomadCheckBox.AutoCheck = false;
            this.nomadCheckBox.AutoSize = true;
            this.nomadCheckBox.Enabled = false;
            this.nomadCheckBox.Location = new System.Drawing.Point(8, 64);
            this.nomadCheckBox.Name = "nomadCheckBox";
            this.nomadCheckBox.Size = new System.Drawing.Size(83, 17);
            this.nomadCheckBox.TabIndex = 11;
            this.nomadCheckBox.Text = "Nomad Run";
            this.nomadCheckBox.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 529);
            this.Controls.Add(this.Tabs);
            this.Controls.Add(this.toolStrip1);
            this.Icon = new Icon("Resources/mkii.ico"); //((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(889, 568);
            this.MinimumSize = new System.Drawing.Size(889, 568);
            this.Name = "Main";
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "The UQM Save Editor";
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.Tabs.ResumeLayout(false);
            this.Summary.ResumeLayout(false);
            this.DevicesBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TotalMinerals)).EndInit();
            this.ThrusterBox.ResumeLayout(false);
            this.ThrusterBox.PerformLayout();
            this.JetsBox.ResumeLayout(false);
            this.JetsBox.PerformLayout();
            this.SeedBox.ResumeLayout(false);
            this.SeedBox.PerformLayout();
            this.ShipNameBox.ResumeLayout(false);
            this.ShipNameBox.PerformLayout();
            this.CaptainBox.ResumeLayout(false);
            this.CaptainBox.PerformLayout();
            this.ShipsBox.ResumeLayout(false);
            this.ShipsBox.PerformLayout();
            this.ModulesBox.ResumeLayout(false);
            this.ModulesBox.PerformLayout();
            this.ShipStatusBox.ResumeLayout(false);
            this.ShipStatusBox.PerformLayout();
            this.LanderUpgradesBox.ResumeLayout(false);
            this.LanderUpgradesBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Landers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BioData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResourceUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ShipFuel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FlagshipCrew)).EndInit();
            this.CargoBox.ResumeLayout(false);
            this.CargoBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Minerals_Exotics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minerals_Radioactives)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minerals_PreciousMetals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minerals_RareEarths)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minerals_NobleGases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minerals_BaseMetals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minerals_Corrosives)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Minerals_CommonElements)).EndInit();
            this.Coordinates.ResumeLayout(false);
            this.Coordinates.PerformLayout();
            this.StatusBox.ResumeLayout(false);
            this.OrbitBox.ResumeLayout(false);
            this.OrbitBox.PerformLayout();
            this.NearestStarBox.ResumeLayout(false);
            this.NearestStarBox.PerformLayout();
            this.HSCoordsBox.ResumeLayout(false);
            this.HSCoordsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UniverseY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UniverseX)).EndInit();
            this.megaModModes.ResumeLayout(false);
            this.megaModModes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private ToolStrip toolStrip1;
		private ToolStripButton Open;
		private ToolStripButton Reload;
		private ToolStripButton Save;
		private TabControl Tabs;
		private TabPage Summary;
		private TabPage Coordinates;
		private ListBox StarList;
		public GroupBox ModulesBox;
		public Button UpgradeToMax;
		public ComboBox Module16;
		public ComboBox Module15;
		public ComboBox Module14;
		public ComboBox Module13;
		public ComboBox Module12;
		public ComboBox Module11;
		public ComboBox Module10;
		public ComboBox Module09;
		public ComboBox Module08;
		public ComboBox Module07;
		public ComboBox Module06;
		private Label ModuleLabel01;
		private Label ModuleLabel02;
		public ComboBox Module05;
		private Label ModuleLabel03;
		public ComboBox Module04;
		private Label ModuleLabel04;
		public ComboBox Module03;
		private Label ModuleLabel05;
		public ComboBox Module02;
		private Label ModuleLabel06;
		public ComboBox Module01;
		private Label ModuleLabel07;
		private Label ModuleLabel16;
		private Label ModuleLabel08;
		private Label ModuleLabel15;
		private Label ModuleLabel09;
		private Label ModuleLabel14;
		private Label ModuleLabel10;
		private Label ModuleLabel13;
		private Label ModuleLabel11;
		private Label ModuleLabel12;
		public TextBox CustomSeed;
		public GroupBox LanderUpgradesBox;
		public CheckBox LanderModifications_DisplacedByBomb;
		public CheckBox LanderModifications_QuakeShield;
		public CheckBox LanderModifications_RapidFire;
		public CheckBox LanderModifications_BioShield;
		public CheckBox LanderModifications_DoubleCargo;
		public CheckBox LanderModifications_DoubleSpeed;
		public CheckBox LanderModifications_LightningShield;
		public CheckBox LanderModifications_HeatShield;
		public GroupBox ShipStatusBox;
		public TextBox Credits;
		private Label label58;
		public TextBox CommanderName;
		private Label LandersLabel;
		public Label BioDataLabel;
		private Label RULabel;
		private Label FuelLabel;
		private Label CrewLabel;
		public NumericUpDown Landers;
		public NumericUpDown BioData;
		public NumericUpDown ResourceUnits;
		public NumericUpDown ShipFuel;
		public NumericUpDown FlagshipCrew;
		public TextBox ShipName;
		public GroupBox CargoBox;
		private Label ExoticsLabel;
		public Label RadioactivsLabel;
		private Label PreciousMetalsLabel;
		private Label RareEarthsLabel;
		private Label NoblesGasesLabel;
		private Label BaseMetalsLabel;
		private Label CorrosiveLabel;
		private Label CommonLabel;
		public NumericUpDown Minerals_Exotics;
		public NumericUpDown Minerals_Radioactives;
		public NumericUpDown Minerals_PreciousMetals;
		public NumericUpDown Minerals_RareEarths;
		public NumericUpDown Minerals_NobleGases;
		public NumericUpDown Minerals_BaseMetals;
		public NumericUpDown Minerals_Corrosives;
		public NumericUpDown Minerals_CommonElements;
		public ListBox Devices;
		public ComboBox CurrentStatus;
		public TextBox NearestPlanet;
		private GroupBox HSCoordsBox;
		public TextBox NearestStar;
		private Label UniYLabel;
		private Label UniXLabel;
		public NumericUpDown UniverseY;
		public NumericUpDown UniverseX;
		public GroupBox ShipsBox;
		public ComboBox Ship01;
		public ComboBox Ship02;
		public ComboBox Ship03;
		public ComboBox Ship04;
		public ComboBox Ship05;
		public ComboBox Ship06;
		public ComboBox Ship07;
		public ComboBox Ship08;
		public ComboBox Ship09;
		public ComboBox Ship10;
		public ComboBox Ship11;
		public ComboBox Ship12;
		private Label ShipLabel01;
		private Label ShipLabel12;
		private Label ShipLabel02;
		private Label ShipLabel11;
		private Label ShipLabel10;
		private Label ShipLabel03;
		private Label ShipLabel09;
		private Label ShipLabel08;
		private Label ShipLabel04;
		private Label ShipLabel07;
		private Label ShipLabel06;
		private Label ShipLabel05;
		private Label TotalLabel;
		private GroupBox NearestStarBox;
		private GroupBox StatusBox;
		private GroupBox OrbitBox;
		private GroupBox ShipNameBox;
		private GroupBox CaptainBox;
		private GroupBox SeedBox;
		private CheckBox Spoilers;
		private Button MaxJets;
		private Button MaxThrusters;
		public CheckBox Thruster10;
		public CheckBox Thruster9;
		public CheckBox Thruster8;
		public CheckBox Thruster7;
		public CheckBox Thruster6;
		public CheckBox Thruster5;
		public CheckBox Thruster4;
		public CheckBox Thruster3;
		public CheckBox Thruster2;
		public CheckBox Thruster1;
		public CheckBox Thruster0;
		public CheckBox Jets7;
		public CheckBox Jets6;
		public CheckBox Jets5;
		public CheckBox Jets4;
		public CheckBox Jets3;
		public CheckBox Jets2;
		public CheckBox Jets1;
		public CheckBox Jets0;
		private Label MaxThrustLabel;
		private Label MaxJetsLabel;
		private Label MaxModulesLabel;
		public GroupBox ThrusterBox;
		public GroupBox JetsBox;
		private GroupBox DevicesBox;
		private ToolTip ReadOnly;
		private ToolTip MaxLimits;
		public NumericUpDown TotalMinerals;
        private ToolStripLabel version;
        private GroupBox megaModModes;
        public CheckBox nomadCheckBox;
        public CheckBox extendedCheckBox;
        private Label difficultyLabel;
        public ComboBox difficultyBox;
    }
}