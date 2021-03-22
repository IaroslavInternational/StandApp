using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Newtonsoft.Json;
using System.IO;
using System.IO.Ports;

namespace StandApp
{
    public partial class ChartForm : Form
    {
        private delegate void TempSetter(string val);
        private TempSetter SetTemp;

        private delegate void PresSetter(string val);
        private PresSetter SetPres;

        private delegate void HeightSetter(string val);
        private HeightSetter SetHeight;

        private delegate void HumSetter(string val);
        private HumSetter SetHum;       

        private const string Celsius = "°C";
        private const string Percent = "%";
        private const string mmOfMerc = "мм. рт. ст.";
        private const string meter = "м.";

        public ChartForm()
        {
            InitializeComponent();

            serialPortMain.DataReceived += SerialPortMain_DataReceived;

            SetTemp = new TempSetter(SetNewTemperature);
            SetPres = new PresSetter(SetNewPressure);
            SetHeight = new HeightSetter(SetNewHeight);
            SetHum = new HumSetter(SetNewHumidity);
        }

        private void SetNewTemperature(string val)
        {
            tempState.Text = val + " " + Celsius;
        }  
        
        private void SetNewHumidity(string val)
        {
            humState.Text = val + " " + Percent;
        }

        private void SetNewPressure(string val)
        {
            presState.Text = val + " " + mmOfMerc;
        }

        private void SetNewHeight(string val)
        {
            heightState.Text = val + " " + meter;
        }

        private void ChartForm_Load(object sender, EventArgs e)
        {
            string rawData = "";
            bool IsFileExisting = false;

            try
            {
                // чтение из файла
                using (FileStream fstream = File.OpenRead("connection settings.json"))
                {
                    // преобразуем строку в байты
                    byte[] array = new byte[fstream.Length];
                    // считываем данные
                    fstream.Read(array, 0, array.Length);
                    // декодируем байты в строку
                    rawData = System.Text.Encoding.Default.GetString(array);

                    IsFileExisting = true;
                }
            }
            catch(FileNotFoundException ex)
            {
                IsFileExisting = false;

                Errors.ShowMessage(Errors.checkConnection);
            }

            if (IsFileExisting)
            {
                ConnectionData data = JsonConvert.DeserializeObject<ConnectionData>(rawData);

                serialPortMain.PortName = data.PortName;
                serialPortMain.BaudRate = data.BaudRate;

                if (!serialPortMain.IsOpen)
                {
                    serialPortMain.Open();
                    serialPortMain.WriteLine("[Work mode]");
                }
                else
                {
                    Errors.ShowMessage(Errors.portIsBusy);
                }
            }
        }

        private void SerialPortMain_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var data = serialPortMain.ReadLine();
            data = Commands.DeleteSpecSymb(data);

            string[] arr_data = data.Split(Commands.SPLITTER);

            if (arr_data.Length != 1)
            {
                string command = arr_data[0];
                string value = arr_data[1];

                if (command == Commands.BMP_E280.temperature)
                {
                    tempState.Invoke(SetTemp, value);
                }
                else if (command == Commands.BMP_E280.pressure)
                {
                    presState.Invoke(SetPres, value);
                }
                else if (command == Commands.BMP_E280.altitude)
                {
                    heightState.Invoke(SetHeight, value);
                }
                else if (command == Commands.BMP_E280.humidity)
                {
                    humState.Invoke(SetHum, value);
                }
            }           
        }

        private void ChartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPortMain.IsOpen)
            {
                serialPortMain.Close();
            }
        }
    }
}
