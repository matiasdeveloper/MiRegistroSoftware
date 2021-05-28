using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace MigracionDatos
{
    public class SqlServerConnect
    {
        private static string strConnection = Properties.Resources.Azure;

        private SqlConnection conn = new SqlConnection(strConnection);

        public SqlConnection openConnetion()
        {
            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    Console.WriteLine("Sql connection has succesful.");
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connection DB" + ex);
            }
            return conn;
        }

        public SqlConnection closeConnection()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return conn;
        }
    }
}
