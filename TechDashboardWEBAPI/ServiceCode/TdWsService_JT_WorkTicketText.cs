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
        #region JT_WorkTicketText

        public List<JT_WorkTicketText> GetSDataForJT_WorkTicketTextFiltered(string filterType, string filterText)
        {
            return GetData<JT_WorkTicketText>(filterType, filterText);
        }

        public List<JT_WorkTicketText> GetSDataForJT_WorkTicketTextAll()
        {
            return GetData<JT_WorkTicketText>(string.Empty, string.Empty);
        }

        #endregion
    }
}
