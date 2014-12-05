﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPageZiYang : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserInfo"] == null)
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
    }
}
