namespace Pinger
{
    partial class HeadForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            try
            {
                base.Dispose(disposing);
            }
            catch { }
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HeadForm));
            this.PanNetAdap = new System.Windows.Forms.Panel();
            this.ButOffNetAdap = new System.Windows.Forms.Button();
            this.ButOnNetAdap = new System.Windows.Forms.Button();
            this.LvNetAdap = new System.Windows.Forms.ListView();
            this.clh1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clh2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clh3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clh4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LabLvNetAdap = new System.Windows.Forms.Label();
            this.PanWifi = new System.Windows.Forms.Panel();
            this.CheckShowPassWifi = new System.Windows.Forms.CheckBox();
            this.LabWifiHelp = new System.Windows.Forms.Label();
            this.TexBoxPassWifi = new System.Windows.Forms.TextBox();
            this.LabEnterPass = new System.Windows.Forms.Label();
            this.ButOffWifi = new System.Windows.Forms.Button();
            this.ButOnWifi = new System.Windows.Forms.Button();
            this.LabLvWifi = new System.Windows.Forms.Label();
            this.LvWifi = new System.Windows.Forms.ListView();
            this.LvWifiClh1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LvWifiClh2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LvWifiClh3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LvWifiClh4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TexBoxCheckInternet = new System.Windows.Forms.TextBox();
            this.ButCheckInternet = new System.Windows.Forms.Button();
            this.ButSettings = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TexBoxInfo = new System.Windows.Forms.TextBox();
            this.LabAutoMode = new System.Windows.Forms.Label();
            this.CheckBoxAutoMode = new System.Windows.Forms.CheckBox();
            this.panOveral = new System.Windows.Forms.Panel();
            this.TextBoxIntervalCheckInternet = new System.Windows.Forms.TextBox();
            this.notifi = new System.Windows.Forms.NotifyIcon(this.components);
            this.PanNetAdap.SuspendLayout();
            this.PanWifi.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panOveral.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanNetAdap
            // 
            this.PanNetAdap.Controls.Add(this.ButOffNetAdap);
            this.PanNetAdap.Controls.Add(this.ButOnNetAdap);
            this.PanNetAdap.Controls.Add(this.LvNetAdap);
            this.PanNetAdap.Controls.Add(this.LabLvNetAdap);
            this.PanNetAdap.Location = new System.Drawing.Point(20, 164);
            this.PanNetAdap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PanNetAdap.Name = "PanNetAdap";
            this.PanNetAdap.Size = new System.Drawing.Size(643, 180);
            this.PanNetAdap.TabIndex = 0;
            // 
            // ButOffNetAdap
            // 
            this.ButOffNetAdap.Enabled = false;
            this.ButOffNetAdap.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButOffNetAdap.Location = new System.Drawing.Point(114, 151);
            this.ButOffNetAdap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButOffNetAdap.Name = "ButOffNetAdap";
            this.ButOffNetAdap.Size = new System.Drawing.Size(102, 25);
            this.ButOffNetAdap.TabIndex = 3;
            this.ButOffNetAdap.Text = "Отключить";
            this.ButOffNetAdap.UseVisualStyleBackColor = true;
            this.ButOffNetAdap.Click += new System.EventHandler(this.ButOffNetAdap_Click);
            // 
            // ButOnNetAdap
            // 
            this.ButOnNetAdap.Enabled = false;
            this.ButOnNetAdap.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButOnNetAdap.Location = new System.Drawing.Point(3, 150);
            this.ButOnNetAdap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButOnNetAdap.Name = "ButOnNetAdap";
            this.ButOnNetAdap.Size = new System.Drawing.Size(102, 25);
            this.ButOnNetAdap.TabIndex = 2;
            this.ButOnNetAdap.Text = "Включить";
            this.ButOnNetAdap.UseVisualStyleBackColor = true;
            this.ButOnNetAdap.Click += new System.EventHandler(this.ButOnNetAdap_Click);
            // 
            // LvNetAdap
            // 
            this.LvNetAdap.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clh1,
            this.clh2,
            this.clh3,
            this.clh4});
            this.LvNetAdap.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LvNetAdap.ForeColor = System.Drawing.SystemColors.WindowText;
            this.LvNetAdap.FullRowSelect = true;
            this.LvNetAdap.HideSelection = false;
            this.LvNetAdap.Location = new System.Drawing.Point(3, 24);
            this.LvNetAdap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LvNetAdap.MultiSelect = false;
            this.LvNetAdap.Name = "LvNetAdap";
            this.LvNetAdap.Size = new System.Drawing.Size(628, 117);
            this.LvNetAdap.TabIndex = 1;
            this.LvNetAdap.UseCompatibleStateImageBehavior = false;
            this.LvNetAdap.View = System.Windows.Forms.View.Details;
            this.LvNetAdap.SelectedIndexChanged += new System.EventHandler(this.LvNetAdap_SelectedIndexChanged);
            // 
            // clh1
            // 
            this.clh1.Text = "Имя";
            this.clh1.Width = 190;
            // 
            // clh2
            // 
            this.clh2.Text = "Тип";
            this.clh2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clh2.Width = 136;
            // 
            // clh3
            // 
            this.clh3.Text = "Статус";
            this.clh3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clh3.Width = 160;
            // 
            // clh4
            // 
            this.clh4.Text = "Состояние";
            this.clh4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clh4.Width = 120;
            // 
            // LabLvNetAdap
            // 
            this.LabLvNetAdap.AutoSize = true;
            this.LabLvNetAdap.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabLvNetAdap.Location = new System.Drawing.Point(4, 0);
            this.LabLvNetAdap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabLvNetAdap.Name = "LabLvNetAdap";
            this.LabLvNetAdap.Size = new System.Drawing.Size(153, 19);
            this.LabLvNetAdap.TabIndex = 0;
            this.LabLvNetAdap.Text = "Сетевые адаптеры";
            // 
            // PanWifi
            // 
            this.PanWifi.Controls.Add(this.CheckShowPassWifi);
            this.PanWifi.Controls.Add(this.LabWifiHelp);
            this.PanWifi.Controls.Add(this.TexBoxPassWifi);
            this.PanWifi.Controls.Add(this.LabEnterPass);
            this.PanWifi.Controls.Add(this.ButOffWifi);
            this.PanWifi.Controls.Add(this.ButOnWifi);
            this.PanWifi.Controls.Add(this.LabLvWifi);
            this.PanWifi.Controls.Add(this.LvWifi);
            this.PanWifi.Location = new System.Drawing.Point(20, 354);
            this.PanWifi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PanWifi.Name = "PanWifi";
            this.PanWifi.Size = new System.Drawing.Size(643, 254);
            this.PanWifi.TabIndex = 1;
            // 
            // CheckShowPassWifi
            // 
            this.CheckShowPassWifi.AutoSize = true;
            this.CheckShowPassWifi.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckShowPassWifi.Location = new System.Drawing.Point(497, 226);
            this.CheckShowPassWifi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CheckShowPassWifi.Name = "CheckShowPassWifi";
            this.CheckShowPassWifi.Size = new System.Drawing.Size(79, 19);
            this.CheckShowPassWifi.TabIndex = 8;
            this.CheckShowPassWifi.Text = "показать";
            this.CheckShowPassWifi.UseVisualStyleBackColor = true;
            this.CheckShowPassWifi.CheckedChanged += new System.EventHandler(this.CheckShowPassWifi_CheckedChanged);
            // 
            // LabWifiHelp
            // 
            this.LabWifiHelp.AutoSize = true;
            this.LabWifiHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabWifiHelp.Location = new System.Drawing.Point(6, 286);
            this.LabWifiHelp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabWifiHelp.Name = "LabWifiHelp";
            this.LabWifiHelp.Size = new System.Drawing.Size(0, 15);
            this.LabWifiHelp.TabIndex = 7;
            // 
            // TexBoxPassWifi
            // 
            this.TexBoxPassWifi.Location = new System.Drawing.Point(332, 221);
            this.TexBoxPassWifi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TexBoxPassWifi.Name = "TexBoxPassWifi";
            this.TexBoxPassWifi.PasswordChar = '*';
            this.TexBoxPassWifi.Size = new System.Drawing.Size(157, 26);
            this.TexBoxPassWifi.TabIndex = 6;
            // 
            // LabEnterPass
            // 
            this.LabEnterPass.AutoSize = true;
            this.LabEnterPass.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabEnterPass.Location = new System.Drawing.Point(224, 227);
            this.LabEnterPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabEnterPass.Name = "LabEnterPass";
            this.LabEnterPass.Size = new System.Drawing.Size(100, 15);
            this.LabEnterPass.TabIndex = 5;
            this.LabEnterPass.Text = "Введите пароль";
            // 
            // ButOffWifi
            // 
            this.ButOffWifi.Enabled = false;
            this.ButOffWifi.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButOffWifi.Location = new System.Drawing.Point(114, 222);
            this.ButOffWifi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButOffWifi.Name = "ButOffWifi";
            this.ButOffWifi.Size = new System.Drawing.Size(102, 25);
            this.ButOffWifi.TabIndex = 4;
            this.ButOffWifi.Text = "Отключить";
            this.ButOffWifi.UseVisualStyleBackColor = true;
            this.ButOffWifi.Click += new System.EventHandler(this.ButOffWifi_Click);
            // 
            // ButOnWifi
            // 
            this.ButOnWifi.Enabled = false;
            this.ButOnWifi.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButOnWifi.Location = new System.Drawing.Point(4, 222);
            this.ButOnWifi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButOnWifi.Name = "ButOnWifi";
            this.ButOnWifi.Size = new System.Drawing.Size(102, 25);
            this.ButOnWifi.TabIndex = 3;
            this.ButOnWifi.Text = "Включить";
            this.ButOnWifi.UseVisualStyleBackColor = true;
            this.ButOnWifi.Click += new System.EventHandler(this.ButOnWifi_Click);
            // 
            // LabLvWifi
            // 
            this.LabLvWifi.AutoSize = true;
            this.LabLvWifi.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabLvWifi.Location = new System.Drawing.Point(6, -1);
            this.LabLvWifi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabLvWifi.Name = "LabLvWifi";
            this.LabLvWifi.Size = new System.Drawing.Size(45, 19);
            this.LabLvWifi.TabIndex = 1;
            this.LabLvWifi.Text = "WIFI";
            // 
            // LvWifi
            // 
            this.LvWifi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LvWifiClh1,
            this.LvWifiClh2,
            this.LvWifiClh3,
            this.LvWifiClh4});
            this.LvWifi.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LvWifi.FullRowSelect = true;
            this.LvWifi.HideSelection = false;
            this.LvWifi.Location = new System.Drawing.Point(4, 23);
            this.LvWifi.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LvWifi.MultiSelect = false;
            this.LvWifi.Name = "LvWifi";
            this.LvWifi.Size = new System.Drawing.Size(627, 189);
            this.LvWifi.TabIndex = 0;
            this.LvWifi.UseCompatibleStateImageBehavior = false;
            this.LvWifi.View = System.Windows.Forms.View.Details;
            this.LvWifi.SelectedIndexChanged += new System.EventHandler(this.LvWifi_SelectedIndexChanged);
            // 
            // LvWifiClh1
            // 
            this.LvWifiClh1.Text = "Имя";
            this.LvWifiClh1.Width = 190;
            // 
            // LvWifiClh2
            // 
            this.LvWifiClh2.Text = "Уровнь сигнала";
            this.LvWifiClh2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LvWifiClh2.Width = 136;
            // 
            // LvWifiClh3
            // 
            this.LvWifiClh3.Text = "Защита";
            this.LvWifiClh3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LvWifiClh3.Width = 160;
            // 
            // LvWifiClh4
            // 
            this.LvWifiClh4.Text = "Статус";
            this.LvWifiClh4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LvWifiClh4.Width = 120;
            // 
            // TexBoxCheckInternet
            // 
            this.TexBoxCheckInternet.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TexBoxCheckInternet.Location = new System.Drawing.Point(8, 67);
            this.TexBoxCheckInternet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TexBoxCheckInternet.Multiline = true;
            this.TexBoxCheckInternet.Name = "TexBoxCheckInternet";
            this.TexBoxCheckInternet.ReadOnly = true;
            this.TexBoxCheckInternet.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TexBoxCheckInternet.Size = new System.Drawing.Size(195, 486);
            this.TexBoxCheckInternet.TabIndex = 2;
            // 
            // ButCheckInternet
            // 
            this.ButCheckInternet.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButCheckInternet.Location = new System.Drawing.Point(7, 27);
            this.ButCheckInternet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ButCheckInternet.Name = "ButCheckInternet";
            this.ButCheckInternet.Size = new System.Drawing.Size(196, 33);
            this.ButCheckInternet.TabIndex = 3;
            this.ButCheckInternet.Text = "Проверить!";
            this.ButCheckInternet.UseVisualStyleBackColor = true;
            this.ButCheckInternet.Click += new System.EventHandler(this.ButCheckInternet_Click);
            // 
            // ButSettings
            // 
            this.ButSettings.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButSettings.Location = new System.Drawing.Point(679, 4);
            this.ButSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButSettings.Name = "ButSettings";
            this.ButSettings.Size = new System.Drawing.Size(195, 27);
            this.ButSettings.TabIndex = 5;
            this.ButSettings.Text = "Настройки";
            this.ButSettings.UseVisualStyleBackColor = true;
            this.ButSettings.Click += new System.EventHandler(this.ButSettings_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ButCheckInternet);
            this.groupBox1.Controls.Add(this.TexBoxCheckInternet);
            this.groupBox1.Location = new System.Drawing.Point(671, 38);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 570);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Проверка соединения";
            // 
            // TexBoxInfo
            // 
            this.TexBoxInfo.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TexBoxInfo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TexBoxInfo.Location = new System.Drawing.Point(6, 31);
            this.TexBoxInfo.Multiline = true;
            this.TexBoxInfo.Name = "TexBoxInfo";
            this.TexBoxInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TexBoxInfo.Size = new System.Drawing.Size(627, 117);
            this.TexBoxInfo.TabIndex = 8;
            this.TexBoxInfo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TexBoxAutoMode_KeyPress);
            // 
            // LabAutoMode
            // 
            this.LabAutoMode.AutoSize = true;
            this.LabAutoMode.ForeColor = System.Drawing.SystemColors.WindowText;
            this.LabAutoMode.Location = new System.Drawing.Point(6, 3);
            this.LabAutoMode.Name = "LabAutoMode";
            this.LabAutoMode.Size = new System.Drawing.Size(194, 19);
            this.LabAutoMode.TabIndex = 6;
            this.LabAutoMode.Text = "Автоматический режим";
            // 
            // CheckBoxAutoMode
            // 
            this.CheckBoxAutoMode.AutoSize = true;
            this.CheckBoxAutoMode.Location = new System.Drawing.Point(206, 6);
            this.CheckBoxAutoMode.Name = "CheckBoxAutoMode";
            this.CheckBoxAutoMode.Size = new System.Drawing.Size(15, 14);
            this.CheckBoxAutoMode.TabIndex = 7;
            this.CheckBoxAutoMode.UseVisualStyleBackColor = true;
            this.CheckBoxAutoMode.CheckedChanged += new System.EventHandler(this.CheckBoxAutoMode_CheckedChanged);
            // 
            // panOveral
            // 
            this.panOveral.Controls.Add(this.TextBoxIntervalCheckInternet);
            this.panOveral.Controls.Add(this.CheckBoxAutoMode);
            this.panOveral.Controls.Add(this.LabAutoMode);
            this.panOveral.Controls.Add(this.TexBoxInfo);
            this.panOveral.ForeColor = System.Drawing.Color.Black;
            this.panOveral.Location = new System.Drawing.Point(18, 5);
            this.panOveral.Name = "panOveral";
            this.panOveral.Size = new System.Drawing.Size(645, 151);
            this.panOveral.TabIndex = 9;
            // 
            // TextBoxIntervalCheckInternet
            // 
            this.TextBoxIntervalCheckInternet.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TextBoxIntervalCheckInternet.Location = new System.Drawing.Point(227, 3);
            this.TextBoxIntervalCheckInternet.Name = "TextBoxIntervalCheckInternet";
            this.TextBoxIntervalCheckInternet.ReadOnly = true;
            this.TextBoxIntervalCheckInternet.Size = new System.Drawing.Size(406, 23);
            this.TextBoxIntervalCheckInternet.TabIndex = 9;
            // 
            // notifi
            // 
            this.notifi.Icon = ((System.Drawing.Icon)(resources.GetObject("notifi.Icon")));
            this.notifi.Text = "Pinger";
            this.notifi.Visible = true;
            this.notifi.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifi_MouseDoubleClick);
            // 
            // HeadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 616);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ButSettings);
            this.Controls.Add(this.panOveral);
            this.Controls.Add(this.PanWifi);
            this.Controls.Add(this.PanNetAdap);
            this.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "HeadForm";
            this.Text = "Pinger";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HeadForm_FormClosing);
            this.Load += new System.EventHandler(this.HeadForm_Load);
            this.Resize += new System.EventHandler(this.HeadForm_Resize);
            this.PanNetAdap.ResumeLayout(false);
            this.PanNetAdap.PerformLayout();
            this.PanWifi.ResumeLayout(false);
            this.PanWifi.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panOveral.ResumeLayout(false);
            this.panOveral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanNetAdap;
        private System.Windows.Forms.Button ButOffNetAdap;
        private System.Windows.Forms.Button ButOnNetAdap;
        private System.Windows.Forms.ListView LvNetAdap;
        private System.Windows.Forms.ColumnHeader clh1;
        private System.Windows.Forms.ColumnHeader clh2;
        private System.Windows.Forms.ColumnHeader clh3;
        private System.Windows.Forms.ColumnHeader clh4;
        private System.Windows.Forms.Label LabLvNetAdap;
        private System.Windows.Forms.Panel PanWifi;
        private System.Windows.Forms.Label LabWifiHelp;
        private System.Windows.Forms.TextBox TexBoxPassWifi;
        private System.Windows.Forms.Label LabEnterPass;
        private System.Windows.Forms.Button ButOffWifi;
        private System.Windows.Forms.Button ButOnWifi;
        private System.Windows.Forms.Label LabLvWifi;
        private System.Windows.Forms.ListView LvWifi;
        private System.Windows.Forms.ColumnHeader LvWifiClh1;
        private System.Windows.Forms.ColumnHeader LvWifiClh2;
        private System.Windows.Forms.ColumnHeader LvWifiClh3;
        private System.Windows.Forms.ColumnHeader LvWifiClh4;
        private System.Windows.Forms.CheckBox CheckShowPassWifi;
        private System.Windows.Forms.TextBox TexBoxCheckInternet;
        private System.Windows.Forms.Button ButCheckInternet;
        private System.Windows.Forms.Button ButSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TexBoxInfo;
        private System.Windows.Forms.Label LabAutoMode;
        private System.Windows.Forms.CheckBox CheckBoxAutoMode;
        private System.Windows.Forms.Panel panOveral;
        private System.Windows.Forms.TextBox TextBoxIntervalCheckInternet;
        private System.Windows.Forms.NotifyIcon notifi;
    }
}

