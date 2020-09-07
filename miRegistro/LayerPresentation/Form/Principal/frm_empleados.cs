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
                    break;
                case 1:
                    info.Add(lbl_permisos_1);
                    info.Add(lbl_email_1);
                    info.Add(lbl_acceso_1);
                    info.Add(lbl_id_1);
                    break;
                case 2:
                    info.Add(lbl_permisos_2);
                    info.Add(lbl_email_2);
                    info.Add(lbl_acceso_2);
                    info.Add(lbl_id_2);
                    break;
                case 3:
                    info.Add(lbl_permisos_3);
                    info.Add(lbl_email_3);
                    info.Add(lbl_acceso_3);
                    info.Add(lbl_id_3);
                    break;
                case 4:
                    info.Add(lbl_permisos_4);
                    info.Add(lbl_email_4);
                    info.Add(lbl_acceso_4);
                    info.Add(lbl_id_4);
                    break;
                case 5:
                    info.Add(lbl_permisos_5);
                    info.Add(lbl_email_5);
                    info.Add(lbl_acceso_5);
                    info.Add(lbl_id_5);
                    break;
                case 6:
                    info.Add(lbl_permisos_6);
                    info.Add(lbl_email_6);
                    info.Add(lbl_acceso_6);
                    info.Add(lbl_id_6);
                    break;
                case 7:
                    info.Add(lbl_permisos_7);
                    info.Add(lbl_email_7);
                    info.Add(lbl_acceso_7);
                    info.Add(lbl_id_7);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            txtBox_fecha.Text = DateTime.Now.ToString();
        }

        private void btn_tramites_0_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lbl_id_0.Text);
            string empleado = (string)lbl_nombre_0.Text;
            string mes = dateNow.Month.ToString();

            DataTable dt = null;
            dt = GetDataTramitesTableWithID(id);
            int[] tramites = Statistics.FindTramites(empleado, dt, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
            int[] errores = Statistics.FindErrores(empleado, dt, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);

            frm_tramites_pantallaCompleta mv = new frm_tramites_pantallaCompleta(id, empleado, mes, dt, errores, tramites);
            mv.Show();

        }
        private void btn_tramites_1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lbl_id_1.Text);
            string empleado = (string)lbl_nombre_1.Text;
            string mes = dateNow.Month.ToString();

            DataTable dt = null;
            dt = GetDataTramitesTableWithID(id);
            int[] tramites = Statistics.FindTramites(empleado, dt, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
            int[] errores = Statistics.FindErrores(empleado, dt, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);

            frm_tramites_pantallaCompleta mv = new frm_tramites_pantallaCompleta(id, empleado, mes, dt, errores, tramites);
            mv.Show();
        }
        private void btn_tramites_2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lbl_id_2.Text);
            string empleado = (string)lbl_nombre_2.Text;
            string mes = dateNow.Month.ToString();

            DataTable dt = null;
            dt = GetDataTramitesTableWithID(id);
            int[] tramites = Statistics.FindTramites(empleado, dt, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
            int[] errores = Statistics.FindErrores(empleado, dt, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);

            frm_tramites_pantallaCompleta mv = new frm_tramites_pantallaCompleta(id, empleado, mes, dt, errores, tramites);
            mv.Show();
        }
        
        private DataTable GetDataTramitesTableWithID(int id)
        {
            LinkedList<Employee> tmp = Cn_Employee.data.GetCache().GetUsers();
            LinkedListNode<Employee> employee = tmp.First;

            DataTable table = new DataTable();

            for (int i = 0; i < tmp.Count; i++)
            {
                if (employee.Value.id == id)
                {
                    table = employee.Value.tramitesMes;
                    break;
                }
                employee = employee.Next;
            }

            return table;
        }
        private void frm_empleados_Load(object sender, EventArgs e)
        {
            Statistics.tmp = Cn_Employee.data.GetCache().GetUsers();
            refreshDashboard();
        }
        private void btn_refreshdata_Click(object sender, EventArgs e)
        {
            refreshData();
            refreshDashboard();
        }
    }
}
