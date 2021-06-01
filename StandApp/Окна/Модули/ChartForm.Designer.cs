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
            this.chartMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.анимацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.включитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выключитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.showRealPresBtn = new FontAwesome.Sharp.IconButton();
            this.showPresChartBtn = new FontAwesome.Sharp.IconButton();
            this.showHumChartBtn = new FontAwesome.Sharp.IconButton();
            this.showTempChartBtn = new FontAwesome.Sharp.IconButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.logAcceptBtn = new FontAwesome.Sharp.IconButton();
            this.showCurrentChart = new FontAwesome.Sharp.IconButton();
            this.showVoltageChart = new FontAwesome.Sharp.IconButton();
            this.showEngineChartBtn = new FontAwesome.Sharp.IconButton();
            this.weightPresInd = new LiveCharts.WinForms.AngularGauge();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.checkBoxLog = new System.Windows.Forms.CheckBox();
            this.intervalUE_Exp = new System.Windows.Forms.TextBox();
            this.stepUE_Exp = new System.Windows.Forms.TextBox();
            this.endUE_Exp = new System.Windows.Forms.TextBox();
            this.startUE_Exp = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.startExpOne = new FontAwesome.Sharp.IconButton();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.panel8 = new System.Windows.Forms.Panel();
            this.stopAll = new FontAwesome.Sharp.IconButton();
            this.panel6 = new System.Windows.Forms.Panel();
            this.moment_state = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.IfCurrent2Enabled = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.currentState2 = new System.Windows.Forms.Label();
            this.rpm_state = new System.Windows.Forms.Label();
            this.voltageState = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.engineSpeedStateMcs = new System.Windows.Forms.Label();
            this.currentState = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PWM = new System.Windows.Forms.Label();
            this.engineSpeedState = new System.Windows.Forms.Label();
            this.engineTrackBar = new System.Windows.Forms.TrackBar();
            this.panel1.SuspendLayout();
            this.chartMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.engineTrackBar)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(188, 116);
            this.panel1.TabIndex = 2;
            // 
            // tenzoState
            // 
            this.tenzoState.AutoSize = true;
            this.tenzoState.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.tenzoState.ForeColor = System.Drawing.Color.Gainsboro;
            this.tenzoState.Location = new System.Drawing.Point(113, 86);
            this.tenzoState.Name = "tenzoState";
            this.tenzoState.Size = new System.Drawing.Size(40, 20);
            this.tenzoState.TabIndex = 8;
            this.tenzoState.Text = "0 гр.";
            // 
            // presState
            // 
            this.presState.AutoSize = true;
            this.presState.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.presState.ForeColor = System.Drawing.Color.Gainsboro;
            this.presState.Location = new System.Drawing.Point(113, 66);
            this.presState.Name = "presState";
            this.presState.Size = new System.Drawing.Size(47, 20);
            this.presState.TabIndex = 7;
            this.presState.Text = "0 кПа";
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
            this.mainChart.Size = new System.Drawing.Size(853, 331);
            this.mainChart.TabIndex = 3;
            this.mainChart.Text = "cartesianChart1";
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
            this.анимацияToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.анимацияToolStripMenuItem.Text = "Анимация";
            // 
            // включитьToolStripMenuItem
            // 
            this.включитьToolStripMenuItem.BackColor = System.Drawing.SystemColors.Window;
            this.включитьToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.включитьToolStripMenuItem.Name = "включитьToolStripMenuItem";
            this.включитьToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.включитьToolStripMenuItem.Text = "Включить";
            this.включитьToolStripMenuItem.Click += new System.EventHandler(this.включитьToolStripMenuItem_Click);
            // 
            // выключитьToolStripMenuItem
            // 
            this.выключитьToolStripMenuItem.BackColor = System.Drawing.SystemColors.Window;
            this.выключитьToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.выключитьToolStripMenuItem.Name = "выключитьToolStripMenuItem";
            this.выключитьToolStripMenuItem.Size = new System.Drawing.Size(157, 26);
            this.выключитьToolStripMenuItem.Text = "Выключить";
            this.выключитьToolStripMenuItem.Click += new System.EventHandler(this.выключитьToolStripMenuItem_Click);
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
            this.showRealPresBtn.Click += new System.EventHandler(this.showRealPresBtn_Click);
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
            this.showTempChartBtn.BackColor = System.Drawing.Color.SpringGreen;
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
            this.panel3.Location = new System.Drawing.Point(206, 349);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(32, 116);
            this.panel3.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(18)))), ((int)(((byte)(40)))));
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Location = new System.Drawing.Point(244, 349);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(32, 116);
            this.panel4.TabIndex = 10;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(18)))), ((int)(((byte)(40)))));
            this.panel5.Controls.Add(this.logAcceptBtn);
            this.panel5.Controls.Add(this.showCurrentChart);
            this.panel5.Controls.Add(this.showVoltageChart);
            this.panel5.Controls.Add(this.showEngineChartBtn);
            this.panel5.Location = new System.Drawing.Point(3, 25);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(26, 80);
            this.panel5.TabIndex = 4;
            // 
            // logAcceptBtn
            // 
            this.logAcceptBtn.BackColor = System.Drawing.Color.DimGray;
            this.logAcceptBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logAcceptBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.logAcceptBtn.FlatAppearance.BorderSize = 0;
            this.logAcceptBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logAcceptBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.logAcceptBtn.IconChar = FontAwesome.Sharp.IconChar.File;
            this.logAcceptBtn.IconColor = System.Drawing.Color.Black;
            this.logAcceptBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.logAcceptBtn.IconSize = 20;
            this.logAcceptBtn.Location = new System.Drawing.Point(0, 60);
            this.logAcceptBtn.Name = "logAcceptBtn";
            this.logAcceptBtn.Size = new System.Drawing.Size(26, 20);
            this.logAcceptBtn.TabIndex = 5;
            this.logAcceptBtn.UseVisualStyleBackColor = false;
            this.logAcceptBtn.Click += new System.EventHandler(this.logAcceptBtn_Click);
            // 
            // showCurrentChart
            // 
            this.showCurrentChart.BackColor = System.Drawing.Color.YellowGreen;
            this.showCurrentChart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showCurrentChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.showCurrentChart.FlatAppearance.BorderSize = 0;
            this.showCurrentChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showCurrentChart.ForeColor = System.Drawing.Color.Gainsboro;
            this.showCurrentChart.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            this.showCurrentChart.IconColor = System.Drawing.Color.Black;
            this.showCurrentChart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.showCurrentChart.IconSize = 20;
            this.showCurrentChart.Location = new System.Drawing.Point(0, 40);
            this.showCurrentChart.Name = "showCurrentChart";
            this.showCurrentChart.Size = new System.Drawing.Size(26, 20);
            this.showCurrentChart.TabIndex = 4;
            this.showCurrentChart.UseVisualStyleBackColor = false;
            this.showCurrentChart.Click += new System.EventHandler(this.showCurrentChart_Click);
            // 
            // showVoltageChart
            // 
            this.showVoltageChart.BackColor = System.Drawing.Color.OrangeRed;
            this.showVoltageChart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showVoltageChart.Dock = System.Windows.Forms.DockStyle.Top;
            this.showVoltageChart.FlatAppearance.BorderSize = 0;
            this.showVoltageChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showVoltageChart.ForeColor = System.Drawing.Color.Gainsboro;
            this.showVoltageChart.IconChar = FontAwesome.Sharp.IconChar.ChargingStation;
            this.showVoltageChart.IconColor = System.Drawing.Color.Black;
            this.showVoltageChart.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.showVoltageChart.IconSize = 20;
            this.showVoltageChart.Location = new System.Drawing.Point(0, 20);
            this.showVoltageChart.Name = "showVoltageChart";
            this.showVoltageChart.Size = new System.Drawing.Size(26, 20);
            this.showVoltageChart.TabIndex = 3;
            this.showVoltageChart.UseVisualStyleBackColor = false;
            this.showVoltageChart.Click += new System.EventHandler(this.showVoltageChart_Click);
            // 
            // showEngineChartBtn
            // 
            this.showEngineChartBtn.BackColor = System.Drawing.Color.White;
            this.showEngineChartBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.showEngineChartBtn.Dock = System.Windows.Forms.DockStyle.Top;
            this.showEngineChartBtn.FlatAppearance.BorderSize = 0;
            this.showEngineChartBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showEngineChartBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.showEngineChartBtn.IconChar = FontAwesome.Sharp.IconChar.Play;
            this.showEngineChartBtn.IconColor = System.Drawing.Color.Black;
            this.showEngineChartBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.showEngineChartBtn.IconSize = 20;
            this.showEngineChartBtn.Location = new System.Drawing.Point(0, 0);
            this.showEngineChartBtn.Name = "showEngineChartBtn";
            this.showEngineChartBtn.Size = new System.Drawing.Size(26, 20);
            this.showEngineChartBtn.TabIndex = 1;
            this.showEngineChartBtn.UseVisualStyleBackColor = false;
            this.showEngineChartBtn.Click += new System.EventHandler(this.showEngineChartBtn_Click);
            // 
            // weightPresInd
            // 
            this.weightPresInd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.weightPresInd.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.weightPresInd.ForeColor = System.Drawing.Color.Gainsboro;
            this.weightPresInd.Location = new System.Drawing.Point(282, 350);
            this.weightPresInd.Name = "weightPresInd";
            this.weightPresInd.Size = new System.Drawing.Size(50, 47);
            this.weightPresInd.TabIndex = 11;
            this.weightPresInd.Text = "Весы";
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(18)))), ((int)(((byte)(40)))));
            this.panel7.Controls.Add(this.label18);
            this.panel7.Controls.Add(this.label17);
            this.panel7.Controls.Add(this.label16);
            this.panel7.Controls.Add(this.label13);
            this.panel7.Controls.Add(this.label15);
            this.panel7.Controls.Add(this.checkBoxLog);
            this.panel7.Controls.Add(this.intervalUE_Exp);
            this.panel7.Controls.Add(this.stepUE_Exp);
            this.panel7.Controls.Add(this.endUE_Exp);
            this.panel7.Controls.Add(this.startUE_Exp);
            this.panel7.Controls.Add(this.label11);
            this.panel7.Controls.Add(this.label10);
            this.panel7.Controls.Add(this.label12);
            this.panel7.Controls.Add(this.label9);
            this.panel7.Controls.Add(this.startExpOne);
            this.panel7.Location = new System.Drawing.Point(699, 349);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(166, 116);
            this.panel7.TabIndex = 16;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.label18.ForeColor = System.Drawing.Color.Gainsboro;
            this.label18.Location = new System.Drawing.Point(96, 72);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(16, 20);
            this.label18.TabIndex = 28;
            this.label18.Text = "c";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.label17.ForeColor = System.Drawing.Color.Gainsboro;
            this.label17.Location = new System.Drawing.Point(93, 50);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(22, 20);
            this.label17.TabIndex = 27;
            this.label17.Text = "%";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.label16.ForeColor = System.Drawing.Color.Gainsboro;
            this.label16.Location = new System.Drawing.Point(93, 28);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(22, 20);
            this.label16.TabIndex = 26;
            this.label16.Text = "%";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.label13.ForeColor = System.Drawing.Color.Gainsboro;
            this.label13.Location = new System.Drawing.Point(93, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(22, 20);
            this.label13.TabIndex = 22;
            this.label13.Text = "%";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.label15.ForeColor = System.Drawing.Color.Gainsboro;
            this.label15.Location = new System.Drawing.Point(3, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 20);
            this.label15.TabIndex = 25;
            this.label15.Text = "Лог:";
            // 
            // checkBoxLog
            // 
            this.checkBoxLog.Checked = true;
            this.checkBoxLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxLog.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxLog.ForeColor = System.Drawing.Color.Gainsboro;
            this.checkBoxLog.Location = new System.Drawing.Point(61, 94);
            this.checkBoxLog.Name = "checkBoxLog";
            this.checkBoxLog.Size = new System.Drawing.Size(16, 18);
            this.checkBoxLog.TabIndex = 24;
            this.checkBoxLog.UseVisualStyleBackColor = true;
            // 
            // intervalUE_Exp
            // 
            this.intervalUE_Exp.BackColor = System.Drawing.Color.Gainsboro;
            this.intervalUE_Exp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.intervalUE_Exp.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.intervalUE_Exp.Location = new System.Drawing.Point(61, 71);
            this.intervalUE_Exp.Name = "intervalUE_Exp";
            this.intervalUE_Exp.Size = new System.Drawing.Size(30, 21);
            this.intervalUE_Exp.TabIndex = 23;
            this.intervalUE_Exp.Text = "1";
            // 
            // stepUE_Exp
            // 
            this.stepUE_Exp.BackColor = System.Drawing.Color.Gainsboro;
            this.stepUE_Exp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stepUE_Exp.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stepUE_Exp.Location = new System.Drawing.Point(61, 49);
            this.stepUE_Exp.Name = "stepUE_Exp";
            this.stepUE_Exp.Size = new System.Drawing.Size(30, 21);
            this.stepUE_Exp.TabIndex = 22;
            this.stepUE_Exp.Text = "1";
            this.stepUE_Exp.TextChanged += new System.EventHandler(this.stepUE_Exp_TextChanged);
            // 
            // endUE_Exp
            // 
            this.endUE_Exp.BackColor = System.Drawing.Color.Gainsboro;
            this.endUE_Exp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.endUE_Exp.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.endUE_Exp.Location = new System.Drawing.Point(61, 27);
            this.endUE_Exp.Name = "endUE_Exp";
            this.endUE_Exp.Size = new System.Drawing.Size(30, 21);
            this.endUE_Exp.TabIndex = 21;
            this.endUE_Exp.Text = "100";
            this.endUE_Exp.TextChanged += new System.EventHandler(this.endUE_Exp_TextChanged);
            // 
            // startUE_Exp
            // 
            this.startUE_Exp.BackColor = System.Drawing.Color.Gainsboro;
            this.startUE_Exp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.startUE_Exp.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startUE_Exp.Location = new System.Drawing.Point(61, 5);
            this.startUE_Exp.Name = "startUE_Exp";
            this.startUE_Exp.Size = new System.Drawing.Size(30, 21);
            this.startUE_Exp.TabIndex = 20;
            this.startUE_Exp.Text = "0";
            this.startUE_Exp.TextChanged += new System.EventHandler(this.startUE_Exp_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.label11.ForeColor = System.Drawing.Color.Gainsboro;
            this.label11.Location = new System.Drawing.Point(3, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 20);
            this.label11.TabIndex = 19;
            this.label11.Text = "Шаг:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.label10.ForeColor = System.Drawing.Color.Gainsboro;
            this.label10.Location = new System.Drawing.Point(3, 6);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "Старт:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.label12.ForeColor = System.Drawing.Color.Gainsboro;
            this.label12.Location = new System.Drawing.Point(3, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(27, 20);
            this.label12.TabIndex = 17;
            this.label12.Text = "δt:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.label9.ForeColor = System.Drawing.Color.Gainsboro;
            this.label9.Location = new System.Drawing.Point(3, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "Конец:";
            // 
            // startExpOne
            // 
            this.startExpOne.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.startExpOne.BackColor = System.Drawing.Color.DodgerBlue;
            this.startExpOne.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startExpOne.FlatAppearance.BorderSize = 0;
            this.startExpOne.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startExpOne.ForeColor = System.Drawing.Color.Gainsboro;
            this.startExpOne.IconChar = FontAwesome.Sharp.IconChar.Rocket;
            this.startExpOne.IconColor = System.Drawing.Color.Black;
            this.startExpOne.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.startExpOne.IconSize = 20;
            this.startExpOne.Location = new System.Drawing.Point(121, 0);
            this.startExpOne.Name = "startExpOne";
            this.startExpOne.Size = new System.Drawing.Size(45, 116);
            this.startExpOne.TabIndex = 2;
            this.startExpOne.UseVisualStyleBackColor = false;
            this.startExpOne.Click += new System.EventHandler(this.startExpOne_Click);
            // 
            // MainTimer
            // 
            this.MainTimer.Tick += new System.EventHandler(this.MainTimer_Tick);
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(18)))), ((int)(((byte)(40)))));
            this.panel8.Controls.Add(this.stopAll);
            this.panel8.Location = new System.Drawing.Point(279, 399);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(56, 66);
            this.panel8.TabIndex = 17;
            // 
            // stopAll
            // 
            this.stopAll.BackColor = System.Drawing.Color.Red;
            this.stopAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stopAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stopAll.FlatAppearance.BorderSize = 0;
            this.stopAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopAll.ForeColor = System.Drawing.Color.Gainsboro;
            this.stopAll.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.stopAll.IconColor = System.Drawing.Color.Black;
            this.stopAll.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.stopAll.IconSize = 20;
            this.stopAll.Location = new System.Drawing.Point(0, 0);
            this.stopAll.Name = "stopAll";
            this.stopAll.Size = new System.Drawing.Size(56, 66);
            this.stopAll.TabIndex = 6;
            this.stopAll.UseVisualStyleBackColor = false;
            this.stopAll.Click += new System.EventHandler(this.stopAll_Click);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(18)))), ((int)(((byte)(40)))));
            this.panel6.Controls.Add(this.moment_state);
            this.panel6.Controls.Add(this.label19);
            this.panel6.Controls.Add(this.IfCurrent2Enabled);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.currentState2);
            this.panel6.Controls.Add(this.rpm_state);
            this.panel6.Controls.Add(this.voltageState);
            this.panel6.Controls.Add(this.label14);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.engineSpeedStateMcs);
            this.panel6.Controls.Add(this.currentState);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.PWM);
            this.panel6.Controls.Add(this.engineSpeedState);
            this.panel6.Controls.Add(this.engineTrackBar);
            this.panel6.Location = new System.Drawing.Point(338, 349);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(358, 116);
            this.panel6.TabIndex = 11;
            // 
            // moment_state
            // 
            this.moment_state.AutoSize = true;
            this.moment_state.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.moment_state.ForeColor = System.Drawing.Color.Gainsboro;
            this.moment_state.Location = new System.Drawing.Point(77, 71);
            this.moment_state.Name = "moment_state";
            this.moment_state.Size = new System.Drawing.Size(57, 20);
            this.moment_state.TabIndex = 27;
            this.moment_state.Text = "50 Н*м";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.label19.ForeColor = System.Drawing.Color.Gainsboro;
            this.label19.Location = new System.Drawing.Point(3, 71);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(68, 20);
            this.label19.TabIndex = 26;
            this.label19.Text = "Момент:";
            // 
            // IfCurrent2Enabled
            // 
            this.IfCurrent2Enabled.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IfCurrent2Enabled.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.IfCurrent2Enabled.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IfCurrent2Enabled.ForeColor = System.Drawing.Color.Gainsboro;
            this.IfCurrent2Enabled.Location = new System.Drawing.Point(294, 72);
            this.IfCurrent2Enabled.Name = "IfCurrent2Enabled";
            this.IfCurrent2Enabled.Size = new System.Drawing.Size(16, 18);
            this.IfCurrent2Enabled.TabIndex = 25;
            this.IfCurrent2Enabled.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.label6.ForeColor = System.Drawing.Color.Gainsboro;
            this.label6.Location = new System.Drawing.Point(190, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Ток 2:";
            // 
            // currentState2
            // 
            this.currentState2.AutoSize = true;
            this.currentState2.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.currentState2.ForeColor = System.Drawing.Color.Gainsboro;
            this.currentState2.Location = new System.Drawing.Point(243, 71);
            this.currentState2.Name = "currentState2";
            this.currentState2.Size = new System.Drawing.Size(45, 20);
            this.currentState2.TabIndex = 20;
            this.currentState2.Text = "100 А";
            // 
            // rpm_state
            // 
            this.rpm_state.AutoSize = true;
            this.rpm_state.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.rpm_state.ForeColor = System.Drawing.Color.Gainsboro;
            this.rpm_state.Location = new System.Drawing.Point(245, 92);
            this.rpm_state.Name = "rpm_state";
            this.rpm_state.Size = new System.Drawing.Size(76, 20);
            this.rpm_state.TabIndex = 19;
            this.rpm_state.Text = "5000 об/с";
            // 
            // voltageState
            // 
            this.voltageState.AutoSize = true;
            this.voltageState.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.voltageState.ForeColor = System.Drawing.Color.Gainsboro;
            this.voltageState.Location = new System.Drawing.Point(113, 92);
            this.voltageState.Name = "voltageState";
            this.voltageState.Size = new System.Drawing.Size(38, 20);
            this.voltageState.TabIndex = 17;
            this.voltageState.Text = "50 В";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.label14.ForeColor = System.Drawing.Color.Gainsboro;
            this.label14.Location = new System.Drawing.Point(190, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 20);
            this.label14.TabIndex = 16;
            this.label14.Text = "Ток 1:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.label8.ForeColor = System.Drawing.Color.Gainsboro;
            this.label8.Location = new System.Drawing.Point(190, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 20);
            this.label8.TabIndex = 18;
            this.label8.Text = "RPM:";
            // 
            // engineSpeedStateMcs
            // 
            this.engineSpeedStateMcs.AutoSize = true;
            this.engineSpeedStateMcs.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.engineSpeedStateMcs.ForeColor = System.Drawing.Color.Gainsboro;
            this.engineSpeedStateMcs.Location = new System.Drawing.Point(114, 50);
            this.engineSpeedStateMcs.Name = "engineSpeedStateMcs";
            this.engineSpeedStateMcs.Size = new System.Drawing.Size(70, 20);
            this.engineSpeedStateMcs.TabIndex = 15;
            this.engineSpeedStateMcs.Text = "2400 мкс";
            // 
            // currentState
            // 
            this.currentState.AutoSize = true;
            this.currentState.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.currentState.ForeColor = System.Drawing.Color.Gainsboro;
            this.currentState.Location = new System.Drawing.Point(243, 49);
            this.currentState.Name = "currentState";
            this.currentState.Size = new System.Drawing.Size(45, 20);
            this.currentState.TabIndex = 14;
            this.currentState.Text = "100 А";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.label7.ForeColor = System.Drawing.Color.Gainsboro;
            this.label7.Location = new System.Drawing.Point(4, 92);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Напряжение:";
            // 
            // PWM
            // 
            this.PWM.AutoSize = true;
            this.PWM.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.PWM.ForeColor = System.Drawing.Color.DarkOrange;
            this.PWM.Location = new System.Drawing.Point(3, 50);
            this.PWM.Name = "PWM";
            this.PWM.Size = new System.Drawing.Size(51, 20);
            this.PWM.TabIndex = 9;
            this.PWM.Text = "ШИМ:";
            // 
            // engineSpeedState
            // 
            this.engineSpeedState.AutoSize = true;
            this.engineSpeedState.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.engineSpeedState.ForeColor = System.Drawing.Color.Gainsboro;
            this.engineSpeedState.Location = new System.Drawing.Point(60, 50);
            this.engineSpeedState.Name = "engineSpeedState";
            this.engineSpeedState.Size = new System.Drawing.Size(48, 20);
            this.engineSpeedState.TabIndex = 9;
            this.engineSpeedState.Text = "100 %";
            // 
            // engineTrackBar
            // 
            this.engineTrackBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.engineTrackBar.Location = new System.Drawing.Point(0, 0);
            this.engineTrackBar.Maximum = 100;
            this.engineTrackBar.Name = "engineTrackBar";
            this.engineTrackBar.Size = new System.Drawing.Size(358, 45);
            this.engineTrackBar.TabIndex = 12;
            this.engineTrackBar.TickFrequency = 2;
            this.engineTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.engineTrackBar.ValueChanged += new System.EventHandler(this.engineTrackBar_ValueChanged);
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(36)))), ((int)(((byte)(81)))));
            this.ClientSize = new System.Drawing.Size(877, 477);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.weightPresInd);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.mainChart);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(877, 477);
            this.Name = "ChartForm";
            this.Text = "Управление";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChartForm_FormClosing);
            this.Load += new System.EventHandler(this.ChartForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.chartMenu.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.engineTrackBar)).EndInit();
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
        private FontAwesome.Sharp.IconButton showEngineChartBtn;
        private System.Windows.Forms.Panel panel7;
        private FontAwesome.Sharp.IconButton startExpOne;
        private System.Windows.Forms.TextBox intervalUE_Exp;
        private System.Windows.Forms.TextBox stepUE_Exp;
        private System.Windows.Forms.TextBox endUE_Exp;
        private System.Windows.Forms.TextBox startUE_Exp;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private FontAwesome.Sharp.IconButton showCurrentChart;
        private FontAwesome.Sharp.IconButton showVoltageChart;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox checkBoxLog;
        private System.Windows.Forms.Panel panel8;
        private FontAwesome.Sharp.IconButton stopAll;
        private FontAwesome.Sharp.IconButton logAcceptBtn;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label currentState2;
        private System.Windows.Forms.Label rpm_state;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label voltageState;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label engineSpeedStateMcs;
        private System.Windows.Forms.Label currentState;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label PWM;
        private System.Windows.Forms.Label engineSpeedState;
        private System.Windows.Forms.TrackBar engineTrackBar;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox IfCurrent2Enabled;
        private System.Windows.Forms.Label moment_state;
        private System.Windows.Forms.Label label19;
    }
}