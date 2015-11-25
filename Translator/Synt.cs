using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{
    class Synt
    {
        //Обработка текста для нужд синтаксического анализатора
        public Synt()
        {
            Code.SyntError = "none";
            code = Code.AllCode;     
        }

        //Синтаксический анализ кода
        public bool GoAnalyze()
        {
            if (Code.SyntError != "none") return false;

           
            return true;
        }
        private String code;
    }
}
