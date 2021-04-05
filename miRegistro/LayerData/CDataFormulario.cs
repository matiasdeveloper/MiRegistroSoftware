using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerData.SqlQuery
{
    public class CDataFormulario
    {
        private protected MySqlConnect _mySqlConnect;
        SqlDataReader _read;
        SqlCommand _command;
        DataTable _table;

        public CDataFormulario()
        {
            Initialize();
        }

        private protected void Initialize()
        {
            _mySqlConnect = new MySqlConnect();
            _command = new SqlCommand();
        }
        public void InsertFormulario(int idEmpresa, int idTipo)
        {
            string q = "INSERT INTO Formulario (FkIdEmpresa, FkIdTipo, UltimaActualizacion) VALUES('"+idEmpresa+"', '"+idTipo+"', NOW()) " +
                @"SET @last_id_numeracion = LAST_INSERT_ID(); 
                INSERT INTO Formulario(FkIdEmpresa, FkIdTipo, UltimaActualizacion) VALUES(1, 34, NOW());
                SET @last_id_numeracion = LAST_INSERT_ID();
                INSERT INTO Formulario_Parametro (IdFormulario, IdParametro, ValorParametro)
                VALUES(@last_id_numeracion, 1, 100),(@last_id_numeracion, 2, 50),(@last_id_numeracion, 3, 10); ";

            _command.Connection = _mySqlConnect.OpenConnection();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _mySqlConnect.CloseConnection();
        }
        public void DeleteFormulario(int id)
        {
            /*string q = "DELETE FROM Formularios WHERE id_formulario = " + id + ";";

            _command.Connection = _mySqlConnect.OpenConnection();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _mySqlConnect.CloseConnection();*/
        }

        public void AddNumeracionFormulario(int idFormulario, string numeracion, int stock)
        {
            string q = @"INSERT INTO NumeracionFormulario (FkIdFormulario, Numearcion, Stock)
                         VALUES ('"+ idFormulario +"', '" + numeracion + "', '"+ stock +"');";

            _command.Connection = _mySqlConnect.OpenConnection();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _mySqlConnect.CloseConnection();
        }
        public void UpdateParametroFormulario(int idFormulario, int idParametro, int stock)
        {
            string q = @"UPDATE formulario_parametro
                        SET ValorParametro = '"+ stock +"' " +
                        "WHERE IdFormulario = '"+idFormulario+ "' AND IdParametro = '" + idParametro + "';";

            _command.Connection = _mySqlConnect.OpenConnection();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _mySqlConnect.CloseConnection();
        }

        public void AddCategoria(int clase, string categoria)
        {
            string q =  @"INSERT INTO categoriaformulario (NombreCategoria)
                        VALUES('"+ categoria +"');" +
                        @"SET @last_id_categoria = LAST_INSERT_ID();
                        INSERT INTO tipoformulario (FkIdClase, FkIdCategoria)
                        VALUES('"+clase+ "', @last_id_categoria);";

            _command.Connection = _mySqlConnect.OpenConnection();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _mySqlConnect.CloseConnection();
        }
          
        public DataTable GetFormularios(int idClase)
        {
            string q = @"SELECT F.IdFormulario AS ID, E.Nombre AS Empresa, Clf.NombreClase AS Clase, Cf.NombreCategoria AS Categoria, N.numeracion AS Numeracion, Sum(N.Stock) AS Stock, F.ultimaactualizacion
                        FROM Formulario F
                            INNER JOIN TipoFormulario Tf ON Tf.IdTipoFormulario = F.FkIdTipo
                            INNER JOIN Empresa E On E.IdEmpresa = F.FkIdEmpresa
                            JOIN claseformulario Clf ON Clf.IdClase = Tf.FkIdClase
                            JOIN categoriaformulario Cf ON Cf.IdCategoria = Tf.FKIdCategoria
                            JOIN numeracionformulario N ON N.FkIdFormulario = F.IdFormulario
                        WHERE Tf.FkIdClase = '" +idClase+"' " +
                       "GROUP BY F.IdFormulario; ";

            _command.Connection = _mySqlConnect.OpenConnection();
            _command.CommandText = q;
            _read = _command.ExecuteReader();

            _table.Load(_read);
            _mySqlConnect.CloseConnection();

            return _table;
        }
        public DataTable GetNumeracionFormularios()
        {
            string q = @"SELECT N.numeracion AS Numeracion, Clf.NombreClase AS Clase, Cf.NombreCategoria AS Categoria, Sum(N.Stock) AS Stock
                        FROM numeracionformulario N
                            JOIN Formulario F ON F.IdFormulario = N.FkIdFormulario
                            INNER JOIN TipoFormulario Tf ON Tf.IdTipoFormulario = F.FkIdTipo
                            JOIN claseformulario Clf ON Clf.IdClase = Tf.FkIdClase
                            JOIN categoriaformulario Cf ON Cf.IdCategoria = Tf.FKIdCategoria
                        GROUP BY N.IdNumeracion;";

            _command.Connection = _mySqlConnect.OpenConnection();
            _command.CommandText = q;
            _read = _command.ExecuteReader();

            _table.Load(_read);
            _mySqlConnect.CloseConnection();

            return _table;
        }
        public DataTable GetParametros(int idFormulario)
        {
            string q = @"SELECT P.NombreParametro, Fp.ValorParametro
                        FROM Formulario F
                            JOIN formulario_parametro Fp ON Fp.IdFormulario = F.IdFormulario
                            JOIN parametro P ON Fp.IdParametro = P.IdParametro
                            INNER JOIN TipoFormulario Tf ON Tf.IdTipoFormulario = F.FkIdTipo
                            JOIN claseformulario Clf ON Clf.IdClase = Tf.FkIdClase
                            JOIN categoriaformulario Cf ON Cf.IdCategoria = Tf.FKIdCategoria
                        WHERE F.IdFormulario = '"+ idFormulario +"';";

            _command.Connection = _mySqlConnect.OpenConnection();
            _command.CommandText = q;
            _read = _command.ExecuteReader();

            _table.Load(_read);
            _mySqlConnect.CloseConnection();

            return _table;
        }
        public DataTable GetCategorias(int idClase)
        {
            DataTable _table = new DataTable();
            string q = "";
            q = @"SELECT Tf.IdTipoFormulario AS 'IdRelacion', Clf.IdClase, Clf.NombreClase AS 'Clase', Cf.NombreCategoria AS 'Categoria' 
                FROM tipoformulario Tf
                    JOIN claseformulario Clf ON Clf.IdClase = Tf.FkIdClase
                    JOIN categoriaformulario Cf ON Cf.IdCategoria = Tf.FKIdCategoria
                HAVING Clf.IdClase = '"+ idClase+"';";

            _command.Connection = _mySqlConnect.OpenConnection();
            _command.CommandText = q;
            _read = _command.ExecuteReader();

            _table.Load(_read);
            _mySqlConnect.CloseConnection();

            return _table;
        }
    }
}
