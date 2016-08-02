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
        #region JT_Transaction

        public List<JT_Transaction> GetSDataForJT_TransactionFiltered(string filterType, string filterText)
        {
            return GetData<JT_Transaction>(filterType, filterText);
        }

        public List<JT_Transaction> GetSDataForJT_TransactionAll()
        {
            return GetData<JT_Transaction>(string.Empty, string.Empty);
        }

        #endregion
    }
}
