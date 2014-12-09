using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            Session["UserInfo"] = Page.Request.UserHostAddress + "|" + Page.Request.Browser.ToString();
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {

    }
    protected void btnFindPassWord_Click(object sender, EventArgs e)
    {

    }
}