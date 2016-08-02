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
        #region JT_CustomerBillingRates

        public List<JT_CustomerBillingRates> GetSDataForJT_CustomerBillingRatesFiltered(string filterType, string filterText)
        {
            return GetData<JT_CustomerBillingRates>(filterType, filterText);
        }

        public List<JT_CustomerBillingRates> GetSDataForJT_CustomerBillingRatesAll()
        {
            return GetData<JT_CustomerBillingRates>(string.Empty, string.Empty);
        }

        #endregion
    }
}
