using LayerBusiness;
using LayerPresentation.Clases;
using LayerSoporte.Cache;
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
    public partial class frm_empleados : Form
    {
        public frm_empleados()
        {
            InitializeComponent();
        }

        Cn_Tramites _handlerTramites = new Cn_Tramites();
        Cn_Empleados _handlerEmpleados = new Cn_Empleados();

        DateTime dateNow = DateTime.Now;

        private void refreshDashboard() 
        {
            ChargeInfoEmployees();
        }
        private void cargarPrivilegios()
        {
            if (UserLoginCache.Priveleges == Privileges.Administrador)
            {
                // Code here
                if(UserLoginCache.isRoot == 1) 
                {
                    Button[] edit = { btn_edit_0, btn_edit_1, btn_edit_2, btn_edit_3, btn_edit_4, btn_edit_5, btn_edit_6, btn_edit_7 };
                    foreach (Button e in edit)
                    {
                        e.Enabled = true;
                    }
                }
            } 
        }
        private void ChargeInfoEmployees()
        {
            Panel[] panels = { panel_0, panel_1, panel_2, panel_3, panel_4, panel_5, panel_6, panel_7 };
            Label[] names = { lbl_nombre_0, lbl_nombre_1, lbl_nombre_2, lbl_nombre_3, lbl_nombre_4, lbl_nombre_5, lbl_nombre_6, lbl_nombre_7};
            Label[][] info = { InfoReference(0), InfoReference(1), InfoReference(2), InfoReference(3), InfoReference(4), InfoReference(5), InfoReference(6), InfoReference(7) };

            Statistics.DisplayNames(names);
            Statistics.DisplayInfo(panels, info);

            Label[][] statistics = { InfoStatistic(0), InfoStatistic(1), InfoStatistic(2), InfoStatistic(3), InfoStatistic(4), InfoStatistic(5), InfoStatistic(6), InfoStatistic(7) };
            Statistics.DisplayEmployeeData(statistics);
        }
        private Label[] InfoReference(int i) 
        {
            List<Label> info = new List<Label>();
            switch (i) 
            {
                case 0:
                    info.Add(lbl_permisos_0);
                    info.Add(lbl_email_0);
                    info.Add(lbl_acceso_0);
                    info.Add(lbl_id_0);
                    info.Add(lbl_user_0);
                    break;
                case 1:
                    info.Add(lbl_permisos_1);
                    info.Add(lbl_email_1);
                    info.Add(lbl_acceso_1);
                    info.Add(lbl_id_1);
                    info.Add(lbl_user_1);
                    break;
                case 2:
                    info.Add(lbl_permisos_2);
                    info.Add(lbl_email_2);
                    info.Add(lbl_acceso_2);
                    info.Add(lbl_id_2);
                    info.Add(lbl_user_2);
                    break;
                case 3:
                    info.Add(lbl_permisos_3);
                    info.Add(lbl_email_3);
                    info.Add(lbl_acceso_3);
                    info.Add(lbl_id_3);
                    info.Add(lbl_user_3);
                    break;
                case 4:
                    info.Add(lbl_permisos_4);
                    info.Add(lbl_email_4);
                    info.Add(lbl_acceso_4);
                    info.Add(lbl_id_4);
                    info.Add(lbl_user_4);
                    break;
                case 5:
                    info.Add(lbl_permisos_5);
                    info.Add(lbl_email_5);
                    info.Add(lbl_acceso_5);
                    info.Add(lbl_id_5);
                    info.Add(lbl_user_5);
                    break;
                case 6:
                    info.Add(lbl_permisos_6);
                    info.Add(lbl_email_6);
                    info.Add(lbl_acceso_6);
                    info.Add(lbl_id_6);
                    info.Add(lbl_user_6);
                    break;
                case 7:
                    info.Add(lbl_permisos_7);
                    info.Add(lbl_email_7);
                    info.Add(lbl_acceso_7);
                    info.Add(lbl_id_7);
                    info.Add(lbl_user_7);
                    break;
            }
            return info.ToArray();
        }
        private Label[] InfoStatistic(int i)
        {
            List<Label> info = new List<Label>();
            switch (i)
            {
                case 0:
                    info.Add(lbl_diainscriptos_0);
                    info.Add(lbl_diaprocesados_0);
                    info.Add(lbl_mesinscriptos_0);
                    info.Add(lbl_mesprocesados_0);
                    info.Add(lbl_meserrores_0);
                    break;
                case 1:
                    info.Add(lbl_diainscriptos_1);
                    info.Add(lbl_diaprocesados_1);
                    info.Add(lbl_mesinscriptos_1);
                    info.Add(lbl_mesprocesados_1);
                    info.Add(lbl_meserrores_1); break;
                case 2:
                    info.Add(lbl_diainscriptos_2);
                    info.Add(lbl_diaprocesados_2);
                    info.Add(lbl_mesinscriptos_2);
                    info.Add(lbl_mesprocesados_2);
                    info.Add(lbl_meserrores_2);
                    break;
                case 3:
                    info.Add(lbl_diainscriptos_3);
                    info.Add(lbl_diaprocesados_3);
                    info.Add(lbl_mesinscriptos_3);
                    info.Add(lbl_mesprocesados_3);
                    info.Add(lbl_meserrores_3); break;
                case 4:
                    info.Add(lbl_diainscriptos_4);
                    info.Add(lbl_diaprocesados_4);
                    info.Add(lbl_mesinscriptos_4);
                    info.Add(lbl_mesprocesados_4);
                    info.Add(lbl_meserrores_4); break;
                case 5:
                    info.Add(lbl_diainscriptos_5);
                    info.Add(lbl_diaprocesados_5);
                    info.Add(lbl_mesinscriptos_5);
                    info.Add(lbl_mesprocesados_5);
                    info.Add(lbl_meserrores_5); break;
                case 6:
                    info.Add(lbl_diainscriptos_6);
                    info.Add(lbl_diaprocesados_6);
                    info.Add(lbl_mesinscriptos_6);
                    info.Add(lbl_mesprocesados_6);
                    info.Add(lbl_meserrores_6); break;
                case 7:
                    info.Add(lbl_diainscriptos_7);
                    info.Add(lbl_diaprocesados_7);
                    info.Add(lbl_mesinscriptos_7);
                    info.Add(lbl_mesprocesados_7);
                    info.Add(lbl_meserrores_7); break;
            }
            return info.ToArray();
        }
        private void refreshData() 
        {
            _handlerEmpleados.GenerateEmployeesDataCache();
            _handlerTramites.RefreshDataDashboardCache();

            Statistics.tmp = Cn_Employee.data.GetCache().GetUsers();
        }
        private bool ExportDataTramitesPdf(Label lblid, Label lblname)
        {
            Random r = new Random();
            int id = Convert.ToInt32(lblid.Text);
            string dia = dateNow.Day + "-" + dateNow.Month;
            string user = lblname.Text + "_" + dia;

            DataTable dt = null;
            dt = DataTramites.GetTableDate(DataTramites.GetDataTramitesTableWithID(id), Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);

            bool result = DataSave.ExportToPdf(dt, user);

            return result;
        }

        // Buttons and more
        private void btn_tramites_0_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lbl_id_0.Text);
            string empleado = (string)lbl_nombre_0.Text;
            string mes = dateNow.Month.ToString();

            DataTable dt = null;
            dt = DataTramites.GetDataTramitesTableWithID(id);

            frm_tramites_pantallaCompleta mv = new frm_tramites_pantallaCompleta(id, empleado, mes, dt, Fechas.firstDayOfMonth.ToShortDateString(), Fechas.lastDayOfMonth.ToShortDateString());
            mv.Show();
        }
        private void btn_tramites_1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lbl_id_1.Text);
            string empleado = (string)lbl_nombre_1.Text;
            string mes = dateNow.Month.ToString();

            DataTable dt = null;
            dt = DataTramites.GetDataTramitesTableWithID(id);

            frm_tramites_pantallaCompleta mv = new frm_tramites_pantallaCompleta(id, empleado, mes, dt, Fechas.firstDayOfMonth.ToShortDateString(), Fechas.lastDayOfMonth.ToShortDateString());
            mv.Show();
        }
        private void btn_tramites_2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lbl_id_2.Text);
            string empleado = (string)lbl_nombre_2.Text;
            string mes = dateNow.Month.ToString();

            DataTable dt = null;
            dt = DataTramites.GetDataTramitesTableWithID(id);

            frm_tramites_pantallaCompleta mv = new frm_tramites_pantallaCompleta(id, empleado, mes, dt, Fechas.firstDayOfMonth.ToShortDateString(), Fechas.lastDayOfMonth.ToShortDateString());
            mv.Show();
        }
        private void btn_tramites_3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lbl_id_3.Text);
            string empleado = (string)lbl_nombre_3.Text;
            string mes = dateNow.Month.ToString();

            DataTable dt = null;
            dt = DataTramites.GetDataTramitesTableWithID(id);

            frm_tramites_pantallaCompleta mv = new frm_tramites_pantallaCompleta(id, empleado, mes, dt, Fechas.firstDayOfMonth.ToShortDateString(), Fechas.lastDayOfMonth.ToShortDateString());
            mv.Show();
        }
        private void btn_tramites_4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lbl_id_4.Text);
            string empleado = (string)lbl_nombre_4.Text;
            string mes = dateNow.Month.ToString();

            DataTable dt = null;
            dt = DataTramites.GetDataTramitesTableWithID(id);

            frm_tramites_pantallaCompleta mv = new frm_tramites_pantallaCompleta(id, empleado, mes, dt, Fechas.firstDayOfMonth.ToShortDateString(), Fechas.lastDayOfMonth.ToShortDateString());
            mv.Show();
        }
        private void btn_tramites_5_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lbl_id_5.Text);
            string empleado = (string)lbl_nombre_5.Text;
            string mes = dateNow.Month.ToString();

            DataTable dt = null;
            dt = DataTramites.GetDataTramitesTableWithID(id);

            frm_tramites_pantallaCompleta mv = new frm_tramites_pantallaCompleta(id, empleado, mes, dt, Fechas.firstDayOfMonth.ToShortDateString(), Fechas.lastDayOfMonth.ToShortDateString());
            mv.Show();
        }

        private void btn_tramites_6_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lbl_id_6.Text);
            string empleado = (string)lbl_nombre_6.Text;
            string mes = dateNow.Month.ToString();

            DataTable dt = null;
            dt = DataTramites.GetDataTramitesTableWithID(id);

            frm_tramites_pantallaCompleta mv = new frm_tramites_pantallaCompleta(id, empleado, mes, dt, Fechas.firstDayOfMonth.ToShortDateString(), Fechas.lastDayOfMonth.ToShortDateString());
            mv.Show();
        }

        private void btn_tramites_7_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lbl_id_7.Text);
            string empleado = (string)lbl_nombre_7.Text;
            string mes = dateNow.Month.ToString();

            DataTable dt = null;
            dt = DataTramites.GetDataTramitesTableWithID(id);

            frm_tramites_pantallaCompleta mv = new frm_tramites_pantallaCompleta(id, empleado, mes, dt, Fechas.firstDayOfMonth.ToShortDateString(), Fechas.lastDayOfMonth.ToShortDateString());
            mv.Show();
        }
        // Edit buttons
        private void btn_edit_0_Click(object sender, EventArgs e)
        {
            List<string>[] data = DataUsers.GetUserData(Convert.ToInt32(lbl_id_0.Text));
            frm_configuracion_empleado frm = new frm_configuracion_empleado(Convert.ToInt32(lbl_id_0.Text),data[0], data[1], data[2]);
            frm.Show();
        }
        private void btn_edit_1_Click(object sender, EventArgs e)
        {
            List<string>[] data = DataUsers.GetUserData(Convert.ToInt32(lbl_id_1.Text));
            frm_configuracion_empleado frm = new frm_configuracion_empleado(Convert.ToInt32(lbl_id_1.Text), data[0], data[1], data[2]);
            frm.Show();
        }
        private void btn_edit_2_Click(object sender, EventArgs e)
        {
            List<string>[] data = DataUsers.GetUserData(Convert.ToInt32(lbl_id_2.Text));
            frm_configuracion_empleado frm = new frm_configuracion_empleado(Convert.ToInt32(lbl_id_2.Text), data[0], data[1], data[2]);
            frm.Show();
        }
        private void btn_edit_3_Click(object sender, EventArgs e)
        {
            List<string>[] data = DataUsers.GetUserData(Convert.ToInt32(lbl_id_3.Text));
            frm_configuracion_empleado frm = new frm_configuracion_empleado(Convert.ToInt32(lbl_id_3.Text), data[0], data[1], data[2]);
            frm.Show();
        }
        private void btn_edit_4_Click(object sender, EventArgs e)
        {
            List<string>[] data = DataUsers.GetUserData(Convert.ToInt32(lbl_id_4.Text));
            frm_configuracion_empleado frm = new frm_configuracion_empleado(Convert.ToInt32(lbl_id_4.Text), data[0], data[1], data[2]);
            frm.Show();
        }
        private void btn_edit_5_Click(object sender, EventArgs e)
        {
            List<string>[] data = DataUsers.GetUserData(Convert.ToInt32(lbl_id_5.Text));
            frm_configuracion_empleado frm = new frm_configuracion_empleado(Convert.ToInt32(lbl_id_5.Text), data[0], data[1], data[2]);
            frm.Show();
        }
        private void btn_edit_6_Click(object sender, EventArgs e)
        {
            List<string>[] data = DataUsers.GetUserData(Convert.ToInt32(lbl_id_6.Text));
            frm_configuracion_empleado frm = new frm_configuracion_empleado(Convert.ToInt32(lbl_id_6.Text), data[0], data[1], data[2]);
            frm.Show();
        }
        private void btn_edit_7_Click(object sender, EventArgs e)
        {
            List<string>[] data = DataUsers.GetUserData(Convert.ToInt32(lbl_id_7.Text));
            frm_configuracion_empleado frm = new frm_configuracion_empleado(Convert.ToInt32(lbl_id_7.Text), data[0], data[1], data[2]);
            frm.Show();
        }
       
        // Save buttons
        private void btn_savepdf_0_Click(object sender, EventArgs e)
        {
            if (ExportDataTramitesPdf(lbl_id_0, lbl_nombre_0)) 
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }
        private void btn_savepdf_7_Click(object sender, EventArgs e)
        {
            if(ExportDataTramitesPdf(lbl_id_7, lbl_nombre_7)) 
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }
        private void btn_savepdf_3_Click(object sender, EventArgs e)
        {
            if (ExportDataTramitesPdf(lbl_id_3, lbl_nombre_3)) 
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }
        private void btn_savepdf_2_Click(object sender, EventArgs e)
        {
            if(ExportDataTramitesPdf(lbl_id_2, lbl_nombre_2)) 
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }
        private void btn_savepdf_6_Click(object sender, EventArgs e)
        {
            if(ExportDataTramitesPdf(lbl_id_6, lbl_nombre_6)) 
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }
        private void btn_savepdf_5_Click(object sender, EventArgs e)
        {
            if(ExportDataTramitesPdf(lbl_id_5, lbl_nombre_5)) 
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }
        private void btn_savepdf_4_Click(object sender, EventArgs e)
        {
            if(ExportDataTramitesPdf(lbl_id_4, lbl_nombre_4)) 
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }
        private void btn_savepdf_1_Click(object sender, EventArgs e)
        {
            if(ExportDataTramitesPdf(lbl_id_1, lbl_nombre_1)) 
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }

        // Load
        private void frm_empleados_Load(object sender, EventArgs e)
        {
            Statistics.tmp = Cn_Employee.data.GetCache().GetUsers();
            refreshDashboard();
            cargarPrivilegios();
        }
        private void btn_refreshdata_Click(object sender, EventArgs e)
        {
            refreshData();
            refreshDashboard();
        }
    }
}
