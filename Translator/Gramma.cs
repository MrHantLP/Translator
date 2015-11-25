using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{
    //Структура правила
    public class Pravilo
    {
        public String leftSide;
        public struct structRightSide
        {
            public String text, notTerminal, terminal;
            public structRightSide(String t, String n, String term)
            {
                text = t;
                notTerminal = n;
                terminal = term;
            }
        };
        public List<List<structRightSide>> rightSide;

    }
    //Граматика сделана на 55%
    class Gramma
    {
        public static List<Pravilo> p;
        public static void Init()
        {

        }
    }
}
