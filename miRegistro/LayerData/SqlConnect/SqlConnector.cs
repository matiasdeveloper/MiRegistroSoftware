using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerData
{
    public class SqlConnector
    {
        public static IDBConnector connector;

        public SqlConnector(IDBConnector c)
        {
            connector = c;
            c.connectionString = Properties.Settings.Default.connProduction;
        }
    }
}
