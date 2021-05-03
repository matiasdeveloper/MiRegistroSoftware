using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MySqlConnect : IConnector
    {
        public string connectionString { get; set; }

        public MySql.Data.MySqlClient.MySqlConnection sqlConnection { get; set; }
        public string server { get; set; } 
        public string port { get; set; }
        public string user { get; set; }
        public string password { get; set; }

        public MySql.Data.MySqlClient.MySqlConnection OpenConnection()
        {
            try
            {
                using (sqlConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString))
                {
                    if (sqlConnection.State == ConnectionState.Closed)
                    {
                        sqlConnection.Open();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Write("Error connection DB" + ex);
            }
            return sqlConnection;
        }

        public MySql.Data.MySqlClient.MySqlConnection CloseConnection()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            return sqlConnection;
        }
    }
}
