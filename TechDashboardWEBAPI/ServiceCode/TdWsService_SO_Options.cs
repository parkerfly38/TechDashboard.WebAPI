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
        #region SO_Options

        public List<SO_Options> GetSDataForSO_OptionsFiltered(string filterType, string filterText)
        {
            return GetData<SO_Options>(filterType, filterText);
        }

        public List<SO_Options> GetSDataForSO_OptionsAll()
        {
            return GetData<SO_Options>(string.Empty, string.Empty);
        }

        #endregion
    }
}
