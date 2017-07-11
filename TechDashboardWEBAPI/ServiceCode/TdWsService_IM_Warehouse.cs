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
        #region IM_Warehouse

        /// <summary>
        /// GetSDataForIM_WarehouseFiltered
        /// Returns data from IM_Warehouse table via SDATA, using a filter on the data
        /// </summary>
        /// <param name="filterType"></param>
        /// <param name="filterText"></param>
        /// <returns></returns>
        public List<IM_Warehouse> GetSDataForIM_WarehouseFiltered(string filterType, string filterText)
        {
            return GetData<IM_Warehouse>(filterType, filterText);
        }

        /// <summary>
        /// GetSDataForIM_WarehouseAll
        /// Returns data from IM_Warehouse table via SDATA, returning all data
        /// </summary>
        /// <returns></returns>
        public List<IM_Warehouse> GetSDataForIM_WarehouseAll()
        {
            return GetData<IM_Warehouse>(string.Empty, string.Empty);
        }

        #endregion
    }
}
