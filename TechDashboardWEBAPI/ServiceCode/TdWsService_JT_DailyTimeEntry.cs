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
        #region JT_DailyTimeEntry

        public List<JT_DailyTimeEntry> GetSDataForJT_DailyTimeEntryFiltered(string filterType, string filterText)
        {
            return GetData<JT_DailyTimeEntry>(filterType, filterText);
        }

        public List<JT_DailyTimeEntry> GetSDataForJT_DailyTimeEntryAll()
        {
            return GetData<JT_DailyTimeEntry>(string.Empty, string.Empty);
        }

        #endregion
    }
}
