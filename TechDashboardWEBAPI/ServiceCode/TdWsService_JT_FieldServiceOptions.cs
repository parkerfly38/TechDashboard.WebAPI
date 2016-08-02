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
        #region JT_FieldServiceOptions

        public List<JT_FieldServiceOptions> GetSDataForJT_FieldServiceOptionsFiltered(string filterType, string filterText)
        {
            return GetData<JT_FieldServiceOptions>(filterType, filterText);
        }

        public List<JT_FieldServiceOptions> GetSDataForJT_FieldServiceOptionsAll()
        {
            return GetData<JT_FieldServiceOptions>(string.Empty, string.Empty);
        }

        #endregion
    }
}
