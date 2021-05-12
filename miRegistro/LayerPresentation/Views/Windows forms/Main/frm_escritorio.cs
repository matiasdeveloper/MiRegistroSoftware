using LayerPresentation.Clases;
using LayerPresentation.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.Lib;
using Bunifu.Framework.UI;

namespace LayerPresentation
{
    public partial class frm_escritorio : Form
    {
        public frm_escritorio()
        {
            InitializeComponent();
        }
        protected Image[] images = { Properties.Resources.r_positive, Properties.Resources.r_negative };
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
            //currentDt = DataTramites.data;
        }
        public void RefreshAll()
        {
            //UtilitiesCommon.RefreshAllData();
            RefreshDesktopDashboard();
        }
        public void RefreshDesktopDashboard()
        {
            // Delete old registers in charts
            //chart_circle_diario.Series["Series1"].Points.Clear();
            //chart_circle_mensual.Series["Series1"].Points.Clear();

            // Charge data into the charts, labels and others
            //ChargeDataTramites();
            //ChargeDataFormularios();

            /*LoadPanel_1();
            LoadPanel_2();
            LoadPanel_3();
            LoadPanel_4();
            LoadPanel_8();
            LoadPanel_9();
            LoadPanel_10();*/
        }
        void LoadPanel_1()
        {
            // Load data from tramites
            /*float[] month = Statistics.GetDashboardStatistic_MonthComplete();
            float[] day = Statistics.GetDashboardStatistic_DayComplete();

            LoadDataPanel_01(month[0], month[1], lbl_totalmensual, pic_porcentajemensual, lbl_porcentajemensual);
            LoadDataPanel_01(month[2], month[3], lbl_totalerroresmensual, pic_erroresmensual, lbl_porcentajemensualerrores, true);
            LoadDataPanel_01(day[0], day[1], lbl_totaldiario, pic_porcentajediario, lbl_porcentajediario);
            LoadDataPanel_01(day[2], day[3], lbl_totalerroresdiarios, pic_erroresdiarios, lbl_porcentajediarioerrores, true);
        */}
        void LoadDataPanel_01(float total, float percentage, Label lbl, PictureBox pic, Label per, bool isError = false)
        {
            lbl.Text = total.ToString();
            if (percentage >= 0.0)
            {
                if (isError)
                {
                    per.Text = "+" + percentage.ToString("0.00") + "%";
                    pic.BackgroundImage = images[1];
                    per.ForeColor = ColorController.GetNegative();
                } else 
                {
                    per.Text = "+" + percentage.ToString("0.00") + "%";
                    pic.BackgroundImage = images[0];
                    per.ForeColor = ColorController.GetPositive();
                }
            }
            else if (percentage < 0)
            {
                if (isError)
                {
                    per.Text = percentage.ToString("0.00") + "%";
                    pic.BackgroundImage = images[0];
                    per.ForeColor = ColorController.GetPositive();
                }
                else 
                {
                    per.Text = percentage.ToString("0.00") + "%";
                    pic.BackgroundImage = images[1];
                    per.ForeColor = ColorController.GetNegative();
                }
            }
            else
            {
                per.Text = "+" + "0" + "%";
                pic.BackgroundImage = images[0];
                per.ForeColor = ColorController.GetPositive();
            }
        }

        void LoadPanel_2()
        {
            // Load data from stock bajos
            /*int autos = DataFormularios.CountStockForElement("Auto");
            int motos = DataFormularios.CountStockForElement("Moto");
            int varios = DataFormularios.CountStockForElement("Varios");

            lbl_stockbajo.Text = (autos + motos + varios).ToString();
            lbl_stockbajo_autos.Text = autos.ToString();
            lbl_stockbajo_motos.Text = motos.ToString();

            //int total = (Cn_HandlerFormularios.data.formularioCache.totalAltos + Cn_HandlerFormularios.data.formularioCache.totalMedios + Cn_HandlerFormularios.data.formularioCache.totalBajos);

            //LoadDataPanel_02(total, (autos + motos + varios), chart_progress_stock);
        
            */
        }
        private void LoadDataPanel_02(int total, int stockbajo, BunifuCircleProgressbar chartProgress)
        {
            int v = (int)Math.Round(UtilitiesCommon.CalculatePercentage(total, stockbajo), MidpointRounding.AwayFromZero);
            chartProgress.Value = v;
            lbl_stockbajo_percentage.Text = v.ToString() + "%";
        }

