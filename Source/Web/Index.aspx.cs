using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadNews();
    }

    /// <summary>
    /// 加载新闻
    /// </summary>
    public void LoadNews()
    {
        if (!IsPostBack)
        {
            XTHospital.BLL.BLL_System bll = new XTHospital.BLL.BLL_System();
            List<XTHospital.Model.News> list = bll.GetNewsList("Public", 10);
            System.Text.StringBuilder strNews = new System.Text.StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                strNews.AppendLine(@"<li><a title=" + list[i].Body + " href=" + list[i].Url + ">" + list[i].Title + "【" + list[i].CreateTime.ToShortDateString() + "】</a></li>");
            }
            this.ulNews.InnerHtml = strNews.ToString();
            this.ulNews.DataBind();
        }
    }

}