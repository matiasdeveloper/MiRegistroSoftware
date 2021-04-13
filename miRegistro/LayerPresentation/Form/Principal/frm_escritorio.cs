using LayerBusiness;
using LayerPresentation.Clases;
using LayerPresentation.Properties;
using LayerSoporte.Cache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayerPresentation
{
    public partial class frm_escritorio : Form
    {
        public frm_escritorio()
        {
            InitializeComponent();
        }

        DataTable currentDt = null;

        // Metodos
        private void Start()
        {
            InitializeForm();
            RefreshStockParameters();
            RefreshDesktopDashboard();
        }
        void InitializeForm()
        {
            DataTramites.DisplayEmpleados(comboBox_empleados);
            currentDt = DataTramites.data;
        }
        public void RefreshAll()
        {
            Utilities_Common.RefreshAllData();
            RefreshDesktopDashboard();
        }
        public void RefreshDesktopDashboard()
        {
            // Delete old registers in charts
            chart_circle_diario.Series["Series1"].Points.Clear();
            chart_circle_mensual.Series["Series1"].Points.Clear();

            // Charge data into the charts, labels and others
            ChargeDataTramites();
            ChargeDataFormularios();
        }

        private void ChargeDataFormularios()
        {
            lbl_stockalto.Text = Cn_HandlerFormularios.data.formularioCache.totalAltos.ToString();
            lbl_stockmedio.Text = Cn_HandlerFormularios.data.formularioCache.totalMedios.ToString();
            lbl_stockbajo.Text = Cn_HandlerFormularios.data.formularioCache.totalBajos.ToString();
        }
        private void ChargeDataTramites()
        {
            // Display All Information For Tramites

            Label[] Hoy = { lbl_totaldiario_procesados, lbl_totaldiario_inscriptos };
            Label[] Mes = { lbl_totalmensual_procesados, lbl_totalmensual_inscriptos };

            Statistics.DashboardStatisticHoy(Hoy);
            DisplayChartDiario();

            Statistics.DashboardStatisticMes(Mes);
            DisplayChartMensual();

            string[] series = { "Empleados" };
            chart_mensual_empleados.Series[series[0]].IsValueShownAsLabel = true;
            chart_mensual_empleados.Series[series[0]].Points.Clear();

            Statistics.DashboardChartEmployees(chart_mensual_empleados, series, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
            Statistics.DisplayTopErrores(dg_topErrores, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
        } 

        void DisplayChartDiario() 
        {
            lbl_totaldiarios.Text = lbl_totaldiario_procesados.Text;
            lbl_porcentaje_diario_procesados.Text = "100%";
            lbl_porcentaje_diario_inscriptos.Text = Utilities.CalculatePercentage(Convert.ToInt32(lbl_totaldiarios.Text), Convert.ToInt32(lbl_totaldiario_inscriptos.Text)).ToString() + "%";
            chart_circle_diario.Series["Series1"].IsValueShownAsLabel = true;
            chart_circle_diario.Series["Series1"].Points.AddXY("Procesados", lbl_totaldiario_procesados.Text);
            chart_circle_diario.Series["Series1"].Points.AddXY("Inscriptos", lbl_totaldiario_inscriptos.Text);
        }
        void DisplayChartMensual()
        {
            lbl_totalmensual.Text = lbl_totalmensual_procesados.Text;
            lbl_porcentaje_mensual_procesados.Text = "100%";
            lbl_porcentaje_mensual_inscriptos.Text = Utilities.CalculatePercentage(Convert.ToInt32(lbl_totalmensual.Text), Convert.ToInt32(lbl_totalmensual_inscriptos.Text)).ToString() + "%";
            chart_circle_mensual.Series["Series1"].IsValueShownAsLabel = true;
            chart_circle_mensual.Series["Series1"].Points.AddXY("Procesados", lbl_totalmensual_procesados.Text);
            chart_circle_mensual.Series["Series1"].Points.AddXY("Inscriptos", lbl_totalmensual_inscriptos.Text);
        }
        
        public void RefreshStockParameters()
        {
            Cn_HandlerFormularios.stockBajo = Settings.Default.StockBajo;
            Cn_HandlerFormularios.stockMedio = Settings.Default.StockMedio;
            Cn_HandlerFormularios.stockAlto = Settings.Default.StockAlto;
        }
        private void LoadAccesPrivileges()
        {
            if (UserLoginCache.Priveleges == Privileges.Estandar)
            {
                // Code here
                btn_inscribir.Enabled = false;
                btn_insertar.Enabled = false;
                btn_savepdf_empleado.Enabled = false;
            }
        }

        // Exportar Pdf Buttons
        private void btn_savepdf_stock_Click(object sender, EventArgs e)
        {
            DataTable dt = Cn_HandlerFormularios.data.GetCache().GetCurrentFormulario(Cn_HandlerFormularios.current).data;

            if (Utilites_Pdf.ExportDataTableInPdf(dt, "InformeFORMULARIOS"))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }
        private void btn_savepdf_tramites_Click(object sender, EventArgs e)
        {
            if (Utilites_Pdf.ExportDataTableInPdf(currentDt, "TramitesRNA"))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }
        private void btn_savepdf_empleado_Click(object sender, EventArgs e)
        {
            string empleado = comboBox_empleados.SelectedValue.ToString();
            int id = Convert.ToInt32(empleado);
            string user = comboBox_empleados.GetItemText(comboBox_empleados.SelectedItem);

            DataTable dt = DataTramites.GetTableDate(DataTramites.GetEmployeeDataTramites(id), Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
            if (Utilites_Pdf.ExportDataTableInPdf(dt, user))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }

        // Query buttons
        private void btn_query_mensual_Click(object sender, EventArgs e)
        {
            DataTable dt = QuerySpecific.myQuery("Mes", currentDt, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth, "", "", true);
            frm_tramites_pantallaCompleta mv = new frm_tramites_pantallaCompleta(1, "Todos mensual", DateTime.Now.Month.ToString(), dt, Fechas.firstDayOfMonth.ToShortDateString(), Fechas.lastDayOfMonth.ToShortDateString(),false, null, this);
            mv.Show();
        }
        private void btn_query_diaria_Click(object sender, EventArgs e)
        {
            DataTable dt = QuerySpecific.myQuery("Hoy", currentDt, DateTime.Now, DateTime.Now, "", "", true);
            frm_tramites_pantallaCompleta mv = new frm_tramites_pantallaCompleta(1, "Todos diario", DateTime.Now.Month.ToString(), dt, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString(), false, null, this);
            mv.Show();
        }
        private void btn_query_ayer_Click(object sender, EventArgs e)
        {
            DataTable dt = QuerySpecific.myQuery("Ayer", currentDt, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-1), "", "", true);
            frm_tramites_pantallaCompleta mv = new frm_tramites_pantallaCompleta(1, "Todos ayer", DateTime.Now.Month.ToString(), dt, DateTime.Now.AddDays(-1).ToShortDateString(), DateTime.Now.AddDays(-1).ToShortDateString(), false, null, this);
            mv.Show();
        }

        // Crud Buttons
        private void btn_inscribir_Click(object sender, EventArgs e)
        {
            if (checkBox_inscripto.Checked)
            {
                frm_tramites_inscribir_mult frm = new frm_tramites_inscribir_mult(DateTime.Today, null, this);
                frm.Show();
            }
        }
        private void btn_insertar_Click(object sender, EventArgs e)
        {
            string[] d = null;
            frm_tramites_insertar frm = new frm_tramites_insertar(false, 0, d);
            frm.Show();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lbl_hora.Text = DateTime.Now.ToString("HH:mm:ss");
            lbl_fecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btn_refreshdata_Click(object sender, EventArgs e)
        {
            Utilities_Common.RefreshAllData();
            RefreshDesktopDashboard();
        }

        // Load Windows Form
        private void frm_escritorio_Load(object sender, EventArgs e)
        {
            Start();
            LoadAccesPrivileges();
        }
    }
}
