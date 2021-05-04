using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiRegistro.Models;
using MySql.Data.MySqlClient;

namespace Models
{
    public class LoginViewModel
    { 
        public usuario ValidateLogin(string user, string password)
        {
            usuario result = null;
            try 
            {
                using (MiRegistroEntity db = new MiRegistroEntity())
                {
                    var lst = from d in db.usuario
                              where d.Usuario1 == user && d.Contraseña == password && d.Activo == 1
                              select d;

                    if (lst.Count() > 0)
                    {
                        usuario oUser = lst.First();
                        return oUser;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.Write(ex);
                return result;
            }

            return result;
        }

        public usuario FindSavedUser() 
        {
            usuario usuario = new usuario();
            usuario.Usuario1 = PasswordEncrypter.Decrypt(MiRegistro.Properties.Settings.Default.user);
            usuario.Contraseña = PasswordEncrypter.Decrypt(MiRegistro.Properties.Settings.Default.pass);
            return usuario;
        }
        public void RememberMe(bool remember, string user, string password)
        {
            if (remember)
            {
                MiRegistro.Properties.Settings.Default.user = PasswordEncrypter.Encrypt(user);
                MiRegistro.Properties.Settings.Default.pass = PasswordEncrypter.Encrypt(password);
                MiRegistro.Properties.Settings.Default.Save();
            }
            else
            {
                if (PasswordEncrypter.Decrypt(MiRegistro.Properties.Settings.Default.user) == user)
                {
                    MiRegistro.Properties.Settings.Default.user = "";
                    MiRegistro.Properties.Settings.Default.pass = "";
                    MiRegistro.Properties.Settings.Default.Save();
                }
            }
        }

        /*
        while (_read.Read())
        {
            UserCache.IdUser = _read.GetInt32(0);
            UserCache.IdPerfil = _read.GetInt32(1);
            UserCache.IdSecurity = _read.GetInt32(2);
            UserCache.User = _read.GetString(3);
            UserCache.Email = _read.GetString(4);
            UserCache.LastAcess = _read.GetDateTime(5);
            UserCache.isRoot = _read.GetInt32(6);
            result = true;
        }
        */
    }
}
