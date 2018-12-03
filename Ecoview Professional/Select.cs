using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecoview_Professional
{
    public partial class Select : Form
    {
       public bool searchKeyNotFound = false;
        public Select()
        {
            InitializeComponent();
            try
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                string versionURL = "http://pe-lab.ru/ecoview-version/version-prof";

                if (label1.Text.Substring(16) == wc.DownloadString(versionURL))
                {

                    label1.Text = "";
                    label1.ForeColor = Color.Black;
                }
                else
                {
                    label1.Text = "Внимание! Доступна новая версия " + wc.DownloadString(versionURL);
                    label1.ForeColor = Color.Red;
                }
                label1.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Italic);
                //label1.Location = new Point(204, 115);

            }

            catch
            {
                label1.Text = "";
            }

        }
        bool click = false;
        int selet_rezim;
        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                selet_rezim = 1;

            }
            else
            {
                if (radioButton2.Checked == true)
                {
                    selet_rezim = 2;
                }
                else
                {
                    if (radioButton3.Checked == true)
                    {
                        selet_rezim = 3;
                    }
                    else
                    {
                        if (radioButton4.Checked == true)
                        {
                            selet_rezim = 4;
                        }
                        else
                        {
                            if (radioButton7.Checked == true)
                            {
                                //SearchGuardant serachkey = new SearchGuardant(ref searchKeyNotFound);
                                selet_rezim = 5;
                                searchKeyNotFound = true;

                            }
                            else
                            {
                                /*if (radioButton6.Checked == true)
                                {                               
                                    
                                    selet_rezim = 6;
                                }
                                else
                                {*/
                                    if (radioButton5.Checked == true)
                                    {
                                        selet_rezim = 9;
                                    }
                                //}
                            }

                        }
                    }
                }
            }


            if (searchKeyNotFound == true || selet_rezim != 5)
            {
                Hide();
                Ecoview f2 = new Ecoview(selet_rezim);
                f2.ShowDialog();
                this.Dispose();
            }
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            click = false;
            Application.Exit();
        }

        private void Select_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (click != true)
            {
                
                System.Windows.Forms.Application.ExitThread();

            }
        }

        private void Select_Load(object sender, EventArgs e)
        {
           
        }
    }
}
