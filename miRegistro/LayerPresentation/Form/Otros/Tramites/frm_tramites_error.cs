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

            _handlerTPc = frm1;
            _handlerTramites = frm;

            lbl_dominio.Text = dominio;
            lbl_nombre.Text = nombre;
            lbl_fecha.Text = fecha;
            this.id = id;
            lbl_id.Text = id.ToString();

            displayErrores(comboBox_tipoError);
        }

        Cn_Tramites _cnObject = new Cn_Tramites();

        frm_tramites_pantallaCompleta _handlerTPc;
        frm_tramites _handlerTramites;

        private int id;
        private int cod_error;
        private string observaciones;

        private void displayErrores(ComboBox cb)
        {
            Cn_Tramites objects = new Cn_Tramites();
            DataTable dt = objects.mostarErrores();
            dt.Rows.RemoveAt(0);
            cb.DisplayMember = "Nombre";
            cb.ValueMember = "Cod";
            cb.DataSource = dt;
        }

        private bool initVariables()
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
        private void deleteFields()
        {
            textBox1.Text = "Ingrese las observaciones del error";
            comboBox_tipoError.SelectedIndex = 0;
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
                    int cod = 0;
                    if (checkBox_errores.Checked) 
                    {
                        cod = 1;
                    }
                    _cnObject.actualizarError(id, observaciones, cod, cod_error);
                    deleteFields();
                    frm_successdialog f = new frm_successdialog(2);
                    f.Show();

                    if(_handlerTramites != null) 
                    {
                        _handlerTramites.refreshAll();
                    }
                    if(_handlerTPc != null) 
                    {
                        _handlerTPc.refreshData();
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
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

        private void frm_tramites_error_Load(object sender, EventArgs e)
        {

        }
    }
}
