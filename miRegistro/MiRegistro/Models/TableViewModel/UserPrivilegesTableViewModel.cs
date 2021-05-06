using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiRegistro.Models
{
    public class UserPrivilegesTableViewModel
    {
        // User
        public string privilegeName { get; set; }
        public string description { get; set; }
        public DateTime inicioDate { get; set; }
        public DateTime finDate { get; set; }
    }
}
