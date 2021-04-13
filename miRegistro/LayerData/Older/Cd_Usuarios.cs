﻿using System;
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
        private MySqlConnect _conn = new MySqlConnect();
        SqlDataReader _read;
        SqlCommand _command = new SqlCommand();

        #region LoginUser
        public bool AddUser(List<string> login, List<string> info, List<string> empleado)
        {
            bool resultado = false;
            string query_user = "INSERT INTO Users VALUES('"+login[0]+"', CAST('"+login[1]+"' AS VARBINARY(MAX)), '"+login[2]+"', CAST('probando respuesta' AS VARBINARY(MAX)), '0')";
            string query_info = " INSERT INTO Info_users VALUES(SCOPE_IDENTITY(),'"+info[0]+"','"+info[1]+"', '"+info[2]+"','"+info[3]+"', GETDATE(), GETDATE(), '-')";

            _command.Connection = _conn.OpenConnection();
            _command.CommandText = query_user + "\n" +query_info;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();
            _conn.CloseConnection();

            int lastId = GetLastId();

            _command.Connection = _conn.OpenConnection();
            string query_empleado = "INSERT INTO Empleados VALUES('" + lastId + "', '" + empleado[0] + "', '" + empleado[1] + "', '1000', 'Ninguna')";
            _command.CommandText = query_empleado;
            _command.ExecuteNonQuery();
            _conn.CloseConnection();

            return resultado;
        }
        public int GetLastId()
        {
            int id = 0;
            string q = "SELECT COUNT(*) FROM Users";

            _command.Connection = _conn.OpenConnection();
            _command.CommandText = q;
            _read = _command.ExecuteReader();

            while (_read.Read())
            {
                id = _read.GetInt32(0);
            }

            _conn.CloseConnection();

            return id;
        }
        
        public int Autentificar(string user, string password) 
        {
            int resultado = -1;
            string q = "SELECT * FROM Users WHERE Usuario = '" + user + "' AND Contraseña = CAST('" + password + "' AS varbinary(MAX))";

            _command.Connection = _conn.OpenConnection();
            _command.CommandText = q;
            _read = _command.ExecuteReader();

            while (_read.Read())
            {
                UserLoginCache.IdUser = _read.GetInt32(0);
                UserLoginCache.Username = _read.GetString(1);
                UserLoginCache.Password = Encoding.UTF8.GetString(_read.GetSqlBinary(2).Value);
                UserLoginCache.Priveleges = _read.GetString(3);
                UserLoginCache.RespuestaSecurity = Encoding.UTF8.GetString(_read.GetSqlBinary(4).Value);
                //UserLoginCache.isRoot = _read.GetInt32(5);
                resultado = 1;
            }

            _conn.CloseConnection();
            return resultado;
        }
        public bool VerificarPassword(int id, string password)
        {
            bool resultado = false;
            string q = "SELECT * FROM Users WHERE Id = " + id + " AND Contraseña = CAST('" + password + "' AS varbinary(MAX))";

            _command.Connection = _conn.OpenConnection();
            _command.CommandText = q;
            _read = _command.ExecuteReader();

            while (_read.Read())
            {
                resultado = true;
            }

            _conn.CloseConnection();
            return resultado;
        }

        public DataTable IntializeLoginUserData(string user)
        {
            DataTable _dtTable = new DataTable();
            string q = "SELECT * FROM Info_users WHERE Id = " + UserLoginCache.IdUser + "";
            _command.Connection = _conn.OpenConnection();
            _command.CommandText = q;
            _read = _command.ExecuteReader();
            while (_read.Read())
            {
                UserLoginCache.Nombre = _read.GetString(1);
                UserLoginCache.Nick = _read.GetString(2);
                UserLoginCache.City = _read.GetString(3);
                UserLoginCache.Email = _read.GetString(4);
                UserLoginCache.Fecha_nacimiento = _read.GetDateTime(5);
                UserLoginCache.Fecha_UltimoAcceso = _read.GetDateTime(6);
            }
            _dtTable.Load(_read);
            _conn.CloseConnection();

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
            _command.Connection = _conn.OpenConnection();

            // First
            q = "UPDATE Users SET Usuario = '" + user + "', Contraseña = CAST('" + password + "' AS VARBINARY(MAX)) WHERE Id = " + id + ";";
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();
            // Second
            q = "UPDATE Info_users SET Nombre = '" + nombre + "', Nombre_corto = '" + nombre_corto + "', Email = '" + email + "' WHERE Id = " + id + "";
            _command.CommandText = q;
            _command.ExecuteNonQuery();

            _conn.CloseConnection();
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
                command.Connection = _conn.OpenConnection();
                command.CommandText = q;
                _read = command.ExecuteReader();
                _dtTable.Load(_read);
            }
            _conn.CloseConnection();

            return _dtTable;
        }
        public DataTable GetInfoUser(int id)
        {
            DataTable _dtTable = new DataTable();

            using (SqlCommand command = new SqlCommand())
            {
                string q = "SELECT * FROM Info_users WHERE Id = '" + id + "' ";
                command.Connection = _conn.OpenConnection();
                command.CommandText = q;
                _read = command.ExecuteReader();
                _dtTable.Load(_read);
            }
            _conn.CloseConnection();

            return _dtTable;
        }
        public DataTable GetInfoEmployee(int id)
        {
            DataTable _dtTable = new DataTable();

            using (SqlCommand command = new SqlCommand())
            {
                string q = "SELECT * FROM Empleados WHERE Cod_empleado = '" + id + "';";
                command.Connection = _conn.OpenConnection();
                command.CommandText = q;
                _read = command.ExecuteReader();
                _dtTable.Load(_read);
            }
            _conn.CloseConnection();

            return _dtTable;
        }
        public DataTable GetEmpleados() 
        {
            DataTable _dtTable = new DataTable();

            using (SqlCommand command = new SqlCommand())
            {
                string q = "SELECT Cod_empleado FROM Empleados";
                command.Connection = _conn.OpenConnection();
                command.CommandText = q;
                _read = command.ExecuteReader();
                _dtTable.Load(_read);
            }
            _conn.CloseConnection();

            return _dtTable;
        }
        public void GetDataFromRecover(string user)
        {
            string q = "SELECT * FROM Users WHERE Usuario = '" + user + "';";
            _command.Connection = _conn.OpenConnection();
            _command.CommandText = q;
            _read = _command.ExecuteReader();

            while (_read.Read())
            {
                UserLoginCache.IdUser = _read.GetInt32(0);
                UserLoginCache.Username = _read.GetString(1);
                UserLoginCache.Password = Encoding.UTF8.GetString(_read.GetSqlBinary(2).Value);
                UserLoginCache.Priveleges = _read.GetString(3);
            }

            _conn.CloseConnection();
            GetEmailFromUserConnected();
        }
        private void GetEmailFromUserConnected()
        {
            string q = "SELECT * FROM Info_users WHERE Id = " + UserLoginCache.IdUser + "";
            _command.Connection = _conn.OpenConnection();
            _command.CommandText = q;
            _read = _command.ExecuteReader();
            while (_read.Read())
            {
                UserLoginCache.Email = _read.GetString(4);
            }
            _conn.CloseConnection();
        }
        public DataTable FindDataFromSpecificUser(int id)
        {
            DataTable _dtTable = new DataTable();
            DataTable _dtTable2 = GetInfoUser(id);
            string q = "";

            using (SqlCommand command1 = new SqlCommand())
            {
                q = "SELECT * FROM Users WHERE Id = '" + id + "' ";
                command1.Connection = _conn.OpenConnection();
                command1.CommandText = q;
                _read = command1.ExecuteReader();
                _dtTable.Load(_read);
            }
            _conn.CloseConnection();

            foreach (DataRow dr in _dtTable.Rows)
            {
                // _dtTable2.Rows.Add(dr.ItemArray);
            }

            return _dtTable2;
        }
        #endregion

        #region UpdateUsers
        public void UpdateUserData(int id, string[] user)
        {
            string q = "UPDATE Users SET Usuario = '" + user[0] + "', Contraseña = CAST('" + user[1] + "' AS VARBINARY(MAX)), Type_user = '" + user[2] + "', isRoot = "+Convert.ToInt32(user[3])+" WHERE Id = " + id + "";

            _command.Connection = _conn.OpenConnection();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _conn.CloseConnection();
        }
        public void UpdateUserInfo(int id, string[] info)
        {
            string q = "UPDATE Info_users SET Nombre = '" + info[0] + "', Nombre_corto = '" + info[1] + "', Ciudad = '" + info[2] + "', Email = '" + info[3] + "', Fecha_nacimiento = CONVERT(VARCHAR, '" + info[4] + "', 100) WHERE Id = " + id + "";

            _command.Connection = _conn.OpenConnection();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _conn.CloseConnection();
        }
        public void UpdateUserEmpleado(int id, string[] empleado)
        {
            string q = "UPDATE Empleados SET Fecha_contratacion = CONVERT(VARCHAR, '" + empleado[0] + "', 100), Salario ='" + empleado[1]+"' , Observaciones = '"+empleado[2]+"' WHERE Cod_empleado = " + id + "";

            _command.Connection = _conn.OpenConnection();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _conn.CloseConnection();
        }
       
        public void UpdateUser(int id,  string user)
        {
            string q = "UPDATE Users SET Usuario = '"+ user +"' WHERE Id = "+ id +"";
            
            _command.Connection = _conn.OpenConnection();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _conn.CloseConnection();
        }
        public void UpdatePassword(int id, string password)
        {
            string q = "UPDATE Users SET Contraseña = CAST('"+ password +"' AS VARBINARY(MAX)) WHERE Id = "+ id +"";

            _command.Connection = _conn.OpenConnection();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _conn.CloseConnection();
        }
        public void UpdatePrivileges(int id, string privilegesAdmin) 
        {
            string q = "UPDATE Users SET Type_user = " + privilegesAdmin + " WHERE Id = " + id + "";

            _command.Connection = _conn.OpenConnection();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _conn.CloseConnection();
        }
        public void UpdateName(int id, string nombre)
        {
            string q = "UPDATE Info_users SET Nombre = '"+ nombre +"'WHERE Id = "+ id +"";

            _command.Connection = _conn.OpenConnection();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _conn.CloseConnection();
        }
        public void UpdateShortName(int id, string shortnombre)
        {
            string q = "UPDATE Info_users SET Nombre_corto = '" + shortnombre + "' WHERE Id = "+ id +"";

            _command.Connection = _conn.OpenConnection();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _conn.CloseConnection();
        }
        public void UpdateEmail(int id, string email)
        {
            string q = "UPDATE Info_users SET Email = '" + email + "' WHERE Id = "+id+"";

            _command.Connection = _conn.OpenConnection();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _conn.CloseConnection();
        }
        public void UpdateCity(int id, string city)
        {
            string q = "UPDATE Info_users SET Ciudad = '" + city + "' WHERE Id = "+ id +"; ";

            _command.Connection = _conn.OpenConnection();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _conn.CloseConnection();
        }
        public void UpdateLastAccess(int id, DateTime fecha)
        {
            string q = "UPDATE Info_users SET Fecha_ultimoacesso = CONVERT(VARCHAR, '" + fecha.ToString("MM/dd/yyyy") + "', 100) WHERE Id = " + id + "";

            _command.Connection = _conn.OpenConnection();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _conn.CloseConnection();
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
