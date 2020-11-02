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

        Cn_Tramites _handlerTramites = new Cn_Tramites();
        Cn_Empleados _handlerEmpleados = new Cn_Empleados();
        Cn_Formularios _handlerFormularios = new Cn_Formularios();

        // Metodos
        private void Intialize() 
        {
            DataTramites.DisplayEmpleados(comboBox_empleados);
            currentDt = GetTramites(Cn_HandlerTramites.current);

            RefreshStockParameters();
            _handlerFormularios.RefreshDataDashboardCache();

            RefreshDashboard();
        }
        public void RefreshAll() 
        {
            RefreshData();
            RefreshDashboard();
        }
        private void RefreshData()
        {
            _handlerEmpleados.GenerateEmployeesDataCache();
            _handlerTramites.RefreshDataTramitesCache();
            _handlerTramites.RefreshDataDashboardCache();
            _handlerFormularios.RefreshDataFormulariosCache();
            _handlerFormularios.RefreshDataDashboardCache();

            Statistics.tmp = Cn_Employee.data.GetCache().GetUsers();
        }
        public void RefreshDashboard() 
        {
            chart_circle_diario.Series["Series1"].Points.Clear();
            chart_circle_mensual.Series["Series1"].Points.Clear();

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
            Label[] Hoy = { lbl_totaldiario_procesados, lbl_totaldiario_inscriptos };
            Label[] Mes = { lbl_totalmensual_procesados, lbl_totalmensual_inscriptos };

            Statistics.DashboardStatisticHoy(Hoy);
            lbl_totaldiarios.Text = lbl_totaldiario_procesados.Text;
            lbl_porcentaje_diario_procesados.Text = "100%";
            lbl_porcentaje_diario_inscriptos.Text = CalculatePercentage(Convert.ToInt32(lbl_totaldiarios.Text), Convert.ToInt32(lbl_totaldiario_inscriptos.Text)).ToString() + "%";
            chart_circle_diario.Series["Series1"].IsValueShownAsLabel = true;
            chart_circle_diario.Series["Series1"].Points.AddXY("Procesados", lbl_totaldiario_procesados.Text);
            chart_circle_diario.Series["Series1"].Points.AddXY("Inscriptos", lbl_totaldiario_inscriptos.Text);

            Statistics.DashboardStatisticMes(Mes);
            lbl_totalmensual.Text = lbl_totalmensual_procesados.Text;
            lbl_porcentaje_mensual_procesados.Text = "100%";
            lbl_porcentaje_mensual_inscriptos.Text = CalculatePercentage(Convert.ToInt32(lbl_totalmensual.Text), Convert.ToInt32(lbl_totalmensual_inscriptos.Text)).ToString() + "%";
            chart_circle_mensual.Series["Series1"].IsValueShownAsLabel = true;
            chart_circle_mensual.Series["Series1"].Points.AddXY("Procesados", lbl_totalmensual_procesados.Text);
            chart_circle_mensual.Series["Series1"].Points.AddXY("Inscriptos", lbl_totalmensual_inscriptos.Text);

            string[] series = { "Empleados" };
            chart_mensual_empleados.Series[series[0]].IsValueShownAsLabel = true;
            chart_mensual_empleados.Series[series[0]].Points.Clear();

            Statistics.DashboardChartEmployees(chart_mensual_empleados, series, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);

            Statistics.DisplayTopErrores(dg_topErrores, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
        }
        private double CalculatePercentage(int total, int value) 
        {
            float percentage = 0;
            if(total > 0 & value > 0) 
            {
                percentage = (value * 100) / total;
            }
            var vOut = Math.Round(percentage, 0);
            return vOut;
        }
        private bool ExportInformePdf(DataTable dt, string name)
        {
            string dia = DateTime.Now.Day + "-" + DateTime.Now.Month;
            string user = name + "_" + dia;

            bool result = DataSave.ExportToPdf(dt, user);

            return result;
        }
        private DataTable GetTramites(int id)
        {
            Tramites tmp = Cn_HandlerTramites.data.GetCache().GetCurrentTramites(id);
            DataTable table = tmp.data;
            //MessageBox.Show(table.Rows.Count.ToString());
            return table;
        }
        public void RefreshStockParameters()
        {
            Cn_HandlerFormularios.stockBajo = Settings.Default.StockBajo;
            Cn_HandlerFormularios.stockMedio = Settings.Default.StockMedio;
            Cn_HandlerFormularios.stockAlto = Settings.Default.StockAlto;
        }
        // Exportar Pdf Buttons
        private void btn_savepdf_stock_Click(object sender, EventArgs e)
        {
            DataTable dt = Cn_HandlerFormularios.data.GetCache().GetCurrentFormulario(Cn_HandlerFormularios.current).data;

            if (ExportInformePdf(dt, "InformeFORMULARIOS"))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }
        private void btn_savepdf_tramites_Click(object sender, EventArgs e)
        {
            if (ExportInformePdf(currentDt, "TramitesRNA"))
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

            DataTable dt = DataTramites.GetTableDate(DataTramites.GetDataTramitesTableWithID(id), Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
            if (ExportInformePdf(dt, user))
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
                frm_tramites_inscribir_mult frm = new frm_tramites_inscribir_mult(DateTime.Today, currentDt, null, this);
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

        private void frm_escritorio_Load(object sender, EventArgs e)
        {
            Intialize();
            cargarPrivilegios();
        }
        private void btn_refreshdata_Click(object sender, EventArgs e)
        {
            RefreshData();
            RefreshDashboard();
        }
        private void cargarPrivilegios()
        {
            if (UserLoginCache.Priveleges == Privileges.Estandar)
            {
                // Code here
                btn_inscribir.Enabled = false;
                btn_insertar.Enabled = false;
                btn_savepdf_empleado.Enabled = false;
            }
        }
    }
}