        void LoadPanel_3()
        {
            BunifuProgressBar[] progress_bar = { progress_procesados, progress_inscriptos };
            Label[] text_progress = { lbl_porcentaje_procesados, lbl_porcentaje_inscriptos };

            //LoadDataPanel_03(Fechas.dateNow, Fechas.dateNow, progress_bar, text_progress);
        }
        private void LoadDataPanel_03(DateTime first, DateTime last, BunifuProgressBar[] progressbars, Label[] progresstexts)
        {
            /*
            int[] result = Statistics.GetStatisticTramites(first, last, true);
            progressbars[0].Value = result[2];
            progressbars[1].Value = result[3];
            progresstexts[0].Text = result[2].ToString() + "%";
            progresstexts[1].Text = result[3].ToString() + "%";
            lbl_procesados.Text = result[0].ToString();
            lbl_inscriptos.Text = result[1].ToString();*/
        }

        void LoadPanel_4()
        {
            //LoadDataPanel_04(Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
        }
        private void LoadDataPanel_04(DateTime first, DateTime last)
        {
            string[] series = { "Empleados" };
            chart_tramitesempleados.Series[series[0]].Points.Clear();

            //Statistics.LoadChartEmployee(chart_tramitesempleados, series, first, last);
        }

        void LoadPanel_8()
        {
            dg_toperror.Rows.Add("1", "Matias", 120);
            dg_toperror.Rows.Add("2", "Noeli", 50);
            dg_toperror.Rows.Add("3", "Paola", 10);
            dg_toperror.Rows.Add("4", "Valeria", 1);
        }
        void LoadPanel_9()
        {
           //LoadDataPanel_09("Mes", "Procesados", Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
        }
        private void LoadDataPanel_09(string rangeDispose, string etapa, DateTime dt1, DateTime dt2)
        {
            /*switch (rangeDispose) 
            {
                case "Mes":
                    Statistics.LoadChartDetails(chart_tramites, rangeDispose, etapa, "Series1", Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
                    break;
                case "Año":
                    Statistics.LoadChartDetails(chart_tramites, rangeDispose, etapa, "Series1", Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
                    break;
            }*/
        }
        void LoadPanel_10()
        {
            dg_toptramites.Rows.Add("1", "Matias", 120);
            dg_toptramites.Rows.Add("2", "Noeli", 50);
            dg_toptramites.Rows.Add("3", "Paola", 10);
            dg_toptramites.Rows.Add("4", "Valeria", 1);
        }


        private void ChargeDataTramites()
        {
            //Label[] Hoy = { lbl_total_procesados, lbl_total_inscriptos };
            //Label[] Mes = { lbl_totalmensual_procesados, lbl_totalmensual_inscriptos };

            //Statistics.DashboardStatisticHoy(Hoy);
            //DisplayChartDiario();

            //Statistics.DashboardStatisticMes(Mes);
            //DisplayChartMensual();

            //Statistics.DisplayTopErrores(dg_toperror, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
        } 
        void DisplayChartDiario() 
        {
            //lbl_totaldiario.Text = lbl_total_procesados.Text;
            lbl_porcentaje_procesados.Text = "100%";
            //lbl_porcentaje_inscriptos.Text = Utilities.CalculatePercentage(Convert.ToInt32(lbl_totaldiario.Text), Convert.ToInt32(lbl_total_inscriptos.Text)).ToString() + "%";
            //chart_circle_diario.Series["Series1"].Points.AddXY("Procesados", lbl_total_procesados.Text);
            //chart_circle_diario.Series["Series1"].Points.AddXY("Inscriptos", lbl_total_inscriptos.Text);
        }
        void DisplayChartMensual()
        {
            /*lbl_totalmensual.Text = lbl_totalmensual_procesados.Text;
            lbl_porcentaje_mensual_procesados.Text = "100%";
            lbl_porcentaje_mensual_inscriptos.Text = Utilities.CalculatePercentage(Convert.ToInt32(lbl_totalmensual.Text), Convert.ToInt32(lbl_totalmensual_inscriptos.Text)).ToString() + "%";
            chart_circle_mensual.Series["Series1"].IsValueShownAsLabel = true;
            chart_circle_mensual.Series["Series1"].Points.AddXY("Procesados", lbl_totalmensual_procesados.Text);
            chart_circle_mensual.Series["Series1"].Points.AddXY("Inscriptos", lbl_totalmensual_inscriptos.Text);*/
        }
        
