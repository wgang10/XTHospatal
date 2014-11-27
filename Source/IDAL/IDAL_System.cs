using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;

namespace XTHospital.IDAL
{
    public interface IDAL_System
    {
        ReturnValue GetNewsList(string SystemName, int Num);
    }
}
