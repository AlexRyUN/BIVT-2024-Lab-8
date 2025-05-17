using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _output;
        public (char, double)[] Output 
        {  
            get 
            {
                if (_output == null)
                {
                    return null;
                }
                (char, double)[] copyoutput = new (char, double)[_output.Length];
                for (int i = 0; i < _output.Length; i++)
                {
                    copyoutput[i] = _output[i];
                }
                return copyoutput;
            
            } 
        }//ВОЗВРАЩАТЬ КОПИЮ

        public Blue_3(string text) : base(text)
        {
            _output = null;
        }
        public override void Review()
        {
            char[] punct = { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/', '\r', '\n' };
            string[] words = Input.Split(punct, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].ToLower(); 
            }
            (char, int)[] qwords = new (char, int)[0];
            char[] letters = new char[0];
            double numberwords = 0;
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == null || words[i].Length < 1) { continue; }
                char nletter = words[i][0];
                if (!(char.IsLetter(nletter)))
                {
                    continue;
                }
                else if (letters.Contains(nletter))
                {
                    for (int j = 0; j < qwords.Length; j++)
                    {
                        if(nletter == qwords[j].Item1)
                        {
                            qwords[j].Item2 += 1;
                            break;
                        }
                    }
                    numberwords++;
                }
                else
                {
                    char[] templetters = new char[letters.Length+1];
                    for (int j = 0; j < letters.Length; j++)
                    {
                        templetters[j] = letters[j];
                    }
                    templetters[templetters.Length-1] = nletter;
                    (char, int)[] nqwords = new (char, int)[qwords.Length+1];
                    for (int k = 0;k < qwords.Length; k++)
                    {
                        nqwords[k] = qwords[k];
                    }
                    nqwords[nqwords.Length - 1] = (nletter, 1);
                    qwords = nqwords;
                    letters = templetters;
                    numberwords++;
                }
            }
            // Сортировка 
            
            for (int i = 0; i < qwords.Length; i++)
            {
                bool swopped = false;
                for (int j = 0; j < qwords.Length-i-1; j++)
                {
                    if ((qwords[j].Item2 < qwords[j+1].Item2) || ((qwords[j].Item2 == qwords[j + 1].Item2)&& (qwords[j].Item1 > qwords[j+1].Item1)))
                    {
                        (char, int)tempqw = qwords[j];
                        qwords[j] = qwords[j + 1];
                        qwords[j+1] = tempqw;
                        swopped = true;
                    }
                }
                if (!swopped) break;
            }
            //Cоздание нужного по заданию массива кортежей
            _output = new (char, double)[qwords.Length];
            for (int i = 0; i < qwords.Length; i++)
            {
                _output[i].Item1 = qwords[i].Item1;
                _output[i].Item2 = (qwords[i].Item2*100) / numberwords;
                
            }
        }
        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
                return null;
            string[] mstr = new string[_output.Length];
            for (int i = 0; i < _output.Length; i++)
            {
                mstr[i] = $"{_output[i].Item1} - {_output[i].Item2:F4}";
            }
            string rstr = string.Join(Environment.NewLine, mstr);
            return rstr;
        }
    }
}
