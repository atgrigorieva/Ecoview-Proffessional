using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using System.Xml.Linq;

namespace Ecoview_Professional
{
    class OpenAll
    {
        Ecoview _Analis;
        public OpenAll(Ecoview parent)
        {
            this._Analis = parent;
            try
            {
                switch (_Analis.selet_rezim)
                {
                    case 2:
                        _Analis.Izmerenie1 = true;
                        if (_Analis.tabControl2.SelectedIndex == 0)
                        {
                            Open();
                        }
                        else
                        {
                            Open1();
                        }
                        break;
                    case 1:
                        IzmerenieFR_Open();
                        break;
                    case 6:
                        _Analis.Izmerenie1 = true;
                        if (_Analis.tabControl2.SelectedIndex == 0)
                        {
                            Open();
                        }
                        else
                        {
                            Open1();
                        }
                        break;
                    case 5:
                        TableScan_Open();
                        break;
                    case 4:
                        TableKin_Open();
                        break;
                    case 3:
                        TableMulti_Open();
                        break;
                }
                _Analis.label27.Visible = false;
                _Analis.label24.Visible = false;
                _Analis.label25.Visible = false;
                _Analis.label26.Visible = false;
                _Analis.label28.Visible = false;
                _Analis.button3.Enabled = true;
                _Analis.button7.Enabled = true;
                _Analis.button8.Enabled = true;
                _Analis.button9.Enabled = true;
                if (_Analis.versionPribor != "" && _Analis.versionPribor != null)
                {
                    _Analis.button1.Enabled = true;
                }
            }
            catch
            {
                if (shifrTrueFalse != false)
                {
                    MessageBox.Show("Прервана связь с прибором. Подключитесь снова!");
                    //SWF.Application.OpenForms["LogoFrm"].Close();
                    _Analis.GWNew.Text = null;

                    _Analis.Izmerenie1 = true;

                    this._Analis.подключитьToolStripMenuItem.Enabled = true;
                    _Analis.button2.Enabled = true;
                    _Analis.button11.Enabled = false;
                    _Analis.button12.Enabled = false;
                    _Analis.button14.Enabled = false;
                    this._Analis.настройкаПортаToolStripMenuItem.Enabled = false;
                    this._Analis.информацияToolStripMenuItem.Enabled = false;
                    this._Analis.калибровкаToolStripMenuItem.Enabled = false;
                    this._Analis.темновойТокToolStripMenuItem.Enabled = false;
                    this._Analis.измеритьToolStripMenuItem.Enabled = false;

                    this._Analis.калибровкаДляОдноволновогоАнализаToolStripMenuItem.Enabled = false;
                    _Analis.button1.Enabled = false;
                    _Analis.label28.Visible = false;
                    _Analis.label33.Visible = false;
                    _Analis.label24.Visible = true;
                    if (_Analis.versionPribor != null && _Analis.versionPribor != "")
                    {
                        _Analis.newPort.Close();
                        _Analis.versionPribor = "";
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
                        _Analis.MinMax();
                        //button14.Enabled = true;
                        _Analis.button11.Enabled = false;

                    }
                    _Analis.Podskazka.Text = "Подключите прибор!";
                    _Analis.label27.Visible = false;
                    _Analis.label24.Visible = true;
                    _Analis.label25.Visible = false;
                    _Analis.label26.Visible = false;
                    _Analis.label28.Visible = false;
                    return;
                }
            }
        }
        public void TableMulti_Open()
        {
            _Analis.openFileDialog1.InitialDirectory = "C";
            _Analis.openFileDialog1.Title = "Open File";
            _Analis.openFileDialog1.FileName = "";
            _Analis.openFileDialog1.Filter = "MULTI файл|*.MULTI2";
            if (_Analis.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _Analis.dataGridView5.Rows.Clear();
                for (int i = _Analis.dataGridView5.ColumnCount - 1; i >= 2; i--)
                {
                    _Analis.dataGridView5.Columns.Remove(_Analis.dataGridView5.Columns[i]);
                }
                try
                {

                    // получаем выбранный файл
                    openFileMulti(ref _Analis.filepath);
                    _Analis.button3.Enabled = true;
                    // button9.Enabled = false;
                }
                catch (Exception t) { MessageBox.Show("exeption" + t.Message); }
            }
        }
        public void TableKin_Open()
        {
            _Analis.openFileDialog1.InitialDirectory = "C";
            _Analis.openFileDialog1.Title = "Open File";
            _Analis.openFileDialog1.FileName = "";
            _Analis.openFileDialog1.Filter = "KIN файл|*.KIN2";
            if (_Analis.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _Analis.chart3.Series[0].Points.Clear();
                _Analis.chart3.Series[1].Points.Clear();
                _Analis.chart3.Series.Clear();
                _Analis.chart3.Series.Add("Series1");
                _Analis.chart3.Series.Add("Series2");
                //listBox1.Items.Clear();
                _Analis.dataGridView4.Rows.Clear();
                _Analis.dataGridView3.Rows.Clear();
                _Analis.TableKinetica1.Rows.Clear();
                try
                {

                    // получаем выбранный файл
                    openFileKin(ref _Analis.filepath);
                    _Analis.button3.Enabled = true;
                }
                catch (Exception t) { MessageBox.Show("exeption" + t.Message); }
            }
        }
        public void TableScan_Open()
        {
            _Analis.openFileDialog1.InitialDirectory = "C";
            _Analis.openFileDialog1.Title = "Open File";
            _Analis.openFileDialog1.FileName = "";
            _Analis.openFileDialog1.Filter = "SCAN файл|*.SCAN2";
            if (_Analis.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _Analis.ScanChart.Series[0].Points.Clear();
                _Analis.ScanChart.Series[1].Points.Clear();
                _Analis.ScanChart.Series.Clear();
                _Analis.ScanChart.Series.Add("Series1");
                _Analis.ScanChart.Series.Add("Series2");
                _Analis.listBox1.Items.Clear();
                _Analis.ScanTable.Rows.Clear();
                _Analis.dataGridView1.Rows.Clear();
                _Analis.dataGridView2.Rows.Clear();
                try
                {
                    // получаем выбранный файл
                    openFileScan(ref _Analis.filepath);
                    _Analis.button3.Enabled = true;
                }
                catch (Exception t) { MessageBox.Show("exeption" + t.Message); }
            }
        }

