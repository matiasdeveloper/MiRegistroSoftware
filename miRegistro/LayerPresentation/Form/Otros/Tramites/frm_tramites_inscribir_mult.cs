using LayerBusiness;
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
    public partial class frm_tramites_inscribir_mult : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        public frm_tramites_inscribir_mult(DateTime fecha, DataTable dt, frm_tramites frm = null, frm_escritorio frm1 = null)
        {
            InitializeComponent();
            DataTramites.DisplayEmpleados(comboBox_empleados);

            this._handlerEscritorio = frm1;
            this._handlerTramites = frm;

            this.fecha = fecha;
            this.data= dt;

            InitializeData();
        }

        Cn_Tramites _cnObject = new Cn_Tramites();

        frm_escritorio _handlerEscritorio;
        frm_tramites _handlerTramites;

        private DataTable data;
        private DateTime fecha;
        private int cod_empleado;
        private int[] id_selected;

        private void InitializeData() 
        {
            this.dateTime_fecha.Value = new DateTime(fecha.Year, fecha.Month, fecha.Day);

            this.dg_tramites.AutoGenerateColumns = false;
            this.dg_tramites.DataSource = DataTramites.GetTableDate(data, fecha, fecha.AddDays(1));
            this.dg_tramites.SelectAll();
        }
        private void deleteFields()
        {
            comboBox_empleados.SelectedIndex = 0;
            checkBox_inscripto.Checked = true;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool initVariables()
        {
            bool isOk = true;
            cod_empleado = Convert.ToInt32(comboBox_empleados.SelectedValue);

            id_selected = GetSelectedId();
            if(id_selected.Length <= 0) 
            {
                isOk = false;
            }

            return isOk;
        }
        private int[] GetSelectedId() 
        {
            List<int> ids = new List<int>();
            if(dg_tramites.SelectedRows.Count != 0) 
            {
                // Find ids to selecteds
                foreach (DataGridViewRow row in dg_tramites.SelectedRows) 
                {
                    ids.Add((int)row.Cells["Id1"].Value);
                }         
            } else { MessageBox.Show("Seleccione en la tabla los tramites que desea inscribir", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            return ids.ToArray();
        }
        private void btn_cargar_Click(object sender, EventArgs e)
        {
            if (initVariables()) 
            {
                DialogResult dialogResult = MessageBox.Show("Estas seguro que deseas inscribir los tramites seleccionados?", "Atencion", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        int cod = 0;
                        if (checkBox_inscripto.Checked)
                        {
                            cod = 1;
                        }
                        else
                        {
                            cod = 0;
                            cod_empleado = 1;
                        }

                        _cnObject.inscribirMultiple(id_selected, cod, cod_empleado);

                        deleteFields();
                        frm_successdialog f = new frm_successdialog(2);
                        f.Show();

                        if (_handlerTramites != null)
                        {
                            _handlerTramites.refreshAll();
                        }
                        if (_handlerEscritorio != null)
                        {
                            _handlerEscritorio.RefreshAll();
                        }

                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void barra_titulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void dg_tramites_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dg_tramites.Columns[e.ColumnIndex].Name == "Inscripto")
            {
                if (Convert.ToBoolean(e.Value) == true)
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(41, 217, 85);
                }
            }
            if (this.dg_tramites.Columns[e.ColumnIndex].Name == "Error")
            {
                if (Convert.ToBoolean(e.Value) == true)
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(242, 53, 53);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(41, 217, 85);
                }
            }
        }
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            this.dg_tramites.AutoGenerateColumns = false;
            this.dg_tramites.DataSource = DataTramites.GetTableDate(data, dateTime_fecha.Value, dateTime_fecha.Value.AddDays(1));
            this.dg_tramites.SelectAll();
        }
        private void frm_tramites_inscribir_mult_Load(object sender, EventArgs e)
        {

        }
    }
}
