using LayerData;
using LayerData.Data;
using LayerData.SqlServer;
using LayerPresentation;
using LayerSoporte.Cache;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LayerBusiness
{
    public class Cn_Tramites
    {       
        private Cd_Tramites _cdObject = new Cd_Tramites();
        private DataTramites d;

        #region Crud
        public void insertarTramite(string dominio, DateTime fecha, int cod_proceso, int cod_empleadoProceso, string observaciones, int error, int cod_error)
        {
            _cdObject.Insert(dominio, fecha, cod_proceso, cod_empleadoProceso, observaciones, error, cod_error);
        }
        public void InsertarCategoria(string nombre)
        {
            _cdObject.InsertCategoria(nombre);
        }
        public void actualizarTramite(int id,string dominio, int cod_proceso, int cod_empleadoProceso, string observaciones, int error, int cod_error)
        {
            _cdObject.Update(id ,dominio, cod_proceso, cod_empleadoProceso, observaciones, error, cod_error);
        }
        public void actualizarError(int id, string observaciones, int error, int cod_error)
        {
            _cdObject.ErrorUpdate(id, observaciones, error, cod_error);
        }
        public void inscribirTramite(int id, int cod_inscripto, int cod_empleado)
        {
            _cdObject.InscribirTramite(id, cod_inscripto, cod_empleado);
        }
        public void inscribirMultiple(int[] id, int cod_inscripto, int cod_empleado)
        {
            foreach(int i in id) 
            {
                _cdObject.InscribirTramite(i, cod_inscripto, cod_empleado);
            }
        }
        public void eliminarTramite(string id)
        {
            _cdObject.Delete(Convert.ToInt32(id));
        }
        #endregion

        #region Show
        // Query default
        public DataTable mostrarTodo()
        {
            DataTable _table = new DataTable();
           _table = _cdObject.mostrarTodo();
            return _table;
        }
        // Query default
        public DataTable mostrarEmpleados()
        {
            DataTable _table = new DataTable();
            _table = _cdObject.mostrarEmpleados();
            return _table;
        }
        public DataTable mostarTramites()
        {
            DataTable _table = new DataTable();
            _table = _cdObject.mostrarTramites();
            return _table;
        }
        public DataTable mostarErrores()
        {
            DataTable _table = new DataTable();
            _table = _cdObject.mostrarErrores();
            return _table;
        }
        public DataTable mostrarByEmployee(int employee)
        {
            DataTable _table = new DataTable();
            _table = _cdObject.mostrarByEmployee(employee);
            return _table;
        }
        /*
        public DataTable mostrarByDominio(string dominio)
        {
            DataTable _table = new DataTable();
            _table = _cdObject.mostrarByDominio(dominio);
            return _table;
        }
        public DataTable mostrarByFecha(DateTime fecha)
        {
            DataTable _table = new DataTable();
            _table = _cdObject.mostrarByFecha(fecha);
            return _table;
        }
        public DataTable mostrarByRangeOfFecha(DateTime fecha1, DateTime fecha2)
        {
            DataTable _table = new DataTable();
            _table = _cdObject.mostrarByRangeOfFecha(fecha1, fecha2);
            return _table;
        }
        public DataTable mostrarByFechaAndEmployee(DateTime fecha, int employee)
        {
            DataTable _table = new DataTable();
            _table = _cdObject.mostrarByFechaAndEmployee(fecha, employee);
            return _table;
        }
        public DataTable mostrarByRangeOfFechaAndEmployee(DateTime fecha1, DateTime fecha2, int employee)
        {
            DataTable _table = new DataTable();
            _table = _cdObject.mostrarByRangeOfFechaAndEmployee(fecha1, fecha2, employee);
            return _table;
        }
        public DataTable mostrarByFechaAndProcesado(DateTime fecha1, int procesado)
        {
            DataTable _table = new DataTable();
            _table = _cdObject.mostrarByFechaAndProcesado(fecha1, procesado);
            return _table;
        }
        public DataTable mostrarByRangeOfFechaAndProcesado(DateTime fecha1, DateTime fecha2, int procesado)
        {
            DataTable _table = new DataTable();
            _table = _cdObject.mostrarByRangeOfFechaAndProcesado(fecha1, fecha2, procesado);
            return _table;
        }
        public DataTable mostrarByFechaAndInscripto(DateTime fecha1, int procesado)
        {
            DataTable _table = new DataTable();
            _table = _cdObject.mostrarByFechaAndInscripto(fecha1, procesado);
            return _table;
        }
        public DataTable mostrarByRangeOfFechaAndInscripto(DateTime fecha1, DateTime fecha2, int procesado)
        {
            DataTable _table = new DataTable();
            _table = _cdObject.mostrarByRangeOfFechaAndInscripto(fecha1, fecha2, procesado);
            return _table;
        }
        public DataTable mostrarByFechaAndError(DateTime fecha1, int error)
        {
            DataTable _table = new DataTable();
            _table = _cdObject.mostrarByFechaAndError(fecha1, error);
            return _table;
        }
        public DataTable mostrarByRangeOfFechaAndError(DateTime fecha1, DateTime fecha2, int error)
        {
            DataTable _table = new DataTable();
            _table = _cdObject.mostrarByRangeOfFechaAndError(fecha1, fecha2, error);
            return _table;
        }
        public DataTable GetTramitesID(int id)
        {
            DataTable _table = new DataTable();
            _table = _cdObject.GetTramitesID(id);
            return _table;
        }*/
        #endregion

        #region Counting
        public int countAllTramites()
        {
            Int32 count = _cdObject.countAllTramites();
            return count;
        }
        public int countTramitesAllError()
        {
            Int32 count = _cdObject.countTramitesAllError();
            return count;
        }
        public int countTramitesAllError_PorTipo(int tipoError)
        {
            Int32 count = _cdObject.countTramitesAllError();
            return count;
        }
        public int countTramitesAllProcesado()
        {
            Int32 count = _cdObject.countTramitesAllProcesados();
            return count;
        }
        public int countTramitesAllInscripto()
        {
            Int32 count = _cdObject.countTramitesAllInscriptos();
            return count;
        }
        public int countAllTipoTramites()
        {
            Int32 count = _cdObject.countAllTiposDeTramites();
            return count;
        }
        public int countByDate(DateTime dt1, DateTime dt2)
        {
            Int32 count = _cdObject.countTramitesByRange(dt1, dt2);
            return count;
        }
        public int countByError(bool isError, DateTime dt1, DateTime dt2)
        {
            int e = 0;
            if (isError)
            {
                e = 1;
            }
            else
            {
                e = 0;
            }

            Int32 count = _cdObject.countTramitesByRangeAndError(e, dt1, dt2);
            return count;
        }
        public int countByTipoError(int tipoDeError, DateTime dt1, DateTime dt2)
        {
            Int32 count = _cdObject.countTramitesByRangeAndTipoError(tipoDeError, dt1, dt2);
            return count;
        }
        public int countByInscripto(bool isIncripto, DateTime dt1, DateTime dt2)
        {
            int e = 0;
            if (isIncripto)
            {
                e = 1;
            }
            else
            {
                e = 0;
            }
            Int32 count = _cdObject.countTramitesByRangeAndInscripto(e, dt1, dt2);
            return count;
        }
        public int countEmpleados()
        {
            Int32 count = _cdObject.countEmpleados();
            return count;
        }
        #endregion

        #region Cache
        public void GenerateDataTramitesCache()
        {
            Cn_HandlerTramites.data = new DataTramites();
            Cn_HandlerTramites.current += 1;

             // Generate the data cache from all of tramites
            Cn_HandlerTramites.data.GetCache().AddTramites(GetTramites(Cn_HandlerTramites.current));

            RefreshDataDashboardCache();
            RefreshDataFechasCache();
        }
        public void RefreshDataTramitesCache() 
        {
            Cn_HandlerTramites.current += 1;
            // Generate the new data cache from all of tramites
            Cn_HandlerTramites.data.GetCache().AddTramites(GetTramites(Cn_HandlerTramites.current));
            RefreshDataDashboardCache();
        }
        public void RefreshDataDashboardCache() 
        {
            Cn_HandlerTramites.data.GetCache().totalTramites = countAllTramites();
            Cn_HandlerTramites.data.GetCache().totalErrores = countTramitesAllError();
            Cn_HandlerTramites.data.GetCache().totalProcesados = countTramitesAllProcesado();
            Cn_HandlerTramites.data.GetCache().totalInscriptos = countTramitesAllInscripto();
            Cn_HandlerTramites.data.GetCache().totalEmpleados = countEmpleados();
            Cn_HandlerTramites.data.GetCache().totalTipos = countAllTipoTramites();
        }
        private Tramites GetTramites(int id)
        {
            DataTable tramites = mostrarTodo();
            Tramites cache = new Tramites(id, tramites);
            return cache;
        }
        public void RefreshDataFechasCache()
        {
            Fechas.firstDayOfWeek = FirstDayOfWeek(DateTime.Now);
            Fechas.lastDayOfWeek = Fechas.firstDayOfWeek.AddDays(6);

            DateTime dateNow = DateTime.Now;

            Fechas.firstDayOfMonth = new DateTime(dateNow.Year, dateNow.Month, 1);
            Fechas.lastDayOfMonth = Fechas.firstDayOfMonth.AddMonths(1).AddDays(-1);
        }
        public static DateTime FirstDayOfWeek(DateTime dt)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0)
                diff += 7;
            return dt.AddDays(-diff).Date;
        }
        #endregion
    }
}
