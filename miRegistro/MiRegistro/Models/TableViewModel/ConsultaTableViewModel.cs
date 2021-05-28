using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ConsultaTableViewModel
    {
        public string Dominio { get; set; }

        public DateTime firstDate { get; set; }
        public DateTime lastDate { get; set; }

        public int categoryId { get; set; }
        public string categoryName { get; set; }

        public int etapa { get; set; }

        public int employeeIdProceso { get; set; }

        public int employeeIdInscripcion { get; set; }

        public int error { get; set; }
    }
}
