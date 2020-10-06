using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using LayerSoporte.Cache;

namespace LayerData
{
    public class Cd_Usuarios
    {
        private Db_Connection _conn = new Db_Connection();
        SqlDataReader _read;
        SqlCommand _command = new SqlCommand();

        #region LoginUser
        public int Autentificar(string user, string password) 
        {
            int resultado = -1;
            string q = "SELECT * FROM Users WHERE Usuario = '" + user + "' AND Contraseña = CAST('" + password + "' AS varbinary(MAX))";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _read = _command.ExecuteReader();

            while (_read.Read())
            {
                UserLoginCache.IdUser = _read.GetInt32(0);
                UserLoginCache.Username = _read.GetString(1);
                UserLoginCache.Password = Encoding.UTF8.GetString(_read.GetSqlBinary(2).Value);
                UserLoginCache.Priveleges = _read.GetString(3);
                UserLoginCache.RespuestaSecurity = Encoding.UTF8.GetString(_read.GetSqlBinary(4).Value);
                UserLoginCache.isRoot = _read.GetInt32(5);
                resultado = 1;
            }

            _conn.closeConnection();
            return resultado;
        }
        public DataTable IntializeLoginUserData(string user)
        {
            DataTable _dtTable = new DataTable();
            string q = "SELECT * FROM Info_users WHERE Id = " + UserLoginCache.IdUser + "";
            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _read = _command.ExecuteReader();
            while (_read.Read())
            {
                UserLoginCache.Nombre = _read.GetString(1);
                UserLoginCache.Nombre_Corto = _read.GetString(2);
                UserLoginCache.City = _read.GetString(3);
                UserLoginCache.Email = _read.GetString(4);
                UserLoginCache.Fecha_nacimiento = _read.GetDateTime(5);
                UserLoginCache.Fecha_UltimoAcceso = _read.GetDateTime(6);
            }
            _dtTable.Load(_read);
            _conn.closeConnection();

            return _dtTable;
        }
        public Tuple<bool, string> RecoverPassword(string userRequesting)
        {
            GetDataFromRecover(userRequesting);

            var mailService = new MailServices.SystemSupportMail();      
            mailService.sendMail(
                subject: "Solicitud de recuperacion de contraseña!",
                body: @"Hola " + userRequesting + "\nSolicitaste una recuperacion de contraseña!\n" +
                "Tu actual contraseña es: " + UserLoginCache.Password +
                "\nPorfavor! Ingrese al sistema y por seguridad cambie su contraseña!\n"
                + "\nGracias, Atte. el sistema de miRegistro",
                receptMail: UserLoginCache.Email);
                      
            return Tuple.Create(true,"Hola " + userRequesting + "\nSolicitaste una recuperacion de la contraseña\n"
                + "Por favor chequea tu casilla de correo de: " + UserLoginCache.Email
                + "\nCambia tu contraseña al ingresar! Es por tu seguridad!" + "\nMuchas gracias!");
        }

        public void EditProfile(int id, string user, string password, string nombre, string nombre_corto, string email)
        {
            string q = "";
            _command.Connection = _conn.openConnetion();

            // First
            q = "UPDATE Users SET Usuario = '" + user + "', Contraseña = CAST('" + password + "' AS VARBINARY(MAX)) WHERE Id = " + id + ";";
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();
            // Second
            q = "UPDATE Info_users SET Nombre = '" + nombre + "', Nombre_corto = '" + nombre_corto + "', Email = '" + email + "' WHERE Id = " + id + "";
            _command.CommandText = q;
            _command.ExecuteNonQuery();

            _conn.closeConnection();
        }

        #endregion

        #region GetDataFromUsers
        // Get data from user
        public DataTable GetUser(int id)
        {
            DataTable _dtTable = new DataTable();

            using(SqlCommand command = new SqlCommand())
            {
                string q = "SELECT Usuario, Type_user as Privilegios FROM Users WHERE Id = '" + id + "' ";
                command.Connection = _conn.openConnetion();
                command.CommandText = q;
                _read = command.ExecuteReader();
                _dtTable.Load(_read);
            }
            _conn.closeConnection();

            return _dtTable;
        }
        public DataTable GetInfoUser(int id)
        {
            DataTable _dtTable = new DataTable();

            using (SqlCommand command = new SqlCommand())
            {
                string q = "SELECT * FROM Info_users WHERE Id = '" + id + "' ";
                command.Connection = _conn.openConnetion();
                command.CommandText = q;
                _read = command.ExecuteReader();
                _dtTable.Load(_read);
            }
            _conn.closeConnection();

            return _dtTable;
        }
        public DataTable GetInfoEmployee(int id)
        {
            DataTable _dtTable = new DataTable();

            using (SqlCommand command = new SqlCommand())
            {
                string q = "SELECT * FROM Empleados WHERE Cod_empleado = '" + id + "';";
                command.Connection = _conn.openConnetion();
                command.CommandText = q;
                _read = command.ExecuteReader();
                _dtTable.Load(_read);
            }
            _conn.closeConnection();

            return _dtTable;
        }
        public DataTable GetEmpleados() 
        {
            DataTable _dtTable = new DataTable();

            using (SqlCommand command = new SqlCommand())
            {
                string q = "SELECT Cod_empleado FROM Empleados";
                command.Connection = _conn.openConnetion();
                command.CommandText = q;
                _read = command.ExecuteReader();
                _dtTable.Load(_read);
            }
            _conn.closeConnection();

            return _dtTable;
        }
        public void GetDataFromRecover(string user)
        {
            string q = "SELECT * FROM Users WHERE Usuario = '" + user + "';";
            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _read = _command.ExecuteReader();

            while (_read.Read())
            {
                UserLoginCache.IdUser = _read.GetInt32(0);
                UserLoginCache.Username = _read.GetString(1);
                UserLoginCache.Password = Encoding.UTF8.GetString(_read.GetSqlBinary(2).Value);
                UserLoginCache.Priveleges = _read.GetString(3);
            }

            _conn.closeConnection();
            GetEmailFromUserConnected();
        }
        private void GetEmailFromUserConnected()
        {
            string q = "SELECT * FROM Info_users WHERE Id = " + UserLoginCache.IdUser + "";
            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _read = _command.ExecuteReader();
            while (_read.Read())
            {
                UserLoginCache.Email = _read.GetString(4);
            }
            _conn.closeConnection();
        }
        public DataTable FindDataFromSpecificUser(int id)
        {
            DataTable _dtTable = new DataTable();
            DataTable _dtTable2 = GetInfoUser(id);
            string q = "";

            using (SqlCommand command1 = new SqlCommand())
            {
                q = "SELECT * FROM Users WHERE Id = '" + id + "' ";
                command1.Connection = _conn.openConnetion();
                command1.CommandText = q;
                _read = command1.ExecuteReader();
                _dtTable.Load(_read);
            }
            _conn.closeConnection();

            foreach (DataRow dr in _dtTable.Rows)
            {
                // _dtTable2.Rows.Add(dr.ItemArray);
            }

            return _dtTable2;
        }
        #endregion

        public void AnyMethod() 
        {
            if(UserLoginCache.Priveleges == Privileges.Administrador) 
            {
                // Codes INSERT, UPDATE, DELETE, READ
            }
            if(UserLoginCache.Priveleges == Privileges.Estandar) 
            {
                // Codes READ
            }
        }
    }
}
