using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[] _output;
        public string[] Output 
        { 
            get 
            {
                string[] copyoutput = new string[_output.Length];
                for (int i = 0; i < _output.Length; i++)
                {
                    copyoutput[i] = _output[i];
                }
                return copyoutput; 
            } 
        }


        public Blue_1(string text) : base(text)
        {
            _output = null;
        }


        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = null;
                return;
            }
            
            string[] Chtext = Input.Split('');
            string[] result = new string[0];  
            string Naborstr = "";
            int i = 0;
            while (i < Chtext.Length)
            {
                string proba = string.Empty;
                if (Naborstr.Length > 0)
                {
                    proba = Naborstr + " " + Chtext[i];
                }
                else
                {
                    proba = Chtext[i];
                }
                if (proba.Length > 50)
                {
                    
                    string[] nresult = new string[result.Length + 1];
                    for (int j = 0; j < result.Length; j++)
                    {
                        nresult[j] = result[j];
                    }
                    nresult[nresult.Length - 1] = Naborstr;
                    result = nresult;
                    Naborstr = "";
                    i--;
                }
                else
                {
                    Naborstr = proba;   
                }
                i++;

            }
            if (Naborstr.Length > 0)
            {
                string[] nresult = new string[result.Length + 1];
                for (int j = 0; j < result.Length; j++)
                {
                    nresult[j] = result[j];
                }
                nresult[nresult.Length - 1] = Naborstr;
                result = nresult;
                Naborstr = "";
            }
            _output = result;
        }
        public override string ToString()
        {
            if (String.IsNullOrEmpty(this.Input) || _output == null) 
            { 
                return null; 
            }
            return string.Join(Environment.NewLine, _output);
        }
    }
}
