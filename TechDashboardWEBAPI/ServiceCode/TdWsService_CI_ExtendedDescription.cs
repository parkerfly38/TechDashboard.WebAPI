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
        // dch rkl 01/13/2017 Added New Table

        #region TdWsService_CI_ExtendedDescription

        public List<CI_ExtendedDescription> GetSDataForCI_ExtendedDescriptionFiltered(string filterType, string filterText)
        {
            return GetData<CI_ExtendedDescription>(filterType, filterText);
        }

        public List<CI_ExtendedDescription> GetSDataForCI_ExtendedDescriptionAll()
        {
            return GetData<CI_ExtendedDescription>(string.Empty, string.Empty);
        }

        #endregion
    }
}
