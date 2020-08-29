using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using LayerData;
using LayerSoporte.Cache;

namespace LayerBusiness
{
    public class Cn_Usuarios
    {
        private Cd_Usuarios _cdObject = new Cd_Usuarios();

        public Tuple<bool, string> RecoverPassword(string userRequest) 
        {
            return _cdObject.RecoverPassword(userRequest);
        }

        public int verificarAuntetificacion(string user, string password)
        {
            int resultado = -1;
            resultado = _cdObject.Autentificar(user, password);
            return resultado;
        }
        public DataTable IntializeLoginUserData(string user) 
        {
            DataTable _dtTable = new DataTable();
            _dtTable = _cdObject.IntializeLoginUserData(user);
            return _dtTable;
        }
        public DataTable FindDataFromSpecificUser(string user) 
        {
            DataTable _dtTable = new DataTable();
            _dtTable = _cdObject.FindDataFromSpecificUser(int.Parse(user));
            return _dtTable;
        }
        public void EditProfile(string id, string user, string password, string nombre, string nombre_corto, string email)
        {
            _cdObject.EditProfile(Convert.ToInt32(id), user, password, nombre, nombre_corto, email);
        }
        // Get data from users
        public DataTable GetUser(int user)
        {
            DataTable _dtTable = new DataTable();
            _dtTable = _cdObject.GetUser(user);
            return _dtTable;
        }
        public DataTable GetInfoUser(int user)
        {
            DataTable _dtTable = new DataTable();
            _dtTable = _cdObject.GetInfoUser(user);
            return _dtTable;
        }
        public DataTable GetInfoEmpleado(int user)
        {
            DataTable _dtTable = new DataTable();
            _dtTable = _cdObject.GetInfoEmployee(user);
            return _dtTable;
        }
        public DataTable GetEmpleados()
        {
            DataTable _dtTable = new DataTable();
            _dtTable = _cdObject.GetEmpleados();
            return _dtTable;
        }

        public void AnyMethod()
        {
            // Security and permission
            if (UserLoginCache.Priveleges == Privileges.Administrador)
            {
                // Codes INSERT, UPDATE, DELETE, READ
            }
            if (UserLoginCache.Priveleges == Privileges.Estandar)
            {
                // Codes READ
            }
        }
    }
}
