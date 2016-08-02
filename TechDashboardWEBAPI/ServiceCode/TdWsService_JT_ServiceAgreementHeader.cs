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
        #region JT_ServiceAgreementHeader

        public List<JT_ServiceAgreementHeader> GetSDataForJT_ServiceAgreementHeaderFiltered(string filterType, string filterText)
        {
            return GetData<JT_ServiceAgreementHeader>(filterType, filterText);
        }

        public List<JT_ServiceAgreementHeader> GetSDataForJT_ServiceAgreementHeaderAll()
        {
            return GetData<JT_ServiceAgreementHeader>(string.Empty, string.Empty);
        }

        #endregion
    }
}
