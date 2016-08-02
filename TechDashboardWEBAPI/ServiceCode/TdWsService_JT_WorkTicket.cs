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
        #region JT_WorkTicket

        public List<JT_WorkTicket> GetSDataForJT_WorkTicketFiltered(string filterType, string filterText)
        {
            return GetData<JT_WorkTicket>(filterType, filterText);
        }

        public List<JT_WorkTicket> GetSDataForJT_WorkTicketAll()
        {
            return GetData<JT_WorkTicket>(string.Empty, string.Empty);
        }

        #endregion
    }
}