        public void RefreshStockParameters()
        {
           /* Cn_HandlerFormularios.stockBajo = Settings.Default.StockBajo;
            Cn_HandlerFormularios.stockMedio = Settings.Default.StockMedio;
            Cn_HandlerFormularios.stockAlto = Settings.Default.StockAlto;*/
        }
        private void LoadAccesPrivileges()
        {
            /*if (UserLoginCacheOld.Priveleges == Privileges.Estandar)
            {
                // Code here
                btn_accionesrapidas_insertart.Enabled = false;
                btn_accionesrapidas_inscribirt.Enabled = false;
            }*/
        }

        // Exportar Pdf Buttons
        private void btn_savepdf_stock_Click(object sender, EventArgs e)
        {
            //DataTable dt = Cn_HandlerFormularios.data.GetCache().GetCurrentFormulario(Cn_HandlerFormularios.current).data;

            /*if (PdfExporter.ExportDataTableInPdf(dt, "InformeFORMULARIOS"))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }*/
        }
        private void btn_savepdf_tramites_Click(object sender, EventArgs e)
        {
            if (PdfExporter.ExportDataTableInPdf(currentDt, "TramitesRNA"))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }

        /* Query buttons
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
        */

        // Acciones rapidas (Panel 05)
        private void btn_accionesrapidas_consulta_Click(object sender, EventArgs e)
        {
            /*DataTable dt = QuerySpecific.myQuery("Hoy", currentDt, DateTime.Now, DateTime.Now, "", "", true);
            frm_tramites_pantallaCompleta mv = new frm_tramites_pantallaCompleta(1, "Todos diario", DateTime.Now.Month.ToString(), dt, DateTime.Now.ToShortDateString(), DateTime.Now.ToShortDateString(), false, null, this);
            mv.Show();*/
        }
        private void btn_accionesrapidas_stock_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable(); // create dt

