using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rkl.Erp.Sage.Sage100.TableObjects;

namespace TechDashboardWEBAPI.ServiceCode
{
    public partial class TdWsService
    {
        #region SO_SalesOrderHeader

        public List<SO_SalesOrderHeader> GetSDataForSO_SalesOrderHeaderFiltered(string filterType, string filterText)
        {
            return GetData<SO_SalesOrderHeader>(filterType, filterText);
        }

        public List<SO_SalesOrderHeader> GetSDataForSO_SalesOrderHeaderAll()
        {
            return GetData<SO_SalesOrderHeader>(string.Empty, string.Empty);
        }

        #endregion
    }
}
