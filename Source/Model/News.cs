using System;
using System.Collections.Generic;
using System.Text;

namespace XTHospital.Model
{
    public class News
    {
        public News() { }
        public News(int ID,string SystemName,DateTime createTime,DateTime updateTime,string title,string url,string body) 
        { 
            this.CreateTime = createTime;
            this.UpdateTime = updateTime;
            this.SystemName = SystemName;
            this.Title = title;
            this.Url = url;
            this.Body = body;
            this.ID = ID;
        }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Body { get; set; }
        public string SystemName { get; set; }
        public int ID { get; set; }
    }
}
