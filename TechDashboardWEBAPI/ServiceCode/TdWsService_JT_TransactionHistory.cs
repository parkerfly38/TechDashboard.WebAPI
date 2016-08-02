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
        #region JT_TransactionHistory

        public List<JT_TransactionHistory> GetSDataForJT_TransactionHistoryFiltered(string filterType, string filterText)
        {
            return GetData<JT_TransactionHistory>(filterType, filterText);
        }

        public List<JT_TransactionHistory> GetSDataForJT_TransactionHistoryAll()
        {
            return GetData<JT_TransactionHistory>(string.Empty, string.Empty);
        }

        #endregion
    }
}
