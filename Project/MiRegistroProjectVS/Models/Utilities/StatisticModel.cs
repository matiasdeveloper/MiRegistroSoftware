using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class StatisticModel
    {
        Random r = new Random();

        // Borrar al finalizar!!!
        /*
            DateTime firstActualMonth = FechaModel.firstDayOfMonth;
            DateTime lastActualMonth = FechaModel.lastDayOfMonth;

            DateTime firstPastMonth = FechaModel.firstDayOfMonth.AddMonths(-1);
            DateTime lastPastMonth = FechaModel.lastDayOfMonth.AddMonths(-1);

            DateTime dt1 = new DateTime(firstActualMonth.Year, firstActualMonth.Month, firstActualMonth.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(lastActualMonth.Year, lastActualMonth.Month, lastActualMonth.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            DateTime dt1_past = new DateTime(firstPastMonth.Year, firstPastMonth.Month, firstPastMonth.Day, 0, 0, 0);
            DateTime dt2_past = new DateTime(lastPastMonth.Year, lastPastMonth.Month, lastPastMonth.Day, 0, 0, 0);
            dt2_past = dt2_past.AddDays(1);

         */
        /*Tramites dt = Cn_HandlerTramites.data.tramitesCache.GetCurrentTramites(Cn_HandlerTramites.current);
            foreach (DataRow fila in dt.data.Rows)
            {
                DateTime date = (DateTime)fila[5];
                if (date >= dt1_past && date < dt2_past)
                {
                    procesado_past++;
                    if ((bool)fila[6] == true)
                    {
                        errores_past++;
                    }
                }
                if (date >= dt1 & date < dt2)
                {
                    procesado++;
                    if ((bool)fila[6] == true)
                    {
                        errores++;
                    }
                }
            }*/

        // Return DashboardTableViewModel with calculate variables.
        public DashboardTableViewModel GetDashboardStatisticComplete(TramitesTableViewModel[] tramites, DateTime firstDate, DateTime lastDate, DateTime firstPastDate, DateTime lastPastDate)
        {
            DashboardTableViewModel dashboardModel = new DashboardTableViewModel();

            dashboardModel.totalProcesado = r.Next(50,200); dashboardModel.totalProcesadoPast = 50;
            dashboardModel.errores = r.Next(2,8); dashboardModel.erroresPast = 2;

            // Find dashboard table view model parameters

            dashboardModel.percentageDifference = Convert.ToSingle(Percentage.CalculateDifferencePercentage(dashboardModel.totalProcesado, dashboardModel.totalProcesadoPast));
            dashboardModel.percentageDifferenceErrores = Convert.ToSingle(Percentage.CalculateDifferencePercentage(dashboardModel.errores, dashboardModel.erroresPast));

            return dashboardModel;
        }
    }
}
