using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models.Storages
{
    class Page
    {
        private string _content;
        public Page()
        {
            _content = "";
        }
        public string Text
        {
            get
            {
                return _content;
            }
        }
        public bool Write(string row, int maxCountCharacter)
        {
            if (_content.Length + row.Length <= maxCountCharacter)
            {
                _content += row;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
