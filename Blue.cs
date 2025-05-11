using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public abstract class Blue
    {
        private string _text;
        public string Input { get { return _text; } }

        public Blue(string st)
        {
            _text = st;
        }
        public abstract void Review();
    }
}
