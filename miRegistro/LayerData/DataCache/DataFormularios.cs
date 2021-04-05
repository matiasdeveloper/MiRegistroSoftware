using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayerSoporte.Cache;
using LayerSoporte.Cache.Formularios;

namespace LayerData.Data
{
    public class DataFormularios
    {
        public DataFormularios()
        {
            formularioCache = new FormulariosDataCache(); 
        }

        public FormulariosDataCache formularioCache;

        public FormulariosDataCache GetCache()
        {
            return formularioCache;
        }
    }
}
