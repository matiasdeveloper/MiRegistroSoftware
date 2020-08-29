using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerSoporte.Cache
{
    public class Tramites
    {
        public DataTable data;
        public int id;

        public Tramites(int id, DataTable data)
        {
            this.id = id;
            this.data = data;
        }
    }
}
