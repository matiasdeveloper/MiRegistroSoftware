using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerPresentation.Models
{
    public class MySqlConnect : IConnector
    {
        public string connectionString { get; set; }
        public SqlConnection sqlConnection { get; set; }

        public SqlConnection OpenConnection()
        {
            try
            {
                using (sqlConnection = new SqlConnection(connectionString))
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

        public SqlConnection CloseConnection()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
            return sqlConnection;
        }
    }
}
