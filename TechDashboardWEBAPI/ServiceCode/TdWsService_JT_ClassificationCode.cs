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
        #region JT_ClassificationCode

        public List<JT_ClassificationCode> GetSDataForJT_ClassificationCodeFiltered(string filterType, string filterText)
        {
            return GetData<JT_ClassificationCode>(filterType, filterText);
        }

        public List<JT_ClassificationCode> GetSDataForJT_ClassificationCodeAll()
        {
            return GetData<JT_ClassificationCode>(string.Empty, string.Empty);
        }

        #endregion
    }
}
