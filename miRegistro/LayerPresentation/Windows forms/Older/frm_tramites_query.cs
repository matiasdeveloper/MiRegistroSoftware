using LayerPresentation.Clases;
using LayerSoporte.Cache;
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

namespace LayerPresentation
{
    public partial class frm_tramites_query : Form
    {
        // Move form with mouse down in bar
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        
        /// <summary>
        /// Open form to make an query in tramites. 
        /// For example: "Por fecha"
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="queryNombre"></param>
        /// <param name="handler"></param>
        public frm_tramites_query(string nombre, string queryNombre, frm_tramites handler)
        {
            InitializeComponent();
            lbl_name.Text = nombre;
            currentDt = DataTramites.data;
            _frmTramites = handler;

            Initialize(queryNombre);
        }

        private frm_tramites _frmTramites;
        private DataTable currentDt;
        private Panel _currentPanelQueryActual;

        private void Initialize(string name) 
        {
            DataTramites.DisplayEmpleados(comboBox_empleado);
            DataTramites.DisplayEmpleados(comboBox_empleados1);

            switch (name)
            {
                case "Dominio":
                    if (_currentPanelQueryActual != panel_simple_dominio)
                    {
                        ActivateCurrentPanelQuery(panel_simple_dominio);
                    }
                    break;
                case "Empleado":
                    if (_currentPanelQueryActual != panel_simple_empleado)
                    {
                        ActivateCurrentPanelQuery(panel_simple_empleado);
                    }
                    break;
                case "Fecha":
                    if (_currentPanelQueryActual != panel_simple_fecha)
                    {
                        ActivateCurrentPanelQuery(panel_simple_fecha);
                    }
                    break;
                case "Fecha_Empleado":
                    if (_currentPanelQueryActual != panel_complejo_fechaempleado)
                    {
                        ActivateCurrentPanelQuery(panel_complejo_fechaempleado);
                    }
                    break;
                case "Fecha_Procesado":
                    if (_currentPanelQueryActual != panel_complejo_fechaprocesados)
                    {
                        ActivateCurrentPanelQuery(panel_complejo_fechaprocesados);
                    }
                    break;
                case "Fecha_Inscripto":
                    if (_currentPanelQueryActual != panel_complejo_fechainscriptos)
                    {
                        ActivateCurrentPanelQuery(panel_complejo_fechainscriptos);
                    }
                    break;
                case "Fecha_Errores":
                    if (_currentPanelQueryActual != panel_complejo_fechaerrores)
                    {
                        ActivateCurrentPanelQuery(panel_complejo_fechaerrores);
                    }
                    break;
                case "Diaria":
                    if (_currentPanelQueryActual != panel_simple_diaria)
                    {
                        ActivateCurrentPanelQuery(panel_simple_diaria);
                    }
                    break;
                default:
                    if (_currentPanelQueryActual != panel_simple_fecha)
                    {
                        ActivateCurrentPanelQuery(panel_simple_fecha);
                    }
                    break;
            }
        }


        // Activate or desactivate panel query actual when press button
        private void ActivateCurrentPanelQuery(Panel pn)
        {
            if (pn != null)
            {
                DisableCurrentPanelQuery();
                _currentPanelQueryActual = (Panel)pn;
                _currentPanelQueryActual.Visible = true;
            }
        }
        private void DisableCurrentPanelQuery()
        {
            if (_currentPanelQueryActual != null)
            {
                _currentPanelQueryActual.Visible = false;
            }
        }

        // Check correct rb
        private void CheckRadioButtonClicked(RadioButton r1, RadioButton r2)
        {
            if (!r1.Checked)
            {
                r1.Checked = true;
                r2.Checked = false;
            }
        }

