using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerPresentation.Clases
{
    public static class QuerySpecific
    {
        // Generate query with tramites and get the result
        /// <summary>
        /// Query avaiable ('Dominio', 'Empleado', 'Fecha', 'Fecha_empleado', 'Fecha_Procesado', 'Fecha_Inscripto', 'Hoy', 'Ayer', 'Semana', 'Mes')
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static DataTable myQuery(string name, DataTable data, DateTime fecha1, DateTime fecha2, string dominio, string empleado, bool etapa)
        {
            DataTable dt = new DataTable();
            switch (name)
            {
                case "Dominio":
                    dt = GetByDominio(dominio, data);
                    break;
                case "Empleado":
                    dt = GetByEmpleado(empleado, data);
                    break;
                case "Fecha":
                    dt = GetByFecha(fecha1, fecha2, data);
                    break;
                case "Fecha_Empleado":
                    dt = GetByFecha_Empleado(fecha1, fecha2, empleado, data);
                    break;
                case "Fecha_Procesado":
                    dt = GetByFecha_Procesado(fecha1, fecha2, data);
                    break;
                case "Fecha_Inscripto":
                    dt = GetByFecha_Inscripto(fecha1, fecha2, etapa, data);
                    break;
                case "Fecha_Errores":
                    dt = GetByFecha_Errores(fecha1, fecha2, etapa, data);
                    break;
                case "Hoy":
                    dt = GetByFecha(fecha1, fecha2, data);
                    break;
                case "Ayer":
                    dt = GetByFecha(fecha1, fecha2, data);
                    break;
                case "Semana":
                    dt = GetByFecha(fecha1, fecha2, data);
                    break;
                case "Mes":
                    dt = GetByFecha(fecha1, fecha2, data);
                    break;
                default:

                    break;
            }
            return dt;
        }

        // Simples
        public static DataTable GetByDominio(string dominio, DataTable data) 
        {
            DataTable dt = CreatorTables.Tramites();
            foreach (DataRow fila in data.Rows)
            {
                if ((string)fila[1] == dominio)
                {
                    CreatorTables.AddRowTramites(dt, fila);
                }
            }
            return dt;
        }
        public static DataTable GetByEmpleado(string empleado, DataTable data)
        {
            DataTable dt = CreatorTables.Tramites();
            foreach (DataRow fila in data.Rows)
            {
                if ((string)fila[2] == empleado)
                {
                    CreatorTables.AddRowTramites(dt, fila);
                }
            }
            return dt;
        }
        public static DataTable GetByFecha(DateTime fecha1, DateTime fecha2, DataTable data)
        {
            DataTable dt = CreatorTables.Tramites();

            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            foreach (DataRow fila in data.Rows)
            {
                DateTime date = (DateTime)fila[5];
                if (date >= dt1 & date < dt2)
                {
                    CreatorTables.AddRowTramites(dt, fila);
                }
            }
            return dt;
        }
        
        // Especificas
        public static DataTable GetByFecha_Empleado(DateTime fecha1, DateTime fecha2, string empleado,DataTable data)
        {
            DataTable dt = CreatorTables.Tramites();

            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            foreach (DataRow fila in data.Rows)
            {
                DateTime date = (DateTime)fila[5];
                if (date >= dt1 & date < dt2 && (string)fila[2] == empleado)
                {
                    CreatorTables.AddRowTramites(dt, fila);
                }
            }
            return dt;
        }
        public static DataTable GetByFecha_Procesado(DateTime fecha1, DateTime fecha2, DataTable data)
        {
            DataTable dt = CreatorTables.Tramites();

            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            foreach (DataRow fila in data.Rows)
            {
                DateTime date = (DateTime)fila[5];
                if (date >= dt1 & date < dt2)
                {
                    CreatorTables.AddRowTramites(dt, fila);
                }
            }
            return dt;
        }
        public static DataTable GetByFecha_Inscripto(DateTime fecha1, DateTime fecha2, bool inscripto,DataTable data)
        {
            DataTable dt = CreatorTables.Tramites();

            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            foreach (DataRow fila in data.Rows)
            {
                DateTime date = (DateTime)fila[5];
                if (date >= dt1 & date < dt2)
                {
                    if((bool)fila[9] == true) 
                    {
                        CreatorTables.AddRowTramites(dt, fila);
                    }
                }
            }
            return dt;
        }
        public static DataTable GetByFecha_Errores(DateTime fecha1, DateTime fecha2, bool errores,DataTable data)
        {
            DataTable dt = CreatorTables.Tramites();

            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            foreach (DataRow fila in data.Rows)
            {
                DateTime date = (DateTime)fila[5];
                if (date >= dt1 & date < dt2)
                {
                    if ((bool)fila[6] == true)
                    {
                        CreatorTables.AddRowTramites(dt, fila);
                    }
                }
            }
            return dt;
        }
    }
}
