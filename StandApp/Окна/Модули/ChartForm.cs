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

        // Установка текста для напряжения в другом потоке
        private delegate void VoltageSetter(string val);
        private VoltageSetter SetVoltage;

        // Добавление значения к главному графику в другом потоке
        private delegate void MainChartSetter(double val);
        private MainChartSetter AddVal;

        // Добавление значения к графику весов в другом потоке
        private delegate void WeightChartSetter(double val);
        private WeightChartSetter AddWeightVal;

        /************/

        /* Настройки */
        
        private const string Celsius =  "°C";            // Постфикс для температуры в                     градусах
        private const string Percent =  "%";             // Постфикс для влажности в                       процентах
        private const string kpa =      "кПа";           // Постфикс для давления в                        килопаскалях
        private const string kgramm =   "кг";            // Постфикс для давления на тензодатчик в         килограммах
        private const string gramm =    "гр.";           // Постфикс для давления на тензодатчик в         граммах
        private const string ue =       "у. е.";         // Постфикс для ШИМ-сигнала для двигателя в       условных единицах
        private const string microsec = "мкс";           // Постфикс для ШИМ-сигнала для двигателя в       микросекундах
        private const string current =  "А";             // Постфикс для тока потребления двигателем в     амперах
        private const string voltage =  "В";              // Постфикс для падения напряжения на двигателе в вольтах

        private bool IsShowTempChart =     false;        // Показать график для температуры
        private bool IsShowPresChart =     false;        // Показать график для давления
        private bool IsShowHumChart =      false;        // Показать график для влажности
        private bool IsShowRealPresChart = false;        // Показать график для давления на тензодатчике
        private bool IsShowEngineChart =   false;        // Показать график для скорости оборотов
        private bool IsShowCurrentChart =  false;        // Показать график для потребелния тока
        private bool IsShowVoltageChart =  false;        // Показать график для падения напряжения

        private int AllowedPoints = 100;                 // Кол-во одновременно отрисованных точек на графике

        private int CurrentEngineWrite_Exp = 0;          // Текущий ШИМ-сигнал для эксперимента

        private bool IsExp = false;                      // Индикатор эксперимента

        private static string logPath = "log.txt";       // Имя файла с логом 
        private FileStream logFileStream =
        new FileStream(logPath, FileMode.OpenOrCreate);  // Поток работы с файлом

        private UInt32 exp_num = 1;                      // Номер эксперимента

        /*************/

        // Конструктор
        public ChartForm()
        {
            InitializeComponent();

            /* Объявление делегат */

            SetTemp = new TempSetter(SetNewTemperature);
            SetPres = new PresSetter(SetNewPressure);
            SetTenzo = new TenzoSetter(SetNewTenzoPressure);
            SetHum = new HumSetter(SetNewHumidity);
            SetVoltage = new VoltageSetter(SetNewVoltage);
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
            weightPresInd.Wedge = 180;
            weightPresInd.LabelsStep = weightPresInd.ToValue / 4;
            weightPresInd.TickStep = weightPresInd.ToValue / 20;

            /*********************************/

            // Обнуление скорости
            engineSpeedState.Text = "0 " + ue;

            /* Подсказки */
            {
                ToolTip temp_tt = new ToolTip();
                temp_tt.SetToolTip(showTempChartBtn,    "Температура");

                ToolTip hum_tt = new ToolTip();
                hum_tt.SetToolTip(showHumChartBtn,      "Влажность");

                ToolTip pres_tt = new ToolTip();
                pres_tt.SetToolTip(showPresChartBtn,    "Атмосферное давление");

                ToolTip realPres_tt = new ToolTip();
                realPres_tt.SetToolTip(showRealPresBtn, "Давление на тензодатчик");   
                
                ToolTip engine_tt = new ToolTip();
                engine_tt.SetToolTip(engineTrackBar,    "Скороcть вращения двигателя");   
                engine_tt.SetToolTip(showEngineChartBtn,"Скороcть вращения двигателя");   
                
                ToolTip current_tt = new ToolTip();
                current_tt.SetToolTip(showCurrentChart, "Ток потребления");    
                
                ToolTip voltage_tt = new ToolTip();
                voltage_tt.SetToolTip(showVoltageChart, "Падение напряжения");          
                
                ToolTip exp_tt = new ToolTip();
                exp_tt.SetToolTip(startExpOne,          "Начать эксперимент");
            }
            /*************/

            // Создание события приёма данных
            serialPortMain.DataReceived += SerialPortMain_DataReceived;

            // Установка заддержки отправки данных
            serialPortMain.WriteTimeout = 10;
        }

        // Добавить лог
        private void AddLog(string message)
        {            
            byte[] array = System.Text.Encoding.Default.GetBytes(message);
            logFileStream.Write(array, 0, array.Length);
        }

        // Отключить отображение всех графиков и очистить график
        private void DisableAllCharts()
        {
            IsShowTempChart = false;
            IsShowPresChart = false;
            IsShowHumChart = false;
            IsShowRealPresChart = false;
            IsShowEngineChart = false;
            IsShowCurrentChart = false;
            IsShowVoltageChart = false;

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

        // Сеттер давления на тензодатчик
        private void SetNewTenzoPressure(string val)
        {
            tenzoState.Text = val + " " + gramm;
        }

        // Сеттер падения напряжения
        private void SetNewVoltage(string val)
        {
            voltageState.Text = val + " " + voltage;
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
            weightPresInd.Value = val / 1000;
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
                        mainChart.Invoke(AddVal, double.Parse(value, System.Globalization.CultureInfo.InvariantCulture));
                    }
                }
                else if(command == Commands.Voltmeter.data) // Если вольтметр
                {
                    // Установить значение
                    voltageState.Invoke(SetVoltage, value);

                    // При возможности отрисовать график
                    if (IsShowVoltageChart)
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
                serialPortMain.WriteLine(Commands.Arduino.shutdown);    // Перевести систему в спящий режим
                serialPortMain.Close();                                 // Отключить порт
            }

            logFileStream.Close();  // Закрытие лог-файла
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

        // При нажатии на кнопку для отрисовки кол-ва оборотов двигателя
        private void showEngineChartBtn_Click(object sender, EventArgs e)
        {
            if(!IsShowEngineChart)
            {
                DisableAllCharts();
                IsShowEngineChart = true;

                showEngineChartBtn.IconChar = FontAwesome.Sharp.IconChar.Pause;
                
                PWM.ForeColor = System.Drawing.Color.Gainsboro;

                SetDataInterval(0.0, 10000.0);
                SetDataPostfix(ue);
            }
            else
            {
                IsShowEngineChart = false;

                showEngineChartBtn.IconChar = FontAwesome.Sharp.IconChar.Play;

                PWM.ForeColor = System.Drawing.Color.DarkOrange;
            }
        }

        // При нажатии на кнопку для отрисовки тока потребления
        private void showCurrentChart_Click(object sender, EventArgs e)
        {
            DisableAllCharts();
            IsShowCurrentChart = true;

            SetDataInterval(0.0, 120.0);
            SetDataPostfix(current);
        }

        // При нажатии на кнопку для отрисовки падения напряжения
        private void showVoltageChart_Click(object sender, EventArgs e)
        {
            DisableAllCharts();
            IsShowVoltageChart = true;

            SetDataInterval(0.0, 50.0);
            SetDataPostfix(voltage);
        }

        // При изменении ШИМ-сигнала на двигатель
        private void engineTrackBar_ValueChanged(object sender, EventArgs e)
        {
            engineSpeedState.Text = Convert.ToString(engineTrackBar.Value) + " " + ue;
            engineSpeedStateMcs.Text = Convert.ToString(Commands.Map(engineTrackBar.Value, 0, 1000, 544, 2400)) + " " + microsec;

            if (IsShowEngineChart)
            {
                serialPortMain.WriteLine(Commands.Engine.write + Commands.SPLITTER + Convert.ToString(engineTrackBar.Value));
                PWM.ForeColor = System.Drawing.Color.Gainsboro;
            }
        }

        // При нажатии на кнопку для включения анимации графика
        private void включитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainChart.DisableAnimations = false;
        }

        // При нажатии на кнопку для выключения анимации графика
        private void выключитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainChart.DisableAnimations = true;
        }

        // При нажатии на кнопку для старта эксперимента
        private void startExpOne_Click(object sender, EventArgs e)
        {
            if (!IsExp)
            {
                DisableAllCharts();

                MainTimer.Interval = Convert.ToInt32(intervalUE_Exp.Text);
                CurrentEngineWrite_Exp = Convert.ToInt32(startUE_Exp.Text);

                IsExp = true;

                startExpOne.BackColor = System.Drawing.Color.BlueViolet;
                startExpOne.IconChar = FontAwesome.Sharp.IconChar.PlaneDeparture;

                engineTrackBar.Enabled = false;

                PWM.ForeColor = System.Drawing.Color.Gainsboro;

                // Выключение двигателя
                serialPortMain.WriteLine(Commands.Engine.write + Commands.SPLITTER + 0);

                if (checkBoxLog.Checked)
                {
                    DateTime dateTime = DateTime.Now;

                    AddLog("Эксперимент: " + exp_num + "\n");
                    AddLog(dateTime.ToString("dd.MM.yyyy") + "\n" + dateTime.ToString("HH:mm:ss") + "\n");
                    AddLog("Начальный уровень ШИМ: " + Commands.Map(Convert.ToInt32(startUE_Exp.Text), 0, 1000, 544, 2400).ToString() + " " + microsec + "\n");
                    AddLog("Конечный уровень ШИМ: " + Commands.Map(Convert.ToInt32(endUE_Exp.Text), 0, 1000, 544, 2400).ToString() + " " + microsec + "\n");
                    AddLog("Шаг: " + Convert.ToInt32(stepUE_Exp.Text).ToString() + " " + ue + "\n");
                    AddLog("Интервал: " + Convert.ToInt32(intervalUE_Exp.Text).ToString() + " " + "мс" + "\n");

                    exp_num++;
                }

                // Запуск таймера
                 MainTimer.Start();         
            }
            else
            {
                // Остановка таймера
                MainTimer.Stop();

                // Выключение двигателя
                serialPortMain.WriteLine(Commands.Engine.write + Commands.SPLITTER + 0);

                IsExp = false;

                startExpOne.BackColor = System.Drawing.Color.DodgerBlue;
                startExpOne.IconChar = FontAwesome.Sharp.IconChar.Rocket;

                engineTrackBar.Enabled = true;
                engineTrackBar.Value = 0;

                PWM.ForeColor = System.Drawing.Color.DarkOrange;
            }
        }

        // Событие таймера при экспиременте
        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if(CurrentEngineWrite_Exp <= Convert.ToInt32(endUE_Exp.Text) && CurrentEngineWrite_Exp != Convert.ToInt32(endUE_Exp.Text))
            {                
                CurrentEngineWrite_Exp += Convert.ToInt32(stepUE_Exp.Text);

                engineTrackBar.Value = CurrentEngineWrite_Exp;

                serialPortMain.WriteLine(Commands.Engine.write + Commands.SPLITTER + CurrentEngineWrite_Exp.ToString());

                if (checkBoxLog.Checked)
                {
                    AddLog("ШИМ|" + CurrentEngineWrite_Exp.ToString() + "|");
                    AddLog("Тяга|" + tenzoState.Text + "|");
                    AddLog("Ток|" + currentState.Text + "|");
                    AddLog("Напр.|" + voltageState.Text + "\n");
                }
            }
            else
            {
                // Остановка таймера
                MainTimer.Stop();

                serialPortMain.WriteLine(Commands.Engine.write + Commands.SPLITTER + '0');

                IsExp = false;

                startExpOne.BackColor = System.Drawing.Color.DodgerBlue;
                startExpOne.IconChar = FontAwesome.Sharp.IconChar.Rocket;

                engineTrackBar.Enabled = true;
                engineTrackBar.Value = 0;
            }
        }

        // При нажатии на кнопку отключения всего
        private void stopAll_Click(object sender, EventArgs e)
        {
            DisableAllCharts();
            MainTimer.Stop();

            engineTrackBar.Value = 0;
        }
    }
}
