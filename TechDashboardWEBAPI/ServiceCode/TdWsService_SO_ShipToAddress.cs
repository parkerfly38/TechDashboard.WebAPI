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
        #region SO_ShipToAddress

        public List<SO_ShipToAddress> GetSDataForSO_ShipToAddressFiltered(string filterType, string filterText)
        {
            return GetData<SO_ShipToAddress>(filterType, filterText);
        }

        public List<SO_ShipToAddress> GetSDataForSO_ShipToAddressFilteredRest(string filterType, string filterTextEncoded)
        {
            return GetData<SO_ShipToAddress>(filterType, filterTextEncoded);
        }

        public List<SO_ShipToAddress> GetSDataForSO_ShipToAddressAll()
        {
            return GetData<SO_ShipToAddress>(string.Empty, string.Empty);
        }

        #endregion
    }
}
