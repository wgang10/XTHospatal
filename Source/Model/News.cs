﻿using System;
using System.Collections.Generic;
using System.Text;

namespace XTHospital.Model
{
    public class News
    {
        public News() { }
        public News(DateTime createtiem,string title,string url,string body) 
        { 
            this.CreateTime = createtiem;
            this.Title = title;
            this.Url = url;
            this.Body = body;
        }
        public DateTime CreateTime { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Body { get; set; }
    }
}
