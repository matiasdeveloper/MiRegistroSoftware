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
    class Db_Connection
    {
        private static string strConnection = Properties.Settings.Default.connectionStrings;

        private SqlConnection conn = new SqlConnection(strConnection);

        public SqlConnection openConnetion()
        {
            try 
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch(Exception ex) 
            {
                Debug.Write("Error connection DB" + ex);
            }
            return conn;
        }

        public SqlConnection closeConnection() 
        {
            if(conn.State == ConnectionState.Open) 
            {
                conn.Close();
            }
            return conn;
        }
    }
}
