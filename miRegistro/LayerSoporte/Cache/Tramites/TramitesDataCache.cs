using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerSoporte.Cache
{
    public class TramitesDataCache
    {

        LinkedList<Tramites> tramitesCache;
        //LinkedList<CategoriasTramites> categoriasCache;

        public int totalTramites;
        public int totalProcesados;
        public int totalInscriptos;
        public int totalErrores;
        public int totalEmpleados;
        public int totalTipos;

        public TramitesDataCache()
        {
            this.tramitesCache = new LinkedList<Tramites>();
        }
        public bool AddTramites(Tramites u)
        {
            LinkedListNode<Tramites> currentTramite = tramitesCache.Find(u);

            if (currentTramite == null)
            {
                this.tramitesCache.AddLast(u);
                return true;
            }
            else
            {
                return false;
            }
        }
        public LinkedList<Tramites> GetTramitesID(int id)
        {
            LinkedList<Tramites> tmpUser = new LinkedList<Tramites>();
            LinkedListNode<Tramites> currentTramites = this.tramitesCache.First;
            while (currentTramites != null)
            {
                if (currentTramites.Value.id == id)
                {
                    tmpUser.AddLast(currentTramites.Value);
                    break;
                }
                currentTramites = currentTramites.Next;
            }
            return tmpUser;
        }
        public LinkedList<Tramites> GetTramites()
        {
            return tramitesCache;
        }
        public Tramites GetCurrentTramites(int id) 
        {
            Tramites tmpUser = null;
            LinkedListNode<Tramites> currentTramites = this.tramitesCache.First;
            while (currentTramites != null)
            {
                if (currentTramites.Value.id == id)
                {
                    tmpUser = currentTramites.Value;
                    break;
                }
                currentTramites = currentTramites.Next;
            }
            return tmpUser;
        }
        /// <summary>
        /// Return total, procesados, inscriptos and errores in this order.
        /// </summary>
        /// <returns></returns>
        public Tuple<int, int, int, int> GetTramitesHistory() 
        {
            return Tuple.Create(totalTramites, totalProcesados, totalInscriptos, totalErrores);
        }
    }
}
