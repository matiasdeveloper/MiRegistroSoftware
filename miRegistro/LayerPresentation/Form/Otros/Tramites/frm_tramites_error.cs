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

            _frmTramitesPantallaCompleta = frm1;
            _frmTramites = frm;

            lbl_dominio.Text = dominio;
            lbl_nombre.Text = nombre;
            lbl_fecha.Text = fecha;
            this.id = id;
            lbl_id.Text = id.ToString();

            LoadComboBoxErrores(comboBox_tipoError);
        }

        frm_tramites_pantallaCompleta _frmTramitesPantallaCompleta;
        frm_tramites _frmTramites;

        private int id;
        private int cod_error;
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

        // Initialize variables previous to charge the error to the id tramite
        private bool InitializeVariables()
        {
            bool isOk = true;
            if(textBox1.Text == "" || textBox1.Text == "Ingrese las observaciones del error") 
            {
                MessageBox.Show("Ingrese las observaciones del tramite!", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                isOk = false;
                return isOk;
            } else 
            {
                observaciones = textBox1.Text;
            }
            // Tipo de error
            switch (comboBox_tipoError.Text)
            {
                case "Error Parcial":
                    cod_error = 1;
                    break;
                case "Error Total":
                    cod_error = 2;
                    break;
                default:
                    cod_error = 1;
                    break;
            }

            return isOk;
        }
        private void DeleteFields()
        {
            textBox1.Text = "Ingrese las observaciones del error";
            comboBox_tipoError.SelectedIndex = 0;
        }

        private void RefreshData() 
        {
            if (_frmTramites != null)
            {
                _frmTramites.RefreshAll();
            }
            if (_frmTramitesPantallaCompleta != null)
            {
                _frmTramitesPantallaCompleta.RefreshDataTramites();
            }
        }
        private void btn_cargar_Click(object sender, EventArgs e)
        {
            if (InitializeVariables())
            {
                try
                {
                    int cod = 0;
                    if (checkBox_errores.Checked) 
                    {
                        cod = 1;
                    }
                    Utilities_Common.layerBusiness.cn_tramites.actualizarError(id, observaciones, cod, cod_error);
                    DeleteFields();
                    RefreshData();

                    frm_successdialog f = new frm_successdialog(2);
                    f.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally 
                {
                    this.Close();
                }
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Ingrese las observaciones del error")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Ingrese las observaciones del error";
                textBox1.ForeColor = Color.LightGray;
            }
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
        private void frm_tramites_error_Load(object sender, EventArgs e)
        {

        }
    }
}
