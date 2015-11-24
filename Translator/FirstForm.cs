using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Translator
{
    public partial class FirstForm : Form
    {
        public FirstForm()
        {
            InitializeComponent();
            ChosePath.Focus();
        }

        private void FirstForm_Load(object sender, EventArgs e)
        {
            
            RUN.Enabled = false;

        }

        private void FirstForm_Shown(object sender, EventArgs e)
        {
            ChosePath.Focus();
        }

        //Считываем файл, если что выводим всякие ошибки
        //Тут же текст программы приводится в божеский вид удобный для синтаксического анализа
        private void ChosePath_Click(object sender, EventArgs e)
        {                                      
            openFileDialog.FileName = "*.pas";
            openFileDialog.ShowDialog();    
            if (openFileDialog.FileName == null) return;
            try
            {
                RUN.Enabled = true;
                StreamReader reader = new StreamReader(openFileDialog.FileName);
                Code.allCode = reader.ReadToEnd() + "\r\n";
                reader.Close();
                FileLocation.Text = openFileDialog.FileName;           
            }
            catch (FileNotFoundException no_file)
            {
                MessageBox.Show(no_file.Message, "Ошибка. Файл не найден", MessageBoxButtons.OK);
            }
            catch (Exception Unknown_e)
            {
                MessageBox.Show(Unknown_e.Message, "Неизвестная ошибка", MessageBoxButtons.OK);
                //throw;
            }
        }

        //Начинаем анализ кода 
        private void RUN_Click(object sender, EventArgs e)
        {
            //****
            //Начинает работу твой код можешь его хоть тут вставить 
            //путь к файлу в openFileDialog.FileName сейчас сидит там можно взять Path и создавать файлы там вообщем как угодно
            //или перенеси в выделенный класс весь код
            //по феншую вроде так разкоменть то что ниже Code.allCode доступен отовсюду ты только его не редактируй а так можно не передавать параметром
            //Lexer lexer = new Lexer(Code.allCode);
            //if(lexer.goAnalyze()) Message.Box ("Всё круто"); else Давай досвидания;
            
            Synt syntax = new Synt();
            if (syntax.GoAnalyze())
            {
                MessageBox.Show("Ваш код прошёл проверку синтаксического анализатора", "Синтаксический анализатор: Успех =)", MessageBoxButtons.OK);
            }                                                                                                                                       
            else
            {
                MessageBox.Show("Ошибка: " + Code.SyntError+"\nПроцесстрансляции будет прерван", "Синтаксический анализатор: Что-то пошло не так", MessageBoxButtons.OK);
                return;
            }             
            

                             
        }
    }
}
