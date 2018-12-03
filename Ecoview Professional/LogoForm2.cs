using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecoview_Professional
{
    class LogoForm2
    {
        public LogoForm2()
        {
            Form LogoForm2 = new Form();
            // LogoForm.BackColor = System.Drawing.Color.White;
            LogoForm2.BackgroundImage = System.Drawing.Image.FromFile("Yasnovka_DLWALVE.png");
            LogoForm2.AutoScaleMode = AutoScaleMode.Font;
            LogoForm2.Size = new Size(430, 107);
            LogoForm2.Text = "Установка длины волны...";
            LogoForm2.MinimizeBox = false;
            LogoForm2.MaximizeBox = false;
            LogoForm2.AutoSize = false;
            LogoForm2.Name = "LogoForm2";
            LogoForm2.ShowInTaskbar = false;
            LogoForm2.StartPosition = FormStartPosition.CenterScreen;
            LogoForm2.ControlBox = false;
            LogoForm2.FormBorderStyle = FormBorderStyle.None;

            LogoForm2.Show();
        }
    }
}
