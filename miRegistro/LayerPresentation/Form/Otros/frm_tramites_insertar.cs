using LayerBusiness;
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
        public frm_tramites_insertar(frm_tramites frm, bool isEdit, int id, string[] data)
        {
            InitializeComponent();
            displayEmpleados(comboBox_empleados);
            displayTramites(comboBox_tramites);
            displayErrores(comboBox_tipoError);

            _frmHandler = frm;
            this.isEdit = isEdit;
            this.id = id;

            if (isEdit == true && data != null)
            {
                barra_titulo.BackColor = Color.Orange;
                lbl_tittle.Text = "Editar tramite ID: " + id;
                textBox_dominio.Text = data[0];

                dateTime_fecha.Enabled = false;

                int index = comboBox_tramites.FindStringExact(data[1]);
                comboBox_tramites.SelectedValue = index + 1;

                index = comboBox_empleados.FindString(data[2]);
                comboBox_empleados.SelectedValue = index + 1;

                if (data[3] == "Procesado")
                { checkBox_procesados.Checked = true; } else { checkBox_procesados.Checked = false; }
                if (data[4] == "True")
                { checkBox_errores.Checked = true; } else { checkBox_errores.Checked = false; }
                comboBox_tipoError.SelectedIndex = comboBox_tipoError.FindString(data[5]);
                textBox_observaciones.Text = data[6];

                btn_cargar.Text = "Actualizar tramite";
                btn_cargar.FlatAppearance.BorderColor = Color.Orange;
                btn_cargar.Image = LayerPresentation.Properties.Resources.edit;
            }        
        }
        Cn_Tramites _cnObject = new Cn_Tramites();
        frm_tramites _frmHandler;
        // Move form with mouse down in bar
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        
        // Variables de carga
        private string dominio;
        private int codigo;
        private Random ran = new Random();
        private DateTime fecha;
        private int cod_tramite;
        private int cod_empleado;
        private int cod_etapa;
        private int error;
        private int cod_error;
        private string observaciones;
        // Variables de edicion
        private bool isEdit;
        private int id;

        // Variable de errores
        private bool iniciarCarga = true;

        // Display combobox
        private void displayEmpleados(ComboBox cb)
        {
            Cn_Tramites objects = new Cn_Tramites();
            DataTable dt = objects.mostrarEmpleados();
            cb.DisplayMember = "Nombre";
            cb.ValueMember = "Cod";
            cb.DataSource = dt;
        }
        private void displayTramites(ComboBox cb)
        {
            Cn_Tramites objects = new Cn_Tramites();
            DataTable dt = objects.mostarTramites();
            cb.DisplayMember = "Nombre";
            cb.ValueMember = "Cod";
            cb.DataSource = dt;
        }
        private void displayErrores(ComboBox cb)
        {
            Cn_Tramites objects = new Cn_Tramites();
            DataTable dt = objects.mostarErrores();
            cb.DisplayMember = "Nombre";
            cb.ValueMember = "Cod";
            cb.DataSource = dt;
        }
        // Insert data
        private bool initVariables() 
        {
            // Dominio
            dominio = textBox_dominio.Text;
            if(string.IsNullOrEmpty(textBox_dominio.Text))
            {
                iniciarCarga = false;
                MessageBox.Show("Campo de dominio vacio, por favor para continuar con la carga del tramite se debera ingresar un dominio (Ej: 'AA096UY')", "Atencion Dominio Vacio! Error detectado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return iniciarCarga;
            }
            // Fecha
            fecha = new DateTime(dateTime_fecha.Value.Year, dateTime_fecha.Value.Month, dateTime_fecha.Value.Day, 0,0,0);
            // Codifica las variables tramites, empleados y etapas
            // Tramites
            string tramite = comboBox_tramites.SelectedValue.ToString();
            cod_tramite = Convert.ToInt32(tramite);
            // Empleados
            string empleado = comboBox_empleados.SelectedValue.ToString();
            cod_empleado = Convert.ToInt32(empleado);
            // Etapas
            cod_etapa = 1;
            // Carga errores
            if (checkBox_errores.Checked == true)
            {
                error = 1;
                if (comboBox_tipoError.Text == "Sin Errores")
                {
                    iniciarCarga = false;
                    MessageBox.Show("Por favor seleccione el tipo de error! (Ej: ERROR PARCIAL o ERROR TOTAL)", "Atencion Campo de tipo de error Vacio! Error detectado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                error = 0;
            }
            // Tipo de error
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
            // Carga las observaciones
            observaciones = textBox_observaciones.Text;
            if (checkBox_errores.Checked == true && string.IsNullOrEmpty(textBox_observaciones.Text))
            {
                iniciarCarga = false;
                MessageBox.Show("Las observaciones se encuentran vacias y detectamos la casilla de error activada, por favor para continuar especifique el tipo de error en el campo de observaciones!", "Atencion especifique tipo de error! Error detectado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return iniciarCarga;
            }
            return iniciarCarga;
        }
        private void deleteFields() 
        {
            dateTime_fecha.Value = DateTime.Now;

            textBox_dominio.Text = "";
            textBox_observaciones.Text = "No";
            checkBox_errores.Checked = false;
            checkBox_procesados.Checked = true;
            comboBox_tipoError.SelectedValue = 0;
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void barra_titulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void btn_cargar_Click(object sender, EventArgs e)
        {
            if (initVariables()) 
            {
                try
                {
                    if (!isEdit)
                    {
                        _cnObject.insertarTramite(dominio, fecha, cod_tramite, cod_empleado, observaciones, error, cod_error);
                        deleteFields();
                        frm_successdialog f = new frm_successdialog(0);
                        f.Show();
                        _frmHandler.refreshData();
                    }
                    else
                    {
                        _cnObject.actualizarTramite(id, dominio, cod_tramite, cod_empleado, observaciones, error, cod_error);
                        deleteFields();
                        frm_successdialog f = new frm_successdialog(2);
                        f.Show();
                        _frmHandler.refreshData();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        private void frm_tramites_insertar_Load(object sender, EventArgs e)
        {

        }
    }
}
