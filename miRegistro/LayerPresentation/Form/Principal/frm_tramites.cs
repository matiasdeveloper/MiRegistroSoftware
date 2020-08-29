using LayerBusiness;
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

        private Button _currentBtn;
        private Panel _currentPanelQuery;
        private Panel _currentPanelQueryActual;

        private int selectedId;
        // Methods
        public void refreshData() 
        {
            refreshTramites(Cn_HandlerTramites.current);
            refreshDashboard();

            displayEmpleados(comboBox_empleado);
            displayEmpleados(comboBox_empleados1);
        }
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
        private void refreshTramites(int id) 
        {
            dg_tramites.AutoGenerateColumns = false;
            DataTable dt = GetTramites(id);
            dg_tramites.DataSource = dt;
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
            LinkedList<Tramites> tmp = Cn_HandlerTramites.data.GetCache().GetTramites();
            LinkedListNode<Tramites> tramites = tmp.First;

            DataTable table = new DataTable();

            for (int i = 0; i < tmp.Count; i++)
            {
                if (tramites.Value.id == id)
                {
                    table = tramites.Value.data;
                    break;
                }
                tramites = tramites.Next;
            }
            return table;
        }

        // Check the button selected
        private void checkCorrectButton(RadioButton r1, RadioButton r2) 
        {
            if (!r1.Checked) 
            {
                r1.Checked = true;
                r2.Checked = false;
            }
        }        
        
        // Check the date range
        private Tuple<bool, bool> checkCorrectDate(DateTimePicker date1, DateTimePicker date2) 
        {
            bool isOk = false;
            bool isOne = true;
            if(date1.Checked && date2.Checked) 
            {
                if(date1.Value < date2.Value) 
                {
                    isOne = false;
                    isOk = true;
                } else 
                {
                    isOk = false;
                    MessageBox.Show("El valor de la segunda fecha no puede ser menor o igual que la primera", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }       
            } 
            else if(date1.Checked)
            {
                isOne = true;
                isOk = true;
            } 
            else 
            {
                MessageBox.Show("Seleccione al menos una fecha para iniciar la busquedad", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return Tuple.Create(isOk, isOne);
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
                disablePanelQueryActual();
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

        // Activate or desactivate panel query actual when press button
        private void activatePanelQueryActual(Panel pn)
        {
            if (pn != null)
            {
                disablePanelQueryActual();
                _currentPanelQueryActual = (Panel)pn;
                _currentPanelQueryActual.Visible = true;
            }
        }
        private void disablePanelQueryActual()
        {
            if (_currentPanelQueryActual != null)
            {
                _currentPanelQueryActual.Visible = false;
            }
        }

        // Display combobox empleados
        private void displayEmpleados(ComboBox cb) 
        {
            DataTable dt = GetEmployes();
            cb.DisplayMember = "Empleado";
            cb.ValueMember = "Id";
            cb.DataSource = dt;
        }
        private DataTable GetEmployes()
        {
            LinkedList<Employee> tmp = Cn_Employee.data.GetCache().GetUsers();
            LinkedListNode<Employee> employee = tmp.First;

            DataTable table = CreateNewTopTable();

            for (int i = 0; i < tmp.Count; i++)
            {
                AddRowData(table, employee.Value.id, employee.Value.nombre);
                employee = employee.Next;
            }

            return table;
        }
        private DataTable CreateNewTopTable()
        {
            DataTable table = new DataTable();
            DataColumn column;
            // Create new DataColumn, set DataType, ColumnName and add to DataTable.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Id";
            table.Columns.Add(column);

            // Create a first column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Empleado";
            table.Columns.Add(column);

            return table;
        }
        private void AddRowData(DataTable table, int top, string empleado)
        {
            DataRow row;

            row = table.NewRow();
            row["Id"] = top;
            row["Empleado"] = empleado;

            table.Rows.Add(row);
        }

        // Get data from selected index in datagrid
        private string[] getDataFromSelectedIndex() 
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
        
        // Generate query with tramites and get the result
        /// <summary>
        /// Query avaiable ('Dominio', 'Empleado', 'Fecha', 'Fecha_empleado', 'Fecha_Procesado', 'Fecha_Inscripto', 'Hoy', 'Ayer', 'Semana', 'Mes')
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private DataTable myQuery(string name) 
        {
            DataTable dt = new DataTable();
            switch (name) 
            {
                case "Dominio":

                    break;
                case "Empleado":

                    break;
                case "Fecha":

                    break;
                case "Fecha_Empleado":

                    break;
                case "Fecha_Procesado":

                    break;
                case "Fecha_Inscripto":

                    break;
                case "Fecha_Errores":

                    break;
                case "Hoy":

                    break;
                case "Ayer":

                    break;
                case "Semana":

                    break;
                case "Mes":

                    break;
                default:

                    break;
            }
            return dt;
        }
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
                activatePanel(panel_simple);

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
                activatePanel(panel_complejo);

                radioButton_simple.Checked = false;
            }
        }
        
        private void dg_tramites_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dg_tramites.Columns[e.ColumnIndex].Name == "Error")
            {
                if (Convert.ToBoolean(e.Value) == true)
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(192, 25, 28);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(81, 189, 51);
                }
            }
            
            if (this.dg_tramites.Columns[e.ColumnIndex].Name == "Tipo Error")
            {
                if (Convert.ToString(e.Value) == "Error Total")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(81, 189, 51);
                }
                else if (Convert.ToString(e.Value) == "Error Parcial")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(228, 194, 78);
                }
                else if (Convert.ToString(e.Value) == "Sin Errores")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(192, 25, 28);
                }
            }
        }
        private void btn_refreshdata_Click(object sender, EventArgs e)
        {
            _cnTramites.GenerateDataTramitesCache();
            refreshTramites(Cn_HandlerTramites.current);
        }
        private void btn_imprimirPorDominio_Click(object sender, EventArgs e)
        {
            dg_tramites.AutoGenerateColumns = false;
            DataTable dt = myQuery("Dominio");
            dg_tramites.DataSource = dt;           
        }
        private void btn_imprimirPorEmpleado_Click(object sender, EventArgs e)
        {
            dg_tramites.AutoGenerateColumns = false;
            string empleado = comboBox_empleado.SelectedValue.ToString();
            int cod_empleado = Convert.ToInt32(empleado);

            DataTable dt = myQuery("Empleado");
            dg_tramites.DataSource = dt;
        }
        private void btn_imprimirPorFecha_Click(object sender, EventArgs e)
        {
            /*try 
            {
                var values = checkCorrectDate(dateTimePicker_fecha1, dateTimePicker_fecha2);
                if (values.Item1)
                {
                    if (values.Item2)
                    {
                        DateTime dt1 = dateTimePicker_fecha1.Value;
                        dg_tramites.AutoGenerateColumns = false;

                        DataTable dt = objects.mostrarByFecha(dateTimePicker_fecha1.Value.ToUniversalTime());
                        dg_tramites.DataSource = dt;
                    }
                    else
                    {
                        DateTime dt1 = dateTimePicker_fecha1.Value;
                        DateTime dt2 = dateTimePicker_fecha2.Value;
                        dg_tramites.AutoGenerateColumns = false;

                        DataTable dt = objects.mostrarByRangeOfFecha(dateTimePicker_fecha1.Value.ToUniversalTime(), dateTimePicker_fecha2.Value.ToUniversalTime());
                        dg_tramites.DataSource = dt;
                    }
                }
            } 
            catch(Exception ex) 
            {
                MessageBox.Show("Error en la consulta: " + ex);
            }*/
        }
        private void btn_imprimirPorFechaAndEmployee_Click(object sender, EventArgs e)
        {
            /*try
            {
                var values = checkCorrectDate(dateTimePicker_fecha3, dateTimePicker_fecha4);
                if (values.Item1)
                {
                    string empleado = comboBox_empleados1.SelectedValue.ToString();
                    int cod_empleado = Convert.ToInt32(empleado);

                    Cn_tramites objects = new Cn_tramites();
                    if (values.Item2)
                    {
                        DateTime dt1 = dateTimePicker_fecha3.Value;
                        dg_tramites.AutoGenerateColumns = false;

                        DataTable dt = objects.mostrarByFechaAndEmployee(dateTimePicker_fecha3.Value.ToUniversalTime(), cod_empleado);
                        dg_tramites.DataSource = dt;

                        TramitesData.tramites = dt;
                        TramitesData.lastQuery = 4;
                    }
                    else
                    {
                        DateTime dt1 = dateTimePicker_fecha3.Value;
                        DateTime dt2 = dateTimePicker_fecha4.Value;
                        dg_tramites.AutoGenerateColumns = false;

                        DataTable dt = objects.mostrarByRangeOfFechaAndEmployee(dateTimePicker_fecha3.Value.ToUniversalTime(), dateTimePicker_fecha4.Value.ToUniversalTime(), cod_empleado);
                        dg_tramites.DataSource = dt;

                        TramitesData.tramites = dt;
                        TramitesData.lastQuery = 5;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta: " + ex);
            }*/
        }
        private void btn_imprimirPorFechaAndProcesado_Click(object sender, EventArgs e)
        {
            /*try
            {
                var values = checkCorrectDate(dateTimePicker_fecha5, dateTimePicker_fecha6);
                if (values.Item1)
                {
                    int cod_etapa = 0;
                    if (radioButton_siProcesados.Checked) { cod_etapa = 1; } else { cod_etapa = 0; }

                    Cn_tramites objects = new Cn_tramites();
                    if (values.Item2)
                    {
                        dg_tramites.AutoGenerateColumns = false;

                        DataTable dt = objects.mostrarByFechaAndProcesado(dateTimePicker_fecha5.Value.ToUniversalTime(), cod_etapa);
                        dg_tramites.DataSource = dt;

                        TramitesData.tramites = dt;
                        TramitesData.lastQuery = 6;
                    }
                    else
                    {
                        dg_tramites.AutoGenerateColumns = false;

                        DataTable dt = objects.mostrarByRangeOfFechaAndProcesado(dateTimePicker_fecha5.Value.ToUniversalTime(), dateTimePicker_fecha6.Value.ToUniversalTime(), cod_etapa);
                        dg_tramites.DataSource = dt;

                        TramitesData.tramites = dt;
                        TramitesData.lastQuery = 7;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta: " + ex);
            }*/
        }
        private void btn_imprimirPorFechaAndInscripto_Click(object sender, EventArgs e)
        {
            /*try
            {
                var values = checkCorrectDate(dateTimePicker_fecha7, dateTimePicker_fecha8);
                if (values.Item1)
                {
                    int isIncripto = 0;
                    if (radioButton_siInscriptos.Checked) { isIncripto = 1; } else { isIncripto = 0; }

                    Cn_tramites objects = new Cn_tramites();
                    if (values.Item2)
                    {
                        dg_tramites.AutoGenerateColumns = false;

                        DataTable dt = objects.mostrarByFechaAndInscripto(dateTimePicker_fecha7.Value.ToUniversalTime(), isIncripto);
                        dg_tramites.DataSource = dt;

                        TramitesData.tramites = dt;
                        TramitesData.lastQuery = 7;
                    }
                    else
                    {
                        dg_tramites.AutoGenerateColumns = false;

                        DataTable dt = objects.mostrarByRangeOfFechaAndInscripto(dateTimePicker_fecha7.Value.ToUniversalTime(), dateTimePicker_fecha8.Value.ToUniversalTime(), isIncripto);
                        dg_tramites.DataSource = dt;

                        TramitesData.tramites = dt;
                        TramitesData.lastQuery = 8;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta: " + ex);
            }*/
        }
        private void btn_imprimirPorFechaAndErrores_Click(object sender, EventArgs e)
        {
            /*try
            {
                var values = checkCorrectDate(dateTimePicker_fecha9, dateTimePicker_fecha10);
                if (values.Item1)
                {
                    int isError = 0;
                    if (radioButton_siError.Checked) { isError = 1; } else { isError = 0; }

                    Cn_tramites objects = new Cn_tramites();
                    if (values.Item2)
                    {
                        dg_tramites.AutoGenerateColumns = false;

                        DataTable dt = objects.mostrarByFechaAndError(dateTimePicker_fecha9.Value.ToUniversalTime(), isError);
                        dg_tramites.DataSource = dt;

                        TramitesData.tramites = dt;
                        TramitesData.lastQuery = 9;
                    }
                    else
                    {
                        dg_tramites.AutoGenerateColumns = false;

                        DataTable dt = objects.mostrarByRangeOfFechaAndError(dateTimePicker_fecha9.Value.ToUniversalTime(), dateTimePicker_fecha10.Value.ToUniversalTime(), isError);
                        dg_tramites.DataSource = dt;

                        TramitesData.tramites = dt;
                        TramitesData.lastQuery = 10;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta: " + ex);
            }*/
        }
        private void btn_imprimirPorHoy_Click(object sender, EventArgs e)
        {
            dg_tramites.AutoGenerateColumns = false;

            DataTable dt = myQuery("Hoy");
            dg_tramites.DataSource = dt;
        }
        private void btn_imprimirPorAyer_Click(object sender, EventArgs e)
        {
            dg_tramites.AutoGenerateColumns = false;

            DataTable dt = myQuery("Ayer");
            dg_tramites.DataSource = dt;
        }
        private void btn_imprimirPorSemana_Click(object sender, EventArgs e)
        {
            dg_tramites.AutoGenerateColumns = false;

            DataTable dt = myQuery("Semana");
            dg_tramites.DataSource = dt;
        }
        private void btn_imprimirPorMes_Click(object sender, EventArgs e)
        {
            dg_tramites.AutoGenerateColumns = false;

            DateTime date = DateTime.Now;
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            DataTable dt = myQuery("Mes");
            dg_tramites.DataSource = dt;
        }
        
        // Buttons for query panel
        private void btn_simple_fecha_Click(object sender, EventArgs e)
        {
            activateButton(sender, Color.Blue);
            if (_currentPanelQueryActual != panel_simple_fecha)
            {
                activatePanelQueryActual(panel_simple_fecha);
            }
        }
        private void btn_simple_empleado_Click(object sender, EventArgs e)
        {
            activateButton(sender, Color.Blue);
            if (_currentPanelQueryActual != panel_simple_empleado)
            {
                activatePanelQueryActual(panel_simple_empleado);
            }
        }
        private void btn_simple_dominio_Click(object sender, EventArgs e)
        {
            activateButton(sender, Color.Blue);
            if (_currentPanelQueryActual != panel_simple_dominio)
            {
                activatePanelQueryActual(panel_simple_dominio);
            }
        }
        private void btn_simple_diaria_Click(object sender, EventArgs e)
        {
            activateButton(sender, Color.Blue);
            if (_currentPanelQueryActual != panel_simple_diaria)
            {
                activatePanelQueryActual(panel_simple_diaria);
            }
        }
        private void btn_complejo_fechaempleado_Click(object sender, EventArgs e)
        {
            activateButton(sender, Color.Blue);
            if (_currentPanelQueryActual != panel_complejo_fechaempleado)
            {
                activatePanelQueryActual(panel_complejo_fechaempleado);
            }
        }
        private void btn_complejo_fechaprocesados_Click(object sender, EventArgs e)
        {
            activateButton(sender, Color.Blue);
            if (_currentPanelQueryActual != panel_complejo_fechaprocesados)
            {
                activatePanelQueryActual(panel_complejo_fechaprocesados);
            }
        }
        private void btn_complejo_fechainscriptos_Click(object sender, EventArgs e)
        {
            activateButton(sender, Color.Blue);
            if (_currentPanelQueryActual != panel_complejo_fechainscriptos)
            {
                activatePanelQueryActual(panel_complejo_fechainscriptos);
            }
        }
        private void btn_complejo_fechaerrores_Click(object sender, EventArgs e)
        {
            activateButton(sender, Color.Blue);
            if (_currentPanelQueryActual != panel_complejo_fechaerrores)
            {
                activatePanelQueryActual(panel_complejo_fechaerrores);
            }
        }

        private void txtBox_dominio_Enter(object sender, EventArgs e)
        {
            if (txtBox_dominio.Text == "EJ: AA111XX")
            {
                txtBox_dominio.Text = "";
                txtBox_dominio.ForeColor = Color.Black;
            }
        }

        private void txtBox_dominio_Leave(object sender, EventArgs e)
        {
            if (txtBox_dominio.Text == "")
            {
                txtBox_dominio.Text = "EJ: AA111XX";
                txtBox_dominio.ForeColor = Color.Gray;
            }
        }
        // Radiobutton query hard
        private void radioButton_siProcesados_Click(object sender, EventArgs e)
        {
            checkCorrectButton(radioButton_siProcesados, radioButton_noProcesados);
        }

        private void radioButton_noProcesados_Click(object sender, EventArgs e)
        {
            checkCorrectButton(radioButton_noProcesados, radioButton_siProcesados);
        }

        private void radioButton_siInscriptos_Click(object sender, EventArgs e)
        {
            checkCorrectButton(radioButton_siInscriptos, radioButton_noInscriptos);
        }

        private void radioButton_noInscriptos_Click(object sender, EventArgs e)
        {
            checkCorrectButton(radioButton_noInscriptos, radioButton_siInscriptos);
        }
        private void radioButton_siError_Click(object sender, EventArgs e)
        {
            checkCorrectButton(radioButton_siError, radioButton_noError);
        }
        private void radioButton_noError_Click(object sender, EventArgs e)
        {
            checkCorrectButton(radioButton_noError, radioButton_siError);
        }
        // Button Crud
        private void btn_editar_Click(object sender, EventArgs e)
        {
            var data = getDataFromSelectedIndex();

            string[] d = new string[6];
            d = data;
            int id = selectedId;

            frm_tramites_insertar frm = new frm_tramites_insertar(this, true, id, d);
            frm.Show();
        }
        private void btn_insertar_Click(object sender, EventArgs e)
        {
            string[] d = null;
            frm_tramites_insertar frm = new frm_tramites_insertar(this, false, 0, d);
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
                        //int id = getTramiteSelectedID();

                        //_cnTramites.eliminarTramite(id.ToString());
                        frm_successdialog f = new frm_successdialog(1);
                        f.Show();

                        refreshData();
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
            var data = getDataFromSelectedIndex();
            int id = selectedId;

            frm_tramites_error frm = new frm_tramites_error(this, id, data[2] ,data[0], data[7]);
            frm.Show();
        }

        private void btn_inscribir_Click(object sender, EventArgs e)
        {
            var data = getDataFromSelectedIndex();
            int id = selectedId;

            frm_tramites_inscribir frm = new frm_tramites_inscribir(this, false, id, data[2], data[0], data[7]);
            frm.Show();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            txtBox_fecha.Text = DateTime.Now.ToString();
        }
        private void frm_tramites_consultas_Load(object sender, EventArgs e)
        {
            activatePanel(panel_simple);
            cargarPrivilegios();
        }

    }
}
