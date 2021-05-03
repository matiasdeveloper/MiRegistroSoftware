using LayerData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerBusiness
{
    public class PersistanceConnectionDB
    {
        public PersistanceConnectionDB()
        {
            SqlConnector sqlConnector = new SqlConnector(new MySqlConnect());
        }
    }
}
