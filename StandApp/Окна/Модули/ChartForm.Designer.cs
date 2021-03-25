namespace StandApp
{
    partial class ChartForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tenzoState = new System.Windows.Forms.Label();
            this.presState = new System.Windows.Forms.Label();
            this.humState = new System.Windows.Forms.Label();
            this.tempState = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.serialPortMain = new System.IO.Ports.SerialPort(this.components);
            this.mainChart = new LiveCharts.WinForms.CartesianChart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.showRealPresBtn = new FontAwesome.Sharp.IconButton();
            this.showPresChartBtn = new FontAwesome.Sharp.IconButton();
            this.showHumChartBtn = new FontAwesome.Sharp.IconButton();
            this.showTempChartBtn = new FontAwesome.Sharp.IconButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.weightPresInd = new LiveCharts.WinForms.AngularGauge();
            this.chartMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.анимацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.включитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выключитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.chartMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(18)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.tenzoState);
            this.panel1.Controls.Add(this.presState);
            this.panel1.Controls.Add(this.humState);
            this.panel1.Controls.Add(this.tempState);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 349);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 116);
            this.panel1.TabIndex = 2;
            // 
            // tenzoState
            // 
            this.tenzoState.AutoSize = true;
            this.tenzoState.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.tenzoState.ForeColor = System.Drawing.Color.Gainsboro;
            this.tenzoState.Location = new System.Drawing.Point(113, 86);
            this.tenzoState.Name = "tenzoState";
            this.tenzoState.Size = new System.Drawing.Size(35, 20);
            this.tenzoState.TabIndex = 8;
            this.tenzoState.Text = "0 м.";
            // 
            // presState
            // 
            this.presState.AutoSize = true;
            this.presState.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.presState.ForeColor = System.Drawing.Color.Gainsboro;
            this.presState.Location = new System.Drawing.Point(113, 66);
            this.presState.Name = "presState";
            this.presState.Size = new System.Drawing.Size(89, 20);
            this.presState.TabIndex = 7;
            this.presState.Text = "0 мм. рт. ст.";
            // 
            // humState
            // 
            this.humState.AutoSize = true;
            this.humState.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.humState.ForeColor = System.Drawing.Color.Gainsboro;
            this.humState.Location = new System.Drawing.Point(113, 46);
            this.humState.Name = "humState";
            this.humState.Size = new System.Drawing.Size(34, 20);
            this.humState.TabIndex = 6;
            this.humState.Text = "0 %";
            // 
            // tempState
            // 
            this.tempState.AutoSize = true;
            this.tempState.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.tempState.ForeColor = System.Drawing.Color.Gainsboro;
            this.tempState.Location = new System.Drawing.Point(113, 26);
            this.tempState.Name = "tempState";
            this.tempState.Size = new System.Drawing.Size(37, 20);
            this.tempState.TabIndex = 5;
            this.tempState.Text = "0 °C";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.label5.ForeColor = System.Drawing.Color.Gainsboro;
            this.label5.Location = new System.Drawing.Point(4, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Температура:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(4, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Тензодатчик:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.label3.ForeColor = System.Drawing.Color.Gainsboro;
            this.label3.Location = new System.Drawing.Point(4, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Давление:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.label2.ForeColor = System.Drawing.Color.Gainsboro;
            this.label2.Location = new System.Drawing.Point(4, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Влажность:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 14.25F);
            this.label1.ForeColor = System.Drawing.Color.Gainsboro;
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Показатели:";
            // 
            // mainChart
            // 
            this.mainChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mainChart.ContextMenuStrip = this.chartMenu;
            this.mainChart.Location = new System.Drawing.Point(12, 12);
            this.mainChart.Name = "mainChart";
            this.mainChart.Size = new System.Drawing.Size(740, 331);
            this.mainChart.TabIndex = 3;
            this.mainChart.Text = "cartesianChart1";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(18)))), ((int)(((byte)(40)))));
            this.panel2.Controls.Add(this.showRealPresBtn);
            this.panel2.Controls.Add(this.showPresChartBtn);
            this.panel2.Controls.Add(this.showHumChartBtn);
            this.panel2.Controls.Add(this.showTempChartBtn);
            this.panel2.Location = new System.Drawing.Point(3, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(26, 80);
            this.panel2.TabIndex = 4;
            // 
            // showRealPresBtn
            // 
            this.showRealPresBtn.BackColor = System.Drawing.Color.Maroon;
            this.showRealPresBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showRealPresBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.showRealPresBtn.FlatAppearance.BorderSize = 0;
            this.showRealPresBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showRealPresBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.showRealPresBtn.IconChar = FontAwesome.Sharp.IconChar.LongArrowAltDown;
            this.showRealPresBtn.IconColor = System.Drawing.Color.Black;
            this.showRealPresBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.showRealPresBtn.IconSize = 20;
            this.showRealPresBtn.Location = new System.Drawing.Point(0, 60);
            this.showRealPresBtn.Name = "showRealPresBtn";
            this.showRealPresBtn.Size = new System.Drawing.Size(26, 20);
            this.showRealPresBtn.TabIndex = 3;
            this.showRealPresBtn.UseVisualStyleBackColor = false;
            // 
            // showPresChartBtn
            // 
            this.showPresChartBtn.BackColor = System.Drawing.Color.BlueViolet;
            this.showPresChartBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showPresChartBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.showPresChartBtn.FlatAppearance.BorderSize = 0;
            this.showPresChartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showPresChartBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.showPresChartBtn.IconChar = FontAwesome.Sharp.IconChar.CompressAlt;
            this.showPresChartBtn.IconColor = System.Drawing.Color.Black;
            this.showPresChartBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.showPresChartBtn.IconSize = 20;
            this.showPresChartBtn.Location = new System.Drawing.Point(0, 40);
            this.showPresChartBtn.Name = "showPresChartBtn";
            this.showPresChartBtn.Size = new System.Drawing.Size(26, 20);
            this.showPresChartBtn.TabIndex = 2;
            this.showPresChartBtn.UseVisualStyleBackColor = false;
            this.showPresChartBtn.Click += new System.EventHandler(this.showPresChartBtn_Click);
            // 
            // showHumChartBtn
            // 
            this.showHumChartBtn.BackColor = System.Drawing.Color.DodgerBlue;
            this.showHumChartBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showHumChartBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.showHumChartBtn.FlatAppearance.BorderSize = 0;
            this.showHumChartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showHumChartBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.showHumChartBtn.IconChar = FontAwesome.Sharp.IconChar.Tint;
            this.showHumChartBtn.IconColor = System.Drawing.Color.Black;
            this.showHumChartBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.showHumChartBtn.IconSize = 20;
            this.showHumChartBtn.Location = new System.Drawing.Point(0, 20);
            this.showHumChartBtn.Name = "showHumChartBtn";
            this.showHumChartBtn.Size = new System.Drawing.Size(26, 20);
            this.showHumChartBtn.TabIndex = 1;
            this.showHumChartBtn.UseVisualStyleBackColor = false;
            this.showHumChartBtn.Click += new System.EventHandler(this.showHumChartBtn_Click);
            // 
            // showTempChartBtn
            // 
            this.showTempChartBtn.BackColor = System.Drawing.Color.Goldenrod;
            this.showTempChartBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showTempChartBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.showTempChartBtn.FlatAppearance.BorderSize = 0;
            this.showTempChartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showTempChartBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.showTempChartBtn.IconChar = FontAwesome.Sharp.IconChar.ThermometerThreeQuarters;
            this.showTempChartBtn.IconColor = System.Drawing.Color.Black;
            this.showTempChartBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.showTempChartBtn.IconSize = 20;
            this.showTempChartBtn.Location = new System.Drawing.Point(0, 0);
            this.showTempChartBtn.Name = "showTempChartBtn";
            this.showTempChartBtn.Size = new System.Drawing.Size(26, 20);
            this.showTempChartBtn.TabIndex = 0;
            this.showTempChartBtn.UseVisualStyleBackColor = false;
            this.showTempChartBtn.Click += new System.EventHandler(this.showTempChart_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(18)))), ((int)(((byte)(40)))));
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Location = new System.Drawing.Point(264, 349);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(32, 116);
            this.panel3.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(18)))), ((int)(((byte)(40)))));
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(302, 349);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(32, 116);
            this.panel4.TabIndex = 10;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(18)))), ((int)(((byte)(40)))));
            this.panel5.Location = new System.Drawing.Point(3, 25);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(26, 80);
            this.panel5.TabIndex = 4;
            // 
            // weightPresInd
            // 
            this.weightPresInd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.weightPresInd.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.weightPresInd.ForeColor = System.Drawing.Color.Gainsboro;
            this.weightPresInd.Location = new System.Drawing.Point(340, 350);
            this.weightPresInd.Name = "weightPresInd";
            this.weightPresInd.Size = new System.Drawing.Size(122, 115);
            this.weightPresInd.TabIndex = 11;
            this.weightPresInd.Text = "Весы";
            // 
            // chartMenu
            // 
            this.chartMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(77)))));
            this.chartMenu.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chartMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.анимацияToolStripMenuItem});
            this.chartMenu.Name = "chartMenu";
            this.chartMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.chartMenu.Size = new System.Drawing.Size(153, 30);
            // 
            // анимацияToolStripMenuItem
            // 
            this.анимацияToolStripMenuItem.BackColor = System.Drawing.SystemColors.Window;
            this.анимацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.включитьToolStripMenuItem,
            this.выключитьToolStripMenuItem});
            this.анимацияToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.анимацияToolStripMenuItem.Name = "анимацияToolStripMenuItem";
            this.анимацияToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.анимацияToolStripMenuItem.Text = "Анимация";
            // 
            // включитьToolStripMenuItem
            // 
            this.включитьToolStripMenuItem.BackColor = System.Drawing.SystemColors.Window;
            this.включитьToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.включитьToolStripMenuItem.Name = "включитьToolStripMenuItem";
            this.включитьToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.включитьToolStripMenuItem.Text = "Включить";
            this.включитьToolStripMenuItem.Click += new System.EventHandler(this.включитьToolStripMenuItem_Click);
            // 
            // выключитьToolStripMenuItem
            // 
            this.выключитьToolStripMenuItem.BackColor = System.Drawing.SystemColors.Window;
            this.выключитьToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.выключитьToolStripMenuItem.Name = "выключитьToolStripMenuItem";
            this.выключитьToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.выключитьToolStripMenuItem.Text = "Выключить";
            this.выключитьToolStripMenuItem.Click += new System.EventHandler(this.выключитьToolStripMenuItem_Click);
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(36)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(764, 477);
            this.Controls.Add(this.weightPresInd);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.mainChart);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(764, 477);
            this.Name = "ChartForm";
            this.Text = "ChartForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChartForm_FormClosing);
            this.Load += new System.EventHandler(this.ChartForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.chartMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPortMain;
        private LiveCharts.WinForms.CartesianChart mainChart;
        private System.Windows.Forms.Label tenzoState;
        private System.Windows.Forms.Label presState;
        private System.Windows.Forms.Label humState;
        private System.Windows.Forms.Label tempState;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton showTempChartBtn;
        private FontAwesome.Sharp.IconButton showPresChartBtn;
        private FontAwesome.Sharp.IconButton showHumChartBtn;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private LiveCharts.WinForms.AngularGauge weightPresInd;
        private FontAwesome.Sharp.IconButton showRealPresBtn;
        private System.Windows.Forms.ContextMenuStrip chartMenu;
        private System.Windows.Forms.ToolStripMenuItem анимацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem включитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выключитьToolStripMenuItem;
    }
}