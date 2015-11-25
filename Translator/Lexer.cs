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
        public Lexer()
        {
            code = Code.AllCode;
            //**********
            //подгтовка делай что хошь
            //**********
        }
        public bool GoAnalyze()
        {
            //*****
            //код со всякими созданиями файлов и т.д. и т.п
            //все создания файлов и т.д делай тут и пути к ним в паблик статик в програм.кс прописывай
            //папку возьми из пути к файлу он уже есть в паблик статике Code.pasPath , аналогично сделай переменные с путями к своим кей вёрдам и т.д
            //Ошибку суй сюда Code.LexError
            //***
            return true;
        }
    }
}
