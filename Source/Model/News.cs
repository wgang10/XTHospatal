using System;
using System.Collections.Generic;
using System.Text;

namespace XTHospital.Model
{
    public class News
    {
        public News() { }
        public News(string ID,string SystemName,DateTime createtiem,string title,string url,string body) 
        { 
            this.CreateTime = createtiem;
            this.SystemName = SystemName;
            this.Title = title;
            this.Url = url;
            this.Body = body;
            this.NewsID = ID;
        }
        public DateTime CreateTime { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Body { get; set; }
        public string SystemName { get; set; }
        public string NewsID { get; set; }
    }
}
