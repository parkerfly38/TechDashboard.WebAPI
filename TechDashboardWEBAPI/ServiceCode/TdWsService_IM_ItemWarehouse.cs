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
        #region IM_ItemWarehouse

        public List<IM_ItemWarehouse> GetSDataForIM_ItemWarehouseFiltered(string filterType, string filterText)
        {
            return GetData<IM_ItemWarehouse>(filterType, filterText);
        }

        public List<IM_ItemWarehouse> GetSDataForIM_ItemWarehouseAll()
        {
            return GetData<IM_ItemWarehouse>(string.Empty, string.Empty);
        }

        #endregion
    }
}
