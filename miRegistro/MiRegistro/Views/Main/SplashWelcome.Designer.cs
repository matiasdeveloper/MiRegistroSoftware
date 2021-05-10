
namespace MiRegistro.Views.Main
{
    partial class SplashWelcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SplashWelcome));
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.timerloading = new System.Windows.Forms.Timer(this.components);
            this.progress_bar = new Guna.UI.WinForms.GunaProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_companyname = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_loading = new System.Windows.Forms.Label();
            this.checkbox_terms = new Guna.UI.WinForms.GunaCheckBox();
            this.timerslider = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.sliderpicture = new Guna.UI.WinForms.GunaPictureBox();
            this.lbl_privileges = new System.Windows.Forms.Label();
            this.lbl_nick = new System.Windows.Forms.Label();
            this.btn_next = new Guna.UI.WinForms.GunaGradientButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sliderpicture)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 10;
            this.gunaElipse1.TargetControl = this;
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = null;
            // 
            // timerloading
            // 
            this.timerloading.Enabled = true;
            this.timerloading.Interval = 65;
            // 
            // progress_bar
            // 
            this.progress_bar.BackColor = System.Drawing.Color.Transparent;
            this.progress_bar.BorderColor = System.Drawing.Color.Black;
            this.progress_bar.ColorStyle = Guna.UI.WinForms.ColorStyle.Default;
            this.progress_bar.IdleColor = System.Drawing.Color.WhiteSmoke;
            this.progress_bar.Location = new System.Drawing.Point(-7, 364);
            this.progress_bar.Name = "progress_bar";
            this.progress_bar.ProgressMaxColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.progress_bar.ProgressMinColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.progress_bar.Size = new System.Drawing.Size(353, 28);
            this.progress_bar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(32, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bienvenido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(32, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ingresando al sistema RNA";
            // 
            // lbl_companyname
            // 
            this.lbl_companyname.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_companyname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_companyname.Location = new System.Drawing.Point(192, 84);
            this.lbl_companyname.Name = "lbl_companyname";
            this.lbl_companyname.Size = new System.Drawing.Size(145, 26);
            this.lbl_companyname.TabIndex = 3;
            this.lbl_companyname.Text = "My Company";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(32, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Estas accediendo con privilegios de:";
            // 
            // lbl_loading
            // 
            this.lbl_loading.Font = new System.Drawing.Font("Poppins Thin", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_loading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.lbl_loading.Location = new System.Drawing.Point(32, 150);
            this.lbl_loading.Name = "lbl_loading";
            this.lbl_loading.Size = new System.Drawing.Size(165, 26);
            this.lbl_loading.TabIndex = 6;
            this.lbl_loading.Text = "Cargando sistema . . ";
            // 
            // checkbox_terms
            // 
            this.checkbox_terms.BaseColor = System.Drawing.Color.White;
            this.checkbox_terms.Checked = true;
            this.checkbox_terms.CheckedOffColor = System.Drawing.Color.Gray;
            this.checkbox_terms.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.checkbox_terms.Enabled = false;
            this.checkbox_terms.FillColor = System.Drawing.Color.White;
            this.checkbox_terms.Font = new System.Drawing.Font("Poppins", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkbox_terms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkbox_terms.Location = new System.Drawing.Point(32, 264);
            this.checkbox_terms.Name = "checkbox_terms";
            this.checkbox_terms.Size = new System.Drawing.Size(247, 20);
            this.checkbox_terms.TabIndex = 258;
            this.checkbox_terms.Text = "Aceptas los terminos y condiciones de servicio.";
            // 
            // timerslider
            // 
            this.timerslider.Enabled = true;
            this.timerslider.Interval = 2500;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(78)))), ((int)(((byte)(81)))));
            this.label7.Location = new System.Drawing.Point(33, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 24);
            this.label7.TabIndex = 260;
            this.label7.Text = "Registro";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.label8.Location = new System.Drawing.Point(14, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 21);
            this.label8.TabIndex = 261;
            this.label8.Text = "Mi";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.sliderpicture);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(346, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 372);
            this.panel1.TabIndex = 262;
            // 
            // sliderpicture
            // 
            this.sliderpicture.BackgroundImage = global::MiRegistro.Properties.Resources.splash3;
            this.sliderpicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sliderpicture.BaseColor = System.Drawing.Color.White;
            this.sliderpicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sliderpicture.Location = new System.Drawing.Point(0, 0);
            this.sliderpicture.Name = "sliderpicture";
            this.sliderpicture.Size = new System.Drawing.Size(409, 372);
            this.sliderpicture.TabIndex = 259;
            this.sliderpicture.TabStop = false;
            // 
            // lbl_privileges
            // 
            this.lbl_privileges.Font = new System.Drawing.Font("Poppins ExtraLight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_privileges.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.lbl_privileges.Location = new System.Drawing.Point(32, 127);
            this.lbl_privileges.Name = "lbl_privileges";
            this.lbl_privileges.Size = new System.Drawing.Size(305, 26);
            this.lbl_privileges.TabIndex = 5;
            this.lbl_privileges.Text = "My Privileges (MAX 48)";
            // 
            // lbl_nick
            // 
            this.lbl_nick.Font = new System.Drawing.Font("Poppins Thin", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nick.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.lbl_nick.Location = new System.Drawing.Point(154, 58);
            this.lbl_nick.Name = "lbl_nick";
            this.lbl_nick.Size = new System.Drawing.Size(102, 18);
            this.lbl_nick.TabIndex = 263;
            this.lbl_nick.Text = "My nick";
            // 
            // btn_next
            // 
            this.btn_next.AnimationHoverSpeed = 0.07F;
            this.btn_next.AnimationSpeed = 0.03F;
            this.btn_next.BackColor = System.Drawing.Color.Transparent;
            this.btn_next.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_next.BaseColor2 = System.Drawing.Color.CornflowerBlue;
            this.btn_next.BorderColor = System.Drawing.Color.Black;
            this.btn_next.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_next.Enabled = false;
            this.btn_next.FocusedColor = System.Drawing.Color.Empty;
            this.btn_next.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_next.ForeColor = System.Drawing.Color.White;
            this.btn_next.Image = ((System.Drawing.Image)(resources.GetObject("btn_next.Image")));
            this.btn_next.ImageAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btn_next.ImageSize = new System.Drawing.Size(0, 0);
            this.btn_next.Location = new System.Drawing.Point(34, 290);
            this.btn_next.Name = "btn_next";
            this.btn_next.OnHoverBaseColor1 = System.Drawing.Color.CornflowerBlue;
            this.btn_next.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_next.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_next.OnHoverForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_next.OnHoverImage = null;
            this.btn_next.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_next.Radius = 17;
            this.btn_next.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_next.Size = new System.Drawing.Size(266, 38);
            this.btn_next.TabIndex = 256;
            this.btn_next.Text = "Continuar a MiRegistro";
            this.btn_next.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SplashWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(755, 372);
            this.Controls.Add(this.lbl_nick);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.checkbox_terms);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.lbl_loading);
            this.Controls.Add(this.lbl_privileges);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbl_companyname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.progress_bar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashWelcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashWelcome";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sliderpicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
        private System.Windows.Forms.Label label1;
        public Guna.UI.WinForms.GunaCheckBox checkbox_terms;
        public System.Windows.Forms.Timer timerslider;
        public Guna.UI.WinForms.GunaProgressBar progress_bar;
        public Guna.UI.WinForms.GunaGradientButton btn_next;
        public System.Windows.Forms.Timer timerloading;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label8;
        public Guna.UI.WinForms.GunaPictureBox sliderpicture;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label lbl_companyname;
        public System.Windows.Forms.Label lbl_loading;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label lbl_privileges;
        public System.Windows.Forms.Label lbl_nick;
    }
}