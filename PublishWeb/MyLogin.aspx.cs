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

public partial class MyLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
        }
    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        try
        {
            LiteralMsg.Text = "";
            LiteralMsg.DataBind();
            if (this.txtValidateCode.Text.Trim().ToUpper() == Session["CheckCode"].ToString().ToUpper())
            {
                string strUserID = txtLoginID.Text.Trim();
                string strUserPWD = txtPWD.Text.Trim();
                string strEmployeeName = string.Empty;
                XTHospital.BLL.BLL_LoginUser bll = new XTHospital.BLL.BLL_LoginUser();
                XTHospital.COM.ReturnValue resoult = bll.GetEmployeePWD(strUserID);
                if (resoult.ErrorFlag)
                {
                    if (resoult.Count < 1)
                    {
                        XTHospital.BLL.BLL_Log.AddLog("查询用户[" + strUserID + "]尝试登录系统失败，用户名或密码错误！", "1", Page.Request.UserHostAddress);//添加日志
                        LiteralMsg.Text = "用户名或密码错误！";
                        LiteralMsg.DataBind();
                        return;
                    }
                    else
                    {
                        if (strUserPWD == resoult.ResultDataSet.Tables[0].Rows[0]["EmployeePWD"].ToString())
                        {
                            Session["LoginUserID"] = strUserID;
                            Session["LoginUserName"] = strEmployeeName;
                            strEmployeeName = resoult.ResultDataSet.Tables[0].Rows[0]["EmployeeName"].ToString().Trim();
                            Session["EmployeeID"] = resoult.ResultDataSet.Tables[0].Rows[0]["EmployeeID"].ToString().Trim();
                            Session["EmployeeMail"] = resoult.ResultDataSet.Tables[0].Rows[0]["EmployeeEmail"].ToString().Trim();
                            Session["EmployeePhone"] = resoult.ResultDataSet.Tables[0].Rows[0]["EmployeePhone"].ToString().Trim();
                            XTHospital.BLL.BLL_Log.AddLog("查询用户[" + strEmployeeName + "]登录了系统.", "1", Page.Request.UserHostAddress);//添加日志
                            Response.Redirect("XTHospitalDefault.aspx");
                        }
                        else
                        {
                            LiteralMsg.Text = "用户名或密码错误！";
                            LiteralMsg.DataBind();
                            return;
                        }
                    }
                }
                else
                {
                    LiteralMsg.Text = resoult.ErrorID;
                    LiteralMsg.DataBind();
                    return;
                }
            }
            else
            {
                LiteralMsg.Text = "验证码错误!";
                LiteralMsg.DataBind();
                return;
            }
        }
        catch(Exception ex)
        {
            LiteralMsg.Text = ex.Message;
            LiteralMsg.DataBind();
            return;
        }
    }  

    protected void btnFindPassWord_Click(object sender, EventArgs e)
    {
        Response.Redirect("XTHospitalFindPassWord.aspx");
    }
}
