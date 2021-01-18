using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using LayerBusiness;
using LayerPresentation.Properties;
using LayerSoporte.Cache;
using LayerPresentation.Clases;

namespace LayerPresentation
{
    public partial class frm_principal :  Form // Hereda de system.windows.form
    {
        public frm_principal()
        {
            InitializeComponent();
        }

        private Button currentButton;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        public extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        public extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void OpenFormInPanel(object Formhijo)
        {
            if (this.panel_contenedor.Controls.Count > 0)
                this.panel_contenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panel_contenedor.Controls.Add(fh);
            this.panel_contenedor.Tag = fh;
            fh.Show();
        }
        private void ActivateButton(object senderBtn, Color color) 
        {
            if(senderBtn != null) 
            {
                DisableButton();
                currentButton = (Button)senderBtn;
                currentButton.BackColor = Color.FromArgb(0, 104, 148);
                currentButton.ForeColor = color;
            }
        }
        private void DisableButton() 
        {
            if(currentButton != null) 
            {
                currentButton.BackColor = Color.FromArgb(30, 30, 30);
                currentButton.ForeColor = Color.White;
            }
        }
        
        private void cargarDatosUsuario()
        {
            lbl_electronico.Text = UserLoginCache.Email;
            lbl_nombre.Text = UserLoginCache.Nombre;
            lbl_permisos.Text = UserLoginCache.Priveleges;
            lbl_lastacess.Text = UserLoginCache.Fecha_UltimoAcceso.ToShortDateString();

            cargarPrivilegios();
        }
        private void cargarPrivilegios()
        {
            if (UserLoginCache.Priveleges == Privileges.Administrador)
            {
                // Code here activate or desactive functions
            }
        }
        public void cargarColor(Color color) 
        {
            barra_info.BackColor = color;
            barra_titulo.BackColor = color;
            barra_dev.BackColor = color;
        }
        private void barra_titulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btn_stock_Click(object sender, EventArgs e)
        {
            if(!(currentButton == sender)) 
            {
                ActivateButton(sender, Color.White);
                OpenFormInPanel(new frm_formularios());
            }
        }
        private void btn_escritorio_Click(object sender, EventArgs e)
        {
            if(!(currentButton == sender)) 
            {
                ActivateButton(sender, Color.White);
                OpenFormInPanel(new frm_escritorio());
            }
        }
        private void btn_empleados_Click(object sender, EventArgs e)
        {
            if(!(currentButton == sender)) 
            {
                ActivateButton(sender, Color.White);
                OpenFormInPanel(new frm_empleados());
            }
        }
        private void btn_configuracion_Click(object sender, EventArgs e)
        {
            if(!(currentButton == sender)) 
            {
                ActivateButton(sender, Color.White);
                OpenFormInPanel(new frm_configuracion());
            }
        }
        private void btn_chat_Click(object sender, EventArgs e)
        {
            if(!(currentButton == sender)) 
            {
                ActivateButton(sender, Color.White);
                //OpenFormInPanel(frm_Chat);
            }
        }
        private void btn_tramites_Click(object sender, EventArgs e)
        {
            if (!(currentButton == sender))
            {
                ActivateButton(sender, Color.White);
                OpenFormInPanel(new frm_tramites());
            }
        }
        private void btn_estadisticas_Click(object sender, EventArgs e)
        {
            if (!(currentButton == sender))
            {
                ActivateButton(sender, Color.White);
                OpenFormInPanel(new frm_estadisticas());
            }
        }
        private void btn_logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que deseas cerrar sesion?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Frm_principal_Load(object sender, EventArgs e)
        {
            ActivateButton(btn_escritorio, Color.White);
            OpenFormInPanel(new frm_escritorio());
            
            cargarDatosUsuario();
            cargarColor(Properties.Settings.Default.Color);
            
            Alertas.BuscarAlertas();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            txtBox_fecha.Text = DateTime.Now.ToString();
        }
    }
}
