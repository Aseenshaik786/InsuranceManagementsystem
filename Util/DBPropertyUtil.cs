using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace InsuranceManagementSystem.Util
{
    public static class DBPropertyUtil
    {
        public static string GetConnectionString(string propertyFileName)
        {
            return "Server=(localdb)\\MSSQLLocalDB;Database=InsuranceDB;Trusted_Connection=True;";
        }
    }
}
