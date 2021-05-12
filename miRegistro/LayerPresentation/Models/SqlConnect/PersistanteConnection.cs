using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerPresentation.Models.SqlConnect
{
    public class PersistanteConnection
    {
        public PersistanteConnection()
        {
            SqlConnector sqlConnector = new SqlConnector(new MySqlConnect());
            // Set default connection string
           // SqlConnector.connector.connectionString = Properties.Settings.Default.ConnProduction;
        }
    }
}
