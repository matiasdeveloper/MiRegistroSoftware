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
    class MySqlConnect
    {
        private static string connectionString = Properties.Settings.Default.connectionStrings;
        private SqlConnection sqlConnection = new SqlConnection(connectionString);

        public SqlConnection OpenConnection()
        {
            try 
            {
                if (sqlConnection.State == ConnectionState.Closed)
                {
                    Console.WriteLine("MySql connection has succesful.");
                    sqlConnection.Open();
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine("Error connection DB" + ex);
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
