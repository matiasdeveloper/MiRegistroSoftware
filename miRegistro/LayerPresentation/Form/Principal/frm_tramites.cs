using Bunifu.Framework.UI;
using LayerBusiness;
using LayerPresentation.Clases;
using LayerSoporte.Cache;
using MaterialDesignColors.Recommended;
using Microsoft.PowerBI.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayerPresentation
{
    public partial class frm_tramites : Form
    {
        public frm_tramites()
        {
            InitializeComponent();
            LoadDataTramites();
            LoadDashboard();
        }
        // Variable
        private Button _currentBtn;
        private Panel _currentPanelQuery;

        private int selectedId = 0;
        
        // Methods
        public void RefreshAll() 
        {
            Utilities_Common.RefreshTramitesData();
            RefreshDashboardData();
        }
        private void RefreshDashboardData() 
        {
            Statistics.tmp = Cn_Employee.data.GetCache().GetUsers();
            LoadDataTramites();
        }
        private void LoadDataTramites() 
        {
            for(int i = 0; i < 10; i++) 
            {
                dg_tramites.Rows.Add("01", "AA000XX", "Transferencia", "Procesado", "Matias", "", "Sin errrores", "27/20/14", "Sin observaciones");
                dg_tramites.Rows.Add("22", "AA000XX", "Inscripcion inicial", "Procesado", "Matias", "", "Sin errrores", "27/20/14", "Sin observaciones");
                dg_tramites.Rows.Add("10", "AA000XX", "Desarrollo de software", "Procesado e inscripto", "Matias", "Noeli", "Error en la cedula", "27/20/14", "Todas las observaciones posibles");
            }
            //LoadTramites(Cn_HandlerTramites.current);
        }
        // Charge priviliges when intialize the form
        private void LoadAccessPrivileges() 
        {
            if (UserLoginCache.Priveleges == Privileges.Estandar)
            {
                // Code here
                btn_insertar.Enabled = false;
                btn_editar.Enabled = false;
                btn_inscribir.Enabled = false;
                btn_error.Enabled = false;
                btn_eliminar.Enabled = false;
            }
        }
        // Refresh data tramites
        private void LoadTramites(int id) 
        {
            dg_tramites.AutoGenerateColumns = false;
            DataTable dt = DataTramites.data;

            dg_tramites.DataSource = dt;
            DisableButton();
        }
        private void LoadDashboard()
        {
            Tuple<int,int,int,int> dt = Cn_HandlerTramites.data.tramitesCache.GetTramitesHistory();
            lbl_totaltramites.Text = "(" + dt.Item1.ToString() + "tramites)";
        }

        /// <summary>
        /// Load the data from the new query executed by the user. 
        /// For example: Query for range of dates.
        /// </summary>
        /// <param name="dt"></param>
        public void LoadDataQuery(DataTable dt) 
        {
            if(dt == DataTramites.data) 
            {
                DisableButton();
            }
            dg_tramites.AutoGenerateColumns = false;
            dg_tramites.DataSource = dt;
        }

        // Activate or desactivate button in current query
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                _currentBtn = (Button)senderBtn;
                _currentBtn.BackColor = Color.FromArgb(224, 224, 224);
                _currentBtn.ForeColor = color;
            }
        }
        private void DisableButton()
        {
            if (_currentBtn != null)
            {
                _currentBtn.BackColor = Color.White;
                _currentBtn.ForeColor = Color.Black;
            }
        }   
        
        // Activate or desactivate panel query
        private void ActivatePanelQuery(Panel pn) 
        {
            if(pn != null) 
            {
                DisableButton();
                DisablePanelQuery();
                _currentPanelQuery = (Panel)pn;
                _currentPanelQuery.Visible = true;
            }
        }
        private void DisablePanelQuery() 
        {
            if(_currentPanelQuery != null) 
            {
                _currentPanelQuery.Visible = false;
            }
        }

        // Get data from selected index in datagrid
        private string[] GetDataFromSelectedIndex() 
        {
            selectedId = Convert.ToInt32(dg_tramites.CurrentRow.Cells["Id"].Value); ;
            string[] data = new string[8];
            
            data[0] = dg_tramites.CurrentRow.Cells["Dominio"].Value.ToString();
            data[1] = dg_tramites.CurrentRow.Cells["Tramite"].Value.ToString();
            data[2] = dg_tramites.CurrentRow.Cells["Empleado"].Value.ToString();
            data[3] = dg_tramites.CurrentRow.Cells["Etapa"].Value.ToString();
            data[4] = dg_tramites.CurrentRow.Cells["Error"].Value.ToString();
            data[5] = dg_tramites.CurrentRow.Cells["TipoError"].Value.ToString();
            data[6] = dg_tramites.CurrentRow.Cells["Observaciones"].Value.ToString();
            data[7] = dg_tramites.CurrentRow.Cells["Fecha"].Value.ToString();

            return data;
        }

        private void OpenNewFormInQuery(string nombre, string query)
        {
            frm_tramites_query frm = new frm_tramites_query(nombre, query, this);
            frm.Show();
        }
       
        // Refresh
        private void btn_refreshdata_Click(object sender, EventArgs e)
        {
            LoadDataQuery(DataTramites.data);
        }
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            Utilities_Common.RefreshTramitesData();
            RefreshDashboardData();
        }

        // Buttons for query panel
        private void btn_simple_fecha_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.Blue);
            OpenNewFormInQuery("una o dos fechas", "Fecha");
        }

        private void btn_simple_empleado_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.Blue);
            OpenNewFormInQuery("empleado registrados", "Empleado");
        }
        private void btn_simple_dominio_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.Blue);
            OpenNewFormInQuery("dominio del vehiculo", "Dominio");
        }
        private void btn_simple_diaria_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.Blue);
            OpenNewFormInQuery("diaria (Mes y Dia)", "Diaria");
        }
        private void btn_complejo_fechaempleado_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.Blue);
            OpenNewFormInQuery("fecha y empleado", "Fecha_Empleado");
        }
        private void btn_complejo_fechaprocesados_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.Blue);
            OpenNewFormInQuery("fecha y procesados", "Fecha_Procesado");
        }
        private void btn_complejo_fechainscriptos_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.Blue);
            OpenNewFormInQuery("fecha e inscripto", "Fecha_Inscripto");
        }
        private void btn_complejo_fechaerrores_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.Blue);
            OpenNewFormInQuery("fecha y errores", "Fecha_Errores");
        }

        // Button Crud
        private void btn_editar_Click(object sender, EventArgs e)
        {
            var data = GetDataFromSelectedIndex();

            string[] d = new string[6];
            d = data;
            int id = selectedId;

            frm_tramites_insertar frm = new frm_tramites_insertar();
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

                        Utilities_Common.layerBusiness.cn_tramites.eliminarTramite(id.ToString());
                        frm_successdialog f = new frm_successdialog(1);
                        f.Show();

                        RefreshAll();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void btn_error_Click(object sender, EventArgs e)
        {
            var data = GetDataFromSelectedIndex();
            int id = selectedId;

            frm_tramites_error frm = new frm_tramites_error(id, data[2] ,data[0], data[7], this);
            frm.Show();
        }
        
        // Paint the datagridview
        private void dg_tramites_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           /* if (this.dg_tramites.Columns[e.ColumnIndex].Name == "Inscripto")
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
            }*/
        }
        private void btn_savepdf_Click(object sender, EventArgs e)
        {
            if (Utilites_Pdf.ExportDataGridViewInPdf(dg_tramites, "TramitesRNA"))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }
        private void frm_tramites_consultas_Load(object sender, EventArgs e)
        {
            //ActivatePanelQuery(query_group_1);
            //LoadAccessPrivileges();
        }

        private void button_acciones_Click(object sender, EventArgs e)
        {
            if (pn_acciones.Visible)
            {
                pn_acciones.Visible = false;
            }
            else
            {
                ShowMoreOptions(pn_acciones);
            }
        }
        private void ShowMoreOptions(BunifuCards panel)
        {
            panel.Visible = false;
            TransitionPnMore.Show(panel);
        }

        private void button_consultar_Click(object sender, EventArgs e)
        {
            if (pn_consulta.Visible)
            {
                pn_consulta.Visible = false;
            }
            else
            {
                ShowMoreOptions(pn_consulta);
            }
        }

        private void button_cancelarconsulta_Click(object sender, EventArgs e)
        {
            if (pn_consulta.Visible)
            {
                pn_consulta.Visible = false;
                // Delete fields
            }
        }

        // Multiples
        private void btn_insertar_Click_1(object sender, EventArgs e)
        {
            frm_tramites_insertar frm = new frm_tramites_insertar();
            frm.Show();
        }
        private void btn_inscribir_Click_1(object sender, EventArgs e)
        {
            frm_tramites_inscribir_mult frm = new frm_tramites_inscribir_mult(DateTime.Today, this);
            frm.Show();
        }
        private void btn_refreshdata_Click_1(object sender, EventArgs e)
        {

        }

        // Acciones
        private void btn_error_Click_1(object sender, EventArgs e)
        {

        }
        private void btn_inscribirsingle_Click(object sender, EventArgs e)
        {

        }
        private void btn_editar_Click_1(object sender, EventArgs e)
        {

        }
        private void btn_eliminar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
