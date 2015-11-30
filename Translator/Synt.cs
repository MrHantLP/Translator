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
            int line = 1, column = -1;
            for (int i = 0; i < code.Length; i++, column++)
            {
                if (code[i] == '\n')
                {
                    line++;
                    column = -1;
                }

                if (code[i] == '\'')
                {
                    int j = 1;
                    try
                    {
                        while (code[i + (j++)] != '\'') ;
                        code = code.Remove(++i, j - 2);
                    }
                    catch (Exception e)
                    {
                        Code.SyntError = "В строке " + line + " столбце " + column + " ожидалось \' (апостраф, символ конца строки)";
                        return;
                    }

                }
            }

            code = code.Replace("\r\n", " ");
            code = code.Replace(";", " ; ");
            code = code.Replace("..", " .. ");
            while (code.IndexOf("  ") != -1)
                code = code.Replace("  ", " ");

        }

        //Синтаксический анализ кода
        public bool GoAnalyze()
        {
            if (Code.SyntError != "none") return false;

            Gramma.Init();
#if DEBUG
            Gramma.Check();
#endif




            return true;
        }
        private String code;
    }
}
