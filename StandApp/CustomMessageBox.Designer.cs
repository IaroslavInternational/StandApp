
namespace StandApp
{
    partial class CustomMessageBox
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
            this.errorLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.messageField = new System.Windows.Forms.RichTextBox();
            this.submitBtn = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 14.25F);
            this.errorLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.errorLabel.Location = new System.Drawing.Point(7, 9);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(75, 25);
            this.errorLabel.TabIndex = 1;
            this.errorLabel.Text = "Header";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(28)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.messageField);
            this.panel1.Location = new System.Drawing.Point(12, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(321, 102);
            this.panel1.TabIndex = 3;
            // 
            // messageField
            // 
            this.messageField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(28)))), ((int)(((byte)(80)))));
            this.messageField.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.messageField.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.messageField.ForeColor = System.Drawing.Color.Gainsboro;
            this.messageField.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.messageField.Location = new System.Drawing.Point(3, 3);
            this.messageField.Name = "messageField";
            this.messageField.ReadOnly = true;
            this.messageField.Size = new System.Drawing.Size(315, 96);
            this.messageField.TabIndex = 0;
            this.messageField.Text = "Message";
            // 
            // submitBtn
            // 
            this.submitBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(50)))), ((int)(((byte)(60)))));
            this.submitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submitBtn.FlatAppearance.BorderSize = 0;
            this.submitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitBtn.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.submitBtn.ForeColor = System.Drawing.Color.Gainsboro;
            this.submitBtn.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.submitBtn.IconColor = System.Drawing.Color.Gainsboro;
            this.submitBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.submitBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.submitBtn.Location = new System.Drawing.Point(12, 154);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.submitBtn.Size = new System.Drawing.Size(321, 60);
            this.submitBtn.TabIndex = 5;
            this.submitBtn.Text = "Подтвердить";
            this.submitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.submitBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.submitBtn.UseVisualStyleBackColor = false;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // CustomMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(107)))));
            this.ClientSize = new System.Drawing.Size(350, 226);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.errorLabel);
            this.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "CustomMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CutomMessageBox";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox messageField;
        private FontAwesome.Sharp.IconButton submitBtn;
    }
}