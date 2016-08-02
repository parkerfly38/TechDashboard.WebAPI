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
        #region JT_LaborText

        public List<JT_LaborText> GetSDataForJT_LaborTextFiltered(string filterType, string filterText)
        {
            return GetData<JT_LaborText>(filterType, filterText);
        }

        public List<JT_LaborText> GetSDataForJT_LaborTextAll()
        {
            return GetData<JT_LaborText>(string.Empty, string.Empty);
        }

        #endregion
    }
}
