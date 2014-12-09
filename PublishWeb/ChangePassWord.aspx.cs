using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassWord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
    protected void btnSave_Click(object sender, EventArgs e)
    {

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}