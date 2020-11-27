namespace LayerPresentation
{
    partial class frm_formularios_alerta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_formularios_alerta));
            this.barra_titulo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_minimize = new System.Windows.Forms.PictureBox();
            this.btn_close = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_fechayhora = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_numeroDeAlerta = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_usuarioAlertado = new System.Windows.Forms.Label();
            this.UltimaActualizacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stocks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numeracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoria1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Objeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dg_formulariosAlert = new System.Windows.Forms.DataGridView();
            this.btn_savepdf = new System.Windows.Forms.Button();
            this.barra_titulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_formulariosAlert)).BeginInit();
            this.SuspendLayout();
            // 
            // barra_titulo
            // 
            this.barra_titulo.BackColor = System.Drawing.Color.Maroon;
            this.barra_titulo.Controls.Add(this.label1);
            this.barra_titulo.Controls.Add(this.btn_minimize);
            this.barra_titulo.Controls.Add(this.btn_close);
            this.barra_titulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.barra_titulo.Location = new System.Drawing.Point(0, 0);
            this.barra_titulo.Name = "barra_titulo";
            this.barra_titulo.Size = new System.Drawing.Size(897, 32);
            this.barra_titulo.TabIndex = 0;
            this.barra_titulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barra_titulo_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(284, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Alerta de stock bajo de formularios";
            // 
            // btn_minimize
            // 
            this.btn_minimize.BackgroundImage = global::LayerPresentation.Properties.Resources.minimize;
            this.btn_minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_minimize.Location = new System.Drawing.Point(849, 8);
            this.btn_minimize.Margin = new System.Windows.Forms.Padding(2);
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(17, 19);
            this.btn_minimize.TabIndex = 5;
            this.btn_minimize.TabStop = false;
            this.btn_minimize.Click += new System.EventHandler(this.btn_minimize_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackgroundImage = global::LayerPresentation.Properties.Resources.close;
            this.btn_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.Location = new System.Drawing.Point(870, 8);
            this.btn_close.Margin = new System.Windows.Forms.Padding(2);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(17, 19);
            this.btn_close.TabIndex = 3;
            this.btn_close.TabStop = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(512, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Ultima alerta por el sistema: \r\n";
            // 
            // lbl_fechayhora
            // 
            this.lbl_fechayhora.AutoSize = true;
            this.lbl_fechayhora.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_fechayhora.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_fechayhora.Location = new System.Drawing.Point(729, 44);
            this.lbl_fechayhora.Name = "lbl_fechayhora";
            this.lbl_fechayhora.Size = new System.Drawing.Size(106, 18);
            this.lbl_fechayhora.TabIndex = 10;
            this.lbl_fechayhora.Text = "fecha y hora.\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(26, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Numero de alerta: ";
            // 
            // lbl_numeroDeAlerta
            // 
            this.lbl_numeroDeAlerta.AutoSize = true;
            this.lbl_numeroDeAlerta.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_numeroDeAlerta.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_numeroDeAlerta.Location = new System.Drawing.Point(178, 42);
            this.lbl_numeroDeAlerta.Name = "lbl_numeroDeAlerta";
            this.lbl_numeroDeAlerta.Size = new System.Drawing.Size(39, 18);
            this.lbl_numeroDeAlerta.TabIndex = 12;
            this.lbl_numeroDeAlerta.Text = "num";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(261, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 13;
            this.label3.Text = "Usuario alertado:";
            // 
            // lbl_usuarioAlertado
            // 
            this.lbl_usuarioAlertado.AutoSize = true;
            this.lbl_usuarioAlertado.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_usuarioAlertado.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_usuarioAlertado.Location = new System.Drawing.Point(401, 42);
            this.lbl_usuarioAlertado.Name = "lbl_usuarioAlertado";
            this.lbl_usuarioAlertado.Size = new System.Drawing.Size(63, 18);
            this.lbl_usuarioAlertado.TabIndex = 14;
            this.lbl_usuarioAlertado.Text = "usuario \r\n";
            // 
            // UltimaActualizacion
            // 
            this.UltimaActualizacion.DataPropertyName = "Ultima actualizacion";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.UltimaActualizacion.DefaultCellStyle = dataGridViewCellStyle1;
            this.UltimaActualizacion.HeaderText = "UltimaActualizacion";
            this.UltimaActualizacion.MinimumWidth = 6;
            this.UltimaActualizacion.Name = "UltimaActualizacion";
            this.UltimaActualizacion.ReadOnly = true;
            this.UltimaActualizacion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.UltimaActualizacion.Width = 220;
            // 
            // Stocks
            // 
            this.Stocks.DataPropertyName = "Stock Actual";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Stocks.DefaultCellStyle = dataGridViewCellStyle2;
            this.Stocks.HeaderText = "Stock Actuales";
            this.Stocks.MinimumWidth = 6;
            this.Stocks.Name = "Stocks";
            this.Stocks.ReadOnly = true;
            this.Stocks.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Stocks.Width = 120;
            // 
            // Numeracion
            // 
            this.Numeracion.DataPropertyName = "Numeracion";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Numeracion.DefaultCellStyle = dataGridViewCellStyle3;
            this.Numeracion.HeaderText = "Numeracion";
            this.Numeracion.MinimumWidth = 6;
            this.Numeracion.Name = "Numeracion";
            this.Numeracion.ReadOnly = true;
            this.Numeracion.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Numeracion.Width = 150;
            // 
            // categoria1
            // 
            this.categoria1.DataPropertyName = "Categoria";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.categoria1.DefaultCellStyle = dataGridViewCellStyle4;
            this.categoria1.HeaderText = "Categoria del formulario";
            this.categoria1.MinimumWidth = 6;
            this.categoria1.Name = "categoria1";
            this.categoria1.ReadOnly = true;
            this.categoria1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.categoria1.Width = 220;
            // 
            // Objeto
            // 
            this.Objeto.DataPropertyName = "Objeto";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Objeto.DefaultCellStyle = dataGridViewCellStyle5;
            this.Objeto.HeaderText = "Objeto";
            this.Objeto.MinimumWidth = 6;
            this.Objeto.Name = "Objeto";
            this.Objeto.ReadOnly = true;
            this.Objeto.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ID1
            // 
            this.ID1.DataPropertyName = "Id";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.LightCoral;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ID1.DefaultCellStyle = dataGridViewCellStyle6;
            this.ID1.HeaderText = "ID";
            this.ID1.MinimumWidth = 6;
            this.ID1.Name = "ID1";
            this.ID1.ReadOnly = true;
            this.ID1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ID1.Width = 45;
            // 
            // dg_formulariosAlert
            // 
            this.dg_formulariosAlert.AllowUserToAddRows = false;
            this.dg_formulariosAlert.AllowUserToDeleteRows = false;
            this.dg_formulariosAlert.AllowUserToResizeColumns = false;
            this.dg_formulariosAlert.AllowUserToResizeRows = false;
            this.dg_formulariosAlert.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dg_formulariosAlert.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dg_formulariosAlert.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(53)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_formulariosAlert.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dg_formulariosAlert.ColumnHeadersHeight = 25;
            this.dg_formulariosAlert.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID1,
            this.Objeto,
            this.categoria1,
            this.Numeracion,
            this.Stocks,
            this.UltimaActualizacion});
            this.dg_formulariosAlert.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_formulariosAlert.DefaultCellStyle = dataGridViewCellStyle8;
            this.dg_formulariosAlert.EnableHeadersVisualStyles = false;
            this.dg_formulariosAlert.GridColor = System.Drawing.Color.Black;
            this.dg_formulariosAlert.Location = new System.Drawing.Point(21, 71);
            this.dg_formulariosAlert.MultiSelect = false;
            this.dg_formulariosAlert.Name = "dg_formulariosAlert";
            this.dg_formulariosAlert.ReadOnly = true;
            this.dg_formulariosAlert.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_formulariosAlert.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dg_formulariosAlert.RowHeadersVisible = false;
            this.dg_formulariosAlert.RowHeadersWidth = 51;
            this.dg_formulariosAlert.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dg_formulariosAlert.Size = new System.Drawing.Size(858, 302);
            this.dg_formulariosAlert.TabIndex = 6;
            this.dg_formulariosAlert.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dg_formulariosAlert_CellFormatting);
            // 
            // btn_savepdf
            // 
            this.btn_savepdf.BackColor = System.Drawing.Color.White;
            this.btn_savepdf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_savepdf.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btn_savepdf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_savepdf.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_savepdf.ForeColor = System.Drawing.Color.DarkCyan;
            this.btn_savepdf.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_savepdf.Location = new System.Drawing.Point(725, 379);
            this.btn_savepdf.Name = "btn_savepdf";
            this.btn_savepdf.Size = new System.Drawing.Size(154, 23);
            this.btn_savepdf.TabIndex = 90;
            this.btn_savepdf.Text = "Guardar PDF";
            this.btn_savepdf.UseVisualStyleBackColor = false;
            this.btn_savepdf.Click += new System.EventHandler(this.btn_savepdf_Click);
            // 
            // frm_formularios_alerta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 409);
            this.Controls.Add(this.btn_savepdf);
            this.Controls.Add(this.lbl_usuarioAlertado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_numeroDeAlerta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_fechayhora);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dg_formulariosAlert);
            this.Controls.Add(this.barra_titulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_formularios_alerta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alerta de stock";
            this.Load += new System.EventHandler(this.frm_formularios_alerta_Load);
            this.barra_titulo.ResumeLayout(false);
            this.barra_titulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dg_formulariosAlert)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel barra_titulo;
        private System.Windows.Forms.PictureBox btn_minimize;
        private System.Windows.Forms.PictureBox btn_close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_fechayhora;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_numeroDeAlerta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_usuarioAlertado;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimaActualizacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stocks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numeracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoria1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Objeto;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID1;
        private System.Windows.Forms.DataGridView dg_formulariosAlert;
        private System.Windows.Forms.Button btn_savepdf;
    }
}