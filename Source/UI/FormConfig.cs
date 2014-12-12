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
            currentLabel.ForeColor = Color.Blue;
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
            Process.Start(((Label)sender).Tag.ToString());
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
                if (lblScroll[i] == lblTxt[(lblTxt.Count - 1)] && lblScroll[i].Top == this.Height - 84)
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
            GlobalVal.FormShow.Show();
            this.Close();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            
        }
    }
}
