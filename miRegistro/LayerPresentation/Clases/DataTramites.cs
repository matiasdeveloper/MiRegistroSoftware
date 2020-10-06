using LayerBusiness;
using LayerPresentation.Clases;
using LayerSoporte.Cache;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public static class DataTramites
{
    // Display combobox empleados
    public static void DisplayEmpleados(ComboBox cb)
    {
        DataTable dt = GetEmployes();
        cb.DisplayMember = "Empleado";
        cb.ValueMember = "Id";
        cb.DataSource = dt;
    }
    private static DataTable GetEmployes()
    {
        LinkedList<Employee> tmp = Cn_Employee.data.GetCache().GetUsers();
        LinkedListNode<Employee> employee = tmp.First;

        DataTable table = CreatorTables.EmployeeList();

        for (int i = 0; i < tmp.Count; i++)
        {
            if(employee.Value.nombre != "Admin S.") 
            {
                CreatorTables.AddRowEmployeeList(table, employee.Value.id, employee.Value.nombre);
            }
            employee = employee.Next;
        }

        return table;
    }

    public static DataTable GetDataTramitesTableWithID(int id)
    {
        LinkedList<Employee> tmp = Cn_Employee.data.GetCache().GetUsers();
        LinkedListNode<Employee> employee = tmp.First;

        DataTable table = new DataTable();

        for (int i = 0; i < tmp.Count; i++)
        {
            if (employee.Value.id == id)
            {
                table = employee.Value.tramitesMes;
                break;
            }
            employee = employee.Next;
        }

        return table;
    }
    public static DataTable GetTableDate(DataTable data, DateTime dt1, DateTime dt2)
    {
        DataTable tramites = CreatorTables.TramitesEmployeeTable();
        dt2.AddDays(1);
        foreach (DataRow fila in data.Rows)
        {
            if ((DateTime)fila[5] >= dt1 && (DateTime)fila[5] < dt2)
            {
                CreatorTables.AddRowTramitesEmployeesTable(tramites, (int)fila[0], (string)fila[1], (string)fila[2],
                    (string)fila[3], (string)fila[4], (DateTime)fila[5], (bool)fila[6],
                    (string)fila[7], (string)fila[8], (bool)fila[9], (string)fila[10]);
            }
            else { /* fila.Delete(); */}
        }
        return tramites;
    }
}

