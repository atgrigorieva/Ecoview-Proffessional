using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Ecoview_Professional
{
   public class CreateDimension
    {
        Ecoview _Analis;
        public string GWString;
        public int countSTR;
        public string k1_linear0;
        public string Description;
        public string DateTime;
        public string Ispolnitel;
        public string direction;
        public string code;
        public TextBox[] textBox = new TextBox[20];
        public TextBox[] textBoxCO = new TextBox[20];
        public int NoCoIzmer;
        public string edconctr;
        public string SposobZadan;
        public string Zavisimoct;
        public string aproksim;
        public bool ResponseModeNormal = true;
        public string Veshestvo1;
        public string WidthCuvette;
        public string ND;
        public int Days;
        public string CountSeriya, CountInSeriya, NoCaIzm1, NoCaSer1;
        public string BottomLine, TopLine;
        public double k0, k1, k2;
        public bool USE_KO;
        public string F1, F2, errorMethod;
        public double start = 0.0, cancel = 0.0, interval, delay;
        public double[] massWL;
        public double[] massGE;
        public string[][,] countScan;
        public int countscan = 0;
        public string typeIzmer;
        public int index;
        public OpenFileDialog openFileDialog1;
        public string filepath;
        public CreateDimension(Ecoview parent)
        {
            this._Analis = parent;
            Description = _Analis.Description;
            DateTime = _Analis.DateTime;
            Ispolnitel = _Analis.Ispolnitel;
            direction = _Analis.direction;
            code = _Analis.code;
            k0 = _Analis.k0; k1 = _Analis.k1; k2 = _Analis.k2;
            USE_KO = _Analis.USE_KO;
            Zavisimoct = _Analis.Zavisimoct;
            aproksim = _Analis.aproksim;
            CountSeriya = _Analis.CountSeriya;
            CountInSeriya = _Analis.CountInSeriya;
            SposobZadan = _Analis.SposobZadan;
            edconctr = _Analis.edconctr;
            Days = _Analis.Days;
            if (_Analis.ComPort == true)
            {
                GWString = _Analis.GWNew.Text;
            }
            else
            {
                GWString = _Analis.wavelength1;
            }


                switch (_Analis.selet_rezim)
                {
                    case 1:
                        if (_Analis.ComPodkl == true)
                        {
                            GWString = _Analis.GWNew.Text;
                            countSTR = 0;
                            IzmerenieFR izmereneFR = new IzmerenieFR(this, _Analis.versionPribor);
                            izmereneFR.ShowDialog();
                            
                        }
                        else
                        {
                            MessageBox.Show("Для проведения измерений необхдимо подключиться к прибору!");
                        }
                        break;
                    case 2:
                        
                        if (_Analis.tabControl2.SelectedIndex == 0)
                        {
                        
                           /// if (_Analis.ComPodkl == true)
                            //{
                                _Analis.textBoxCO = textBoxCO;
                                NewGraduirovka newgrad = new NewGraduirovka(this, _Analis.versionPribor, _Analis.selet_rezim);
                                newgrad.ShowDialog();
                        // FotometrScan();


                        /*  }
                          else
                          {
                              MessageBox.Show("Для проведения сканирования необхдимо подключиться к прибору!");
                          }*/
                    }
                    else
                        {
                            k0 = Convert.ToDouble(_Analis.AgroText0.Text);
                            k1 = Convert.ToDouble(_Analis.AgroText1.Text);
                            k2 = Convert.ToDouble(_Analis.AgroText2.Text);
                            NewIzmerenie newIzmer = new NewIzmerenie(this, _Analis.versionPribor, _Analis.selet_rezim);
                            newIzmer.ShowDialog();

                            if (_Analis.ComPodkl == true)
                            {
                            // FotometrScan();

                            //  button12.Enabled = true;

                            }
                            else
                            {
                                MessageBox.Show("Для проведения сканирования необхдимо подключиться к прибору!");
                            }
                        _Analis.button3.Enabled = true;
                        _Analis.button7.Enabled = true;
                        _Analis.button8.Enabled = true;
                        _Analis.button9.Enabled = true;
                    }
                        break;
                    case 3:
                        if (_Analis.ComPodkl == true)
                        {
                            MultiWave multiWave = new MultiWave(this, _Analis.versionPribor);
                            multiWave.ShowDialog();
                            _Analis.Podskazka.Text = "Измерьте 0 Asb/100%T";
                            _Analis.label25.Visible = false;
                            _Analis.label26.Visible = false;
                            _Analis.label59.Visible = true;
                            _Analis.button12.Enabled = true;
                            _Analis.button14.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Для проведения сканирования необхдимо подключиться к прибору!");
                        }
                    break;
                    case 4:
                        if (_Analis.ComPodkl == true)
                        {
                            KineticaScan kineticaScan = new KineticaScan(this, _Analis.versionPribor);
                            kineticaScan.ShowDialog();
                            _Analis.Podskazka.Text = "Измерьте 0 Asb/100%T";
                            _Analis.label25.Visible = false;
                            _Analis.label26.Visible = false;
                            _Analis.label59.Visible = true;
                            _Analis.button12.Enabled = true;
                            _Analis.button14.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Для проведения сканирования необхдимо подключиться к прибору!");
                        }
                    break;
                case 5:
                    if (_Analis.ComPodkl == true)
                    {

                        FotometrScan fotometrScan = new FotometrScan(this, _Analis.versionPribor);
                        fotometrScan.ShowDialog();
                        _Analis.Podskazka.Text = "Измерьте 0 Asb/100%T";
                        _Analis.label25.Visible = false;
                        _Analis.label26.Visible = false;
                        _Analis.label59.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Для проведения сканирования необхдимо подключиться к прибору!");
                    }
                    break;
                case 6:
                    _Analis.Izmerenie1 = true;
                    if (_Analis.tabControl2.SelectedIndex == 0)
                    {
                        NewGraduirovka newgrad = new NewGraduirovka(this, _Analis.versionPribor, _Analis.selet_rezim);
                        newgrad.ShowDialog();
                        if (_Analis.ComPodkl == true)
                        {
                            // FotometrScan();
                            _Analis.Podskazka.Text = "Измерьте 0 Asb/100%T";
                            _Analis.label25.Visible = false;
                            _Analis.label26.Visible = false;
                            _Analis.label59.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Для проведения сканирования необхдимо подключиться к прибору!");
                        }
                    }
                    else
                    {
                        k0 = Convert.ToDouble(_Analis.AgroText0.Text);
                        k1 = Convert.ToDouble(_Analis.AgroText1.Text);
                        k2 = Convert.ToDouble(_Analis.AgroText2.Text);
                        NewIzmerenie newIzmer = new NewIzmerenie(this, _Analis.versionPribor, _Analis.selet_rezim);
                        newIzmer.ShowDialog();
                        if (_Analis.ComPodkl == true)
                        {
                            // FotometrScan();

                            //  button12.Enabled = true;

                        }
                        else
                        {
                            MessageBox.Show("Для проведения сканирования необхдимо подключиться к прибору!");
                        }
                        /*if (_Analis.ComPodkl == true)
                        {

                            // FotometrScan();
                            _Analis.Podskazka.Text = "Измерьте 0 Asb/100%T";
                            _Analis.label25.Visible = false;
                            _Analis.label26.Visible = false;
                            _Analis.label59.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("Для проведения сканирования необхдимо подключиться к прибору!");
                        }*/
                    }
                    break;
                case 9:
                        if (_Analis.ComPodkl == true)
                        {
                            ExcelResim _ExcelResim = new ExcelResim(this, _Analis.versionPribor);
                            _ExcelResim.ShowDialog();

                        }
                        else
                        {
                            MessageBox.Show("Для проведения сканирования необхдимо подключиться к прибору!");
                        }
                    break;
                }

            if (_Analis.versionPribor != "" && _Analis.versionPribor != null)
            {
                _Analis.button1.Enabled = true;
            }
            _Analis.label28.Visible = false;

        }
        public void IzmerenieFR_RowsRemove2()
        {
            _Analis.GWNew.Text = GWString;
            _Analis.IzmerenieFR_Table.Rows.Clear();
            for (int i = 0; i < countSTR; i++)
            {
                _Analis.IzmerenieFR_Table.Rows.Add();
                _Analis.IzmerenieFR_Table.Rows[i].Cells[0].Value = i + 1;
                _Analis.IzmerenieFR_Table.Rows[i].Cells[2].Value = GWString;
                _Analis.IzmerenieFR_Table.Rows[i].Cells[5].Value = string.Format("{0:0.0}", k1_linear0);
            }
            _Analis.IzmerenieFR_Table.CurrentCell = _Analis.IzmerenieFR_Table[3, 0];



            SW();
            SAGE sage = new SAGE(ref _Analis.countSA, ref _Analis.GE5_1_0, ref _Analis.versionPribor, ref _Analis.newPort, ref _Analis.ResponseModeNormal);
            _Analis.button11.Enabled = true;
            _Analis.DateTime = DateTime;
            _Analis.Ispolnitel = Ispolnitel;
            _Analis.Description = Description;
            _Analis.direction = direction;
            _Analis.code = code;
            _Analis.label26.Visible = false;
            _Analis.label25.Visible = false;
            _Analis.label59.Visible = true;
            _Analis.Podskazka.Text = "Измерьте 0 Asb/100%T";
        }
        public void GradTable()
        {
            _Analis.NoCoIzmer = NoCoIzmer;
            if (_Analis.ComPort == true && _Analis.SposobZadan != "Ввод коэффициентов")
            {
                _Analis.Podskazka.Text = "Измерьте 0 Asb/100%T";
                _Analis.label25.Visible = false;
                _Analis.label26.Visible = false;
                _Analis.label59.Visible = true;
            }
            if (_Analis.ComPort != false)
            {
                _Analis.GWNew.Text = string.Format("{0:0.0}", GWString);
                SW();
                SAGE sage = new SAGE(ref _Analis.countSA, ref _Analis.GE5_1_0, ref _Analis.versionPribor, ref _Analis.newPort, ref _Analis.ResponseModeNormal);
            }

            _Analis.textBox10.Text = string.Format("{0:0.0}", GWString);
            _Analis.DateTime = DateTime;
            _Analis.dateTimePicker1.Text = DateTime;
            _Analis.Ispolnitel = Ispolnitel;
            _Analis.Description = Description;
            _Analis.textBox1.Text = Description;
            _Analis.direction = direction;
            _Analis.code = code;
            _Analis.BottomLine = BottomLine;
            _Analis.TopLine = TopLine;
            _Analis.ND = ND;
            _Analis.Veshestvo1 = Veshestvo1;
            _Analis.Days = Days;
            _Analis.numericUpDown1.Text = Convert.ToString(Days);
            _Analis.CountSeriya = CountSeriya;
            _Analis.CountInSeriya = CountInSeriya;
            _Analis.edconctr = edconctr;
            _Analis.WidthCuvette = WidthCuvette;
            _Analis.textBox2.Text = WidthCuvette;
            _Analis.textBox3.Text = errorMethod;
            _Analis.textBox11.Text = Veshestvo1;
            _Analis.wavelength1 = GWString;

            _Analis.aproksim = aproksim;

            _Analis.SposobZadan = SposobZadan;
            _Analis.Zavisimoct = Zavisimoct;

            _Analis.USE_KO = USE_KO;
            _Analis.chart1.Series[0].Points.Clear();
            _Analis.chart1.Series[1].Points.Clear();
            WLREMOVE1();
            WLREMOVESTR1();
            _Analis.button10.Enabled = true;
            switch (_Analis.SposobZadan)
            {
                case "Ввод коэффициентов":
                    _Analis.k0 = k0;
                    _Analis.k1 = k1;
                    _Analis.k2 = k2;
                    _Analis.AgroText0.Text = string.Format("{0:0.0000}", k0);
                    _Analis.AgroText1.Text = string.Format("{0:0.0000}", k1);
                    _Analis.AgroText2.Text = string.Format("{0:0.0000}", k2);
                    if(_Analis.aproksim == "Линейная через 0")
                    {
                        _Analis.label14.Text = "A(C) = " + k1.ToString("0.0000 ;- 0.0000 ") + "*C";
                        for (double i = 0; i <= 3; i++)
                        {
                            double x2 = i;
                            double y2 = i * k1;
                            _Analis.chart1.Series[1].Points.AddXY(x2, y2);
                         
                            _Analis.chart1.Series[0].Enabled = false;
                            _Analis.chart1.ChartAreas[0].AxisX.Title = "Концетрация, " + _Analis.edconctr;
                            _Analis.chart1.ChartAreas[0].AxisY.Title = "Оптическая плотность, А";
                            _Analis.chart1.ChartAreas[0].AxisX.Minimum = 0;
                           
                            _Analis.chart1.ChartAreas[0].AxisY.Minimum = 0;
                        }
                        if(_Analis.aproksim == "Линейная")
                        {
                            _Analis.label14.Text = "A(C) = " + k1.ToString("0.0000 ;- 0.0000 ") + "*C" + k0.ToString(" + 0.0000 ;- 0.0000 ");
                            for (double i = 0; i <= 3; i++)
                            {
                                double x2 = i;
                                double y2 = i * k1 + k0;
                                _Analis.chart1.Series[1].Points.AddXY(x2, y2);
                                _Analis.chart1.Series[0].Enabled = false;
                                
                                _Analis.chart1.ChartAreas[0].AxisX.Title = "Концетрация, " + _Analis.edconctr;
                                _Analis.chart1.ChartAreas[0].AxisY.Title = "Оптическая плотность, А";
                                _Analis.chart1.ChartAreas[0].AxisX.Minimum = 0;
                             
                                _Analis.chart1.ChartAreas[0].AxisY.Minimum = 0;
                            }
                        }
                        else
                        {
                            _Analis.label14.Text = "A(C) = " + k0.ToString(" 0.0000 ;- 0.0000 ") + k1.ToString(" + 0.0000 ;- 0.0000 ") + "*C" + k2.ToString(" + 0.0000 ;- 0.0000 ") + "*C^2";
                            for (double i = 0; i <= 3; i++)
                            {
                                double x2 = i;
                                double y2 = i * k1 + k0 + i * k2 * k2;
                                _Analis.chart1.Series[0].Enabled = false;
                                _Analis.chart1.Series[1].Points.AddXY(x2, y2);
                         
                                _Analis.chart1.ChartAreas[0].AxisX.Title = "Концетрация, " + _Analis.edconctr;
                                _Analis.chart1.ChartAreas[0].AxisY.Title = "Оптическая плотность, А";
                                _Analis.chart1.ChartAreas[0].AxisX.Minimum = 0;
                               
                                _Analis.chart1.ChartAreas[0].AxisY.Minimum = 0;
                            }
                        }
                    }
                    functionA();
                    break;
                default:
                    _Analis.NoCaIzm = Convert.ToInt32(CountSeriya);
                    _Analis.NoCaSer = Convert.ToInt32(CountInSeriya);

                    WLADD1();
                    WLADDSTR1();
                    break;
                
            }

            


        }
        public void WLADD1()
        {

            for (int i = 1; i <= _Analis.NoCaIzm; i++)
            {

                DataGridViewTextBoxColumn firstColumn1 =
                new DataGridViewTextBoxColumn();
                firstColumn1.HeaderText = "A; Сер" + i;
                firstColumn1.Name = "A;Ser (" + i;
                firstColumn1.ValueType = Type.GetType("System.Double");

                _Analis.Table1.Columns.Add(firstColumn1);
               
            }

            for (int i = 1; i <= _Analis.NoCaIzm; i++)
            {
                _Analis.Table1.Columns["A;Ser (" + i].Width = 50;
            }
            _Analis.Table1.Columns[1].HeaderText = "Конц " + edconctr;
        }

        public void WLADDSTR1()
        {
            if (_Analis.USE_KO == true)
            {

                _Analis.Table1.Rows.Add(0, Convert.ToDouble(0.000));

                for (int i = 1; i <= _Analis.NoCaSer; i++)
                {
                    _Analis.Table1.Rows.Add(i, textBoxCO[i - 1].Text);


                }

                _Analis.Table1.CurrentCell = _Analis.Table1[3, 0];

            }
            else
            {
                for (int i = 1; i <= _Analis.NoCaSer; i++)
                {
                    _Analis.Table1.Rows.Add(i, textBoxCO[i - 1].Text);


                }

                _Analis.Table1.CurrentCell = _Analis.Table1[3, 0];
            }
            for (int i = 1; i <= _Analis.NoCaIzm; i++)
            {
                if (_Analis.USE_KO == false)
                {
                    _Analis.Table1.Rows[_Analis.NoCaSer].Cells["A;Ser (" + i].ReadOnly = true;
                }
                else
                {
                    _Analis.Table1.Rows[_Analis.NoCaSer + 1].Cells["A;Ser (" + i].ReadOnly = true;
                }
            }

            if (_Analis.USE_KO == false)
            {
                _Analis.Table1.Rows[_Analis.NoCaSer].Cells["NoCo"].ReadOnly = true;
                _Analis.Table1.Rows[_Analis.NoCaSer].Cells["Concetr"].ReadOnly = true;
                _Analis.Table1.Rows[_Analis.NoCaSer].Cells["Asred"].ReadOnly = true;
            }
            else
            {
                _Analis.Table1.Rows[_Analis.NoCaSer + 1].Cells["NoCo"].ReadOnly = true;
                _Analis.Table1.Rows[_Analis.NoCaSer + 1].Cells["Concetr"].ReadOnly = true;
                _Analis.Table1.Rows[_Analis.NoCaSer + 1].Cells["Asred"].ReadOnly = true;
            }

            _Analis.button11.Enabled = true;
        }
        public void WLREMOVE1()
        {
            while (true)
            {
                int i = _Analis.Table1.Columns.Count - 1;//С какого столбца начать
                if (_Analis.Table1.Columns[i].Name == "Asred")
                    break;
                _Analis.Table1.Columns.RemoveAt(i);
            }

        }
        public void WLREMOVESTR1()
        {
            _Analis.Table1.Rows.Clear();

        }
        public void SW()
        {
            LogoForm2 logoform = new LogoForm2();
            string SWText1 = GWString;
            double Walve_double = Convert.ToDouble(GWString.Replace(".", ","));
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
        public void Table2Create()
        {
            if (_Analis.ComPort == true)
            {
                _Analis.Podskazka.Text = "Измерьте 0 Asb/100%T";
                _Analis.label59.Visible = true;
                _Analis.label24.Visible = false;
                _Analis.button12.Enabled = true;
            }
            else
            {
                _Analis.Podskazka.Text = "Подключите прибор!";
                _Analis.label24.Visible = true;
            }
            _Analis.label25.Visible = false;
            _Analis.label26.Visible = false;
            
            _Analis.NoCaIzm1 = Convert.ToInt32(NoCaIzm1);
            _Analis.NoCaSer1 = Convert.ToInt32(NoCaSer1);
            _Analis.textBox8.Text = Description;
            _Analis.F1Text.Text = F1;
            _Analis.F2Text.Text = F2;
            _Analis.textBox7.Text = errorMethod;
            _Analis.IzmerenieOpen = true;
            _Analis.параметрыToolStripMenuItem.Enabled = true;
            _Analis.button10.Enabled = true;
            _Analis.button11.Enabled = true;
            _Analis.textBox12.Text = _Analis.Veshestvo1;
            _Analis.textBox9.Text = _Analis.wavelength1;        

           
            _Analis.Opt_dlin_cuvet.SelectedIndex = index;

            if (_Analis.ComPodkl == true)
            {
                _Analis.IzmerCreate1 = true;

            }
            else
            {
                _Analis.IzmerCreate1 = false;
            }
            if (_Analis.IzmerCreate == true)
            {
                _Analis.button14.Enabled = true;
            }
            else
            {
                _Analis.button14.Enabled = false;
            }
           // _Analis.Podskazka.Text = "Измеряйте или введите значения!";
            _Analis.label27.Visible = false;
            
            _Analis.label25.Visible = false;
            _Analis.label26.Visible = false;


            _Analis.новыйToolStripMenuItem.Enabled = false;
            _Analis.сохранитьToolStripMenuItem.Enabled = false;
            _Analis.эксопртВPDFToolStripMenuItem.Enabled = false;
            _Analis.экспортToolStripMenuItem.Enabled = false;
            _Analis.печатьToolStripMenuItem1.Enabled = false;
            _Analis.параметрыToolStripMenuItem.Enabled = true;
            _Analis.измеритьToolStripMenuItem.Enabled = false;
            _Analis.калибровкаToolStripMenuItem.Enabled = true;
            //   _Analis.справкаToolStripMenuItem.Visible = false;
            _Analis.button1.Enabled = false;
            _Analis.button3.Enabled = false;
            _Analis.button7.Enabled = false;
            _Analis.button8.Enabled = false;
            _Analis.button9.Enabled = false;
            _Analis.button10.Enabled = true;
      //      _Analis.button12.Enabled = false;
            _Analis.button14.Enabled = false;
            _Analis.button11.Enabled = false;

           

            // _Analis.label28.Visible = true;
            // _Analis.label33.Visible = true;
            WLREMOVE2();
            WLREMOVESTR2();
            WLADD2();
            WLADDSTR2();
            if (_Analis.tabControl2.SelectedTab == _Analis.tabPage4 && _Analis.Table2.Rows.Count > 0 && _Analis.ComPort == true)
            {
                _Analis.button14.Enabled = true;
            }
        }
        public void WLREMOVE2()
        {
            while (true)
            {
                int i = _Analis.Table2.Columns.Count - 1;//С какого столбца начать
                if (_Analis.Table2.Columns[i].Name == "Obrazec")
                    break;
                _Analis.Table2.Columns.RemoveAt(i);
            }

        }

        public void WLADD2()
        {
            if (_Analis.NoCaIzm1 >= 2)
            {
                for (int i = 1; i <= _Analis.NoCaIzm1; i++)
                {

                    DataGridViewTextBoxColumn firstColumn2 =
                    new DataGridViewTextBoxColumn();
                    firstColumn2.HeaderText = "A; Сер." + i;
                    firstColumn2.Name = "A;Ser" + i;
                    firstColumn2.ValueType = Type.GetType("System.Double");
                    _Analis.Table2.Columns.Add(firstColumn2);
                    DataGridViewTextBoxColumn firstColumn3 =
                    new DataGridViewTextBoxColumn();
                    firstColumn3.HeaderText = "C, " + edconctr + "; Сер." + i;
                    firstColumn3.Name = "C,edconctr;Ser." + i;
                    firstColumn3.ValueType = Type.GetType("System.Double");
                    _Analis.Table2.Columns.Add(firstColumn3);
                    // Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A; Сер" + i].KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_KeyPress);
                    firstColumn3.ReadOnly = true;
                    firstColumn3.Width = 50;
                    firstColumn2.Width = 50;
                }
            }
            else
            {

                DataGridViewTextBoxColumn firstColumn2_1 =
                        new DataGridViewTextBoxColumn();
                firstColumn2_1.HeaderText = "A; Сер." + 1;
                firstColumn2_1.Name = "A;Ser" + 1;
                firstColumn2_1.ValueType = Type.GetType("System.Double");
                _Analis.Table2.Columns.Add(firstColumn2_1);
                DataGridViewTextBoxColumn firstColumn3_1 =
                new DataGridViewTextBoxColumn();
                firstColumn3_1.HeaderText = "C, " + edconctr + "; Сер." + 1;
                firstColumn3_1.Name = "C,edconctr;Ser." + 1;
                firstColumn3_1.ValueType = Type.GetType("System.Double");
                _Analis.Table2.Columns.Add(firstColumn3_1);
                firstColumn3_1.ReadOnly = true;
                firstColumn3_1.Width = 50;
                firstColumn2_1.Width = 50;
            }
            if (_Analis.selet_rezim == 2)
            {
                DataGridViewTextBoxColumn firstColumn4 =
                new DataGridViewTextBoxColumn();
                firstColumn4.HeaderText = "Cср, " + edconctr;
                firstColumn4.Name = "Ccr";
                firstColumn4.ValueType = Type.GetType("System.Double");
                _Analis.Table2.Columns.Add(firstColumn4);
                firstColumn4.ReadOnly = true;
                DataGridViewTextBoxColumn firstColumn5 =
                new DataGridViewTextBoxColumn();
                firstColumn5.HeaderText = "d, %";
                firstColumn5.Name = "d%";
                firstColumn5.ValueType = Type.GetType("System.Double");
                firstColumn5.ReadOnly = true;
                _Analis.Table2.Columns.Add(firstColumn5);
                firstColumn4.Width = 100;
                firstColumn5.Width = 50;
            }


        }
        public void WLADDSTR2()
        {
            _Analis.count = 0;
            if (USE_KO == false)
            {
                if (_Analis.NoCaSer1 > 1)
                {
                    for (int i = 1; i <= _Analis.NoCaSer1; i++)
                    {
                        _Analis.Table2.Rows.Add(i);
                        _Analis.Table2.Rows[_Analis.count].Cells["Column1"].Value = _Analis.count + 1;
                        _Analis.count++;
                    }
                }
                else
                {
                    _Analis.Table2.Rows.Add(1);
                    _Analis.Table2.Rows[_Analis.count].Cells["Column1"].Value = _Analis.count + 1;
                    _Analis.count++;
                    _Analis.Table2.Rows.Add(1);
                }
                for (int i = 0; i < _Analis.Table2.RowCount - 1; i++)
                {

                    if (_Analis.Table2.Rows[i].Cells["Column1"].Value == null)
                    {
                        _Analis.Table2.Rows.RemoveAt(i);
                        i--;
                    }
                }
            }
            else
            {

                if (_Analis.NoCaSer1 > 1)
                {
                    _Analis.Table2.Rows.Add(0, "Контрольный", string.Format("{0:0.0000}", 0));
                    _Analis.Table2.Rows[_Analis.count].Cells["Column1"].Value = _Analis.count;
                    _Analis.count++;
                    for (int i = 1; i <= _Analis.NoCaSer1; i++)
                    {
                        _Analis.Table2.Rows.Add(i);
                        _Analis.Table2.Rows[_Analis.count].Cells["Column1"].Value = _Analis.count;
                        _Analis.count++;
                    }
                }
                else
                {
                    _Analis.Table2.Rows.Add(0, "Контрольный", string.Format("{0:0.0000}", 0));
                    _Analis.Table2.Rows[_Analis.count].Cells["Column1"].Value = _Analis.count;
                    _Analis.count++;
                    _Analis.Table2.Rows.Add(1, "");
                    _Analis.Table2.Rows[_Analis.count].Cells["Column1"].Value = _Analis.count;
                    _Analis.Table2.Rows.Add(1);
                }
                for (int i = 0; i < _Analis.Table2.RowCount - 1; i++)
                {

                    if (_Analis.Table2.Rows[i].Cells["Column1"].Value == null)
                    {
                        _Analis.Table2.Rows.RemoveAt(i);
                        i--;
                    }
                }
            }
            //Table2.Rows.Add();
            _Analis.Table2.CurrentCell = this._Analis.Table2[2, 0];
            for (int i = 1; i <= _Analis.NoCaIzm1; i++)
            {
                _Analis.Table2.Rows[0].Cells["C,edconctr;Ser." + i].ReadOnly = true;
                if (_Analis.selet_rezim == 2)
                {
                    _Analis.Table2.Rows[0].Cells["Ccr"].ReadOnly = true;
                    _Analis.Table2.Rows[0].Cells["d%"].ReadOnly = true;
                }
            }
            _Analis.Table2.Rows[_Analis.Table2.RowCount - 1].ReadOnly = true;
            _Analis.button11.Enabled = true;

        }

        public void WLREMOVESTR2()
        {
            _Analis.Table2.Rows.Clear();

        }
        public void Datagriview5Create()
        {
            _Analis.DateTime = DateTime;
            _Analis.Ispolnitel = Ispolnitel;
            _Analis.Description = Description;
            _Analis.direction = direction;
            _Analis.code = code;
            _Analis.textBoxCO = textBoxCO;
            _Analis.dataGridView5.Rows.Clear();
            while (true)
            {
                int i = _Analis.dataGridView5.Columns.Count - 1;//С какого столбца начать
                if (_Analis.dataGridView5.Columns[i].Name == "Obrazec1")
                    break;
                _Analis.dataGridView5.Columns.RemoveAt(i);
            }
            for (int i = 0; i < Convert.ToInt32(CountSeriya); i++)
            {
                DataGridViewTextBoxColumn firstColumn1 =
                new DataGridViewTextBoxColumn();
                firstColumn1.HeaderText = "Abs " + _Analis.textBoxCO[i].Text + " нм";
                firstColumn1.Name = "Abs " + i;
                firstColumn1.ValueType = Type.GetType("System.Double");
                firstColumn1.ReadOnly = true;
                _Analis.dataGridView5.Columns.Add(firstColumn1);

            }
            _Analis.massGEMultiAbs = new double[1][];
            _Analis.massGEMultiT = new double[1][];
        }
        public void KineticaTableCreate()
        {
            _Analis.timer2.Tick -= _Analis.TableKinetica;
            SW();
            _Analis.massWL = new double[0];
            _Analis.massGE = new double[0];
            _Analis.dataGridView3.Rows.Clear();
            _Analis.dataGridView4.Rows.Clear();
            _Analis.TableKinetica1.Rows.Clear();
          //  _Analis.chart3.Series.Add("Series1");
          //  _Analis.chart3.Series.Add("Series2");
            _Analis.chart3.Series[0].Points.Clear();
            _Analis.chart3.Series[1].Points.Clear();
            if (typeIzmer == "Abs")
            {
                _Analis.TableKinetica1.Columns[1].HeaderText = "Abs";
                _Analis.TableKinetica1.Columns[2].HeaderText = "%T";
                _Analis.dataGridView3.Columns[1].HeaderText = "Abs";
                _Analis.dataGridView3.Columns[2].HeaderText = "%T";
                _Analis.dataGridView4.Columns[1].HeaderText = "Abs";
                _Analis.dataGridView4.Columns[2].HeaderText = "%T";
            }
            else
            {
                _Analis.TableKinetica1.Columns[2].HeaderText = "Abs";
                _Analis.TableKinetica1.Columns[1].HeaderText = "%T";
                _Analis.dataGridView3.Columns[1].HeaderText = "%T";
                _Analis.dataGridView3.Columns[2].HeaderText = "Abs";
                _Analis.dataGridView4.Columns[1].HeaderText = "%T";
                _Analis.dataGridView4.Columns[2].HeaderText = "Abs";
            }
            if (_Analis.TableKinetica1.Columns[1].HeaderText == "Abs")
            {
                //Array.Sort(massGE);
                _Analis.chart3.ChartAreas[0].AxisY.Minimum = 0;
                _Analis.chart3.ChartAreas[0].AxisY.Maximum = 3;
                _Analis.chart3.ChartAreas[0].AxisX.Minimum = 0;
                _Analis.chart3.ChartAreas[0].AxisX.Maximum = _Analis.start;
            }
            else
            {
                //Array.Sort(massGE);
                _Analis.chart3.ChartAreas[0].AxisY.Minimum = 0;
                _Analis.chart3.ChartAreas[0].AxisY.Maximum = 125;
                _Analis.chart3.ChartAreas[0].AxisX.Minimum = 0;
                _Analis.chart3.ChartAreas[0].AxisX.Maximum = _Analis.start;
            }
            _Analis.label53.Text = Convert.ToString(_Analis.delay);
            _Analis.DateTime = DateTime;
            _Analis.Ispolnitel = Ispolnitel;
            _Analis.Description = Description;
            _Analis.direction = direction;
            _Analis.code = code;
            _Analis.timer2.Tick += _Analis.TableKinetica;


            _Analis.interval = interval;
            _Analis.timer2.Interval = Convert.ToInt32(interval * 1000); // 500 миллисекунд
            _Analis.start = start;
            _Analis.delay = delay;
            _Analis.timer2.Enabled = false;
    


        }
        public void TableExcel()
        {
            _Analis.GWNew.Text = GWString;
            _Analis.filepath = filepath;
            SW();
            SAGE sage = new SAGE(ref _Analis.countSA, ref _Analis.GE5_1_0, ref _Analis.versionPribor, ref _Analis.newPort, ref _Analis.ResponseModeNormal);
            _Analis.button11.Enabled = true;
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            _Analis.workBook = excelApp.Workbooks.Open(_Analis.filepath);
            _Analis.workSheet = (Microsoft.Office.Interop.Excel.Worksheet)_Analis.workBook.Worksheets.get_Item(1);
            // Открываем созданный excel-файл
            excelApp.Visible = true;
            excelApp.UserControl = true;

            _Analis.label60.Visible = true;
            _Analis.label60.Text = "Длина волны для измерения: " + GWString;

            _Analis.label61.Visible = true;
            _Analis.label61.Text = "Файл измерений: " + _Analis.filepath + "\n\nРежим измерений: Abs" +
                "\n\nДля измерения выберите нужную ячейку " +
                "в открывшейся таблице Excel и нажмите кнопку ИЗМЕРИТЬ на панели инструментов." +
                "\n\nВыполняйте процедуру необходимое количество раз.\n\nНе забывайте сохранять таблицу.";
            _Analis.Podskazka.Text = "Откалибруйтесь!";
            _Analis.button11.Enabled = false;
            _Analis.button14.Enabled = true;
            _Analis.button12.Enabled = true;
           
            _Analis.label25.Visible = false;
            _Analis.label26.Visible = false;
            _Analis.label59.Visible = true;
            
        }
        public void functionA()
        {
            _Analis.groupBox2.Enabled = false;
            _Analis.groupBox5.Enabled = false;
            _Analis.groupBox3.Enabled = false;
            _Analis.RR.Text = "";
            _Analis.SKO.Text = "";
            _Analis.label21.Text = "";
            _Analis.label22.Text = "";
            // chart1.Series[0].Points.Clear();
            //   chart1.Series[1].Points.Clear();
            if (_Analis.Zavisimoct == "A(C)")
            {
                if (_Analis.aproksim == "Линейная через 0")
                {

                    _Analis.label14.Text = "A(C) = " + _Analis.k1.ToString("0.0000 ;- 0.0000 ") + "*C";
                    double x2 = 0;
                    for (double i = 0; i < 5; i = i + 0.5)
                    {
                        double y2 = i * _Analis.k1;
                        _Analis.chart1.Series[1].Points.AddXY(i, y2);
                        _Analis.chart1.Series[1].ChartType = SeriesChartType.Line;
                        _Analis.chart1.ChartAreas[0].AxisX.Title = "Концетрация, " + _Analis.edconctr;
                        _Analis.chart1.ChartAreas[0].AxisY.Title = "Оптическая плотность, А";
                        _Analis.chart1.ChartAreas[0].AxisX.Minimum = 0;

                        _Analis.chart1.ChartAreas[0].AxisY.Minimum = 0;
                        x2 = i;
                    }
                    double xfin = x2 * 1.1;
                    double yfin = xfin * _Analis.k1;
                    _Analis.chart1.Series[1].Points.AddXY(xfin, yfin);
                }
                else
                {
                    if (_Analis.aproksim == "Линейная")
                    {
                        _Analis.label14.Text = "A(C) = " + _Analis.k0.ToString("0.0000 ;- 0.0000 ") + _Analis.k1.ToString("+ 0.0000 ;- 0.0000 ") + "*C ";
                        double x2 = 0;
                        for (double i = 0; i < 5; i = i + 0.5)
                        {
                            double y2 = i * _Analis.k1 + _Analis.k0;
                            _Analis.chart1.Series[1].Points.AddXY(i, y2);
                            _Analis.chart1.Series[1].ChartType = SeriesChartType.Line;
                            _Analis.chart1.ChartAreas[0].AxisX.Title = "Концетрация, " + _Analis.edconctr;
                            _Analis.chart1.ChartAreas[0].AxisY.Title = "Оптическая плотность, А";
                            _Analis.chart1.ChartAreas[0].AxisX.Minimum = 0;

                            _Analis.chart1.ChartAreas[0].AxisY.Minimum = 0;
                            x2 = i;
                        }
                        double xfin = x2 * 1.1;
                        double yfin = xfin * _Analis.k1 + _Analis.k0;
                        _Analis.chart1.Series[1].Points.AddXY(xfin, yfin);
                    }
                    else
                    {
                        _Analis.label14.Text = "A(C) = " + _Analis.k0.ToString("0.0000 ;- 0.0000 ") + _Analis.k1.ToString("+ 0.0000 ;- 0.0000 ") + "*C " + _Analis.k2.ToString("+ 0.0000 ;- 0.0000 ") + "*C^2";
                        double x2 = 0;
                        for (double i = 0; i < 5; i = i + 0.5)
                        {
                            double y2 = i * _Analis.k1 + i * i * _Analis.k2 + _Analis.k0;
                            _Analis.chart1.Series[1].Points.AddXY(i, y2);
                            _Analis.chart1.Series[1].ChartType = SeriesChartType.Line;
                            _Analis.chart1.ChartAreas[0].AxisX.Title = "Концетрация, " + _Analis.edconctr;
                            _Analis.chart1.ChartAreas[0].AxisY.Title = "Оптическая плотность, А";
                            _Analis.chart1.ChartAreas[0].AxisX.Minimum = 0;

                            _Analis.chart1.ChartAreas[0].AxisY.Minimum = 0;
                            x2 = i;
                        }
                        double xfin = x2 * 1.1;
                        double yfin = xfin * _Analis.k1;
                        _Analis.chart1.Series[1].Points.AddXY(xfin, yfin);
                    }


                }
            }
            else
            {
                if (_Analis.aproksim == "Линейная через 0")
                {
                    _Analis.label14.Text = "C(A) = " + _Analis.k1.ToString("0.0000 ;- 0.0000 ") + "*A";
                    double x2 = 0;
                    for (double i = 0; i < 5; i = i + 0.5)
                    {
                        double y2 = i * _Analis.k1;
                        _Analis.chart1.Series[1].Points.AddXY(i, y2);
                        _Analis.chart1.Series[1].ChartType = SeriesChartType.Line;
                        _Analis.chart1.ChartAreas[0].AxisX.Title = "Оптическая плотность, А";
                        _Analis.chart1.ChartAreas[0].AxisY.Title = "Концетрация, " + _Analis.edconctr;
                        _Analis.chart1.ChartAreas[0].AxisX.Minimum = 0;

                        _Analis.chart1.ChartAreas[0].AxisY.Minimum = 0;
                        x2 = i;
                    }
                    double xfin = x2 * 1.1;
                    double yfin = xfin * _Analis.k1;
                    _Analis.chart1.Series[1].Points.AddXY(xfin, yfin);
                }
                else
                {
                    if (_Analis.aproksim == "Линейная")
                    {
                        _Analis.label14.Text = "C(A) = " + _Analis.k0.ToString("0.0000 ;- 0.0000 ") + _Analis.k1.ToString("+ 0.0000 ;- 0.0000 ") + "*A ";
                        double x2 = 0;
                        for (double i = 0; i < 5; i = i + 0.5)
                        {
                            double y2 = i * _Analis.k1 + _Analis.k0;
                            _Analis.chart1.Series[1].Points.AddXY(i, y2);
                            _Analis.chart1.Series[1].ChartType = SeriesChartType.Line;
                            _Analis.chart1.ChartAreas[0].AxisX.Title = "Оптическая плотность, А";
                            _Analis.chart1.ChartAreas[0].AxisY.Title = "Концетрация, " + _Analis.edconctr;
                            _Analis.chart1.ChartAreas[0].AxisX.Minimum = 0;

                            _Analis.chart1.ChartAreas[0].AxisY.Minimum = 0;
                            x2 = i;
                        }
                        double xfin = x2 * 1.1;
                        double yfin = xfin * _Analis.k1;
                        _Analis.chart1.Series[1].Points.AddXY(xfin, yfin);
                    }
                    else
                    {
                        _Analis.label14.Text = "C(A) = " + _Analis.k0.ToString("0.0000 ;- 0.0000 ") + _Analis.k1.ToString("+ 0.0000 ;- 0.0000 ") + "*A " + _Analis.k2.ToString("+ 0.0000 ;- 0.0000 ") + "*A^2";
                        double x2 = 0;
                        for (double i = 0; i < 5; i = i + 0.5)
                        {
                            double y2 = i * _Analis.k1 + i * _Analis.k2 + _Analis.k0;
                            _Analis.chart1.Series[1].Points.AddXY(i, y2);
                            _Analis.chart1.Series[1].ChartType = SeriesChartType.Line;
                            _Analis.chart1.ChartAreas[0].AxisX.Title = "Оптическая плотность, А";
                            _Analis.chart1.ChartAreas[0].AxisY.Title = "Концетрация, " + _Analis.edconctr;
                            _Analis.chart1.ChartAreas[0].AxisX.Minimum = 0;

                            _Analis.chart1.ChartAreas[0].AxisY.Minimum = 0;
                            x2 = i;
                        }
                        double xfin = x2 * 1.1;
                        double yfin = xfin * _Analis.k1;
                        _Analis.chart1.Series[1].Points.AddXY(xfin, yfin);
                    }

                }
            }
            _Analis.новыйToolStripMenuItem.Enabled = false;
            _Analis.сохранитьToolStripMenuItem.Enabled = true;
            _Analis.эксопртВPDFToolStripMenuItem.Enabled = false;
            _Analis.экспортToolStripMenuItem.Enabled = false;
            _Analis.печатьToolStripMenuItem1.Enabled = true;
            _Analis.параметрыToolStripMenuItem.Enabled = true;
            _Analis.измеритьToolStripMenuItem.Enabled = false;
            _Analis.калибровкаToolStripMenuItem.Enabled = false;
         //   _Analis.справкаToolStripMenuItem.Visible = false;
            _Analis.button1.Enabled = false;
            _Analis.button3.Enabled = true;
            _Analis.button7.Enabled = true;
            _Analis.button8.Enabled = false;
            _Analis.button9.Enabled = false;
            _Analis.button10.Enabled = true;
            _Analis.button12.Enabled = false;
            _Analis.button14.Enabled = false;
            _Analis.button11.Enabled = false;

            _Analis.label27.Visible = true;
            _Analis.label59.Visible = false;
            _Analis.label24.Visible = false;
            _Analis.Podskazka.Text = "Сохраните градуировку";

        }
        public double shag;
        public void ScaTableCreate()
        {
            _Analis.ScanTable.Rows.Clear();
            _Analis.dataGridView1.Rows.Clear();
            _Analis.dataGridView2.Rows.Clear();
            _Analis.listBox1.Items.Clear();
            _Analis.start = start;
            _Analis.cancel = cancel;
            int rows = 0;
            for (double i = _Analis.start; i >= _Analis.cancel; i -= shag)
            {
                _Analis.ScanTable.Rows.Add(string.Format("{0:0.0}", i));
                rows++;
            }
            _Analis.ScanChart.Series[0].Points.Clear();
            _Analis.ScanChart.Series[1].Points.Clear();

            _Analis.ScanChart.Series.Clear();
            _Analis.ScanChart.Series.Add("Series1");
           _Analis.ScanChart.Series.Add("Series2");
            if (typeIzmer == "Abs")
            {
                _Analis.ScanTable.Columns[1].HeaderText = "Abs";
                _Analis.ScanTable.Columns[2].HeaderText = "%T";
                _Analis.dataGridView1.Columns[1].HeaderText = "Abs";
                _Analis.dataGridView1.Columns[2].HeaderText = "%T";
                _Analis.dataGridView2.Columns[1].HeaderText = "Abs";
                _Analis.dataGridView2.Columns[2].HeaderText = "%T";
            }
            else
            {
                _Analis.ScanTable.Columns[2].HeaderText = "Abs";
                _Analis.ScanTable.Columns[1].HeaderText = "%T";
                _Analis.dataGridView1.Columns[1].HeaderText = "%T";
                _Analis.dataGridView1.Columns[2].HeaderText = "Abs";
                _Analis.dataGridView2.Columns[1].HeaderText = "%T";
                _Analis.dataGridView2.Columns[2].HeaderText = "Abs";
            }
            if (_Analis.ScanTable.Columns[1].HeaderText == "Abs")
            {
                //Array.Sort(massGE);
                _Analis.ScanChart.ChartAreas[0].AxisY.Minimum = 0;
                _Analis.ScanChart.ChartAreas[0].AxisY.Maximum = 3;
                _Analis.ScanChart.ChartAreas[0].AxisX.Minimum = _Analis.cancel;
                _Analis.ScanChart.ChartAreas[0].AxisX.Maximum = _Analis.start;
            }
            else
            {
                //Array.Sort(massGE);
                _Analis.ScanChart.ChartAreas[0].AxisY.Minimum = 0;
                _Analis.ScanChart.ChartAreas[0].AxisY.Maximum = 125;
                _Analis.ScanChart.ChartAreas[0].AxisX.Minimum = _Analis.cancel;
                _Analis.ScanChart.ChartAreas[0].AxisX.Maximum = _Analis.start;
            }
            _Analis.Description = Description;
            _Analis.button11.Enabled = true;
            _Analis.StopSpectr = false;
            _Analis.scan_mass = null;
            int countStr = _Analis.ScanTable.Rows.Count;
            _Analis.countScan = new string[1][,];
            _Analis.button3.Enabled = true;
            _Analis.label27.Visible = false;
            _Analis.label33.Visible = false;
            _Analis.label28.Visible = false;
            _Analis.label59.Visible = true;
            _Analis.countButtonClick = 0;

            ResponseModeNormal = _Analis.ResponseModeNormal;

        }
    }
}
