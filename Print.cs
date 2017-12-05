using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ecoview_Professional
{
    class Print
    {
        Ecoview _Analis;
        public Print(Ecoview parent)
        {
            this._Analis = parent;
            string str = "";
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                str += PrinterSettings.InstalledPrinters[i] + "\n";
            }

            if (str != "")
            {
                switch (_Analis.selet_rezim)
                {
                    case 2:
                        if (_Analis.tabControl2.SelectedIndex == 0 && _Analis.SposobZadan == "По СО")
                        {
                            _Analis.PrintDoc();
                        }
                        else
                        {
                            if (_Analis.tabControl2.SelectedIndex == 0 && _Analis.SposobZadan != "По СО")
                            {
                                _Analis.PrintDoc1();
                            }
                            else
                            {
                                _Analis.PrintDoc2();
                            }
                        }
                        break;
                    case 1:
                        _Analis.IzmerenieFR_TablePrintDoc();
                        break;
                    case 6:
                        if (_Analis.tabControl2.SelectedIndex == 0 && _Analis.SposobZadan == "По СО")
                        {
                            _Analis.PrintDoc();
                        }
                        else
                        {
                            if (_Analis.tabControl2.SelectedIndex == 0 && _Analis.SposobZadan != "По СО")
                            {
                                _Analis.PrintDoc1();
                            }
                            else
                            {
                                _Analis.PrintDoc2();
                            }
                        }
                        break;
                    case 5:
                        // this.TopMost = false;
                        _Analis.PrintScan();
                        break;
                    case 4:
                        //    this.TopMost = false;
                        _Analis.PrintKinetica();
                        break;
                    case 3:
                        // this.TopMost = false;
                        _Analis.PrintMulti();
                        break;
                }

            }
            else
            {
                MessageBox.Show("Внимание! Принтер не найден! Подключите принтер!");
            }

        }
    }
}
