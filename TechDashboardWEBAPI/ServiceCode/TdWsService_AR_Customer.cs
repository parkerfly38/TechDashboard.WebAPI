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
        public List<AR_Customer> GetSDataForAR_CustomerFiltered(string filterType, string filterText)
        {
            return GetData<AR_Customer>(filterType, filterText);
        }

        public List<AR_Customer> GetSDataForAR_CustomerAll()
        {
            return GetData<AR_Customer>(string.Empty, string.Empty);
        }
    }
}
