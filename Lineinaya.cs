using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace Ecoview_Professional
{
    class Lineinaya
    {
        Ecoview _Analis;
        public Lineinaya(Ecoview parent)
        {
            this._Analis = parent;
            double max = -1;
            int index = -1;
            double[] SredOtklMatr = new double[_Analis.Table1.Rows.Count - 1];
            double SUMMSer = 0;
            double SREDSUMMX = 0;
            double SUMMX1 = 0;
            _Analis.chart1.Series[0].Points.Clear();
            _Analis.chart1.Series[1].Points.Clear();
            _Analis.k0 = 0; _Analis.k1 = 0; _Analis.k2 = 0;
            _Analis.SUM0 = 0; _Analis.SUM1 = 0;
            _Analis.SUMMX = 0; _Analis.SUMMY = 0; _Analis.XY = 0; _Analis.SUMMY2 = 0;
            _Analis.AgroText0.Text = string.Format("{0:0.0000}", 0);
            _Analis.AgroText1.Text = string.Format("{0:0.0000}", 0);
            _Analis.AgroText0.Text = string.Format("{0:0.0000}", 0);
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
            //  index = index + 1;
            _Analis.label21.Text = "P,% = " + string.Format("{0:0.00}", max) + "% (CO №" + index + ")";
            if (_Analis.Zavisimoct == "A(C)")
            {

                try
                {
                    _Analis.Table1.Columns.Remove("X*X");
                    _Analis.Table1.Columns.Remove("X*Y");
                    _Analis.Table1.Columns.Remove("X*X*X");
                    _Analis.Table1.Columns.Remove("X*X*X*X");
                    _Analis.Table1.Columns.Remove("X*X*Y");
                    _Analis.Table1.Columns.Add("X*X", "Конц* Конц");
                    _Analis.Table1.Columns.Add("X*Y", "Конц* Асред");
                    _Analis.Table1.Columns["X*X"].Width = 50;
                    _Analis.Table1.Columns["X*Y"].Width = 50;
                    _Analis.Table1.Columns["X*X"].ReadOnly = true;
                    _Analis.Table1.Columns["X*Y"].ReadOnly = true;
                }



                catch
                {
                    _Analis.Table1.Columns.Add("X*X", "Конц* Конц");
                    _Analis.Table1.Columns.Add("X*Y", "Конц* Асред");
                    _Analis.Table1.Columns["X*X"].Width = 50;
                    _Analis.Table1.Columns["X*Y"].Width = 50;
                    _Analis.Table1.Columns["X*X"].ReadOnly = true;
                    _Analis.Table1.Columns["X*Y"].ReadOnly = true;
                }
                if (_Analis.USE_KO == false)
                {
                    USE_KO_lineinaya_not();
                }
                else
                {
                    USE_KO_lineinaya();
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
                    _Analis.Table1.Columns.Add("X*X", "Асред* Асред");
                    _Analis.Table1.Columns.Add("X*Y", "Конц* Асред");
                    _Analis.Table1.Columns["X*X"].Width = 50;
                    _Analis.Table1.Columns["X*Y"].Width = 50;
                    _Analis.Table1.Columns["X*X"].ReadOnly = true;
                    _Analis.Table1.Columns["X*Y"].ReadOnly = true;
                }
                catch
                {
                    _Analis.Table1.Columns.Add("X*X", "Асред* Асред");
                    _Analis.Table1.Columns.Add("X*Y", "Конц* Асред");
                    _Analis.Table1.Columns["X*X"].Width = 50;
                    _Analis.Table1.Columns["X*Y"].Width = 50;
                    _Analis.Table1.Columns["X*X"].ReadOnly = true;
                    _Analis.Table1.Columns["X*Y"].ReadOnly = true;
                }


                if (_Analis.USE_KO == false)
                {
                    USE_KO_lineinaya1_not();
                }
                else
                {
                    USE_KO_lineinaya1();
                }
            }
        }
        public void USE_KO_lineinaya_not()
        {
            double max = -1;
            int index = -1;
            double[] SredOtklMatr = new double[_Analis.Table1.Rows.Count - 1];
            double SUMMSer = 0;
            double SREDSUMMX = 0;
            double SUMMX1 = 0;
            _Analis.chart1.Series[0].Points.Clear();
            _Analis.chart1.Series[1].Points.Clear();

            _Analis.k0 = 0; _Analis.k1 = 0; _Analis.k2 = 0;
            _Analis.SUM0 = 0; _Analis.SUM1 = 0;
            _Analis.SUMMX = 0; _Analis.SUMMY = 0; _Analis.XY = 0; _Analis.SUMMY2 = 0;
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double x = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);
                double y = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);
                // double y0 = Convert.ToDouble(Table1.Rows[0].Cells["Concetr"].Value);
                double y1 = Convert.ToDouble(_Analis.Table1.Rows[_Analis.Table1.Rows.Count - 2].Cells["Concetr"].Value);
                // double x0 = Convert.ToDouble(Table1.Rows[0].Cells["Asred"].Value);
                double x1 = Convert.ToDouble(_Analis.Table1.Rows[_Analis.Table1.Rows.Count - 2].Cells["Asred"].Value);
                _Analis.SUMMX += x; _Analis.SUMMY += y;
                _Analis.XY += x * y;
                _Analis.SUMMY2 += y * y;
                _Analis.Table1.Rows[i].Cells["X*X"].Value = y * y;
                _Analis.Table1.Rows[i].Cells["X*Y"].Value = x * y;
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["NoCo"].Value = "n = " + Convert.ToString(_Analis.Table1.Rows.Count - 1);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["Asred"].Value = "СУММА = " + Convert.ToString(_Analis.SUMMX);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["Concetr"].Value = "СУММА = " + Convert.ToString(_Analis.SUMMY);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*X"].Value = "СУММА = " + Convert.ToString(_Analis.SUMMY2);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*Y"].Value = "СУММА = " + Convert.ToString(_Analis.XY);
            }

            SREDSUMMX = _Analis.SUMMX / (_Analis.Table1.Rows.Count - 1);
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
            _Analis.k0 = (_Analis.SUMMY2 * _Analis.SUMMX - _Analis.SUMMY * _Analis.XY) / ((_Analis.NoCaSer) * _Analis.SUMMY2 - _Analis.SUMMY * _Analis.SUMMY);
            _Analis.k1 = ((_Analis.NoCaSer) * _Analis.XY - _Analis.SUMMY * _Analis.SUMMX) / ((_Analis.NoCaSer) * _Analis.SUMMY2 - _Analis.SUMMY * _Analis.SUMMY);
            _Analis.AgroText0.Text = string.Format("{0:0.0000}", _Analis.k0);
            _Analis.AgroText1.Text = string.Format("{0:0.0000}", _Analis.k1);
            _Analis.AgroText2.Text = string.Format("{0:0.0000}", 0);
            max = -1;
            double[] Table1masStr1 = new double[_Analis.Table1.Rows.Count - 1];
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double x = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);
                double y = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);
                double xrasch = _Analis.k1 * x + _Analis.k0;
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
            //index = index + 1;
            _Analis.label22.Text = "Макс.Ошибка А(С) = " + string.Format("{0:0.00}", max) + "% (CO №" + index + ")";
            double y2 = 0;
            _Analis.label14.Text = "A(C) = " + _Analis.k1.ToString("0.0000 ;- 0.0000 ") + "*C " + _Analis.k0.ToString("+ 0.0000 ;- 0.0000 ");

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
            for (int i = 0; i < (_Analis.Table1.Rows.Count - 1); i++)
            {
                double x1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);
                double y1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);

                yx += (y1 - (_Analis.k1 * x1 + _Analis.k0)) * (y1 - (_Analis.k1 * x1 + _Analis.k0));
                yx1 += (y1 - SREDSUMM) * (y1 - SREDSUMM);
            }
            _Analis.RR.Text = "R^2 = " + string.Format("{0:0.0000}", (1 - (yx / yx1)));

            double x0 = 0;
            double y0 = x0 * _Analis.k1 + _Analis.k0;
            _Analis.chart1.Series[1].Points.AddXY(x0, y0);
            int k = 0;
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                _Analis.circle = 1;
                double x1_1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);
                double y1_1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);



                // chart1.ChartAreas[0].AxisY.Crossing = k0;
                _Analis.chart1.Series[0].Points.AddXY(y1_1, x1_1);
                _Analis.chart1.Series[0].Points[k].Label = Convert.ToString(_Analis.Table1.Rows[i].Cells[0].Value);
                k++; 
                _Analis.chart1.Series[0].ChartType = SeriesChartType.Point;
                _Analis.chart1.ChartAreas[0].AxisY.Crossing = 0;
                _Analis.chart1.ChartAreas[0].AxisX.Crossing = 0;
                //  double x2 = 0.1 * i;
                //double y2 = (x2 - k0) / k1;
                y2 = y1_1;
                double x2 = y1_1 * _Analis.k1 + _Analis.k0;
                _Analis.chart1.Series[1].Points.AddXY(y2, x2);
                _Analis.chart1.Series[1].ChartType = SeriesChartType.Line;
                _Analis.chart1.ChartAreas[0].AxisX.Minimum = 0;
                _Analis.chart1.ChartAreas[0].AxisX.Title = "Концетрация, " + _Analis.edconctr;
                _Analis.chart1.ChartAreas[0].AxisY.Title = "Оптическая плотность, А";
                //  chart1.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(string.Format("{0:0.0000}", Table1.Rows[Table1.Rows.Count - 2].Cells["Concetr"].Value) + y2);
                _Analis.chart1.ChartAreas[0].AxisY.Minimum = 0;
                //   chart1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(string.Format("{0:0.0000}", Table1.Rows[Table1.Rows.Count - 2].Cells["Asred"].Value) + x2);
                //   chart1.ChartAreas[0].AxisX.Interval = Math.Round((Convert.ToDouble(Table1.Rows[3].Cells["Concetr"].Value) - Convert.ToDouble(Table1.Rows[2].Cells["Concetr"].Value)), 2);

                //       chart1.ChartAreas[0].AxisX.Interval = 5;
            }
            double xfin = y2 * 1.1;
            double yfin = xfin * _Analis.k1 + _Analis.k0;
            _Analis.chart1.Series[1].Points.AddXY(xfin, yfin);
        }
        public void USE_KO_lineinaya()
        {
            double max = -1;
            int index = -1;
            double[] SredOtklMatr = new double[_Analis.Table1.Rows.Count - 1];
            double SUMMSer = 0;
            double SREDSUMMX = 0;
            double SUMMX1 = 0;
            _Analis.chart1.Series[0].Points.Clear();
            _Analis.chart1.Series[1].Points.Clear();
            _Analis.k0 = 0; _Analis.k1 = 0; _Analis.k2 = 0;
            _Analis.SUM0 = 0; _Analis.SUM1 = 0;
            _Analis.SUMMX = 0; _Analis.SUMMY = 0; _Analis.XY = 0; _Analis.SUMMY2 = 0;
            _Analis.AgroText0.Text = string.Format("{0:0.0000}", 0);
            _Analis.AgroText1.Text = string.Format("{0:0.0000}", 0);
            _Analis.AgroText0.Text = string.Format("{0:0.0000}", 0);
            max = -1;
            double x1_1 = Convert.ToDouble(_Analis.Table1.Rows[0].Cells["Asred"].Value);
            double y1_1 = Convert.ToDouble(_Analis.Table1.Rows[0].Cells["Concetr"].Value);
            _Analis.SUMMX += (x1_1 - x1_1); _Analis.SUMMY += y1_1;
            SUMMX1 += x1_1;
            _Analis.XY += (x1_1 - x1_1) * y1_1;
            _Analis.SUMMY2 += y1_1 * y1_1;
            _Analis.Table1.Rows[0].Cells["X*X"].Value = y1_1 * y1_1;
            _Analis.Table1.Rows[0].Cells["X*Y"].Value = (x1_1 - x1_1) * y1_1;
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double x = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);
                double y = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);

                SUMMX1 += x;
                _Analis.SUMMX += (x - x1_1); _Analis.SUMMY += y;
                _Analis.XY += (x - x1_1) * y;
                _Analis.SUMMY2 += y * y;
                _Analis.Table1.Rows[i].Cells["X*X"].Value = y * y;
                _Analis.Table1.Rows[i].Cells["X*Y"].Value = (x - x1_1) * y;
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["NoCo"].Value = "n = " + Convert.ToString(_Analis.Table1.Rows.Count - 1);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["Asred"].Value = "СУММА = " + Convert.ToString(_Analis.SUMMX);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["Concetr"].Value = "СУММА = " + Convert.ToString(_Analis.SUMMY);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*X"].Value = "СУММА = " + Convert.ToString(_Analis.SUMMY2);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*Y"].Value = "СУММА = " + Convert.ToString(_Analis.XY);
            }
            SREDSUMMX = SUMMX1 / (_Analis.Table1.Rows.Count - 1);
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
            _Analis.k0 = (_Analis.SUMMY2 * _Analis.SUMMX - _Analis.SUMMY * _Analis.XY) / ((_Analis.NoCaSer) * _Analis.SUMMY2 - _Analis.SUMMY * _Analis.SUMMY);
            _Analis.k1 = ((_Analis.NoCaSer) * _Analis.XY - _Analis.SUMMY * _Analis.SUMMX) / ((_Analis.NoCaSer) * _Analis.SUMMY2 - _Analis.SUMMY * _Analis.SUMMY);
            _Analis.AgroText0.Text = string.Format("{0:0.0000}", _Analis.k0);
            _Analis.AgroText1.Text = string.Format("{0:0.0000}", _Analis.k1);
            _Analis.AgroText2.Text = string.Format("{0:0.0000}", 0);
            double[] Table1masStr1 = new double[_Analis.Table1.Rows.Count - 1];
            max = -1;
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double x = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);
                double y = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);
                double xrasch = _Analis.k1 * x + _Analis.k0;
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
            _Analis.label14.Text = "A(C) = " + _Analis.k1.ToString("0.0000 ;- 0.0000 ") + "*C " + _Analis.k0.ToString("+ 0.0000 ;- 0.0000 ");
            double x0 = Convert.ToDouble(_Analis.Table1.Rows[0].Cells["Asred"].Value);
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

                yx += (y1 - x0 - (_Analis.k1 * x1 + _Analis.k2)) * (y1 - x0 - (_Analis.k1 * x1 + _Analis.k2));
                yx1 += (y1 - x0 - SREDSUMM) * (y1 - x0 - SREDSUMM);
            }
            _Analis.RR.Text = "R^2 = " + string.Format("{0:0.0000}", (1 - (yx / yx1)));
            double x2 = x0 - x0;
            double y2 = x2 * _Analis.k1 + _Analis.k0;
            _Analis.chart1.Series[1].Points.AddXY(x2, y2);
            int k = 0;
            for (int i = 1; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                _Analis.circle = 1;
                x1_1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);
                y1_1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);

                // chart1.ChartAreas[0].AxisY.Crossing = k0;
                _Analis.chart1.Series[0].Points.AddXY(y1_1, (x1_1 - x0));
                _Analis.chart1.Series[0].Points[k].Label = Convert.ToString(_Analis.Table1.Rows[i].Cells[0].Value);
                k++;
                _Analis.chart1.Series[0].ChartType = SeriesChartType.Point;
                _Analis.chart1.ChartAreas[0].AxisY.Crossing = 0;
                _Analis.chart1.ChartAreas[0].AxisX.Crossing = 0;
                //  double x2 = 0.1 * i;
                //double y2 = (x2 - k0) / k1;
                x2 = y1_1;
                y2 = x2 * _Analis.k1 + _Analis.k0;
                _Analis.chart1.Series[1].Points.AddXY(x2, y2);
                _Analis.chart1.Series[1].ChartType = SeriesChartType.Line;
                _Analis.chart1.ChartAreas[0].AxisX.Minimum = 0;
                _Analis.chart1.ChartAreas[0].AxisX.Title = "Концетрация, " + _Analis.edconctr;
                _Analis.chart1.ChartAreas[0].AxisY.Title = "Оптическая плотность, А";
                //  chart1.ChartAreas[0].AxisX.Maximum = Convert.ToDouble(string.Format("{0:0.0000}", Table1.Rows[Table1.Rows.Count - 2].Cells["Concetr"].Value) + y2);
                _Analis.chart1.ChartAreas[0].AxisY.Minimum = 0;
                //   chart1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(string.Format("{0:0.0000}", Table1.Rows[Table1.Rows.Count - 2].Cells["Asred"].Value) + x2);
                //   chart1.ChartAreas[0].AxisX.Interval = Math.Round((Convert.ToDouble(Table1.Rows[3].Cells["Concetr"].Value) - Convert.ToDouble(Table1.Rows[2].Cells["Concetr"].Value)), 2);

                //       chart1.ChartAreas[0].AxisX.Interval = 5;
            }
            double xfin = x2 * 1.1;
            double yfin = xfin * _Analis.k1 + _Analis.k0;
            _Analis.chart1.Series[1].Points.AddXY(xfin, yfin);
        }
        public void USE_KO_lineinaya1()
        {
            double max = -1;
            int index = -1;
            double[] SredOtklMatr = new double[_Analis.Table1.Rows.Count - 1];
            double SUMMSer = 0;
            double SREDSUMMX = 0;
            double SUMMX1 = 0;
            _Analis.chart1.Series[0].Points.Clear();
            _Analis.chart1.Series[1].Points.Clear();
            _Analis.k0 = 0; _Analis.k1 = 0; _Analis.k2 = 0;
            _Analis.SUM0 = 0; _Analis.SUM1 = 0;
            _Analis.SUMMX = 0; _Analis.SUMMY = 0; _Analis.XY = 0; _Analis.SUMMY2 = 0;
            _Analis.AgroText0.Text = string.Format("{0:0.0000}", 0);
            _Analis.AgroText1.Text = string.Format("{0:0.0000}", 0);
            _Analis.AgroText0.Text = string.Format("{0:0.0000}", 0);
            max = -1;
            double x0 = Convert.ToDouble(_Analis.Table1.Rows[0].Cells["Concetr"].Value);
            double y0 = Convert.ToDouble(_Analis.Table1.Rows[0].Cells["Asred"].Value);
            _Analis.SUMMX += x0; _Analis.SUMMY += y0 - y0;
            _Analis.XY += x0 * (y0 - y0);
            _Analis.SUMMY2 += (y0 - y0) * (y0 - y0);
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double y = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);
                double x = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);


                _Analis.SUMMX += x; _Analis.SUMMY += (y - y0);
                _Analis.XY += x * (y - y0);
                _Analis.SUMMY2 += (y - y0) * (y - y0);
                _Analis.Table1.Rows[i].Cells["X*X"].Value = (y - y0) * (y - y0);
                _Analis.Table1.Rows[i].Cells["X*Y"].Value = x * (y - y0);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["NoCo"].Value = "n = " + Convert.ToString(_Analis.Table1.Rows.Count - 1);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["Concetr"].Value = "СУММА = " + Convert.ToString(_Analis.SUMMX);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["Asred"].Value = "СУММА = " + Convert.ToString(_Analis.SUMMY);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*X"].Value = "СУММА = " + Convert.ToString(_Analis.SUMMY2);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*Y"].Value = "СУММА = " + Convert.ToString(_Analis.XY);
            }

            _Analis.k0 = (_Analis.SUMMY2 * _Analis.SUMMX - _Analis.SUMMY * _Analis.XY) / ((_Analis.NoCaSer) * _Analis.SUMMY2 - _Analis.SUMMY * _Analis.SUMMY);
            _Analis.k1 = ((_Analis.NoCaSer) * _Analis.XY - _Analis.SUMMY * _Analis.SUMMX) / ((_Analis.NoCaSer) * _Analis.SUMMY2 - _Analis.SUMMY * _Analis.SUMMY);
            _Analis.AgroText0.Text = string.Format("{0:0.0000}", _Analis.k0);
            _Analis.AgroText1.Text = string.Format("{0:0.0000}", _Analis.k1);
            _Analis.AgroText2.Text = string.Format("{0:0.0000}", 0);
            _Analis.label14.Text = "C(A) = " + _Analis.k1.ToString("0.0000 ;- 0.0000 ") + "*A " + _Analis.k0.ToString("+ 0.0000 ;- 0.0000 ");
            max = -1;
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double Ser1 = (Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value) - Convert.ToDouble(_Analis.Table1.Rows[0].Cells["Asred"].Value)) * _Analis.k1 + _Analis.k0;
                SUMMSer = 0;
                for (int j = 1; j <= _Analis.NoCaIzm; j++)
                {
                    double Ser = (Convert.ToDouble(_Analis.Table1.Rows[i].Cells["A;Ser (" + j].Value) - Convert.ToDouble(_Analis.Table1.Rows[0].Cells["A;Ser (" + j].Value)) * _Analis.k1 + _Analis.k0;

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
                _Analis.SKO.Text = "СКО(С) = " + string.Format("{0:0.00}", max) + "% (CO №" + index + ")";
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
                    Table1masStr[j - 1] = (Convert.ToDouble(_Analis.Table1.Rows[i].Cells["A;Ser (" + j].Value) - Convert.ToDouble(_Analis.Table1.Rows[0].Cells["A;Ser (" + j].Value)) * _Analis.k1 + _Analis.k0;
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

                yx += (x1 - (_Analis.k1 * (y1 - x0) + _Analis.k0)) * (x1 - (_Analis.k1 * (y1 - x0) + _Analis.k0));
                yx1 += (x1 - SREDSUMM) * (x1 - SREDSUMM);
            }
            _Analis.RR.Text = "R^2 = " + string.Format("{0:0.0000}", (1 - (yx / yx1)));
            double x2 = x0 - x0;
            double y2 = x2 * _Analis.k1 + _Analis.k0;
            _Analis.chart1.Series[1].Points.AddXY(x2, y2);
            int k = 0;
            for (int i = 1; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                _Analis.circle = 1;
                double x1_1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);
                double y1_1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);

                // chart1.ChartAreas[0].AxisY.Crossing = k0;
                _Analis.chart1.Series[0].Points.AddXY((x1_1 - x0), y1_1);
                _Analis.chart1.Series[0].Points[k].Label = Convert.ToString(_Analis.Table1.Rows[i].Cells[0].Value);
                k++;
                _Analis.chart1.Series[0].ChartType = SeriesChartType.Point;
                _Analis.chart1.ChartAreas[0].AxisY.Crossing = 0;
                _Analis.chart1.ChartAreas[0].AxisX.Crossing = 0;
                // double y2 = 0.5 * i;
                //     double x2 = (y2 - k0) / k1;
                //  double y2 = k1 * x1_1 + k0;
                x2 = x1_1 - x0;
                y2 = x2 * _Analis.k1 + _Analis.k0;
                _Analis.chart1.Series[1].Points.AddXY(x2, y2);
                _Analis.chart1.Series[1].ChartType = SeriesChartType.Line;
                _Analis.chart1.ChartAreas[0].AxisX.Title = "Оптическая плотность, А";
                _Analis.chart1.ChartAreas[0].AxisY.Title = "Концетрация, " + _Analis.edconctr;
                _Analis.chart1.ChartAreas[0].AxisX.Minimum = 0;
                //  chart1.ChartAreas[0].AxisX.Maximum = Math.Round((Convert.ToDouble(Table1.Rows[Table1.Rows.Count - 2].Cells["Asred"].Value) + x2), 2);
                _Analis.chart1.ChartAreas[0].AxisY.Minimum = 0;
                //      chart1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(Table1.Rows[Table1.Rows.Count - 2].Cells["Concetr"].Value) + y2;
                //   chart1.ChartAreas[0].AxisX.Interval = Math.Round((Convert.ToDouble(Table1.Rows[3].Cells["Asred"].Value) - Convert.ToDouble(Table1.Rows[2].Cells["Asred"].Value)), 2);
                //     chart1.ChartAreas[0].AxisX.Interval = 5;
            }
            double xfin = x2 * 1.1;
            double yfin = xfin * _Analis.k1 + _Analis.k0;
            _Analis.chart1.Series[1].Points.AddXY(xfin, yfin);

        }
        public void USE_KO_lineinaya1_not()
        {
            double max = -1;
            int index = -1;
            double[] SredOtklMatr = new double[_Analis.Table1.Rows.Count - 1];
            double SUMMSer = 0;
            double SREDSUMMX = 0;
            double SUMMX1 = 0;

            _Analis.AgroText0.Text = string.Format("{0:0.0000}", 0);
            _Analis.AgroText1.Text = string.Format("{0:0.0000}", 0);
            _Analis.AgroText0.Text = string.Format("{0:0.0000}", 0);
            max = -1;
            _Analis.chart1.Series[0].Points.Clear();
            _Analis.chart1.Series[1].Points.Clear();
            _Analis.k0 = 0; _Analis.k1 = 0; _Analis.k2 = 0;
            _Analis.SUM0 = 0; _Analis.SUM1 = 0;
            _Analis.SUMMX = 0; _Analis.SUMMY = 0; _Analis.XY = 0; _Analis.SUMMY2 = 0;
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double y = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);
                double x = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);
                //double x0 = Convert.ToDouble(Table1.Rows[0].Cells["Concetr"].Value);
                double x1 = Convert.ToDouble(_Analis.Table1.Rows[_Analis.Table1.Rows.Count - 2].Cells["Concetr"].Value);
                // double y0 = Convert.ToDouble(Table1.Rows[0].Cells["Asred"].Value);
                double y1 = Convert.ToDouble(_Analis.Table1.Rows[_Analis.Table1.Rows.Count - 2].Cells["Asred"].Value);
                _Analis.SUMMX += x; _Analis.SUMMY += y;
                _Analis.XY += x * y;
                _Analis.SUMMY2 += y * y;
                _Analis.Table1.Rows[i].Cells["X*X"].Value = y * y;
                _Analis.Table1.Rows[i].Cells["X*Y"].Value = x * y;
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["NoCo"].Value = "n = " + Convert.ToString(_Analis.Table1.Rows.Count - 1);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["Concetr"].Value = "СУММА = " + Convert.ToString(_Analis.SUMMX);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["Asred"].Value = "СУММА = " + Convert.ToString(_Analis.SUMMY);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*X"].Value = "СУММА = " + Convert.ToString(_Analis.SUMMY2);
                _Analis.Table1.Rows[_Analis.Table1.Rows.Count - 1].Cells["X*Y"].Value = "СУММА = " + Convert.ToString(_Analis.XY);
            }
            _Analis.k0 = (_Analis.SUMMY2 * _Analis.SUMMX - _Analis.SUMMY * _Analis.XY) / ((_Analis.NoCaSer) * _Analis.SUMMY2 - _Analis.SUMMY * _Analis.SUMMY);
            _Analis.k1 = ((_Analis.NoCaSer) * _Analis.XY - _Analis.SUMMY * _Analis.SUMMX) / ((_Analis.NoCaSer) * _Analis.SUMMY2 - _Analis.SUMMY * _Analis.SUMMY);
            _Analis.AgroText0.Text = string.Format("{0:0.0000}", _Analis.k0);
            _Analis.AgroText1.Text = string.Format("{0:0.0000}", _Analis.k1);
            _Analis.AgroText2.Text = string.Format("{0:0.0000}", 0);
            _Analis.label14.Text = "C(A) = " + _Analis.k1.ToString("0.0000 ;- 0.0000 ") + "*A " + _Analis.k0.ToString("+ 0.0000 ;- 0.0000 ");
            max = -1;
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                double Ser1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value) * _Analis.k1 + _Analis.k0;
                SUMMSer = 0;
                for (int j = 1; j <= _Analis.NoCaIzm; j++)
                {
                    double Ser = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["A;Ser (" + j].Value) * _Analis.k1 + _Analis.k0;

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
                _Analis.SKO.Text = "СКО(С) = " + string.Format("{0:0.00}", max) + "% (CO №" + index + ")";
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
                    Table1masStr[j - 1] = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["A;Ser (" + j].Value) * _Analis.k1 + _Analis.k0;
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

                yx += (x1 - (_Analis.k1 * y1 + _Analis.k0)) * (x1 - (_Analis.k1 * y1 + _Analis.k0));
                yx1 += (x1 - SREDSUMM) * (x1 - SREDSUMM);
            }
            _Analis.RR.Text = "R^2 = " + string.Format("{0:0.0000}", (1 - (yx / yx1)));
            double x0 = 0;
            double y0 = x0 * _Analis.k1 + _Analis.k0;
            double x2 = 0;
            _Analis.chart1.Series[1].Points.AddXY(x0, y0);
            int k = 0;
            for (int i = 0; i < _Analis.Table1.Rows.Count - 1; i++)
            {
                _Analis.circle = 1;
                double x1_1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Asred"].Value);
                double y1_1 = Convert.ToDouble(_Analis.Table1.Rows[i].Cells["Concetr"].Value);

                // chart1.ChartAreas[0].AxisY.Crossing = k0;
                _Analis.chart1.Series[0].Points.AddXY(x1_1, y1_1);
                _Analis.chart1.Series[0].Points[k].Label = Convert.ToString(_Analis.Table1.Rows[i].Cells[0].Value);
                k++;
                _Analis.chart1.Series[0].ChartType = SeriesChartType.Point;
                _Analis.chart1.ChartAreas[0].AxisY.Crossing = 0;
                _Analis.chart1.ChartAreas[0].AxisX.Crossing = 0;
                // double y2 = 0.5 * i;
                //     double x2 = (y2 - k0) / k1;
                //  double y2 = k1 * x1_1 + k0;
                x2 = x1_1;
                double y2 = x1_1 * _Analis.k1 + _Analis.k0;
                _Analis.chart1.Series[1].Points.AddXY(x2, y2);
                _Analis.chart1.Series[1].ChartType = SeriesChartType.Line;
                _Analis.chart1.ChartAreas[0].AxisX.Title = "Оптическая плотность, А";
                _Analis.chart1.ChartAreas[0].AxisY.Title = "Концетрация, " + _Analis.edconctr;
                _Analis.chart1.ChartAreas[0].AxisX.Minimum = 0;
                //  chart1.ChartAreas[0].AxisX.Maximum = Math.Round((Convert.ToDouble(Table1.Rows[Table1.Rows.Count - 2].Cells["Asred"].Value) + x2), 2);
                _Analis.chart1.ChartAreas[0].AxisY.Minimum = 0;
                //      chart1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(Table1.Rows[Table1.Rows.Count - 2].Cells["Concetr"].Value) + y2;
                //   chart1.ChartAreas[0].AxisX.Interval = Math.Round((Convert.ToDouble(Table1.Rows[3].Cells["Asred"].Value) - Convert.ToDouble(Table1.Rows[2].Cells["Asred"].Value)), 2);
                //     chart1.ChartAreas[0].AxisX.Interval = 5;
            }
            double xfin = x2 * 1.1;
            double yfin = xfin * _Analis.k1 + _Analis.k0;
            _Analis.chart1.Series[1].Points.AddXY(xfin, yfin);
        }
    }
}
