using LayerPresentation.Models.SqlConnect;
using LayerPresentation.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace LayerPresentation.Controllers
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
                _view.txtBox_user.Text = PasswordEncrypter.Decrypt(Properties.Settings.Default.user);
                _view.txtBox_pass.Text = PasswordEncrypter.Decrypt(Properties.Settings.Default.pass);
                _view.txtBox_pass.UseSystemPasswordChar = true;
                _view.checkBox_guardar.Checked = true;
            }
        }

        private void Autentificar(object sender, EventArgs e)
        {
            MessageBox.Show("Autentificando");
            //OpenSystem();
            //RememberUser();
        }

        private void RememberUser()
        {
            if (_view.checkBox_guardar.Checked)
            {
                Properties.Settings.Default.user = PasswordEncrypter.Encrypt(_view.txtBox_user.Text);
                Properties.Settings.Default.pass = PasswordEncrypter.Encrypt(_view.txtBox_pass.Text);
                Properties.Settings.Default.Save();
            }
            else
            {
                if (PasswordEncrypter.Decrypt(Properties.Settings.Default.user) == _view.txtBox_user.Text)
                {
                    Properties.Settings.Default.user = "";
                    Properties.Settings.Default.pass = "";
                    Properties.Settings.Default.Save();
                }
            }
        }
        private protected void OpenSystem()
        {
            frm_principal frmPrincipal = new frm_principal();
            frmPrincipal.FormClosed += Logout;

            frm_bienvenida frmBienvenida = new frm_bienvenida(frmPrincipal, _view);
            frmBienvenida.Show();

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
