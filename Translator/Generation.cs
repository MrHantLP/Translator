using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Translator
{
    class Generation
    {
        private String code; //чтоб из вне код не попортилось
        public Generation()
        {
            code = Code.AllCode;//в code получаем оригинальный исходный файл        
            //**********
            //подгтовка файла делай что хошь
            //**********
        }
        public bool GoGenerate()
        {
            //*****
            //Генерация происходит тут. Путь к файлу лежит в Code.pasPath с него можно достать директорию и там сгенерить файл с такимже названием но расширением *.cs
            //Путь к сгенерированному файлу засунуть в Code.CsPath
            //Если всё хорошо возвращаем тру. Ошибки могут быть только на этапе создания файлов там надо через трай кэч и если что ошибку пихаем в Code.GenerationError
            //***

            return true;
        }
    }
}
