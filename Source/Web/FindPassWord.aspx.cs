using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XTHospital.BLL;
using XTHospital.COMM.Entity;

public partial class FindPassWord : System.Web.UI.Page
{
    BLLUser bll;

    public FindPassWord()
    {
        bll = new BLLUser();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Login.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        lbLoginMessage.Visible = false;
        if (string.IsNullOrEmpty(txtMail.Text.Trim()))
        {
            lbLoginMessage.Visible = true;
            lbLoginMessage.Text = "邮箱不能为空。";
            lbLoginMessage.Visible = true;
            return;
        }

        if (this.txtValidateCode.Text.Trim().ToUpper() != Session["CheckCode"].ToString().ToUpper())
        {
            lbLoginMessage.Visible = true;
            lbLoginMessage.Text = "验证码错误!";
            lbLoginMessage.DataBind();
            return;
        }


        string strMail = txtMail.Text.Trim();
        IList<Member> list = bll.GetAllMemberByEmail(strMail);
        if (list.Count > 0)
        {

            bool blFlag = false;
            string strPassWord = "";//新密码;
            string strUserName = list[0].Nickname;
            string strMessage = string.Empty;
            string strTitle = "子扬软件找回密码";
            string strMailTo = strMail;
            string strMailBody = @"尊敬的阁下：
	您好！很高兴您能收到这封邮件。
	
	您最近忘记密码了吗?以后要牢记哦。
    
	您的账号为：" + strMail + "   密码：" + strPassWord;
            strMailBody += @"

致
	敬


    子扬软件

    本邮件为系统自动发送，请勿回复。";
            blFlag = XTHospital.COM.Method.SendMail1(strMailTo, strTitle, strMailBody, out strMessage);
            if (blFlag)
            {
                XTHospital.BLL.BLL_Log.AddLog("用户[" + strUserName + "]使用了找回密码功能，将密码发送到了邮箱[" + strMailTo + "].", "1", Page.Request.UserHostAddress);//添加日志
                lbLoginMessage.Text = "密码已经发送到了您的邮箱！请查收";
                lbLoginMessage.DataBind();
                return;
            }
            else
            {
                XTHospital.BLL.BLL_Log.AddLog("用户[" + strUserName + "]使用了找回密码功能，发送到邮箱[" + strMailTo + "]时失败." + strMessage, "1", Page.Request.UserHostAddress);//添加日志
                lbLoginMessage.Text = "发送到邮箱[" + strMailTo + "]时失败.";
                lbLoginMessage.DataBind();
                return;
            }
        }
        else
        {
            XTHospital.BLL.BLL_Log.AddLog("用户[" + strMail + "]尝试找回密码失败，用户名不存在！", "1", Page.Request.UserHostAddress);//添加日志
            lbLoginMessage.Text = "用户名不存在！";
            lbLoginMessage.DataBind();
            return;
        }
    }
}