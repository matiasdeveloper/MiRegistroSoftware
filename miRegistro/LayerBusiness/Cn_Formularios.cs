using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using LayerData;

namespace LayerBusiness
{
    public class Cn_Formularios
    {
        private Cd_Formularios _cdObject = new Cd_Formularios();

        public DataTable mostrarFormularios(int mostrarIn) 
        {
            DataTable _table = new DataTable();
            _table = _cdObject.mostrar(mostrarIn);
            return _table;          
        } 
        
        public DataTable mostrarCategorias(int mostrarIn) 
        {
            DataTable _table = new DataTable();
            _table = _cdObject.mostarCategorias(mostrarIn);
            return _table;
        }
        public void insertarFormularios(string cod_categoria, string cod_elemento, string numeracion, string stock, string datetime) 
        {
            _cdObject.Insert(Convert.ToInt32(cod_categoria),Convert.ToInt32(cod_elemento),numeracion, Convert.ToInt32(stock), Convert.ToDateTime(datetime));   
        } 
        public void actualizarFormularios(int cod_categoria, int cod_elemento, string numeracion, string stock, string datetime, string id)
        {
            _cdObject.Update(cod_categoria, cod_elemento, numeracion, Convert.ToInt32(stock), Convert.ToDateTime(datetime) , Convert.ToInt32(id));
        }
        public void eliminarFormularios(string id)
        {
            _cdObject.Delete(Convert.ToInt32(id));
        }
        public void actualizarStock(string stock, string dateNow, string id) 
        {
            _cdObject.UpdateStock(Convert.ToInt32(stock), Convert.ToDateTime(dateNow), Convert.ToInt32(id));
        }
        public int consultasRapidas(int min, int max) 
        {
            int num = _cdObject.queryCount(min, max);
            return num;      
        }
        public DataTable findAlert(int menorIgualQue) 
        {
            DataTable _table = new DataTable();
            _table = _cdObject.findAlert(menorIgualQue);
            return _table;
        }
    }
}
