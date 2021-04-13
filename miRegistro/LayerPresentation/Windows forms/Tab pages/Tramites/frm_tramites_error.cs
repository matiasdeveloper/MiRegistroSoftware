using LayerBusiness;
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
    public partial class frm_tramites_error : Form
    {
        // Move form with mouse down in bar
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public frm_tramites_error(int id, string nombre, string dominio, string fecha, frm_tramites frm = null, frm_tramites_pantallaCompleta frm1 = null)
        {
            InitializeComponent();

            lbl_dominio.Text = dominio;
            lbl_nombre.Text = nombre;
            lbl_fecha.Text = fecha;

            this.idTramite = id;
            lbl_id.Text = id.ToString();

            LoadComboBoxErrores(comboBox_tipoError);
        }

        private int idTramite;
        private int codCategoriaError;
        private int codEmpleado;
        private string observaciones;

        private void LoadComboBoxErrores(ComboBox cb)
        {
            Cn_Tramites objects = new Cn_Tramites();
            DataTable dt = objects.mostarErrores();
            dt.Rows.RemoveAt(0);
            cb.DisplayMember = "Nombre";
            cb.ValueMember = "Cod";
            cb.DataSource = dt;
        }

        private void DeleteFields()
        {
            txtbox_observaciones.Text = "Ingrese las observaciones del error";
            comboBox_tipoError.SelectedIndex = 0;
            comboBox_empleadoerror.SelectedIndex = 0;
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

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtbox_observaciones.Text == "Ingrese las observaciones del error")
            {
                txtbox_observaciones.Text = "";
                txtbox_observaciones.ForeColor = System.Drawing.Color.Black;
            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txtbox_observaciones.Text == "")
            {
                txtbox_observaciones.Text = "Ingrese las observaciones del error";
                txtbox_observaciones.ForeColor = System.Drawing.Color.LightGray;
            }
        }

        private void btn_c1_siguiente_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 1;
            c1.Checked = true;
        }

        private void btn_c2_volver_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 0;
        }

        bool ValidarTabDetallesError()
        {
            bool s = true;
            if (comboBox_tipoError.SelectedIndex < 0 || comboBox_empleadoerror.SelectedIndex < 0)
            {
                s = false;
                return s;
            }
            if (txtbox_observaciones.Text != "" || txtbox_observaciones.Text != "Ingrese las observaciones del error")
            {
                s = false;
                return s;
            }
            return s;
        }

        bool CargarError() 
        {
            bool result = true;
            InitializeVariables();
            try
            {
                //UtilitiesCommon.layerBusiness.cn_tramites.actualizarError(idTramite, observaciones, 1, codCategoriaError);
                DeleteFields();
                //RefreshData();

                frm_successdialog f = new frm_successdialog(2);
                f.Show();
            }
            catch (Exception ex)
            {
                result = false;
                MessageBox.Show(ex.ToString());
            }
            return result;
        }

        private void InitializeVariables()
        {
            int codError = Convert.ToInt32(comboBox_tipoError.SelectedValue.ToString());
            codCategoriaError = codError;


            int codEmpleado = Convert.ToInt32(comboBox_empleadoerror.SelectedValue.ToString());
            this.codEmpleado = codEmpleado;

            observaciones = textBox_observaciones.Text.ToLower();
        }

        private void btn_c2_siguiente_Click(object sender, EventArgs e)
        {
            // Cargar error
            if (ValidarTabDetallesError()) 
            {
                if (CargarError()) 
                {
                    tab.SelectedIndex = 2;
                    c2.Checked = true;
                    c3.Checked = true;
                }
            }
        }
        private void btn_c4_ingresartramite_Click(object sender, EventArgs e)
        {
            tab.SelectedIndex = 0;
            DeleteFields();
        }

        private void frm_tramites_error_Load(object sender, EventArgs e)
        {

        }
        private void btn_close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuSeparator4_Load(object sender, EventArgs e)
        {

        }
    }
}
