using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Xml;
using SWF = System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Printing;
using System.Text.RegularExpressions;
using System.Linq;
using System.Globalization;
using Microsoft.Win32;
using System.Xml.Linq;
using System.Data;
using System.Diagnostics;

namespace Ecoview_Professional
{
    public partial class Ecoview : Form
    {
        public string edconctr;
        public string SposobZadan;
        public string Zavisimoct;
        public string aproksim;
        public int selet_rezim;
        public bool IzmerenieOpen = false;
        public bool IzmerCreate = false;
        public bool IzmerCreate1 = false;
        public double[][] massGEMultiAbs;
        public double[][] massGEMultiT;
        public int countButtonClick;
        public string filepath, filepath2, filepathFull;
        public Microsoft.Office.Interop.Excel.Workbook workBook;
        public Microsoft.Office.Interop.Excel.Worksheet workSheet;
        public string WL_grad1;
        public int IzmerFr_count;
        public double CellOpt;
        public double[] El;
        double CelloptCopy;
        int cordY = 0;
        public string[] HeaderCells;
        public string[,] Cells1;
        public string version = "264";
        public int count;
        public string[,] Stolbec;
        public int StolbecCol_1 = 0;
        public string CountSeriya2 = Convert.ToString(3);
        public string CountInSeriya2 = Convert.ToString(3);
        public string[,] CellColor;
        public string[,] Stolbec_1;
        public string F1;
        public string F2;
        public bool USE_KO_Izmer = false;
        public string Pogreshnost2 = "";
        public string TypeYravn1 = "";
        public string USE_CO_XML1 = "";
        public string filepath1;
        public int StolbecCol = 0;
        public string TimeIzmer1 = "";
        public string DateTime2_2_1 = "";
        public string DateTime2_1 = "";
        public bool USE_KO_1;
        public string pathTemp = Path.GetTempPath();
        public bool ResponseModeNormal = true;
        string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "/";
        public Ecoview(int selet_rezim1)
        {
            InitializeComponent();
            if (!File.Exists(@"registrastion"))
            {
                FirstStart firstStrat = new FirstStart();
                firstStrat.ShowDialog();
            }
            this.selet_rezim = selet_rezim1;
            новыйToolStripMenuItem.Enabled = false;
            сохранитьToolStripMenuItem.Enabled = false;
            эксопртВPDFToolStripMenuItem.Enabled = false;
            экспортToolStripMenuItem.Enabled = false;
            печатьToolStripMenuItem1.Enabled = false;
            параметрыToolStripMenuItem.Enabled = false;
            измеритьToolStripMenuItem.Enabled = false;
            калибровкаToolStripMenuItem.Enabled = false;
            справкаToolStripMenuItem.Visible = true;
            button1.Enabled = false;
            button3.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button12.Enabled = false;
            button14.Enabled = false;
            button11.Enabled = false;

            switch (selet_rezim)
            {

                case 1:
                    tabControl2.TabPages.Remove(tabPage3);
                    tabControl2.TabPages.Remove(tabPage4);
                    tabControl2.TabPages.Remove(tabPage2);
                    tabControl2.TabPages.Remove(tabPage5);
                    tabControl2.TabPages.Remove(tabPage6);
                    tabControl2.TabPages.Remove(tabPage7);
                    tabControl2.TabPages.Remove(tabPage8);
                    tabControl2.TabPages.Remove(tabPage9);
                    this.Text = "Ecoview Professional v1.0 Фотометрический режим";
                    графикРезультатаОдноволновогоИзмеренияToolStripMenuItem.Enabled = true;
                    tabControl2.SelectedIndex = 2;
                    tabControl2.SelectTab(tabPage1);
                    загрузкаДанныхСПрибораToolStripMenuItem.Visible = true;
                    ToolTip t1 = new ToolTip();
                    t1.SetToolTip(Add_Table2, "Добавить образец");
                    ToolTip t = new ToolTip();
                    t.SetToolTip(Remove_Table2, "Удалить текущий образец");
                    break;
                case 2:
                    tabControl2.TabPages.Remove(tabPage1);
                    tabControl2.TabPages.Remove(tabPage2);
                    tabControl2.TabPages.Remove(tabPage5);
                    tabControl2.TabPages.Remove(tabPage6);
                    tabControl2.TabPages.Remove(tabPage7);
                    tabControl2.TabPages.Remove(tabPage8);
                    tabControl2.TabPages.Remove(tabPage9);
                    this.Text = "Ecoview Professional v1.0 Количественный режим";
                    tabControl2.SelectedIndex = 0;
                    tabControl2.SelectTab(tabPage3);
                    tabPage4.Parent = null;
                    button13.Enabled = false;
                    radioButton1.Enabled = false;
                    radioButton2.Enabled = false;
                    radioButton3.Enabled = false;
                    radioButton4.Enabled = false;
                    radioButton5.Enabled = false;
                    chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                    chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                    новыйToolStripMenuItem.Enabled = true;
                    button5.Enabled = true;
                    загрузкаДанныхСПрибораToolStripMenuItem.Visible = true;
                    DateTime now = System.DateTime.Today;
                    string dayWeek = now.ToLongDateString();
                    dateTimePicker1.Text = dayWeek;
                    dateTimePicker2.Text = dayWeek;
                    break;
                case 3:
                    tabControl2.TabPages.Remove(tabPage3);
                    tabControl2.TabPages.Remove(tabPage4);
                    tabControl2.TabPages.Remove(tabPage1);
                    tabControl2.TabPages.Remove(tabPage5);
                    tabControl2.TabPages.Remove(tabPage6);
                    tabControl2.TabPages.Remove(tabPage7);
                    tabControl2.TabPages.Remove(tabPage8);
                    tabControl2.TabPages.Remove(tabPage9);
                    this.Text = "Ecoview Professional v1.0 Многоволновой режим";
                    tabControl2.SelectedIndex = 3;
                    button13.Enabled = false;
                    tabControl2.SelectTab(tabPage2);

                    break;
                case 4:
                    tabControl2.TabPages.Remove(tabPage3);
                    tabControl2.TabPages.Remove(tabPage4);
                    tabControl2.TabPages.Remove(tabPage2);
                    tabControl2.TabPages.Remove(tabPage1);
                    tabControl2.TabPages.Remove(tabPage6);
                    tabControl2.TabPages.Remove(tabPage7);
                    tabControl2.TabPages.Remove(tabPage8);
                    tabControl2.TabPages.Remove(tabPage9);
                    this.Text = "Ecoview Professional v1.0 Кинетический режим";
                    tabControl2.SelectedIndex = 4;
                    button13.Enabled = false;
                    tabControl2.SelectTab(tabPage5);
                    chart3.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
                    chart3.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
                    break;

                case 5:
                    tabControl2.TabPages.Remove(tabPage3);
                    tabControl2.TabPages.Remove(tabPage4);
                    tabControl2.TabPages.Remove(tabPage2);
                    tabControl2.TabPages.Remove(tabPage5);
                    tabControl2.TabPages.Remove(tabPage1);
                    tabControl2.TabPages.Remove(tabPage7);
                    tabControl2.TabPages.Remove(tabPage8);
                    tabControl2.TabPages.Remove(tabPage9);
                    this.Text = "Eciview Professional v1.0 Сканирование спектра";

                    tabControl2.SelectedIndex = 5;
                    tabControl2.SelectTab(tabPage6);
                    Podskazka.Text = "Подключите прибор";
                    label24.Visible = true;
                    break;
                case 6:
                    tabControl2.TabPages.Remove(tabPage7);
                    tabControl2.TabPages.Remove(tabPage8);
                    tabControl2.TabPages.Remove(tabPage2);
                    tabControl2.TabPages.Remove(tabPage5);
                    tabControl2.TabPages.Remove(tabPage6);
                    tabControl2.TabPages.Remove(tabPage1);
                    tabControl2.TabPages.Remove(tabPage9);
                    this.Text = "Eciview Professional v1.0 Агро режим";
                    tabControl2.SelectedIndex = 6;
                    Add_Table2.Visible = false;
                    Remove_Table2.Visible = false;
                    tabControl2.SelectTab(tabPage3);
                    tabControl2.TabPages[0].Text = "Градуировка Агро";
                    break;
                case 9:
                    tabControl2.TabPages.Remove(tabPage4);
                    tabControl2.TabPages.Remove(tabPage5);
                    tabControl2.TabPages.Remove(tabPage2);
                    tabControl2.TabPages.Remove(tabPage1);
                    tabControl2.TabPages.Remove(tabPage6);
                    tabControl2.TabPages.Remove(tabPage7);
                    tabControl2.TabPages.Remove(tabPage8);
                    this.Text = "Ecoview Professional v1.0 Работа в Excel";
                    tabControl2.SelectedIndex = 9;

                    tabControl2.SelectTab(tabPage9);
                    break;
            }

            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.button13, "Изменить длину волны");
            toolTip1.SetToolTip(this.button1, "Выключить");
            toolTip1.SetToolTip(this.button2, "Включить");
            toolTip1.SetToolTip(this.button4, "О приборе");
            toolTip1.SetToolTip(this.button5, "Создать");
            toolTip1.SetToolTip(this.button6, "Открыть");
            toolTip1.SetToolTip(this.button7, "Сохранить");
            toolTip1.SetToolTip(this.button3, "Печать");
            toolTip1.SetToolTip(this.button8, "Экспортировать в Excle");
            toolTip1.SetToolTip(this.button9, "Экспортировать в PDF");
            toolTip1.SetToolTip(this.button10, "Настройки");
            toolTip1.SetToolTip(this.button12, "Откалибровать");
            toolTip1.SetToolTip(this.button14, "Измерить");
            switch (selet_rezim)
            {
                case 1:
                    toolTip1.SetToolTip(this.button11, "Задать вручную");
                    break;
                case 2:
                    toolTip1.SetToolTip(this.button11, "Задать вручную");
                    break;
                case 3:
                    toolTip1.SetToolTip(this.button11, "Остановить");
                    break;
                case 4:
                    toolTip1.SetToolTip(this.button11, "Остановить");
                    break;

            }
            var applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);


            string SrokIstech_Text = path + @"pribor/SrokIstech";
            DecriptorPribor decriptorSrokIstech = new DecriptorPribor(ref SrokIstech_Text, pathTemp);
            var SrokIstech_Text_var = Path.Combine(applicationDirectory, pathTemp + SrokIstech_Text);

            string Poveren_Text = path + @"pribor/Poveren";
            DecriptorPribor decriptorPoveren = new DecriptorPribor(ref Poveren_Text, pathTemp);
            var Poveren_Text_var = Path.Combine(applicationDirectory, pathTemp + Poveren_Text);


            StreamReader fs3 = new StreamReader(SrokIstech_Text_var);
            string srok = fs3.ReadLine();
            fs3.Close();

            StreamReader fs4 = new StreamReader(Poveren_Text_var);
            DateTime date1 = new DateTime();
            date1 = Convert.ToDateTime(fs4.ReadLine());
            fs4.Close();


            string address_lab_Text = path + @"pribor/address_lab";
            DecriptorPribor decriptoraddress_lab = new DecriptorPribor(ref address_lab_Text, pathTemp);
            var address_lab_var = Path.Combine(applicationDirectory, pathTemp + address_lab_Text);

            string name_lab_Text = path + @"pribor/name_lab";
            DecriptorPribor decriptorname_lab = new DecriptorPribor(ref name_lab_Text, pathTemp);
            var name_lab_var = Path.Combine(applicationDirectory, pathTemp + name_lab_Text);

            StreamReader fs5 = new StreamReader(address_lab_var);
            address_lab = fs5.ReadLine();
            fs5.Close();

            StreamReader fs6 = new StreamReader(name_lab_var);
            name_lab = fs6.ReadLine();
            fs6.Close();

