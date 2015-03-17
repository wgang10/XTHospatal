using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormAppTest
{
    public partial class FormLiLv : Form
    {
        public FormLiLv()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calculate();
            //SetChart();
        }

        private void Calculate()
        {
            double original = double.Parse(txtBenjin.Text);
            double rate = double.Parse(txtLiLv.Text);
            int time = int.Parse(txtTime.Text);
            double add = double.Parse(txtAdd.Text);
            double result = original;
            double touru = original;
            double lixi = 0;

            List<string> x = new List<string>();
            List<double> y1 = new List<double>();
            List<double> y2 = new List<double>();

            for (int i = 1; i <= time; i++)
            {
                if (i > 1)
                {
                    result += add;
                    touru += add;
                }
                result += result * rate;
                x.Add(i.ToString());
                y1.Add(result-touru);
                y2.Add(result);
            }
            lixi = result - touru;
            txtTouRu.Text = touru.ToString();
            txtHuibao.Text = result.ToString();
            txtLiXi.Text = lixi.ToString();

            FillColumnChart(chart2, x.ToArray(), y1.ToArray(), y2.ToArray());
        }

        private void SetChart()
        {
            string[] x = { "z", "a", "b", "c" };
            int[] y1 = { 1, 2, 3, 4 };
            int[] y2 = { 2, 3, 5, 6 };

            //FillColumnChart(chart2, x, y1, y2);
        }

        public void FillColumnChart(Chart chart2, string[] x, double[] y1, double[] y2)
        {
            //chart2.Series.Clear();
            chart2.Legends.Clear();

            chart2.ChartAreas[0].Area3DStyle.Enable3D = true;
            chart2.ChartAreas[0].Area3DStyle.Inclination = 30;
            chart2.ChartAreas[0].Area3DStyle.PointDepth = 50;
            chart2.ChartAreas[0].Area3DStyle.IsClustered = true;
            chart2.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;

            chart2.Series[0].ChartType = SeriesChartType.Column;
            chart2.Series[0].Points.DataBindXY(x, y1);

            Series second = new Series();
            second.ChartType = SeriesChartType.Column;
            second.Points.DataBindXY(x, y2);
            chart2.Series.Add(second);
        }
    }
}
