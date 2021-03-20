using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;

namespace StandApp
{
    public partial class setupForm : Form
    {
        public setupForm()
        {
            InitializeComponent();
        }

        private bool IsSuccessLoad;
        private const int AllowedLines = 14;

        private void AddLog(string log)
        {
            if (console.Lines.Length == AllowedLines)
            {
                console.Clear();
            }

            console.Text += ">" + log + "\n";
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
            }
            else 
            {
                AddLog("Порт с контроллером не был обнаружен. Повторная проверка...");
                LoadPorts();
            }
        }
    }
}
