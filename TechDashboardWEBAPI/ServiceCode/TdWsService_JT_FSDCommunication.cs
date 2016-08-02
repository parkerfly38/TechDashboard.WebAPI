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
        #region JT_FSDCommunication

        public List<JT_FSDCommunication> GetSDataForJT_FSDCommunicationFiltered(string filterType, string filterText)
        {
            return GetData<JT_FSDCommunication>(filterType, filterText);
        }

        public List<JT_FSDCommunication> GetSDataForJT_FSDCommunicationAll()
        {
            return GetData<JT_FSDCommunication>(string.Empty, string.Empty);
        }

        #endregion
    }
}
