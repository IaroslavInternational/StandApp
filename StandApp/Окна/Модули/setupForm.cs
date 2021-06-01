using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using Newtonsoft.Json;

namespace StandApp
{
    // Данные для подключения к COM-порту и настройки
    struct ConnectionData
    {
        public string PortName;
        public int    BaudRate;
        public int    Timeout;
        public double TenzoCalFactor1;
        public double TenzoCalFactor2;      
        public double CurrentCalFactor1;
        public double CurrentCalFactor2;
        public double VoltageCalFactor;
        public string LogSplitter;
        public int    WorkInterval_low;
        public int    WorkInterval_high;
        public bool   IsChartAnimationActive;
        public int    WeightChartMax;
        public double Shoulder;
        public string prop;
        public string engine;
        public string esc;
    }

    // Форма настроек и тестирования подключения
    public partial class SetupForm : Form
    {
        /* Делегаты */
        
        // Добавление лога в другом потоке
        private delegate void AddThreadLog(string log);
        private AddThreadLog AddLogTh;

        // Установка галочки в другом потоке
        private delegate void SetThreadChecked(bool IsCheck);
        private SetThreadChecked SetCheckedTh;

        // Сохранение настроек в другом потоке
        private delegate void SaveThreadSettings();
        private SaveThreadSettings SaveSettingsTh;

        /************/
        
        private bool IsSuccessLoad;             // Если порты добавлены
        private const int AllowedLines = 19;    // Максимум строк в логе

        private string sPortName;
        private int sBaudRate;
        private int sTimeout;
        private double sTenzoCalFactor1;
        private double sTenzoCalFactor2;    
        private double sCurrentCalFactor1;
        private double sCurrentCalFactor2;
        private double sVoltageCalFactor;
        private string sLogSplitter;
        private int sWorkInterval_low;
        private int sWorkInterval_high;
        private bool sIsChartAnimationActive;
        private int sWeightChartMax;
        private double sShoulder;
        public string sprop;
        public string sengine;
        public string sesc;

        // Экземпляр данных
        private ConnectionData data = new ConnectionData();

        // Конструктор
        public SetupForm()
        {
            InitializeComponent();            

            /* Объявление делегат */
            
            AddLogTh = new AddThreadLog(AddLog);
            SetCheckedTh = new SetThreadChecked(SetChekedValue);
            SaveSettingsTh = new SaveThreadSettings(SaveConnectionSettings);

            /**********************/

            // Создание события приёма данных
            serialTestPort.DataReceived += SerialTestPort_DataReceived;

            // Установка заддержки отправки данных
            serialTestPort.WriteTimeout = 10;
        }

        // Добавить лог
        private void AddLog(string log)
        {
            if (console.Lines.Length == AllowedLines)
            {
                console.Clear();
                console.Text += "\n";
            }

            console.Text += " > " + log + "\n";
        }
        
        // Установка галочки, при сохранении настроек 
        private void SetChekedValue(bool IsCheck)
        {
            checkBoxConnection.Checked = IsCheck;
        }

        // Загрузка списка портов
        private void LoadPorts()
        {
            try
            {
                AddLog("Проверка портов...");

                string[] ports = SerialPort.GetPortNames();
                comList.Items.AddRange(ports);

                if (ports.Length == 0)
                {
                    AddLog("Порт с контроллером не обнаружен");
                    IsSuccessLoad = false;
                }
                else
                {
                    comList.SelectedItem = comList.Items[0];

                    AddLog("Добавлены порты");
                    IsSuccessLoad = true;
                }
            }
            catch (Win32Exception ex)
            {
                AddLog(ex.ToString());
            }
        }

        // Загрузка списка возможных скоростей
        private void LoadRates()
        {
            AddLog("Добавление списка доступных скоростей...");

            baudRateList.Items.Add(300);
            baudRateList.Items.Add(1200);

            for (int i = 1200; i < 38400; i += i)
            {
                baudRateList.Items.Add(i * 2);
            }

            baudRateList.Items.Add(57600);
            
            for (int i = 57600; i < 230400; i += i)
            {
                baudRateList.Items.Add(i * 2);
            }

            baudRateList.Items.Add(250000);

            for (int i = 250000; i < 2000000; i += i)
            {
                baudRateList.Items.Add(i * 2);
            }

            baudRateList.SelectedItem = 9600;

            AddLog("Добавлен список скоростей");
        }

        // Сохранение настроек
        private void SaveConnectionSettings()
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
                ConnectionData data1 = JsonConvert.DeserializeObject<ConnectionData>(rawData);

