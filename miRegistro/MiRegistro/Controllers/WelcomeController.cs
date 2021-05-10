using MiRegistro.Models;
using MiRegistro.Properties;
using MiRegistro.Views.Main;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace MiRegistro.Controllers
{
    public class WelcomeController
    {
        FormModel _formModel = new FormModel();
        WelcomeViewModel _model = new WelcomeViewModel();
        SplashWelcome _view { get; set; }

        public WelcomeController(SplashWelcome view)
        {
            _view = view;
            _view.Load += new EventHandler(Load);
            _view.timerloading.Tick += new EventHandler(LoadProcess);
            _view.timerslider.Tick += new EventHandler(Slider);

            _view.btn_next.Click += new EventHandler(OpenSystem);
            _view.checkbox_terms.Click += new EventHandler(OnCheckBoxClick);
        }

        public void LoadDataUser(UserTableViewModel usuario) 
        {
            _view.lbl_nick.Text = usuario.Nick;
            _view.lbl_companyname.Text = usuario.Empresa;
            _view.lbl_privileges.Text = GetPrivilegesText(usuario.Privileges);

            _formModel.SetCacheUser(usuario);
        }

        private string GetPrivilegesText(List<UserPrivilegesTableViewModel> listprivileges)
        {
            string text = "";
            if(listprivileges != null) 
            {
                if(listprivileges.Count > 0) 
                {
                    foreach (var p in listprivileges)
                    {
                        if (text.Length > 0)
                        {
                            text = text + ", " + p.privilegeName;
                        }
                        else
                        {
                            text = p.privilegeName;
                        }
                    }

                    text = text + ".";
                    return text;
                }
            }
            return text;
        }

        private void Load(object sender, EventArgs e)
        {          
            ResourceManager rm = Resources.ResourceManager;
            string routeImage = "splash" + 1;
            Bitmap myImage = (Bitmap)rm.GetObject(routeImage);

            _view.sliderpicture.BackgroundImage = myImage;

            _model.SetTermConditionStatus(false); // Desactivar!! // Here

            if (!_model.GetTermConditionStatus())
            {
                _view.checkbox_terms.Enabled = true; 
                _view.checkbox_terms.Checked = false;
            }
            else
            {
                _view.checkbox_terms.Enabled = false;
                _view.checkbox_terms.Checked = true;
            }
        }

        public void OnCheckBoxClick(object sender, EventArgs e) 
        {
            if (_view.progress_bar.Value < 100)
                return;

            _view.btn_next.Enabled = _view.checkbox_terms.Checked;
            _model.SetTermConditionStatus(_view.checkbox_terms.Checked);
        }
        public void LoadProcess(object sender, EventArgs e) 
        {
            if (_view.countTimer == 0)
            {
                if (_view.Opacity < 1)
                    _view.Opacity += 0.05;

                _view.progress_bar.Value += 1;
                if (_view.progress_bar.Value == 100)
                {
                    _view.timerloading.Stop();
                    _view.timerloading.Start();
                    _view.countTimer++;
                }
            }
            else
            {
                _view.timerloading.Stop();
                _view.lbl_loading.Text = "Todo listo . .";

                if (_view.checkbox_terms.Checked)
                {
                    _view.btn_next.Enabled = true;
                }
            }
        }

        public void Slider(object sender, EventArgs e) 
        {
            if(_view.imageToSplash == _view.totalImageToSplash) 
            {
                _view.imageToSplash = 0;
            }

            _view.imageToSplash++;
            _view.sliderpicture.BackgroundImage = _formModel.GetImageResource("splash", _view.imageToSplash);
        }

        public void OpenSystem(object sender, EventArgs e) 
        {
           if (_view.checkbox_terms.Checked && _view.progress_bar.Value == 100)
           {
                Main main = new Main();
                main.Show();
                main.FormClosed += _view.loginParent.oLoginController.Logout;

                _view.Close();
            }
        }
    }
}
