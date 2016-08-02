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
        #region JT_Technician

        public List<JT_Technician> GetSDataForJT_TechnicianAll()
        {
            return GetData<JT_Technician>(string.Empty, string.Empty);
        }

        public List<JT_Technician> GetSDataForJT_TechnicianFiltered(string filterType, string filterText)
        {
            return GetData<JT_Technician>(filterType, filterText);
        }

        public bool UpdateJT_Technician(JT_Technician technician)
        {
            return UpdateTechnicianRecord(technician);
        }

        #endregion
    }
}
