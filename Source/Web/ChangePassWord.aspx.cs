using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XTHospital.BLL;
using XTHospital.COMM.Entity;

public partial class ChangePassWord : System.Web.UI.Page
{
    private readonly BLLUser bll;

    public ChangePassWord()
    {
        bll = new BLLUser();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Literal1.Visible = false;
            //Literal1.Text = Request.Url.ToString();
        }
        //if (!IsPostBack)
        //{
        //    if (Session["UserInfo"] != null)
        //    {
        //        this.Label1.Text = Session["UserInfo"].ToString();
        //    }
        //    else
        //    {
        //        Response.Redirect("Login.aspx");
        //    }
        //}
    }

    /// <summary>
    /// 修改密码
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        LiteralMsg.Visible = false;
        //密码验证
        if (!txtNewPWD.Text.Trim().Equals(txtConfirmNewPWD.Text.Trim()))
        {
            LiteralMsg.Visible = true;
            LiteralMsg.Text = "两次输入密码不一致。";
            LiteralMsg.DataBind();
            return;
        }
        Member modelMember = (Member)Session["MemberInfo"];
        string msg = string.Empty;
        if (bll.ChangePassWord(modelMember.Id, txtOldPWD.Text.Trim(), txtNewPWD.Text.Trim(), ref msg))
        {
            LiteralMsg.Visible = true;
            LiteralMsg.Text = "密码修改成功。";
            LiteralMsg.DataBind();
        }
        else
        {
            LiteralMsg.Visible = true;
            LiteralMsg.Text = msg;
            LiteralMsg.DataBind();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("MemberInfo.aspx");
    }
}