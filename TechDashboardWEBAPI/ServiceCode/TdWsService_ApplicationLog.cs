using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechDashboardWEBAPI.Models;
using TechDashboardWEBAPI.DataAccess;

namespace TechDashboardWEBAPI.ServiceCode
{
    public partial class TdWsService
    {
        public void InsertError(ApplicationLog appLog)
        {
            DBMapper dataMapper = new DBMapper();
            dataMapper.InsertError(appLog);
        }
    }
}
