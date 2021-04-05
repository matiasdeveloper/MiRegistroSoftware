using LayerSoporte.Cache;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerData.Data
{
    public class DataTramites
    {
        public DataTramites()
        {
            tramitesCache = new TramitesDataCache();
        }

        public TramitesDataCache tramitesCache;

        public TramitesDataCache GetCache()
        {
            return tramitesCache;
        }
    }
}
