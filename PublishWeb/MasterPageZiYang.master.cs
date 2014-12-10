using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPageZiYang : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["MemberInfo"] == null)
        {
            this.divLogin.Visible = true;
            this.divLogined.Visible = false;
        }
        else
        {
            this.divLogin.Visible = false;
            this.divLogined.Visible = true;
        }
    }
    protected void btnLogOut_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        System.Web.Security.FormsAuthentication.SignOut();
        Response.Redirect(Request.Url.ToString()+"?"+new Random().Next(1000));
    }
}
