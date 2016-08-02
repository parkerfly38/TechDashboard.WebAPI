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
        #region JT_Employee

        public List<JT_Employee> GetSDataForJT_EmployeeFiltered(string filterType, string filterText)
        {
            return GetData<JT_Employee>(filterType, filterText);
        }

        public List<JT_Employee> GetSDataForJT_EmployeeAll()
        {
            return GetData<JT_Employee>(string.Empty, string.Empty);
        }

        #endregion
    }
}
