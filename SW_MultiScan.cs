using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ecoview_Professional
{
    class SW_MultiScan
    {
        Ecoview _Analis;
        public SW_MultiScan(Ecoview parent)
        {
            this._Analis = parent;
            Application.DoEvents();
            string SWText1 = _Analis.textBoxCO[_Analis.countscan].Text;
            double Walve_double = Convert.ToDouble(_Analis.textBoxCO[_Analis.countscan].Text.Replace(".", ","));
            _Analis.newPort.Write("SW " + Walve_double.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")) + "\r");
            // Thread.Sleep(100);
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
            _Analis.GWNew.Text = string.Format("{0:0.0}", _Analis.textBoxCO[_Analis.countscan].Text);
            Application.DoEvents();
        }
    }
}
