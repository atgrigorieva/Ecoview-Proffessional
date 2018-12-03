using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Ecoview_Professional
{
    class Calibrovka
    {
        Ecoview _Analis;
        public Calibrovka(Ecoview parent)
        {
            this._Analis = parent;

            _Analis.button1.Enabled = false;
            try
            {
                _Analis.label59.Visible = false;
                switch (_Analis.selet_rezim)
                {
                    case 5:
                        _Analis.StopSpectr = false;
                        _Analis.countscan = 0;
                        _Analis.scan_massSA = new double[_Analis.ScanTable.Rows.Count - 1];
                        _Analis.scan_mass = new double[_Analis.ScanTable.Rows.Count - 1];
                        ///MessageBox.Show("Hello");
                        Application.DoEvents();
                        LogoForm logoform1 = new LogoForm();
                        while ((_Analis.countscan != _Analis.ScanTable.Rows.Count - 1) && (_Analis.StopSpectr != true))
                        {

                            Application.DoEvents();
                            _Analis.label33.Visible = true;
                            _Analis.Podskazka.Text = "Можно остановить";
                            Application.DoEvents();
                            _Analis.GWNew.Text = string.Format("{0:0.0}", _Analis.ScanTable.Rows[_Analis.countscan].Cells[0].Value.ToString());
                            _Analis.SW_Scan();
                            Thread.Sleep(50);
                            _Analis.SAGEScan(ref _Analis.countSA, ref _Analis.GE5_1_0);
                            Application.DoEvents();


                            _Analis.countscan++;
                        }
                        Application.OpenForms["LogoForm"].Close();
                        MessageBox.Show("Калибровка закончена!");
                        _Analis.Podskazka.Text = "Можно сканировать";
                        _Analis.label59.Visible = false;
                        _Analis.label28.Visible = true;
                        _Analis.label25.Visible = false;
                        _Analis.label26.Visible = false;
                        _Analis.label33.Visible = false;
                        break;
                    case 3:
                        _Analis.StopSpectr = false;
                        _Analis.countscan = 0;
                        _Analis.scan_massSA = new double[_Analis.dataGridView5.Columns.Count - 2];
                        _Analis.scan_mass = new double[_Analis.dataGridView5.Columns.Count - 2];
                        Application.DoEvents();
                        LogoForm logoform = new LogoForm();
                        while ((_Analis.countscan != _Analis.dataGridView5.Columns.Count - 2) && (_Analis.StopSpectr != true))
                        {
                            _Analis.label33.Visible = true;
                            _Analis.Podskazka.Text = "Можно остановить";
                            Application.DoEvents();
                            _Analis.SW_MultiScan();
                            Application.DoEvents();
                            _Analis.GWNew.Text = string.Format("{0:0.0}", _Analis.textBoxCO[_Analis.countscan].Text);
                            _Analis.button12.Enabled = false;
                            _Analis.button14.Enabled = false;
                            _Analis.button11.Enabled = true;
                            SAGEScan sageScan = new SAGEScan(ref _Analis.scan_massSA, ref _Analis.scan_mass, ref _Analis.versionPribor, ref _Analis.newPort, ref _Analis.countscan, ref _Analis.ResponseModeNormal);
                            Application.DoEvents();
                            _Analis.countscan++;
                        }
                        Application.OpenForms["LogoForm"].Close();
                        _Analis.button12.Enabled = true;
                        _Analis.button14.Enabled = true;
                        _Analis.button11.Enabled = false;
                        MessageBox.Show("Калибровка закончена!");
                        _Analis.label59.Visible = false;
                        _Analis.label28.Visible = true;
                        _Analis.label25.Visible = false;
                        _Analis.label26.Visible = false;
                        _Analis.Podskazka.Text = "Можно сканировать";
                        _Analis.label33.Visible = false;
                        break;

                    default:
                        SAGE sage = new SAGE(ref _Analis.countSA, ref _Analis.GE5_1_0, ref _Analis.versionPribor, ref _Analis.newPort, ref _Analis.ResponseModeNormal);
                        MessageBox.Show("Калибровка закончена!");
                        _Analis.label59.Visible = false;
                        _Analis.label28.Visible = true;
                        _Analis.label25.Visible = false;
                        _Analis.label26.Visible = false;
                        _Analis.label27.Visible = false;
                        _Analis.label33.Visible = false;
                        _Analis.Podskazka.Text = "Можно сканировать";
                        break;

                }
                //  _Analis.button3.Enabled = true;
                _Analis.Podskazka.Text = "Можно сканировать";
                _Analis.button1.Enabled = true;

                _Analis.label33.Visible = false;
            }
            catch
            {

            }
        }
    }
}
