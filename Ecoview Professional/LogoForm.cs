using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecoview_Professional
{
    class LogoForm
    {
        public LogoForm()
        {
            Form LogoForm = new Form();
            // LogoForm.BackColor = System.Drawing.Color.White;
            LogoForm.BackgroundImage = System.Drawing.Image.FromFile("Calibrovka.png");
            LogoForm.AutoScaleMode = AutoScaleMode.Font;
            LogoForm.Size = new Size(430, 107);
            LogoForm.Text = "Калибровка...";
            LogoForm.MinimizeBox = false;
            LogoForm.MaximizeBox = false;
            LogoForm.AutoSize = false;
            LogoForm.Name = "LogoForm";
            LogoForm.ShowInTaskbar = false;
            LogoForm.StartPosition = FormStartPosition.CenterScreen;
            LogoForm.ControlBox = false;
            LogoForm.FormBorderStyle = FormBorderStyle.None;
            /*PictureBox PicBox = new PictureBox();
            PicBox.Size = new Size(307, 179);
            PicBox.Location = new System.Drawing.Point(12, 12);
            PicBox.ImageLocation = "D:\\Analis-samo\\Analis200\\Analis200\bin\x64\\Release\\Calibrovka.png";
            PicBox.SizeMode = PictureBoxSizeMode.Zoom;
            LogoForm.Controls.Add(PicBox);*/
            LogoForm.Show();
        }
    }
}
