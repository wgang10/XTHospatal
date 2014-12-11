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
        if (!IsPostBack)
        {
            if (Request.QueryString["ID"] != null && Request.QueryString["ID"].ToString() != "")
            {
                IList<Member> list = bll.GetAllMemberByID(Int32.Parse(Request.QueryString["ID"]));
                if (list.Count > 0)
                {
                    Session["MemberInfo"] = list[0];
                }
            }

            if (Session["MemberInfo"] == null)
            {
                Response.Redirect("Login.aspx", true);
                return;
            }
            SetMemberInfo();
        }
    }    
    
    protected void rdbNotExist_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbNotExist.Checked)
        {
            lbMessage.Text = "";
            lbMessage.Visible = false;
            lbMessage.DataBind();
            lbEmail.Text = "邮箱地址:";
            lbPassWord.Text = "设置密码:";
            btnBindEmail.Text = "绑定账号";
            //btnVerify.DataBind();
        }
    }
    protected void rdbExist_CheckedChanged(object sender, EventArgs e)
    {
        if (rdbExist.Checked)
        {
            lbMessage.Text = "";
            lbMessage.Visible = false;
            lbMessage.DataBind();
            lbEmail.Text = "登陆账号:";
            lbPassWord.Text = "登录密码:";
            btnBindEmail.Text = "登录账号";
            //btnVerify.DataBind();
        }
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
            btnUnBindQQ.Visible = true;
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
    protected void btnUnBindQQ_Click(object sender, EventArgs e)
    {

    }
    protected void btnChangeBindQQ_Click(object sender, EventArgs e)
    {

    }
    protected void btnBindEmail_Click(object sender, EventArgs e)
    {
        lbMessage.Text = "";
        lbMessage.Visible = false;

        Member modelMember = (Member)Session["MemberInfo"];
        string strMsg = string.Empty;
        if (rdbNotExist.Checked)
        {
            //邮箱激活
            if (bll.BindNewEmail(txtEmail.Text, txtPassWord.Text, modelMember.Id, ref strMsg))
            {
                //显示已经激活，QQ账号登录后确实是已经激活状态
                //输入正确激活码后应该直接登录显示绑定的邮箱
                //另外现在没有添加历史记录
                Response.Redirect(String.Format("ActivatMember.aspx?LoginID={0}&NickName={1}&LimitTime={2}&ID={3}", txtEmail.Text.Trim(), modelMember.Nickname, strMsg, modelMember.Id));
            }
            else
            {
                lbMessage.Visible = true;
                lbMessage.Text = strMsg;
            }
        }
        else
        {
            if (bll.BindOldEmail(txtEmail.Text, txtPassWord.Text, modelMember.Id, ref strMsg))
            {
                lbLoginID.Text = String.Format("邮箱/登录账号:<strong>{0}</strong>", txtEmail.Text);
                modelMember.Email = txtEmail.Text;
                Session["MemberInfo"] = modelMember;
                lbMessage.Visible = true;
                lbLoginTimes.Text = String.Format("这是您第 {0} 次登录", strMsg);
                lbMessage.Text = "邮箱绑定成功";
                divBindEmail.Visible = false;
            }
            else
            {
                lbMessage.Visible = true;
                lbMessage.Text = strMsg;
            }
        }
    }
}