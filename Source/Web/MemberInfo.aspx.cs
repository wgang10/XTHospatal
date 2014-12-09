using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XTHospital.BLL;
using XTHospital.COMM.Entity;

public partial class MebmerInfo : System.Web.UI.Page
{
    private readonly BLLUser bll;

    public MebmerInfo()
    {
        bll = new BLLUser();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MemberInfo"] == null)
        {
            Response.Redirect("Login.aspx", true);
            return;
        }
        if (!IsPostBack)
        {
            SetMemberInfo();
        }
    }
    protected void btnBindQQ_Click(object sender, EventArgs e)
    {

    }
    protected void btnVerify_Click(object sender, EventArgs e)
    {

    }
    protected void rdbNotExist_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void rdbExist_CheckedChanged(object sender, EventArgs e)
    {

    }

    private void SetMemberInfo()
    {
        Member modelMember = (Member)Session["MemberInfo"];
        if (!string.IsNullOrEmpty(modelMember.Email))
        {
            lbLoginID.Text = String.Format("邮箱/登录账号:<strong>{0}</strong>", modelMember.Email);
        }
        else
        {
            divBindEmail.Visible = true;
        }

        if (modelMember.Status.Equals(4))
        {
            lbLoginID.Text = String.Format("已绑定邮箱:<strong>{0}</strong>,但还未进行激活！     <a href='#'>进行激活</a>", modelMember.Email);
        }

        if (string.IsNullOrEmpty(modelMember.OpenId))
        {
            divBingQQ.Visible = true;
        }

        if (!string.IsNullOrEmpty(modelMember.OpenId) && !string.IsNullOrEmpty(modelMember.Email))
        {
            lbBindQQ.Text = "已经绑定QQ账号";
            btnBindQQ.Visible = true;
        }

        lbNickname.Text = String.Format("欢迎您:<strong>{0}</strong>", modelMember.Nickname);
        lbLoginTimes.Text = String.Format("这是您第 {0} 次登录", modelMember.LoginTimes);

        if (modelMember.LoginTimes < 2)
        {
            lbLastLoginDateTime.Text = "";
        }
        else
        {
            lbLastLoginDateTime.Text = "上次登陆时间:" + modelMember.LastLoginDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss");

        }
        lbIntegral.Text = "您的当前积分为:" + modelMember.Integral.ToString();
        if (string.IsNullOrEmpty(modelMember.PhotoURL))
        {
            imgPhoto.ImageUrl = @"~/images/photo.jpg";
        }
        else
        {
            imgPhoto.ImageUrl = modelMember.PhotoURL;
        }

    }
}