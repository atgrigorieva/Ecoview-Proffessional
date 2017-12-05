using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace Ecoview_Professional
{
    public partial class HelpDesk : Form
    {
        public HelpDesk()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox3.Text != null && textBox4.Text != null && richTextBox1.Text != null)
            {
                // отправитель - устанавливаем адрес и отображаемое в письме имя
                MailAddress from = new MailAddress("info@promecolab.ru", "Ecoview Professional");
                // кому отправляем
                MailAddress to = new MailAddress("nastena.grigoreva.93@inbox.ru");
                // создаем объект сообщения
                MailMessage m = new MailMessage(from, to);
                // тема письма

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
                m.Subject = "Заявка на Техническую помошь";
                // текст письма
                m.Body = "------------------------------------------------------------<br>" +
                            "Информация об организации: <br>" +
                            "<br>Наименование предприятия / организации: " + textBox1.Text + "<br>" +

                            "Телефон:" + textBox4.Text + "<br>" +
                            "Электронная почта:" + textBox3.Text + "<br><br>-------------------------------------------------------------<br>" +
                            "Информация об ошибке:<br><br>" +
                            textText.Replace("\n\n", "<br>");
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
            else
            {
                MessageBox.Show("Не все поля заполнены!");
            }
        }

        private void HelpDesk_Load(object sender, EventArgs e)
        {

        }
    }
}
