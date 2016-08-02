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
        #region JT_WorkTicketAttachment

        public List<JT_WorkTicketAttachment> GetSDataForJT_WorkTicketAttachmentFiltered(string filterType, string filterText)
        {
            return GetData<JT_WorkTicketAttachment>(filterType, filterText);
        }

        public List<JT_WorkTicketAttachment> GetSDataForJT_WorkTicketAttachmentAll()
        {
            return GetData<JT_WorkTicketAttachment>(string.Empty, string.Empty);
        }

        #endregion
    }
}
