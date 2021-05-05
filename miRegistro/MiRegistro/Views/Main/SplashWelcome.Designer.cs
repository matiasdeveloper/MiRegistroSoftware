
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gunaClose = new Guna.UI.WinForms.GunaControlBox();
            this.gunaMinimize = new Guna.UI.WinForms.GunaControlBox();
            this.gunaControlBox1 = new Guna.UI.WinForms.GunaControlBox();
            this.gunaControlBox2 = new Guna.UI.WinForms.GunaControlBox();
            this.btn_next = new Guna.UI.WinForms.GunaGradientButton();
            this.checkbox_terms = new Guna.UI.WinForms.GunaCheckBox();
            this.timersplash = new System.Windows.Forms.Timer(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.sliderpicture = new Guna.UI.WinForms.GunaPictureBox();
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
            this.timerloading.Interval = 45;
            // 
            // progress_bar
            // 
            this.progress_bar.BackColor = System.Drawing.Color.Transparent;
            this.progress_bar.BorderColor = System.Drawing.Color.Black;
            this.progress_bar.ColorStyle = Guna.UI.WinForms.ColorStyle.Default;
            this.progress_bar.IdleColor = System.Drawing.Color.WhiteSmoke;
            this.progress_bar.Location = new System.Drawing.Point(-2, 361);
            this.progress_bar.Name = "progress_bar";
            this.progress_bar.ProgressMaxColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.progress_bar.ProgressMinColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.progress_bar.Size = new System.Drawing.Size(807, 28);
            this.progress_bar.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bienvenido/a";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(29, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ingresando al sistema RNA";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(191, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "El Calafate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkGray;
            this.label4.Location = new System.Drawing.Point(29, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(224, 21);
            this.label4.TabIndex = 4;
            this.label4.Text = "Estas accediendo con privilegios de:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkGray;
            this.label5.Location = new System.Drawing.Point(29, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(244, 26);
            this.label5.TabIndex = 5;
            this.label5.Text = "Administrador";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Poppins Thin", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.label6.Location = new System.Drawing.Point(31, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 26);
            this.label6.TabIndex = 6;
            this.label6.Text = "Cargando sistema . . ";
            // 
            // gunaClose
            // 
            this.gunaClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaClose.AnimationHoverSpeed = 0.07F;
            this.gunaClose.AnimationSpeed = 0.03F;
            this.gunaClose.IconColor = System.Drawing.Color.Black;
            this.gunaClose.IconSize = 15F;
            this.gunaClose.Location = new System.Drawing.Point(718, 8);
            this.gunaClose.Name = "gunaClose";
            this.gunaClose.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.gunaClose.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaClose.OnPressedColor = System.Drawing.Color.Black;
            this.gunaClose.Size = new System.Drawing.Size(24, 22);
            this.gunaClose.TabIndex = 8;
            // 
            // gunaMinimize
            // 
            this.gunaMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaMinimize.AnimationHoverSpeed = 0.07F;
            this.gunaMinimize.AnimationSpeed = 0.03F;
            this.gunaMinimize.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MinimizeBox;
            this.gunaMinimize.IconColor = System.Drawing.Color.Black;
            this.gunaMinimize.IconSize = 15F;
            this.gunaMinimize.Location = new System.Drawing.Point(688, 8);
            this.gunaMinimize.Name = "gunaMinimize";
            this.gunaMinimize.OnHoverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.gunaMinimize.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaMinimize.OnPressedColor = System.Drawing.Color.Black;
            this.gunaMinimize.Size = new System.Drawing.Size(24, 22);
            this.gunaMinimize.TabIndex = 9;
            // 
            // gunaControlBox1
            // 
            this.gunaControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox1.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox1.AnimationSpeed = 0.03F;
            this.gunaControlBox1.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox1.IconSize = 15F;
            this.gunaControlBox1.Location = new System.Drawing.Point(718, 8);
            this.gunaControlBox1.Name = "gunaControlBox1";
            this.gunaControlBox1.OnHoverBackColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox1.Size = new System.Drawing.Size(24, 22);
            this.gunaControlBox1.TabIndex = 8;
            // 
            // gunaControlBox2
            // 
            this.gunaControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaControlBox2.AnimationHoverSpeed = 0.07F;
            this.gunaControlBox2.AnimationSpeed = 0.03F;
            this.gunaControlBox2.ControlBoxType = Guna.UI.WinForms.FormControlBoxType.MinimizeBox;
            this.gunaControlBox2.IconColor = System.Drawing.Color.Black;
            this.gunaControlBox2.IconSize = 15F;
            this.gunaControlBox2.Location = new System.Drawing.Point(688, 8);
            this.gunaControlBox2.Name = "gunaControlBox2";
            this.gunaControlBox2.OnHoverBackColor = System.Drawing.Color.White;
            this.gunaControlBox2.OnHoverIconColor = System.Drawing.Color.White;
            this.gunaControlBox2.OnPressedColor = System.Drawing.Color.Black;
            this.gunaControlBox2.Size = new System.Drawing.Size(24, 22);
            this.gunaControlBox2.TabIndex = 9;
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
            this.btn_next.ImageSize = new System.Drawing.Size(0, 0);
            this.btn_next.Location = new System.Drawing.Point(39, 287);
            this.btn_next.Name = "btn_next";
            this.btn_next.OnHoverBaseColor1 = System.Drawing.Color.CornflowerBlue;
            this.btn_next.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_next.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btn_next.OnHoverForeColor = System.Drawing.Color.WhiteSmoke;
            this.btn_next.OnHoverImage = null;
            this.btn_next.OnPressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_next.Radius = 17;
            this.btn_next.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_next.Size = new System.Drawing.Size(272, 38);
            this.btn_next.TabIndex = 256;
            this.btn_next.Text = "Continuar a MiRegistro";
            this.btn_next.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkbox_terms
            // 
            this.checkbox_terms.BaseColor = System.Drawing.Color.White;
            this.checkbox_terms.CheckedOffColor = System.Drawing.Color.Gray;
            this.checkbox_terms.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.checkbox_terms.FillColor = System.Drawing.Color.White;
            this.checkbox_terms.Font = new System.Drawing.Font("Poppins", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkbox_terms.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkbox_terms.Location = new System.Drawing.Point(37, 260);
            this.checkbox_terms.Name = "checkbox_terms";
            this.checkbox_terms.Size = new System.Drawing.Size(247, 20);
            this.checkbox_terms.TabIndex = 258;
            this.checkbox_terms.Text = "Aceptas los terminos y condiciones de servicio.";
            // 
            // timersplash
            // 
            this.timersplash.Enabled = true;
            this.timersplash.Interval = 2500;
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
            // sliderpicture
            // 
            this.sliderpicture.BackgroundImage = global::MiRegistro.Properties.Resources.splash_glaciar;
            this.sliderpicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.sliderpicture.BaseColor = System.Drawing.Color.White;
            this.sliderpicture.Location = new System.Drawing.Point(329, -4);
            this.sliderpicture.Name = "sliderpicture";
            this.sliderpicture.Size = new System.Drawing.Size(427, 364);
            this.sliderpicture.TabIndex = 259;
            this.sliderpicture.TabStop = false;
            // 
            // SplashWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(755, 372);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.checkbox_terms);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.gunaControlBox2);
            this.Controls.Add(this.gunaControlBox1);
            this.Controls.Add(this.gunaMinimize);
            this.Controls.Add(this.gunaClose);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progress_bar);
            this.Controls.Add(this.sliderpicture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SplashWelcome";
            this.Text = "SplashWelcome";
            ((System.ComponentModel.ISupportInitialize)(this.sliderpicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private Guna.UI.WinForms.GunaControlBox gunaClose;
        private Guna.UI.WinForms.GunaControlBox gunaMinimize;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox2;
        private Guna.UI.WinForms.GunaControlBox gunaControlBox1;
        public Guna.UI.WinForms.GunaCheckBox checkbox_terms;
        public System.Windows.Forms.Timer timersplash;
        public Guna.UI.WinForms.GunaProgressBar progress_bar;
        public Guna.UI.WinForms.GunaGradientButton btn_next;
        public System.Windows.Forms.Timer timerloading;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label8;
        public Guna.UI.WinForms.GunaPictureBox sliderpicture;
    }
}