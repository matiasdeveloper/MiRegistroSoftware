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

namespace LayerPresentation
{
    public partial class frm_principal : Form
    {
        private Cn_alertas _cnObject = new Cn_alertas();
        DataTable nuevaAlerta = new DataTable();

        public frm_principal()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private Button _currentBtn;
        private int stockBajo = 0;

        private frm_chat frm_Chat = new frm_chat();

        private void AbrirFormEnPanel(object Formhijo)
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
        private void activateButton(object senderBtn, Color color) 
        {
            if(senderBtn != null) 
            {
                disableButton();
                _currentBtn = (Button)senderBtn;
                _currentBtn.BackColor = Color.FromArgb(45, 66, 91);
                _currentBtn.ForeColor = color;
            }
        }
        private void disableButton() 
        {
            if(_currentBtn != null) 
            {
                _currentBtn.BackColor = Color.FromArgb(15, 15, 15);
                _currentBtn.ForeColor = Color.White;
            }
        }
        private void buscarNuevasAlertas(int StockMenorQue)
        {
            Cn_alertas objects = new Cn_alertas();
            nuevaAlerta = _cnObject.buscarNuevasAlertas(StockMenorQue);
            if (!(nuevaAlerta.Rows.Count == 0))
            {
                DateTime now = new DateTime();
                now = DateTime.Now;
                int id = _cnObject.insertarNuevaAlerta(UserLoginCache.Username);
                foreach (DataRow fila in nuevaAlerta.Rows)
                {
                    string valor = fila[0].ToString();
                    _cnObject.insertarDetallesAlerta(id, Convert.ToInt32(valor), "Alerta de stock");
                }
                if (MessageBox.Show("Alerta de stock detectada!" + "\nPara mas infomarcion pressione 'SI'" + "\nPara descartar la alerta presione 'NO'", "ALERTA DE STOCK", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // Mostrar los formularios de la alerta con bajo stock.
                    frm_formularios_alerta mv = new frm_formularios_alerta(true, id, UserLoginCache.Fecha_UltimoAcceso.ToString(), UserLoginCache.Username);
                    mv.TopMost = true;
                    mv.Show();
                }
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
            activateButton(sender, Color.White);
            AbrirFormEnPanel(new frm_formularios());
        }
        private void btn_escritorio_Click(object sender, EventArgs e)
        {
            activateButton(sender, Color.White);
            AbrirFormEnPanel(new frm_escritorio());
        }
        private void btn_empleados_Click(object sender, EventArgs e)
        {
            activateButton(sender, Color.White);
            AbrirFormEnPanel(new frm_empleados());
        }
        private void btn_configuracion_Click(object sender, EventArgs e)
        {
            activateButton(sender, Color.White);
            AbrirFormEnPanel(new frm_configuracion());
        }
        private void btn_chat_Click(object sender, EventArgs e)
        {
            activateButton(sender, Color.White);
            AbrirFormEnPanel(frm_Chat);
        }
        private void btn_tramites_Click(object sender, EventArgs e)
        {
            activateButton(sender, Color.White);
            AbrirFormEnPanel(new frm_tramites());
        }
        private void btn_estadisticas_Click(object sender, EventArgs e)
        {
            activateButton(sender, Color.White);
            AbrirFormEnPanel(new frm_estadisticas());
        }
        private void btn_logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que deseas cerrar sesion?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
                Login log = new Login();
                log.Show();
            }
        }

        private void Frm_principal_Load(object sender, EventArgs e)
        {
            activateButton(btn_escritorio, Color.White);
            AbrirFormEnPanel(new frm_escritorio());

            stockBajo = Settings.Default.StockBajo;
            buscarNuevasAlertas(stockBajo);

            cargarDatosUsuario();
        }
    }
}
