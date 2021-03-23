
namespace StandApp
{
    partial class SetupForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comList = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.baudRateList = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.testCnct = new FontAwesome.Sharp.IconButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.console = new System.Windows.Forms.RichTextBox();
            this.serialTestPort = new System.IO.Ports.SerialPort(this.components);
            this.panel4 = new System.Windows.Forms.Panel();
            this.checkBoxConnection = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.baudRateSelected = new System.Windows.Forms.Label();
            this.comPortSelected = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 14.25F);
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM-порт";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(18)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.comList);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 76);
            this.panel1.TabIndex = 1;
            // 
            // comList
            // 
            this.comList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(77)))));
            this.comList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.comList.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 14.25F);
            this.comList.ForeColor = System.Drawing.Color.Gainsboro;
            this.comList.FormattingEnabled = true;
            this.comList.ItemHeight = 25;
            this.comList.Location = new System.Drawing.Point(8, 38);
            this.comList.Name = "comList";
            this.comList.Size = new System.Drawing.Size(207, 25);
            this.comList.TabIndex = 1;
            this.comList.SelectedValueChanged += new System.EventHandler(this.comList_SelectedValueChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(18)))), ((int)(((byte)(40)))));
            this.panel2.Controls.Add(this.baudRateList);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(12, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(228, 76);
            this.panel2.TabIndex = 2;
            // 
            // baudRateList
            // 
            this.baudRateList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(77)))));
            this.baudRateList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.baudRateList.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 14.25F);
            this.baudRateList.ForeColor = System.Drawing.Color.Gainsboro;
            this.baudRateList.FormattingEnabled = true;
            this.baudRateList.ItemHeight = 25;
            this.baudRateList.Location = new System.Drawing.Point(8, 38);
            this.baudRateList.Name = "baudRateList";
            this.baudRateList.Size = new System.Drawing.Size(207, 25);
            this.baudRateList.TabIndex = 2;
            this.baudRateList.SelectedValueChanged += new System.EventHandler(this.baudRateList_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 14.25F);
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Baud-rate";
            // 
            // testCnct
            // 
            this.testCnct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.testCnct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(64)))), ((int)(((byte)(142)))));
            this.testCnct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.testCnct.FlatAppearance.BorderSize = 0;
            this.testCnct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testCnct.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.testCnct.ForeColor = System.Drawing.Color.Gainsboro;
            this.testCnct.IconChar = FontAwesome.Sharp.IconChar.NetworkWired;
            this.testCnct.IconColor = System.Drawing.Color.Gainsboro;
            this.testCnct.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.testCnct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.testCnct.Location = new System.Drawing.Point(12, 324);
            this.testCnct.Name = "testCnct";
            this.testCnct.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.testCnct.Size = new System.Drawing.Size(228, 91);
            this.testCnct.TabIndex = 3;
            this.testCnct.Text = "Проверить подключение";
            this.testCnct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.testCnct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.testCnct.UseVisualStyleBackColor = false;
            this.testCnct.Click += new System.EventHandler(this.testCnct_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(18)))), ((int)(((byte)(40)))));
            this.panel3.Controls.Add(this.console);
            this.panel3.Location = new System.Drawing.Point(255, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(387, 403);
            this.panel3.TabIndex = 2;
            // 
            // console
            // 
            this.console.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(18)))), ((int)(((byte)(40)))));
            this.console.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.console.Dock = System.Windows.Forms.DockStyle.Fill;
            this.console.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.console.ForeColor = System.Drawing.Color.Gainsboro;
            this.console.Location = new System.Drawing.Point(0, 0);
            this.console.Name = "console";
            this.console.Size = new System.Drawing.Size(387, 403);
            this.console.TabIndex = 10;
            this.console.Text = "";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(18)))), ((int)(((byte)(40)))));
            this.panel4.Controls.Add(this.checkBoxConnection);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.baudRateSelected);
            this.panel4.Controls.Add(this.comPortSelected);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Location = new System.Drawing.Point(12, 176);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(228, 142);
            this.panel4.TabIndex = 3;
            // 
            // checkBoxConnection
            // 
            this.checkBoxConnection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxConnection.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxConnection.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkBoxConnection.Location = new System.Drawing.Point(142, 111);
            this.checkBoxConnection.Name = "checkBoxConnection";
            this.checkBoxConnection.Size = new System.Drawing.Size(24, 24);
            this.checkBoxConnection.TabIndex = 6;
            this.checkBoxConnection.UseVisualStyleBackColor = true;
            this.checkBoxConnection.Click += new System.EventHandler(this.checkBoxConnection_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 14.25F);
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Location = new System.Drawing.Point(3, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 25);
            this.label7.TabIndex = 5;
            this.label7.Text = "Подключено:";
            // 
            // baudRateSelected
            // 
            this.baudRateSelected.AutoSize = true;
            this.baudRateSelected.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 14.25F);
            this.baudRateSelected.ForeColor = System.Drawing.Color.Gainsboro;
            this.baudRateSelected.Location = new System.Drawing.Point(116, 38);
            this.baudRateSelected.Name = "baudRateSelected";
            this.baudRateSelected.Size = new System.Drawing.Size(20, 25);
            this.baudRateSelected.TabIndex = 4;
            this.baudRateSelected.Text = "-";
            // 
            // comPortSelected
            // 
            this.comPortSelected.AutoSize = true;
            this.comPortSelected.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 14.25F);
            this.comPortSelected.ForeColor = System.Drawing.Color.Gainsboro;
            this.comPortSelected.Location = new System.Drawing.Point(116, 13);
            this.comPortSelected.Name = "comPortSelected";
            this.comPortSelected.Size = new System.Drawing.Size(20, 25);
            this.comPortSelected.TabIndex = 3;
            this.comPortSelected.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 14.25F);
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(3, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "COM-порт:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 14.25F);
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(3, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Baud-rate:";
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(36)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(654, 427);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.testCnct);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(654, 427);
            this.Name = "SetupForm";
            this.Text = "Подключение";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.setupForm_FormClosing);
            this.Load += new System.EventHandler(this.setupForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox comList;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox baudRateList;
        private FontAwesome.Sharp.IconButton testCnct;
        private System.Windows.Forms.Panel panel3;
        private System.IO.Ports.SerialPort serialTestPort;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label baudRateSelected;
        private System.Windows.Forms.Label comPortSelected;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxConnection;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox console;
    }
}