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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pn_success.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(127, 8);
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
            this.lbl_info.Location = new System.Drawing.Point(2, 155);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(370, 29);
            this.lbl_info.TabIndex = 3;
            this.lbl_info.Text = "Dato ingresado correctamente con total exito";
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
            this.btn_aceptar.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(180)))), ((int)(((byte)(74)))));
            this.btn_aceptar.ActiveForecolor = System.Drawing.Color.White;
            this.btn_aceptar.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(180)))), ((int)(((byte)(74)))));
            this.btn_aceptar.BackColor = System.Drawing.Color.White;
            this.btn_aceptar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_aceptar.BackgroundImage")));
            this.btn_aceptar.ButtonText = "Aceptar";
            this.btn_aceptar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_aceptar.Font = new System.Drawing.Font("Poppins", 12F);
            this.btn_aceptar.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_aceptar.IdleBorderThickness = 1;
            this.btn_aceptar.IdleCornerRadius = 30;
            this.btn_aceptar.IdleFillColor = System.Drawing.Color.Transparent;
            this.btn_aceptar.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(180)))), ((int)(((byte)(74)))));
            this.btn_aceptar.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(180)))), ((int)(((byte)(74)))));
            this.btn_aceptar.Location = new System.Drawing.Point(87, 182);
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
            this.lbl_tittle.Location = new System.Drawing.Point(40, 132);
            this.lbl_tittle.Name = "lbl_tittle";
            this.lbl_tittle.Size = new System.Drawing.Size(291, 27);
            this.lbl_tittle.TabIndex = 2;
            this.lbl_tittle.Text = "Excelente! ";
            this.lbl_tittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pn_success
            // 
            this.pn_success.Controls.Add(this.btn_aceptar);
            this.pn_success.Controls.Add(this.lbl_info);
            this.pn_success.Controls.Add(this.lbl_tittle);
            this.pn_success.Controls.Add(this.pictureBox1);
            this.pn_success.Location = new System.Drawing.Point(15, 13);
            this.pn_success.Name = "pn_success";
            this.pn_success.Size = new System.Drawing.Size(379, 248);
            this.pn_success.TabIndex = 242;
            // 
            // frm_successdialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(415, 272);
            this.Controls.Add(this.pn_success);
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
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.Timer timer1;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_aceptar;
        private System.Windows.Forms.Label lbl_tittle;
        private System.Windows.Forms.Panel pn_success;
    }
}