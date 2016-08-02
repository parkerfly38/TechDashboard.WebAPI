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
        #region JT_ServiceEquipmentParts

        public List<JT_ServiceEquipmentParts> GetSDataForJT_ServiceEquipmentPartsFiltered(string filterType, string filterText)
        {
            return GetData<JT_ServiceEquipmentParts>(filterType, filterText);
        }

        public List<JT_ServiceEquipmentParts> GetSDataForJT_ServiceEquipmentPartsAll()
        {
            return GetData<JT_ServiceEquipmentParts>(string.Empty, string.Empty);
        }

        #endregion
    }
}
