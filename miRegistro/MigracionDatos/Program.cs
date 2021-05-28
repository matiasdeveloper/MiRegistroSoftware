using System;
using System.Data;

namespace MigracionDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to migration system!");
            Console.ReadLine();

            MySqlConnect mysqlConnect = new MySqlConnect();
            SqlServerConnect sqlConnect = new SqlServerConnect();
            Console.ReadLine();

            DataTable dataTramites = GetOlderTramites(10, sqlConnect);
            sqlConnect.closeConnection();

            Console.WriteLine("Data downloaded succesful");
            Console.WriteLine("To continue migration operation please press a key");
            Console.ReadLine();
            Console.WriteLine("Rows older to migrate: " + dataTramites.Rows.Count);
            Console.ReadLine();

            int success = 0;
            int fail = 0;

            foreach (DataRow row in dataTramites.Rows)
            {
                try 
                {
                    string Dominio = (string)row["Dominio"];
                    int fkIdCategoria = (int)row["Cod_proceso"];
                    int fkIdEmpresa = (int)1;
                    DateTime fecha = ((DateTime)row["Fecha"]);
                    string observaciones = (string)row["Observaciones"];
                    int idProcesoEmpleado = (int)row["Cod_empleadoProceso"];
                    int idInscripcion = (int)row["Cod_empleadoInscripto"];
                    bool isInscripto = (bool)row["Inscripto"];

                    MigrateDataTramites(mysqlConnect, Dominio, fkIdCategoria, fkIdEmpresa, fecha, observaciones, idProcesoEmpleado, idInscripcion, isInscripto);
                    Console.WriteLine("> " + row["Dominio"].ToString());
                    success++;
                }
                catch(Exception e)
                {
                    Console.WriteLine("Excepetion in: " + (string)row["Dominio"]);
                    Console.WriteLine("Saving the exception");
                    fail++;
                }
            }

            Console.ReadLine();
            Console.WriteLine("Operation Completed Successful you migragte: " + success);
            Console.WriteLine("Operation Have errors you  don't migragte: " + fail);

            Console.WriteLine("Closing connection mysql");
            mysqlConnect.CloseConnection();
        }

        public static DataTable GetOlderTramites(int countToGet, SqlServerConnect _conn)
        {
            Microsoft.Data.SqlClient.SqlDataReader _read;
            DataTable _table = new DataTable();
            Microsoft.Data.SqlClient.SqlCommand _command = new Microsoft.Data.SqlClient.SqlCommand();

            string q = "";

            q = @"SELECT TOP (10000) * FROM Tramites";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            _read = _command.ExecuteReader();

            _table.Clear();
            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        }
        public static void MigrateDataTramites(MySqlConnect _conn, string Dominio, int fkIdCategoria, int fkIdEmpresa, DateTime fecha, string observaciones, int idProcesoEmpleado, int idInscripcion, bool isInscripto)
        {
            MySql.Data.MySqlClient.MySqlCommand _command = new MySql.Data.MySqlClient.MySqlCommand();

            string q = @"INSERT INTO tramite (Dominio, FkIdCategoria, FkIdEmpresa, Fecha, Observaciones) VALUES ('"+Dominio+"', '"+fkIdCategoria+"', '"+fkIdEmpresa+ "', STR_TO_DATE('"+fecha.Day+","+fecha.Month+","+fecha.Year+"','%d,%m,%Y'), '" + observaciones+"');";

            int idProceso = TransformToNewCodeEmployeeDB(idProcesoEmpleado);

            string q2 = @"INSERT INTO tramite_proceso
                            VALUES (LAST_INSERT_ID(), 1," +
                                " '" + idProceso + "', 1);";

            int idInscripto = TransformToNewCodeEmployeeDB(idInscripcion);

            string q3 = @"INSERT INTO tramite_proceso
                            VALUES (LAST_INSERT_ID(), 2," +
                                " '" + idInscripto + "', 1)";

            _command.Connection = _conn.OpenConnection();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _command.CommandText = q2;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            if (isInscripto) 
            {
                _command.CommandText = q3;
                _command.CommandType = CommandType.Text;
                _command.ExecuteNonQuery();
            }
        }
        private static int TransformToNewCodeEmployeeDB(int idOlder)
        {
            int i = 1;
            switch (idOlder) 
            {
                case 2:
                    i = 1;
                    break;
                case 3:
                    i = 3;
                    break;
                case 4:
                    i = 2;
                    break;
                case 5:
                    i = 6;
                    break;
                case 6:
                    i = 4;
                    break;
                case 7:
                    i = 5;
                    break;
            }

            return i;
        }
    }
}
