using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LayerData
{
    public class Cd_Alertas
    {
        private Db_Connection _conn = new Db_Connection();

        SqlDataReader _read;
        DataTable _table = new DataTable();
        SqlCommand _command = new SqlCommand();

        public DataTable mostarAlertas() 
        {
            string q = @"SELECT cod_alerta AS Codigo,  fecha_alerta AS Fecha, usuario_alerta AS 'Usuario alertado'
                         FROM Alertas ORDER BY Fecha DESC;";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _read = _command.ExecuteReader();

            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        }
        public DataTable mostrarAlertasFromUser(string user)
        {
            string q = @"SELECT cod_alerta AS Codigo,  fecha_alerta AS Fecha, usuario_alerta AS 'Usuario alertado'
                         FROM Alertas 
                         WHERE usuario_alerta='"+user+"'" +
                         "ORDER BY Fecha;";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _read = _command.ExecuteReader();

            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        }
        public DataTable mostrarSpecificAlert(int[] formId) 
        {
            _command.Connection = _conn.openConnetion();
            
            foreach(int id in formId) 
            {
                string q = @"SELECT id_formulario as ID, name_categoria as Categoria , name_elemento as Objeto,
                            numeracion as Numeracion, stock as 'Stock actual', ultima_actualizacion as 'Ultima actualizacion'
                            FROM 
                            Formularios 
                            inner join CategoriasFormularios on Formularios.cod_categoria = CategoriasFormularios.cod_categoria 
                            inner join CategoriasElementos on Formularios.cod_elemento = CategoriasElementos.cod_elemento
                            WHERE  id_formulario = "+id+" ORDER BY stock, ultima_actualizacion;";
                _command.CommandText = q;
                _read = _command.ExecuteReader();

                _table.Load(_read);
            }
            _conn.closeConnection();

            return _table;
        }
        public int insertarAlertas(string user)
        {
            string q = "INSERT INTO Alertas VALUES (GETDATE(), '"+user+"');";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            q = "SELECT MAX(cod_alerta) AS LastID FROM Alertas";
            _command.CommandText = q;
            _read = _command.ExecuteReader();

            int id = 0;
            while (_read.Read()) 
            {
                id = _read.GetInt32(0);
            }

            _conn.closeConnection();

            return id;
        }

        public DataTable buscarNuevasAlertas(int stockMenorQue) 
        {
            string q = @"SELECT id_formulario 
                         FROM Formularios
                         WHERE stock <= "+stockMenorQue+" ";
            
            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _read = _command.ExecuteReader();

            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        } 

        public void insertarDetallesAlerta(int id, int id_formulario, string detalleOperacion) 
        {
            string q = "INSERT INTO DetalleAlertas VALUES(" + id + ", " + id_formulario + ", '" + detalleOperacion + "');";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _conn.closeConnection();
        }

        public int[] buscarDetallesAlerta(int cod_alerta) 
        {
            List<int> list = new List<int>();
            int[] specific;

            string q = @"SELECT * FROM DetalleAlertas WHERE cod_alerta = "+cod_alerta+" ;";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _read = _command.ExecuteReader();

            while (_read.Read()) 
            {
                list.Add(_read.GetInt32(1));
            }

            _conn.closeConnection();

            specific = list.ToArray();
            return specific;
        }

    }
}
