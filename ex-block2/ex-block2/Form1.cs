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
            string folder = @"C:\Users\MNYAW\Desktop\lab6_exception_block-2\ex-block2\ex-block2\bin\Debug\net9.0-windows\photos";

            if (!Directory.Exists(folder))
            {
                MessageBox.Show($"Папку не знайдено:\n{folder}", "Неправильно вписаний шлях", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] files = Directory.GetFiles(folder);
            Regex regexExtForImage = new Regex(@"^((bmp)|(gif)|(tiff?)|(jpe?g)|(png))$", RegexOptions.IgnoreCase);

            int cnt = 0;

            foreach (string filePath in files)
            {
                if (filePath.Contains("-mirrored.gif")) continue;

                try
                {
                    using (Bitmap bmp = new Bitmap(filePath))
                    {
                        bmp.RotateFlip(RotateFlipType.RotateNoneFlipX);
                        string fileNameNoExt = Path.GetFileNameWithoutExtension(filePath);
                        string newFileName = fileNameNoExt + "-mirrored.gif";
                        string savePath = Path.Combine(folder, newFileName);
                        bmp.Save(savePath, ImageFormat.Gif);

                        cnt++;
                    }
                }
                catch
                {
                    string ext = Path.GetExtension(filePath).TrimStart('.');
                    if (regexExtForImage.IsMatch(ext))
                    {
                        MessageBox.Show(
                            $"Знайдено битий файл: '{Path.GetFileName(filePath)}'\n(правильне розширення - дивний вміст).",
                            "Увага, помилка файлу!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
                    }
                }
            }

        }
    }
}
