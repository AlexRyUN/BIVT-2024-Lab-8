using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    public class Blue_4 : Blue
    {
        private int _output;
        public int Output { get { return _output; } }
        public Blue_4(string text) : base(text)
        {
        }
        public override void Review()
        {
            if (String.IsNullOrEmpty(this.Input)) return;
            char[] punct = { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/', '\r', '\n' };
            string[] words = Input.Split(punct, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                bool digits = char.IsDigit(word[0]);
                if (digits)
                {
                    int res = 0;
                    foreach (char cifr in word)
                    {
                        if (!char.IsDigit(cifr)) break;
                        res *= 10;
                        res += ((int)cifr - 48);
                    }
                    _output += res;
                }
            }
        }
        public override string ToString()
        {
            string str = $"{_output}";
            return str;
        }
    }
}
