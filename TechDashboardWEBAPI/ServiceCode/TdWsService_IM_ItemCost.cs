using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Rkl.Erp.Sage.Sage100.TableObjects;

namespace TechDashboardWEBAPI.ServiceCode
{
    public partial class TdWsService
    {
        #region IM_ItemWarehouse

        public List<IM_ItemCost> GetSDataForIM_ItemCost(string filterType, string filterText)
        {
            return GetData<IM_ItemCost>(filterType, filterText);
        }

        public List<IM_ItemCost> GetSDataForIM_ItemCost()
        {
            return GetData<IM_ItemCost>(string.Empty, string.Empty);
        }

        #endregion
    }
}