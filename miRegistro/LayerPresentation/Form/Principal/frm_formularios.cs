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
using LayerBusiness;
using LayerPresentation.Properties;
using LayerSoporte.Cache;
using LayerPresentation.Clases;

namespace LayerPresentation
{
    public partial class frm_formularios : Form
    {
        public frm_formularios()
        {
            InitializeComponent();
            Initialize();
        }
        DataTable currentDt;
        private RadioButton currentOperation;
        private int optionSelected = 1;

        // Functions
        // Refresh all UI
        private void Initialize() 
        {
            ShowCategoriasFormularios("Auto");
            ShowAlertas();
            currentOperation = rb_insert;
        }
        private void RefreshDashboardData() 
        {
            LoadDataFormularios();
        }
        // Load 
        private void LoadAccessPrivileges()
        {
            if (UserLoginCache.Priveleges == Privileges.Estandar)
            {
                // Code here
                btn_changeStockParameter.Enabled = false;

                rb_insert.Enabled = false;
                rb_deleteData.Enabled = false;
                rb_update.Enabled = false;

                btn_save.Enabled = false;
                btn_delete.Enabled = false;
            }
        }

        // Refresh Data stock and Formularios
        public void RefreshDataStock()
        {
            Cn_HandlerFormularios.stockBajo = Settings.Default.StockBajo;
            Cn_HandlerFormularios.stockMedio = Settings.Default.StockMedio;
            Cn_HandlerFormularios.stockAlto = Settings.Default.StockAlto;
        }

        public void LoadDataFormularios()
        {
            currentDt = DataFormularios.data; 

            DisplayDataTableFormularios(dg_formularios_1, "Auto");
            DisplayDataTableFormularios(dg_formularios_2, "Moto");
            DisplayDataTableFormularios(dg_formularios_3, "Varios");
        }        
        private void DisplayDataTableFormularios(DataGridView dt, string name)
        {
            DataTable data = DataFormularios.GetTableForElement(currentDt, name);

            dt.AutoGenerateColumns = false;
            dt.DataSource = data;
        }
        
        private void ShowAlertas() 
        {
            Utilities_Common.layerBusiness.cn_alertas = new Cn_alertas();
            dg_alertas_1.DataSource = Utilities_Common.layerBusiness.cn_alertas.mostrarAlertas();
        }     
        private void ShowCategoriasFormularios(string name) 
        {
            cb_categorias.DataSource = DataFormularios.GetCategoriasForName(Cn_HandlerFormularios.data.formularioCache.GetCategorias(), name);
            cb_categorias.DisplayMember = "Nombre";
            cb_categorias.ValueMember = "Id";
        }
        
        // Set and delete fields for crud
        private void SetFieldForTextBoxCRUD()
        {
            switch (txtBox_object.Text)
            {
                case "Auto":
                    txtBox_numeracion.Text = dg_formularios_1.CurrentRow.Cells[3].Value.ToString();
                    txtBox_stock.Text = dg_formularios_1.CurrentRow.Cells[4].Value.ToString();
                    break;
                case "Moto":
                    txtBox_numeracion.Text = dg_formularios_2.CurrentRow.Cells[3].Value.ToString();
                    txtBox_stock.Text = dg_formularios_2.CurrentRow.Cells[4].Value.ToString();
                    break;
                case "Varios":
                    txtBox_numeracion.Text = dg_formularios_3.CurrentRow.Cells[3].Value.ToString();
                    txtBox_stock.Text = dg_formularios_3.CurrentRow.Cells[4].Value.ToString();
                    break;
                default:
                    txtBox_numeracion.Text = dg_formularios_1.CurrentRow.Cells[3].Value.ToString();
                    txtBox_stock.Text = dg_formularios_1.CurrentRow.Cells[4].Value.ToString();
                    break;
            }
        }
        private void DeleteFieldForTextBoxCRUD() 
        {
            txtBox_stock.Text = "";
            txtBox_numeracion.Text = "";
        }
        
        private string GetCurrentElement()
        {
            string s = "";
            switch (txtBox_object.Text) 
            {
                case "Auto":
                    s = "1";
                    break;
                case "Moto":
                    s = "2";
                    break;
                case "Varios":
                    s = "3";
                    break;
            }
            return s;
        }
        private string GetSelectedID(string element)
        {
            string idFormulario = "";
            switch (element)
            {
                case "1":
                    idFormulario = dg_formularios_1.CurrentRow.Cells["ID1"].Value.ToString();
                    break;
                case "2":
                    idFormulario = dg_formularios_2.CurrentRow.Cells["ID2"].Value.ToString();
                    break;
                case "3":
                    idFormulario = dg_formularios_3.CurrentRow.Cells["ID3"].Value.ToString();
                    break;
                default:
                    idFormulario = dg_formularios_1.CurrentRow.Cells["ID1"].Value.ToString();
                    break;
            }
            return idFormulario;
        }

