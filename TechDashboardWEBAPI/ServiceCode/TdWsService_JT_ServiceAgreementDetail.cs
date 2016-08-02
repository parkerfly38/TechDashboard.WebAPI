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
        #region JT_ServiceAgreementDetail

        public List<JT_ServiceAgreementDetail> GetSDataForJT_ServiceAgreementDetailFiltered(string filterType, string filterText)
        {
            return GetData<JT_ServiceAgreementDetail>(filterType, filterText);
        }

        public List<JT_ServiceAgreementDetail> GetSDataForJT_ServiceAgreementDetailAll()
        {
            return GetData<JT_ServiceAgreementDetail>(string.Empty, string.Empty);
        }

        #endregion
    }
}
