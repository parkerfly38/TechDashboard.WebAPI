using Rkl.Erp.Sage.Sage100.TableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechDashboardWEBAPI.ServiceCode
{
    public partial class TdWsService
    {
        public List<SO_SalesOrderDetail> GetSDataForSO_SalesOrderDetailFiltered(string filterType, string filterText)
        {
            return GetData<SO_SalesOrderDetail>(filterType, filterText);
        }

        public List<SO_SalesOrderDetail> GetSDataForSO_SalesOrderDetailAll()
        {
            return GetData<SO_SalesOrderDetail>(string.Empty, string.Empty);
        }
    }
}