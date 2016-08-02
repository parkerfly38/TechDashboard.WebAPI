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
        #region JT_WorkTicketHistory

        public List<JT_WorkTicketHistory> GetSDataForJT_WorkTicketHistoryFiltered(string filterType, string filterText)
        {
            return GetData<JT_WorkTicketHistory>(filterType, filterText);
        }

        public List<JT_WorkTicketHistory> GetSDataForJT_WorkTicketHistoryAll()
        {
            return GetData<JT_WorkTicketHistory>(string.Empty, string.Empty);
        }

        #endregion
    }
}
