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
            LoadNews(100);
        }

        private void LoadNews(int Nums)
        {
            uControlNews1.btnRefresh.Click += new System.EventHandler(RreshTime);
            timer1.Start();
            WebService.ServiceSoapClient server = new WebService.ServiceSoapClient();
            WebService.Notic[] news = server.GetNews("ALL", Nums);
            lbID.Text = string.Empty;
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
            WebService.Notic news = (WebService.Notic)dataGridView1.CurrentRow.DataBoundItem;
            lbID.Text = news.Id.ToString();
            lbCreatetime.Text = news.CreateTime.ToString();
            txtSystemName.Text = news.SystemName;
            txtTitle.Text = news.Title;
            txtUrl.Text = news.Url;
            txtBody.Text = news.Body;
        }

        private void btnDeleteLogic_Click(object sender, EventArgs e)
        {
            WebService.ServiceSoapClient server = new WebService.ServiceSoapClient();
            bool isSuccess = server.DeleteNewsLogic(Int32.Parse(lbID.Text));//逻辑删除
            if (isSuccess)
            {
                LoadNews(100);
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

        private void btnDeletePhysic_Click(object sender, EventArgs e)
        {
            WebService.ServiceSoapClient server = new WebService.ServiceSoapClient();
            bool isSuccess = server.DeleteNewsPhysic(Int32.Parse(lbID.Text));//物理删除
            if (isSuccess)
            {
                LoadNews(100);
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }

        private void btnAddNews_Click(object sender, EventArgs e)
        {
            WebService.ServiceSoapClient server = new WebService.ServiceSoapClient();
            WebService.Notic model = new WebService.Notic();
            if (string.IsNullOrEmpty(lbID.Text))
            {
                model.Id = -1;
            }
            else
            {
                model.Id = Int32.Parse(lbID.Text);
            }
            model.SystemName = txtSystemName.Text;
            model.Title = txtTitle.Text;
            model.Url = txtUrl.Text;
            model.Body = txtBody.Text;
            bool isSuccese = server.AddUpdateNews(model);
            if (isSuccese)
            {
                LoadNews(100);
            }
            else
            {
                MessageBox.Show("保存失败。");
            }
        }
    }
}
