using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerData.SqlQuery
{
    public class CDataAlertas
    {
        private protected MySqlConnect _mySqlConnect;
        SqlDataReader _read;
        SqlCommand _command;
        DataTable _table;

        public CDataAlertas()
        {
            Initialize();
        }

        private protected void Initialize()
        {
            _mySqlConnect = new MySqlConnect();
            _command = new SqlCommand();
        }
    }
}
