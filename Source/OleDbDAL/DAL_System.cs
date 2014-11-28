using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Text;
using XTHospital.COM;
using XTHospital.DB;
using XTHospital.IDAL;
using XTHospital.Model;

namespace XTHospital.OleDbDAL
{
    public class DAL_System : IDAL_System
    {
        #region SQL Statement

        private string getNews_SQL = @"Select Top @@@ ID,SystemName,CreateTime,Title,Url,Body From News Where TRANS_STATE <> '3' ";

        private string deleteNews_physic_SQL = @"Delete From  News Where ID = @ID ";

        private string deleteNews_logic_SQL = @"Update News set TRANS_STATE='3' Where ID = @ID ";

        private string addNews_SQL = @"Insert into News (TRANS_STATE,SystemName,CreateTime,Title,Url,Body) values ('1',@SystemName,now(),@Title,@Url,@Body) ";

        private string updateNews_SQL = @"update News set TRANS_STATE='2',SystemName=@SystemName,CreateTime=now(),Title=@Title,Url=@Url,Body=@Body Where ID <> @ID ";

        #endregion

        #region 方法

        public ReturnValue GetNewsList(string SystemName, int Num)
        {
            string strWhere = string.Empty;
            strWhere += " and SystemName = '" + SystemName + "' Order By CreateTime Desc";
            return OleDbHelper.Query(getNews_SQL.Replace("@@@",Num.ToString()) + strWhere);
        }

        public ReturnValue UpdateNews(News model)
        {
            OleDbParameter[] parametersAdd = {
					new OleDbParameter("@SystemName", OleDbType.VarWChar,50),
					new OleDbParameter("@Title", OleDbType.VarChar,100),
                    new OleDbParameter("@Url", OleDbType.VarChar,100),
					new OleDbParameter("@Body", OleDbType.LongVarWChar),
                    new OleDbParameter("@ID", OleDbType.Integer)};
            parametersAdd[0].Value = model.SystemName;
            parametersAdd[1].Value = model.Title;
            parametersAdd[2].Value = model.Url;
            parametersAdd[3].Value = model.Body;
            parametersAdd[4].Value = model.NewsID;
            return OleDbHelper.ExecuteSql(updateNews_SQL, parametersAdd);
        }

        public ReturnValue AddNews(News model)
        {
            OleDbParameter[] parametersAdd = {
					new OleDbParameter("@SystemName", OleDbType.VarWChar,50),
					new OleDbParameter("@Title", OleDbType.VarChar,100),
                    new OleDbParameter("@Url", OleDbType.VarChar,100),
					new OleDbParameter("@Body", OleDbType.LongVarWChar)};
            parametersAdd[0].Value = model.SystemName;
            parametersAdd[1].Value = model.Title;
            parametersAdd[2].Value = model.Url;
            parametersAdd[3].Value = model.Body;
            return OleDbHelper.ExecuteSql(addNews_SQL, parametersAdd);
        }

        public ReturnValue DeleteNewsPhysic(string ID)
        {
            OleDbParameter[] parameters = { new OleDbParameter("@ID", OleDbType.Integer) };
            parameters[0].Value = ID;
            return OleDbHelper.ExecuteSql(deleteNews_physic_SQL, parameters);
        }

        public ReturnValue DeleteNewsLogic(string ID)
        {
            OleDbParameter[] parameters = { new OleDbParameter("@ID", OleDbType.Integer) };
            parameters[0].Value = ID;
            return OleDbHelper.ExecuteSql(deleteNews_logic_SQL, parameters);
        }

        #endregion
    }
}
