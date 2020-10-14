using LayerBusiness;
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
    public partial class frm_tramites_inscribir : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public frm_tramites_inscribir(int id, string nombre, string dominio, string fecha, frm_tramites frm = null, frm_tramites_pantallaCompleta frm1 = null)
        {
            InitializeComponent();
            DataTramites.DisplayEmpleados(comboBox_empleados);

            this._handlerTPc = frm1;
            this._handlerTramites = frm;

            lbl_dominio.Text = dominio;
            lbl_nombre.Text = nombre;
            lbl_fecha.Text = fecha;
            this.id = id;
            lbl_id.Text = id.ToString();
        }

        Cn_Tramites _cnObject = new Cn_Tramites();

        frm_tramites_pantallaCompleta _handlerTPc;
        frm_tramites _handlerTramites;

        private int id;
        private int cod_empleado;
        private bool initVariables()
        {
            bool isOk = true;
            cod_empleado = Convert.ToInt32(comboBox_empleados.SelectedValue);
            return isOk;
        }
        private void deleteFields()
        {
            comboBox_empleados.SelectedIndex = 0;
        }

        private void btn_close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_cargar_Click_1(object sender, EventArgs e)
        {
            if (initVariables())
            {
                try
                {
                    int cod = 0;
                    if (checkBox_inscripto.Checked) 
                    {
                        cod = 1;
                    }
                    else
                    {
                        cod = 0;
                        cod_empleado = 1;
                    }

                    _cnObject.inscribirTramite(id, cod, cod_empleado);
                    deleteFields();
                    frm_successdialog f = new frm_successdialog(2);
                    f.Show();

                    if(_handlerTramites != null) 
                    {
                        _handlerTramites.refreshAll();
                    }
                    if (_handlerTPc != null)
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

        private void barra_titulo_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void frm_tramites_inscribir_Load(object sender, EventArgs e)
        {

        }
    }
}
