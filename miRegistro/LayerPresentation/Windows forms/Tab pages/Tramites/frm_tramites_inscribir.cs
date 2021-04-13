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

            this._frmTramitesPantallaCompleta = frm1;
            this._frmTramites = frm;

            lbl_dominio.Text = dominio;
            lbl_nombre.Text = nombre;
            lbl_fecha.Text = fecha;
            this.id = id;
            lbl_id.Text = id.ToString();
        }

        frm_tramites_pantallaCompleta _frmTramitesPantallaCompleta;
        frm_tramites _frmTramites;

        private int id;
        private int cod_empleado;

        private bool InitializeVariables()
        {
            bool isOk = true;
            cod_empleado = Convert.ToInt32(comboBox_empleados.SelectedValue);
            return isOk;
        }
        private void DeleteFields()
        {
            comboBox_empleados.SelectedIndex = 0;
        }
        private void RefreshData() 
        {
            if (_frmTramites != null)
            {
<<<<<<< HEAD:miRegistro/LayerPresentation/Windows forms/Tab pages/Tramites/frm_tramites_inscribir.cs
                //_frmTramites.RefreshAll();
=======
                _frmTramites.RefreshAll();
>>>>>>> 53e7dd443230e3e11d0379924015b683904fdb8a:miRegistro/LayerPresentation/Form/Otros/Tramites/frm_tramites_inscribir.cs
            }
            if (_frmTramitesPantallaCompleta != null)
            {
                _frmTramitesPantallaCompleta.RefreshDataTramites();
            }
        }
        private void btn_cargar_Click_1(object sender, EventArgs e)
        {
            if (InitializeVariables())
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

<<<<<<< HEAD:miRegistro/LayerPresentation/Windows forms/Tab pages/Tramites/frm_tramites_inscribir.cs
                    //UtilitiesCommon.layerBusiness.cn_tramites.inscribirTramite(id, cod, cod_empleado);
=======
                    Utilities_Common.layerBusiness.cn_tramites.inscribirTramite(id, cod, cod_empleado);
>>>>>>> 53e7dd443230e3e11d0379924015b683904fdb8a:miRegistro/LayerPresentation/Form/Otros/Tramites/frm_tramites_inscribir.cs
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

        private void barra_titulo_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void btn_close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frm_tramites_inscribir_Load(object sender, EventArgs e)
        {

        }
    }
}