        private void PaintCellFormating(DataGridView dg, object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dg.Columns[e.ColumnIndex].Index == 4)
            {
                if (Convert.ToInt32(e.Value) <= Cn_HandlerFormularios.stockAlto)
                {
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(41, 217, 85);
                    if (Convert.ToInt32(e.Value) <= Cn_HandlerFormularios.stockMedio)
                    {
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.BackColor = Color.FromArgb(242, 145, 61);
                        if (Convert.ToInt32(e.Value) <= Cn_HandlerFormularios.stockBajo)
                        {
                            e.CellStyle.ForeColor = Color.White;
                            e.CellStyle.BackColor = Color.FromArgb(242, 53, 53);
                        }
                    }
                }
            }
        }

        private bool AutoCheckedRadioButton(RadioButton rb_actual, RadioButton rb_1, RadioButton rb_2, string dg_name)
        {
            if (rb_actual.Checked == true)
            {
                MessageBox.Show("La opcion se encuentra seleccionada!");
                return false;
            }
            else if (rb_1.Checked || rb_2.Checked && !rb_actual.Checked)
            {
                rb_actual.Checked = true;
                rb_1.Checked = false;
                rb_2.Checked = false;

                LoadActualGrid(dg_name);
                return true;
            }
            return false;
        }
        private void LoadActualGrid(string name)
        {
            switch (name)
            {
                case "dg_1":
                    dg_formularios_1.Visible = true;
                    dg_formularios_2.Visible = false;
                    dg_formularios_3.Visible = false;
                    break;
                case "dg_2":
                    dg_formularios_1.Visible = false;
                    dg_formularios_2.Visible = true;
                    dg_formularios_3.Visible = false;
                    break;
                case "dg_3":
                    dg_formularios_1.Visible = false;
                    dg_formularios_2.Visible = false;
                    dg_formularios_3.Visible = true;
                    break;
            }
        }

        private void SetStockLabel()
        {
            switch (txtBox_objeto.Text)
            {
                case "Auto":
                    txtBox_categoria_stock.Text = dg_formularios_1.CurrentRow.Cells["categoria1"].Value.ToString();
                    txtBox_stockAnterior.Text = dg_formularios_1.CurrentRow.Cells[4].Value.ToString();
                    break;
                case "Moto":
                    txtBox_categoria_stock.Text = dg_formularios_2.CurrentRow.Cells["categoria2"].Value.ToString();
                    txtBox_stockAnterior.Text = dg_formularios_2.CurrentRow.Cells[4].Value.ToString();
                    break;
                case "Varios":
                    txtBox_categoria_stock.Text = dg_formularios_3.CurrentRow.Cells["categoria3"].Value.ToString();
                    txtBox_stockAnterior.Text = dg_formularios_3.CurrentRow.Cells[4].Value.ToString();
                    break;
                default:
                    txtBox_categoria_stock.Text = dg_formularios_1.CurrentRow.Cells["categoria1"].Value.ToString();
                    txtBox_stockAnterior.Text = dg_formularios_3.CurrentRow.Cells[4].Value.ToString();
                    break;
            }
        }
        private void SetStockColor(int stock, TextBox txt)
        {
            if (stock != 0)
            {
                if (stock <= Cn_HandlerFormularios.stockAlto)
                {
                    txt.ForeColor = Color.White;
                    txt.BackColor = Color.FromArgb(81, 189, 51);
                    if (stock <= Cn_HandlerFormularios.stockMedio)
                    {
                        txt.ForeColor = Color.White;
                        txt.BackColor = Color.FromArgb(228, 194, 78);
                        if (stock <= Cn_HandlerFormularios.stockBajo)
                        {
                            txt.ForeColor = Color.White;
                            txt.BackColor = Color.FromArgb(192, 25, 28);
                        }
                    }
                }

            }
        }

