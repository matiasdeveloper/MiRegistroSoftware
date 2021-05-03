using LayerPresentation.Clases;
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

        private void LoadDashboard() 
        {
            ChargeInfoEmployees();
        }
        private void LoadAccessPrivileges()
        {
            /*if (UserLoginCacheOld.Priveleges == Privileges.Administrador)
            {
                // Code here
                if(UserLoginCacheOld.isRoot) 
                {
                    Button[] edit = { btn_edit_0, btn_edit_1, btn_edit_2, btn_edit_3, btn_edit_4, btn_edit_5, btn_edit_6, btn_edit_7 };
                    foreach (Button e in edit)
                    {
                        e.Enabled = true;
                    }
                }
            } */
        }

        private void ChargeInfoEmployees()
        {
            Panel[] panels = { panel_0, panel_1, panel_2, panel_3, panel_4, panel_5, panel_6, panel_7 };
            Label[] names = { lbl_nombre_0, lbl_nombre_1, lbl_nombre_2, lbl_nombre_3, lbl_nombre_4, lbl_nombre_5, lbl_nombre_6, lbl_nombre_7};
            Label[][] info = { InfoReference(0), InfoReference(1), InfoReference(2), InfoReference(3), InfoReference(4), InfoReference(5), InfoReference(6), InfoReference(7) };

            //Statistics.DisplayNames(names);
            //Statistics.DisplayInfo(panels, info);

            Label[][] statistics = { InfoStatistic(0), InfoStatistic(1), InfoStatistic(2), InfoStatistic(3), InfoStatistic(4), InfoStatistic(5), InfoStatistic(6), InfoStatistic(7) };
            //Statistics.DisplayEmployeeData(statistics);
        }
        
        private Label[] InfoReference(int i) 
        {
            List<Label> info = new List<Label>();

            info.Add(UtilitiesCommon.FindLabelInForm(this, String.Format("lbl_permisos_" + i)));
            info.Add(UtilitiesCommon.FindLabelInForm(this, String.Format("lbl_email_" + i)));
            info.Add(UtilitiesCommon.FindLabelInForm(this, String.Format("lbl_acceso_" + i)));
            info.Add(UtilitiesCommon.FindLabelInForm(this, String.Format("lbl_id_" + i)));
            info.Add(UtilitiesCommon.FindLabelInForm(this, String.Format("lbl_user_" + i)));

            return info.ToArray();
        }
        private Label[] InfoStatistic(int i)
        {
            List<Label> info = new List<Label>();

            info.Add(UtilitiesCommon.FindLabelInForm(this, String.Format("lbl_diainscriptos_" + i)));
            info.Add(UtilitiesCommon.FindLabelInForm(this, String.Format("lbl_diaprocesados_" + i)));
            info.Add(UtilitiesCommon.FindLabelInForm(this, String.Format("lbl_mesinscriptos_" + i)));
            info.Add(UtilitiesCommon.FindLabelInForm(this, String.Format("lbl_mesprocesados_" + i)));
            info.Add(UtilitiesCommon.FindLabelInForm(this, String.Format("lbl_meserrores_" + i)));

            return info.ToArray();
        }
        
        private void RefreshData() 
        {
            //UtilitiesCommon.RefreshEmplooyeeDataTramites();
            //Statistics.tmp = Cn_Employee.data.GetCache().GetUsers();
            LoadDashboard();
        }

        private void ShowEmployeeTramites(int num)
        {
            /*string labelid = String.Format("lbl_id_" + num);
            Label lbl_id = UtilitiesCommon.FindLabelInForm(this, labelid);
            int id = Convert.ToInt32(lbl_id.Text);

            string labelemployee = String.Format("lbl_nombre_" + num);
            Label lbl_employee = UtilitiesCommon.FindLabelInForm(this, labelemployee);

            //DataTable dt = DataTramites.GetEmployeeDataTramites(id);
            string empleado = (string)lbl_employee.Text;
            //string mes = Fechas.dateNow.ToString();

            frm_tramites_pantallaCompleta mv = new frm_tramites_pantallaCompleta(num, empleado, mes, dt, Fechas.firstDayOfMonth.ToShortDateString(), Fechas.lastDayOfMonth.ToShortDateString());
            mv.Show();*/
        }

        // Buttons and more
        private void btn_tramites_0_Click(object sender, EventArgs e)
        {
            ShowEmployeeTramites(0);
        }
        private void btn_tramites_1_Click(object sender, EventArgs e)
        {
            ShowEmployeeTramites(1);
        }
        private void btn_tramites_2_Click(object sender, EventArgs e)
        {
            ShowEmployeeTramites(2);
        }
        private void btn_tramites_3_Click(object sender, EventArgs e)
        {
            ShowEmployeeTramites(3);
        }
        private void btn_tramites_4_Click(object sender, EventArgs e)
        {
            ShowEmployeeTramites(4);
        }
        private void btn_tramites_5_Click(object sender, EventArgs e)
        {
            ShowEmployeeTramites(5);
        }
        private void btn_tramites_6_Click(object sender, EventArgs e)
        {
            ShowEmployeeTramites(6);
        }
        private void btn_tramites_7_Click(object sender, EventArgs e)
        {
            ShowEmployeeTramites(7);
        }

        private void ShowEmployeeConfiguration(int id) 
        {
            //List<string>[] data = DataUsers.GetUserData(id);
            //frm_configuracion_empleado frm = new frm_configuracion_empleado(id, data[0], data[1], data[2]);
            //frm.Show();

        }
        // Edit buttons
        private void btn_edit_0_Click(object sender, EventArgs e)
        {
            ShowEmployeeConfiguration(Convert.ToInt32(lbl_id_0.Text));       
        }
        private void btn_edit_1_Click(object sender, EventArgs e)
        {
            ShowEmployeeConfiguration(Convert.ToInt32(lbl_id_1.Text));
        }
        private void btn_edit_2_Click(object sender, EventArgs e)
        {
            ShowEmployeeConfiguration(Convert.ToInt32(lbl_id_2.Text));
        }
        private void btn_edit_3_Click(object sender, EventArgs e)
        {
            ShowEmployeeConfiguration(Convert.ToInt32(lbl_id_3.Text));
        }
        private void btn_edit_4_Click(object sender, EventArgs e)
        {
            ShowEmployeeConfiguration(Convert.ToInt32(lbl_id_4.Text));
        }
        private void btn_edit_5_Click(object sender, EventArgs e)
        {
            ShowEmployeeConfiguration(Convert.ToInt32(lbl_id_5.Text));
        }
        private void btn_edit_6_Click(object sender, EventArgs e)
        {
            ShowEmployeeConfiguration(Convert.ToInt32(lbl_id_6.Text));
        }
        private void btn_edit_7_Click(object sender, EventArgs e)
        {
            ShowEmployeeConfiguration(Convert.ToInt32(lbl_id_7.Text));
        }
       
        // Save buttons
        private void btn_savepdf_0_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lbl_id_0);
            /*DataTable dt = DataTramites.GetTableDate(DataTramites.GetEmployeeDataTramites(id), Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);

            if (PdfExporter.ExportDataTableInPdf(dt, lbl_nombre_0.Text))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }*/
        }
        private void btn_savepdf_1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lbl_id_1);
            //DataTable dt = DataTramites.GetTableDate(DataTramites.GetEmployeeDataTramites(id), Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);

            /*if (PdfExporter.ExportDataTableInPdf(dt, lbl_nombre_1.Text))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }*/
        }
        private void btn_savepdf_2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lbl_id_2);
            //DataTable dt = DataTramites.GetTableDate(DataTramites.GetEmployeeDataTramites(id), Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);

            /*if (PdfExporter.ExportDataTableInPdf(dt, lbl_nombre_2.Text))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }*/
        }
        private void btn_savepdf_3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lbl_id_3);
            //DataTable dt = DataTramites.GetTableDate(DataTramites.GetEmployeeDataTramites(id), Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);

            /*if (PdfExporter.ExportDataTableInPdf(dt, lbl_nombre_3.Text))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }*/
        }
        private void btn_savepdf_4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lbl_id_4);
            //DataTable dt = DataTramites.GetTableDate(DataTramites.GetEmployeeDataTramites(id), Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);

            /*if (PdfExporter.ExportDataTableInPdf(dt, lbl_nombre_4.Text))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }*/
        }
        private void btn_savepdf_5_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lbl_id_5);
            //DataTable dt = DataTramites.GetTableDate(DataTramites.GetEmployeeDataTramites(id), Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);

            /*if (PdfExporter.ExportDataTableInPdf(dt, lbl_nombre_5.Text))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }*/
        }
        private void btn_savepdf_6_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lbl_id_6);
            /*DataTable dt = DataTramites.GetTableDate(DataTramites.GetEmployeeDataTramites(id), Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);

            if (PdfExporter.ExportDataTableInPdf(dt, lbl_nombre_6.Text))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }*/
        }
        private void btn_savepdf_7_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lbl_id_7);
            /*DataTable dt = DataTramites.GetTableDate(DataTramites.GetEmployeeDataTramites(id), Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);

            if (PdfExporter.ExportDataTableInPdf(dt, lbl_nombre_7.Text))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }*/
        }
        
        // Load
        private void frm_empleados_Load(object sender, EventArgs e)
        {
            //Statistics.tmp = Cn_Employee.data.GetCache().GetUsers();
            LoadDashboard();
            LoadAccessPrivileges();
        }
        private void btn_refreshdata_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }
}
