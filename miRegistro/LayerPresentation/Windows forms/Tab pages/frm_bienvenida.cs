using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LayerBusiness;
using LayerPresentation.Clases;
using LayerSoporte.Cache;

namespace LayerPresentation
{
    public partial class frm_bienvenida : Form
    {
        public frm_bienvenida(frm_principal principal, frm_login login)
        {
            InitializeComponent();
            frm = principal;
        }

        frm_principal frm;
        int count = 0;
        
        private void LoadDataForm() 
        {
            lbl_nombreCorto.Text = UserLoginCache.Nick;
            lbl_privilegios.Text = UserLoginCache.Priveleges;
        }
        private protected void InitializeProgram() 
        {
            ColorController.frm = frm;

            Cn_HandlerFormularios.stockBajo = LayerPresentation.Properties.Settings.Default.StockBajo;
            Cn_HandlerFormularios.stockMedio = LayerPresentation.Properties.Settings.Default.StockMedio;
            Cn_HandlerFormularios.stockAlto = LayerPresentation.Properties.Settings.Default.StockAlto;

            // Initialize layer
            /*UtilitiesCommon.layerBusiness = new Utilities_LayerBusiness();

            UtilitiesCommon.layerBusiness.cn_empleados.GenerateEmployeesDataCache();
            Statistics.tmp = Cn_Employee.data.GetCache().GetUsers();

            UtilitiesCommon.layerBusiness.cn_tramites.GenerateDataTramitesCache();

            UtilitiesCommon.layerBusiness.cn_formularios = new Cn_Formularios();
            UtilitiesCommon.layerBusiness.cn_formularios.GenerateDataFormulariosCache();*/
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count == 0)
            {
                if (this.Opacity < 1) this.Opacity += 0.05;
                bunifuProgressBar1.Value += 1;
                if (bunifuProgressBar1.Value == 100)
                {
                    timer1.Stop();
                    timer1.Start();
                    count++;
                }
            }
            else
            {
                this.Opacity -= 0.02;
                if (this.Opacity == 0)
                {
                    timer1.Stop();
                    frm.Show();
                    frm.Opacity = 100;
                    this.Close();
                }
            }
        }

        private void Bienvenida_Load(object sender, EventArgs e)
        {
            LoadDataForm();
            InitializeProgram();

            this.Opacity = 0;
            timer1.Start();

            this.ShowIcon = true;
            this.ShowInTaskbar = false;
        }

        private void bunifuGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
