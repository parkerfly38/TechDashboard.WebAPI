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
        #region JT_TechnicianScheduleDetail

        public List<JT_TechnicianScheduleDetail> GetSDataForJT_TechnicianScheduleDetailFiltered(string filterType, string filterText)
        {
            return GetData<JT_TechnicianScheduleDetail>(filterType, filterText);
        }

        public List<JT_TechnicianScheduleDetail> GetSDataForJT_TechnicianScheduleDetailAll()
        {
            return GetData<JT_TechnicianScheduleDetail>(string.Empty, string.Empty);
        }

        #endregion
    }
}
