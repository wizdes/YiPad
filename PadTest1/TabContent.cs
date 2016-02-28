using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PadTest1
{
    public class TabContent
    {
        private string _header;
        private readonly object _content;

        public TabContent(string header, object content)
        {
            _header = header;
            _content = content;
        }

        public string Header
        {
            get { return _header; }
            set { _header = value; }
        }

        public object Content
        {
            get { return _content; }
        }
    }
}
