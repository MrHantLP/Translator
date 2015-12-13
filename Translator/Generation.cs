using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{
    class Generation
    {

        String sharpCode = "", specEndings = "";
        int deepCount=0;
        String deep = "      ";

        public Generation()
        {
        }
        public bool GoGenerate()
        {
            StreamWriter csCode;
            try
            {
                csCode = new StreamWriter(Path.GetFullPath(Code.PasPath).Replace(".pas", ".cs"), false, Encoding.ASCII);
            }
            catch (Exception e)
            {
                Code.GenerationError = "Ошибка при создании файла: " + e.Message;
                return false;
            }
            sharpCode = "using System;\nclass ";
            sharpCode += Code.Tokens[1].value + "\n{\n" + "   static void Main()\n   {\n"; //Встпуление закончено дальше идёт сама программа
            specEndings += "   }\n}";

            //Обьявляем переменные первая начинается с Code.Tokens[4]
            for (int index = 1; index < Semantics.ids.Count; index++)
            {
                String type;
                switch (Semantics.ids[index].type)
                {
                    case "boolean":
                        type = "bool";
                        break;
                    case "real":
                        type = "double";
                        break;
                    case "integer":
                        type = "int";
                        break;
                    case "string":
                        type = "string";
                        break;
                    default:
                        Code.GenerationError = "Замечен недопустимый тип переменной";
                        return false;
                }
                if (!Semantics.ids[index].array)
                {
                    sharpCode += deep + type + " " + Semantics.ids[index].key + ";\n";

                }
                else
                {
                    String arrayBegining, arrayEnding;
                    //int indexCountOFEleemnts = Code.Tokens.IndexOf(Code.Tokens.Find(x => x.value == "," || x.value == "]"),Code.Tokens.IndexOf(Code.Tokens.Find(x=>x.value==Semantics.ids[index].key&&x.klass=="идентификатор")))-1;
                    int indexCountOFEleemnts = Code.Tokens.FindIndex(Code.Tokens.IndexOf(Code.Tokens.Find(x=>x.value==Semantics.ids[index].key&&x.klass=="идентификатор")),x => x.value == "," || x.value == "]")-1;
                    Int32 aCount= Int32.Parse(Code.Tokens[indexCountOFEleemnts].value)+1;//в этой строчке берём верзнюю границу массива и увеличивая её на 1 получаем количество элементов  вмассиве
                    arrayBegining = deep + type + "[]";
                    arrayEnding = " = new " + type + "[" + aCount.ToString() + "]";
                    indexCountOFEleemnts++;//проверим сколько размерностей у массива
                    while (Code.Tokens[indexCountOFEleemnts].value == ",")
                    {
                        arrayBegining += "[]";
                        indexCountOFEleemnts = Code.Tokens.FindIndex(indexCountOFEleemnts + 1, x => x.value == "," || x.value == "]") - 1;
                        aCount = Int32.Parse(Code.Tokens[indexCountOFEleemnts].value) + 1;
                        arrayEnding += "[" + aCount.ToString() + "]";
                        indexCountOFEleemnts++;
                    }
                    sharpCode += arrayBegining + Semantics.ids[index].key + arrayEnding + ";\n";
                }
            }


            //Основная часть программы
            int indexT = Code.Tokens.FindIndex(x=>x.value=="begin")+1;//index Токена



            while (indexT < Code.Tokens.Count-2)
            {
                switch (Code.Tokens[indexT].value)
                {
                    case "begin":
                        sharpCode += deep + "{\n";
                        deep += "      ";
                        indexT++;
                        break;
                    case "end":
                        sharpCode += deep + "}\n";
                        deep = deep.Remove(0, 6);
                        indexT++;
                        break;
                    case "read":
                        {
                            indexT++;
                            String tmp = " = Console.Read();\n";
                            while (Code.Tokens[++indexT].value != ")")
                            {
                                if (Code.Tokens[indexT].value != ",")
                                    sharpCode += deep + Code.Tokens[indexT].value + tmp;
                            }
                            indexT += 2;//пропускаем ;
                        }
                        break;
                    case "readln":
                        {
                            indexT++;
                            String tmp = " = Console.ReadLine();\n";
                            while (Code.Tokens[++indexT].value != ")")
                            {
                                if (Code.Tokens[indexT].value != ",")
                                    sharpCode += deep + Code.Tokens[indexT].value + tmp;
                            }
                            indexT += 2;//пропускаем ;
                        }
                        break;
                    case "write":
                        {
                            indexT++;
                            sharpCode += deep + "Console.Write(";
                            while (Code.Tokens[++indexT].value != ")")
                            {
                                if (Code.Tokens[indexT].value == ",")
                                    sharpCode += "+";
                                else
                                    sharpCode += Code.Tokens[indexT].value.Replace("'", "\"");
                            }
                            sharpCode += ");\n";
                            indexT += 2;
                        }
                        break;
                    case "writeln":
                        {
                            indexT++;
                            sharpCode += deep + "Console.WriteLine(";
                            while (Code.Tokens[++indexT].value != ")")
                            {
                                if (Code.Tokens[indexT].value == ",")
                                    sharpCode += "+";
                                else
                                    sharpCode += Code.Tokens[indexT].value.Replace("'", "\"");
                            }           
                            sharpCode += ");\n";
                            indexT += 2;
                        }
                        break;


                    case ";":
                        {
                            indexT++;
                        }
                        break;
                    default:
                        if (Code.Tokens[indexT].klass == "идентификатор")
                        {
                            sharpCode += deep + Code.Tokens[indexT].value;
                        }
                        indexT++;
                        break;
                }          
            }


            csCode.WriteLine(sharpCode + specEndings);
            csCode.Close();
            return true;
        }
    }
}
