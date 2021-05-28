using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiRegistro.Models;
using MySql.Data.MySqlClient;

namespace Models
{
    public class LoginViewModel
    {
        private MiRegistroEntity db;

        public LoginViewModel(MiRegistroEntity entity)
        {
            this.db = entity;
        }

        public UserTableViewModel ValidateLogin(string user, string password)
        {
            UserTableViewModel result = null;
            try 
            {
                using (MiRegistroEntity db = new MiRegistroEntity())
                {
                    var lst = db.usuario
                                .Join
                                (
                                 db.perfil,
                                 U => U.IdUsuario,
                                 P => P.IdPerfil,
                                 (U, P) => new
                                 {
                                     U,
                                     P
                                 }
                                )
                                .Join
                                (
                                    db.empleado,
                                    xU => xU.U.IdUsuario,
                                    E => E.FkIdUsuario,
                                    (xU, E) => new
                                    {
                                        xU,
                                        E
                                    }
                                )
                                .Join
                                (
                                    db.empresa,
                                    xE => xE.E.FkIdEmpresa,
                                    E => E.IdEmpresa,
                                    (xE, E) => new 
                                    {
                                        xE,
                                        E
                                    }
                                )
                                .Where
                                (
                                   x => x.xE.xU.U.Usuario1 == user && x.xE.xU.U.Contraseña == password
                                )
                                .Select(x => new UserTableViewModel{
                                    Id = x.xE.xU.U.IdUsuario,
                                    Usuario = x.xE.xU.U.Usuario1,
                                    Activo = x.xE.xU.U.Activo,
                                    Email = x.xE.xU.U.Email,
                                    Nombre = x.xE.xU.P.Nombre,
                                    Apellido = x.xE.xU.P.Apellido,
                                    Nick = x.xE.xU.P.Nick,
                                    FechaCumpleaños = (DateTime)x.xE.xU.P.FechaCumpleaños,
                                    Empresa = x.E.Nombre
                                })
                                .ToList().Take(1);

                    if (lst.Count() > 0)
                    {
                        UserTableViewModel oUser = lst.First();
                        oUser.Privileges =  GetValidUserPrivileges(oUser.Id);
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

        public List<UserPrivilegesTableViewModel> GetValidUserPrivileges(int iduser)
        {
            List<UserPrivilegesTableViewModel> result = null;
            try
            {
                using(db)
                {
                    DateTime today = DateTime.Now.Date;
                    var lst = db.usuario_rol
                                .Join
                                (
                                 db.usuario,
                                 UR => UR.IdUsuario,
                                 U => U.IdUsuario,
                                 (UR, U) => new
                                 {
                                     UR,
                                     U
                                 }
                                )
                                .Join
                                (
                                db.rol,
                                xUR => xUR.UR.IdRol,
                                R => R.IdRol,
                                (xUR, R) => new 
                                {
                                    xUR.UR,
                                    R
                                }
                                )
                                .Where
                                (
                                   x => x.UR.IdUsuario == iduser && x.UR.FechaFin >= today
                                )
                                .Select(x => new UserPrivilegesTableViewModel
                                {
                                    privilegeName = x.UR.rol.Nombre,
                                    description = x.UR.rol.Descripcion,
                                    inicioDate = (DateTime)x.UR.FechaInicio,
                                    finDate = (DateTime)x.UR.FechaFin
                                })
                                .ToList();

                    string query = @"SELECT U.Usuario, R.IdRol, R.Nombre
                                        FROM usuario_rol Ur
                                        INNER JOIN usuario U ON U.IdUsuario = Ur.IdUsuario
                                        INNER JOIN rol R ON R.IdRol = Ur.IdRol;";

                    if (lst.Count() > 0)
                    {
                        result = lst.ToList();
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return result;
            }

            return result;
        }
        public LoginTableViewModel FindSavedUser() 
        {
            LoginTableViewModel usuario = new LoginTableViewModel();
            if(MiRegistro.Properties.Settings.Default.user != null) 
            {
                try
                {
                    usuario.User = PasswordEncrypter.Decrypt(MiRegistro.Properties.Settings.Default.user);
                    usuario.Password = PasswordEncrypter.Decrypt(MiRegistro.Properties.Settings.Default.pass);
                }
                catch { }
            }
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
                if(MiRegistro.Properties.Settings.Default.user != null && MiRegistro.Properties.Settings.Default.pass != null) 
                {
                    if (PasswordEncrypter.Decrypt(MiRegistro.Properties.Settings.Default.user) == user)
                    {
                        MiRegistro.Properties.Settings.Default.user = "";
                        MiRegistro.Properties.Settings.Default.pass = "";
                        MiRegistro.Properties.Settings.Default.Save();
                    }
                }
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
