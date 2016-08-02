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
        #region JT_TransactionImportDetail

        public List<JT_TransactionImportDetail> GetSDataForJT_TransactionImportDetailFiltered(string filterType, string filterText)
        {
            return GetData<JT_TransactionImportDetail>(filterType, filterText);
        }

        public List<JT_TransactionImportDetail> GetSDataForJT_TransactionImportDetailAll()
        {
            return GetData<JT_TransactionImportDetail>(string.Empty, string.Empty);
        }

        public bool InsertJT_TransactionImportDetail(JT_TransactionImportDetail importDetail)
        {
            return InsertRecord<JT_TransactionImportDetail>(importDetail);
        }

        #endregion
    }
}
