using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XTHospital.BLL;

public partial class Register : System.Web.UI.Page
{
    private readonly BLLUser bll;

    public Register()
    {
        bll = new BLLUser();
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        lbRegisterMsg.Text = "";
        lbRegisterMsg.Visible = false;
        lbRegisterMsg.DataBind();
        string msg = string.Empty;

        //密码验证
        if (!txtPassWord.Text.Trim().Equals(txtPassWordVerify.Text.Trim()))
        {
            lbRegisterMsg.Visible = true;
            lbRegisterMsg.Text = "两次输入密码不一致。";
            lbRegisterMsg.DataBind();
            return;
        }

        if (this.txtValidateCode.Text.Trim().ToUpper() != Session["CheckCode"].ToString().ToUpper())
        {
            lbRegisterMsg.Visible = true;
            lbRegisterMsg.Text = "验证码错误!";
            lbRegisterMsg.DataBind();
            return;
        }

        //邮箱验证
        if (!bll.CheckEmail(txtEmail.Text.Trim(), ref msg))
        {
            lbRegisterMsg.Visible = true;
            lbRegisterMsg.Text = msg;
            lbRegisterMsg.DataBind();
            return;
        }

        int ID = -1;
        if (bll.RegistMember(txtNickName.Text.Trim(), txtEmail.Text.Trim(), txtPassWord.Text.Trim(), ref msg, ref ID))
        {
            //注册成功
            //邮箱激活
            Response.Redirect(String.Format("ActivatMember.aspx?LoginID={0}&NickName={1}&LimitTime={2}&ID={3}", txtEmail.Text.Trim(), txtNickName.Text.Trim(), msg, ID));
        }
        else
        {
            //注册失败
            lbRegisterMsg.Visible = true;
            lbRegisterMsg.Text = msg;
            lbRegisterMsg.DataBind();
        }
    }
}