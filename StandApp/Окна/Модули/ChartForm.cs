using LiveCharts;
using LiveCharts.Wpf;
using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;

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

        // Установка текста для влажности в другом потоке
        private delegate void HumSetter(string val);
        private HumSetter SetHum;

        // Установка текста для давления на тензодатчик в другом потоке
        private delegate void TenzoSetter(string val);
        private TenzoSetter SetTenzo;

        // Добавление значения к главному графику в другом потоке
        private delegate void MainChartSetter(double val);
        private MainChartSetter AddVal;

        // Добавление значения к графику весов в другом потоке
        private delegate void WeightChartSetter(double val);
        private WeightChartSetter AddWeightVal;

        /************/

        private const string Celsius = "°C";            // Постфикс для температуры в градусах
        private const string Percent = "%";             // Постфикс для влажности в процентах
        private const string kpa = "кПа";               // Постфикс для давления в кПа
        private const string kgramm = "кг.";            // Постфикс для давления на тензодатчик в килограммах
        private const string microsec = "мк. с.";       // Постфикс для давления на тензодатчик в килограммах

        private bool IsShowTempChart = false;        // Показать график для температуры
        private bool IsShowPresChart = false;        // Показать график для давления
        private bool IsShowHumChart = false;         // Показать график для влажности
        private bool IsShowRealPresChart = false;    // Показать график для давления на тензодатчике
        private bool IsShowEngineChart = false;      // Показать график для скорости оборотов

        private int AllowedPoints = 100;   // Кол-во одновременно отрисованных точек на графике

        // Конструктор
        public ChartForm()
        {
            InitializeComponent();

            /* Объявление делегат */

            SetTemp = new TempSetter(SetNewTemperature);
            SetPres = new PresSetter(SetNewPressure);
            SetTenzo = new TenzoSetter(SetNewTenzoPressure);
            SetHum = new HumSetter(SetNewHumidity);
            AddVal = new MainChartSetter(AddNewValueToMainChart);
            AddWeightVal = new WeightChartSetter(AddNewValueToWeightChart);

            /**********************/

            /* Настройки главного графика */

            // Объявления пустого графика
            mainChart.Series.Add(new LineSeries
            {
                Values = new ChartValues<double> { 0.0 },
                ScalesYAt = 0,
                StrokeThickness = 1
            });

            mainChart.Zoom = ZoomingOptions.X;

            /******************************/

            /* Настройки весового индикатора */
           
            weightPresInd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            weightPresInd.Font = new System.Drawing.Font("Microsoft YaHei UI Light", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            weightPresInd.ForeColor = System.Drawing.Color.Gainsboro;
            weightPresInd.Name = "weightPresInd";
            weightPresInd.TabIndex = 11;
            weightPresInd.Text = "Весы";
            weightPresInd.ToValue = 20;
            weightPresInd.LabelsStep = weightPresInd.ToValue / 10;
            weightPresInd.TickStep = weightPresInd.ToValue / 20;

            /*********************************/

            // Обнуление скорости
            engineSpeedState.Text = "0";

            /* Подсказки */
            {
                ToolTip temp_tt = new ToolTip();
                temp_tt.SetToolTip(showTempChartBtn, "Температура");

                ToolTip hum_tt = new ToolTip();
                hum_tt.SetToolTip(showHumChartBtn, "Влажность");

                ToolTip pres_tt = new ToolTip();
                pres_tt.SetToolTip(showPresChartBtn, "Атмосферное давление");

                ToolTip realPres_tt = new ToolTip();
                realPres_tt.SetToolTip(showRealPresBtn, "Давление на тензодатчик");   
                
                ToolTip engine_tt = new ToolTip();
                engine_tt.SetToolTip(engineTrackBar, "Скороcть вращения двигателя");
            }
            /*************/

            // Создание события приёма данных
            serialPortMain.DataReceived += SerialPortMain_DataReceived;
        }

        // Отключить отображение всех графиков и очистить график
        private void DisableAllCharts()
        {
            IsShowTempChart = false;
            IsShowPresChart = false;
            IsShowHumChart = false;
            IsShowRealPresChart = false;

            mainChart.Series[0].Values.Clear();
        }

        // Установить единицы измерения для главного графика
        private void SetDataPostfix(string pf)
        {
            mainChart.Series[0].LabelPoint = point => point.Y + " " + pf;
        }

        // Установить дипазон значение для главного графика   
        private void SetDataInterval(double lb, double ub)
        {
            mainChart.AxisY[0].MinValue = lb;
            mainChart.AxisY[0].MaxValue = ub;
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
            presState.Text = val + " " + kpa;
        }

        private void SetNewTenzoPressure(string val)
        {
            tenzoState.Text = val + " " + kgramm;
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

        // Установить новое значение на весах
        private void AddNewValueToWeightChart(double val)
        {
            weightPresInd.Value = val;
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
                catch (IOException ex)
                {
                    Errors.ShowMessage(Errors.deletedPort);
                }
            }
        }

        // При получении данных с МК
        private void SerialPortMain_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (!serialPortMain.IsOpen)
                return;

            var data = serialPortMain.ReadLine();   // Данные
            data = Commands.DeleteSpecSymb(data);   // Очистка от спец. символов

            // 0 - Команда | 1 - значение
            string[] arr_data = data.Split(Commands.SPLITTER);

            // Если не информация
            if (arr_data.Length != 1)
            {
                string command = arr_data[0];   // Команда
                string value = arr_data[1];     // Значение

                if (command == Commands.BMP_E280.temperature)     // Если датчик температуры
                {
                    // Установить значение
                    tempState.Invoke(SetTemp, value);

                    // При возможности отрисовать график
                    if (IsShowTempChart)
                    {
                        mainChart.Invoke(AddVal, double.Parse(value, System.Globalization.CultureInfo.InvariantCulture));
                    }
                }
                else if (command == Commands.BMP_E280.pressure)   // Если датчик давления
                {
                    // Установить значение
                    presState.Invoke(SetPres, value);

                    // При возможности отрисовать график
                    if (IsShowPresChart)
                    {
                        mainChart.Invoke(AddVal, double.Parse(value, System.Globalization.CultureInfo.InvariantCulture));
                    }
                }
                else if (command == Commands.BMP_E280.humidity)   // Если датчик влажности
                {
                    // Установить значение
                    humState.Invoke(SetHum, value);

                    // При возможности отрисовать график
                    if (IsShowHumChart)
                    {
                        mainChart.Invoke(AddVal, double.Parse(value, System.Globalization.CultureInfo.InvariantCulture));
                    }
                }
                else if (command == Commands.HX711.realPressure) // Если тензодатчик
                {
                    // Установить значение
                    tenzoState.Invoke(SetTenzo, value);

                    weightPresInd.Invoke(AddWeightVal, double.Parse(value, System.Globalization.CultureInfo.InvariantCulture));
                    
                    // При возможности отрисовать график
                    if (IsShowRealPresChart)
                    {
                        //mainChart.Invoke(AddVal, double.Parse(value, System.Globalization.CultureInfo.InvariantCulture));
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
                serialPortMain.WriteLine(Commands.Arduino.shutdown);    // Перевести систему в спящий режим
                serialPortMain.Close();                                 // Отключить порт
            }
        }

        // При нажатии на кнопку для отрисовки температуры
        private void showTempChart_Click(object sender, EventArgs e)
        {
            DisableAllCharts();
            IsShowTempChart = true;

            SetDataInterval(-50.0, 150.0);
            SetDataPostfix(Celsius);
        }

        // При нажатии на кнопку для отрисовки влажности
        private void showHumChartBtn_Click(object sender, EventArgs e)
        {
            DisableAllCharts();
            IsShowHumChart = true;

            SetDataInterval(0.0, 100.0);
            SetDataPostfix(Percent);
        }

        // При нажатии на кнопку для отрисовки давления
        private void showPresChartBtn_Click(object sender, EventArgs e)
        {
            DisableAllCharts();
            IsShowPresChart = true;

            SetDataInterval(0.0, 133.5);
            SetDataPostfix(kpa);
        }

        // При нажатии на кнопку для отрисовки давления на тензодатчик
        private void showRealPresBtn_Click(object sender, EventArgs e)
        {
            DisableAllCharts();
            IsShowRealPresChart = true;

            SetDataInterval(0.0, 20.0);
            SetDataPostfix(kgramm);
        }

        private void включитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainChart.DisableAnimations = false;
        }

        private void выключитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainChart.DisableAnimations = true;
        }

        private void showEngineChartBtn_Click(object sender, EventArgs e)
        {
            DisableAllCharts();

            IsShowEngineChart = true;
            IsShowRealPresChart = true;
        }

        private void engineTrackBar_Scroll(object sender, EventArgs e)
        {
            if(IsShowEngineChart)
            {
                serialPortMain.WriteLine(Commands.Engine.write + Commands.SPLITTER + Convert.ToString(engineTrackBar.Value));
                engineSpeedState.Text = Convert.ToString(engineTrackBar.Value) + " " + microsec;
            }
        }
    }
}
