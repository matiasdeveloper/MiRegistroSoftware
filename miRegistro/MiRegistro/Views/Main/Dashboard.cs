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

namespace MiRegistro.Views
{
    public partial class Dashboard : Form
    {
        protected Image[] images = { Properties.Resources.r_positive, Properties.Resources.r_negative };
        public DashboardController oDashboardController;

        public Dashboard()
        {
            InitializeComponent();
            oDashboardController = new DashboardController(this);
        }

        public void LoadDataPanel_01(float total, float percentage, Label lbl, PictureBox pic, Label per, bool isError = false)
        {
            lbl.Text = total.ToString();
            if (percentage >= 0.0)
            {
                if (isError)
                {
                    per.Text = "+" + percentage.ToString("0.00") + "%";
                    pic.BackgroundImage = images[1];
                    per.ForeColor = ColorSystem.GetNegative();
                }
                else
                {
                    per.Text = "+" + percentage.ToString("0.00") + "%";
                    pic.BackgroundImage = images[0];
                    per.ForeColor = ColorSystem.GetPositive();
                }
            }
            else if (percentage < 0)
            {
                if (isError)
                {
                    per.Text = percentage.ToString("0.00") + "%";
                    pic.BackgroundImage = images[0];
                    per.ForeColor = ColorSystem.GetPositive();
                }
                else
                {
                    per.Text = percentage.ToString("0.00") + "%";
                    pic.BackgroundImage = images[1];
                    per.ForeColor = ColorSystem.GetNegative();
                }
            }
            else
            {
                per.Text = "+" + "0" + "%";
                pic.BackgroundImage = images[0];
                per.ForeColor = ColorSystem.GetPositive();
            }
        }
        public void LoadDataPanel_02(double percentage, int stocknegativo, int stocknegativomotos, int stocknegativoautos)
        {
            int v = (int)Math.Round(percentage, MidpointRounding.AwayFromZero);
            chart_stockformularios.Value = v;
            lbl_stockbajo_percentage.Text = v.ToString() + "%";
            lbl_stockbajo.Text = stocknegativo.ToString();

            lbl_stockbajo_autos.Text = stocknegativoautos.ToString();
            lbl_stockbajo_motos.Text = stocknegativomotos.ToString();
        }
        public void LoadDataPanel_8(int[] result)
        {
            progress_procesados.Value = result[0];
            lbl_porcentaje_procesados.Text = result[0].ToString() + "%";
            progress_inscriptos.Value = result[1];
            lbl_porcentaje_inscriptos.Text = result[1].ToString() + "%";

            lbl_procesados.Text = result[2].ToString();
            lbl_inscriptos.Text = result[3].ToString();
        }
    }
}
