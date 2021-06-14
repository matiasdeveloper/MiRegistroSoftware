using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Models
{
    public class MySqlConnect
    {
        public string connectionString { get; set; }
        public MySqlConnection MySqlConnection { get; set; }

        public MySqlConnection OpenConnection()
        {
            try
            {
                using (MySqlConnection = new MySqlConnection(connectionString))
                {
                    if (MySqlConnection.State == ConnectionState.Closed)
                    {
                        MySqlConnection.Open();
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Write("Error connection DB" + ex);
            }
            return MySqlConnection;
        }

        public MySqlConnection CloseConnection()
        {
            if (MySqlConnection.State == ConnectionState.Open)
            {
                MySqlConnection.Close();
            }
            return MySqlConnection;
        }
    }
}
