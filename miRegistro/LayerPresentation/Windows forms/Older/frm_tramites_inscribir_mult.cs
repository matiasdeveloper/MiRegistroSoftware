using LayerBusiness;
using LayerPresentation.Clases;
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


        public frm_tramites_inscribir_mult(DateTime fecha, frm_tramites frm = null, frm_escritorio frm1 = null)
        {
            InitializeComponent();
            DataTramites.DisplayEmpleados(comboBox_empleados);

            this._frmEscritorio = frm1;
            this._frmTramites = frm;

            this.fecha = fecha;

            InitializeData();
        }

        frm_escritorio _frmEscritorio;
        frm_tramites _frmTramites;

        private DateTime fecha;
        private int cod_empleado;
        private int[] id_selected;

        private void InitializeData() 
        {
            this.dateTime_fecha.Value = new DateTime(fecha.Year, fecha.Month, fecha.Day);

            this.dg_tramites.AutoGenerateColumns = false;
            this.dg_tramites.DataSource = DataTramites.GetTableDate(DataTramites.data, fecha, fecha.AddDays(1));
            this.dg_tramites.SelectAll();
        }
        private void DeleteFields()
        {
            comboBox_empleados.SelectedIndex = 0;
            checkBox_inscripto.Checked = true;
        }

        private bool InitializeVariables()
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
        
        private void RefreshData() 
        {
            if (_frmTramites != null)
            {
                //_frmTramites.RefreshAll();
            }
            if (_frmEscritorio != null)
            {
                _frmEscritorio.RefreshAll();
            }
        }
        
        private void btn_cargar_Click(object sender, EventArgs e)
        {
            if (InitializeVariables()) 
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

                        //UtilitiesCommon.layerBusiness.cn_tramites.inscribirMultiple(id_selected, cod, cod_empleado);
<<<<<<< HEAD

=======
>>>>>>> 26889f9 (Solved new errors when compile new merge files)
                        DeleteFields();
                        RefreshData();

                        frm_successdialog f = new frm_successdialog(2);
                        f.Show();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally 
                    {
                        this.Close();
                    }
                }
            }
        }

        private void dg_tramites_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dg_tramites.Columns[e.ColumnIndex].Name == "Inscripto")
            {
                if (Convert.ToBoolean(e.Value) == true)
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.White;
                    e.CellStyle.BackColor = System.Drawing.Color.FromArgb(41, 217, 85);
                }
            }
            if (this.dg_tramites.Columns[e.ColumnIndex].Name == "Error")
            {
                if (Convert.ToBoolean(e.Value) == true)
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.White;
                    e.CellStyle.BackColor = System.Drawing.Color.FromArgb(242, 53, 53);
                }
                else
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.White;
                    e.CellStyle.BackColor = System.Drawing.Color.FromArgb(41, 217, 85);
                }
            }
        }
        private void btn_refresh_Click(object sender, EventArgs e)
        {
            this.dg_tramites.AutoGenerateColumns = false;
            this.dg_tramites.DataSource = DataTramites.GetTableDate(DataTramites.data, dateTime_fecha.Value, dateTime_fecha.Value.AddDays(1));
            this.dg_tramites.SelectAll();
        }

        private void barra_titulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frm_tramites_inscribir_mult_Load(object sender, EventArgs e)
        {

        }
    }
}
