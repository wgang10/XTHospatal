using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class FormConfig : FormBase
    {
        public FormConfig()
        {
            InitializeComponent();
            for (int i = 0; i < 13; i++)
            {
                Label lbl = new Label();
                lblTxt.Add(lbl);
                lblTxt[i].Top = this.Height - 24;
                lblTxt[i].Left = 24;
                lblTxt[i].Visible = false;
                lblTxt[i].BackColor = Color.Transparent;
                lblTxt[i].ForeColor = Color.Blue;
                lblTxt[i].AutoSize = true;
                this.Controls.Add(lblTxt[i]);
            }
            lblTxt[0].Text = "产品名称: CMCSharpSDK";
            lblTxt[1].Text = "产品全称: CodingMouse C# 开发工具包";
            lblTxt[2].Text = "当前版本: 1.0.0.0";
            lblTxt[3].Text = "";
            lblTxt[4].Text = "程式设计: 邓超 (网络用名: CodingMouse)";
            lblTxt[5].Text = "";
            lblTxt[6].Text = "    Qicq: 454811990";
            lblTxt[7].Text = "  E-mail: CodingMouse@gmail.com";
            lblTxt[8].Text = "    Blog: http://blog.csdn.net/CodingMouse";
            lblTxt[9].Text = "";
            lblTxt[10].Text = "测试环境: Microsoft Windows Server 2003 Enterprise Edition";
            lblTxt[11].Text = "          Microsoft Visual Studio 2005 Team Suite";
            lblTxt[12].Text = "          Microsoft SQL Server 2005 Enterprise Edition";
            // 添加事件监听
            lblTxt[7].Click += new EventHandler(frmAbout_Email_Click);
            lblTxt[8].Click += new EventHandler(frmAbout_WebSite_Click);
            lblTxt[7].MouseMove += new MouseEventHandler(frmAbout_Link_MouseMove);
            lblTxt[8].MouseMove += new MouseEventHandler(frmAbout_Link_MouseMove);
            lblTxt[7].MouseLeave += new EventHandler(frmAbout_Link_MouseLeave);
            lblTxt[8].MouseLeave += new EventHandler(frmAbout_Link_MouseLeave);
            lblScroll.Add(lblTxt[0]);
        }

        #region Private Members
        List<Label> lblTxt = new List<Label>();
        List<Label> lblScroll = new List<Label>();
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
        }
        /// <summary>
        /// 链接标签鼠标移开事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAbout_Link_MouseLeave(object sender, EventArgs e)
        {
            Label currentLabel = (sender as Label);
            currentLabel.ForeColor = Color.White;
            currentLabel.Cursor = Cursors.Default;
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
            Process.Start("http://ziyangsoft.com");
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
                lblScroll[i].Visible = true;
                lblScroll[i].Top -= 1;
                if (lblScroll[i] == lblTxt[(lblTxt.Count - 1)] 
                    && lblScroll[i].Top == this.Height - 84)
                {
                    index = 0;
                    lblScroll.Add(lblTxt[0]);
                }
                if (lblScroll[i].Top < (lblTxt.Count - 1))
                {
                    lblScroll[i].Visible = false;
                    lblScroll[i].Top = this.Height - (lblTxt.Count - 1) * 2;
                    lblScroll.RemoveAt(i);
                }
            }
            if (index < (lblTxt.Count - 1))
            {
                if ((lblTxt[index].Top + lblTxt[index].Height) - lblTxt[index + 1].Top 
                    == -(lblTxt.Count - 1))
                {
                    lblScroll.Add(lblTxt[index + 1]);
                    index++;
                }
            }
        }
        /// <summary>
        /// 窗体双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAbout_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
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
        /// 鼠标指针在窗体上方并移动鼠标指针事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAbout_MouseMove(object sender, MouseEventArgs e)
        {
            // 如果可移动
            if (this.isMove)
            {
                // 根据旧坐标的相对偏移位置移动窗体
                // 方法一：
                // this.Left += e.X - this._x;
                // this.Top += e.Y - this._y;
                // 方法二：
                this.SetDesktopLocation(this.Left + e.X - this._x, this.Top + e.Y - this._y);
            }
            // 保存鼠标指针坐标点
            _mouseLocation = e.Location;
        }
        /// <summary>
        /// 鼠标指针在窗体上方并释放按键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAbout_MouseUp(object sender, MouseEventArgs e)
        {
            // 标识窗体不可移动
            this.isMove = false;
        }
        /// <summary>
        /// 鼠标指针在窗体上移过并保持静止状态一段时间事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAbout_MouseHover(object sender, EventArgs e)
        {
            this.toolTip1.ToolTipIcon = ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "关闭提示";
            this.toolTip1.Show(
                "请双击鼠标键来关闭此窗体 ...", 
                this, new Point(_mouseLocation.X + 6, _mouseLocation.Y + 6), 
                5000);
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            GlobalVal.ShowForm.Show();
            this.Close();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            GlobalVal.SplashObj.Dispose();
            timer1.Start();
        }
    }
}
