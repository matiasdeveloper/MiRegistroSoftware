using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

public class MySqlConnect
{
    private static string connectionString = MigracionDatos.Properties.Resources.MySql;
    private MySqlConnection sqlConnection = new MySqlConnection(connectionString);

    public MySqlConnection OpenConnection()
    {
        try
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                Console.WriteLine("MySql connection has succesful.");
                sqlConnection.Open();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error connection DB" + ex);
        }
        return sqlConnection;
    }

    public MySqlConnection CloseConnection()
    {
        if (sqlConnection.State == ConnectionState.Open)
        {
            sqlConnection.Close();
        }
        return sqlConnection;
    }
}
