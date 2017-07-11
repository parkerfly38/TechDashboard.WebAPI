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
        #region JT_TimeTrackerOptions

        /// <summary>
        /// GetSDataForJT_TimeTrackerOptionsFiltered
        /// Returns data from JT_TimeTrackerOptions table via SDATA, using a filter on the data
        /// </summary>
        /// <param name="filterType"></param>
        /// <param name="filterText"></param>
        /// <returns></returns>
        public List<JT_TimeTrackerOptions> GetSDataForJT_TimeTrackerOptionsFiltered(string filterType, string filterText)
        {
            return GetData<JT_TimeTrackerOptions>(filterType, filterText);
        }

        /// <summary>
        /// GetSDataForJT_TimeTrackerOptionsAll
        /// Returns data from JT_TimeTrackerOptions table via SDATA, returning all data
        /// </summary>
        /// <returns></returns>
        public List<JT_TimeTrackerOptions> GetSDataForJT_TimeTrackerOptionsAll()
        {
            return GetData<JT_TimeTrackerOptions>(string.Empty, string.Empty);
        }

        #endregion
    }
}
