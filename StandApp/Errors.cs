using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace StandApp
{
    // Ошибки, предупреждения и оповещения
    public static class Errors
    {
        // Базовая структура сообщения
        public class ErrorStruct
        {
            public string header;
            public string message;
        }

        // Ошибка занятости порта
        public static ErrorStruct portIsBusy = new ErrorStruct
        {
            header = "Ошибка",
            message = "Порт занят! Закройте используемый монитор порта."
        };

        // Ошибка загрузки настроек
        public static ErrorStruct checkSettings = new ErrorStruct
        {
            header = "Ошибка",
            message = "Произошла ошибка во время загрузки настроек. Перейдите в" +
            " раздел \"Подключение\" и проведите настройку."
        };

        // Ошибка подключения порта
        public static ErrorStruct deletedPort = new ErrorStruct
        {
            header = "Ошибка",
            message = "COM-порт был отключён, проверьте подключение."
        };

        public static ErrorStruct succesSave = new ErrorStruct
        {
            header = "Сообщение",
            message = "Настройки успешно сохранены."
        };

        // Метод для вывода сообщения 
        public static void ShowMessage(ErrorStruct es)
        {
            Form messageBox = new CustomMessageBox(es);
            messageBox.ShowDialog();
        }
    }
}
