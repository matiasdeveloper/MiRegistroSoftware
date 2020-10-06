using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LayerData
{
    public class Cd_Formularios
    {
        private Db_Connection _conn = new Db_Connection();

        SqlDataReader _read;
        DataTable _table = new DataTable();
        SqlCommand _command = new SqlCommand();

        public DataTable MostrarTodo()
        {
            string q = "";

            q = @"SELECT id_formulario as ID, name_categoria as Categoria , name_elemento as Objeto,
                numeracion as Numeracion, stock as 'Stock actual', ultima_actualizacion as 'Ultima actualizacion'
                FROM 
                Formularios 
                inner join CategoriasFormularios on Formularios.cod_categoria = CategoriasFormularios.cod_categoria 
                inner join CategoriasElementos on Formularios.cod_elemento = CategoriasElementos.cod_elemento
                ORDER BY name_elemento";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _read = _command.ExecuteReader();

            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        }
        public DataTable mostrar(int mostrarIn) 
        {
            string q = "";
            // Select query for object
            switch (mostrarIn) 
            {
                case 1:
                    q = @"SELECT id_formulario as ID, name_categoria as Categoria , name_elemento as Objeto,
                numeracion as Numeracion, stock as 'Stock actual', ultima_actualizacion as 'Ultima actualizacion'
                FROM 
                Formularios 
                inner join CategoriasFormularios on Formularios.cod_categoria = CategoriasFormularios.cod_categoria 
                inner join CategoriasElementos on Formularios.cod_elemento = CategoriasElementos.cod_elemento
                WHERE  CategoriasElementos.cod_elemento = '1'
                ORDER BY stock, ultima_actualizacion";
                    break;
                case 2:
                    q = @"SELECT id_formulario as ID, name_categoria as Categoria , name_elemento as Objeto,
                numeracion as Numeracion, stock as 'Stock actual', ultima_actualizacion as 'Ultima actualizacion'
                FROM 
                Formularios 
                inner join CategoriasFormularios on Formularios.cod_categoria = CategoriasFormularios.cod_categoria 
                inner join CategoriasElementos on Formularios.cod_elemento = CategoriasElementos.cod_elemento
                WHERE  CategoriasElementos.cod_elemento = '2'
                ORDER BY stock, ultima_actualizacion";
                    break;
                case 3:
                    q = @"SELECT id_formulario as ID, name_categoria as Categoria , name_elemento as Objeto,
                numeracion as Numeracion, stock as 'Stock actual', ultima_actualizacion as 'Ultima actualizacion'
                FROM 
                Formularios 
                inner join CategoriasFormularios on Formularios.cod_categoria = CategoriasFormularios.cod_categoria 
                inner join CategoriasElementos on Formularios.cod_elemento = CategoriasElementos.cod_elemento
                WHERE  CategoriasElementos.cod_elemento = '3'
                ORDER BY stock, ultima_actualizacion";
                    break;
                default:
                    q = @"SELECT id_formulario as ID, name_categoria as Categoria , name_elemento as Objeto,
                numeracion as Numeracion, stock as 'Stock actual', ultima_actualizacion as 'Ultima actualizacion'
                FROM 
                Formularios 
                inner join CategoriasFormularios on Formularios.cod_categoria = CategoriasFormularios.cod_categoria 
                inner join CategoriasElementos on Formularios.cod_elemento = CategoriasElementos.cod_elemento
                WHERE  CategoriasElementos.cod_elemento = '1'
                ORDER BY stock, ultima_actualizacion";
                    break;
            }

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _read = _command.ExecuteReader();

            _table.Load(_read);
            _conn.closeConnection();
             
            return _table;
        }
        
        public DataTable MostarCategorias() 
        {
            DataTable _table = new DataTable();
            string q = "";
            q = @"SELECT cod_categoria,name_categoria, descripcion_categoria
                  FROM CategoriasFormularios ORDER BY descripcion_categoria;";
            
            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _read = _command.ExecuteReader();

            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        }
       
        public DataTable mostarCategorias(int mostrarIn)
        {
            string q = "";
            switch (mostrarIn) 
            {
                case 1:
                    q = "SELECT cod_categoria,name_categoria FROM CategoriasFormularios WHERE descripcion_categoria = 'Auto';";
                    break;
                case 2:
                    q = "SELECT cod_categoria,name_categoria FROM CategoriasFormularios WHERE descripcion_categoria = 'Moto';";
                    break;
                case 3:
                    q = "SELECT cod_categoria,name_categoria FROM CategoriasFormularios WHERE descripcion_categoria = 'Varios';";
                    break;
                default:
                    q = "SELECT cod_categoria,name_categoria FROM CategoriasFormularios WHERE descripcion_categoria = 'Auto';";
                    break;
            }

            DataTable _table = new DataTable();
            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _read = _command.ExecuteReader();

            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        }
        
        #region CRUD
        public void Insert(int cod_categoria,int cod_elemento, string numeracion, int stock, DateTime datetime)
        {
            string q = "INSERT INTO Formularios VALUES ("+cod_categoria+", "+cod_elemento+",'"+numeracion+"', "+stock+", GETDATE());";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _conn.closeConnection();
        }

        public void Update(int cod_categoria, int cod_elemento, string numeracion, int stock, DateTime datetime, int id)
        {
            string q = "UPDATE Formularios SET cod_categoria = "+ cod_categoria + ", cod_elemento = " + cod_elemento + ",numeracion = '" + numeracion + "', stock = " + stock + ", ultima_actualizacion = GETDATE() WHERE id_formulario = " + id + ";";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _conn.closeConnection();
        }

        public void Delete(int id)
        {
            string q = "DELETE FROM Formularios WHERE id_formulario = " + id + ";";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _conn.closeConnection();
        }

        public void UpdateStock(int stock, DateTime datetime, int id)
        {
            string q = "UPDATE Formularios SET stock = " + stock + ", ultima_actualizacion = GETDATE() WHERE id_formulario = " + id + ";";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            _command.ExecuteNonQuery();

            _conn.closeConnection();
        }
        #endregion
        #region Count
        public int queryCount(int min, int max) 
        {
            int numFormulariosInAlert = 0;

            string q = "SELECT COUNT(id_formulario) FROM Formularios WHERE Stock > "+min+" AND Stock <= "+max+";";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _command.CommandType = CommandType.Text;
            numFormulariosInAlert = (int)_command.ExecuteScalar();

            _conn.closeConnection();


            return numFormulariosInAlert;
        }
        #endregion
        public DataTable findAlert(int menorIgualQue) 
        {
            // Select query for object
            string q = @"SELECT id_formulario as ID, name_categoria as Categoria , name_elemento as Objeto,
                numeracion as Numeracion, stock as 'Stock actual', ultima_actualizacion as 'Ultima actualizacion'
                FROM 
                Formularios 
                inner join CategoriasFormularios on Formularios.cod_categoria = CategoriasFormularios.cod_categoria 
                inner join CategoriasElementos on Formularios.cod_elemento = CategoriasElementos.cod_elemento
                WHERE  stock <= "+ menorIgualQue +" ORDER BY stock, ultima_actualizacion";

            _command.Connection = _conn.openConnetion();
            _command.CommandText = q;
            _read = _command.ExecuteReader();

            _table.Load(_read);
            _conn.closeConnection();

            return _table;
        }
    }
}
