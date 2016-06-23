using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using XTHospital.BLL;
using XTHospital.COMM.Entity;

public partial class MemberManage : System.Web.UI.Page
{
    private readonly BLLUser bll;

    public MemberManage()
    {
        bll = new BLLUser();
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGridData();
        }
    }

    private void BindGridData()
    {
        IList<Member> list = bll.GetAllMembers();
        this.GridView1.DataSource = list;
        this.DataBind();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            GridViewRow row = GridView1.Rows[Convert.ToInt32(e.CommandArgument)];
            string strKeyValue = row.Cells[0].Text;
            try
            {
                bool blFalg = bll.DeleteMember(Convert.ToInt32(strKeyValue));
                if (blFalg)
                {
                    //Response.Write("<script>alert('删除成功!');</script>");
                    BindGridData();
                }
                else
                {
                    //Response.Write("<script>alert('删除失败!');</script>");
                    //this.DataBind();
                }

            }
            catch
            {
                //Response.Write("<script>alert('发生错误!');</script>");
                //Response.Redirect("ErrorPage.aspx");
                //this.DataBind();
            }
        }
        else if (e.CommandName == "Update")
        {
            GridViewRow row = GridView1.Rows[Convert.ToInt32(e.CommandArgument)];
            string strKeyValue = row.Cells[0].Text;
            Response.Redirect("MemberInfo.aspx?ID=" + strKeyValue);
            return;
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "javascript:style.backgroundColor='#F8F8F8';");
            e.Row.Attributes.Add("onmouseout", "javascript:this.style.backgroundColor='#ebf7fb';");
            e.Row.Attributes.Add("ondblclick", "javascript:window.location='MemberInfo.aspx?ID=" + e.Row.Cells[0].Text + "';");
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}