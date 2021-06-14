using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class DashboardViewModel
    {
        public TramitesTableViewModel[] GetTramitesData(DateTime date1, DateTime date2) 
        {
            TramitesTableViewModel[] tramites = null; 
            
            // Get tramites in range date1 < x < date2

            return tramites;
        }

        public DashboardTableViewModel[] GetStatisticModel(TramitesTableViewModel[] tramites) 
        {
            List<DashboardTableViewModel> statistic = new List<DashboardTableViewModel>();

            StatisticModel _statisticModel = new StatisticModel();

            // Access to statistic model
            statistic.Add(_statisticModel.GetDashboardStatisticComplete(tramites, FechaModel.firstDayOfMonth, FechaModel.lastDayOfMonth, FechaModel.firstDayOfMonth.AddMonths(-1), FechaModel.lastDayOfMonth.AddMonths(-1))); // Add monthly statistic dashboard model
            statistic.Add(_statisticModel.GetDashboardStatisticComplete(tramites, FechaModel.dateNow, FechaModel.dateNow.AddDays(1), DateTime.Today, DateTime.Today)); // Add daily statistic dashboard model

            return statistic.ToArray();
        }
    }
}
