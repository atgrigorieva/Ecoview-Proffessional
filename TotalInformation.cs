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
    public partial class TotalInformation : Form
    {
        Ecoview _Analis;
        public TotalInformation(Ecoview parent)
        {
            InitializeComponent();
            this._Analis = parent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Analis.Veshestvo1 = Veshestvo.Text;
            _Analis.Ispolnitel = Ispolnitel.Text;
            _Analis.direction = textBox1.Text;
            _Analis.code = textBox2.Text;
            _Analis.BottomLine = Down.Text;
            _Analis.TopLine = Up.Text;
            _Analis.ND = ND.Text;
            _Analis.DateTime = dateTimePicker1.Value.Date.ToString("dd.MM.yyyy");
            _Analis.Days = Convert.ToInt32(numericUpDown1.Value);
            _Analis.numericUpDown1.Text = Convert.ToString(numericUpDown1.Value);
            _Analis.dateTimePicker1.Text = dateTimePicker1.Text;
            _Analis.textBox11.Text = Veshestvo.Text;
            _Analis.Description = Description.Text;
            _Analis.textBox1.Text = _Analis.Description;
            _Analis.WidthCuvette = Opt_dlin_cuvet.Text;
            textBox2.Text = _Analis.WidthCuvette;
            _Analis.textBox3.Text = string.Format("{0:0.0000}", textBox4.Text);

            Close();
        }
        public void AllTextBoxNotNull()
        {
            bool filled = this.Controls.OfType<TextBox>().All(textBox => textBox.Text != "");
            if (filled)
            {
                button1.Visible = true;
            }
            else
            {
                button1.Visible = false;
            }
        }

        private void Ispolnitel_Leave(object sender, EventArgs e)
        {
            AllTextBoxNotNull();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            AllTextBoxNotNull();
        }

        private void Veshestvo_TextChanged(object sender, EventArgs e)
        {
            AllTextBoxNotNull();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            AllTextBoxNotNull();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            AllTextBoxNotNull();
        }

        private void Down_Leave(object sender, EventArgs e)
        {
            AllTextBoxNotNull();
        }

        private void Up_Leave(object sender, EventArgs e)
        {
            AllTextBoxNotNull();
        }

        private void Opt_dlin_cuvet_Leave(object sender, EventArgs e)
        {
            AllTextBoxNotNull();
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            AllTextBoxNotNull();
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            AllTextBoxNotNull();
        }

        private void ND_Leave(object sender, EventArgs e)
        {
            AllTextBoxNotNull();
        }

        private void Up_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (e.KeyChar == 46 && Up.Text.IndexOf(',') == -1)
            {
                e.KeyChar = ',';

            }
            else
            {

                if (e.KeyChar == 46 && Up.Text.IndexOf(',') != -1)
                {
                    e.Handled = true;
                    return;
                }

            }
            if (number == 44 && Up.Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }
            if ((number == 45 && Up.Text.IndexOf('-') != -1) || (number == 43 && Up.Text.IndexOf('+') != -1))
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

        private void Down_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (e.KeyChar == 46 && Down.Text.IndexOf(',') == -1)
            {
                e.KeyChar = ',';

            }
            else
            {

                if (e.KeyChar == 46 && Down.Text.IndexOf(',') != -1)
                {
                    e.Handled = true;
                    return;
                }

            }
            if (number == 44 && Down.Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }
            if ((number == 45 && Down.Text.IndexOf('-') != -1) || (number == 43 && Down.Text.IndexOf('+') != -1))
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
            if ((number == 45 && textBox4.Text.IndexOf('-') != -1) || (number == 43 && textBox4.Text.IndexOf('+') != -1))
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

        private void Description_TextChanged(object sender, EventArgs e)
        {
            AllTextBoxNotNull();
        }

        private void Down_TextChanged(object sender, EventArgs e)
        {
            AllTextBoxNotNull();
        }

        private void Up_TextChanged(object sender, EventArgs e)
        {
            AllTextBoxNotNull();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            AllTextBoxNotNull();
        }

        private void Ispolnitel_TextChanged(object sender, EventArgs e)
        {
            AllTextBoxNotNull();
        }

        private void ND_TextChanged(object sender, EventArgs e)
        {
            AllTextBoxNotNull();
        }
    }
}
