using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class PaperStrogeStandarts
    {
        private readonly static Dictionary<string, KeyValuePair<Size, int>> _paperFormats =
            new Dictionary<string, KeyValuePair<Size, int>>
            {
                {"A_1", new KeyValuePair<Size, int>(new Size(841, 594 ),  88000) },
                {"A_2", new KeyValuePair<Size, int>(new Size(594, 420 ),  44000) },
                {"A_3", new KeyValuePair<Size, int>(new Size(420, 297 ),  22000) },
                {"A_4", new KeyValuePair<Size, int>(new Size(297, 210 ),  11000) },
                {"A_5", new KeyValuePair<Size, int>(new Size(210, 148 ),  5500) },
                {"A_6", new KeyValuePair<Size, int>(new Size(148, 105 ),  2750) }
            };
        public static Size getSize(string paperFormat)
        {
            if (_paperFormats.ContainsKey(paperFormat)) //проверяем существует ли ключ в значении
            {
                return _paperFormats[paperFormat].Key;
            }
            throw new ArgumentException("Некорректный формат листа");
        }
        public static KeyValuePair<Size, int> getPaperInfo(string paperFormat)
        {
            if (_paperFormats.ContainsKey(paperFormat)) //проверяем существует ли ключ в значении
            {
                return _paperFormats[paperFormat];
            }
            throw new ArgumentException("Некорректный формат листа");
        }
        public static int getMaxCountCharacters(string paperFormat)
        {
            if (_paperFormats.ContainsKey(paperFormat)) //проверяем существует ли ключ в значении
            {
                return _paperFormats[paperFormat].Value;
            }
            throw new ArgumentException("Некорректный формат листа");
        }

        /*public static Size getSize(string paperFormat) {

    foreach (KeyValuePair<string, Size> item in _paperFormats.Keys)
    {
        //item - один ключ
        if (item.Key.Equals(paperFormat))
        {
            return item.Value;
        }
    }
    throw new ArgumentException("Некорректный формат листа");
}*/
        /*new Dictionary<KeyValuePair<string, Size>, int> {
    {new KeyValuePair<string, Size>("A_1", new Size(841, 594 )), 88000 },
    {new KeyValuePair<string, Size>("A_2", new Size(594, 420 )), 44000 },
    {new KeyValuePair<string, Size>("A_3", new Size(420, 297 )), 22000 },
    {new KeyValuePair<string, Size>("A_4", new Size(297, 210 )), 11000 },
    {new KeyValuePair<string, Size>("A_5", new Size(210, 148 )), 5500 },
    {new KeyValuePair<string, Size>("A_6", new Size(148, 105 )), 2750 }
};*/
    }
}
