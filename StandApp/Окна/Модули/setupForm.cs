using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;
using System.IO;
using System.IO.Ports;
using Newtonsoft.Json;

namespace StandApp
{
    // Данные для подключения к COM-порту
    struct ConnectionData
    {
        public string PortName;
        public int BaudRate;
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

            AddLog("Добавлен список скоростей");
        }

        // Сохранение настроек
        private void SaveConnectionSettings()
        {
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
