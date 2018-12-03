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
    public partial class NewIzmerenie : Form
    {
        CreateDimension _Analis;
        string versionPribor;
        int selet_rezim;

        public NewIzmerenie(CreateDimension parent, string versionPribor1, int selet_rezim1)
        {
            InitializeComponent();
            this._Analis = parent;

            this.selet_rezim = selet_rezim1;
            if (selet_rezim == 6)
            {
                numericUpDown3.Enabled = false;
                numericUpDown4.Enabled = false;
                USE_KO.Checked = true;
            }
            DLWave.Text = _Analis.GWString;
            int index = Opt_dlin_cuvet.FindString(_Analis.WidthCuvette);
            numericUpDown3.Value = 1;
            numericUpDown4.Value = 1;
            //  MessageBox.Show(index.ToString());
            Opt_dlin_cuvet.SelectedIndex = index;

            label23.Text = _Analis.code;
            label22.Text = _Analis.direction;
            Description.Text = _Analis.Description;
            Sozdana.Text = _Analis.DateTime;
            Zavisimost.Text = _Analis.Zavisimoct;
            Aproksimaciya.Text = _Analis.aproksim;
            label11.Text = Convert.ToString(_Analis.CountSeriya);
            label10.Text = Convert.ToString(_Analis.CountInSeriya);
            label9.Text = string.Format("{0:0.0000}", _Analis.k0);
            label8.Text = string.Format("{0:0.0000}", _Analis.k1);
            label7.Text = string.Format("{0:0.0000}", _Analis.k2);
            label12.Text = _Analis.SposobZadan;
            Ed_Izmer.Text = _Analis.edconctr;
            dateTimePicker1.Text = _Analis.DateTime;
            Deistvie.Text = dateTimePicker1.Value.AddDays(_Analis.Days).ToString("dd.MM.yyyy");

            _Analis.WidthCuvette = Convert.ToString(index);
            if (_Analis.USE_KO == true)
            {
                USE_KO.Checked = true;

            }
            else
            {
                USE_KO.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
            "Все текущие параметры и данные измерений будут потеряны. Продолжить?",
            "Подтверждение",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Information,
            MessageBoxDefaultButton.Button1,
            MessageBoxOptions.DefaultDesktopOnly);
            if (result == DialogResult.Yes)
            {
                _Analis.NoCaIzm1 = numericUpDown3.Text;
                _Analis.NoCaSer1 = numericUpDown4.Text;
                _Analis.Description = textBox1.Text;
                _Analis.F1 = textBox2.Text;
                _Analis.F2 = textBox3.Text;
                _Analis.errorMethod = textBox4.Text;
                _Analis.DateTime = dateTimePicker1.Value.Date.ToString("dd.MM.yyyy");
                _Analis.index = Opt_dlin_cuvet.SelectedIndex;

                _Analis.Table2Create();
            }
            this.TopMost = true;
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void USE_KO_Click(object sender, EventArgs e)
        {
            if (sender is CheckBox)
                ((CheckBox)sender).Checked = !((CheckBox)sender).Checked;
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (e.KeyChar == 46 && textBox2.Text.IndexOf(',') == -1)
            {
                e.KeyChar = ',';

            }
            else
            {

                if (e.KeyChar == 46 && textBox2.Text.IndexOf(',') != -1)
                {
                    e.Handled = true;
                    return;
                }

            }
            if (number == 44 && textBox2.Text.IndexOf(',') != -1)
            {
                e.Handled = true;
                return;
            }
            if ((number == 45 && textBox2.Text.IndexOf('-') != -1) || (number == 43 && textBox2.Text.IndexOf('+') != -1))
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
            if ((number == 45 && textBox3.Text.IndexOf('-') != -1) || (number == 43 && textBox3.Text.IndexOf('+') != -1))
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
    }
}
