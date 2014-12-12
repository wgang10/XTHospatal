using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace UI
{
    public partial class UControlNews : UserControl
    {
        #region Private Members
        List<Label> lbListNews = new List<Label>();
        List<Label> lbListScroll = new List<Label>();
        List<News> Newslist;// = new List<News>();
        Color backColor = Color.CadetBlue;
        Color foreColor = Color.Blue;
        /// <summary>
        /// 刷新周期 单位：分钟
        /// </summary>
        int refreshCycle = 10;

        DateTime lastRefreshTime=DateTime.Now;
        
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
            for (int i = 0; i < lbListScroll.Count; i++)
            {
                if (lbListScroll[i].Top <= this.Height && lbListScroll[i].Top + RowHight >= RowTop)
                {
                    lbListScroll[i].Visible = true;
                }
                lbListScroll[i].Top -= 1;
                if (lbListScroll[i].Top + RowHight < 0)
                {
                    lbListScroll[i].Visible = false;
                    lbListScroll.Remove(lbListScroll[i]);
                }
            }
            if (lbListScroll.Count == 0)
            {
                //刷新
                if (DateTime.Now.Subtract(lastRefreshTime).Minutes >= refreshCycle)
                {
                    GetLatestNews();
                    return;
                }
                for (int j = 0; j < lbListNews.Count; j++)
                {
                    lbListNews[j].Top = this.Height + j * RowHight;
                    lbListScroll.Add(lbListNews[j]);
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
            this.NewsBackColor = backColor;
            btnRefresh.Visible = false;
        }

        private void SetNews()
        {
            if (Newslist == null)
                Newslist = new List<News>();
            for (int i = 0; i < Newslist.Count; i++)
            {
                Label lbl = new Label();
                lbListNews.Add(lbl);
                lbListNews[i].Top = this.Height + i * RowHight;
                lbListNews[i].Left = RowLeft;
                lbListNews[i].Visible = false;
                lbListNews[i].BackColor = Color.Transparent;
                lbListNews[i].ForeColor = foreColor;
                lbListNews[i].AutoSize = true;
                this.Controls.Add(lbListNews[i]);
                lbListNews[i].Text = Newslist[i].Title;
                lbListNews[i].Tag = Newslist[i];
                // 添加事件监听
                lbListNews[i].Click += new EventHandler(frmAbout_WebSite_Click);
                lbListNews[i].MouseMove += new MouseEventHandler(frmAbout_Link_MouseMove);
                lbListNews[i].MouseLeave += new EventHandler(frmAbout_Link_MouseLeave);
                lbListNews[i].MouseHover += new EventHandler(frmAbout_MouseHover);
                lbListNews[i].MouseDown += new MouseEventHandler(frmAbout_MouseDown);
                lbListScroll.Add(lbListNews[i]);
            }
            if (!DesignMode)
            {
                timer1.Start();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetLatestNews();
        }

        private void GetLatestNews()
        {
            if (GlobalVal.WebSerices == null)
            {
                GlobalVal.WebSerices = new MyWebService(GlobalVal.ServicesURL + @"/Service.asmx");
            }

            lastRefreshTime = DateTime.Now;
            List<News> list=new List<News>();
            
            webService.Notic[] news = GlobalVal.WebSerices.GetNews("XTHospital", 10);
            for (int i = 0; i < news.Length; i++)
            {
                 list.Add(new News(news[i].Id.ToString(),news[i].SystemName,news[i].UpdateTime, news[i].Title, news[i].Url, news[i].Body));
            }
            NewsSource = list;
        }

        /// <summary>
        /// 背景色
        /// </summary>
        public Color NewsBackColor
        {
            set {
                backColor = value;
                this.BackColor = value;
            }
        }

        /// <summary>
        /// 字体颜色
        /// </summary>
        public Color NewsForeColor
        {
            set
            {
                foreColor = value;
                foreach (Label lb in lbListNews)
                {                    
                    lb.ForeColor = foreColor;
                }
            }
        }

        /// <summary>
        /// 刷新周期
        /// </summary>
        public int RefreshCycle
        {
            set {
                refreshCycle = value;
            }
            get {
                return refreshCycle;
            }
        }

        /// <summary>
        /// 新闻源
        /// </summary>
        public List<News> NewsSource
        {
            set {
                if (value != null && value.Count>0)
                {
                    if (Newslist != null)
                    {
                        Newslist.Clear();
                    }                  
                    foreach (Label lb in lbListNews)
                    {
                        lb.Dispose();
                    }
                    lbListScroll.Clear();
                    lbListNews.Clear();
                    timer1.Stop();
                    Newslist = value;
                    SetNews();
                }
            }
        }

        public DateTime LastRefreshTime
        {
            get { return lastRefreshTime; }
        }

        /// <summary>
        /// 刷新按钮是否可见
        /// </summary>
        public bool VisibleFreshButton
        {
            set {
                btnRefresh.Visible = value;
            }
            get{
                return btnRefresh.Visible;
            }
        }

        public class News
        {
            private System.DateTime createTimeField;

            private string titleField;

            private string urlField;

            private string bodyField;

            private string systemNameField;

            private string idField;

            public News(string newsId,string systemName,DateTime createtiem, string title, string url, string body)
            {
                this.idField = newsId;
                this.systemNameField = systemName;
                this.createTimeField = createtiem;
                this.titleField = title;
                this.urlField = url;
                this.bodyField = body;
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

            public string ID
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }

            public string SystemName
            {
                get
                {
                    return this.systemNameField;
                }
                set
                {
                    this.systemNameField = value;
                }
            }
        }
    }
}
