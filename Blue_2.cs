using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _output;
        private string _lettercomb;
        public string Output { get { return _output; } }
        public Blue_2(string text, string lettercomb) : base(text)
        {
            _lettercomb = lettercomb;
            _output = null;
        }
        public override void Review()
        {
            string[] words = Input.Split(' ');
            string[] nwords = new string[0];
            char[] punc = { '.', ',', ';', '!', '?' };
            string preword = "";
            
            for (int w  = 0; w < words.Length; w++)
            {
                if (!words[w].ToLower().Contains(_lettercomb.ToLower()))
                {
                    string[] tempwords = new string[nwords.Length + 1];
                    for (int i = 0; i < nwords.Length; i++)
                    {
                        tempwords[i] = nwords[i];
                    }
                    tempwords[tempwords.Length-1] = words[w] ;
                    nwords = tempwords;
                }
                
                else
                {
                    if (w == 0) continue;
                    bool contzn = false;
                    foreach(char zn in punc)
                    {
                        if (words[w].Contains(zn)) contzn = true;
                    }
                    if (contzn)
                    {
                        if (char.IsPunctuation(words[w][words[w].Length - 1]) && char.IsPunctuation(words[w][0]))
                        {
                            if ((char.IsPunctuation(words[w][words[w].Length - 2]) && (words[w].Length>2)))
                            {
                                string[] tempwords = new string[nwords.Length + 1];
                                for (int i = 0; i < nwords.Length; i++)
                                {
                                    tempwords[i] = nwords[i];
                                }
                                tempwords[tempwords.Length - 1] = $"{(words[w][0])}" + $"{(words[w][words[w].Length - 2])}"+ $"{(words[w][words[w].Length - 1])}";
                                nwords = tempwords;
                            }
                            else 
                            {
                                string[] tempwords = new string[nwords.Length + 1];
                                for (int i = 0; i < nwords.Length; i++)
                                {
                                    tempwords[i] = nwords[i];
                                }
                                tempwords[tempwords.Length - 1] = $"{(words[w][0])}" + $"{(words[w][words[w].Length - 1])}";
                                nwords = tempwords;

                            }
                            
                        }
                        //else if (char.IsPunctuation(words[w][0]))$"{(words[w][0])}" +
                        //{
                        //    string[] tempwords = new string[nwords.Length + 1];
                        //    for (int i = 0; i < nwords.Length; i++)
                        //    {
                        //        tempwords[i] = nwords[i];
                        //    }
                        //    tempwords[tempwords.Length - 1] = $"{(words[w][0])}";
                        //    nwords = tempwords;
                        //}
                        else if (char.IsPunctuation(words[w][words[w].Length - 1]))
                        {
                            string pdops = $"{words[w][words[w].Length - 1]}";
                            nwords[nwords.Length - 1] = words[w - 1] + pdops;
                        }
                        
                        
                    }
                    
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
