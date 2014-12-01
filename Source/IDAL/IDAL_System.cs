using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.Model;

namespace XTHospital.IDAL
{
    public interface IDAL_System
    {
        ReturnValue GetNewsList(string SystemName, int Num);

        ReturnValue SearchNews(string ID);

        ReturnValue UpdateNews(News model);

        ReturnValue AddNews(News model);

        ReturnValue DeleteNewsPhysic(string ID);

        ReturnValue DeleteNewsLogic(string ID);
    }
}
