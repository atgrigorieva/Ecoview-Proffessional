using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace Ecoview_Professional
{
    class Kvadratichnaya
    {
        Ecoview _Analis;
        public Kvadratichnaya(Ecoview parent)
        {
            this._Analis = parent;
            double max = -1;
            int index = -1;
            double[] SredOtklMatr = new double[_Analis.Table1.Rows.Count - 1];
            _Analis.chart1.Series[0].Points.Clear();
            _Analis.chart1.Series[1].Points.Clear();
            double x2 = 0; double x3 = 0; double x4 = 0; double xy = 0; double SUMX = 0;
            double SUMY = 0; double x2y = 0;
            double Opred; double OpredA; double OpredB; double OpredC;
            _Analis.k0 = 0; _Analis.k1 = 0; _Analis.k2 = 0;
            max = -1;
            double[] Table1masStr_1 = new double[_Analis.NoCaIzm];
            double[] Table1masStr1_1 = new double[_Analis.Table1.Rows.Count - 1];
            for (int i = 0; i < (_Analis.Table1.Rows.Count - 1); i++)
            {
                for (int j = 1; j <= _Analis.NoCaIzm; j++)
                {
                    Table1masStr_1[j - 1] = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["A;Ser (" + j].Value);
                }
                Array.Sort(Table1masStr_1);
                double maxEl = Table1masStr_1[Table1masStr_1.Length - 1];
                double minEl = Table1masStr_1[0];
                double p1 = 2 * ((maxEl - minEl) / (maxEl + minEl)) * 100;
                //  Table1.Rows[i].Cells["P"].Value = string.Format("{0:0.0000}", p1);
                Table1masStr1_1[i] = p1;
            }
            for (int i = 1; i <= Table1masStr1_1.Length; i++)
            {
                // Если максимальная стоимость меньше, либо равно текущей проверяемой
                if (max <= Table1masStr1_1[i - 1])
                {
                    // Запоминаем новое максимальное значение
                    max = Table1masStr1_1[i - 1];
                    // Запоминаем порядковый номер
                    index = i;
                }
            }
            // max = max / 100;
            //index = index + 1;
            _Analis.label21.Text = "P,% = " + string.Format("{0:0.00}", max) + "% (CO №" + index + ")";
            if (_Analis.Zavisimoct == "A(C)")
            {


               /// _Analis.radioButton4.Checked = true;

                try
                {
                    _Analis.Table1.Columns.Remove("X*X");
                    _Analis.Table1.Columns.Remove("X*Y");
                    _Analis.Table1.Columns.Remove("X*X*X");
                    _Analis.Table1.Columns.Remove("X*X*X*X");
                    _Analis.Table1.Columns.Remove("X*X*Y");
                    _Analis.Table1.Columns.Add("X*X", "Конц* Конц");
                    _Analis.Table1.Columns.Add("X*Y", "Асред* Конц");
                    _Analis.Table1.Columns.Add("X*X*X", "Асред ^3");
                    _Analis.Table1.Columns.Add("X*X*X*X", "Асред ^4");
                    _Analis.Table1.Columns.Add("X*X*Y", "Асред ^2*Конц");
                    _Analis.Table1.Columns["X*X"].Width = 50;
                    _Analis.Table1.Columns["X*Y"].Width = 50;
                    _Analis.Table1.Columns["X*X*X"].Width = 50;
                    _Analis.Table1.Columns["X*X*X*X"].Width = 50;
                    _Analis.Table1.Columns["X*X*Y"].Width = 50;
                    _Analis.Table1.Columns["X*X"].ReadOnly = true;
                    _Analis.Table1.Columns["X*Y"].ReadOnly = true;
                    _Analis.Table1.Columns["X*X*X"].ReadOnly = true;
                    _Analis.Table1.Columns["X*X*X*X"].ReadOnly = true;
                    _Analis.Table1.Columns["X*X*Y"].ReadOnly = true;
                }
                catch
                {
                    _Analis.Table1.Columns.Add("X*X", "Конц* Конц");
                    _Analis.Table1.Columns.Add("X*Y", "Асред* Конц");
                    _Analis.Table1.Columns.Add("X*X*X", "Асред ^3");
                    _Analis.Table1.Columns.Add("X*X*X*X", "Асред ^4");
                    _Analis.Table1.Columns.Add("X*X*Y", "Асред ^2*Конц");
                    _Analis.Table1.Columns["X*X"].Width = 50;
                    _Analis.Table1.Columns["X*Y"].Width = 50;
                    _Analis.Table1.Columns["X*X*X"].Width = 50;
                    _Analis.Table1.Columns["X*X*X*X"].Width = 50;
                    _Analis.Table1.Columns["X*X*Y"].Width = 50;
                    _Analis.Table1.Columns["X*X"].ReadOnly = true;
                    _Analis.Table1.Columns["X*Y"].ReadOnly = true;
                    _Analis.Table1.Columns["X*X*X"].ReadOnly = true;
                    _Analis.Table1.Columns["X*X*X*X"].ReadOnly = true;
                    _Analis.Table1.Columns["X*X*Y"].ReadOnly = true;
                }
                if (_Analis.USE_KO == false)
                {
                    USE_KO_kvadratichnaya_not();
                }
                else
                {
                    USE_KO_kvadratichnaya();
                }
            }
            else
            {

              

                try
                {
                    _Analis.Table1.Columns.Remove("X*X");
                    _Analis.Table1.Columns.Remove("X*Y");
                    _Analis.Table1.Columns.Remove("X*X*X");
                    _Analis.Table1.Columns.Remove("X*X*X*X");
                    _Analis.Table1.Columns.Remove("X*X*Y");
                    _Analis.Table1.Columns.Add("X*X", "Асред ^2");
                    _Analis.Table1.Columns.Add("X*Y", "Конц* Асред");
                    _Analis.Table1.Columns.Add("X*X*X", "Асред ^3");
                    _Analis.Table1.Columns.Add("X*X*X*X", "Асред ^4");
                    _Analis.Table1.Columns.Add("X*X*Y", "Асред ^2*Конц");
                    _Analis.Table1.Columns["X*X"].Width = 50;
                    _Analis.Table1.Columns["X*Y"].Width = 50;
                    _Analis.Table1.Columns["X*X*X"].Width = 50;
                    _Analis.Table1.Columns["X*X*X*X"].Width = 50;
                    _Analis.Table1.Columns["X*X*Y"].Width = 50;
                    _Analis.Table1.Columns["X*X"].ReadOnly = true;
                    _Analis.Table1.Columns["X*Y"].ReadOnly = true;
                    _Analis.Table1.Columns["X*X*X"].ReadOnly = true;
                    _Analis.Table1.Columns["X*X*X*X"].ReadOnly = true;
                    _Analis.Table1.Columns["X*X*Y"].ReadOnly = true;
                }
                catch
                {
                    _Analis.Table1.Columns.Add("X*X", "Асред ^2");
                    _Analis.Table1.Columns.Add("X*Y", "Конц* Асред");
                    _Analis.Table1.Columns.Add("X*X*X", "Асред ^3");
                    _Analis.Table1.Columns.Add("X*X*X*X", "Асред ^4");
                    _Analis.Table1.Columns.Add("X*X*Y", "Асред ^2*Конц");

                    _Analis.Table1.Columns["X*X"].Width = 50;
                    _Analis.Table1.Columns["X*Y"].Width = 50;
                    _Analis.Table1.Columns["X*X*X"].Width = 50;
                    _Analis.Table1.Columns["X*X*X*X"].Width = 50;
                    _Analis.Table1.Columns["X*X*Y"].Width = 50;
                    _Analis.Table1.Columns["X*X"].ReadOnly = true;
                    _Analis.Table1.Columns["X*Y"].ReadOnly = true;
                    _Analis.Table1.Columns["X*X*X"].ReadOnly = true;
                    _Analis.Table1.Columns["X*X*X*X"].ReadOnly = true;
                    _Analis.Table1.Columns["X*X*Y"].ReadOnly = true;
                }
                if (_Analis.USE_KO == false)
                {
                    USE_KO_kvadratichnaya1_not();
                }
                else
                {
                    USE_KO_kvadratichnaya1();
                }

            }
            

        }
        public void USE_KO_kvadratichnaya_not()
        {
            double max = -1;
            int index = -1;
            double[] SredOtklMatr = new double[_Analis.Table1.Rows.Count - 1];
           _Analis.chart1.Series[0].Points.Clear();
           _Analis.chart1.Series[1].Points.Clear();
            double x2 = 0; double x3 = 0; double x4 = 0; double xy = 0; double SUMX = 0;
            double SUMY = 0; double x2y = 0;
            double Opred; double OpredA; double OpredB; double OpredC;
           _Analis.k0 = 0; _Analis.k1 = 0; _Analis.k2 = 0;
            max = -1;
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {

                double y = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);
                double x = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);

                x2 += x * x;
                x3 += x * x * x;
                x4 += x * x * x * x;
                xy += x * y;
                SUMX += x;
                SUMY += y;
                x2y += x * x * y;
                _Analis.Table1.Rows[i].Cells["X*X"].Value = string.Format("{0:0.0000}", x * x);
                _Analis.Table1.Rows[i].Cells["X*Y"].Value = string.Format("{0:0.0000}", x * y);
                _Analis.Table1.Rows[i].Cells["X*X*X"].Value = string.Format("{0:0.0000}", x * x * x);
                _Analis.Table1.Rows[i].Cells["X*X*X*X"].Value = string.Format("{0:0.0000}", x * x * x * x);
                _Analis.Table1.Rows[i].Cells["X*X*Y"].Value = string.Format("{0:0.0000}", x * x * y);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["NoCo"].Value = "n = " + Convert.ToString(_Analis.Table1.Rows.Count - 1);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["Concetr"].Value = "СУММА = " + Convert.ToString(_Analis.SUMMX);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["Asred"].Value = "СУММА = " + Convert.ToString(_Analis.SUMMY);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*X"].Value = "СУММА = " + Convert.ToString(x2);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*X*X"].Value = "СУММА = " + Convert.ToString(x3);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*X*X*X"].Value = "СУММА = " + Convert.ToString(x4);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*X*Y"].Value = "СУММА = " + Convert.ToString(x2y);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*Y"].Value = "СУММА = " + Convert.ToString(xy);

            }
            double SUMMSer = 0;
            max = -1;
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double Ser1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);
                SUMMSer = 0;
                for (int j = 1; j <= _Analis.NoCaIzm; j++)
                {
                    double Ser = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["A;Ser (" + j].Value);

                    SUMMSer += (Ser - Ser1) * (Ser - Ser1);
                }
                double SredOtkl = Math.Sqrt(SUMMSer / (_Analis.NoCaIzm - 1));
                double SredOtklProc = (SredOtkl / Ser1) * 100;
                SredOtklMatr[i] = SredOtklProc;
            }

            // Цикл по всем элементам массива
            // От 0 до размера массива
            for (int i = 1; i <= SredOtklMatr.Length; i++)
            {
                // Если максимальная стоимость меньше, либо равно текущей проверяемой
                if (max <= SredOtklMatr[i - 1])
                {
                    // Запоминаем новое максимальное значение
                    max = SredOtklMatr[i - 1];
                    // Запоминаем порядковый номер
                    index = i;
                }
            }
            // max = max / 100;
            //index = index + 1;
            if (_Analis.NoCaIzm >= 3)
            {
                _Analis.SKO.Text = "СКО(А) = " + string.Format("{0:0.00}", max) + "% (CO №" + index + ")";
            }
            else
            {
                _Analis.SKO.Text = "СКО(A) - Не применимо для Nсер. < 3";
            }
            Opred = x2 * x2 * x2 + SUMX * SUMX * x4 + (_Analis.NoCaSer) * x3 * x3 - (_Analis.NoCaSer) * x2 * x4 - x2 * SUMX * x3 - SUMX * x3 * x2;
            OpredA = SUMY * x2 * x2 + SUMX * SUMX * x2y + (_Analis.NoCaSer) * xy * x3 - (_Analis.NoCaSer) * x2 * x2y - SUMY * SUMX * x3 - SUMX * xy * x2;
            OpredB = x2 * xy * x2 + SUMY * SUMX * x4 + (_Analis.NoCaSer) * x3 * x2y - (_Analis.NoCaSer) * xy * x4 - x2 * SUMX * x2y - SUMY * x3 * x2;
            OpredC = x2 * x2 * x2y + SUMX * xy * x4 + SUMY * x3 * x3 - SUMY * x2 * x4 - x2 * xy * x3 - SUMX * x3 * x2y;

            _Analis.k2 = OpredA / Opred;
            _Analis.k1 = OpredB / Opred;
           _Analis.k0 = OpredC / Opred;
            _Analis.AgroText0.Text = string.Format("{0:0.0000}",_Analis.k0);
            _Analis.AgroText1.Text = string.Format("{0:0.0000}", _Analis.k1);
            _Analis.AgroText2.Text = string.Format("{0:0.0000}", _Analis.k2);
            _Analis.label14.Text = "A(C) = " +_Analis.k0.ToString("0.0000 ;- 0.0000 ") + _Analis.k1.ToString("+ 0.0000 ;- 0.0000 ") + "*C " + _Analis.k2.ToString("+ 0.0000 ;- 0.0000 ") + "*C^2";
            max = -1;
            double[] Table1masStr1 = new double[_Analis.Table1.Rows.Count - 1];
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double x = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);
                double y = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);
                double xrasch = _Analis.k1 * x + _Analis.k2 * x * x +_Analis.k0;
                double[] Table1masStr = new double[_Analis.NoCaIzm];
                for (int j = 1; j <= _Analis.NoCaIzm; j++)
                {
                    Table1masStr[j - 1] = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["A;Ser (" + j].Value);
                }
                Array.Sort(Table1masStr);
                double maxEl = Table1masStr[Table1masStr.Length - 1];
                Table1masStr1[i] = Math.Abs(((maxEl - xrasch) * 100) / xrasch);
                //label22.Text = "Макс.Ошибка А(С) = " + string.Format("{0:0.0000}", (((maxEl - xrasch) * 100) / xrasch));
            }
            for (int i = 1; i <= Table1masStr1.Length; i++)
            {
                // Если максимальная стоимость меньше, либо равно текущей проверяемой
                if (max <= Table1masStr1[i - 1])
                {
                    // Запоминаем новое максимальное значение
                    max = Table1masStr1[i - 1];
                    // Запоминаем порядковый номер
                    index = i;
                }
            }
            // max = max / 100;
            // index = index + 1;
            _Analis.label22.Text = "Макс.Ошибка А(С) = " + string.Format("{0:0.00}", max) + "% (CO №" + index + ")";
            double yx = 0;
            double yx1 = 0;
            double SREDSUMM = 0;
            _Analis.SUMMX = 0;
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double y1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);
                _Analis.SUMMX += y1;
            }
            SREDSUMM = _Analis.SUMMX / (_Analis.Table1.Rows.Count - 1);
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double x1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);
                double y1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);

                yx += (y1 - (_Analis.k1 * x1 + _Analis.k2 * x1 * x1 +_Analis.k0)) * (y1 - (_Analis.k1 * x1 + _Analis.k2 * x1 * x1 +_Analis.k0));
                yx1 += (y1 - SREDSUMM) * (y1 - SREDSUMM);
            }
            _Analis.RR.Text = "R^2 = " + string.Format("{0:0.0000}", (1 - (yx / yx1)));

            double x2_1 = 0;
            double y0 =_Analis.k0 + _Analis.k1 * x2_1 + _Analis.k2 * x2_1 * x2_1;
           _Analis.chart1.Series[1].Points.AddXY(x2_1, y0);
            int k = 0;
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double y = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);
                double x = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);

               _Analis.chart1.Series[0].Points.AddXY(x, y);
               _Analis.chart1.Series[0].Points[k].Label = Convert.ToString(_Analis.Table1.Rows[i].Cells[0].Value);
                k++;
               _Analis.chart1.Series[0].ChartType = SeriesChartType.Point;
               _Analis.chart1.ChartAreas[0].AxisY.Crossing = 0;
               _Analis.chart1.ChartAreas[0].AxisX.Crossing = 0;

                // double x2_1 = 0.3 * i;
                x2_1 = x;
                double y2_1 =_Analis.k0 + _Analis.k1 * x2_1 + _Analis.k2 * x2_1 * x2_1;

               _Analis.chart1.Series[1].Points.AddXY(x2_1, y2_1);
               _Analis.chart1.Series[1].ChartType = SeriesChartType.Line;
               _Analis.chart1.ChartAreas[0].AxisX.Title = "Концетрация, " + _Analis.edconctr;
               _Analis.chart1.ChartAreas[0].AxisY.Title = "Оптическая плотность, А";
               _Analis.chart1.ChartAreas[0].AxisX.Minimum = 0;
                // _Analis.chart1.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(Table1.Rows[Table1.Rows.Count - 2].Cells["Concetr"].Value) + x2_1;
               _Analis.chart1.ChartAreas[0].AxisY.Minimum = 0;
                //  _Analis.chart1.ChartAreas[0].AxisY.Maximum = Math.Round((Convert.ToDouble(Table1.Rows[Table1.Rows.Count - 2].Cells["Asred"].Value) + y2_1), 2);
                //chart1.ChartAreas[0].AxisX.Interval = Math.Round((Convert.ToDouble(Table1.Rows[3].Cells["Concetr"].Value) - Convert.ToDouble(Table1.Rows[2].Cells["Concetr"].Value)), 2);
            }
            double xfin = x2_1 * 1.1;
            double yfin =_Analis.k0 + _Analis.k1 * xfin + _Analis.k2 * xfin * xfin;
           _Analis.chart1.Series[1].Points.AddXY(xfin, yfin);
        }
        public void USE_KO_kvadratichnaya()
        {
            double max = -1;
            int index = -1;
            double[] SredOtklMatr = new double[_Analis.Table1.Rows.Count - 1];
            _Analis.chart1.Series[0].Points.Clear();
            _Analis.chart1.Series[1].Points.Clear();
            double x2 = 0; double x3 = 0; double x4 = 0; double xy = 0; double SUMX = 0;
            double SUMY = 0; double x2y = 0;
            double Opred; double OpredA; double OpredB; double OpredC;
            _Analis.k0 = 0; _Analis.k1 = 0; _Analis.k2 = 0;
            double y0 = Convert.ToDouble(_Analis.Table1.Rows[0].Cells["Asred"].Value);
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {

                double y = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);
                double x = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);

                x2 += x * x;
                x3 += x * x * x;
                x4 += x * x * x * x;
                xy += x * (y - y0);
                SUMX += x;
                SUMY += (y - y0);
                x2y += x * x * (y - y0);
                _Analis.Table1.Rows[i].Cells["X*X"].Value = string.Format("{0:0.0000}", x * x);
                _Analis.Table1.Rows[i].Cells["X*Y"].Value = string.Format("{0:0.0000}", x * (y - y0));
                _Analis.Table1.Rows[i].Cells["X*X*X"].Value = string.Format("{0:0.0000}", x * x * x);
                _Analis.Table1.Rows[i].Cells["X*X*X*X"].Value = string.Format("{0:0.0000}", x * x * x * x);
                _Analis.Table1.Rows[i].Cells["X*X*Y"].Value = string.Format("{0:0.0000}", x * x * (y - y0));
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["NoCo"].Value = "n = " + Convert.ToString(_Analis.Table1.Rows.Count - 1);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["Concetr"].Value = "СУММА = " + Convert.ToString(_Analis.SUMMX);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["Asred"].Value = "СУММА = " + Convert.ToString(_Analis.SUMMY);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*X"].Value = "СУММА = " + Convert.ToString(x2);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*X*X"].Value = "СУММА = " + Convert.ToString(x3);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*X*X*X"].Value = "СУММА = " + Convert.ToString(x4);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*X*Y"].Value = "СУММА = " + Convert.ToString(x2y);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*Y"].Value = "СУММА = " + Convert.ToString(xy);

            }
            double SUMMSer = 0;
            max = -1;
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double Ser1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value) - Convert.ToDouble(_Analis.Table1.Rows[0].Cells["Asred"].Value);
                SUMMSer = 0;
                for (int j = 1; j <= _Analis.NoCaIzm; j++)
                {
                    double Ser = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["A;Ser (" + j].Value) - Convert.ToDouble(_Analis.Table1.Rows[0].Cells["A;Ser (" + j].Value);

                    SUMMSer += (Ser - Ser1) * (Ser - Ser1);
                }
                double SredOtkl = Math.Sqrt(SUMMSer / (_Analis.NoCaIzm - 1));
                double SredOtklProc = (SredOtkl / Ser1) * 100;
                SredOtklMatr[i] = SredOtklProc;
            }

            // Цикл по всем элементам массива
            // От 0 до размера массива
            for (int i = 1; i <= SredOtklMatr.Length; i++)
            {
                // Если максимальная стоимость меньше, либо равно текущей проверяемой
                if (max <= SredOtklMatr[i - 1])
                {
                    // Запоминаем новое максимальное значение
                    max = SredOtklMatr[i - 1];
                    // Запоминаем порядковый номер
                    index = i;
                }
            }
            // max = max / 100;
            index = index - 1;
            if (_Analis.NoCaIzm >= 3)
            {
                _Analis.SKO.Text = "СКО(А) = " + string.Format("{0:0.00}", max) + "% (CO №" + index + ")";
            }
            else
            {
                _Analis.SKO.Text = "СКО(A) - Не применимо для Nсер. < 3";
            }
            Opred = x2 * x2 * x2 + SUMX * SUMX * x4 + (_Analis.NoCaSer) * x3 * x3 - (_Analis.NoCaSer) * x2 * x4 - x2 * SUMX * x3 - SUMX * x3 * x2;
            OpredA = SUMY * x2 * x2 + SUMX * SUMX * x2y + (_Analis.NoCaSer) * xy * x3 - (_Analis.NoCaSer) * x2 * x2y - SUMY * SUMX * x3 - SUMX * xy * x2;
            OpredB = x2 * xy * x2 + SUMY * SUMX * x4 + (_Analis.NoCaSer) * x3 * x2y -  (_Analis.NoCaSer) * xy * x4 - x2 * SUMX * x2y - SUMY * x3 * x2;
            OpredC = x2 * x2 * x2y + SUMX * xy * x4 + SUMY * x3 * x3 - SUMY * x2 * x4 - x2 * xy * x3 - SUMX * x3 * x2y;

            _Analis.k2 = OpredA / Opred;
            _Analis.k1 = OpredB / Opred;
            _Analis.k0 = OpredC / Opred;
            _Analis.AgroText0.Text = string.Format("{0:0.0000}", _Analis.k0);
            _Analis.AgroText1.Text = string.Format("{0:0.0000}", _Analis.k1);
            _Analis.AgroText2.Text = string.Format("{0:0.0000}", _Analis.k2);
            _Analis.label14.Text = "A(C) = " + _Analis.k0.ToString("0.0000 ;- 0.0000 ") + _Analis.k1.ToString("+ 0.0000;- 0.0000") + "*C " + _Analis.k2.ToString("+ 0.0000;- 0.0000") + "*C^2";
            double[] Table1masStr1 = new double[_Analis.Table1.Rows.Count - 1];
            max = -1;
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double x = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);
                double y = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);
                double xrasch = _Analis.k1 * x + _Analis.k2 * x * x + _Analis.k0;
                double[] Table1masStr = new double[_Analis.NoCaIzm];
                for (int j = 1; j <= _Analis.NoCaIzm; j++)
                {
                    Table1masStr[j - 1] = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["A;Ser (" + j].Value) - Convert.ToDouble(_Analis.Table1.Rows[0].Cells["A;Ser (" + j].Value);
                }
                Array.Sort(Table1masStr);
                double maxEl = Table1masStr[Table1masStr.Length - 1];
                Table1masStr1[i] = Math.Abs(((maxEl - xrasch) * 100) / xrasch);
                //label22.Text = "Макс.Ошибка А(С) = " + string.Format("{0:0.0000}", (((maxEl - xrasch) * 100) / xrasch));
            }
            for (int i = 1; i <= Table1masStr1.Length; i++)
            {
                // Если максимальная стоимость меньше, либо равно текущей проверяемой
                if (max <= Table1masStr1[i - 1])
                {
                    // Запоминаем новое максимальное значение
                    max = Table1masStr1[i - 1];
                    // Запоминаем порядковый номер
                    index = i;
                }
            }
            // max = max / 100;
            index = index - 1;
            _Analis.label22.Text = "Макс.Ошибка А(С) = " + string.Format("{0:0.00}", max) + "% (CO №" + index + ")";
            y0 = Convert.ToDouble(_Analis.Table1.Rows[0].Cells["Asred"].Value);
            double x0 = Convert.ToDouble(_Analis.Table1.Rows[0].Cells["Concetr"].Value);
            double yx = 0;
            double yx1 = 0;
            double SREDSUMM = 0;
            _Analis.SUMMX = 0;
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double y1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);
                _Analis.SUMMX += y1;
            }
            SREDSUMM = _Analis.SUMMX / (_Analis.Table1.Rows.Count - 1);
            for (int i = 0; i < (_Analis.Table1.Rows.Count - 1); i++)
            {
                double x1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);
                double y1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);

                yx += (y1 - y0 - (_Analis.k1 * x1 + _Analis.k2 * x1 * x1 + _Analis.k0)) * (y1 - y0 - (_Analis.k1 * x1 + _Analis.k2 * x1 * x1 + _Analis.k0));
                yx1 += (y1 - y0 - SREDSUMM) * (y1 - y0 - SREDSUMM);
            }
            _Analis.RR.Text = "R^2 = " + string.Format("{0:0.0000}", (1 - (yx / yx1)));
            double x2_1 = x0;
            double y2_1 = _Analis.k0 + _Analis.k1 * x2_1 + _Analis.k2 * x2_1 * x2_1;

            _Analis.chart1.Series[1].Points.AddXY(x2_1, y2_1);
            int k = 0;
            for (int i = 1; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double y = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);
                double x = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);

                _Analis.chart1.Series[0].Points.AddXY(x, (y - y0));
                _Analis.chart1.Series[0].Points[k].Label = Convert.ToString(_Analis.Table1.Rows[i].Cells[0].Value);
                k++;
                _Analis.chart1.Series[0].ChartType = SeriesChartType.Point;
                _Analis.chart1.ChartAreas[0].AxisY.Crossing = 0;
                _Analis.chart1.ChartAreas[0].AxisX.Crossing = 0;

                // double x2_1 = 0.3 * i;
                x2_1 = x;
                y2_1 = _Analis.k0 + _Analis.k1 * x2_1 + _Analis.k2 * x2_1 * x2_1;

                _Analis.chart1.Series[1].Points.AddXY(x2_1, y2_1);
                _Analis.chart1.Series[1].ChartType = SeriesChartType.Line;
                _Analis.chart1.ChartAreas[0].AxisX.Title = "Концетрация, " + _Analis.edconctr;
                _Analis.chart1.ChartAreas[0].AxisY.Title = "Оптическая плотность, А";
                _Analis.chart1.ChartAreas[0].AxisX.Minimum = 0;
                //  chart1.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(Table1.Rows[Table1.Rows.Count - 2].Cells["Concetr"].Value) + x2_1;
                _Analis.chart1.ChartAreas[0].AxisY.Minimum = 0;
                //   chart1.ChartAreas[0].AxisY.Maximum = Math.Round((Convert.ToDouble(Table1.Rows[Table1.Rows.Count - 2].Cells["Asred"].Value) + y2_1), 2);
                //chart1.ChartAreas[0].AxisX.Interval = Math.Round((Convert.ToDouble(Table1.Rows[3].Cells["Concetr"].Value) - Convert.ToDouble(Table1.Rows[2].Cells["Concetr"].Value)), 2);
            }
            double xfin = x2_1 * 1.1;
            double yfin = _Analis.k0 + _Analis.k1 * xfin + _Analis.k2 * xfin * xfin;
            _Analis.chart1.Series[1].Points.AddXY(xfin, yfin);
        }
        public void USE_KO_kvadratichnaya1_not()
        {
            double max = -1;
            int index = -1;
            double[] SredOtklMatr = new double[_Analis.Table1.Rows.Count - 1];
            _Analis.chart1.Series[0].Points.Clear();
            _Analis.chart1.Series[1].Points.Clear();
            double x2 = 0; double x3 = 0; double x4 = 0; double xy = 0; double SUMX = 0;
            double SUMY = 0; double x2y = 0;
            double Opred; double OpredA; double OpredB; double OpredC;
            _Analis.k0 = 0; _Analis.k1 = 0; _Analis.k2 = 0;
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double x = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);
                double y = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);

                x2 += x * x;
                x3 += x * x * x;
                x4 += x * x * x * x;
                xy += x * y;
                SUMX += x;
                SUMY += y;
                x2y += x * x * y;
                _Analis.Table1.Rows[i].Cells["X*X"].Value = string.Format("{0:0.0000}", x * x);
                _Analis.Table1.Rows[i].Cells["X*X*X"].Value = string.Format("{0:0.0000}", x * x * x);
                _Analis.Table1.Rows[i].Cells["X*X*X*X"].Value = string.Format("{0:0.0000}", x * x * x * x);
                _Analis.Table1.Rows[i].Cells["X*X*Y"].Value = string.Format("{0:0.0000}", x * x * y);
                _Analis.Table1.Rows[i].Cells["X*Y"].Value = string.Format("{0:0.0000}", x * y);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["NoCo"].Value = "n = " + Convert.ToString(_Analis.Table1.Rows.Count - 1);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["Asred"].Value = "СУММА = " + Convert.ToString(_Analis.SUMMX);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["Concetr"].Value = "СУММА = " + Convert.ToString(_Analis.SUMMY);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*X"].Value = "СУММА = " + Convert.ToString(x2);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*X*X"].Value = "СУММА = " + Convert.ToString(x3);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*X*X*X"].Value = "СУММА = " + Convert.ToString(x4);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*X*Y"].Value = "СУММА = " + Convert.ToString(x2y);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*Y"].Value = "СУММА = " + Convert.ToString(xy);
            }
            Opred = x2 * x2 * x2 + SUMX * SUMX * x4 + (_Analis.NoCaSer) * x3 * x3 - (_Analis.NoCaSer) * x2 * x4 - x2 * SUMX * x3 - SUMX * x3 * x2;
            OpredA = SUMY * x2 * x2 + SUMX * SUMX * x2y + (_Analis.NoCaSer) * xy * x3 - (_Analis.NoCaSer) * x2 * x2y - SUMY * SUMX * x3 - SUMX * xy * x2;
            OpredB = x2 * xy * x2 + SUMY * SUMX * x4 + (_Analis.NoCaSer) * x3 * x2y - (_Analis.NoCaSer) * xy * x4 - x2 * SUMX * x2y - SUMY * x3 * x2;
            OpredC = x2 * x2 * x2y + SUMX * xy * x4 + SUMY * x3 * x3 - SUMY * x2 * x4 - x2 * xy * x3 - SUMX * x3 * x2y;

            _Analis.k2 = OpredA / Opred;
            _Analis.k1 = OpredB / Opred;
            _Analis.k0 = OpredC / Opred;
            _Analis.AgroText0.Text = string.Format("{0:0.0000}", _Analis.k0);
            _Analis.AgroText1.Text = string.Format("{0:0.0000}", _Analis.k1);
            _Analis.AgroText2.Text = string.Format("{0:0.0000}", _Analis.k2);
            _Analis.label14.Text = "C(A) = " + _Analis.k0.ToString("0.0000 ;- 0.0000 ") + _Analis.k1.ToString("+ 0.0000;- 0.0000") + "*A " + _Analis.k2.ToString("+ 0.0000;- 0.0000") + "*A^2";
            max = -1;
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double Ser1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value) * _Analis.k1 + Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value) * Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value) * _Analis.k2 + _Analis.k0;
                double SUMMSer = 0;
                for (int j = 1; j <= _Analis.NoCaIzm; j++)
                {
                    double Ser = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["A;Ser (" + j].Value) * _Analis.k1 + Convert.ToDouble(_Analis.Table1.Rows[i].Cells["A;Ser (" + j].Value) * Convert.ToDouble(_Analis.Table1.Rows[i].Cells["A;Ser (" + j].Value) * _Analis.k2 + _Analis.k0;

                    SUMMSer += (Ser - Ser1) * (Ser - Ser1);
                }
                double SredOtkl = Math.Sqrt(SUMMSer / (_Analis.NoCaIzm - 1));
                double SredOtklProc = (SredOtkl / Ser1) * 100;
                SredOtklMatr[i] = SredOtklProc;
            }

            // Цикл по всем элементам массива
            // От 0 до размера массива
            for (int i = 1; i <= SredOtklMatr.Length; i++)
            {
                // Если максимальная стоимость меньше, либо равно текущей проверяемой
                if (max <= SredOtklMatr[i - 1])
                {
                    // Запоминаем новое максимальное значение
                    max = SredOtklMatr[i - 1];
                    // Запоминаем порядковый номер
                    index = i;
                }
            }
            // max = max / 100;
            // index = index + 1;
            if (_Analis.NoCaIzm >= 3)
            {
                _Analis.SKO.Text = "СКО(C) = " + string.Format("{0:0.00}", max) + "% (CO №" + index + ")";
            }
            else
            {
                _Analis.Text = "СКО(C) - Не применимо для Nсер. < 3";
            }
            max = -1;
            double[] Table1masStr1 = new double[_Analis.Table1.Rows.Count - 1];
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double x = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);
                //  double y = Convert.ToDouble(Table1.Rows[i].Cells["Asred"].Value);
                //double xrasch = k1 * x;
                double[] Table1masStr = new double[_Analis.NoCaIzm];
                for (int j = 1; j <= _Analis.NoCaIzm; j++)
                {
                    Table1masStr[j - 1] = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["A;Ser (" + j].Value) * _Analis.k1 + Convert.ToDouble(_Analis.Table1.Rows[i].Cells["A;Ser (" + j].Value) * Convert.ToDouble(_Analis.Table1.Rows[i].Cells["A;Ser (" + j].Value) * _Analis.k2 + _Analis.k0;
                }
                Array.Sort(Table1masStr);
                double maxEl = Table1masStr[Table1masStr.Length - 1];
                Table1masStr1[i] = Math.Abs(((maxEl - x) * 100) / x);
                //label22.Text = "Макс.Ошибка А(С) = " + string.Format("{0:0.0000}", (((maxEl - xrasch) * 100) / xrasch));
            }
            for (int i = 1; i <= Table1masStr1.Length; i++)
            {
                // Если максимальная стоимость меньше, либо равно текущей проверяемой
                if (max <= Table1masStr1[i - 1])
                {
                    // Запоминаем новое максимальное значение
                    max = Table1masStr1[i - 1];
                    // Запоминаем порядковый номер
                    index = i;
                }
            }
            // max = max / 100;
            //index = index + 1;
            _Analis.label22.Text = "Макс.Ошибка А(С) = " + string.Format("{0:0.00}", max) + "% (CO №" + index + ")";
            double yx = 0;
            double yx1 = 0;
            double SREDSUMM = 0;
            _Analis.SUMMX = 0;
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double y1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);
                _Analis.SUMMX += y1;
            }
            SREDSUMM = _Analis.SUMMX / (_Analis.Table1.Rows.Count - 1);
            for (int i = 0; i < (_Analis.Table1.Rows.Count - 1); i++)
            {
                double x1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);
                double y1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);

                yx += (x1 - (_Analis.k1 * y1 + _Analis.k2 * y1 * y1 + _Analis.k0)) * (x1 - (_Analis.k1 * y1 + _Analis.k2 * y1 * y1 + _Analis.k0));
                yx1 += (x1 - SREDSUMM) * (x1 - SREDSUMM);
            }
            _Analis.RR.Text = "R^2 = " + string.Format("{0:0.0000}", (1 - (yx / yx1)));
            double x2_1 = 0;
            double y0 = _Analis.k0 + _Analis.k1 * x2_1 + _Analis.k2 * x2_1 * x2_1;
            _Analis.chart1.Series[1].Points.AddXY(x2_1, y0);
            int k = 0;
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double x = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);
                double y = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);

                _Analis.chart1.Series[0].Points.AddXY(x, y);
                _Analis.chart1.Series[0].Points[k].Label = Convert.ToString(_Analis.Table1.Rows[i].Cells[0].Value);
                k++;
                _Analis.chart1.Series[0].ChartType = SeriesChartType.Point;
                _Analis.chart1.ChartAreas[0].AxisY.Crossing = 0;
                _Analis.chart1.ChartAreas[0].AxisX.Crossing = 0;
                x2_1 = x;
                double y2_1 = _Analis.k0 + _Analis.k1 * x2_1 + _Analis.k2 * x2_1 * x2_1;

                _Analis.chart1.Series[1].Points.AddXY(x2_1, y2_1);
                _Analis.chart1.Series[1].ChartType = SeriesChartType.Line;
                _Analis.chart1.ChartAreas[0].AxisX.Title = "Оптическая плотность, А";
                _Analis.chart1.ChartAreas[0].AxisY.Title = "Концетрация, " + _Analis.edconctr;
                _Analis.chart1.ChartAreas[0].AxisX.Minimum = 0;
                //  chart1.ChartAreas[0].AxisX.Maximum = Math.Round((Convert.ToDouble(Table1.Rows[Table1.Rows.Count - 2].Cells["Asred"].Value) + x2_1), 2);
                _Analis.chart1.ChartAreas[0].AxisY.Minimum = 0;
                //   chart1.ChartAreas[0].AxisY.Maximum = Math.Round((Convert.ToDouble(Table1.Rows[Table1.Rows.Count - 2].Cells["Concetr"].Value) + y2_1), 2);
                //   chart1.ChartAreas[0].AxisX.Interval = Math.Round((Convert.ToDouble(Table1.Rows[3].Cells["Asred"].Value) - Convert.ToDouble(Table1.Rows[2].Cells["Asred"].Value)+ (Convert.ToDouble(Table1.Rows[3].Cells["Asred"].Value) - Convert.ToDouble(Table1.Rows[2].Cells["Asred"].Value))), 2);
                //  chart1.ChartAreas[0].AxisX.Interval = 5;
            }
        }
        public void USE_KO_kvadratichnaya1()
        {
            double max = -1;
            int index = -1;
            double[] SredOtklMatr = new double[_Analis.Table1.Rows.Count - 1];
            _Analis.chart1.Series[0].Points.Clear();
            _Analis.chart1.Series[1].Points.Clear();
            double x2 = 0; double x3 = 0; double x4 = 0; double xy = 0; double SUMX = 0;
            double SUMY = 0; double x2y = 0;
            double Opred; double OpredA; double OpredB; double OpredC;
            _Analis.k0 = 0; _Analis.k1 = 0; _Analis.k2 = 0;
            double x0 = Convert.ToDouble(_Analis.Table1.Rows[0].Cells["Asred"].Value);
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double x = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);
                double y = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);

                x2 += (x - x0) * (x - x0);
                x3 += (x - x0) * (x - x0) * (x - x0);
                x4 += (x - x0) * (x - x0) * (x - x0) * (x - x0);
                xy += (x - x0) * y;
                SUMX += (x - x0);
                SUMY += y;
                x2y += (x - x0) * (x - x0) * y;
                _Analis.Table1.Rows[i].Cells["X*X"].Value = string.Format("{0:0.0000}", (x - x0) * (x - x0));
                _Analis.Table1.Rows[i].Cells["X*X*X"].Value = string.Format("{0:0.0000}", (x - x0) * (x - x0) * (x - x0));
                _Analis.Table1.Rows[i].Cells["X*X*X*X"].Value = string.Format("{0:0.0000}", (x - x0) * (x - x0) * (x - x0) * (x - x0));
                _Analis.Table1.Rows[i].Cells["X*X*Y"].Value = string.Format("{0:0.0000}", (x - x0) * (x - x0) * y);
                _Analis.Table1.Rows[i].Cells["X*Y"].Value = string.Format("{0:0.0000}", (x - x0) * y);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["NoCo"].Value = "n = " + Convert.ToString(_Analis.Table1.Rows.Count - 1);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["Asred"].Value = "СУММА = " + Convert.ToString(_Analis.SUMMX);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["Concetr"].Value = "СУММА = " + Convert.ToString(_Analis.SUMMY);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*X"].Value = "СУММА = " + Convert.ToString(x2);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*X*X"].Value = "СУММА = " + Convert.ToString(x3);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*X*X*X"].Value = "СУММА = " + Convert.ToString(x4);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*X*Y"].Value = "СУММА = " + Convert.ToString(x2y);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*Y"].Value = "СУММА = " + Convert.ToString(xy);
            }
            Opred = x2 * x2 * x2 + SUMX * SUMX * x4 + (_Analis.NoCaSer) * x3 * x3 - (_Analis.NoCaSer) * x2 * x4 - x2 * SUMX * x3 - SUMX * x3 * x2;
            OpredA = SUMY * x2 * x2 + SUMX * SUMX * x2y + (_Analis.NoCaSer) * xy * x3 - (_Analis.NoCaSer) * x2 * x2y - SUMY * SUMX * x3 - SUMX * xy * x2;
            OpredB = x2 * xy * x2 + SUMY * SUMX * x4 + (_Analis.NoCaSer) * x3 * x2y - (_Analis.NoCaSer) * xy * x4 - x2 * SUMX * x2y - SUMY * x3 * x2;
            OpredC = x2 * x2 * x2y + SUMX * xy * x4 + SUMY * x3 * x3 - SUMY * x2 * x4 - x2 * xy * x3 - SUMX * x3 * x2y;

            _Analis.k2 = OpredA / Opred;
            _Analis.k1 = OpredB / Opred;
            _Analis.k0 = OpredC / Opred;
            _Analis.AgroText0.Text = string.Format("{0:0.0000}", _Analis.k0);
            _Analis.AgroText1.Text = string.Format("{0:0.0000}", _Analis.k1);
            _Analis.AgroText2.Text = string.Format("{0:0.0000}", _Analis.k2);
            _Analis.label14.Text = "C(A) = " + _Analis.k0.ToString("0.0000 ;- 0.0000 ") + _Analis.k1.ToString("+ 0.0000;- 0.0000") + "*A " + _Analis.k2.ToString("+ 0.0000;- 0.0000") + "*A^2";
            max = -1;
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double Ser1 = (Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value) - Convert.ToDouble(_Analis.Table1.Rows[0].Cells["Asred"].Value)) * _Analis.k1 + (Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value) - Convert.ToDouble(_Analis.Table1.Rows[0].Cells["Asred"].Value)) * (Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value) - Convert.ToDouble(_Analis.Table1.Rows[0].Cells["Asred"].Value)) * _Analis.k2 + _Analis.k0;
                double SUMMSer = 0;
                for (int j = 1; j <= _Analis.NoCaIzm; j++)
                {
                    double Ser = (Convert.ToDouble(_Analis.Table1.Rows[i].Cells["A;Ser (" + j].Value) - Convert.ToDouble(_Analis.Table1.Rows[0].Cells["A;Ser (" + j].Value)) * _Analis.k1 + (Convert.ToDouble(_Analis.Table1.Rows[i].Cells["A;Ser (" + j].Value) - Convert.ToDouble(_Analis.Table1.Rows[0].Cells["A;Ser (" + j].Value)) * (Convert.ToDouble(_Analis.Table1.Rows[i].Cells["A;Ser (" + j].Value) - Convert.ToDouble(_Analis.Table1.Rows[0].Cells["A;Ser (" + j].Value)) * _Analis.k2 + _Analis.k0;

                    SUMMSer += (Ser - Ser1) * (Ser - Ser1);
                }
                double SredOtkl = Math.Sqrt(SUMMSer / (_Analis.NoCaIzm - 1));
                double SredOtklProc = (SredOtkl / Ser1) * 100;
                SredOtklMatr[i] = SredOtklProc;
            }

            // Цикл по всем элементам массива
            // От 0 до размера массива
            for (int i = 1; i <= SredOtklMatr.Length; i++)
            {
                // Если максимальная стоимость меньше, либо равно текущей проверяемой
                if (max <= SredOtklMatr[i - 1])
                {
                    // Запоминаем новое максимальное значение
                    max = SredOtklMatr[i - 1];
                    // Запоминаем порядковый номер
                    index = i;
                }
            }
            // max = max / 100;
            index = index - 1;
            if (_Analis.NoCaIzm >= 3)
            {
                _Analis.SKO.Text = "СКО(C) = " + string.Format("{0:0.00}", max) + "% (CO №" + index + ")";
            }
            else
            {
                _Analis.SKO.Text = "СКО(C) - Не применимо для Nсер. < 3";
            }
            max = -1;
            double[] Table1masStr1 = new double[_Analis.Table1.Rows.Count - 1];
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double x = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);
                //  double y = Convert.ToDouble(Table1.Rows[i].Cells["Asred"].Value);
                //double xrasch = k1 * x;
                double[] Table1masStr = new double[_Analis.NoCaIzm];
                for (int j = 1; j <= _Analis.NoCaIzm; j++)
                {
                    Table1masStr[j - 1] = (Convert.ToDouble(_Analis.Table1.Rows[i].Cells["A;Ser (" + j].Value) - Convert.ToDouble(_Analis.Table1.Rows[0].Cells["A;Ser (" + j].Value)) * _Analis.k1 + (Convert.ToDouble(_Analis.Table1.Rows[i].Cells["A;Ser (" + j].Value) - Convert.ToDouble(_Analis.Table1.Rows[0].Cells["A;Ser (" + j].Value)) * (Convert.ToDouble(_Analis.Table1.Rows[i].Cells["A;Ser (" + j].Value) - Convert.ToDouble(_Analis.Table1.Rows[0].Cells["A;Ser (" + j].Value)) * _Analis.k2 + _Analis.k0;
                }
                Array.Sort(Table1masStr);
                double maxEl = Table1masStr[Table1masStr.Length - 1];
                Table1masStr1[i] = Math.Abs(((maxEl - x) * 100) / x);
                //label22.Text = "Макс.Ошибка А(С) = " + string.Format("{0:0.0000}", (((maxEl - xrasch) * 100) / xrasch));
            }
            for (int i = 1; i <= Table1masStr1.Length; i++)
            {
                // Если максимальная стоимость меньше, либо равно текущей проверяемой
                if (max <= Table1masStr1[i - 1])
                {
                    // Запоминаем новое максимальное значение
                    max = Table1masStr1[i - 1];
                    // Запоминаем порядковый номер
                    index = i;
                }
            }
            // max = max / 100;
            index = index - 1;
            _Analis.label22.Text = "Макс.Ошибка А(С) = " + string.Format("{0:0.00}", max) + "% (CO №" + index + ")";
            double y0 = Convert.ToDouble(_Analis.Table1.Rows[0].Cells["Concetr"].Value);
            x0 = Convert.ToDouble(_Analis.Table1.Rows[0].Cells["Asred"].Value);
            double yx = 0;
            double yx1 = 0;
            double SREDSUMM = 0;
            _Analis.SUMMX = 0;
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double y1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);
                _Analis.SUMMX += y1;
            }
            SREDSUMM = _Analis.SUMMX / (_Analis.Table1.Rows.Count - 1);
            for (int i = 0; i < (_Analis.Table1.Rows.Count - 1); i++)
            {
                double x1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);
                double y1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);

                yx += (x1 - (_Analis.k1 * (y1 - x0) + _Analis.k2 * (y1 - x0) * (y1 - x0) + _Analis.k0)) * (x1 - (_Analis.k1 * (y1 - x0) + _Analis.k2 * (y1 - x0) * (y1 - x0) + _Analis.k0));
                yx1 += (x1 - SREDSUMM) * (x1 - SREDSUMM);
            }
            _Analis.RR.Text = "R^2 = " + string.Format("{0:0.0000}", (1 - (yx / yx1)));
            double x2_1 = x0 - x0;
            double y2_1 = _Analis.k0 + _Analis.k1 * x2_1 + _Analis.k2 * x2_1 * x2_1;

            _Analis.chart1.Series[1].Points.AddXY(x2_1, y2_1);
            int k = 0;
            for (int i = 1; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double x = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);
                double y = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);

                _Analis.chart1.Series[0].Points.AddXY((x - x0), y);
                _Analis.chart1.Series[0].Points[k].Label = Convert.ToString(_Analis.Table1.Rows[i].Cells[0].Value);
                k++;
                _Analis.chart1.Series[0].ChartType = SeriesChartType.Point;
                _Analis.chart1.ChartAreas[0].AxisY.Crossing = 0;
                _Analis.chart1.ChartAreas[0].AxisX.Crossing = 0;
                x2_1 = x - x0;
                y2_1 = _Analis.k0 + _Analis.k1 * x2_1 + _Analis.k2 * x2_1 * x2_1;

                _Analis.chart1.Series[1].Points.AddXY(x2_1, y2_1);
                _Analis.chart1.Series[1].ChartType = SeriesChartType.Line;
                _Analis.chart1.ChartAreas[0].AxisX.Title = "Оптическая плотность, А";
                _Analis.chart1.ChartAreas[0].AxisY.Title = "Концетрация, " + _Analis.edconctr;
                _Analis.chart1.ChartAreas[0].AxisX.Minimum = 0;
                //  chart1.ChartAreas[0].AxisX.Maximum = Math.Round((Convert.ToDouble(Table1.Rows[Table1.Rows.Count - 2].Cells["Asred"].Value) + x2_1), 2);
                _Analis.chart1.ChartAreas[0].AxisY.Minimum = 0;
                //   chart1.ChartAreas[0].AxisY.Maximum = Math.Round((Convert.ToDouble(Table1.Rows[Table1.Rows.Count - 2].Cells["Concetr"].Value) + y2_1), 2);
                //   chart1.ChartAreas[0].AxisX.Interval = Math.Round((Convert.ToDouble(Table1.Rows[3].Cells["Asred"].Value) - Convert.ToDouble(Table1.Rows[2].Cells["Asred"].Value)+ (Convert.ToDouble(Table1.Rows[3].Cells["Asred"].Value) - Convert.ToDouble(Table1.Rows[2].Cells["Asred"].Value))), 2);
                //  chart1.ChartAreas[0].AxisX.Interval = 5;
            }
            double xfin = x2_1 * 1.1;
            double yfin = _Analis.k0 + _Analis.k1 * xfin + _Analis.k2 * xfin * xfin;
            _Analis.chart1.Series[1].Points.AddXY(xfin, yfin);
        }
    }
}
