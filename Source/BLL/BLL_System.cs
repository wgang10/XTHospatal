using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
//using XTHospital.FDAL;
//using XTHospital.IDAL;
//using XTHospital.Model;
using XTHospital.COMM.Entity;
using XTHospital.ORM;

namespace XTHospital.BLL
{
    public class BLL_System
    {
        //private readonly IDAL_System dal = Factory.CreateSystem();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<Notic> GetNewsList(string SystemName, int Num)
        {
            //List<News> list = new List<News>();
            //ReturnValue resoult = dal.GetNewsList(SystemName,Num);
            //if (resoult.ErrorFlag)
            //{
            //    for (int i = 0; i < resoult.Count; i++)
            //    {
            //        News news = new News(resoult.ResultDataSet.Tables[0].Rows[i]["ID"].ToString(),
            //            resoult.ResultDataSet.Tables[0].Rows[i]["SystemName"].ToString(),
            //            DateTime.Parse(resoult.ResultDataSet.Tables[0].Rows[i]["CreateTime"].ToString()),
            //            resoult.ResultDataSet.Tables[0].Rows[i]["Title"].ToString(),
            //            resoult.ResultDataSet.Tables[0].Rows[i]["Url"].ToString(),
            //            resoult.ResultDataSet.Tables[0].Rows[i]["Body"].ToString());
            //        list.Add(news);
            //    }
            //}
            //return list;
            return OptionNews.GetNewsList(SystemName,Num);

        }

        public List<XTHospital.Model.News> GetNewsListForWeb(string SystemName, int Num)
        {
            //List<News> list = new List<News>();
            //ReturnValue resoult = dal.GetNewsList(SystemName,Num);
            //if (resoult.ErrorFlag)
            //{
            //    for (int i = 0; i < resoult.Count; i++)
            //    {
            //        News news = new News(resoult.ResultDataSet.Tables[0].Rows[i]["ID"].ToString(),
            //            resoult.ResultDataSet.Tables[0].Rows[i]["SystemName"].ToString(),
            //            DateTime.Parse(resoult.ResultDataSet.Tables[0].Rows[i]["CreateTime"].ToString()),
            //            resoult.ResultDataSet.Tables[0].Rows[i]["Title"].ToString(),
            //            resoult.ResultDataSet.Tables[0].Rows[i]["Url"].ToString(),
            //            resoult.ResultDataSet.Tables[0].Rows[i]["Body"].ToString());
            //        list.Add(news);
            //    }
            //}
            //return list;
            IList<Notic> list = OptionNews.GetNewsList(SystemName, Num);
            List<XTHospital.Model.News> listNews = new List<Model.News>();
            for (int i = 0; i < list.Count; i++)
            {
                listNews.Add(new Model.News(list[i].Id,
                    list[i].SystemName,
                    list[i].CreateTime,
                    list[i].UpdateTime,
                    list[i].Title,
                    list[i].Url,
                    list[i].Body));   
            }
            return listNews;
        }

        public bool DeleteNewsLogic(int ID)
        {
            IList<Notic> list = OptionNews.GetNewsByID(ID);
            if (list.Count>0)
            {
                list[0].Status = 2;
            }
            return OptionNews.UpdateNews(list[0]);
        }

        public bool DeleteNewsPhysic(int ID)
        {
            Notic model = new Notic();
            model.Id = ID;
            return OptionNews.DeleteNews(model);
        }

        public bool AddUpdateNews(Notic model)
        {
            //ReturnValue resoult;
            //if (!string.IsNullOrEmpty(model.NewsID))
            //{
            //    resoult = dal.SearchNews(model.NewsID);
            //    if (!resoult.ErrorFlag)
            //    {
            //        return resoult;
            //    }
            //    if (resoult.Count > 0)
            //    {
            //        resoult = dal.UpdateNews(model);
            //    }
            //    else
            //    {
            //        resoult = dal.AddNews(model);
            //    }
            //}
            //else
            //{
            //    resoult = dal.AddNews(model);
            //}
            //return resoult;

            IList<Notic> list = OptionNews.GetNewsByID(model.Id);
            if (list.Count > 0)
            {
                model.Status = 1;
                model.UpdateTime = DateTime.Now;
                return OptionNews.UpdateNews(model);
            }
            else
            {
                model.Status = 0;
                model.CreateTime = DateTime.Now;
                model.UpdateTime = DateTime.Now;
                if (OptionNews.SaveNews(model) == -1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
