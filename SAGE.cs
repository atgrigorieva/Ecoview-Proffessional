using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using SWF = System.Windows.Forms;

namespace Ecoview_Professional
{
    class SAGE
    {



        public SAGE(ref int countSA, ref string GE5_1_0, ref string versionPribor, ref SerialPort newPort)
        {
            if (versionPribor.Contains("2"))
            { countSA = 8; }
            else
            {
                countSA = 4;
            }

            LogoForm logoform = new LogoForm();

            newPort.Write("SA " + countSA + "\r");

            string indata = newPort.ReadExisting();

            string indata_0;
            bool indata_bool = true;
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
            for (int i = 0; i <= 5000000; i++)
            {
                indata = newPort.ReadExisting();
                if (indata_0.Contains("\r>"))
                {
                    break;
                }
                indata_0 += indata;
            }
            int indata_zero = 0;
            indata_bool = true;

            string GE5_1 = "";
            Regex regex = new Regex(@"\W");
            Regex regex1 = new Regex(@"\D");
            GE5_1 = regex.Replace(indata_0, "");
            GE5_1 = regex1.Replace(GE5_1, "");

            GE5_1_0 = regex.Replace(indata_0, "");
            GE5_1_0 = regex1.Replace(GE5_1, "");
            //GEText.Text = GE5_1_0;
            //if(GE5_1 == "")
            {
                double GAText1 = (Convert.ToDouble(GE5_1_0) / Convert.ToDouble(GE5_1_0)) * 100;

                // GAText.Text = string.Format("{0:0.00}", GAText1);

                double OptPlot = Math.Log10(Convert.ToDouble(GE5_1_0) / Convert.ToDouble(GE5_1));

                double OptPlot1 = OptPlot - Math.Truncate(OptPlot);
                //  OptichPlot.Text = string.Format("{0:0.0000}", OptPlot1);
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
                    for (int i = 0; i <= 5000000; i++)
                    {
                        indata = newPort.ReadExisting();
                        if (indata_0.Contains("\r>"))
                        {
                            break;
                        }
                        indata_0 += indata;
                    }
                    indata_zero = 0;
                    indata_bool = true;

                    regex = new Regex(@"\W");
                    regex1 = new Regex(@"\D");
                    GE5_1 = regex.Replace(indata_0, "");
                    GE5_1 = regex1.Replace(GE5_1, "");

                    GE5_1_0 = regex.Replace(indata_0, "");
                    GE5_1_0 = regex1.Replace(GE5_1, "");
                    //GEText.Text = GE5_1_0;
                    //   if (GE5_1 == "")
                    {
                        GAText1 = (Convert.ToDouble(GE5_1_0) / Convert.ToDouble(GE5_1_0)) * 100;


                        //    GAText.Text = string.Format("{0:0.00}", GAText1);

                        OptPlot = Math.Log10(Convert.ToDouble(GE5_1_0) / Convert.ToDouble(GE5_1));

                        OptPlot1 = OptPlot - Math.Truncate(OptPlot);
                        //   OptichPlot.Text = string.Format("{0:0.0000}", OptPlot1);
                    }

                }

            }

            SWF.Application.OpenForms["LogoForm"].Close();


        }

    }





}
