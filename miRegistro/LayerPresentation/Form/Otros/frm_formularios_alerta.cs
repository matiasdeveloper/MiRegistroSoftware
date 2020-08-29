using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using LayerBusiness;
using LayerPresentation.Properties;

namespace LayerPresentation
{
    public partial class frm_formularios_alerta : Form
    {
        private Cn_Formularios _cnObject = new Cn_Formularios();
        private Cn_alertas _cnObjectAlert = new Cn_alertas();

        private int stockBajo = 0;
        private int stockMedio = 0;
        private int stockAlto = 0;

        public frm_formularios_alerta(bool isInit, int id, string fecha, string usuario)
        {
            InitializeComponent();
            isInitial = isInit;
            idAlert = id;
            fechaAlert = fecha;
            userAlert = usuario;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private bool isInitial = false;
        private int idAlert;
        private string fechaAlert;
        private string userAlert;

        private void barra_titulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void chargeDataAlert()
        {
            if(isInitial == false) 
            {
                // Initial program
                Cn_Formularios objects = new Cn_Formularios();
                dg_formulariosAlert.DataSource = objects.findAlert(stockBajo);

                lbl_fechayhora.Text = fechaAlert;
                lbl_numeroDeAlerta.Text = idAlert.ToString();
                lbl_usuarioAlertado.Text = userAlert;
            } else 
            {
                // Specific alert
                Cn_alertas objects = new Cn_alertas();
                int[] idForm = _cnObjectAlert.buscarDetallesAlerta(idAlert);

                dg_formulariosAlert.DataSource = objects.mostrarSpecificAlert(idForm);
                lbl_fechayhora.Text = fechaAlert;
                lbl_numeroDeAlerta.Text = idAlert.ToString();
                lbl_usuarioAlertado.Text = userAlert;
            }
        }

        private void frm_formularios_alerta_Load(object sender, EventArgs e)
        {
            stockBajo = Settings.Default.StockBajo;
            stockMedio = Settings.Default.StockMedio;
            stockAlto = Settings.Default.StockAlto;

            chargeDataAlert();
        }

        private void btn_refreshTable_Click(object sender, EventArgs e)
        {
            chargeDataAlert();
        }

        private void dg_formulariosAlert_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dg_formulariosAlert.Columns[e.ColumnIndex].Name == "Stocks")
            {
                if (Convert.ToInt32(e.Value) <= stockAlto)
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(81, 189, 51);
                    if (Convert.ToInt32(e.Value) <= stockMedio)
                    {
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.BackColor = Color.FromArgb(228, 194, 78);
                        if (Convert.ToInt32(e.Value) <= stockBajo)
                        {
                            e.CellStyle.ForeColor = Color.White;
                            e.CellStyle.BackColor = Color.FromArgb(192, 25, 28);
                        }
                    }
                }

            }
        }

        private void btn_maximize_Click(object sender, EventArgs e)
        {

        }
    }
}
