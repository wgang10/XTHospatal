using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XTHospital.COMM.Entity;
using XTHospital.BLL;

public partial class Login : System.Web.UI.Page
{
    private readonly BLLUser bll;
    public Login()
    {
        bll = new BLLUser();
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        lbLoginMessage.Visible = false;
        lbLoginMessage.Text = "";

        if (string.IsNullOrEmpty(txtLoginID.Text.Trim()) || string.IsNullOrEmpty(txtLoginPWD.Text.Trim()))
        {
            lbLoginMessage.Visible = true;
            lbLoginMessage.Text = "账号和密码不能为空。";
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

        string msg = string.Empty;
        Member modelMember = new Member();
        if (bll.LoginMember(txtLoginID.Text, txtLoginPWD.Text, ref msg, ref modelMember))
        {
            XTHospital.COM.UtilityLog.WriteInfo(string.Format("账号 {0} 登陆成功。", txtLoginID.Text));
            Session["MemberInfo"] = modelMember;
            Response.Redirect("MemberInfo.aspx", true);
        }
        else
        {
            txtValidateCode.Text = "";
            XTHospital.COM.UtilityLog.WriteInfo(string.Format("账号 {0} 登陆失败。{1}", txtLoginID.Text, msg));
            lbLoginMessage.Text = msg;
            lbLoginMessage.Visible = true;
        }
    }

    protected void btnFindPassWord_Click(object sender, EventArgs e)
    {
        Response.Redirect("FindPassWord.aspx");
    }
}