                sPortName = data1.PortName;
                sBaudRate = data1.BaudRate;
                sTimeout = data1.Timeout;
                sTenzoCalFactor1 = data1.TenzoCalFactor1;
                sTenzoCalFactor2 = data1.TenzoCalFactor2;  
                sCurrentCalFactor1 = data1.CurrentCalFactor1;
                sCurrentCalFactor2 = data1.CurrentCalFactor2;
                sVoltageCalFactor = data1.VoltageCalFactor;
                sLogSplitter = data1.LogSplitter;
                sWorkInterval_low = data1.WorkInterval_low;
                sWorkInterval_high = data1.WorkInterval_high;
                sIsChartAnimationActive = data1.IsChartAnimationActive;
                sWeightChartMax = data1.WeightChartMax;
                sShoulder = data1.Shoulder;
                sprop = data1.prop;
                sengine = data1.engine;
                sesc = data1.esc;
            }

            data.Timeout = sTimeout;
            data.TenzoCalFactor1 = sTenzoCalFactor1;      
            data.TenzoCalFactor2 = sTenzoCalFactor2;   
            data.CurrentCalFactor1 = sCurrentCalFactor1;      
            data.CurrentCalFactor2 = sCurrentCalFactor2;
            data.VoltageCalFactor = sVoltageCalFactor;
            data.LogSplitter = sLogSplitter;
            data.WorkInterval_low = sWorkInterval_low;
            data.WorkInterval_high = sWorkInterval_high;
            data.IsChartAnimationActive = sIsChartAnimationActive;
            data.WeightChartMax = sWeightChartMax;
            data.Shoulder = sShoulder;
            data.prop = sprop;
            data.engine = sengine;
            data.esc = sesc;

            string json = JsonConvert.SerializeObject(data);

            // запись в файл
            using (FileStream fstream = new FileStream("connection settings.json", FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(json);               
                fstream.Write(array, 0, array.Length);
                
                console.Invoke(AddLogTh, "Настройки сохранены");
            }
        }

        // При загрузке формы
        private void setupForm_Load(object sender, EventArgs e)
        {
            AddLog("Настройка...");

            LoadPorts();
            LoadRates();
        }

        // Проверить подключение
        private void testCnct_Click(object sender, EventArgs e)
        {
            // Если загружен список портов
            if (IsSuccessLoad)
            {
                AddLog("Подключение к порту " + comList.SelectedItem + "...");

                // Инициализация порта
                serialTestPort.PortName = (string)comList.SelectedItem;
                serialTestPort.BaudRate = (int)baudRateList.SelectedItem;

                // Проверочный вывод
                comPortSelected.Text = (string)comList.SelectedItem;
                baudRateSelected.Text = Convert.ToString(baudRateList.SelectedItem);

                // Если порт не открыт
                if (!serialTestPort.IsOpen)
                {
                    // Открыть порт
                    serialTestPort.Open();

                    AddLog("Порт " + serialTestPort.PortName + " открыт");

                    // Сохранение данных
                    data.PortName = (string)comList.SelectedItem;
                    data.BaudRate = Convert.ToInt32(baudRateList.SelectedItem);

                    // Запрос к МК
                    serialTestPort.WriteLine(Commands.Arduino.testConnection);
                }
                else
                {
                    AddLog("Порт " + serialTestPort.PortName + " не доступен");
                }
            }
            else
            {
                AddLog("Порт с контроллером не был обнаружен. Повторная проверка...");
                LoadPorts();
            }
        }

        // При получении данных с МК
        private void SerialTestPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var read = serialTestPort.ReadLine();
            var log = "Ответ от контроллера:" + read;

            // Очистка от спец. символов
            read = Commands.DeleteSpecSymb(read);

            if (read != "")
            {
                // Если соединение установлено
                if (read == Commands.Response.goodConnection)
                {
                    // Поставить галочку
                    checkBoxConnection.Invoke(SetCheckedTh, true);
                    
                    // Сохранить настройки
                    SaveSettingsTh();
                }

                // Лог
                console.Invoke(AddLogTh, log);
            }
        }

        // При изменении списка портов
        private void comList_SelectedValueChanged(object sender, EventArgs e)
        {
            comPortSelected.Text = (string)comList.SelectedItem;
        }

        // При изменении списка достпных скоростей
        private void baudRateList_SelectedValueChanged(object sender, EventArgs e)
        {
            baudRateSelected.Text = Convert.ToString(baudRateList.SelectedItem);
        }

        // Отслежевание клика по chek box, чтобы не дать поставить галочку
        private void checkBoxConnection_Click(object sender, EventArgs e)
        {
            if (sender is CheckBox)
            {
                ((CheckBox)sender).Checked = !((CheckBox)sender).Checked;
            }
        }

        // При закрытии формы
        private void setupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AddLog("Закрытие порта");

            if (serialTestPort.IsOpen)
            {
                serialTestPort.Close();
            }
        }
    }
}
