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
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Ecoview_Professional
{
    public partial class Registration : Form
    {
        PriborInformation _Analis;
        public string pathTemp = Path.GetTempPath();
        string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/";
        public Registration()
        {
            InitializeComponent();
            /*  this._Analis = parent;
              textBox10.Text = _Analis.Model1.SelectedItem.ToString();
              textBox11.Text = _Analis.textBox1.Text;
              textBox13.Text = _Analis.textBox5.Text;
              textBox1.Text = _Analis.textBox4.Text;
              textBox5.Text = _Analis.textBox4.Text;
              dateTimePicker1.Value = _Analis.dateTimePicker1.Value;*/
            var applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            string model = path + @"pribor/model";
            DecriptorPribor decriptorModel = new DecriptorPribor(ref model, pathTemp);

            // model = model.Substring(model.LastIndexOf(@"/") + 1);
            var model_var = Path.Combine(applicationDirectory, pathTemp + model);

            string SerNomer_Text = path + @"pribor/SerNomer";
            DecriptorPribor decriptorSerNomer = new DecriptorPribor(ref SerNomer_Text, pathTemp);
            var SerNomer_Text_var = Path.Combine(applicationDirectory, pathTemp + SerNomer_Text);

            string address_lab_Text = path + @"pribor/address_lab";
            DecriptorPribor decriptoraddress_lab = new DecriptorPribor(ref address_lab_Text, pathTemp);
            var address_lab_var = Path.Combine(applicationDirectory, pathTemp + address_lab_Text);

            string name_lab_Text = path + @"pribor/name_lab";
            DecriptorPribor decriptorname_lab = new DecriptorPribor(ref name_lab_Text, pathTemp);
            var name_lab_var = Path.Combine(applicationDirectory, pathTemp + name_lab_Text);


            string Poveren_Text = path + @"pribor/Poveren";
            DecriptorPribor decriptorPoveren = new DecriptorPribor(ref Poveren_Text, pathTemp);
            var Poveren_Text_var = Path.Combine(applicationDirectory, pathTemp + Poveren_Text);

            StreamReader fs = new StreamReader(model_var);
            string model1;
            model1 = fs.ReadLine();
            textBox10.Text = model1;
            fs.Close();

            StreamReader fs1 = new StreamReader(SerNomer_Text_var);
            textBox11.Text = fs1.ReadLine();
            fs1.Close();

            StreamReader fs5 = new StreamReader(address_lab_var);
            textBox13.Text = fs5.ReadLine();
            fs5.Close();

            StreamReader fs6 = new StreamReader(name_lab_var);
            textBox1.Text = fs6.ReadLine();
            textBox5.Text = textBox1.Text;
            fs6.Close();

            StreamReader fs4 = new StreamReader(Poveren_Text_var);
            dateTimePicker1.Text = fs4.ReadLine();
            fs4.Close();
            button1.Enabled = false;
            label18.Text = "";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkedListBox2.Enabled = true;
            }
            else
            {
                checkedListBox2.Enabled = false;
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                checkedListBox1.Enabled = true;
            }
            else
            {
                checkedListBox1.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                checkedListBox3.Enabled = true;
            }
            else
            {
                checkedListBox3.Enabled = false;
            }
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
            string result = "Экологический контроль: <br>";
            foreach (object itemChecked in checkedListBox1.CheckedItems)
            {
                result += " " + itemChecked.ToString() + "<br>";
            }

            string result1 = "Контроль сырья и продукции: <br>";
            foreach (object itemChecked in checkedListBox2.CheckedItems)
            {
                result1 += " " + itemChecked.ToString() + "<br>";
            }

            string result2 = "Прочие области применения: <br>";

            result2 += " " + textBox12.Text + "<br>";

            m.Subject = "Регистрация Спектрофотометра";
            // текст письма
            m.Body = "------------------------------------------------------------<br>" +
                        "Информация об организации: <br>" +
                        "<br>Наименование предприятия / организации: " + textBox1.Text + "<br>" +
                        "ИНН предприятия: " + textBox2.Text + "<br>" +
                        "Структурное подразделение: " + textBox3.Text + "<br>" +
                        "Почтовый адрес: " + textBox4.Text + "<br>" +
                        "Наименование лаборатории: " + textBox5.Text + "<br>" +
                        "ФИО Начальника лаборатории: " + textBox6.Text + "<br><br>-------------------------------------------------------------<br>" +
                        "Информация об ответственном лице:<br><br>" +
                        "ФИО ответственного:" + textBox7.Text + "<br>" +
                        "Телефон отвественного:" + textBox8.Text + "<br>" +
                        "Электронная почта ответственного:" + textBox9.Text + "<br><br>-------------------------------------------------------------<br>" +
                        "Информация о регистрируемом приборе:<br><br>" +
                        "Модель спектрофотометра:" + textBox10.Text + "<br>" +
                        "Заводской номер спектрофотометра: " + textBox11.Text + "<br>" +
                        "<br><br><br>Область применения: " + "<br><br>" +
                        result + "<br>" +
                        result1 + "<br>" +
                        result2 + "<br>" +
                        "Адрес установки:" + textBox13.Text + "<br>" +
                        "Дата первичной проверки:" + dateTimePicker1.Text + "<br>" +
                        "Дата приобретения: " + dateTimePicker2.Text + "<br>" +
                        "Дата ввода в эксплуатацию:" + dateTimePicker3.Text + "<br>";
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
                string namefile = "registrastion";
                // button1.Enabled = false;
                System.IO.StreamWriter textFile = new System.IO.StreamWriter(@namefile);
                textFile.WriteLine("registrastion not!");
                // textFile.WriteLine("And goodbye");
                textFile.Close();
                EncriptorFileBase64 encriptorFileBase64 = new EncriptorFileBase64(@namefile, pathTemp);
                Close();
            }
            catch (SmtpException ex)
            {
                //В случае ошибки при отсылке сообщения можем увидеть, в чем проблема
                MessageBox.Show(ex.Message);
            }
            //Console.Read();
        }

        private void textBox8_Validated(object sender, EventArgs e)
        {
            //  if(Validate == true)
        }

        private void textBox8_Validating(object sender, CancelEventArgs e)
        {
            //regular expression pattern for valid email
            //addresses, allows for the following domains:
            //com,edu,info,gov,int,mil,net,org,biz,name,museum,coop,aero,pro,tv
            string pattern = @"^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.
    (com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$";
            //Regular expression object
            Regex check = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);
            //boolean variable to return to calling method
            bool valid = false;

            //make sure an email address was provided
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                valid = false;
                label18.Text = "* Email-адрес не корректный";
                label18.ForeColor = Color.DarkRed;
                //  button1.Enabled = false;
            }
            else
            {
                //use IsMatch to validate the address
                valid = check.IsMatch(textBox8.Text);
                // button1.Enabled = true;
                label18.Text = "";
            }
            //return the value to the calling method

        }

        private void textBox9_Validating(object sender, CancelEventArgs e)
        {
            //regular expression pattern for valid email
            //addresses, allows for the following domains:
            //com,edu,info,gov,int,mil,net,org,biz,name,museum,coop,aero,pro,tv
            string pattern = @"(^\+\d{1,2})?((\(\d{3}\))|(\-?\d{3}\-)|(\d{3}))((\d{3}\-\d{4})|(\d{3}\-\d\d\  
-\d\d)|(\d{7})|(\d{3}\-\d\-\d{3}))$";
            //Regular expression object
            Regex check = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);
            //boolean variable to return to calling method
            bool valid = false;

            //make sure an email address was provided
            if (string.IsNullOrEmpty(textBox9.Text))
            {
                valid = false;
                label18.Text = "* Телефон для связи не корректный";
                label18.ForeColor = Color.DarkRed;
                // button1.Enabled = false;
            }
            else
            {
                //use IsMatch to validate the address
                valid = check.IsMatch(textBox8.Text);
                button1.Enabled = true;
                label18.Text = "";
            }
            //return the value to the calling method
        }
        int allString = 0;
        private void textBox1_Leave(object sender, EventArgs e)
        {

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {

        }

        private void textBox5_Leave(object sender, EventArgs e)
        {

        }

        private void textBox6_Leave(object sender, EventArgs e)
        {

        }

        private void textBox7_Leave(object sender, EventArgs e)
        {

        }

        private void textBox8_Leave(object sender, EventArgs e)
        {

        }

        private void textBox9_Leave(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != null && textBox1.TextLength == 1)
            {
                allString++;
            }
            else
            {
                allString--;
            }
            if (allString > 9 && textBox10.Text != null && textBox11.Text != null && textBox13.Text != null && label18.Text == "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != null && textBox2.TextLength == 1)
            {
                allString++;
            }
            else
            {
                allString--;
            }
            if (allString > 9 && textBox10.Text != null && textBox11.Text != null && textBox13.Text != null && label18.Text == "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != null && textBox3.TextLength == 1)
            {
                allString++;
            }
            else
            {
                allString--;
            }
            if (allString > 9 && textBox10.Text != null && textBox11.Text != null && textBox13.Text != null && label18.Text == "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != null && textBox4.TextLength == 1)
            {
                allString++;
            }
            else
            {
                allString--;
            }
            if (allString > 9 && textBox10.Text != null && textBox11.Text != null && textBox13.Text != null && label18.Text == "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != null && textBox5.TextLength == 1)
            {
                allString++;
            }
            else
            {
                allString--;
            }
            if (allString > 9 && textBox10.Text != null && textBox11.Text != null && textBox13.Text != null && label18.Text == "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != null && textBox6.TextLength == 1)
            {
                allString++;
            }
            else
            {
                allString--;
            }
            if (allString > 9 && textBox10.Text != null && textBox11.Text != null && textBox13.Text != null && label18.Text == "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text != null && textBox7.TextLength == 1)
            {
                allString++;
            }
            else
            {
                allString--;
            }
            if (allString > 9 && textBox10.Text != null && textBox11.Text != null && textBox13.Text != null && label18.Text == "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            //regular expression pattern for valid email
            //addresses, allows for the following domains:
            //com,edu,info,gov,int,mil,net,org,biz,name,museum,coop,aero,pro,tv
            string pattern = @"^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+(\.[-.a-zA-Z0-9]+)*\.
    (com|edu|info|gov|int|mil|net|org|biz|name|museum|coop|aero|pro|tv|[a-zA-Z]{2})$";
            //Regular expression object
            Regex check = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);
            //boolean variable to return to calling method
            bool valid = false;

            //make sure an email address was provided
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                valid = false;
                label18.Text = "* Email-адрес не корректный";
                label18.ForeColor = Color.DarkRed;
                //  button1.Enabled = false;
            }
            else
            {
                //use IsMatch to validate the address
                valid = check.IsMatch(textBox8.Text);
                // button1.Enabled = true;
                label18.Text = "";
            }
            //return the value to the calling method
            if (textBox8.Text != null && textBox8.TextLength == 1)
            {
                allString++;
            }
            else
            {
                allString--;
            }
            if (allString > 9 && textBox10.Text != null && textBox11.Text != null && textBox13.Text != null && label18.Text == "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            //regular expression pattern for valid email
            //addresses, allows for the following domains:
            //com,edu,info,gov,int,mil,net,org,biz,name,museum,coop,aero,pro,tv
            string pattern = @"(^\+\d{1,2})?((\(\d{3}\))|(\-?\d{3}\-)|(\d{3}))((\d{3}\-\d{4})|(\d{3}\-\d\d\  
-\d\d)|(\d{7})|(\d{3}\-\d\-\d{3}))$";
            //Regular expression object
            Regex check = new Regex(pattern, RegexOptions.IgnorePatternWhitespace);
            //boolean variable to return to calling method
            bool valid = false;

            //make sure an email address was provided
            if (string.IsNullOrEmpty(textBox9.Text))
            {
                valid = false;
                label18.Text = "* Телефон для связи не корректный";
                label18.ForeColor = Color.DarkRed;
                // button1.Enabled = false;
            }
            else
            {
                //use IsMatch to validate the address
                valid = check.IsMatch(textBox8.Text);
                button1.Enabled = true;
                label18.Text = "";
            }
            //return the value to the calling method
            if (textBox9.Text != null && textBox9.TextLength == 1)
            {
                allString++;
            }
            else
            {
                allString--;
            }
            if (allString > 9 && textBox10.Text != null && textBox11.Text != null && textBox13.Text != null && label18.Text == "")
            {
                button1.Enabled = true;
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
