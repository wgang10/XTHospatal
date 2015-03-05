using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            for (int i = 1; i <= time; i++)
            {
                if (i > 1)
                {
                    result += add;
                    touru += add;
                }
                result += result * rate;
            }
            lixi = result - touru;
            txtTouRu.Text = touru.ToString();
            txtHuibao.Text = result.ToString();
            txtLiXi.Text = lixi.ToString();
        }
    }
}
