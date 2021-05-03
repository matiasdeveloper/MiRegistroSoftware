using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace LayerData
{
    class MySqlConnectOlder
    {
        private static string connectionString = Properties.Settings.Default.connAzure;
        private SqlConnection sqlConnection = new SqlConnection(connectionString);

        public SqlConnection OpenConnection()
        {
            try 
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    sqlConnection.Open();
                }
            }
            catch(Exception ex) 
            {
                Debug.Write("Error connection DB" + ex);
            }
            return sqlConnection;
        }

        public SqlConnection CloseConnection() 
        {
            if(sqlConnection.State == ConnectionState.Open) 
            {
                sqlConnection.Close();
            }
            return sqlConnection;
        }
    }
}
