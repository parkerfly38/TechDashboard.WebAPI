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
        // dch rkl 01/20/2017 Added AR_Options Table

        #region TdWsService_AR_Options

        public List<AR_Options> GetSDataForAR_OptionsFiltered(string filterType, string filterText)
        {
            return GetData<AR_Options>(filterType, filterText);
        }

        public List<AR_Options> GetSDataForAR_OptionsAll()
        {
            return GetData<AR_Options>(string.Empty, string.Empty);
        }

        #endregion
    }
}
