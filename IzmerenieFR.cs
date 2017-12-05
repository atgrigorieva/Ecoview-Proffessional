using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ecoview_Professional
{
    public partial class IzmerenieFR : Form
    {
        CreateDimension _Analis;
        string versionPribor;

        public IzmerenieFR(CreateDimension parent,  string versionPribor1)
        {
            InitializeComponent();
            this._Analis = parent;
            Walve.Text = _Analis.GWString;
            this.versionPribor = versionPribor1;

        }
        bool form_close = false;
        private void button1_Click(object sender, EventArgs e)
        {
            k1_linear0.Text = k1_linear0.Text.Replace(",", ".");
            
           // string Dlina = Walve.Text;
            _Analis.countSTR = Convert.ToInt32(countIzmer.Text);
            _Analis.GWString = string.Format("{0:0.0}", Walve.Text);

            _Analis.k1_linear0 = k1_linear0.Text;

            
            _Analis.DateTime = dateTimePicker1.Value.Date.ToString("dd.MM.yyyy");
            _Analis.Ispolnitel = administrant.Text;
            _Analis.Description = annotation.Text;
            _Analis.direction = direction_text.Text;
            _Analis.code = code_text.Text;

            _Analis.IzmerenieFR_RowsRemove2();
            Close();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
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
                MessageBox.Show("В данное поле можно вводить цифры, знаки '.'");
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

        private void k1_linear0_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (e.KeyChar == 46 && k1_linear0.Text.IndexOf(',') == -1)
            {
                e.KeyChar = ',';

            }
            else
            {

                if (e.KeyChar == 46 && k1_linear0.Text.IndexOf(',') != -1)
                {
                    e.Handled = true;
                    return;
                }

            }
            if (number == 44 && k1_linear0.Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }
            if ((number == 45 && k1_linear0.Text.IndexOf('-') != -1))
            {
                e.Handled = true;
                return;
            }
            if ((e.KeyChar <= 42 || e.KeyChar >= 58 || e.KeyChar == 43 || e.KeyChar == 47) && number != 8 && number != 44) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
                MessageBox.Show("В данное поле можно вводить цифры, знаки '-', '.'");
            }
        }
    }
}
