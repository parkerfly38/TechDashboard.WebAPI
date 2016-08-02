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
        #region JT_MiscellaneousCodes

        public List<JT_MiscellaneousCodes> GetSDataForJT_MiscellaneousCodesFiltered(string filterType, string filterText)
        {
            return GetData<JT_MiscellaneousCodes>(filterType, filterText);
        }

        public List<JT_MiscellaneousCodes> GetSDataForJT_MiscellaneousCodesAll()
        {
            return GetData<JT_MiscellaneousCodes>(string.Empty, string.Empty);
        }

        #endregion
    }
}
