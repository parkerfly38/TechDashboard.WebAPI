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
        #region JT_EarningsCode

        public List<JT_EarningsCode> GetSDataForJT_EarningsCodeFiltered(string filterType, string filterText)
        {
            return GetData<JT_EarningsCode>(filterType, filterText);
        }

        public List<JT_EarningsCode> GetSDataForJT_EarningsCodeAll()
        {
            return GetData<JT_EarningsCode>(string.Empty, string.Empty);
        }

        #endregion
    }
}
