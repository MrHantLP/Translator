using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{
    class Lexer
    {
        private String code; //чтоб из вне ничё не попортилось
        public Lexer(String out_code)
        {
            code = out_code;
            //**********
            //чистка кода тут
            //**********
        }
        public bool goAnalyze()
        {
            //*****
            //код со всякими созданиями файлов и т.д. и т.п
            //всё ок тру не ок фолс и можно почему
            //***
            return true;
        }
    }
}
