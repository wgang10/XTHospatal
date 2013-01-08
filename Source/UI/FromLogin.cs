using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Net;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class FromLogin : Form
    {
        public FromLogin()
        {
            InitializeComponent();
            this.Load += delegate { this.alphaBlendingBringer1.SetAlphaBlending(this); };
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要退出系统吗？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                GlobalVal.blCloseForm = true;
                Application.Exit();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string strUserID=txtUserID.Text.Trim();
            string strUserPWD=txtUserPwd.Text.Trim();
            //string strYearMonth=cmbYearMonth.Text.Trim();
            if(strUserID.Length <1)
            {
                MessageBox.Show("用户名不能为空！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUserID.Focus();
                txtUserID.Select();
                return;
            }
            if(strUserPWD.Length <1)
            {
                MessageBox.Show("密码不能为空！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtUserPwd.Focus();
                txtUserPwd.Select();
                return;
            }
            //if (strYearMonth.Length < 1)
            //{
            //    MessageBox.Show("请选择或输入年月！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    cmbYearMonth.Focus();
            //    cmbYearMonth.Select();
            //    return;
            //}
            //if (!CheckYearMonth(cmbYearMonth.Text))
            //{
            //    MessageBox.Show("请输入正确的年月！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    cmbYearMonth.Focus();
            //    cmbYearMonth.Select();
            //    return;
            //}
            XTHotpatalWebServices.Service webSerices = new UI.XTHotpatalWebServices.Service();
            string[] resoult = webSerices.ValidateUserNoYearMonth(GlobalVal.gloStrLoginUserID,GlobalVal.gloStrTerminalCD, strUserID, strUserPWD);
            if (resoult[0] == "1")
            {
                webSerices.AddLog("管理用户[" + strUserID+"]登录了系统.", "2", Dns.GetHostAddresses(Dns.GetHostName())[0].ToString());
                //GlobalVal.gloYearMonth = strYearMonth;
                GlobalVal.gloStrLoginUserID = strUserID;
                GlobalVal.gloStrLoginUserType = resoult[2];
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                webSerices.AddLog("用户[" + strUserID + "]尝试登录管理系统失败." + resoult[1], "2", Dns.GetHostAddresses(Dns.GetHostName())[0].ToString());
                MessageBox.Show(resoult[1], "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void FromLogin_Load(object sender, EventArgs e)
        {
            this.Height = 248;
            this.Activate();
            //Method.CmbDataBound("YearMonth", cmbYearMonth);
        }

        /// <summary>
        /// SetYearMonth
        /// </summary>
        /// <param name="YearMonth"></param>
        /// <returns></returns>
        private bool CheckYearMonth(string YearMonth)
        {
            bool blFlag = false;
            int intYear = 0;
            int intMonth = 0;
            if (YearMonth.Trim().Length == 6)
            {
                try
                {
                    intYear = Int32.Parse(YearMonth.Substring(0, 4));
                    intMonth = Int32.Parse(YearMonth.Substring(4, 2));
                    if (1900 <= intYear && intYear <= 2100 && 1 <= intMonth && intMonth <= 12)
                    {
                        blFlag = true;
                    }
                }
                catch
                {
                }
            }
            return blFlag;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("IEXPLORE.exe", "http://www.shangmeisi.com");
        }

        private void FromLogin_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (btnLogin.Enabled)
                    {
                        btnLogin_Click(sender, e);
                    }
                    break;
                case Keys.Escape:

                    if (btnExit.Enabled)
                    {
                        btnExit_Click(sender, e);
                    }
                    break;
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            this.Height = 352;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool blws = false;
            try
            {
                XTHotpatalWebServices.Service webServices = new UI.XTHotpatalWebServices.Service();
                webServices.Url = txtServerURL.Text;
                string strResoult = webServices.CheckWebServices();
                if (strResoult.Trim() == "WanGang")
                {
                    blws = true;
                    MessageBox.Show("成功连接服务！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Height = 248;
                }
            }
            catch
            { }
            finally
            {
                if (!blws)
                {
                    MessageBox.Show("不能连接到服务器！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Height = 248;
        }
    }
}