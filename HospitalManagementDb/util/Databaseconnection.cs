using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace util
{
    public class Databaseconnectionstring
    {
        public static string connectionstring()
        {
            return "server = DESKTOP-8UIMAL2\\SQLEXPRESS; database = hospitalmanagementdb; Integrated Security = true; TrustServerCertificate = true";
        }

    }

    public class Databaseconnection
    {
        public static SqlConnection connectionobj()
        {
            string con = Databaseconnectionstring.connectionstring();
            return new SqlConnection(con);
        }
    }
}
