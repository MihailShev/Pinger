namespace Pinger
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PanNetAdap = new System.Windows.Forms.Panel();
            this.ButDelNetAdap = new System.Windows.Forms.Button();
            this.LvNetAdap = new System.Windows.Forms.ListView();
            this.clh1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clh2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clh3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clh4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ButSaveSettings = new System.Windows.Forms.Button();
            this.comboPriorityNetAdap = new System.Windows.Forms.ComboBox();
            this.comboTypeNetAdap = new System.Windows.Forms.ComboBox();
            this.LabPanNetAdap = new System.Windows.Forms.Label();
            this.PanWifi = new System.Windows.Forms.Panel();
            this.ButResetPassWifi = new System.Windows.Forms.Button();
            this.LabTexBoxPass = new System.Windows.Forms.Label();
            this.ButSaveSettingsWifi = new System.Windows.Forms.Button();
            this.ButDelWifi = new System.Windows.Forms.Button();
            this.CheckBoxShowPass = new System.Windows.Forms.CheckBox();
            this.TexBoxPass = new System.Windows.Forms.TextBox();
            this.ComboPriorityWifi = new System.Windows.Forms.ComboBox();
            this.ButAddWifi = new System.Windows.Forms.Button();
            this.LvWifi = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LabPanWifi = new System.Windows.Forms.Label();
            this.LbAddress = new System.Windows.Forms.ListBox();
            this.ButAddAddress = new System.Windows.Forms.Button();
            this.TexBoxAddress = new System.Windows.Forms.TextBox();
            this.TexBoxHelp = new System.Windows.Forms.TextBox();
            this.GroupManageAddress = new System.Windows.Forms.GroupBox();
            this.ButDelAddress = new System.Windows.Forms.Button();
            this.GroupAutoModeStart = new System.Windows.Forms.GroupBox();
            this.CheckBoxAutoModeStart = new System.Windows.Forms.CheckBox();
            this.GroupTimeoutRequest = new System.Windows.Forms.GroupBox();
            this.ButChangeTimeoutRequest = new System.Windows.Forms.Button();
            this.TexBoxTimeoutRequest = new System.Windows.Forms.TextBox();
            this.GroupPausaModem = new System.Windows.Forms.GroupBox();
            this.ButChangePausaModem = new System.Windows.Forms.Button();
            this.TexBoxPausaModem = new System.Windows.Forms.TextBox();
            this.GroupPausaCheckEnableAdapter = new System.Windows.Forms.GroupBox();
            this.ButChangePausaCheckAdapter = new System.Windows.Forms.Button();
            this.TexBoxPausaCheckEnableAdapter = new System.Windows.Forms.TextBox();
            this.GroupIntervalCheckInternet = new System.Windows.Forms.GroupBox();
            this.ButChangeIntervalChekcInternet = new System.Windows.Forms.Button();
            this.TexBoxIntervalCheckInternet = new System.Windows.Forms.TextBox();
            this.TimerMouseCatcher = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LabAddAutoRun = new System.Windows.Forms.Label();
            this.CheckBoxAddAutoRun = new System.Windows.Forms.CheckBox();
            this.PanNetAdap.SuspendLayout();
            this.PanWifi.SuspendLayout();
            this.GroupManageAddress.SuspendLayout();
            this.GroupAutoModeStart.SuspendLayout();
            this.GroupTimeoutRequest.SuspendLayout();
            this.GroupPausaModem.SuspendLayout();
            this.GroupPausaCheckEnableAdapter.SuspendLayout();
            this.GroupIntervalCheckInternet.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanNetAdap
            // 
            this.PanNetAdap.Controls.Add(this.ButDelNetAdap);
            this.PanNetAdap.Controls.Add(this.LvNetAdap);
            this.PanNetAdap.Controls.Add(this.ButSaveSettings);
            this.PanNetAdap.Controls.Add(this.comboPriorityNetAdap);
            this.PanNetAdap.Controls.Add(this.comboTypeNetAdap);
            this.PanNetAdap.Location = new System.Drawing.Point(13, 191);
            this.PanNetAdap.Margin = new System.Windows.Forms.Padding(4);
            this.PanNetAdap.Name = "PanNetAdap";
            this.PanNetAdap.Size = new System.Drawing.Size(636, 132);
            this.PanNetAdap.TabIndex = 0;
            // 
            // ButDelNetAdap
            // 
            this.ButDelNetAdap.Enabled = false;
            this.ButDelNetAdap.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButDelNetAdap.Location = new System.Drawing.Point(496, 97);
            this.ButDelNetAdap.Margin = new System.Windows.Forms.Padding(4);
            this.ButDelNetAdap.Name = "ButDelNetAdap";
            this.ButDelNetAdap.Size = new System.Drawing.Size(136, 26);
            this.ButDelNetAdap.TabIndex = 6;
            this.ButDelNetAdap.Text = "Удалить";
            this.ButDelNetAdap.UseVisualStyleBackColor = true;
            this.ButDelNetAdap.Click += new System.EventHandler(this.ButDelNetAdap_Click);
            // 
            // LvNetAdap
            // 
            this.LvNetAdap.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clh1,
            this.clh2,
            this.clh3,
            this.clh4});
            this.LvNetAdap.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LvNetAdap.FullRowSelect = true;
            this.LvNetAdap.HideSelection = false;
            this.LvNetAdap.Location = new System.Drawing.Point(6, 4);
            this.LvNetAdap.Margin = new System.Windows.Forms.Padding(4);
            this.LvNetAdap.Name = "LvNetAdap";
            this.LvNetAdap.Size = new System.Drawing.Size(487, 119);
            this.LvNetAdap.TabIndex = 5;
            this.LvNetAdap.UseCompatibleStateImageBehavior = false;
            this.LvNetAdap.View = System.Windows.Forms.View.Details;
            this.LvNetAdap.SelectedIndexChanged += new System.EventHandler(this.LvNetAdap_SelectedIndexChanged);
            // 
            // clh1
            // 
            this.clh1.Text = "Имя";
            this.clh1.Width = 180;
            // 
            // clh2
            // 
            this.clh2.Text = "Тип";
            this.clh2.Width = 81;
            // 
            // clh3
            // 
            this.clh3.Text = "Приоритет";
            this.clh3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clh3.Width = 110;
            // 
            // clh4
            // 
            this.clh4.Text = "Статус";
            this.clh4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clh4.Width = 100;
            // 
            // ButSaveSettings
            // 
            this.ButSaveSettings.Enabled = false;
            this.ButSaveSettings.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButSaveSettings.Location = new System.Drawing.Point(496, 63);
            this.ButSaveSettings.Margin = new System.Windows.Forms.Padding(4);
            this.ButSaveSettings.Name = "ButSaveSettings";
            this.ButSaveSettings.Size = new System.Drawing.Size(136, 26);
            this.ButSaveSettings.TabIndex = 4;
            this.ButSaveSettings.Text = "Сохранить";
            this.ButSaveSettings.UseVisualStyleBackColor = true;
            this.ButSaveSettings.Click += new System.EventHandler(this.ButSaveSettings_Click);
            // 
            // comboPriorityNetAdap
            // 
            this.comboPriorityNetAdap.Enabled = false;
            this.comboPriorityNetAdap.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboPriorityNetAdap.FormattingEnabled = true;
            this.comboPriorityNetAdap.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboPriorityNetAdap.Location = new System.Drawing.Point(496, 35);
            this.comboPriorityNetAdap.Margin = new System.Windows.Forms.Padding(4);
            this.comboPriorityNetAdap.Name = "comboPriorityNetAdap";
            this.comboPriorityNetAdap.Size = new System.Drawing.Size(136, 23);
            this.comboPriorityNetAdap.TabIndex = 3;
            this.comboPriorityNetAdap.Text = "Приоритет";
            this.comboPriorityNetAdap.SelectedIndexChanged += new System.EventHandler(this.comboPriorityNetAdap_SelectedIndexChanged);
            // 
            // comboTypeNetAdap
            // 
            this.comboTypeNetAdap.Enabled = false;
            this.comboTypeNetAdap.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboTypeNetAdap.FormattingEnabled = true;
            this.comboTypeNetAdap.Items.AddRange(new object[] {
            "Unknown",
            "Wan",
            "Wifi",
            "Bluetooth",
            "Modem"});
            this.comboTypeNetAdap.Location = new System.Drawing.Point(496, 4);
            this.comboTypeNetAdap.Margin = new System.Windows.Forms.Padding(4);
            this.comboTypeNetAdap.Name = "comboTypeNetAdap";
            this.comboTypeNetAdap.Size = new System.Drawing.Size(136, 23);
            this.comboTypeNetAdap.TabIndex = 2;
            this.comboTypeNetAdap.Text = "Тип адаптера";
            this.comboTypeNetAdap.SelectedIndexChanged += new System.EventHandler(this.comboTypeNetAdap_SelectedIndexChanged);
            // 
            // LabPanNetAdap
            // 
            this.LabPanNetAdap.AutoSize = true;
            this.LabPanNetAdap.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabPanNetAdap.Location = new System.Drawing.Point(13, 168);
            this.LabPanNetAdap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabPanNetAdap.Name = "LabPanNetAdap";
            this.LabPanNetAdap.Size = new System.Drawing.Size(246, 19);
            this.LabPanNetAdap.TabIndex = 0;
            this.LabPanNetAdap.Text = "Настройки сетевых адаптеров";
            // 
            // PanWifi
            // 
            this.PanWifi.Controls.Add(this.ButResetPassWifi);
            this.PanWifi.Controls.Add(this.LabTexBoxPass);
            this.PanWifi.Controls.Add(this.ButSaveSettingsWifi);
            this.PanWifi.Controls.Add(this.ButDelWifi);
            this.PanWifi.Controls.Add(this.CheckBoxShowPass);
            this.PanWifi.Controls.Add(this.TexBoxPass);
            this.PanWifi.Controls.Add(this.ComboPriorityWifi);
            this.PanWifi.Controls.Add(this.ButAddWifi);
            this.PanWifi.Controls.Add(this.LvWifi);
            this.PanWifi.Controls.Add(this.LabPanWifi);
            this.PanWifi.Location = new System.Drawing.Point(14, 331);
            this.PanWifi.Margin = new System.Windows.Forms.Padding(4);
            this.PanWifi.Name = "PanWifi";
            this.PanWifi.Size = new System.Drawing.Size(637, 233);
            this.PanWifi.TabIndex = 1;
            // 
            // ButResetPassWifi
            // 
            this.ButResetPassWifi.Enabled = false;
            this.ButResetPassWifi.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButResetPassWifi.Location = new System.Drawing.Point(500, 128);
            this.ButResetPassWifi.Margin = new System.Windows.Forms.Padding(4);
            this.ButResetPassWifi.Name = "ButResetPassWifi";
            this.ButResetPassWifi.Size = new System.Drawing.Size(136, 26);
            this.ButResetPassWifi.TabIndex = 9;
            this.ButResetPassWifi.Text = "Сбросить пароль";
            this.ButResetPassWifi.UseVisualStyleBackColor = true;
            this.ButResetPassWifi.Click += new System.EventHandler(this.ButResetPassWifi_Click);
            // 
            // LabTexBoxPass
            // 
            this.LabTexBoxPass.AutoSize = true;
            this.LabTexBoxPass.Enabled = false;
            this.LabTexBoxPass.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabTexBoxPass.Location = new System.Drawing.Point(21, 205);
            this.LabTexBoxPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabTexBoxPass.Name = "LabTexBoxPass";
            this.LabTexBoxPass.Size = new System.Drawing.Size(259, 15);
            this.LabTexBoxPass.TabIndex = 8;
            this.LabTexBoxPass.Text = "Сохранить пароль для подключения к Wifi";
            // 
            // ButSaveSettingsWifi
            // 
            this.ButSaveSettingsWifi.Enabled = false;
            this.ButSaveSettingsWifi.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButSaveSettingsWifi.Location = new System.Drawing.Point(500, 94);
            this.ButSaveSettingsWifi.Margin = new System.Windows.Forms.Padding(4);
            this.ButSaveSettingsWifi.Name = "ButSaveSettingsWifi";
            this.ButSaveSettingsWifi.Size = new System.Drawing.Size(136, 26);
            this.ButSaveSettingsWifi.TabIndex = 5;
            this.ButSaveSettingsWifi.Text = "Сохранить";
            this.ButSaveSettingsWifi.UseVisualStyleBackColor = true;
            this.ButSaveSettingsWifi.Click += new System.EventHandler(this.ButSaveSettingsWifi_Click);
            // 
            // ButDelWifi
            // 
            this.ButDelWifi.Enabled = false;
            this.ButDelWifi.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButDelWifi.Location = new System.Drawing.Point(500, 162);
            this.ButDelWifi.Margin = new System.Windows.Forms.Padding(4);
            this.ButDelWifi.Name = "ButDelWifi";
            this.ButDelWifi.Size = new System.Drawing.Size(136, 26);
            this.ButDelWifi.TabIndex = 3;
            this.ButDelWifi.Text = "Удалить";
            this.ButDelWifi.UseVisualStyleBackColor = true;
            this.ButDelWifi.Click += new System.EventHandler(this.ButDelWifi_Click);
            // 
            // CheckBoxShowPass
            // 
            this.CheckBoxShowPass.AutoSize = true;
            this.CheckBoxShowPass.Enabled = false;
            this.CheckBoxShowPass.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckBoxShowPass.Location = new System.Drawing.Point(423, 205);
            this.CheckBoxShowPass.Margin = new System.Windows.Forms.Padding(4);
            this.CheckBoxShowPass.Name = "CheckBoxShowPass";
            this.CheckBoxShowPass.Size = new System.Drawing.Size(79, 19);
            this.CheckBoxShowPass.TabIndex = 7;
            this.CheckBoxShowPass.Text = "показать";
            this.CheckBoxShowPass.UseVisualStyleBackColor = true;
            this.CheckBoxShowPass.CheckedChanged += new System.EventHandler(this.CheckBoxShowPass_CheckedChanged);
            // 
            // TexBoxPass
            // 
            this.TexBoxPass.Enabled = false;
            this.TexBoxPass.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TexBoxPass.Location = new System.Drawing.Point(288, 201);
            this.TexBoxPass.Margin = new System.Windows.Forms.Padding(4);
            this.TexBoxPass.Name = "TexBoxPass";
            this.TexBoxPass.PasswordChar = '*';
            this.TexBoxPass.Size = new System.Drawing.Size(127, 23);
            this.TexBoxPass.TabIndex = 6;
            this.TexBoxPass.TextChanged += new System.EventHandler(this.TexBoxPass_TextChanged);
            // 
            // ComboPriorityWifi
            // 
            this.ComboPriorityWifi.Enabled = false;
            this.ComboPriorityWifi.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ComboPriorityWifi.FormattingEnabled = true;
            this.ComboPriorityWifi.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.ComboPriorityWifi.Location = new System.Drawing.Point(501, 63);
            this.ComboPriorityWifi.Margin = new System.Windows.Forms.Padding(4);
            this.ComboPriorityWifi.Name = "ComboPriorityWifi";
            this.ComboPriorityWifi.Size = new System.Drawing.Size(136, 23);
            this.ComboPriorityWifi.TabIndex = 4;
            this.ComboPriorityWifi.Text = "Приоритет";
            this.ComboPriorityWifi.SelectedIndexChanged += new System.EventHandler(this.ComboPriorityWifi_SelectedIndexChanged);
            // 
            // ButAddWifi
            // 
            this.ButAddWifi.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButAddWifi.Location = new System.Drawing.Point(501, 29);
            this.ButAddWifi.Margin = new System.Windows.Forms.Padding(4);
            this.ButAddWifi.Name = "ButAddWifi";
            this.ButAddWifi.Size = new System.Drawing.Size(136, 26);
            this.ButAddWifi.TabIndex = 2;
            this.ButAddWifi.Text = "Добавить Wifi";
            this.ButAddWifi.UseVisualStyleBackColor = true;
            this.ButAddWifi.Click += new System.EventHandler(this.ButAddWifi_Click);
            // 
            // LvWifi
            // 
            this.LvWifi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.LvWifi.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LvWifi.FullRowSelect = true;
            this.LvWifi.HideSelection = false;
            this.LvWifi.Location = new System.Drawing.Point(6, 29);
            this.LvWifi.Margin = new System.Windows.Forms.Padding(4);
            this.LvWifi.Name = "LvWifi";
            this.LvWifi.Size = new System.Drawing.Size(487, 159);
            this.LvWifi.TabIndex = 1;
            this.LvWifi.UseCompatibleStateImageBehavior = false;
            this.LvWifi.View = System.Windows.Forms.View.Details;
            this.LvWifi.SelectedIndexChanged += new System.EventHandler(this.LvWifi_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Имя";
            this.columnHeader1.Width = 180;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Пароль";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Приоритет";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Статус";
            this.columnHeader4.Width = 100;
            // 
            // LabPanWifi
            // 
            this.LabPanWifi.AutoSize = true;
            this.LabPanWifi.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabPanWifi.Location = new System.Drawing.Point(6, 6);
            this.LabPanWifi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabPanWifi.Name = "LabPanWifi";
            this.LabPanWifi.Size = new System.Drawing.Size(174, 19);
            this.LabPanWifi.TabIndex = 0;
            this.LabPanWifi.Text = "Настрйоки сетей Wifi";
            // 
            // LbAddress
            // 
            this.LbAddress.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LbAddress.FormattingEnabled = true;
            this.LbAddress.ItemHeight = 15;
            this.LbAddress.Location = new System.Drawing.Point(8, 35);
            this.LbAddress.Margin = new System.Windows.Forms.Padding(4);
            this.LbAddress.Name = "LbAddress";
            this.LbAddress.Size = new System.Drawing.Size(134, 94);
            this.LbAddress.TabIndex = 2;
            this.LbAddress.SelectedIndexChanged += new System.EventHandler(this.LbAddress_SelectedIndexChanged);
            // 
            // ButAddAddress
            // 
            this.ButAddAddress.Enabled = false;
            this.ButAddAddress.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButAddAddress.Location = new System.Drawing.Point(148, 66);
            this.ButAddAddress.Margin = new System.Windows.Forms.Padding(4);
            this.ButAddAddress.Name = "ButAddAddress";
            this.ButAddAddress.Size = new System.Drawing.Size(131, 26);
            this.ButAddAddress.TabIndex = 3;
            this.ButAddAddress.Text = "Добавить";
            this.ButAddAddress.UseVisualStyleBackColor = true;
            this.ButAddAddress.Click += new System.EventHandler(this.ButAddAddress_Click);
            // 
            // TexBoxAddress
            // 
            this.TexBoxAddress.Location = new System.Drawing.Point(148, 35);
            this.TexBoxAddress.Margin = new System.Windows.Forms.Padding(4);
            this.TexBoxAddress.Name = "TexBoxAddress";
            this.TexBoxAddress.Size = new System.Drawing.Size(131, 23);
            this.TexBoxAddress.TabIndex = 5;
            this.TexBoxAddress.TextChanged += new System.EventHandler(this.TexBoxAddress_TextChanged);
            // 
            // TexBoxHelp
            // 
            this.TexBoxHelp.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TexBoxHelp.Location = new System.Drawing.Point(14, 32);
            this.TexBoxHelp.Margin = new System.Windows.Forms.Padding(4);
            this.TexBoxHelp.Multiline = true;
            this.TexBoxHelp.Name = "TexBoxHelp";
            this.TexBoxHelp.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TexBoxHelp.Size = new System.Drawing.Size(635, 132);
            this.TexBoxHelp.TabIndex = 6;
            this.TexBoxHelp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TexBoxHelp_KeyPress);
            // 
            // GroupManageAddress
            // 
            this.GroupManageAddress.Controls.Add(this.ButDelAddress);
            this.GroupManageAddress.Controls.Add(this.LbAddress);
            this.GroupManageAddress.Controls.Add(this.ButAddAddress);
            this.GroupManageAddress.Controls.Add(this.TexBoxAddress);
            this.GroupManageAddress.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupManageAddress.Location = new System.Drawing.Point(669, 32);
            this.GroupManageAddress.Margin = new System.Windows.Forms.Padding(4);
            this.GroupManageAddress.Name = "GroupManageAddress";
            this.GroupManageAddress.Padding = new System.Windows.Forms.Padding(4);
            this.GroupManageAddress.Size = new System.Drawing.Size(289, 136);
            this.GroupManageAddress.TabIndex = 9;
            this.GroupManageAddress.TabStop = false;
            this.GroupManageAddress.Text = "Сервера для проверки соединения с интернетом";
            // 
            // ButDelAddress
            // 
            this.ButDelAddress.Enabled = false;
            this.ButDelAddress.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButDelAddress.Location = new System.Drawing.Point(148, 104);
            this.ButDelAddress.Margin = new System.Windows.Forms.Padding(4);
            this.ButDelAddress.Name = "ButDelAddress";
            this.ButDelAddress.Size = new System.Drawing.Size(133, 25);
            this.ButDelAddress.TabIndex = 6;
            this.ButDelAddress.Text = "Удалить";
            this.ButDelAddress.UseVisualStyleBackColor = true;
            this.ButDelAddress.Click += new System.EventHandler(this.ButDelAddress_Click);
            // 
            // GroupAutoModeStart
            // 
            this.GroupAutoModeStart.Controls.Add(this.CheckBoxAutoModeStart);
            this.GroupAutoModeStart.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupAutoModeStart.Location = new System.Drawing.Point(667, 482);
            this.GroupAutoModeStart.Name = "GroupAutoModeStart";
            this.GroupAutoModeStart.Size = new System.Drawing.Size(289, 60);
            this.GroupAutoModeStart.TabIndex = 14;
            this.GroupAutoModeStart.TabStop = false;
            this.GroupAutoModeStart.Text = "Активация режима автоматического контроля соединения с интернетом при запуске при" +
    "ложения";
            // 
            // CheckBoxAutoModeStart
            // 
            this.CheckBoxAutoModeStart.AutoSize = true;
            this.CheckBoxAutoModeStart.Location = new System.Drawing.Point(137, 33);
            this.CheckBoxAutoModeStart.Name = "CheckBoxAutoModeStart";
            this.CheckBoxAutoModeStart.Size = new System.Drawing.Size(15, 14);
            this.CheckBoxAutoModeStart.TabIndex = 0;
            this.CheckBoxAutoModeStart.UseVisualStyleBackColor = true;
            this.CheckBoxAutoModeStart.CheckedChanged += new System.EventHandler(this.CheckBoxAutoModeStart_CheckedChanged);
            // 
            // GroupTimeoutRequest
            // 
            this.GroupTimeoutRequest.Controls.Add(this.ButChangeTimeoutRequest);
            this.GroupTimeoutRequest.Controls.Add(this.TexBoxTimeoutRequest);
            this.GroupTimeoutRequest.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupTimeoutRequest.Location = new System.Drawing.Point(669, 251);
            this.GroupTimeoutRequest.Name = "GroupTimeoutRequest";
            this.GroupTimeoutRequest.Size = new System.Drawing.Size(289, 70);
            this.GroupTimeoutRequest.TabIndex = 13;
            this.GroupTimeoutRequest.TabStop = false;
            this.GroupTimeoutRequest.Text = "Таймаут ожидания ответа от сервера при проверке соединения (секунды)";
            // 
            // ButChangeTimeoutRequest
            // 
            this.ButChangeTimeoutRequest.Location = new System.Drawing.Point(146, 36);
            this.ButChangeTimeoutRequest.Name = "ButChangeTimeoutRequest";
            this.ButChangeTimeoutRequest.Size = new System.Drawing.Size(133, 25);
            this.ButChangeTimeoutRequest.TabIndex = 1;
            this.ButChangeTimeoutRequest.Text = "Изменить";
            this.ButChangeTimeoutRequest.UseVisualStyleBackColor = true;
            this.ButChangeTimeoutRequest.Click += new System.EventHandler(this.ButChangeTimeoutRequest_Click);
            // 
            // TexBoxTimeoutRequest
            // 
            this.TexBoxTimeoutRequest.Location = new System.Drawing.Point(6, 38);
            this.TexBoxTimeoutRequest.Name = "TexBoxTimeoutRequest";
            this.TexBoxTimeoutRequest.ReadOnly = true;
            this.TexBoxTimeoutRequest.Size = new System.Drawing.Size(134, 23);
            this.TexBoxTimeoutRequest.TabIndex = 0;
            this.TexBoxTimeoutRequest.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GroupPausaModem
            // 
            this.GroupPausaModem.Controls.Add(this.ButChangePausaModem);
            this.GroupPausaModem.Controls.Add(this.TexBoxPausaModem);
            this.GroupPausaModem.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupPausaModem.Location = new System.Drawing.Point(669, 397);
            this.GroupPausaModem.Name = "GroupPausaModem";
            this.GroupPausaModem.Size = new System.Drawing.Size(289, 79);
            this.GroupPausaModem.TabIndex = 12;
            this.GroupPausaModem.TabStop = false;
            this.GroupPausaModem.Text = "Задержка перед первым выполнением проверки соединения с интернетом для адаптеров " +
    "с типом \"Modem\" (сукунды)";
            // 
            // ButChangePausaModem
            // 
            this.ButChangePausaModem.Location = new System.Drawing.Point(147, 45);
            this.ButChangePausaModem.Name = "ButChangePausaModem";
            this.ButChangePausaModem.Size = new System.Drawing.Size(133, 25);
            this.ButChangePausaModem.TabIndex = 1;
            this.ButChangePausaModem.Text = "Изменить";
            this.ButChangePausaModem.UseVisualStyleBackColor = true;
            this.ButChangePausaModem.Click += new System.EventHandler(this.ButChangePausaModem_Click);
            // 
            // TexBoxPausaModem
            // 
            this.TexBoxPausaModem.Location = new System.Drawing.Point(7, 47);
            this.TexBoxPausaModem.Name = "TexBoxPausaModem";
            this.TexBoxPausaModem.ReadOnly = true;
            this.TexBoxPausaModem.Size = new System.Drawing.Size(134, 23);
            this.TexBoxPausaModem.TabIndex = 0;
            this.TexBoxPausaModem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GroupPausaCheckEnableAdapter
            // 
            this.GroupPausaCheckEnableAdapter.Controls.Add(this.ButChangePausaCheckAdapter);
            this.GroupPausaCheckEnableAdapter.Controls.Add(this.TexBoxPausaCheckEnableAdapter);
            this.GroupPausaCheckEnableAdapter.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupPausaCheckEnableAdapter.Location = new System.Drawing.Point(669, 327);
            this.GroupPausaCheckEnableAdapter.Name = "GroupPausaCheckEnableAdapter";
            this.GroupPausaCheckEnableAdapter.Size = new System.Drawing.Size(289, 64);
            this.GroupPausaCheckEnableAdapter.TabIndex = 11;
            this.GroupPausaCheckEnableAdapter.TabStop = false;
            this.GroupPausaCheckEnableAdapter.Text = "Задержка перед выполнением проверки удалось ли включить адаптер (секунды)";
            // 
            // ButChangePausaCheckAdapter
            // 
            this.ButChangePausaCheckAdapter.Location = new System.Drawing.Point(147, 33);
            this.ButChangePausaCheckAdapter.Name = "ButChangePausaCheckAdapter";
            this.ButChangePausaCheckAdapter.Size = new System.Drawing.Size(133, 25);
            this.ButChangePausaCheckAdapter.TabIndex = 1;
            this.ButChangePausaCheckAdapter.Text = "Изменить";
            this.ButChangePausaCheckAdapter.UseVisualStyleBackColor = true;
            this.ButChangePausaCheckAdapter.Click += new System.EventHandler(this.ButChangePausaCheckAdapter_Click);
            // 
            // TexBoxPausaCheckEnableAdapter
            // 
            this.TexBoxPausaCheckEnableAdapter.Location = new System.Drawing.Point(7, 35);
            this.TexBoxPausaCheckEnableAdapter.Name = "TexBoxPausaCheckEnableAdapter";
            this.TexBoxPausaCheckEnableAdapter.ReadOnly = true;
            this.TexBoxPausaCheckEnableAdapter.Size = new System.Drawing.Size(134, 23);
            this.TexBoxPausaCheckEnableAdapter.TabIndex = 0;
            this.TexBoxPausaCheckEnableAdapter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GroupIntervalCheckInternet
            // 
            this.GroupIntervalCheckInternet.Controls.Add(this.ButChangeIntervalChekcInternet);
            this.GroupIntervalCheckInternet.Controls.Add(this.TexBoxIntervalCheckInternet);
            this.GroupIntervalCheckInternet.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupIntervalCheckInternet.Location = new System.Drawing.Point(669, 175);
            this.GroupIntervalCheckInternet.Name = "GroupIntervalCheckInternet";
            this.GroupIntervalCheckInternet.Size = new System.Drawing.Size(289, 70);
            this.GroupIntervalCheckInternet.TabIndex = 10;
            this.GroupIntervalCheckInternet.TabStop = false;
            this.GroupIntervalCheckInternet.Text = "Интервал между проверками соединения с интернетом (секунды)";
            // 
            // ButChangeIntervalChekcInternet
            // 
            this.ButChangeIntervalChekcInternet.Location = new System.Drawing.Point(146, 36);
            this.ButChangeIntervalChekcInternet.Name = "ButChangeIntervalChekcInternet";
            this.ButChangeIntervalChekcInternet.Size = new System.Drawing.Size(133, 25);
            this.ButChangeIntervalChekcInternet.TabIndex = 1;
            this.ButChangeIntervalChekcInternet.Text = "Изменить";
            this.ButChangeIntervalChekcInternet.UseVisualStyleBackColor = true;
            this.ButChangeIntervalChekcInternet.Click += new System.EventHandler(this.ButChangeIntervalChekcInternet_Click);
            // 
            // TexBoxIntervalCheckInternet
            // 
            this.TexBoxIntervalCheckInternet.Location = new System.Drawing.Point(6, 38);
            this.TexBoxIntervalCheckInternet.Name = "TexBoxIntervalCheckInternet";
            this.TexBoxIntervalCheckInternet.ReadOnly = true;
            this.TexBoxIntervalCheckInternet.Size = new System.Drawing.Size(134, 23);
            this.TexBoxIntervalCheckInternet.TabIndex = 0;
            this.TexBoxIntervalCheckInternet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TimerMouseCatcher
            // 
            this.TimerMouseCatcher.Interval = 3000;
            this.TimerMouseCatcher.Tick += new System.EventHandler(this.TimerMouseCatcher_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(669, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 19);
            this.label1.TabIndex = 15;
            this.label1.Text = "Остальные настройки";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 19);
            this.label2.TabIndex = 16;
            this.label2.Text = "Подсказки";
            // 
            // LabAddAutoRun
            // 
            this.LabAddAutoRun.AutoSize = true;
            this.LabAddAutoRun.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabAddAutoRun.Location = new System.Drawing.Point(665, 545);
            this.LabAddAutoRun.Name = "LabAddAutoRun";
            this.LabAddAutoRun.Size = new System.Drawing.Size(260, 19);
            this.LabAddAutoRun.TabIndex = 17;
            this.LabAddAutoRun.Text = "Добавить в автозапуск Windows";
            // 
            // CheckBoxAddAutoRun
            // 
            this.CheckBoxAddAutoRun.AutoSize = true;
            this.CheckBoxAddAutoRun.Location = new System.Drawing.Point(931, 550);
            this.CheckBoxAddAutoRun.Name = "CheckBoxAddAutoRun";
            this.CheckBoxAddAutoRun.Size = new System.Drawing.Size(15, 14);
            this.CheckBoxAddAutoRun.TabIndex = 18;
            this.CheckBoxAddAutoRun.UseVisualStyleBackColor = true;
            this.CheckBoxAddAutoRun.CheckedChanged += new System.EventHandler(this.CheckBoxAddAutoRun_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 570);
            this.Controls.Add(this.CheckBoxAddAutoRun);
            this.Controls.Add(this.LabAddAutoRun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GroupAutoModeStart);
            this.Controls.Add(this.GroupPausaModem);
            this.Controls.Add(this.GroupTimeoutRequest);
            this.Controls.Add(this.GroupPausaCheckEnableAdapter);
            this.Controls.Add(this.LabPanNetAdap);
            this.Controls.Add(this.TexBoxHelp);
            this.Controls.Add(this.PanWifi);
            this.Controls.Add(this.PanNetAdap);
            this.Controls.Add(this.GroupIntervalCheckInternet);
            this.Controls.Add(this.GroupManageAddress);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Настройки";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingsForm_FormClosed);
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.PanNetAdap.ResumeLayout(false);
            this.PanWifi.ResumeLayout(false);
            this.PanWifi.PerformLayout();
            this.GroupManageAddress.ResumeLayout(false);
            this.GroupManageAddress.PerformLayout();
            this.GroupAutoModeStart.ResumeLayout(false);
            this.GroupAutoModeStart.PerformLayout();
            this.GroupTimeoutRequest.ResumeLayout(false);
            this.GroupTimeoutRequest.PerformLayout();
            this.GroupPausaModem.ResumeLayout(false);
            this.GroupPausaModem.PerformLayout();
            this.GroupPausaCheckEnableAdapter.ResumeLayout(false);
            this.GroupPausaCheckEnableAdapter.PerformLayout();
            this.GroupIntervalCheckInternet.ResumeLayout(false);
            this.GroupIntervalCheckInternet.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanNetAdap;
        private System.Windows.Forms.Label LabPanNetAdap;
        private System.Windows.Forms.Button ButSaveSettings;
        private System.Windows.Forms.ComboBox comboPriorityNetAdap;
        private System.Windows.Forms.ComboBox comboTypeNetAdap;
        private System.Windows.Forms.ListView LvNetAdap;
        private System.Windows.Forms.ColumnHeader clh1;
        private System.Windows.Forms.ColumnHeader clh2;
        private System.Windows.Forms.ColumnHeader clh3;
        private System.Windows.Forms.ColumnHeader clh4;
        private System.Windows.Forms.Panel PanWifi;
        private System.Windows.Forms.Label LabPanWifi;
        private System.Windows.Forms.ListView LvWifi;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button ButDelNetAdap;
        private System.Windows.Forms.Button ButAddWifi;
        private System.Windows.Forms.Button ButDelWifi;
        private System.Windows.Forms.Button ButSaveSettingsWifi;
        private System.Windows.Forms.ComboBox ComboPriorityWifi;
        private System.Windows.Forms.TextBox TexBoxPass;
        private System.Windows.Forms.Label LabTexBoxPass;
        private System.Windows.Forms.CheckBox CheckBoxShowPass;
        private System.Windows.Forms.Button ButResetPassWifi;
        private System.Windows.Forms.ListBox LbAddress;
        private System.Windows.Forms.Button ButAddAddress;
        private System.Windows.Forms.TextBox TexBoxAddress;
        private System.Windows.Forms.TextBox TexBoxHelp;
        private System.Windows.Forms.GroupBox GroupManageAddress;
        private System.Windows.Forms.Button ButDelAddress;
        private System.Windows.Forms.GroupBox GroupIntervalCheckInternet;
        private System.Windows.Forms.Button ButChangeIntervalChekcInternet;
        private System.Windows.Forms.TextBox TexBoxIntervalCheckInternet;
        private System.Windows.Forms.GroupBox GroupPausaCheckEnableAdapter;
        private System.Windows.Forms.Button ButChangePausaCheckAdapter;
        private System.Windows.Forms.TextBox TexBoxPausaCheckEnableAdapter;
        private System.Windows.Forms.GroupBox GroupPausaModem;
        private System.Windows.Forms.Button ButChangePausaModem;
        private System.Windows.Forms.TextBox TexBoxPausaModem;
        private System.Windows.Forms.GroupBox GroupTimeoutRequest;
        private System.Windows.Forms.Button ButChangeTimeoutRequest;
        private System.Windows.Forms.TextBox TexBoxTimeoutRequest;
        private System.Windows.Forms.GroupBox GroupAutoModeStart;
        private System.Windows.Forms.CheckBox CheckBoxAutoModeStart;
        private System.Windows.Forms.Timer TimerMouseCatcher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LabAddAutoRun;
        private System.Windows.Forms.CheckBox CheckBoxAddAutoRun;
    }
}