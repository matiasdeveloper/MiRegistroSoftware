using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayerData.Data;

namespace LayerBusiness
{
    public class Cn_HandlerFormularios
    {
        public static DataFormularios data { get; set; }
        public static int current = 0;

        public static int stockBajo;
        public static int stockMedio;
        public static int stockAlto;
    }
}
