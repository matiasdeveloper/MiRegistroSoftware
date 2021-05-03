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
using LayerPresentation.Properties;
using LayerPresentation.Clases;
using LayerPresentation.Controllers;

namespace LayerPresentation
{
    public partial class Login : Form
    {
        protected LoginController oLoginController;

        public Login()
        {
            InitializeComponent();

            oLoginController = new LoginController(this);
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            //FindSavedUser();
        }

        private void txtBox_user_Enter_1(object sender, EventArgs e)
        {
            if (txtBox_user.Text == "usuarioejemplo")
            {
                txtBox_user.Text = "";
                txtBox_user.ForeColor = System.Drawing.Color.Black;
            }
        }
        private void txtBox_user_Leave_1(object sender, EventArgs e)
        {
            if (txtBox_user.Text == "")
            {
                txtBox_user.Text = "usuarioejemplo";
                txtBox_user.ForeColor = System.Drawing.Color.Silver;
            }
        }

        private void txtBox_pass_Enter_1(object sender, EventArgs e)
        {
            if (txtBox_pass.Text == "8 caracteres o mas")
            {
                txtBox_pass.Text = "";
                txtBox_pass.ForeColor = System.Drawing.Color.Black;
                txtBox_pass.UseSystemPasswordChar = true;
            }
        }
        private void txtBox_pass_Leave_1(object sender, EventArgs e)
        {
            if (txtBox_pass.Text == "")
            {
                txtBox_pass.Text = "8 caracteres o mas";
                txtBox_pass.ForeColor = System.Drawing.Color.Silver;
                txtBox_pass.UseSystemPasswordChar = false;
            }
        }
        private void btn_saveinfo_Click(object sender, EventArgs e)
        {
            checkBox_guardar.Checked = !(checkBox_guardar.Checked);
        }

        private void txtBox_user_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }
        private void txtBox_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }


        void MostrarOcultarPassword() 
        {
            if (txtBox_pass.Text != "8 caracteres o mas" || txtBox_pass.Text != "")
            {
                if (txtBox_pass.UseSystemPasswordChar)
                {
                    txtBox_pass.UseSystemPasswordChar = false;
                    //btn_showpassword.Image = LayerPresentation.Properties.Resources.invisible_64px;
                }
                else
                {
                    txtBox_pass.UseSystemPasswordChar = true;
                    //btn_showpassword.Image = LayerPresentation.Properties.Resources.eye_64px;
                }
            }
        }
        private void btn_showpassword_MouseEnter(object sender, EventArgs e)
        {
            MostrarOcultarPassword();
        }
        private void btn_showpassword_MouseLeave(object sender, EventArgs e)
        {
            MostrarOcultarPassword();
        }

        private void textboxUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }
        private void textboxUsuario_Enter(object sender, EventArgs e)
        {
            if (txtBox_user.Text == "usuarioejemplo")
            {
                txtBox_user.Text = "";
                txtBox_user.ForeColor = System.Drawing.Color.Black;
            }
        }
        private void textboxUsuario_Leave(object sender, EventArgs e)
        {
            if (txtBox_user.Text == "")
            {
                txtBox_user.Text = "usuarioejemplo";
                txtBox_user.ForeColor = System.Drawing.Color.Silver;
            }
        }

        private void textboxContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }
        private void textboxContraseña_Enter(object sender, EventArgs e)
        {
            if (txtBox_pass.Text == "8 caracteres o mas")
            {
                txtBox_pass.Text = "";
                txtBox_pass.ForeColor = System.Drawing.Color.Black;
                txtBox_pass.UseSystemPasswordChar = true;
            }
        }
        private void textboxContraseña_Leave(object sender, EventArgs e)
        {
            if (txtBox_pass.Text == "")
            {
                txtBox_pass.Text = "8 caracteres o mas";
                txtBox_pass.ForeColor = System.Drawing.Color.Silver;
                txtBox_pass.UseSystemPasswordChar = false;
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {

        }

        /*void Other() 
        {
            _cnUsuarios.IntializeLoginUserData(txtBox_user.Text);

            // Update last access
            _cnUsuarios.UpdateLastAccess(UserLoginCache.IdUser, DateTime.Now);
            UserLoginCacheOld.Fecha_UltimoAcceso = DateTime.Now;
        }*/
    }
}
