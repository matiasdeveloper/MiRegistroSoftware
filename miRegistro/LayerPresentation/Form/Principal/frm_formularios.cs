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
        private Cn_Formularios _cnObject = new Cn_Formularios();
        private DataTable currentDt;

        #region variables

        private bool insert = true;
        private bool update = false;
        private bool delete = false;
        private bool stock = false;

        private bool autos = true;
        private bool motos = false;
        private bool varios = false;

        private int actualGrid = 1;
        private int optionSelected = 1;

        #endregion

        public frm_formularios()
        {
            InitializeComponent();
        }
        // Functions
        // Refresh all UI
        private void RefreshAll() 
        {
            RefreshFormularios();
            RefreshDataStock();

            mostrarCategorias("Auto");
            mostrarAlertas();
        }
        // Refresh Data stock and Formularios
        public void RefreshDataStock()
        {
            Cn_HandlerFormularios.stockBajo = Settings.Default.StockBajo;
            Cn_HandlerFormularios.stockMedio = Settings.Default.StockMedio;
            Cn_HandlerFormularios.stockAlto = Settings.Default.StockAlto;
        }
        public void RefreshData() 
        {
            _cnObject.RefreshDataFormulariosCache();
            _cnObject.RefreshDataCategoriasCache();
            _cnObject.RefreshDataDashboardCache();
        }

        public void RefreshFormularios()
        {
            DataTable dt = DataFormularios.GetFormulariosCacheByID(Cn_HandlerFormularios.current);
            currentDt = dt; 

            mostarFormularios(dg_formularios_1, "Auto");
            mostarFormularios(dg_formularios_2, "Moto");
            mostarFormularios(dg_formularios_3, "Varios");
        }        
        private void mostarFormularios(DataGridView dt, string name)
        {
            DataTable data = DataFormularios.GetTableForElement(currentDt, name);

            dt.AutoGenerateColumns = false;
            dt.DataSource = data;
        }
        
        private void mostrarAlertas() 
        {
            Cn_alertas objects = new Cn_alertas();
            dg_alertas_1.DataSource = objects.mostrarAlertas();
        }
        private void mostrarCategorias(string name) 
        {
            cb_categorias.DataSource = DataFormularios.GetCategoriasForName(Cn_HandlerFormularios.data.formularioCache.GetCategorias(), name);
            cb_categorias.DisplayMember = "Nombre";
            cb_categorias.ValueMember = "Id";
        }
        
        // Set and delete fields for crud
        private void setFields()
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
        private void deleteFields() 
        {
            txtBox_stock.Text = "";
            txtBox_numeracion.Text = "";
        }
        
        private string getElement()
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
        private string getId(string element)
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

        // Only number in stock
        private void txtBox_stock_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

        // Select Operations for do
        private void rb_insert_Click(object sender, EventArgs e)
        {
            if(insert == true) 
            {
                MessageBox.Show("La opcion se encuentra seleccionada!");
            } else if(stock == true || update == true || delete == true && insert == false) 
            {
                optionSelected = 1;

                insert = true;
                update = false;
                delete = false;
                stock = false;

                rb_insert.Checked = true;
                rb_update.Checked = false;
                rb_deleteData.Checked = false;
                rb_updateStock.Checked = false;

                btn_save.Enabled = true;
                btn_update.Enabled = false;
                btn_delete.Enabled = false;
                btn_stock.Enabled = false;

                panel_stock.Visible = false;
                panel_crud.Visible = true;

                cb_categorias.Enabled = true;
                txtBox_object.Enabled = true;
                txtBox_numeracion.Enabled = true;
                txtBox_stock.Enabled = true;

                txtBox_stock.ForeColor = Color.Black;
                txtBox_stock.BackColor = Color.White;

                deleteFields();
            }
        }
        private void rb_update_Click(object sender, EventArgs e)
        {
            if (update == true)
            {
                MessageBox.Show("La opcion se encuentra seleccionada!");
            }
            else if (stock == true || insert == true || delete == true && update == false)
            {
                if(dg_formularios_1.SelectedRows.Count > 0 || dg_formularios_2.SelectedRows.Count > 0 || dg_formularios_3.SelectedRows.Count > 0)
                {
                    optionSelected = 2;

                    insert = false;
                    update = true;
                    delete = false;
                    stock = false;

                    rb_insert.Checked = false;
                    rb_update.Checked = true;
                    rb_deleteData.Checked = false;
                    rb_updateStock.Checked = false;

                    btn_save.Enabled = false;
                    btn_update.Enabled = true;
                    btn_delete.Enabled = false;
                    btn_stock.Enabled = false;

                    panel_stock.Visible = false;
                    panel_crud.Visible = true;

                    cb_categorias.Enabled = true;
                    txtBox_object.Enabled = true;
                    txtBox_numeracion.Enabled = true;
                    txtBox_stock.Enabled = true;

                    setFields();
                    getColorForStock(Convert.ToInt32(txtBox_stock.Text), txtBox_stock);
                }
                else 
                {
                    MessageBox.Show("Por favor, para actualizar un registro seleccione" +
                        "\nprimero una fila en la tabla");
                }
            }
        }
        private void rb_deleteData_Click(object sender, EventArgs e)
        {
            if (delete == true)
            {
                MessageBox.Show("La opcion se encuentra seleccionada!");
            }
            else if (stock == true || update == true || insert == true && delete == false)
            {
                if (dg_formularios_1.SelectedRows.Count > 0 || dg_formularios_2.SelectedRows.Count > 0 || dg_formularios_3.SelectedRows.Count > 0)
                {
                    optionSelected = 3;

                    insert = false;
                    update = false;
                    delete = true;
                    stock = false;

                    rb_insert.Checked = false;
                    rb_update.Checked = false;
                    rb_deleteData.Checked = true;
                    rb_updateStock.Checked = false;

                    btn_save.Enabled = false;
                    btn_update.Enabled = false;
                    btn_delete.Enabled = true;
                    btn_stock.Enabled = false;

                    panel_stock.Visible = false;
                    panel_crud.Visible = true;

                    cb_categorias.Enabled = false;
                    txtBox_object.Enabled = false;
                    txtBox_numeracion.Enabled = false;
                    txtBox_stock.Enabled = false;

                    txtBox_stock.ForeColor = Color.Black;
                    txtBox_stock.BackColor = Color.White;

                    setFields();
                }
                else
                {
                    MessageBox.Show("Por favor, para eliminar un registro seleccione" +
                        "\n primero una fila en la tabla");
                }
            }
        }
        private void rb_updateStock_Click(object sender, EventArgs e)
        {
            if (stock == true)
            {
                MessageBox.Show("La opcion se encuentra seleccionada!");
            }
            else if (delete == true || update == true || insert == true && stock == false)
            {
                if (dg_formularios_1.SelectedRows.Count > 0 || dg_formularios_2.SelectedRows.Count > 0 || dg_formularios_3.SelectedRows.Count > 0)
                {
                    optionSelected = 4;

                    insert = false;
                    update = false;
                    delete = false;
                    stock = true;

                    rb_insert.Checked = false;
                    rb_update.Checked = false;
                    rb_deleteData.Checked = false;
                    rb_updateStock.Checked = true;

                    btn_save.Enabled = false;
                    btn_update.Enabled = false;
                    btn_delete.Enabled = false;
                    btn_stock.Enabled = true;

                    panel_stock.Visible = true;
                    panel_crud.Visible = false;

                    cb_categorias.Enabled = false;
                    txtBox_object.Enabled = false;
                    txtBox_numeracion.Enabled = false;
                    txtBox_stock.Enabled = false;
 

                    setFieldsForStock();
                    getColorForStock(Convert.ToInt32(txtBox_stockAnterior.Text), txtBox_stockAnterior);
                }
                else
                {
                    MessageBox.Show("Por favor, para eliminar un registro seleccione" +
                        "\n primero una fila en la tabla");
                }
            }
        }
                
        // Stock color DG FORMATTING CELLS
        private void Dg_Formularios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dg_formularios_1.Columns[e.ColumnIndex].Index == 4) 
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
        private void dg_formularios_2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dg_formularios_2.Columns[e.ColumnIndex].Index == 4)
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
        private void dg_formularios_3_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dg_formularios_3.Columns[e.ColumnIndex].Index == 4)
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
        
        // Functions for stock color
        private void setFieldsForStock()
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
        private void getColorForStock(int stock, TextBox txt)
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


        // Select Table for Operations
        private void rb_moto_Click(object sender, EventArgs e)
        {
            if (motos == true)
            {
                MessageBox.Show("La opcion se encuentra seleccionada!");
            }
            else if (autos == true || varios == true && motos == false)
            {
                actualGrid = 2;

                autos = false;
                motos = true;
                varios = false;

                rb_auto.Checked = false;
                rb_moto.Checked = true;
                rb_varios.Checked = false;

                dg_formularios_1.Visible = false;

                dg_formularios_2.Visible = true;

                dg_formularios_3.Visible = false;

                mostrarCategorias("Moto");
                txtBox_object.Text = "Moto";
                txtBox_objeto.Text = "Moto";
            }
        }
        private void rb_varios_Click(object sender, EventArgs e)
        {
            if (varios == true)
            {
                MessageBox.Show("La opcion se encuentra seleccionada!");
            }
            else if (autos == true || motos == true && varios == false)
            {
                actualGrid = 3;

                autos = false;
                motos = false;
                varios = true;

                rb_auto.Checked = false;
                rb_moto.Checked = false;
                rb_varios.Checked = true;

                dg_formularios_1.Visible = false;

                dg_formularios_2.Visible = false;

                dg_formularios_3.Visible = true;

                /*categories*/
                mostrarCategorias("Varios");
                txtBox_object.Text = "Varios";
                txtBox_objeto.Text = "Varios";
            }
        }
        private void rb_auto_Click(object sender, EventArgs e)
        {
            if (autos == true)
            {
                MessageBox.Show("La opcion se encuentra seleccionada!");
            }
            else if (motos == true || varios == true && autos == false)
            {
                actualGrid = 1;

                autos = true;
                motos = false;
                varios = false;

                rb_auto.Checked = true;
                rb_moto.Checked = false;
                rb_varios.Checked = false;

                dg_formularios_1.Visible = true;

                dg_formularios_2.Visible = false;

                dg_formularios_3.Visible = false;

                /*categories*/
                // Change categories in the CATEGORIES and OBJECTS
                mostrarCategorias("Auto");
                txtBox_object.Text = "Auto";
                txtBox_objeto.Text = "Auto";
            }
        }

        // Prevent false click
        private void dg_formularios_1_Click(object sender, EventArgs e)
        {
            if (!dg_formularios_1.Enabled && actualGrid != 1)
            {
                MessageBox.Show("Por favor, para insertar, actualizar, eliminar o cambiar el stock seleccione primero esta tabla en '1- Seleccione la tabla'");
            } else 
            {
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

                        setFields();
                        getColorForStock(Convert.ToInt32(txtBox_stock.Text), txtBox_stock);
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

                        setFields();
                        break;
                    case 4:
                        rb_updateStock.Checked = false;
                        rb_updateStock.Checked = true;

                        cb_categorias.Enabled = false;
                        txtBox_object.Enabled = false;
                        txtBox_numeracion.Enabled = false;
                        txtBox_stock.Enabled = false;

                        setFieldsForStock();
                        getColorForStock(Convert.ToInt32(txtBox_stockAnterior.Text), txtBox_stockAnterior);
                        break;
                }
            }
        }
        private void dg_formularios_2_Click(object sender, EventArgs e)
        {
            if (!dg_formularios_2.Enabled && actualGrid != 2)
            {
                MessageBox.Show("Por favor, para insertar, actualizar, eliminar o cambiar el stock seleccione primero esta tabla en '1- Seleccione la tabla'");
            }
            else
            {
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

                        setFields();
                        getColorForStock(Convert.ToInt32(txtBox_stock.Text), txtBox_stock);
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

                        setFields();
                        break;
                    case 4:
                        rb_updateStock.Checked = false;
                        rb_updateStock.Checked = true;

                        cb_categorias.Enabled = false;
                        txtBox_object.Enabled = false;
                        txtBox_numeracion.Enabled = false;
                        txtBox_stock.Enabled = false;

                        setFieldsForStock();
                        getColorForStock(Convert.ToInt32(txtBox_stockAnterior.Text), txtBox_stockAnterior);
                        break;
                }
            }
        }
        private void dg_formularios_3_Click(object sender, EventArgs e)
        {
            if (!dg_formularios_3.Enabled && actualGrid != 3)
            {
                MessageBox.Show("Por favor, para insertar, actualizar, eliminar o cambiar el stock seleccione primero esta tabla en '1- Seleccione la tabla'");
            }
            else
            {
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

                        setFields();
                        getColorForStock(Convert.ToInt32(txtBox_stock.Text), txtBox_stock);
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

                        setFields();
                        break;
                    case 4:
                        rb_updateStock.Checked = false;
                        rb_updateStock.Checked = true;

                        cb_categorias.Enabled = false;
                        txtBox_object.Enabled = false;
                        txtBox_numeracion.Enabled = false;
                        txtBox_stock.Enabled = false;

                        setFieldsForStock();
                        getColorForStock(Convert.ToInt32(txtBox_stockAnterior.Text), txtBox_stockAnterior);
                        break;
                }
            }
        }

        // Crud
        private void btn_update_Click(object sender, EventArgs e)
        {
            try
            {
                if (dg_formularios_1.SelectedRows.Count > 0)
                {
                    _cnObject.actualizarFormularios((int)cb_categorias.SelectedValue, Convert.ToInt32(getElement()), txtBox_numeracion.Text, txtBox_stock.Text, DateTime.Now.ToString(), getId(getElement()));
                    frm_successdialog f = new frm_successdialog(2);
                    f.Show();
                    // Refresh data
                    RefreshData();
                    RefreshAll();

                    deleteFields();
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
                    _cnObject.actualizarStock(txtBox_stockNuevo.Text, DateTime.Now.ToString(), getId(getElement()));
                    frm_successdialog f = new frm_successdialog(3);
                    f.Show();
                    // Refresh data
                    RefreshData();
                    RefreshAll();

                    deleteFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            string idFormulario = getId(getElement());
            try
            {
                if (dg_formularios_1.SelectedRows.Count > 0 || dg_formularios_2.SelectedRows.Count > 0 || dg_formularios_3.SelectedRows.Count > 0)
                {
                    _cnObject.eliminarFormularios(idFormulario);
                    frm_successdialog f = new frm_successdialog(1);
                    f.Show();
                    // Refresh data
                    RefreshData();
                    RefreshAll();

                    deleteFields();
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
                _cnObject.insertarFormularios(cb_categorias.SelectedValue.ToString(), getElement(), txtBox_numeracion.Text, txtBox_stock.Text, DateTime.Now.ToString());
                frm_successdialog f = new frm_successdialog(0);
                f.Show();
                // Refresh data
                RefreshData();
                RefreshAll();

                deleteFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Consultas rapidas
        private void btn_stockbajo_Click(object sender, EventArgs e)
        {
            int num = Cn_HandlerFormularios.data.formularioCache.totalBajos;
            MessageBox.Show("Tenes " + num + " formularios que cuentan con stock bajo", "Consulta rapida (Auto, Motos, Varios)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_stockmedio_Click(object sender, EventArgs e)
        {
            int num = Cn_HandlerFormularios.data.formularioCache.totalMedios;
            MessageBox.Show("Tenes " + num + " formularios que cuentan con stock medio", "Consulta rapida (Auto, Motos, Varios)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btn_stockalto_Click(object sender, EventArgs e)
        {
            int num = Cn_HandlerFormularios.data.formularioCache.totalAltos;
            MessageBox.Show("Tenes " + num + " formularios que cuentan con stock alto", "Consulta rapida (Auto, Motos, Varios)", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                RefreshDataStock();
                RefreshData();
                RefreshAll();
            }
        }

        // Alerts
        private void btn_detalle_alerta_Click(object sender, EventArgs e)
        {
            frm_formularios_alerta mv = new frm_formularios_alerta(true, getAlertSelectedId(), dg_alertas_1.CurrentRow.Cells["fecha"].Value.ToString(), dg_alertas_1.CurrentRow.Cells["user"].Value.ToString());
            mv.Show();
        }
        private int getAlertSelectedId() 
        {
            int id = 0;
            id = Convert.ToInt32(dg_alertas_1.CurrentRow.Cells["Cod"].Value.ToString());
            return id;
        }

        // Save Pdf and Informe
        private void btn_savePdf_informe_Click(object sender, EventArgs e)
        {
            if(ExportInformePdf(GenearteInforme(), "InformeFORMULARIOS")) 
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }
        private void btn_savePdf_autos_Click(object sender, EventArgs e)
        {
            if (ExportDatagridviewPdf(dg_formularios_1, "FormulariosAUTO"))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }
        private void btn_savePdf_motos_Click(object sender, EventArgs e)
        {
            if (ExportDatagridviewPdf(dg_formularios_2, "FormulariosMOTO"))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }
        private void btn_savePdf_varios_Click(object sender, EventArgs e)
        {
            if (ExportDatagridviewPdf(dg_formularios_3, "FormulariosVARIOS"))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }
        private DataTable GenearteInforme() 
        {
            return currentDt;
        }
        private DataTable GenerateInformeAlertas() 
        {
            Cn_Formularios objects = new Cn_Formularios();   
            DataTable dt = objects.findAlert(Cn_HandlerFormularios.stockBajo);
            return dt;
        }
        private bool ExportInformePdf(DataTable dt, string name)
        {
            string dia = DateTime.Now.Day + "-" + DateTime.Now.Month;
            string user = name + "_" + dia;

            bool result = DataSave.ExportToPdf(dt, user);

            return result;
        }
        private bool ExportDatagridviewPdf(DataGridView dt, string name)
        {
            Random r = new Random();
            string dia = DateTime.Now.Day + "-" + DateTime.Now.Month;
            string user = name + "_" + dia;

            bool result = DataSave.saveInPdf(dt, user);

            return result;
        }
        private void btn_exportPdf_alertas_Click(object sender, EventArgs e)
        {
            if (ExportInformePdf(GenerateInformeAlertas(), "InformeALERTAS_StockBajo"))
            {
                frm_successdialog f = new frm_successdialog(5);
                f.Show();
            }
        }

        // Refresh data
        private void btn_refreshdata_Click(object sender, EventArgs e)
        {
            RefreshData();
            RefreshDataStock();
            RefreshAll();
        }
        // Load 
        private void cargarPrivilegios()
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
        private void frm_formularios_Load(object sender, EventArgs e)
        {
            RefreshAll();

            txtBox_stockBajo.Text = Cn_HandlerFormularios.stockBajo.ToString();
            txtBox_stockMedio.Text = Cn_HandlerFormularios.stockMedio.ToString();
            txtBox_stockAlto.Text = Cn_HandlerFormularios.stockAlto.ToString();

            cargarPrivilegios();
        }
    }
}
