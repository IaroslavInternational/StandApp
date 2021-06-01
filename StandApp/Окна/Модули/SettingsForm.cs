using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using Newtonsoft.Json;

namespace StandApp
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            string rawData = "";
            bool IsFileExisting = false;

            try
            {
                // чтение из файла
                using (FileStream fstream = File.OpenRead("connection settings.json"))
                {
                    byte[] array = new byte[fstream.Length];
                    fstream.Read(array, 0, array.Length);

                    rawData = System.Text.Encoding.Default.GetString(array);

                    IsFileExisting = true;
                }
            }
            catch (FileNotFoundException ex)
            {
                IsFileExisting = false;

                Errors.ShowMessage(Errors.checkSettings);
            }

            if (IsFileExisting)
            {
                ConnectionData data = JsonConvert.DeserializeObject<ConnectionData>(rawData);

                sCom.Text = data.PortName;

                sBaudR.Text =    Convert.ToString(data.BaudRate);
                sTout.Text =     Convert.ToString(data.Timeout);
                sCalF1.Text =    Convert.ToString(data.TenzoCalFactor1);
                sCalF2.Text =    Convert.ToString(data.TenzoCalFactor2);   
                sCalFC1.Text =   Convert.ToString(data.CurrentCalFactor1);
                sCalFC2.Text =   Convert.ToString(data.CurrentCalFactor2);
                sCalFV.Text =    Convert.ToString(data.VoltageCalFactor);
                sShoulder.Text = Convert.ToString(data.Shoulder);
                sMaxW.Text =     Convert.ToString(data.WeightChartMax);
                sMinPwm.Text =   Convert.ToString(data.WorkInterval_low);
                sMaxPwm.Text =   Convert.ToString(data.WorkInterval_high);
                sProp.Text =     Convert.ToString(data.prop);
                sEng.Text =      Convert.ToString(data.engine);
                sEsc.Text =      Convert.ToString(data.esc);

                sEnableAnim.Checked = data.IsChartAnimationActive;
                sLogSp.Text = data.LogSplitter;
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            ConnectionData newData = new ConnectionData();

            newData.PortName = sCom.Text;
            newData.BaudRate = Convert.ToInt32(sBaudR.Text); 
            newData.Timeout = Convert.ToInt32(sTout.Text);
            newData.TenzoCalFactor1 = Convert.ToDouble(sCalF1.Text);
            newData.TenzoCalFactor2 = Convert.ToDouble(sCalF2.Text);    
            newData.CurrentCalFactor1 = Convert.ToDouble(sCalFC1.Text);
            newData.CurrentCalFactor2 = Convert.ToDouble(sCalFC2.Text);
            newData.VoltageCalFactor = Convert.ToDouble(sCalFV.Text);
            newData.Shoulder = Convert.ToDouble(sShoulder.Text);
            newData.WeightChartMax = Convert.ToInt32(sMaxW.Text);
            newData.WorkInterval_low = Convert.ToInt32(sMinPwm.Text);
            newData.WorkInterval_high = Convert.ToInt32(sMaxPwm.Text);
            newData.IsChartAnimationActive = sEnableAnim.Checked;
            newData.LogSplitter = sLogSp.Text;
            newData.prop = sProp.Text;
            newData.engine = sEng.Text;
            newData.esc = sEsc.Text;

            string json = JsonConvert.SerializeObject(newData);

            // запись в файл
            using (FileStream fstream = new FileStream("connection settings.json", FileMode.Create))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(json);
                fstream.Write(array, 0, array.Length);
            }

            Errors.ShowMessage(Errors.succesSave);
        }
    }
}
