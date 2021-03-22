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
using LiveCharts;
using LiveCharts.Wpf;

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

        private delegate void MainChartSetter(double val);
        private MainChartSetter AddVal;

        private const string Celsius = "°C";
        private const string Percent = "%";
        private const string mmOfMerc = "мм. рт. ст.";
        private const string meter = "м.";

        bool IsShowTempChart = false;
        bool IsShowPresChart = false;
        bool IsShowAltChart = false;
        bool IsShowHumChart = false;

        public ChartForm()
        {
            InitializeComponent();

            serialPortMain.DataReceived += SerialPortMain_DataReceived;

            SetTemp = new TempSetter(SetNewTemperature);
            SetPres = new PresSetter(SetNewPressure);
            SetHeight = new HeightSetter(SetNewHeight);
            SetHum = new HumSetter(SetNewHumidity);
            AddVal = new MainChartSetter(AddNewValueToMainChart);

            mainChart.Series.Add(new LineSeries
            {
                Values = new ChartValues<double> { 0.0 },
                ScalesYAt = 0
            });
        }

        public void DisableAllCharts()
        {
            IsShowTempChart = false;
            IsShowPresChart = false;
            IsShowAltChart = false;
            IsShowHumChart = false;

            mainChart.Series[0].Values.Clear();
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

        private void AddNewValueToMainChart(double val)
        {
            if (mainChart.Series[0].Values.Count == 20)
            {
                mainChart.Series[0].Values.RemoveAt(0);
            }

            mainChart.Series[0].Values.Add(val);
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
            catch (FileNotFoundException ex)
            {
                IsFileExisting = false;

                Errors.ShowMessage(Errors.checkConnection);
            }

            if (IsFileExisting)
            {
                ConnectionData data = JsonConvert.DeserializeObject<ConnectionData>(rawData);

                try
                {
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
                catch(IOException ex)
                {
                    Errors.ShowMessage(Errors.deletedPort);
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

                    if (IsShowTempChart)
                    {
                        mainChart.Invoke(AddVal, double.Parse(value, System.Globalization.CultureInfo.InvariantCulture));
                    }
                }
                else if (command == Commands.BMP_E280.pressure)
                {
                    presState.Invoke(SetPres, value);

                    if (IsShowPresChart)
                    {
                        mainChart.Invoke(AddVal, double.Parse(value, System.Globalization.CultureInfo.InvariantCulture));
                    }
                }
                else if (command == Commands.BMP_E280.altitude)
                {
                    heightState.Invoke(SetHeight, value);

                    if (IsShowAltChart)
                    {
                        mainChart.Invoke(AddVal, double.Parse(value, System.Globalization.CultureInfo.InvariantCulture));
                    }
                }
                else if (command == Commands.BMP_E280.humidity)
                {
                    humState.Invoke(SetHum, value);

                    if (IsShowHumChart)
                    {
                        mainChart.Invoke(AddVal, double.Parse(value, System.Globalization.CultureInfo.InvariantCulture));
                    }
                }
            }
        }

        private void ChartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPortMain.IsOpen)
            {
                serialPortMain.WriteLine(Commands.Arduino.shutdown);
                serialPortMain.Close();
            }
        }

        private void showTempChart_Click(object sender, EventArgs e)
        {
            DisableAllCharts();
            IsShowTempChart = true;

            mainChart.AxisY[0].MinValue = -50.0;
            mainChart.AxisY[0].MaxValue = 150.0;
        }

        private void showHumChartBtn_Click(object sender, EventArgs e)
        {
            DisableAllCharts();
            IsShowHumChart = true;

            mainChart.AxisY[0].MinValue = 0.0;
            mainChart.AxisY[0].MaxValue = 100.0;
        }

        private void showPresChartBtn_Click(object sender, EventArgs e)
        {
            DisableAllCharts();
            IsShowPresChart = true;

            mainChart.AxisY[0].MinValue = 0.0;
            mainChart.AxisY[0].MaxValue = 1000.0;
        }

        private void showAltChartBtn_Click(object sender, EventArgs e)
        {
            DisableAllCharts();
            IsShowAltChart = true;

            mainChart.AxisY[0].MinValue = -20.0;
            mainChart.AxisY[0].MaxValue = 1000.0;
        }
    }
}