            if (date1 > System.DateTime.Now)
            {
                MessageBox.Show("Дата поверки больше текущей!\n\nПроверьте системное время или дату поверки!");
            }
            if (srok != "")
            {
                DateTime date2 = new DateTime();
                date2 = date1.AddDays(-Convert.ToInt32(srok));
                date2 = date2.AddYears(1);

                string datamin = Convert.ToString(date2.Subtract(System.DateTime.Now));
                if (Convert.ToInt32(date2.Subtract(System.DateTime.Now).ToString("dd")) < Convert.ToInt32(srok))
                {
                    MessageBox.Show("До окончания поверки осталось: " + date2.Subtract(System.DateTime.Now).ToString("dd") + " дней");
                }

            }
            Podskazka.Text = "Подключитесь к прибору!";
        }
        // public Label label6;
        public bool nonPort; //Порт включен(выключен)
        public SerialPort newPort; //SerialPort
        public string portsName; //Имя порта
        public string GW1_2;
        public string versionPribor; //версия прибора
        public string wavelength1 = Convert.ToString(0);
        public string[] RDstring;
        public int countSA;
        public string GE5_1_0 = "";
        public int indata_zero;
        public bool ComPort, ComPodkl, StopSpectr, StopAgro, USE_KO;
        //public string this.Text = "";
        public string address_lab;
        public string name_lab;
        public bool OpenIzmer;
        public bool OpenIzmer1;
        public string Description, Description1;
        public string DateTime;
        public string Ispolnitel;
        public string direction;
        public string code;
        public SWF.TextBox[] textBox = new SWF.TextBox[20];
        public SWF.TextBox[] textBoxCO = new SWF.TextBox[20];
        public int NoCoIzmer;
        public string Veshestvo1;
        public string WidthCuvette;
        public string ND;
        public int Days;
        public string CountSeriya, CountInSeriya;
        public string BottomLine, TopLine;
        public double k0, k1, k2;
        public int NoCaIzm, NoCaIzm1, NoCaSer, NoCaSer1;
        public double start = 0.0, cancel = 0.0, interval, delay;
        public double[] scan_massSA;
        public double[] scan_mass;

        private void button12_Click(object sender, EventArgs e)
        {
            Calibrovka calibrovka = new Calibrovka(this);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Izmerenie izmeren = new Izmerenie(this);
        }

        public double[] massWL;

        private void button15_Click(object sender, EventArgs e)
        {
            if (IzmerenieFR_Table.RowCount <= 26)
            {
                if (IzmerenieFR_Table.RowCount > 1)
                {
                    IzmerFr_count = IzmerenieFR_Table.RowCount - 1;
                    IzmerenieFR_Table.Rows.Add();
                    IzmerenieFR_Table.Rows[IzmerFr_count].Cells[0].Value = IzmerFr_count + 1;
                    IzmerenieFR_Table.Rows[IzmerFr_count].Cells[2].Value = GWNew.Text;
                    IzmerenieFR_Table.Rows[IzmerFr_count].Cells[5].Value = "0.0";
                }
                else
                {
                    MessageBox.Show("Создайте новое Измерение");
                }
            }
            else
            {
                MessageBox.Show("Строк не более 26");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (IzmerenieFR_Table.RowCount > 1)
            {
                if (IzmerenieFR_Table.RowCount > 2)
                {
                    if (IzmerenieFR_Table.CurrentCell.RowIndex != IzmerenieFR_Table.RowCount - 1)
                    {
                        IzmerenieFR_Table.Rows.RemoveAt(IzmerenieFR_Table.CurrentCell.RowIndex);
                        for (int i = 0; i < IzmerenieFR_Table.RowCount - 1; i++)
                        {
                            IzmerenieFR_Table.Rows[i].Cells[0].Value = i + 1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Удаление запрещено!");
                    }
                }

                else
                {
                    MessageBox.Show("Количество образцов не может быть меньше 1 !");
                }


            }
            else
            {
                MessageBox.Show("Таблица не содержит строк!");
            }
        }

        public double[] massGE;
        public string[][,] countScan;
        public int countscan = 0;

        private void button11_Click(object sender, EventArgs e)
        {
            switch (selet_rezim)
            {
                case 2:
                    if (tabControl2.SelectedIndex == 0)
                    {
                        if (Table1.CurrentCell.ColumnIndex >= 3 && Table1.CurrentCell.ReadOnly != true)
                        {

                            if (Table1.CurrentCell.Value != "" && Table1.CurrentCell.Value != null)
                            {
                                CellOpt = Convert.ToDouble(Table1.CurrentCell.Value.ToString());
                                CelloptCopy = CellOpt;
                            }

                            ZapicInTable1();

                        }
                    }
                    else
                    {
                        if (Table2.CurrentCell.ColumnIndex >= 2 && Table2.CurrentCell.ReadOnly != true)
                        {
                            if (Table2.CurrentCell.Value != "" && Table2.CurrentCell.Value != null)
                            {
                                CellOpt = Convert.ToDouble(Table2.CurrentCell.Value.ToString());
                                CelloptCopy = CellOpt;
                            }

                            ZapicInTable2();
                        }
                    }
                    break;
                case 1:
                    if (IzmerenieFR_Table.CurrentCell.ColumnIndex == 5)
                    {
                        IzmerenieFR_Table_Zapic();
                    }
                    else
                    {
                        if (IzmerenieFR_Table.CurrentCell.ReadOnly == true)
                        {
                            MessageBox.Show("Изменения запрещены");
                        }
                    }
                    break;
                case 6:
                    if (tabControl2.SelectedIndex == 0)
                    {
                        if (Table1.CurrentCell.ColumnIndex >= 3 && Table1.CurrentCell.ReadOnly != true)
                        {

                            if (Table1.CurrentCell.Value != "" && Table1.CurrentCell.Value != null)
                            {
                                //CellOpt = Convert.ToDouble(Table1.CurrentCell.Value.ToString());
                            }

                            //ZapicInTable1();

                        }
                    }
                    else
                    {
                        StopAgro = true;
                    }
                    break;
                case 5:
                    StopSpectr = true;
                    break;
                case 4:
                    if (timer2.Enabled == true)
                    {
                        timer2.Enabled = true;
                        timer2.Stop();
                        MinMax();
                        countscan = 0;
                        //  TableKinetica1.Rows.Add();
                        button14.Enabled = true;
                        button11.Enabled = false;
                        label27.Visible = true;
                        label28.Visible = false;
                        Podskazka.Text = "Сохраните измерение";
                        label33.Visible = false;
                        button6.Enabled = true;
                        button5.Enabled = true;
                        button3.Enabled = true;
                        button7.Enabled = true;
                        button12.Enabled = true;
                        button8.Enabled = true;

                    }

                    break;
                case 3:
                    StopSpectr = true;
                    break;
                case 9:
                    StopSpectr = true;
                    break;
            }
            button1.Enabled = true;
        }

        public double timeLeft;

        public void IzmerenieFR_Table_Zapic()
        {
            InputBox _InputBox = new InputBox(this);
            _InputBox.ShowDialog();

            IzmerenieFR_Table.CurrentCell.Value = string.Format("{0:0.0}", CellOpt);
            CellOpt = 0;
            IzmerenieFR_Table.Rows[IzmerenieFR_Table.CurrentRow.Index].Cells[6].Value = string.Format("{0:0.0000}",
                Convert.ToDouble(IzmerenieFR_Table.Rows[IzmerenieFR_Table.CurrentRow.Index].Cells[3].Value)
                * Convert.ToDouble(IzmerenieFR_Table.Rows[IzmerenieFR_Table.CurrentRow.Index].Cells[5].Value));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Conection conection = new Conection(this);
            button13.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PortClose portclose = new PortClose(this);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView5.ColumnCount - 2; i++)
            {
                if (dataGridView5.Columns["Abs " + i].HeaderText == "Abs " + textBoxCO[i].Text + " нм")
                {
                    dataGridView5.Columns["Abs " + i].HeaderText = "%T " + textBoxCO[i].Text + " нм";
                }
                else
                {
                    dataGridView5.Columns["Abs " + i].HeaderText = "Abs " + textBoxCO[i].Text + " нм";
                }
            }
            for (int j = 0; j < dataGridView5.Rows.Count - 1; j++)
            {
                for (int i = 0; i < dataGridView5.ColumnCount - 2; i++)
                {
                    if (dataGridView5.Columns["Abs " + i].HeaderText == "Abs " + textBoxCO[i].Text + " нм")
                    {
                        if (massGEMultiAbs[j][i].ToString() != null)
                        {
                            dataGridView5.Rows[j].Cells["Abs " + i].Value = string.Format("{0:0.0000}", massGEMultiAbs[j][i]);
                        }
                        else
                        {
                            dataGridView5.Rows[j].Cells["Abs " + i].Value = null;
                        }
                    }
                    else
                    {
                        if (massGEMultiT[j][i].ToString() != null)
                        {
                            dataGridView5.Rows[j].Cells["Abs " + i].Value = string.Format("{0:0.00}", massGEMultiT[j][i]);
                        }
                        else
                        {
                            dataGridView5.Rows[j].Cells["Abs " + i].Value = null;
                        }
                    }
                }
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (ComPodkl == true)
            {
                WalveNew();
            }
            else
            {
                MessageBox.Show("Подключитесь к прибору!");
            }
        }
        public void WalveNew()
        {
            NewWalve _NewWalve = new NewWalve(this);
            _NewWalve.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PriborInformation informationPribor = new PriborInformation(this);
            informationPribor.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CreateDimension createDemension = new CreateDimension(this);
        }

        private void Ecoview_Load(object sender, EventArgs e)
        {

        }
        public void TableKinetica(object sender, EventArgs e)
        {
            label56.Text = string.Format("{0:0.0}", timeLeft);
            timeLeft = timeLeft - Convert.ToDouble(interval);
            //Application.DoEvents();
            //  MessageBox.Show("Интервал: " + interval*1000);
            TableKinetica1.Rows.Add();
            Array.Resize<double>(ref massWL, massWL.Length + 1);
            Array.Resize<double>(ref massGE, massGE.Length + 1);

            string GE5Izmer = "";
            string GE5_1_1 = "";
            while (GE5Izmer == "")
            {
                // SW_Scan();
                GE5Izmer = "";
                GE5_1_1 = "";
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

                    else
                    {
                        indata = newPort.ReadExisting();
                    }
                }
                newPort.Write("GE 1\r");

                indata_0 = "";
                int index = 0;
                if (ResponseModeNormal == true)
                {
                    if (versionPribor.Contains("2"))
                    {
                        Thread.Sleep(3);
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
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

                indata_bool = true;

                Regex regex = new Regex(@"\W");
                Regex regex1 = new Regex(@"\D");
                GE5Izmer = regex.Replace(indata_0, "");
                GE5Izmer = regex1.Replace(GE5Izmer, "");
            }


            double Aser = Convert.ToDouble(GE5Izmer) / Convert.ToDouble(GE5_1_0) * 100;
            double OptPlot1 = 0;

            OptPlot1 = Math.Log10((Convert.ToDouble(GE5_1_0) - Convert.ToDouble(RDstring[countSA])) / (Convert.ToDouble(GE5Izmer) - Convert.ToDouble(RDstring[countSA])));
            double OptPlot1_1 = OptPlot1;
            // Application.DoEvents();
            massWL[countscan] = Convert.ToDouble(TableKinetica1.Rows[countscan].Cells[0].Value);
            TableKinetica1.Rows[countscan].Cells[0].Value = string.Format("{0:0.0}", Convert.ToDouble(interval) * countscan);
            if (TableKinetica1.Columns[1].HeaderText == "Abs")
            {
                TableKinetica1.Rows[countscan].Cells[1].Value = string.Format("{0:0.0000}", OptPlot1_1);
                massGE[countscan] = Convert.ToDouble(TableKinetica1.Rows[countscan].Cells[1].Value);
                TableKinetica1.Rows[countscan].Cells[2].Value =
                    string.Format("{0:0.0}",
                    ((Convert.ToDouble(GE5Izmer) - Convert.ToDouble(RDstring[countSA])) /
                    (Convert.ToDouble(GE5_1_0) - Convert.ToDouble(RDstring[countSA])) * 100));
            }
            else
            {
                TableKinetica1.Rows[countscan].Cells[2].Value = string.Format("{0:0.0000}", OptPlot1_1);
                TableKinetica1.Rows[countscan].Cells[1].Value =
                    string.Format("{0:0.0}",
                    ((Convert.ToDouble(GE5Izmer) - Convert.ToDouble(RDstring[countSA])) /
                    (Convert.ToDouble(GE5_1_0) - Convert.ToDouble(RDstring[countSA])) * 100));

                massGE[countscan] = Convert.ToDouble(TableKinetica1.Rows[countscan].Cells[1].Value);

            }
            massWL[countscan] = Convert.ToDouble(TableKinetica1.Rows[countscan].Cells[0].Value);
            massGE[countscan] = Convert.ToDouble(TableKinetica1.Rows[countscan].Cells[1].Value);
            Array.Sort(massWL);
            Array.Sort(massGE);
            double x1 = Convert.ToDouble(TableKinetica1.Rows[countscan].Cells[0].Value);
            double y1 = Convert.ToDouble(TableKinetica1.Rows[countscan].Cells[1].Value);
            /*ScanChart.Series[0].Points.AddXY(x1, y1);
            ScanChart.Series[0].ChartType = SeriesChartType.Point;
            ScanChart.ChartAreas[0].AxisY.Crossing = 0;
            ScanChart.ChartAreas[0].AxisX.Crossing = 0;*/

            chart3.Series[countButtonClick].Points.AddXY(x1, y1);
            chart3.Series[countButtonClick].ChartType = SeriesChartType.Line;
            if (TableKinetica1.Rows[countscan].Cells[1].Value != null && TableKinetica1.Rows[countscan].Cells[2].Value != null)
            {
                chart3.ChartAreas[0].AxisX.Minimum = cancel;
                chart3.ChartAreas[0].AxisX.Maximum = start;

            }
            chart3.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart3.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart3.ChartAreas[0].AxisX.Title = TableKinetica1.Columns[0].HeaderText;
            chart3.ChartAreas[0].AxisY.Title = TableKinetica1.Columns[1].HeaderText;
            countscan++;
            //del = GoodMorning;


            if (timeLeft == 0.0)
            {
                timer2.Enabled = false;
                timer2.Stop();
                MinMax();
                button14.Enabled = true;
                button11.Enabled = false;
                label33.Visible = false;
                label27.Visible = true;
                Podskazka.Text = "Сохраните градуировку!";
                button1.Enabled = true;
                label56.Text = "00";
                countscan = 0;

                button6.Enabled = true;
                button5.Enabled = true;
                button3.Enabled = true;
                button7.Enabled = true;
                button12.Enabled = true;
                button8.Enabled = true;

            }

        }
        public void MinMax()
        {
            double max = 0.0;
            double min = 0.0;
            countscan = 0;
            chart3.Series[0].Points.Clear();
           // chart3.Series[1].Points.Clear();
            
            chart3.ChartAreas[0].AxisX.Minimum = Convert.ToDouble(TableKinetica1.Rows[0].Cells[0].Value);
            chart3.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(TableKinetica1.Rows[TableKinetica1.Rows.Count - 2].Cells[0].Value);

          
            chart3.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart3.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart3.ChartAreas[0].AxisX.Title = TableKinetica1.Columns[0].HeaderText;
            chart3.ChartAreas[0].AxisY.Title = TableKinetica1.Columns[1].HeaderText;
            for (int i = 0; i < TableKinetica1.Rows.Count - 1; i++)
            {
                double x = Convert.ToDouble(TableKinetica1.Rows[i].Cells[0].Value);
                double y = Convert.ToDouble(TableKinetica1.Rows[i].Cells[1].Value);


                chart3.Series[countButtonClick].Points.AddXY(x, y);
                chart3.Series[countButtonClick].ChartType = SeriesChartType.Line;

            }
            for (int i = 0; i < TableKinetica1.Rows.Count; i++)
            {
                

                double x1 = 0;
                double y1 = 0;
                if (i == 0)
                {
                    if (Convert.ToDouble(TableKinetica1.Rows[i].Cells[1].Value) > Convert.ToDouble(TableKinetica1.Rows[i + 1].Cells[1].Value))
                    {
                        max = Convert.ToDouble(TableKinetica1.Rows[i].Cells[1].Value);
                        dataGridView3.Rows.Add(TableKinetica1.Rows[i].Cells[0].Value, TableKinetica1.Rows[i].Cells[1].Value, TableKinetica1.Rows[i].Cells[2].Value);
                        min = max;
                        x1 = Convert.ToDouble(TableKinetica1.Rows[i].Cells[0].Value);
                        y1 = Convert.ToDouble(TableKinetica1.Rows[i].Cells[1].Value);
                        chart3.Series[1].Points.AddXY(x1, y1);
                        chart3.Series[1].Points[countscan].Label = Convert.ToString(x1);
                        chart3.Series[1].Points[countscan].Color = System.Drawing.Color.DarkViolet;
                        chart3.Series[1].ChartType = SeriesChartType.Point;
                        countscan++;
                    }
                    else
                    {
                        min = Convert.ToDouble(TableKinetica1.Rows[i].Cells[1].Value);
                        dataGridView4.Rows.Add(TableKinetica1.Rows[i].Cells[0].Value, TableKinetica1.Rows[i].Cells[1].Value, TableKinetica1.Rows[i].Cells[2].Value);
                        max = min;
                        x1 = Convert.ToDouble(TableKinetica1.Rows[i].Cells[0].Value);
                        y1 = Convert.ToDouble(TableKinetica1.Rows[i].Cells[1].Value);
                        chart3.Series[1].Points.AddXY(x1, y1);
                        chart3.Series[1].Points[countscan].Label = Convert.ToString(x1);
                        chart3.Series[1].Points[countscan].Color = System.Drawing.Color.DarkOrchid;
                        chart3.Series[1].ChartType = SeriesChartType.Point;
                        countscan++;
                    }

                }
                else {
                    if (i + 1 != TableKinetica1.Rows.Count)
                    {
                        if (Convert.ToDouble(TableKinetica1.Rows[i].Cells[1].Value) > Convert.ToDouble(TableKinetica1.Rows[i - 1].Cells[1].Value)
                            &&
                            Convert.ToDouble(TableKinetica1.Rows[i].Cells[1].Value) >= Convert.ToDouble(TableKinetica1.Rows[i + 1].Cells[1].Value)

                            )
                        {
                            max = Convert.ToDouble(TableKinetica1.Rows[i].Cells[1].Value);
                            min = max;
                            dataGridView3.Rows.Add(TableKinetica1.Rows[i].Cells[0].Value, TableKinetica1.Rows[i].Cells[1].Value, TableKinetica1.Rows[i].Cells[2].Value);
                            x1 = Convert.ToDouble(TableKinetica1.Rows[i].Cells[0].Value);
                            y1 = Convert.ToDouble(TableKinetica1.Rows[i].Cells[1].Value);
                            chart3.Series[1].Points.AddXY(x1, y1);
                            chart3.Series[1].Points[countscan].Label = Convert.ToString(x1);
                            chart3.Series[1].Points[countscan].Color = System.Drawing.Color.DarkViolet;
                            chart3.Series[1].ChartType = SeriesChartType.Point;
                            countscan++;
                        }
                        if ((Convert.ToDouble(TableKinetica1.Rows[i].Cells[1].Value) < Convert.ToDouble(TableKinetica1.Rows[i - 1].Cells[1].Value)
                            &&
                            Convert.ToDouble(TableKinetica1.Rows[i].Cells[1].Value) <= Convert.ToDouble(TableKinetica1.Rows[i + 1].Cells[1].Value))

                            )
                        {
                            min = Convert.ToDouble(TableKinetica1.Rows[i].Cells[1].Value);
                            dataGridView4.Rows.Add(TableKinetica1.Rows[i].Cells[0].Value, TableKinetica1.Rows[i].Cells[1].Value, TableKinetica1.Rows[i].Cells[2].Value);
                            max = min;
                            x1 = Convert.ToDouble(TableKinetica1.Rows[i].Cells[0].Value);
                            y1 = Convert.ToDouble(TableKinetica1.Rows[i].Cells[1].Value);
                            chart3.Series[1].Points.AddXY(x1, y1);
                            chart3.Series[1].Points[countscan].Label = Convert.ToString(x1);
                            chart3.Series[1].Points[countscan].Color = System.Drawing.Color.Teal;
                            chart3.Series[1].ChartType = SeriesChartType.Point;
                            countscan++;
                        }
                    }
                }

            }



        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            Zavisimoct = "A(C)";
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();

            if (radioButton1.Checked == true)
            {
                Lineinaya0 lineinaya0 = new Lineinaya0(this);

            }
            else
            {
                if (radioButton2.Checked == true)
                {

                    Lineinaya lineinaya = new Lineinaya(this);
                }
                else
                {
                    // kvadratichnaya();
                    Kvadratichnaya kvadratichnaya = new Kvadratichnaya(this);
                }
            }

        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            Zavisimoct = "C(A)";
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            if (radioButton1.Checked == true)
            {
                Lineinaya0 lineinaya0 = new Lineinaya0(this);

            }
            else
            {
                if (radioButton2.Checked == true)
                {

                    Lineinaya lineinaya = new Lineinaya(this);
                }
                else
                {
                    // kvadratichnaya();
                    Kvadratichnaya kvadratichnaya = new Kvadratichnaya(this);
                }
            }

        }

        public void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            lineynaya0();
        }
        public void lineynaya0()
        {
            aproksim = "Линейная через 0";
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            Lineinaya0 lineinaya0 = new Lineinaya0(this);
            AgroText0.Enabled = true;
            AgroText1.Enabled = true;
            AgroText2.Enabled = true;
            RR.Enabled = true;
            SKO.Enabled = true;
            label21.Enabled = true;
            label22.Enabled = true;
            label14.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            lineinaya();
        }
        public void lineinaya()
        {
            aproksim = "Линейная";
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            Lineinaya lineinaya = new Lineinaya(this);
            AgroText0.Enabled = true;
            AgroText1.Enabled = true;
            AgroText2.Enabled = true;
            RR.Enabled = true;
            SKO.Enabled = true;
            label21.Enabled = true;
            label22.Enabled = true;
            label14.Enabled = true;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            kvadratichnaya();
        }
        public void kvadratichnaya()
        {
            aproksim = "Квадратичная";
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            Kvadratichnaya kvadratichnaya = new Kvadratichnaya(this);
            AgroText0.Enabled = true;
            AgroText1.Enabled = true;
            AgroText2.Enabled = true;
            RR.Enabled = true;
            SKO.Enabled = true;
            label21.Enabled = true;
            label22.Enabled = true;
            label14.Enabled = true;
        }
        public void IzmerenieFr_izmer()
        {
            int startIndexCell = 3;
            int endIndexCell = 6;
            int rowIndex = IzmerenieFR_Table.CurrentRow.Index;

            bool doNotWrite = false;
            string SWAnalis = WL_grad1;
            string GE5Izmer = "";
            string GE5_1_1 = "";
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

                else
                {
                    indata = newPort.ReadExisting();

                }
            }


            // double[] GEIZMERmass = new double[10];
            double GEIZMERmass = 0;
            for (int j = 0; j < 10; j++)
            {
                newPort.Write("GE 1\r");
                indata_0 = "";
                int index = 0;
                if (ResponseModeNormal == true)
                {
                    if (versionPribor.Contains("2"))
                    {
                        Thread.Sleep(3);
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
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

                indata_bool = true;
                GE5Izmer = "";
                Regex regex = new Regex(@"\W");
                Regex regex1 = new Regex(@"\D");
                GE5Izmer = regex.Replace(indata_0, "");
                GE5Izmer = regex1.Replace(GE5Izmer, "");
                // GEIZMERmass[j] = Convert.ToDouble(GE5Izmer);
                GEIZMERmass += Convert.ToDouble(GE5Izmer);
            }

            GEIZMERmass = GEIZMERmass / 10;
            GE5Izmer = "";
            GE5Izmer = Convert.ToString(GEIZMERmass);
            //GE5Izmer = Convert.ToString(GEIZMERmass.Max());



            double Aser = Convert.ToDouble(GE5Izmer) / Convert.ToDouble(GE5_1_0) * 100;
            double OptPlot1 = 0;

            OptPlot1 = Math.Log10((Convert.ToDouble(GE5_1_0) - Convert.ToDouble(RDstring[countSA])) /
                (Convert.ToDouble(GE5Izmer) - Convert.ToDouble(RDstring[countSA])));


            IzmerenieFR_Table.Rows[rowIndex].Cells[1].Value = "Образец " + (rowIndex + 1);
            double OptPlot1_1 = OptPlot1;
            IzmerenieFR_Table.Rows[rowIndex].Cells[2].Value = string.Format("{0:0.0}", GWNew.Text);
            if (IzmerenieFR_Table.CurrentCell.ColumnIndex != 5)
            {
                if ((IzmerenieFR_Table.CurrentCell.ReadOnly != true && rowIndex != IzmerenieFR_Table.Rows.Count - 1) || IzmerenieFR_Table.CurrentCell.ColumnIndex == 3)
                {
                    IzmerenieFR_Table.Rows[rowIndex].Cells[3].Value = string.Format("{0:0.0000}", OptPlot1_1);
                    string k1 = Convert.ToString(IzmerenieFR_Table.Rows[rowIndex].Cells[5].Value);
                    k1 = k1.Replace(".", ",");
                    IzmerenieFR_Table.Rows[rowIndex].Cells[4].Value = string.Format("{0:0.00}",
                         (Convert.ToDouble(GE5Izmer) - Convert.ToDouble(RDstring[countSA])) /
                        ((Convert.ToDouble(GE5_1_0) - Convert.ToDouble(RDstring[countSA]))) * 100);


                    IzmerenieFR_Table.Rows[rowIndex].Cells[6].Value = string.Format("{0:0.0000}", (OptPlot1_1 * Convert.ToDouble(k1)));
                    int curentIndex = IzmerenieFR_Table.CurrentCell.ColumnIndex;
                    if (curentIndex != IzmerenieFR_Table.ColumnCount - 1 || rowIndex != IzmerenieFR_Table.Rows.Count - 1)
                    {
                        if (rowIndex != IzmerenieFR_Table.Rows.Count - 2)
                        {
                            IzmerenieFR_Table.CurrentCell = this.IzmerenieFR_Table[curentIndex, rowIndex + 1];
                        }
                        else
                        {
                            MessageBox.Show("Измерения были проведены!");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Запись запрещена!");
                }
            }
            else
            {
                MessageBox.Show("Производить измерения в данную ячейку запрещено! Только ручное изменение!");
            }
        }
        public void TimerTick1(object sender, EventArgs e)
        {
            label53.Text = Convert.ToString(delay);
            delay--;
            if (delay < 0.0)
            {
                //  label33.Visible = false;
                timer1.Stop();
                timer1.Enabled = false;
                timeLeft = Convert.ToInt32(start);
                timer2.Start();
                TableKinetica1.Rows.Clear();
                TableKinetica(sender, e);
                TableKinetica1.Rows.Clear();
                timer2.Enabled = true;
                button11.Enabled = true;
                countscan = 0;
            }

        }
        public void ChartGraf()
        {


            if (TableKinetica1.Columns[1].HeaderText == "Abs")
            {
                //Array.Sort(massGE);
                chart3.ChartAreas[0].AxisY.Minimum = 0;
                chart3.ChartAreas[0].AxisY.Maximum = 3;
                chart3.ChartAreas[0].AxisX.Minimum = 0;
                chart3.ChartAreas[0].AxisX.Maximum = start;
                dataGridView1.Columns[1].HeaderText = "Abs";
                dataGridView1.Columns[2].HeaderText = "%T";
                dataGridView2.Columns[1].HeaderText = "Abs";
                dataGridView2.Columns[2].HeaderText = "%T";
                TableKinetica1.Columns[2].HeaderText = "%T";
            }
            else
            {
                //Array.Sort(massGE);
                chart3.ChartAreas[0].AxisY.Minimum = 0;
                chart3.ChartAreas[0].AxisY.Maximum = 125;
                chart3.ChartAreas[0].AxisX.Minimum = 0;
                chart3.ChartAreas[0].AxisX.Maximum = start;
                TableKinetica1.Columns[2].HeaderText = "Abs";
                dataGridView1.Columns[1].HeaderText = "%T";
                dataGridView1.Columns[2].HeaderText = "Abs";
                dataGridView2.Columns[1].HeaderText = "%T";
                dataGridView2.Columns[2].HeaderText = "Abs";
            }

        }
        public void TableKinetica()
        {

            label56.Text = string.Format("{0:0.0}", timeLeft);
            timeLeft = timeLeft - Convert.ToDouble(interval);
            Application.DoEvents();
            //  MessageBox.Show("Интервал: " + interval*1000);
            TableKinetica1.Rows.Add();
            Array.Resize<double>(ref massWL, massWL.Length + 1);
            Array.Resize<double>(ref massGE, massGE.Length + 1);

            string GE5Izmer = "";
            string GE5_1_1 = "";
            while (GE5Izmer == "")
            {
                // SW_Scan();
                GE5Izmer = "";
                GE5_1_1 = "";
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

                    else
                    {
                        indata = newPort.ReadExisting();
                    }
                }
                newPort.Write("GE 1\r");

                indata_0 = "";
                int index = 0;
                if (ResponseModeNormal == true)
                {
                    if (versionPribor.Contains("2"))
                    {
                        Thread.Sleep(3);
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
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

                indata_bool = true;

                Regex regex = new Regex(@"\W");
                Regex regex1 = new Regex(@"\D");
                GE5Izmer = regex.Replace(indata_0, "");
                GE5Izmer = regex1.Replace(GE5Izmer, "");
            }


            double Aser = Convert.ToDouble(GE5Izmer) / Convert.ToDouble(GE5_1_0) * 100;
            double OptPlot1 = 0;

            OptPlot1 = Math.Log10((Convert.ToDouble(GE5_1_0) - Convert.ToDouble(RDstring[countSA])) / (Convert.ToDouble(GE5Izmer) - Convert.ToDouble(RDstring[countSA])));
            double OptPlot1_1 = OptPlot1;
            Application.DoEvents();
            massWL[countscan] = Convert.ToDouble(TableKinetica1.Rows[countscan].Cells[0].Value);
            TableKinetica1.Rows[countscan].Cells[0].Value = string.Format("{0:0.0}", Convert.ToDouble(interval) * countscan);
            if (TableKinetica1.Columns[1].HeaderText == "Abs")
            {
                TableKinetica1.Rows[countscan].Cells[1].Value = string.Format("{0:0.0000}", OptPlot1_1);
                massGE[countscan] = Convert.ToDouble(TableKinetica1.Rows[countscan].Cells[1].Value);
                TableKinetica1.Rows[countscan].Cells[2].Value =
                    string.Format("{0:0.0}",
                    ((Convert.ToDouble(GE5Izmer) - Convert.ToDouble(RDstring[countSA])) /
                    (Convert.ToDouble(GE5_1_0) - Convert.ToDouble(RDstring[countSA])) * 100));
            }
            else
            {
                TableKinetica1.Rows[countscan].Cells[2].Value = string.Format("{0:0.0000}", OptPlot1_1);
                TableKinetica1.Rows[countscan].Cells[1].Value =
                    string.Format("{0:0.0}",
                    ((Convert.ToDouble(GE5Izmer) - Convert.ToDouble(RDstring[countSA])) /
                    (Convert.ToDouble(GE5_1_0) - Convert.ToDouble(RDstring[countSA])) * 100));
                /** listBox1.Items.Add(GE5Izmer);*/
                massGE[countscan] = Convert.ToDouble(TableKinetica1.Rows[countscan].Cells[1].Value);

            }
            massWL[countscan] = Convert.ToDouble(TableKinetica1.Rows[countscan].Cells[0].Value);
            massGE[countscan] = Convert.ToDouble(TableKinetica1.Rows[countscan].Cells[1].Value);
            Array.Sort(massWL);
            Array.Sort(massGE);
            double x1 = Convert.ToDouble(TableKinetica1.Rows[countscan].Cells[0].Value);
            double y1 = Convert.ToDouble(TableKinetica1.Rows[countscan].Cells[1].Value);


            chart3.Series[countButtonClick].Points.AddXY(x1, y1);
            chart3.Series[countButtonClick].ChartType = SeriesChartType.Line;
            if (TableKinetica1.Rows[countscan].Cells[1].Value != null && TableKinetica1.Rows[countscan].Cells[2].Value != null)
            {
                chart3.ChartAreas[0].AxisX.Minimum = cancel;
                chart3.ChartAreas[0].AxisX.Maximum = start;

            }
            chart3.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart3.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart3.ChartAreas[0].AxisX.Title = TableKinetica1.Columns[0].HeaderText;
            chart3.ChartAreas[0].AxisY.Title = TableKinetica1.Columns[1].HeaderText;
            countscan++;
            //del = GoodMorning;


            if (timeLeft == 0.0)
            {
                timer2.Enabled = false;
                timer2.Stop();
                MinMax();
                button14.Enabled = true;
                button11.Enabled = false;
                label33.Visible = false;
                label27.Visible = true;
                Podskazka.Text = "Сохраните градуировку!";
                button1.Enabled = true;
                label56.Text = "00";
                countscan = 0;

                button6.Enabled = true;
                button5.Enabled = true;
                button3.Enabled = true;
                button7.Enabled = true;
                button12.Enabled = true;
                button8.Enabled = true;

            }

        }

        private void Table1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Table1.CurrentCell.ColumnIndex >= 3 && Table1.CurrentCell.ReadOnly != true)
            {

                if (Table1.CurrentCell.Value != "" && Table1.CurrentCell.Value != null)
                {
                    CellOpt = Convert.ToDouble(Table1.CurrentCell.Value.ToString());
                    CelloptCopy = CellOpt;
                }

                ZapicInTable1();

            }
        }
        public void ZapicInTable1()
        {
            bool doNotWrite = false;
            double sum = 0.0;
            int startIndexCell = 2;
            int endIndexCell = startIndexCell + NoCaIzm;
            int rowIndex = Table1.CurrentRow.Index;
            //int curentIndex = Table1.CurrentCell.ColumnIndex;

            if (Table1.CurrentCell.ColumnIndex > 2)
            {
                InputBox _InputBox = new InputBox(this);
                _InputBox.ShowDialog();
                if (Table1.CurrentCell.ReadOnly != true)
                {
                    Table1.CurrentCell.Value = string.Format("{0:0.0000}", CellOpt);
                    if (CelloptCopy != CellOpt)
                    {
                        Table1.CurrentCell.Style.BackColor = System.Drawing.Color.Pink;
                    }
                    CellOpt = 0;
                }
                else
                {
                    MessageBox.Show("Запись запрещена!");
                }
            }


            int rownull = 0;
            for (int j = 0; j < Table1.Rows.Count - 1; j++)
            {
                {
                    for (int i = 3; i < Table1.Rows[j].Cells.Count; i++)
                    {
                        if (Table1.Rows[j].Cells[i].Value == null)
                        {
                            doNotWrite = true;

                            for (int l = startIndexCell + NoCaIzm; l <= endIndexCell; ++l)
                            {
                                if (Table1.Rows[rowIndex].Cells[l].Value == null)
                                {
                                    cellnull++;
                                }
                            }
                        }


                    }
                }
            }



            if (!doNotWrite)
            {
                if (NoCaSer == 1)
                {
                    radioButton1.Enabled = true;
                    radioButton4.Enabled = true;
                    radioButton5.Enabled = true;
                    radioButton3.Enabled = false;
                    radioButton2.Enabled = false;
                }
                if (NoCaSer == 2)
                {
                    radioButton1.Enabled = true;
                    radioButton2.Enabled = true;
                    radioButton4.Enabled = true;
                    radioButton5.Enabled = true;
                    radioButton3.Enabled = false;
                }
                if (NoCaSer >= 3)
                {
                    radioButton1.Enabled = true;
                    radioButton2.Enabled = true;
                    radioButton3.Enabled = true;
                    radioButton4.Enabled = true;
                    radioButton5.Enabled = true;
                }

                sum = 0.0;
                /*while (true)
                 {
                     int i = Table1.Columns.Count - 1;//С какого столбца начать
                     if (Table1.Columns.Count == 3 + Convert.ToInt32(CountSeriya2))
                         break;
                     //Table1.Columns.RemoveAt(i);
                 }*/

                for (int l = startIndexCell + NoCaIzm; l <= endIndexCell; ++l)
                {
                    if (Table1.Rows[rowIndex].Cells[l].Value == null)
                    {
                        cellnull++;
                    }

                    else
                    {
                        for (int j = 0; j < Table1.Rows.Count - 1; j++)
                        {

                            for (int i1 = startIndexCell + 1; i1 <= endIndexCell; ++i1)
                            {
                                sum += Convert.ToDouble(Table1.Rows[j].Cells[i1].Value);
                                Asred1 = sum / NoCaIzm;
                                // MessageBox.Show(Convert.ToString(Asred1));
                                Table1.Rows[j].Cells["Asred"].Value = string.Format("{0:0.0000}", Asred1);

                            }
                            sum = 0.0;
                        }
                    }
                    Izmerenie1 = true;
                }
                for (int m = 0; m < Table1.Rows.Count - 1; m++)
                {
                    for (int ml = 0; ml < Table1.Rows[m].Cells.Count; ml++)
                    {
                        if (Table1.Rows[m].Cells[ml].Value == null)
                        { doNotWrite = true; }
                    }
                }

                functionAsred();
            }

            int curentIndex = Table1.CurrentCell.ColumnIndex;
            if (curentIndex != Table1.ColumnCount - 1 || rowIndex != Table1.Rows.Count - 2)
            {
                if (rowIndex != Table1.Rows.Count - 2)
                {
                    Table1.CurrentCell = this.Table1[curentIndex, rowIndex + 1];
                }
                else
                {
                    Table1.CurrentCell = this.Table1[curentIndex + 1, 0];
                }
                Table1.EndEdit();
            }

        }

        private void Table1_CancelRowEdit(object sender, QuestionEventArgs e)
        {
            Table1.EndEdit();
            return;
        }

        private void Table2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Table2.CurrentCell.ColumnIndex >= 2 && Table2.CurrentCell.ReadOnly != true)
            {
                if (Table2.CurrentCell.Value != "" && Table2.CurrentCell.Value != null)
                {
                    CellOpt = Convert.ToDouble(Table2.CurrentCell.Value.ToString());
                    CelloptCopy = CellOpt;
                }

                ZapicInTable2();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Print print = new Print(this);
        }

        public void Play_Ecxel()
        {

            try
            {
                string GE5Izmer = "";

                int cell = Convert.ToInt32(workSheet.Application.ActiveCell.Column);
                int row = Convert.ToInt32(workSheet.Application.ActiveCell.Row);

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

                    else
                    {
                        indata = newPort.ReadExisting();

                    }
                }
                indata_bool = true;
                newPort.Write("GE 1\r");
                indata_0 = "";

                int index = 0;
                if (ResponseModeNormal == true)
                {
                    if (versionPribor.Contains("2"))
                    {
                        Thread.Sleep(3);
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
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
                GE5Izmer = "";
                Regex regex = new Regex(@"\W");
                Regex regex1 = new Regex(@"\D");
                GE5Izmer = regex.Replace(indata_0, "");
                GE5Izmer = regex1.Replace(GE5Izmer, "");

                double Aser = Convert.ToDouble(GE5Izmer) / Convert.ToDouble(GE5_1_0) * 100;
                double OptPlot1 = 0;

                OptPlot1 = Math.Log10((Convert.ToDouble(GE5_1_0) - Convert.ToDouble(RDstring[countSA])) /
                    (Convert.ToDouble(GE5Izmer) - Convert.ToDouble(RDstring[countSA])));
                double OptPlot1_1 = OptPlot1;

                workSheet.Cells[row, cell] = string.Format("{0:0.0000}", OptPlot1_1);
                // timePlay++;
            }
            catch
            {
                MessageBox.Show("Вы закрыли файл или файл недоступен для записи!");
            }



        }
        public void SW_MultiScan()
        {
            SW_MultiScan sw_multiscan = new SW_MultiScan(this);
        }
        public void TableMultiScan()
        {
            countscan = 0;
            while ((countscan != dataGridView5.ColumnCount - 2) && (StopSpectr != true))
            {
                Application.DoEvents();
                string GE5Izmer = "";
                string GE5_1_1 = "";
                while (GE5Izmer == "")
                {
                    SW_MultiScan();
                    GE5Izmer = "";
                    GE5_1_1 = "";
                    newPort.Write("SA " + scan_massSA[countscan] + "\r");
                    string indata = newPort.ReadExisting();
                    string indata_0;
                    bool indata_bool = true;
                    while (indata_bool == true)
                    {
                        if (indata.Contains(">"))
                        {
                            indata_bool = false;
                        }

                        else
                        {
                            indata = newPort.ReadExisting();
                        }
                    }

                    newPort.Write("GE 1\r");

                    indata_0 = "";
                    int index = 0;
                    if (ResponseModeNormal == true)
                    {
                        if (versionPribor.Contains("2"))
                        {
                            Thread.Sleep(3);
                        }
                        else
                        {
                            Thread.Sleep(1000);
                        }
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

                    //  indata_0 = "";
                    indata_bool = true;

                    Regex regex = new Regex(@"\W");
                    Regex regex1 = new Regex(@"\D");
                    GE5Izmer = regex.Replace(indata_0, "");
                    GE5Izmer = regex1.Replace(GE5Izmer, "");
                }
                //MessageBox.Show("Измерение");

                double Aser = Convert.ToDouble(GE5Izmer) / Convert.ToDouble(scan_mass[countscan]) * 100;
                double OptPlot1 = 0;

                OptPlot1 = Math.Log10((Convert.ToDouble(scan_mass[countscan]) - Convert.ToDouble(RDstring[countSA])) /
                    (Convert.ToDouble(GE5Izmer) - Convert.ToDouble(RDstring[countSA])));
                double OptPlot1_1 = OptPlot1;
                Application.DoEvents();
                dataGridView5.Rows[dataGridView5.Rows.Count - 2].Cells["Abs " + countscan].Value = string.Format("{0:0.0000}", OptPlot1_1);
                massGEMultiAbs[dataGridView5.Rows.Count - 2][countscan] =
                    Convert.ToDouble(dataGridView5.Rows[dataGridView5.Rows.Count - 2].Cells["Abs " + countscan].Value);

                massGEMultiT[dataGridView5.Rows.Count - 2][countscan] = (Convert.ToDouble(GE5Izmer) - Convert.ToDouble(RDstring[countSA])) /
                    (Convert.ToDouble(scan_mass[countscan]) - Convert.ToDouble(RDstring[countSA])) * 100;
                countscan++;
                Application.DoEvents();
            }
            button14.Enabled = true;
            button11.Enabled = false;
            Application.DoEvents();
            if (StopSpectr == true)
            {
                MessageBox.Show("Измерение было прервано!");
            }
        }
        int cellnull;
        public bool Izmerenie1;
        double Asred1;
        public void Graduirovka()
        {
            double sum = 0.0;
            int startIndexCell = 2;
            int endIndexCell = startIndexCell + NoCaIzm;
            int rowIndex = Table1.CurrentRow.Index;

            bool doNotWrite = false;
            string SWAnalis = WL_grad1;
            string GE5Izmer = "";
            string GE5_1_1 = "";
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

                else
                {
                    indata = newPort.ReadExisting();

                }
            }

            newPort.Write("GE 1\r");
            indata_0 = "";
            int index = 0;
            if (ResponseModeNormal == true)
            {
                if (versionPribor.Contains("2"))
                {
                    Thread.Sleep(3);
                }
                else
                {
                    Thread.Sleep(1000);
                }
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
            indata_bool = true;

            Regex regex = new Regex(@"\W");
            Regex regex1 = new Regex(@"\D");
            GE5Izmer = regex.Replace(indata_0, "");
            GE5Izmer = regex1.Replace(GE5Izmer, "");

            double Aser = Convert.ToDouble(GE5Izmer) / Convert.ToDouble(GE5_1_0) * 100;
            double OptPlot1 = 0;

            OptPlot1 = Math.Log10((Convert.ToDouble(GE5_1_0) - Convert.ToDouble(RDstring[countSA])) / (Convert.ToDouble(GE5Izmer) - Convert.ToDouble(RDstring[countSA])));



            double OptPlot1_1 = OptPlot1;
            if (Table1.CurrentCell.ReadOnly != true)
            {
                Table1.CurrentCell.Value = string.Format("{0:0.0000}", OptPlot1_1);
                Table1.CurrentCell.Style.BackColor = System.Drawing.Color.White;

                int curentIndex = Table1.CurrentCell.ColumnIndex;
                if (curentIndex != Table1.ColumnCount - 1 || rowIndex != Table1.Rows.Count - 2)
                {
                    if (rowIndex != Table1.Rows.Count - 2)
                    {
                        Table1.CurrentCell = this.Table1[curentIndex, rowIndex + 1];

                    }
                    else
                    {
                        Table1.CurrentCell = this.Table1[curentIndex + 1, 0];
                    }

                }

            }
            else
            {
                MessageBox.Show("Запись запрещена!");
            }

            for (int j = 0; j < Table1.Rows.Count - 1; j++)
            {
                {
                    for (int i = 3; i < Table1.Rows[j].Cells.Count; i++)
                    {
                        if (Table1.Rows[j].Cells[i].Value == null)
                        {
                            doNotWrite = true;

                            for (int l = startIndexCell + NoCaIzm; l <= endIndexCell; ++l)
                            {
                                if (Table1.Rows[rowIndex].Cells[l].Value == null)
                                {
                                    cellnull++;
                                    // Table1.Rows[rowIndex].Cells[Table1.CurrentCell.ColumnIndex + 1].Selected = true;

                                }
                            }
                        }


                    }
                }
            }
            if (!doNotWrite)
            {
                if (NoCaSer == 1)
                {
                    radioButton1.Enabled = true;
                    radioButton4.Enabled = true;
                    radioButton5.Enabled = true;
                    radioButton3.Enabled = false;
                    radioButton2.Enabled = false;
                }
                if (NoCaSer == 2)
                {
                    radioButton1.Enabled = true;
                    radioButton2.Enabled = true;
                    radioButton4.Enabled = true;
                    radioButton5.Enabled = true;
                    radioButton3.Enabled = false;
                }
                if (NoCaSer >= 3)
                {
                    radioButton1.Enabled = true;
                    radioButton2.Enabled = true;
                    radioButton3.Enabled = true;
                    radioButton4.Enabled = true;
                    radioButton5.Enabled = true;
                }
                sum = 0.0;


                for (int l = startIndexCell + NoCaIzm; l <= endIndexCell; ++l)
                {
                    if (Table1.Rows[rowIndex].Cells[l].Value == null)
                    {
                        cellnull++;
                    }

                    else
                    {
                        for (int j = 0; j < Table1.Rows.Count - 1; j++)
                        {

                            for (int i1 = startIndexCell + 1; i1 <= endIndexCell; ++i1)
                            {
                                sum += Convert.ToDouble(Table1.Rows[j].Cells[i1].Value);
                                Asred1 = sum / NoCaIzm;
                                // MessageBox.Show(Convert.ToString(Asred1));
                                Table1.Rows[j].Cells["Asred"].Value = string.Format("{0:0.0000}", Asred1);

                            }
                            sum = 0.0;
                        }
                    }
                    Izmerenie1 = true;
                }
                for (int m = 0; m < Table1.Rows.Count - 1; m++)
                {
                    for (int ml = 0; ml < Table1.Rows[m].Cells.Count; ml++)
                    {
                        if (Table1.Rows[m].Cells[ml].Value == null)
                        { doNotWrite = true; }
                    }
                }
                if (!doNotWrite)
                {
                    while (true)
                    {
                        int ml = Table1.Columns.Count - 1;//С какого столбца начать
                        if (Table1.Columns.Count == 3 + NoCaIzm)
                            break;
                        Table1.Columns.RemoveAt(ml);
                    }
                    if (Zavisimoct == "A(C)")
                    {
                        radioButton4.Checked = true;
                        functionAsred();
                    }
                    else
                    {
                        radioButton5.Checked = true;
                        functionAsred();
                    }

                    label59.Visible = false;
                    label27.Visible = true;
                    label28.Visible = false;
                    Podskazka.Text = "Сохраните измерение";
                    button1.Enabled = true;
                    radioButton1.Enabled = true;
                    radioButton2.Enabled = true;
                    radioButton3.Enabled = true;
                    radioButton4.Enabled = true;
                    radioButton5.Enabled = true;

                }

            }
        }
        public int circle;
        public double XY, SUMMY2, SUMMX, SUM0, SUM1, SUMMY;
        public void functionAsred()
        {
            while (true)
            {
                int ml = Table1.Columns.Count - 1;//С какого столбца начать
                if (Table1.Columns.Count == 3 + NoCaIzm)
                    break;
                Table1.Columns.RemoveAt(ml);
            }
            groupBox3.Enabled = true;
            groupBox2.Enabled = true;

            if (aproksim == "Линейная через 0")
            {
                radioButton1.Checked = true;
                Lineinaya0 lineinaya0 = new Lineinaya0(this);

            }
            else
            {
                if (aproksim == "Линейная")
                {
                    radioButton2.Checked = true;
                    Lineinaya lineinaya = new Lineinaya(this);
                }
                else
                {
                    // kvadratichnaya();
                    radioButton3.Checked = true;
                    Kvadratichnaya kvadratichnaya = new Kvadratichnaya(this);
                }
            }
            Podskazka.Text = "Сохраните градуировку!";
            label27.Visible = true;
            label24.Visible = false;
            label25.Visible = false;
            label26.Visible = false;
            label28.Visible = false;
            label33.Visible = false;
            label14.Enabled = true;
            RR.Enabled = true;
            SKO.Enabled = true;
            label21.Enabled = true;
            label22.Enabled = true;
            AgroText0.Enabled = true;
            AgroText1.Enabled = true;
            AgroText2.Enabled = true;



            новыйToolStripMenuItem.Enabled = false;
            сохранитьToolStripMenuItem.Enabled = true;
            эксопртВPDFToolStripMenuItem.Enabled = true;
            экспортToolStripMenuItem.Enabled = true;
            печатьToolStripMenuItem1.Enabled = true;
            параметрыToolStripMenuItem.Enabled = true;
            измеритьToolStripMenuItem.Enabled = true;
            калибровкаToolStripMenuItem.Enabled = true;
            //   справкаToolStripMenuItem.Visible = false;
            button1.Enabled = false;
            button3.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button12.Enabled = true;
            button14.Enabled = true;
            button11.Enabled = true;

            label27.Visible = true;
            label59.Visible = false;
            label24.Visible = false;






        }
        public void Izmerenie()
        {
            double CCR = 0.0;
            int rowIndex2 = Table2.CurrentRow.Index;
            bool doNotWrite1 = false;
            double maxEl;
            double minEl;
            double serValue = 0;
            int cellnull = 0;
            El = new double[NoCaIzm1];
            string GE5Izmer = "";
            string GE5_1_1 = "";
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
            // Thread.Sleep(500);
            // GEbyteRecieved4_1 = newPort.ReadBufferSize;
            //  GEbuffer4_1 = new byte[GEbyteRecieved4_1];
            // MessageBox.Show(newPort.Read(GEbuffer4_1, 0, GEbyteRecieved4_1).ToString());
            // Thread.SpinWait(500);
            indata_0 = "";
            int index = 0;
            if (ResponseModeNormal == true)
            {
                if (versionPribor.Contains("2"))
                {
                    Thread.Sleep(3);
                }
                else
                {
                    Thread.Sleep(1000);
                }
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
            int indata_zero = 0;
            //  indata_0 = "";
            indata_bool = true;
            /* while (indata_bool == true)
             {

                 if (indata.Contains(">"))
                 {
                     indata_0 = indata;
                     indata_bool = false;

                 }
                 else {                   

                         indata = newPort.ReadExisting();
                         indata_0 += indata;

                 }
             }*/
            GE5Izmer = "";
            Regex regex = new Regex(@"\W");
            Regex regex1 = new Regex(@"\D");
            GE5Izmer = regex.Replace(indata_0, "");
            GE5Izmer = regex1.Replace(GE5Izmer, "");

            // MessageBox.Show(GE5Izmer);
            int curentIndex = Table2.CurrentCell.ColumnIndex;
            double Aser = Convert.ToDouble(GE5Izmer) / Convert.ToDouble(GE5_1_0) * 100;
            double OptPlot1 = Math.Log10((Convert.ToDouble(GE5_1_0) - Convert.ToDouble(RDstring[countSA])) /
                (Convert.ToDouble(GE5Izmer) - Convert.ToDouble(RDstring[countSA])));
            double OptPlot1_1 = OptPlot1 - Math.Truncate(OptPlot1);
            if (selet_rezim == 6)
            {
                Table2.Rows[0].ReadOnly = true;
                if (Table2.Rows[Table2.CurrentCell.RowIndex].ReadOnly == true)
                {
                    Table2.CurrentCell = this.Table2[2, Table2.CurrentCell.RowIndex + 1];
                }
            }
            else {
                if (Table2.CurrentCell.ReadOnly != true && Table2.SelectedCells[0].ColumnIndex != 1)

                {

                    Table2.CurrentCell.Value = string.Format("{0:0.0000}", OptPlot1_1);
                    Table2.CurrentCell.Style.BackColor = System.Drawing.Color.White;
                }

                else

                {

                    MessageBox.Show("Запись запрещена!");

                }
            }





            bool doNotWrite = false;
            double SredValue = 0;

            if (USE_KO == false)
            {
                if (Table2.CurrentCell.Value == null)
                {
                    El = new double[NoCaIzm1];

                    doNotWrite = true;


                    // El = new double[NoCaIzm1 + 1];
                    //for (int j = 0; j < Table2.Rows.Count - 1; j++)
                    //{
                    // El = new double[NoCaIzm1 + 1];
                    SredValue = 0;
                    for (int i1 = 1; i1 <= NoCaIzm1; i1++)
                    {
                        if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value == null)
                        {
                            cellnull++;
                        }
                        else
                        {
                            if (aproksim == "Линейная через 0")
                            {
                                if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value.ToString() != "")
                                {
                                    serValue = Convert.ToDouble(Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value.ToString()) / Convert.ToDouble(AgroText1.Text);
                                }
                                else
                                {
                                    serValue = 0;
                                }

                            }
                            if (aproksim == "Линейная")
                            {
                                if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value.ToString() != "")
                                {
                                    serValue = ((Convert.ToDouble(Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value.ToString()) - Convert.ToDouble(AgroText0.Text))) / Convert.ToDouble(AgroText1.Text);
                                }
                                else
                                {
                                    serValue = 0;
                                }
                            }
                            if (aproksim == "Квадратичная")
                            {
                                if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value.ToString() != "")
                                {
                                    serValue = ((Convert.ToDouble(Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value.ToString()) - Convert.ToDouble(AgroText0.Text))) / (Convert.ToDouble(AgroText1.Text) + Convert.ToDouble(AgroText2.Text));
                                }
                                else
                                {
                                    serValue = 0;
                                }
                            }
                            double CValue1 = Convert.ToDouble(F1Text.Text);
                            double CValue2 = Convert.ToDouble(F2Text.Text);
                            if (serValue >= 0)
                            {
                                Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value = string.Format("{0:0.0000}", serValue * CValue1 * CValue2);
                                SredValue += Convert.ToDouble(Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value.ToString());
                            }
                            else
                            {
                                Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value = "";
                            }
                            CCR = SredValue / NoCaIzm1;
                            if (Convert.ToDouble(textBox7.Text) >= 1)
                            {
                                Table2.Rows[Table2.CurrentCell.RowIndex].Cells["Ccr"].Value = string.Format("{0:0.0000}", CCR) + "±" + string.Format("{0:0.00}", ((CCR * Convert.ToDouble(textBox7.Text)) / 100));
                            }
                            else Table2.Rows[Table2.CurrentCell.RowIndex].Cells["Ccr"].Value = string.Format("{0:0.0000}", CCR);
                            //Table2.Rows[j].Cells["d%"].Value = El.Max();
                            //  El[i1] = Convert.ToDouble(Table2.Rows[j].Cells["C,edconctr;Ser." + i1].Value.ToString());
                        }
                        //El = new double[NoCaIzm1 + 1];
                        if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value == null)
                        {
                            cellnull++;
                        }
                        else
                        {
                            if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value.ToString() != "")
                            {
                                El[i1 - 1] = Convert.ToDouble(Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value.ToString());
                            }
                        }
                    }

                    Array.Sort(El);
                    maxEl = El[El.Length - 1];
                    minEl = El[0];
                    double a = ((maxEl - minEl) * 100) / Convert.ToDouble(CCR);
                    double b = a;
                    // b = b * 10;


                    if (minEl == 0)
                    {
                        Table2.Rows[Table2.CurrentCell.RowIndex].Cells["d%"].Value = 0.0000;
                    }
                    else
                    {
                        Table2.Rows[Table2.CurrentCell.RowIndex].Cells["d%"].Value = string.Format("{0:0.00}", b);

                    }
                }

            }
            else
            {
                for (int i1 = 1; i1 <= NoCaIzm1; i1++)
                {
                    Table2.Rows[0].Cells["C,edconctr;Ser." + i1].ReadOnly = true;
                    if (selet_rezim == 2)
                    {
                        Table2.Rows[0].Cells["Ccr"].ReadOnly = true;
                        Table2.Rows[0].Cells["d%"].ReadOnly = true;
                    }
                }
                if (Table2.CurrentCell.Value == null && Table2.CurrentCell.ReadOnly != true && Table2.SelectedCells[0].ColumnIndex != 1)
                {
                    Table2_UseCo();
                }
            }

            if (!doNotWrite)
            {
                if (USE_KO == true)
                {
                    Table2_UseCo();
                }

                else
                {
                    for (int i = 1; i <= NoCaIzm1; i++)
                    {
                        Table2.Rows[0].Cells["C,edconctr;Ser." + i].ReadOnly = true;
                        Table2.Rows[0].Cells["Ccr"].ReadOnly = true;
                        Table2.Rows[0].Cells["d%"].ReadOnly = true;
                    }
                    El = new double[NoCaIzm1];

                    // for (int j = 0; j < Table2.Rows.Count - 1; j++)
                    // {
                    SredValue = 0;
                    for (int i1 = 1; i1 <= NoCaIzm1; i1++)
                    {
                        if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value == null)
                        {
                            cellnull++;
                        }
                        else
                        {
                            if (aproksim == "Линейная через 0")
                            {
                                if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value.ToString() != "")
                                {
                                    serValue = Convert.ToDouble(Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value.ToString()) / Convert.ToDouble(AgroText1.Text);
                                }
                                else
                                {
                                    serValue = 0;
                                }

                            }
                            if (aproksim == "Линейная")
                            {
                                if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value.ToString() != "")
                                {
                                    serValue = ((Convert.ToDouble(Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value.ToString()) - Convert.ToDouble(AgroText0.Text))) / Convert.ToDouble(AgroText1.Text);
                                }
                                else
                                {
                                    serValue = 0;
                                }
                            }
                            if (aproksim == "Квадратичная")
                            {
                                if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value.ToString() != "")
                                {
                                    serValue = ((Convert.ToDouble(Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value.ToString()) - Convert.ToDouble(AgroText0.Text))) / (Convert.ToDouble(AgroText1.Text) + Convert.ToDouble(AgroText2.Text));
                                }
                                else
                                {
                                    serValue = 0;
                                }
                            }
                            double CValue1 = Convert.ToDouble(F1Text.Text);
                            double CValue2 = Convert.ToDouble(F2Text.Text);

                            if (serValue >= 0)
                            {
                                Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value = string.Format("{0:0.0000}", serValue * CValue1 * CValue2);
                                SredValue += Convert.ToDouble(Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value.ToString());
                            }
                            else
                            {
                                Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value = "";
                            }
                            CCR = SredValue / NoCaIzm1;
                            if (Convert.ToDouble(textBox7.Text) >= 1)
                            {
                                Table2.Rows[Table2.CurrentCell.RowIndex].Cells["Ccr"].Value = string.Format("{0:0.0000}", CCR) + "±" + string.Format("{0:0.00}", ((CCR * Convert.ToDouble(textBox7.Text)) / 100));
                            }
                            else Table2.Rows[Table2.CurrentCell.RowIndex].Cells["Ccr"].Value = string.Format("{0:0.0000}", CCR);
                            //Table2.Rows[j].Cells["d%"].Value = El.Max();
                            if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value == null)
                            {
                                cellnull++;
                            }
                            else
                            {
                                if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value.ToString() != "")
                                {
                                    El[i1 - 1] = Convert.ToDouble(Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value.ToString());
                                }
                            }
                        }

                    }

                    Array.Sort(El);
                    maxEl = El[El.Length - 1];
                    minEl = El[0];
                    double a = ((maxEl - minEl) * 100) / Convert.ToDouble(CCR);
                    double b = a;


                    if (minEl == 0)
                    {
                        Table2.Rows[Table2.CurrentCell.RowIndex].Cells["d%"].Value = 0.0000;
                    }
                    else
                    {
                        Table2.Rows[Table2.CurrentCell.RowIndex].Cells["d%"].Value = string.Format("{0:0.00}", b);

                    }
                    // return;

                    /* for (int i1 = 1; i1 <= NoCaIzm1; i1++)
                     {
                         Table2.Rows[0].Cells["C,edconctr;Ser." + i1].Value = "";
                         Table2.Rows[0].Cells["Ccr"].Value = "";
                         Table2.Rows[0].Cells["d%"].Value = "";
                     }*/
                }
            }
            if ((curentIndex != Table2.ColumnCount - 2 || Table2.CurrentCell.RowIndex != Table2.Rows.Count - 2) && Table2.CurrentCell.ReadOnly != true)

            {

                if (Table2.CurrentCell.RowIndex != Table2.Rows.Count - 2)

                {

                    Table2.CurrentCell = this.Table2[curentIndex, Table2.CurrentCell.RowIndex + 1];

                }

                else

                {

                    Table2.CurrentCell = this.Table2[curentIndex + 2, 0];

                }

            }

            else

            {

                Table2.CurrentCell = this.Table2[2, 0];

            }

        }
        public void ZapicInTable2()
        {
            bool doNotWrite = false;
            double sum = 0.0;
            int rowIndex = Table2.CurrentRow.Index;
            int curentIndex = Table2.CurrentCell.ColumnIndex;
            double CCR = 0.0;
            double maxEl;
            double minEl;
            double serValue = 0;
            int cellnull = 0;
            if (Table2.CurrentCell.ColumnIndex > 1)
            {
                InputBox _InputBox = new InputBox(this);
                _InputBox.ShowDialog();
                if (Table2.CurrentCell.ReadOnly != true)
                {
                    Table2.CurrentCell.Value = string.Format("{0:0.0000}", CellOpt);
                    if (CelloptCopy != CellOpt)
                    {
                        Table2.CurrentCell.Style.BackColor = System.Drawing.Color.Pink;
                    }

                    CellOpt = 0;
                }
                else
                {
                    MessageBox.Show("Запись запрещена!");
                }
            }
            PodschetTable2();
            if (curentIndex != Table2.ColumnCount - 1 || rowIndex != Table2.Rows.Count - 2)
            {
                if (rowIndex != Table2.Rows.Count - 2)
                {
                    Table2.CurrentCell = this.Table2[curentIndex, rowIndex + 1];
                }
                else
                {
                    Table2.CurrentCell = this.Table2[curentIndex + 2, 0];
                }
            }
        }
        public void PodschetTable2()
        {
            bool doNotWrite = false;
            double sum = 0.0;
            int rowIndex = Table2.CurrentRow.Index;
            int curentIndex = Table2.CurrentCell.ColumnIndex;
            double CCR = 0.0;
            double maxEl;
            double minEl;
            double serValue = 0;
            int cellnull = 0;
            if (USE_KO == false)
            {
                if (Table2.CurrentCell.Value == null)
                {
                    El = new double[NoCaIzm1];

                    doNotWrite = true;


                    // El = new double[NoCaIzm1 + 1];
                    //for (int j = 0; j < Table2.Rows.Count - 1; j++)
                    //{
                    // El = new double[NoCaIzm1 + 1];
                    double SredValue = 0;
                    for (int i1 = 1; i1 <= NoCaIzm1; i1++)
                    {
                        if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value == null)
                        {
                            cellnull++;
                        }
                        else
                        {
                            if (aproksim == "Линейная через 0")
                            {
                                if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value.ToString() != "")
                                {
                                    serValue = Convert.ToDouble(Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value.ToString()) / Convert.ToDouble(AgroText1.Text);
                                }
                                else
                                {
                                    serValue = 0;
                                }

                            }
                            if (aproksim == "Линейная")
                            {
                                if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value.ToString() != "")
                                {
                                    serValue = ((Convert.ToDouble(Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value.ToString()) - Convert.ToDouble(AgroText0.Text))) / Convert.ToDouble(AgroText1.Text);
                                }
                                else
                                {
                                    serValue = 0;
                                }
                            }
                            if (aproksim == "Квадратичная")
                            {
                                if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value.ToString() != "")
                                {
                                    serValue = ((Convert.ToDouble(Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value.ToString()) - Convert.ToDouble(AgroText0.Text))) / (Convert.ToDouble(AgroText1.Text) + Convert.ToDouble(AgroText2.Text));
                                }
                                else
                                {
                                    serValue = 0;
                                }
                            }
                            double CValue1 = Convert.ToDouble(F1Text.Text);
                            double CValue2 = Convert.ToDouble(F2Text.Text);
                            if (serValue >= 0)
                            {
                                Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value = string.Format("{0:0.0000}", serValue * CValue1 * CValue2);
                                SredValue += Convert.ToDouble(Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value.ToString());
                            }
                            else
                            {
                                Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value = "";
                            }
                            CCR = SredValue / NoCaIzm1;
                            if (Convert.ToDouble(textBox7.Text) >= 1)
                            {
                                Table2.Rows[Table2.CurrentCell.RowIndex].Cells["Ccr"].Value = string.Format("{0:0.0000}", CCR) + "±" + string.Format("{0:0.00}", ((CCR * Convert.ToDouble(textBox7.Text)) / 100));
                            }
                            else Table2.Rows[Table2.CurrentCell.RowIndex].Cells["Ccr"].Value = string.Format("{0:0.0000}", CCR);
                            //Table2.Rows[j].Cells["d%"].Value = El.Max();
                            //  El[i1] = Convert.ToDouble(Table2.Rows[j].Cells["C,edconctr;Ser." + i1].Value.ToString());
                        }
                        //El = new double[NoCaIzm1 + 1];
                        if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value == null)
                        {
                            cellnull++;
                        }
                        else
                        {
                            if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value.ToString() != "")
                            {
                                El[i1 - 1] = Convert.ToDouble(Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value.ToString());
                            }
                        }
                    }

                    Array.Sort(El);
                    maxEl = El[El.Length - 1];
                    minEl = El[0];
                    double a = ((maxEl - minEl) * 100) / Convert.ToDouble(CCR);
                    double b = a;
                    // b = b * 10;


                    if (minEl == 0)
                    {
                        Table2.Rows[Table2.CurrentCell.RowIndex].Cells["d%"].Value = 0.0000;
                    }
                    else
                    {
                        Table2.Rows[Table2.CurrentCell.RowIndex].Cells["d%"].Value = string.Format("{0:0.00}", b);

                    }
                }

            }
            else
            {
                for (int i1 = 1; i1 <= NoCaIzm1; i1++)
                {
                    Table2.Rows[0].Cells["C,edconctr;Ser." + i1].ReadOnly = true;
                    Table2.Rows[0].Cells["Ccr"].ReadOnly = true;
                    Table2.Rows[0].Cells["d%"].ReadOnly = true;
                }
                if (Table2.CurrentCell.Value == null && Table2.CurrentCell.ReadOnly != true)
                {
                    El = new double[NoCaIzm1];

                    doNotWrite = true;


                    // El = new double[NoCaIzm1 + 1];
                    for (int j = 0; j < Table2.Rows.Count - 1; j++)
                    {
                        // El = new double[NoCaIzm1 + 1];
                        double SredValue = 0;
                        for (int i1 = 1; i1 <= NoCaIzm1; i1++)
                        {
                            if (Table2.Rows[j].Cells["A;Ser" + i1].Value == null)
                            {
                                cellnull++;
                            }
                            else
                            {
                                if (aproksim == "Линейная через 0")
                                {
                                    if (Table2.Rows[0].Cells["A;Ser" + i1].Value.ToString() != "" && Table2.Rows[j].Cells["A;Ser" + i1].Value.ToString() != "")
                                    {
                                        serValue = (Convert.ToDouble(Table2.Rows[j].Cells["A;Ser" + i1].Value.ToString()) - Convert.ToDouble(Table2.Rows[0].Cells["A;Ser" + i1].Value.ToString())) / Convert.ToDouble(AgroText1.Text);
                                    }
                                    else
                                    {

                                        serValue = 0;
                                        if (Table2.Rows[0].Cells["A;Ser" + i1].Value.ToString() == null)
                                        {
                                            MessageBox.Show("Измерьте Контрольый образец!");
                                            return;


                                        }
                                    }
                                }
                                if (aproksim == "Линейная")
                                {
                                    if (Table2.Rows[0].Cells["A;Ser" + i1].Value.ToString() != "" && Table2.Rows[j].Cells["A;Ser" + i1].Value.ToString() != "")
                                    {
                                        serValue = ((Convert.ToDouble(Table2.Rows[j].Cells["A;Ser" + i1].Value.ToString()) - Convert.ToDouble(Table2.Rows[0].Cells["A;Ser" + i1].Value.ToString()) - Convert.ToDouble(AgroText0.Text))) / Convert.ToDouble(AgroText1.Text);
                                    }
                                    else
                                    {

                                        serValue = 0;
                                        if (Table2.Rows[0].Cells["A;Ser" + i1].Value.ToString() == null)
                                        {
                                            MessageBox.Show("Измерьте Контрольный образец!");
                                            return;


                                        }
                                    }

                                }
                                if (aproksim == "Квадратичная")
                                {
                                    if (Table2.Rows[0].Cells["A;Ser" + i1].Value.ToString() != "" && Table2.Rows[j].Cells["A;Ser" + i1].Value.ToString() != "")
                                    {
                                        serValue = ((Convert.ToDouble(Table2.Rows[j].Cells["A;Ser" + i1].Value.ToString()) - Convert.ToDouble(Table2.Rows[0].Cells["A;Ser" + i1].Value.ToString()) - Convert.ToDouble(AgroText0.Text))) / (Convert.ToDouble(AgroText1.Text) + Convert.ToDouble(AgroText2.Text));
                                    }
                                    else
                                    {
                                        serValue = 0;
                                        if (Table2.Rows[0].Cells["A;Ser" + i1].Value.ToString() == null)
                                        {
                                            MessageBox.Show("Измерьте Контрольный образец!");
                                            return;


                                        }
                                    }
                                }
                                double CValue1 = Convert.ToDouble(F1Text.Text);
                                double CValue2 = Convert.ToDouble(F2Text.Text);

                                if (serValue >= 0)
                                {
                                    Table2.Rows[j].Cells["C,edconctr;Ser." + i1].Value = string.Format("{0:0.0000}", serValue * CValue1 * CValue2);
                                    SredValue += Convert.ToDouble(Table2.Rows[j].Cells["C,edconctr;Ser." + i1].Value.ToString());
                                }
                                else
                                {
                                    Table2.Rows[j].Cells["C,edconctr;Ser." + i1].Value = "";
                                }
                                CCR = SredValue / NoCaIzm1;
                                if (Convert.ToDouble(textBox7.Text) >= 1)
                                {
                                    Table2.Rows[j].Cells["Ccr"].Value = string.Format("{0:0.0000}", CCR) + "±" + string.Format("{0:0.00}", ((CCR * Convert.ToDouble(textBox7.Text)) / 100));
                                }
                                else Table2.Rows[j].Cells["Ccr"].Value = string.Format("{0:0.0000}", CCR);
                                //Table2.Rows[j].Cells["d%"].Value = El.Max();
                                //  El[i1] = Convert.ToDouble(Table2.Rows[j].Cells["C,edconctr;Ser." + i1].Value.ToString());
                            }
                            //El = new double[NoCaIzm1 + 1];
                            if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value == null)
                            {
                                cellnull++;
                            }
                            else
                            {
                                if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value.ToString() != "")
                                {
                                    El[i1 - 1] = Convert.ToDouble(Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value.ToString());
                                }
                            }
                        }

                        Array.Sort(El);
                        maxEl = El[El.Length - 1];
                        minEl = El[0];
                        double a = ((maxEl - minEl) * 100) / Convert.ToDouble(CCR);
                        double b = a;
                        // b = b * 10;


                        if (minEl == 0)
                        {
                            Table2.Rows[Table2.CurrentCell.RowIndex].Cells["d%"].Value = 0.0000;
                        }
                        else
                        {
                            Table2.Rows[Table2.CurrentCell.RowIndex].Cells["d%"].Value = string.Format("{0:0.00}", b);

                        }

                    }
                }
                for (int i1 = 1; i1 <= NoCaIzm1; i1++)
                {
                    Table2.Rows[0].Cells["C,edconctr;Ser." + i1].Value = "";
                    Table2.Rows[0].Cells["Ccr"].Value = "";
                    Table2.Rows[0].Cells["d%"].Value = "";
                }
            }


            if (!doNotWrite)
            {
                if (USE_KO == true)
                {

                    Table2_UseCo();


                }

                else
                {
                    for (int i = 1; i <= NoCaIzm1; i++)
                    {
                        Table2.Rows[0].Cells["C,edconctr;Ser." + i].ReadOnly = true;
                        Table2.Rows[0].Cells["Ccr"].ReadOnly = true;
                        Table2.Rows[0].Cells["d%"].ReadOnly = true;
                    }
                    El = new double[NoCaIzm1];

                    // for (int j = 0; j < Table2.Rows.Count - 1; j++)
                    // {
                    double SredValue = 0;
                    for (int i1 = 1; i1 <= NoCaIzm1; i1++)
                    {
                        if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value == null)
                        {
                            cellnull++;
                        }
                        else
                        {
                            if (aproksim == "Линейная через 0")
                            {
                                if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value.ToString() != "")
                                {

                                    serValue = Convert.ToDouble(Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value.ToString()) / Convert.ToDouble(AgroText1.Text);
                                }
                                else
                                {
                                    serValue = 0;
                                }

                            }
                            if (aproksim == "Линейная")
                            {
                                if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value.ToString() != "")
                                {
                                    serValue = ((Convert.ToDouble(Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value.ToString()) - Convert.ToDouble(AgroText0.Text))) / Convert.ToDouble(AgroText1.Text);
                                }
                                else
                                {
                                    serValue = 0;
                                }
                            }
                            if (aproksim == "Квадратичная")
                            {
                                if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value.ToString() != "")
                                {
                                    serValue = ((Convert.ToDouble(Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i1].Value.ToString()) - Convert.ToDouble(AgroText0.Text))) / (Convert.ToDouble(AgroText1.Text) + Convert.ToDouble(AgroText2.Text));
                                }
                                else
                                {
                                    serValue = 0;
                                }
                            }
                            double CValue1 = Convert.ToDouble(F1Text.Text);
                            double CValue2 = Convert.ToDouble(F2Text.Text);

                            if (serValue >= 0)
                            {
                                Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value = string.Format("{0:0.0000}", serValue * CValue1 * CValue2);
                                SredValue += Convert.ToDouble(Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value.ToString());
                            }
                            else
                            {
                                Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value = "";
                            }
                            CCR = SredValue / NoCaIzm1;
                            if (Convert.ToDouble(textBox7.Text) >= 1)
                            {
                                Table2.Rows[Table2.CurrentCell.RowIndex].Cells["Ccr"].Value = string.Format("{0:0.0000}", CCR) + "±" + string.Format("{0:0.00}", ((CCR * Convert.ToDouble(textBox7.Text)) / 100));
                            }
                            else Table2.Rows[Table2.CurrentCell.RowIndex].Cells["Ccr"].Value = string.Format("{0:0.0000}", CCR);
                            //Table2.Rows[j].Cells["d%"].Value = El.Max();
                            if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value == null)
                            {
                                cellnull++;
                            }
                            else
                            {
                                if (Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value.ToString() != "")
                                {
                                    El[i1 - 1] = Convert.ToDouble(Table2.Rows[Table2.CurrentCell.RowIndex].Cells["C,edconctr;Ser." + i1].Value.ToString());
                                }
                            }
                        }

                    }

                    Array.Sort(El);
                    maxEl = El[El.Length - 1];
                    minEl = El[0];
                    double a = ((maxEl - minEl) * 100) / Convert.ToDouble(CCR);
                    double b = a;


                    if (minEl == 0)
                    {
                        Table2.Rows[Table2.CurrentCell.RowIndex].Cells["d%"].Value = 0.0000;
                    }
                    else
                    {
                        Table2.Rows[Table2.CurrentCell.RowIndex].Cells["d%"].Value = string.Format("{0:0.00}", b);

                    }
                    // return;

                    /* for (int i1 = 1; i1 <= NoCaIzm1; i1++)
                     {
                         Table2.Rows[0].Cells["C,edconctr;Ser." + i1].Value = "";
                         Table2.Rows[0].Cells["Ccr"].Value = "";
                         Table2.Rows[0].Cells["d%"].Value = "";
                     }*/
                }
            }


            doNotWrite = false;
            for (int j = 0; j < Table2.Rows.Count - 1; j++)
            {

                for (int i = 2; i < Table2.Rows[j].Cells.Count; i++)
                {
                    if (Table2.Rows[j].Cells[i].Value == null)
                    {
                        doNotWrite = true;
                        break;

                    }
                }
            }
            if (doNotWrite == true)
            {
                button3.Enabled = true;
                button9.Enabled = false;
            }
        }
        public void Table2_UseCo()
        {
            double CCR = 0.0;

            double maxEl;
            double minEl;
            double serValue = 0;
            int cellnull = 0;
            int count = 0;
            for (int i1 = 0; i1 < Table2.RowCount - 1; i1++)
            {
                serValue = 0;
                El = new double[NoCaIzm1];

                double SredValue = 0;
                for (int i = 1; i <= NoCaIzm1; i++)
                {
                    if (Table2.Rows[i1].Cells["A;Ser" + i].Value == null)
                    {
                        cellnull++;
                    }
                    else
                    {
                        if (aproksim == "Линейная через 0")
                        {

                            if (Table2.Rows[0].Cells["A;Ser" + i].Value.ToString() != "" && Table2.Rows[i1].Cells["A;Ser" + i].Value.ToString() != "")
                            {
                                if ((Convert.ToDouble(Table2.Rows[0].Cells["A;Ser" + i].Value.ToString()) > Convert.ToDouble(Table2.Rows[i1].Cells["A;Ser" + i].Value.ToString())) && count == 0)
                                {
                                    if (count == 0)
                                    {
                                        count++;
                                        MessageBox.Show("Оптическая плотность контрольногго образца не может быть больше иззмеряемого!");
                                    }

                                }

                                serValue = (Convert.ToDouble(Table2.Rows[i1].Cells["A;Ser" + i].Value.ToString()) - Convert.ToDouble(Table2.Rows[0].Cells["A;Ser" + i].Value.ToString())) / Convert.ToDouble(AgroText1.Text);
                            }
                            else
                            {

                                serValue = 0;
                                if (Table2.Rows[0].Cells["A;Ser" + i1].Value.ToString() == null)
                                {
                                    MessageBox.Show("Измерьте Контрольный образец!");
                                    return;


                                }
                            }
                        }
                        if (aproksim == "Линейная")
                        {
                            if (Table2.Rows[0].Cells["A;Ser" + i].Value.ToString() != "" && Table2.Rows[Table2.CurrentCell.RowIndex].Cells["A;Ser" + i].Value.ToString() != "")
                            {
                                if ((Convert.ToDouble(Table2.Rows[0].Cells["A;Ser" + i].Value.ToString()) > Convert.ToDouble(Table2.Rows[i1].Cells["A;Ser" + i].Value.ToString())) && count == 0)
                                {
                                    if (count == 0)
                                    {
                                        count++;
                                        MessageBox.Show("Оптическая плотность контрольногго образца не может быть больше иззмеряемого!");
                                    }
                                }
                                serValue = ((Convert.ToDouble(Table2.Rows[i1].Cells["A;Ser" + i].Value.ToString()) - Convert.ToDouble(Table2.Rows[0].Cells["A;Ser" + i].Value.ToString()) - Convert.ToDouble(AgroText0.Text))) / Convert.ToDouble(AgroText1.Text);
                            }
                            else
                            {

                                serValue = 0;
                                if (Table2.Rows[0].Cells["A;Ser" + i1].Value.ToString() == null)
                                {
                                    MessageBox.Show("Измерьте Контрольный образец!");
                                    return;


                                }
                            }

                        }
                        if (aproksim == "Квадратичная")
                        {
                            if (Table2.Rows[0].Cells["A;Ser" + i].Value.ToString() != "" && Table2.Rows[i1].Cells["A;Ser" + i].Value.ToString() != "")
                            {
                                if ((Convert.ToDouble(Table2.Rows[0].Cells["A;Ser" + i].Value.ToString()) > Convert.ToDouble(Table2.Rows[i1].Cells["A;Ser" + i].Value.ToString())) && count == 0)
                                {
                                    if (count == 0)
                                    {
                                        count++;
                                        MessageBox.Show("Оптическая плотность контрольногго образца не может быть больше иззмеряемого!");
                                    }
                                }
                                serValue = ((Convert.ToDouble(Table2.Rows[i1].Cells["A;Ser" + i].Value.ToString()) - Convert.ToDouble(Table2.Rows[0].Cells["A;Ser" + i].Value.ToString()) - Convert.ToDouble(AgroText0.Text))) / (Convert.ToDouble(AgroText1.Text) + Convert.ToDouble(AgroText2.Text));
                            }
                            else
                            {
                                serValue = 0;
                                if (Table2.Rows[0].Cells["A;Ser" + i].Value.ToString() == null)
                                {
                                    MessageBox.Show("Измерьте Контрольый образец!");
                                    return;


                                }
                            }
                        }
                        double CValue1 = Convert.ToDouble(F1Text.Text);
                        double CValue2 = Convert.ToDouble(F2Text.Text);

                        if (serValue >= 0)
                        {
                            Table2.Rows[i1].Cells["C,edconctr;Ser." + i].Value = string.Format("{0:0.0000}", serValue * CValue1 * CValue2);
                            SredValue += Convert.ToDouble(Table2.Rows[i1].Cells["C,edconctr;Ser." + i].Value.ToString());
                        }
                        else
                        {
                            Table2.Rows[i1].Cells["C,edconctr;Ser." + i].Value = "";
                        }
                        if (Convert.ToDouble(Table2.Rows[0].Cells["A;Ser" + i].Value.ToString()) > Convert.ToDouble(Table2.Rows[i1].Cells["A;Ser" + i].Value.ToString()))
                        {
                            if (selet_rezim == 2)
                            {
                                Table2.Rows[i1].Cells["Ccr"].Value = "";
                            }

                        }
                        else {
                            if (selet_rezim == 2)
                            {
                                CCR = SredValue / NoCaIzm1;
                                if (Convert.ToDouble(textBox7.Text) >= 1)
                                {

                                    Table2.Rows[i1].Cells["Ccr"].Value = string.Format("{0:0.0000}", CCR) + "±" + string.Format("{0:0.0000}", ((CCR * Convert.ToDouble(textBox7.Text))) / 100);
                                }
                                else
                                {

                                    Table2.Rows[i1].Cells["Ccr"].Value = string.Format("{0:0.0000}", CCR);
                                }

                                //Table2.Rows[j].Cells["d%"].Value = El.Max();
                                if (Table2.Rows[i1].Cells["C,edconctr;Ser." + i].Value == null)
                                {
                                    cellnull++;
                                }
                                else
                                {
                                    if (Table2.Rows[i1].Cells["C,edconctr;Ser." + i].Value.ToString() != "")
                                    {
                                        El[i - 1] = Convert.ToDouble(Table2.Rows[i1].Cells["C,edconctr;Ser." + i].Value.ToString());
                                    }
                                }
                            }
                        }




                    }
                }
                if (selet_rezim == 2)
                {
                    Array.Sort(El);
                    maxEl = El[El.Length - 1];
                    minEl = El[0];
                    double a = ((maxEl - minEl) * 100) / Convert.ToDouble(CCR);
                    double b = a;


                    if (minEl == 0)
                    {
                        Table2.Rows[i1].Cells["d%"].Value = 0.0000;
                    }
                    else
                    {
                        Table2.Rows[i1].Cells["d%"].Value = string.Format("{0:0.0}", b);

                    }
                }
            }
            for (int i1 = 1; i1 <= NoCaIzm1; i1++)
            {
                Table2.Rows[0].Cells["C,edconctr;Ser." + i1].Value = "";
                if (selet_rezim == 2)
                {
                    Table2.Rows[0].Cells["Ccr"].Value = "";
                    Table2.Rows[0].Cells["d%"].Value = "";
                }
            }


        }
        public void PrintMulti()
        {
            bool doNotWrite = false;
            for (int j = 0; j < dataGridView5.Rows.Count - 1; j++)
            {

                for (int i = 3; i < dataGridView5.Rows[j].Cells.Count; i++)
                {
                    if (dataGridView5.Rows[j].Cells[i].Value == null)
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
                prinPage = 0;
                strcountScan = 0;
                realwidth = 0;
                realheight = 0;
                width = 0;
                height1 = 0;
                pageyes = false; // для первй части таблицы (k = 7)
                pageyes_1 = false; // для второй части таблицы (dataGridView5.ColumnCount - k <= 14)
                pageyes1 = false;// для второй части таблицы (dataGridView5.ColumnCount - k > 14)
                pageyes1_1 = false; // для третей части таблицы ( dataGridView5.ColumnCount == 22)
                pageyes2 = false; // для третей части таблицы ( dataGridView5.ColumnCount > 22)
                pageyes2_1 = false; // первая часть готова
                pageyes2_2 = false; // вторая часть готова (dataGridView5.ColumnCount - k <= 14)
                pageyes2_3 = false; // вторая часть готова (dataGridView5.ColumnCount - k > 14)
                pageyes2_4 = false; // третья часть готова  ( dataGridView5.ColumnCount == 22)
                PrintPreviewDialogSelectPrinter printPreviewDialogSelectPrinter = new PrintPreviewDialogSelectPrinter();
                printPreviewDialogSelectPrinter.Document = MultiTablePrint;
                printPreviewDialogSelectPrinter.ShowDialog();

            }
        }
        public void PrintDoc()
        {
            bool doNotWrite = false;
            for (int j = 0; j < Table1.Rows.Count - 1; j++)
            {

                for (int i = 3; i < Table1.Rows[j].Cells.Count; i++)
                {
                    if (Table1.Rows[j].Cells[i].Value == null)
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
                prinPage = 0;
                strcountScan = 0;
                realwidth = 0;
                realheight = 0;
                width = 0;
                height1 = 0;

                PrintPreviewDialogSelectPrinter printPreviewDialogSelectPrinter = new PrintPreviewDialogSelectPrinter();
                printPreviewDialogSelectPrinter.Document = printTable1;
                printPreviewDialogSelectPrinter.ShowDialog();
            }
        }
        private int pagesCount;
        //  PaperSize paperSize = new PaperSize("papersize", 2100, 5);
        public int prinPage = 0;
        int strcountScan = 0;
        int realwidth = 0;
        int realheight = 0;
        int width = 0;
        int height1 = 0;

        public void PrintKinetica()
        {
            bool doNotWrite = false;
            for (int j = 0; j < TableKinetica1.Rows.Count - 1; j++)
            {

                for (int i = 0; i < TableKinetica1.Rows[j].Cells.Count; i++)
                {
                    if (TableKinetica1.Rows[j].Cells[i].Value == null)
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
                prinPage = 0;
                strcountScan = 0;
                realwidth = 0;
                realheight = 0;
                width = 0;
                height1 = 0;
                PrintPreviewDialogSelectPrinter printPreviewDialogSelectPrinter = new PrintPreviewDialogSelectPrinter();
                printPreviewDialogSelectPrinter.Document = KinTablePrint;
                printPreviewDialogSelectPrinter.ShowDialog();

            }
        }

        public void PrintScan()
        {
            bool doNotWrite = false;
            for (int j = 0; j < ScanTable.Rows.Count - 1; j++)
            {

                for (int i = 0; i < ScanTable.Rows[j].Cells.Count; i++)
                {
                    if (ScanTable.Rows[j].Cells[i].Value == null)
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
                prinPage = 0;
                strcountScan = 0;
                realwidth = 0;
                realheight = 0;
                width = 0;
                height1 = 0;
                PrintPreviewDialogSelectPrinter printPreviewDialogSelectPrinter = new PrintPreviewDialogSelectPrinter();
                printPreviewDialogSelectPrinter.Document = ScanTablePrint;
                printPreviewDialogSelectPrinter.ShowDialog();

            }
        }

        public void IzmerenieFR_TablePrintDoc()
        {
            bool doNotWrite = false;
            for (int j = 0; j < IzmerenieFR_Table.Rows.Count - 1; j++)
            {

                for (int i = 3; i < IzmerenieFR_Table.Rows[j].Cells.Count; i++)
                {
                    if (IzmerenieFR_Table.Rows[j].Cells[i].Value == null)
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

                PrintPreviewDialogSelectPrinter printPreviewDialogSelectPrinter = new PrintPreviewDialogSelectPrinter();
                printPreviewDialogSelectPrinter.Document = IzmerenieFRprintTable1;
                printPreviewDialogSelectPrinter.ShowDialog();
            }
        }
        public void PrintDoc1()
        {
            PrintPreviewDialogSelectPrinter printPreviewDialogSelectPrinter = new PrintPreviewDialogSelectPrinter();
            printPreviewDialogSelectPrinter.Document = printTable1;
            printPreviewDialogSelectPrinter.ShowDialog();
        }
        public void PrintDoc2()
        {
            bool doNotWrite = false;
            for (int j = 0; j < Table2.Rows.Count - 1; j++)
            {

                for (int i = 2; i < Table2.Rows[j].Cells.Count; i++)
                {
                    if (Table2.Rows[j].Cells[i].Value == null)
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
                if (Table2.Rows.Count >= 1)
                {

                    PrintPreviewDialogSelectPrinter printPreviewDialogSelectPrinter = new PrintPreviewDialogSelectPrinter();
                    printPreviewDialogSelectPrinter.Document = printTable2;
                    printPreviewDialogSelectPrinter.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Создайте таблицу измерений!");
                }
            }
        }
        int height;

        public void printdatagridview5_2(object sender, PrintPageEventArgs e)
        {

        }
        bool pageyes = false; // для первй части таблицы (k = 7)
        bool pageyes_1 = false; // для второй части таблицы (dataGridView5.ColumnCount - k <= 14)
        bool pageyes1 = false;// для второй части таблицы (dataGridView5.ColumnCount - k > 14)
        bool pageyes1_1 = false; // для третей части таблицы ( dataGridView5.ColumnCount == 22)
        bool pageyes2 = false; // для третей части таблицы ( dataGridView5.ColumnCount > 22)
        bool pageyes2_1 = false; // первая часть готова
        bool pageyes2_2 = false; // вторая часть готова (dataGridView5.ColumnCount - k <= 14)
        bool pageyes2_3 = false; // вторая часть готова (dataGridView5.ColumnCount - k > 14)

        private void ScanTablePrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (prinPage <= 0)
            {
                e.Graphics.DrawString("Измерение в режиме сканирования\n\n",
                new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, 100, 50);
                e.Graphics.DrawString("График сканирования\n\n",
                  new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 100, 100);
                height = ScanChart.Height;
                Bitmap bmp = new Bitmap(ScanChart.Width, ScanChart.Height);
                ScanChart.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, ScanChart.Width, ScanChart.Height));
                e.Graphics.DrawImage(bmp, 25, 130);
                height = height + 160;
                e.Graphics.DrawString("Таблица сканирования\n\n",
                new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 100, height);


                realwidth = ScanTable.Columns[0].Width + 5;
                realheight = height + 35;
                width = 100;
                height1 = ScanTable.Rows[0].Height + 5;
                for (int z = 0; z < ScanTable.Columns.Count; z++)
                {
                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                    e.Graphics.DrawString(ScanTable.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                    realwidth = realwidth + width;
                }
                realwidth = ScanTable.Columns[0].Width + 5;
                realheight = realheight + 20;

                while (strcountScan < ScanTable.Rows.Count - 1)
                {
                    for (int j = 0; j < ScanTable.Columns.Count; j++)
                    {
                        e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                        e.Graphics.DrawString(ScanTable.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                        realwidth = realwidth + width;

                    }
                    realwidth = ScanTable.Columns[0].Width + 5;
                    realheight = realheight + 20;

                    if (realheight > e.MarginBounds.Height)
                    {
                        height = 100;
                        e.HasMorePages = true;
                        //   strcountScan++;
                        prinPage++;
                        return;
                    }
                    else
                    {
                        e.HasMorePages = false;

                    }
                    // strcountScan++;

                    strcountScan++;
                }
            }
            else {
                realwidth = ScanTable.Columns[0].Width + 5;
                realheight = 20;
                width = 100;
                height1 = ScanTable.Rows[0].Height + 5;
                for (int z = 0; z < ScanTable.Columns.Count; z++)
                {
                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                    e.Graphics.DrawString(ScanTable.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                    realwidth = realwidth + width;
                }
                realwidth = ScanTable.Columns[0].Width + 5;
                realheight = realheight + 20;

                while (strcountScan < ScanTable.Rows.Count - 1)
                {
                    for (int j = 0; j < ScanTable.Columns.Count; j++)
                    {
                        e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                        e.Graphics.DrawString(ScanTable.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                        realwidth = realwidth + width;

                    }
                    realwidth = ScanTable.Columns[0].Width + 5;
                    realheight = realheight + 20;

                    if (realheight > e.MarginBounds.Height)
                    {
                        height = 100;
                        e.HasMorePages = true;
                        //   strcountScan++;
                        prinPage++;
                        return;
                    }
                    else
                    {
                        e.HasMorePages = false;

                    }
                    strcountScan++;
                }
            }
            prinPage = 0;
            strcountScan = 0;
        }

        private void KinTablePrint_PrintPage(object sender, PrintPageEventArgs e)
        {

            if (prinPage <= 0)
            {
                e.Graphics.DrawString("Протокол выполнения измерений\n         в Кинетическом режиме\n\n",
                new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, 180, 50);

                e.Graphics.DrawString("Идентификационный номер (код) исследования:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 115);
                e.Graphics.DrawString(code, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 400, 115);

                e.Graphics.DrawString("Лаборатория:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 135);
                e.Graphics.DrawString(name_lab, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 140, 135);

                e.Graphics.DrawString("Адрес лаборатории:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 155);
                e.Graphics.DrawString(address_lab, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 195, 155);

                e.Graphics.DrawString("Имя файла:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(25, 175));
                e.Graphics.DrawString(filepath, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(130, 175));
                height = height + 20;

                e.Graphics.DrawString("График измерений\n\n",
                  new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 195);
                height = chart3.Height;
                Bitmap bmp = new Bitmap(chart3.Width, chart3.Height);
                chart3.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, chart3.Width, chart3.Height));
                e.Graphics.DrawImage(bmp, 25, 220);
                height = height + 230;
                e.Graphics.DrawString("Таблица результатов измерений\n\n",
                new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, height);

                realwidth = TableKinetica1.Columns[0].Width + 5;
                realheight = height + 35;
                width = 100;
                height1 = TableKinetica1.Rows[0].Height + 5;
                for (int z = 0; z < ScanTable.Columns.Count; z++)
                {
                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                    e.Graphics.DrawString(TableKinetica1.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                    realwidth = realwidth + width;
                }
                realwidth = TableKinetica1.Columns[0].Width + 5;
                realheight = realheight + 20;

                while (strcountScan < TableKinetica1.Rows.Count - 1)
                {
                    for (int j = 0; j < TableKinetica1.Columns.Count; j++)
                    {
                        e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                        e.Graphics.DrawString(TableKinetica1.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                        realwidth = realwidth + width;

                    }
                    realwidth = TableKinetica1.Columns[0].Width + 5;
                    realheight = realheight + 20;

                    if (realheight > e.MarginBounds.Height)
                    {
                        height = 100;
                        e.HasMorePages = true;
                        //   strcountScan++;
                        e.Graphics.DrawString("Страница " + (prinPage + 1), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 300, 1100);
                        prinPage++;
                        return;
                    }
                    else
                    {
                        e.HasMorePages = false;

                    }
                    // strcountScan++;

                    strcountScan++;
                }
            }
            else {


                e.Graphics.DrawString("Идентификационный номер (код) исследования:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 50);
                e.Graphics.DrawString(code, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 400, 50);
                realwidth = TableKinetica1.Columns[0].Width + 5;
                realheight = 80;
                width = 100;
                height1 = TableKinetica1.Rows[0].Height + 5;
                for (int z = 0; z < TableKinetica1.Columns.Count; z++)
                {
                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                    e.Graphics.DrawString(TableKinetica1.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                    realwidth = realwidth + width;
                }
                realwidth = TableKinetica1.Columns[0].Width + 5;
                realheight = realheight + 20;

                while (strcountScan < TableKinetica1.Rows.Count - 1)
                {
                    for (int j = 0; j < TableKinetica1.Columns.Count; j++)
                    {
                        e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                        e.Graphics.DrawString(TableKinetica1.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                        realwidth = realwidth + width;

                    }
                    realwidth = TableKinetica1.Columns[0].Width + 5;
                    realheight = realheight + 20;

                    if (realheight > e.MarginBounds.Height)
                    {
                        height = 100;
                        e.HasMorePages = true;
                        //   strcountScan++;
                        e.Graphics.DrawString("Страница " + (prinPage + 1), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 300, 1100);
                        prinPage++;
                        return;
                    }
                    else
                    {
                        e.HasMorePages = false;

                    }
                    strcountScan++;
                }
            }
            KinPrintCancel(sender, e);


        }

        private void MultiTablePrint_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (prinPage <= 0)
            {
                e.Graphics.DrawString("Протокол выполнения измерений\n        в Многоволновом режиме\n\n\n\n",
                new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, 180, 50);
                height = 120;

                e.Graphics.DrawString("Идентификационный номер (код) исследования:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, height);
                e.Graphics.DrawString(code, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 400, height);

                height = height + 20;

                e.Graphics.DrawString("Лаборатория:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, height);
                e.Graphics.DrawString(name_lab, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 140, height);
                height = height + 20;

                e.Graphics.DrawString("Адрес лаборатории:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, height);
                e.Graphics.DrawString(address_lab, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 195, height);
                height = height + 20;

                e.Graphics.DrawString("Имя файла:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(25, height));
                e.Graphics.DrawString(filepath, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(130, height));
                height = height + 20;

                e.Graphics.DrawString("Таблица результатов измерений\n\n",
                new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, height);
                realwidth = dataGridView5.Columns[0].Width + 5;
                realheight = height + 30;
                width = 100;
                height1 = dataGridView5.Rows[0].Height + 5;
                if (dataGridView5.ColumnCount < 7)
                {
                    printdatagridview5(sender, e);
                }
                else
                {
                    if (dataGridView5.ColumnCount >= 7 || dataGridView5.ColumnCount <= 22)
                    {
                        printdatagridview5_1(sender, e);
                    }
                    else
                    {
                        // printdatagridview5_2(sender, e);
                    }
                }

            }
            else
            {
                height = 50;

                e.Graphics.DrawString("Идентификационный номер (код) исследования:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, height);
                e.Graphics.DrawString(code, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 400, height);

                height = height + 10;
                realwidth = dataGridView5.Columns[0].Width + 5;
                realheight = height;
                width = 100;
                height1 = dataGridView5.Rows[0].Height + 5;
                if (dataGridView5.ColumnCount >= 7 || dataGridView5.ColumnCount <= 22)
                {

                    if (prinPage > 1)
                    {
                        if (prinPage == 2 && dataGridView5.ColumnCount <= 17 && dataGridView5.Rows.Count > 22)
                        {
                            PrintDatagridview5PageAdd2(sender, e);
                        }
                        else
                        {
                            if (dataGridView5.ColumnCount > 17 && dataGridView5.Rows.Count < 22)
                            {
                                PrintDatagridview5PageAdd3(sender, e);
                                // PrintMultiCancel(sender, e);
                            }
                            else {

                                if (dataGridView5.ColumnCount > 17 && dataGridView5.Rows.Count > 22)
                                {
                                    if (prinPage == 2)
                                    {
                                        PrintDatagridview5PageAdd4(sender, e);
                                    }

                                    else
                                    {
                                        PrintDatagridview5PageAdd3(sender, e);
                                    }

                                    // PrintMultiCancel(sender, e);


                                }
                            }
                        }
                        //PrintMultiCancel(sender, e);
                    }
                    else
                    {
                        PrintDatagridview5PageAdd(sender, e);
                        if (dataGridView5.ColumnCount <= 17 || dataGridView5.Rows.Count < 22)
                        {
                            PrintMultiCancel(sender, e);
                        }



                    }
                }
                else
                {
                    PrintMultiCancel(sender, e);
                }

            }

        }
        public void PrintMultiCancel(object sender, PrintPageEventArgs e)
        {
            realheight += 30;

            e.Graphics.DrawString("Описание:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(25, realheight));
            e.Graphics.DrawString(Description, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(130, realheight));


            e.Graphics.DrawString("Дата:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, realheight + 20);
            e.Graphics.DrawString(DateTime, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 85, realheight + 20);
            e.Graphics.DrawString("Время начала:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 180, realheight + 20);
            e.Graphics.DrawString(" _______ ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 290, realheight + 20);
            e.Graphics.DrawString("Время окончания:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 380, realheight + 20);
            e.Graphics.DrawString(" _______ ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 530, realheight + 20);

            e.Graphics.DrawString("Исполнитель:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, realheight + 50);
            e.Graphics.DrawString(" _______________________ /   " + Ispolnitel, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 160, realheight + 50);
            e.Graphics.DrawString("Руководитель:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, realheight + 80);
            e.Graphics.DrawString(" _______________________ /   " + direction, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 160, realheight + 80);
            if (prinPage > 0)
            {
                e.Graphics.DrawString("Страница " + (prinPage + 1), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 300, 1100);
            }

            prinPage = 0;
            strcountScan = 0;
        }

        private void printTable1_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (prinPage <= 0)
            {
                e.Graphics.DrawString("Расчет линейного градуировочного графика\n\n", new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, 100, 50);

                e.Graphics.DrawString("Идентификационный номер (код) исследования:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 110);
                e.Graphics.DrawString(code, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 400, 110);

                e.Graphics.DrawString("Лаборатория:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 130);
                e.Graphics.DrawString(name_lab, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 140, 130);

                e.Graphics.DrawString("Адрес лаборатории:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 150);
                e.Graphics.DrawString(address_lab, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 195, 150);

                e.Graphics.DrawString("Нормативный документ:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 170);
                e.Graphics.DrawString(ND, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 250, 170);


                e.Graphics.DrawString("Вещество:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 190);
                e.Graphics.DrawString(Veshestvo1, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 115, 190);
                e.Graphics.DrawString("Длина волны (нм):", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 210);
                e.Graphics.DrawString(wavelength1, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 200, 210);
                e.Graphics.DrawString("Длина кюветы (мм):", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 300, 210);
                e.Graphics.DrawString(WidthCuvette, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 490, 210);
                e.Graphics.DrawString("Границы обнаружения:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 230);
                e.Graphics.DrawString("Нижняя:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 230, 230);
                e.Graphics.DrawString(BottomLine + " " + edconctr, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 330, 230);
                e.Graphics.DrawString("Верхняя:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 450, 230);
                e.Graphics.DrawString(TopLine + " " + edconctr, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 540, 230);

                e.Graphics.DrawString("Примечание:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 250);
                e.Graphics.DrawString(Description, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 155, 250);
                e.Graphics.DrawString("Статистика:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 270);
                e.Graphics.DrawString(RR.Text + "                                               " + SKO.Text + "\n" + label21.Text + "          " + label22.Text, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 140, 270);


                e.Graphics.DrawString("Информация о приборе:\n", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(25, 310));
                var applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);

                string model = path + @"pribor/model";
                DecriptorPribor decriptorModel = new DecriptorPribor(ref model, pathTemp);
                applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                // model = model.Substring(model.LastIndexOf(@"/") + 1);
                var filePathToOpen = Path.Combine(applicationDirectory, pathTemp + model);


                StreamReader fs = new StreamReader(filePathToOpen);
                e.Graphics.DrawString("Модель: ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(200, 330));
                e.Graphics.DrawString(fs.ReadLine(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(310, 330));
                fs.Close();

                string SerNomer_Text = path + @"pribor/SerNomer";
                DecriptorPribor decriptorSerNomer = new DecriptorPribor(ref SerNomer_Text, pathTemp);
                applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                //    SerNomer_Text = Convert.ToString((SerNomer_Text.LastIndexOf(@"\") + 1));
                filePathToOpen = Path.Combine(applicationDirectory, pathTemp + SerNomer_Text);

                StreamReader fs1 = new StreamReader(filePathToOpen);
                e.Graphics.DrawString("Серийный номер: ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(530, 330));
                e.Graphics.DrawString(fs1.ReadLine(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(700, 330));
                fs1.Close();


                string InventarNomer_Text = path + @"pribor/InventarNomer";
                DecriptorPribor decriptorInventarNomer = new DecriptorPribor(ref InventarNomer_Text, pathTemp);
                applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                //  InventarNomer_Text = Convert.ToString((InventarNomer_Text.LastIndexOf(@"\") + 1));
                filePathToOpen = Path.Combine(applicationDirectory, pathTemp + InventarNomer_Text);

                StreamReader fs2 = new StreamReader(filePathToOpen);
                e.Graphics.DrawString("Инвентарный номер: ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(500, 350));
                e.Graphics.DrawString(fs2.ReadLine(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(705, 350));
                fs2.Close();


                string Poveren_Text = path + @"pribor/Poveren";
                DecriptorPribor decriptorPoveren = new DecriptorPribor(ref Poveren_Text, pathTemp);
                applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                //   Poveren_Text = Convert.ToString((Poveren_Text.LastIndexOf(@"\") + 1));
                filePathToOpen = Path.Combine(applicationDirectory, pathTemp + Poveren_Text);


                StreamReader fs3 = new StreamReader(filePathToOpen);
                DateTime data = Convert.ToDateTime(fs3.ReadLine());
                // data.Date.ToString("d.mm.yyyy"); 
                //  MessageBox.Show(Convert.ToString(data));   
                data = data.AddYears(1);
                fs3.Close();
                e.Graphics.DrawString("Поверка действительна до: ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(60, 350));
                e.Graphics.DrawString(data.Date.ToString("dd.MM.yyyy"), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(315, 350));

                // e.Graphics.DrawString("Градуировочное уравнение: " + label14.Text, new System.Drawing.Font("C:\\Windows\\Fonts\\georgia.ttf", 12, FontStyle.Bold), Brushes.Black, new Point(50, 430));
                if (SposobZadan == "По СО")
                {
                    e.Graphics.DrawString("Таблица исходных данных ( ячейки, выделенные цветом ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 370);
                    e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(480, 370, 40, 20));
                    e.Graphics.DrawString(", изменены вручную!):", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(530, 370));
                    if (NoCaIzm <= 3)
                    {
                        Table1PrintViewer1(sender, e);
                    }
                    else
                    {
                        if (NoCaIzm > 3 && NoCaIzm <= 7)
                        {
                            Table1PrintViewer2(sender, e);
                        }
                        else
                        {
                            Table1PrintViewer3(sender, e);
                        }
                    }
                }
                else
                {
                    cordY = 370;
                }

                if (cordY > e.MarginBounds.Height)
                {
                    e.Graphics.DrawString("Страница " + (prinPage + 1) + " из 2", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 300, 1100);
                    e.HasMorePages = true;
                    //   strcountScan++;
                    prinPage++;
                    cordY = 50;
                    return;
                }
                else
                {
                    if (prinPage <= 0 && NoCaIzm > 3 && Table1.Rows.Count > 6)
                    {
                        e.Graphics.DrawString("Страница " + (prinPage + 1) + " из 2", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 300, 1100);
                        e.HasMorePages = true;
                        //   strcountScan++;
                        prinPage++;
                        cordY = 50;
                        return;
                    }
                    else {
                        if (prinPage <= 0 && NoCaIzm <= 3 && Table1.Rows.Count > 11)
                        {
                            e.Graphics.DrawString("Страница " + (prinPage + 1) + " из 2", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 300, 1100);
                            e.HasMorePages = true;
                            //   strcountScan++;
                            prinPage++;
                            cordY = 50;
                            return;
                        }
                        else {
                            if (prinPage <= 0)
                            {
                                e.HasMorePages = false;
                                e.Graphics.DrawString("Градуировочное уравнение:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, cordY + 30);
                                e.Graphics.DrawString(label14.Text, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 285, cordY + 30);
                                int height = chart1.Height;
                                Bitmap bmp = new Bitmap(chart1.Width, chart1.Height);
                                chart1.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, chart1.Width, chart1.Height));
                                e.Graphics.DrawImage(bmp, 25, cordY + 60);
                                cordY = cordY + chart1.Height + 70;

                                e.Graphics.DrawString("Дата:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, cordY);
                                e.Graphics.DrawString(DateTime, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 80, cordY);
                                e.Graphics.DrawString("Время начала:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 180, cordY);
                                e.Graphics.DrawString(" _______ ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 290, cordY);

                                e.Graphics.DrawString("Время окончания:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 380, cordY);
                                e.Graphics.DrawString(" _______ ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 530, cordY);

                                e.Graphics.DrawString("Исполнитель:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, cordY + 30);
                                e.Graphics.DrawString(" _______________________ /   " + Ispolnitel, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 160, cordY + 30);
                                e.Graphics.DrawString("Руководитель:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, cordY + 60);
                                e.Graphics.DrawString(" _______________________ /   " + direction, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 160, cordY + 60);

                                prinPage = 0;
                                strcountScan = 0;


                            }
                        }
                    }

                }
            }
            else
            {
                e.Graphics.DrawString("Идентификационный номер (код) исследования:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 50);
                e.Graphics.DrawString(code, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 400, 50);

                if (NoCaIzm > 7 && Table1.Rows.Count > 10)
                {
                    Table1PageAdd(sender, e);
                    e.Graphics.DrawString("Градуировочное уравнение:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, cordY + 30);
                    e.Graphics.DrawString(label14.Text, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 285, cordY + 30);
                    int height = chart1.Height;
                    Bitmap bmp = new Bitmap(chart1.Width, chart1.Height);
                    chart1.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, chart1.Width, chart1.Height));
                    e.Graphics.DrawImage(bmp, 25, cordY + 60);
                    cordY = cordY + chart1.Height + 70;
                }
                else
                {
                    if (NoCaIzm > 3 && NoCaIzm <= 7 && Table1.Rows.Count > 10)
                    {
                        Table1PageAdd2(sender, e);
                        e.Graphics.DrawString("Градуировочное уравнение:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, cordY + 30);
                        e.Graphics.DrawString(label14.Text, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 285, cordY + 30);
                        int height = chart1.Height;
                        Bitmap bmp = new Bitmap(chart1.Width, chart1.Height);
                        chart1.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, chart1.Width, chart1.Height));
                        e.Graphics.DrawImage(bmp, 25, cordY + 60);
                        cordY = cordY + chart1.Height + 70;
                    }
                    else
                    {
                        e.Graphics.DrawString("Градуировочное уравнение:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, cordY + 30);
                        e.Graphics.DrawString(label14.Text, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 285, cordY + 30);
                        int height = chart1.Height;
                        Bitmap bmp = new Bitmap(chart1.Width, chart1.Height);
                        chart1.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, chart1.Width, chart1.Height));
                        e.Graphics.DrawImage(bmp, 25, cordY + 60);
                        cordY = cordY + chart1.Height + 70;
                    }

                }
                e.Graphics.DrawString("Дата:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, cordY);
                e.Graphics.DrawString(DateTime, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 80, cordY);
                e.Graphics.DrawString("Время начала:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 180, cordY);
                e.Graphics.DrawString(" _______ ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 290, cordY);

                e.Graphics.DrawString("Время окончания:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 380, cordY);
                e.Graphics.DrawString(" _______ ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 530, cordY);

                e.Graphics.DrawString("Исполнитель:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, cordY + 30);
                e.Graphics.DrawString(" _______________________ /   " + Ispolnitel, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 160, cordY + 30);
                e.Graphics.DrawString("Руководитель:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, cordY + 60);
                e.Graphics.DrawString(" _______________________ /   " + direction, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 160, cordY + 60);


                e.Graphics.DrawString("Страница " + (prinPage + 1) + " из 2", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 300, 1100);
                prinPage = 0;
                strcountScan = 0;
            }
        }

        private void printTable2_PrintPage(object sender, PrintPageEventArgs e)
        {
            cordY = 480;
            if (prinPage <= 0)
            {
                e.Graphics.DrawString("Протокол выполнения измерений\n\n", new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, 100, 50);

                e.Graphics.DrawString("Идентификационный номер (код) исследования:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 110);
                e.Graphics.DrawString(code, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 400, 110);

                e.Graphics.DrawString("Лаборатория:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 130);
                e.Graphics.DrawString(name_lab, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 140, 130);

                e.Graphics.DrawString("Адрес лаборатории:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 150);
                e.Graphics.DrawString(address_lab, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 195, 150);

                //  e.Graphics.DrawString("Нормативный документ:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 170);
                //   e.Graphics.DrawString(ND, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 250, 170);

                e.Graphics.DrawString("Измерение:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 190);
                e.Graphics.DrawString("Имя файла:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 60, 210);
                e.Graphics.DrawString(filepath2, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 165, 210);
                e.Graphics.DrawString("Описание:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 60, 230);
                e.Graphics.DrawString(textBox8.Text, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 150, 230);

                e.Graphics.DrawString("Длина волны:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 60, 250);
                e.Graphics.DrawString(wavelength1, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 180, 250);

                e.Graphics.DrawString("Погрешность методики: ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 240, 250);
                e.Graphics.DrawString(textBox7.Text, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 470, 250);

                e.Graphics.DrawString("Оптическая длина кюветы:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 60, 270);
                e.Graphics.DrawString(Opt_dlin_cuvet.Text, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 320, 270);
                e.Graphics.DrawString("F1 = ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 420, 270);
                e.Graphics.DrawString(F1Text.Text, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 470, 270);
                e.Graphics.DrawString("F2 = ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 580, 270);
                e.Graphics.DrawString(F2Text.Text, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 630, 270);
                //e.Graphics.DrawString("Таблица исходных данных", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 230);
                e.Graphics.DrawString("Градуировка:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 290);
                //   e.Graphics.DrawString(textBox8.Text, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 130, 260);
                e.Graphics.DrawString("Имя файла:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 60, 310);
                e.Graphics.DrawString(filepath, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 170, 310);
                e.Graphics.DrawString("Описание:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 60, 330);
                e.Graphics.DrawString(Description, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 170, 330);
                e.Graphics.DrawString("Дата:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 60, 350);
                e.Graphics.DrawString(DateTime, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 120, 350);
                e.Graphics.DrawString("Действительна до: ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 230, 350);
                e.Graphics.DrawString(dateTimePicker1.Value.AddDays(Days).ToString("dd.MM.yyyy"), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 405, 350);
                e.Graphics.DrawString("Погрешность методики:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 505, 350);
                e.Graphics.DrawString(textBox3.Text, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 730, 350);
                e.Graphics.DrawString("Градуировочное уравнение:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 60, 370);
                e.Graphics.DrawString(label14.Text, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 330, 370);
                e.Graphics.DrawString("Нормативный документ:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 60, 390);
                e.Graphics.DrawString(ND, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 280, 390);
                e.Graphics.DrawString("Статистика:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 60, 410);
                e.Graphics.DrawString(RR.Text + "                                               " + SKO.Text + "\n" + label21.Text + "          " + label22.Text, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 140, 430);
                e.Graphics.DrawString("Информация о приборе:\n", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(25, 470));

                var applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);

                string model = path + @"pribor/model";
                DecriptorPribor decriptorModel = new DecriptorPribor(ref model, pathTemp);
                var model_var = Path.Combine(applicationDirectory, pathTemp + model);


                string SerNomer_Text = path + @"pribor/SerNomer";
                DecriptorPribor decriptorSerNomer = new DecriptorPribor(ref SerNomer_Text, pathTemp);
                var SerNomer_Text_var = Path.Combine(applicationDirectory, pathTemp + SerNomer_Text);

                string InventarNomer_Text = path + @"pribor/InventarNomer";
                DecriptorPribor decriptorInventarNomer = new DecriptorPribor(ref InventarNomer_Text, pathTemp);
                var InventarNomer_Text_var = Path.Combine(applicationDirectory, pathTemp + InventarNomer_Text);

                string SrokIstech_Text = path + @"pribor/SrokIstech";
                DecriptorPribor decriptorSrokIstech = new DecriptorPribor(ref SrokIstech_Text, pathTemp);
                var SrokIstech_Text_var = Path.Combine(applicationDirectory, pathTemp + SrokIstech_Text);

                string Poveren_Text = path + @"pribor/Poveren";
                DecriptorPribor decriptorPoveren = new DecriptorPribor(ref Poveren_Text, pathTemp);
                var Poveren_Text_var = Path.Combine(applicationDirectory, pathTemp + Poveren_Text);

                StreamReader fs = new StreamReader(model_var);
                e.Graphics.DrawString("Модель: ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(60, 490));
                e.Graphics.DrawString(fs.ReadLine(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(140, 490));
                fs.Close();

                StreamReader fs1 = new StreamReader(SerNomer_Text_var);
                e.Graphics.DrawString("Серийный номер: ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(500, 490));
                e.Graphics.DrawString(fs1.ReadLine(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(700, 490));
                fs1.Close();

                StreamReader fs2 = new StreamReader(InventarNomer_Text_var);
                e.Graphics.DrawString("Инвентарный номер: ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(500, 510));
                e.Graphics.DrawString(fs2.ReadLine(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(705, 510));
                fs2.Close();

                StreamReader fs3 = new StreamReader(Poveren_Text_var);
                DateTime data = Convert.ToDateTime(fs3.ReadLine());
                // data.Date.ToString("d.mm.yyyy"); 
                //  MessageBox.Show(Convert.ToString(data));   
                data = data.AddYears(1);
                fs3.Close();
                e.Graphics.DrawString("Поверка действительна до: ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(60, 510));
                e.Graphics.DrawString(data.Date.ToString("dd.MM.yyyy"), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(315, 510));
                e.Graphics.DrawString("Данные измерений (ячейки, выделенные цветом ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 530);

                e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(420, 530, 40, 20));
                e.Graphics.DrawString(", изменены вручную!):", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(470, 530));

                if (NoCaIzm1 <= 3)
                {
                    Table2PrintViewer1(sender, e);
                }
                else
                {
                    if (NoCaIzm1 > 3 && NoCaIzm1 <= 7)
                    {
                        Table2PrintViewer2(sender, e);
                    }
                    else
                    {
                        Table2PrintViewer3(sender, e);
                    }
                }

                if (cordY > e.MarginBounds.Height)
                {
                    e.Graphics.DrawString("Страница " + (prinPage + 1) + " из 2", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 300, 1100);
                    e.HasMorePages = true;
                    //   strcountScan++;
                    prinPage++;
                    cordY = 50;
                    return;
                }
                else
                {
                    if (prinPage <= 0 && NoCaIzm1 > 3 && Table2.Rows.Count > 10)
                    {
                        e.Graphics.DrawString("Страница " + (prinPage + 1) + " из 2", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 300, 1100);
                        e.HasMorePages = true;
                        //   strcountScan++;
                        prinPage++;
                        cordY = 50;
                        return;
                    }
                    else {
                        if (prinPage <= 0 && NoCaIzm1 <= 3 && Table2.Rows.Count > 11)
                        {
                            e.Graphics.DrawString("Страница " + (prinPage + 1) + " из 2", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 300, 1100);
                            e.HasMorePages = true;
                            //   strcountScan++;
                            prinPage++;
                            cordY = 50;
                            return;
                        }
                        else {
                            if (prinPage <= 0)
                            {
                                e.Graphics.DrawString("Дата:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, cordY + 30);
                                e.Graphics.DrawString(dateTimePicker2.Value.ToString("dd.MM.yyyy"), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 85, cordY + 30);

                                e.Graphics.DrawString("Время начала:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 180, cordY + 30);
                                e.Graphics.DrawString(" _______ ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 290, cordY + 30);

                                e.Graphics.DrawString("Время окончания:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 380, cordY + 30);
                                e.Graphics.DrawString(" _______ ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 530, cordY + 30);

                                e.Graphics.DrawString("Измерения выполнил(а):", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, cordY + 60);
                                e.Graphics.DrawString(" _______________________ /   ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 250, cordY + 60);

                                e.Graphics.DrawString("Руководитель:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, cordY + 90);
                                e.Graphics.DrawString(" _______________________ /   " + direction, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 160, cordY + 90);
                                prinPage = 0;
                                strcountScan = 0;
                            }
                        }
                    }
                }




            }
            else
            {
                e.Graphics.DrawString("Идентификационный номер (код) исследования:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 50);
                e.Graphics.DrawString(code, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 400, 50);
                if (NoCaIzm1 > 7 && Table2.Rows.Count > 10)
                {

                    Table2PageAdd2(sender, e);
                }
                else {
                    if (NoCaIzm1 > 3 && NoCaIzm1 <= 7 && Table2.Rows.Count > 10)
                    {
                        Table2PageAdd1(sender, e);
                    }
                }

                e.Graphics.DrawString("Дата:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, cordY + 35);
                e.Graphics.DrawString(dateTimePicker2.Value.ToString("dd.MM.yyyy"), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 85, cordY + 35);

                e.Graphics.DrawString("Время начала:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 180, cordY + 35);
                e.Graphics.DrawString(" _______ ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 290, cordY + 35);

                e.Graphics.DrawString("Время окончания:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 380, cordY + 35);
                e.Graphics.DrawString(" _______ ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 530, cordY + 35);

                e.Graphics.DrawString("Измерения выполнил(а):", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, cordY + 65);
                e.Graphics.DrawString(" _______________________ /   ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 250, cordY + 65);

                e.Graphics.DrawString("Руководитель:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, cordY + 95);
                e.Graphics.DrawString(" _______________________ /   " + direction, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 160, cordY + 95);
                e.Graphics.DrawString("Страница " + (prinPage + 1) + " из 2", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 300, 1100);
                prinPage = 0;
                strcountScan = 0;
            }
        }

        private void IzmerenieFRprintTable1_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Протокол выполнения измерений\n       в Фотометрическом режиме\n\n", new System.Drawing.Font("Times New Roman", 20, FontStyle.Bold), Brushes.Black, 180, 50);

            e.Graphics.DrawString("Идентификационный номер (код) исследования:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 115);
            e.Graphics.DrawString(code, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 400, 115);

            e.Graphics.DrawString("Лаборатория:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 135);
            e.Graphics.DrawString(name_lab, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 140, 135);

            e.Graphics.DrawString("Адрес лаборатории:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 155);
            e.Graphics.DrawString(address_lab, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 195, 155);

            e.Graphics.DrawString("Примечание:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 175);
            e.Graphics.DrawString(Description, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 155, 175);
            e.Graphics.DrawString("Информация о приборе:\n", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(25, 195));
            var applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);

            string model = path + @"pribor/model";
            DecriptorPribor decriptorModel = new DecriptorPribor(ref model, pathTemp);
            applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            // model = model.Substring(model.LastIndexOf(@"/") + 1);
            var filePathToOpen = Path.Combine(applicationDirectory, pathTemp + model);




            StreamReader fs = new StreamReader(filePathToOpen);
            e.Graphics.DrawString("Модель: ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(200, 215));
            e.Graphics.DrawString(fs.ReadLine(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(310, 215));
            fs.Close();


            string SerNomer_Text = path + @"pribor/SerNomer";
            DecriptorPribor decriptorSerNomer = new DecriptorPribor(ref SerNomer_Text, pathTemp);
            applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            //    SerNomer_Text = Convert.ToString((SerNomer_Text.LastIndexOf(@"\") + 1));
            filePathToOpen = Path.Combine(applicationDirectory, pathTemp + SerNomer_Text);

            StreamReader fs1 = new StreamReader(filePathToOpen);
            e.Graphics.DrawString("Серийный номер: ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(530, 235));
            e.Graphics.DrawString(fs1.ReadLine(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(700, 235));
            fs1.Close();


            string InventarNomer_Text = path + @"pribor/InventarNomer";
            DecriptorPribor decriptorInventarNomer = new DecriptorPribor(ref InventarNomer_Text, pathTemp);
            applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            //  InventarNomer_Text = Convert.ToString((InventarNomer_Text.LastIndexOf(@"\") + 1));
            filePathToOpen = Path.Combine(applicationDirectory, pathTemp + InventarNomer_Text);

            StreamReader fs2 = new StreamReader(filePathToOpen);
            e.Graphics.DrawString("Инвентарный номер: ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(500, 215));
            e.Graphics.DrawString(fs2.ReadLine(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(705, 215));
            fs2.Close();

            string Poveren_Text = path + @"pribor/Poveren";
            DecriptorPribor decriptorPoveren = new DecriptorPribor(ref Poveren_Text, pathTemp);
            applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);
            //   Poveren_Text = Convert.ToString((Poveren_Text.LastIndexOf(@"\") + 1));
            filePathToOpen = Path.Combine(applicationDirectory, pathTemp + Poveren_Text);

            StreamReader fs3 = new StreamReader(filePathToOpen);
            DateTime data = Convert.ToDateTime(fs3.ReadLine());
            // data.Date.ToString("d.mm.yyyy"); 
            //  MessageBox.Show(Convert.ToString(data));   
            data = data.AddYears(1);
            fs3.Close();
            e.Graphics.DrawString("Поверка действительна до: ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(60, 235));
            e.Graphics.DrawString(data.Date.ToString("dd.MM.yyyy"), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(315, 235));

            e.Graphics.DrawString("Имя файла:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(25, 255));
            e.Graphics.DrawString(filepath, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(130, 255));

            e.Graphics.DrawString("Таблица результатов измерений", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, 275);
            IzmerenieFRPrintViewer1(sender, e);

            e.Graphics.DrawString("Дата:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, cordY);
            e.Graphics.DrawString(DateTime, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 80, cordY);


            e.Graphics.DrawString("Время начала:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 180, cordY);
            e.Graphics.DrawString(" _______ ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 290, cordY);

            e.Graphics.DrawString("Время окончания:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 380, cordY);
            e.Graphics.DrawString(" _______ ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 530, cordY);

            e.Graphics.DrawString("Исполнитель:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, cordY + 30);
            e.Graphics.DrawString(" _______________________ /   " + Ispolnitel, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 160, cordY + 30);
            e.Graphics.DrawString("Руководитель:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, cordY + 60);
            e.Graphics.DrawString(" _______________________ /   " + direction, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 160, cordY + 60);
            /* stringToPrint = stringToPrint.Substring(charactersOnPage);

             // Check to see if more pages are to be printed.
             e.HasMorePages = (stringToPrint.Length > 0);*/
            e.HasMorePages = false;
        }

        private void IzmerenieFRprintPreviewTable1_Load(object sender, EventArgs e)
        {

        }

        private void printPreviewTable2_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaveAll saveall = new SaveAll(this);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (selet_rezim == 2)
            {
                if (tabControl2.SelectedIndex == 0)
                {
                    ModificateGrad modificateGrad = new ModificateGrad(this);
                    modificateGrad.ShowDialog();
                }
                else
                {
                    ModificateIzmer modifcateizmer = new ModificateIzmer(this);
                    modifcateizmer.ShowDialog();
                }
            }
        }
        public void SWСhange()
        {
            LogoForm2 logoform = new LogoForm2();
            string SWText1 = wavelength1;
            double Walve_double = Convert.ToDouble(wavelength1.Replace(".", ","));
            newPort.Write("SW " + Walve_double.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")) + "\r");
            string indata = newPort.ReadExisting();

            bool indata_bool = true;
            while (indata_bool == true)
            {
                if (indata.Contains(">"))
                {

                    indata_bool = false;

                }

                else
                {
                    indata = newPort.ReadExisting();
                }
            }


            Application.OpenForms["LogoForm2"].Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            OpenAll openall = new OpenAll(this);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ExportExcelAll exportExcelAll = new ExportExcelAll(this);
        }

        public void KinPrintCancel(object sender, PrintPageEventArgs e)
        {
            realheight += 20;
            e.Graphics.DrawString("Описание:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new Point(25, realheight));
            e.Graphics.DrawString(Description, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new Point(130, realheight));

            e.Graphics.DrawString("Дата:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, realheight + 20);
            e.Graphics.DrawString(DateTime, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 85, realheight + 20);
            e.Graphics.DrawString("Время начала:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 180, realheight + 20);
            e.Graphics.DrawString(" _______ ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 290, realheight + 20);

            e.Graphics.DrawString("Время окончания:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 380, realheight + 20);
            e.Graphics.DrawString(" _______ ", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 530, realheight + 20);

            e.Graphics.DrawString("Исполнитель:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, realheight + 50);
            e.Graphics.DrawString(" _______________________ /   " + Ispolnitel, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 160, realheight + 50);
            e.Graphics.DrawString("Руководитель:", new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, 25, realheight + 80);
            e.Graphics.DrawString(" _______________________ /   " + direction, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 160, realheight + 80);
            if (prinPage > 0)
            {
                e.Graphics.DrawString("Страница " + (prinPage + 1), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 300, 1100);
            }
            prinPage = 0;
            strcountScan = 0;
        }

        bool pageyes2_4 = false; // третья часть готова  ( dataGridView5.ColumnCount == 22)
        //bool pageyes2_4 = false; // третья часть готова ( dataGridView5.ColumnCount > 22)
        int p = 1;
        public void printdatagridview5_1(object sender, PrintPageEventArgs e)
        {
            if (prinPage < 1)
            {
                int k = 7;
                for (int z = 0; z < k; z++)
                {
                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                    e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                    realwidth = realwidth + width;
                }
                realwidth = dataGridView5.Columns[0].Width + 5;
                realheight = realheight + 20;
                while (strcountScan < dataGridView5.Rows.Count - 1)
                {
                    for (int j = 0; j < k; j++)
                    {
                        e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                        e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                        realwidth = realwidth + width;

                    }
                    realwidth = dataGridView5.Columns[0].Width + 5;
                    realheight = realheight + 20;

                    if (realheight > e.MarginBounds.Height)
                    {
                        height = 100;
                        e.HasMorePages = true;
                        //   strcountScan++;
                        prinPage++;
                        pageyes = true;
                        strcountScan++;
                        e.Graphics.DrawString("Страница " + prinPage, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 300, 1100);
                        return;
                    }
                    else
                    {
                        e.HasMorePages = false;

                    }
                    strcountScan++;
                }
                if (dataGridView5.Rows.Count < 20)
                {
                    if (dataGridView5.ColumnCount - k <= 5)
                    {
                        strcountScan = 0;
                        pageyes2_1 = true;
                        pageyes = true;
                        realwidth = dataGridView5.Columns[0].Width + 5;
                        realheight = realheight + 35;
                        width = 100;
                        height1 = dataGridView5.Rows[0].Height + 5;
                        for (int z = 0; z < 2; z++)
                        {
                            e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                            e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                            e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                            realwidth = realwidth + width;
                        }
                        //realwidth = dataGridView5.Columns[0].Width + 5;
                        // realheight = realheight + 20;
                        for (int z = k; z < dataGridView5.ColumnCount; z++)
                        {
                            e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                            e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                            e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                            realwidth = realwidth + width;
                        }
                        realwidth = dataGridView5.Columns[0].Width + 5;
                        realheight = realheight + 20;
                        while (strcountScan < dataGridView5.Rows.Count - 1)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                                realwidth = realwidth + width;

                            }
                            //    realwidth = dataGridView5.Columns[0].Width + 5;
                            // realheight = realheight + 20;
                            for (int j = k; j < dataGridView5.ColumnCount; j++)
                            {
                                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                                realwidth = realwidth + width;

                            }
                            realwidth = dataGridView5.Columns[0].Width + 5;
                            realheight = realheight + 20;
                            strcountScan++;
                        }
                    }

                    else
                    {
                        if (dataGridView5.Rows.Count < 14 && dataGridView5.ColumnCount <= 17)
                        {
                            strcountScan = 0;
                            pageyes2_1 = true;
                            pageyes = true;
                            realwidth = dataGridView5.Columns[0].Width + 5;
                            realheight = realheight + 35;
                            width = 100;
                            height1 = dataGridView5.Rows[0].Height + 5;

                            for (int z = 0; z < 2; z++)
                            {
                                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                                realwidth = realwidth + width;
                            }
                            //realwidth = dataGridView5.Columns[0].Width + 5;
                            // realheight = realheight + 20;
                            for (int z = k; z < 12; z++)
                            {
                                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                                realwidth = realwidth + width;
                            }
                            realwidth = dataGridView5.Columns[0].Width + 5;
                            realheight = realheight + 20;
                            while (strcountScan < dataGridView5.Rows.Count - 1)
                            {
                                for (int j = 0; j < 2; j++)
                                {
                                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                    e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                                    realwidth = realwidth + width;

                                }
                                //    realwidth = dataGridView5.Columns[0].Width + 5;
                                // realheight = realheight + 20;
                                for (int j = k; j < 12; j++)
                                {
                                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                    e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                                    realwidth = realwidth + width;

                                }
                                realwidth = dataGridView5.Columns[0].Width + 5;
                                realheight = realheight + 20;
                                strcountScan++;
                            }

                            strcountScan = 0;
                            pageyes2_1 = true;
                            pageyes = true;
                            realwidth = dataGridView5.Columns[0].Width + 5;
                            realheight = realheight + 35;
                            width = 100;
                            height1 = dataGridView5.Rows[0].Height + 5;

                            for (int z = 0; z < 2; z++)
                            {
                                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                                realwidth = realwidth + width;
                            }
                            //realwidth = dataGridView5.Columns[0].Width + 5;
                            // realheight = realheight + 20;
                            for (int z = 12; z < dataGridView5.ColumnCount; z++)
                            {
                                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                                realwidth = realwidth + width;
                            }
                            realwidth = dataGridView5.Columns[0].Width + 5;
                            realheight = realheight + 20;
                            while (strcountScan < dataGridView5.Rows.Count - 1)
                            {
                                for (int j = 0; j < 2; j++)
                                {
                                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                    e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                                    realwidth = realwidth + width;

                                }
                                //    realwidth = dataGridView5.Columns[0].Width + 5;
                                // realheight = realheight + 20;
                                for (int j = 12; j < dataGridView5.ColumnCount; j++)
                                {
                                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                    e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                                    realwidth = realwidth + width;

                                }
                                realwidth = dataGridView5.Columns[0].Width + 5;
                                realheight = realheight + 20;
                                strcountScan++;
                            }
                        }
                        else
                        {
                            if (dataGridView5.Rows.Count < 10 && dataGridView5.ColumnCount > 17)
                            {
                                strcountScan = 0;
                                pageyes2_1 = true;
                                pageyes = true;
                                realwidth = dataGridView5.Columns[0].Width + 5;
                                realheight = realheight + 35;
                                width = 100;
                                height1 = dataGridView5.Rows[0].Height + 5;

                                for (int z = 0; z < 2; z++)
                                {
                                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                    e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                                    realwidth = realwidth + width;
                                }
                                //realwidth = dataGridView5.Columns[0].Width + 5;
                                // realheight = realheight + 20;
                                for (int z = k; z < 12; z++)
                                {
                                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                    e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                                    realwidth = realwidth + width;
                                }
                                realwidth = dataGridView5.Columns[0].Width + 5;
                                realheight = realheight + 20;
                                while (strcountScan < dataGridView5.Rows.Count - 1)
                                {
                                    for (int j = 0; j < 2; j++)
                                    {
                                        e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                        e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                                        realwidth = realwidth + width;

                                    }
                                    //    realwidth = dataGridView5.Columns[0].Width + 5;
                                    // realheight = realheight + 20;
                                    for (int j = k; j < 12; j++)
                                    {
                                        e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                        e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                                        realwidth = realwidth + width;

                                    }
                                    realwidth = dataGridView5.Columns[0].Width + 5;
                                    realheight = realheight + 20;
                                    strcountScan++;
                                }

                                strcountScan = 0;
                                pageyes2_1 = true;
                                pageyes = true;
                                realwidth = dataGridView5.Columns[0].Width + 5;
                                realheight = realheight + 35;
                                width = 100;
                                height1 = dataGridView5.Rows[0].Height + 5;

                                for (int z = 0; z < 2; z++)
                                {
                                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                    e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                                    realwidth = realwidth + width;
                                }
                                //realwidth = dataGridView5.Columns[0].Width + 5;
                                // realheight = realheight + 20;
                                for (int z = 12; z < 17; z++)
                                {
                                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                    e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                                    realwidth = realwidth + width;
                                }
                                realwidth = dataGridView5.Columns[0].Width + 5;
                                realheight = realheight + 20;
                                while (strcountScan < dataGridView5.Rows.Count - 1)
                                {
                                    for (int j = 0; j < 2; j++)
                                    {
                                        e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                        e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                                        realwidth = realwidth + width;

                                    }
                                    //    realwidth = dataGridView5.Columns[0].Width + 5;
                                    // realheight = realheight + 20;
                                    for (int j = 12; j < 17; j++)
                                    {
                                        e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                        e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                                        realwidth = realwidth + width;

                                    }
                                    realwidth = dataGridView5.Columns[0].Width + 5;
                                    realheight = realheight + 20;
                                    strcountScan++;
                                }

                                strcountScan = 0;
                                pageyes2_1 = true;
                                pageyes = true;
                                realwidth = dataGridView5.Columns[0].Width + 5;
                                realheight = realheight + 35;
                                width = 100;
                                height1 = dataGridView5.Rows[0].Height + 5;

                                for (int z = 0; z < 2; z++)
                                {
                                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                    e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                                    realwidth = realwidth + width;
                                }
                                //realwidth = dataGridView5.Columns[0].Width + 5;
                                // realheight = realheight + 20;
                                for (int z = 17; z < dataGridView5.ColumnCount; z++)
                                {
                                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                    e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                                    realwidth = realwidth + width;
                                }
                                realwidth = dataGridView5.Columns[0].Width + 5;
                                realheight = realheight + 20;
                                while (strcountScan < dataGridView5.Rows.Count - 1)
                                {
                                    for (int j = 0; j < 2; j++)
                                    {
                                        e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                        e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                                        realwidth = realwidth + width;

                                    }
                                    //    realwidth = dataGridView5.Columns[0].Width + 5;
                                    // realheight = realheight + 20;
                                    for (int j = 17; j < dataGridView5.ColumnCount; j++)
                                    {
                                        e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                        e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                                        realwidth = realwidth + width;

                                    }
                                    realwidth = dataGridView5.Columns[0].Width + 5;
                                    realheight = realheight + 20;
                                    strcountScan++;
                                }
                            }
                            else
                            {
                                e.HasMorePages = true;
                                prinPage++;
                                e.Graphics.DrawString("Страница " + prinPage, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 300, 1100);
                                // pageyes_1 = true;
                                //strcountScan++;
                                return;
                            }

                        }
                    }
                }
                else
                {
                    e.HasMorePages = true;
                    prinPage++;
                    e.Graphics.DrawString("Страница " + prinPage, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 300, 1100);
                    //pageyes_1 = true;
                    //strcountScan++;
                    return;

                }
                PrintMultiCancel(sender, e);
            }
        }
        public void PrintDatagridview5PageAdd(object sender, PrintPageEventArgs e)
        {
            int k = 7;
            if (dataGridView5.ColumnCount - k <= 5)
            {
                strcountScan = 0;
                pageyes2_1 = true;
                pageyes = true;
                realwidth = dataGridView5.Columns[0].Width + 5;
                realheight = realheight + 35;
                width = 100;
                height1 = dataGridView5.Rows[0].Height + 5;
                for (int z = 0; z < 2; z++)
                {
                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                    e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                    realwidth = realwidth + width;
                }
                //realwidth = dataGridView5.Columns[0].Width + 5;
                // realheight = realheight + 20;
                for (int z = k; z < dataGridView5.ColumnCount; z++)
                {
                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                    e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                    realwidth = realwidth + width;
                }
                realwidth = dataGridView5.Columns[0].Width + 5;
                realheight = realheight + 20;
                while (strcountScan < dataGridView5.Rows.Count - 1)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                        e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                        realwidth = realwidth + width;

                    }
                    //    realwidth = dataGridView5.Columns[0].Width + 5;
                    // realheight = realheight + 20;
                    for (int j = k; j < dataGridView5.ColumnCount; j++)
                    {
                        e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                        e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                        realwidth = realwidth + width;

                    }
                    realwidth = dataGridView5.Columns[0].Width + 5;
                    realheight = realheight + 20;
                    strcountScan++;
                }
            }

            else
            {
                if (dataGridView5.ColumnCount <= 17 && dataGridView5.Rows.Count <= 22)
                {
                    strcountScan = 0;
                    pageyes2_1 = true;
                    pageyes = true;
                    realwidth = dataGridView5.Columns[0].Width + 5;
                    realheight = realheight + 35;
                    width = 100;
                    height1 = dataGridView5.Rows[0].Height + 5;

                    for (int z = 0; z < 2; z++)
                    {
                        e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                        e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                        realwidth = realwidth + width;
                    }
                    //realwidth = dataGridView5.Columns[0].Width + 5;
                    // realheight = realheight + 20;
                    for (int z = k; z < 12; z++)
                    {
                        e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                        e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                        realwidth = realwidth + width;
                    }
                    realwidth = dataGridView5.Columns[0].Width + 5;
                    realheight = realheight + 20;
                    while (strcountScan < dataGridView5.Rows.Count - 1)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                            e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                            e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                            realwidth = realwidth + width;

                        }
                        //    realwidth = dataGridView5.Columns[0].Width + 5;
                        // realheight = realheight + 20;
                        for (int j = k; j < 12; j++)
                        {
                            e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                            e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                            e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                            realwidth = realwidth + width;

                        }
                        realwidth = dataGridView5.Columns[0].Width + 5;
                        realheight = realheight + 20;
                        strcountScan++;
                    }

                    strcountScan = 0;
                    pageyes2_1 = true;
                    pageyes = true;
                    realwidth = dataGridView5.Columns[0].Width + 5;
                    realheight = realheight + 35;
                    width = 100;
                    height1 = dataGridView5.Rows[0].Height + 5;

                    for (int z = 0; z < 2; z++)
                    {
                        e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                        e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                        realwidth = realwidth + width;
                    }
                    //realwidth = dataGridView5.Columns[0].Width + 5;
                    // realheight = realheight + 20;
                    for (int z = 12; z < dataGridView5.ColumnCount; z++)
                    {
                        e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                        e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                        realwidth = realwidth + width;
                    }
                    realwidth = dataGridView5.Columns[0].Width + 5;
                    realheight = realheight + 20;
                    while (strcountScan < dataGridView5.Rows.Count - 1)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                            e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                            e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                            realwidth = realwidth + width;

                        }
                        //    realwidth = dataGridView5.Columns[0].Width + 5;
                        // realheight = realheight + 20;
                        for (int j = 12; j < dataGridView5.ColumnCount; j++)
                        {
                            e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                            e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                            e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                            realwidth = realwidth + width;

                        }
                        realwidth = dataGridView5.Columns[0].Width + 5;
                        realheight = realheight + 20;
                        strcountScan++;
                    }
                }
                else
                {


                    if (dataGridView5.ColumnCount <= 17 && dataGridView5.Rows.Count > 22)
                    {
                        strcountScan = 0;
                        pageyes2_1 = true;
                        pageyes = true;
                        realwidth = dataGridView5.Columns[0].Width + 5;
                        realheight = realheight + 35;
                        width = 100;
                        height1 = dataGridView5.Rows[0].Height + 5;

                        for (int z = 0; z < 2; z++)
                        {
                            e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                            e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                            e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                            realwidth = realwidth + width;
                        }
                        //realwidth = dataGridView5.Columns[0].Width + 5;
                        // realheight = realheight + 20;
                        for (int z = k; z < 12; z++)
                        {
                            e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                            e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                            e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                            realwidth = realwidth + width;
                        }
                        realwidth = dataGridView5.Columns[0].Width + 5;
                        realheight = realheight + 20;
                        while (strcountScan < dataGridView5.Rows.Count - 1)
                        {
                            for (int j = 0; j < 2; j++)
                            {
                                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                                realwidth = realwidth + width;

                            }
                            //    realwidth = dataGridView5.Columns[0].Width + 5;
                            // realheight = realheight + 20;
                            for (int j = k; j < 12; j++)
                            {
                                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                                realwidth = realwidth + width;

                            }
                            realwidth = dataGridView5.Columns[0].Width + 5;
                            realheight = realheight + 20;
                            strcountScan++;
                        }

                        e.HasMorePages = true;
                        prinPage++;
                        e.Graphics.DrawString("Страница " + prinPage, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 300, 1100);
                        pageyes_1 = true;
                        //strcountScan++;
                        return;
                    }
                    else {

                        if (dataGridView5.ColumnCount > 17 && dataGridView5.Rows.Count < 18)
                        {
                            strcountScan = 0;
                            pageyes2_1 = true;
                            pageyes = true;
                            realwidth = dataGridView5.Columns[0].Width + 5;
                            realheight = realheight + 35;
                            width = 100;
                            height1 = dataGridView5.Rows[0].Height + 5;

                            for (int z = 0; z < 2; z++)
                            {
                                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                                realwidth = realwidth + width;
                            }
                            //realwidth = dataGridView5.Columns[0].Width + 5;
                            // realheight = realheight + 20;
                            for (int z = k; z < 12; z++)
                            {
                                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                                realwidth = realwidth + width;
                            }
                            realwidth = dataGridView5.Columns[0].Width + 5;
                            realheight = realheight + 20;
                            while (strcountScan < dataGridView5.Rows.Count - 1)
                            {
                                for (int j = 0; j < 2; j++)
                                {
                                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                    e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                                    realwidth = realwidth + width;

                                }
                                //    realwidth = dataGridView5.Columns[0].Width + 5;
                                // realheight = realheight + 20;
                                for (int j = k; j < 12; j++)
                                {
                                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                    e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                                    realwidth = realwidth + width;

                                }
                                realwidth = dataGridView5.Columns[0].Width + 5;
                                realheight = realheight + 20;
                                strcountScan++;
                            }

                            strcountScan = 0;
                            pageyes2_1 = true;
                            pageyes = true;
                            realwidth = dataGridView5.Columns[0].Width + 5;
                            realheight = realheight + 35;
                            width = 100;
                            height1 = dataGridView5.Rows[0].Height + 5;

                            for (int z = 0; z < 2; z++)
                            {
                                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                                realwidth = realwidth + width;
                            }
                            //realwidth = dataGridView5.Columns[0].Width + 5;
                            // realheight = realheight + 20;
                            for (int z = 12; z < 17; z++)
                            {
                                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                                realwidth = realwidth + width;
                            }
                            realwidth = dataGridView5.Columns[0].Width + 5;
                            realheight = realheight + 20;
                            while (strcountScan < dataGridView5.Rows.Count - 1)
                            {
                                for (int j = 0; j < 2; j++)
                                {
                                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                    e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                                    realwidth = realwidth + width;

                                }
                                //    realwidth = dataGridView5.Columns[0].Width + 5;
                                // realheight = realheight + 20;
                                for (int j = 12; j < 17; j++)
                                {
                                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                    e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                                    realwidth = realwidth + width;

                                }
                                realwidth = dataGridView5.Columns[0].Width + 5;
                                realheight = realheight + 20;
                                strcountScan++;
                            }


                        }
                        else
                        {

                            strcountScan = 0;
                            pageyes2_1 = true;
                            pageyes = true;
                            realwidth = dataGridView5.Columns[0].Width + 5;
                            realheight = realheight + 35;
                            width = 100;
                            height1 = dataGridView5.Rows[0].Height + 5;

                            for (int z = 0; z < 2; z++)
                            {
                                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                                realwidth = realwidth + width;
                            }
                            //realwidth = dataGridView5.Columns[0].Width + 5;
                            // realheight = realheight + 20;
                            for (int z = k; z < 12; z++)
                            {
                                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                                realwidth = realwidth + width;
                            }
                            realwidth = dataGridView5.Columns[0].Width + 5;
                            realheight = realheight + 20;
                            while (strcountScan < dataGridView5.Rows.Count - 1)
                            {
                                for (int j = 0; j < 2; j++)
                                {
                                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                    e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                                    realwidth = realwidth + width;

                                }
                                //    realwidth = dataGridView5.Columns[0].Width + 5;
                                // realheight = realheight + 20;
                                for (int j = k; j < 12; j++)
                                {
                                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                    e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                                    realwidth = realwidth + width;

                                }
                                realwidth = dataGridView5.Columns[0].Width + 5;
                                realheight = realheight + 20;
                                strcountScan++;
                            }
                            if (dataGridView5.Rows.Count < 22)
                            {
                                strcountScan = 0;
                                pageyes2_1 = true;
                                pageyes = true;
                                realwidth = dataGridView5.Columns[0].Width + 5;
                                realheight = realheight + 35;
                                width = 100;
                                height1 = dataGridView5.Rows[0].Height + 5;

                                for (int z = 0; z < 2; z++)
                                {
                                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                    e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                                    realwidth = realwidth + width;
                                }
                                //realwidth = dataGridView5.Columns[0].Width + 5;
                                // realheight = realheight + 20;
                                for (int z = 12; z < 17; z++)
                                {
                                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                    e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                                    realwidth = realwidth + width;
                                }
                                realwidth = dataGridView5.Columns[0].Width + 5;
                                realheight = realheight + 20;
                                while (strcountScan < dataGridView5.Rows.Count - 1)
                                {
                                    for (int j = 0; j < 2; j++)
                                    {
                                        e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                        e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                                        realwidth = realwidth + width;

                                    }
                                    //    realwidth = dataGridView5.Columns[0].Width + 5;
                                    // realheight = realheight + 20;
                                    for (int j = 12; j < 17; j++)
                                    {
                                        e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                                        e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                                        e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                                        realwidth = realwidth + width;

                                    }
                                    realwidth = dataGridView5.Columns[0].Width + 5;
                                    realheight = realheight + 20;
                                    strcountScan++;
                                }
                            }
                            else
                            {
                                e.HasMorePages = true;
                                prinPage++;
                                e.Graphics.DrawString("Страница " + prinPage, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 300, 1100);
                                // pageyes_1 = true;
                                //strcountScan++;
                                return;
                            }

                        }
                    }
                }
            }
            //PrintMultiCancel(sender, e);
        }

        private void Add_Table2_Click(object sender, EventArgs e)
        {
            if (Table2.RowCount != 0)
            {
                if (USE_KO == true && Table2.Rows.Count <= 21)
                {
                    Table2.Rows.Add();
                    Table2.Rows[Table2.RowCount - 2].ReadOnly = false;

                    Table2.Rows[Table2.RowCount - 2].Cells[0].Value = Table2.RowCount - 2;

                }
                else
                {
                    if (USE_KO != true && Table2.Rows.Count <= 20)
                    {
                        Table2.Rows.Add();
                        Table2.Rows[Table2.RowCount - 2].ReadOnly = false;
                        Table2.Rows[Table2.RowCount - 2].Cells[0].Value = Table2.RowCount - 1;
                    }
                    else
                    {
                        MessageBox.Show("Количество образцов от 1 до 20!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Измерение еще не создано! Создайте Измерение.");
            }
        }

        private void Remove_Table2_Click(object sender, EventArgs e)
        {
            if (Table2.RowCount != 0)
            {

                if (USE_KO == false)
                {
                    if (Table2.Rows.Count > 2)
                    {
                        Table2.Rows.RemoveAt(Table2.CurrentCell.RowIndex);
                        for (int i = 0; i < Table2.RowCount - 1; i++)
                        {
                            Table2.Rows[i].Cells[0].Value = i + 1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Количество образцов не может быть меньше 1 !");
                    }
                }
                else
                {
                    if (Table2.Rows.Count > 3)
                    {
                        if (Table2.CurrentCell.RowIndex != 0)
                        {
                            Table2.Rows.RemoveAt(Table2.CurrentCell.RowIndex);
                            for (int i = 0; i < Table2.RowCount - 1; i++)
                            {
                                Table2.Rows[i].Cells[0].Value = i;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Удалять Контрольный опыт запрещено!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Количество образцов не может быть меньше 1 !");
                    }
                }
            }
            else
            {
                MessageBox.Show("Таблица не содержит строк!");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ExportPDFDocALL ExportPDFDoc = new ExportPDFDocALL(this);
        }

        private void подключитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Conection conection = new Conection(this);
            button13.Enabled = true;
        }

        private void измеритьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Izmerenie izmeren = new Izmerenie(this);
        }

        private void калибровкаДляОдноволновогоАнализаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calibrovka calibrovka = new Calibrovka(this);
        }

        private void новыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateDimension createDemension = new CreateDimension(this);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenAll openall = new OpenAll(this);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAll saveall = new SaveAll(this);
        }

        private void экспортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportExcelAll exportExcelAll = new ExportExcelAll(this);
        }

        private void эксопртВPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportPDFDocALL ExportPDFDoc = new ExportPDFDocALL(this);
        }

        private void печатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Print print = new Print(this);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ComPort == true)
            {

                char[] ClosePribor = { Convert.ToChar('Q'), Convert.ToChar('U'), Convert.ToChar('\r') };
                try
                {
                    newPort.Write("QU\r");
                    Thread.Sleep(500);
                    //  byte[] buffer1 = new byte[byteRecieved1];
                    string indata = newPort.ReadExisting();

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

                    newPort.Close();
                    wavelength1 = Convert.ToString(0);
                }
                catch
                {
                    SWF.Application.Exit();
                }
            }
            else
            {
                SWF.Application.Exit();
                ///  this.Hide();

                /* Select _Select = new Select(this);                
                 _Select.Owner = this;
                 _Select.ShowDialog();*/
                //System.Environment.Exit(0);
                //   Dispose();
                //   Close();

            }
        }

        private void Ecoview_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ComPort == true)
            {

                char[] ClosePribor = { Convert.ToChar('Q'), Convert.ToChar('U'), Convert.ToChar('\r') };
                try
                {
                    newPort.Write("QU\r");
                    Thread.Sleep(500);
                    //  byte[] buffer1 = new byte[byteRecieved1];
                    string indata = newPort.ReadExisting();

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

                    newPort.Close();
                    wavelength1 = Convert.ToString(0);
                }
                catch
                {
                    SWF.Application.Exit();
                }
            }
            else
            {
                SWF.Application.Exit();
                ///  this.Hide();

                /* Select _Select = new Select(this);                
                 _Select.Owner = this;
                 _Select.ShowDialog();*/
                //System.Environment.Exit(0);
                //   Dispose();
                //   Close();

            }
        }

        public void PrintDatagridview5PageAdd2(object sender, PrintPageEventArgs e)
        {
            strcountScan = 0;
            pageyes2_1 = true;
            pageyes = true;
            realwidth = dataGridView5.Columns[0].Width + 5;
            realheight = realheight + 35;
            width = 100;
            height1 = dataGridView5.Rows[0].Height + 5;

            for (int z = 0; z < 2; z++)
            {
                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                realwidth = realwidth + width;
            }
            //realwidth = dataGridView5.Columns[0].Width + 5;
            // realheight = realheight + 20;
            for (int z = 12; z < dataGridView5.ColumnCount; z++)
            {
                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                realwidth = realwidth + width;
            }
            realwidth = dataGridView5.Columns[0].Width + 5;
            realheight = realheight + 20;
            while (strcountScan < dataGridView5.Rows.Count - 1)
            {
                for (int j = 0; j < 2; j++)
                {
                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                    e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                    realwidth = realwidth + width;

                }
                //    realwidth = dataGridView5.Columns[0].Width + 5;
                // realheight = realheight + 20;
                for (int j = 12; j < dataGridView5.ColumnCount; j++)
                {
                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                    e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                    realwidth = realwidth + width;

                }
                realwidth = dataGridView5.Columns[0].Width + 5;
                realheight = realheight + 20;
                strcountScan++;
            }
            PrintMultiCancel(sender, e);
        }

        public void PrintDatagridview5PageAdd3(object sender, PrintPageEventArgs e)
        {
            strcountScan = 0;
            pageyes2_1 = true;
            pageyes = true;
            realwidth = dataGridView5.Columns[0].Width + 5;
            realheight = realheight + 35;
            width = 100;
            height1 = dataGridView5.Rows[0].Height + 5;

            for (int z = 0; z < 2; z++)
            {
                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                realwidth = realwidth + width;
            }
            //realwidth = dataGridView5.Columns[0].Width + 5;
            // realheight = realheight + 20;
            for (int z = 17; z < dataGridView5.ColumnCount; z++)
            {
                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                realwidth = realwidth + width;
            }
            realwidth = dataGridView5.Columns[0].Width + 5;
            realheight = realheight + 20;
            while (strcountScan < dataGridView5.Rows.Count - 1)
            {
                for (int j = 0; j < 2; j++)
                {
                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                    e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                    realwidth = realwidth + width;

                }
                //    realwidth = dataGridView5.Columns[0].Width + 5;
                // realheight = realheight + 20;
                for (int j = 17; j < dataGridView5.ColumnCount; j++)
                {
                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                    e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                    realwidth = realwidth + width;

                }
                realwidth = dataGridView5.Columns[0].Width + 5;
                realheight = realheight + 20;
                strcountScan++;
            }
            PrintMultiCancel(sender, e);
        }
        public void PrintDatagridview5PageAdd4(object sender, PrintPageEventArgs e)
        {
            strcountScan = 0;
            pageyes2_1 = true;
            pageyes = true;
            realwidth = dataGridView5.Columns[0].Width + 5;
            realheight = realheight + 35;
            width = 100;
            height1 = dataGridView5.Rows[0].Height + 5;

            for (int z = 0; z < 2; z++)
            {
                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                realwidth = realwidth + width;
            }
            //realwidth = dataGridView5.Columns[0].Width + 5;
            // realheight = realheight + 20;
            for (int z = 12; z < 17; z++)
            {
                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                realwidth = realwidth + width;
            }
            realwidth = dataGridView5.Columns[0].Width + 5;
            realheight = realheight + 20;
            while (strcountScan < dataGridView5.Rows.Count - 1)
            {
                for (int j = 0; j < 2; j++)
                {
                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                    e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                    realwidth = realwidth + width;

                }
                //    realwidth = dataGridView5.Columns[0].Width + 5;
                // realheight = realheight + 20;
                for (int j = 12; j < 17; j++)
                {
                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                    e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                    realwidth = realwidth + width;

                }
                realwidth = dataGridView5.Columns[0].Width + 5;
                realheight = realheight + 20;
                strcountScan++;
            }
            e.HasMorePages = true;
            prinPage++;
            e.Graphics.DrawString("Страница " + prinPage, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 300, 1100);
            //  pageyes_1 = true;
            //strcountScan++;
            return;
        }
        public void printdatagridview5(object sender, PrintPageEventArgs e)
        {
            for (int z = 0; z < dataGridView5.Columns.Count; z++)
            {
                e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                e.Graphics.DrawString(dataGridView5.Columns[z].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, realwidth, realheight);
                realwidth = realwidth + width;
            }
            realwidth = dataGridView5.Columns[0].Width + 5;
            realheight = realheight + 20;

            while (strcountScan < dataGridView5.Rows.Count - 1)
            {
                for (int j = 0; j < dataGridView5.Columns.Count; j++)
                {
                    e.Graphics.FillRectangle(Brushes.White, realwidth, realheight, width, height1);
                    e.Graphics.DrawRectangle(Pens.Black, realwidth, realheight, width, height1);
                    e.Graphics.DrawString(dataGridView5.Rows[strcountScan].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, realwidth, realheight);
                    realwidth = realwidth + width;

                }
                realwidth = dataGridView5.Columns[0].Width + 5;
                realheight = realheight + 20;

                if (realheight > e.MarginBounds.Height + 20)
                {
                    height = 100;
                    e.HasMorePages = true;
                    //   strcountScan++;
                    prinPage++;
                    e.Graphics.DrawString("Страница " + prinPage, new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 300, 1100);
                    return;
                }
                else
                {
                    e.HasMorePages = false;

                }
                strcountScan++;
            }
            PrintMultiCancel(sender, e);
        }




        public void IzmerenieFRPrintViewer1(object sender, PrintPageEventArgs e)
        {
            int itemperpage = 0;
            int totalnumber = 0;
            int height = 305;
            int width = 25;
            Pen p = new Pen(Brushes.Black, 1.5f);
            for (int i = 0; i < IzmerenieFR_Table.ColumnCount; i++)
            {
                e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, IzmerenieFR_Table.Columns[i].Width + 5, IzmerenieFR_Table.Rows[0].Height * 2));
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, IzmerenieFR_Table.Columns[0].Width + 5, IzmerenieFR_Table.Rows[0].Height * 2));
                e.Graphics.DrawString(IzmerenieFR_Table.Columns[i].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, IzmerenieFR_Table.Columns[0].Width + 5, IzmerenieFR_Table.Rows[0].Height * 2));
                width = width + IzmerenieFR_Table.Columns[i].Width + 5;
            }
            width = width + IzmerenieFR_Table.Columns[6].Width + 5;
            height = height + IzmerenieFR_Table.Rows[0].Height * 2;
            width = 25;
            int height1 = height;
            int width1_1 = width;
            while (totalnumber < IzmerenieFR_Table.Rows.Count - 1)
            {
                for (int i = 0; i < IzmerenieFR_Table.ColumnCount; i++)
                {
                    e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, IzmerenieFR_Table.Columns[0].Width + 5, IzmerenieFR_Table.Rows[totalnumber].Height));
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, IzmerenieFR_Table.Columns[0].Width + 5, IzmerenieFR_Table.Rows[totalnumber].Height));
                    e.Graphics.DrawString(IzmerenieFR_Table.Rows[totalnumber].Cells[i].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, IzmerenieFR_Table.Columns[0].Width + 5, IzmerenieFR_Table.Rows[totalnumber].Height));
                    width = width + IzmerenieFR_Table.Columns[i].Width + 5;
                    //  height += IzmerenieFR_Table.Rows[totalnumber].Height;
                }
                height += IzmerenieFR_Table.Rows[totalnumber].Height;
                width = 25;
                totalnumber++;



            }

            // height = height1;
            //   width = width + IzmerenieFR_Table.Columns[0].Width + 5;
            cordY = height + 10;
        }
        ///Если меньше или равно 3
        public void Table1PrintViewer1(object sender, PrintPageEventArgs e)
        {
            int totalnumber = 0;
            int height = 395;
            int width = 25;
            Pen p = new Pen(Brushes.Black, 1.5f);

            for (int i = 0; i < Table1.ColumnCount; i++)
            {
                e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[i].Width + 10, Table1.Rows[0].Height * 2));
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[i].Width + 10, Table1.Rows[0].Height * 2));
                e.Graphics.DrawString(Table1.Columns[i].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 5, height, Table1.Columns[i].Width + 10, Table1.Rows[0].Height * 2));
                width = width + Table1.Columns[i].Width + 5;
            }
            height = height + Table1.Rows[0].Height * 2;
            width = 25;
            int height1 = height;
            while (totalnumber < Table1.Rows.Count - 1)
            {
                for (int j = 0; j < Table1.ColumnCount; j++)
                {
                    if (Table1.Rows[totalnumber].Cells[j].Style.BackColor.Name == "Pink")
                    {
                        e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table1.Columns[j].Width + 10, Table1.Rows[totalnumber].Height));
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[j].Width + 10, Table1.Rows[totalnumber].Height));
                    }
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[j].Width + 10, Table1.Rows[totalnumber].Height));
                    e.Graphics.DrawString(Table1.Rows[totalnumber].Cells[j].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[j].Width + 10, Table1.Rows[totalnumber].Height));
                    width = width + Table1.Columns[j].Width + 5;
                    //height += Table1.Rows[totalnumber].Height;
                }
                height += Table1.Rows[totalnumber].Height;
                width = 25;
                totalnumber++;
            }

            cordY = height;
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Table2.RowCount == 0)
            {
                k0 = Convert.ToDouble(AgroText0.Text);
                k1 = Convert.ToDouble(AgroText1.Text);
                k2 = Convert.ToDouble(AgroText2.Text);

                USE_KO_1 = USE_KO;
                button11.Enabled = false;
            }
            if (tabControl2.SelectedIndex == 1 && Table2.Rows.Count == 0)
            {
                Podskazka.Text = "Создайте или откройте Измерение!";
                label27.Visible = false;
                label24.Visible = false;
                label25.Visible = true;
                label26.Visible = true;
                label28.Visible = false;
                label33.Visible = false;
                button10.Enabled = false;
                if (Table2.RowCount > 0 && (k0 != Convert.ToDouble(AgroText0.Text) || k1 != Convert.ToDouble(AgroText1.Text) || k2 != Convert.ToDouble(AgroText2.Text) || USE_KO_1 != USE_KO))
                {
                    MessageBox.Show("Внимание: Градуировка была изменена! Таблица Измерений будет пересчитана по новым коэффициентам!");
                    k0 = Convert.ToDouble(string.Format("{0:0.0000}", AgroText0.Text));
                    k1 = Convert.ToDouble(string.Format("{0:0.0000}", AgroText1.Text));
                    k2 = Convert.ToDouble(string.Format("{0:0.0000}", AgroText2.Text));
                    if (USE_KO_1 != USE_KO && USE_KO == false)
                    {
                        Table2.Rows.RemoveAt(0);
                        USE_KO_1 = USE_KO;
                    }
                    else
                    {
                        if (USE_KO_1 != USE_KO && USE_KO == true)
                        {
                            Table2.Rows.Insert(0, 0, "Контрольный");
                            for (int i = 1; i <= NoCaSer1; i++)
                            {
                                Table2.Rows[0].Cells["A;Ser" + i].Value = string.Format("{0:0.0000}", 0);

                            }
                            //   Table2.Rows.Add();
                            USE_KO_1 = USE_KO;
                            MessageBox.Show("Не забудьте измерить холостую пробу!");
                        }
                    }
                    PodschetTable2();
                }
            }
            else
            {
                if (tabControl2.SelectedIndex == 1 && Table2.Rows.Count > 0)
                {
                    bool doNotWrite = false;

                    for (int j = 0; j < Table2.Rows.Count - 1; j++)
                    {
                        for (int i = 2; i < Table2.Rows[j].Cells.Count; i++)
                        {
                            if (Table2.Rows[j].Cells[i].Value == null)
                            {
                                doNotWrite = true;

                            }
                        }
                    }
                    if (!doNotWrite)
                    {
                        label28.Visible = false;
                        label33.Visible = false;
                    }
                    else {
                        Podskazka.Text = "Измеряйте или введите значения!";
                        label27.Visible = false;
                        label24.Visible = false;
                        label25.Visible = false;
                        label26.Visible = false;
                        label28.Visible = true;
                        label33.Visible = true;
                        // button10.Enabled = false;
                        if (Table2.RowCount > 0 && (k0 != Convert.ToDouble(AgroText0.Text) || k1 != Convert.ToDouble(AgroText1.Text) || k2 != Convert.ToDouble(AgroText2.Text) || USE_KO_1 != USE_KO))
                        {
                            MessageBox.Show("Внимание: Градуировка была изменена! Таблица Измерений будет пересчитана по новым коэффициентам!");
                            k0 = Convert.ToDouble(string.Format("{0:0.0000}", AgroText0.Text));
                            k1 = Convert.ToDouble(string.Format("{0:0.0000}", AgroText1.Text));
                            k2 = Convert.ToDouble(string.Format("{0:0.0000}", AgroText2.Text));
                            if (USE_KO_1 != USE_KO && USE_KO == false)
                            {
                                Table2.Rows.RemoveAt(0);
                                USE_KO_1 = USE_KO;
                            }
                            else
                            {
                                if (USE_KO_1 != USE_KO && USE_KO == true)
                                {
                                    Table2.Rows.Insert(0, 0, "Контрольный");
                                    for (int i = 1; i <= NoCaSer1; i++)
                                    {
                                        Table2.Rows[0].Cells["A;Ser" + i].Value = string.Format("{0:0.0000}", 0);

                                    }
                                    //   Table2.Rows.Add();
                                    USE_KO_1 = USE_KO;
                                    MessageBox.Show("Не забудьте измерить холостую пробу!");
                                }
                            }
                            PodschetTable2();
                        }
                    }
                }
                else
                {
                    Podskazka.Text = "Перейдите в измерения!";
                    label27.Visible = false;
                    label24.Visible = false;
                    label25.Visible = false;
                    label26.Visible = false;
                    label28.Visible = false;
                    label33.Visible = false;
                    if (tabControl2.SelectedIndex == 0 && selet_rezim == 2)
                    {
                        button10.Enabled = true;
                    }
                    else
                    {
                        button10.Enabled = false;
                    }

                }
            }
        }
        public string[] filereadpribor;
        private void графикРезультатаОдноволновогоИзмеренияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C";
            openFileDialog1.Title = "Open File";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "TXT файл|*.TXT";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // получаем выбранный файл
                    //  openFileMulti(ref filepath);
                    filepath = openFileDialog1.FileName;
                    ReadFilePribor filepribor = new ReadFilePribor(filepath, this);
                    tabPage4.Parent = null;
                    /* foreach (string s in filereadpribor)
                     {
                         Console.WriteLine(s);
                     }*/
                    switch (selet_rezim)
                    {
                        case 1:
                            if (filereadpribor[0] == "Photometry Test Report")
                            {
                                IzmerenieFR_Table.Rows.Clear();
                                int count = System.IO.File.ReadAllLines(filepath).Length;
                                for (int i = 0; i < filereadpribor.Length - 4; i++)
                                {
                                    IzmerenieFR_Table.Rows.Add(i + 1, "Измерение " + (i + 1),
                                        filereadpribor[4 + i].Substring(8,
                                        filereadpribor[4 + i].LastIndexOf(".") - filereadpribor[4 + i].IndexOf(".") + 1).Replace(".", ","),
                                        filereadpribor[4 + i].Substring(filereadpribor[4 + i].LastIndexOf(".") - 1).Replace(".", ","));
                                    IzmerenieFR_Table.Rows[i].Cells[3].Value = IzmerenieFR_Table.Rows[i].Cells[3].Value.ToString().Substring(0, IzmerenieFR_Table.Rows[i].Cells[3].Value.ToString().Length - 2);
                                    IzmerenieFR_Table.Rows[i].Cells[5].Value = "0.0";
                                    string k1 = "0.0";
                                    k1 = k1.Replace(".", ",");
                                    IzmerenieFR_Table.Rows[i].Cells[4].Value = string.Format("{0:0.00}",
                                        Math.Pow(10, Convert.ToDouble(IzmerenieFR_Table.Rows[i].Cells[3].Value.ToString())) * 100);


                                    IzmerenieFR_Table.Rows[i].Cells[6].Value = string.Format("{0:0.0000}", (Convert.ToDouble(IzmerenieFR_Table.Rows[i].Cells[3].Value.ToString()) * Convert.ToDouble(k1)));
                                    // IzmerenieFR_Table.Rows[i].Cells[2].Value = filereadpribor[4 + i].Substring(filereadpribor[4 + i].LastIndexOf(".") - 1, filereadpribor[4 + i].IndexOf(" ")).Replace(".", ",");
                                }
                                печатьToolStripMenuItem1.Enabled = true;
                                button3.Enabled = true;
                            }
                            else
                            {
                                MessageBox.Show("Файл не поддерживается!");
                            }
                            break;
                        case 2:
                            if (filereadpribor[0] == "Quantitation Test Report")
                            {
                                string typefile = filereadpribor[2];

                                if (typefile.Substring(8) != "A=A1")
                                {
                                    MessageBox.Show("Внимание! Программа не поддерживает данный формат данных!");
                                    //  return;
                                }
                                else {
                                    MessageBox.Show("Для полноценного просмотра результатов необходимо заполнить следующую форму!");
                                    if (filereadpribor.Contains("Results"))
                                    {

                                        TotalInformationResults totlaInformationResults = new TotalInformationResults(this);
                                        totlaInformationResults.ShowDialog();
                                    }
                                    else
                                    {
                                        TotalInformation totlaInformation = new TotalInformation(this);
                                        totlaInformation.ShowDialog();
                                    }



                                    wavelength1 = filereadpribor[3].Substring(4);
                                    textBox9.Text = wavelength1;
                                    textBox10.Text = wavelength1;
                                    //   MessageBox.Show("Длина волны: " + wavelength1);

                                    edconctr = filereadpribor[4].Substring(7);
                                    switch (edconctr)
                                    {
                                        case "-":
                                            edconctr = "-";
                                            break;
                                        case "mg/l":
                                            edconctr = "мг/л";
                                            break;
                                        case "ug/dl":
                                            edconctr = "мкг/дл";
                                            break;
                                        case "ng/ul":
                                            edconctr = "нг/мкл";
                                            break;
                                        case "%":
                                            edconctr = "%";
                                            break;
                                        case "ug/l":
                                            edconctr = "мкг/л";
                                            break;
                                        case "mg/ml":
                                            edconctr = "мг/мл";
                                            break;
                                        case "mol/l":
                                            edconctr = "М/л";
                                            break;
                                        case "ppm":
                                            edconctr = "ppm";
                                            break;
                                        case "ng/l":
                                            edconctr = "нг/л";
                                            break;
                                        case "ug/ml":
                                            edconctr = "мкг/мл";
                                            break;
                                        case "mmol/l":
                                            edconctr = "мМ/л";
                                            break;
                                        case "ppb":
                                            edconctr = "ppb";
                                            break;
                                        case "g/dl":
                                            edconctr = "г/дл";
                                            break;
                                        case "ng/ml":
                                            edconctr = "нг/мл";
                                            break;
                                        case "IU":
                                            edconctr = "ME";
                                            break;
                                        case "g/l":
                                            edconctr = "г/л";
                                            break;
                                        case "mg/dl":
                                            edconctr = "мг/дл";
                                            break;
                                        case "ug/ul":
                                            edconctr = "мкг/мкл";
                                            break;
                                        default:
                                            edconctr = "Свое";
                                            break;



                                    }
                                    if (filereadpribor[5].Contains("Std"))
                                    {
                                        SposobZadan = "По СО";
                                    }
                                    else
                                    {
                                        SposobZadan = "Ввод коэффициентов";
                                    }

                                    if (SposobZadan == "По СО")
                                    {
                                        chart1.Series[0].Points.Clear();
                                        chart1.Series[1].Points.Clear();
                                        WLREMOVE1();
                                        WLREMOVESTR1();

                                        NoCaIzm = 1;


                                        for (int i = 1; i <= NoCaIzm; i++)
                                        {

                                            DataGridViewTextBoxColumn firstColumn1 =
                                            new DataGridViewTextBoxColumn();
                                            firstColumn1.HeaderText = "A; Сер" + i;
                                            firstColumn1.Name = "A;Ser (" + i;
                                            firstColumn1.ValueType = Type.GetType("System.Double");

                                            Table1.Columns.Add(firstColumn1);
                                            //firstColumn1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txt_KeyPress);
                                            //   firstColumn1.EditingControlShowing

                                        }

                                        for (int i = 1; i <= NoCaIzm; i++)
                                        {
                                            Table1.Columns["A;Ser (" + i].Width = 50;
                                        }
                                        Concetr.HeaderText = "Конц " + edconctr;

                                        if (filereadpribor.Contains("Results"))
                                        {

                                            for (int i = 0; i < filereadpribor.Length - Array.IndexOf(filereadpribor, "Results") - 3; i++)
                                            {
                                                Table1.Rows.Add(filereadpribor[12 + i].Substring(0, 1), filereadpribor[12 + i].Substring(20, 6).Replace(".", ","), filereadpribor[12 + i].Substring(8, 5).Replace(".", ","), filereadpribor[12 + i].Substring(8, 5).Replace(".", ","));
                                            }
                                            Table1CreateFile();
                                            tabPage4.Parent = tabControl2;

                                            WLREMOVE2();
                                            WLREMOVESTR2();
                                            NoCaIzm1 = 1;
                                            DataGridViewTextBoxColumn firstColumn2_1 =
                                            new DataGridViewTextBoxColumn();
                                            firstColumn2_1.HeaderText = "A; Сер." + 1;
                                            firstColumn2_1.Name = "A;Ser" + 1;
                                            firstColumn2_1.ValueType = Type.GetType("System.Double");
                                            Table2.Columns.Add(firstColumn2_1);
                                            DataGridViewTextBoxColumn firstColumn3_1 =
                                            new DataGridViewTextBoxColumn();
                                            firstColumn3_1.HeaderText = "C, " + edconctr + "; Сер." + 1;
                                            firstColumn3_1.Name = "C,edconctr;Ser." + 1;
                                            firstColumn3_1.ValueType = Type.GetType("System.Double");
                                            Table2.Columns.Add(firstColumn3_1);
                                            firstColumn3_1.ReadOnly = true;
                                            firstColumn3_1.Width = 50;
                                            firstColumn2_1.Width = 50;
                                            if (selet_rezim == 2)
                                            {
                                                DataGridViewTextBoxColumn firstColumn4 =
                                            new DataGridViewTextBoxColumn();
                                                firstColumn4.HeaderText = "Cср, " + edconctr;
                                                firstColumn4.Name = "Ccr";
                                                firstColumn4.ValueType = Type.GetType("System.Double");
                                                Table2.Columns.Add(firstColumn4);
                                                firstColumn4.ReadOnly = true;
                                                DataGridViewTextBoxColumn firstColumn5 =
                                                new DataGridViewTextBoxColumn();
                                                firstColumn5.HeaderText = "d, %";
                                                firstColumn5.Name = "d%";
                                                firstColumn5.ValueType = Type.GetType("System.Double");
                                                firstColumn5.ReadOnly = true;
                                                Table2.Columns.Add(firstColumn5);
                                                firstColumn4.Width = 100;
                                                firstColumn5.Width = 50;
                                            }

                                            //   tabControl2.SelectTab(tabPage4);
                                            for (int i = 0; i < filereadpribor.Length - Array.IndexOf(filereadpribor, "Results") - 2; i++)
                                            {
                                                Table2.Rows.Add(filereadpribor[Array.IndexOf(filereadpribor, "Results") + i + 2].Substring(0, 1),
                                                    "Образец " + filereadpribor[Array.IndexOf(filereadpribor, "Results") + i + 2].Substring(0, 1),
                                                    filereadpribor[Array.IndexOf(filereadpribor, "Results") + i + 2].Substring(8, 5).Replace(".", ","),
                                                    filereadpribor[Array.IndexOf(filereadpribor, "Results") + i + 2].Substring(20, 6).Replace(".", ","));
                                            }
                                            F1Text.Text = string.Format("{0:0.0000}", 1);
                                            F2Text.Text = string.Format("{0:0.0000}", 1);
                                            // textBox7.Text = string.Format("{0:0.0000}", 0);
                                            Table2CreateFile();
                                        }
                                        else
                                        {
                                            int lengthfilereadpribor = filereadpribor.Length;
                                            lengthfilereadpribor -= 12;

                                            for (int i = 0; i < lengthfilereadpribor; i++)
                                            {
                                                Table1.Rows.Add(filereadpribor[12 + i].Substring(0, 1), filereadpribor[12 + i].Substring(20, 6).Replace(".", ","), filereadpribor[12 + i].Substring(8, 5).Replace(".", ","), filereadpribor[12 + i].Substring(8, 5).Replace(".", ","));
                                            }
                                            Table1CreateFile();
                                        }




                                    }
                                    else
                                    {
                                        string typeAproksim = filereadpribor[6];
                                        string typeZavisimoct = filereadpribor[6].Substring(0, 1);

                                        int amount = typeAproksim.ToCharArray().Where(i => i == '+').Count();

                                        switch (amount)
                                        {
                                            case 0:
                                                if (typeZavisimoct == "C")
                                                {
                                                    Zavisimoct = "C(A)";
                                                    radioButton5.Checked = true;
                                                    label14.Text = "C(A)";
                                                }
                                                else
                                                {
                                                    Zavisimoct = "A(C)";
                                                    radioButton4.Checked = true;
                                                    label14.Text = "A(C)";
                                                }
                                                radioButton1.Checked = true;
                                                aproksim = "Линейная через 0";


                                                AgroText1.Text = string.Format("{0:0.0000}", typeAproksim.Substring(2, (typeAproksim.Length - 4)));
                                                k1 = Convert.ToDouble(AgroText1.Text.Replace(".", ","));


                                                break;
                                            case 1:
                                                if (typeZavisimoct == "C")
                                                {
                                                    Zavisimoct = "C(A)";
                                                    radioButton5.Checked = true;
                                                    label14.Text = "C(A)";
                                                }
                                                else
                                                {
                                                    Zavisimoct = "A(C)";
                                                    radioButton4.Checked = true;
                                                    label14.Text = "A(C)";
                                                }
                                                radioButton2.Checked = true;
                                                aproksim = "Линейная";
                                                int temp = typeAproksim.IndexOf("+");
                                                AgroText1.Text = string.Format("{0:0.0000}", typeAproksim.Substring(2, (typeAproksim.Length - temp - 1)));
                                                k1 = Convert.ToDouble(AgroText1.Text.Replace(".", ","));
                                                AgroText0.Text = string.Format("{0:0.0000}", typeAproksim.Substring((typeAproksim.Length - temp + 4)));
                                                k0 = Convert.ToDouble(AgroText0.Text.Replace(".", ","));

                                                //++count;


                                                break;
                                            case 2:
                                                if (typeZavisimoct == "C")
                                                {
                                                    Zavisimoct = "C(A)";
                                                    radioButton5.Checked = true;
                                                    label14.Text = "C(A)";
                                                }
                                                else
                                                {
                                                    Zavisimoct = "A(C)";
                                                    radioButton4.Checked = true;
                                                    label14.Text = "A(C)";
                                                }
                                                radioButton3.Checked = true;
                                                aproksim = "квадратичная";

                                                temp = typeAproksim.IndexOf("+");
                                                int temp1 = typeAproksim.LastIndexOf("+");
                                                AgroText2.Text = string.Format("{0:0.0000}", typeAproksim.Substring(2, (typeAproksim.Length - temp - 10)));
                                                k2 = Convert.ToDouble(AgroText2.Text.Replace(".", ","));
                                                AgroText0.Text = string.Format("{0:0.0000}", typeAproksim.Substring((typeAproksim.Length - temp + 6)));
                                                k0 = Convert.ToDouble(AgroText0.Text.Replace(".", ","));
                                                AgroText1.Text = string.Format("{0:0.0000}", typeAproksim.Substring((typeAproksim.Length - temp1 + 6), (typeAproksim.Length - temp1 - 1)));
                                                k1 = Convert.ToDouble(AgroText1.Text.Replace(".", ","));
                                                break;

                                        }
                                        GradTable();

                                    }
                                    button10.Enabled = true;
                                    button3.Enabled = true;
                                    button8.Enabled = true;
                                    button7.Enabled = true;
                                    button9.Enabled = true;
                                    label28.Visible = false;
                                    label33.Visible = false;
                                    экспортToolStripMenuItem.Enabled = true;
                                    эксопртВPDFToolStripMenuItem.Enabled = true;
                                    печатьToolStripMenuItem1.Enabled = true;
                                    параметрыToolStripMenuItem.Enabled = true;

                                }
                            }
                            else
                            {
                                MessageBox.Show("Файл не поддерживается!");
                            }
                            break;
                    }
                }
                catch (Exception t) { MessageBox.Show("exeption" + t.Message); }


            }

        }
        public void Table1CreateFile()
        {
            string typeAproksim = filereadpribor[7];
            string typeZavisimoct = filereadpribor[7].Substring(0, 1);

            int amount = typeAproksim.ToCharArray().Where(i => i == '+').Count();
            switch (amount)
            {
                case 0:
                    if (typeZavisimoct == "C")
                    {
                        Zavisimoct = "C(A)";
                        radioButton5.Checked = true;
                        label14.Text = "C(A)";
                    }
                    else
                    {
                        Zavisimoct = "A(C)";
                        radioButton4.Checked = true;
                        label14.Text = "A(C)";
                    }
                    radioButton1.Checked = true;
                    aproksim = "Линейная через 0";
                    lineynaya0();
                    break;
                case 1:
                    if (typeZavisimoct == "C")
                    {
                        Zavisimoct = "C(A)";
                        radioButton5.Checked = true;
                        label14.Text = "C(A)";
                    }
                    else
                    {
                        Zavisimoct = "A(C)";
                        radioButton4.Checked = true;
                        label14.Text = "A(C)";
                    }
                    radioButton2.Checked = true;
                    aproksim = "Линейная";
                    lineinaya();
                    break;
                case 2:
                    if (typeZavisimoct == "C")
                    {
                        Zavisimoct = "C(A)";
                        radioButton5.Checked = true;
                        label14.Text = "C(A)";
                    }
                    else
                    {
                        Zavisimoct = "A(C)";
                        radioButton4.Checked = true;
                        label14.Text = "A(C)";
                    }
                    radioButton3.Checked = true;
                    aproksim = "квадратичная";
                    kvadratichnaya();
                    break;

            }
            CountSeriya = Convert.ToString(1);
            CountInSeriya = Convert.ToString(Table1.RowCount - 1);
        }
        public void Table2CreateFile()
        {
            double CCR = 0.0;

            double maxEl;
            double minEl;
            double serValue = 0;
            for (int i = 0; i < Table2.RowCount; i++)
            {
                El = new double[NoCaIzm1];
                double SredValue = 0;
                for (int i1 = 1; i1 <= NoCaIzm1; i1++)
                {
                    switch (aproksim)
                    {
                        case "Линейная через 0":
                            serValue = Convert.ToDouble(Table2.Rows[i].Cells["A;Ser" + i1].Value.ToString()) / Convert.ToDouble(AgroText1.Text);
                            break;
                        case "Линейная":
                            serValue = ((Convert.ToDouble(Table2.Rows[i].Cells["A;Ser" + i1].Value.ToString()) - Convert.ToDouble(AgroText0.Text))) / Convert.ToDouble(AgroText1.Text);
                            break;
                        case "Квадратичная":
                            serValue = ((Convert.ToDouble(Table2.Rows[i].Cells["A;Ser" + i1].Value.ToString()) - Convert.ToDouble(AgroText0.Text))) / (Convert.ToDouble(AgroText1.Text) + Convert.ToDouble(AgroText2.Text));
                            break;
                    }
                    double CValue1 = Convert.ToDouble(F1Text.Text);
                    double CValue2 = Convert.ToDouble(F2Text.Text);
                    if (serValue >= 0)
                    {
                        Table2.Rows[i].Cells["C,edconctr;Ser." + i1].Value = string.Format("{0:0.0000}", serValue * CValue1 * CValue2);
                        SredValue += Convert.ToDouble(Table2.Rows[i].Cells["C,edconctr;Ser." + i1].Value.ToString());
                    }
                    else
                    {
                        Table2.Rows[i].Cells["C,edconctr;Ser." + i1].Value = "";
                    }
                    CCR = SredValue / NoCaIzm1;
                    if (Convert.ToDouble(textBox7.Text) >= 1)
                    {
                        Table2.Rows[i].Cells["Ccr"].Value = string.Format("{0:0.0000}", CCR) + "±" + string.Format("{0:0.00}", ((CCR * Convert.ToDouble(textBox7.Text)) / 100));
                    }
                    else Table2.Rows[i].Cells["Ccr"].Value = string.Format("{0:0.0000}", CCR);
                    if (Table2.Rows[i].Cells["C,edconctr;Ser." + i1].Value.ToString() != "")
                    {
                        El[i1 - 1] = Convert.ToDouble(Table2.Rows[i].Cells["C,edconctr;Ser." + i1].Value.ToString());
                    }
                    Array.Sort(El);
                    maxEl = El[El.Length - 1];
                    minEl = El[0];
                    double a = ((maxEl - minEl) * 100) / Convert.ToDouble(CCR);
                    double b = a;
                    // b = b * 10;


                    if (minEl == 0)
                    {
                        Table2.Rows[i].Cells["d%"].Value = 0.0000;
                    }
                    else
                    {
                        Table2.Rows[i].Cells["d%"].Value = string.Format("{0:0.00}", b);

                    }
                }
            }
            Table2.Rows.Add();
        }
        private void волновойАнализToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void адаптироватьСтарыеФайлыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C";
            openFileDialog1.Title = "Open File";
            openFileDialog1.FileName = "";
            switch (selet_rezim)
            {
                case 1:
                    openFileDialog1.Filter = "ISFR2 файл|*.isfr2";
                    break;
                case 2:
                    openFileDialog1.Filter = "QS2 файл; QA2 файл|*.qs2; *.qa2";
                    break;
                case 3:
                    openFileDialog1.Filter = "MULTI файл|*.MULTI2";
                    break;
                case 4:
                    openFileDialog1.Filter = "KIN файл|*.KIN2";
                    break;
                case 5:
                    openFileDialog1.Filter = "SCAN файл|*.SCAN2";
                    break;
                case 6:
                    openFileDialog1.Filter = "Agro QS2 файл|*.aq2";
                    break;
            }
            //openFileDialog1.Filter = "MULTI файл; KIN файл; SCAN файл; QS2 файл; Agro QS2; ISFR2 файл|*.MULTI2; *.KIN2; *.SCAN2; *.qs2; *.qa2; *.isfr2";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    filepath = openFileDialog1.FileName;
                    EncriptorFileBase64 encriptorFileBase64 = new EncriptorFileBase64(filepath, pathTemp);
                }
                catch
                {
                    MessageBox.Show("Формат файла не поддерживается!");
                }
            }
        }

        ///Если больше 3 и меньше или равно 7
        public void Table1PrintViewer2(object sender, PrintPageEventArgs e)
        {
            int height = 395;
            int width = 25;
            Pen p = new Pen(Brushes.Black, 1.5f);

            e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[0].Width + 5, Table1.Rows[0].Height * 2));
            e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[0].Width + 5, Table1.Rows[0].Height * 2));
            e.Graphics.DrawString(Table1.Columns[0].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[0].Width + 5, Table1.Rows[0].Height * 2));
            width = width + Table1.Columns[0].Width + 5;
            e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[1].Width, Table1.Rows[1].Height * 2));
            e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[1].Width, Table1.Rows[0].Height * 2));
            e.Graphics.DrawString(Table1.Columns[1].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[1].Width, Table1.Rows[0].Height * 2));
            width = width + Table1.Columns[1].Width;
            e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[2].Width + 5, Table1.Rows[0].Height * 2));
            e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[2].Width + 5, Table1.Rows[0].Height * 2));
            e.Graphics.DrawString(Table1.Columns[2].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[2].Width + 5, Table1.Rows[0].Height * 2));
            width = width + Table1.Columns[2].Width + 5;
            int k = 3;
            for (int i = 0; i < NoCaIzm; i++)
            {
                e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[0].Height * 2));
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[0].Height * 2));
                e.Graphics.DrawString(Table1.Columns[k].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[k].Width + 10, Table1.Rows[0].Height * 2));
                width = width + Table1.Columns[k].Width + 10;
                k++;
            }
            height = height + Table1.Rows[0].Height * 2;
            /* Формируем значения */
            width = 25;
            int height1 = height;
            int width1_1 = width;


            for (int j = 0; j < Table1.Rows.Count - 1; j++)
            {
                if (Table1.Rows[j].Cells[0].Style.BackColor.Name == "Pink")
                {
                    e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table1.Columns[0].Width + 10, Table1.Rows[j].Height));
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[0].Width + 10, Table1.Rows[j].Height));
                }
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[0].Width + 5, Table1.Rows[j].Height));
                e.Graphics.DrawString(Table1.Rows[j].Cells[0].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[0].Width + 5, Table1.Rows[j].Height));
                // width = width + Table1.Columns[0].Width;
                height += Table1.Rows[j].Height;
            }
            height = height1;
            width = width + Table1.Columns[0].Width + 5;
            for (int j = 0; j < Table1.Rows.Count - 1; j++)
            {
                if (Table1.Rows[j].Cells[1].Style.BackColor.Name == "Pink")
                {
                    e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table1.Columns[1].Width + 10, Table1.Rows[j].Height));
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[1].Width + 10, Table1.Rows[j].Height));
                }
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[1].Width, Table1.Rows[j].Height));
                e.Graphics.DrawString(Table1.Rows[j].Cells[1].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[1].Width, Table1.Rows[j].Height));
                // width = width + Table1.Columns[1].Width;
                height += Table1.Rows[j].Height;
            }
            height = height1;
            width = width + Table1.Columns[1].Width;
            for (int j = 0; j < Table1.Rows.Count - 1; j++)
            {
                if (Table1.Rows[j].Cells[2].Style.BackColor.Name == "Pink")
                {
                    e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table1.Columns[2].Width + 10, Table1.Rows[j].Height));
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[2].Width + 10, Table1.Rows[j].Height));
                }
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[2].Width + 5, Table1.Rows[j].Height));
                if (Table1.Rows[j].Cells[2].Value != null)
                {
                    e.Graphics.DrawString(Table1.Rows[j].Cells[2].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[2].Width + 5, Table1.Rows[j].Height));
                }
                else
                {
                    e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[2].Width + 5, Table1.Rows[j].Height));
                }
                // width = width + Table1.Columns[2].Width;
                height += Table1.Rows[j].Height;
            }
            height = height1;
            width = width + Table1.Columns[2].Width + 5;
            int width1 = width;
            k = 3;
            for (int j = 0; j < Table1.Rows.Count - 1; j++)
            {
                for (int i = 0; i < NoCaIzm; i++)
                {
                    if (Table1.Rows[j].Cells[k].Style.BackColor.Name == "Pink")
                    {
                        e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                    }
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                    if (Table1.Rows[j].Cells[k].Value != null)
                    {
                        e.Graphics.DrawString(Table1.Rows[j].Cells[k].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                    }
                    width = width + Table1.Columns[k].Width + 10;
                    k++;
                    //width1_1 = width;
                }
                height += Table1.Rows[j].Height;
                width = width1;
                k = 3;
            }
            /*Cancel*/
            if (Table1.Rows.Count <= 10)
            {
                height = height + 10;
                width = 25;
                k = NoCaIzm + 3;
                for (int i = 0; i < Table1.Columns.Count - NoCaIzm - 3; i++)
                {
                    if (Table1.Rows[i].Cells[k].Style.BackColor.Name == "Pink")
                    {
                        e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[i].Height));
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[i].Height));
                    }
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[0].Height * 2));
                    e.Graphics.DrawString(Table1.Columns[k].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[k].Width + 10, Table1.Rows[0].Height * 2));
                    width = width + Table1.Columns[k].Width + 10;
                    k++;
                    // height = height + Table1.Rows[i].Height;
                }

                /*Формируем вторую часть значений*/

                height = height + Table1.Rows[0].Height * 2;
                width1 = 25;
                width = 25;
                k = NoCaIzm + 3;
                for (int j = 0; j < Table1.Rows.Count - 1; j++)
                {
                    for (int i = 0; i < Table1.Columns.Count - NoCaIzm - 3; i++)
                    {
                        if (Table1.Rows[j].Cells[k].Style.BackColor.Name == "Pink")
                        {
                            e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                        }
                        else
                        {
                            e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                        }
                        e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                        if (Table1.Rows[j].Cells[k].Value != null)
                        {
                            e.Graphics.DrawString(Table1.Rows[j].Cells[k].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                        }
                        else
                        {
                            e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                        }
                        width = width + Table1.Columns[k].Width + 10;
                        k++;
                    }
                    cordY = height;
                    height += Table1.Rows[j].Height;
                    width = width1;
                    k = NoCaIzm + 3;
                }
                /*Cancel*/
            }
            else
            {
                e.Graphics.DrawString("Страница " + (prinPage + 1) + " из 2", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 300, 1100);
                e.HasMorePages = true;
                prinPage++;

                cordY = 50;
                return;
            }

        }

        public void Table1PageAdd2(object sender, PrintPageEventArgs e)
        {
            Pen p = new Pen(Brushes.Black, 1.5f);
            height = 80;
            width = 25;
            int k = NoCaIzm + 3;
            for (int i = 0; i < Table1.Columns.Count - NoCaIzm - 3; i++)
            {
                e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[0].Height * 2));
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[0].Height * 2));
                e.Graphics.DrawString(Table1.Columns[k].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[k].Width + 10, Table1.Rows[0].Height * 2));
                width = width + Table1.Columns[k].Width + 10;
                k++;
                // height = height + Table1.Rows[i].Height;
            }

            /*Формируем вторую часть значений*/

            height = height + Table1.Rows[0].Height * 2;
            int width1 = 25;
            width = 25;
            k = NoCaIzm + 3;
            for (int j = 0; j < Table1.Rows.Count - 1; j++)
            {
                for (int i = 0; i < Table1.Columns.Count - NoCaIzm - 3; i++)
                {
                    if (Table1.Rows[j].Cells[k].Style.BackColor.Name == "Pink")
                    {
                        e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                    }
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                    if (Table1.Rows[j].Cells[k].Value != null)
                    {
                        e.Graphics.DrawString(Table1.Rows[j].Cells[k].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                    }
                    width = width + Table1.Columns[k].Width + 10;
                    k++;
                }
                cordY = height;
                height += Table1.Rows[j].Height;
                width = width1;
                k = NoCaIzm + 3;
            }
            /*Cancel*/
        }
        /*Если больше 7*/
        public void Table1PrintViewer3(object sender, PrintPageEventArgs e)
        {
            Pen p = new Pen(Brushes.Black, 1.5f);
            if (prinPage <= 0)
            {
                int height = 395;
                int width = 25;


                e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[0].Width + 5, Table1.Rows[0].Height * 2));
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[0].Width + 5, Table1.Rows[0].Height * 2));
                e.Graphics.DrawString(Table1.Columns[0].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[0].Width + 5, Table1.Rows[0].Height * 2));
                width = width + Table1.Columns[0].Width + 5;
                e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[1].Width, Table1.Rows[1].Height * 2));
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[1].Width, Table1.Rows[1].Height * 2));
                e.Graphics.DrawString(Table1.Columns[1].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[1].Width, Table1.Rows[0].Height * 2));
                width = width + Table1.Columns[1].Width;
                e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[2].Width + 5, Table1.Rows[0].Height * 2));
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[2].Width + 5, Table1.Rows[0].Height * 2));
                e.Graphics.DrawString(Table1.Columns[2].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[2].Width + 5, Table1.Rows[0].Height * 2));
                width = width + Table1.Columns[2].Width + 5;
                int k = 3;
                for (int i = 0; i < 7; i++)
                {
                    e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[0].Height * 2));
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[0].Height * 2));
                    e.Graphics.DrawString(Table1.Columns[k].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[k].Width + 10, Table1.Rows[0].Height * 2));
                    width = width + Table1.Columns[k].Width + 10;
                    k++;
                }


                height = height + Table1.Rows[0].Height * 2;
                /* Формируем значения */
                width = 25;
                int height1 = height;
                int width1_1 = width;


                for (int j = 0; j < Table1.Rows.Count - 1; j++)
                {
                    if (Table1.Rows[j].Cells[0].Style.BackColor.Name == "Pink")
                    {
                        e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table1.Columns[0].Width + 10, Table1.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[0].Width + 10, Table1.Rows[j].Height));
                    }
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[0].Width + 5, Table1.Rows[j].Height));
                    e.Graphics.DrawString(Table1.Rows[j].Cells[0].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[0].Width + 5, Table1.Rows[j].Height));
                    // width = width + Table1.Columns[0].Width;
                    height += Table1.Rows[j].Height;
                }
                height = height1;
                width = width + Table1.Columns[0].Width + 5;
                for (int j = 0; j < Table1.Rows.Count - 1; j++)
                {
                    if (Table1.Rows[j].Cells[1].Style.BackColor.Name == "Pink")
                    {
                        e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table1.Columns[1].Width + 10, Table1.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[1].Width + 10, Table1.Rows[j].Height));
                    }
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[1].Width, Table1.Rows[j].Height));
                    e.Graphics.DrawString(Table1.Rows[j].Cells[1].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[1].Width, Table1.Rows[j].Height));
                    // width = width + Table1.Columns[1].Width;
                    height += Table1.Rows[j].Height;
                }
                height = height1;
                width = width + Table1.Columns[1].Width;
                for (int j = 0; j < Table1.Rows.Count - 1; j++)
                {
                    if (Table1.Rows[j].Cells[2].Style.BackColor.Name == "Pink")
                    {
                        e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table1.Columns[2].Width + 10, Table1.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[2].Width + 10, Table1.Rows[j].Height));
                    }
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[2].Width + 5, Table1.Rows[j].Height));
                    if (Table1.Rows[j].Cells[2].Value != null)
                    {
                        e.Graphics.DrawString(Table1.Rows[j].Cells[2].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[2].Width + 5, Table1.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[2].Width + 5, Table1.Rows[j].Height));
                    }
                    // width = width + Table1.Columns[2].Width;
                    height += Table1.Rows[j].Height;
                }
                height = height1;
                width = width + Table1.Columns[2].Width + 5;
                int width1 = width;
                k = 3;
                for (int j = 0; j < Table1.Rows.Count - 1; j++)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        if (Table1.Rows[j].Cells[k].Style.BackColor.Name == "Pink")
                        {
                            e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                        }
                        else
                        {
                            e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                        }
                        e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                        if (Table1.Rows[j].Cells[k].Value != null)
                        {
                            e.Graphics.DrawString(Table1.Rows[j].Cells[k].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                        }
                        else
                        {
                            e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                        }
                        width = width + Table1.Columns[k].Width + 10;
                        k++;
                        //width1_1 = width;
                    }
                    height += Table1.Rows[j].Height;
                    width = width1;
                    k = 3;
                }
                /*Cancel*/



                if (Table1.Rows.Count <= 10)
                {
                    height = height + 10;
                    width = 25;
                    k = 10;
                    //k = 11;
                    for (int i = 0; i < NoCaIzm - 7; i++)
                    {
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[0].Height * 2));
                        e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[0].Height * 2));
                        e.Graphics.DrawString(Table1.Columns[k].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[k].Width + 10, Table1.Rows[0].Height * 2));
                        width = width + Table1.Columns[k].Width + 10;
                        k++;
                    }

                    for (int i = 0; i < Table1.Columns.Count - NoCaIzm - 3; i++)
                    {
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[0].Height * 2));
                        e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[0].Height * 2));
                        e.Graphics.DrawString(Table1.Columns[k].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[k].Width + 10, Table1.Rows[0].Height * 2));
                        width = width + Table1.Columns[k].Width + 10;
                        k++;
                        // height = height + Table1.Rows[i].Height;
                    }

                    /*Формируем вторую часть значений*/

                    height = height + Table1.Rows[0].Height * 2;
                    height1 = height;
                    width1 = 25;
                    width = 25;
                    k = 10;
                    for (int j = 0; j < Table1.Rows.Count - 1; j++)
                    {
                        for (int i = 0; i < NoCaIzm - 7; i++)
                        {
                            if (Table1.Rows[j].Cells[k].Style.BackColor.Name == "Pink")
                            {
                                e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                            }
                            else
                            {
                                e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                            }
                            e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                            if (Table1.Rows[j].Cells[k].Value != null)
                            {
                                e.Graphics.DrawString(Table1.Rows[j].Cells[k].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                            }
                            else
                            {
                                e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                            }
                            width = width + Table1.Columns[k].Width + 10;
                            k++;
                            //width1_1 = width;
                        }
                        height += Table1.Rows[j].Height;
                        width = width1;
                        k = 10;
                    }
                    width = (Table1.Columns[10].Width + 10) * (NoCaIzm - 7) + width;
                    width1 = width;
                    height = height1;
                    k = 10 + NoCaIzm - 7;
                    for (int j = 0; j < Table1.Rows.Count - 1; j++)
                    {
                        for (int i = 0; i < Table1.Columns.Count - NoCaIzm - 3; i++)
                        {
                            if (Table1.Rows[j].Cells[k].Style.BackColor.Name == "Pink")
                            {
                                e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                            }
                            else
                            {
                                e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                            }
                            e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                            if (Table1.Rows[j].Cells[k].Value != null)
                            {
                                e.Graphics.DrawString(Table1.Rows[j].Cells[k].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                            }
                            else
                            {
                                e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                            }
                            width = width + Table1.Columns[k].Width + 10;
                            k++;
                        }
                        cordY = height;

                        height += Table1.Rows[j].Height;
                        width = width1;
                        k = 10 + NoCaIzm - 7;
                    }
                    e.HasMorePages = false;
                    /*Cancel*/
                }
                else
                {
                    e.Graphics.DrawString("Страница " + (prinPage + 1) + " из 2", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 300, 1100);
                    e.HasMorePages = true;
                    prinPage++;

                    cordY = 50;
                    return;



                }

            }


        }
        public void Table1PageAdd(object sender, PrintPageEventArgs e)
        {


            Pen p = new Pen(Brushes.Black, 1.5f);
            height = 80;
            width = 25;
            int k = 10;
            //k = 11;
            for (int i = 0; i < NoCaIzm - 7; i++)
            {
                e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[0].Height * 2));
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[0].Height * 2));
                e.Graphics.DrawString(Table1.Columns[k].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[k].Width + 10, Table1.Rows[0].Height * 2));
                width = width + Table1.Columns[k].Width + 10;
                k++;
            }

            for (int i = 0; i < Table1.Columns.Count - NoCaIzm - 3; i++)
            {
                e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[0].Height * 2));
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[0].Height * 2));
                e.Graphics.DrawString(Table1.Columns[k].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[k].Width + 10, Table1.Rows[0].Height * 2));
                width = width + Table1.Columns[k].Width + 10;
                k++;
                // height = height + Table1.Rows[i].Height;
            }

            /*Формируем вторую часть значений*/

            height = height + Table1.Rows[0].Height * 2;
            height1 = height;
            int width1 = 25;
            width = 25;
            k = 10;
            for (int j = 0; j < Table1.Rows.Count - 1; j++)
            {
                for (int i = 0; i < NoCaIzm - 7; i++)
                {
                    if (Table1.Rows[j].Cells[k].Style.BackColor.Name == "Pink")
                    {
                        e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                    }
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                    if (Table1.Rows[j].Cells[k].Value != null)
                    {
                        e.Graphics.DrawString(Table1.Rows[j].Cells[k].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                    }
                    width = width + Table1.Columns[k].Width + 10;
                    k++;
                    //width1_1 = width;
                }
                height += Table1.Rows[j].Height;
                width = width1;
                k = 10;
            }
            width = (Table1.Columns[10].Width + 10) * (NoCaIzm - 7) + width;
            width1 = width;
            height = height1;
            k = 10 + NoCaIzm - 7;
            for (int j = 0; j < Table1.Rows.Count - 1; j++)
            {
                for (int i = 0; i < Table1.Columns.Count - NoCaIzm - 3; i++)
                {
                    if (Table1.Rows[j].Cells[k].Style.BackColor.Name == "Pink")
                    {
                        e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                    }
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                    if (Table1.Rows[j].Cells[k].Value != null)
                    {
                        e.Graphics.DrawString(Table1.Rows[j].Cells[k].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table1.Columns[k].Width + 10, Table1.Rows[j].Height));
                    }
                    width = width + Table1.Columns[k].Width + 10;
                    k++;
                }
                cordY = height;

                height += Table1.Rows[j].Height;
                width = width1;
                k = 10 + NoCaIzm - 7;
            }
        }
        ///Если меньше или равно 3
        public void Table2PrintViewer1(object sender, PrintPageEventArgs e)
        {
            int height = 560;
            int width = 25;
            Pen p = new Pen(Brushes.Black, 1.5f);

            e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[0].Width + 5, Table2.Rows[0].Height * 2));
            e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[0].Width + 5, Table2.Rows[0].Height * 2));
            e.Graphics.DrawString(Table2.Columns[0].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[0].Width + 5, Table2.Rows[0].Height * 2));
            width = width + Table2.Columns[0].Width + 5;
            e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[1].Width, Table2.Rows[0].Height * 2));
            e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[1].Width, Table2.Rows[0].Height * 2));
            e.Graphics.DrawString(Table2.Columns[1].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[1].Width, Table2.Rows[0].Height * 2));
            width = width + Table2.Columns[1].Width;

            for (int i = 2; i <= Table2.Columns.Count - NoCaIzm1; i++)
            {
                e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[i].Width + 10, Table2.Rows[0].Height * 2));
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[i].Width + 10, Table2.Rows[0].Height * 2));
                e.Graphics.DrawString(Table2.Columns[i].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[i].Width + 10, Table2.Rows[0].Height * 2));
                width = width + Table2.Columns[i].Width + 10;
            }
            for (int i = Table2.Columns.Count - NoCaIzm1 + 1; i < Table2.Columns.Count; i++)
            {
                e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[i].Width + 10, Table2.Rows[0].Height * 2));
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[i].Width + 10, Table2.Rows[0].Height * 2));
                e.Graphics.DrawString(Table2.Columns[i].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[i].Width + 10, Table2.Rows[0].Height * 2));
                width = width + Table2.Columns[i].Width + 10;
                // height = height + Table2.Rows[i].Height;
            }
            height = height + Table2.Rows[0].Height * 2;
            width = 25;
            int height1 = height;
            int width1_1 = width;



            for (int j = 0; j < Table2.Rows.Count - 1; j++)
            {
                if (Table2.Rows[j].Cells[0].Style.BackColor.Name == "Pink")
                {
                    e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table2.Columns[0].Width + 10, Table2.Rows[j].Height));
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[0].Width + 10, Table2.Rows[j].Height));
                }
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[0].Width + 5, Table2.Rows[j].Height));
                e.Graphics.DrawString(Table2.Rows[j].Cells[0].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[0].Width + 5, Table2.Rows[j].Height));
                // width = width + Table2.Columns[0].Width;
                height += Table2.Rows[j].Height;
            }
            height = height1;
            width = width + Table2.Columns[0].Width + 5;
            for (int j = 0; j < Table2.Rows.Count - 1; j++)
            {
                if (Table2.Rows[j].Cells[1].Style.BackColor.Name == "Pink")
                {
                    e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table2.Columns[1].Width + 10, Table2.Rows[j].Height));
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[1].Width + 10, Table2.Rows[j].Height));
                }
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[1].Width, Table2.Rows[j].Height));
                if (Table2.Rows[j].Cells[1].Value != null)
                {
                    e.Graphics.DrawString(Table2.Rows[j].Cells[1].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[1].Width, Table2.Rows[j].Height));

                }
                else
                {
                    e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[1].Width, Table2.Rows[j].Height));
                }
                // width = width + Table2.Columns[1].Width;
                height += Table2.Rows[j].Height;
            }
            height = height1;
            width = width + Table2.Columns[1].Width;

            int width1 = width;
            for (int j = 0; j < Table2.Rows.Count - 1; j++)
            {
                for (int i = 2; i <= Table2.Columns.Count - NoCaIzm1; i++)
                {
                    if (Table2.Rows[j].Cells[i].Style.BackColor.Name == "Pink")
                    {
                        e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table2.Columns[i].Width + 10, Table2.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[i].Width + 10, Table2.Rows[j].Height));
                    }
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[i].Width + 10, Table2.Rows[j].Height));
                    if (Table2.Rows[j].Cells[i].Value != null)
                    {
                        e.Graphics.DrawString(Table2.Rows[j].Cells[i].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[i].Width + 10, Table2.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[i].Width + 10, Table2.Rows[j].Height));
                    }
                    width = width + Table2.Columns[i].Width + 10;
                    width1_1 = width;
                }
                height += Table2.Rows[j].Height;
                width = width1;
            }

            height = height1;
            width1 = width1_1;
            width = width1;
            for (int j = 0; j < Table2.Rows.Count - 1; j++)
            {
                for (int i = Table2.Columns.Count - NoCaIzm1 + 1; i < Table2.Columns.Count; i++)
                {
                    if (Table2.Rows[j].Cells[i].Style.BackColor.Name == "Pink")
                    {
                        e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table2.Columns[i].Width + 10, Table2.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[i].Width + 10, Table2.Rows[j].Height));
                    }
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[i].Width + 10, Table2.Rows[j].Height));
                    if (Table2.Rows[j].Cells[i].Value != null)
                    {
                        e.Graphics.DrawString(Table2.Rows[j].Cells[i].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[i].Width + 10, Table2.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[i].Width + 10, Table2.Rows[j].Height));
                    }
                    width = width + Table2.Columns[i].Width + 10;
                }
                cordY = height;
                height += Table2.Rows[j].Height;
                width = width1;
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScanTable.Rows.Clear();
            int number = listBox1.SelectedIndex;
            int m = countScan[number].GetLength(0);
            int n = countScan[number].GetLength(1);
            ScanTable.ColumnCount = n;
            ScanTable.RowCount = m + 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {

                        ScanTable.Rows[i].Cells[j].Value = countScan[number][i, j];

                }
            }
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            double max = 0.0;
            double min = 0.0;
            for (int i = 0; i < ScanTable.Rows.Count; i++)
            {
                if (i == 0)
                {
                    if (Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value) > Convert.ToDouble(ScanTable.Rows[i + 1].Cells[1].Value))
                    {
                        max = Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value);
                        dataGridView1.Rows.Add(ScanTable.Rows[i].Cells[0].Value, ScanTable.Rows[i].Cells[1].Value, ScanTable.Rows[i].Cells[2].Value);
                        min = max;
                        double x1 = Convert.ToDouble(ScanTable.Rows[i].Cells[0].Value);
                        double y1 = Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value);
                        ScanChart.Series[0].Points.AddXY(x1, y1);
                        ScanChart.Series[0].ChartType = SeriesChartType.Point;
                    }
                    else
                    {
                        min = Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value);
                        dataGridView2.Rows.Add(ScanTable.Rows[i].Cells[0].Value, ScanTable.Rows[i].Cells[1].Value, ScanTable.Rows[i].Cells[2].Value);
                        max = min;
                        double x1 = Convert.ToDouble(ScanTable.Rows[i].Cells[0].Value);
                        double y1 = Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value);
                        ScanChart.Series[0].Points.AddXY(x1, y1);
                        ScanChart.Series[0].ChartType = SeriesChartType.Point;
                    }

                }
                else {
                    if (i + 1 != ScanTable.Rows.Count)
                    {
                        if (Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value) >= Convert.ToDouble(ScanTable.Rows[i - 1].Cells[1].Value)
                            &&
                            Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value) > Convert.ToDouble(ScanTable.Rows[i + 1].Cells[1].Value)

                            )
                        {
                            max = Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value);
                            min = max;
                            dataGridView1.Rows.Add(ScanTable.Rows[i].Cells[0].Value, ScanTable.Rows[i].Cells[1].Value, ScanTable.Rows[i].Cells[2].Value);
                            double x1 = Convert.ToDouble(ScanTable.Rows[i].Cells[0].Value);
                            double y1 = Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value);
                            ScanChart.Series[0].Points.AddXY(x1, y1);
                            ScanChart.Series[0].ChartType = SeriesChartType.Point;
                        }
                        if ((Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value) <= Convert.ToDouble(ScanTable.Rows[i - 1].Cells[1].Value)
                            &&
                            Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value) < Convert.ToDouble(ScanTable.Rows[i + 1].Cells[1].Value))

                            )
                        {
                            min = Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value);
                            dataGridView2.Rows.Add(ScanTable.Rows[i].Cells[0].Value, ScanTable.Rows[i].Cells[1].Value, ScanTable.Rows[i].Cells[2].Value);
                            max = min;
                            double x1 = Convert.ToDouble(ScanTable.Rows[i].Cells[0].Value);
                            double y1 = Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value);
                            ScanChart.Series[0].Points.AddXY(x1, y1);
                            ScanChart.Series[0].ChartType = SeriesChartType.Point;
                        }
                    }
                }
            }
        }

        private void справкаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HelpDesk helpDesk = new HelpDesk();
            helpDesk.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Process.Start("TeamViewerQS.exe");

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ReviewsWishes reviewswishes = new ReviewsWishes();
            reviewswishes.ShowDialog();
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgrammVersion _versionProgramm = new ProgrammVersion();
            _versionProgramm.Show();
        }

        private void удаленнаяТехПомощьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(path + "TeamViewerQS.exe");
            }
            catch
            {
                MessageBox.Show("У вас отсутствует один или несколько модулей! Переустановите программу или напишите в нашу поддержку, мы поможем исправить проблему!");
            }
        }

        private void запросВТехПоддержкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpDesk helpDesk = new HelpDesk();
            helpDesk.ShowDialog();
        }

        private void оПрограммеToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ProgrammVersion _versionProgramm = new ProgrammVersion();
            _versionProgramm.Show();
        }

        private void отзывыИПожеланияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReviewsWishes reviewswishes = new ReviewsWishes();
            reviewswishes.ShowDialog();
        }

        ///Если больше 3 и меньше или равно 7
        public void Table2PrintViewer2(object sender, PrintPageEventArgs e)
        {

            int height = 560;
            int width = 25;
            Pen p = new Pen(Brushes.Black, 1.5f);
            if (prinPage <= 0)
            {
                e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[0].Width + 5, Table2.Rows[0].Height * 2));
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[0].Width + 5, Table2.Rows[0].Height * 2));
                e.Graphics.DrawString(Table2.Columns[0].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[0].Width + 5, Table2.Rows[0].Height * 2));
                width = width + Table2.Columns[0].Width + 5;
                e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[1].Width, Table2.Rows[1].Height * 2));
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[1].Width, Table2.Rows[0].Height * 2));
                e.Graphics.DrawString(Table2.Columns[1].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[1].Width, Table2.Rows[0].Height * 2));
                width = width + Table2.Columns[1].Width;

                int k = 2;
                for (int i = 0; i < NoCaIzm1 * 2; i++)
                {
                    e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[0].Height * 2));
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[0].Height * 2));
                    e.Graphics.DrawString(Table2.Columns[k].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[k].Width + 10, Table2.Rows[0].Height * 2));
                    width = width + Table2.Columns[k].Width + 10;
                    k++;
                }
                height = height + Table2.Rows[0].Height * 2;
                /* Формируем значения */
                width = 25;
                int height1 = height;
                int width1_1 = width;

                for (int j = 0; j < Table2.Rows.Count - 1; j++)
                {
                    if (Table2.Rows[j].Cells[0].Style.BackColor.Name == "Pink")
                    {
                        e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table2.Columns[0].Width + 10, Table2.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[0].Width + 10, Table2.Rows[j].Height));
                    }
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[0].Width + 5, Table2.Rows[j].Height));
                    e.Graphics.DrawString(Table2.Rows[j].Cells[0].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[0].Width + 5, Table2.Rows[j].Height));
                    // width = width + Table2.Columns[0].Width;
                    height += Table2.Rows[j].Height;
                }
                height = height1;
                width = width + Table2.Columns[0].Width + 5;
                for (int j = 0; j < Table2.Rows.Count - 1; j++)
                {
                    if (Table2.Rows[j].Cells[1].Style.BackColor.Name == "Pink")
                    {
                        e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table2.Columns[1].Width + 10, Table2.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[1].Width + 10, Table2.Rows[j].Height));
                    }
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[1].Width, Table2.Rows[j].Height));
                    if (Table2.Rows[j].Cells[1].Value != null)
                    {
                        e.Graphics.DrawString(Table2.Rows[j].Cells[1].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[1].Width, Table2.Rows[j].Height));

                    }
                    else
                    {
                        e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[1].Width, Table2.Rows[j].Height));
                    }
                    // width = width + Table2.Columns[1].Width;
                    height += Table2.Rows[j].Height;
                }
                height = height1;
                width = width + Table2.Columns[1].Width;

                int width1 = width;
                k = 2;
                for (int j = 0; j < Table2.Rows.Count - 1; j++)
                {
                    for (int i = 0; i < NoCaIzm1 * 2; i++)
                    {
                        if (Table2.Rows[j].Cells[k].Style.BackColor.Name == "Pink")
                        {
                            e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                        }
                        else
                        {
                            e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                        }

                        e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                        if (Table2.Rows[j].Cells[k].Value != null)
                        {
                            e.Graphics.DrawString(Table2.Rows[j].Cells[k].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                        }
                        else
                        {
                            e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                        }
                        width = width + Table2.Columns[k].Width + 10;
                        k++;
                        //width1_1 = width;
                    }
                    height += Table2.Rows[j].Height;
                    width = width1;
                    k = 2;
                }
                /*Cancel*/
                if (Table2.Rows.Count <= 10)
                {
                    height = height + 10;
                    width = 25;
                    k = NoCaIzm1 * 2 + 2;
                    for (int i = 0; i < Table2.Columns.Count - NoCaIzm1 * 2 - 2; i++)
                    {
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[0].Height * 2));
                        e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[0].Height * 2));
                        e.Graphics.DrawString(Table2.Columns[k].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[k].Width + 10, Table2.Rows[0].Height * 2));
                        width = width + Table2.Columns[k].Width + 10;
                        k++;
                        // height = height + Table2.Rows[i].Height;
                    }

                    /*Формируем вторую часть значений*/

                    height = height + Table2.Rows[0].Height * 2;
                    width1 = 25;
                    width = 25;
                    k = NoCaIzm1 * 2 + 2;
                    for (int j = 0; j < Table2.Rows.Count - 1; j++)
                    {
                        for (int i = 0; i < Table2.Columns.Count - NoCaIzm1 * 2 - 2; i++)
                        {
                            if (Table2.Rows[j].Cells[k].Style.BackColor.Name == "Pink")
                            {
                                e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                            }
                            else
                            {
                                e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                            }

                            e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                            if (Table2.Rows[j].Cells[k].Value != null)
                            {
                                e.Graphics.DrawString(Table2.Rows[j].Cells[k].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                            }
                            else
                            {
                                e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                            }
                            width = width + Table2.Columns[k].Width + 10;
                            k++;
                        }
                        cordY = height;
                        height += Table2.Rows[j].Height;
                        width = width1;
                        k = NoCaIzm1 * 2 + 2;
                    }
                    /*Cancel*/
                }
                else
                {
                    e.Graphics.DrawString("Страница " + (prinPage + 1) + " из 2", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 300, 1100);
                    e.HasMorePages = true;
                    prinPage++;

                    cordY = 50;
                    return;
                }
            }

        }

        public void Table2PageAdd1(object sender, PrintPageEventArgs e)
        {
            Pen p = new Pen(Brushes.Black, 1.5f);
            height = 80;
            width = 25;
            int k = NoCaIzm1 * 2 + 2;
            e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[0].Width + 10, Table2.Rows[0].Height * 2));
            e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[0].Width + 10, Table2.Rows[0].Height * 2));
            e.Graphics.DrawString(Table2.Columns[0].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[0].Width + 10, Table2.Rows[0].Height * 2));
            width = width + Table2.Columns[0].Width + 10;

            e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[1].Width + 10, Table2.Rows[0].Height * 2));
            e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[1].Width + 10, Table2.Rows[0].Height * 2));
            e.Graphics.DrawString(Table2.Columns[1].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[1].Width + 10, Table2.Rows[1].Height * 2));
            width = width + Table2.Columns[1].Width + 10;
            for (int i = 0; i < Table2.Columns.Count - NoCaIzm1 * 2 - 2; i++)
            {
                e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[0].Height * 2));
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[0].Height * 2));
                e.Graphics.DrawString(Table2.Columns[k].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[k].Width + 10, Table2.Rows[0].Height * 2));
                width = width + Table2.Columns[k].Width + 10;
                k++;
                // height = height + Table2.Rows[i].Height;
            }

            /*Формируем вторую часть значений*/

            height = height + Table2.Rows[0].Height * 2;
            int width1 = 25;
            width = 25;
            k = NoCaIzm1 * 2 + 2;
            for (int j = 0; j < Table2.Rows.Count - 1; j++)
            {
                if (Table2.Rows[j].Cells[0].Style.BackColor.Name == "Pink")
                {
                    e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table2.Columns[0].Width + 10, Table2.Rows[j].Height));
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[0].Width + 10, Table2.Rows[j].Height));
                }
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[0].Width + 10, Table2.Rows[j].Height));
                if (Table2.Rows[j].Cells[0].Value != null)
                {
                    e.Graphics.DrawString(Table2.Rows[j].Cells[0].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[0].Width + 10, Table2.Rows[j].Height));
                }
                else
                {
                    e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[0].Width + 10, Table2.Rows[j].Height));
                }
                width = width + Table2.Columns[0].Width + 10;

                if (Table2.Rows[j].Cells[1].Style.BackColor.Name == "Pink")
                {
                    e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table2.Columns[1].Width + 10, Table2.Rows[j].Height));
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[1].Width + 10, Table2.Rows[j].Height));
                }
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[1].Width + 10, Table2.Rows[j].Height));
                if (Table2.Rows[j].Cells[1].Value != null)
                {
                    e.Graphics.DrawString(Table2.Rows[j].Cells[1].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[1].Width + 10, Table2.Rows[j].Height));
                }
                else
                {
                    e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[1].Width + 10, Table2.Rows[j].Height));
                }
                width = width + Table2.Columns[1].Width + 10;
                for (int i = 0; i < Table2.Columns.Count - NoCaIzm1 * 2 - 2; i++)
                {
                    if (Table2.Rows[j].Cells[k].Style.BackColor.Name == "Pink")
                    {
                        e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                    }
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                    if (Table2.Rows[j].Cells[k].Value != null)
                    {
                        e.Graphics.DrawString(Table2.Rows[j].Cells[k].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                    }
                    width = width + Table2.Columns[k].Width + 10;
                    k++;
                }
                cordY = height;
                height += Table2.Rows[j].Height;
                width = width1;
                k = NoCaIzm1 * 2 + 2;
            }
            /*Cancel*/
        }

        /*Если больше 7*/
        public void Table2PrintViewer3(object sender, PrintPageEventArgs e)
        {
            int height = 560;
            int width = 25;
            Pen p = new Pen(Brushes.Black, 1.5f);
            if (prinPage <= 0)
            {
                e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[0].Width + 5, Table2.Rows[0].Height * 2));
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[0].Width + 5, Table2.Rows[0].Height * 2));
                e.Graphics.DrawString(Table2.Columns[0].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[0].Width + 5, Table2.Rows[0].Height * 2));
                width = width + Table2.Columns[0].Width + 5;
                e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[1].Width, Table2.Rows[1].Height * 2));
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[1].Width, Table2.Rows[1].Height * 2));
                e.Graphics.DrawString(Table2.Columns[1].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[1].Width, Table2.Rows[0].Height * 2));
                width = width + Table2.Columns[1].Width;

                int k = 2;
                for (int i = 0; i < 10; i++)
                {
                    e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[0].Height * 2));
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[0].Height * 2));
                    e.Graphics.DrawString(Table2.Columns[k].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[k].Width + 10, Table2.Rows[0].Height * 2));
                    width = width + Table2.Columns[k].Width + 10;
                    k++;
                }


                height = height + Table2.Rows[0].Height * 2;
                /* Формируем значения */
                width = 25;
                int height1 = height;
                int width1_1 = width;


                for (int j = 0; j < Table2.Rows.Count - 1; j++)
                {
                    if (Table2.Rows[j].Cells[0].Style.BackColor.Name == "Pink")
                    {
                        e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table2.Columns[0].Width + 10, Table2.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[0].Width + 10, Table2.Rows[j].Height));
                    }
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[0].Width + 5, Table2.Rows[j].Height));
                    e.Graphics.DrawString(Table2.Rows[j].Cells[0].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[0].Width + 5, Table2.Rows[j].Height));
                    // width = width + Table2.Columns[0].Width;
                    height += Table2.Rows[j].Height;
                }
                height = height1;
                width = width + Table2.Columns[0].Width + 5;
                for (int j = 0; j < Table2.Rows.Count - 1; j++)
                {
                    if (Table2.Rows[j].Cells[1].Style.BackColor.Name == "Pink")
                    {
                        e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table2.Columns[1].Width + 10, Table2.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[1].Width + 10, Table2.Rows[j].Height));
                    }
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[1].Width, Table2.Rows[j].Height));
                    if (Table2.Rows[j].Cells[1].Value != null)
                    {
                        e.Graphics.DrawString(Table2.Rows[j].Cells[1].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[1].Width, Table2.Rows[j].Height));

                    }
                    else
                    {
                        e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[1].Width, Table2.Rows[j].Height));
                    }
                    // width = width + Table2.Columns[1].Width;
                    height += Table2.Rows[j].Height;
                }
                height = height1;
                width = width + Table2.Columns[1].Width;

                int width1 = width;
                k = 2;
                for (int j = 0; j < Table2.Rows.Count - 1; j++)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (Table2.Rows[j].Cells[k].Style.BackColor.Name == "Pink")
                        {
                            e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                        }
                        else
                        {
                            e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                        }
                        e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                        if (Table2.Rows[j].Cells[k].Value != null)
                        {
                            e.Graphics.DrawString(Table2.Rows[j].Cells[k].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                        }
                        else
                        {
                            e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                        }
                        width = width + Table2.Columns[k].Width + 10;
                        k++;
                        //width1_1 = width;
                    }
                    height += Table2.Rows[j].Height;
                    width = width1;
                    k = 2;
                }
                /*Cancel*/

                if (Table2.Rows.Count <= 10)
                {
                    height = height + 10;
                    width = 25;
                    k = 12;
                    //k = 11;
                    for (int i = 0; i < NoCaIzm1 * 2 - 10; i++)
                    {
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[0].Height * 2));
                        e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[0].Height * 2));
                        e.Graphics.DrawString(Table2.Columns[k].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[k].Width + 10, Table2.Rows[0].Height * 2));
                        width = width + Table2.Columns[k].Width + 10;
                        k++;
                    }

                    for (int i = 0; i < Table2.Columns.Count - NoCaIzm1 * 2 - 2; i++)
                    {
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[0].Height * 2));
                        e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[0].Height * 2));
                        e.Graphics.DrawString(Table2.Columns[k].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[k].Width + 10, Table2.Rows[0].Height * 2));
                        width = width + Table2.Columns[k].Width + 10;
                        k++;
                        // height = height + Table2.Rows[i].Height;
                    }

                    /*Формируем вторую часть значений*/

                    height = height + Table2.Rows[0].Height * 2;
                    height1 = height;
                    width1 = 25;
                    width = 25;
                    k = 12;
                    for (int j = 0; j < Table2.Rows.Count - 1; j++)
                    {
                        for (int i = 0; i < NoCaIzm1 * 2 - 10; i++)
                        {
                            if (Table2.Rows[j].Cells[k].Style.BackColor.Name == "Pink")
                            {
                                e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                            }
                            else
                            {
                                e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                            }
                            e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                            if (Table2.Rows[j].Cells[k].Value != null)
                            {
                                e.Graphics.DrawString(Table2.Rows[j].Cells[k].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                            }
                            else
                            {
                                e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                            }
                            width = width + Table2.Columns[k].Width + 10;
                            k++;
                            //width1_1 = width;
                        }
                        height += Table2.Rows[j].Height;
                        width = width1;
                        k = 12;
                    }
                    width = (Table2.Columns[10].Width + 10) * (NoCaIzm1 * 2 - 10) + width;
                    width1 = width;
                    height = height1;
                    k = 2 + NoCaIzm1 * 2;
                    for (int j = 0; j < Table2.Rows.Count - 1; j++)
                    {
                        for (int i = 0; i < Table2.Columns.Count - NoCaIzm1 * 2 - 2; i++)
                        {
                            if (Table2.Rows[j].Cells[k].Style.BackColor.Name == "Pink")
                            {
                                e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                            }
                            else
                            {
                                e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                            }
                            e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                            if (Table2.Rows[j].Cells[k].Value != null)
                            {
                                e.Graphics.DrawString(Table2.Rows[j].Cells[k].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                            }
                            else
                            {
                                e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                            }
                            width = width + Table2.Columns[k].Width + 10;
                            k++;
                        }
                        cordY = height;
                        height += Table2.Rows[j].Height;
                        width = width1;
                        k = 2 + NoCaIzm1 * 2;
                    }
                    /*Cancel*/
                }
                else
                {
                    e.Graphics.DrawString("Страница " + (prinPage + 1) + " из 2", new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular), Brushes.Black, 300, 1100);
                    e.HasMorePages = true;
                    prinPage++;

                    cordY = 50;
                    return;
                }
            }
        }

        public void Table2PageAdd2(object sender, PrintPageEventArgs e)
        {
            int height = 80;
            int width = 25;
            Pen p = new Pen(Brushes.Black, 1.5f);
            int k = 12;

            for (int i = 0; i < NoCaIzm1 * 2 - 10; i++)
            {
                e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[0].Height * 2));
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[0].Height * 2));
                e.Graphics.DrawString(Table2.Columns[k].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[k].Width + 10, Table2.Rows[0].Height * 2));
                width = width + Table2.Columns[k].Width + 10;
                k++;
            }

            for (int i = 0; i < Table2.Columns.Count - NoCaIzm1 * 2 - 2; i++)
            {
                e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[0].Height * 2));
                e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[0].Height * 2));
                e.Graphics.DrawString(Table2.Columns[k].HeaderText, new System.Drawing.Font("Times New Roman", 12, FontStyle.Bold), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[k].Width + 10, Table2.Rows[0].Height * 2));
                width = width + Table2.Columns[k].Width + 10;
                k++;
                // height = height + Table2.Rows[i].Height;
            }

            /*Формируем вторую часть значений*/

            height = height + Table2.Rows[0].Height * 2;
            height1 = height;
            int width1 = 25;
            width = 25;
            k = 12;
            for (int j = 0; j < Table2.Rows.Count - 1; j++)
            {
                for (int i = 0; i < NoCaIzm1 * 2 - 10; i++)
                {
                    if (Table2.Rows[j].Cells[k].Style.BackColor.Name == "Pink")
                    {
                        e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                    }
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                    if (Table2.Rows[j].Cells[k].Value != null)
                    {
                        e.Graphics.DrawString(Table2.Rows[j].Cells[k].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                    }
                    width = width + Table2.Columns[k].Width + 10;
                    k++;
                    //width1_1 = width;
                }
                height += Table2.Rows[j].Height;
                width = width1;
                k = 12;
            }
            width = (Table2.Columns[10].Width + 10) * (NoCaIzm1 * 2 - 10) + width;
            width1 = width;
            height = height1;
            k = 2 + NoCaIzm1 * 2;
            for (int j = 0; j < Table2.Rows.Count - 1; j++)
            {
                for (int i = 0; i < Table2.Columns.Count - NoCaIzm1 * 2 - 2; i++)
                {
                    if (Table2.Rows[j].Cells[k].Style.BackColor.Name == "Pink")
                    {
                        e.Graphics.FillRectangle(Brushes.Pink, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.FillRectangle(Brushes.White, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                    }
                    e.Graphics.DrawRectangle(p, new System.Drawing.Rectangle(width, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                    if (Table2.Rows[j].Cells[k].Value != null)
                    {
                        e.Graphics.DrawString(Table2.Rows[j].Cells[k].Value.ToString(), new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                    }
                    else
                    {
                        e.Graphics.DrawString("", new System.Drawing.Font("Times New Roman", 10, FontStyle.Regular), Brushes.Black, new System.Drawing.Rectangle(width + 10, height, Table2.Columns[k].Width + 10, Table2.Rows[j].Height));
                    }
                    width = width + Table2.Columns[k].Width + 10;
                    k++;
                }
                cordY = height;
                height += Table2.Rows[j].Height;
                width = width1;
                k = 2 + NoCaIzm1 * 2;
            }
            /*Cancel*/
        }
        public void Table2Create()
        {
            Podskazka.Text = "Измерьте 0 Asb/100%T";
            label25.Visible = false;
            label26.Visible = false;
            label59.Visible = true;

            textBox8.Text = Description;
            F1Text.Text = F1;
            F2Text.Text = F2;

            IzmerenieOpen = true;
            параметрыToolStripMenuItem.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            if (ComPodkl == true)
            {
                IzmerCreate1 = true;

            }
            else
            {
                IzmerCreate1 = false;
            }
            if (IzmerCreate == true)
            {
                button14.Enabled = true;
            }
            else
            {
                button14.Enabled = false;
            }
            // Podskazka.Text = "Измеряйте или введите значения!";
            label27.Visible = false;
            label24.Visible = false;
            label25.Visible = false;
            label26.Visible = false;
            // label28.Visible = true;
            // label33.Visible = true;
            WLREMOVE2();
            WLREMOVESTR2();
            WLADD2();
            WLADDSTR2();
        }
        public void WLREMOVE2()
        {
            while (true)
            {
                int i = Table2.Columns.Count - 1;//С какого столбца начать
                if (Table2.Columns[i].Name == "Obrazec")
                    break;
                Table2.Columns.RemoveAt(i);
            }

        }

        public void WLADD2()
        {
            if (NoCaIzm1 >= 2)
            {
                for (int i = 1; i <= NoCaIzm1; i++)
                {

                    DataGridViewTextBoxColumn firstColumn2 =
                    new DataGridViewTextBoxColumn();
                    firstColumn2.HeaderText = "A; Сер." + i;
                    firstColumn2.Name = "A;Ser" + i;
                    firstColumn2.ValueType = Type.GetType("System.Double");
                    Table2.Columns.Add(firstColumn2);
                    DataGridViewTextBoxColumn firstColumn3 =
                    new DataGridViewTextBoxColumn();
                    firstColumn3.HeaderText = "C, " + edconctr + "; Сер." + i;
                    firstColumn3.Name = "C,edconctr;Ser." + i;
                    firstColumn3.ValueType = Type.GetType("System.Double");
                    Table2.Columns.Add(firstColumn3);
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
                Table2.Columns.Add(firstColumn2_1);
                DataGridViewTextBoxColumn firstColumn3_1 =
                new DataGridViewTextBoxColumn();
                firstColumn3_1.HeaderText = "C, " + edconctr + "; Сер." + 1;
                firstColumn3_1.Name = "C,edconctr;Ser." + 1;
                firstColumn3_1.ValueType = Type.GetType("System.Double");
                Table2.Columns.Add(firstColumn3_1);
                firstColumn3_1.ReadOnly = true;
                firstColumn3_1.Width = 50;
                firstColumn2_1.Width = 50;
            }
            if (selet_rezim == 2)
            {
                DataGridViewTextBoxColumn firstColumn4 =
                new DataGridViewTextBoxColumn();
                firstColumn4.HeaderText = "Cср, " + edconctr;
                firstColumn4.Name = "Ccr";
                firstColumn4.ValueType = Type.GetType("System.Double");
                Table2.Columns.Add(firstColumn4);
                firstColumn4.ReadOnly = true;
                DataGridViewTextBoxColumn firstColumn5 =
                new DataGridViewTextBoxColumn();
                firstColumn5.HeaderText = "d, %";
                firstColumn5.Name = "d%";
                firstColumn5.ValueType = Type.GetType("System.Double");
                firstColumn5.ReadOnly = true;
                Table2.Columns.Add(firstColumn5);
                firstColumn4.Width = 100;
                firstColumn5.Width = 50;
            }


        }
        public void WLADDSTR2()
        {
            count = 0;
            if (USE_KO == false)
            {
                if (NoCaSer1 > 1)
                {
                    for (int i = 1; i <= NoCaSer1; i++)
                    {
                        Table2.Rows.Add(i);
                        Table2.Rows[count].Cells["Column1"].Value = count + 1;
                        count++;
                    }
                }
                else
                {
                    Table2.Rows.Add(1);
                    Table2.Rows[count].Cells["Column1"].Value = count + 1;
                    count++;
                    Table2.Rows.Add(1);
                }
                for (int i = 0; i < Table2.RowCount - 1; i++)
                {

                    if (Table2.Rows[i].Cells["Column1"].Value == null)
                    {
                        Table2.Rows.RemoveAt(i);
                        i--;
                    }
                }
            }
            else
            {

                if (NoCaSer1 > 1)
                {
                    Table2.Rows.Add(0, "Контрольный", string.Format("{0:0.0000}", 0));
                    Table2.Rows[count].Cells["Column1"].Value = count;
                    count++;
                    for (int i = 1; i <= NoCaSer1; i++)
                    {
                        Table2.Rows.Add(i);
                        Table2.Rows[count].Cells["Column1"].Value = count;
                        count++;
                    }
                }
                else
                {
                    Table2.Rows.Add(0, "Контрольный", string.Format("{0:0.0000}", 0));
                    Table2.Rows[count].Cells["Column1"].Value = count;
                    count++;
                    Table2.Rows.Add(1, "");
                    Table2.Rows[count].Cells["Column1"].Value = count;
                    Table2.Rows.Add(1);
                }
                for (int i = 0; i < Table2.RowCount - 1; i++)
                {

                    if (Table2.Rows[i].Cells["Column1"].Value == null)
                    {
                        Table2.Rows.RemoveAt(i);
                        i--;
                    }
                }
            }
            //Table2.Rows.Add();
            Table2.CurrentCell = this.Table2[2, 0];
            for (int i = 1; i <= NoCaIzm1; i++)
            {
                Table2.Rows[0].Cells["C,edconctr;Ser." + i].ReadOnly = true;
                if (selet_rezim == 2)
                {
                    Table2.Rows[0].Cells["Ccr"].ReadOnly = true;
                    Table2.Rows[0].Cells["d%"].ReadOnly = true;
                }
            }
            Table2.Rows[Table2.RowCount - 1].ReadOnly = true;
            button11.Enabled = true;

        }

        public void WLREMOVESTR2()
        {
            Table2.Rows.Clear();

        }
        public void GradTable()
        {

            if (ComPort == true && SposobZadan != "Ввод коэффициентов")
            {
                Podskazka.Text = "Измерьте 0 Asb/100%T";
                label25.Visible = false;
                label26.Visible = false;
                label59.Visible = true;
            }
            if (ComPort != false)
            {
                GWNew.Text = string.Format("{0:0.0}", wavelength1);
                SW sw = new SW(this);
                SAGE sage = new SAGE(ref countSA, ref GE5_1_0, ref versionPribor, ref newPort, ref ResponseModeNormal);
            }

            textBox10.Text = string.Format("{0:0.0}", wavelength1);

            dateTimePicker1.Text = DateTime;

            textBox1.Text = Description;

            numericUpDown1.Text = Convert.ToString(Days);

            textBox2.Text = WidthCuvette;

            textBox11.Text = Veshestvo1;

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();



            WLREMOVE1();
            WLREMOVESTR1();
            button10.Enabled = true;
            switch (SposobZadan)
            {
                case "Ввод коэффициентов":

                    AgroText0.Text = string.Format("{0:0.0000}", k0);
                    AgroText1.Text = string.Format("{0:0.0000}", k1);
                    AgroText2.Text = string.Format("{0:0.0000}", k2);
                    if (aproksim == "Линейная через 0")
                    {
                        label14.Text = "A(C) = " + k1.ToString("0.0000 ;- 0.0000 ") + "*C";
                        for (double i = 0; i <= 3; i++)
                        {
                            double x2 = i;
                            double y2 = i * k1;
                            chart1.Series[1].Points.AddXY(x2, y2);

                            chart1.Series[0].Enabled = false;
                            chart1.ChartAreas[0].AxisX.Title = "Концетрация, " + edconctr;
                            chart1.ChartAreas[0].AxisY.Title = "Оптическая плотность, А";
                            chart1.ChartAreas[0].AxisX.Minimum = 0;

                            chart1.ChartAreas[0].AxisY.Minimum = 0;
                        }
                        if (aproksim == "Линейная")
                        {
                            label14.Text = "A(C) = " + k1.ToString("0.0000 ;- 0.0000 ") + "*C" + k0.ToString(" + 0.0000 ;- 0.0000 ");
                            for (double i = 0; i <= 3; i++)
                            {
                                double x2 = i;
                                double y2 = i * k1 + k0;
                                chart1.Series[1].Points.AddXY(x2, y2);
                                chart1.Series[0].Enabled = false;

                                chart1.ChartAreas[0].AxisX.Title = "Концетрация, " + edconctr;
                                chart1.ChartAreas[0].AxisY.Title = "Оптическая плотность, А";
                                chart1.ChartAreas[0].AxisX.Minimum = 0;

                                chart1.ChartAreas[0].AxisY.Minimum = 0;
                            }
                        }
                        else
                        {
                            label14.Text = "A(C) = " + k0.ToString(" 0.0000 ;- 0.0000 ") + k1.ToString(" + 0.0000 ;- 0.0000 ") + "*C" + k2.ToString(" + 0.0000 ;- 0.0000 ") + "*C^2";
                            for (double i = 0; i <= 3; i++)
                            {
                                double x2 = i;
                                double y2 = i * k1 + k0 + i * k2 * k2;
                                chart1.Series[0].Enabled = false;
                                chart1.Series[1].Points.AddXY(x2, y2);

                                chart1.ChartAreas[0].AxisX.Title = "Концетрация, " + edconctr;
                                chart1.ChartAreas[0].AxisY.Title = "Оптическая плотность, А";
                                chart1.ChartAreas[0].AxisX.Minimum = 0;

                                chart1.ChartAreas[0].AxisY.Minimum = 0;
                            }
                        }
                    }
                    functionA();
                    break;
                default:
                    NoCaIzm = Convert.ToInt32(CountSeriya);
                    NoCaSer = Convert.ToInt32(CountInSeriya);

                    AgroText0.Text = string.Format("0.0000", 0);
                    AgroText1.Text = string.Format("0.0000", 0);
                    AgroText2.Text = string.Format("0.0000", 0);
                    WLADD1();
                    WLADDSTR1();
                    Table1.Visible = true;
                    break;

            }




        }
        public void WLADD1()
        {

            for (int i = 1; i <= NoCaIzm; i++)
            {

                DataGridViewTextBoxColumn firstColumn1 =
                new DataGridViewTextBoxColumn();
                firstColumn1.HeaderText = "A; Сер" + i;
                firstColumn1.Name = "A;Ser (" + i;
                firstColumn1.ValueType = Type.GetType("System.Double");

                Table1.Columns.Add(firstColumn1);

            }

            for (int i = 1; i <= NoCaIzm; i++)
            {
                Table1.Columns["A;Ser (" + i].Width = 50;
            }
            Table1.Columns[1].HeaderText = "Конц " + edconctr;
        }

        public void WLADDSTR1()
        {
            if (USE_KO == true)
            {

                Table1.Rows.Add(0, Convert.ToDouble(0.000));

                for (int i = 1; i <= NoCaSer; i++)
                {
                    Table1.Rows.Add(i, textBoxCO[i - 1].Text);


                }

                Table1.CurrentCell = Table1[3, 0];

            }
            else
            {
                for (int i = 1; i <= NoCaSer; i++)
                {
                    Table1.Rows.Add(i, textBoxCO[i - 1].Text);


                }

                Table1.CurrentCell = Table1[3, 0];
            }
            for (int i = 1; i <= NoCaIzm; i++)
            {
                if (USE_KO == false)
                {
                    Table1.Rows[NoCaSer].Cells["A;Ser (" + i].ReadOnly = true;
                }
                else
                {
                    Table1.Rows[NoCaSer + 1].Cells["A;Ser (" + i].ReadOnly = true;
                }
            }

            if (USE_KO == false)
            {
                Table1.Rows[NoCaSer].Cells["NoCo"].ReadOnly = true;
                Table1.Rows[NoCaSer].Cells["Concetr"].ReadOnly = true;
                Table1.Rows[NoCaSer].Cells["Asred"].ReadOnly = true;
            }
            else
            {
                Table1.Rows[NoCaSer + 1].Cells["NoCo"].ReadOnly = true;
                Table1.Rows[NoCaSer + 1].Cells["Concetr"].ReadOnly = true;
                Table1.Rows[NoCaSer + 1].Cells["Asred"].ReadOnly = true;
            }

            button11.Enabled = true;
        }
        public void WLREMOVE1()
        {
            while (true)
            {
                int i = Table1.Columns.Count - 1;//С какого столбца начать
                if (Table1.Columns[i].Name == "Asred")
                    break;
                Table1.Columns.RemoveAt(i);
            }

        }
        public void WLREMOVESTR1()
        {
            Table1.Rows.Clear();

        }
        public void functionA()
        {
            groupBox2.Enabled = false;
            groupBox5.Enabled = false;
            groupBox3.Enabled = false;
            RR.Text = "";
            SKO.Text = "";
            label21.Text = "";
            label22.Text = "";
            // chart1.Series[0].Points.Clear();
            //   chart1.Series[1].Points.Clear();
            if (Zavisimoct == "A(C)")
            {
                if (aproksim == "Линейная через 0")
                {

                    label14.Text = "A(C) = " + k1.ToString("0.0000 ;- 0.0000 ") + "*C";
                    double x2 = 0;
                    for (double i = 0; i < 5; i = i + 0.5)
                    {
                        double y2 = i * k1;
                        chart1.Series[1].Points.AddXY(i, y2);
                        chart1.Series[1].ChartType = SeriesChartType.Line;
                        chart1.ChartAreas[0].AxisX.Title = "Концетрация, " + edconctr;
                        chart1.ChartAreas[0].AxisY.Title = "Оптическая плотность, А";
                        chart1.ChartAreas[0].AxisX.Minimum = 0;

                        chart1.ChartAreas[0].AxisY.Minimum = 0;
                        x2 = i;
                    }
                    double xfin = x2 * 1.1;
                    double yfin = xfin * k1;
                    chart1.Series[1].Points.AddXY(xfin, yfin);
                }
                else
                {
                    if (aproksim == "Линейная")
                    {
                        label14.Text = "A(C) = " + k0.ToString("0.0000 ;- 0.0000 ") + k1.ToString("+ 0.0000 ;- 0.0000 ") + "*C ";
                        double x2 = 0;
                        for (double i = 0; i < 5; i = i + 0.5)
                        {
                            double y2 = i * k1 + k0;
                            chart1.Series[1].Points.AddXY(i, y2);
                            chart1.Series[1].ChartType = SeriesChartType.Line;
                            chart1.ChartAreas[0].AxisX.Title = "Концетрация, " + edconctr;
                            chart1.ChartAreas[0].AxisY.Title = "Оптическая плотность, А";
                            chart1.ChartAreas[0].AxisX.Minimum = 0;

                            chart1.ChartAreas[0].AxisY.Minimum = 0;
                            x2 = i;
                        }
                        double xfin = x2 * 1.1;
                        double yfin = xfin * k1 + k0;
                        chart1.Series[1].Points.AddXY(xfin, yfin);
                    }
                    else
                    {
                        label14.Text = "A(C) = " + k0.ToString("0.0000 ;- 0.0000 ") + k1.ToString("+ 0.0000 ;- 0.0000 ") + "*C " + k2.ToString("+ 0.0000 ;- 0.0000 ") + "*C^2";
                        double x2 = 0;
                        for (double i = 0; i < 5; i = i + 0.5)
                        {
                            double y2 = i * k1 + i * i * k2 + k0;
                            chart1.Series[1].Points.AddXY(i, y2);
                            chart1.Series[1].ChartType = SeriesChartType.Line;
                            chart1.ChartAreas[0].AxisX.Title = "Концетрация, " + edconctr;
                            chart1.ChartAreas[0].AxisY.Title = "Оптическая плотность, А";
                            chart1.ChartAreas[0].AxisX.Minimum = 0;

                            chart1.ChartAreas[0].AxisY.Minimum = 0;
                            x2 = i;
                        }
                        double xfin = x2 * 1.1;
                        double yfin = xfin * k1;
                        chart1.Series[1].Points.AddXY(xfin, yfin);
                    }


                }
            }
            else
            {
                if (aproksim == "Линейная через 0")
                {
                    label14.Text = "C(A) = " + k1.ToString("0.0000 ;- 0.0000 ") + "*A";
                    double x2 = 0;
                    for (double i = 0; i < 5; i = i + 0.5)
                    {
                        double y2 = i * k1;
                        chart1.Series[1].Points.AddXY(i, y2);
                        chart1.Series[1].ChartType = SeriesChartType.Line;
                        chart1.ChartAreas[0].AxisX.Title = "Оптическая плотность, А";
                        chart1.ChartAreas[0].AxisY.Title = "Концетрация, " + edconctr;
                        chart1.ChartAreas[0].AxisX.Minimum = 0;

                        chart1.ChartAreas[0].AxisY.Minimum = 0;
                        x2 = i;
                    }
                    double xfin = x2 * 1.1;
                    double yfin = xfin * k1;
                    chart1.Series[1].Points.AddXY(xfin, yfin);
                }
                else
                {
                    if (aproksim == "Линейная")
                    {
                        label14.Text = "C(A) = " + k0.ToString("0.0000 ;- 0.0000 ") + k1.ToString("+ 0.0000 ;- 0.0000 ") + "*A ";
                        double x2 = 0;
                        for (double i = 0; i < 5; i = i + 0.5)
                        {
                            double y2 = i * k1 + k0;
                            chart1.Series[1].Points.AddXY(i, y2);
                            chart1.Series[1].ChartType = SeriesChartType.Line;
                            chart1.ChartAreas[0].AxisX.Title = "Оптическая плотность, А";
                            chart1.ChartAreas[0].AxisY.Title = "Концетрация, " + edconctr;
                            chart1.ChartAreas[0].AxisX.Minimum = 0;

                            chart1.ChartAreas[0].AxisY.Minimum = 0;
                            x2 = i;
                        }
                        double xfin = x2 * 1.1;
                        double yfin = xfin * k1;
                        chart1.Series[1].Points.AddXY(xfin, yfin);
                    }
                    else
                    {
                        label14.Text = "C(A) = " + k0.ToString("0.0000 ;- 0.0000 ") + k1.ToString("+ 0.0000 ;- 0.0000 ") + "*A " + k2.ToString("+ 0.0000 ;- 0.0000 ") + "*A^2";
                        double x2 = 0;
                        for (double i = 0; i < 5; i = i + 0.5)
                        {
                            double y2 = i * k1 + i * k2 + k0;
                            chart1.Series[1].Points.AddXY(i, y2);
                            chart1.Series[1].ChartType = SeriesChartType.Line;
                            chart1.ChartAreas[0].AxisX.Title = "Оптическая плотность, А";
                            chart1.ChartAreas[0].AxisY.Title = "Концетрация, " + edconctr;
                            chart1.ChartAreas[0].AxisX.Minimum = 0;

                            chart1.ChartAreas[0].AxisY.Minimum = 0;
                            x2 = i;
                        }
                        double xfin = x2 * 1.1;
                        double yfin = xfin * k1;
                        chart1.Series[1].Points.AddXY(xfin, yfin);
                    }

                }
            }
            новыйToolStripMenuItem.Enabled = false;
            сохранитьToolStripMenuItem.Enabled = true;
            эксопртВPDFToolStripMenuItem.Enabled = false;
            экспортToolStripMenuItem.Enabled = false;
            печатьToolStripMenuItem1.Enabled = true;
            параметрыToolStripMenuItem.Enabled = true;
            измеритьToolStripMenuItem.Enabled = false;
            калибровкаToolStripMenuItem.Enabled = false;
            //   справкаToolStripMenuItem.Visible = false;
            button1.Enabled = false;
            button3.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = true;
            button12.Enabled = false;
            button14.Enabled = false;
            button11.Enabled = false;

            label27.Visible = true;
            label59.Visible = false;
            label24.Visible = false;
            Podskazka.Text = "Сохраните градуировку";

        }
        public void SW_Scan()
        {
            Application.DoEvents();
            string SWText1 = ScanTable.Rows[countscan].Cells[0].Value.ToString();
            //double Walve_double = Convert.ToDouble(ScanTable.Rows[countscan].Cells[0].Value.ToString().Replace(".", ","));
            newPort.Write("SW " + ScanTable.Rows[countscan].Cells[0].Value.ToString().Replace(".", ",") + "\r");
            string indata = "";
            while (indata.Contains(">") == false)
            {
                indata = newPort.ReadExisting();
            }
            GWNew.Text = string.Format("{0:0.0}", ScanTable.Rows[countscan].Cells[0].Value.ToString());
            Application.DoEvents();
        }
        public void SAGEScan(ref int countSA, ref string GE5_1_0)
        {
            Regex regex1 = new Regex(@"\D");
            Regex regex = new Regex(@"\W");

            if (versionPribor.Contains("2"))
            { countSA = 8; }
            else
            {
                countSA = 4;
            }
            LogoForm logoform1 = new LogoForm();

            newPort.Write("SA " + countSA + "\r");
            string indata = "";
            while (indata.Contains(">") == false)
            {
                indata = newPort.ReadExisting();
            }

            newPort.Write("GE 1\r");
            if (ResponseModeNormal == true)
            {
                if (versionPribor.Contains("2"))
                {
                    Thread.Sleep(3);
                }
                else
                {
                    Thread.Sleep(1000);
                }
            }
            else
            {
                //Thread.Sleep(1000);
            }
            
            string indata_0 = "";

            while (indata_0.Contains("\r>") == false){
                indata = newPort.ReadExisting();
                indata_0 += indata;
            }
            int index = 0;
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

            string GE5_1 = regex.Replace(indata_0, "");
            GE5_1 = regex1.Replace(GE5_1, "");
            GE5_1_0 = GE5_1;

            while (Convert.ToInt32(GE5_1) > 10000 && countSA > 1)
            {
                countSA--;
                newPort.Write("SA " + countSA + "\r");
                indata = "";
                while (indata.Contains(">") == false)
                {
                    indata = newPort.ReadExisting();
                }

                newPort.Write("GE 1\r");
                if (ResponseModeNormal == true)
                {
                    if (versionPribor.Contains("2"))
                    {
                        Thread.Sleep(3);
                    }
                    else
                    {
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    //Thread.Sleep(1000);
                }

                indata_0 = "";

                while (indata_0.Contains("\r>") == false)
                {
                    indata = newPort.ReadExisting();
                    indata_0 += indata;
                }
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

                GE5_1 = regex.Replace(indata_0, "");
                GE5_1 = regex1.Replace(GE5_1, "");
                GE5_1_0 = GE5_1;
            }
            scan_mass[countscan] = Convert.ToDouble(GE5_1_0);
            scan_massSA[countscan] = Convert.ToDouble(countSA);
            SWF.Application.OpenForms["LogoForm"].Close();

        }
        public void TableScan()
        {
            double[] massWL = new double[ScanTable.Rows.Count - 1];
            double[] massGE = new double[ScanTable.Rows.Count - 1];
            double[] massABS = new double[ScanTable.Rows.Count - 1];
            double[] massT = new double[ScanTable.Rows.Count - 1];
            Regex regex = new Regex(@"\W");
            Regex regex1 = new Regex(@"\D");
            countscan = 0;

            while ((countscan != ScanTable.Rows.Count - 1) && (StopSpectr != true) && label56.Text != "0")
            {
                double GEIZMERmass = 0;
                string GE5Izmer = "";
                while (GE5Izmer == "")
                {
                    SW_Scan();
                    newPort.Write("SA " + scan_massSA[countscan] + "\r");

                    string indata = "";
                    while (indata.Contains(">") == false)
                    {
                        indata = newPort.ReadExisting();
                    }

                    for (int j = 0; j < 10; j++)
                    {
                        newPort.Write("GE 1\r");

                        if (ResponseModeNormal == true)
                        {
                            if (versionPribor.Contains("2"))
                            {
                                Thread.Sleep(3);
                            }
                            else
                            {
                                Thread.Sleep(1000);
                            }
                        }
                        else
                        {
                            //Thread.Sleep(1000);
                        }

                        string indata_0 = "";

                        while (indata_0.Contains("\r>") == false)
                        {
                            indata = newPort.ReadExisting();
                            indata_0 += indata;
                        }
                        int index = 0;
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
                        GE5Izmer = regex.Replace(indata_0, "");
                        GE5Izmer = regex1.Replace(GE5Izmer, "");
                        GEIZMERmass += Convert.ToDouble(GE5Izmer);
                    }
                }
                GEIZMERmass = GEIZMERmass / 10;
                GE5Izmer = Convert.ToString(GEIZMERmass);

                massWL[countscan] = Convert.ToDouble(ScanTable.Rows[countscan].Cells[0].Value);
                
                massABS[countscan] = Convert.ToDouble(string.Format("{0:0.0000}",
                    Math.Log10((Convert.ToDouble(scan_mass[countscan]) -
                    Convert.ToDouble(RDstring[Convert.ToInt32(scan_massSA[countscan])])) /
                    (Convert.ToDouble(GE5Izmer) - Convert.ToDouble(RDstring[Convert.ToInt32(scan_massSA[countscan])])))));

                massT[countscan] = Convert.ToDouble(string.Format("{0:0.00}",
                        ((Convert.ToDouble(GE5Izmer) - Convert.ToDouble(RDstring[countSA])) /
                        (Convert.ToDouble(scan_mass[countscan]) - Convert.ToDouble(RDstring[countSA])) * 100)));

                if (ScanTable.Columns[1].HeaderText == "Abs")
                    massGE[countscan] = massABS[countscan];
                else
                    massGE[countscan] = massT[countscan];

                //Array.Sort(massWL);
                //Array.Sort(massGE);

                double x1 = Convert.ToDouble(ScanTable.Rows[countscan].Cells[0].Value);
                double y1 = massGE[countscan];

                ScanChart.Series[countButtonClick + 1].Points.AddXY(x1, y1);
                ScanChart.Series[countButtonClick + 1].ChartType = SeriesChartType.Line;

                if (massABS[countscan].ToString() != null && massT[countscan].ToString() != null)
                {
                    ScanChart.ChartAreas[0].AxisX.Minimum = cancel;
                    ScanChart.ChartAreas[0].AxisX.Maximum = start;

                }
                ScanChart.ChartAreas[0].AxisX.MajorGrid.Enabled = true;
                ScanChart.ChartAreas[0].AxisY.MajorGrid.Enabled = true;
                ScanChart.ChartAreas[0].AxisX.Title = ScanTable.Columns["WalveDl"].HeaderText;
                ScanChart.ChartAreas[0].AxisY.Title = ScanTable.Columns["Abs_scan"].HeaderText;
                countscan++;

            }
            double max = 0.0;
            double min = 0.0;
            for (int i = 0; i < ScanTable.Rows.Count - 1; i++)
            {
                if (ScanTable.Columns[1].HeaderText == "Abs")
                {
                    ScanTable.Rows[i].Cells[1].Value = massABS[i];
                    
                    ScanTable.Rows[i].Cells[2].Value = massT[i];
                }
                else
                {
                    ScanTable.Rows[i].Cells[2].Value = massABS[i];
                    ScanTable.Rows[i].Cells[1].Value = massT[i];

                }
            }

            for (int i = 0; i < ScanTable.Rows.Count; i++)
            {
                if (i == 0)
                {
                    if (Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value) > Convert.ToDouble(ScanTable.Rows[i + 1].Cells[1].Value))
                    {
                        max = Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value);
                        dataGridView1.Rows.Add(ScanTable.Rows[i].Cells[0].Value, ScanTable.Rows[i].Cells[1].Value, ScanTable.Rows[i].Cells[2].Value);
                        min = max;
                        double x1 = Convert.ToDouble(ScanTable.Rows[i].Cells[0].Value);
                        double y1 = Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value);
                        ScanChart.Series[0].Points.AddXY(x1, y1);
                        ScanChart.Series[0].ChartType = SeriesChartType.Point;
                    }
                    else
                    {
                        min = Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value);
                        dataGridView2.Rows.Add(ScanTable.Rows[i].Cells[0].Value, ScanTable.Rows[i].Cells[1].Value, ScanTable.Rows[i].Cells[2].Value);
                        max = min;
                        double x1 = Convert.ToDouble(ScanTable.Rows[i].Cells[0].Value);
                        double y1 = Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value);
                        ScanChart.Series[0].Points.AddXY(x1, y1);
                        ScanChart.Series[0].ChartType = SeriesChartType.Point;
                    }
                }
                else
                {
                    if (i + 1 != ScanTable.Rows.Count)
                    {
                        if (Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value) >= Convert.ToDouble(ScanTable.Rows[i - 1].Cells[1].Value)
                            &&
                            Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value) > Convert.ToDouble(ScanTable.Rows[i + 1].Cells[1].Value)

                            )
                        {
                            max = Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value);
                            min = max;
                            dataGridView1.Rows.Add(ScanTable.Rows[i].Cells[0].Value, ScanTable.Rows[i].Cells[1].Value, ScanTable.Rows[i].Cells[2].Value);
                            double x1 = Convert.ToDouble(ScanTable.Rows[i].Cells[0].Value);
                            double y1 = Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value);
                            ScanChart.Series[0].Points.AddXY(x1, y1);
                            ScanChart.Series[0].ChartType = SeriesChartType.Point;
                        }
                        if ((Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value) <= Convert.ToDouble(ScanTable.Rows[i - 1].Cells[1].Value)
                            &&
                            Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value) < Convert.ToDouble(ScanTable.Rows[i + 1].Cells[1].Value)

                            )

                            )
                        {
                            min = Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value);
                            dataGridView2.Rows.Add(ScanTable.Rows[i].Cells[0].Value, ScanTable.Rows[i].Cells[1].Value, ScanTable.Rows[i].Cells[2].Value);
                            max = min;
                            double x1 = Convert.ToDouble(ScanTable.Rows[i].Cells[0].Value);
                            double y1 = Convert.ToDouble(ScanTable.Rows[i].Cells[1].Value);
                            ScanChart.Series[0].Points.AddXY(x1, y1);
                            ScanChart.Series[0].ChartType = SeriesChartType.Point;
                        }
                    }
                }
            }
        }
        public void TableScan_Save()
        {
            if (countButtonClick == 1)
            {
                listBox1.Items.Add("Измерение" + countButtonClick);
                Array.Resize<string[,]>(ref countScan, countButtonClick + 1);
                countScan[countButtonClick] = new string[ScanTable.Rows.Count - 1, 3];
                ScanTable_Save();
                Application.DoEvents();
                ScanChart.Series.Add("area" + countButtonClick);
                Random r = new Random();
                int x = r.Next(100, 200), y = r.Next(100, 200);
                ScanChart.Series["area" + countButtonClick].Color =
                    System.Drawing.Color.FromArgb(
                        (byte)(x - 2 * y),
                        (byte)(y + x),
                        (byte)(y - 2 * x));
                //   TableScan();

                Application.DoEvents();

            }
            else
            {
                listBox1.Items.Add("Измерение" + countButtonClick);
                Array.Resize<string[,]>(ref countScan, countButtonClick + 1);
                countScan[countButtonClick] = new string[ScanTable.Rows.Count - 1, 3];
                ScanTable_Save();
                Application.DoEvents();
                ScanChart.Series.Add("area" + countButtonClick);
                Random r = new Random();
                int x = r.Next(0, 200), y = r.Next(0, 200);
                ScanChart.Series["area" + countButtonClick].Color =
                    System.Drawing.Color.FromArgb(
                        (byte)(x - 2 * y),
                        (byte)(y + x),
                        (byte)(y - 2 * x));
                //   TableScan();

                Application.DoEvents();

            }

        }
        public void ScanTable_Save()
        {

            for (int i = 0; i < ScanTable.Rows.Count - 1; i++)
            {
                for (int k = 0; k < ScanTable.ColumnCount; k++)
                {

                    countScan[countButtonClick][i, k] = ScanTable.Rows[i].Cells[k].Value.ToString();


                }
            }
            countButtonClick++;


        }

    }
}