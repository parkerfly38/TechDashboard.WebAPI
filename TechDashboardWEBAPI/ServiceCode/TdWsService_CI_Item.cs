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
        #region CI_Item

        public List<CI_Item> GetSDataForCI_ItemFiltered(string filterType, string filterText)
        {
            return GetData<CI_Item>(filterType, filterText);
        }

        public List<CI_Item> GetSDataForCI_ItemAll()
        {
            return GetData<CI_Item>(string.Empty, string.Empty);
        }

        #endregion
    }
}
