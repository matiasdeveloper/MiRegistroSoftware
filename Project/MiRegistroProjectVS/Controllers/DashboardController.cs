using Guna.UI.WinForms;
using MiRegistro.Models;
using MiRegistro.Views;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class DashboardController
    {
        DashboardViewModel _model = new DashboardViewModel();
        Dashboard _view { get; set; }

        public DashboardController(Dashboard view)
        {
            _view = view;
            _view.Load += new EventHandler(LoadDashboard);
            _view.timer_timedate.Tick += new EventHandler(UpdateTimeDate);

            _view.btn_accionesrapidas_inscribir.Click += new EventHandler(OnClickAccionRapidaInscribir);
            _view.btn_accionesrapidas_insertar.Click += new EventHandler(OnClickAccionRapidaInsertar);
            _view.btn_accionesrapidas_stock.Click += new EventHandler(OnClickAccionRapidaStock);
        }

        private void OnClickAccionRapidaStock(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void OnClickAccionRapidaInsertar(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void OnClickAccionRapidaInscribir(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void UpdateTimeDate(object sender, EventArgs e)
        {
            _view.lbl_time.Text = DateTime.Now.ToString("HH:mm:ss");
            _view.lbl_date.Text = DateTime.Today.ToLongDateString();
        }

        void LoadDashboard(object sender, EventArgs e)
        {
            var tramitesMensual = _model.GetTramitesData(FechaModel.firstDayOfMonth, FechaModel.lastDayOfMonth);  // Get tramites month
            var dashboardTableModels = _model.GetStatisticModel(tramitesMensual);   // Get monthly and daily dashboard statistic model

            LoadPanel_1(dashboardTableModels);
            LoadPanel_4();
            // LoadPanel_5();
            LoadPanel_6(DateTime.Today, DateTime.Today.AddDays(1));
            LoadPanel_7();
            LoadPanel_8(DateTime.Today, DateTime.Today.AddDays(1));
            //LoadPanel_9();
        }
        void LoadPanel_1(DashboardTableViewModel[] dashboardTableModels)
        {
            // Panel preview

            _view.LoadDataPanel_01(dashboardTableModels[0].totalProcesado, dashboardTableModels[0].percentageDifference, _view.lbl_totalmensual, _view.pic_porcentajemensual, _view.lbl_porcentajemensual);
            _view.LoadDataPanel_01(dashboardTableModels[0].errores, dashboardTableModels[0].percentageDifferenceErrores, _view.lbl_totalerroresmensual, _view.pic_erroresmensual, _view.lbl_porcentajemensualerrores, true);
            
            _view.LoadDataPanel_01(dashboardTableModels[1].totalProcesado, dashboardTableModels[1].percentageDifference, _view.lbl_totaldiario, _view.pic_porcentajediario, _view.lbl_porcentajediario);
            _view.LoadDataPanel_01(dashboardTableModels[1].errores, dashboardTableModels[1].percentageDifferenceErrores, _view.lbl_totalerroresdiarios, _view.pic_erroresdiarios, _view.lbl_porcentajediarioerrores, true);   
        }

        void LoadPanel_4()
        {
            // Panel stock formularios

            int[] stockNegativo = { 10, 20, 3 }; // Todos los formularios stock negativo
            int stockNegativoTotal = 33;
            int stockTotal = 75; // Count stock total

            double percentage = Percentage.CalculateTotalPercentage(stockTotal, stockNegativoTotal);

            _view.LoadDataPanel_02(percentage, stockNegativoTotal, stockNegativo[0], stockNegativo[1]);
        }

        void LoadPanel_5() // Complete here
        {
            // Panel tramites chart

        }

        void LoadPanel_6(DateTime first, DateTime last)
        {
            // Panel top tramites

            // TramitesTableViewModel = ?

            _view.dg_toptramites.Rows.Add("1", "Matias", 150);
            _view.dg_toptramites.Rows.Add("2", "Noeli", 120);
            _view.dg_toptramites.Rows.Add("3", "Paola", 75);
            _view.dg_toptramites.Rows.Add("4", "Valeria", 10);
        }

        void LoadPanel_7()
        {
            // Panel top errores

            // ErroresTableViewModel = ?

            _view.dg_toperror.Rows.Add("1", "Matias", 120);
            _view.dg_toperror.Rows.Add("2", "Noeli", 50);
            _view.dg_toperror.Rows.Add("3", "Paola", 10);
            _view.dg_toperror.Rows.Add("4", "Valeria", 1);
        }

        void LoadPanel_8(DateTime firstDay, DateTime lastDay)
        {
            // Panel tramites progress
            int[] result = { 99, 75, 150, 75 }; //Statistics.GetStatisticTramites(first, last, true); 

            _view.LoadDataPanel_8(result);
        }

        void LoadPanel_9() // Complete here
        {
            // Panel empleados chart

        }
    }
}
