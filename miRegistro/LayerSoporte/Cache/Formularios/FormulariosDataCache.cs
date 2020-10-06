using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerSoporte.Cache.Formularios
{
    public class FormulariosDataCache
    {
        LinkedList<Formulario> formulariosCache;
        DataTable categoriasCache;

        public int totalBajos;
        public int totalMedios;
        public int totalAltos;

        public FormulariosDataCache()
        {
            this.formulariosCache = new LinkedList<Formulario>();
        }
        public bool AddCategoria(DataTable dt) 
        {
            categoriasCache = dt;
            return true;
        }
        public bool AddFormularios(Formulario u)
        {
            LinkedListNode<Formulario> currentFormulario = formulariosCache.Find(u);

            if (currentFormulario == null)
            {
                this.formulariosCache.AddLast(u);
                return true;
            }
            else
            {
                return false;
            }
        }
        public LinkedList<Formulario> GetFormulariosID(int id)
        {
            LinkedList<Formulario> tmpForm = new LinkedList<Formulario>();
            LinkedListNode<Formulario> currentFormulario = this.formulariosCache.First;
            while (currentFormulario != null)
            {
                if (currentFormulario.Value.id == id)
                {
                    tmpForm.AddLast(currentFormulario.Value);
                    break;
                }
                currentFormulario = currentFormulario.Next;
            }
            return tmpForm;
        }
        
        public LinkedList<Formulario> GetFormularios()
        {
            return formulariosCache;
        }
        public DataTable GetCategorias()
        {
            return categoriasCache;
        }
        public Formulario GetCurrentFormulario(int id)
        {
            Formulario tmpForm = null;
            LinkedListNode<Formulario> currentFormulario = this.formulariosCache.First;
            while (currentFormulario != null)
            {
                if (currentFormulario.Value.id == id)
                {
                    tmpForm = currentFormulario.Value;
                    break;
                }
                currentFormulario = currentFormulario.Next;
            }
            return tmpForm;
        }
    }
}
