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
    struct ConnectionData
    {
        public string PortName;
        public int BaudRate;
    }

    public partial class setupForm : Form
    {
        public delegate void AddThreadLog(string log);
        public AddThreadLog AddLogTh;

        public delegate void SetThreadChecked(bool IsCheck);
        public SetThreadChecked SetCheckedTh;

        public delegate void SaveThreadSettings();
        public SaveThreadSettings SaveSettingsTh;

        private bool IsSuccessLoad;
        private const int AllowedLines = 17;

        private ConnectionData data = new ConnectionData();

        public setupForm()
        {
            InitializeComponent();

            AddLogTh = new AddThreadLog(AddLog);
            SetCheckedTh = new SetThreadChecked(SetChekedValue);
            SaveSettingsTh = new SaveThreadSettings(SaveConnectionSettings);
        }

        private void AddLog(string log)
        {
            if (console.Lines.Length == AllowedLines)
            {
                console.Clear();
                console.Text += "\n";
            }

            console.Text += " > " + log + "\n";
        }
        
        private void SetChekedValue(bool IsCheck)
        {
            checkBoxConnection.Checked = IsCheck;
        }

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

        private void setupForm_Load(object sender, EventArgs e)
        {
            AddLog("Настройка...");

            LoadPorts();
            LoadRates();
        }

        private void testCnct_Click(object sender, EventArgs e)
        {
            if (IsSuccessLoad)
            {
                AddLog("Подключение к порту " + comList.SelectedItem + "...");

                serialTestPort.PortName = (string)comList.SelectedItem;
                serialTestPort.BaudRate = (int)baudRateList.SelectedItem;

                comPortSelected.Text = (string)comList.SelectedItem;
                baudRateSelected.Text = Convert.ToString(baudRateList.SelectedItem);

                serialTestPort.DataReceived += SerialTestPort_DataReceived;

                if (!serialTestPort.IsOpen)
                {
                    serialTestPort.Open();

                    AddLog("Порт " + serialTestPort.PortName + " открыт");

                    data.PortName = (string)comList.SelectedItem;
                    data.BaudRate = Convert.ToInt32(baudRateList.SelectedItem);

                    serialTestPort.WriteLine("[Test connection]");
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

        private void SerialTestPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var read = serialTestPort.ReadLine();
            var log = "Ответ от контроллера:" + read;

            read = Regex.Replace(read, @"[\u0000-\u001F]", string.Empty);

            if (read != "")
            {
                if (read == "[Connection succeeded]")
                {
                    checkBoxConnection.Invoke(SetCheckedTh, true);
                    SaveSettingsTh();
                }

                console.Invoke(AddLogTh, log);
            }
        }

        private void comList_SelectedValueChanged(object sender, EventArgs e)
        {
            comPortSelected.Text = (string)comList.SelectedItem;
        }

        private void baudRateList_SelectedValueChanged(object sender, EventArgs e)
        {
            baudRateSelected.Text = Convert.ToString(baudRateList.SelectedItem);
        }
    }
}