        public void Open()
        {
            if (_Analis.selet_rezim == 2)
            {
                _Analis.openFileDialog1.InitialDirectory = "C";
                _Analis.openFileDialog1.Title = "Open File";
                _Analis.openFileDialog1.FileName = "";
                _Analis.openFileDialog1.Filter = "QS2 файл|*.qs2";
            }
            else
            {
                _Analis.openFileDialog1.InitialDirectory = "C";
                _Analis.openFileDialog1.Title = "Open File";
                _Analis.openFileDialog1.FileName = "";
                _Analis.openFileDialog1.Filter = "Agro QS2 файл|*.aq2";
            }
            if (_Analis.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _Analis.chart1.Series[0].Points.Clear();
                _Analis.chart1.Series[1].Points.Clear();
                _Analis.Table1.Visible = false;
                try
                {

                    // получаем выбранный файл
                    openFile(ref _Analis.filepath);
                    _Analis.button11.Enabled = true;
                }
                catch (Exception t) { MessageBox.Show("exeption" + t.Message); }

                if (_Analis.SposobZadan != "Ввод коэффициентов")
                {
                    _Analis.Table1.Visible = true;
                    _Analis.groupBox2.Enabled = true;
                    _Analis.groupBox5.Enabled = true;
                    _Analis.groupBox3.Enabled = true;
                    TableWrite();
                    _Analis.AgroText0.Enabled = true;
                    _Analis.AgroText1.Enabled = true;
                    _Analis.AgroText2.Enabled = true;
                    _Analis.RR.Enabled = true;
                    _Analis.SKO.Enabled = true;
                    _Analis.label21.Enabled = true;
                    _Analis.label22.Enabled = true;
                    _Analis.label14.Enabled = true;
                    _Analis.button11.Enabled = true;
                }
                else
                {
                    _Analis.groupBox2.Enabled = false;
                    _Analis.groupBox5.Enabled = false;
                    _Analis.groupBox3.Enabled = false;
                    _Analis.RR.Text = "";
                    _Analis.SKO.Text = "";
                    _Analis.label21.Text = "";
                    _Analis.label22.Text = "";
                    _Analis.button11.Enabled = false;
                }
                _Analis.radioButton1.Enabled = true;
                _Analis.radioButton2.Enabled = true;
                _Analis.radioButton3.Enabled = true;
                _Analis.radioButton4.Enabled = true;
                _Analis.radioButton5.Enabled = true;
                _Analis.button3.Enabled = true;
                _Analis.button9.Enabled = false;


                _Analis.Podskazka.Text = "Перейдите в Измерения!";
                _Analis.label27.Visible = false;
                _Analis.label24.Visible = false;
                _Analis.label25.Visible = false;
                _Analis.label26.Visible = false;
                _Analis.label28.Visible = false;


                _Analis.новыйToolStripMenuItem.Enabled = false;
                _Analis.сохранитьToolStripMenuItem.Enabled = true;
                if (_Analis.SposobZadan != "Ввод коэффициентов")
                {
                    _Analis.эксопртВPDFToolStripMenuItem.Enabled = true;
                    _Analis.экспортToolStripMenuItem.Enabled = true;

                    _Analis.button8.Enabled = true;
                    _Analis.button9.Enabled = true;
                }

                _Analis.печатьToolStripMenuItem1.Enabled = true;
                _Analis.параметрыToolStripMenuItem.Enabled = true;
                _Analis.измеритьToolStripMenuItem.Enabled = true;
                _Analis.калибровкаToolStripMenuItem.Enabled = true;
                //   справкаToolStripMenuItem.Visible = false;
                _Analis.button1.Enabled = false;
                _Analis.button3.Enabled = true;
                _Analis.button10.Enabled = true;
                _Analis.button12.Enabled = true;
                _Analis.button14.Enabled = true;
                _Analis.button11.Enabled = true;
                _Analis.button7.Enabled = true;


                if (Convert.ToInt32(_Analis.CountInSeriya) < 3)
                {
                    _Analis.radioButton3.Enabled = false;
                }
                else
                {
                    if (Convert.ToInt32(_Analis.CountInSeriya) < 2)
                    {
                        _Analis.radioButton2.Enabled = false;
                        _Analis.radioButton3.Enabled = false;
                    }
                    else
                    {
                        _Analis.radioButton1.Enabled = true;
                        _Analis.radioButton2.Enabled = true;
                        _Analis.radioButton3.Enabled = true;
                    }
                }

                _Analis.tabPage4.Parent = _Analis.tabControl2;
                if (_Analis.selet_rezim == 6)
                {
                    _Analis.tabControl2.TabPages[1].Text = "Измерение Агро";
                }
            }
        }
        public void TableWrite()
        {

            int StolbecCol = 3 + Convert.ToInt32(_Analis.CountSeriya);

            if (_Analis.USE_KO == false)
            {
                for (int i = 0; i < Convert.ToInt32(_Analis.CountInSeriya); i++)
                {
                    for (int j = 0; j < StolbecCol; j++)
                    {
                        if (_Analis.CellColor[i, j] == "Pink")
                        {
                            _Analis.Table1.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.Pink;
                        }
                        else
                        {
                            _Analis.Table1.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.White;
                        }
                        _Analis.Table1.Rows[i].Cells[j].Value = _Analis.Stolbec[i, j];
                    }

                }
            }
            else
            {
                for (int i = 0; i < (Convert.ToInt32(_Analis.CountInSeriya) + 1); i++)
                {
                    for (int j = 0; j < StolbecCol; j++)
                    {
                        if (_Analis.CellColor[i, j] == "Pink")
                        {
                            _Analis.Table1.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.Pink;
                        }
                        else
                        {
                            _Analis.Table1.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.White;
                        }
                        _Analis.Table1.Rows[i].Cells[j].Value = _Analis.Stolbec[i, j];
                    }

                }
            }
            _Analis.NoCaIzm = Convert.ToInt32(_Analis.CountSeriya);
            if (_Analis.Zavisimoct == "A(C)")
            {
                _Analis.radioButton4.Checked = true;
            }
            else
            {
                _Analis.radioButton5.Checked = true;
            }
            if (_Analis.aproksim == "Линейная через 0")
            {
                _Analis.radioButton1.Checked = true;
                _Analis.lineynaya0();
                //Lineinaya0 lineinaya0 = new Lineinaya0();
            }
            else
            {
                if (_Analis.aproksim == "Линейная")
                {
                    _Analis.radioButton2.Checked = true;
                    _Analis.lineinaya();
                    //  lineinaya();
                }
                else
                {
                    _Analis.radioButton3.Checked = true;
                    _Analis.kvadratichnaya();
                    //kvadratichnaya();
                }
            }
            _Analis.OpenIzmer = true;
            if (_Analis.button12.Enabled == true && _Analis.OpenIzmer == true)
            {
                _Analis.IzmerCreate = true;
            }
            else
            {
                _Analis.IzmerCreate = false;
            }
            if (_Analis.IzmerCreate == true)
            {
                _Analis.button14.Enabled = true;
            }
            else
            {
                _Analis.button14.Enabled = false;
            }

        }
        public void openFileMulti(ref string filepath)
        {
            filepath = _Analis.openFileDialog1.FileName;

            //  DecriptorFile decriptorfile = new DecriptorFile(ref filepath, _Analis.pathTemp);
            Decriptor64 decriptorfile = new Decriptor64(ref filepath, _Analis.pathTemp, ref shifrTrueFalse);
            if (shifrTrueFalse == false)
            {
                MessageBox.Show("Формат файла не поддерживается!");
                return;
            }
            else
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(_Analis.pathTemp + filepath);
                XmlNodeList nodes = xDoc.ChildNodes;

                XDocument xdoc = XDocument.Load(_Analis.pathTemp + filepath);

                foreach (XElement IzmerScan1 in xdoc.Element("Data_Izmerenie").Elements("Izmerenie"))
                {
                    XElement Direction = IzmerScan1.Element("Direction");
                    XElement Code = IzmerScan1.Element("Code");
                    XElement Address = IzmerScan1.Element("Address");
                    XElement NameLab = IzmerScan1.Element("NameLab");

                    XElement Ispolnitel1 = IzmerScan1.Element("Ispolnitel");
                    XElement DateTime1 = IzmerScan1.Element("DateTime");
                    XElement Description1 = IzmerScan1.Element("Description");


                    if (Direction != null && Code != null && Address != null && NameLab != null)
                    {
                        if (Direction.Value != "")
                        {
                            _Analis.direction = Direction.Value;
                        }
                        else
                        {
                            _Analis.direction = "";
                        }

                        if (Code.Value != "" || Code.Value != null)
                        {
                            _Analis.code = Code.Value;
                        }
                        else
                        {
                            _Analis.code = "";
                        }

                        if (Address.Value != "")
                        {
                            _Analis.address_lab = Address.Value;
                        }
                        else
                        {
                            _Analis.address_lab = "";
                        }

                        if (NameLab.Value != "")
                        {
                            _Analis.name_lab = NameLab.Value;
                        }
                        else
                        {
                            _Analis.name_lab = "";
                        }

                    }

                    if (Ispolnitel1 != null && DateTime1 != null && Description1 != null)
                    {
                        if (Ispolnitel1.Value != "")
                        {
                            _Analis.Ispolnitel = Ispolnitel1.Value;
                        }
                        else
                        {
                            _Analis.Ispolnitel = "";
                        }

                        if (DateTime1.Value != "" || DateTime1.Value != null)
                        {
                            _Analis.DateTime = DateTime1.Value;
                        }
                        else
                        {
                            _Analis.DateTime = "";
                        }
                        if (Description1.Value != "")
                        {
                            _Analis.Description = Description1.Value;
                        }
                        else
                        {
                            _Analis.Description = "";
                        }

                    }
                }
                foreach (XElement IzmerScan1 in xdoc.Element("Data_Izmerenie").Element("NumberIzmer").Elements("Str"))
                {
                    int celssData = 0;

                    foreach (XElement IzmerScan1_1 in IzmerScan1.Elements("Cells"))
                    {
                        XAttribute CellsAttribute0 = IzmerScan1_1.Attribute("TypeCell1");
                        if (CellsAttribute0 != null)
                        {
                            if (CellsAttribute0.Value.Contains("Abs"))
                            {
                                CellsAttribute0.Value = CellsAttribute0.Value.Substring(4);
                                CellsAttribute0.Value = CellsAttribute0.Value.Substring(0, CellsAttribute0.Value.Length - 3);
                                // dataGridView5.Columns.Add("Abs " + celssData, "Abs " + CellsAttribute0.Value + " нм");

                                DataGridViewTextBoxColumn firstColumn1 =
                                new DataGridViewTextBoxColumn();
                                firstColumn1.HeaderText = "Abs " + CellsAttribute0.Value + " нм";
                                firstColumn1.Name = "Abs " + celssData;
                                firstColumn1.ValueType = Type.GetType("System.Double");
                                firstColumn1.ReadOnly = true;
                                _Analis.dataGridView5.Columns.Add(firstColumn1);
                            }
                            else
                            {
                                CellsAttribute0.Value = CellsAttribute0.Value.Substring(3);
                                CellsAttribute0.Value = CellsAttribute0.Value.Substring(0, CellsAttribute0.Value.Length - 3);
                                // dataGridView5.Columns.Add("Abs " + celssData, "%T " + CellsAttribute0.Value + " нм");

                                DataGridViewTextBoxColumn firstColumn1 =
                                new DataGridViewTextBoxColumn();
                                firstColumn1.HeaderText = "%T " + CellsAttribute0.Value + " нм";
                                firstColumn1.Name = "Abs " + celssData;
                                firstColumn1.ValueType = Type.GetType("System.Double");
                                firstColumn1.ReadOnly = true;
                                _Analis.dataGridView5.Columns.Add(firstColumn1);
                            }

                            _Analis.textBoxCO[celssData] = new TextBox();
                            _Analis.textBoxCO[celssData].Text = CellsAttribute0.Value;
                        }
                        celssData++;

                    }
                    break;

                }

                foreach (XElement IzmerScan in xdoc.Element("Data_Izmerenie").Elements("NumberIzmer"))
                {
                    int rowsData = 1;
                    foreach (XElement IzmerScan1 in IzmerScan.Elements("Str"))
                    {
                        XElement CellsElement0 = IzmerScan1.Element("Cells0");
                        XElement CellsElement1 = IzmerScan1.Element("Cells1");
                        _Analis.dataGridView5.Rows.Add(CellsElement0.Value, CellsElement1.Value);
                        Array.Resize<double[]>(ref _Analis.massGEMultiAbs, rowsData);
                        _Analis.massGEMultiAbs[_Analis.massGEMultiAbs.Length - 1] = new double[_Analis.dataGridView5.ColumnCount - 2];
                        Array.Resize<double[]>(ref _Analis.massGEMultiT, rowsData);
                        _Analis.massGEMultiT[_Analis.massGEMultiAbs.Length - 1] = new double[_Analis.dataGridView5.ColumnCount - 2];
                        int celssData = 0;

                        foreach (XElement IzmerScan2 in IzmerScan1.Elements("Cells"))
                        {
                            XElement CellsElement3 = IzmerScan2;
                            if (CellsElement3 != null)
                            {
                                _Analis.dataGridView5.Rows[_Analis.dataGridView5.Rows.Count - 2].Cells[celssData + 2].Value = CellsElement3.Value;
                                if (_Analis.dataGridView5.Columns["Abs " + celssData].HeaderText.Contains("Abs "))
                                {
                                    _Analis.massGEMultiAbs[rowsData - 1][celssData] = Convert.ToDouble(CellsElement3.Value);
                                    _Analis.massGEMultiT[rowsData - 1][celssData] = System.Math.Pow(System.Math.Pow(10, Convert.ToDouble(CellsElement3.Value)), -1) * 100;
                                }
                                else
                                {
                                    _Analis.massGEMultiT[rowsData - 1][celssData] = Convert.ToDouble(CellsElement3.Value);
                                    _Analis.massGEMultiAbs[rowsData - 1][celssData] = Math.Log10(System.Math.Pow((Convert.ToDouble(CellsElement3.Value) / 100), -1));
                                }

                            }
                            celssData++;
                        }
                        rowsData++;
                    }
                }
            }
        }
        public void openFileKin(ref string filepath)
        {
            filepath = _Analis.openFileDialog1.FileName;
            //    DecriptorFile decriptorfile = new DecriptorFile(ref filepath, _Analis.pathTemp);
            Decriptor64 decriptorfile = new Decriptor64(ref filepath, _Analis.pathTemp, ref shifrTrueFalse);
            if (shifrTrueFalse == false)
            {
                MessageBox.Show("Формат файла не поддерживается!");
                return;
            }
            else
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(_Analis.pathTemp + filepath);
                XmlNodeList nodes = xDoc.ChildNodes;

                foreach (XmlNode n in nodes)
                {
                    if ("Data_Izmerenie".Equals(n.Name))
                    {
                        for (XmlNode d = n.FirstChild; d != null; d = d.NextSibling)
                        {
                            if ("Izmerenie".Equals(d.Name))
                            {
                                for (XmlNode k = d.FirstChild; k != null; k = k.NextSibling)
                                {

                                    if ("TypeIzmer".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.TableKinetica1.Columns[1].HeaderText = k.FirstChild.Value;
                                        if (_Analis.TableKinetica1.Columns[1].HeaderText == "Abs")
                                        {
                                            _Analis.TableKinetica1.Columns[2].HeaderText = "%T";
                                        }
                                        else
                                        {
                                            _Analis.TableKinetica1.Columns[2].HeaderText = "Abs";
                                        }
                                        _Analis.chart3.ChartAreas[0].AxisX.Title = _Analis.TableKinetica1.Columns[0].HeaderText;
                                        _Analis.chart3.ChartAreas[0].AxisY.Title = _Analis.TableKinetica1.Columns[1].HeaderText;
                                    }

                                    if ("Direction".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.direction = k.FirstChild.Value;
                                    }
                                    if ("Code".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.code = k.FirstChild.Value;
                                    }
                                    if ("Address".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.address_lab = k.FirstChild.Value;
                                    }
                                    if ("NameLab".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.name_lab = k.FirstChild.Value;
                                    }
                                    if ("DateTime".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.DateTime = k.FirstChild.Value;
                                    }
                                    if ("Ispolnitel".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.Ispolnitel = k.FirstChild.Value;
                                    }

                                    if ("Description".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.Description = k.FirstChild.Value;
                                    }
                                }
                            }

                        }
                    }
                }

                XDocument xdoc = XDocument.Load(_Analis.pathTemp + filepath);
                foreach (XElement IzmerScan in xdoc.Element("Data_Izmerenie").Elements("NumberIzmer"))
                {
                    foreach (XElement IzmerScan1 in xdoc.Element("Data_Izmerenie").Element("NumberIzmer").Elements("Str"))
                    {
                        XElement CellsElement0 = IzmerScan1.Element("Cells0");
                        XElement CellsElement1 = IzmerScan1.Element("Cells1");
                        XElement CellsElement2 = IzmerScan1.Element("Cells2");

                        _Analis.TableKinetica1.Rows.Add(CellsElement0.Value, CellsElement1.Value, CellsElement2.Value);
                    }
                }

                _Analis.chart3.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                _Analis.chart3.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                //  chart3.ChartAreas[0].AxisX.Title = TableKinetica1.Columns[0].HeaderText;
                // chart3.ChartAreas[0].AxisY.Title = TableKinetica1.Columns[1].HeaderText;
                switch (_Analis.TableKinetica1.Columns[1].HeaderText)
                {
                    case "Abs":
                        _Analis.chart3.ChartAreas[0].AxisY.Minimum = 0;
                        _Analis.chart3.ChartAreas[0].AxisY.Maximum = 3;
                        _Analis.chart3.ChartAreas[0].AxisX.Minimum = 0;
                        _Analis.chart3.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(_Analis.TableKinetica1.Rows[_Analis.TableKinetica1.Rows.Count - 2].Cells[0].Value);
                        _Analis.dataGridView4.Columns[1].HeaderText = "Abs";
                        _Analis.dataGridView4.Columns[2].HeaderText = "%T";
                        _Analis.dataGridView3.Columns[1].HeaderText = "Abs";
                        _Analis.dataGridView3.Columns[2].HeaderText = "%T";
                        break;
                    case "%T":
                        _Analis.chart3.ChartAreas[0].AxisY.Minimum = 0;
                        _Analis.chart3.ChartAreas[0].AxisY.Maximum = 125;
                        _Analis.chart3.ChartAreas[0].AxisX.Minimum = 0;
                        _Analis.chart3.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(_Analis.TableKinetica1.Rows[_Analis.TableKinetica1.Rows.Count - 2].Cells[0].Value);
                        _Analis.dataGridView4.Columns[1].HeaderText = "%T";
                        _Analis.dataGridView4.Columns[2].HeaderText = "Abs";
                        _Analis.dataGridView3.Columns[1].HeaderText = "%T";
                        _Analis.dataGridView3.Columns[2].HeaderText = "Abs";
                        break;
                }

                _Analis.massGE = new double[_Analis.TableKinetica1.Rows.Count - 2];
                _Analis.massWL = new double[_Analis.TableKinetica1.Rows.Count - 2];
                _Analis.chart3.Series[1].ChartType = SeriesChartType.Line;
                for (int i = 0; i < _Analis.massGE.Length; i++)
                {
                    _Analis.massWL[i] = Convert.ToDouble(_Analis.TableKinetica1.Rows[i].Cells[0].Value);
                    _Analis.massGE[i] = Convert.ToDouble(_Analis.TableKinetica1.Rows[i].Cells[1].Value);
                    double x1 = Convert.ToDouble(_Analis.TableKinetica1.Rows[i].Cells[0].Value);
                    double y1 = Convert.ToDouble(_Analis.TableKinetica1.Rows[i].Cells[1].Value);
                    _Analis.chart3.Series[1].Points.AddXY(x1, y1);


                }


                Array.Sort(_Analis.massWL);
                Array.Sort(_Analis.massGE);

                _Analis.MinMax();
            }
        }
        public void openFileScan(ref string filepath)
        {
            filepath = _Analis.openFileDialog1.FileName;
            //    DecriptorFile decriptorfile = new DecriptorFile(ref filepath, _Analis.pathTemp);
            Decriptor64 decriptorfile = new Decriptor64(ref filepath, _Analis.pathTemp, ref shifrTrueFalse);
            if (shifrTrueFalse == false)
            {
                MessageBox.Show("Формат файла не поддерживается!");
                return;
            }
            else
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(_Analis.pathTemp + filepath);
                XmlNodeList nodes = xDoc.ChildNodes;

                foreach (XmlNode n in nodes)
                {
                    if ("Data_Izmerenie".Equals(n.Name))
                    {
                        for (XmlNode d = n.FirstChild; d != null; d = d.NextSibling)
                        {
                            if ("Izmerenie".Equals(d.Name))
                            {
                                for (XmlNode k = d.FirstChild; k != null; k = k.NextSibling)
                                {
                                    if ("CountIzmer".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        for (int i = 0; i < Convert.ToInt32(k.FirstChild.Value); i++)
                                        {
                                            _Analis.listBox1.Items.Add("Измерение" + i);
                                        }
                                    }
                                    if ("TypeIzmer".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.ScanTable.Columns[1].HeaderText = k.FirstChild.Value;
                                        if (_Analis.ScanTable.Columns[1].HeaderText == "Abs")
                                        {
                                            _Analis.ScanTable.Columns[2].HeaderText = "%T";
                                        }
                                        else
                                        {
                                            _Analis.ScanTable.Columns[2].HeaderText = "Abs";
                                        }
                                        _Analis.ScanChart.ChartAreas[0].AxisX.Title = _Analis.ScanTable.Columns["WalveDl"].HeaderText;
                                        _Analis.ScanChart.ChartAreas[0].AxisY.Title = _Analis.ScanTable.Columns["Abs_scan"].HeaderText;
                                    }
                                }
                            }

                        }
                    }
                }
                Array.Resize<string[,]>(ref _Analis.countScan, _Analis.listBox1.Items.Count);
                XDocument xdoc = XDocument.Load(_Analis.pathTemp + filepath);
                double[] RowsMax;
                foreach (XElement IzmerScan in xdoc.Element("Data_Izmerenie").Elements("NumberIzmer"))
                {
                    XElement CountStrElement = IzmerScan.Element("CountStr");
                    XAttribute NumberIzmer = IzmerScan.Attribute("Nomer");
                    //   MessageBox.Show(NumberIzmer.Value);
                    int StrCount = 0;
                    if (CountStrElement != null)
                    {
                        StrCount = Convert.ToInt32(CountStrElement.Value);

                    }
                    _Analis.countScan[Convert.ToInt32(NumberIzmer.Value)] = new string[StrCount, 3];

                    RowsMax = new double[StrCount];
                    foreach (XElement IzmerScan1 in xdoc.Element("Data_Izmerenie").Element("NumberIzmer").Elements("Str"))
                    {
                        XAttribute nameAttribute = IzmerScan1.Attribute("Nomer");
                        XElement RowsElement = IzmerScan1.Element("Cells0");
                        RowsMax[Convert.ToInt32(nameAttribute.Value)] = Convert.ToDouble(RowsElement.Value);
                    }

                    _Analis.ScanChart.ChartAreas[0].AxisX.Minimum = RowsMax[StrCount - 1];
                    _Analis.ScanChart.ChartAreas[0].AxisX.Maximum = RowsMax[0];
                    _Analis.ScanChart.ChartAreas[0].AxisY.Minimum = 0;
                    _Analis.ScanChart.ChartAreas[0].AxisY.Maximum = 125;
                }


                //MessageBox.Show(RowsMax);
                foreach (XElement IzmerScan in xdoc.Element("Data_Izmerenie").Elements("NumberIzmer"))
                {
                    XElement CountStrElement = IzmerScan.Element("CountStr");
                    XAttribute NumberIzmer = IzmerScan.Attribute("Nomer");
                    //   MessageBox.Show(NumberIzmer.Value);
                    int StrCount = 0;
                    if (CountStrElement != null)
                    {
                        StrCount = Convert.ToInt32(CountStrElement.Value);

                    }

                    Application.DoEvents();
                    //  if (chart1.Series.Count > 1) { chart1.Series.RemoveAt(Convert.ToInt32(NumberIzmer.Value)+1); }
                    _Analis.ScanChart.Series.Add("area" + Convert.ToInt32(NumberIzmer.Value));
                    Random r = new Random();
                    int x = r.Next(100, 200), y = r.Next(100, 200);
                    _Analis.ScanChart.Series["area" + Convert.ToInt32(NumberIzmer.Value)].Color =
                        System.Drawing.Color.FromArgb(
                            (byte)(x - 2 * y),
                            (byte)(y + x),
                            (byte)(y - 2 * x));
                    _Analis.ScanChart.Series["area" + Convert.ToInt32(NumberIzmer.Value)].ChartType = SeriesChartType.Line;
                    //   TableScan();
                    // Application.DoEvents();
                    ///    RowsMax = new String[StrCount];
                    double[] massWL = new double[StrCount];
                    double[] massGE = new double[StrCount];
                    foreach (XElement IzmerScan1 in IzmerScan.Elements("Str"))
                    {

                        XAttribute nameAttribute = IzmerScan1.Attribute("Nomer");
                        XElement CellsElement0 = IzmerScan1.Element("Cells0");
                        XElement CellsElement1 = IzmerScan1.Element("Cells1");
                        XElement CellsElement2 = IzmerScan1.Element("Cells2");
                        if (nameAttribute != null && CellsElement0 != null && CellsElement1 != null && CellsElement2 != null)
                        {
                            _Analis.countScan[Convert.ToInt32(NumberIzmer.Value)][Convert.ToInt32(nameAttribute.Value), 0] = CellsElement0.Value;
                            _Analis.countScan[Convert.ToInt32(NumberIzmer.Value)][Convert.ToInt32(nameAttribute.Value), 1] = CellsElement1.Value;
                            _Analis.countScan[Convert.ToInt32(NumberIzmer.Value)][Convert.ToInt32(nameAttribute.Value), 2] = CellsElement2.Value;
                            double x1 = Convert.ToDouble(CellsElement0.Value);
                            double y1 = Convert.ToDouble(CellsElement1.Value);
                            _Analis.ScanChart.Series["area" + Convert.ToInt32(NumberIzmer.Value)].Points.AddXY(x1, y1);
                            massWL[Convert.ToInt32(nameAttribute.Value)] = Convert.ToDouble(CellsElement0.Value);
                            massGE[Convert.ToInt32(nameAttribute.Value)] = Convert.ToDouble(CellsElement1.Value);

                        }


                    }
                    double max = 0.0;
                    double min = 0.0;

                    for (int i = 0; i < StrCount; i++)
                    {
                        if (i == 0)
                        {
                            if (massGE[i] > massGE[i + 1])
                            {
                                max = massGE[i];
                                //dataGridView1.Rows.Add(ScanTable.Rows[i].Cells[0].Value, ScanTable.Rows[i].Cells[1].Value, ScanTable.Rows[i].Cells[2].Value);
                                min = max;
                                double x1 = massWL[i];
                                double y1 = massGE[i];
                                _Analis.ScanChart.Series[0].Points.AddXY(x1, y1);
                                _Analis.ScanChart.Series[0].ChartType = SeriesChartType.Point;
                            }
                            else
                            {
                                min = massGE[i];
                                //  dataGridView2.Rows.Add(ScanTable.Rows[i].Cells[0].Value, ScanTable.Rows[i].Cells[1].Value, ScanTable.Rows[i].Cells[2].Value);
                                max = min;
                                double x1 = massWL[i];
                                double y1 = massGE[i];
                                _Analis.ScanChart.Series[0].Points.AddXY(x1, y1);
                                _Analis.ScanChart.Series[0].ChartType = SeriesChartType.Point;
                            }

                        }
                        else {
                            if (i + 1 != StrCount)
                            {
                                if (massGE[i] >= massGE[i - 1] && massGE[i] > massGE[i + 1])
                                {
                                    max = massGE[i];
                                    min = max;
                                    // dataGridView1.Rows.Add(ScanTable.Rows[i].Cells[0].Value, ScanTable.Rows[i].Cells[1].Value, ScanTable.Rows[i].Cells[2].Value);
                                    double x1 = massWL[i];
                                    double y1 = massGE[i];
                                    _Analis.ScanChart.Series[0].Points.AddXY(x1, y1);
                                    _Analis.ScanChart.Series[0].ChartType = SeriesChartType.Point;
                                }
                                if (massGE[i] <= massGE[i - 1] && massGE[i] < massGE[i + 1])
                                {
                                    min = massGE[i];
                                    //  dataGridView2.Rows.Add(ScanTable.Rows[i].Cells[0].Value, ScanTable.Rows[i].Cells[1].Value, ScanTable.Rows[i].Cells[2].Value);
                                    max = min;
                                    double x1 = massWL[i];
                                    double y1 = massGE[i];
                                    _Analis.ScanChart.Series[0].Points.AddXY(x1, y1);
                                    _Analis.ScanChart.Series[0].ChartType = SeriesChartType.Point;
                                }
                            }
                        }
                    }

                    _Analis.listBox1.SetSelected(0, true);

                }

            }

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
        public void openFile(ref string filepath)
        {
            WLREMOVE1();
            WLREMOVESTR1();
            filepath = _Analis.openFileDialog1.FileName;
            //string filepathCopy = filepath;
            _Analis.параметрыToolStripMenuItem.Enabled = true;
            _Analis.button10.Enabled = true;
            _Analis.filepathFull = _Analis.filepath;
            //   DecriptorFile decriptorfile = new DecriptorFile(ref filepath, _Analis.pathTemp);
            Decriptor64 decriptorfile = new Decriptor64(ref _Analis.filepathFull, _Analis.pathTemp, ref shifrTrueFalse);
            if (shifrTrueFalse == false)
            {
                MessageBox.Show("Формат файла не поддерживается!");
                return;
            }
            else
            {
                XmlDocument xDoc = new XmlDocument();

                xDoc.Load(_Analis.pathTemp + _Analis.filepathFull);

                XmlNodeList nodes = xDoc.ChildNodes;

                foreach (XmlNode n in nodes)
                { // Обрабатываем в цикле только Data_Izmerenie
                    if ("Data_Izmerenie".Equals(n.Name))
                    {
                        // Читаем в цикле вложенные значения Izmerenie
                        for (XmlNode d = n.FirstChild; d != null; d = d.NextSibling)
                        {
                            // Обрабатываем в цикле только Izmerenie
                            if ("Izmerenie".Equals(d.Name))
                            {
                                //Можно, например, в этом цикле, да и не только..., взять какие-то данные
                                for (XmlNode k = d.FirstChild; k != null; k = k.NextSibling)
                                {
                                    if ("Version".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        if (_Analis.version != k.FirstChild.Value)
                                        {
                                            MessageBox.Show("Внимание, версия программы отличается от версии открываемого документа!\n" +
                                        "Рекомендуем создать новую градуировку!");
                                            break;
                                        }
                                        else
                                        {
                                            // MessageBox.Show("Версия совпадает!");
                                            break;
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("Внимание, версия программы отличается от версии открываемого документа!\n" +
    "Рекомендуем создать новую градуировку!");
                                        break;
                                    }

                                }
                            }
                        }
                    }
                }


                foreach (XmlNode n in nodes)
                { // Обрабатываем в цикле только Data_Izmerenie
                    if ("Data_Izmerenie".Equals(n.Name))
                    {
                        // Читаем в цикле вложенные значения Izmerenie
                        for (XmlNode d = n.FirstChild; d != null; d = d.NextSibling)
                        {
                            // Обрабатываем в цикле только Izmerenie
                            if ("Izmerenie".Equals(d.Name))
                            {
                                //Можно, например, в этом цикле, да и не только..., взять какие-то данные
                                for (XmlNode k = d.FirstChild; k != null; k = k.NextSibling)
                                {
                                    if ("USE_CO_XML".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.USE_CO_XML1 = k.FirstChild.Value;
                                        if (_Analis.USE_CO_XML1 == "true")
                                        {
                                            _Analis.USE_KO = true;
                                        }
                                        else
                                        {
                                            _Analis.USE_KO = false;
                                        }

                                    }
                                    if ("SposobZadan".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.SposobZadan = k.FirstChild.Value;

                                    }
                                }
                            }
                        }
                    }
                }
                // Обходим значения
                foreach (XmlNode n in nodes)
                { // Обрабатываем в цикле только Data_Izmerenie
                    if ("Data_Izmerenie".Equals(n.Name))
                    {
                        // Читаем в цикле вложенные значения Izmerenie
                        for (XmlNode d = n.FirstChild; d != null; d = d.NextSibling)
                        {
                            // Обрабатываем в цикле только Izmerenie
                            if ("Izmerenie".Equals(d.Name))
                            {
                                //Можно, например, в этом цикле, да и не только..., взять какие-то данные
                                for (XmlNode k = d.FirstChild; k != null; k = k.NextSibling)
                                {

                                    if ("Veshestvo".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.Veshestvo1 = k.FirstChild.Value; //Вещество
                                        _Analis.textBox11.Text = _Analis.Veshestvo1;
                                        _Analis.textBox12.Text = _Analis.Veshestvo1;

                                    }

                                    if ("Direction".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.direction = k.FirstChild.Value;

                                    }
                                    if ("Code".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.code = k.FirstChild.Value;

                                    }
                                    if ("Address".Equals(k.Name) && k.FirstChild != null)
                                    {

                                        _Analis.address_lab = k.FirstChild.Value;

                                    }
                                    if ("NameLab".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.name_lab = k.FirstChild.Value;
                                    }




                                    if ("wavelength".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.wavelength1 = k.FirstChild.Value; //Длина волны
                                        _Analis.textBox9.Text = _Analis.wavelength1;
                                        _Analis.textBox10.Text = _Analis.wavelength1;
                                    }
                                    if ("WidthCuvet".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.WidthCuvette = k.FirstChild.Value; //Ширина кюветы
                                        _Analis.textBox2.Text = _Analis.WidthCuvette;

                                    }
                                    if ("BottomLine".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.BottomLine = k.FirstChild.Value; //Нижняя граница
                                    }
                                    if ("TopLine".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.TopLine = k.FirstChild.Value; //Верхняя граница
                                    }

                                    if ("ND".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.ND = k.FirstChild.Value; //НД
                                    }
                                    if ("Description".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.Description = k.FirstChild.Value; //Примечание
                                        _Analis.textBox1.Text = _Analis.Description;

                                    }
                                    if ("DateTime".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.DateTime = k.FirstChild.Value; //Дата
                                        _Analis.dateTimePicker1.Text = _Analis.DateTime;
                                    }
                                    if ("DateTime1_1".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.DateTime2_1 = k.FirstChild.Value; //Дата
                                        _Analis.label6.Text = _Analis.DateTime2_1;
                                    }

                                    if ("DateTime1_1_1".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.DateTime2_2_1 = k.FirstChild.Value; //Дата
                                        _Analis.numericUpDown1.Value = Convert.ToInt32(_Analis.DateTime2_2_1);
                                        _Analis.Days = Convert.ToInt32(_Analis.numericUpDown1.Value);
                                    }
                                    if ("Pogreshnost".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.Pogreshnost2 = k.FirstChild.Value; //Дата
                                        _Analis.textBox3.Text = _Analis.Pogreshnost2;
                                    }
                                    if ("Ispolnitel".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.Ispolnitel = k.FirstChild.Value; //Исполнитель
                                    }
                                    /*  Stolbec = new string[this.Table1.Rows.Count - 1, this.Table1.Columns.Count];
                                          for (int i = 0; i < this.Table1.Rows.Count - 1; i++)
                                      {
                                          for (int j = 0; j < this.Table1.Columns.Count; j++)
                                          {
                                              if ("Stolbec".Equals(k.Name) && k.FirstChild != null)
                                              {
                                                  Stolbec[i, j] = k.FirstChild.Value;
                                                  Table1.Rows[i].Cells[j].Value = Stolbec[i, j];
                                              }
                                          }
                                      }*/
                                    if ("TypeIzmer".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.TimeIzmer1 = k.FirstChild.Value;
                                        if (_Analis.TimeIzmer1 == "A (C) - градуировочное уравнение (стандарт)")
                                        {
                                            _Analis.Zavisimoct = "A(C)";
                                        }
                                        else
                                        {
                                            _Analis.Zavisimoct = "C(A)";
                                        }


                                    }

                                    if ("TypeYravn".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.TypeYravn1 = k.FirstChild.Value; //Исполнитель
                                        if (_Analis.SposobZadan != "Ввод коэффициентов")
                                        {
                                            if (_Analis.TypeYravn1 == "Линейное через 0" || _Analis.TypeYravn1 == "Линейное")
                                            {
                                                //  MessageBox.Show("Линейное");
                                                _Analis.Table1.Columns.Add("X*X", "Конц*Конц");
                                                _Analis.Table1.Columns.Add("X*Y", "Асред*Конц");
                                                /*  Table1.Columns["X*X"].Width = 50;
                                                  Table1.Columns["X*Y"].Width = 50;
                                                  Table1.Columns["X*X*X"].Width = 50;
                                                  Table1.Columns["X*X*X*X"].Width = 50;
                                                  Table1.Columns["X*X*Y"].Width = 50;*/
                                            }
                                            else
                                            {
                                                // MessageBox.Show("Квадратичное");
                                                _Analis.Table1.Columns.Add("X*X", "Конц* Конц");
                                                _Analis.Table1.Columns.Add("X*Y", "Асред* Конц");
                                                _Analis.Table1.Columns.Add("X*X*X", "Асред ^3");
                                                _Analis.Table1.Columns.Add("X*X*X*X", "Асред ^4");
                                                _Analis.Table1.Columns.Add("X*X*Y", "Асред ^2*Конц");
                                                /*    Table1.Columns["X*X"].Width = 50;
                                                    Table1.Columns["X*Y"].Width = 50;
                                                    Table1.Columns["X*X*X"].Width = 50;
                                                    Table1.Columns["X*X*X*X"].Width = 50;
                                                    Table1.Columns["X*X*Y"].Width = 50;*/
                                            }
                                        }
                                    }
                                    if (_Analis.SposobZadan != "Ввод коэффициентов")
                                    {
                                        if ("CountSeriyal".Equals(k.Name) && k.FirstChild != null)
                                        {
                                            _Analis.CountSeriya2 = k.FirstChild.Value; //Количество столбцов
                                            _Analis.CountSeriya = _Analis.CountSeriya2;
                                            while (true)
                                            {
                                                int i = _Analis.Table1.Columns.Count - 1;//С какого столбца начать
                                                if (_Analis.Table1.Columns[i].Name == "Asred")
                                                    break;
                                                _Analis.Table1.Columns.RemoveAt(i);
                                            }
                                            for (int i = 1; i <= Convert.ToInt32(_Analis.CountSeriya2); i++)
                                            {

                                                DataGridViewTextBoxColumn firstColumn2 =
                                                new DataGridViewTextBoxColumn();
                                                firstColumn2.HeaderText = "A; Сер" + i;
                                                firstColumn2.Name = "A;Ser (" + i;
                                                _Analis.Table1.Columns.Add(firstColumn2);
                                            }
                                            for (int i = 1; i <= Convert.ToInt32(_Analis.CountSeriya2); i++)
                                            {
                                                _Analis.Table1.Columns["A;Ser (" + i].Width = 50;
                                            }
                                            _Analis.Table1.Columns[1].HeaderText = "Конц " + _Analis.edconctr;
                                        }

                                        if ("edconctr".Equals(k.Name) && k.FirstChild != null)
                                        {
                                            _Analis.edconctr = k.FirstChild.Value;
                                            _Analis.Table1.Columns[1].HeaderText = "Конц " + _Analis.edconctr;
                                        }
                                        if ("CountInSeriyal".Equals(k.Name) && k.FirstChild != null)
                                        {
                                            _Analis.CountInSeriya2 = k.FirstChild.Value; //Количество строк
                                            _Analis.CountInSeriya = _Analis.CountInSeriya2;
                                            _Analis.NoCaSer = Convert.ToInt32(_Analis.CountInSeriya);
                                            if (_Analis.USE_KO == false)
                                            {
                                                for (int i = 0; i < _Analis.NoCaSer; i++)
                                                {
                                                    _Analis.Table1.Rows.Add();
                                                }
                                            }
                                            else
                                            {
                                                for (int i = 0; i < (_Analis.NoCaSer + 1); i++)
                                                {
                                                    _Analis.Table1.Rows.Add();
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if ("edconctr".Equals(k.Name) && k.FirstChild != null)
                                        {
                                            _Analis.edconctr = k.FirstChild.Value;
                                        }

                                        if ("k0".Equals(k.Name) && k.FirstChild != null)
                                        {
                                            _Analis.AgroText0.Text = k.FirstChild.Value;
                                            _Analis.k0 = Convert.ToDouble(_Analis.AgroText0.Text);

                                        }
                                        if ("k1".Equals(k.Name) && k.FirstChild != null)
                                        {
                                            _Analis.AgroText1.Text = k.FirstChild.Value;
                                            _Analis.k1 = Convert.ToDouble(_Analis.AgroText1.Text);

                                        }
                                        if ("k2".Equals(k.Name) && k.FirstChild != null)
                                        {
                                            _Analis.AgroText2.Text = k.FirstChild.Value;

                                            _Analis.k2 = Convert.ToDouble(_Analis.AgroText2.Text);
                                        }
                                    }

                                }

                            }
                        }
                        if (_Analis.TypeYravn1 == "Линейное через 0")
                        {
                            _Analis.aproksim = "Линейная через 0";
                        }
                        else
                        {
                            if (_Analis.TypeYravn1 == "Линейное")
                            {
                                _Analis.aproksim = "Линейная";
                            }
                            else
                            {
                                _Analis.aproksim = "Квадратичная";
                            }
                        }
                        if (_Analis.SposobZadan != "Ввод коэффициентов")
                        {
                            if (_Analis.USE_KO == false)
                            {
                                if (_Analis.TypeYravn1 == "Линейное через 0" || _Analis.TypeYravn1 == "Линейное")
                                {
                                    _Analis.StolbecCol = 5 + Convert.ToInt32(_Analis.CountSeriya2);
                                }
                                else
                                {
                                    _Analis.StolbecCol = 8 + Convert.ToInt32(_Analis.CountSeriya2);
                                }
                                _Analis.Stolbec = new string[Convert.ToInt32(_Analis.CountInSeriya2), _Analis.StolbecCol];
                                _Analis.CellColor = new string[Convert.ToInt32(_Analis.CountInSeriya2), _Analis.StolbecCol];
                            }
                            else
                            {
                                if (_Analis.TypeYravn1 == "Линейное через 0" || _Analis.TypeYravn1 == "Линейное")
                                {
                                    _Analis.StolbecCol = 5 + Convert.ToInt32(_Analis.CountSeriya2);
                                }
                                else
                                {
                                    _Analis.StolbecCol = 8 + Convert.ToInt32(_Analis.CountSeriya2);
                                }
                                _Analis.Stolbec = new string[(Convert.ToInt32(_Analis.CountInSeriya2) + 1), _Analis.StolbecCol];
                                _Analis.CellColor = new string[(Convert.ToInt32(_Analis.CountInSeriya2) + 1), _Analis.StolbecCol];
                            }
                            int stroka = 0;

                            // Читаем в цикле вложенные значения Stroka

                            for (XmlNode d = n.FirstChild; d != null; d = d.NextSibling)
                            {

                                // Обрабатываем в цикле только Stroka
                                if ("Stroka".Equals(d.Name))
                                {
                                    int stolbec = 0;
                                    //Можно, например, в этом цикле, да и не только..., взять какие-то данные
                                    for (XmlNode k = d.FirstChild; k != null; k = k.NextSibling)
                                    {


                                        if ("Stolbec".Equals(k.Name) && k.FirstChild != null)
                                        {

                                            _Analis.Stolbec[stroka, stolbec] = k.FirstChild.Value;
                                            if (k.Attributes.Count > 0)
                                            {
                                                XmlNode attr = k.Attributes.GetNamedItem("Hand");
                                                if (attr != null)
                                                    _Analis.CellColor[stroka, stolbec] = attr.Value;
                                            }

                                            stolbec++;
                                        }

                                    }
                                    stroka++;
                                }

                            }
                        }
                        else
                        {
                            functionA();
                        }
                    }
                }
                if (_Analis.ComPort == true)
                {
                    SW2();
                }
                else
                {
                    //   GWNew.Text = wavelength1;
                }
            }

        }
        public void SW2()
        {
            LogoForm2 logoform = new LogoForm2();
            string SWText1 = _Analis.wavelength1;
            _Analis.newPort.Write("SW " + _Analis.wavelength1 + "\r");
            //  Thread.Sleep(20000);
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
            _Analis.GWNew.Text = _Analis.wavelength1;
            Application.OpenForms["LogoForm2"].Close();
            // GW();
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
        }
        //string filepath;
        public void IzmerenieFR_Open()
        {
            _Analis.openFileDialog1.InitialDirectory = "C";
            _Analis.openFileDialog1.Title = "Open File";
            _Analis.openFileDialog1.FileName = "";
            _Analis.openFileDialog1.Filter = "ISFR2 файл|*.isfr2";
            if (_Analis.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _Analis.filepath = _Analis.openFileDialog1.FileName;
                    // получаем выбранный файл
                    IzmerenieFR_openFile(ref _Analis.filepath);
                    _Analis.button11.Enabled = true;
                    //  button10.Enabled = true;
                    _Analis.button3.Enabled = true;
                    _Analis.button9.Enabled = false;
                }
                catch (Exception t) { MessageBox.Show("exeption" + t.Message); }
            }
        }

        public void Open1()
        {
            _Analis.openFileDialog1.InitialDirectory = "C";
            _Analis.openFileDialog1.Title = "Open File";
            _Analis.openFileDialog1.FileName = "";
            _Analis.openFileDialog1.Filter = "QA2 файл|*.qa2";
            if (_Analis.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // получаем выбранный файл
                    openFile2(ref _Analis.filepath2, ref _Analis.filepath, ref _Analis.filepathFull);
                    _Analis.button11.Enabled = true;
                    _Analis.Table2.Rows.Add();
                }
                catch (Exception t) { MessageBox.Show("exeption" + t.Message); }



            }
        }
        public void IzmerenieFR_RowsRemove2()
        {
            _Analis.IzmerenieFR_Table.Rows.Clear();
        }
        public void IzmerenieFR_openFile(ref string filepath)
        {
            IzmerenieFR_RowsRemove2();
            string RowsCount = "";
            //  DecriptorFile decriptorfile = new DecriptorFile(ref filepath, _Analis.pathTemp);
            Decriptor64 decriptorfile = new Decriptor64(ref filepath, _Analis.pathTemp, ref shifrTrueFalse);
            if (shifrTrueFalse == false)
            {
                MessageBox.Show("Формат файла не поддерживается!");
                return;
            }
            else
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(_Analis.pathTemp + filepath);

                XmlNodeList nodes = xDoc.ChildNodes;
                XDocument xdoc = XDocument.Load(_Analis.pathTemp + filepath);
                foreach (XElement IzmerenieElement in xdoc.Element("Data_Izmerenie").Elements("Izmerenie"))
                {
                    XElement countIzmer1Element = IzmerenieElement.Element("countIzmer1");
                    XElement DescriptionElement = IzmerenieElement.Element("Description");
                    XElement DateTimeElement = IzmerenieElement.Element("DateTime");
                    XElement IspolnitelElement = IzmerenieElement.Element("Ispolnitel");
                    if (countIzmer1Element != null && DescriptionElement != null && DateTimeElement != null && IspolnitelElement != null)
                    {
                        _Analis.DateTime = DateTimeElement.Value;
                        _Analis.Description = DescriptionElement.Value;
                        _Analis.Ispolnitel = IspolnitelElement.Value;
                        RowsCount = countIzmer1Element.Value; //Количество строк

                        for (int i = 0; i < Convert.ToInt32(RowsCount); i++)
                        {
                            _Analis.IzmerenieFR_Table.Rows.Add();
                        }
                        _Analis.StolbecCol_1 = 7;

                        _Analis.Stolbec_1 = new string[Convert.ToInt32(RowsCount), _Analis.StolbecCol_1];
                    }
                    XElement Direction = IzmerenieElement.Element("Direction");
                    XElement Code = IzmerenieElement.Element("Code");
                    XElement Address = IzmerenieElement.Element("Address");
                    XElement NameLab = IzmerenieElement.Element("NameLab");
                    if (Direction != null && Code != null && Address != null && NameLab != null)
                    {
                        _Analis.direction = Direction.Value;
                        _Analis.code = Code.Value;
                        _Analis.address_lab = Address.Value;
                        _Analis.name_lab = NameLab.Value;
                    }
                }

                int stroka = 0;

                // Читаем в цикле вложенные значения Stroka
                foreach (XmlNode n in nodes)
                {
                    if ("Data_Izmerenie".Equals(n.Name))
                    {
                        for (XmlNode d = n.FirstChild; d != null; d = d.NextSibling)
                        {

                            // Обрабатываем в цикле только Stroka
                            if ("Stroka".Equals(d.Name))
                            {
                                int stolbec = 0;
                                //Можно, например, в этом цикле, да и не только..., взять какие-то данные
                                for (XmlNode k = d.FirstChild; k != null; k = k.NextSibling)
                                {


                                    if ("Stolbec".Equals(k.Name) && k.FirstChild != null)
                                    {

                                        _Analis.Stolbec_1[stroka, stolbec] = k.FirstChild.Value;


                                        stolbec++;
                                    }

                                }
                                stroka++;
                            }

                        }
                    }
                }
                IzmerenieFR_Table_Write();
            }

        }
        public void IzmerenieFR_Table_Write()
        {
            int StolbecCol_1 = 7;
            for (int i = 0; i < (_Analis.Stolbec_1.Length / StolbecCol_1); i++)
            {
                for (int j = 0; j < StolbecCol_1; j++)
                {

                    _Analis.IzmerenieFR_Table.Rows[i].Cells[j].Value = _Analis.Stolbec_1[i, j];
                }

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
        public void WLREMOVESTR2()
        {
            _Analis.Table2.Rows.Clear();

        }
        public bool shifrTrueFalse = false;
        public void openFile2(ref string filepath2, ref string filepath, ref string filepathFull)
        {
            WLREMOVE2();
            WLREMOVESTR2();
            filepath2 = _Analis.openFileDialog1.FileName;
            _Analis.параметрыToolStripMenuItem.Enabled = true;
            _Analis.button10.Enabled = true;
            bool NotFile = false;
            //  DecriptorFile decriptorfile = new DecriptorFile(ref filepath2, _Analis.pathTemp);
            Decriptor64 decriptorfile = new Decriptor64(ref filepath2, _Analis.pathTemp, ref shifrTrueFalse);
            if (shifrTrueFalse == false)
            {
                MessageBox.Show("Формат файла не поддерживается!");
                return;
            }
            else
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(_Analis.pathTemp + filepath2);

                XmlNodeList nodes = xDoc.ChildNodes;
                foreach (XmlNode n in nodes)
                { // Обрабатываем в цикле только Data_Izmerenie
                    if ("Data_Izmerenie".Equals(n.Name))
                    {
                        // Читаем в цикле вложенные значения Izmerenie


                        for (XmlNode d = n.FirstChild; d != null; d = d.NextSibling)
                        {
                            // Обрабатываем в цикле только Izmerenie
                            if ("Izmerenie".Equals(d.Name))
                            {
                                //Можно, например, в этом цикле, да и не только..., взять какие-то данные
                                for (XmlNode k = d.FirstChild; k != null; k = k.NextSibling)
                                {
                                    if ("filepath".Equals(k.Name) && k.FirstChild != null)
                                    {
                                        _Analis.filepath1 = k.FirstChild.Value;
                                        if (_Analis.filepath1 == filepath)
                                        {
                                            NotFile = true;



                                        }
                                        else
                                        {
                                            NotFile = false;
                                        }

                                    }
                                }
                            }
                        }
                    }
                }
                if (NotFile == false)
                {
                    MessageBox.Show("Внимание!! Открытый файл измерения не соответсвует файлу градуировки!");
                }
                if (NotFile == true)
                {
                    foreach (XmlNode n in nodes)
                    { // Обрабатываем в цикле только Data_Izmerenie
                        if ("Data_Izmerenie".Equals(n.Name))
                        {
                            // Читаем в цикле вложенные значения Izmerenie


                            for (XmlNode d = n.FirstChild; d != null; d = d.NextSibling)
                            {
                                // Обрабатываем в цикле только Izmerenie
                                if ("Izmerenie".Equals(d.Name))
                                {
                                    //Можно, например, в этом цикле, да и не только..., взять какие-то данные
                                    for (XmlNode k = d.FirstChild; k != null; k = k.NextSibling)
                                    {
                                        if ("USE_CO_XML".Equals(k.Name) && k.FirstChild != null)
                                        {
                                            _Analis.USE_CO_XML1 = k.FirstChild.Value;
                                            if (_Analis.USE_CO_XML1 == "true")
                                            {
                                                _Analis.USE_KO_Izmer = true;
                                            }
                                            else
                                            {
                                                _Analis.USE_KO_Izmer = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Обходим значения
                    foreach (XmlNode n in nodes)
                    { // Обрабатываем в цикле только Data_Izmerenie
                        if ("Data_Izmerenie".Equals(n.Name))
                        {
                            // Читаем в цикле вложенные значения Izmerenie
                            for (XmlNode d = n.FirstChild; d != null; d = d.NextSibling)
                            {
                                // Обрабатываем в цикле только Izmerenie
                                if ("Izmerenie".Equals(d.Name))
                                {
                                    //Можно, например, в этом цикле, да и не только..., взять какие-то данные
                                    for (XmlNode k = d.FirstChild; k != null; k = k.NextSibling)
                                    {

                                        if ("WidthCuvet".Equals(k.Name) && k.FirstChild != null)
                                        {
                                            _Analis.WidthCuvette = k.FirstChild.Value; //Ширина кюветы
                                            int index = _Analis.Opt_dlin_cuvet.FindString(_Analis.WidthCuvette);
                                            //  MessageBox.Show(index.ToString());
                                            _Analis.Opt_dlin_cuvet.SelectedIndex = index;
                                        }

                                        if ("Description".Equals(k.Name) && k.FirstChild != null)
                                        {
                                            _Analis.Description1 = k.FirstChild.Value; //Примечание
                                            _Analis.textBox8.Text = _Analis.Description1;
                                        }
                                        if ("DateTime".Equals(k.Name) && k.FirstChild != null)
                                        {
                                            _Analis.DateTime = k.FirstChild.Value; //Дата
                                            _Analis.dateTimePicker2.Text = _Analis.DateTime;
                                        }

                                        if ("Pogreshnost".Equals(k.Name) && k.FirstChild != null)
                                        {
                                            _Analis.Pogreshnost2 = k.FirstChild.Value; //Дата
                                            _Analis.textBox7.Text = _Analis.Pogreshnost2;
                                        }
                                        if ("F1".Equals(k.Name) && k.FirstChild != null)
                                        {
                                            _Analis.F1 = k.FirstChild.Value; //F1
                                            _Analis.F1Text.Text = _Analis.F1;
                                        }
                                        if ("F2".Equals(k.Name) && k.FirstChild != null)
                                        {
                                            _Analis.F2 = k.FirstChild.Value; //F1
                                            _Analis.F2Text.Text = _Analis.F2;
                                        }

                                        if ("CountSeriyal".Equals(k.Name) && k.FirstChild != null)
                                        {
                                            _Analis.CountSeriya2 = k.FirstChild.Value; //Количество столбцов
                                            while (true)
                                            {
                                                int i = _Analis.Table2.Columns.Count - 1;//С какого столбца начать
                                                if (_Analis.Table2.Columns[i].Name == "Obrazec")
                                                    break;
                                                _Analis.Table2.Columns.RemoveAt(i);
                                            }

                                            for (int i = 1; i <= Convert.ToInt32(_Analis.CountSeriya2); i++)
                                            {

                                                DataGridViewTextBoxColumn firstColumn2 =
                                                new DataGridViewTextBoxColumn();
                                                firstColumn2.HeaderText = "A; Сер." + i;
                                                firstColumn2.Name = "A;Ser" + i;
                                                firstColumn2.ValueType = Type.GetType("System.Double");
                                                _Analis.Table2.Columns.Add(firstColumn2);
                                                DataGridViewTextBoxColumn firstColumn3 =
                                                new DataGridViewTextBoxColumn();
                                                firstColumn3.HeaderText = "C, " + _Analis.edconctr + "; Сер." + i;
                                                firstColumn3.Name = "C,edconctr;Ser." + i;
                                                firstColumn3.ValueType = Type.GetType("System.Double");
                                                firstColumn3.ReadOnly = true;
                                                _Analis.Table2.Columns.Add(firstColumn3);
                                                firstColumn3.Width = 50;
                                                firstColumn2.Width = 50;

                                            }
                                            DataGridViewTextBoxColumn firstColumn4 =
                                            new DataGridViewTextBoxColumn();
                                            firstColumn4.HeaderText = "Cср, " + _Analis.edconctr;
                                            firstColumn4.Name = "Ccr";
                                            firstColumn4.ReadOnly = true;
                                            firstColumn4.ValueType = Type.GetType("System.Double");
                                            _Analis.Table2.Columns.Add(firstColumn4);

                                            DataGridViewTextBoxColumn firstColumn5 =
                                            new DataGridViewTextBoxColumn();
                                            firstColumn5.HeaderText = "d, %";
                                            firstColumn5.Name = "d%";
                                            firstColumn5.ReadOnly = true;
                                            firstColumn5.ValueType = Type.GetType("System.Double");
                                            _Analis.Table2.Columns.Add(firstColumn5);
                                            firstColumn4.Width = 100;
                                            firstColumn5.Width = 50;
                                        }
                                        if ("CountInSeriyal".Equals(k.Name) && k.FirstChild != null)
                                        {
                                            _Analis.CountInSeriya2 = k.FirstChild.Value; //Количество строк
                                            _Analis.NoCaSer1 = Convert.ToInt32(_Analis.CountInSeriya2);
                                            if (_Analis.USE_KO == false)
                                            {
                                                for (int i = 0; i < Convert.ToInt32(_Analis.CountInSeriya2); i++)
                                                {
                                                    _Analis.Table2.Rows.Add();
                                                }
                                                _Analis.StolbecCol_1 = 2 + Convert.ToInt32(_Analis.CountSeriya2) + Convert.ToInt32(_Analis.CountSeriya2) + 2;

                                                _Analis.Stolbec_1 = new string[Convert.ToInt32(_Analis.CountInSeriya2), _Analis.StolbecCol_1];

                                                _Analis.CellColor = new string[Convert.ToInt32(_Analis.CountInSeriya2), _Analis.StolbecCol_1];
                                                //Table2.Rows.Add();
                                            }
                                            else
                                            {
                                                if (_Analis.USE_KO_Izmer == false && _Analis.USE_KO == true)
                                                {
                                                    _Analis.Table2.Rows.Add(0, "Контрольный");
                                                    for (int i = 0; i < Convert.ToInt32(_Analis.CountInSeriya2) + 1; i++)
                                                    {
                                                        _Analis.Table2.Rows.Add();
                                                    }
                                                    _Analis.StolbecCol_1 = 2 + Convert.ToInt32(_Analis.CountSeriya2) + Convert.ToInt32(_Analis.CountSeriya2) + 2;

                                                    _Analis.Stolbec_1 = new string[Convert.ToInt32(_Analis.CountInSeriya2) + 1, _Analis.StolbecCol_1];

                                                    _Analis.CellColor = new string[Convert.ToInt32(_Analis.CountInSeriya2), _Analis.StolbecCol_1];
                                                    //Table2.Rows.Add();
                                                }
                                                else
                                                {
                                                    for (int i = 0; i < (Convert.ToInt32(_Analis.CountInSeriya2) + 1); i++)
                                                    {
                                                        _Analis.Table2.Rows.Add();
                                                    }
                                                    // Table2.Rows.Add();
                                                    _Analis.StolbecCol_1 = 2 + Convert.ToInt32(_Analis.CountSeriya2) + Convert.ToInt32(_Analis.CountSeriya2) + 2;

                                                    _Analis.Stolbec_1 = new string[(Convert.ToInt32(_Analis.CountInSeriya2) + 1), _Analis.StolbecCol_1];
                                                    _Analis.CellColor = new string[(Convert.ToInt32(_Analis.CountInSeriya2) + 1), _Analis.StolbecCol_1];
                                                }
                                            }
                                        }

                                    }

                                }
                            }

                            int stroka = 0;

                            // Читаем в цикле вложенные значения Stroka

                            for (XmlNode d = n.FirstChild; d != null; d = d.NextSibling)
                            {

                                // Обрабатываем в цикле только Stroka
                                if ("Stroka".Equals(d.Name))
                                {
                                    int stolbec = 0;
                                    //Можно, например, в этом цикле, да и не только..., взять какие-то данные
                                    for (XmlNode k = d.FirstChild; k != null; k = k.NextSibling)
                                    {


                                        if ("Stolbec".Equals(k.Name) && k.FirstChild != null)
                                        {

                                            _Analis.Stolbec_1[stroka, stolbec] = k.FirstChild.Value;
                                            if (k.Attributes.Count > 0)
                                            {
                                                XmlNode attr = k.Attributes.GetNamedItem("Hand");
                                                if (attr != null)
                                                    _Analis.CellColor[stroka, stolbec] = attr.Value;
                                            }

                                            stolbec++;
                                        }

                                    }
                                    stroka++;
                                }

                            }
                        }
                    }
                    TableWrite2();
                    _Analis.button3.Enabled = true;
                    _Analis.button9.Enabled = false;
                    _Analis.печатьToolStripMenuItem1.Enabled = true;
                }


            }
        }
        public void TableWrite2()
        {

            int StolbecCol_1 = 2 + Convert.ToInt32(_Analis.CountSeriya2) + Convert.ToInt32(_Analis.CountSeriya2) + 2;

            if (_Analis.USE_KO == false)
            {
                for (int i = 0; i < Convert.ToInt32(_Analis.CountInSeriya2); i++)
                {
                    for (int j = 0; j < StolbecCol_1; j++)
                    {
                        if (_Analis.CellColor[i, j] == "Pink")
                        {
                            _Analis.Table2.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.Pink;
                        }
                        else
                        {
                            _Analis.Table2.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.White;
                        }
                        _Analis.Table2.Rows[i].Cells[j].Value = _Analis.Stolbec_1[i, j];
                    }

                }
            }
            else
            {
                if (_Analis.USE_KO_Izmer == false && _Analis.USE_KO == true)
                {
                    for (int i = 1; i < (Convert.ToInt32(_Analis.CountInSeriya2) + 1); i++)
                    {
                        for (int j = 0; j < StolbecCol_1; j++)
                        {
                            if (_Analis.CellColor[i, j] == "Pink")
                            {
                                _Analis.Table2.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.Pink;
                            }
                            else
                            {
                                _Analis.Table2.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.White;
                            }
                            _Analis.Table2.Rows[i].Cells[j].Value = _Analis.Stolbec_1[i - 1, j];
                        }

                    }
                }
                else
                {
                    for (int i = 0; i < (Convert.ToInt32(_Analis.CountInSeriya2) + 1); i++)
                    {
                        for (int j = 0; j < StolbecCol_1; j++)
                        {
                            if (_Analis.CellColor[i, j] == "Pink")
                            {
                                _Analis.Table2.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.Pink;
                            }
                            else
                            {
                                _Analis.Table2.Rows[i].Cells[j].Style.BackColor = System.Drawing.Color.White;
                            }
                            _Analis.Table2.Rows[i].Cells[j].Value = _Analis.Stolbec_1[i, j];
                        }

                    }
                }
            }
            _Analis.NoCaIzm1 = Convert.ToInt32(_Analis.CountSeriya2);
            _Analis.OpenIzmer1 = true;
            if (_Analis.button12.Enabled == true && _Analis.OpenIzmer1 == true)
            {
                _Analis.IzmerCreate = true;
            }
            else
            {
                _Analis.IzmerCreate = false;
            }
            if (_Analis.IzmerCreate == true)
            {
                _Analis.button14.Enabled = true;
            }
            else
            {
                _Analis.button14.Enabled = false;
            }

        }
    }
}