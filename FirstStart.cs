using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ecoview_Professional
{
    public partial class FirstStart : Form
    {
        public FirstStart()
        {
            InitializeComponent();
        }

        private void FirstStart_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Уважаемый пользователь! При регистрации прибора вы автоматически получаете продление лицензии на 3 месяца!\n Вы можете продлить прибор нажав на кнопку Продолжить.";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            registration.ShowDialog();
            Close();
        }
        public string pathTemp = Path.GetTempPath();
        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                string namefile = "registrastion";
                // button1.Enabled = false;
                System.IO.StreamWriter textFile = new System.IO.StreamWriter(@namefile);
                textFile.WriteLine("registrastion not!");
                // textFile.WriteLine("And goodbye");
                textFile.Close();
                EncriptorFileBase64 encriptorFileBase64 = new EncriptorFileBase64(@namefile, pathTemp);
                Close();
            }
            else
            {
                button1.Enabled = true;
                Close();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.ecoview.ru/images/ecove/doc_pdf/Pravila.pdf");
        }
    }
}
