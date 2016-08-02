using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using System.Data.SqlClient;

namespace TechDashboardWEBAPI.DataAccess
{
    public class ConnectionFactory
    {
        public static Dictionary<string, string> ConnectionStrings = new Dictionary<string, string>();

        public static DbConnection GetOpenConnection()
        {
            return new SqlConnection("Data Source=testdbv2.rkldev.local;Initial Catalog=TechDashboard;Integrated Security=False;User ID=admin;Password=");
        }
    }
}