        private bool AutoCheckedOperations(RadioButton rb_pressed, RadioButton rb_current, string operation)
        {
            if (rb_pressed == rb_current)
            {
                MessageBox.Show("La opcion se encuentra seleccionada!");
                return false;
            }
            else if (rb_current != rb_pressed)
            {
                rb_current.Checked = false;
                rb_pressed.Checked = true;
                currentOperation = rb_pressed;

                LoadActualOperation(operation);
                DeleteFieldForTextBoxCRUD();
                return true;
            }

            return false;
        }
        private void LoadActualOperation(string operation)
        {
            switch (operation)
            {
                case "Insert":
                    btn_save.Enabled = true;
                    btn_update.Enabled = false;
                    btn_delete.Enabled = false;
                    btn_stock.Enabled = false;
                    break;
                case "Update":
                    btn_save.Enabled = false;
                    btn_update.Enabled = true;
                    btn_delete.Enabled = false;
                    btn_stock.Enabled = false;
                    break;
                case "Delete":
                    btn_save.Enabled = false;
                    btn_update.Enabled = false;
                    btn_delete.Enabled = true;
                    btn_stock.Enabled = false;
                    break;
                case "UpdateStock":
                    btn_save.Enabled = false;
                    btn_update.Enabled = false;
                    btn_delete.Enabled = false;
                    btn_stock.Enabled = true;
                    break;
            }
        }

        // Prevent false click
        private void PreventFalseClickInDataGridView(DataGridView dg)
        {
            if (!dg.Enabled)
            {
                MessageBox.Show("Por favor, para insertar, actualizar, eliminar o cambiar el stock seleccione primero esta tabla en '1- Seleccione la tabla'");
            }
            switch (optionSelected)
            {
                case 1:
                    rb_insert.Checked = false;
                    rb_insert.Checked = true;
                    break;
                case 2:
                    cb_categorias.Enabled = true;
                    txtBox_object.Enabled = true;
                    txtBox_numeracion.Enabled = true;
                    txtBox_stock.Enabled = true;

                    SetFieldForTextBoxCRUD();
                    SetStockColor(Convert.ToInt32(txtBox_stock.Text), txtBox_stock);
                    break;
                case 3:
                    rb_deleteData.Checked = false;
                    rb_deleteData.Checked = true;

                    cb_categorias.Enabled = false;
                    txtBox_object.Enabled = false;
                    txtBox_numeracion.Enabled = false;
                    txtBox_stock.Enabled = false;

                    txtBox_stock.ForeColor = Color.Black;
                    txtBox_stock.BackColor = Color.White;

                    SetFieldForTextBoxCRUD();
                    break;
                case 4:
                    rb_updateStock.Checked = false;
                    rb_updateStock.Checked = true;

                    cb_categorias.Enabled = false;
                    txtBox_object.Enabled = false;
                    txtBox_numeracion.Enabled = false;
                    txtBox_stock.Enabled = false;

                    SetStockLabel();
                    SetStockColor(Convert.ToInt32(txtBox_stockAnterior.Text), txtBox_stockAnterior);
                    break;
            }
        }

        private int GetAlertaSelectedId()
        {
            int id = 0;
            id = Convert.ToInt32(dg_alertas_1.CurrentRow.Cells["Cod"].Value.ToString());
            return id;
        }

