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
            tabControl.SelectedIndex = 1;
        }

        DateTime dateNow = DateTime.Now;
        
        public void RefreshDashboardData() 
        {
            ClearCharts();

            LoadStatisticTramites();
            LoadStatisticErrors();
        }
        private void ClearCharts() 
        {
            chart_tramites.Series["Total tramites"].Points.Clear();
            chart_tramites.Series["Procesados"].Points.Clear();
            chart_tramites.Series["Inscriptos"].Points.Clear();

            chart_errores.Series["Total errores"].Points.Clear();
            chart_errores.Series["Parciales"].Points.Clear();
            chart_errores.Series["Totales"].Points.Clear();
        }
        private void LoadStatisticErrors()
        {            
            // Historic
            Label[] ErroresHoy = { lbl_totalerrores_dia, lbl_totalerrores_parcial_dia, lbl_totalerrores_total_dia};
            Label[] ErroresMes = { lbl_totalerrores_mes, lbl_totalerrores_parcial_mes, lbl_totalerrores_total_mes }; ;
            Label[] ErroresHist = { lbl_totalerrores_hist, lbl_totalerrores_parcial_hist, lbl_totalerrores_total_hist }; ;
            Statistics.DashboardStatisticErrores(ErroresHoy, ErroresMes, ErroresHist);

            // Quickly
            Label[] names = GetLabelArray("lbl_name", 9);
            Label[] errores = GetLabelArray("lbl_countErrores", 9);
            Label[] erroresParciales = GetLabelArray("lbl_errorParcial_", 9);
            Label[] erroresTotales = GetLabelArray("lbl_errorTotal_", 9);

            Panel[] panels = { panelError_user_0, panelError_user_1, panelError_user_2, panelError_user_3, panelError_user_4, panelError_user_5, panelError_user_6, panelError_user_7, panelError_user_8 };
            
            Statistics.DisplayNames(names);
            Statistics.DisplayErrores(errores, erroresParciales, erroresTotales, panels);

            Statistics.DisplayTopErrores(dg_topErrores, dateNow.AddYears(-50), dateNow.AddYears(50));
            
            #region CHART
            string[] series = { "Total errores", "Parciales", "Totales" };
            Statistics.DashboardChartEmployeesErrores(chart_errores, series, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
            #endregion
        }

        /// <summary>
        /// Find all of label into the current form with specific names
        /// </summary>
        /// <param name="labelName"></param>
        /// <param name="total"></param>
        private Label[] GetLabelArray(string labelName, int total) 
        {
            List<Label> lbl = new List<Label>();

            for(int i = 0; i < total; i++) 
            {
                try 
                {
                    lbl.Add(UtilitiesCommon.FindLabelInForm(this, String.Format(labelName + i)));
                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex);
                }
            }

            return lbl.ToArray();
        }

        private void LoadStatisticTramites()
        {
            // Historic
            Label[] lblHist = { lbl_totaltramites, lbl_totalprocesados, lbl_totalinscriptos, lbl_totalerrores, lbl_totalempleados, lbl_totaltipos };
            Statistics.DashboardStatisticHistory(lblHist);
            
            // Quickly
            Label[] Ayer = { lbl_parcialprocesados_ayer, lbl_parcialinscriptos_ayer };
            Label[] Hoy = { lbl_parcialprocesados_dia, lbl_parcialinscriptos_dia };
            Label[] Mes = { lbl_parcialprocesados_mes, lbl_parcialinscriptos_mes };

            Statistics.DashboardStatisticAyer(Ayer);
            Statistics.DashboardStatisticHoy(Hoy);
            Statistics.DashboardStatisticMes(Mes);

            // Specific
            Label[] names_inscriptosMes = GetLabelArray("lblnombreinscriptos_", 9);
            Label[] names_procesadosMes = GetLabelArray("lblnombre_", 9);
            Label[] count_inscriptosMes = GetLabelArray("lbl_countInscriptos_", 9);
            Label[] count_procesadosMes = GetLabelArray("lbl_countProcesados_", 9);

            Statistics.DisplayNames(names_inscriptosMes);
            Statistics.DisplayNames(names_procesadosMes);
            Statistics.DisplayEtapas(count_inscriptosMes, count_procesadosMes);
            
            Statistics.DisplayTopTramites(dg_topTramites);

            #region CHART
            string[] series = { "Total tramites", "Procesados", "Inscriptos" };
            Statistics.LoadChartEmployee(chart_tramites, series, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth, false);
            #endregion
        }
        
        private void btn_top_Click(object sender, EventArgs e)
        {
            int id = (int)dg_topTramites.SelectedRows[0].Cells[0].Value;
            string empleado = (string)dg_topTramites.SelectedRows[0].Cells[1].Value.ToString();
            string mes = dateNow.Month.ToString();
            DataTable dt = null;
            dt = DataTramites.GetEmployeeDataTramites(id);
            
            frm_tramites_pantallaCompleta mv = new frm_tramites_pantallaCompleta(id, empleado, mes, dt, Fechas.firstDayOfMonth.ToShortDateString(), Fechas.lastDayOfMonth.ToShortDateString(), true, this);
            mv.Show();
        }
        private void btn_toperror_Click_1(object sender, EventArgs e)
        {
            int id = (int)dg_topErrores.SelectedRows[0].Cells[0].Value;
            string empleado = (string)dg_topErrores.SelectedRows[0].Cells[1].Value.ToString();
            string mes = dateNow.Month.ToString();

            DataTable dt = null;
            dt = DataTramites.GetEmployeeDataTramites(id);

            frm_tramites_pantallaCompleta mv = new frm_tramites_pantallaCompleta(id, empleado, mes, dt, Fechas.firstDayOfMonth.ToShortDateString(), Fechas.lastDayOfMonth.ToShortDateString(), true, this);
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
        private void btn_refreshdata_Click(object sender, EventArgs e)
        {
            //UtilitiesCommon.RefreshStatisticData();
            RefreshDashboardData();
        }

        private void frm_estadisticas_Load(object sender, EventArgs e)
        {
            //Statistics.tmp = Cn_Employee.data.GetCache().GetUsers();
            RefreshDashboardData();
        }
    }
}
