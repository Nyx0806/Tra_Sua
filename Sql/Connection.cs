using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Tra_Sua
{
    class Connection
    {
        public static string stringConnection = @"Data Source=RAPHAEL\RAPHAELSERVER;Initial Catalog=Quanlitrasua;Persist Security Info=True;User ID=sa;Password=***********;Trust Server Certificate=True";
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}
