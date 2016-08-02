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
        #region JT_TechnicianStatus

        public List<JT_TechnicianStatus> GetSDataForJT_TechnicianStatusFiltered(string filterType, string filterText)
        {
            return GetData<JT_TechnicianStatus>(filterType, filterText);
        }

        public List<JT_TechnicianStatus> GetSDataForJT_TechnicianStatusAll()
        {
            return GetData<JT_TechnicianStatus>(string.Empty, string.Empty);
        }

        #endregion
    }
}
