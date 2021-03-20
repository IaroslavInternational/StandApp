
namespace StandApp
{
    partial class setupForm
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
            this.console = new System.Windows.Forms.RichTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.serialTestPort = new System.IO.Ports.SerialPort(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
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
            this.testCnct.Location = new System.Drawing.Point(12, 277);
            this.testCnct.Name = "testCnct";
            this.testCnct.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.testCnct.Size = new System.Drawing.Size(228, 60);
            this.testCnct.TabIndex = 3;
            this.testCnct.Text = "Проверить подключение";
            this.testCnct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.testCnct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.testCnct.UseVisualStyleBackColor = false;
            this.testCnct.Click += new System.EventHandler(this.testCnct_Click);
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
            this.console.Size = new System.Drawing.Size(355, 325);
            this.console.TabIndex = 4;
            this.console.Text = "";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(18)))), ((int)(((byte)(40)))));
            this.panel3.Controls.Add(this.console);
            this.panel3.Location = new System.Drawing.Point(255, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(355, 325);
            this.panel3.TabIndex = 2;
            // 
            // setupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(622, 349);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.testCnct);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "setupForm";
            this.Text = "setupForm";
            this.Load += new System.EventHandler(this.setupForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
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
        private System.Windows.Forms.RichTextBox console;
        private System.Windows.Forms.Panel panel3;
        private System.IO.Ports.SerialPort serialTestPort;
    }
}