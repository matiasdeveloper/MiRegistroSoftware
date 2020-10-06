using LayerSoporte.Cache;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayerSoporte;
using LayerBusiness;

namespace LayerPresentation.Clases
{
    public static class DataFormularios
    {
        /// <summary>
        /// Get the cache for formularios
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DataTable GetFormulariosCacheByID(int id)
        {
            LinkedList<Formulario> tmp = Cn_HandlerFormularios.data.formularioCache.GetFormularios();
            LinkedListNode<Formulario> formularios = tmp.First;

            DataTable table = new DataTable();

            for (int i = 0; i < tmp.Count; i++)
            {
                if (formularios.Value.id == id)
                {
                    table = formularios.Value.data;
                    break;
                }
                formularios = formularios.Next;
            }
            return table;
        }
        
        /// <summary>
        /// Get the table por element (1- Auto, 2- Moto, 3- Varios)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static DataTable GetTableForElement(DataTable data, string name)
        {
            DataTable formularios = CreatorTables.FormulariosTable();
            foreach (DataRow fila in data.Rows)
            {
                if ((string)fila[2] == name)
                {
                    CreatorTables.AddRowFormulariosTable(formularios, (int)fila[0], (string)fila[1], (string)fila[2],
                        (string)fila[3], (int)fila[4], (DateTime)fila[5]);
                }
                else { /* fila.Delete(); */}
            }
            return formularios;
        }

        /// <summary>
        /// Get the categorias in formularios for elements (1- Auto, 2- Moto, 3- Varios)
        /// </summary>
        /// <param name="data"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static DataTable GetCategoriasForName(DataTable data, string name)
        {
            DataTable cat = CreatorTables.CategoriasFormularios();
            foreach (DataRow fila in data.Rows)
            {
                if ((string)fila[2] == name)
                {
                    CreatorTables.AddRowCategoriasFormularios(cat, (int)fila[0], (string)fila[1]);
                }
                else { /* fila.Delete(); */}
            }
            return cat;
        }
    }
}
