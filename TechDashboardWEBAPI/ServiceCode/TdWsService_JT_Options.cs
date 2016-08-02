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
        #region JT_Options

        public List<JT_Options> GetSDataForJT_OptionsFiltered(string filterType, string filterText)
        {
            return GetData<JT_Options>(filterType, filterText);
        }

        public List<JT_Options> GetSDataForJT_OptionsAll()
        {
            return GetData<JT_Options>(string.Empty, string.Empty);
        }

        #endregion
    }
}
