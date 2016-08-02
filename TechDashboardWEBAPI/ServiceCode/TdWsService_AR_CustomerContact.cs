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
        public List<AR_CustomerContact> GetSDataForAR_CustomerContactFiltered(string filterType, string filterText)
        {
            return GetData<AR_CustomerContact>(filterType, filterText);
        }

        public List<AR_CustomerContact> GetSDataForAR_CustomerContactAll()
        {
            return GetData<AR_CustomerContact>(string.Empty, string.Empty);
        }
    }
}
