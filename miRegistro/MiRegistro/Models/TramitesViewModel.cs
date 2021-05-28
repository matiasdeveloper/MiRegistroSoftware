using MiRegistro.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TramitesViewModel
    {
        Random random = new Random();
        private MiRegistroEntity db;
        
        public TramitesViewModel(MiRegistroEntity entity) 
        {
            this.db = entity;
        }

        private DataTable GetTableTramites()
        {
            return GenerateDt(random.Next(0,100));
        }
        private DataTable GenerateDt(int rows)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Id");
            dt.Columns.Add("Dominio");
            dt.Columns.Add("Categoria");
            dt.Columns.Add("Estado");
            dt.Columns.Add("Procesado");
            dt.Columns.Add("Inscripto");
            dt.Columns.Add("Errores");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Observaciones");
            for (int i = 0; i < rows; i++)
            {
                dt.Rows.Add(GenerateRandomRow());
            }
            return dt;
        }
        private object[] GenerateRandomRow()
        {
            object[] a = { "01", "AA150SS", "Transferencia", "Procesado", "Matias", "", "Sin errrores", "27/20/14", "Sin observaciones" };
            object[] a1 = { "22", "AA230LD", "Inscripcion inicial", "Procesado", "Matias", "", "Sin errrores", "27/20/14", "Sin observaciones" };
            object[] a2 = { "10", "AA120DF", "Desarrollo de software", "Inscripto", "Matias", "Noeli", "Error en la cedula", "27/20/14", "Todas las observaciones posibles" };
            object[] a3 = { "55", "AA450LF", "Cedula autorizada", "Observado", "Matias", "Noeli", "Error en la cedula", "27/20/14", "Todas las observaciones posibles" };
            object[] a4 = { "23", "AA655FF", "Cambio de uso", "Inscripto", "Matias", "Noeli", "Sin errores", "27/20/14", "Todas las observaciones posibles" };

            object[] res = { a, a1, a2, a3, a4};
            int rnd = random.Next(0, res.Length);
            return (object[])res[rnd];
        }

        public Tuple<DataTable,bool> GetTramitesAdvanced(ConsultaTableViewModel consultaParameters) 
        {
            Tuple<DataTable, bool> result = new Tuple<DataTable, bool>(GetTableTramites(), true);

            return result;
        }
        public Tuple<DataTable, bool> GetTramitesSimple(ConsultaTableViewModel consultaParameters)
        {
            Tuple<DataTable, bool> result = new Tuple<DataTable, bool>(GetTableTramites(), true);

            return result;
        }
        public Tuple<DataTable, bool> GetTramitesQuickly()
        {
            Tuple<DataTable, bool> result = new Tuple<DataTable, bool>(GetTableTramites(), true);

            return result;
        }
    
        public bool DeleteTramite(int id) 
        {
            bool result;
            try 
            {
                // Delete tramite
                return true;
            }
            catch 
            {
                // Save log error
                return false;
            }
        }
    }
}
