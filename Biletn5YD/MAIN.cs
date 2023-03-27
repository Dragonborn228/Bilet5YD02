using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using Word = Microsoft.Office.Interop.Word;


namespace Biletn5YD
{
    public partial class MAIN : Form
    {
        public string name;
        public MAIN()
        {
            InitializeComponent();
            pictureBox1.ImageLocation = $@"C:\Users\User\Desktop\Biletn5YD\Biletn5YD\resurse\Formjpg.jpg";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a=0;
            double b=0;
            double x=0;
            try
            {
                 a = Convert.ToInt32(textBox1.Text);
                 b = Convert.ToInt32(textBox2.Text);
                 x = Convert.ToInt32(comboBox1.SelectedIndex.ToString());
            }
            catch
            {
                MessageBox.Show("Введите данные");
            }
            try
            {
                if(a>0 & b > 0)
                {
                    double price = SUSL.USL(a, b, x);

                    if (radioButton1.Checked == true)
                    {
                        price = price + 1000;
                        name = radioButton1.Text;
                    }
                    if (radioButton2.Checked == true)
                    {
                        price = price + 3400.50;
                        name = radioButton2.Text;
                    }
                    if (radioButton3.Checked == true)
                    {
                        price = price + 2560;
                        name = radioButton3.Text;
                    }
                    if (radioButton4.Checked == true)
                    {
                        price = price + 7900.90;
                        name = radioButton4.Text;
                    }
                    if (radioButton5.Checked == true)
                    {
                        price = price + 6210.50;
                        name = radioButton5.Text;
                    }

                    label4.Text = price.ToString();
                    pictureBox1.ImageLocation = $@"C:\Users\User\Desktop\Biletn5YD\Biletn5YD\resurse\SvoiForm.jpg";
                }
                else
                {
                    MessageBox.Show("Введено отрицательное число(а)");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                string savePath = Path.GetFullPath(@"C:\Users\User\Desktop\Biletn5YD\Biletn5YD\resurse");

                OpenFileDialog OPF = new OpenFileDialog();
                OPF.Filter = "Изображения|*.png|*.jpeg|*.jpg";
                if (OPF.ShowDialog() == DialogResult.OK)
                {

                    string fileName = Path.GetFileName(OPF.FileName);


                    savePath = savePath + "\\" + fileName;

                    try
                    {
                        Bitmap image = new Bitmap(OPF.FileName);
                        Bitmap newSizeImage = new Bitmap(image, new Size(900, 1200));
                        newSizeImage.Save(savePath,
                        System.Drawing.Imaging.ImageFormat.Jpeg);

                        MessageBox.Show("Изображение загружено.",
    "Успех",
    MessageBoxButtons.OK,
    MessageBoxIcon.Information,
    MessageBoxDefaultButton.Button1,
    MessageBoxOptions.DefaultDesktopOnly);
                        pictureBox1.ImageLocation = $@"{savePath}";
                    }
                    catch
                    {
                        MessageBox.Show(
    "Не удалось загрузить изображене",
    "Ошибка",
    MessageBoxButtons.OK,
    MessageBoxIcon.Error,
    MessageBoxDefaultButton.Button1,
    MessageBoxOptions.DefaultDesktopOnly);
                    }

                }
                else
                {
                    MessageBox.Show(
    "Изображение не выбрано!",
    "Внимание",
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning,
    MessageBoxDefaultButton.Button1,
    MessageBoxOptions.DefaultDesktopOnly);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            // Создаём объект документа
            Word.Document doc = null;
            double a = Convert.ToInt32(textBox1.Text);
            double b = Convert.ToInt32(textBox2.Text);
            double x = Convert.ToInt32(comboBox1.SelectedIndex.ToString());
            string price = label4.Text;
            double s = a * b / 10000;
            DateTime date = DateTime.Now;

            try
            {
                //    // Создаём объект приложения
                Word.Application app = new Word.Application();
                // Путь до шаблона документа меняется от места нахождения у вас будет другой
                string source = @"C:\Users\User\Desktop\Biletn5YD\Чек.docx";
                // Открываем
                doc = app.Documents.Add(source);
                doc.Activate();

                // Добавляем информацию
                // wBookmarks содержит все закладки
                Word.Bookmarks wBookmarks = doc.Bookmarks;
                Word.Range wRange;
                int i = 0;
                string[] data = new string[6] { $"{s}", $"{date}", $"{price}",$"{1}", $"{name}", $"{comboBox1.Text}" };
                foreach (Word.Bookmark mark in wBookmarks)
                {

                    wRange = mark.Range;
                    wRange.Text = data[i];
                    i++;
                }

                // Закрываем документ
                doc.Close();
                doc = null;
            }
            catch
            {
                // Если произошла ошибка, то
                // закрываем документ и выводим информацию
                doc.Close();
                doc = null;
                Console.WriteLine("Во время выполнения произошла ошибка!");
                Console.ReadLine();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            double x = Convert.ToInt32(comboBox1.SelectedIndex.ToString());
            if (x == 0)
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
                radioButton4.Enabled = true;
                radioButton5.Enabled = true;
            }
            if (x == 1)
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
                radioButton5.Enabled = false;
            }
            if (x == 2)
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
                radioButton5.Enabled = false;
            }
        }
    }
}
