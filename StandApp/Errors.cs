using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace StandApp
{
    public static class Errors
    {
        public class ErrorStruct
        {
            public string header;
            public string message;
        }

        public static ErrorStruct portIsBusy = new ErrorStruct
        {
            header = "Ошибка",
            message = "Порт занят! Закройте используемый монитор порта."
        };

        public static ErrorStruct checkConnection = new ErrorStruct
        {
            header = "Ошибка",
            message = "Произошла ошибка во время загрузки настроек. Перейдите в" +
            " раздел \"Подключение\" и проведите настройку."
        };

        public static ErrorStruct deletedPort = new ErrorStruct
        {
            header = "Ошибка",
            message = "COM-порт был отключён, проверьте подключение."
        };

        public static void ShowMessage(ErrorStruct es)
        {
            Form messageBox = new CustomMessageBox(es);
            messageBox.ShowDialog();
        }
    }
}
