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
        #region JT_EquipmentAsset

        public List<JT_EquipmentAsset> GetSDataForJT_EquipmentAssetFiltered(string filterType, string filterText)
        {
            return GetData<JT_EquipmentAsset>(filterType, filterText);
        }

        public List<JT_EquipmentAsset> GetSDataForJT_EquipmentAssetAll()
        {
            return GetData<JT_EquipmentAsset>(string.Empty, string.Empty);
        }

        #endregion
    }
}
