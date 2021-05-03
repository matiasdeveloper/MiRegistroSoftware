using LayerPresentation.Clases;
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
    public partial class frm_tramites_insertar : Form
    {
        // Move form with mouse down in bar
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public frm_tramites_insertar()
        {
            InitializeComponent();

            /*DataTramites.DisplayEmpleados(comboBox_empleadoerror);
            DataTramites.DisplayEmpleados(comboBox_empleadoinscripto);
            DataTramites.DisplayEmpleados(comboBox_empleadoproceso);
            LoadComboBoxTramites(comboBox_tramites);*/
            LoadComboBoxErrores(comboBox_tipoError);
        }

        // Variables de carga
        Tuple<string, DateTime, int> datosTramite;
        Tuple<int, int, int, int> datosDetalleTramite;
        Tuple<int, int, int, string> datosObservacionTramite;

        // Variable de errores
        //private bool iniciarCarga = true;

        // Display combobox
        private void LoadComboBoxTramites(ComboBox cb)
        {
            //Cn_Tramites objects = new Cn_Tramites();
            //DataTable dt = objects.mostarTramites();
            cb.DisplayMember = "Nombre";
            cb.ValueMember = "Cod";
            //cb.DataSource = dt;
        }
        private void LoadComboBoxErrores(ComboBox cb)
        {
            //Cn_Tramites objects = new Cn_Tramites();
            //DataTable dt = objects.mostarErrores();
            cb.DisplayMember = "Nombre";
            cb.ValueMember = "Cod";
            //cb.DataSource = dt;
        }

        // Initialize Charge Tramites
        private void InitializeVariables() 
        {
            string tramite = comboBox_tramites.SelectedValue.ToString();
            int cod_tramite = Convert.ToInt32(tramite);     
            DateTime fecha = new DateTime(dateTime_fecha.Value.Year, dateTime_fecha.Value.Month, dateTime_fecha.Value.Day, 0, 0, 0);

            datosTramite = new Tuple<string, DateTime, int>(textBox_dominio.Text, fecha, cod_tramite);

            string empleado = comboBox_empleadoproceso.SelectedValue.ToString();
            int cod_empleado = Convert.ToInt32(empleado);
            string empleadoinscripto = comboBox_empleadoinscripto.SelectedValue.ToString();
            int cod_empleadoinscripto = Convert.ToInt32(empleadoinscripto);
            int cod_inscripto = 0;

            datosDetalleTramite = new Tuple<int, int, int, int>(1, cod_empleado, cod_inscripto, cod_empleadoinscripto);

            int error = 0;
            if (checkBox_errores.Checked) 
            {
                error = 1;
            }
            int cod_error = 0;
            switch (comboBox_tipoError.Text)
            {
                case "Sin errores":
                    cod_error = 0;
                    break;
                case "Error Parcial":
                    if (error == 1)
                    {
                        cod_error = 1;
                    }
                    break;
                case "Error Total":
                    if (error == 1)
                    {
                        cod_error = 2;
                    }
                    break;
                default:
                    cod_error = 0;
                    break;
            }
            string empleadoerror = comboBox_empleadoerror.SelectedValue.ToString();
            int cod_empleadoeerror = Convert.ToInt32(empleadoerror);

            datosObservacionTramite = new Tuple<int, int, int, string>(error, cod_error, cod_empleadoeerror, textBox_observaciones.Text);
        }
        private void DeleteFields() 
        {
            dateTime_fecha.Value = DateTime.Now;

            textBox_dominio.Text = "Ej: AA000XX";
            textBox_dominio.ForeColor = System.Drawing.Color.Silver;

            pn_inscribir.Visible = false;

            checkBox_errores.Checked = false;
            pn_categoriaerror.Visible = false;
            textBox_observaciones.Text = "Sin observaciones";

            comboBox_tipoError.SelectedValue = 0;
        }
        
        private void RefreshData() 
        {
            /*if (_frmTramites != null)
            {
                _frmTramites.RefreshAll();
            }
            if (_frmTramitesPantallaCompleta != null)
            {
                _frmTramitesPantallaCompleta.RefreshDataTramites();
            }*/
        }
        
        private bool CargarTramite()
        {
            bool result = true;

            InitializeVariables();
            try
            {
                //UtilitiesCommon.layerBusiness.cn_tramites.insertarTramite(datosTramite, datosDetalleTramite, datosObservacionTramite);
                DeleteFields();
                //RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                result = false;
            }

            return result;
        }

        private void frm_tramites_insertar_Load(object sender, EventArgs e)
        {

        }
        private void btn_c1_siguiente_Click(object sender, EventArgs e)
        {
            if (ValidarTabDatos()) 
            {
                tab.SelectedIndex = 1;
                c1.Checked = true;
            }
        }

        bool ValidarTabDatos() 
        {
            bool s = true;
            if(textBox_dominio.Text.Length < 4 || textBox_dominio.Text == "Ej: AA000XX") 
            {
                s = false;
                return s;
            }
            if(comboBox_tramites.SelectedIndex < 0) 
            {
                s = false;
                return s;
            }
            return s;
        }
        bool ValidarTabDetalle()
        {
            bool s = true;
            if(comboBox_empleadoproceso.SelectedIndex < 0) 
            {
                s = false;
                return s;
            }
            if(comboBox_empleadoinscripto.SelectedIndex < 0) 
            {
                s = false;
                return s;
            }
            return s;
        }
        bool ValidarTabObservaciones() 
        {
            bool s = true;
            if (checkBox_errores.Checked) 
            {
                if(comboBox_tipoError.SelectedIndex < 0 || comboBox_empleadoerror.SelectedIndex < 0) 
                {
                    s = false;
                    return s;
                }
            }
            return s;
        }

        private void btn_c2_siguiente_Click(object sender, EventArgs e)
        {
            if (ValidarTabDetalle()) 
            {
                tab.SelectedIndex = 2;
                c2.Checked = true;
            }
        }
        private void btn_c3_siguiente_Click(object sender, EventArgs e)
        {
            if (ValidarTabObservaciones()) 
            {
                // Insertar tramite
                if (CargarTramite())
                {
                    tab.SelectedIndex = 3;
                    c3.Checked = true;
                    c4.Checked = true;
                }
            }
        }
        private void btn_c4_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_c2_volver_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 0;
        }
        private void btn_c3_volver_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 1;
        }
        private void btn_c3_omitir_Click(object sender, EventArgs e)
        {
            if (ValidarTabObservaciones()) 
            {
                tab.SelectedIndex = 3;
                // Insertar tramite
            }
        }
        private void btn_c4_ingresartramite_Click(object sender, EventArgs e)
        {
            // Ingresar nuevo tramite
            tab.SelectedIndex = 0;
            DeleteFields();
        }

        private void c1_Click(object sender, EventArgs e)
        {
            c1.Checked = c1.Checked;
        }
        private void c2_Click(object sender, EventArgs e)
        {
            c2.Checked = c2.Checked;
        }
        private void c3_Click(object sender, EventArgs e)
        {
            c3.Checked = c3.Checked;
        }
        private void c4_Click(object sender, EventArgs e)
        {
            c4.Checked = c4.Checked;
        }

        private void btn_close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void checkBox_errores_OnChange(object sender, EventArgs e)
        {
            pn_categoriaerror.Visible = checkBox_errores.Checked;
        }
        private void textBox_dominio_Enter_1(object sender, EventArgs e)
        {
            if (textBox_dominio.Text == "Ej: AA000XX")
            {
                textBox_dominio.Text = "";
                textBox_dominio.ForeColor = System.Drawing.Color.Black;
            }
        }
        private void textBox_dominio_Leave_1(object sender, EventArgs e)
        {
            if (textBox_dominio.Text == "")
            {
                textBox_dominio.Text = "Ej: AA000XX";
                textBox_dominio.ForeColor = System.Drawing.Color.Silver;
            }
        }
        private void btn_checkboxerror_Click(object sender, EventArgs e)
        {
            checkBox_errores.Checked = !checkBox_errores.Checked;
            pn_categoriaerror.Visible = checkBox_errores.Checked;
        }

        private void textBox_dominio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }

        private void cb_etapa_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cb_etapa.SelectedIndex) 
            {
                case 0:
                    pn_inscribir.Visible = false;
                    pn_observar.Visible = false;
                    break;
                case 1:
                    pn_inscribir.Visible = true;
                    pn_observar.Visible = false;
                    break;
                case 2:
                    pn_observar.Visible = true;
                    pn_inscribir.Visible = false;
                    break;
            }
        }
    }
}