            if (PdfExporter.ExportDataTableInPdf(dt, "InformeFORMULARIOS"))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }
        private void btn_accionesrapidas_insertart_Click(object sender, EventArgs e)
        {
            //string[] d = null;
            frm_tramites_insertar frm = new frm_tramites_insertar();
            frm.Show();
        }
        private void btn_accionesrapidas_inscribirt_Click(object sender, EventArgs e)
        {
            frm_tramites_inscribir_mult frm = new frm_tramites_inscribir_mult(DateTime.Today, null, this);
            frm.Show();
        }
        // Buttons Chart Panel 09
        private void btn_chart_tramitesinscriptos_Click(object sender, EventArgs e)
        {
            btn_chart_tramitesfinalizados.IdleForecolor = System.Drawing.Color.LightGray;
            btn_chart_tramitesprocesados.IdleForecolor = System.Drawing.Color.LightGray;
            btn_chart_tramitesinscriptos.IdleForecolor = System.Drawing.Color.FromArgb(1, 171, 65, 43);
        }
        private void btn_chart_tramitesprocesados_Click(object sender, EventArgs e)
        {
            btn_chart_tramitesfinalizados.IdleForecolor = System.Drawing.Color.LightGray;
            btn_chart_tramitesprocesados.IdleForecolor = System.Drawing.Color.FromArgb(1, 171, 65, 43);
            btn_chart_tramitesinscriptos.IdleForecolor = System.Drawing.Color.LightGray;
        }
        private void btn_chart_tramitesfinalizados_Click(object sender, EventArgs e)
        {
            btn_chart_tramitesfinalizados.IdleForecolor = System.Drawing.Color.FromArgb(1, 171, 65, 43);
            btn_chart_tramitesprocesados.IdleForecolor = System.Drawing.Color.LightGray;
            btn_chart_tramitesinscriptos.IdleForecolor = System.Drawing.Color.LightGray;
        }

        // Comboxs OnSelected
        private void cb_tramitesempleados_onItemSelected(object sender, EventArgs e)
        {
           /* // Panel 04
            switch (cb_tramitesempleados.SelectedValue.ToString())
            {
                case "1 año":
                    int year = DateTime.Now.Year;
                    DateTime firstDay = new DateTime(year, 1, 1);
                    DateTime lastDay = new DateTime(year, 12, 31);
                    LoadDataPanel_04(firstDay, lastDay);
                    break;
                case "1 semana":
                    LoadDataPanel_04(Fechas.firstDayOfWeek, Fechas.lastDayOfWeek);
                    break;
                case "1 mes":
                    LoadDataPanel_04(Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
                    break;
                case "1 mes ant.":
                    LoadDataPanel_04(Fechas.firstDayOfMonth.AddMonths(-1), Fechas.lastDayOfMonth.AddMonths(-1));
                    break;
                case "1 dia":
                    LoadDataPanel_04(Fechas.dateNow, Fechas.dateNow);
                    break;
                default:
                    LoadDataPanel_04(Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
                    break;
            }*/
        }

        private void cb_tramites_onItemSelected(object sender, EventArgs e)
        {
          /*  BunifuProgressBar[] progress_bar = { progress_procesados, progress_inscriptos };
            Label[] text_progress = { lbl_porcentaje_procesados, lbl_porcentaje_inscriptos };

            // Panel 03
            switch (cb_tramites.SelectedValue.ToString())
            {
                case "1 año":
                    int year = DateTime.Now.Year;
                    DateTime firstDay = new DateTime(year, 1, 1);
                    DateTime lastDay = new DateTime(year, 12, 31);
                    LoadDataPanel_03(firstDay, lastDay, progress_bar, text_progress);
                    break;
                case "1 semana":
                    LoadDataPanel_03(Fechas.firstDayOfWeek, Fechas.lastDayOfWeek, progress_bar, text_progress);
                    break;
                case "1 mes":
                    LoadDataPanel_03(Fechas.firstDayOfMonth, Fechas.lastDayOfMonth, progress_bar, text_progress);
                    break;
                case "1 mes ant.":
                    LoadDataPanel_03(Fechas.firstDayOfMonth.AddMonths(-1), Fechas.lastDayOfMonth.AddMonths(-1), progress_bar, text_progress);
                    break;
                case "1 dia":
                    LoadDataPanel_03(Fechas.dateNow, Fechas.dateNow, progress_bar, text_progress);
                    break;
                default:
                    LoadDataPanel_03(Fechas.firstDayOfMonth, Fechas.lastDayOfMonth, progress_bar, text_progress);
                    break;
            }*/
        }
        private void cb_tramites_chart_onItemSelected(object sender, EventArgs e)
        {
            // Panel 09 Load Data Chart
            switch (cb_tramites.SelectedValue.ToString())
            {
                case "1 año":
                    int year = DateTime.Now.Year;
                    DateTime firstDay = new DateTime(year, 1, 1);
                    DateTime lastDay = new DateTime(year, 12, 31);
                    break;
                case "1 semana":
                    break;
                case "1 mes":
                    break;
                case "1 mes ant.":
                    break;
                case "1 dia":
                    break;
                default:
                    break;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_time.Text = DateTime.Now.ToString("HH:mm:ss");
            lbl_date.Text = DateTime.Now.ToLongDateString();
        }

        private void btn_refreshdata_Click(object sender, EventArgs e)
        {
            //UtilitiesCommon.RefreshAllData();
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
