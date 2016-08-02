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
        #region JT_TemplateParts

        public List<JT_TemplateParts> GetSDataForJT_TemplatePartsFiltered(string filterType, string filterText)
        {
            return GetData<JT_TemplateParts>(filterType, filterText);
        }

        public List<JT_TemplateParts> GetSDataForJT_TemplatePartsAll()
        {
            return GetData<JT_TemplateParts>(string.Empty, string.Empty);
        }

        #endregion
    }
}
