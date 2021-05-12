using Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI.WinForms;

namespace MiRegistro.Views.Main
{
    public partial class Main : Form
    {
        private int currentForm = 0;
        protected MainController oMainController;

        public GunaAdvenceButton currentSidebarButton;

        public Main()
        {
            InitializeComponent();
            oMainController = new MainController(this);
        }

        private void btn_dashboard_Click(object sender, EventArgs e)
        {
            oMainController.ActivateButtonSidebar(sender);
        }
        private void btn_tramites_Click(object sender, EventArgs e)
        {
            oMainController.ActivateButtonSidebar(sender);
        }
        private void btn_formularios_Click(object sender, EventArgs e)
        {
            oMainController.ActivateButtonSidebar(sender);
        }
        private void btn_empleados_Click(object sender, EventArgs e)
        {
            //oMainController.ActivateButtonSidebar(sender);
        }
        private void btn_estadisticas_Click(object sender, EventArgs e)
        {
            //oMainController.ActivateButtonSidebar(sender);
        }
        private void gunaAdvenceButton6_Click(object sender, EventArgs e)
        {
            oMainController.ActivateButtonSidebar(sender);
        }
        private void gunaAdvenceButton5_Click(object sender, EventArgs e)
        {
            oMainController.ActivateButtonSidebar(sender);
        }
    }
}
