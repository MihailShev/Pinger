namespace Pinger
{
    partial class AddWifiForm
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
            this.LvWifi = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LabLvWifi = new System.Windows.Forms.Label();
            this.LbWifi = new System.Windows.Forms.ListBox();
            this.LabLbWifi = new System.Windows.Forms.Label();
            this.ButAddWifi = new System.Windows.Forms.Button();
            this.ButDelWifi = new System.Windows.Forms.Button();
            this.ButSaveAddedWifi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LvWifi
            // 
            this.LvWifi.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.LvWifi.FullRowSelect = true;
            this.LvWifi.HideSelection = false;
            this.LvWifi.Location = new System.Drawing.Point(14, 38);
            this.LvWifi.MultiSelect = false;
            this.LvWifi.Name = "LvWifi";
            this.LvWifi.Size = new System.Drawing.Size(396, 169);
            this.LvWifi.TabIndex = 0;
            this.LvWifi.UseCompatibleStateImageBehavior = false;
            this.LvWifi.View = System.Windows.Forms.View.Details;
            this.LvWifi.SelectedIndexChanged += new System.EventHandler(this.LvWifi_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Имя";
            this.columnHeader1.Width = 79;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Уровень сигнала";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 115;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Защита";
            this.columnHeader3.Width = 90;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Статус";
            this.columnHeader4.Width = 90;
            // 
            // LabLvWifi
            // 
            this.LabLvWifi.AutoSize = true;
            this.LabLvWifi.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabLvWifi.Location = new System.Drawing.Point(14, 13);
            this.LabLvWifi.Name = "LabLvWifi";
            this.LabLvWifi.Size = new System.Drawing.Size(166, 19);
            this.LabLvWifi.TabIndex = 1;
            this.LabLvWifi.Text = "Доступные сети Wifi";
            // 
            // LbWifi
            // 
            this.LbWifi.FormattingEnabled = true;
            this.LbWifi.ItemHeight = 15;
            this.LbWifi.Location = new System.Drawing.Point(523, 38);
            this.LbWifi.Name = "LbWifi";
            this.LbWifi.Size = new System.Drawing.Size(169, 169);
            this.LbWifi.TabIndex = 2;
            this.LbWifi.SelectedIndexChanged += new System.EventHandler(this.LbWifi_SelectedIndexChanged);
            // 
            // LabLbWifi
            // 
            this.LabLbWifi.AutoSize = true;
            this.LabLbWifi.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabLbWifi.Location = new System.Drawing.Point(519, 13);
            this.LabLbWifi.Name = "LabLbWifi";
            this.LabLbWifi.Size = new System.Drawing.Size(173, 19);
            this.LabLbWifi.TabIndex = 3;
            this.LabLbWifi.Text = "Выбранные сети Wifi";
            // 
            // ButAddWifi
            // 
            this.ButAddWifi.Enabled = false;
            this.ButAddWifi.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButAddWifi.Location = new System.Drawing.Point(416, 38);
            this.ButAddWifi.Name = "ButAddWifi";
            this.ButAddWifi.Size = new System.Drawing.Size(101, 27);
            this.ButAddWifi.TabIndex = 4;
            this.ButAddWifi.Text = "Добавить";
            this.ButAddWifi.UseVisualStyleBackColor = true;
            this.ButAddWifi.Click += new System.EventHandler(this.ButAddWifi_Click);
            // 
            // ButDelWifi
            // 
            this.ButDelWifi.Enabled = false;
            this.ButDelWifi.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButDelWifi.Location = new System.Drawing.Point(416, 71);
            this.ButDelWifi.Name = "ButDelWifi";
            this.ButDelWifi.Size = new System.Drawing.Size(101, 27);
            this.ButDelWifi.TabIndex = 5;
            this.ButDelWifi.Text = "Удалить";
            this.ButDelWifi.UseVisualStyleBackColor = true;
            this.ButDelWifi.Click += new System.EventHandler(this.ButDelWifi_Click);
            // 
            // ButSaveAddedWifi
            // 
            this.ButSaveAddedWifi.Enabled = false;
            this.ButSaveAddedWifi.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButSaveAddedWifi.Location = new System.Drawing.Point(416, 180);
            this.ButSaveAddedWifi.Name = "ButSaveAddedWifi";
            this.ButSaveAddedWifi.Size = new System.Drawing.Size(101, 27);
            this.ButSaveAddedWifi.TabIndex = 6;
            this.ButSaveAddedWifi.Text = "Сохранить";
            this.ButSaveAddedWifi.UseVisualStyleBackColor = true;
            this.ButSaveAddedWifi.Click += new System.EventHandler(this.ButSaveAddedWifi_Click);
            // 
            // AddWifiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 211);
            this.Controls.Add(this.ButSaveAddedWifi);
            this.Controls.Add(this.ButDelWifi);
            this.Controls.Add(this.ButAddWifi);
            this.Controls.Add(this.LabLbWifi);
            this.Controls.Add(this.LbWifi);
            this.Controls.Add(this.LabLvWifi);
            this.Controls.Add(this.LvWifi);
            this.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddWifiForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Добавление сетей Wifi";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddWifiForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView LvWifi;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label LabLvWifi;
        private System.Windows.Forms.ListBox LbWifi;
        private System.Windows.Forms.Label LabLbWifi;
        private System.Windows.Forms.Button ButAddWifi;
        private System.Windows.Forms.Button ButDelWifi;
        private System.Windows.Forms.Button ButSaveAddedWifi;
    }
}