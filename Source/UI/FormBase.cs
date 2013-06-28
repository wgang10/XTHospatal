using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        #region ""

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
        #endregion

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
                        Method.MessageShow(GlobalVal.glostrMsg);
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
                        Method.MessageShow(GlobalVal.glostrMsg);
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
                        Method.MessageShow(GlobalVal.glostrMsg);
                        return false;
                    }
                    break;

                #endregion

                #region enumCheckItems.UserGroup
                case enumCheckItems.UserGroup:
                    if (!Method.CheckIsAllInputType(strValue, 50, blnAllowEmpty, true))
                    {
                        Method.MessageShow(GlobalVal.glostrMsg);
                        return false;
                    }
                    break;
                #endregion

                #region enumCheckItems.DateYMD

                case enumCheckItems.DateYMD:
                    if (!Method.CheckIsDate(strValue,blnAllowEmpty, true))
                    {
                        Method.MessageShow(GlobalVal.glostrMsg);
                        return false;
                    }
                    break;

                #endregion

                #region enumCheckItems.PHONE_NO
                case enumCheckItems.PHONE_NO:
                    if (!Method.CheckIsTelNo(strValue,blnAllowEmpty, true))
                    {
                        Method.MessageShow(GlobalVal.glostrMsg);
                        return false;
                    }
                    break;
                #endregion

                #region enumCheckItems.E_Mail
                case enumCheckItems.E_Mail:
                    if (!Method.CheckIsEmail(strValue,blnAllowEmpty, true))
                    {
                        Method.MessageShow(GlobalVal.glostrMsg);
                        return false;
                    }
                    break;
                #endregion

                #region enumCheckItems.Post
                case enumCheckItems.Post:
                    if (!Method.CheckIsNumber(strValue, 6, blnAllowEmpty, true))
                    {
                        Method.MessageShow(GlobalVal.glostrMsg);
                        return false;
                    }
                    break;
                #endregion

                #region enumCheckItems.ItemMEMO

                case enumCheckItems.ItemMEMO:
                    if (!Method.CheckIsAllInputType(strValue, 128, blnAllowEmpty, true))
                    {
                        Method.MessageShow(GlobalVal.glostrMsg);
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

        private void FormBase_Load(object sender, EventArgs e)
        {
            linkLabel1.Text = GlobalVal.glostrSupportCompanyName;
            label139.Text = GlobalVal.glostrCopyright;
            lbUser.Text = GlobalVal.gloStrLoginUserID;
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("IEXPLORE.exe", GlobalVal.glostrSupportCompanyURL);
        }

    }
}