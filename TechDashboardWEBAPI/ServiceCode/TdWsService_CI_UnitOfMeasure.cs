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
        // dch rkl 01/20/2017 Added CI_UnitOfMeasure Table

        #region TdWsService_CI_UnitOfMeasure

        public List<CI_UnitOfMeasure> GetSDataForCI_UnitOfMeasureFiltered(string filterType, string filterText)
        {
            return GetData<CI_UnitOfMeasure>(filterType, filterText);
        }

        public List<CI_UnitOfMeasure> GetSDataForCI_UnitOfMeasureAll()
        {
            return GetData<CI_UnitOfMeasure>(string.Empty, string.Empty);
        }

        #endregion
    }
}
