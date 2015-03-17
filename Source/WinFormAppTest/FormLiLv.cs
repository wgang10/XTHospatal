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
            DataTable dt = CreateDataTable();
            double original = double.Parse(txtBenjin.Text);
            double rate = double.Parse(txtLiLv.Text);
            int time = int.Parse(txtTime.Text);
            double add = double.Parse(txtAdd.Text);
            double result = original;
            double touru = original;
            double lixi = 0;

            for (int i = 1; i <= time; i++)
            {
                if (i > 1)
                {
                    result += add;
                    touru += add;
                }
                result += result * rate;
                DataRow dr = dt.NewRow();
                dr["Time"] = i;
                dr["Lixi"] = result - touru;
                dr["All"] = result;
                dt.Rows.Add(dr);
            }
            lixi = result - touru;
            txtTouRu.Text = touru.ToString();
            txtHuibao.Text = result.ToString();
            txtLiXi.Text = lixi.ToString();

            FillColumnChart(dt);
        }

        private void SetChart()
        {
            string[] x = { "z", "a", "b", "c" };
            int[] y1 = { 1, 2, 3, 4 };
            int[] y2 = { 2, 3, 5, 6 };

            //FillColumnChart(chart2, x, y1, y2);
        }

        public void FillColumnChart(DataTable DT)
        {
            dataGridView1.DataSource = DT;

            chart2.Series.Clear();

            Series seriesAll = new Series("总收入");
            chart2.Series.Add(seriesAll);
            Series seriesLixi = new Series("利息");
            chart2.Series.Add(seriesLixi);

            chart2.DataSource = DT;

            //设置图表Y轴对应项
            seriesAll.YValueMembers = "All";
            seriesLixi.YValueMembers = "Lixi";

            //设置图表X轴对应项
            chart2.Series[0].XValueMember = "Time";

            //chart2.ChartAreas[0].Area3DStyle.Enable3D = true;
            //chart2.ChartAreas[0].Area3DStyle.Inclination = 30;
            //chart2.ChartAreas[0].Area3DStyle.PointDepth = 50;
            //chart2.ChartAreas[0].Area3DStyle.IsClustered = true;
            //chart2.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;

            chart2.DataBind();
        }

        private DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Time");
            dt.Columns.Add("All");
            dt.Columns.Add("Lixi");
            return dt;
        }
    }
}
