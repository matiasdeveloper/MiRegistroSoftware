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

        public bool AddUser(List<string>[] data)
        {
            bool isOk = _cdObject.AddUser(data[0], data[1], data[2]);
            return isOk;
        }
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
        public bool verificarPassword(int id, string password) 
        {
            bool resultado = _cdObject.VerificarPassword(id, password);
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
        #region Update User
        public void UpdateUserData(int id, string[] user) 
        {
            _cdObject.UpdateUserData(id, user);
        }
        public void UpdateUserInfo(int id, string[] info)
        {
            _cdObject.UpdateUserInfo(id, info);
        }
        public void UpdateUserEmpleado(int id, string[] empleado)
        {
            _cdObject.UpdateUserEmpleado(id, empleado);
        }
        public void UpdateUser(int id, string user) 
        {
            _cdObject.UpdateUser(id, user);
        }
        public void UpdatePassword(int id, string password) 
        {
            _cdObject.UpdatePassword(id, password);
        }
        public void UpdateName(int id, string name) 
        {
            _cdObject.UpdateName(id, name);
        }
        public void UpdateShortName(int id, string shortname) 
        {
            _cdObject.UpdateShortName(id, shortname);
        }
        public void UpdateEmail(int id, string email) 
        {
            _cdObject.UpdateEmail(id, email);
        }
        public void UpdateCity(int id, string city) 
        {
            _cdObject.UpdateCity(id, city);
        }
        public void UpdateLastAccess(int id, DateTime dt) 
        {
            _cdObject.UpdateLastAccess(id, dt);
        }
        #endregion
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
