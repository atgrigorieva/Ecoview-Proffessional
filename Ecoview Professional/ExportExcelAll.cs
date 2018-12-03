using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Ecoview_Professional
{
    class ExportExcelAll
    {
        Ecoview _Analis;
        public ExportExcelAll(Ecoview parent)
        {
            this._Analis = parent;
            RegistryKey hkcr = Registry.ClassesRoot;
            RegistryKey excelKey = hkcr.OpenSubKey("Excel.Application");
            bool excelInstalled = excelKey == null ? false : true;
            if (excelInstalled == true)
            {
                switch (_Analis.selet_rezim)
                {
                    case 2:
                        if (_Analis.tabControl2.SelectedIndex == 0 && _Analis.SposobZadan == "По СО")
                        {
                            SaveExcel();
                        }
                        else
                        {
                            if (_Analis.tabControl2.SelectedIndex != 0 && _Analis.SposobZadan == "По СО")
                            {
                                SaveExcel1();
                            }
                        }
                        break;
                    case 1:
                        IzmerenieFR_TableSaveExcel();
                        break;
                    case 6:
                        if (_Analis.tabControl2.SelectedIndex == 0 && _Analis.SposobZadan == "По СО")
                        {
                            SaveExcel();
                        }
                        else
                        {
                            if (_Analis.tabControl2.SelectedIndex != 0 && _Analis.SposobZadan == "По СО")
                            {
                                SaveExcel1();
                            }
                        }
                        break;
                    case 5:
                        SaveExcelScan();
                        break;
                    case 3:
                        SaveExcelMulti();
                        break;
                    case 4:
                        SaveExcelKin();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Внимание!! Экспорт в Ecxel не возможен! Отсутствует Excel!");
            }

        }
        public void SaveExcelMulti()
        {
            bool doNotWrite = false;
            for (int j = 0; j < _Analis.dataGridView5.Rows.Count - 1; j++)
            {

                for (int i = 3; i < _Analis.dataGridView5.Rows[j].Cells.Count; i++)
                {
                    if (_Analis.dataGridView5.Rows[j].Cells[i].Value == null)
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
                ExportToExcelMulti();
            }
        }
        public void SaveExcelKin()
        {
            bool doNotWrite = false;
            for (int j = 0; j < _Analis.TableKinetica1.Rows.Count - 1; j++)
            {

                for (int i = 3; i < _Analis.TableKinetica1.Rows[j].Cells.Count; i++)
                {
                    if (_Analis.TableKinetica1.Rows[j].Cells[i].Value == null)
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
                ExportToExcelKin();
            }
        }
        public void SaveExcelScan()
        {
            bool doNotWrite = false;
            for (int j = 0; j < _Analis.ScanTable.Rows.Count - 1; j++)
            {

                for (int i = 3; i < _Analis.ScanTable.Rows[j].Cells.Count; i++)
                {
                    if (_Analis.ScanTable.Rows[j].Cells[i].Value == null)
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
                ExportToExcelScan();
            }
        }

        public void IzmerenieFR_TableSaveExcel()
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
                ExportToExcelIzmerenieFR();
            }
        }
        public void SaveExcel()
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
                ExportToExcel();
            }
        }

        public void ExportToExcelMulti()
        {
            _Analis.saveFileDialog1.InitialDirectory = "C";
            _Analis.saveFileDialog1.Title = "Save as Excel File";
            _Analis.saveFileDialog1.FileName = "";
            _Analis.saveFileDialog1.Filter = "Excel Files(2003)|*.xls|Excel Files(2007)|*.xlsx";

            if (_Analis.saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Microsoft.Office.Interop.Excel.Application exApp = new Microsoft.Office.Interop.Excel.Application();
                //Excel.Application exApp = new Excel.Application();
                exApp.Application.Workbooks.Add(Type.Missing);

                exApp.Columns.ColumnWidth = 20;
                for (int i = 1; i < this._Analis.dataGridView5.Columns.Count + 1; i++)
                {
                    exApp.Cells[1, i] = this._Analis.dataGridView5.Columns[i - 1].HeaderText;
                }
                //Thread.Sleep(500);
                for (int i = 0; i < this._Analis.dataGridView5.Rows.Count; i++)
                {
                    // Thread.Sleep(200);
                    for (int j = 0; j < this._Analis.dataGridView5.Columns.Count; j++)
                    {
                        exApp.Cells[i + 2, j + 1] = this._Analis.dataGridView5.Rows[i].Cells[j].Value;
                    }
                }

                exApp.ActiveWorkbook.SaveCopyAs(_Analis.saveFileDialog1.FileName.ToString());
                exApp.ActiveWorkbook.Saved = true;
                exApp.Visible = true;
            }
        }

        public void ExportToExcelKin()
        {
            _Analis.saveFileDialog1.InitialDirectory = "C";
            _Analis.saveFileDialog1.Title = "Save as Excel File";
            _Analis.saveFileDialog1.FileName = "";
            _Analis.saveFileDialog1.Filter = "Excel Files(2003)|*.xls|Excel Files(2007)|*.xlsx";

            if (_Analis.saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Microsoft.Office.Interop.Excel.Application exApp = new Microsoft.Office.Interop.Excel.Application();
                //Excel.Application exApp = new Excel.Application();
                exApp.Application.Workbooks.Add(Type.Missing);

                exApp.Columns.ColumnWidth = 20;
                for (int i = 1; i < this._Analis.TableKinetica1.Columns.Count + 1; i++)
                {
                    exApp.Cells[1, i] = this._Analis.TableKinetica1.Columns[i - 1].HeaderText;
                }
                //Thread.Sleep(500);
                for (int i = 0; i < this._Analis.TableKinetica1.Rows.Count; i++)
                {
                    // Thread.Sleep(200);
                    for (int j = 0; j < this._Analis.TableKinetica1.Columns.Count; j++)
                    {
                        exApp.Cells[i + 2, j + 1] = this._Analis.TableKinetica1.Rows[i].Cells[j].Value;
                    }
                }

                exApp.ActiveWorkbook.SaveCopyAs(_Analis.saveFileDialog1.FileName.ToString());
                exApp.ActiveWorkbook.Saved = true;
                exApp.Visible = true;
            }
        }
        string[,] TableExpExcell;
        public class Counter
        {
            public int x;
            public int y;
        }
        public void ExportToExcelScan()
        {
            _Analis.saveFileDialog1.InitialDirectory = "C";
            _Analis.saveFileDialog1.Title = "Save as Excel File";
            _Analis.saveFileDialog1.FileName = "";
            _Analis.saveFileDialog1.Filter = "Excel Files(2003)|*.xls|Excel Files(2007)|*.xlsx";

            if (_Analis.saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Microsoft.Office.Interop.Excel.Application exApp = new Microsoft.Office.Interop.Excel.Application();
                //Excel.Application exApp = new Excel.Application();
                exApp.Application.Interactive = false;
                //exApp.Visible = false;
                exApp.Application.Workbooks.Add(Type.Missing);
                //exApp.Visible = false;
                //exApp.Application.Calculate = false;

                exApp.Columns.ColumnWidth = 20;
                
               /* Counter counter = new Counter();
                counter.TableExpExcell = new string[this._Analis.ScanTable.Rows.Count - 1, this._Analis.ScanTable.Columns.Count];
                for (int i = 0; i < this._Analis.ScanTable.Rows.Count - 1; i++)
                {
                    // Thread.Sleep(200);
                    for (int j = 0; j < this._Analis.ScanTable.Columns.Count; j++)
                    {

                        counter.TableExpExcell[i, j] = this._Analis.ScanTable.Rows[i].Cells[j].Value.ToString();

                    }
                }
                
                Thread myThread = new Thread(new ParameterizedThreadStart(ExportExcelTable));
                myThread.Start(exApp, TableExpExcell);*/
                
                for (int i = 1; i < this._Analis.ScanTable.Columns.Count + 1; i++)
                {
                    exApp.Cells[1, i] = this._Analis.ScanTable.Columns[i - 1].HeaderText;
                }
               /* for (int i = 0; i < TableExpExcell.GetLength(0); i++)
                {
                    // Thread.Sleep(200);
                    for (int j = 0; j < TableExpExcell.GetLength(1); j++)
                    {

                        exApp.Cells[i + 2, j + 1] = Convert.ToDouble(TableExpExcell[i, j]);

                    }
                }*/
                //Thread.Sleep(500);
                for (int i = 0; i < this._Analis.ScanTable.Rows.Count; i++)
                {
                    // Thread.Sleep(200);
                    for (int j = 0; j < this._Analis.ScanTable.Columns.Count; j++)
                    {
                        
                        exApp.Cells[i + 2, j + 1] = Convert.ToDouble(this._Analis.ScanTable.Rows[i].Cells[j].Value);
                        
                    }
                }
                
                exApp.ActiveWorkbook.SaveCopyAs(_Analis.saveFileDialog1.FileName.ToString());
                exApp.ActiveWorkbook.Saved = true;
                
                exApp.Visible = true;
                exApp.Application.Interactive = true;

            }
        }
      public static void ExportExcelTable(Microsoft.Office.Interop.Excel.Application exApp, string[,] TableExpExcell)
        {
        
            //Thread.Sleep(500);
            for (int i = 0; i < TableExpExcell.GetLength(0); i++)
            {
                // Thread.Sleep(200);
                for (int j = 0; j < TableExpExcell.GetLength(1); j++)
                {

                    exApp.Cells[i + 2, j + 1] = Convert.ToDouble(TableExpExcell[i,j]);

                }
            }
        }
        public void ExportToExcel()
        {
            _Analis.saveFileDialog1.InitialDirectory = "C";
            _Analis.saveFileDialog1.Title = "Save as Excel File";
            _Analis.saveFileDialog1.FileName = "";
            _Analis.saveFileDialog1.Filter = "Excel Files(2003)|*.xls|Excel Files(2007)|*.xlsx";

            if (_Analis.saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Microsoft.Office.Interop.Excel.Application exApp = new Microsoft.Office.Interop.Excel.Application();
                //Excel.Application exApp = new Excel.Application();
                exApp.Application.Workbooks.Add(Type.Missing);

                exApp.Columns.ColumnWidth = 20;
                for (int i = 1; i < this._Analis.Table1.Columns.Count + 1; i++)
                {
                    exApp.Cells[1, i] = this._Analis.Table1.Columns[i - 1].HeaderText;
                }
                Thread.Sleep(500);
                for (int i = 0; i < this._Analis.Table1.Rows.Count; i++)
                {
                    Thread.Sleep(2000);
                    for (int j = 0; j < this._Analis.Table1.Columns.Count; j++)
                    {
                        exApp.Cells[i + 2, j + 1] = this._Analis.Table1.Rows[i].Cells[j].Value;
                    }
                }

                exApp.ActiveWorkbook.SaveCopyAs(_Analis.saveFileDialog1.FileName.ToString());
                exApp.ActiveWorkbook.Saved = true;
                exApp.Visible = true;
                //  exApp.Quit();

            }
        }
        public void ExportToExcelIzmerenieFR()
        {
            _Analis.saveFileDialog1.InitialDirectory = "C";
            _Analis.saveFileDialog1.Title = "Save as Excel File";
            _Analis.saveFileDialog1.FileName = "";
            _Analis.saveFileDialog1.Filter = "Excel Files(2003)|*.xls|Excel Files(2007)|*.xlsx";

            if (_Analis.saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Microsoft.Office.Interop.Excel.Application exApp = new Microsoft.Office.Interop.Excel.Application();
                //Excel.Application exApp = new Excel.Application();
                exApp.Application.Workbooks.Add(Type.Missing);

                exApp.Columns.ColumnWidth = 20;
                for (int i = 1; i < this._Analis.IzmerenieFR_Table.Columns.Count + 1; i++)
                {
                    exApp.Cells[1, i] = this._Analis.IzmerenieFR_Table.Columns[i - 1].HeaderText;
                }
                Thread.Sleep(500);
                for (int i = 0; i < this._Analis.IzmerenieFR_Table.Rows.Count; i++)
                {
                    Thread.Sleep(2000);
                    for (int j = 0; j < this._Analis.IzmerenieFR_Table.Columns.Count; j++)
                    {
                        string value = Convert.ToString(this._Analis.IzmerenieFR_Table.Rows[i].Cells[j].Value);
                        value = value.Replace(",", ".");
                        exApp.Cells[i + 2, j + 1] = value;

                    }
                }

                exApp.ActiveWorkbook.SaveCopyAs(_Analis.saveFileDialog1.FileName.ToString());
                exApp.ActiveWorkbook.Saved = true;
                exApp.Visible = true;
                //  exApp.Quit();

            }
        }
        public void SaveExcel1()
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
                ExportToExcel2();
            }


        }
        public void ExportToExcel2()
        {

            _Analis.saveFileDialog1.InitialDirectory = "C";
            _Analis.saveFileDialog1.Title = "Save as Excel File";
            _Analis.saveFileDialog1.FileName = "";
            _Analis.saveFileDialog1.Filter = "Excel Files(2003)|*.xls|Excel Files(2007)|*.xlsx";

            if (_Analis.saveFileDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Microsoft.Office.Interop.Excel.Application exApp = new Microsoft.Office.Interop.Excel.Application();
                //Excel.Application exApp = new Excel.Application();
                exApp.Application.Workbooks.Add(Type.Missing);

                exApp.Columns.ColumnWidth = 20;
                for (int i = 1; i < this._Analis.Table2.Columns.Count + 1; i++)
                {
                    exApp.Cells[1, i] = this._Analis.Table2.Columns[i - 1].HeaderText;
                }
                Thread.Sleep(500);
                for (int i = 0; i < this._Analis.Table2.Rows.Count; i++)
                {
                    Thread.Sleep(2000);
                    for (int j = 0; j < this._Analis.Table2.Columns.Count; j++)
                    {
                        exApp.Cells[i + 2, j + 1] = this._Analis.Table2.Rows[i].Cells[j].Value;
                    }
                }

                exApp.ActiveWorkbook.SaveCopyAs(_Analis.saveFileDialog1.FileName.ToString());
                exApp.ActiveWorkbook.Saved = true;
                // exApp.Quit();
                exApp.Visible = true;
            }

        }
    }
}
