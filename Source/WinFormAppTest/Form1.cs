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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            uControlNews1.btnRefresh.Click += new System.EventHandler(RreshTime);
            timer1.Start();
            WebService.ServiceSoapClient server = new WebService.ServiceSoapClient();
            WebService.News[] news = server.GetNews("XTHospatal", 10);
            this.dataGridView1.DataSource = news;
        }

        private void RreshTime(object sender, EventArgs e)
        {
            label2.Text = "上次刷新时间"+uControlNews1.LastRefreshTime.ToString();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int refreshCycle=5;
            uControlNews1.RefreshCycle = Int32.TryParse(textBox1.Text, out refreshCycle) ? refreshCycle : refreshCycle;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                uControlNews1.NewsBackColor = colorDialog1.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                uControlNews1.NewsForeColor = colorDialog1.Color;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int second = 60 * uControlNews1.RefreshCycle-DateTime.Now.Subtract(uControlNews1.LastRefreshTime).Seconds;
            label3.Text = "还有 " + second.ToString() +" 秒刷新";
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            WebService.News news = (WebService.News)dataGridView1.CurrentRow.DataBoundItem;
            lbID.Text = news.NewsID;
            lbCreatetime.Text = news.CreateTime.ToString();
            txtSystemName.Text = news.SystemName;
            txtTitle.Text = news.Title;
            txtUrl.Text = news.Url;
            txtBody.Text = news.Body;
        }
    }
}
