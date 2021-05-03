using Models.SqlConnect;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Models
{
    public class LoginViewModel
    {
        MySqlDataReader _read;
        MySqlCommand _command;

        public LoginViewModel()
        {
            _command = new MySqlCommand();
        }

        public bool ValidateLogin(string user, string password)
        {
            bool result = false;
            string query = "SELECT * FROM usuario WHERE usuario='" + user + "' AND contraseña='" + password + "' LIMIT 1;";

            _command.Connection = new MySqlConnection(SqlConnector.dbconn.connectionString);
            _command.CommandText = query;
            _read = _command.ExecuteReader();

            while (_read.Read())
            {
                /*UserCache.IdUser = _read.GetInt32(0);
                UserCache.IdPerfil = _read.GetInt32(1);
                UserCache.IdSecurity = _read.GetInt32(2);
                UserCache.User = _read.GetString(3);
                UserCache.Email = _read.GetString(4);
                UserCache.LastAcess = _read.GetDateTime(5);
                UserCache.isRoot = _read.GetInt32(6);*/
                result = true;
            }

            SqlConnector.dbconn.CloseConnection();
            return result;
        }
        public void PersistanteConnection()
        {
            PersistanteConnection persistanteConn = new PersistanteConnection();
        }
    }
}
