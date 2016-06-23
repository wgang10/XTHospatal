using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DeleteFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        lbMessage.Text = "";
        try
        {
            txtFilePath.Text = System.Web.HttpContext.Current.Server.MapPath(txtFileName.Text);
            txtFilePath.DataBind();
        }
        catch (Exception ex)
        {
            lbMessage.Text = ex.Message;
            lbMessage.DataBind();
        }

    }
    protected void btnDelate_Click(object sender, EventArgs e)
    {
        if (txtVerification.Text != "wan") return;
        lbMessage.Text = "";
        try
        {
            File.Delete(txtFilePath.Text);
            lbMessage.Text = "完成删除";
        }
        catch (Exception ex)
        {
            lbMessage.Text = ex.Message;
            lbMessage.DataBind();
        }
    }
    protected void btnDeleteFolder_Click(object sender, EventArgs e)
    {
        if (txtVerification.Text != "wan") return;
        lbMessage.Text = "";
        try
        {
            DirectoryInfo di = new DirectoryInfo(txtFilePath.Text);
            di.Delete(true);
            lbMessage.Text = "完成删除";
        }
        catch (Exception ex)
        {
            lbMessage.Text = ex.Message;
            lbMessage.DataBind();
        }
    }
}