using LayerBusiness.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerBusiness
{
    public class CNegocioUsuario
    {
        private CDataUsuario cdObject;

        public CNegocioUsuario() 
        {
            cdObject = new CDataUsuario();
        }

        public bool VerificarAutentificacion(string user, string password) 
        {
            user = user.ToLower();
            //password = PasswordEncrypter.Decrypt(password);
            bool result = cdObject.Autentificar(user, password);
            return result;
        }
    }
}
