using Models.SqlConnect;
using MiRegistro.Properties;
using MiRegistro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace Controllers
{
    public class LoginController
    {
        Login _view { get; set; }

        public LoginController(Login view) 
        {
            _view = view;
            _view.Load += new EventHandler(PersistanteConnection);
            _view.Load += new EventHandler(FindSavedUser);

            _view.btn_login.Click += new EventHandler(Autentificar);
        }

        private void PersistanteConnection(object sender, EventArgs e) 
        {
            PersistanteConnection pconn = new PersistanteConnection();
        }
        private void FindSavedUser(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Settings.Default.user))
            {
                _view.txtBox_user.Text = PasswordEncrypter.Decrypt(MiRegistro.Properties.Settings.Default.user);
                _view.txtBox_pass.Text = PasswordEncrypter.Decrypt(MiRegistro.Properties.Settings.Default.pass);
                _view.txtBox_pass.UseSystemPasswordChar = true;
                _view.checkBox_guardar.Checked = true;
            }
        }

        private void Autentificar(object sender, EventArgs e)
        {
            LoginViewModel model = new LoginViewModel();
            if (model.ValidateLogin(_view.txtBox_user.Text, _view.txtBox_pass.Text)) 
            {
                OpenSystem();
                RememberUser();
            }
        }

        private void RememberUser()
        {
            if (_view.checkBox_guardar.Checked)
            {
                MiRegistro.Properties.Settings.Default.user = PasswordEncrypter.Encrypt(_view.txtBox_user.Text);
                MiRegistro.Properties.Settings.Default.pass = PasswordEncrypter.Encrypt(_view.txtBox_pass.Text);
                MiRegistro.Properties.Settings.Default.Save();
            }
            else
            {
                if (PasswordEncrypter.Decrypt(MiRegistro.Properties.Settings.Default.user) == _view.txtBox_user.Text)
                {
                    MiRegistro.Properties.Settings.Default.user = "";
                    MiRegistro.Properties.Settings.Default.pass = "";
                    MiRegistro.Properties.Settings.Default.Save();
                }
            }
        }
        private protected void OpenSystem()
        {
            //frm_principal frmPrincipal = new frm_principal();
            //frmPrincipal.FormClosed += Logout;

            //frm_bienvenida frmBienvenida = new frm_bienvenida(frmPrincipal, _view);
            //frmBienvenida.Show();

            _view.Opacity = 0;
            _view.ShowIcon = false;
            _view.ShowInTaskbar = false;

            _view.Hide();
        }

        public void Logout(object sender, FormClosedEventArgs e)
        {
            _view.Show();
            _view.Opacity = 100;
            _view.WindowState = FormWindowState.Normal;

            _view.ShowIcon = true;
            _view.ShowInTaskbar = true;

            _view.txtBox_user.Text = "usuarioejemplo";
            _view.txtBox_pass.Text = "8 caracteres o mas";
            _view.txtBox_pass.UseSystemPasswordChar = false;
        }

    }
}
