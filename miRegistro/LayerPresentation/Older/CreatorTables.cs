using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerPresentation.Clases
{
    public static class CreatorTables
    {
        public static DataTable Tramites()
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

            // Create four column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Nombre Inscripto";
            table.Columns.Add(column);

            return table;
        }
        public static void AddRowTramites(DataTable dt, DataRow fila)
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
            row["Nombre Inscripto"] = fila[10];

            dt.Rows.Add(row);
        }

        public static DataTable TramitesEmployeeTable()
        {
            DataTable table = new DataTable();
            DataColumn column;

            // Create new DataColumn, set DataType, ColumnName and add to DataTable.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Id";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Dominio";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Empleado";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Tramite";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Etapa";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.DateTime");
            column.ColumnName = "Fecha";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Boolean");
            column.ColumnName = "Error";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Tipo error";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Observaciones";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Boolean");
            column.ColumnName = "Inscripto";
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.String");
            column.ColumnName = "Nombre Inscripto";
            table.Columns.Add(column);

            return table;
        }
        public static void AddRowTramitesEmployeesTable(DataTable table, int id,string dominio ,string empleado, string tipoTramite,
            string etapa, DateTime fecha, bool error, string tipoError, string observaciones, bool inscripto, string nombreInscripto)
        {
            DataRow row;
            row = table.NewRow();
            row["Id"] = id;
            row["Dominio"] = dominio;
            row["Empleado"] = empleado;
            row["Tramite"] = tipoTramite;
            row["Etapa"] = etapa;
            row["Fecha"] = fecha;
            row["Error"] = error;
            row["Tipo error"] = tipoError;
            row["Observaciones"] = observaciones;
            row["Inscripto"] = inscripto;
            row["Nombre Inscripto"] = nombreInscripto;
            table.Rows.Add(row);
        }

        public static DataTable TopEmployeesTable()
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
            column.ColumnName = "Empleado";
            table.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Total";
            table.Columns.Add(column);

            // Create third column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Data1";
            table.Columns.Add(column);

            // Create four column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Data2";
            table.Columns.Add(column);

            return table;
        }
        public static void AddRowTopEmployeesTable(DataTable table, string empleado, int top, int total, int erroresP, int erroresT)
        {
            DataRow row;

            row = table.NewRow();
            row["Id"] = top;
            row["Empleado"] = empleado;
            row["Total"] = total;
            row["Data1"] = erroresP;
            row["Data2"] = erroresT;

            table.Rows.Add(row);
        }

        public static DataTable EmployeeList()
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
            column.ColumnName = "Empleado";
            table.Columns.Add(column);

            return table;
        }
        public static void AddRowEmployeeList(DataTable table, int top, string empleado)
        {
            DataRow row;

            row = table.NewRow();
            row["Id"] = top;
            row["Empleado"] = empleado;

            table.Rows.Add(row);
        }

        public static DataTable FormulariosTable()
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
            column.ColumnName = "Categoria";
            table.Columns.Add(column);

            // Create a first column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Objeto";
            table.Columns.Add(column);

            // Create a first column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Numeracion";
            table.Columns.Add(column);

            // Create a first column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Stock";
            table.Columns.Add(column);

            // Create a first column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.DateTime");
            column.ColumnName = "UltimaActualizacion";
            table.Columns.Add(column);

            return table;
        }
        public static void AddRowFormulariosTable(DataTable table, int id, string cat, string obj, string numeracion, int stock, DateTime dt)
        {
            DataRow row;

            row = table.NewRow();
            row["Id"] = id;
            row["Categoria"] = cat;
            row["Objeto"] = obj;
            row["Numeracion"] = numeracion;
            row["Stock"] = stock;
            row["UltimaActualizacion"] = dt;

            table.Rows.Add(row);
        }

        public static DataTable CategoriasFormularios()
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
            column.ColumnName = "Nombre";
            table.Columns.Add(column);

            return table;
        }
        public static void AddRowCategoriasFormularios(DataTable table, int id, string name)
        {
            DataRow row;

            row = table.NewRow();
            row["Id"] = id;
            row["Nombre"] = name;

            table.Rows.Add(row);
        }

    }
}
