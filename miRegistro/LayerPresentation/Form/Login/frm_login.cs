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
using LayerSoporte.Cache;
using LayerPresentation.Properties;
using LayerPresentation.Clases;

namespace LayerPresentation
{
    public partial class frm_login : Form
    {
        public frm_login()
        {
            InitializeComponent();
        }

        private Cn_Usuarios _cnObject = new Cn_Usuarios();

        #region Variables
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        #endregion
       
        private void txtBox_user_Enter(object sender, EventArgs e)
        {
            if(txtBox_user.Text == "Usuario") 
            {
                txtBox_user.Text = "";
                txtBox_user.ForeColor = Color.LightCyan;
            }
        }

        private void txtBox_user_Leave(object sender, EventArgs e)
        {
            if(txtBox_user.Text == "") 
            {
                txtBox_user.Text = "Usuario";
                txtBox_user.ForeColor = Color.DimGray;
            }
        }

        private void txtBox_pass_Enter(object sender, EventArgs e)
        {
            if (txtBox_pass.Text == "Contraseña")
            {
                txtBox_pass.Text = "";
                txtBox_pass.ForeColor = Color.LightCyan;
                txtBox_pass.UseSystemPasswordChar = true;
            }
        }

        private void txtBox_pass_Leave(object sender, EventArgs e)
        {
            if (txtBox_pass.Text == "")
            {
                txtBox_pass.Text = "Contraseña";
                txtBox_pass.ForeColor = Color.DimGray;
                txtBox_pass.UseSystemPasswordChar = false;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            try 
            {
                if (_cnObject.verificarAuntetificacion(txtBox_user.Text, txtBox_pass.Text) > 0)
                {
                    // Charge data from user
                    RememberUser();
                    _cnObject.IntializeLoginUserData(txtBox_user.Text);

                    // Update last access
                    _cnObject.UpdateLastAccess(UserLoginCache.IdUser, DateTime.Now);
                    UserLoginCache.Fecha_UltimoAcceso = DateTime.Now;

                    // Charge Bienvenida
                    frm_principal _objUI = new frm_principal();
                    _objUI.FormClosed += Logout;

                    frm_bienvenida objUI = new frm_bienvenida(_objUI, this);
                    objUI.Show();
                    //objUI.FormClosed += Logout;

                    this.Opacity = 0;
                    this.ShowIcon = false;
                    this.ShowInTaskbar = false;

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos! \nVuelve a intentarlo");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void RememberUser()
        {
            if (checkBox_guardar.Checked)
            {
                Properties.Settings.Default.user = Utilities_Encrypt_Decrypt.Encrypt(txtBox_user.Text);
                Properties.Settings.Default.pass = Utilities_Encrypt_Decrypt.Encrypt(txtBox_pass.Text);
                Properties.Settings.Default.Save();
            } 
            else 
            {
                if (Utilities_Encrypt_Decrypt.Decrypt(Properties.Settings.Default.user) == txtBox_user.Text) 
                {
                    Properties.Settings.Default.user = "";
                    Properties.Settings.Default.pass = "";
                    Properties.Settings.Default.Save();
                }
            }
        }
        private void FindSavedUser()
        {
            if (!String.IsNullOrEmpty(Settings.Default.user)) 
            {
                txtBox_user.Text = Utilities_Encrypt_Decrypt.Decrypt(Properties.Settings.Default.user);
                txtBox_pass.Text = Utilities_Encrypt_Decrypt.Decrypt(Properties.Settings.Default.pass);
                txtBox_pass.UseSystemPasswordChar = true;
                checkBox_guardar.Checked = true;
            }
        }
        
        public void Logout(object sender, FormClosedEventArgs e)
        {
            this.Show();
            this.Opacity = 100;
            this.WindowState = FormWindowState.Normal;

            this.ShowIcon = true;
            this.ShowInTaskbar = true;

            txtBox_pass.Clear();
            txtBox_user.Text = "Usuario";
            txtBox_user.Clear();
            txtBox_pass.Text = "Contraseña";
            txtBox_pass.UseSystemPasswordChar = false;
            FindSavedUser();
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Para cambiar la contraseña o cualquier dato de su cuenta Comuniquese con el usuario root del sistema" + "\nGracias.","Atencion!", MessageBoxButtons.OK);
            //var recoverPassword = new Login_recoverPassword();
            //recoverPassword.ShowDialog();
        }

        private void txtBox_user_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }
        private void txtBox_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }
        private void Login_Load(object sender, EventArgs e)
        {
            FindSavedUser();
        }
    }
}
