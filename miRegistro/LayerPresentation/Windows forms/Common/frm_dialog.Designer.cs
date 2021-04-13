namespace LayerPresentation
{
    partial class frm_successdialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_successdialog));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_info = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_aceptar = new Bunifu.Framework.UI.BunifuThinButton2();
            this.lbl_tittle = new System.Windows.Forms.Label();
            this.pn_success = new System.Windows.Forms.Panel();
            this.tab = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage_error = new System.Windows.Forms.TabPage();
            this.tabPage_sucess = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuThinButton21 = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pn_success.SuspendLayout();
            this.tab.SuspendLayout();
            this.tabPage_error.SuspendLayout();
            this.tabPage_sucess.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(129, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 120);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_info
            // 
            this.lbl_info.Font = new System.Drawing.Font("Poppins ExtraLight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_info.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_info.Location = new System.Drawing.Point(9, 155);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(370, 29);
            this.lbl_info.TabIndex = 3;
            this.lbl_info.Text = "Escriba la excpecion encontrada aqui";
            this.lbl_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.ActiveBorderThickness = 1;
            this.btn_aceptar.ActiveCornerRadius = 30;
            this.btn_aceptar.ActiveFillColor = System.Drawing.Color.Red;
            this.btn_aceptar.ActiveForecolor = System.Drawing.Color.White;
            this.btn_aceptar.ActiveLineColor = System.Drawing.Color.Red;
            this.btn_aceptar.BackColor = System.Drawing.Color.Transparent;
            this.btn_aceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_aceptar.BackgroundImage")));
            this.btn_aceptar.ButtonText = "Aceptar";
            this.btn_aceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_aceptar.Font = new System.Drawing.Font("Poppins", 12F);
            this.btn_aceptar.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_aceptar.IdleBorderThickness = 1;
            this.btn_aceptar.IdleCornerRadius = 30;
            this.btn_aceptar.IdleFillColor = System.Drawing.Color.Transparent;
            this.btn_aceptar.IdleForecolor = System.Drawing.Color.Red;
            this.btn_aceptar.IdleLineColor = System.Drawing.Color.Red;
            this.btn_aceptar.Location = new System.Drawing.Point(94, 182);
            this.btn_aceptar.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(201, 43);
            this.btn_aceptar.TabIndex = 241;
            this.btn_aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_aceptar.Click += new System.EventHandler(this.btn_c1_siguiente_Click);
            // 
            // lbl_tittle
            // 
            this.lbl_tittle.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tittle.Location = new System.Drawing.Point(47, 132);
            this.lbl_tittle.Name = "lbl_tittle";
            this.lbl_tittle.Size = new System.Drawing.Size(291, 27);
            this.lbl_tittle.TabIndex = 2;
            this.lbl_tittle.Text = "Lo sentimos!";
            this.lbl_tittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pn_success
            // 
            this.pn_success.Controls.Add(this.btn_aceptar);
            this.pn_success.Controls.Add(this.lbl_info);
            this.pn_success.Controls.Add(this.lbl_tittle);
            this.pn_success.Controls.Add(this.pictureBox1);
            this.pn_success.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_success.Location = new System.Drawing.Point(3, 3);
            this.pn_success.Name = "pn_success";
            this.pn_success.Size = new System.Drawing.Size(395, 244);
            this.pn_success.TabIndex = 242;
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabPage_error);
            this.tab.Controls.Add(this.tabPage_sucess);
            this.tab.Depth = 0;
            this.tab.Location = new System.Drawing.Point(-2, -14);
            this.tab.MouseState = MaterialSkin.MouseState.HOVER;
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(409, 280);
            this.tab.TabIndex = 242;
            // 
            // tabPage_error
            // 
            this.tabPage_error.Controls.Add(this.pn_success);
            this.tabPage_error.Location = new System.Drawing.Point(4, 26);
            this.tabPage_error.Name = "tabPage_error";
            this.tabPage_error.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_error.Size = new System.Drawing.Size(401, 250);
            this.tabPage_error.TabIndex = 1;
            this.tabPage_error.Text = "Error";
            this.tabPage_error.UseVisualStyleBackColor = true;
            // 
            // tabPage_sucess
            // 
            this.tabPage_sucess.Controls.Add(this.panel1);
            this.tabPage_sucess.Location = new System.Drawing.Point(4, 26);
            this.tabPage_sucess.Name = "tabPage_sucess";
            this.tabPage_sucess.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_sucess.Size = new System.Drawing.Size(401, 250);
            this.tabPage_sucess.TabIndex = 0;
            this.tabPage_sucess.Text = "Success";
            this.tabPage_sucess.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bunifuThinButton21);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 244);
            this.panel1.TabIndex = 243;
            // 
            // bunifuThinButton21
            // 
            this.bunifuThinButton21.ActiveBorderThickness = 1;
            this.bunifuThinButton21.ActiveCornerRadius = 30;
            this.bunifuThinButton21.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(180)))), ((int)(((byte)(74)))));
            this.bunifuThinButton21.ActiveForecolor = System.Drawing.Color.White;
            this.bunifuThinButton21.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(180)))), ((int)(((byte)(74)))));
            this.bunifuThinButton21.BackColor = System.Drawing.Color.Transparent;
            this.bunifuThinButton21.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuThinButton21.BackgroundImage")));
            this.bunifuThinButton21.ButtonText = "Aceptar";
            this.bunifuThinButton21.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuThinButton21.Font = new System.Drawing.Font("Poppins", 12F);
            this.bunifuThinButton21.ForeColor = System.Drawing.Color.SeaGreen;
            this.bunifuThinButton21.IdleBorderThickness = 1;
            this.bunifuThinButton21.IdleCornerRadius = 30;
            this.bunifuThinButton21.IdleFillColor = System.Drawing.Color.Transparent;
            this.bunifuThinButton21.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(180)))), ((int)(((byte)(74)))));
            this.bunifuThinButton21.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(180)))), ((int)(((byte)(74)))));
            this.bunifuThinButton21.Location = new System.Drawing.Point(97, 182);
            this.bunifuThinButton21.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.bunifuThinButton21.Name = "bunifuThinButton21";
            this.bunifuThinButton21.Size = new System.Drawing.Size(201, 43);
            this.bunifuThinButton21.TabIndex = 241;
            this.bunifuThinButton21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Poppins ExtraLight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(12, 155);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(370, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dato ingresado correctamente con total exito";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Excelente! ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.White;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(128, 8);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(120, 120);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 15;
            this.gunaElipse1.TargetControl = this;
            // 
            // frm_successdialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(415, 272);
            this.Controls.Add(this.tab);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frm_successdialog";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exito";
            this.Load += new System.EventHandler(this.frm_successdialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pn_success.ResumeLayout(false);
            this.tab.ResumeLayout(false);
            this.tabPage_error.ResumeLayout(false);
            this.tabPage_sucess.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.Timer timer1;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_aceptar;
        private System.Windows.Forms.Label lbl_tittle;
        private System.Windows.Forms.Panel pn_success;
        private MaterialSkin.Controls.MaterialTabControl tab;
        private System.Windows.Forms.TabPage tabPage_error;
        private System.Windows.Forms.TabPage tabPage_sucess;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuThinButton2 bunifuThinButton21;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
    }
}