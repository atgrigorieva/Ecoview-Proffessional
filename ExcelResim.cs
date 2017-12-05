using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ecoview_Professional
{
    public partial class ExcelResim : Form
    {
        CreateDimension _Analis;
        string versionPribor;
        public ExcelResim(CreateDimension parent, string versionPribor1)
        {
            InitializeComponent();
            this._Analis = parent;
            this.versionPribor = versionPribor1;
        }
        bool form_close = false;
        private void button2_Click(object sender, EventArgs e)
        {
            if (_Analis.filepath != null && Walve.Text != "")
            {
                _Analis.GWString = Walve.Text;
                _Analis.TableExcel();
                Close();
            }
            else
            {
                MessageBox.Show("Вы не выбрали файл для записи или не задали длину волны");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            form_close = false;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C";
            openFileDialog1.Title = "Open File";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Excel файл|*.xls; *.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _Analis.filepath = openFileDialog1.FileName;
                    textBox1.Text = _Analis.filepath;


                }
                catch (Exception t) { MessageBox.Show("exeption" + t.Message); }
            }
        }
        private void Walve_Leave(object sender, EventArgs e)
        {
            if (Walve.Text != "")
            {
                if (versionPribor.Contains("V"))
                {
                    if (Convert.ToDouble(Walve.Text.Replace(".", ",")) < 315)
                    {
                        Walve.Text = Convert.ToString(315);
                    }
                    if (Convert.ToDouble(Walve.Text.Replace(".", ",")) > 1050)
                    {
                        Walve.Text = Convert.ToString(1050);
                    }
                }
                else
                {
                    if (versionPribor.Contains("U") && versionPribor.Contains("2"))
                    {
                        if (Convert.ToDouble(Walve.Text.Replace(".", ",")) < 190)
                        {
                            Walve.Text = Convert.ToString(190);
                        }
                        if (Convert.ToDouble(Walve.Text.Replace(".", ",")) > 1050)
                        {
                            Walve.Text = Convert.ToString(1050);
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(Walve.Text.Replace(".", ",")) < 200)
                        {
                            Walve.Text = Convert.ToString(200);
                        }
                        if (Convert.ToDouble(Walve.Text.Replace(".", ",")) > 1050)
                        {
                            Walve.Text = Convert.ToString(1050);
                        }
                    }
                }
            }
        }
        private void Walve_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (e.KeyChar == 46 && Walve.Text.IndexOf(',') == -1)
            {
                e.KeyChar = ',';

            }
            else
            {

                if (e.KeyChar == 46 && Walve.Text.IndexOf(',') != -1)
                {
                    e.Handled = true;
                    return;
                }

            }
            if (number == 44 && Walve.Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }

            if ((e.KeyChar <= 42 || e.KeyChar >= 58 || e.KeyChar == 43 || e.KeyChar <= 45 || e.KeyChar == 47) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
                MessageBox.Show("В данное поле можно вводить цифры, знаки ','");
            }
        }
    }
}
