using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayerPresentation;
using LayerSoporte.Cache;

namespace LayerBusiness
{
    public class Cn_Empleados
    {
        Cn_Usuarios _cnUsuarios = new Cn_Usuarios();
        private DataEmployee d;

        public void GenerateEmployeesDataCache()
        {
            DataTable employeesIDs = _cnUsuarios.GetEmpleados();
            Cn_Employee.data = new DataEmployee(UserLoginCache.IdUser, employeesIDs.Rows.Count);

            d = Cn_Employee.data;

            EmployeesDataCache data = d.GetCache();

            foreach (DataRow fila in employeesIDs.Rows)
            {
                // Generate the data cache from all of user
                data.AddUser(GenerateEmployee((int)fila[0]));
            }
        }
        private Employee GenerateEmployee(int id)
        {
            DataTable UserData = _cnUsuarios.GetUser(id);
            DataTable UserInfoData = _cnUsuarios.GetInfoUser(id);
            DataTable Employee = _cnUsuarios.GetInfoEmpleado(id);

            Cn_Tramites _cnT = new Cn_Tramites();
            Cn_alertas _cnA = new Cn_alertas();
            DataTable TramitesEmployee = _cnT.mostrarByEmployee(id);
            DataTable AlertasEmployee = _cnA.mostrarAlertasFromUser(id.ToString());

            string usuario = UserData.Rows[0][1].ToString();
            string nombre = UserInfoData.Rows[0][1].ToString();
            string privilegios = UserData.Rows[0][1].ToString();
            string city = UserInfoData.Rows[0][3].ToString();
            string email = UserInfoData.Rows[0][4].ToString();
            DateTime fechaNacimiento = (DateTime)UserInfoData.Rows[0][5];
            DateTime fechaAcceso = (DateTime)UserInfoData.Rows[0][6];
            string cellphone = UserInfoData.Rows[0][7].ToString();
            DataTable tramitesMes = TramitesEmployee;
            DataTable alertas = AlertasEmployee;
            DateTime fechaContratacion = (DateTime)Employee.Rows[0][2];
            string salario = Employee.Rows[0][3].ToString();
            string observaciones = Employee.Rows[0][4].ToString();

            Employee cache = new Employee(id, usuario, nombre, privilegios, city, email, fechaNacimiento, fechaAcceso, cellphone, tramitesMes, alertas, fechaContratacion, salario, observaciones);
            
            return cache;
        }
    }
}
