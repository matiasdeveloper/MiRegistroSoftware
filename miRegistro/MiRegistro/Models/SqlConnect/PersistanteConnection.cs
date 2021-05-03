using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SqlConnect
{
    public class PersistanteConnection
    {
        public PersistanteConnection()
        {
            SqlConnector sqlConnector = new SqlConnector(new MySqlConnect());
            // Set default connection string
            SqlConnector.dbconn.connectionString = MiRegistro.Properties.Settings.Default.Server + MiRegistro.Properties.Settings.Default.Port + MiRegistro.Properties.Settings.Default.UserDb + MiRegistro.Properties.Settings.Default.PassDb + "database=miregistro;";
        }
    }
}
