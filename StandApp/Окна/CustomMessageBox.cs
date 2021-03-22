using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StandApp
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox(Errors.ErrorStruct es)
        {
            InitializeComponent();

            errorLabel.Text = es.header;
            messageField.Text = es.message;
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
