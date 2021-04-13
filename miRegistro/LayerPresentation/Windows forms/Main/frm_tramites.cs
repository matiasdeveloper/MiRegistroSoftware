using Bunifu.Framework.UI;
using LayerBusiness;
using LayerPresentation.Clases;
using LayerSoporte.Cache;
using MaterialDesignColors.Recommended;
using Microsoft.PowerBI.Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PagedList;

namespace LayerPresentation
{
    public partial class frm_tramites : Form
    {
        private int pageNumber = 1;
        private int pageSize = 10;

        private BunifuCards currentPanelOpenInFront;
        public DataTable DataSource { get; set; }

        private int selectedIdDatagridview = 0;

        private int y = 164;

        private Label currentQuerySelected;

        Random r = new Random();
        public frm_tramites()
        {
            InitializeComponent();
            UpdateDataTramites();

            currentQuerySelected = button_hoy;
        }
        
        private DataTable GenerateDt(int rows) 
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Id");
            dt.Columns.Add("Dominio");
            dt.Columns.Add("Categoria");
            dt.Columns.Add("Estado");
            dt.Columns.Add("Procesado");
            dt.Columns.Add("Inscripto");
            dt.Columns.Add("Errores");
            dt.Columns.Add("Fecha");
            dt.Columns.Add("Observaciones");
            for(int i =0; i < rows; i++) 
            {
                dt.Rows.Add(GenerateRandomRow());
            }
            return dt;
        }
        private object[] GenerateRandomRow() 
        {
            object[] a = { "01", "AA150SS", "Transferencia", "Procesado", "Matias", "", "Sin errrores", "27/20/14", "Sin observaciones" };
            object[] a1 = { "22", "AA230LD", "Inscripcion inicial", "Procesado", "Matias", "", "Sin errrores", "27/20/14", "Sin observaciones" };
            object[] a2 = { "10", "AA120DF", "Desarrollo de software", "Procesado e inscripto", "Matias", "Noeli", "Error en la cedula", "27/20/14", "Todas las observaciones posibles" };

            object[] res = { a, a1, a2 };
            int rnd = r.Next(0, 3);
            return (object[])res[rnd];
        }
        
        public void DataBind(DataTable dataTable)
        {
            // Set data of datagridview
            DataSource = dataTable;
            dg_tramites.AutoGenerateColumns = false;
            dg_tramites.DataSource = ShowData(1);
        }
        private DataTable ShowData(int pageNumber)
        {
            DataTable dt = new DataTable();
            int startIndex = pageSize * (pageNumber - 1);
            var result = DataSource.AsEnumerable().Where((s, k) => (k >= startIndex && k < (startIndex + pageSize)));

            foreach (DataColumn colunm in DataSource.Columns)
            {
                dt.Columns.Add(colunm.ColumnName);
            }

            foreach (var item in result)
            {
                dt.ImportRow(item);
            }

            lbl_paging.Text = string.Format("Mostrando {0} - {1} de {2} resultados", pageNumber, (DataSource.Rows.Count / pageSize) + 1, DataSource.Rows.Count);
            return dt;
        }

        private protected void UpdateDataTramites() 
        {
            DataSource = GenerateDt(49);
            DisplayDataTramites();
            //Utilities_Common.RefreshTramitesData();
        }
        private void DisplayDataTramites()
        {
            DataBind(DataSource);
            lbl_totaltramites.Text = "(" + 100 + "tramites)";
        }
        private void LoadAccessPrivileges()
        {
            /*if (UserLoginCache.Priveleges == Privileges.Estandar)
            {
                // Code here
                btn_insertar.Enabled = false;
                btn_editar.Enabled = false;
                btn_inscribir.Enabled = false;
                btn_error.Enabled = false;
                btn_eliminar.Enabled = false;
            }*/
        }
        private string[] GetSelectedRowDatagridview()
        {
            selectedIdDatagridview = Convert.ToInt32(dg_tramites.CurrentRow.Cells["Id"].Value);
            string[] data = new string[9];

            data[0] = dg_tramites.CurrentRow.Cells["Id"].Value.ToString();
            data[1] = dg_tramites.CurrentRow.Cells["Dominio"].Value.ToString();
            data[2] = dg_tramites.CurrentRow.Cells["Categoria"].Value.ToString();
            data[3] = dg_tramites.CurrentRow.Cells["Estado"].Value.ToString();
            data[4] = dg_tramites.CurrentRow.Cells["Procesado"].Value.ToString();
            data[5] = dg_tramites.CurrentRow.Cells["Inscripto"].Value.ToString();
            data[6] = dg_tramites.CurrentRow.Cells["Errores"].Value.ToString();
            data[7] = dg_tramites.CurrentRow.Cells["Fecha"].Value.ToString();
            data[8] = dg_tramites.CurrentRow.Cells["Observaciones"].Value.ToString();

            return data;
        }
        private void ShowMoreOptions(BunifuCards panel)
        {
            if (panel == currentPanelOpenInFront || panel.Visible == true)
            {
                currentPanelOpenInFront = null;
                panel.Visible = false;
            }
            else
            {
                // Open panel
                if (currentPanelOpenInFront != null)
                {
                    currentPanelOpenInFront.Visible = false;
                }
                currentPanelOpenInFront = panel;

                panel.Visible = false;
                TransitionPnMore.Show(panel);
            }
        }

