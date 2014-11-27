using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace WinFormAppTest
{
    public partial class UControlNews : UserControl
    {
        #region Private Members
        List<Label> lblTxt = new List<Label>();
        List<Label> lblScroll = new List<Label>();
        int RowHight = 25;//行高
        int RowLeft = 25;//左缩进
        int RowTop = 25;//上边距
        int index = 0;
        /// <summary>
        /// 保存窗体旧坐标的X轴值和Y轴值
        /// </summary>
        int _x, _y;
        /// <summary>
        /// 保存窗体是否可移动标识
        /// </summary>
        bool isMove = false;
        /// <summary>
        /// 保存鼠标指针指向的坐标点
        /// </summary>
        Point _mouseLocation;
        #endregion

        #region Event Handlers
        /// <summary>
        /// 链接标签鼠标移动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAbout_Link_MouseMove(object sender, MouseEventArgs e)
        {
            Label currentLabel = (sender as Label);
            currentLabel.ForeColor = Color.Yellow;
            currentLabel.Cursor = Cursors.Hand;
            timer1.Stop();
        }
        /// <summary>
        /// 链接标签鼠标移开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAbout_Link_MouseLeave(object sender, EventArgs e)
        {
            Label currentLabel = (sender as Label);
            currentLabel.ForeColor = Color.Blue;
            currentLabel.Cursor = Cursors.Default;
            timer1.Start();
        }
        /// <summary>
        /// [E-mail]滚动标签点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAbout_Email_Click(object sender, EventArgs e)
        {
            Process.Start("mailto:wgang10@foxmail.com");
        }
        /// <summary>
        /// [Blog]滚动标签点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAbout_WebSite_Click(object sender, EventArgs e)
        {
            var lb = (Label)sender;
            var New = (News)lb.Tag;
            Process.Start(New.Url);
        }
        /// <summary>
        /// 计时器事件(调度信息字幕显示)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrShow_Tick(object sender, EventArgs e)
        {
            // 控制字幕滚动
            for (int i = 0; i < lblScroll.Count; i++)
            {
                if (lblScroll[i].Top <= this.Height && lblScroll[i].Top + RowHight >= RowTop)
                {
                    lblScroll[i].Visible = true;
                }
                lblScroll[i].Top -= 1;
                if (lblScroll[i].Top + RowHight < 0)
                {
                    lblScroll[i].Visible = false;
                    lblScroll.Remove(lblScroll[i]);
                }
            }
            if (lblScroll.Count == 0)
            {
                for (int j = 0; j < lblTxt.Count; j++)
                {
                    lblTxt[j].Top = this.Height + j * RowHight;
                    lblScroll.Add(lblTxt[j]);
                }
            }
        }
        /// <summary>
        /// 鼠标指针在窗体上方并按下按键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAbout_MouseDown(object sender, MouseEventArgs e)
        {
            // 仅响应鼠标左键点击事件
            if (e.Button == MouseButtons.Left)
            {
                // 保存旧坐标
                this._x = e.X;
                this._y = e.Y;
                // 标识窗体可移动
                this.isMove = true;
            }
        }
        /// <summary>
        /// 鼠标指针在窗体上移过并保持静止状态一段时间事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAbout_MouseHover(object sender, EventArgs e)
        {
            var New = (News)((Label)sender).Tag;
            this.toolTip1.ToolTipIcon = ToolTipIcon.None;
            this.toolTip1.ToolTipTitle = New.Title;
            this.toolTip1.Show(
                New.Body,
                this, new Point(_mouseLocation.X + 6, _mouseLocation.Y + 6),
                5000);
        }
        #endregion

        public UControlNews()
        {
            InitializeComponent();
        }

        private void UControlNews_Load(object sender, EventArgs e)
        {
            List<News> list = new List<News>();
            list.Add(new News(DateTime.Now, "消息111111111baidu1", "http://www.baidu.com", "内容1111111111111111111"));
            list.Add(new News(DateTime.Now, "消息222222ziyang2222", "http://www.ziyangsoft.com", "内容22222222222222222222"));
            list.Add(new News(DateTime.Now, "消息333333333333bitauto333", "http://www.bitauto.com", "内容33333333333333333333333"));
            list.Add(new News(DateTime.Now, "消息4444444444444444444444444", "http://www.baidu.com", "内容444444444444"));
            list.Add(new News(DateTime.Now, "消息555555555cnbeta5555", "http://www.cnbeta.com", "内容55555555555555555555"));
            list.Add(new News(DateTime.Now, "消息666666taobao666666", "http://www.taobao.com", "内容6666666666666666666"));
            for (int i = 0; i < list.Count; i++)
            {
                Label lbl = new Label();
                lblTxt.Add(lbl);
                lblTxt[i].Top = this.Height + i*RowHight;
                lblTxt[i].Left = RowLeft;
                lblTxt[i].Visible = false;
                lblTxt[i].BackColor = Color.Transparent;
                lblTxt[i].ForeColor = Color.Blue;
                lblTxt[i].AutoSize = true;
                this.Controls.Add(lblTxt[i]);
                lblTxt[i].Text = list[i].Title;
                lblTxt[i].Tag = list[i];
                // 添加事件监听
                lblTxt[i].Click += new EventHandler(frmAbout_WebSite_Click);
                lblTxt[i].MouseMove += new MouseEventHandler(frmAbout_Link_MouseMove);
                lblTxt[i].MouseLeave += new EventHandler(frmAbout_Link_MouseLeave);
                lblTxt[i].MouseHover += new EventHandler(frmAbout_MouseHover);
                lblTxt[i].MouseDown += new MouseEventHandler(frmAbout_MouseDown);
                lblScroll.Add(lblTxt[i]);
            }
            if (!DesignMode)
            {
                timer1.Start();
            }
        }

        public class News
        {

            private System.DateTime createTimeField;

            private string titleField;

            private string urlField;

            private string bodyField;

            public News(DateTime createtiem, string title, string url, string body)
            {
                this.CreateTime = createtiem;
                this.Title = title;
                this.Url = url;
                this.Body = body;
            }

            /// <remarks/>
            public System.DateTime CreateTime
            {
                get
                {
                    return this.createTimeField;
                }
                set
                {
                    this.createTimeField = value;
                }
            }

            /// <remarks/>
            public string Title
            {
                get
                {
                    return this.titleField;
                }
                set
                {
                    this.titleField = value;
                }
            }

            /// <remarks/>
            public string Url
            {
                get
                {
                    return this.urlField;
                }
                set
                {
                    this.urlField = value;
                }
            }

            /// <remarks/>
            public string Body
            {
                get
                {
                    return this.bodyField;
                }
                set
                {
                    this.bodyField = value;
                }
            }
        }
    }
}
