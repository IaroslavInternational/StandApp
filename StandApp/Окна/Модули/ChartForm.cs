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
        /* Делегаты */
        
        // Установка текста для температуры в другом потоке
        private delegate void TempSetter(string val);
        private TempSetter SetTemp;

        // Установка текста для давления в другом потоке
        private delegate void PresSetter(string val);
        private PresSetter SetPres;

        // Установка текста для высоты в другом потоке
        private delegate void HeightSetter(string val);
        private HeightSetter SetHeight;

        // Установка текста для влажности в другом потоке
        private delegate void HumSetter(string val);
        private HumSetter SetHum;

        // Добавление значения к графику в другом потоке
        private delegate void MainChartSetter(double val);
        private MainChartSetter AddVal;

        /************/

        private const string Celsius = "°C";            // Постфикс для температуры в градусах
        private const string Percent = "%";             // Постфикс для влажности в процентах
        private const string mmOfMerc = "мм. рт. ст.";  // Постфикс для давления в мм. рт. ст
        private const string meter = "м.";              // Постфикс для высоты в метрах

        private bool IsShowTempChart = false;   // Показать график для температуры
        private bool IsShowPresChart = false;   // Показать график для давления
        private bool IsShowAltChart = false;    // Показать график для высоты
        private bool IsShowHumChart = false;    // Показать график для влажности

        private const int AllowedPoints = 20;   // Кол-во одновременно отрисованных точек на графике

        // Конструктор
        public ChartForm()
        {
            InitializeComponent();

            /* Объявление делегат */
            
            SetTemp = new TempSetter(SetNewTemperature);
            SetPres = new PresSetter(SetNewPressure);
            SetHeight = new HeightSetter(SetNewHeight);
            SetHum = new HumSetter(SetNewHumidity);
            AddVal = new MainChartSetter(AddNewValueToMainChart);

            /**********************/

            // Объявления пустого графика
            mainChart.Series.Add(new LineSeries
            {
                Values = new ChartValues<double> { 0.0 },
                ScalesYAt = 0
            });

            // Создание события приёма данных
            serialPortMain.DataReceived += SerialPortMain_DataReceived;
        }

        // Отключить отображение всех графиков и очистить график
        public void DisableAllCharts()
        {
            IsShowTempChart = false;
            IsShowPresChart = false;
            IsShowAltChart = false;
            IsShowHumChart = false;

            mainChart.Series[0].Values.Clear();
        }

        // Сеттер температуры 
        private void SetNewTemperature(string val)
        {
            tempState.Text = val + " " + Celsius;
        }

        // Сеттер влажности
        private void SetNewHumidity(string val)
        {
            humState.Text = val + " " + Percent;
        }

        // Сеттер давления
        private void SetNewPressure(string val)
        {
            presState.Text = val + " " + mmOfMerc;
        }

        // Сеттер высоты
        private void SetNewHeight(string val)
        {
            heightState.Text = val + " " + meter;
        }

        // Добавить новое значение на график 
        private void AddNewValueToMainChart(double val)
        {
            if (mainChart.Series[0].Values.Count == AllowedPoints)
            {
                mainChart.Series[0].Values.RemoveAt(0);
            }

            mainChart.Series[0].Values.Add(val);
        }

        // При загрузке формы
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

                Errors.ShowMessage(Errors.checkSettings);
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

        // При получении данных с МК
        private void SerialPortMain_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var data = serialPortMain.ReadLine();   // Данные
            data = Commands.DeleteSpecSymb(data);   // Очистка от спец. символов

            // 0 - Команда | 1 - значение
            string[] arr_data = data.Split(Commands.SPLITTER);

            // Если не информация
            if (arr_data.Length != 1)
            {
                string command = arr_data[0];   // Команда
                string value = arr_data[1];     // Значение
                
                if (command == Commands.BMP_E280.temperature)   // Если датчик температуры
                {
                    // Установить значение
                    tempState.Invoke(SetTemp, value);

                    // При возможности отрисовать график
                    if (IsShowTempChart)
                    {
                        mainChart.Invoke(AddVal, double.Parse(value, System.Globalization.CultureInfo.InvariantCulture));
                    }
                }
                else if (command == Commands.BMP_E280.pressure) // Если датчик давления
                {
                    // Установить значение
                    presState.Invoke(SetPres, value);

                    // При возможности отрисовать график
                    if (IsShowPresChart)
                    {
                        mainChart.Invoke(AddVal, double.Parse(value, System.Globalization.CultureInfo.InvariantCulture));
                    }
                }
                else if (command == Commands.BMP_E280.altitude) // Если датчик высоты
                {
                    // Установить значение
                    heightState.Invoke(SetHeight, value);

                    // При возможности отрисовать график
                    if (IsShowAltChart)
                    {
                        mainChart.Invoke(AddVal, double.Parse(value, System.Globalization.CultureInfo.InvariantCulture));
                    }
                }
                else if (command == Commands.BMP_E280.humidity) // Если датчик влажности
                {
                    // Установить значение
                    humState.Invoke(SetHum, value);

                    // При возможности отрисовать график
                    if (IsShowHumChart)
                    {
                        mainChart.Invoke(AddVal, double.Parse(value, System.Globalization.CultureInfo.InvariantCulture));
                    }
                }
            }
        }

        // При закрытии формы
        private void ChartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Если порт открыт
            if (serialPortMain.IsOpen)
            {
                serialPortMain.DataReceived += null;

                serialPortMain.WriteLine(Commands.Arduino.shutdown);    // Перевести систему в спящий режим
                serialPortMain.Close();                                 // Отключить порт
            }
        }

        // При нажатии на кнопку для отрисовки температуры
        private void showTempChart_Click(object sender, EventArgs e)
        {
            DisableAllCharts();
            IsShowTempChart = true;

            mainChart.AxisY[0].MinValue = -50.0;
            mainChart.AxisY[0].MaxValue = 150.0;
        }

        // При нажатии на кнопку для отрисовки влажности
        private void showHumChartBtn_Click(object sender, EventArgs e)
        {
            DisableAllCharts();
            IsShowHumChart = true;

            mainChart.AxisY[0].MinValue = 0.0;
            mainChart.AxisY[0].MaxValue = 100.0;
        }

        // При нажатии на кнопку для отрисовки давления
        private void showPresChartBtn_Click(object sender, EventArgs e)
        {
            DisableAllCharts();
            IsShowPresChart = true;

            mainChart.AxisY[0].MinValue = 0.0;
            mainChart.AxisY[0].MaxValue = 1000.0;
        }

        // При нажатии на кнопку для отрисовки высоты
        private void showAltChartBtn_Click(object sender, EventArgs e)
        {
            DisableAllCharts();
            IsShowAltChart = true;

            mainChart.AxisY[0].MinValue = -20.0;
            mainChart.AxisY[0].MaxValue = 1000.0;
        }
    }
}
