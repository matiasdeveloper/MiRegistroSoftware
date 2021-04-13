using LayerData;
using LayerSoporte.Cache;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CDataUsuario
{
    private protected MySqlConnect _mySqlConnect;
    SqlDataReader _read;
    SqlCommand _command;


    public CDataUsuario() 
    {
        Initialize();
    }

    private protected void Initialize() 
    {
        _mySqlConnect = new MySqlConnect();
        _command = new SqlCommand();
    }

    public bool Autentificar(string user, string password)
    {
        bool resultado = false;
        string query = "SELECT * FROM usuario WHERE usuario='" + user + "' AND contraseña='" + password + "' LIMIT 1;";

        _command.Connection = _mySqlConnect.OpenConnection();
        _command.CommandText = query;
        _read = _command.ExecuteReader();

        while (_read.Read())
        {
            UserLoginCache.IdUser = _read.GetInt32(0);
            UserLoginCache.Username = _read.GetString(1);
            UserLoginCache.Password = Encoding.UTF8.GetString(_read.GetSqlBinary(2).Value);
            UserLoginCache.Priveleges = _read.GetString(3);
            UserLoginCache.RespuestaSecurity = Encoding.UTF8.GetString(_read.GetSqlBinary(4).Value);
            //UserLoginCache.isRoot = _read.GetInt32(5);
            resultado = true;
        }

        _mySqlConnect.CloseConnection();
        return resultado;
    }
}
