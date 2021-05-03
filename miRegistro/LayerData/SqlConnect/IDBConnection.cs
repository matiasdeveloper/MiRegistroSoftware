using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LayerData.SqlConnect
{
    public interface IDBConnection
    {
        string connection{ get; set;}
        SqlConnection sqlConnection { get; set; }

        SqlConnection OpenConnection();
        SqlConnection CloseConnection();
    }
}
