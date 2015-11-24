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
    }
}
