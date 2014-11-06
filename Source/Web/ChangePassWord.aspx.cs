using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class ChangePassWord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["LoginUserID"] == null || Session["LoginUserID"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                ShowData();
            }
        }
        catch
        {
            Response.Redirect("Login.aspx");
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtNewPWD.Text.Trim() != txtConfirmNewPWD.Text.Trim())
        {
            LiteralMsg.Text = "修改密码和确认密码不一致！";
            LiteralMsg.DataBind();
            return;
        }
        else
        {
            XTWebService.Employee model = new XTWebService.Employee();
            model.UPDATER_ID = Session["LoginUserID"].ToString();
            model.TERMINAL_CD="";
            model.EmployeePWD = txtOldPWD.Text.Trim();
            model.EmployeeNewPWD=txtConfirmNewPWD.Text.Trim();
            model.EmployeeEmail=txtMail.Text.Trim();
            model.EmployeePhone=txtEmployeePhone.Text.Trim();
            model.EmployeeID = Session["EmployeeID"].ToString();      
            XTWebService.ReturnValue resoult = GlobalValue.GloWebSerices.ChangePassWord(model);
            if (!resoult.ErrorFlag)
            {
                LiteralMsg.Text = resoult.ErrorID;
                LiteralMsg.DataBind();
                return;
            }
            else
            {
                LiteralMsg.Text = "修改成功！";
                Session["EmployeeMail"] = txtMail.Text.Trim(); ;
                Session["EmployeePhone"] = txtEmployeePhone.Text.Trim();
                LiteralMsg.DataBind();
                return;
            }
        }
    }

    protected void ShowData()
    {
        if (Session["EmployeeMail"] == null || Session["EmployeeMail"].ToString() == "")
        {
            txtMail.Text = "";
            txtMail.Enabled = true;
        }
        else
        {
            txtMail.Text = Session["EmployeeMail"].ToString();
            txtMail.Enabled = false;
        }
        if (Session["EmployeePhone"] == null || Session["EmployeePhone"].ToString() == "")
        {
            txtEmployeePhone.Text = "";
        }
        else
        {
            txtEmployeePhone.Text = Session["EmployeePhone"].ToString();
        }
        txtMail.DataBind();
        txtEmployeePhone.DataBind();
    }
}
