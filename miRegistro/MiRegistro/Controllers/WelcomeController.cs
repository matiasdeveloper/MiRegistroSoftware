using MiRegistro.Models;
using MiRegistro.Views.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiRegistro.Controllers
{
    public class WelcomeController
    {
        WelcomeViewModel _model = new WelcomeViewModel();
        SplashWelcome _view { get; set; }

        public WelcomeController(SplashWelcome view)
        {
            _view = view;
            _view.timerloading.Tick += new EventHandler(LoadProcess);
            _view.timersplash.Tick += new EventHandler(Slider);

            _view.btn_next.Click += new EventHandler(OpenSystem);
            _view.checkbox_terms.Click += new EventHandler(OnCheckBoxClick);

            //_view.btn_login.Click += new EventHandler(Autentificar);
        }

        public void OnCheckBoxClick(object sender, EventArgs e) 
        {
            if (_view.checkbox_terms.Checked && _view.progress_bar.Value == 100) 
            {
                _view.btn_next.Enabled = true;
            } else 
            {
                _view.btn_next.Enabled = false;
            }
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
                _view.imageToSplash = 1;
            }

            _view.sliderpicture.ImageLocation = string.Format(@"..\Resources\{0}.png", _view.imageToSplash);
            _view.imageToSplash++; 
        }

        public void OpenSystem(object sender, EventArgs e) 
        {
           if (_view.checkbox_terms.Checked && _view.progress_bar.Value == 100)
           {
                _view.Opacity = 0;
            }
        }
    }
}
