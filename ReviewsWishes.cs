using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace Ecoview_Professional
{
    public partial class ReviewsWishes : Form
    {
        public ReviewsWishes()
        {
            InitializeComponent();
        }
        public string pathTemp = Path.GetTempPath();
        string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/";
        public string address_lab;
        public string name_lab;
        private void ReviewsWishes_Load(object sender, EventArgs e)
        {
            var applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);

            string model = path + @"pribor/model";
            DecriptorPribor decriptorModel = new DecriptorPribor(ref model, pathTemp);

            // model = model.Substring(model.LastIndexOf(@"/") + 1);
            var model_var = Path.Combine(applicationDirectory, pathTemp + model);

            string SerNomer_Text = path + @"pribor/SerNomer";
            DecriptorPribor decriptorSerNomer = new DecriptorPribor(ref SerNomer_Text, pathTemp);
            var SerNomer_Text_var = Path.Combine(applicationDirectory, pathTemp + SerNomer_Text);

            string InventarNomer_Text = path + @"pribor/InventarNomer";
            DecriptorPribor decriptorInventarNomer = new DecriptorPribor(ref InventarNomer_Text, pathTemp);
            var InventarNomer_Text_var = Path.Combine(applicationDirectory, pathTemp + InventarNomer_Text);



            string Poveren_Text = path + @"pribor/Poveren";
            DecriptorPribor decriptorPoveren = new DecriptorPribor(ref Poveren_Text, pathTemp);
            var Poveren_Text_var = Path.Combine(applicationDirectory, pathTemp + Poveren_Text);

            string address_lab_Text = path + @"pribor/address_lab";
            DecriptorPribor decriptoraddress_lab = new DecriptorPribor(ref address_lab_Text, pathTemp);
            var address_lab_var = Path.Combine(applicationDirectory, pathTemp + address_lab_Text);

            string name_lab_Text = path + @"pribor/name_lab";
            DecriptorPribor decriptorname_lab = new DecriptorPribor(ref name_lab_Text, pathTemp);
            var name_lab_var = Path.Combine(applicationDirectory, pathTemp + name_lab_Text);

            StreamReader fs = new StreamReader(model_var);
            string model1;
            model1 = fs.ReadLine();
            textBox5.Text = model1;
            fs.Close();

            StreamReader fs1 = new StreamReader(SerNomer_Text_var);
            textBox7.Text = fs1.ReadLine();
            fs1.Close();

            StreamReader fs2 = new StreamReader(InventarNomer_Text_var);
            //textBox2.Text = fs2.ReadLine();
            fs2.Close();

            StreamReader fs5 = new StreamReader(address_lab_var);
            textBox4.Text = fs5.ReadLine();
            fs5.Close();

            StreamReader fs6 = new StreamReader(name_lab_var);
            textBox3.Text = fs6.ReadLine();
            fs6.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress("info@promecolab.ru", "Ecoview Professional");
            // кому отправляем
            MailAddress to = new MailAddress("nastena.grigoreva.93@inbox.ru");
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            string PK;
            if (checkBox1.Checked == true) { PK = "да"; }
            else PK = "нет";

            char[] A_S = new char[richTextBox1.Text.Length];
            for (int i = 0; i < A_S.Length; i++)
            {
                A_S[i] = richTextBox1.Text[i];
            }

            string textText = "";

            for (int i = 0; i < A_S.Length; i++)
            {
                textText = textText + A_S[i].ToString();
                if (i % 500 == 0 && i != 0)
                {
                    textText = textText + "\n\n";
                }
            }

            m.Subject = "Отзывы и пожелания";
            // текст письма
            m.Body = "------------------------------------------------------------<br>" +
                        "Информация об организации: <br>" +
                        "<br>Должность: " + textBox1.Text + "<br>" +
                        "ФИО: " + textBox2.Text + "<br>" +
                        "Название лаборатории: " + textBox3.Text + "<br>" +
                        "Адрес лаборатории: " + textBox4.Text + "<br>" +

                        "Модель прибора: " + textBox5.Text + "<br>" +
                        "Заводской номер: " + textBox7.Text + "<br>" +
                        "Год изготовления прибора: " + textBox6.Text + "<br>" +
                        "Дата ввода в эксплуатацию: " + dateTimePicker1.Text + "<br>" +

                        "<br><br>-------------------------------------------------------------<br>" +
                        "Информация об использовании прибора:<br><br>" +
                        "Выполняемые измерения:" + textBox9.Text + "<br>" +
                        "Кол-во измерений в день:" + textBox10.Text + "<br>" +
                        "Используемые режимы работы прибора:" + textBox11.Text + "<br>" +
                        "Используемые кюветы: " + textBox12.Text + "<br>" +
                        "Использование подключения к ПК:" + PK + "<br>" + "<br><br>-------------------------------------------------------------<br>" +

                        "Оценка качества работы (по 5-ти бальной шкале):<br><br>" +

                        "Удобство работы:" + numericUpDown1.Text + "; " +
                        "Удобство кюветодержателя:" + numericUpDown2.Text + "; " +
                        "Внешний вид: " + numericUpDown3.Text + "; " +
                        "Надежность:" + numericUpDown4.Text + "<br>" +
                        "Комплект поставки: " + numericUpDown5.Text + "; " +
                        "Точность измерений: " + numericUpDown6.Text + ";" +
                        "Технические характеристики: " + numericUpDown7.Text + ";" +
                        "Общая оценка: " + numericUpDown8.Text + "<br>" + "<br><br>-------------------------------------------------------------<br>" +
                        "Отзывы и пожелания" + "<br>" + textText.Replace("\n\n", "<br>");




            // письмо представляет код html
            m.IsBodyHtml = true;
            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient("smtp.spaceweb.ru", 25);
            // логин и пароль
            smtp.Credentials = new NetworkCredential("info@promecolab.ru", "B2%7sK%1mM");
            smtp.EnableSsl = true;
            // smtp.UseDefaultCredentials = true;
            try
            {
                //Отсылаем сообщение
                smtp.Send(m);
                Close();
            }
            catch (SmtpException ex)
            {
                //В случае ошибки при отсылке сообщения можем увидеть, в чем проблема
                MessageBox.Show(ex.Message);
            }
            //Console.Read();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintPreviewDialogSelectPrinter printPreviewDialogSelectPrinter = new PrintPreviewDialogSelectPrinter();
            printPreviewDialogSelectPrinter.Document = ReviewsTablePrint;
            printPreviewDialogSelectPrinter.ShowDialog();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;

        }

        private void ReviewsTablePrint_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string PK;
            if (checkBox1.Checked == true) { PK = "да"; }
            else PK = "нет";
            e.Graphics.DrawString("Отзывы и пожелания\n\n",
                new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, 300, 50);
            e.Graphics.DrawString("Должность:",
              new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 100, 100);
            e.Graphics.DrawString(textBox1.Text,
              new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 190, 100);
            e.Graphics.DrawString("ФИО:",
              new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 100, 120);
            e.Graphics.DrawString(textBox2.Text,
              new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 150, 120);
            e.Graphics.DrawString("Наименование лаборатории:",
              new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 100, 140);
            e.Graphics.DrawString(textBox3.Text,
              new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 330, 140);
            e.Graphics.DrawString("Адрес лаборатории:",
              new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 100, 160);
            e.Graphics.DrawString(textBox4.Text,
              new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 270, 160);

            e.Graphics.DrawString("Модель прибора:",
                new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 100, 180);
            e.Graphics.DrawString(textBox5.Text,
              new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 240, 180);
            e.Graphics.DrawString("Заводской номер:",
              new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 450, 180);
            e.Graphics.DrawString(textBox7.Text,
              new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 590, 180);
            e.Graphics.DrawString("Год изготовления прибора:",
              new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 100, 200);
            e.Graphics.DrawString(textBox6.Text,
              new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 310, 200);
            e.Graphics.DrawString("Дата ввода в эксплуатацию:",
              new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 400, 200);
            e.Graphics.DrawString(dateTimePicker1.Text,
              new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 620, 200);


            e.Graphics.DrawString("Информация об использовании прибора:",
                new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 250, 230);

            e.Graphics.DrawString("Выполняемые измерения:",
                new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 100, 260);
            e.Graphics.DrawString(textBox9.Text,
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 300, 260);
            e.Graphics.DrawString("Количество измерений в день:",
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 100, 280);
            e.Graphics.DrawString(textBox10.Text,
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 330, 280);
            e.Graphics.DrawString("Использование подключения к ПК:",
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 430, 280);
            e.Graphics.DrawString(PK,
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 700, 280);
            e.Graphics.DrawString("Используемые режимы работы прибора:",
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 100, 300);
            e.Graphics.DrawString(textBox11.Text,
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 330, 300);
            e.Graphics.DrawString("Используемые кюветы:",
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 100, 320);
            e.Graphics.DrawString(textBox12.Text,
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 330, 320);






            e.Graphics.DrawString("Оценка качества (по 5-ти бальной шкале):",
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 250, 350);

            e.Graphics.DrawString("Удобство работы:",
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 100, 380);
            e.Graphics.DrawString(numericUpDown1.Text,
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 240, 380);
            e.Graphics.DrawString("Удобство кюветодержателя:",
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 275, 380);
            e.Graphics.DrawString(numericUpDown2.Text,
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 490, 380);
            e.Graphics.DrawString("Внешний вид:",
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 550, 380);
            e.Graphics.DrawString(numericUpDown3.Text,
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 660, 380);
            e.Graphics.DrawString("Надежность:",
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 100, 400);
            e.Graphics.DrawString(numericUpDown4.Text,
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 200, 400);
            e.Graphics.DrawString("Комплект поставки:",
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 250, 400);
            e.Graphics.DrawString(numericUpDown5.Text,
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 410, 400);
            e.Graphics.DrawString("Точность измерений:",
              new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 450, 400);
            e.Graphics.DrawString(numericUpDown6.Text,
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 630, 400);
            e.Graphics.DrawString("Технические характеристики:",
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 100, 420);
            e.Graphics.DrawString(numericUpDown7.Text,
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 330, 420);
            e.Graphics.DrawString("Общая оценка:",
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 370, 420);
            e.Graphics.DrawString(numericUpDown8.Text,
             new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 500, 420);



            e.Graphics.DrawString("Отзывы и пожелания:",
            new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 300, 450);

            /*   e.Graphics.DrawString(richTextBox1.Text,
               new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 100, 470);*/


            Graphics g = e.Graphics;
            int x = 100; int y = 470;
            SolidBrush brush = new SolidBrush(Color.Black);
            string value = richTextBox1.Text;
            Font Font1 = new Font("Times New Roman", 12, FontStyle.Regular, GraphicsUnit.Point);
            e.Graphics.MeasureString(value, Font1, 200);
            // g.DrawString(value, Font1, brush, x, y);
            System.Drawing.StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Near;
            stringFormat.LineAlignment = StringAlignment.Near;
            e.Graphics.DrawString(value, Font1, Brushes.Black, new Rectangle(x, y, 650, 520), stringFormat);


            e.Graphics.DrawString("Подпись:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 100, 990);
            e.Graphics.DrawString(" _______________________ /   ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 180, 990);
            e.Graphics.DrawString("ФИО:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 400, 990);
            e.Graphics.DrawString(" _______________________ /   ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 460, 990);
            e.Graphics.DrawString("\"___ \"_______________ 201___ г.", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 100, 1020);
            e.Graphics.DrawString("Телефон:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 100, 1060);
            e.Graphics.DrawString(" _______________________", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 180, 1060);
            e.Graphics.DrawString("E-mail:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 100, 1090);
            e.Graphics.DrawString(" _______________________", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 160, 1090);
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
