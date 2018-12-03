using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecoview_Professional
{
    public class Conection
    {
        Ecoview _Analis;
        public Conection(Ecoview parent)
        {
            this._Analis = parent;
            COnectionPort();


        }
        public bool nonPort;
        public string portsName;
        public SerialPort newPort;
        public string[] RDstring;
        public int countSA;
        public string GE5_1_0 = "";
        public int indata_zero;
        public string versionPribor; //версия прибора
        public string wavelength1;
        public TextBox GWNew;
        public string GW1_2;
        string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/";
        public void COnectionPort()
        {
            // SettingPort _SettingPort = new SettingPort(_Analis.nonPort, _Analis.portsName);
            newPort = new SerialPort();
            SettingPort _SettingPort = new SettingPort(this);
            _Analis.newPort = newPort;
            _Analis.nonPort = nonPort;
            _Analis.portsName = portsName;
            if (_Analis.nonPort == true)
            {
                _SettingPort.ShowDialog();
            }
            else
            {
                _SettingPort.Dispose();
            }
            _Analis.newPort = newPort;
            _Analis.nonPort = nonPort;
            _Analis.portsName = portsName;
            if (_Analis.nonPort == true)
            {
                _Analis.newPort = new SerialPort();

                try
                {
                    // настройки порта (Communication interface)
                    _Analis.newPort.PortName = _Analis.portsName;
                    _Analis.newPort.BaudRate = 19200;
                    _Analis.newPort.DataBits = 8;
                    _Analis.newPort.Parity = System.IO.Ports.Parity.None;
                    _Analis.newPort.StopBits = System.IO.Ports.StopBits.One;
                    // Установка таймаутов чтения/записи (read/write timeouts)
                    //_Analis.newPort.ReadTimeout = 20000;
                    //_Analis.newPort.WriteTimeout = 1;
                    //    newPort.DataReceived += new SerialDataReceivedEventHandler(newPort_DataReceived);
                    _Analis.newPort.RtsEnable = false;
                    _Analis.newPort.DtrEnable = true;
                    _Analis.newPort.Open();// MessageBox.Show("ПОРТ ОТКРЫТ " + newPort.PortName);


                    _Analis.newPort.DiscardInBuffer();
                    _Analis.newPort.DiscardOutBuffer();
                }
                catch (Exception)
                {
                    MessageBox.Show("Порт не был выбран!");
                    return;

                }
                newPort = _Analis.newPort;
                string openport = path + "/pribor/openport.port";
                File.WriteAllText(openport, string.Empty);
                File.AppendAllText(openport, _Analis.portsName, Encoding.UTF8);
                string pathTemp = Path.GetTempPath();
                EncriptorPribor encriptSerNomer = new EncriptorPribor(openport, pathTemp);

                _Analis.newPort.Write("CO\r");
                GWNew = _Analis.GWNew;
                wavelength1 = GWNew.Text;
                SettingWL setingwl = new SettingWL(this);
                _Analis.nonPort = nonPort;
                _Analis.portsName = portsName;
                //CO();
                RD rd = new RD(this);
                newPort = _Analis.newPort;
                _Analis.RDstring = RDstring;
                _Analis.ComPodkl = true;

                //sage.SAGE1(this);
                SAGE sage = new SAGE(ref _Analis.countSA, ref _Analis.GE5_1_0, ref versionPribor, ref newPort, ref _Analis.ResponseModeNormal);
                _Analis.versionPribor = versionPribor;
                if (_Analis.textBox10.Text != "")
                {
                    SW();
                    _Analis.GWNew.Text = _Analis.wavelength1;
                    SAGE sage1 = new SAGE(ref _Analis.countSA, ref _Analis.GE5_1_0, ref versionPribor, ref newPort, ref _Analis.ResponseModeNormal);
                }

                _Analis.ComPort = true;
                _Analis.подключитьToolStripMenuItem.Enabled = false;
                _Analis.настройкаПортаToolStripMenuItem.Enabled = true;
                _Analis.информацияToolStripMenuItem.Enabled = true;
                _Analis.калибровкаToolStripMenuItem.Enabled = true;
                _Analis.темновойТокToolStripMenuItem.Enabled = true;
                _Analis.измеритьToolStripMenuItem.Enabled = true;
                _Analis.измеритьToolStripMenuItem.Enabled = true;
                _Analis.измеритьToolStripMenuItem.Enabled = true;
                _Analis.калибровкаДляОдноволновогоАнализаToolStripMenuItem.Enabled = true;
                _Analis.button1.Enabled = true;
                _Analis.button2.Enabled = false;

                _Analis.button12.Enabled = true;
                if ((_Analis.OpenIzmer == true && _Analis.ComPort == true) || (_Analis.OpenIzmer1 == true && _Analis.ComPort == true))
                {
                    _Analis.button14.Enabled = true;
                }
                else
                {
                    _Analis.button14.Enabled = false;
                }
                if (_Analis.ComPort == true)
                {
                    _Analis.button14.Enabled = true;
                }
                else
                {
                    _Analis.button14.Enabled = false;
                }
                if (_Analis.SposobZadan == "Ввод коэффициентов")
                {
                    _Analis.button14.Enabled = false;
                }
                else
                {
                    _Analis.button14.Enabled = true;
                }
                switch (_Analis.selet_rezim)
                {
                    case 2:
                        _Analis.Podskazka.Text = "Создайте или откройте Градуировку!";
                        _Analis.label25.Visible = true;
                        _Analis.label26.Visible = true;
                        if (_Analis.tabControl2.SelectedTab == _Analis.tabPage4 && _Analis.Table2.Rows.Count > 0)
                        {
                            _Analis.button14.Enabled = true;
                        }
                        break;
                    case 6:
                        _Analis.Podskazka.Text = "Создайте или откройте Градуировку!";
                        _Analis.label25.Visible = true;
                        _Analis.label26.Visible = true;
                        break;
                    case 5:
                        _Analis.Podskazka.Text = "Создайте Измерение";
                        _Analis.label25.Visible = true;
                        _Analis.label26.Visible = false;
                        break;
                    case 9:
                        _Analis.Podskazka.Text = "Создайте Измерение";
                        _Analis.button14.Enabled = false;
                        _Analis.button12.Enabled = false;
                        _Analis.button6.Enabled = false;
                        _Analis.button7.Enabled = false;
                        _Analis.button8.Enabled = false;
                        _Analis.label25.Visible = true;
                        _Analis.label26.Visible = false;

                        //    button5.Enabled = true;
                        break;
                    case 3:
                        _Analis.Podskazka.Text = "Создайте Измерение";
                        _Analis.button14.Enabled = false;
                        _Analis.button12.Enabled = false;
                        _Analis.button6.Enabled = true;
                        _Analis.button7.Enabled = false;
                        _Analis.button8.Enabled = false;
                        _Analis.label25.Visible = true;
                        _Analis.label26.Visible = false;
                        break;
                    case 4:
                        _Analis.Podskazka.Text = "Создайте Измерение";
                        _Analis.button14.Enabled = false;
                        _Analis.button12.Enabled = false;
                        _Analis.button6.Enabled = true;
                        _Analis.button7.Enabled = false;
                        _Analis.button8.Enabled = false;
                        _Analis.label25.Visible = true;
                        _Analis.label26.Visible = false;
                        break;
                    default:
                        _Analis.Podskazka.Text = "Создайте или откройте Измерение";

                        _Analis.label25.Visible = true;
                        _Analis.label26.Visible = true;
                        break;
                }
                _Analis.label27.Visible = false;
                _Analis.label24.Visible = false;
                _Analis.label28.Visible = false;
                _Analis.label33.Visible = false;



            }


        }
        public void SW()
        {
            LogoForm2 logoform = new LogoForm2();
            WL_grad_Leave();
            _Analis.wavelength1 = _Analis.textBox10.Text;
            string SWText1 = _Analis.textBox10.Text;
            double Walve_double = Convert.ToDouble(_Analis.textBox10.Text.Replace(".", ","));
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


            Application.OpenForms["LogoForm2"].Close();
            // _Analis.GW();
        }
        private void WL_grad_Leave()
        {

            if (_Analis.textBox10.Text != "")
            {
                if (_Analis.versionPribor.Contains("V"))
                {
                    if (Convert.ToDouble(_Analis.textBox10.Text.Replace(".", ",")) < 315)
                    {
                        _Analis.textBox10.Text = Convert.ToString(315);
                    }
                    if (Convert.ToDouble(_Analis.textBox10.Text.Replace(".", ",")) > 1050)
                    {
                        _Analis.textBox10.Text = Convert.ToString(1050);
                    }
                }
                else
                {
                    if (_Analis.versionPribor.Contains("U") && _Analis.versionPribor.Contains("2"))
                    {
                        if (Convert.ToDouble(_Analis.textBox10.Text.Replace(".", ",")) < 190)
                        {
                            _Analis.textBox10.Text = Convert.ToString(190);
                        }
                        if (Convert.ToDouble(_Analis.textBox10.Text.Replace(".", ",")) > 1050)
                        {
                            _Analis.textBox10.Text = Convert.ToString(1050);
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(_Analis.textBox10.Text.Replace(".", ",")) < 200)
                        {
                            _Analis.textBox10.Text = Convert.ToString(200);
                        }
                        if (Convert.ToDouble(_Analis.textBox10.Text.Replace(".", ",")) > 1050)
                        {
                            _Analis.textBox10.Text = Convert.ToString(1050);
                        }
                    }
                }
            }
        }

    }
}
