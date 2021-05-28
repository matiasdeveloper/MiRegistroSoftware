
namespace MiRegistro.Views.Common
{
    partial class Dialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dialog));
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.btn_success = new Guna.UI.WinForms.GunaButton();
            this.lbl_success_message = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.gunaAnimateWindow = new Guna.UI.WinForms.GunaAnimateWindow(this.components);
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.gunaDragControl2 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.gunaDragControl3 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.pn_success = new Guna.UI.WinForms.GunaShadowPanel();
            this.pn_fail = new Guna.UI.WinForms.GunaShadowPanel();
            this.btn_error = new Guna.UI.WinForms.GunaButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbl_tittle = new System.Windows.Forms.Label();
            this.lbl_error_message = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pn_success.SuspendLayout();
            this.pn_fail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 15;
            this.gunaElipse1.TargetControl = this;
            // 
            // btn_success
            // 
            this.btn_success.AnimationHoverSpeed = 0.07F;
            this.btn_success.AnimationSpeed = 0.03F;
            this.btn_success.BackColor = System.Drawing.Color.Transparent;
            this.btn_success.BaseColor = System.Drawing.Color.Transparent;
            this.btn_success.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_success.BorderSize = 1;
            this.btn_success.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_success.FocusedColor = System.Drawing.Color.Empty;
            this.btn_success.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_success.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_success.Image = null;
            this.btn_success.ImageSize = new System.Drawing.Size(15, 15);
            this.btn_success.Location = new System.Drawing.Point(114, 224);
            this.btn_success.Name = "btn_success";
            this.btn_success.OnHoverBaseColor = System.Drawing.Color.White;
            this.btn_success.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btn_success.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_success.OnHoverImage = null;
            this.btn_success.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btn_success.Radius = 12;
            this.btn_success.Size = new System.Drawing.Size(200, 29);
            this.btn_success.TabIndex = 284;
            this.btn_success.Text = "Aceptar";
            this.btn_success.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_success.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.AntiAlias;
            // 
            // lbl_success_message
            // 
            this.lbl_success_message.Font = new System.Drawing.Font("Poppins ExtraLight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_success_message.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_success_message.Location = new System.Drawing.Point(26, 163);
            this.lbl_success_message.Name = "lbl_success_message";
            this.lbl_success_message.Size = new System.Drawing.Size(370, 62);
            this.lbl_success_message.TabIndex = 6;
            this.lbl_success_message.Text = "Dato ingresado correctamente\r\nOperacion realizada con exito.";
            this.lbl_success_message.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(66, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(291, 27);
            this.label2.TabIndex = 5;
            this.label2.Text = "Excelente!";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(151, 15);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(120, 120);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // gunaAnimateWindow
            // 
            this.gunaAnimateWindow.AnimationType = Guna.UI.WinForms.GunaAnimateWindow.AnimateWindowType.AW_BLEND;
            this.gunaAnimateWindow.Interval = 100;
            this.gunaAnimateWindow.TargetControl = this;
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = null;
            // 
            // gunaDragControl2
            // 
            this.gunaDragControl2.TargetControl = null;
            // 
            // gunaDragControl3
            // 
            this.gunaDragControl3.TargetControl = this;
            // 
            // pn_success
            // 
            this.pn_success.BackColor = System.Drawing.Color.Transparent;
            this.pn_success.BaseColor = System.Drawing.Color.White;
            this.pn_success.Controls.Add(this.pn_fail);
            this.pn_success.Controls.Add(this.btn_success);
            this.pn_success.Controls.Add(this.lbl_success_message);
            this.pn_success.Controls.Add(this.label2);
            this.pn_success.Controls.Add(this.pictureBox2);
            this.pn_success.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_success.Location = new System.Drawing.Point(0, 0);
            this.pn_success.Name = "pn_success";
            this.pn_success.ShadowColor = System.Drawing.Color.Gray;
            this.pn_success.ShadowDepth = 60;
            this.pn_success.ShadowShift = 2;
            this.pn_success.Size = new System.Drawing.Size(415, 272);
            this.pn_success.TabIndex = 2;
            // 
            // pn_fail
            // 
            this.pn_fail.BackColor = System.Drawing.Color.Transparent;
            this.pn_fail.BaseColor = System.Drawing.Color.White;
            this.pn_fail.Controls.Add(this.btn_error);
            this.pn_fail.Controls.Add(this.pictureBox1);
            this.pn_fail.Controls.Add(this.lbl_tittle);
            this.pn_fail.Controls.Add(this.lbl_error_message);
            this.pn_fail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_fail.Location = new System.Drawing.Point(0, 0);
            this.pn_fail.Name = "pn_fail";
            this.pn_fail.ShadowColor = System.Drawing.Color.Gray;
            this.pn_fail.ShadowDepth = 60;
            this.pn_fail.ShadowShift = 2;
            this.pn_fail.Size = new System.Drawing.Size(415, 272);
            this.pn_fail.TabIndex = 3;
            this.pn_fail.Visible = false;
            // 
            // btn_error
            // 
            this.btn_error.AnimationHoverSpeed = 0.07F;
            this.btn_error.AnimationSpeed = 0.03F;
            this.btn_error.BackColor = System.Drawing.Color.Transparent;
            this.btn_error.BaseColor = System.Drawing.Color.Transparent;
            this.btn_error.BorderColor = System.Drawing.Color.Red;
            this.btn_error.BorderSize = 1;
            this.btn_error.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_error.FocusedColor = System.Drawing.Color.Empty;
            this.btn_error.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_error.ForeColor = System.Drawing.Color.Red;
            this.btn_error.Image = null;
            this.btn_error.ImageSize = new System.Drawing.Size(15, 15);
            this.btn_error.Location = new System.Drawing.Point(114, 225);
            this.btn_error.Name = "btn_error";
            this.btn_error.OnHoverBaseColor = System.Drawing.Color.White;
            this.btn_error.OnHoverBorderColor = System.Drawing.Color.Red;
            this.btn_error.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_error.OnHoverImage = null;
            this.btn_error.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_error.Radius = 12;
            this.btn_error.Size = new System.Drawing.Size(200, 28);
            this.btn_error.TabIndex = 290;
            this.btn_error.Text = "Aceptar";
            this.btn_error.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btn_error.TextRenderingHint = Guna.UI.WinForms.DrawingTextRenderingHint.AntiAlias;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(153, 16);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 120);
            this.pictureBox1.TabIndex = 287;
            this.pictureBox1.TabStop = false;
            // 
            // lbl_tittle
            // 
            this.lbl_tittle.BackColor = System.Drawing.Color.White;
            this.lbl_tittle.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tittle.Location = new System.Drawing.Point(69, 140);
            this.lbl_tittle.Name = "lbl_tittle";
            this.lbl_tittle.Size = new System.Drawing.Size(291, 27);
            this.lbl_tittle.TabIndex = 288;
            this.lbl_tittle.Text = "Lo sentimos!";
            this.lbl_tittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_error_message
            // 
            this.lbl_error_message.BackColor = System.Drawing.Color.White;
            this.lbl_error_message.Font = new System.Drawing.Font("Poppins ExtraLight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_error_message.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lbl_error_message.Location = new System.Drawing.Point(29, 164);
            this.lbl_error_message.Name = "lbl_error_message";
            this.lbl_error_message.Size = new System.Drawing.Size(370, 62);
            this.lbl_error_message.TabIndex = 289;
            this.lbl_error_message.Text = "Excepcion encontrada: Fx124lgd12";
            this.lbl_error_message.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(415, 272);
            this.Controls.Add(this.pn_success);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Dialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dialog";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pn_success.ResumeLayout(false);
            this.pn_fail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        public Guna.UI.WinForms.GunaButton btn_success;
        public Guna.UI.WinForms.GunaAnimateWindow gunaAnimateWindow;
        public System.Windows.Forms.Label lbl_success_message;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl2;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl3;
        public Guna.UI.WinForms.GunaShadowPanel pn_success;
        public Guna.UI.WinForms.GunaButton btn_error;
        public System.Windows.Forms.Label lbl_error_message;
        public System.Windows.Forms.Label lbl_tittle;
        public System.Windows.Forms.PictureBox pictureBox1;
        public Guna.UI.WinForms.GunaShadowPanel pn_fail;
    }
}