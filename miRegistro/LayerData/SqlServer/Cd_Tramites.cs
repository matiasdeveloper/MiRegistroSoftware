using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerData.SqlServer
{
    public class Cd_Tramites
    {

        private Db_Connection _conn = new Db_Connection();

        SqlDataReader _read;
        DataTable _table = new DataTable();
        SqlCommand _command = new SqlCommand();

        // Create, Update, Insert, Delete
        #region Crud
        public void Insert(string dominio, DateTime fecha, int cod_proceso, int cod_empleadoProceso, string observaciones, int error, int cod_error)
        {
            string q = @"INSERT INTO [dbo].[Tramites]
                       ([Dominio]
                       ,[Fecha]
                       ,[Cod_proceso]
                       ,[Cod_empleadoProceso]
                       ,[Cod_etapa]
                       ,[Observaciones]
                       ,[Error]
                       ,[Cod_error]
                       ,[Inscripto]
                       ,[Cod_empleadoInscripto])
	                   VALUES('" + dominio + "', CONVERT(VARCHAR, '" + fecha.ToString("MM/dd/yyyy") + "', 100) ," + cod_proceso + "," + cod_empleadoProceso + ", '1', '" + observaciones + "'," + error + ", " + cod_error + ", '0', '1')";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _conn.closeConnection();
        }
        public void Update(int id, string dominio, int cod_proceso, int cod_empleadoProceso, string observaciones, int error, int cod_error)
        {
            string q = @"UPDATE Tramites 
                        SET Dominio = '" + dominio + "', Cod_proceso = " + cod_proceso + "" +
                        ", Cod_empleadoProceso = " + cod_empleadoProceso + ", Cod_etapa = '1', Observaciones = '" + observaciones + "'" +
                        ", Error = " + error + ", Cod_error = " + cod_error + "" +
                        "WHERE Id = " + id + ";";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _conn.closeConnection();
        }
        public void ErrorUpdate(int id, string observaciones, int error, int cod_error)
        {
            string q = @"UPDATE Tramites 
                        SET Observaciones = '" + observaciones + "', Error = " + error + ", Cod_error = " + cod_error + " " +
                        "WHERE Id = " + id + " ";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _conn.closeConnection();
        }
        public void InscribirTramite(int id, int cod_inscripto, int cod_empleado)
        {
            string q = @"UPDATE Tramites 
                        SET Inscripto = '" + cod_inscripto + "', Cod_empleadoInscripto = " + cod_empleado + "" +
                        "WHERE Id = " + id + " ";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _conn.closeConnection();
        }
        public void Delete(int id)
        {
            string q = "DELETE FROM Tramites WHERE Id = " + id + ";";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _conn.closeConnection();
        }
        #endregion
        
        #region Show
        // Visualize data
        public DataTable mostrarTodo()
        {
            string q = "";

            q = @"SELECT Id as Id, Dominio as Dominio, Empleados.Nombre as Empleado, 
                Tipo_Tramites.Nombre as Tramite, 
                Tipo_Etapa.Nombre as Etapa, 
                Fecha as Fecha,
                Error as Error, 
                Errores.Nombre AS 'Tipo Error', 
                Tramites.Observaciones as Observaciones, 
                Inscripto as Inscripto,
                Empleados1.Nombre as 'Nombre Inscripto'
                FROM((Tipo_Tramites RIGHT OUTER JOIN(Tipo_Etapa RIGHT OUTER JOIN(Errores RIGHT OUTER JOIN(Empleados RIGHT OUTER JOIN Tramites 
                ON Empleados.Cod_empleado = Tramites.Cod_empleadoProceso) 
                ON Errores.Cod_error = Tramites.Cod_Error)
                ON Tipo_Etapa.Cod_Etapa = Tramites.Cod_etapa) 
                ON Tipo_Tramites.Cod_tramite = Tramites.Cod_proceso)INNER JOIN Empleados Empleados1 
                ON Tramites.Cod_empleadoInscripto = Empleados1.Cod_empleado)
                ORDER BY Fecha DESC";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            _read = _command.ExecuteReader();

            _table.Clear();
            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        }
        public DataTable mostrarEmpleados()
        {
            string q = "";

            q = @"SELECT Cod_empleado as Cod, Nombre FROM Empleados";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            _read = _command.ExecuteReader();

            _table.Clear();
            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        }
        public DataTable mostrarTramites()
        {
            string q = "";

            q = @"SELECT Cod_tramite as Cod, Nombre FROM Tipo_Tramites";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            _read = _command.ExecuteReader();

            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        }
        public DataTable mostrarErrores()
        {
            string q = "";

            q = @"SELECT Cod_error as Cod, Nombre FROM Errores";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            _read = _command.ExecuteReader();

            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        }       
        public DataTable mostrarByDominio(string dominio) 
        {
            string q = "";

            q = @"SELECT Id as Id, Dominio as Dominio, Empleados.Nombre as Empleado, 
                Tipo_Tramites.Nombre as Tramite, 
                Tipo_Etapa.Nombre as Etapa, 
                Fecha as Fecha,
                Error as Error, 
                Errores.Nombre AS 'Tipo Error', 
                Tramites.Observaciones as Observaciones, 
                Inscripto as Inscripto
                FROM((Tipo_Tramites RIGHT OUTER JOIN(Tipo_Etapa RIGHT OUTER JOIN(Errores RIGHT OUTER JOIN(Empleados RIGHT OUTER JOIN Tramites 
                ON Empleados.Cod_empleado = Tramites.Cod_empleadoProceso) 
                ON Errores.Cod_error = Tramites.Cod_Error)
                ON Tipo_Etapa.Cod_Etapa = Tramites.Cod_etapa) 
                ON Tipo_Tramites.Cod_tramite = Tramites.Cod_proceso)INNER JOIN Empleados Empleados1 
                ON Tramites.Cod_empleadoProceso = Empleados1.Cod_empleado)
                WHERE Dominio = '" + dominio + "' ORDER BY Fecha DESC"; 

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            _read = _command.ExecuteReader();

            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        }
        public DataTable mostrarByEmployee(int employee)
        {
            string q = "";

            q = @"SELECT Id as Id, Dominio as Dominio, Empleados.Nombre as Empleado, 
                Tipo_Tramites.Nombre as Tramite, 
                Tipo_Etapa.Nombre as Etapa, 
                Fecha as Fecha,
                Error as Error, 
                Errores.Nombre AS 'Tipo Error', 
                Tramites.Observaciones as Observaciones, 
                Inscripto as Inscripto,
                Empleados1.Nombre as 'Nombre Inscripto'
                FROM((Tipo_Tramites RIGHT OUTER JOIN(Tipo_Etapa RIGHT OUTER JOIN(Errores RIGHT OUTER JOIN(Empleados RIGHT OUTER JOIN Tramites 
                ON Empleados.Cod_empleado = Tramites.Cod_empleadoProceso) 
                ON Errores.Cod_error = Tramites.Cod_Error)
                ON Tipo_Etapa.Cod_Etapa = Tramites.Cod_etapa) 
                ON Tipo_Tramites.Cod_tramite = Tramites.Cod_proceso)INNER JOIN Empleados Empleados1 
                ON Tramites.Cod_empleadoInscripto = Empleados1.Cod_empleado)
                WHERE Empleados.Cod_empleado = '" + employee +"' OR Empleados1.Cod_empleado = '"+ employee +"' ORDER BY Fecha DESC";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            _read = _command.ExecuteReader();

            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        }
        public DataTable mostrarByFecha(DateTime fecha)
        {
            DateTime dt = new DateTime(fecha.Year, fecha.Month, fecha.Day,0 , 0, 0);
            DateTime dtaux = new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0);
            dtaux = dtaux.AddDays(1);

            string q = "";

            q = @"SELECT Id as Id, Dominio as Dominio, Empleados.Nombre as Empleado, 
                Tipo_Tramites.Nombre as Tramite, 
                Tipo_Etapa.Nombre as Etapa, 
                Fecha as Fecha,
                Error as Error, 
                Errores.Nombre AS 'Tipo Error', 
                Tramites.Observaciones as Observaciones, 
                Inscripto as Inscripto
                FROM((Tipo_Tramites RIGHT OUTER JOIN(Tipo_Etapa RIGHT OUTER JOIN(Errores RIGHT OUTER JOIN(Empleados RIGHT OUTER JOIN Tramites 
                ON Empleados.Cod_empleado = Tramites.Cod_empleadoProceso) 
                ON Errores.Cod_error = Tramites.Cod_Error)
                ON Tipo_Etapa.Cod_Etapa = Tramites.Cod_etapa) 
                ON Tipo_Tramites.Cod_tramite = Tramites.Cod_proceso)INNER JOIN Empleados Empleados1 
                ON Tramites.Cod_empleadoProceso = Empleados1.Cod_empleado)
                WHERE Fecha >= CONVERT(VARCHAR, '" + dt.ToString("MM/dd/yyyy") + "' , 100) AND Fecha < CONVERT(VARCHAR, '" + dtaux.ToString("MM/dd/yyyy") + "', 100) ORDER BY Fecha DESC";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            _read = _command.ExecuteReader();

            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        }
        public DataTable mostrarByRangeOfFecha(DateTime fecha1, DateTime fecha2)
        {
            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            string q = "";

            q = @"SELECT Id as Id, Dominio as Dominio, Empleados.Nombre as Empleado, 
                Tipo_Tramites.Nombre as Tramite, 
                Tipo_Etapa.Nombre as Etapa, 
                Fecha as Fecha,
                Error as Error, 
                Errores.Nombre AS 'Tipo Error', 
                Tramites.Observaciones as Observaciones, 
                Inscripto as Inscripto
                FROM((Tipo_Tramites RIGHT OUTER JOIN(Tipo_Etapa RIGHT OUTER JOIN(Errores RIGHT OUTER JOIN(Empleados RIGHT OUTER JOIN Tramites 
                ON Empleados.Cod_empleado = Tramites.Cod_empleadoProceso) 
                ON Errores.Cod_error = Tramites.Cod_Error)
                ON Tipo_Etapa.Cod_Etapa = Tramites.Cod_etapa) 
                ON Tipo_Tramites.Cod_tramite = Tramites.Cod_proceso)INNER JOIN Empleados Empleados1 
                ON Tramites.Cod_empleadoProceso = Empleados1.Cod_empleado)
                WHERE Fecha >= CONVERT(VARCHAR, '" + dt1.ToString("MM/dd/yyyy") + "' , 100) AND Fecha < CONVERT(VARCHAR, '" + dt2.ToString("MM/dd/yyyy") + "', 100) ORDER BY Fecha DESC";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            _read = _command.ExecuteReader();

            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        }
        public DataTable mostrarByFechaAndEmployee(DateTime fecha, int employee)
        {
            DateTime dt = new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0);
            DateTime dtaux = new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0);
            dtaux = dtaux.AddDays(1);

            string q = "";

            q = @"SELECT Id as Id, Dominio as Dominio, Empleados.Nombre as Empleado, 
                Tipo_Tramites.Nombre as Tramite, 
                Tipo_Etapa.Nombre as Etapa, 
                Fecha as Fecha,
                Error as Error, 
                Errores.Nombre AS 'Tipo Error', 
                Tramites.Observaciones as Observaciones, 
                Inscripto as Inscripto
                FROM((Tipo_Tramites RIGHT OUTER JOIN(Tipo_Etapa RIGHT OUTER JOIN(Errores RIGHT OUTER JOIN(Empleados RIGHT OUTER JOIN Tramites 
                ON Empleados.Cod_empleado = Tramites.Cod_empleadoProceso) 
                ON Errores.Cod_error = Tramites.Cod_Error)
                ON Tipo_Etapa.Cod_Etapa = Tramites.Cod_etapa) 
                ON Tipo_Tramites.Cod_tramite = Tramites.Cod_proceso)INNER JOIN Empleados Empleados1 
                ON Tramites.Cod_empleadoProceso = Empleados1.Cod_empleado)
                WHERE Fecha >= CONVERT(VARCHAR, '" + dt.ToString("MM/dd/yyyy") + "' , 100) AND Fecha < CONVERT(VARCHAR, '" + dtaux.ToString("MM/dd/yyyy") + "', 100) AND Empleados.Cod_empleado = '" + employee + "' ORDER BY Fecha DESC";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            _read = _command.ExecuteReader();

            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        }
        public DataTable mostrarByRangeOfFechaAndEmployee(DateTime fecha1, DateTime fecha2, int employee)
        {
            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            string q = "";

            q = @"SELECT Id as Id, Dominio as Dominio, Empleados.Nombre as Empleado, 
                Tipo_Tramites.Nombre as Tramite, 
                Tipo_Etapa.Nombre as Etapa, 
                Fecha as Fecha,
                Error as Error, 
                Errores.Nombre AS 'Tipo Error', 
                Tramites.Observaciones as Observaciones, 
                Inscripto as Inscripto
                FROM((Tipo_Tramites RIGHT OUTER JOIN(Tipo_Etapa RIGHT OUTER JOIN(Errores RIGHT OUTER JOIN(Empleados RIGHT OUTER JOIN Tramites 
                ON Empleados.Cod_empleado = Tramites.Cod_empleadoProceso) 
                ON Errores.Cod_error = Tramites.Cod_Error)
                ON Tipo_Etapa.Cod_Etapa = Tramites.Cod_etapa) 
                ON Tipo_Tramites.Cod_tramite = Tramites.Cod_proceso)INNER JOIN Empleados Empleados1 
                ON Tramites.Cod_empleadoProceso = Empleados1.Cod_empleado)
                WHERE Fecha >= CONVERT(VARCHAR, '" + dt1.ToString("MM/dd/yyyy") + "' , 100) AND Fecha < CONVERT(VARCHAR, '" + dt2.ToString("MM/dd/yyyy") + "', 100) AND Empleados.Cod_empleado = '" + employee + "' ORDER BY Fecha DESC";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            _read = _command.ExecuteReader();

            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        }
        public DataTable mostrarByFechaAndProcesado(DateTime fecha, int procesado)
        {
            DateTime dt = new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0);
            DateTime dtaux = new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0);
            dtaux = dtaux.AddDays(1);

            string q = "";

            q = @"SELECT Id as Id, Dominio as Dominio, Empleados.Nombre as Empleado, 
                Tipo_Tramites.Nombre as Tramite, 
                Tipo_Etapa.Nombre as Etapa, 
                Fecha as Fecha,
                Error as Error, 
                Errores.Nombre AS 'Tipo Error', 
                Tramites.Observaciones as Observaciones, 
                Inscripto as Inscripto
                FROM((Tipo_Tramites RIGHT OUTER JOIN(Tipo_Etapa RIGHT OUTER JOIN(Errores RIGHT OUTER JOIN(Empleados RIGHT OUTER JOIN Tramites 
                ON Empleados.Cod_empleado = Tramites.Cod_empleadoProceso) 
                ON Errores.Cod_error = Tramites.Cod_Error)
                ON Tipo_Etapa.Cod_Etapa = Tramites.Cod_etapa) 
                ON Tipo_Tramites.Cod_tramite = Tramites.Cod_proceso)INNER JOIN Empleados Empleados1 
                ON Tramites.Cod_empleadoProceso = Empleados1.Cod_empleado)
                WHERE Tramites.Cod_etapa = " + procesado + " AND Fecha >= CONVERT(VARCHAR, '" + dt.ToString("MM/dd/yyyy") + "', 100) AND Fecha < CONVERT(VARCHAR, '" + dtaux.ToString("MM/dd/yyyy") + "', 100) ORDER BY Fecha DESC";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            _read = _command.ExecuteReader();

            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        }
        public DataTable mostrarByRangeOfFechaAndProcesado(DateTime fecha1, DateTime fecha2, int procesado)
        {
            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            string q = "";

            q = @"SELECT Id as Id, Dominio as Dominio, Empleados.Nombre as Empleado, 
                Tipo_Tramites.Nombre as Tramite, 
                Tipo_Etapa.Nombre as Etapa, 
                Fecha as Fecha,
                Error as Error, 
                Errores.Nombre AS 'Tipo Error', 
                Tramites.Observaciones as Observaciones, 
                Inscripto as Inscripto
                FROM((Tipo_Tramites RIGHT OUTER JOIN(Tipo_Etapa RIGHT OUTER JOIN(Errores RIGHT OUTER JOIN(Empleados RIGHT OUTER JOIN Tramites 
                ON Empleados.Cod_empleado = Tramites.Cod_empleadoProceso) 
                ON Errores.Cod_error = Tramites.Cod_Error)
                ON Tipo_Etapa.Cod_Etapa = Tramites.Cod_etapa) 
                ON Tipo_Tramites.Cod_tramite = Tramites.Cod_proceso)INNER JOIN Empleados Empleados1 
                ON Tramites.Cod_empleadoProceso = Empleados1.Cod_empleado)
                WHERE Tramites.Cod_etapa = " + procesado + " AND Fecha >= CONVERT(VARCHAR, '" + dt1.ToString("MM/dd/yyyy") + "' , 100) AND Fecha < CONVERT(VARCHAR, '" + dt2.ToString("MM/dd/yyyy") + "', 100) ORDER BY Fecha DESC";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            _read = _command.ExecuteReader();

            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        }
        public DataTable mostrarByFechaAndInscripto(DateTime fecha, int inscripto)
        {
            DateTime dt = new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0);
            DateTime dtaux = new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0);
            dtaux = dtaux.AddDays(1);

            string q = "";

            q = @"SELECT Id as Id, Dominio as Dominio, Empleados.Nombre as Empleado, 
                Tipo_Tramites.Nombre as Tramite, 
                Tipo_Etapa.Nombre as Etapa, 
                Fecha as Fecha,
                Error as Error, 
                Errores.Nombre AS 'Tipo Error', 
                Tramites.Observaciones as Observaciones, 
                Inscripto as Inscripto
                FROM((Tipo_Tramites RIGHT OUTER JOIN(Tipo_Etapa RIGHT OUTER JOIN(Errores RIGHT OUTER JOIN(Empleados RIGHT OUTER JOIN Tramites 
                ON Empleados.Cod_empleado = Tramites.Cod_empleadoProceso) 
                ON Errores.Cod_error = Tramites.Cod_Error)
                ON Tipo_Etapa.Cod_Etapa = Tramites.Cod_etapa) 
                ON Tipo_Tramites.Cod_tramite = Tramites.Cod_proceso)INNER JOIN Empleados Empleados1 
                ON Tramites.Cod_empleadoProceso = Empleados1.Cod_empleado)
                WHERE Tramites.Inscripto = " + inscripto + " AND Fecha >= CONVERT(VARCHAR, '" + dt.ToString("MM/dd/yyyy") + "', 100) AND Fecha < CONVERT(VARCHAR, '" + dtaux.ToString("MM/dd/yyyy") + "', 100) ORDER BY Fecha DESC";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            _read = _command.ExecuteReader();

            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        }
        public DataTable mostrarByRangeOfFechaAndInscripto(DateTime fecha1, DateTime fecha2, int inscripto)
        {
            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            string q = "";

            q = @"SELECT Id as Id, Dominio as Dominio, Empleados.Nombre as Empleado, 
                Tipo_Tramites.Nombre as Tramite, 
                Tipo_Etapa.Nombre as Etapa, 
                Fecha as Fecha,
                Error as Error, 
                Errores.Nombre AS 'Tipo Error', 
                Tramites.Observaciones as Observaciones, 
                Inscripto as Inscripto
                FROM((Tipo_Tramites RIGHT OUTER JOIN(Tipo_Etapa RIGHT OUTER JOIN(Errores RIGHT OUTER JOIN(Empleados RIGHT OUTER JOIN Tramites 
                ON Empleados.Cod_empleado = Tramites.Cod_empleadoProceso) 
                ON Errores.Cod_error = Tramites.Cod_Error)
                ON Tipo_Etapa.Cod_Etapa = Tramites.Cod_etapa) 
                ON Tipo_Tramites.Cod_tramite = Tramites.Cod_proceso)INNER JOIN Empleados Empleados1 
                ON Tramites.Cod_empleadoProceso = Empleados1.Cod_empleado)
                WHERE Tramites.Inscripto = " + inscripto + " AND Fecha >= CONVERT(VARCHAR, '" + dt1.ToString("MM/dd/yyyy") + "' , 100) AND Fecha < CONVERT(VARCHAR, '" + dt2.ToString("MM/dd/yyyy") + "', 100) ORDER BY Fecha DESC";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            _read = _command.ExecuteReader();

            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        }
        public DataTable mostrarByFechaAndError(DateTime fecha, int isError)
        {
            DateTime dt = new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0);
            DateTime dtaux = new DateTime(fecha.Year, fecha.Month, fecha.Day, 0, 0, 0);
            dtaux = dtaux.AddDays(1);

            string q = "";

            q = @"SELECT Id as Id, Dominio as Dominio, Empleados.Nombre as Empleado, 
                Tipo_Tramites.Nombre as Tramite, 
                Tipo_Etapa.Nombre as Etapa, 
                Fecha as Fecha,
                Error as Error, 
                Errores.Nombre AS 'Tipo Error', 
                Tramites.Observaciones as Observaciones, 
                Inscripto as Inscripto
                FROM((Tipo_Tramites RIGHT OUTER JOIN(Tipo_Etapa RIGHT OUTER JOIN(Errores RIGHT OUTER JOIN(Empleados RIGHT OUTER JOIN Tramites 
                ON Empleados.Cod_empleado = Tramites.Cod_empleadoProceso) 
                ON Errores.Cod_error = Tramites.Cod_Error)
                ON Tipo_Etapa.Cod_Etapa = Tramites.Cod_etapa) 
                ON Tipo_Tramites.Cod_tramite = Tramites.Cod_proceso)INNER JOIN Empleados Empleados1 
                ON Tramites.Cod_empleadoProceso = Empleados1.Cod_empleado)
                WHERE Tramites.Error = " + isError + " AND Fecha >= CONVERT(VARCHAR, '" + dt.ToString("MM/dd/yyyy") + "', 100) AND Fecha < CONVERT(VARCHAR, '" + dtaux.ToString("MM/dd/yyyy") + "', 100) ORDER BY Fecha DESC";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            _read = _command.ExecuteReader();

            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        }
        public DataTable mostrarByRangeOfFechaAndError(DateTime fecha1, DateTime fecha2, int isError)
        {
            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            string q = "";

            q = @"SELECT Id as Id, Dominio as Dominio, Empleados.Nombre as Empleado, 
                Tipo_Tramites.Nombre as Tramite, 
                Tipo_Etapa.Nombre as Etapa, 
                Fecha as Fecha,
                Error as Error, 
                Errores.Nombre AS 'Tipo Error', 
                Tramites.Observaciones as Observaciones, 
                Inscripto as Inscripto
                FROM((Tipo_Tramites RIGHT OUTER JOIN(Tipo_Etapa RIGHT OUTER JOIN(Errores RIGHT OUTER JOIN(Empleados RIGHT OUTER JOIN Tramites 
                ON Empleados.Cod_empleado = Tramites.Cod_empleadoProceso) 
                ON Errores.Cod_error = Tramites.Cod_Error)
                ON Tipo_Etapa.Cod_Etapa = Tramites.Cod_etapa) 
                ON Tipo_Tramites.Cod_tramite = Tramites.Cod_proceso)INNER JOIN Empleados Empleados1 
                ON Tramites.Cod_empleadoProceso = Empleados1.Cod_empleado)
                WHERE Tramites.Error = " + isError + " AND Fecha >= CONVERT(VARCHAR, '" + dt1.ToString("MM/dd/yyyy") + "' , 100) AND Fecha < CONVERT(VARCHAR, '" + dt2.ToString("MM/dd/yyyy") + "', 100) ORDER BY Fecha DESC";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            _read = _command.ExecuteReader();

            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        }
        public DataTable GetTramitesID(int id)
        {
            string q = "";

            q = @"SELECT Id as Id, Dominio as Dominio, Empleados.Nombre as Empleado, 
                Tipo_Tramites.Nombre as Tramite, 
                Tipo_Etapa.Nombre as Etapa, 
                Fecha as Fecha,
                Error as Error, 
                Errores.Nombre AS 'Tipo Error', 
                Tramites.Observaciones as Observaciones, 
                Inscripto as Inscripto
                FROM((Tipo_Tramites RIGHT OUTER JOIN(Tipo_Etapa RIGHT OUTER JOIN(Errores RIGHT OUTER JOIN(Empleados RIGHT OUTER JOIN Tramites 
                ON Empleados.Cod_empleado = Tramites.Cod_empleadoProceso) 
                ON Errores.Cod_error = Tramites.Cod_Error)
                ON Tipo_Etapa.Cod_Etapa = Tramites.Cod_etapa) 
                ON Tipo_Tramites.Cod_tramite = Tramites.Cod_proceso)INNER JOIN Empleados Empleados1 
                ON Tramites.Cod_empleadoProceso = Empleados1.Cod_empleado)
                WHERE Empleados.Cod_empleado = '" + id + "' ORDER BY Fecha DESC";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            _read = _command.ExecuteReader();

            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        }
        #endregion

        #region Counting
        // All count
        public int countAllTramites()
        {
            string q = @"SELECT COUNT(*) 
                        FROM Tramites";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            Int32 count = (Int32)_command.ExecuteScalar();
            return count;
        }
        public int countTramitesAllError()
        {
            string q = @"SELECT COUNT(*) 
                        FROM Tramites WHERE Error = '1'";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            Int32 count = (Int32)_command.ExecuteScalar();
            return count;
        }
        public int countTramitesAllError(int tipoDeError)
        {
            string q = @"SELECT COUNT(*) 
                        FROM Tramites WHERE Error = '1' AND Cod_error = "+ tipoDeError +"";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            Int32 count = (Int32)_command.ExecuteScalar();
            return count;
        }
        public int countTramitesAllProcesados()
        {
            string q = @"SELECT COUNT(*) 
                        FROM Tramites WHERE Tramites.Cod_etapa = '1'";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            Int32 count = (Int32)_command.ExecuteScalar();
            return count;
        }
        public int countTramitesAllInscriptos()
        {
            string q = @"SELECT COUNT(*) 
                        FROM Tramites WHERE Tramites.Inscripto = '1';";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            Int32 count = (Int32)_command.ExecuteScalar();
            return count;
        }
        public int countAllTiposDeTramites()
        {
            string q = @"SELECT COUNT(*) 
                        FROM Tipo_Tramites";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            Int32 count = (Int32)_command.ExecuteScalar();
            return count;
        }
        // Correct the counter with Date
        public int countTramitesByRange(DateTime fecha1, DateTime fecha2)
        {
            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            string q = @"SELECT COUNT(*) 
                        FROM Tramites
                        WHERE Fecha >= CONVERT(VARCHAR, '" + dt1.ToString("MM/dd/yyyy") + "' , 100) AND Fecha < CONVERT(VARCHAR, '" + dt2.ToString("MM/dd/yyyy") + "', 100)";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            Int32 count = (Int32)_command.ExecuteScalar();

            return count;
        }
        public int countTramitesByRangeAndError(int isError, DateTime fecha1, DateTime fecha2)
        {
            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            string q = @"SELECT COUNT(*) 
                        FROM Tramites
                        WHERE Error = " + isError + " AND Fecha >= CONVERT(VARCHAR, '" + dt1.ToString("MM/dd/yyyy") + "' , 100) AND Fecha < CONVERT(VARCHAR, '" + dt2.ToString("MM/dd/yyyy") + "', 100)";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            Int32 count = (Int32)_command.ExecuteScalar();
            return count;
        }
        public int countTramitesByRangeAndTipoError(int tipoDeError, DateTime fecha1, DateTime fecha2) 
        {
            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            string q = @"SELECT COUNT(*) 
                        FROM Tramites
                        WHERE Cod_error = " + tipoDeError + " AND Fecha >= CONVERT(VARCHAR, '" + dt1.ToString("MM/dd/yyyy") + "' , 100) AND Fecha < CONVERT(VARCHAR, '" + dt2.ToString("MM/dd/yyyy") + "', 100)";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            Int32 count = (Int32)_command.ExecuteScalar();
            return count;
        }
        public int countTramitesByRangeAndInscripto(int isInscripto, DateTime fecha1, DateTime fecha2) 
        {
            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            string q = @"SELECT COUNT(*) 
                        FROM Tramites
                        WHERE Inscripto = " + isInscripto + " AND Fecha >= CONVERT(VARCHAR, '" + dt1.ToString("MM/dd/yyyy") + "' , 100) AND Fecha < CONVERT(VARCHAR, '" + dt2.ToString("MM/dd/yyyy") + "', 100)";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            Int32 count = (Int32)_command.ExecuteScalar();
            return count;
        }
        public int countEmpleados()
        {
            string q = "SELECT COUNT(*) FROM Empleados;";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;

            Int32 count = (Int32)_command.ExecuteScalar();

            return count;
        }
        #endregion
    }
}
