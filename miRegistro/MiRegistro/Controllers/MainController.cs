using MiRegistro.Models;
using MiRegistro.Views;
using MiRegistro.Views.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace Controllers
{
    public class MainController
    {
        Main _view { get; set; }

        FormModel _formModel = new FormModel();
        MainViewModel _model = new MainViewModel();

        public MainController(Main view) 
        {
            _view = view;
            _view.Load += new EventHandler(LoadFormData);

            _view.btn_dashboard.Click += new EventHandler(DashboardClick);
            _view.btn_tramites.Click += new EventHandler(TramitesClick);
            _view.btn_formularios.Click += new EventHandler(FormulariosClick);
            //_view.btn_empleados.Click += new EventHandler(EmpleadosClick);
            //_view.btn_estadistica.Click += new EventHandler(EstadisticaClick);

            _view.btn_configuracion.Click += new EventHandler(ConfiguracionClick);
            _view.btn_logout.Click += new EventHandler(LogoutClick);

            _view.btn_moreoptions.Click += new EventHandler(MoreOptionsClick);
            _view.btn_more_closesystem.Click += new EventHandler(MoreOptionsCloseClick);
        }
        private void LoadFormData(object sender, EventArgs e)
        {
            UserTableViewModel user = _formModel.GetCacheUser();
            if (user != null)
            {
                _view.lbl_nombre.Text = user.Nombre + " " + user.Apellido;
                _view.lbl_email.Text = user.Email;
            }

            ActivateButtonSidebar(_view.btn_dashboard);
            OpenFormInPanel(new Dashboard());
        }

        private void MoreOptionsCloseClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void MoreOptionsClick(object sender, EventArgs e)
        {
            if (!_view.pn_moreoptions.Visible) 
            {
                _view.gunaTransitionVertical.ShowSync(_view.pn_moreoptions);
            } 
            else
            {
                _view.pn_moreoptions.Visible = false;
            }
        }

        private void DashboardClick(object sender, EventArgs e)
        {
            OpenFormInPanel(new Dashboard());
        }
        private void FormulariosClick(object sender, EventArgs e)
        {
            OpenFormInPanel(new Formularios());
        }
        private void TramitesClick(object sender, EventArgs e)
        {
            OpenFormInPanel(new Tramites());
        }
        private void ConfiguracionClick(object sender, EventArgs e)
        {
            OpenFormInPanel(new Configuracion());
        }
        private protected void LogoutClick(object sender, EventArgs e)
        {
            _view.Close();
        }

        private void OpenFormInPanel(object Formhijo)
        {
            if (_view.pn_contenedor.Controls.Count > 0)
                _view.pn_contenedor.Controls.RemoveAt(0);

            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            _view.pn_contenedor.Controls.Add(fh);
            _view.pn_contenedor.Tag = fh;
            fh.Show();
        }
        
        public void ActivateButtonSidebar(object senderBtn)
        {
            if (!(_view.currentSidebarButton == senderBtn))
            {
                if (senderBtn != null)
                {
                    DisableButtonSidebar();
                    _view.currentSidebarButton = (Guna.UI.WinForms.GunaAdvenceButton)senderBtn;
                    _view.currentSidebarButton.Checked = true;
                }
            }
        }
        public void DisableButtonSidebar()
        {
            if (_view.currentSidebarButton != null)
            {
                _view.currentSidebarButton.Checked = false;
            }
        }
    }
}
