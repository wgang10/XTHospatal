using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Rss : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            System.Text.StringBuilder strNews = new System.Text.StringBuilder();
            DataTable dt = ReadRss(@"http://cnbeta.feedsportal.com/c/34306/f/624776/index.rss");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                strNews.AppendLine(string.Format(@"<li>
    <div>
        <a target='_blank' href='{0}'>{1}</a>
    <div>
        <span>发布于<em>{2}</em></span>
        <div>{3}</div>                            
</li>",dt.Rows[i]["link"].ToString()
          ,dt.Rows[i]["title"].ToString()
          ,dt.Rows[i]["pubDate"].ToString()
          ,dt.Rows[i]["description"].ToString()));
            }
            this.ulNews.InnerHtml = strNews.ToString();
            this.ulNews.DataBind();
        }
    }

    /// <summary>
    /// 获取Rss资源
    /// </summary>
    /// <param name="RssURL"></param>
    /// <returns></returns>
    public static DataTable ReadRss(string RssURL)
    {
        DataTable Dt = new DataTable();
        DataColumn Title = new DataColumn("title", typeof(string));
        DataColumn PubDate = new DataColumn("pubDate", typeof(string));
        DataColumn Link = new DataColumn("link", typeof(string));
        DataColumn Description = new DataColumn("description", typeof(string));
        Dt.Columns.Add(Title);
        Dt.Columns.Add(PubDate);
        Dt.Columns.Add(Link);
        Dt.Columns.Add(Description);

        System.Net.WebRequest myRequest = System.Net.WebRequest.Create(RssURL);
        System.Net.WebResponse myResponse = myRequest.GetResponse();

        System.IO.Stream rssStream = myResponse.GetResponseStream();
        System.Xml.XmlDocument rssDoc = new System.Xml.XmlDocument();
        rssDoc.Load(rssStream);

        System.Xml.XmlNodeList rssItems = rssDoc.SelectNodes("rss/channel/item");
        for (int i = 0; i < rssItems.Count; i++)
        {
            DataRow Row = Dt.NewRow();
            System.Xml.XmlNode rssDetail;
            //标题
            rssDetail = rssItems.Item(i).SelectSingleNode("title");
            if (rssDetail != null)
            {
                Row["Title"] = rssDetail.InnerText;
            }
            else
            {
                Row["Title"] = "";
            }
            //作者
            rssDetail = rssItems.Item(i).SelectSingleNode("description");
            if (rssDetail != null)
            {
                Row["Description"] = rssDetail.InnerText;
            }
            else
            {
                Row["Description"] = "";
            }
            //发布时间
            rssDetail = rssItems.Item(i).SelectSingleNode("pubDate");
            if (rssDetail != null)
            {
                Row["PubDate"] = Convert.ToDateTime(rssDetail.InnerText).ToString("yyyy年MM月dd日");
            }
            else
            {
                Row["PubDate"] = "";
            }
            //链接地址
            rssDetail = rssItems.Item(i).SelectSingleNode("link");
            if (rssDetail != null)
            {
                Row["Link"] = rssDetail.InnerText;
            }
            else
            {
                Row["Link"] = "";
            }
            Dt.Rows.Add(Row);
        }
        return Dt;
    }
}