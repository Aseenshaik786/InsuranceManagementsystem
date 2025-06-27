using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace InsuranceManagementSystem.Util
{
    public static class DBConnUtil
    {
        public static SqlConnection GetConnection(string propertyFileName)
        {
            string connStr = DBPropertyUtil.GetConnectionString(propertyFileName);
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            return conn;
        }
    }
}