        private DataTable CreateFormulariosReport()
        {
            return currentDt;
        }
        private DataTable CreateAlertasReport()
        {
            Cn_Formularios objects = new Cn_Formularios();
            DataTable dt = objects.findAlert(Cn_HandlerFormularios.stockBajo);
            return dt;
        }
        // ---------------------------------------
        // Objects (Txtbox, Label, Panel & Others)
        private void txtBox_stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilities_Common.OnlyNumbers(sender, e);
        }

        // Select Operations for do
        private void rb_insert_Click(object sender, EventArgs e)
        {
            if(AutoCheckedOperations(rb_insert, currentOperation, "Insert"))
            {
                // On operation complete
                optionSelected = 1;

                panel_stock.Visible = false;
                panel_crud.Visible = true;

                cb_categorias.Enabled = true;
                txtBox_object.Enabled = true;
                txtBox_numeracion.Enabled = true;
                txtBox_stock.Enabled = true;

                txtBox_stock.ForeColor = Color.Black;
                txtBox_stock.BackColor = Color.White;
            }
        }        
        private void rb_update_Click(object sender, EventArgs e)
        {
            if(dg_formularios_1.SelectedRows.Count > 0 || dg_formularios_2.SelectedRows.Count > 0 || dg_formularios_3.SelectedRows.Count > 0)
            {
                if (AutoCheckedOperations(rb_update, currentOperation, "Update"))
                {
                    // On operation complete
                    optionSelected = 2;

                    panel_stock.Visible = false;
                    panel_crud.Visible = true;

                    cb_categorias.Enabled = true;
                    txtBox_object.Enabled = true;
                    txtBox_numeracion.Enabled = true;
                    txtBox_stock.Enabled = true;

                    SetFieldForTextBoxCRUD();
                    SetStockColor(Convert.ToInt32(txtBox_stock.Text), txtBox_stock);
                }
            }
            else
            {
                MessageBox.Show("Por favor, para actualizar un registro seleccione" +
                    "\nprimero una fila en la tabla");
            }
        }
        private void rb_deleteData_Click(object sender, EventArgs e)
        {
            if(dg_formularios_1.SelectedRows.Count > 0 || dg_formularios_2.SelectedRows.Count > 0 || dg_formularios_3.SelectedRows.Count > 0) 
            {
                if (AutoCheckedOperations(rb_deleteData, currentOperation, "Delete"))
                {
                    // On operation complete
                    optionSelected = 3;

                    panel_stock.Visible = false;
                    panel_crud.Visible = true;

                    cb_categorias.Enabled = false;
                    txtBox_object.Enabled = false;
                    txtBox_numeracion.Enabled = false;
                    txtBox_stock.Enabled = false;

                    txtBox_stock.ForeColor = Color.Black;
                    txtBox_stock.BackColor = Color.White;

                    SetFieldForTextBoxCRUD();
                }
            }
            else
            {
                MessageBox.Show("Por favor, para eliminar un registro seleccione" +
                    "\n primero una fila en la tabla");
            }
        }
        private void rb_updateStock_Click(object sender, EventArgs e)
        {
            if(dg_formularios_1.SelectedRows.Count > 0 || dg_formularios_2.SelectedRows.Count > 0 || dg_formularios_3.SelectedRows.Count > 0) 
            {
                if(AutoCheckedOperations(rb_updateStock, currentOperation, "UpdateStock")) 
                {
                    // On operation complete
                    optionSelected = 4;

                    panel_stock.Visible = true;
                    panel_crud.Visible = false;

                    cb_categorias.Enabled = false;
                    txtBox_object.Enabled = false;
                    txtBox_numeracion.Enabled = false;
                    txtBox_stock.Enabled = false;

                    SetStockLabel();
                    SetStockColor(Convert.ToInt32(txtBox_stockAnterior.Text), txtBox_stockAnterior);
                }
            }
        }
                
        // Datagridviews formatting celds for stock
        private void Dg_Formularios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            PaintCellFormating(dg_formularios_1, sender, e);
        }
        private void dg_formularios_2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            PaintCellFormating(dg_formularios_2, sender, e);
        }
        private void dg_formularios_3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            PaintCellFormating(dg_formularios_3, sender, e);
        }
               
        // Select Table for Operations
        private void rb_moto_Click(object sender, EventArgs e)
        {
            if(AutoCheckedRadioButton(rb_moto, rb_auto, rb_varios, "dg_2")) 
            {
                // On operation complete
                // Change categories in the options
                ShowCategoriasFormularios("Moto");
                txtBox_object.Text = "Moto";
                txtBox_objeto.Text = "Moto";
            }
        }
        private void rb_varios_Click(object sender, EventArgs e)
        {
            if (AutoCheckedRadioButton(rb_varios, rb_auto, rb_moto, "dg_3")) 
            {
                // On operation complete
                // Change categories in the options
                ShowCategoriasFormularios("Varios");
                txtBox_object.Text = "Varios";
                txtBox_objeto.Text = "Varios";
            }
        }
        private void rb_auto_Click(object sender, EventArgs e)
        {
            if(AutoCheckedRadioButton(rb_auto, rb_moto, rb_varios, "dg_1")) 
            {
                // On operation complete
                // Change categories in the options
                ShowCategoriasFormularios("Auto");
                txtBox_object.Text = "Auto";
                txtBox_objeto.Text = "Auto";
            }
        }        
        
        private void dg_formularios_1_Click(object sender, EventArgs e)
        {
            PreventFalseClickInDataGridView(dg_formularios_1);
        }
        private void dg_formularios_2_Click(object sender, EventArgs e)
        {
            PreventFalseClickInDataGridView(dg_formularios_2);
        }
        private void dg_formularios_3_Click(object sender, EventArgs e)
        {
            PreventFalseClickInDataGridView(dg_formularios_3);
        }

        // Crud
        private void btn_update_Click(object sender, EventArgs e)
        {
            try
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
            }
        }
        private void btn_stock_Click(object sender, EventArgs e)
        {
            try
            {
                if (dg_formularios_1.SelectedRows.Count > 0 || dg_formularios_2.SelectedRows.Count > 0 || dg_formularios_3.SelectedRows.Count > 0)
                {
                    Utilities_Common.layerBusiness.cn_formularios.actualizarStock(txtBox_stockNuevo.Text, DateTime.Now.ToString(), GetSelectedID(GetCurrentElement()));
                    frm_successdialog f = new frm_successdialog(3);
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
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            string idFormulario = GetSelectedID(GetCurrentElement());
            try
            {
                if (dg_formularios_1.SelectedRows.Count > 0 || dg_formularios_2.SelectedRows.Count > 0 || dg_formularios_3.SelectedRows.Count > 0)
                {
                    Utilities_Common.layerBusiness.cn_formularios.eliminarFormularios(idFormulario);
                    frm_successdialog f = new frm_successdialog(1);
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
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                Utilities_Common.layerBusiness.cn_formularios.insertarFormularios(cb_categorias.SelectedValue.ToString(), GetCurrentElement(), txtBox_numeracion.Text, txtBox_stock.Text, DateTime.Now.ToString());
                frm_successdialog f = new frm_successdialog(0);
                f.Show();
                // Refresh data
                Utilities_Common.RefreshFormulariosData();
                RefreshDashboardData();

                DeleteFieldForTextBoxCRUD();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Consultas rapidas
        private void btn_stockbajo_Click(object sender, EventArgs e)
        {
            Alertas.BuscarRapido("bajo");
        }
        private void btn_stockmedio_Click(object sender, EventArgs e)
        {
            Alertas.BuscarRapido("medio");        
        }
        private void btn_stockalto_Click(object sender, EventArgs e)
        {
            Alertas.BuscarRapido("alto");
        }
        private void btn_stockAlerta_Click(object sender, EventArgs e)
        {
            frm_formularios_alerta mv = new frm_formularios_alerta(false, 1, DateTime.Now.ToShortDateString(), UserLoginCache.Nombre);
            mv.Show();
        }

        // Stock parameters
        private void btn_changeStockParameter_Click(object sender, EventArgs e)
        {
            if (Cn_HandlerFormularios.stockBajo.ToString() != txtBox_stockBajo.Text || Cn_HandlerFormularios.stockMedio.ToString() != txtBox_stockMedio.Text || txtBox_stockAlto.Text != txtBox_stockAlto.Text)
            {
                Settings.Default.StockBajo = Convert.ToInt32(txtBox_stockBajo.Text);
                Settings.Default.StockMedio = Convert.ToInt32(txtBox_stockMedio.Text);
                Settings.Default.StockAlto = Convert.ToInt32(txtBox_stockAlto.Text);
                Properties.Settings.Default.Save();

                MessageBox.Show(@"Parametros actualizados correctamente!" + "\nLas alertas y el numero de stock estan siendo actualizados.", "Operacion exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh data
                Utilities_Common.RefreshFormulariosData();
                RefreshDashboardData();
            }
        }

        // Alerts Details Button
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

        // Save Pdf and Informe
        private void btn_savePdf_informe_Click(object sender, EventArgs e)
        {
            if (Utilites_Pdf.ExportDataTableInPdf(CreateFormulariosReport(), "InformeFORMULARIOS"))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }
        private void btn_savePdf_autos_Click(object sender, EventArgs e)
        {
            if (Utilites_Pdf.ExportDataGridViewInPdf(dg_formularios_1, "FormulariosAUTO"))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }
        private void btn_savePdf_motos_Click(object sender, EventArgs e)
        {
            if (Utilites_Pdf.ExportDataGridViewInPdf(dg_formularios_2, "FormulariosMOTO"))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }
        private void btn_savePdf_varios_Click(object sender, EventArgs e)
        {
            if (Utilites_Pdf.ExportDataGridViewInPdf(dg_formularios_3, "FormulariosVARIOS"))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }
        private void btn_exportPdf_alertas_Click(object sender, EventArgs e)
        {
            if (Utilites_Pdf.ExportDataTableInPdf(CreateAlertasReport(), "InformeALERTAS_StockBajo"))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }
        
        // Refresh data
        private void btn_refreshdata_Click(object sender, EventArgs e)
        {
            Utilities_Common.RefreshFormulariosData();
            RefreshDashboardData();
        }
        
        private void txtBox_stockNuevo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Utilities_Common.OnlyNumbers(sender, e);
        }
        
        private void frm_formularios_Load(object sender, EventArgs e)
        {
            RefreshDashboardData();

            txtBox_stockBajo.Text = Cn_HandlerFormularios.stockBajo.ToString();
            txtBox_stockMedio.Text = Cn_HandlerFormularios.stockMedio.ToString();
            txtBox_stockAlto.Text = Cn_HandlerFormularios.stockAlto.ToString();

            LoadAccessPrivileges();
        }
    }
}
