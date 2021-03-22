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
            this.label1 = new System.Windows.Forms.Label();
            this.serialPortMain = new System.IO.Ports.SerialPort(this.components);
            this.mainChart = new LiveCharts.WinForms.CartesianChart();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tempState = new System.Windows.Forms.Label();
            this.humState = new System.Windows.Forms.Label();
            this.presState = new System.Windows.Forms.Label();
            this.heightState = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(18)))), ((int)(((byte)(40)))));
            this.panel1.Controls.Add(this.heightState);
            this.panel1.Controls.Add(this.presState);
            this.panel1.Controls.Add(this.humState);
            this.panel1.Controls.Add(this.tempState);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 299);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 116);
            this.panel1.TabIndex = 2;
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
            this.mainChart.Location = new System.Drawing.Point(12, 12);
            this.mainChart.Name = "mainChart";
            this.mainChart.Size = new System.Drawing.Size(630, 281);
            this.mainChart.TabIndex = 3;
            this.mainChart.Text = "cartesianChart1";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.label4.ForeColor = System.Drawing.Color.Gainsboro;
            this.label4.Location = new System.Drawing.Point(4, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Высота:";
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
            // heightState
            // 
            this.heightState.AutoSize = true;
            this.heightState.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11F);
            this.heightState.ForeColor = System.Drawing.Color.Gainsboro;
            this.heightState.Location = new System.Drawing.Point(113, 86);
            this.heightState.Name = "heightState";
            this.heightState.Size = new System.Drawing.Size(35, 20);
            this.heightState.TabIndex = 8;
            this.heightState.Text = "0 м.";
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.ClientSize = new System.Drawing.Size(654, 427);
            this.Controls.Add(this.mainChart);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChartForm";
            this.Text = "ChartForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChartForm_FormClosing);
            this.Load += new System.EventHandler(this.ChartForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPortMain;
        private LiveCharts.WinForms.CartesianChart mainChart;
        private System.Windows.Forms.Label heightState;
        private System.Windows.Forms.Label presState;
        private System.Windows.Forms.Label humState;
        private System.Windows.Forms.Label tempState;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}