        /// Section Buttons Query
        //  Query simples:
        //  Empleado
        private void btn_imprimirPorEmpleado_Click(object sender, EventArgs e)
        {
            string empleado = comboBox_empleado.GetItemText(comboBox_empleado.SelectedItem);
            DataTable dt = QuerySpecific.myQuery("Empleado", currentDt, DateTime.Now, DateTime.Now, "", empleado, true);
            //_frmTramites.LoadDataQuery(dt);
            this.Close();
        }
        // Dominio
        private void btn_imprimirPorDominio_Click(object sender, EventArgs e)
        {
            DataTable dt = QuerySpecific.myQuery("Dominio", currentDt, DateTime.Now, DateTime.Now, txtBox_dominio.Text.ToUpper(), "", true);
           // _frmTramites.LoadDataQuery(dt);
            this.Close();
        }
        // Fechas
        private void btn_imprimirPorFecha_Click(object sender, EventArgs e)
        {
            try
            {
                var values = Fechas.checkCorrectDate(dateTimePicker_fecha1, dateTimePicker_fecha2);
                if (values.Item1)
                {
                    if (values.Item2)
                    {
                        DateTime dt1 = dateTimePicker_fecha1.Value;
                        DataTable dt = QuerySpecific.myQuery("Fecha", currentDt, dt1, dt1, "", "", true);
                        //_frmTramites.LoadDataQuery(dt);
                        this.Close();
                    }
                    else
                    {
                        DateTime dt1 = dateTimePicker_fecha1.Value;
                        DateTime dt2 = dateTimePicker_fecha2.Value;
                        DataTable dt = QuerySpecific.myQuery("Fecha", currentDt, dt1, dt2, "", "", true);
                        //_frmTramites.LoadDataQuery(dt);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta: " + ex);
            }
        }
        // Today, Yestarday, Week, Month
        private void btn_imprimirPorHoy_Click(object sender, EventArgs e)
        {
            DataTable dt = QuerySpecific.myQuery("Hoy", currentDt, DateTime.Now, DateTime.Now, "", "", true);
            //_frmTramites.LoadDataQuery(dt);
            this.Close();
        }
        private void btn_imprimirPorAyer_Click(object sender, EventArgs e)
        {
            DataTable dt = QuerySpecific.myQuery("Ayer", currentDt, DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-1), "", "", true);
            //_frmTramites.LoadDataQuery(dt);
            this.Close();
        }
        private void btn_imprimirPorSemana_Click(object sender, EventArgs e)
        {
            DataTable dt = QuerySpecific.myQuery("Semana", currentDt, Fechas.firstDayOfWeek, Fechas.lastDayOfWeek, "", "", true);
            //_frmTramites.LoadDataQuery(dt);
            this.Close();
        }
        private void btn_imprimirPorMes_Click(object sender, EventArgs e)
        {
            DataTable dt = QuerySpecific.myQuery("Mes", currentDt, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth, "", "", true);
            //_frmTramites.LoadDataQuery(dt);
            this.Close();
        }

        // Query especificas:
        private void btn_imprimirPorFechaAndErrores_Click(object sender, EventArgs e)
        {
            // error
            try
            {
                var values = Fechas.checkCorrectDate(dateTimePicker_fecha9, dateTimePicker_fecha10);
                if (values.Item1)
                {
                    bool isError = true;
                    if (radioButton_siError.Checked) { isError = true; } else { isError = false; }

                    if (values.Item2)
                    {
                        DataTable dt = QuerySpecific.myQuery("Fecha_Inscripto", currentDt, dateTimePicker_fecha9.Value, dateTimePicker_fecha9.Value, "", "", isError);
                        //_frmTramites.LoadDataQuery(dt);
                        this.Close();
                    }
                    else
                    {
                        DataTable dt = QuerySpecific.myQuery("Fecha_Inscripto", currentDt, dateTimePicker_fecha9.Value, dateTimePicker_fecha10.Value, "", "", isError);
                        //_frmTramites.LoadDataQuery(dt);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta: " + ex);
            }
        }
        private void btn_imprimirPorFechaAndEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                var values = Fechas.checkCorrectDate(dateTimePicker_fecha3, dateTimePicker_fecha4);
                if (values.Item1)
                {
                    string empleado = comboBox_empleados1.GetItemText(comboBox_empleados1.SelectedItem);

                    if (values.Item2)
                    {
                        DateTime dt1 = dateTimePicker_fecha3.Value;
                        DataTable dt = QuerySpecific.myQuery("Fecha_Empleado", currentDt, dt1, dt1, "", empleado, true);
                        //_frmTramites.LoadDataQuery(dt);
                        this.Close();
                    }
                    else
                    {
                        DateTime dt1 = dateTimePicker_fecha3.Value;
                        DateTime dt2 = dateTimePicker_fecha4.Value;

                        DataTable dt = QuerySpecific.myQuery("Fecha_Empleado", currentDt, dt1, dt2, "", empleado, true);
                        //_frmTramites.LoadDataQuery(dt);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta: " + ex);
            }
        }
        private void btn_imprimirPorFechaAndInscripto_Click(object sender, EventArgs e)
        {
            try
            {
                var values = Fechas.checkCorrectDate(dateTimePicker_fecha7, dateTimePicker_fecha8);
                if (values.Item1)
                {
                    bool isIncripto = true;
                    if (radioButton_siInscriptos.Checked) { isIncripto = true; } else { isIncripto = false; }

                    if (values.Item2)
                    {
                        DataTable dt = QuerySpecific.myQuery("Fecha_Inscripto", currentDt, dateTimePicker_fecha7.Value, dateTimePicker_fecha7.Value, "", "", isIncripto);
                        //_frmTramites.LoadDataQuery(dt);
                        this.Close();
                    }
                    else
                    {
                        DataTable dt = QuerySpecific.myQuery("Fecha_Inscripto", currentDt, dateTimePicker_fecha7.Value, dateTimePicker_fecha8.Value, "", "", isIncripto);
                        //_frmTramites.LoadDataQuery(dt);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta: " + ex);
            }
        }
        private void btn_imprimirPorFechaAndProcesado_Click(object sender, EventArgs e)
        {
            try
            {
                var values = Fechas.checkCorrectDate(dateTimePicker_fecha5, dateTimePicker_fecha6);
                if (values.Item1)
                {
                    bool etapa = true;
                    if (radioButton_siProcesados.Checked) { etapa = true; } else { etapa = false; }

                    if (values.Item2)
                    {
                        DataTable dt = QuerySpecific.myQuery("Fecha_Procesado", currentDt, dateTimePicker_fecha5.Value, dateTimePicker_fecha5.Value, "", "", etapa);
                        //_frmTramites.LoadDataQuery(dt);
                        this.Close();
                    }
                    else
                    {
                        DataTable dt = QuerySpecific.myQuery("Fecha_Procesado", currentDt, dateTimePicker_fecha5.Value, dateTimePicker_fecha6.Value, "", "", etapa);
                        //_frmTramites.LoadDataQuery(dt);
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta: " + ex);
            }
        }

       // Enter and Leave in dominio
        private void txtBox_dominio_Enter(object sender, EventArgs e)
        {
            if (txtBox_dominio.Text == "EJ: AA111XX")
            {
                txtBox_dominio.Text = "";
                txtBox_dominio.ForeColor = System.Drawing.Color.Black;
            }
        }
        private void txtBox_dominio_Leave(object sender, EventArgs e)
        {
            if (txtBox_dominio.Text == "")
            {
                txtBox_dominio.Text = "EJ: AA111XX";
                txtBox_dominio.ForeColor = System.Drawing.Color.Gray;
            }
        }

        // RadioButtons Checks
        private void radioButton_siProcesados_Click(object sender, EventArgs e)
        {
            CheckRadioButtonClicked(radioButton_siProcesados, radioButton_noProcesados);
        }
        private void radioButton_noProcesados_Click(object sender, EventArgs e)
        {
            CheckRadioButtonClicked(radioButton_noProcesados, radioButton_siProcesados);
        }
        private void radioButton_siInscriptos_Click(object sender, EventArgs e)
        {
            CheckRadioButtonClicked(radioButton_siInscriptos, radioButton_noInscriptos);
        }
        private void radioButton_noInscriptos_Click(object sender, EventArgs e)
        {
            CheckRadioButtonClicked(radioButton_noInscriptos, radioButton_siInscriptos);
        }
        private void radioButton_siError_Click(object sender, EventArgs e)
        {
            CheckRadioButtonClicked(radioButton_siError, radioButton_noError);
        }
        private void radioButton_noError_Click(object sender, EventArgs e)
        {
            CheckRadioButtonClicked(radioButton_noError, radioButton_siError);
        }

        private void barra_titulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frm_tramites_query_Load(object sender, EventArgs e)
        {

        }
    }
}
