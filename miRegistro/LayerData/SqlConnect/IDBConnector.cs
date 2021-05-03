using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerData
{
    public interface IDBConnector
    {
        string connectionString { get; set; }
        SqlConnection sqlConnection { get; set; }

        SqlConnection OpenConnection();
        SqlConnection CloseConnection();
    }
}
