﻿namespace StandApp
{
    partial class btnHome
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
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(btnHome));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.exitBtn = new FontAwesome.Sharp.IconButton();
            this.linkBtn = new FontAwesome.Sharp.IconButton();
            this.manageBtn = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.homeBtn = new System.Windows.Forms.PictureBox();
            this.titleBar = new System.Windows.Forms.Panel();
            this.labelHome = new System.Windows.Forms.Label();
            this.iconCurrent = new FontAwesome.Sharp.IconPictureBox();
            this.panelShadow = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.settingsBtn = new FontAwesome.Sharp.IconButton();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.homeBtn)).BeginInit();
            this.titleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrent)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelMenu.Controls.Add(this.settingsBtn);
            this.panelMenu.Controls.Add(this.exitBtn);
            this.panelMenu.Controls.Add(this.linkBtn);
            this.panelMenu.Controls.Add(this.manageBtn);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 561);
            this.panelMenu.TabIndex = 0;
            // 
            // exitBtn
            // 
            this.exitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.exitBtn.IconColor = System.Drawing.Color.DarkOrange;
            this.exitBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.exitBtn.Location = new System.Drawing.Point(0, 486);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(220, 75);
            this.exitBtn.TabIndex = 7;
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // linkBtn
            // 
            this.linkBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.linkBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.linkBtn.FlatAppearance.BorderSize = 0;
            this.linkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.linkBtn.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.linkBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.linkBtn.IconChar = FontAwesome.Sharp.IconChar.Link;
            this.linkBtn.IconColor = System.Drawing.Color.Gainsboro;
            this.linkBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.linkBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkBtn.Location = new System.Drawing.Point(0, 200);
            this.linkBtn.Name = "linkBtn";
            this.linkBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.linkBtn.Size = new System.Drawing.Size(220, 60);
            this.linkBtn.TabIndex = 4;
            this.linkBtn.Text = "Подключение";
            this.linkBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.linkBtn.UseVisualStyleBackColor = true;
            this.linkBtn.Click += new System.EventHandler(this.linkBtn_Click);
            // 
            // manageBtn
            // 
            this.manageBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.manageBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.manageBtn.FlatAppearance.BorderSize = 0;
            this.manageBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manageBtn.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.manageBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.manageBtn.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            this.manageBtn.IconColor = System.Drawing.Color.Gainsboro;
            this.manageBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.manageBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.manageBtn.Location = new System.Drawing.Point(0, 140);
            this.manageBtn.Name = "manageBtn";
            this.manageBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.manageBtn.Size = new System.Drawing.Size(220, 60);
            this.manageBtn.TabIndex = 2;
            this.manageBtn.Text = "Управление";
            this.manageBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.manageBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.manageBtn.UseVisualStyleBackColor = true;
            this.manageBtn.Click += new System.EventHandler(this.manageBtn_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.homeBtn);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 140);
            this.panelLogo.TabIndex = 1;
            // 
            // homeBtn
            // 
            this.homeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.homeBtn.Image = global::StandApp.Properties.Resources.mainicon;
            this.homeBtn.Location = new System.Drawing.Point(3, 3);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(214, 134);
            this.homeBtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.homeBtn.TabIndex = 0;
            this.homeBtn.TabStop = false;
            this.homeBtn.Click += new System.EventHandler(this.homeBtn_Click);
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.titleBar.Controls.Add(this.labelHome);
            this.titleBar.Controls.Add(this.iconCurrent);
            this.titleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.titleBar.Location = new System.Drawing.Point(220, 0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(877, 75);
            this.titleBar.TabIndex = 1;
            this.titleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleBar_MouseDown);
            // 
            // labelHome
            // 
            this.labelHome.AutoSize = true;
            this.labelHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelHome.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelHome.ForeColor = System.Drawing.Color.Gainsboro;
            this.labelHome.Location = new System.Drawing.Point(51, 25);
            this.labelHome.Name = "labelHome";
            this.labelHome.Size = new System.Drawing.Size(55, 19);
            this.labelHome.TabIndex = 1;
            this.labelHome.Text = "Начало";
            // 
            // iconCurrent
            // 
            this.iconCurrent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.iconCurrent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconCurrent.ForeColor = System.Drawing.Color.MediumPurple;
            this.iconCurrent.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.iconCurrent.IconColor = System.Drawing.Color.MediumPurple;
            this.iconCurrent.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrent.Location = new System.Drawing.Point(17, 22);
            this.iconCurrent.Name = "iconCurrent";
            this.iconCurrent.Size = new System.Drawing.Size(32, 32);
            this.iconCurrent.TabIndex = 0;
            this.iconCurrent.TabStop = false;
            // 
            // panelShadow
            // 
            this.panelShadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(58)))));
            this.panelShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShadow.Location = new System.Drawing.Point(220, 75);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Size = new System.Drawing.Size(877, 9);
            this.panelShadow.TabIndex = 2;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(220, 84);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(877, 477);
            this.panelDesktop.TabIndex = 3;
            // 
            // settingsBtn
            // 
            this.settingsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.settingsBtn.FlatAppearance.BorderSize = 0;
            this.settingsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsBtn.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settingsBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.settingsBtn.IconChar = FontAwesome.Sharp.IconChar.SdCard;
            this.settingsBtn.IconColor = System.Drawing.Color.Gainsboro;
            this.settingsBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.settingsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsBtn.Location = new System.Drawing.Point(0, 260);
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.settingsBtn.Size = new System.Drawing.Size(220, 60);
            this.settingsBtn.TabIndex = 8;
            this.settingsBtn.Text = "Настройки";
            this.settingsBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.settingsBtn.UseVisualStyleBackColor = true;
            this.settingsBtn.Click += new System.EventHandler(this.settingsBtn_Click);
            // 
            // btnHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 561);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelShadow);
            this.Controls.Add(this.titleBar);
            this.Controls.Add(this.panelMenu);
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1113, 600);
            this.Name = "btnHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StandApp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.btnHome_FormClosing);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.homeBtn)).EndInit();
            this.titleBar.ResumeLayout(false);
            this.titleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private FontAwesome.Sharp.IconButton manageBtn;
        private System.Windows.Forms.Panel panelLogo;
        private FontAwesome.Sharp.IconButton linkBtn;
        private System.Windows.Forms.PictureBox homeBtn;
        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Label labelHome;
        private FontAwesome.Sharp.IconPictureBox iconCurrent;
        private System.Windows.Forms.Panel panelShadow;
        private System.Windows.Forms.Panel panelDesktop;
        private FontAwesome.Sharp.IconButton exitBtn;
        private FontAwesome.Sharp.IconButton settingsBtn;
    }
}