        private void button_hoy_Click(object sender, EventArgs e)
        {

        }
        private void button_mes_Click(object sender, EventArgs e)
        {

        }
        private void button_ayer_Click(object sender, EventArgs e)
        {

        }

        private void button_acciones_Click(object sender, EventArgs e)
        {
            ShowMoreOptions(pn_acciones);
        }
        private void button_consultar_Click(object sender, EventArgs e)
        {
            ShowMoreOptions(pn_consulta);
        }
        private void button_cancelarconsulta_Click(object sender, EventArgs e)
        {
            if (pn_consulta.Visible)
            {
                pn_consulta.Visible = false;
                // Delete fields
            }
        }
        private void button_buscar_Click(object sender, EventArgs e)
        {
            // Generate query
            pn_consulta.Visible = false;
            currentQuerySelected.ForeColor = System.Drawing.Color.DarkGray;
            currentQuerySelected = null;
        }

        // Multiples
        private void btn_insertar_Click_1(object sender, EventArgs e)
        {
            frm_tramites_insertar frm = new frm_tramites_insertar();
            frm.Show();
        }
        private void btn_inscribir_Click_1(object sender, EventArgs e)
        {
            frm_tramites_inscribir_mult frm = new frm_tramites_inscribir_mult(DateTime.Today, this);
            frm.Show();
        }
        private void btn_refreshdata_Click_1(object sender, EventArgs e)
        {
            // Refresh data
        }

        // Acciones
        private void btn_error_Click_1(object sender, EventArgs e)
        {

        }
        private void btn_inscribirsingle_Click(object sender, EventArgs e)
        {

        }
        private void btn_editar_Click_1(object sender, EventArgs e)
        {
            if(dg_tramites.CurrentRow.Index > 16) 
            {
                pn_editar_tramite.Location = new Point(pn_editar_tramite.Location.X, y - 30);
            }
            else 
            {
                pn_editar_tramite.Location = new Point(pn_editar_tramite.Location.X, y + 30 * dg_tramites.CurrentRow.Index);
            }
            ShowMoreOptions(pn_editar_tramite);
        }
        private void btn_eliminar_Click_1(object sender, EventArgs e)
        {

        }

        private void btn_closeeditar_Click(object sender, EventArgs e)
        {
            if (pn_editar_tramite.Visible) 
            {
                pn_editar_tramite.Visible = false;
            }
        }
        
        private void btn_previous_Click(object sender, EventArgs e)
        {
            if (pageNumber == 1)
            {
                //MessageBox.Show("You are already on First page, you can not go to previous of First page.");
            }
            else
            {
                pageNumber -= 1;
                dg_tramites.DataSource = ShowData(pageNumber);
            }
        }
        private void btn_next_Click(object sender, EventArgs e)
        {
            int lastPage = (DataSource.Rows.Count / pageSize) + 1;
            if (pageNumber >= lastPage)
            {
                //MessageBox.Show("You are already on Last page, you can not go to next page of Last page.");
            }
            else
            {
                pageNumber += 1;
                dg_tramites.DataSource = ShowData(pageNumber);
            }
        }

        private void btn_savepdf_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_rowPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int current = Convert.ToInt32((string)comboBox_rowPerPage.SelectedItem);
            pageSize = current;
            DisplayDataTramites();
        }
        private void dg_tramites_SelectionChanged(object sender, EventArgs e)
        {
            selectedIdDatagridview = Convert.ToInt32(dg_tramites.CurrentRow.Cells["ColumnId"].Value);
            //y = dg_tramites.PointToScreen(dg_tramites.GetCellDisplayRectangle(0, dg_tramites.CurrentCell.RowIndex, false).Location).Y;
        }
        private void pn_editar_tramite_VisibleChanged(object sender, EventArgs e)
        {
            // On close panel save data edited
        }

        private void frm_tramites_consultas_Load(object sender, EventArgs e)
        {
            LoadAccessPrivileges();
        }

        private void button_hoy_MouseClick(object sender, MouseEventArgs e)
        {
            if (SelectQueryButton(button_hoy)) 
            {
                // Change query
            } else 
            {
                // Refresh query
            }
        }

        private bool SelectQueryButton(Label click) 
        {
            if(click == currentQuerySelected) 
            {
                return false;
            } 
            else 
            {
                if(currentQuerySelected != null) 
                {
                    currentQuerySelected.ForeColor = System.Drawing.Color.DarkGray;
                }
                currentQuerySelected = click;
                click.ForeColor = System.Drawing.Color.FromArgb(58, 122, 252);
                return true;
            }
        } 
        private void button_mes_MouseClick(object sender, MouseEventArgs e)
        {
            if (SelectQueryButton(button_mes))
            {
                // Change query
            }
            else
            {
                // Refresh query
            }
        }
        private void button_ayer_MouseClick(object sender, MouseEventArgs e)
        {
            if (SelectQueryButton(button_ayer))
            {
                // Change query
            }
            else
            {
                // Refresh query
            }
        }
    }
}

