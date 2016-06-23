using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class XTHospitalLogOut : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        XTHospital.BLL.BLL_Log.AddLog("查询用户[" + Session["LoginUserName"].ToString() + "]退出了系统.", "1", Page.Request.UserHostAddress);//添加日志
        Session.Abandon();
        System.Web.Security.FormsAuthentication.SignOut();
        Response.Redirect("MyLogin.aspx");
    }
}