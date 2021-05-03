using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;
using LayerPresentation.Properties;
using LayerPresentation.Clases;
using Bunifu.Framework.UI;

namespace LayerPresentation
{
    public partial class frm_formularios : Form
    {
        private DataTable DataSource { get; set; }
        private BunifuCards currentPanelOpenInFront = null;
        private int selectedIdDatagridview = 0;
        private int y = 168;
        public frm_formularios()
        {
            InitializeComponent();

            DisplayDataFormularios();
            DisplayDataAlertas();
        }

        private void UpdateDataFormularios() 
        {
            //DataSource = 
        }
        private void DisplayDataAlertas()
        {
            //Utilities_Common.layerBusiness.cn_alertas = new Cn_alertas();
            //dg_alertas_1.DataSource = Utilities_Common.layerBusiness.cn_alertas.mostrarAlertas();

            dg_alertas_1.Rows.Add("15b3", "Stock bajo", "15/05/18 13:58");
            dg_alertas_1.Rows.Add("14c3", "Stock bajo", "15/05/18 13:58");
            dg_alertas_1.Rows.Add("13b3", "Stock bajo", "15/05/18 13:58");
        }
        public void DisplayDataFormularios()
        {
            dg_formularios.Rows.Add("12", "Auto", "08", "150", "Bueno", "12/02/2020 13:43:22");
            dg_formularios.Rows.Add("12", "Auto", "4D", "10", "Critico", "12/02/2020 13:43:22");
            dg_formularios.Rows.Add("12", "Auto", "5D", "20", "Regular", "12/02/2020 13:43:22");
            dg_formularios.Rows.Add("12", "Auto", "100", "50", "Bueno", "12/02/2020 13:43:22");
            dg_formularios.Rows.Add("12", "Auto", "1050", "200", "Bueno", "12/02/2020 13:43:22");

            DisplayDataNumeracion(selectedIdDatagridview);
            // currentDt = DataFormularios.data; 
            //DisplayDataTableFormularios(dg_formularios_1, "Auto");
        }
        public void DisplayDataNumeracion(int idFormulario)
        {
            for (int i = 0; i < 15; i++)
            {
                dg_numeracion.Rows.Add("AA134C", 12);
                dg_numeracion.Rows.Add("AA233", 134);
            }
        }
        
        private void DisplayChartCriticFormularios() 
        {
            
        }
        private void DisplayAlertas()
        {
            //Utilities_Common.layerBusiness.cn_alertas = new Cn_alertas();
            //dg_alertas_1.DataSource = Utilities_Common.layerBusiness.cn_alertas.mostrarAlertas();

            dg_alertas_1.Rows.Add("15b3", "Stock bajo", "15/05/18 13:58");
            dg_alertas_1.Rows.Add("14c3", "Stock bajo", "15/05/18 13:58");
            dg_alertas_1.Rows.Add("13b3", "Stock bajo", "15/05/18 13:58");
            dg_alertas_1.Rows.Add("90b3", "Stock bajo", "15/05/18 13:58");
            dg_alertas_1.Rows.Add("1203", "Stock bajo", "15/05/18 13:58");
        }
        
