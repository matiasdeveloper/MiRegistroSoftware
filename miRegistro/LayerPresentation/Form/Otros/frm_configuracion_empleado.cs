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
    public partial class frm_configuracion_empleado : Form
    {
        public frm_configuracion_empleado(int id, string name, string permisos)
        {
            InitializeComponent();
            this.id = id;
            lbl_id.Text = id.ToString();
            lbl_nombreUser.Text = name;
            lbl_permisos.Text = permisos;
        }
        private int id;

        private void mostraPanelConfig(Panel pn, Button btn)
        {
            pn.Visible = true;
            btn.Visible = false;
        }
        private void ocultarPanelConfig(Panel pn, Button btn)
        {
            pn.Visible = false;
            btn.Visible = true;
        }

        // Buttons
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // User
        private void btn_cambiar1_Click(object sender, EventArgs e)
        {
            mostraPanelConfig(pn_expand_1, btn_cambiar1);
        }
        private void btn_save_user_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_1, btn_cambiar1);
        }

        private void btn_cancelar1_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_1, btn_cambiar1);
        }

        // Pass
        private void btn_cambiar2_Click(object sender, EventArgs e)
        {
            mostraPanelConfig(pn_expand_2, btn_cambiar2);
        }
        private void btn_save_pass_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_2, btn_cambiar2);
        }

        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_2, btn_cambiar2);
        }

        // Name
        private void btn_cambiar3_Click(object sender, EventArgs e)
        {
            mostraPanelConfig(pn_expand_3, btn_cambiar3);
        }
        private void btn_cancelar3_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_3, btn_cambiar3);
        }
        private void btn_save_nombre_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_3, btn_cambiar3);
        }

        // Email
        private void btn_cambiar4_Click(object sender, EventArgs e)
        {
            mostraPanelConfig(pn_expand_4, btn_cambiar4);
        }
        private void btn_save_email_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_4, btn_cambiar4);
        }
        private void btn_cancelar4_Click_1(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_4, btn_cambiar4);
        }

        // City
        private void btn_cambiar5_Click(object sender, EventArgs e)
        {
            mostraPanelConfig(pn_expand_5, btn_cambiar5);
        }
        private void btn_cancelar5_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_5, btn_cambiar5);
        }
        private void btn_save_ciudad_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_5, btn_cambiar5);
        }

        // Birthday
        private void btn_cambiar6_Click(object sender, EventArgs e)
        {
            mostraPanelConfig(pn_expand_6, btn_cambiar6);
        }
        private void btn_cancelar6_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_6, btn_cambiar6);
        }
        private void btn_save_fecha_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_6, btn_cambiar6);
        }

        // Name Employee
        private void btn_cambiar7_Click(object sender, EventArgs e)
        {
            mostraPanelConfig(pn_expand_7, btn_cambiar7);
        }
        private void btn_cancelar7_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_7, btn_cambiar7);
        }
        private void btn_save_nameEmployee_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_7, btn_cambiar7);
        }

        // Fecha Employee Contrat
        private void btn_cambiar8_Click(object sender, EventArgs e)
        {
            mostraPanelConfig(pn_expand_8, btn_cambiar8);
        }
        private void btn_cancelar8_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_8, btn_cambiar8);
        }
        private void btn_save_fechaContratacion_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_8, btn_cambiar8);
        }

        // Permisos
        private void btn_cambiar9_Click(object sender, EventArgs e)
        {
            mostraPanelConfig(pn_expand_9, btn_cambiar9);
        }
        private void btn_cancelar9_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_9, btn_cambiar9);
        }
        private void btn_save_permisos_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_9, btn_cambiar9);
        }
    }
}
