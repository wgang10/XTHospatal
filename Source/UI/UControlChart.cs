using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UI
{
    public partial class UControlChart : UserControl
    {
        private double? _maxValue;
        private double? _minValue;
        private List<StatisticItem> _statisticItems;
        public UControlChart()
        {
            InitializeComponent();
        }

        private void BindChart(List<StatisticItem> data)
        {
            chart1.Series.Clear();
            chart1.DataSource = data;
            
            string[] series = { "MaxValue", "MinValue", "YourValue"};

            for (int i = 0; i < series.Length; i++)
            {
                Series series1 = new Series(series[i]);
                series1.ChartType = SeriesChartType.Spline;
                chart1.Series.Add(series1);
                series1.XValueMember = "Date";
                series1.YValueMembers = series[i];
            }
            chart1.DataBind();
        }

        public double MaxValue
        {
            get { return _maxValue.Value; }
            set { _maxValue = value; }
        }

        public double MinValue
        {
            get { return _minValue.Value; }
            set { _minValue = value; }
        }

        public List<StatisticItem> StatisticItems
        {
            set
            {
                if (!_maxValue.HasValue || !_minValue.HasValue)
                    throw new Exception("Please first set the value of MinValue and MaxValue.");
                this._statisticItems = value;
                foreach (StatisticItem item in _statisticItems)
                {
                    item.MaxValue = this.MaxValue;
                    item.MinValue = this.MinValue;
                }
                BindChart(_statisticItems);
            }
        }

        public string Title
        {
            set {
                this.chart1.Titles[0].Text = value;
            }
        }
    }
}
