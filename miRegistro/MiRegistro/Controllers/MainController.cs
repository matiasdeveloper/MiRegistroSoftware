using MiRegistro.Models;
using MiRegistro.Views;
using MiRegistro.Views.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        }

        private void DashboardClick(object sender, EventArgs e)
        {
            //OpenFormInPanel(new Form1());
        }

        private void LoadFormData(object sender, EventArgs e)
        {
            UserTableViewModel user = _formModel.GetCacheUser();
            if(user != null) 
            {
                _view.lbl_nombre.Text = user.Nombre + " " + user.Apellido;
                _view.lbl_email.Text = user.Email;
            }

            ActivateButtonSidebar(_view.btn_dashboard);
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
