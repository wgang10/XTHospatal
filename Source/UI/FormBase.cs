using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="emInputType"></param>
        public static void KeyPress(System.Windows.Forms.KeyPressEventArgs e, InputType emInputType)
        {
            int intChar = 0;
            intChar = e.KeyChar;
            switch (emInputType)
            {
                case InputType.Num:
                    if ((48 <= intChar && 57 >= intChar) || intChar == 8)
                    {
                        return;
                    }
                    break;
                case InputType.Dbl:
                    if ((48 <= intChar && intChar <= 57) || intChar == 8 || intChar == 46)
                    {
                        return;
                    }
                    break;
                case InputType.Tel:
                    if ((48 <= intChar && intChar <= 57) || intChar == 8 || intChar == 45)
                    {
                        return;
                    }
                    break;
                case InputType.Date:
                    if ((48 <= intChar && intChar <= 57) || intChar == 8 || intChar == 47)
                    {
                        return;
                    }
                    break;
                case InputType.AlphaAndNum:
                    if ((48 <= intChar && intChar <= 57) || (97 <= intChar && intChar <= 122) || (65 <= intChar && intChar <= 90) || intChar == 8)
                    {
                        return;
                    }
                    break;
                default:
                    break;
            }
            e.Handled = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strConstrolName"></param>
        /// <returns></returns>
        protected virtual bool CheckProcess(string strConstrolName)
        {
            return true;
        }

        #region event

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //protected virtual void AllTextBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e, System.Windows.Forms.Control preControl, System.Windows.Forms.Control thisControl, System.Windows.Forms.Control nextControl)
        protected virtual void AllTextBox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            string strControlname = ((System.Windows.Forms.Control)sender).Name;
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                if (CheckProcess(strControlname))
                {
                    SendKeys.Send("{Tab}");
                }
                else
                {
                    return;
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                SendKeys.Send("+{Tab}");
            }
        }

        /// <summary>
        /// CheckProcess
        /// </summary>
        /// <param name="strValue"></param>
        /// <param name="enumItems"></param>
        /// <param name="blnAllowEmpty"></param>
        /// <param name="combox"></param>
        /// <returns></returns>
        protected bool CheckProcess(string strValue, enumCheckItems enumItems, bool blnAllowEmpty, System.Windows.Forms.ComboBox combox)
        {
            switch (enumItems)
            {
                #region enumCheckItems.ItemID

                case enumCheckItems.ItemID:
                    if (!Method.CheckIsNumber(strValue, 12, blnAllowEmpty, true))
                    {
                        Method.MessageShow(GlobalVal.Msg);
                        return false;
                    }
                    if (!blnAllowEmpty || strValue.Length != 0)
                    {
                        if (strValue.Length != 12)
                        {
                            Method.MessageShow("W11006");//The length is input Wrong!
                            return false;
                        }
                    }
                    break;

                #endregion

                #region enumCheckItems.USER_LOGIN_ID

                case enumCheckItems.USER_LOGIN_ID:
                    if (!Method.CheckIsHanAll(strValue,blnAllowEmpty, true))
                    {
                        Method.MessageShow(GlobalVal.Msg);
                        return false;
                    }
                    if (!blnAllowEmpty || strValue.Length != 0)
                    {
                        if (strValue.Length > 50)
                        {
                            Method.MessageShow("W11006");//The length is input Wrong!
                            return false;
                        }
                    }
                    break;

                #endregion

                #region enumCheckItems.ItemName

                case enumCheckItems.ItemName:
                    if (!Method.CheckIsAllInputType(strValue, 25, blnAllowEmpty, true))
                    {
                        Method.MessageShow(GlobalVal.Msg);
                        return false;
                    }
                    break;

                #endregion

                #region enumCheckItems.UserGroup
                case enumCheckItems.UserGroup:
                    if (!Method.CheckIsAllInputType(strValue, 50, blnAllowEmpty, true))
                    {
                        Method.MessageShow(GlobalVal.Msg);
                        return false;
                    }
                    break;
                #endregion

                #region enumCheckItems.DateYMD

                case enumCheckItems.DateYMD:
                    if (!Method.CheckIsDate(strValue,blnAllowEmpty, true))
                    {
                        Method.MessageShow(GlobalVal.Msg);
                        return false;
                    }
                    break;

                #endregion

                #region enumCheckItems.PHONE_NO
                case enumCheckItems.PHONE_NO:
                    if (!Method.CheckIsTelNo(strValue,blnAllowEmpty, true))
                    {
                        Method.MessageShow(GlobalVal.Msg);
                        return false;
                    }
                    break;
                #endregion

                #region enumCheckItems.E_Mail
                case enumCheckItems.E_Mail:
                    if (!Method.CheckIsEmail(strValue,blnAllowEmpty, true))
                    {
                        Method.MessageShow(GlobalVal.Msg);
                        return false;
                    }
                    break;
                #endregion

                #region enumCheckItems.Post
                case enumCheckItems.Post:
                    if (!Method.CheckIsNumber(strValue, 6, blnAllowEmpty, true))
                    {
                        Method.MessageShow(GlobalVal.Msg);
                        return false;
                    }
                    break;
                #endregion

                #region enumCheckItems.ItemMEMO

                case enumCheckItems.ItemMEMO:
                    if (!Method.CheckIsAllInputType(strValue, 128, blnAllowEmpty, true))
                    {
                        Method.MessageShow(GlobalVal.Msg);
                        return false;
                    }
                    break;

                #endregion

                default:
                    break;
            }
            return true;
        }

        #endregion

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

        /// <summary>
        /// 设置当前登录用户
        /// </summary>
        public string LoginUser { set { this.lbUser.Text = "当前登录用户：" + value; } }

        private void FormBase_Load(object sender, EventArgs e)
        {            
            linkLabel1.Text = GlobalVal.SupportCompanyName;
            label139.Text = GlobalVal.Copyright;
            lbUser.Text = "当前登录用户："+GlobalVal.LoginUserID;
            try
            {
                WebClient wc = new WebClient();
                Image image = Image.FromStream(wc.OpenRead(GlobalVal.PictureTopUrl));
                this.pictureBox4.Image = image;
            }
            catch (Exception ex)
            {
                //GlobalVal.gloWebSerices.AddLog("加载图片[" + GlobalVal.gloPictureLoginUrl + "]失败."+ex.Message, "3", Dns.GetHostAddresses(Dns.GetHostName())[0].ToString());
            }            
        }

        public void ShowNews()
        {
            webService.News[] list = GlobalVal.WebSerices.GetNews("XTHospatal", 5);
            for (int i = 0; i < list.Length; i++)
            {
                Label lbl = new Label();
                lblTxt.Add(lbl);
                lblTxt[i].Top = this.splitContainer1.Height - 16;
                lblTxt[i].Left = 4;
                lblTxt[i].Visible = false;
                lblTxt[i].BackColor = Color.Transparent;
                lblTxt[i].ForeColor = Color.Blue;
                lblTxt[i].AutoSize = true;
                this.splitContainer1.Panel2.Controls.Add(lblTxt[i]);
                lblTxt[i].Text = list[i].Title;
                lblTxt[i].Tag = list[i].Url;
                // 添加事件监听
                lblTxt[i].Click += new EventHandler(frmAbout_WebSite_Click);
                lblTxt[i].MouseMove += new MouseEventHandler(frmAbout_Link_MouseMove);
                lblTxt[i].MouseLeave += new EventHandler(frmAbout_Link_MouseLeave);
            }
            lblScroll.Add(lblTxt[0]);
            //lblTxt[0].Top = 4;
            //lblTxt[0].Left = 4;
            //lblTxt[0].Visible = true;

            //lblTxt[1].Top = 20;
            //lblTxt[1].Left = 4;
            //lblTxt[1].Visible = true;

            //lblTxt[2].Top = 36;
            //lblTxt[2].Left = 4;
            //lblTxt[2].Visible = true;

            //lblTxt[3].Top = 52;
            //lblTxt[3].Left = 4;
            //lblTxt[3].Visible = true;

            //lblTxt[4].Top = 68;
            //lblTxt[4].Left = 4;
            //lblTxt[4].Visible = true;
            timer1.Start();
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
                if (lblScroll[i] == lblTxt[(lblTxt.Count - 1)] )
                {
                    index = 0;
                    lblScroll.Clear();
                    lblScroll.Add(lblTxt[0]);
                    lblTxt[0].Top = this.splitContainer1.Height - 16;
                }
            }

            if (index < (lblTxt.Count - 1))
            {
                lblScroll.Add(lblTxt[index + 1]);
                lblTxt[index + 1].Top = this.splitContainer1.Height - 16;
                index++;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(GlobalVal.SupportCompanyURL);
        }

    }
}