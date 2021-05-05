using MiRegistro.Properties;
using MiRegistro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using MiRegistro.Models;
using MiRegistro.Views.Main;

namespace Controllers
{
    public class LoginController
    {
        LoginViewModel _model = new LoginViewModel();
        Login _view { get; set; }

        public LoginController(Login view) 
        {
            _view = view;
            _view.Load += new EventHandler(FindSavedUser);

            _view.btn_login.Click += new EventHandler(Autentificar);
        }

        private void FindSavedUser(object sender, EventArgs e)
        {
            usuario usuario = _model.FindSavedUser();
            if (usuario.Usuario1 != null)
            {
                _view.txtBox_user.Text = usuario.Usuario1;
                _view.txtBox_pass.Text = usuario.Contraseña;
                _view.txtBox_pass.UseSystemPasswordChar = true;
                _view.checkBox_guardar.Checked = true;
            }
        }

        private void Autentificar(object sender, EventArgs e)
        {
            if (_model.ValidateLogin(_view.txtBox_user.Text, _view.txtBox_pass.Text) != null) 
            {
                OpenSystem();
                _model.RememberMe(_view.checkBox_guardar.Checked, _view.txtBox_user.Text, _view.txtBox_pass.Text);
            }
        }

        private protected void OpenSystem()
        {
            //frm_principal frmPrincipal = new frm_principal();
            //frmPrincipal.FormClosed += Logout;

            SplashWelcome splashScreen = new SplashWelcome("");
            splashScreen.Show();

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
