using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DashboardTableViewModel
    {
        public int totalProcesado {get; set;}
        public int totalProcesadoPast { get; set; }
        public float percentageDifference { get; set; }

        public int errores { get; set; }
        public int erroresPast { get; set; }
        public float percentageDifferenceErrores { get; set; }
    }
}
