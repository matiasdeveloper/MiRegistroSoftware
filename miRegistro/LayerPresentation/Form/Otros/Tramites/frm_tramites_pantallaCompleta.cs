using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LayerBusiness;
using LayerPresentation.Clases;
using LayerSoporte.Cache;

namespace LayerPresentation
{
    public partial class frm_tramites_pantallaCompleta : Form
    {
        // Move form with mouse down in bar
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public frm_tramites_pantallaCompleta(int id, string empleado, string mes, DataTable dt, string desde, string hasta, bool isStatistics = true, frm_estadisticas frmStatistic = null, frm_escritorio frmEscritorio = null)
        {
            InitializeComponent();

            this._frmStatistics = frmStatistic;
            this._frmEscritorio = frmEscritorio;

            this.id = id;
            this.empleado = empleado;
            this.mes = mes;
            this.data = dt;
            this.isStatistics = isStatistics;

            lbl_desde.Text = desde;
            lbl_hasta.Text = hasta;

            InitializeData();
        }

        // Variables
        frm_escritorio _frmEscritorio;
        frm_estadisticas _frmStatistics;

        private bool isStatistics;
        private int id;
        private string empleado;
        private string mes;
        private DataTable data;
        private int selectedId = 0;

        private void InitializeData() 
        {
            dg_tramites.DataSource = null;

            dg_tramites.AutoGenerateColumns = false;
            dg_tramites.DataSource = DataTramites.GetTableDate(data, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);

            if (isStatistics) 
            {
                lbl_id.Text = id.ToString();
                lbl_mes.Text = mes;
                lbl_user.Text = empleado;
            } 
            else 
            {
                lbl_id.Text = id.ToString();
                lbl_mes.Text = mes;
                lbl_user.Text = empleado;
            }
        }
        
        // Get data from selected index in datagrid
        private string[] GetDataFromSelectedIndex()
        {
            selectedId = Convert.ToInt32(dg_tramites.CurrentRow.Cells["Id1"].Value); ;
            string[] data = new string[8];

            data[0] = dg_tramites.CurrentRow.Cells["Dominio"].Value.ToString();
            data[1] = dg_tramites.CurrentRow.Cells["Tramite"].Value.ToString();
            data[2] = dg_tramites.CurrentRow.Cells["Empleado1"].Value.ToString();
            data[3] = dg_tramites.CurrentRow.Cells["Etapa"].Value.ToString();
            data[4] = dg_tramites.CurrentRow.Cells["Error"].Value.ToString();
            data[5] = dg_tramites.CurrentRow.Cells["TipoError"].Value.ToString();
            data[6] = dg_tramites.CurrentRow.Cells["Observaciones"].Value.ToString();
            data[7] = dg_tramites.CurrentRow.Cells["Fecha"].Value.ToString();

            return data;
        }
        public void RefreshDataTramites()
        {
            Utilities_Common.RefreshTramitesData();
            DataTable dt = null;

            // Refresh datatable!
            switch (empleado)
            {
                case "Todos mensual":
                    Tramites tmp = Cn_HandlerTramites.data.GetCache().GetCurrentTramites(Cn_HandlerTramites.current);
                    DataTable table = tmp.data;
                    dt = QuerySpecific.myQuery("Mes", table, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth, "", "", true);
                    this.data = dt;

                    break;
                case "Todos diario":
                    Tramites tmp1 = Cn_HandlerTramites.data.GetCache().GetCurrentTramites(Cn_HandlerTramites.current);
                    DataTable table1 = tmp1.data;
                    dt = QuerySpecific.myQuery("Hoy", table1, DateTime.Now, DateTime.Now, "", "", true);
                    this.data = dt;

                    break;
                case "Todos ayer":
                    Tramites tmp2 = Cn_HandlerTramites.data.GetCache().GetCurrentTramites(Cn_HandlerTramites.current);
                    DataTable table2 = tmp2.data;
                    dt = QuerySpecific.myQuery("Ayer", table2, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-1), "", "", true);
                    this.data = dt;

                    break;
                default:
                    dt = DataTramites.GetEmployeeDataTramites(id);

                    int[] tramites = Statistics.FindTramites(empleado, dt, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
                    int[] errores = Statistics.FindErrores(empleado, dt, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);

                    this.data = dt;
                    break;
            }

            InitializeData();
            RefreshData();
        }
        private void RefreshData()
        {
            if (_frmStatistics != null)
            {
                _frmStatistics.RefreshDashboardData();
            }
            if (_frmEscritorio != null)
            {
                _frmEscritorio.RefreshDesktopDashboard();
            }
        }

        private void btn_savepdf_Click(object sender, EventArgs e)
        {
            if (UtilitiesPdf.ExportDataGridViewInPdf(dg_tramites, "TramitesRNA"))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }

        private void btn_editar_Click_1(object sender, EventArgs e)
        {
            var data = GetDataFromSelectedIndex();

            string[] d = new string[6];
            d = data;
            int id = selectedId;

            frm_tramites_insertar frm = new frm_tramites_insertar();
            frm.Show();
        }

        private void btn_inscribir_Click(object sender, EventArgs e)
        {
            var data = GetDataFromSelectedIndex();
            int id = selectedId;

            frm_tramites_inscribir frm = new frm_tramites_inscribir(id, data[2], data[0], data[7], null, this);
            frm.Show();
        }
        private void btn_error_Click(object sender, EventArgs e)
        {
            var data = GetDataFromSelectedIndex();
            int id = selectedId;

            frm_tramites_error frm = new frm_tramites_error(id, data[2], data[0], data[7], null, this);
            frm.Show();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Estas seguro que deseas eliminar el tramite seleccionado?", "Atencion", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (dg_tramites.SelectedRows.Count > 0)
                    {
                        var data = GetDataFromSelectedIndex();
                        int id = selectedId;

                        Cn_Tramites _cnTramites = new Cn_Tramites();
                        _cnTramites.eliminarTramite(id.ToString());

                        frm_successdialog f = new frm_successdialog(1);
                        f.Show();

                        RefreshDataTramites();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void dg_tramites_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dg_tramites.Columns[e.ColumnIndex].Name == "Empleado1")
            {
                if (Convert.ToString(e.Value) == empleado)
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(0, 0, 35);
                }
            }
            if (this.dg_tramites.Columns[e.ColumnIndex].Name == "NombreInscripto")
            {
                if (Convert.ToString(e.Value) == empleado)
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(0, 0, 35);
                }
            }
            if (this.dg_tramites.Columns[e.ColumnIndex].Name == "Inscripto")
            {
                if (Convert.ToBoolean(e.Value) == true)
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(41, 217, 85);
                }
            }
            if (this.dg_tramites.Columns[e.ColumnIndex].Name == "Error")
            {
                if (Convert.ToBoolean(e.Value) == true)
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(242, 53, 53);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(41, 217, 85);
                }
            }

            if (this.dg_tramites.Columns[e.ColumnIndex].Name == "TipoError")
            {
                if (Convert.ToString(e.Value) == "Error Total")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(242, 53, 53);
                }
                else if (Convert.ToString(e.Value) == "Error Parcial")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(242, 145, 61);
                }
            }
        }
        
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void barra_titulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void frm_tramites_pantallaCompleta_Load(object sender, EventArgs e)
        {

        }
    }
}
