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
    public partial class KineticaScan : Form
    {
        CreateDimension _Analis;
        string versionPribor;
        public KineticaScan(CreateDimension parent, string versionPribor1)
        {
            InitializeComponent();
            this._Analis = parent;
            this.versionPribor = versionPribor1;
            comboBox1.Text = comboBox1.Items[3].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((Convert.ToDouble(textBox4.Text) % Convert.ToDouble(comboBox1.SelectedItem.ToString())) != 0)
            {
                MessageBox.Show("Общее время должно быть кратно интервалу!");
                return;
            }
            else
            {
                _Analis.GWString = textBox2.Text;

                //_Analis.countButtonClick = 1;
                _Analis.start = Convert.ToDouble(textBox4.Text);
                _Analis.interval = Convert.ToDouble(comboBox1.SelectedItem.ToString());
                _Analis.delay = Convert.ToDouble(textBox3.Text);
                
                // _Analis.SAGE(ref _Analis.countSA, ref _Analis.GE5_1_0);
                _Analis.massWL = new double[0];
                _Analis.massGE = new double[0];
                _Analis.countscan = 0;
               
                if (radioButton1.Checked == true)
                {
                    _Analis.typeIzmer = "Abs";

                }
                else
                {
                    _Analis.typeIzmer = "%T";
                    
                }

            
               
                /*  TimerCallback tm = new TimerCallback(_Analis.TableKinetica);
                  System.Threading.Timer timer = new System.Threading.Timer(tm, _Analis.delay,
                      Convert.ToInt32(_Analis.start), Convert.ToInt32(_Analis.interval));*/
                
                _Analis.Description = textBox1.Text;
                _Analis.code = textBox7.Text;
                _Analis.direction = textBox6.Text;
                _Analis.DateTime = dateTimePicker1.Value.AddDays(_Analis.Days).ToString("dd.MM.yyyy");
                _Analis.Ispolnitel = textBox5.Text;

                _Analis.KineticaTableCreate();
                // button1.Click += button1_Click;
                
                // _Analis.timer2.Start();
                Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (e.KeyChar == 46 && textBox3.Text.IndexOf(',') == -1)
            {
                e.KeyChar = ',';

            }
            else
            {

                if (e.KeyChar == 46 && textBox3.Text.IndexOf(',') != -1)
                {
                    e.Handled = true;
                    return;
                }

            }
            if (number == 44 && textBox3.Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }

            if ((e.KeyChar >= 58 || e.KeyChar <= 47) && number != 8 && number != 44 && number != 46) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
                MessageBox.Show("В данное поле можно вводить цифры, знаки '.'");
            }
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                if (versionPribor.Contains("V"))
                {
                    if (Convert.ToDouble(textBox2.Text.Replace(".", ",")) < 315)
                    {
                        textBox2.Text = Convert.ToString(315);
                    }
                    if (Convert.ToDouble(textBox2.Text.Replace(".", ",")) > 1050)
                    {
                        textBox2.Text = Convert.ToString(1050);
                    }
                }
                else
                {
                    if (versionPribor.Contains("U") && versionPribor.Contains("2"))
                    {
                        if (Convert.ToDouble(textBox2.Text.Replace(".", ",")) < 190)
                        {
                            textBox2.Text = Convert.ToString(190);
                        }
                        if (Convert.ToDouble(textBox2.Text.Replace(".", ",")) > 1050)
                        {
                            textBox2.Text = Convert.ToString(1050);
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(textBox2.Text.Replace(".", ",")) < 200)
                        {
                            textBox2.Text = Convert.ToString(200);
                        }
                        if (Convert.ToDouble(textBox2.Text.Replace(".", ",")) > 1050)
                        {
                            textBox2.Text = Convert.ToString(1050);
                        }
                    }
                }
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(textBox3.Text) > 3600)
            {
                textBox3.Text = "3600,0";
            }
            if (Convert.ToDouble(textBox3.Text) < 0)
            {
                textBox3.Text = "0,0";
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (Convert.ToDouble(textBox3.Text) > 360000)
            {
                textBox3.Text = "360000,0";
            }
            if (Convert.ToDouble(textBox3.Text) < 0)
            {
                textBox3.Text = "0,0";
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (e.KeyChar == 46 && textBox3.Text.IndexOf(',') == -1)
            {
                e.KeyChar = ',';

            }
            else
            {

                if (e.KeyChar == 46 && textBox3.Text.IndexOf(',') != -1)
                {
                    e.Handled = true;
                    return;
                }

            }
            if (number == 44 && textBox3.Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }

            if ((e.KeyChar >= 58 || e.KeyChar <= 47) && number != 8 && number != 44 && number != 46) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
                MessageBox.Show("В данное поле можно вводить цифры, знаки '.'");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (e.KeyChar == 46 && textBox4.Text.IndexOf(',') == -1)
            {
                e.KeyChar = ',';

            }
            else
            {

                if (e.KeyChar == 46 && textBox4.Text.IndexOf(',') != -1)
                {
                    e.Handled = true;
                    return;
                }

            }
            if (number == 44 && textBox4.Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }

            if ((e.KeyChar >= 58 || e.KeyChar <= 47) && number != 8 && number != 44 && number != 46) //цифры, клавиша BackSpace и запятая а ASCII
            {
                e.Handled = true;
                MessageBox.Show("В данное поле можно вводить цифры, знаки '.'");
            }
        }
    }
}
