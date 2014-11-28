using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.IDAL;
using XTHospital.Model;

namespace XTHospital.DAL
{
    class DAL_System : IDAL_System
    {
        public ReturnValue GetNewsList(string SystemName, int Num)
        {
            return new ReturnValue();
        }

        public ReturnValue UpdateNews(News model)
        {
            return new ReturnValue();
        }

        public ReturnValue AddNews(News model)
        {
            return new ReturnValue();
        }

        public ReturnValue DeleteNewsPhysic(string ID)
        {
            return new ReturnValue();
        }

        public ReturnValue DeleteNewsLogic(string ID)
        {
            return new ReturnValue();
        }
    }
}
