using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using LayerBusiness;
using LayerPresentation.Clases;
using LayerSoporte.Cache;

namespace LayerPresentation
{
    public partial class frm_estadisticas : Form
    {
        public frm_estadisticas()
        {
            InitializeComponent();
        }

        Cn_Tramites _handlerTramites = new Cn_Tramites();
        Cn_Empleados _handlerEmpleados = new Cn_Empleados();

        DateTime dateNow = DateTime.Now;
        
        public void refreshDashboard() 
        {
            chart_tramites.Series["Total tramites"].Points.Clear();
            chart_tramites.Series["Procesados"].Points.Clear();
            chart_tramites.Series["Inscriptos"].Points.Clear();

            chart_errores.Series["Total errores"].Points.Clear();
            chart_errores.Series["Parciales"].Points.Clear();
            chart_errores.Series["Totales"].Points.Clear();

            chargeDataTabTramites();
            chargeDataTabErrores();
        }
        private void refreshData() 
        {
            _handlerEmpleados.GenerateEmployeesDataCache();
            _handlerTramites.RefreshDataDashboardCache();

            Statistics.tmp = Cn_Employee.data.GetCache().GetUsers();
        }
        private void chargeDataTabErrores()
        {
            Label[] ErroresHoy = { lbl_totalerrores_dia, lbl_totalerrores_parcial_dia, lbl_totalerrores_total_dia};
            Label[] ErroresMes = { lbl_totalerrores_mes, lbl_totalerrores_parcial_mes, lbl_totalerrores_total_mes }; ;
            Label[] ErroresHist = { lbl_totalerrores_hist, lbl_totalerrores_parcial_hist, lbl_totalerrores_total_hist }; ;

            Statistics.DashboardStatisticErrores(ErroresHoy, ErroresMes, ErroresHist);

            Label[] names = { lbl_name0, lbl_name1, lbl_name2, lbl_name3, lbl_name4, lbl_name5, lbl_name6, lbl_name7, lbl_name8 };
            Label[] errores = { lbl_countErrores0, lbl_countErrores1, lbl_countErrores2, lbl_countErrores3, lbl_countErrores4, lbl_countErrores5, lbl_countErrores6, lbl_countErrores7, lbl_countErrores8 };
            Label[] erroresparciales = { lbl_errorParcial_0, lbl_errorParcial_1, lbl_errorParcial_2, lbl_errorParcial_3, lbl_errorParcial_4, lbl_errorParcial_5, lbl_errorParcial_6, lbl_errorParcial_7, lbl_errorParcial_8 };
            Label[] errorestotales = { lbl_errorTotal_0, lbl_errorTotal_1, lbl_errorTotal_2, lbl_errorTotal_3, lbl_errorTotal_4, lbl_errorTotal_5, lbl_errorTotal_6, lbl_errorTotal_7, lbl_errorTotal_8 };
            Panel[] paneles = { panelError_user_0, panelError_user_1, panelError_user_2, panelError_user_3, panelError_user_4, panelError_user_5, panelError_user_6, panelError_user_7, panelError_user_8 };
            
            Statistics.DisplayNames(names);
            Statistics.DisplayErrores(errores, erroresparciales, errorestotales, paneles);

            Statistics.DisplayTopErrores(dg_topErrores, dateNow.AddYears(-50), dateNow.AddYears(50));
            #region CHART
            string[] series = { "Total errores", "Parciales", "Totales" };
            Statistics.DashboardChartEmployeesErrores(chart_errores, series, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
            #endregion
        }

        private void chargeDataTabTramites()
        {
            Label[] lblHist = { lbl_totaltramites, lbl_totalprocesados, lbl_totalinscriptos, lbl_totalerrores, lbl_totalempleados, lbl_totaltipos };
            Statistics.DashboardStatisticHistory(lblHist);

            Label[] Ayer = { lbl_parcialprocesados_ayer, lbl_parcialinscriptos_ayer };
            Label[] Hoy = { lbl_parcialprocesados_dia, lbl_parcialinscriptos_dia };
            Label[] Mes = { lbl_parcialprocesados_mes, lbl_parcialinscriptos_mes };

            Statistics.DashboardStatisticAyer(Ayer);
            Statistics.DashboardStatisticHoy(Hoy);
            Statistics.DashboardStatisticMes(Mes);

            Label[] names_inscriptosMes = { lblnombreinscriptos_0 , lblnombreinscriptos_1, lblnombreinscriptos_2 , lblnombreinscriptos_3 , lblnombreinscriptos_4, lblnombreinscriptos_5, lblnombreinscriptos_6, lblnombreinscriptos_7, lblnombreinscriptos_8};
            Label[] names_procesadosMes = { lblnombre_0, lblnombre_1, lblnombre_2, lblnombre_3, lblnombre_4, lblnombre_5, lblnombre_6, lblnombre_7, lblnombre_8 };
            Label[] count_inscriptosMes = { lbl_countInscriptos_0, lbl_countInscriptos_1, lbl_countInscriptos_2, lbl_countInscriptos_3, lbl_countInscriptos_4, lbl_countInscriptos_5, lbl_countInscriptos_6, lbl_countInscriptos_7, lbl_countInscriptos_8 };
            Label[] count_procesadosMes = { lbl_countProcesados_0, lbl_countProcesados_1, lbl_countProcesados_2, lbl_countProcesados_3, lbl_countProcesados_4, lbl_countProcesados_5, lbl_countProcesados_6, lbl_countProcesados_7, lbl_countProcesados_8 };

            Statistics.DisplayNames(names_inscriptosMes);
            Statistics.DisplayNames(names_procesadosMes);
            Statistics.DisplayEtapas(count_inscriptosMes, count_procesadosMes);
            
            Statistics.DisplayTopTramites(dg_topTramites);

            #region CHART
            string[] series = { "Total tramites", "Procesados", "Inscriptos" };
            Statistics.DashboardChartEmployees(chart_tramites, series, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth, false);
            #endregion
        }
        
        private void btn_top_Click(object sender, EventArgs e)
        {
            int id = (int)dg_topTramites.SelectedRows[0].Cells[0].Value;
            string empleado = (string)dg_topTramites.SelectedRows[0].Cells[1].Value.ToString();
            string mes = dateNow.Month.ToString();
            DataTable dt = null;
            dt = DataTramites.GetDataTramitesTableWithID(id);
            int[] tramites = Statistics.FindTramites(empleado, dt, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
            int[] errores = Statistics.FindErrores(empleado, dt, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
            
            frm_tramites_pantallaCompleta mv = new frm_tramites_pantallaCompleta(id, empleado, mes, dt, errores, tramites, Fechas.firstDayOfMonth.ToShortDateString(), Fechas.lastDayOfMonth.ToShortDateString(), true, this);
            mv.Show();
        }
        private void btn_toperror_Click_1(object sender, EventArgs e)
        {
            int id = (int)dg_topErrores.SelectedRows[0].Cells[0].Value;
            string empleado = (string)dg_topErrores.SelectedRows[0].Cells[1].Value.ToString();
            string mes = dateNow.Month.ToString();

            DataTable dt = null;
            dt = DataTramites.GetDataTramitesTableWithID(id);
            
            int[] tramites = Statistics.FindTramites(empleado, dt, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
            int[] errores = Statistics.FindErrores(empleado, dt, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);

            frm_tramites_pantallaCompleta mv = new frm_tramites_pantallaCompleta(id, empleado, mes, dt, errores, tramites, Fechas.firstDayOfMonth.ToShortDateString(), Fechas.lastDayOfMonth.ToShortDateString(), true, this);
            mv.Show();
        }

        private void dg_topTramites_SelectionChanged(object sender, EventArgs e)
        {
            if(dg_topTramites.SelectedRows.Count != 0) 
            {
                txtBox_empleado.Text = this.dg_topTramites.SelectedRows[0].Cells["Empleado1"].Value.ToString();
            }
        }
        private void dg_topErrores_SelectionChanged(object sender, EventArgs e)
        {
            if (dg_topErrores.SelectedRows.Count != 0)
            {
                textBox1.Text = this.dg_topErrores.SelectedRows[0].Cells["Empleado"].Value.ToString();
            }
        }       
        private void timer1_Tick(object sender, EventArgs e)
        {
            txtBox_fecha.Text = DateTime.Now.ToString();
        }
        private void btn_refreshdata_Click(object sender, EventArgs e)
        {
            refreshData();
            refreshDashboard();
        }

        private void frm_estadisticas_Load(object sender, EventArgs e)
        {
            Statistics.tmp = Cn_Employee.data.GetCache().GetUsers();
            refreshDashboard();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chart_tramites_Click(object sender, EventArgs e)
        {

        }
    }
}
