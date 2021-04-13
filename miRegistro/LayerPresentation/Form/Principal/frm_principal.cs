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
using Bunifu.Framework.UI;

namespace LayerPresentation
{
    public partial class frm_principal :  Form // Hereda de system.windows.form
    {
        public frm_principal()
        {
            InitializeComponent();

            currentSidebarButton = btn_dashboard;
            ActivateButtonSidebar(btn_dashboard);
            OpenFormInPanel(new frm_escritorio());
        }

        private protected BunifuFlatButton currentSidebarButton;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        public extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        public extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void OpenFormInPanel(object Formhijo)
        {
            if (this.pn_contenedor.Controls.Count > 0)
                this.pn_contenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.pn_contenedor.Controls.Add(fh);
            this.pn_contenedor.Tag = fh;
            fh.Show();
        }
        private void SidebarON()
        {
            pn_sidebar.Visible = false;
            TransitionSidebar.Show(pn_sidebar);
        }

        private void ActivateButtonSidebar(object senderBtn)
        {
            if (senderBtn != null)
            {
                DisableButtonSidebar();
                currentSidebarButton = (BunifuFlatButton)senderBtn;
                currentSidebarButton.Normalcolor = Color.Black;
                currentSidebarButton.selected = true;
            }
        }
        private void DisableButtonSidebar()
        {
            if (currentSidebarButton != null)
            {
                currentSidebarButton.selected = false;
                currentSidebarButton.Normalcolor = Color.Transparent;
            }
        }
        
        private void LoadUserData()
        {
            lbl_electronico.Text = UserLoginCache.Email;
            lbl_nombre.Text = UserLoginCache.Nombre;
            lbl_permisos.Text = UserLoginCache.Priveleges;
            lbl_lastacess.Text = UserLoginCache.Fecha_UltimoAcceso.ToShortDateString();
        }
        private protected void LoadAccessPrivileges()
        {
            if (UserLoginCache.Priveleges == Privileges.Administrador)
            {
                // Code here activate or desactive functions
            }
        }
        public void LoadUserColor(Color color) 
        {
            pn_sidebar.GradientBottomLeft = color;
            pn_sidebar.GradientBottomRight = color;
            pn_sidebar.GradientTopLeft = color;
            pn_sidebar.GradientTopRight = color;

            pn_tittle_bar.GradientBottomRight = color;
            pn_tittle_bar.GradientTopLeft = color;

            //pn_buttons.GradientBottomLeft = color;
            //pn_buttons.GradientBottomRight = color;
            pn_buttons.GradientTopLeft = color;
            pn_buttons.GradientTopRight = color;

            //pn_infouser.GradientBottomLeft = color;
            //pn_userinfo.GradientBottomRight = color;
            pn_infouser.GradientTopRight = color;
            pn_infouser.GradientTopLeft = color;

            //pn_brand.GradientBottomLeft = color;
            //pn_brand.GradientBottomRight = color;
            pn_brand.GradientTopLeft = color;
            pn_brand.GradientTopRight = color;
        }
        private protected void Logout()
        {
            if (MessageBox.Show("Estas seguro que deseas cerrar sesion?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        // Buttons Sidebar
        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            if (!(currentSidebarButton == sender))
            {
                ActivateButtonSidebar(sender);
                OpenFormInPanel(new frm_escritorio());
            }
        }
        private void btn_tramites_Click_1(object sender, EventArgs e)
        {
            if (!(currentSidebarButton == sender))
            {
                ActivateButtonSidebar(sender);
                OpenFormInPanel(new frm_tramites());
            }
        }
        private void btn_formularios_Click(object sender, EventArgs e)
        {
            if (!(currentSidebarButton == sender))
            {
                ActivateButtonSidebar(sender);
                OpenFormInPanel(new frm_formularios());
            }
        }
        private void btn_employees_Click(object sender, EventArgs e)
        {
            if (!(currentSidebarButton == sender))
            {
                ActivateButtonSidebar(sender);
                OpenFormInPanel(new frm_empleados());
            }
        }
        private void btn_statistics_Click(object sender, EventArgs e)
        {
            if (!(currentSidebarButton == sender))
            {
                ActivateButtonSidebar(sender);
                OpenFormInPanel(new frm_estadisticas());
            }
        }
        private void btn_config_Click(object sender, EventArgs e)
        {
            if (!(currentSidebarButton == sender))
            {
                ActivateButtonSidebar(sender);
                OpenFormInPanel(new frm_configuracion());
            }
        }
        private void btn_logout_Click(object sender, EventArgs e)
        {
            Logout();
        }
        // Tittle bar
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
        
        private void Frm_principal_Load(object sender, EventArgs e)
        {          
            LoadUserData();
            LoadAccessPrivileges();

            LoadUserColor(Properties.Settings.Default.Color);
            
            Alertas.BuscarAlertas();

            SidebarON();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            txtBox_fecha.Text = DateTime.Now.ToString();
        }
    }
}
