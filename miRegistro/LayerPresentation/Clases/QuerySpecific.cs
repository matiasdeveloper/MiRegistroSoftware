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
            DataTable dt = CreateNewTable();
            foreach (DataRow fila in data.Rows)
            {
                if ((string)fila[1] == dominio)
                {
                    AddRow(dt, fila);
                }
            }
            return dt;
        }
        public static DataTable GetByEmpleado(string empleado, DataTable data)
        {
            DataTable dt = CreateNewTable();
            foreach (DataRow fila in data.Rows)
            {
                if ((string)fila[2] == empleado)
                {
                    AddRow(dt, fila);
                }
            }
            return dt;
        }
        public static DataTable GetByFecha(DateTime fecha1, DateTime fecha2, DataTable data)
        {
            DataTable dt = CreateNewTable();

            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            foreach (DataRow fila in data.Rows)
            {
                DateTime date = (DateTime)fila[5];
                if (date >= dt1 & date < dt2)
                {
                    AddRow(dt, fila);
                }
            }
            return dt;
        }
        
        // Especificas
        public static DataTable GetByFecha_Empleado(DateTime fecha1, DateTime fecha2, string empleado,DataTable data)
        {
            DataTable dt = CreateNewTable();

            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            foreach (DataRow fila in data.Rows)
            {
                DateTime date = (DateTime)fila[5];
                if (date >= dt1 & date < dt2 && (string)fila[2] == empleado)
                {
                    AddRow(dt, fila);
                }
            }
            return dt;
        }
        public static DataTable GetByFecha_Procesado(DateTime fecha1, DateTime fecha2, DataTable data)
        {
            DataTable dt = CreateNewTable();

            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            foreach (DataRow fila in data.Rows)
            {
                DateTime date = (DateTime)fila[5];
                if (date >= dt1 & date < dt2)
                {
                    AddRow(dt, fila);
                }
            }
            return dt;
        }
        public static DataTable GetByFecha_Inscripto(DateTime fecha1, DateTime fecha2, bool inscripto,DataTable data)
        {
            DataTable dt = CreateNewTable();

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
                        AddRow(dt, fila);
                    }
                }
            }
            return dt;
        }
        public static DataTable GetByFecha_Errores(DateTime fecha1, DateTime fecha2, bool errores,DataTable data)
        {
            DataTable dt = CreateNewTable();

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
                        AddRow(dt, fila);
                    }
                }
            }
            return dt;
        }

        private static void AddRow(DataTable dt, DataRow fila)
        {
            DataRow row;

            row = dt.NewRow();

            row["Id"] = fila[0];
            row["Dominio"] = fila[1];
            row["Empleado"] = fila[2];
            row["Tramite"] = fila[3];
            row["Etapa"] = fila[4];
            row["Fecha"] = fila[5];
            row["Error"] = fila[6];
            row["Tipo Error"] = fila[7];
            row["Observaciones"] = fila[8];
            row["Inscripto"] = fila[9];

            dt.Rows.Add(row);
        }
        private static DataTable CreateNewTable()
        {
            DataTable table = new DataTable();
            DataColumn column;
            // Create new DataColumn, set DataType, ColumnName and add to DataTable.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Id";
            table.Columns.Add(column);

            // Create a first column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Dominio";
            table.Columns.Add(column);

            // Create a first column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Empleado";
            table.Columns.Add(column);

            // Create a first column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Tramite";
            table.Columns.Add(column);

            // Create a first column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Etapa";
            table.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.DateTime");
            column.ColumnName = "Fecha";
            table.Columns.Add(column);
            
            // Create third column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.Boolean");
            column.ColumnName = "Error";
            table.Columns.Add(column);

            // Create four column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Tipo Error";
            table.Columns.Add(column);

            // Create four column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Observaciones";
            table.Columns.Add(column);

            // Create four column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.Boolean");
            column.ColumnName = "Inscripto";
            table.Columns.Add(column);

            return table;
        }
    }
}
