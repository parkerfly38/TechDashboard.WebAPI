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
        #region JT_ServiceAgreementPMDetail

        public List<JT_ServiceAgreementPMDetail> GetSDataForJT_ServiceAgreementPMDetailFiltered(string filterType, string filterText)
        {
            return GetData<JT_ServiceAgreementPMDetail>(filterType, filterText);
        }

        public List<JT_ServiceAgreementPMDetail> GetSDataForJT_ServiceAgreementPMDetailAll()
        {
            return GetData<JT_ServiceAgreementPMDetail>(string.Empty, string.Empty);
        }

        #endregion
    }
}
