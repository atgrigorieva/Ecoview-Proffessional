using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SWF = System.Windows.Forms;

namespace Ecoview_Professional
{
    class PortClose
    {
        Ecoview _Analis;
        public PortClose(Ecoview parent)
        {
            this._Analis = parent;
            try
            {
                if (_Analis.ComPort == true)
                {
                    char[] ClosePribor = { Convert.ToChar('Q'), Convert.ToChar('U'), Convert.ToChar('\r') };
                    _Analis.newPort.Write("QU\r");
                    Thread.Sleep(500);
                    //  byte[] buffer1 = new byte[byteRecieved1];
                    string indata = _Analis.newPort.ReadExisting();
                    bool indata_bool = true;
                    while (indata_bool == true)
                    {
                        if (indata.Contains(">"))
                        {

                            indata_bool = false;

                        }

                        else {
                            indata = _Analis.newPort.ReadExisting();
                        }
                    }

                    _Analis.GWNew.Text = null;
                  //  _Analis.GEText.Text = null;
                  //  _Analis.GAText.Text = null;
                  //  _Analis.OptichPlot.Text = null;
                
                    _Analis.подключитьToolStripMenuItem.Enabled = true;
                    _Analis.button2.Enabled = true;

                    _Analis.button12.Enabled = false;
                    _Analis.button14.Enabled = false;
                    _Analis.настройкаПортаToolStripMenuItem.Enabled = false;
                    _Analis.информацияToolStripMenuItem.Enabled = false;
                    _Analis.калибровкаToolStripMenuItem.Enabled = false;
                    _Analis.темновойТокToolStripMenuItem.Enabled = false;
                    _Analis.измеритьToolStripMenuItem.Enabled = false;

                    _Analis.калибровкаДляОдноволновогоАнализаToolStripMenuItem.Enabled = false;
                    _Analis.button1.Enabled = false;

                    _Analis.newPort.Close();
                    _Analis.wavelength1 = Convert.ToString(0);
                    // ComPort = false;
                    _Analis.ComPort = false;
                    _Analis.ComPodkl = false;
                    _Analis.label27.Visible = false;
                    _Analis.label24.Visible = true;
                    _Analis.label28.Visible = false;
                    _Analis.label33.Visible = false;
                    _Analis.label25.Visible = false;
                    _Analis.label26.Visible = false;
                    _Analis.label59.Visible = false;
                    _Analis.Podskazka.Text = "Подключите прибор!";
                }
            }
            catch
            {
                MessageBox.Show("Прервана связь с прибором. Подключитесь снова!");
                SWF.Application.OpenForms["LogoFrm"].Close();
                _Analis.GWNew.Text = null;
               

                _Analis.подключитьToolStripMenuItem.Enabled = true;
                _Analis.button2.Enabled = true;
                _Analis.button11.Enabled = false;
                _Analis.button12.Enabled = false;
                _Analis.button14.Enabled = false;
                _Analis.настройкаПортаToolStripMenuItem.Enabled = false;
                _Analis.информацияToolStripMenuItem.Enabled = false;
                _Analis.калибровкаToolStripMenuItem.Enabled = false;
                _Analis.темновойТокToolStripMenuItem.Enabled = false;
                _Analis.измеритьToolStripMenuItem.Enabled = false;

                _Analis.калибровкаДляОдноволновогоАнализаToolStripMenuItem.Enabled = false;
                _Analis.button1.Enabled = false;
                _Analis.label28.Visible = false;
                _Analis.label33.Visible = false;
				if(_Analis.versionPribor != null && _Analis.versionPribor != "")
				{
					_Analis.newPort.Close();
				}
                _Analis.wavelength1 = Convert.ToString(0);
                // ComPort = false;
                _Analis.ComPort = false;
                _Analis.ComPodkl = false;
                _Analis.StopSpectr = true;
                _Analis.StopAgro = true;

                if (_Analis.timer2.Enabled == true)
                {
                    _Analis.timer2.Enabled = true;
                    _Analis.timer2.Stop();
                   // _Analis.MinMax();
                    //button14.Enabled = true;
                    _Analis.button11.Enabled = false;

                }
                _Analis.label27.Visible = false;
                _Analis.label24.Visible = true;
                _Analis.label28.Visible = false;
                _Analis.label25.Visible = false;
                _Analis.label26.Visible = false;
                _Analis.label33.Visible = false;
                return;
            }
        }
    }
}
