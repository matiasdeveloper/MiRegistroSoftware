using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using LayerData;
using LayerSoporte.Cache;
using LayerData.Data;

namespace LayerBusiness
{
    public class Cn_Formularios
    {
        private Cd_Formularios _cdObject = new Cd_Formularios();

        public DataTable MostarTodo()
        {
            DataTable _table = new DataTable();
            _table = _cdObject.MostrarTodo();
            return _table;
        }
        public DataTable MostrarCategorias()
        {
            DataTable _table = new DataTable();
            _table = _cdObject.MostarCategorias();
            return _table;
        }

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
        public int[] ConsultaStockRapido() 
        {
            List<int> a = new List<int>();

            a.Add(consultasRapidas(50, Cn_HandlerFormularios.stockAlto));
            a.Add(consultasRapidas(10, Cn_HandlerFormularios.stockMedio));
            a.Add(consultasRapidas(0, Cn_HandlerFormularios.stockBajo));

            return a.ToArray();
        }
        public DataTable findAlert(int menorIgualQue) 
        {
            DataTable _table = new DataTable();
            _table = _cdObject.findAlert(menorIgualQue);
            return _table;
        }

        #region Cache
        public void GenerateDataFormulariosCache()
        {
            Cn_HandlerFormularios.data = new DataFormularios();
            Cn_HandlerFormularios.current += 1;

            // Generate the data cache from all of formularios
            Cn_HandlerFormularios.data.GetCache().AddFormularios(GetFormularios(Cn_HandlerFormularios.current));
            Cn_HandlerFormularios.data.GetCache().AddCategoria(GetCategorias());
            RefreshDataDashboardCache();
        }
        private Formulario GetFormularios(int id)
        {
            Formulario frm = new Formulario(id, MostarTodo());
            return frm;
        }
        private DataTable GetCategorias()
        {
            DataTable cat = MostrarCategorias();
            return cat;
        }
        public void RefreshDataFormulariosCache()
        {
            Cn_HandlerFormularios.current += 1;

            // Generate the data cache from all of formularios
            Cn_HandlerFormularios.data.GetCache().AddFormularios(GetFormularios(Cn_HandlerFormularios.current));
        }
        public void RefreshDataCategoriasCache() 
        {
            Cn_HandlerFormularios.data.GetCache().AddCategoria(GetCategorias());
        }
        public void RefreshDataDashboardCache()
        {
            int[] countFormularios = ConsultaStockRapido();

            Cn_HandlerFormularios.data.GetCache().totalAltos = countFormularios[0];
            Cn_HandlerFormularios.data.GetCache().totalMedios = countFormularios[1];
            Cn_HandlerFormularios.data.GetCache().totalBajos = countFormularios[2];
        }

        #endregion
    }
}
