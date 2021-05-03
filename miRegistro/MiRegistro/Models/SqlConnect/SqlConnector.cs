using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SqlConnector
    {
        public static SqlConnector connector;
        public static IConnector dbconn;

        public SqlConnector(IConnector c)
        {
            connector = this;
            dbconn = c;
        }
    }
}
