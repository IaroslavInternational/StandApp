/*
 * Работает в паре с файлом MCCode/Headers/commands.h
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace StandApp
{
    // Команды
    public static class Commands
    {
        // Разделитель данных
        public const char SPLITTER = '|';

        // Команды от
        // датчика давления, температуры, влажности и высоты
        public struct BMP_E280
        {
            public const string temperature = "[BMP/E 280 temperature]";    // Температура
            public const string pressure = "[BMP/E 280 pressure]";          // Давление
            public const string altitude = "[BMP/E 280 altitude]";          // Высота
            public const string humidity = "[BMP/E 280 humidity]";          // Влажность
        }

        // Команды для Ардуино
        public struct Arduino
        {
            public const string shutdown = "[Reset]";                   // Спящий режим
            public const string testConnection = "[Test connection]";   // Проверка соединения
        }

        // Полученные команды
        public struct Response
        {
            public const string goodConnection = "[Connection succeded]";   // Успешное подключение
        }

        // Метод для удаления специальных символов
        public static string DeleteSpecSymb(string str)
        {
            return Regex.Replace(str, @"[\u0000-\u001F]", string.Empty);
        }
    }
}
