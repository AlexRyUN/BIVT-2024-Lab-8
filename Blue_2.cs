using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public class Blue_2 : Blue
    {
        private string _output;
        private string _lettercomb;
        public string Output { get { return _output; } }
        public string Lettercomb { get { return _lettercomb; } }
        public Blue_2(string text, string lettercomb) : base(text)
        {
            _lettercomb = lettercomb;
            _output = null;
        }
        public override void Review()
        {
            string[] words = Input.Split(' ');
            string[] nwords = new string[0];
            foreach (string word in words)
            {
                if (!(word.Contains(_lettercomb)))
                {
                    string[] tempwords = new string[nwords.Length + 1];
                    for (int i = 0; i < nwords.Length; i++)
                    {
                        tempwords[i] = nwords[i];
                    }
                    tempwords[tempwords.Length-1] = word;
                    nwords = tempwords;
                }
            }
            string stroka = string.Join(" ", nwords);
            _output = stroka;
        }
        public override string ToString()
        {
            return _output;
        }

    }
}
