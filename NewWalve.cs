using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SWF = System.Windows.Forms;

namespace Ecoview_Professional
{
    public partial class NewWalve : Form
    {
        Ecoview _Analis;
        public NewWalve(Ecoview parent)
        {
            InitializeComponent();
            this._Analis = parent;
            if (_Analis.ComPodkl == true)
            {
                Walve.Text = _Analis.GWNew.Text;
            }
        }
        bool form_close = false;
        private void button2_Click(object sender, EventArgs e)
        {
            SW();
            SAGE sage = new SAGE(ref _Analis.countSA, ref _Analis.GE5_1_0, ref _Analis.versionPribor, ref _Analis.newPort);

            /// _Analis.SAGE(ref _Analis.countSA, ref _Analis.GE5_1_0);
            form_close = true;
            _Analis.label60.Text = "Длина волны для измерения " + _Analis.GWNew.Text;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void SW()
        {
            LogoForm2 logoform = new LogoForm2();
            string SWText1 = Walve.Text;
            double Walve_double = Convert.ToDouble(Walve.Text.Replace(".", ","));
            _Analis.newPort.Write("SW " + Walve_double.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")) + "\r");
            string indata = _Analis.newPort.ReadExisting();

            bool indata_bool = true;
            while (indata_bool == true)
            {
                if (indata.Contains(">"))
                {

                    indata_bool = false;

                }

                else
                {
                    indata = _Analis.newPort.ReadExisting();
                }
            }
            Walve.Text = Walve.Text.Replace(".", ",");
            _Analis.GWNew.Text = string.Format("{0:0.0}", Convert.ToDouble(Walve.Text));
            _Analis.GWNew.Text = _Analis.GWNew.Text.Replace(",", ".");
            Application.OpenForms["LogoForm2"].Close();
        }


        private void Walve_Leave(object sender, EventArgs e)
        {

            if (_Analis.ComPort == true && Walve.Text != "")
            {
                if (_Analis.versionPribor.Contains("V"))
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
                    if (_Analis.versionPribor.Contains("U") && _Analis.versionPribor.Contains("2"))
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
