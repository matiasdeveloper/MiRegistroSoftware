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
            refreshData();
        }
        // Variables
        private Cn_Tramites _cnTramites = new Cn_Tramites();
        private Cn_Empleados _cnEmpleados = new Cn_Empleados();

        private DataTable currentDt;

        private Button _currentBtn;
        private Panel _currentPanelQuery;

        private int selectedId = 0;
        // Methods
        public void refreshAll() 
        {
            _cnTramites.RefreshDataTramitesCache();
            _cnEmpleados.GenerateEmployeesDataCache(); Statistics.tmp = Cn_Employee.data.GetCache().GetUsers();

            refreshTramites(Cn_HandlerTramites.current);
            refreshDashboard();
        }
        public void refreshData() 
        {
            refreshTramites(Cn_HandlerTramites.current);
            refreshDashboard();
        }
        // Charge priviliges when intialize the form
        private void cargarPrivilegios() 
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
        private void refreshTramites(int id) 
        {
            dg_tramites.AutoGenerateColumns = false;
            DataTable dt = GetTramites(id);
            currentDt = dt;
            dg_tramites.DataSource = dt;

            disableButton();
        }
        private void refreshDashboard()
        {
            Tuple<int,int,int,int> dt = Cn_HandlerTramites.data.tramitesCache.GetTramitesHistory();
            lbl_totaltramites.Text = dt.Item1.ToString();
            lbl_totalprocesados.Text = dt.Item2.ToString();
            lbl_totalinscriptos.Text = dt.Item3.ToString();
            lbl_totalerrores.Text = dt.Item4.ToString();
        }
        private DataTable GetTramites(int id)
        {
            Tramites tmp = Cn_HandlerTramites.data.GetCache().GetCurrentTramites(id);
            DataTable table = tmp.data;
            //MessageBox.Show(table.Rows.Count.ToString());
            return table;
        }
        // Refresh query specific tramites
        public void RefreshQuery(DataTable dt) 
        {
            if(dt == currentDt) 
            {
                disableButton();
            }
            dg_tramites.AutoGenerateColumns = false;
            dg_tramites.DataSource = dt;
        }
        // Activate or desactivate active button in current query
        private void activateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                disableButton();
                _currentBtn = (Button)senderBtn;
                _currentBtn.BackColor = Color.FromArgb(224, 224, 224);
                _currentBtn.ForeColor = color;
            }
        }
        private void disableButton()
        {
            if (_currentBtn != null)
            {
                _currentBtn.BackColor = Color.White;
                _currentBtn.ForeColor = Color.Black;
            }
        }   
        
        // Activate or desactivate panel query
        private void activatePanel(Panel pn) 
        {
            if(pn != null) 
            {
                disableButton();
                disablePanel();
                _currentPanelQuery = (Panel)pn;
                _currentPanelQuery.Visible = true;
            }
        }
        private void disablePanel() 
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

        private void OpenFormQuery(string nombre, string query)
        {
            frm_tramites_query frm = new frm_tramites_query(nombre, query, currentDt, this);
            frm.Show();
        }

        // Radio button categories
        private void radioButton_simple_Click(object sender, EventArgs e)
        {
            if (radioButton_simple.Checked)
            {
                //MessageBox.Show("Opcion ya seleccionada!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                radioButton_simple.Checked = true;
                // Display panel
                activatePanel(query_group_1);

                radioButton_complejas.Checked = false;
            }
        }
        private void radioButton_complejas_Click(object sender, EventArgs e)
        {
            if (radioButton_complejas.Checked)
            {
                //MessageBox.Show("Opcion ya seleccionada!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                radioButton_complejas.Checked = true;
                // Display panel
                activatePanel(query_group_2);

                radioButton_simple.Checked = false;
            }
        }
       
        // Refresh
        private void btn_refreshdata_Click(object sender, EventArgs e)
        {
            RefreshQuery(currentDt);
        }
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            _cnTramites.RefreshDataTramitesCache();
            refreshTramites(Cn_HandlerTramites.current);
        }

        // Buttons for query panel
        private void btn_simple_fecha_Click(object sender, EventArgs e)
        {
            activateButton(sender, Color.Blue);
            OpenFormQuery("una o dos fechas", "Fecha");
        }

        private void btn_simple_empleado_Click(object sender, EventArgs e)
        {
            activateButton(sender, Color.Blue);
            OpenFormQuery("empleado registrados", "Empleado");
        }
        private void btn_simple_dominio_Click(object sender, EventArgs e)
        {
            activateButton(sender, Color.Blue);
            OpenFormQuery("dominio del vehiculo", "Dominio");
        }
        private void btn_simple_diaria_Click(object sender, EventArgs e)
        {
            activateButton(sender, Color.Blue);
            OpenFormQuery("diaria (Mes y Dia)", "Diaria");
        }
        private void btn_complejo_fechaempleado_Click(object sender, EventArgs e)
        {
            activateButton(sender, Color.Blue);
            OpenFormQuery("fecha y empleado", "Fecha_Empleado");
        }
        private void btn_complejo_fechaprocesados_Click(object sender, EventArgs e)
        {
            activateButton(sender, Color.Blue);
            OpenFormQuery("fecha y procesados", "Fecha_Procesado");
        }
        private void btn_complejo_fechainscriptos_Click(object sender, EventArgs e)
        {
            activateButton(sender, Color.Blue);
            OpenFormQuery("fecha e inscripto", "Fecha_Inscripto");
        }
        private void btn_complejo_fechaerrores_Click(object sender, EventArgs e)
        {
            activateButton(sender, Color.Blue);
            OpenFormQuery("fecha y errores", "Fecha_Errores");
        }

        // Button Crud
        private void btn_editar_Click(object sender, EventArgs e)
        {
            var data = GetDataFromSelectedIndex();

            string[] d = new string[6];
            d = data;
            int id = selectedId;

            frm_tramites_insertar frm = new frm_tramites_insertar(true, id, d, this);
            frm.Show();
        }
        private void btn_insertar_Click(object sender, EventArgs e)
        {
            string[] d = null;
            frm_tramites_insertar frm = new frm_tramites_insertar(false, 0, d, this);
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

                        _cnTramites.eliminarTramite(id.ToString());
                        frm_successdialog f = new frm_successdialog(1);
                        f.Show();

                        refreshAll();
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
        private void btn_inscribir_Click(object sender, EventArgs e)
        {
            if (checkBox_inscripto.Checked) 
            {
                frm_tramites_inscribir_mult frm = new frm_tramites_inscribir_mult(DateTime.Today, currentDt, this);
                frm.Show();
            } 
            else 
            {
                var data = GetDataFromSelectedIndex();
                int id = selectedId;

                frm_tramites_inscribir frm = new frm_tramites_inscribir(id, data[2], data[0], data[7], this);
                frm.Show();
            }
        }
        
        // Paint the datagrid
        private void dg_tramites_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
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

        private void frm_tramites_consultas_Load(object sender, EventArgs e)
        {
            activatePanel(query_group_1);
            cargarPrivilegios();
        }

        private void btn_savepdf_Click(object sender, EventArgs e)
        {
            if (ExportDataTramitesPdf(dg_tramites, "TramitesRNA"))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }

        private bool ExportDataTramitesPdf(DataGridView dt, string name)
        {
            Random r = new Random();
            string dia = DateTime.Now.Day + "-" + DateTime.Now.Month;
            string user = name + "_" + dia;

            bool result = DataSave.saveInPdf(dt, user);

            return result;
        }

        private void dg_tramites_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