        private void LoadAccessPrivileges()
        {
            /*if (UserLoginCacheOld.Priveleges == Privileges.Estandar)
            {
                btn_save.Enabled = false;
                //btn_delete.Enabled = false;
            }*/
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
        private void PaintCellFormating(DataGridView dg, object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dg.Columns[e.ColumnIndex].Index == 4)
            {
                if (Convert.ToString(e.Value) == "Bueno")
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.FromArgb(41, 217, 85);
                    //e.CellStyle.BackColor = Color.FromArgb(41, 217, 85);
                }
                if (Convert.ToString(e.Value) == "Regular")
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.FromArgb(242, 145, 61);
                   //e.CellStyle.BackColor = Color.FromArgb(242, 145, 61);
                }
                if (Convert.ToString(e.Value) == "Critico")
                {
                    e.CellStyle.ForeColor = System.Drawing.Color.FromArgb(242, 53, 53);
                    //e.CellStyle.BackColor = Color.FromArgb(242, 53, 53);
                }
            }
        }

        #region Older
        private void Initialize() 
        {
            //ShowCategoriasFormularios("Auto");
            //ShowAlertas();
            //LoadDataFormularios();
        }
        private void RefreshDashboardData() 
        {
            //LoadDataFormularios();
        }
        public void RefreshDataStock()
        {
            //Cn_HandlerFormularios.stockBajo = Settings.Default.StockBajo;
            //Cn_HandlerFormularios.stockMedio = Settings.Default.StockMedio;
            //Cn_HandlerFormularios.stockAlto = Settings.Default.StockAlto;
        }
        public void LoadDataFormularios()
        {
            dg_formularios.Rows.Add("12", "Auto", "08", "150", "Bueno", "12/02/2020 13:43:22");
            dg_formularios.Rows.Add("12", "Auto", "08", "150", "Bueno", "12/02/2020 13:43:22");
            dg_formularios.Rows.Add("12", "Auto", "08", "150", "Bueno", "12/02/2020 13:43:22");
            dg_formularios.Rows.Add("12", "Auto", "08", "150", "Bueno", "12/02/2020 13:43:22");
            dg_formularios.Rows.Add("12", "Auto", "08", "150", "Bueno", "12/02/2020 13:43:22");

            //LoadDataNumeracion();
            // currentDt = DataFormularios.data; 
            //DisplayDataTableFormularios(dg_formularios_1, "Auto");
        }      
        private void DisplayDataTableFormularios(DataGridView dt, string name)
        {
            //DataTable data = DataFormularios.GetTableForElement(currentDt, name);

            dt.AutoGenerateColumns = false;
            //dt.DataSource = data;
        }        
        private void ShowCategoriasFormularios(string name) 
        {
            //cb_categorias.DataSource = DataFormularios.GetCategoriasForName(Cn_HandlerFormularios.data.formularioCache.GetCategorias(), name);
            cb_categorias.DisplayMember = "Nombre";
            cb_categorias.ValueMember = "Id";
        }    
        private string GetSelectedID(string element)
        {
            string idFormulario = "";
            idFormulario = dg_formularios.CurrentRow.Cells["ColumnId"].Value.ToString();
            return idFormulario;
        }
        private void SetStockColor(int stock, TextBox txt)
        {
            if (stock != 0)
            {
                /*if (stock <= Cn_HandlerFormularios.stockAlto)
                {
                    txt.ForeColor = System.Drawing.Color.White;
                    txt.BackColor = System.Drawing.Color.FromArgb(81, 189, 51);
                    if (stock <= Cn_HandlerFormularios.stockMedio)
                    {
                        txt.ForeColor = System.Drawing.Color.White;
                        txt.BackColor = System.Drawing.Color.FromArgb(228, 194, 78);
                        if (stock <= Cn_HandlerFormularios.stockBajo)
                        {
                            txt.ForeColor = System.Drawing.Color.White;
                            txt.BackColor = System.Drawing.Color.FromArgb(192, 25, 28);
                        }
                    }
                }*/

            }
        }
        private int GetAlertaSelectedId()
        {
            int id = 0;
            id = Convert.ToInt32(dg_alertas_1.CurrentRow.Cells["Cod"].Value.ToString());
            return id;
        }
        /*private DataTable CreateAlertasReport()
        {
            //Cn_Formularios objects = new Cn_Formularios();
           /* DataTable dt = objects.findAlert(Cn_HandlerFormularios.stockBajo);
            return dt;
        }*/
        private void txtBox_stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            UtilitiesCommon.OnlyNumbers(sender, e);
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            /*try
            {
                if (dg_formularios_1.SelectedRows.Count > 0)
                {
                    Utilities_Common.layerBusiness.cn_formularios.actualizarFormularios((int)cb_categorias.SelectedValue, Convert.ToInt32(GetCurrentElement()), txtBox_numeracion.Text, txtBox_stock.Text, DateTime.Now.ToString(), GetSelectedID(GetCurrentElement()));
                    frm_successdialog f = new frm_successdialog(2);
                    f.Show();
                    // Refresh data
                    Utilities_Common.RefreshFormulariosData();
                    RefreshDashboardData();

                    DeleteFieldForTextBoxCRUD();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }*/
        }
        private void btn_stock_Click(object sender, EventArgs e)
        {
            try
            {
               /* if (dg_formularios_1.SelectedRows.Count > 0 || dg_formularios_2.SelectedRows.Count > 0 || dg_formularios_3.SelectedRows.Count > 0)
                {
                    Utilities_Common.layerBusiness.cn_formularios.actualizarStock(txtBox_stockNuevo.Text, DateTime.Now.ToString(), GetSelectedID(GetCurrentElement()));
                    frm_successdialog f = new frm_successdialog(3);
                    f.Show();
                    // Refresh data
                    Utilities_Common.RefreshFormulariosData();
                    RefreshDashboardData();

                    DeleteFieldForTextBoxCRUD();
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            string idFormulario = GetSelectedID("CurrentElement");
            try
            {
                /*if (dg_formularios_1.SelectedRows.Count > 0 || dg_formularios_2.SelectedRows.Count > 0 || dg_formularios_3.SelectedRows.Count > 0)
                {
                    Utilities_Common.layerBusiness.cn_formularios.eliminarFormularios(idFormulario);
                    frm_successdialog f = new frm_successdialog(1);
                    f.Show();
                    // Refresh data
                    Utilities_Common.RefreshFormulariosData();
                    RefreshDashboardData();

                    DeleteFieldForTextBoxCRUD();
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                //UtilitiesCommon.layerBusiness.cn_formularios.insertarFormularios(cb_categorias.SelectedValue.ToString(), "CurrentElement", txtBox_numeracion.Text, txtBox_numeracion.Text, DateTime.Now.ToString());
                frm_successdialog f = new frm_successdialog(0);
                f.Show();
                // Refresh data
                //UtilitiesCommon.RefreshFormulariosData();
                RefreshDashboardData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btn_stockAlerta_Click(object sender, EventArgs e)
        {
            /*frm_formularios_alerta mv = new frm_formularios_alerta(false, 1, DateTime.Now.ToShortDateString(), UserLoginCacheOld.Nombre);
            mv.Show();*/
        }
        private void btn_changeStockParameter_Click(object sender, EventArgs e)
        {
            /*if (Cn_HandlerFormularios.stockBajo.ToString() != txtBox_stockBajo.Text || Cn_HandlerFormularios.stockMedio.ToString() != txtBox_stockMedio.Text || txtBox_stockAlto.Text != txtBox_stockAlto.Text)
            {
                Settings.Default.StockBajo = Convert.ToInt32(txtBox_stockBajo.Text);
                Settings.Default.StockMedio = Convert.ToInt32(txtBox_stockMedio.Text);
                Settings.Default.StockAlto = Convert.ToInt32(txtBox_stockAlto.Text);
                Properties.Settings.Default.Save();

                MessageBox.Show(@"Parametros actualizados correctamente!" + "\nLas alertas y el numero de stock estan siendo actualizados.", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh data
                Utilities_Common.RefreshFormulariosData();
                RefreshDashboardData();
            }*/
        }
        private void btn_detalle_alerta_Click(object sender, EventArgs e)
        {
            if(dg_alertas_1.Rows.Count > 0) 
            {
                frm_formularios_alerta mv = new frm_formularios_alerta(true, GetAlertaSelectedId(), dg_alertas_1.CurrentRow.Cells["fecha"].Value.ToString(), dg_alertas_1.CurrentRow.Cells["user"].Value.ToString());
                mv.Show();
            } else 
            {
                MessageBox.Show("No hay alertas disponibles!", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btn_savePdf_informe_Click(object sender, EventArgs e)
        {
            /*if (UtilitiesPdf.ExportDataTableInPdf(CreateFormulariosReport(), "InformeFORMULARIOS"))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }*/
        }
        private void btn_savePdf_autos_Click(object sender, EventArgs e)
        {
            /*if (Utilites_Pdf.ExportDataGridViewInPdf(dg_formularios_1, "FormulariosAUTO"))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }*/
        }
        private void btn_exportPdf_alertas_Click(object sender, EventArgs e)
        {
            /*if (PdfExporter.ExportDataTableInPdf(CreateAlertasReport(), "InformeALERTAS_StockBajo"))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }*/
        }
        
        private void txtBox_stockNuevo_KeyPress(object sender, KeyPressEventArgs e)
        {
            UtilitiesCommon.OnlyNumbers(sender, e);
        }
        #endregion

        private void btn_acciones_formularios_Click(object sender, EventArgs e)
        {
            ShowMoreOptions(pn_acciones_formularios);
        }
        private void btn_editarparametros_Click(object sender, EventArgs e)
        {
            ShowMoreOptions(pn_editar_parametros);
        }
        private void button_consultar_Click(object sender, EventArgs e)
        {
            ShowMoreOptions(pn_consulta_formularios);
        }
        private void btn_exportar_formularios_Click(object sender, EventArgs e)
        {
            ShowMoreOptions(pn_acciones_exportar);
        }
        private void btn_exportar_actual_Click(object sender, EventArgs e)
        {
            // Exportar current datagridview
        }
        private void btn_exportar_informe_Click(object sender, EventArgs e)
        {
            // Open panel informes
            pn_acciones_exportar.Visible = false;
            pn_exportar_formularios.Visible = false;
            TransitionPnMore.Show(pn_exportar_formularios);
        }

        private void btn_acciones_numeracion_Click(object sender, EventArgs e)
        {
            ShowMoreOptions(pn_acciones_numeracion);
        }

        private void btn_add_numeracion_Click(object sender, EventArgs e)
        {
            ShowMoreOptions(pn_añadirnumeracion);
        }

        private void btn_detailsparametros_Click(object sender, EventArgs e)
        {
            if(pn_parametros_details.Visible == false) 
            {
                pn_dashboard_critic.Visible = false;
                btn_closeparametros.Image = LayerPresentation.Properties.Resources.subtract_30px;
                pn_parametros_details.Visible = false;
                TransitionPnMore.Show(pn_parametros_details);
            } 
        }
        private void btn_closeparametros_Click(object sender, EventArgs e)
        {
            if(pn_parametros_details.Visible == true) 
            {
                btn_closeparametros.Image = LayerPresentation.Properties.Resources.multiply_60px;
                pn_parametros_details.Visible = false;
                pn_dashboard_critic.Visible = true;
            } 
            else 
            {
                currentPanelOpenInFront = null;
                pn_editar_parametros.Visible = false;
                pn_dashboard_critic.Visible = true;
                pn_dashboard.Visible = true;
            }
        }
        private void pn_editar_parametros_VisibleChanged(object sender, EventArgs e)
        {
            if(currentPanelOpenInFront != pn_editar_parametros) 
            {
                pn_parametros_details.Visible = false;
            }
            pn_dashboard.Visible = !pn_editar_parametros.Visible;
        }

        private void pn_editar_parametros_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_cancelarconsulta_Click(object sender, EventArgs e)
        {
            pn_consulta_formularios.Visible = false;
            currentPanelOpenInFront = null;
        }
        private void btn_cancelarinforme_Click(object sender, EventArgs e)
        {
            pn_exportar_formularios.Visible = false;
            currentPanelOpenInFront = null;
        }

        private void btn_actualizarnumeracion_Click(object sender, EventArgs e)
        {
            if(dg_numeracion.CurrentRow.Index > 10) 
            {
                pn_editarnumeracion.Location = new Point(pn_editarnumeracion.Location.X, y - 30);
            }
            else 
            {
                pn_editarnumeracion.Location = new Point(pn_editarnumeracion.Location.X, y + 30 * dg_numeracion.CurrentRow.Index);
            }

            string[] data = GetSelectedIndexDatagridviewNumeracion();

            txtBox_numeracion_edit.Text = data[0];
            txtBox_stock_numeracion_edit.Text = data[1];

            ShowMoreOptions(pn_editarnumeracion);
        }

        private string[] GetSelectedIndexDatagridviewNumeracion() 
        {
            string[] data = new string[2];

            data[0] = dg_numeracion.CurrentRow.Cells["ColumnNumeracion"].Value.ToString();
            data[1] = dg_numeracion.CurrentRow.Cells["ColumnStockDetail"].Value.ToString();

            return data;
        }
        private void btn_eliminarnumeracion_Click(object sender, EventArgs e)
        {

        }
        private void btn_add_formulario_Click(object sender, EventArgs e)
        {
            ShowMoreOptions(pn_addformularios);
        }
        private void btn_closeadd_Click(object sender, EventArgs e)
        {
            pn_addformularios.Visible = false;
        }
        private void btn_save_Click_1(object sender, EventArgs e)
        {
            // Validate data and save form
        }
        private void btn_close_editar_numeracion_Click(object sender, EventArgs e)
        {
            pn_editarnumeracion.Visible = false;
        }
        private void dg_formularios_SelectionChanged(object sender, EventArgs e)
        {
            selectedIdDatagridview = Convert.ToInt32(dg_formularios.CurrentRow.Cells["ColumnId"].Value.ToString());
        }
        private void txtBox_stock_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            UtilitiesCommon.OnlyNumbers(sender, e);
        }
        private void txtBox_stock_numeracion_KeyPress(object sender, KeyPressEventArgs e)
        {
            UtilitiesCommon.OnlyNumbers(sender, e);
        }
        private void txtBox_stock_numeracionEditar_KeyPress(object sender, KeyPressEventArgs e)
        {
            UtilitiesCommon.OnlyNumbers(sender, e);
        }
        private void btn_refreshdata_Click(object sender, EventArgs e)
        {

        }
        private void dg_formularios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            PaintCellFormating(dg_formularios, sender, e);
        }
        private void frm_formularios_Load(object sender, EventArgs e)
        {
            LoadAccessPrivileges();
        }
    }
}
