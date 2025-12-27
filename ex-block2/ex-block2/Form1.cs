using System;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

namespace ex_block2
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            button1.Text = "Старт обробки";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string targetDir = @"C:\Users\MNYAW\Desktop\lab6_exception_block-2\ex-block2\ex-block2\bin\Debug\net9.0-windows\photos";

            if (!Directory.Exists(targetDir))
            {
                MessageBox.Show($"Папку не знайдено:\n{targetDir}", "Неправильно вписаний шлях", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] files = Directory.GetFiles(targetDir);
            Regex regexExtForImage = new Regex(@"^((bmp)|(gif)|(tiff?)|(jpe?g)|(png))$", RegexOptions.IgnoreCase);

            int processedCount = 0;

        }
    }
}
