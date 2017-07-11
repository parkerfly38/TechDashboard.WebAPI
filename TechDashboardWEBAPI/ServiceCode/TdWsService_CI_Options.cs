using Rkl.Erp.Sage.Sage100.TableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TechDashboardWEBAPI.ServiceCode
{
    public partial class TdWsService
    {

        public List<CI_Options> GetSDataForCI_OptionsFiltered(string filterType, string filterText)
        {
            return GetData<CI_Options>(filterType, filterText);
        }

        public List<CI_Options> GetSDataForCI_OptionsAll()
        {
            return GetData<CI_Options>(string.Empty, string.Empty);
        }
    }
}