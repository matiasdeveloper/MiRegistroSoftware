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
    public partial class Bienvenida : Form
    {
        public Bienvenida(frm_principal principal)
        {
            InitializeComponent();
            frm = principal;
            ColorSystem.frm = principal;
        }

        private Cn_Empleados _cnEmpleados = new Cn_Empleados();
        private Cn_Tramites _cnTramites = new Cn_Tramites();
        private Cn_Formularios _cnFormularios = new Cn_Formularios();

        frm_principal frm;
        int count = 0;
        
        private void intializeText() 
        {
            lbl_nombreCorto.Text = UserLoginCache.Nombre_Corto;
            lbl_privilegios.Text = UserLoginCache.Priveleges;
        }
        private void InitializeProgram() 
        {
            _cnEmpleados.GenerateEmployeesDataCache();
            Statistics.tmp = Cn_Employee.data.GetCache().GetUsers();

            _cnTramites.GenerateDataTramitesCache();
            _cnFormularios.GenerateDataFormulariosCache();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count == 0)
            {
                if (this.Opacity < 1) this.Opacity += 0.05;
                progressBar1.Value += 1;
                if (progressBar1.Value == 100)
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
                    this.Close();
                    frm.Show();
                    frm.Opacity = 100;
                }
            }
        }
        private void Bienvenida_Load(object sender, EventArgs e)
        {
            intializeText();
            InitializeProgram();

            this.Opacity = 0;
            timer1.Start();
        }
    }
}
