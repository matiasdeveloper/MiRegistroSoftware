using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LayerPresentation.Clases;
using LayerSoporte.Cache;

namespace LayerPresentation
{
    public partial class frm_tramites_pantallaCompleta : Form
    {
        public frm_tramites_pantallaCompleta(int id,string empleado, string mes, DataTable dt, int[] errores, int[] tramites)
        {
            InitializeComponent();
            
            this.id = id;
            this.empleado = empleado;
            this.mes = mes;
            this.data = dt;
            this.errores = errores;
            this.tramites = tramites;

            InitializeData();
        }

        private int id;
        private string empleado;
        private string mes;
        private DataTable data;
        private int[] errores;
        private int[] tramites;

        private void InitializeData() 
        {
            dg_tramites.AutoGenerateColumns = false;
            dg_tramites.DataSource = GetTableDate(data, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);

            lbl_id.Text = id.ToString();
            lbl_mes.Text = mes;
            lbl_user.Text = empleado;
            lbl_totalerrores.Text = errores[0].ToString();
            lbl_totaltramites.Text = tramites[0].ToString();
            lbl_totalprocesados.Text = tramites[1].ToString();
            lbl_totalinscriptos.Text = tramites[2].ToString();

            lbl_desde.Text = Fechas.firstDayOfMonth.ToShortDateString();
            lbl_hasta.Text = Fechas.lastDayOfMonth.ToShortDateString();
        }
        private DataTable GetTableDate(DataTable data, DateTime dt1, DateTime dt2)
        {
            DataTable tramites = CreatorTables.TramitesEmployeeTable();
            dt2.AddDays(1);
            foreach (DataRow fila in data.Rows)
            {
                if ((DateTime)fila[5] >= dt1 && (DateTime)fila[5] < dt2)
                {                   
                    CreatorTables.AddRowTramitesEmployeesTable(tramites, (int)fila[0], (string)fila[1], (string)fila[2],
                        (string)fila[3], (string)fila[4], (DateTime)fila[5], (bool)fila[6], 
                        (string)fila[7], (string)fila[8], (bool)fila[9], (string)fila[10]);
                } 
                else { /* fila.Delete(); */}
            }
            return tramites;
        }

        #region Tittle Bar
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        private void dg_tramites_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dg_tramites.Columns[e.ColumnIndex].Name == "Empleado1")
            {
                if (Convert.ToString(e.Value) == empleado)
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(0, 0, 35);
                }
            }
            if (this.dg_tramites.Columns[e.ColumnIndex].Name == "NombreInscripto") 
            {
                if(Convert.ToString(e.Value) == empleado) 
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(0, 0, 35);
                }
            }
            if (this.dg_tramites.Columns[e.ColumnIndex].Name == "Inscripto")
            {
                if (Convert.ToBoolean(e.Value) == true)
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(81, 189, 51);
                }
            }
            if (this.dg_tramites.Columns[e.ColumnIndex].Name == "Error")
            {
                if (Convert.ToBoolean(e.Value) == true)
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(192, 25, 28);
                }
                else
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(81, 189, 51);
                }
            }

            if (this.dg_tramites.Columns[e.ColumnIndex].Name == "TipoError")
            {
                if (Convert.ToString(e.Value) == "Error Total")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(192, 25, 28);
                }
                else if (Convert.ToString(e.Value) == "Error Parcial")
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(228, 194, 78);
                }
            }
        }

        private void frm_tramites_pantallaCompleta_Load(object sender, EventArgs e)
        {

        }
    }
}
