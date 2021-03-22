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
        public ChartForm()
        {
            InitializeComponent();
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

                ErrorStruct checkConnection = new ErrorStruct
                {
                    header = "Ошибка",
                    message = "Произошла ошибка во время загрузки настроек. Перейдите в" +
                    " раздел \"Подключение\" и проведите настройку."
                };

                Form messageBox = new CustomMessageBox(checkConnection);
                messageBox.ShowDialog();
            }

            if(IsFileExisting)
            {
                ConnectionData data = JsonConvert.DeserializeObject<ConnectionData>(rawData);

            }

        }
    }
}
