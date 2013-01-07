using System;
using System.Collections.Generic;
using System.Text;
using XTHospital.COM;
using XTHospital.FDAL;
using XTHospital.Model;
using XTHospital.IDAL;

namespace XTHospital.BLL
{
    public class BLL_Report
    {
        private readonly IDAL_Report dalReport = Factory.CreateReport();
        public ReturnValue AddUpdate(Report model)
        {
            ReturnValue resoult = dalReport.Search(model.EmployeeID,model.YearMonth);
            if (!resoult.ErrorFlag)
            {
                return resoult;
            }
            if (resoult.Count > 0)
            {
                resoult = dalReport.Update(model);
            }
            else
            {
                resoult = dalReport.Add(model);
            }
            return resoult;
        }
    }
}
