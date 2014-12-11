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

        bool blFlag = false;
        string strMail = txtMail.Text.Trim();
        string nwePwd = string.Empty;
        if (!bll.FindPassWord(strMail, ref nwePwd))
        {
            lbLoginMessage.Visible = true;
            lbLoginMessage.Text = nwePwd;
            lbLoginMessage.DataBind();
            return;
        }
        string strMessage = string.Empty;
        string strTitle = "子扬软件找回密码";
        string strMailTo = strMail;
        string strMailBody = string.Format(@"亲爱的 {0},您好！
		
	您最近忘记密码了吗?以后要牢记哦。
    
	您的新密码是：{1}

致
	敬


    子扬软件

    本邮件为系统自动发送，请勿回复。", strMail, nwePwd);
        blFlag = XTHospital.COM.Method.SendMail2(strMailTo, strTitle, strMailBody, out strMessage);
        if (blFlag)
        {
            XTHospital.BLL.BLL_Log.AddLog("用户[" + strMailTo + "]使用了找回密码功能，将密码发送到了邮箱", "1", Page.Request.UserHostAddress);//添加日志
            lbLoginMessage.Visible = true;
            lbLoginMessage.Text = "新密码已经发送到了您的邮箱！使用新密码登陆请尽快修改为您容易记住的密码。";
            lbLoginMessage.DataBind();
            return;
        }
        else
        {
            XTHospital.BLL.BLL_Log.AddLog("用户[" + strMailTo + "]使用了找回密码功能，发送到邮箱时失败." + strMessage, "1", Page.Request.UserHostAddress);//添加日志
            lbLoginMessage.Visible = true;
            lbLoginMessage.Text = "发送到邮箱[" + strMailTo + "]时失败.";
            lbLoginMessage.DataBind();
            return;
        }
    }
}