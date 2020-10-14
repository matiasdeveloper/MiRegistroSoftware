using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayerPresentation
{
    public partial class frm_successdialog : Form
    {
        public frm_successdialog(int isState)
        {
            InitializeComponent();
            switch (isState)
            {
                case 0:
                    lbl_tittle.Text = "Excelente!";
                    lbl_info.Text = "Dato ingresado correctamente.";
                    break;
                case 1:
                    lbl_tittle.Text = "Excelente!";
                    lbl_info.Text = "Dato eliminado correctamente.";
                    break;
                case 2:
                    lbl_tittle.Text = "Maravilloso!";
                    lbl_info.Text = "Dato actualizado correctamente.";
                    break;
                case 3:
                    lbl_tittle.Text = "Segui asi!";
                    lbl_info.Text = "Stock actualizado correctamente.";
                    break;
                case 4:
                    lbl_tittle.Text = "Recuperacion!";
                    lbl_info.Text = "Verifica tu correo electronico.";
                    break;
                case 5:
                    lbl_tittle.Text = "Excelente!";
                    lbl_info.Text = "Pdf generado correctamente.";
                    break;
                case 6:
                    lbl_tittle.Text = "Excelente!!";
                    lbl_info.Text = "Consulta generada correctamente.";
                    break;
            }
        }

        int count = 0;
        int opacity = 0;

        private void frm_successdialog_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            timer1.Start();
        }
        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            count = 1;
            timer1.Stop();

            timer1.Start();
            btn_aceptar.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (count == 0)
            {
                if (this.Opacity < 1) this.Opacity += 0.05;
                opacity += 1;
                if (opacity == 100)
                {
                    timer1.Stop();
                    count++;
                }
            }
            else
            {
                this.Opacity -= 0.05;
                if (this.Opacity == 0)
                {
                    timer1.Stop();
                    this.Close();
                }
            }
        }
    }
}
