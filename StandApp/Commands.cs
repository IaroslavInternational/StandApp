using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace StandApp
{
    public static class Commands
    {
        public const char SPLITTER = '|';

        public struct BMP_E280
        {
            public const string temperature = "[BMP/E 280 temperature]";
            public const string pressure = "[BMP/E 280 pressure]";
            public const string altitude = "[BMP/E 280 altitude]";
            public const string humidity = "[BMP/E 280 humidity]";
        }

        public static string DeleteSpecSymb(string str)
        {
            return Regex.Replace(str, @"[\u0000-\u001F]", string.Empty);
        }
    }
}
