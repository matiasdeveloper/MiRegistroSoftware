using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.util;

namespace LayerPresentation.Models
{
    public class SqlConnector
    {
        public static IConnector connector;

        public SqlConnector(IConnector c)
        {
            connector = c;
        }
    }
}
