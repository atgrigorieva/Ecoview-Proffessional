using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Ecoview_Professional
{
    
    class ExportPDFDocALL
    {
        Ecoview _Analis;
        public ExportPDFDocALL(Ecoview parent)
        {
            this._Analis = parent;
            if (_Analis.selet_rezim == 2)
            {
                if (_Analis.tabControl2.SelectedIndex == 0 && _Analis.SposobZadan == "По СО")
                {
                    SaveToPdf();
                }
                else
                {
                    if (_Analis.tabControl2.SelectedIndex == 0 && _Analis.SposobZadan != "По СО")
                    {
                        SaveToPdf1();
                    }
                    else
                    {
                        SaveTpPdf2();
                    }
                }
            }
            else
            {
                if (_Analis.selet_rezim == 1)
                {
                    IzmerenieFRSavePDF();
                }
                else
                {
                    if (_Analis.selet_rezim == 6)
                    {
                        if (_Analis.tabControl2.SelectedIndex == 0 && _Analis.SposobZadan == "По СО")
                        {
                            SaveToPdf();
                        }
                        else
                        {
                            if (_Analis.tabControl2.SelectedIndex == 0 && _Analis.SposobZadan != "По СО")
                            {
                                SaveToPdf1();
                            }
                            else
                            {
                                SaveTpPdf2();
                            }
                        }
                    }
                }
            }
        }

        public void IzmerenieFRSavePDF()
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
                IzmerenieFRExportToPdf();
            }
        }
        public void SaveToPdf()
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
                ExportToPDF1();
            }
        }
        public void SaveToPdf1()
        {
            ExportToPDF1();
        }

        public void ExportToPDF1()
        {
            BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\georgia.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            string head = @"Расчет линейного градуировочного графика";
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font fontBold = new iTextSharp.text.Font(baseFont, 18f, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font fontBold1 = new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font1 = new iTextSharp.text.Font(baseFont, 5f, iTextSharp.text.Font.BOLD);
            PdfPTable pdfTable = new PdfPTable(_Analis.Table1.ColumnCount);
            PdfPTable pdfTable1 = new PdfPTable(_Analis.Table1.ColumnCount - 3 - _Analis.NoCaIzm);
            if (_Analis.NoCaIzm <= 3)
            {
                //Creating iTextSharp Table from the DataTable data
                pdfTable = new PdfPTable(_Analis.Table1.ColumnCount);
                pdfTable.DefaultCell.Padding = 5;
                pdfTable.WidthPercentage = 100;
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTable.DefaultCell.BorderWidth = 1;
            }
            else
            {
                if (_Analis.NoCaIzm > 3 && _Analis.NoCaIzm <= 7)
                {
                    pdfTable = new PdfPTable(3 + _Analis.NoCaIzm);
                    pdfTable.DefaultCell.Padding = 5;
                    pdfTable.WidthPercentage = 100;
                    pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                    pdfTable.DefaultCell.BorderWidth = 1;
                    pdfTable1 = new PdfPTable(_Analis.Table1.ColumnCount - 3 - _Analis.NoCaIzm);
                    pdfTable1.DefaultCell.Padding = 5;
                    pdfTable1.WidthPercentage = 20;
                    pdfTable1.HorizontalAlignment = Element.ALIGN_LEFT;
                    pdfTable1.DefaultCell.BorderWidth = 1;
                }
                else
                {
                    pdfTable = new PdfPTable(3 + 5);
                    pdfTable.DefaultCell.Padding = 5;
                    pdfTable.WidthPercentage = 100;
                    pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                    pdfTable.DefaultCell.BorderWidth = 1;
                    pdfTable1 = new PdfPTable(_Analis.Table1.ColumnCount - 3 - 5);
                    pdfTable1.DefaultCell.Padding = 5;
                    pdfTable1.WidthPercentage = 100;
                    pdfTable1.HorizontalAlignment = Element.ALIGN_LEFT;
                    pdfTable1.DefaultCell.BorderWidth = 1;
                }
            }



            // iTextSharp.text.Font fontLeft = new iTextSharp.text.Font(baseFont, 9f, iTextSharp.text.Font.NORMAL);
            if (_Analis.SposobZadan == "По СО")
            {

                if (_Analis.NoCaIzm <= 3)
                {
                    PdfPCell cell;
                    for (int i = 0; i < _Analis.Table1.ColumnCount; i++)
                    {
                        cell = new PdfPCell(new Phrase(_Analis.Table1.Columns[i].HeaderText, fontBold1));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        //cell.BackgroundColor = new iTextSharp.text.Color(161, 235, 157);
                        cell.BorderWidth = 1;
                        cell.Padding = 1;
                        cell.PaddingBottom = 5;
                        pdfTable.AddCell(cell);
                    }
                    for (int j = 0; j < _Analis.Table1.Rows.Count; j++)
                    {
                        for (int i = 0; i < _Analis.Table1.ColumnCount; i++)
                        {
                            pdfTable.AddCell(new Phrase(Convert.ToString(_Analis.Table1.Rows[j].Cells[i].Value), font));
                        }
                    }
                }
                else
                {
                    if (_Analis.NoCaIzm > 3 && _Analis.NoCaIzm <= 7)
                    {
                        PdfPCell cell1;
                        PdfPCell cell;
                        int kIzmer1 = 0;
                        for (int i = 0; i < 3 + _Analis.NoCaIzm; i++)
                        {
                            cell = new PdfPCell(new Phrase(_Analis.Table1.Columns[kIzmer1].HeaderText, fontBold1));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            //cell.BackgroundColor = new iTextSharp.text.Color(161, 235, 157);
                            cell.BorderWidth = 1;
                            cell.Padding = 1;
                            cell.PaddingBottom = 5;
                            pdfTable.AddCell(cell);
                            kIzmer1++;
                        }
                        kIzmer1 = 0;
                        for (int j = 0; j < _Analis.Table1.Rows.Count; j++)
                        {
                            for (int i = 0; i < 3 + _Analis.NoCaIzm; i++)
                            {
                                pdfTable.AddCell(new Phrase(Convert.ToString(_Analis.Table1.Rows[j].Cells[kIzmer1].Value), font));
                                kIzmer1++;
                            }
                            kIzmer1 = 0;
                        }
                        int kIzmer = 3 + _Analis.NoCaIzm;
                        for (int i = 0; i < _Analis.Table1.ColumnCount - 3 - _Analis.NoCaIzm; i++)
                        {
                            cell1 = new PdfPCell(new Phrase(_Analis.Table1.Columns[kIzmer].HeaderText, fontBold1));
                            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                            //cell.BackgroundColor = new iTextSharp.text.Color(161, 235, 157);
                            cell1.BorderWidth = 1;
                            cell1.Padding = 1;
                            cell1.PaddingBottom = 5;
                            pdfTable1.AddCell(cell1);
                            kIzmer++;
                        }
                        kIzmer = 3 + _Analis.NoCaIzm;
                        for (int j = 0; j < _Analis.Table1.Rows.Count; j++)
                        {
                            for (int i = 0; i < _Analis.Table1.ColumnCount - 3 - _Analis.NoCaIzm; i++)
                            {
                                pdfTable1.AddCell(new Phrase(Convert.ToString(_Analis.Table1.Rows[j].Cells[kIzmer].Value), font));
                                kIzmer++;
                            }
                            kIzmer = 3 + _Analis.NoCaIzm;
                        }
                    }
                    else
                    {
                        PdfPCell cell1;
                        PdfPCell cell;
                        int kIzmer1 = 0;
                        for (int i = 0; i < 3 + 5; i++)
                        {
                            cell = new PdfPCell(new Phrase(_Analis.Table1.Columns[kIzmer1].HeaderText, fontBold1));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            //cell.BackgroundColor = new iTextSharp.text.Color(161, 235, 157);
                            cell.BorderWidth = 1;
                            cell.Padding = 1;
                            cell.PaddingBottom = 5;
                            pdfTable.AddCell(cell);
                            kIzmer1++;
                        }
                        kIzmer1 = 0;
                        for (int j = 0; j < _Analis.Table1.Rows.Count; j++)
                        {
                            for (int i = 0; i < 3 + 5; i++)
                            {
                                pdfTable.AddCell(new Phrase(Convert.ToString(_Analis.Table1.Rows[j].Cells[kIzmer1].Value), font));
                                kIzmer1++;
                            }
                            kIzmer1 = 0;
                        }
                        int kIzmer = 3 + 5;
                        for (int i = 0; i < _Analis.Table1.ColumnCount - 3 - 5; i++)
                        {
                            cell1 = new PdfPCell(new Phrase(_Analis.Table1.Columns[kIzmer].HeaderText, fontBold1));
                            cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                            //cell.BackgroundColor = new iTextSharp.text.Color(161, 235, 157);
                            cell1.BorderWidth = 1;
                            cell1.Padding = 1;
                            cell1.PaddingBottom = 5;
                            pdfTable1.AddCell(cell1);
                            kIzmer++;
                        }
                        kIzmer = 3 + 5;
                        for (int j = 0; j < _Analis.Table1.Rows.Count; j++)
                        {
                            for (int i = 0; i < _Analis.Table1.ColumnCount - 3 - 5; i++)
                            {
                                pdfTable1.AddCell(new Phrase(Convert.ToString(_Analis.Table1.Rows[j].Cells[kIzmer].Value), font));
                                kIzmer++;
                            }
                            kIzmer = 3 + 5;
                        }
                    }
                }

            }


            var chartimage = new MemoryStream();
            _Analis.chart1.SaveImage(chartimage, ChartImageFormat.Png);
            iTextSharp.text.Image Chart_Image = iTextSharp.text.Image.GetInstance(chartimage.GetBuffer());
            Chart_Image.ScalePercent(70f);
            iTextSharp.text.Rectangle orient = PageSize.A4;
            float margintop = 20;
            float marginleft = 25;
            float marginright = 25;
            float marginbottom = 5;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Pdf File |*.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                Document doc = new Document(orient, marginleft, marginright, margintop, marginbottom);

                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));

                doc.Open();
                //iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance("Image.jpeg");

                Paragraph welcomeParagraph = new Paragraph("Расчет линейного градуировочного графика\n", fontBold);
                welcomeParagraph.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                Paragraph Veshestvo2 = new Paragraph("Вещество: " + _Analis.Veshestvo1, font);
                Paragraph wavelength2 = new Paragraph("Длина волны: " + _Analis.wavelength1, font);
                Paragraph WidthCuvette2 = new Paragraph("Длина кюветы: " + _Analis.WidthCuvette, font); ;
                Paragraph BottomLine2 = new Paragraph("Нижняя граница обнаружения: " + _Analis.BottomLine, font);
                Paragraph TopLine2 = new Paragraph("Верхняя граница обнаружения: " + _Analis.TopLine, font);
                Paragraph ND2 = new Paragraph("НД: " + _Analis.ND, font);
                Paragraph Description2 = new Paragraph("Примечание: " + _Analis.Description, font);
                Paragraph DateTime2 = new Paragraph("Дата: " + _Analis.DateTime, font);
                Paragraph Ispolnitel2 = new Paragraph("Исполнитель: " + _Analis.Ispolnitel, font);
                Paragraph GradYrav = new Paragraph("Градуировочное уравнение: " + _Analis.label14.Text, font);
                Paragraph Table1 = new Paragraph("Таблица исходных данных\n\n", font);

                Paragraph InformationAboutPribor = new Paragraph("Информация о приборе\n", font);
                var applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);


                string model = @"pribor/model";
                DecriptorPribor decriptorModel = new DecriptorPribor(ref model, _Analis.pathTemp);
                var model_var = Path.Combine(applicationDirectory, _Analis.pathTemp + model);


                string SerNomer_Text = @"pribor/SerNomer";
                DecriptorPribor decriptorSerNomer = new DecriptorPribor(ref SerNomer_Text, _Analis.pathTemp);
                var SerNomer_Text_var = Path.Combine(applicationDirectory, _Analis.pathTemp + SerNomer_Text);

                string InventarNomer_Text = @"pribor/InventarNomer";
                DecriptorPribor decriptorInventarNomer = new DecriptorPribor(ref InventarNomer_Text, _Analis.pathTemp);
                var InventarNomer_Text_var = Path.Combine(applicationDirectory, _Analis.pathTemp + InventarNomer_Text);

                string SrokIstech_Text = @"pribor/SrokIstech";
                DecriptorPribor decriptorSrokIstech = new DecriptorPribor(ref SrokIstech_Text, _Analis.pathTemp);
                var SrokIstech_Text_var = Path.Combine(applicationDirectory, _Analis.pathTemp + SrokIstech_Text);

                string Poveren_Text = @"pribor/Poveren";
                DecriptorPribor decriptorPoveren = new DecriptorPribor(ref Poveren_Text, _Analis.pathTemp);
                var Poveren_Text_var = Path.Combine(applicationDirectory, _Analis.pathTemp + Poveren_Text);


                StreamReader fs = new StreamReader(model_var);
                Paragraph Model = new Paragraph("Модель\n" + fs.ReadLine(), font);
                fs.Close();

                StreamReader fs1 = new StreamReader(SerNomer_Text_var);
                Paragraph SerNomer = new Paragraph("Серийный номер\n" + fs1.ReadLine(), font);
                fs1.Close();

                StreamReader fs2 = new StreamReader(InventarNomer_Text_var);
                Paragraph InventarNomer = new Paragraph("Инвентарный номер\n" + fs2.ReadLine(), font);
                fs2.Close();

                StreamReader fs3 = new StreamReader(Poveren_Text_var);
                DateTime data = Convert.ToDateTime(fs3.ReadLine());
                // data.Date.ToString("d.mm.yyyy"); 
                //  MessageBox.Show(Convert.ToString(data));   
                data = data.AddYears(1);
                fs3.Close();
                Paragraph Poveren = new Paragraph("Поверка действительна до\n" + data.Date.ToString("dd.MM.yyyy"), font);

                Paragraph Statistica = new Paragraph("Статистика: " + _Analis.RR.Text + "\n                         " + _Analis.SKO.Text + "\n                         " + _Analis.label21.Text + "\n                         " + _Analis.label22.Text, font);

                PdfPTable Information = new PdfPTable(6);
                PdfPCell Informationcell = new PdfPCell(Model);
                Informationcell.BorderWidth = 0;
                Informationcell.Colspan = 3;
                Information.AddCell(Informationcell);

                Informationcell = new PdfPCell(SerNomer);
                Informationcell.BorderWidth = 0;
                Informationcell.Colspan = 3;
                Information.AddCell(Informationcell);

                Informationcell = new PdfPCell(Poveren);
                Informationcell.BorderWidth = 0;
                Informationcell.Colspan = 3;
                Information.AddCell(Informationcell);

                Informationcell = new PdfPCell(InventarNomer);
                Informationcell.BorderWidth = 0;
                Informationcell.Colspan = 3;
                Information.AddCell(Informationcell);



                PdfPTable table = new PdfPTable(5);
                PdfPCell cell = new PdfPCell(Veshestvo2);
                cell.BorderWidth = 0;
                cell.Colspan = 2;
                table.AddCell(cell);

                cell = new PdfPCell();
                cell.BorderWidth = 0;
                table.AddCell(cell);

                cell = new PdfPCell(ND2);
                cell.BorderWidth = 0;
                cell.Colspan = 2;
                table.AddCell(cell);

                cell = new PdfPCell(wavelength2);
                cell.BorderWidth = 0;
                cell.Colspan = 5;
                table.AddCell(cell);

                cell = new PdfPCell(WidthCuvette2);
                cell.BorderWidth = 0;
                cell.Colspan = 5;
                table.AddCell(cell);

                cell = new PdfPCell(BottomLine2);
                cell.BorderWidth = 0;
                cell.Colspan = 5;
                table.AddCell(cell);

                cell = new PdfPCell(TopLine2);
                cell.BorderWidth = 0;
                cell.Colspan = 5;
                table.AddCell(cell);

                Paragraph welcomeParagraph1 = new Paragraph("\n", fontBold);

                PdfPTable table1 = new PdfPTable(5);
                PdfPCell cell1 = new PdfPCell(Chart_Image);
                cell1.BorderWidth = 0;
                cell1.Colspan = 5;
                table1.AddCell(cell1);

                cell1 = new PdfPCell(welcomeParagraph1);
                cell1.BorderWidth = 0;
                cell1.Colspan = 5;
                table1.AddCell(cell1);

                cell1 = new PdfPCell(DateTime2);
                cell1.BorderWidth = 0;
                cell1.Colspan = 5;
                table1.AddCell(cell1);

                cell1 = new PdfPCell(Ispolnitel2);
                cell1.BorderWidth = 0;
                cell1.Colspan = 5;
                table1.AddCell(cell1);




                doc.Add(welcomeParagraph);
                doc.Add(welcomeParagraph1);
                doc.Add(table);
                //  doc.Add(Veshestvo2);
                //  doc.Add(wavelength2);
                // doc.Add(WidthCuvette2);
                // doc.Add(BottomLine2);
                //  doc.Add(TopLine2);
                doc.Add(Description2);
                doc.Add(Statistica);
                doc.Add(welcomeParagraph1);
                doc.Add(InformationAboutPribor);

                doc.Add(Information);
                // doc.Add(welcomeParagraph1);
                if (_Analis.SposobZadan == "По СО")
                {
                    doc.Add(Table1);

                    //  doc.Add(welcomeParagraph1);
                    if (_Analis.NoCaIzm <= 3)
                    {
                        doc.Add(pdfTable);
                    }
                    else
                    {
                        if (_Analis.NoCaIzm > 3 && _Analis.NoCaIzm <= 7)
                        {
                            doc.Add(pdfTable);
                            doc.Add(welcomeParagraph1);
                            doc.Add(pdfTable1);
                        }
                        else
                        {
                            doc.Add(pdfTable);
                            doc.Add(welcomeParagraph1);
                            doc.Add(pdfTable1);
                        }
                    }
                }
                doc.Add(welcomeParagraph1);

                doc.Add(GradYrav);
                doc.Add(welcomeParagraph1);
                //    doc.Add(Chart_Image);
                //  doc.Add(welcomeParagraph1);
                doc.Add(table1);
                //  doc.Add(ND2);

                // doc.Add(DateTime2);
                // doc.Add(Ispolnitel2);

                doc.Close();
                /*   string filename = Application.StartupPath;
                   filename = Path.GetFullPath(Path.Combine(filename, ".\\Test.pdf"));
                   wbrPdf.Navigate(filename);*/
               // _Analis.filename = sfd.FileName;

            }

            /*   Spire.Pdf.PdfDocument pdfdocument = new Spire.Pdf.PdfDocument();
               pdfdocument.LoadFromFile(filename);        
               pdfdocument.PrintDocument.Print();
               pdfdocument.Dispose();
               */
        }

        public void IzmerenieFRExportToPdf()
        {
            BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\georgia.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font fontBold = new iTextSharp.text.Font(baseFont, 18f, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font fontBold1 = new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font1 = new iTextSharp.text.Font(baseFont, 5f, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Rectangle orient = PageSize.A4;
            float margintop = 20;
            float marginleft = 25;
            float marginright = 25;
            float marginbottom = 5;
            PdfPTable pdfTable = new PdfPTable(_Analis.IzmerenieFR_Table.ColumnCount);
            pdfTable = new PdfPTable(_Analis.IzmerenieFR_Table.ColumnCount);
            pdfTable.DefaultCell.Padding = 5;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 1;
            PdfPCell cell;
            for (int i = 0; i < _Analis.IzmerenieFR_Table.ColumnCount; i++)
            {
                cell = new PdfPCell(new Phrase(_Analis.IzmerenieFR_Table.Columns[i].HeaderText, fontBold1));
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                //cell.BackgroundColor = new iTextSharp.text.Color(161, 235, 157);
                cell.BorderWidth = 1;
                cell.Padding = 1;
                cell.PaddingBottom = 5;
                pdfTable.AddCell(cell);
            }
            for (int j = 0; j < _Analis.IzmerenieFR_Table.Rows.Count; j++)
            {
                for (int i = 0; i < _Analis.IzmerenieFR_Table.ColumnCount; i++)
                {
                    pdfTable.AddCell(new Phrase(Convert.ToString(_Analis.IzmerenieFR_Table.Rows[j].Cells[i].Value), font));
                }
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Pdf File |*.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Document doc = new Document(orient, marginleft, marginright, margintop, marginbottom);
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));

                doc.Open();
                Paragraph welcomeParagraph1 = new Paragraph("\n", fontBold);
                Paragraph welcomeParagraph = new Paragraph("Измерения в фотометрическом режиме\n", fontBold);
                welcomeParagraph.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
                Paragraph Description2 = new Paragraph("Примечание: " + _Analis.Description, font);
                Paragraph DateTime2 = new Paragraph("Дата: " + _Analis.DateTime, font);
                Paragraph Ispolnitel2 = new Paragraph("Исполнитель: " + _Analis.Ispolnitel, font);

                Paragraph InformationAboutPribor = new Paragraph("Информация о приборе:\n", font);
                var applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                string model = @"pribor/model";
                DecriptorPribor decriptorModel = new DecriptorPribor(ref model, _Analis.pathTemp);
                var model_var = Path.Combine(applicationDirectory, _Analis.pathTemp + model);


                string SerNomer_Text = @"pribor/SerNomer";
                DecriptorPribor decriptorSerNomer = new DecriptorPribor(ref SerNomer_Text, _Analis.pathTemp);
                var SerNomer_Text_var = Path.Combine(applicationDirectory, _Analis.pathTemp + SerNomer_Text);

                string InventarNomer_Text = @"pribor/InventarNomer";
                DecriptorPribor decriptorInventarNomer = new DecriptorPribor(ref InventarNomer_Text, _Analis.pathTemp);
                var InventarNomer_Text_var = Path.Combine(applicationDirectory, _Analis.pathTemp + InventarNomer_Text);

                string SrokIstech_Text = @"pribor/SrokIstech";
                DecriptorPribor decriptorSrokIstech = new DecriptorPribor(ref SrokIstech_Text, _Analis.pathTemp);
                var SrokIstech_Text_var = Path.Combine(applicationDirectory, _Analis.pathTemp + SrokIstech_Text);

                string Poveren_Text = @"pribor/Poveren";
                DecriptorPribor decriptorPoveren = new DecriptorPribor(ref Poveren_Text, _Analis.pathTemp);
                var Poveren_Text_var = Path.Combine(applicationDirectory, _Analis.pathTemp + Poveren_Text);
                StreamReader fs = new StreamReader(model_var);
                Paragraph Model = new Paragraph("Модель\n" + fs.ReadLine(), font);
                fs.Close();

                StreamReader fs1 = new StreamReader(SerNomer_Text_var);
                Paragraph SerNomer = new Paragraph("Серийный номер\n" + fs1.ReadLine(), font);
                fs1.Close();

                StreamReader fs2 = new StreamReader(InventarNomer_Text_var);
                Paragraph InventarNomer = new Paragraph("Инвентарный номер\n" + fs2.ReadLine(), font);
                fs2.Close();

                StreamReader fs3 = new StreamReader(Poveren_Text_var);
                DateTime data = Convert.ToDateTime(fs3.ReadLine());
                // data.Date.ToString("d.mm.yyyy"); 
                //  MessageBox.Show(Convert.ToString(data));   
                data = data.AddYears(1);
                fs3.Close();
                Paragraph Poveren = new Paragraph("Поверка действительна до\n" + data.Date.ToString("dd.MM.yyyy"), font);
                PdfPTable Information = new PdfPTable(6);
                PdfPCell Informationcell = new PdfPCell(Model);
                Informationcell.BorderWidth = 0;
                Informationcell.Colspan = 3;
                Information.AddCell(Informationcell);

                Informationcell = new PdfPCell(SerNomer);
                Informationcell.BorderWidth = 0;
                Informationcell.Colspan = 3;
                Information.AddCell(Informationcell);

                Informationcell = new PdfPCell(Poveren);
                Informationcell.BorderWidth = 0;
                Informationcell.Colspan = 3;
                Information.AddCell(Informationcell);

                Informationcell = new PdfPCell(InventarNomer);
                Informationcell.BorderWidth = 0;
                Informationcell.Colspan = 3;
                Information.AddCell(Informationcell);
                Paragraph Table1 = new Paragraph("Таблица исходных данных\n\n", font);

                doc.Add(welcomeParagraph);
                doc.Add(welcomeParagraph1);
                doc.Add(Description2);
                doc.Add(welcomeParagraph1);
                doc.Add(InformationAboutPribor);
                doc.Add(welcomeParagraph1);
                doc.Add(Information);
                doc.Add(welcomeParagraph1);
                doc.Add(Table1);
                doc.Add(welcomeParagraph1);
                doc.Add(pdfTable);
                doc.Add(welcomeParagraph1);
                doc.Add(DateTime2);
                doc.Add(welcomeParagraph1);
                doc.Add(Ispolnitel2);
                doc.Add(welcomeParagraph1);
                doc.Close();
            }
        }
        public void SaveTpPdf2()
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
                if (_Analis.Table2.Rows.Count >= 1)
                {
                    ExportToPDF();
                }
                else
                {
                    MessageBox.Show("Создайте таблицу измерений!");
                }
            }
        }
        public void ExportToPDF()
        {
            //string head = @"Протокол выполнения измерений";

            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(_Analis.Table2.ColumnCount);
            PdfPTable pdfTable2 = new PdfPTable(_Analis.Table2.ColumnCount - 2 - _Analis.NoCaIzm1);
            if (_Analis.NoCaIzm1 <= 3)
            {
                //Creating iTextSharp Table from the DataTable data
                pdfTable = new PdfPTable(_Analis.Table2.ColumnCount);
                pdfTable.DefaultCell.Padding = 5;
                pdfTable.WidthPercentage = 100;
                pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfTable.DefaultCell.BorderWidth = 1;
            }
            else
            {
                if (_Analis.NoCaIzm1 > 3 && _Analis.NoCaIzm1 <= 5)
                {
                    pdfTable = new PdfPTable(2 + _Analis.NoCaIzm1 * 2);
                    pdfTable.DefaultCell.Padding = 5;
                    pdfTable.WidthPercentage = 100;
                    pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                    pdfTable.DefaultCell.BorderWidth = 1;
                    pdfTable2 = new PdfPTable(_Analis.Table2.ColumnCount - 2 - _Analis.NoCaIzm1 * 2);
                    pdfTable2.DefaultCell.Padding = 5;
                    pdfTable2.WidthPercentage = 20;
                    pdfTable2.HorizontalAlignment = Element.ALIGN_LEFT;
                    pdfTable2.DefaultCell.BorderWidth = 1;
                }
                else
                {
                    pdfTable = new PdfPTable(12);
                    pdfTable.DefaultCell.Padding = 5;
                    pdfTable.WidthPercentage = 100;
                    pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
                    pdfTable.DefaultCell.BorderWidth = 1;
                    pdfTable2 = new PdfPTable(_Analis.Table2.ColumnCount - 12);
                    pdfTable2.DefaultCell.Padding = 5;
                    pdfTable2.WidthPercentage = 100;
                    pdfTable2.HorizontalAlignment = Element.ALIGN_LEFT;
                    pdfTable2.DefaultCell.BorderWidth = 1;
                }
            }
            BaseFont baseFont = BaseFont.CreateFont("C:\\Windows\\Fonts\\georgia.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.NORMAL);
            iTextSharp.text.Font fontBold = new iTextSharp.text.Font(baseFont, 18f, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font fontBold1 = new iTextSharp.text.Font(baseFont, 10f, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font font1 = new iTextSharp.text.Font(baseFont, 5f, iTextSharp.text.Font.BOLD);
            // iTextSharp.text.Font fontLeft = new iTextSharp.text.Font(baseFont, 9f, iTextSharp.text.Font.NORMAL);

            //Adding Header row
            if (_Analis.NoCaIzm1 <= 3)
            {
                PdfPCell cell;
                for (int i = 0; i < _Analis.Table2.ColumnCount; i++)
                {
                    cell = new PdfPCell(new Phrase(_Analis.Table2.Columns[i].HeaderText, fontBold1));
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                    //cell.BackgroundColor = new iTextSharp.text.Color(161, 235, 157);
                    cell.BorderWidth = 1;
                    cell.Padding = 1;
                    cell.PaddingBottom = 5;
                    pdfTable.AddCell(cell);
                }
                for (int j = 0; j < _Analis.Table2.Rows.Count - 1; j++)
                {
                    for (int i = 0; i < _Analis.Table2.ColumnCount; i++)
                    {
                        pdfTable.AddCell(new Phrase(Convert.ToString(_Analis.Table2.Rows[j].Cells[i].Value), font));
                    }
                }
            }
            else
            {
                if (_Analis.NoCaIzm1 > 3 && _Analis.NoCaIzm1 <= 5)
                {
                    PdfPCell cell1;
                    PdfPCell cell;
                    int kIzmer1 = 0;
                    //int NoCaIzm1_1 = 5;
                    for (int i = 0; i < 2 + _Analis.NoCaIzm1 * 2; i++)
                    {
                        cell = new PdfPCell(new Phrase(_Analis.Table2.Columns[kIzmer1].HeaderText, fontBold1));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        //cell.BackgroundColor = new iTextSharp.text.Color(161, 235, 157);
                        cell.BorderWidth = 1;
                        cell.Padding = 1;
                        cell.PaddingBottom = 5;
                        pdfTable.AddCell(cell);
                        kIzmer1++;
                    }
                    kIzmer1 = 0;
                    for (int j = 0; j < _Analis.Table2.Rows.Count - 1; j++)
                    {
                        for (int i = 0; i < 2 + _Analis.NoCaIzm1 * 2; i++)
                        {
                            pdfTable.AddCell(new Phrase(Convert.ToString(_Analis.Table2.Rows[j].Cells[kIzmer1].Value), font));
                            kIzmer1++;
                        }
                        kIzmer1 = 0;
                    }
                    int kIzmer = 2 + _Analis.NoCaIzm1 * 2;
                    for (int i = 0; i < _Analis.Table2.ColumnCount - 2 - _Analis.NoCaIzm1 * 2; i++)
                    {
                        cell1 = new PdfPCell(new Phrase(_Analis.Table2.Columns[kIzmer].HeaderText, fontBold1));
                        cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                        //cell.BackgroundColor = new iTextSharp.text.Color(161, 235, 157);
                        cell1.BorderWidth = 1;
                        cell1.Padding = 1;
                        cell1.PaddingBottom = 5;
                        pdfTable2.AddCell(cell1);
                        kIzmer++;
                    }
                    kIzmer = 2 + _Analis.NoCaIzm1 * 2;
                    for (int j = 0; j < _Analis.Table2.Rows.Count - 1; j++)
                    {
                        for (int i = 0; i < _Analis.Table2.ColumnCount - 2 - _Analis.NoCaIzm1 * 2; i++)
                        {
                            pdfTable2.AddCell(new Phrase(Convert.ToString(_Analis.Table2.Rows[j].Cells[kIzmer].Value), font));
                            kIzmer++;
                        }
                        kIzmer = 2 + _Analis.NoCaIzm1 * 2;
                    }
                }
                else
                {
                    PdfPCell cell1;
                    PdfPCell cell;
                    int kIzmer1 = 0;
                    for (int i = 0; i < 12; i++)
                    {
                        cell = new PdfPCell(new Phrase(_Analis.Table2.Columns[kIzmer1].HeaderText, fontBold1));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        //cell.BackgroundColor = new iTextSharp.text.Color(161, 235, 157);
                        cell.BorderWidth = 1;
                        cell.Padding = 1;
                        cell.PaddingBottom = 5;
                        pdfTable.AddCell(cell);
                        kIzmer1++;
                    }
                    kIzmer1 = 0;
                    for (int j = 0; j < _Analis.Table2.Rows.Count - 1; j++)
                    {
                        for (int i = 0; i < 12; i++)
                        {
                            pdfTable.AddCell(new Phrase(Convert.ToString(_Analis.Table2.Rows[j].Cells[kIzmer1].Value), font));
                            kIzmer1++;
                        }
                        kIzmer1 = 0;
                    }
                    int kIzmer = 12;
                    for (int i = 0; i < _Analis.Table2.ColumnCount - 12; i++)
                    {
                        cell1 = new PdfPCell(new Phrase(_Analis.Table2.Columns[kIzmer].HeaderText, fontBold1));
                        cell1.HorizontalAlignment = Element.ALIGN_CENTER;
                        cell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                        //cell.BackgroundColor = new iTextSharp.text.Color(161, 235, 157);
                        cell1.BorderWidth = 1;
                        cell1.Padding = 1;
                        cell1.PaddingBottom = 5;
                        pdfTable2.AddCell(cell1);
                        kIzmer++;
                    }
                    kIzmer = 12;
                    for (int j = 0; j < _Analis.Table2.Rows.Count - 1; j++)
                    {
                        for (int i = 0; i < _Analis.Table2.ColumnCount - 12; i++)
                        {
                            pdfTable2.AddCell(new Phrase(Convert.ToString(_Analis.Table2.Rows[j].Cells[kIzmer].Value), font));
                            kIzmer++;
                        }
                        kIzmer = 12;
                    }
                }
            }

            iTextSharp.text.Rectangle orient = PageSize.A4;

            float margintop = 20;
            float marginleft = 25;
            float marginright = 25;
            float marginbottom = 5;

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Pdf File |*.pdf";
            if (sfd.ShowDialog() == DialogResult.OK)
            {

                Document doc = new Document(orient, marginleft, marginright, margintop, marginbottom);
                PdfWriter wri = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));

                doc.Open();
                //iTextSharp.text.Image image = iTextSharp.text.Image.GetInstance("Image.jpeg");

                Paragraph welcomeParagraph = new Paragraph("Протокол выполнения измерений\n", fontBold);
                welcomeParagraph.Alignment = iTextSharp.text.Element.ALIGN_CENTER;

                Paragraph FileName2 = new Paragraph("Имя файла: " + _Analis.filepath2, font);
                Paragraph Description2 = new Paragraph("Описание: " + _Analis.textBox8.Text, font);


                Paragraph DateTime2 = new Paragraph("Дата: " + _Analis.dateTimePicker2.Value.ToString("dd.MM.yyyy"), font);
                Paragraph WaveLength2 = new Paragraph("Длина волны: " + _Analis.wavelength1, font);
                Paragraph Pogresh2 = new Paragraph("Погрешность методики: " + _Analis.textBox7.Text, font);
                Paragraph Opt_dlin_cuvet2 = new Paragraph("Оптическая длина кюветы: " + _Analis.Opt_dlin_cuvet.Text, font);
                Paragraph F1 = new Paragraph("F1 = " + _Analis.F1Text.Text, font);
                Paragraph F2 = new Paragraph("F2 = " + _Analis.F2Text.Text, font);

                Paragraph Graduirovka2 = new Paragraph("Градуировка: ", font);
                Paragraph FileName1 = new Paragraph("Имя файла: " + _Analis.filepath, font);
                Paragraph Description1 = new Paragraph("Описание: " + _Analis.Description, font);
                Paragraph Date1 = new Paragraph("Дата: " + _Analis.DateTime, font);
                Paragraph Date2 = new Paragraph("Действительна до: " + _Analis.dateTimePicker1.Value.AddDays(_Analis.Days).ToString("dd.MM.yyyy"), font);
                Paragraph Pogresh1 = new Paragraph("Погрешность методики: " + _Analis.textBox3.Text, font);
                Paragraph GradYrav = new Paragraph("Градуировочное уравнение: " + _Analis.label14.Text, font);
                Paragraph ND2 = new Paragraph("НД: " + _Analis.ND, font);

                Paragraph DateIzmer2 = new Paragraph("Данные измерений: ", font);

                Paragraph InformationAboutPribor = new Paragraph("Информация о приборе\n", font);
                var applicationDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                string model = @"pribor/model";
                DecriptorPribor decriptorModel = new DecriptorPribor(ref model, _Analis.pathTemp);
                var model_var = Path.Combine(applicationDirectory, _Analis.pathTemp + model);


                string SerNomer_Text = @"pribor/SerNomer";
                DecriptorPribor decriptorSerNomer = new DecriptorPribor(ref SerNomer_Text, _Analis.pathTemp);
                var SerNomer_Text_var = Path.Combine(applicationDirectory, _Analis.pathTemp + SerNomer_Text);

                string InventarNomer_Text = @"pribor/InventarNomer";
                DecriptorPribor decriptorInventarNomer = new DecriptorPribor(ref InventarNomer_Text, _Analis.pathTemp);
                var InventarNomer_Text_var = Path.Combine(applicationDirectory, _Analis.pathTemp + InventarNomer_Text);

                string SrokIstech_Text = @"pribor/SrokIstech";
                DecriptorPribor decriptorSrokIstech = new DecriptorPribor(ref SrokIstech_Text, _Analis.pathTemp);
                var SrokIstech_Text_var = Path.Combine(applicationDirectory, _Analis.pathTemp + SrokIstech_Text);

                string Poveren_Text = @"pribor/Poveren";
                DecriptorPribor decriptorPoveren = new DecriptorPribor(ref Poveren_Text, _Analis.pathTemp);
                var Poveren_Text_var = Path.Combine(applicationDirectory, _Analis.pathTemp + Poveren_Text);
                StreamReader fs = new StreamReader(model_var);
                Paragraph Model = new Paragraph("Модель\n" + fs.ReadLine(), font);
                fs.Close();

                StreamReader fs1 = new StreamReader(SerNomer_Text_var);
                Paragraph SerNomer = new Paragraph("Серийный номер\n" + fs1.ReadLine(), font);
                fs1.Close();

                StreamReader fs2 = new StreamReader(InventarNomer_Text_var);
                Paragraph InventarNomer = new Paragraph("Инвентарный номер\n" + fs2.ReadLine(), font);
                fs2.Close();

                StreamReader fs3 = new StreamReader(Poveren_Text_var);
                DateTime data = Convert.ToDateTime(fs3.ReadLine());
                // data.Date.ToString("d.mm.yyyy"); 
                //  MessageBox.Show(Convert.ToString(data));   
                data = data.AddYears(1);
                fs3.Close();
                Paragraph Poveren = new Paragraph("Поверка действительна до\n" + data.Date.ToString("dd.MM.yyyy"), font);


                PdfPTable Information = new PdfPTable(6);
                PdfPCell Informationcell = new PdfPCell(Model);
                Informationcell.BorderWidth = 0;
                Informationcell.Colspan = 3;
                Information.AddCell(Informationcell);

                Informationcell = new PdfPCell(SerNomer);
                Informationcell.BorderWidth = 0;
                Informationcell.Colspan = 3;
                Information.AddCell(Informationcell);

                Informationcell = new PdfPCell(Poveren);
                Informationcell.BorderWidth = 0;
                Informationcell.Colspan = 3;
                Information.AddCell(Informationcell);

                Informationcell = new PdfPCell(InventarNomer);
                Informationcell.BorderWidth = 0;
                Informationcell.Colspan = 3;
                Information.AddCell(Informationcell);
                /*  Paragraph Spectrofotometr2 = new Paragraph("Спектфотометр: ", font);
                  Paragraph Model2 = new Paragraph("Модель: __________________________", font);
                  Paragraph Date3 = new Paragraph("Поверка действительна до: __________________________", font);
                  Paragraph SerNom2 = new Paragraph("Серийный номер: __________________________", font);
                  Paragraph InventarNo2 = new Paragraph("Инветарный номер: __________________________", font);
                  */
                Paragraph Vipolnil = new Paragraph("Измерения выполнил(а): ____________________________________", font);
                Paragraph welcomeParagraph1 = new Paragraph("\n", fontBold);



                PdfPTable table = new PdfPTable(9);
                PdfPCell cell = new PdfPCell(DateTime2);
                cell.BorderWidth = 0;
                cell.Colspan = 4;
                table.AddCell(cell);

                /*  cell = new PdfPCell();
                  cell.BorderWidth = 0;
                  table.AddCell(cell);*/

                cell = new PdfPCell(WaveLength2);
                cell.BorderWidth = 0;
                cell.Colspan = 2;
                table.AddCell(cell);

                cell = new PdfPCell(Pogresh2);
                cell.BorderWidth = 0;
                cell.Colspan = 3;
                table.AddCell(cell);

                cell = new PdfPCell(Opt_dlin_cuvet2);
                cell.BorderWidth = 0;
                cell.Colspan = 4;
                table.AddCell(cell);

                cell = new PdfPCell(F1);
                cell.BorderWidth = 0;
                cell.Colspan = 2;
                table.AddCell(cell);

                cell = new PdfPCell(F2);
                cell.BorderWidth = 0;
                cell.Colspan = 3;
                table.AddCell(cell);



                PdfPTable table1 = new PdfPTable(6);
                PdfPCell cell1 = new PdfPCell(FileName1);
                cell1.BorderWidth = 0;
                cell1.Colspan = 6;
                table1.AddCell(cell1);

                /*  cell = new PdfPCell();
                  cell.BorderWidth = 0;
                  table.AddCell(cell);*/

                cell1 = new PdfPCell(Description1);
                cell1.BorderWidth = 0;
                cell1.Colspan = 6;
                table1.AddCell(cell1);

                cell1 = new PdfPCell(Date1);
                cell1.BorderWidth = 0;
                cell1.Colspan = 2;
                table1.AddCell(cell1);

                cell1 = new PdfPCell(Date2);
                cell1.BorderWidth = 0;
                cell1.Colspan = 2;
                table1.AddCell(cell1);

                cell1 = new PdfPCell(Pogresh1);
                cell1.BorderWidth = 0;
                cell1.Colspan = 2;
                table1.AddCell(cell1);

                cell1 = new PdfPCell(GradYrav);
                cell1.BorderWidth = 0;
                cell1.Colspan = 6;
                table1.AddCell(cell1);

                PdfPTable table2 = new PdfPTable(1);
                PdfPCell cell2 = new PdfPCell(table1);
                cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cell2.BorderWidth = 0;
                //cell2.Colspan = 1;
                table2.AddCell(cell2);

                PdfPTable table3 = new PdfPTable(1);
                PdfPCell cell3 = new PdfPCell(table);
                cell.HorizontalAlignment = PdfPCell.ALIGN_LEFT;
                cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                cell3.BorderWidth = 0;
                table3.AddCell(cell3);

                doc.Add(welcomeParagraph);
                doc.Add(welcomeParagraph1);
                doc.Add(FileName2);
                doc.Add(welcomeParagraph1);
                doc.Add(Description2);
                doc.Add(welcomeParagraph1);
                doc.Add(table3);
                doc.Add(welcomeParagraph1);
                doc.Add(InformationAboutPribor);
                doc.Add(welcomeParagraph1);
                doc.Add(Information);
                doc.Add(welcomeParagraph1);
                doc.Add(Graduirovka2);
                doc.Add(welcomeParagraph1);
                doc.Add(table2);
                doc.Add(welcomeParagraph1);
                doc.Add(ND2);
                // doc.Add(pdfTable);
                doc.Add(welcomeParagraph1);
                doc.Add(DateIzmer2);
                doc.Add(welcomeParagraph1);
                if (_Analis.NoCaIzm1 <= 3)
                {
                    doc.Add(pdfTable);
                }
                else
                {
                    if (_Analis.NoCaIzm1 > 3 && _Analis.NoCaIzm1 <= 5)
                    {
                        doc.Add(pdfTable);
                        doc.Add(welcomeParagraph1);
                        doc.Add(pdfTable2);
                    }
                    else
                    {
                        doc.Add(pdfTable);
                        doc.Add(welcomeParagraph1);
                        doc.Add(pdfTable2);
                    }
                }
                doc.Add(welcomeParagraph1);
                doc.Add(Vipolnil);
                // doc.Add(Chart_Image);


                doc.Close();
                // sfd.Visible = true;
            }

        }
    }
}
