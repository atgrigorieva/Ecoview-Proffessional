using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Ecoview_Professional
{
    class SAGEScan
    {
        public SAGEScan(ref double[] scan_massSA, ref double[] scan_mass, ref string versionPribor, ref SerialPort newPort, ref int countscan, ref bool ResponseModeNormal)
        {
            int countSA;
            Regex regex1;
            bool message1 = true;
            if (versionPribor.Contains("2"))
            { countSA = 8; }
            else
            {
                countSA = 4;
            }

            LogoForm logoform = new LogoForm();
            string GE5_1 = "";
            string indata = newPort.ReadExisting();
            int indata_zero = 0;
            string indata_0 = "";
            bool indata_bool = true;
            int GEbyteRecieved4_1 = newPort.ReadBufferSize;
            byte[] GEbuffer4_1 = new byte[GEbyteRecieved4_1];
            Regex regex = new Regex(@"\W");

            newPort.Write("SA " + countSA + "\r");

            indata = newPort.ReadExisting();
            indata_zero = 0;
            indata_0 = "";
            indata_bool = true;
            while (indata_bool == true)
            {

                if (indata.Contains(">"))
                {

                    indata_bool = false;

                }

                else {
                    indata = newPort.ReadExisting();

                }
            }
   
            newPort.Write("GE 1\r");

            indata_0 = "";
            int index = 0;
            if (ResponseModeNormal == true)
            {
                Thread.Sleep(3);
            }
            else
            {
                //Thread.Sleep(1000);
            }
            indata = newPort.ReadExisting();
            indata_0 = indata;
            if (indata_0.Contains("\r>"))
            {
                indata_0 += indata;

            }
            else
            {
                while (!(indata_0.Contains("\r>")))
                {
                    indata = newPort.ReadExisting();
                    indata_0 += indata;
                }
            }
            /*for (int i = 0; i <= 5000000; i++)
            {
                indata = newPort.ReadExisting();
                if (indata_0.Contains("\r>"))
                {
                    break;
                }
                indata_0 += indata;
            }*/


            int index1 = 0;
            int countSub = 0;
            while ((index = indata_0.IndexOf("\r", index)) != -1)
            {
                // Console.WriteLine(index);
                index += "\r".Length;
                if (countSub < 2)
                {
                    index1 = index;
                }
                countSub++;
            }
            if (countSub > 2)
            {
                indata_0 = indata_0.Substring(0, index1);
            }
            indata_zero = 0;
        
            indata_bool = true;

            regex = new Regex(@"\W");
            regex1 = new Regex(@"\D");
            GE5_1 = regex.Replace(indata_0, "");
            GE5_1 = regex1.Replace(GE5_1, "");

            string GE5_1_0 = regex.Replace(indata_0, "");
            GE5_1_0 = regex1.Replace(GE5_1, "");

            double GAText1 = (Convert.ToDouble(GE5_1_0) / Convert.ToDouble(GE5_1_0)) * 100;

            double OptPlot = Math.Log10(Convert.ToDouble(GE5_1_0) / Convert.ToDouble(GE5_1));

            double OptPlot1 = OptPlot - Math.Truncate(OptPlot);
          
            while (Convert.ToInt32(GE5_1) > 10000 && countSA > 1)
            {
                countSA--;
                newPort.Write("SA " + countSA + "\r");
                int SAAnalisByteRecieved1_1_1 = newPort.ReadBufferSize;
                // Thread.Sleep(100);
                indata = newPort.ReadExisting();
                indata_zero = 0;
                indata_0 = "";
                indata_bool = true;
                while (indata_bool == true)
                {

                    if (indata.Contains(">"))
                    {

                        indata_bool = false;

                    }

                    else {
                        indata = newPort.ReadExisting();
                    }
                }
             
                newPort.Write("GE 1\r");
                
                indata_0 = "";
                index = 0;
                if (ResponseModeNormal == true)
                {
                    Thread.Sleep(3);
                }
                else
                {
                    //Thread.Sleep(1000);
                }
                indata = newPort.ReadExisting();
                indata_0 = indata;
                if (indata_0.Contains("\r>"))
                {
                    indata_0 += indata;

                }
                else
                {
                    while (!(indata_0.Contains("\r>")))
                    {
                        indata = newPort.ReadExisting();
                        indata_0 += indata;
                    }
                }
                /*for (int i = 0; i <= 5000000; i++)
                {
                    indata = newPort.ReadExisting();
                    if (indata_0.Contains("\r>"))
                    {
                        break;
                    }
                    indata_0 += indata;
                }*/
                index = 0;
                index1 = 0;
                countSub = 0;
                while ((index = indata_0.IndexOf("\r", index)) != -1)
                {
                    // Console.WriteLine(index);
                    index += "\r".Length;
                    if (countSub < 2)
                    {
                        index1 = index;
                    }
                    countSub++;
                }
                if (countSub > 2)
                {
                    indata_0 = indata_0.Substring(0, index1);
                }
                indata_zero = 0;
               
                indata_bool = true;
                

                regex = new Regex(@"\W");
                regex1 = new Regex(@"\D");
                GE5_1 = regex.Replace(indata_0, "");
                GE5_1 = regex1.Replace(GE5_1, "");

                GE5_1_0 = regex.Replace(indata_0, "");
                GE5_1_0 = regex1.Replace(GE5_1, "");

               

                GAText1 = (Convert.ToDouble(GE5_1_0) / Convert.ToDouble(GE5_1_0)) * 100;

                

                OptPlot = Math.Log10(Convert.ToDouble(GE5_1_0) / Convert.ToDouble(GE5_1));

                OptPlot1 = OptPlot - Math.Truncate(OptPlot);
        
            }
            Application.OpenForms["LogoForm"].Close();
            //  listBox1.Items.Add(GE5_1_0);
            scan_mass[countscan] = Convert.ToDouble(GE5_1_0);
            scan_massSA[countscan] = Convert.ToDouble(countSA);
        }
    }
}
