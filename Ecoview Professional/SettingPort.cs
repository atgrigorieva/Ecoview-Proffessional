using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ecoview_Professional
{
    public partial class SettingPort : Form
    {
      //  bool nonPort;
    //    public string portsName; //Имя порта
        Conection _Conection;
       // public SettingPort(bool nonPort, string portsName)
        public SettingPort(Conection parent)
        {
            InitializeComponent();
            this._Conection = parent;
            //this.nonPort = nonPort;
            //this.portsName = portsName;


            //CO();
            // SW();
            // InitializeTimer();
            string[] ports = SerialPort.GetPortNames();

            try
            {
                for (int i = 0; i < ports.Length; i++)
                {
                    SerialPort newPort = new SerialPort();

                    // настройки порта (Communication interface)
                    newPort.PortName = ports[i];
                    newPort.BaudRate = 19200;
                    newPort.DataBits = 8;
                    newPort.Parity = System.IO.Ports.Parity.None;
                    newPort.StopBits = System.IO.Ports.StopBits.One;
                    // Установка таймаутов чтения/записи (read/write timeouts)
                    newPort.ReadTimeout = 100;
                    newPort.WriteTimeout = 100;
                    //    newPort.DataReceived += new SerialDataReceivedEventHandler(newPort_DataReceived);
                    newPort.RtsEnable = false;
                    newPort.DtrEnable = true;
                    newPort.Open();// MessageBox.Show("ПОРТ ОТКРЫТ " + newPort.PortName);
                    newPort.Write("^*^\r");
                    int byteRecieved = newPort.ReadBufferSize;
                    System.Threading.Thread.Sleep(50);
                    byte[] buffer = new byte[byteRecieved];
                    try
                    {
                        newPort.Read(buffer, 0, byteRecieved);
                        newPort.DiscardInBuffer();
                        newPort.DiscardOutBuffer();
                        newPort.Close();

                    } // Читаем ответ(если ничего не пришло отваливаемся по ReadTimeout = 500
                    catch (TimeoutException)
                    { /* Девайса нет */

                        newPort.DiscardInBuffer();
                        newPort.DiscardOutBuffer();
                        newPort.Close();
                        ports[i] = null;
                        ports = ports.Where(x => x != null).ToArray();
                        i--;

                    }

                }
                string s1 = "";
                StreamReader fs = new StreamReader(@"pribor/openport.port");
                string s = "";


                s = fs.ReadLine();
                s1 = s;
                fs.Close();

                selectPort.Items.Clear();
                selectPort.Items.AddRange(ports);
                if (ports.Length != 0 && s1 == Convert.ToString(0))
                {
                    selectPort.SelectedIndex = 0;
                    _Conection.nonPort = true;
                }
                else
                {
                    if (ports.Length != 0 && s != Convert.ToString(0))
                    {
                        int index = selectPort.FindString(s1);
                        if (index != -1)
                        {
                            selectPort.SelectedIndex = index;
                            _Conection.nonPort = true;
                        }
                        else
                        {
                            selectPort.SelectedIndex = 0;
                            _Conection.nonPort = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Подсоедините спектрофотометр и попробуйте подключиться снова!");
                        _Conection.nonPort = false;
                        Close();
                        // Dispose();
                    }
                }

            }
            catch
            {
                MessageBox.Show("Порт занят! Освободите порт!");
            }
        }

        private void SettingPort_Load(object sender, EventArgs e)
        {

        }

        private void SettingPort_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_Conection.nonPort == false)
            {
                _Conection.nonPort = false;
                MessageBox.Show("Порт не выбран!");
                Close();
            }
            else
            {
                _Conection.nonPort = true;
                Close();
            }
        }

        private void conection_Click(object sender, EventArgs e)
        {
            _Conection.portsName = selectPort.SelectedItem.ToString();

            Close();
        }
    }
}
