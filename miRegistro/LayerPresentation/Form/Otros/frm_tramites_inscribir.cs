using LayerBusiness;
using LayerPresentation.Clases;
using LayerSoporte.Cache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayerPresentation
{
    public partial class frm_tramites_inscribir : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public frm_tramites_inscribir(frm_tramites frm, bool isMultiple,int id, string nombre, string dominio, string fecha)
        {
            InitializeComponent();
            displayEmpleados(comboBox_empleados);

            _handlerTramites = frm;
            //this.isMultiple = isMultiple;

            lbl_dominio.Text = dominio;
            lbl_nombre.Text = nombre;
            lbl_fecha.Text = fecha;
            this.id = id;
            lbl_id.Text = id.ToString();
        }

        Cn_Tramites _cnObject = new Cn_Tramites();
        frm_tramites _handlerTramites;
        //private bool isMultiple;

        private int id;
        private int cod_empleado;
        private bool initVariables()
        {
            bool isOk = true;
            cod_empleado = Convert.ToInt32(comboBox_empleados.SelectedValue);
            return isOk;
        }
        private void deleteFields()
        {
            comboBox_empleados.SelectedIndex = 0;
        }
        // Display combobox empleados
        private void displayEmpleados(ComboBox cb)
        {
            DataTable dt = GetEmployes();
            cb.DisplayMember = "Empleado";
            cb.ValueMember = "Id";
            cb.DataSource = dt;
        }
        private DataTable GetEmployes()
        {
            LinkedList<Employee> tmp = Cn_Employee.data.GetCache().GetUsers();
            LinkedListNode<Employee> employee = tmp.First;

            DataTable table = CreatorTables.EmployeeList();

            for (int i = 0; i < tmp.Count; i++)
            {
                CreatorTables.AddRowEmployeeList(table, employee.Value.id, employee.Value.nombre);
                employee = employee.Next;
            }

            return table;
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void barra_titulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void btn_close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_cargar_Click_1(object sender, EventArgs e)
        {
            if (initVariables())
            {
                try
                {
                    _cnObject.inscribirTramite(id, 1, cod_empleado);
                    deleteFields();
                    frm_successdialog f = new frm_successdialog(2);
                    f.Show();
                    _cnObject.RefreshDataTramitesCache();
                    _handlerTramites.refreshData();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btn_cargarmultiple_Click(object sender, EventArgs e)
        {
            try
            {
                _cnObject.inscribirTramite(id, 1, cod_empleado);
                deleteFields();
                frm_successdialog f = new frm_successdialog(2);
                f.Show();
                _handlerTramites.refreshData();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
