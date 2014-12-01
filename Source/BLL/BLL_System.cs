using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.FDAL;
using XTHospital.IDAL;
using XTHospital.Model;

namespace XTHospital.BLL
{
    public class BLL_System
    {
        private readonly IDAL_System dal = Factory.CreateSystem();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<News> GetNewsList(string SystemName, int Num)
        {
            List<News> list = new List<News>();
            ReturnValue resoult = dal.GetNewsList(SystemName,Num);
            if (resoult.ErrorFlag)
            {
                for (int i = 0; i < resoult.Count; i++)
                {
                    News news = new News(resoult.ResultDataSet.Tables[0].Rows[i]["ID"].ToString(),
                        resoult.ResultDataSet.Tables[0].Rows[i]["SystemName"].ToString(),
                        DateTime.Parse(resoult.ResultDataSet.Tables[0].Rows[i]["CreateTime"].ToString()),
                        resoult.ResultDataSet.Tables[0].Rows[i]["Title"].ToString(),
                        resoult.ResultDataSet.Tables[0].Rows[i]["Url"].ToString(),
                        resoult.ResultDataSet.Tables[0].Rows[i]["Body"].ToString());
                    list.Add(news);
                }
            }
            return list;
        }

        public ReturnValue DeleteNewsLogic(string ID)
        {
            return dal.DeleteNewsLogic(ID);
        }

        public ReturnValue DeleteNewsPhysic(string ID)
        {
            return dal.DeleteNewsPhysic(ID);
        }

        public ReturnValue AddUpdateNews(News model)
        {
            ReturnValue resoult;
            if (!string.IsNullOrEmpty(model.NewsID))
            {
                resoult = dal.SearchNews(model.NewsID);
                if (!resoult.ErrorFlag)
                {
                    return resoult;
                }
                if (resoult.Count > 0)
                {
                    resoult = dal.UpdateNews(model);
                }
                else
                {
                    resoult = dal.AddNews(model);
                }
            }
            else
            {
                resoult = dal.AddNews(model);
            }
            return resoult;
        }
    }
}
