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
        #region JT_WorkTicketClass

        public List<JT_WorkTicketClass> GetSDataForJT_WorkTicketClassFiltered(string filterType, string filterText)
        {
            return GetData<JT_WorkTicketClass>(filterType, filterText);
        }

        public List<JT_WorkTicketClass> GetSDataForJT_WorkTicketClassAll()
        {
            return GetData<JT_WorkTicketClass>(string.Empty, string.Empty);
        }

        #endregion
    }
}
