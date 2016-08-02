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
        #region JT_ActivityCode

        public List<JT_ActivityCode> GetSDataForJT_ActivityCodeFiltered(string filterType, string filterText)
        {
            return GetData<JT_ActivityCode>(filterType, filterText);
        }

        public List<JT_ActivityCode> GetSDataForJT_ActivityCodeAll()
        {
            return GetData<JT_ActivityCode>(string.Empty, string.Empty);
        }

        #endregion
    }
}
