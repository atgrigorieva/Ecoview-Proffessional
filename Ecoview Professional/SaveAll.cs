using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Ecoview_Professional
{
    class SaveAll
    {
        Ecoview _Analis;
        public SaveAll(Ecoview parent)
        {
            this._Analis = parent;

            switch (_Analis.selet_rezim)
            {
                case 2:
                    if (_Analis.tabControl2.SelectedIndex == 0)
                    {
                        if ((_Analis.Table1.RowCount < 1) && _Analis.SposobZadan == "По СО")
                        {
                            MessageBox.Show("Создайте Градуировку");

                        }
                        else
                        {
                            Save();
                        }
                    }
                    else
                    {
                        if (_Analis.Table2.RowCount > 0)
                        {
                            Save1();
                        }
                        else
                        {
                            MessageBox.Show("Создайте Измерение");
                        }
                    }
                    break;
                case 1:
                    SaveFR();
                    _Analis.label27.Visible = false;
                    _Analis.Podskazka.Text = "Можно проводить новые измерения!";
                    _Analis.label25.Visible = true;
                    break;
                case 6:
                    if (_Analis.tabControl2.SelectedIndex == 0)
                    {
                        if ((_Analis.Table1.RowCount < 1) && _Analis.SposobZadan == "По СО")
                        {
                            MessageBox.Show("Создайте Градуировку");

                        }
                        else
                        {
                            Save();
                        }
                    }
                    else
                    {
                        if (_Analis.Table2.RowCount > 0)
                        {
                            Save1();
                        }
                        else
                        {
                            MessageBox.Show("Создайте Измерение");
                        }
                    }
                    break;
                case 5:
                    if (_Analis.ScanTable.RowCount < 2)
                    {
                        MessageBox.Show("Создайте измерение");
                    }
                    else
                    {
                        SaveScan();
                        _Analis.label27.Visible = false;
                        _Analis.Podskazka.Text = "Можно проводить новые измерения!";
                        _Analis.label25.Visible = true;
                    }
                    break;
                case 4:
                    if (_Analis.TableKinetica1.RowCount < 2)
                    {
                        MessageBox.Show("Создайте измерение");
                    }
                    else
                    {
                        SaveKin();
                        _Analis.label27.Visible = false;
                        _Analis.Podskazka.Text = "Можно проводить новые измерения!";
                        _Analis.label25.Visible = true;
                    }
                    break;
                case 3:
                    if (_Analis.dataGridView5.Rows.Count < 2)
                    {
                        MessageBox.Show("Создайте измерение");
                    }
                    else
                    {
                        SaveMulti();
                        _Analis.label27.Visible = false;
                        _Analis.Podskazka.Text = "Можно проводить новые измерения!";
                        _Analis.label25.Visible = true;
                    }
                    break;
            }



        }
        public void SaveMulti()
        {
            bool doNotWrite = false;
            for (int j = 0; j < _Analis.dataGridView5.RowCount - 1; j++)
            {
                for (int i = 0; i < _Analis.dataGridView5.Rows[j].Cells.Count; i++)
                {
                    if (_Analis.dataGridView5.Rows[j].Cells[i].Value == null)
                    {
                        doNotWrite = true;
                        break;
                    }
                }
            }
            if (doNotWrite)
            {
                MessageBox.Show("Не вся поля таблицы были заполнены!");
            }
            else
            {
                SaveAsMultiTable();
            }
        }
        public void SaveKin()
        {
            bool doNotWrite = false;
            for (int j = 0; j < _Analis.TableKinetica1.RowCount - 1; j++)
            {
                for (int i = 0; i < _Analis.TableKinetica1.Rows[j].Cells.Count; i++)
                {
                    if (_Analis.TableKinetica1.Rows[j].Cells[i].Value == null)
                    {
                        doNotWrite = true;
                        break;
                    }
                }
            }
            if (doNotWrite)
            {
                MessageBox.Show("Не вся поля таблицы были заполнены!");
            }
            else
            {
                SaveAsKinTable();
            }
        }
        public void SaveScan()
        {
            bool doNotWrite = false;
            for (int j = 0; j < _Analis.ScanTable.RowCount - 1; j++)
            {
                for (int i = 0; i < _Analis.ScanTable.Rows[j].Cells.Count; i++)
                {
                    if (_Analis.ScanTable.Rows[j].Cells[i].Value == null)
                    {
                        doNotWrite = true;
                        break;
                    }
                }
            }
            if (doNotWrite)
            {
                MessageBox.Show("Не вся поля таблицы были заполнены!");
            }
            else
            {
                SaveAsScanTable();
            }
        }
        public void SaveFR()
        {
            bool doNotWrite = false;
            for (int j = 0; j < _Analis.IzmerenieFR_Table.Rows.Count - 1; j++)
            {

                for (int i = 3; i < _Analis.IzmerenieFR_Table.Rows[j].Cells.Count; i++)
                {
                    if (_Analis.IzmerenieFR_Table.Rows[j].Cells[i].Value == null)
                    {
                        doNotWrite = true;
                        break;

                    }
                }
            }
            if (doNotWrite == true)
            {
                MessageBox.Show("Не вся поля таблицы были заполнены!");
            }
            else
            {
                SaveAsIzmerenieFR();
            }
        }

        public void Save()
        {
            if (_Analis.SposobZadan != "Ввод коэффициентов")
            {
                bool doNotWrite = false;
                for (int j = 0; j < _Analis.Table1.Rows.Count - 1; j++)
                {

                    for (int i = 3; i < _Analis.Table1.Rows[j].Cells.Count; i++)
                    {
                        if (_Analis.Table1.Rows[j].Cells[i].Value == null)
                        {
                            doNotWrite = true;
                            break;

                        }
                    }
                }
                if (doNotWrite == true)
                {
                    MessageBox.Show("Не вся поля таблицы были заполнены!");
                }
                else
                {
                    SaveAs1();


                }
            }
            else
            {
                SaveAs1();

            }

        }
        public void Save1()
        {
            bool doNotWrite = false;
            for (int j = 0; j < _Analis.Table2.Rows.Count - 1; j++)
            {

                for (int i = 2; i < _Analis.Table2.Rows[j].Cells.Count; i++)
                {
                    if (_Analis.Table2.Rows[j].Cells[i].Value == null)
                    {
                        doNotWrite = true;
                        break;

                    }
                }
            }
            if (doNotWrite == true)
            {
                MessageBox.Show("Не вся поля таблицы были заполнены!");
            }
            else
            {
                SaveAs2();
            }
        }
        public void SaveAs1()
        {
            if (_Analis.selet_rezim == 2)
            {
                _Analis.saveFileDialog1.InitialDirectory = "C";
                _Analis.saveFileDialog1.Title = "Save as XML File";
                _Analis.saveFileDialog1.FileName = "";
                _Analis.saveFileDialog1.Filter = "QS2 файл|*.qs2";
            }
            else
            {
                _Analis.saveFileDialog1.InitialDirectory = "C";
                _Analis.saveFileDialog1.Title = "Save as XML File";
                _Analis.saveFileDialog1.FileName = "";
                _Analis.saveFileDialog1.Filter = "Agro QS2 файл|*.aq2";
            }
            if (_Analis.saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                CreateXMLDocument(ref _Analis.filepath);
                WriteXml(ref _Analis.filepath);
                _Analis.button3.Enabled = true;
                _Analis.button9.Enabled = false;
                _Analis.печатьToolStripMenuItem1.Enabled = true;
                _Analis.tabPage4.Parent = _Analis.tabControl2;
                if (_Analis.selet_rezim == 6)
                {
                    _Analis.tabControl2.TabPages[1].Text = "Измерение Агро";
                }

                _Analis.Podskazka.Text = "Перейдите в Измерения!";
                _Analis.label27.Visible = false;
                _Analis.label24.Visible = false;
                _Analis.label25.Visible = false;
                _Analis.label26.Visible = false;
                _Analis.label28.Visible = false;
                _Analis.label33.Visible = false;
                string filepathCopy = _Analis.filepath;
                //EncriptorPribor encriptFile = new EncriptorPribor(_Analis.filepath, _Analis.pathTemp);
                EncriptorFileBase64 encriptorFileBase64 = new EncriptorFileBase64(filepathCopy, _Analis.pathTemp);
            }
        }
        public void SaveAsMultiTable()
        {
            _Analis.saveFileDialog1.InitialDirectory = "C";
            _Analis.saveFileDialog1.Title = "Save as XML File";
            _Analis.saveFileDialog1.FileName = "";
            _Analis.saveFileDialog1.Filter = "MULTI2 файл|*.MULTI2";

            if (_Analis.saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                CreateXMLDocumentMULTI(ref _Analis.filepath);
                WriteXmlMULTI(ref _Analis.filepath);
                _Analis.button3.Enabled = true;
                _Analis.button9.Enabled = false;
                _Analis.печатьToolStripMenuItem1.Enabled = true;
                //  EncriptorPribor encriptFile = new EncriptorPribor(_Analis.filepath, _Analis.pathTemp);
                EncriptorFileBase64 encriptorFileBase64 = new EncriptorFileBase64(_Analis.filepath, _Analis.pathTemp);
            }
        }
        public void SaveAsKinTable()
        {
            _Analis.saveFileDialog1.InitialDirectory = "C";
            _Analis.saveFileDialog1.Title = "Save as XML File";
            _Analis.saveFileDialog1.FileName = "";
            _Analis.saveFileDialog1.Filter = "KIN2 файл|*.KIN2";

            if (_Analis.saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                CreateXMLDocumentIzmerenieKin(ref _Analis.filepath);
                WriteXmlKin(ref _Analis.filepath);
                _Analis.button3.Enabled = true;
                _Analis.button9.Enabled = false;
                _Analis.label28.Visible = false;
                _Analis.label59.Visible = false;
                _Analis.label27.Visible = false;
                _Analis.печатьToolStripMenuItem1.Enabled = true;
                /// EncriptorPribor encriptFile = new EncriptorPribor(_Analis.filepath, _Analis.pathTemp);
                EncriptorFileBase64 encriptorFileBase64 = new EncriptorFileBase64(_Analis.filepath, _Analis.pathTemp);
            }
        }
        public void SaveAsScanTable()
        {
            _Analis.saveFileDialog1.InitialDirectory = "C";
            _Analis.saveFileDialog1.Title = "Save as XML File";
            _Analis.saveFileDialog1.FileName = "";
            _Analis.saveFileDialog1.Filter = "SCAN2 файл|*.SCAN2";

            if (_Analis.saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                CreateXMLDocumentIzmerenieScan(ref _Analis.filepath);
                WriteXmlIzmerenieScan(ref _Analis.filepath);
                _Analis.button3.Enabled = true;
                _Analis.button9.Enabled = false;
                _Analis.печатьToolStripMenuItem1.Enabled = true;
                //  EncriptorPribor encriptFile = new EncriptorPribor(_Analis.filepath, _Analis.pathTemp);
                EncriptorFileBase64 encriptorFileBase64 = new EncriptorFileBase64(_Analis.filepath, _Analis.pathTemp);
            }
        }

        public void SaveAsIzmerenieFR()
        {
            _Analis.saveFileDialog1.InitialDirectory = "C";
            _Analis.saveFileDialog1.Title = "Save as XML File";
            _Analis.saveFileDialog1.FileName = "";
            _Analis.saveFileDialog1.Filter = "ISFR2 файл|*.isfr2";

            if (_Analis.saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                CreateXMLDocumentIzmerenieFR(ref _Analis.filepath);
                WriteXmlIzmerenieFR(ref _Analis.filepath);
                _Analis.button3.Enabled = true;
                _Analis.button9.Enabled = false;
                _Analis.печатьToolStripMenuItem1.Enabled = true;
                //  EncriptorPribor encriptFile = new EncriptorPribor(_Analis.filepath, _Analis.pathTemp);
                EncriptorFileBase64 encriptorFileBase64 = new EncriptorFileBase64(_Analis.filepath, _Analis.pathTemp);
            }
        }

        public void CreateXMLDocumentIzmerenieScan(ref string filepath)
        {
            filepath = _Analis.saveFileDialog1.FileName;
             XmlTextWriter xtw = new XmlTextWriter(filepath, Encoding.UTF8);

            xtw.WriteStartDocument();
            xtw.WriteStartElement("Data_Izmerenie");
            xtw.WriteEndDocument();
            xtw.Close();
        }
        public void CreateXMLDocumentMULTI(ref string filepath)
        {
            filepath = _Analis.saveFileDialog1.FileName;
            XmlTextWriter xtw = new XmlTextWriter(filepath, Encoding.UTF8);

            xtw.WriteStartDocument();
            xtw.WriteStartElement("Data_Izmerenie");
            xtw.WriteEndDocument();
            xtw.Close();
        }
        public void CreateXMLDocumentIzmerenieKin(ref string filepath)
        {
            filepath = _Analis.saveFileDialog1.FileName;
            XmlTextWriter xtw = new XmlTextWriter(filepath, Encoding.UTF8);

            xtw.WriteStartDocument();
            xtw.WriteStartElement("Data_Izmerenie");
            xtw.WriteEndDocument();
            xtw.Close();
        }
        private void CreateXMLDocument(ref string filepath)
        {

            filepath = _Analis.saveFileDialog1.FileName;
            XmlTextWriter xtw = new XmlTextWriter(filepath, Encoding.UTF8);

            xtw.WriteStartDocument();
            xtw.WriteStartElement("Data_Izmerenie");
            xtw.WriteEndDocument();
            xtw.Close();
        }
        public void WriteXmlMULTI(ref string filepath)
        {
            XmlDocument xd = new XmlDocument();
           FileStream fs = new FileStream(filepath, FileMode.Open);
            xd.Load(fs);
            XmlNode Izmerenie = xd.CreateElement("Izmerenie");

            XmlNode Direction = xd.CreateElement("Direction"); // Примечание
            Direction.InnerText = _Analis.direction; // и значение
            Izmerenie.AppendChild(Direction); // и указываем кому принадлежит


            XmlNode Code = xd.CreateElement("Code"); // Примечание
            Code.InnerText = _Analis.code; // и значение
            Izmerenie.AppendChild(Code); // и указываем кому принадлежит

            XmlNode Address = xd.CreateElement("Address"); // Примечание
            Address.InnerText = _Analis.address_lab; // и значение
            Izmerenie.AppendChild(Address); // и указываем кому принадлежит

            XmlNode NameLab = xd.CreateElement("NameLab"); // Примечание
            NameLab.InnerText = _Analis.name_lab; // и значение
            Izmerenie.AppendChild(NameLab); // и указываем кому принадлежит


            XmlNode DateTime1 = xd.CreateElement("DateTime"); // дата создания градуировки
            DateTime1.InnerText = _Analis.DateTime; // и значение
            Izmerenie.AppendChild(DateTime1); // и указываем кому принадлежит

            XmlNode Ispolnitel1 = xd.CreateElement("Ispolnitel"); // Примечание
            Ispolnitel1.InnerText = _Analis.Ispolnitel; // и значение
            Izmerenie.AppendChild(Ispolnitel1); // и указываем кому принадлежит


            XmlNode Description1 = xd.CreateElement("Description"); // Примечание
            Description1.InnerText = _Analis.Description; // и значение
            Izmerenie.AppendChild(Description1); // и указываем кому принадлежит

            xd.DocumentElement.AppendChild(Izmerenie);


            XmlNode NumberIzmer = xd.CreateElement("NumberIzmer");


            for (int i = 0; i < _Analis.dataGridView5.RowCount - 1; i++)
            {
                XmlNode Str = xd.CreateElement("Str");
                XmlAttribute attribute2 = xd.CreateAttribute("Nomer");
                attribute2.Value = Convert.ToString(i); // устанавливаем значение атрибута
                Str.Attributes.Append(attribute2); // добавляем атрибут
                NumberIzmer.AppendChild(Str);
                for (int j = 0; j < _Analis.dataGridView5.ColumnCount; j++)
                {
                    //     HeaderCells1 = this.TableKinetica1.Columns[j].HeaderText;
                    if (j <= 1)
                    {
                        XmlNode Cells1 = xd.CreateElement("Cells" + j);
                        XmlAttribute attribute3 = xd.CreateAttribute("TypeCell");
                        attribute3.Value = _Analis.dataGridView5.Columns[j].HeaderText; // устанавливаем значение атрибута
                        Cells1.Attributes.Append(attribute3); // добавляем атрибут
                        Cells1.InnerText = _Analis.dataGridView5.Rows[i].Cells[j].Value.ToString();
                        Str.AppendChild(Cells1);
                    }
                    else
                    {
                        XmlNode Cells1 = xd.CreateElement("Cells");
                        XmlAttribute attribute3 = xd.CreateAttribute("TypeCell1");
                        attribute3.Value = _Analis.dataGridView5.Columns[j].HeaderText; // устанавливаем значение атрибута
                        Cells1.Attributes.Append(attribute3); // добавляем атрибут
                        Cells1.InnerText = _Analis.dataGridView5.Rows[i].Cells[j].Value.ToString();
                        Str.AppendChild(Cells1);
                    }

                    //xd.DocumentElement.AppendChild(Cells1);
                }



                //   xd.DocumentElement.AppendChild(Str);
            }

            xd.DocumentElement.AppendChild(NumberIzmer);

            fs.Close();         // Закрываем поток  
            xd.Save(filepath); // Сохраняем файл  
        }
        public void WriteXmlKin(ref string filepath)
        {
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(filepath, FileMode.Open);
            xd.Load(fs);
            XmlNode Izmerenie = xd.CreateElement("Izmerenie");

            //string HeaderCells1 =;
            XmlNode TypeIzmer = xd.CreateElement("TypeIzmer");
            TypeIzmer.InnerText = _Analis.TableKinetica1.Columns[1].HeaderText;
            Izmerenie.AppendChild(TypeIzmer);

            XmlNode Direction = xd.CreateElement("Direction"); // Примечание
            Direction.InnerText = _Analis.direction; // и значение
            Izmerenie.AppendChild(Direction); // и указываем кому принадлежит


            XmlNode Code = xd.CreateElement("Code"); // Примечание
            Code.InnerText = _Analis.code; // и значение
            Izmerenie.AppendChild(Code); // и указываем кому принадлежит

            XmlNode Address = xd.CreateElement("Address"); // Примечание
            Address.InnerText = _Analis.address_lab; // и значение
            Izmerenie.AppendChild(Address); // и указываем кому принадлежит

            XmlNode NameLab = xd.CreateElement("NameLab"); // Примечание
            NameLab.InnerText = _Analis.name_lab; // и значение
            Izmerenie.AppendChild(NameLab); // и указываем кому принадлежит


            XmlNode DateTime1 = xd.CreateElement("DateTime"); // дата создания градуировки
            DateTime1.InnerText = _Analis.DateTime; // и значение
            Izmerenie.AppendChild(DateTime1); // и указываем кому принадлежит

            XmlNode Ispolnitel1 = xd.CreateElement("Ispolnitel"); // Примечание
            Ispolnitel1.InnerText = _Analis.Ispolnitel; // и значение
            Izmerenie.AppendChild(Ispolnitel1); // и указываем кому принадлежит
            xd.DocumentElement.AppendChild(Izmerenie);

            XmlNode Description1 = xd.CreateElement("Description"); // Примечание
            Description1.InnerText = _Analis.Description; // и значение
            Izmerenie.AppendChild(Description1); // и указываем кому принадлежит

            XmlNode NumberIzmer = xd.CreateElement("NumberIzmer");


            for (int i = 0; i < _Analis.TableKinetica1.RowCount - 1; i++)
            {
                XmlNode Str = xd.CreateElement("Str");
                XmlAttribute attribute2 = xd.CreateAttribute("Nomer");
                attribute2.Value = Convert.ToString(i); // устанавливаем значение атрибута
                Str.Attributes.Append(attribute2); // добавляем атрибут
                NumberIzmer.AppendChild(Str);

                for (int j = 0; j < _Analis.TableKinetica1.ColumnCount; j++)
                {
                    //     HeaderCells1 = this.TableKinetica1.Columns[j].HeaderText;
                    XmlNode Cells1 = xd.CreateElement("Cells" + j);
                    XmlAttribute attribute3 = xd.CreateAttribute("TypeCell");
                    attribute3.Value = _Analis.TableKinetica1.Columns[j].HeaderText; // устанавливаем значение атрибута
                    Cells1.Attributes.Append(attribute3); // добавляем атрибут
                    Cells1.InnerText = _Analis.TableKinetica1.Rows[i].Cells[j].Value.ToString();
                    Str.AppendChild(Cells1);
                    //xd.DocumentElement.AppendChild(Cells1);
                }
                //   xd.DocumentElement.AppendChild(Str);
            }
            xd.DocumentElement.AppendChild(NumberIzmer);

            fs.Close();         // Закрываем поток  
            xd.Save(filepath); // Сохраняем файл  

        }
        public void WriteXmlIzmerenieScan(ref string filepath)
        {
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(filepath, FileMode.Open);
            xd.Load(fs);
            XmlNode Izmerenie = xd.CreateElement("Izmerenie");

            XmlNode CountIzmer = xd.CreateElement("CountIzmer");
            CountIzmer.InnerText = _Analis.listBox1.Items.Count.ToString();
            Izmerenie.AppendChild(CountIzmer);

            _Analis.HeaderCells = new string[1];
            _Analis.HeaderCells[0] = this._Analis.ScanTable.Columns[1].HeaderText;
            XmlNode TypeIzmer = xd.CreateElement("TypeIzmer");
            TypeIzmer.InnerText = _Analis.HeaderCells[0];
            Izmerenie.AppendChild(TypeIzmer);

            // countScan[countButtonClick - 1][i, k]
            xd.DocumentElement.AppendChild(Izmerenie);
            int countIzmer = 0;

            _Analis.HeaderCells = new string[this._Analis.ScanTable.Columns.Count];
            while (countIzmer < _Analis.listBox1.Items.Count)
            {
                XmlNode NumberIzmer = xd.CreateElement("NumberIzmer");
                XmlAttribute attribute1 = xd.CreateAttribute("Nomer");
                attribute1.Value = Convert.ToString(countIzmer); // устанавливаем значение атрибута
                NumberIzmer.Attributes.Append(attribute1); // добавляем атрибут

                XmlNode CountStr = xd.CreateElement("CountStr");
                CountStr.InnerText = _Analis.countScan[countIzmer].GetLength(0).ToString();
                NumberIzmer.AppendChild(CountStr);

                int m = _Analis.countScan[countIzmer].GetLength(0);
                int n = _Analis.countScan[countIzmer].GetLength(1);
                for (int i = 0; i < m; i++)
                {
                    XmlNode Str = xd.CreateElement("Str");
                    XmlAttribute attribute2 = xd.CreateAttribute("Nomer");
                    attribute2.Value = Convert.ToString(i); // устанавливаем значение атрибута
                    Str.Attributes.Append(attribute2); // добавляем атрибут
                    NumberIzmer.AppendChild(Str);

                    for (int j = 0; j < n; j++)
                    {
                        _Analis.HeaderCells[j] = this._Analis.ScanTable.Columns[j].HeaderText;
                        XmlNode Cells1 = xd.CreateElement("Cells" + j);
                        XmlAttribute attribute3 = xd.CreateAttribute("TypeCell");
                        attribute3.Value = _Analis.HeaderCells[j]; // устанавливаем значение атрибута
                        Cells1.Attributes.Append(attribute3); // добавляем атрибут
                        Cells1.InnerText = _Analis.countScan[countIzmer][i, j];
                        Str.AppendChild(Cells1);
                        //xd.DocumentElement.AppendChild(Cells1);
                    }
                    //   xd.DocumentElement.AppendChild(Str);
                }
                xd.DocumentElement.AppendChild(NumberIzmer);
                countIzmer++;
            }



            fs.Close();         // Закрываем поток  
            xd.Save(filepath); // Сохраняем файл  
        }
        public void WriteXml(ref string filepath)
        {
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(filepath, FileMode.Open);
            xd.Load(fs);

            XmlNode Izmerenie = xd.CreateElement("Izmerenie");

            XmlNode Version = xd.CreateElement("Version"); // Версия программы
            Version.InnerText = _Analis.version; // и значение
            Izmerenie.AppendChild(Version); // и указываем кому принадлежит

            XmlNode Nazvanie = xd.CreateElement("Nazvanie"); // Название вещества
            Nazvanie.InnerText = "Расчет градуировочного графика"; // и значение
            Izmerenie.AppendChild(Nazvanie); // и указываем кому принадлежит

            XmlNode Veshestvo = xd.CreateElement("Veshestvo"); // Название вещества
            Veshestvo.InnerText = _Analis.Veshestvo1; // и значение
            Izmerenie.AppendChild(Veshestvo); // и указываем кому принадлежит

            XmlNode wavelength = xd.CreateElement("wavelength"); // Длина волны
            wavelength.InnerText = _Analis.wavelength1; // и значение
            Izmerenie.AppendChild(wavelength); // и указываем кому принадлежит

            XmlNode WidthCuvet1 = xd.CreateElement("WidthCuvet"); // Ширина кюветы
            WidthCuvet1.InnerText = _Analis.WidthCuvette; // и значение
            Izmerenie.AppendChild(WidthCuvet1); // и указываем кому принадлежит

            XmlNode BottomLine1 = xd.CreateElement("BottomLine"); // Нижняя граница
            BottomLine1.InnerText = _Analis.BottomLine; // и значение
            Izmerenie.AppendChild(BottomLine1); // и указываем кому принадлежит

            XmlNode TopLine1 = xd.CreateElement("TopLine"); // Верхняя граница
            TopLine1.InnerText = _Analis.TopLine; // и значение
            Izmerenie.AppendChild(TopLine1); // и указываем кому принадлежит

            XmlNode ND1 = xd.CreateElement("ND"); // НД
            ND1.InnerText = _Analis.ND; // и значение
            Izmerenie.AppendChild(ND1); // и указываем кому принадлежит

            XmlNode Description1 = xd.CreateElement("Description"); // Примечание
            Description1.InnerText = _Analis.Description; // и значение
            Izmerenie.AppendChild(Description1); // и указываем кому принадлежит
            XmlNode Direction = xd.CreateElement("Direction"); // Примечание
            Direction.InnerText = _Analis.direction; // и значение
            Izmerenie.AppendChild(Direction); // и указываем кому принадлежит


            XmlNode Code = xd.CreateElement("Code"); // Примечание
            Code.InnerText = _Analis.code; // и значение
            Izmerenie.AppendChild(Code); // и указываем кому принадлежит

            XmlNode Address = xd.CreateElement("Address"); // Примечание
            Address.InnerText = _Analis.address_lab; // и значение
            Izmerenie.AppendChild(Address); // и указываем кому принадлежит

            XmlNode NameLab = xd.CreateElement("NameLab"); // Примечание
            NameLab.InnerText = _Analis.name_lab; // и значение
            Izmerenie.AppendChild(NameLab); // и указываем кому принадлежит

            XmlNode DateTime1 = xd.CreateElement("DateTime"); // дата создания градуировки
            DateTime1.InnerText = _Analis.DateTime; // и значение
            Izmerenie.AppendChild(DateTime1); // и указываем кому принадлежит

            XmlNode DateTime1_1 = xd.CreateElement("DateTime1_1"); // Действительно до
            DateTime1_1.InnerText = _Analis.label6.Text; // и значение
            Izmerenie.AppendChild(DateTime1_1); // и указываем кому принадлежит

            XmlNode DateTime1_1_1 = xd.CreateElement("DateTime1_1_1"); // Действительно до
            DateTime1_1_1.InnerText = _Analis.numericUpDown1.Value.ToString(); // и значение
            Izmerenie.AppendChild(DateTime1_1_1); // и указываем кому принадлежит

            XmlNode Pogreshnost = xd.CreateElement("Pogreshnost"); // Действительно до
            Pogreshnost.InnerText = _Analis.textBox3.Text; // и значение
            Izmerenie.AppendChild(Pogreshnost); // и указываем кому принадлежит

            XmlNode Ispolnitel1 = xd.CreateElement("Ispolnitel"); // Примечание
            Ispolnitel1.InnerText = _Analis.Ispolnitel; // и значение
            Izmerenie.AppendChild(Ispolnitel1); // и указываем кому принадлежит

            XmlNode CountSeriya1 = xd.CreateElement("CountSeriyal"); // Примечание
            CountSeriya1.InnerText = _Analis.CountSeriya; // и значение
            Izmerenie.AppendChild(CountSeriya1); // и указываем кому принадлежит

            XmlNode CountInSeriya1 = xd.CreateElement("CountInSeriyal"); // Примечание
            CountInSeriya1.InnerText = _Analis.CountInSeriya; // и значение
            Izmerenie.AppendChild(CountInSeriya1); // и указываем кому принадлежит

            XmlNode edconctr1 = xd.CreateElement("edconctr");
            edconctr1.InnerText = _Analis.edconctr;
            Izmerenie.AppendChild(edconctr1);
            XmlNode USE_CO_XML = xd.CreateElement("USE_CO_XML"); // Примечание
            if (_Analis.USE_KO == true)
            {
                USE_CO_XML.InnerText = "true";
            }
            else
            {
                USE_CO_XML.InnerText = "false";
            }

            Izmerenie.AppendChild(USE_CO_XML); // и указываем кому принадлежит

            XmlNode TypeYravn1 = xd.CreateElement("TypeYravn"); // Тип уравнения
            if (_Analis.radioButton1.Checked == true)
            {
                TypeYravn1.InnerText = "Линейное через 0"; // и значение
            }
            else
            {
                if (_Analis.radioButton2.Checked == true)
                {

                    TypeYravn1.InnerText = "Линейное";
                }
                else
                {
                    TypeYravn1.InnerText = "Квадратичное";
                }
            }

            Izmerenie.AppendChild(TypeYravn1); // и указываем кому принадлежит

            XmlNode TypeIzmer1 = xd.CreateElement("TypeIzmer"); // Тип уравнения
            if (_Analis.radioButton4.Checked == true)
            {
                TypeIzmer1.InnerText = "A (C) - градуировочное уравнение (стандарт)"; // и значение
            }
            else
            {
                TypeIzmer1.InnerText = "C (A) - расчетное уравнение (прибор)";
            }

            Izmerenie.AppendChild(TypeIzmer1); // и указываем кому принадлежит

            // ЗАбиваем запись в документ  
            xd.DocumentElement.AppendChild(Izmerenie);
            _Analis.HeaderCells = new string[this._Analis.Table1.Columns.Count];
            _Analis.Cells1 = new string[this._Analis.Table1.Rows.Count - 1, this._Analis.Table1.Columns.Count];

            XmlNode Zavisimoct1 = xd.CreateElement("SposobZadan"); // Примечание
            Zavisimoct1.InnerText = _Analis.SposobZadan; // и значение
            Izmerenie.AppendChild(Zavisimoct1); // и указываем кому принадлежит
            if (_Analis.SposobZadan != "Ввод коэффициентов")
            {
                for (int i = 0; i < this._Analis.Table1.Rows.Count - 1; i++)
                {
                    XmlNode Cells2 = xd.CreateElement("Stroka");

                    XmlAttribute attribute1 = xd.CreateAttribute("Nomer");
                    attribute1.Value = Convert.ToString(i); // устанавливаем значение атрибута
                    Cells2.Attributes.Append(attribute1); // добавляем атрибут
                    for (int j = 0; j < this._Analis.Table1.Columns.Count; j++)
                    {

                        _Analis.Cells1[i, j] = Convert.ToString(this._Analis.Table1.Rows[i].Cells[j].Value);

                        _Analis.HeaderCells[j] = this._Analis.Table1.Columns[j].HeaderText;
                        XmlNode HeaderCells1 = xd.CreateElement("Stolbec"); // Столбец
                        HeaderCells1.InnerText = _Analis.Cells1[i, j]; // и значение
                        Cells2.AppendChild(HeaderCells1); // и указываем кому принадлежит
                        XmlAttribute attribute = xd.CreateAttribute("Header");
                        attribute.Value =_Analis.HeaderCells[j]; // устанавливаем значение атрибута
                        HeaderCells1.Attributes.Append(attribute); // добавляем атрибут

                        XmlAttribute hand = xd.CreateAttribute("Hand");
                        if (_Analis.Table1.Rows[i].Cells[j].Style.BackColor.Name == "Pink")
                        {
                            hand.Value = "Pink"; // устанавливаем значение атрибута
                        }
                        else
                        {
                            hand.Value = "White";
                        }
                        HeaderCells1.Attributes.Append(hand); // добавляем атрибут                    
                    }
                    xd.DocumentElement.AppendChild(Cells2);
                }

            }
            else
            {
                XmlNode k_0 = xd.CreateElement("k0"); // Примечание
                k_0.InnerText = _Analis.AgroText0.Text; // и значение
                Izmerenie.AppendChild(k_0); // и указываем кому принадлежит
                XmlNode k_1 = xd.CreateElement("k1"); // Примечание
                k_1.InnerText = _Analis.AgroText1.Text; // и значение
                Izmerenie.AppendChild(k_1); // и указываем кому принадлежит
                XmlNode k_2 = xd.CreateElement("k2"); // Примечание
                k_2.InnerText = _Analis.AgroText2.Text; // и значение
                Izmerenie.AppendChild(k_2); // и указываем кому принадлежит
            }


            //ds.WriteXml(filepath);

            fs.Close();         // Закрываем поток  
            xd.Save(filepath); // Сохраняем файл  

        }
        public void SaveAs2()
        {
            _Analis.saveFileDialog1.InitialDirectory = "C";
            _Analis.saveFileDialog1.Title = "Save as XML File";
            _Analis.saveFileDialog1.FileName = "";
            _Analis.saveFileDialog1.Filter = "QA2 файл|*.qa2";

            if (_Analis.saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                CreateXMLDocument2(ref _Analis.filepath2);
                WriteXml2(ref _Analis.filepath2, ref _Analis.filepath);
                _Analis.button3.Enabled = true;
                _Analis.button9.Enabled = false;
                _Analis.печатьToolStripMenuItem1.Enabled = true;
                //  EncriptorPribor encriptFile = new EncriptorPribor(_Analis.filepath2, _Analis.pathTemp);
                EncriptorFileBase64 encriptorFileBase64 = new EncriptorFileBase64(_Analis.filepath2, _Analis.pathTemp);
            }
        }
        private void CreateXMLDocument2(ref string filepath2)
        {

            filepath2 = _Analis.saveFileDialog1.FileName;
            XmlTextWriter xtw = new XmlTextWriter(filepath2, Encoding.UTF8);

            xtw.WriteStartDocument();
            xtw.WriteStartElement("Data_Izmerenie");
            xtw.WriteEndDocument();
            xtw.Close();
        }
        public void WriteXml2(ref string filepath2, ref string filepath)
        {
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(filepath2, FileMode.Open);
            xd.Load(fs);

            XmlNode Izmerenie = xd.CreateElement("Izmerenie");

            XmlNode Nazvanie = xd.CreateElement("Nazvanie"); // Название вещества
            Nazvanie.InnerText = "Измерения"; // и значение
            Izmerenie.AppendChild(Nazvanie); // и указываем кому принадлежит

            XmlNode Direction = xd.CreateElement("Direction"); // Примечание
            Direction.InnerText = _Analis.direction; // и значение
            Izmerenie.AppendChild(Direction); // и указываем кому принадлежит


            XmlNode Code = xd.CreateElement("Code"); // Примечание
            Code.InnerText = _Analis.code; // и значение
            Izmerenie.AppendChild(Code); // и указываем кому принадлежит

            XmlNode Address = xd.CreateElement("Address"); // Примечание
            Address.InnerText = _Analis.address_lab; // и значение
            Izmerenie.AppendChild(Address); // и указываем кому принадлежит

            XmlNode NameLab = xd.CreateElement("NameLab"); // Примечание
            NameLab.InnerText = _Analis.name_lab; // и значение
            Izmerenie.AppendChild(NameLab); // и указываем кому принадлежит

            XmlNode WidthCuvet1 = xd.CreateElement("WidthCuvet"); // Ширина кюветы
            WidthCuvet1.InnerText = _Analis.Opt_dlin_cuvet.Text; // и значение
            Izmerenie.AppendChild(WidthCuvet1); // и указываем кому принадлежит

            XmlNode Description1 = xd.CreateElement("Description"); // Примечание
            Description1.InnerText = _Analis.textBox8.Text; // и значение
            Izmerenie.AppendChild(Description1); // и указываем кому принадлежит

            XmlNode DateTime1 = xd.CreateElement("DateTime"); // дата создания градуировки
            DateTime1.InnerText = _Analis.dateTimePicker2.Text; // и значение
            Izmerenie.AppendChild(DateTime1); // и указываем кому принадлежит

            XmlNode Pogreshnost = xd.CreateElement("Pogreshnost"); // Погрешность
            Pogreshnost.InnerText = _Analis.textBox7.Text; // и значение
            Izmerenie.AppendChild(Pogreshnost); // и указываем кому принадлежит

            XmlNode F1 = xd.CreateElement("F1"); // F1
            F1.InnerText = _Analis.F1Text.Text; // и значение
            Izmerenie.AppendChild(F1); // и указываем кому принадлежит

            XmlNode F2 = xd.CreateElement("F2"); // ДF2
            F2.InnerText = _Analis.F2Text.Text; // и значение
            Izmerenie.AppendChild(F2); // и указываем кому принадлежит

            XmlNode Gradfilepath = xd.CreateElement("filepath");
            Gradfilepath.InnerText = filepath;
            Izmerenie.AppendChild(Gradfilepath);

            XmlNode USE_CO_XML = xd.CreateElement("USE_CO_XML"); // Примечание
            if (_Analis.USE_KO == true)
            {
                USE_CO_XML.InnerText = "true";
            }
            else
            {
                USE_CO_XML.InnerText = "false";
            }

            Izmerenie.AppendChild(USE_CO_XML); // и указываем кому принадлежит
            XmlNode CountSeriya1 = xd.CreateElement("CountSeriyal"); // Примечание
            CountSeriya1.InnerText = Convert.ToString(_Analis.NoCaIzm1); // и значение
            Izmerenie.AppendChild(CountSeriya1); // и указываем кому принадлежит

            XmlNode CountInSeriya1 = xd.CreateElement("CountInSeriyal"); // Примечание
            if (_Analis.USE_KO != true)
            {
                CountInSeriya1.InnerText = Convert.ToString(_Analis.Table2.Rows.Count - 1); // и значение
            }
            else {
                CountInSeriya1.InnerText = Convert.ToString(_Analis.Table2.Rows.Count - 2); // и значение
            }
            Izmerenie.AppendChild(CountInSeriya1); // и указываем кому принадлежит

            // ЗАбиваем запись в документ  
            xd.DocumentElement.AppendChild(Izmerenie);
            _Analis.HeaderCells = new string[this._Analis.Table2.Columns.Count];
            _Analis.Cells1 = new string[this._Analis.Table2.Rows.Count - 1, this._Analis.Table2.Columns.Count];

            for (int i = 0; i < this._Analis.Table2.Rows.Count - 1; i++)
            {
                XmlNode Cells2 = xd.CreateElement("Stroka");

                XmlAttribute attribute1 = xd.CreateAttribute("Nomer");
                attribute1.Value = Convert.ToString(i); // устанавливаем значение атрибута
                Cells2.Attributes.Append(attribute1); // добавляем атрибут
                for (int j = 0; j < this._Analis.Table2.Columns.Count; j++)
                {

                    _Analis.Cells1[i, j] = Convert.ToString(this._Analis.Table2.Rows[i].Cells[j].Value);

                    _Analis.HeaderCells[j] = this._Analis.Table2.Columns[j].HeaderText;
                    XmlNode HeaderCells1 = xd.CreateElement("Stolbec"); // Столбец
                    if (_Analis.Cells1[i, j] != "")
                    {
                        HeaderCells1.InnerText = _Analis.Cells1[i, j]; // и значение
                    }
                    else
                    {
                        HeaderCells1.InnerText = "-";
                    }
                    Cells2.AppendChild(HeaderCells1); // и указываем кому принадлежит
                    XmlAttribute attribute = xd.CreateAttribute("Header");
                    attribute.Value = _Analis.HeaderCells[j]; // устанавливаем значение атрибута
                    HeaderCells1.Attributes.Append(attribute); // добавляем атрибут

                    XmlAttribute hand = xd.CreateAttribute("Hand");
                    if (_Analis.Table2.Rows[i].Cells[j].Style.BackColor.Name == "Pink")
                    {
                        hand.Value = "Pink"; // устанавливаем значение атрибута
                    }
                    else
                    {
                        hand.Value = "White";
                    }
                    HeaderCells1.Attributes.Append(hand); // добавляем атрибут                      
                }
                xd.DocumentElement.AppendChild(Cells2);
            }

            fs.Close();         // Закрываем поток  
            xd.Save(filepath2); // Сохраняем файл  

        }
        public void CreateXMLDocumentIzmerenieFR(ref string filepath)
        {
            filepath = _Analis.saveFileDialog1.FileName;
            XmlTextWriter xtw = new XmlTextWriter(filepath, Encoding.UTF8);
            xtw.WriteStartDocument();
            xtw.WriteStartElement("Data_Izmerenie");
            xtw.WriteEndDocument();
            xtw.Close();
        }
        public void WriteXmlIzmerenieFR(ref string filepath)
        {
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(filepath, FileMode.Open);
            xd.Load(fs);

            XmlNode Izmerenie = xd.CreateElement("Izmerenie");

            XmlNode Version = xd.CreateElement("Version"); // Версия программы
            Version.InnerText = _Analis.version; // и значение
            Izmerenie.AppendChild(Version); // и указываем кому принадлежит
            XmlNode Ispolnitel1 = xd.CreateElement("Ispolnitel"); // Примечание
            Ispolnitel1.InnerText = _Analis.Ispolnitel; // и значение
            Izmerenie.AppendChild(Ispolnitel1); // и указываем кому принадлежит

            XmlNode Direction = xd.CreateElement("Direction"); // Примечание
            Direction.InnerText = _Analis.direction; // и значение
            Izmerenie.AppendChild(Direction); // и указываем кому принадлежит


            XmlNode Code = xd.CreateElement("Code"); // Примечание
            Code.InnerText = _Analis.code; // и значение
            Izmerenie.AppendChild(Code); // и указываем кому принадлежит

            XmlNode Address = xd.CreateElement("Address"); // Примечание
            Address.InnerText = _Analis.address_lab; // и значение
            Izmerenie.AppendChild(Address); // и указываем кому принадлежит

            XmlNode NameLab = xd.CreateElement("NameLab"); // Примечание
            NameLab.InnerText = _Analis.name_lab; // и значение
            Izmerenie.AppendChild(NameLab); // и указываем кому принадлежит

            XmlNode Description1 = xd.CreateElement("Description"); // Примечание
            Description1.InnerText = _Analis.Description; // и значение
            Izmerenie.AppendChild(Description1); // и указываем кому принадлежит

            XmlNode DateTime1 = xd.CreateElement("DateTime"); // дата создания градуировки
            DateTime1.InnerText = _Analis.DateTime; // и значение
            Izmerenie.AppendChild(DateTime1); // и указываем кому принадлежит
            int countIzmer = _Analis.IzmerenieFR_Table.Rows.Count - 1;
            XmlNode countIzmer1 = xd.CreateElement("countIzmer1");
            countIzmer1.InnerText = Convert.ToString(countIzmer);
            Izmerenie.AppendChild(countIzmer1);
            xd.DocumentElement.AppendChild(Izmerenie);
            _Analis.HeaderCells = new string[this._Analis.IzmerenieFR_Table.Columns.Count];
            _Analis.Cells1 = new string[this._Analis.IzmerenieFR_Table.Rows.Count - 1, this._Analis.IzmerenieFR_Table.Columns.Count];
            for (int i = 0; i < this._Analis.IzmerenieFR_Table.Rows.Count - 1; i++)
            {
                XmlNode Cells2 = xd.CreateElement("Stroka");

                XmlAttribute attribute1 = xd.CreateAttribute("Nomer");
                attribute1.Value = Convert.ToString(i); // устанавливаем значение атрибута
                Cells2.Attributes.Append(attribute1); // добавляем атрибут
                for (int j = 0; j < this._Analis.IzmerenieFR_Table.Columns.Count; j++)
                {

                    _Analis.Cells1[i, j] = Convert.ToString(this._Analis.IzmerenieFR_Table.Rows[i].Cells[j].Value);

                    _Analis.HeaderCells[j] = this._Analis.IzmerenieFR_Table.Columns[j].HeaderText;
                    XmlNode HeaderCells1 = xd.CreateElement("Stolbec"); // Столбец
                    if (_Analis.Cells1[i, j] != "")
                    {
                        HeaderCells1.InnerText = _Analis.Cells1[i, j]; // и значение
                    }
                    else
                    {
                        HeaderCells1.InnerText = "-";
                    }
                    Cells2.AppendChild(HeaderCells1); // и указываем кому принадлежит
                    XmlAttribute attribute = xd.CreateAttribute("Header");
                    attribute.Value = _Analis.HeaderCells[j]; // устанавливаем значение атрибута
                    HeaderCells1.Attributes.Append(attribute); // добавляем атрибут                    
                }
                xd.DocumentElement.AppendChild(Cells2);
            }

            fs.Close();         // Закрываем поток  
            xd.Save(filepath); // Сохраняем файл  

        }
    }
}
