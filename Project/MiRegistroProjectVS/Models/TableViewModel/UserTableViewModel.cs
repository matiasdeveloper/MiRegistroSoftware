using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class UserTableViewModel
    {
        // User
        public int Id { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public sbyte? Activo { get; set; }
        public List<UserPrivilegesTableViewModel> Privileges { get; set; }

        // Perfil
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Nick { get; set; }
        public DateTime FechaCumpleaños { get; set; }

        // Empleado
        public string Empresa { get; set; }

    }
}
