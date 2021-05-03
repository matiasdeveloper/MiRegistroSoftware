using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IConnector
    {
        string connectionString { get; set; }

        string server { get; set; }
        string port { get; set; }
        string user { get; set; }
        string password { get; set; }

        MySql.Data.MySqlClient.MySqlConnection sqlConnection { get; set; }

        MySql.Data.MySqlClient.MySqlConnection OpenConnection();
        MySql.Data.MySqlClient.MySqlConnection CloseConnection();
    }
}
