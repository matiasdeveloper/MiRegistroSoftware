
namespace MiRegistro.Views.Main
{
    partial class Main
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
            Guna.UI.Animation.Animation animation3 = new Guna.UI.Animation.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.pn_tittle = new System.Windows.Forms.Panel();
            this.lbl_nombre = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.btn_account = new Guna.UI.WinForms.GunaImageButton();
            this.btn_moreoptions = new Guna.UI.WinForms.GunaImageButton();
            this.gunaElipse1 = new Guna.UI.WinForms.GunaElipse(this.components);
            this.pn_sidebar = new System.Windows.Forms.Panel();
            this.btn_configuracion = new Guna.UI.WinForms.GunaAdvenceButton();
            this.btn_logout = new Guna.UI.WinForms.GunaAdvenceButton();
            this.gunaSeparator2 = new Guna.UI.WinForms.GunaSeparator();
            this.gunaSeparator1 = new Guna.UI.WinForms.GunaSeparator();
            this.btn_estadisticas = new Guna.UI.WinForms.GunaAdvenceButton();
            this.btn_empleados = new Guna.UI.WinForms.GunaAdvenceButton();
            this.btn_formularios = new Guna.UI.WinForms.GunaAdvenceButton();
            this.btn_tramites = new Guna.UI.WinForms.GunaAdvenceButton();
            this.btn_dashboard = new Guna.UI.WinForms.GunaAdvenceButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_lastacess = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pn_contenedor = new System.Windows.Forms.Panel();
            this.pn_moreoptions = new Guna.UI.WinForms.GunaShadowPanel();
            this.gunaSeparator5 = new Guna.UI.WinForms.GunaSeparator();
            this.gunaSeparator4 = new Guna.UI.WinForms.GunaSeparator();
            this.gunaSeparator3 = new Guna.UI.WinForms.GunaSeparator();
            this.btn_more_closesystem = new Guna.UI.WinForms.GunaAdvenceButton();
            this.btn_more_configuracion = new Guna.UI.WinForms.GunaAdvenceButton();
            this.gunaAdvenceButton8 = new Guna.UI.WinForms.GunaAdvenceButton();
            this.gunaAdvenceButton7 = new Guna.UI.WinForms.GunaAdvenceButton();
            this.gunaTransitionVertical = new Guna.UI.WinForms.GunaTransition(this.components);
            this.pn_tittle.SuspendLayout();
            this.pn_sidebar.SuspendLayout();
            this.pn_moreoptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = this.pn_tittle;
            // 
            // pn_tittle
            // 
            this.pn_tittle.BackColor = System.Drawing.Color.White;
            this.pn_tittle.Controls.Add(this.lbl_nombre);
            this.pn_tittle.Controls.Add(this.lbl_email);
            this.pn_tittle.Controls.Add(this.btn_account);
            this.pn_tittle.Controls.Add(this.btn_moreoptions);
            this.gunaTransitionVertical.SetDecoration(this.pn_tittle, Guna.UI.Animation.DecorationType.None);
            this.pn_tittle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_tittle.Location = new System.Drawing.Point(195, 0);
            this.pn_tittle.Margin = new System.Windows.Forms.Padding(2);
            this.pn_tittle.Name = "pn_tittle";
            this.pn_tittle.Size = new System.Drawing.Size(1005, 39);
            this.pn_tittle.TabIndex = 14;
            // 
            // lbl_nombre
            // 
            this.lbl_nombre.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransitionVertical.SetDecoration(this.lbl_nombre, Guna.UI.Animation.DecorationType.None);
            this.lbl_nombre.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nombre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_nombre.Location = new System.Drawing.Point(793, 4);
            this.lbl_nombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_nombre.Name = "lbl_nombre";
            this.lbl_nombre.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_nombre.Size = new System.Drawing.Size(164, 19);
            this.lbl_nombre.TabIndex = 0;
            this.lbl_nombre.Text = "Nombre y Apellido";
            // 
            // lbl_email
            // 
            this.lbl_email.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransitionVertical.SetDecoration(this.lbl_email, Guna.UI.Animation.DecorationType.None);
            this.lbl_email.Font = new System.Drawing.Font("Poppins", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_email.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_email.Location = new System.Drawing.Point(794, 21);
            this.lbl_email.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_email.Size = new System.Drawing.Size(142, 16);
            this.lbl_email.TabIndex = 1;
            this.lbl_email.Text = "Administrador";
            // 
            // btn_account
            // 
            this.gunaTransitionVertical.SetDecoration(this.btn_account, Guna.UI.Animation.DecorationType.None);
            this.btn_account.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_account.Image = global::MiRegistro.Properties.Resources.male_user_100px;
            this.btn_account.ImageSize = new System.Drawing.Size(30, 30);
            this.btn_account.Location = new System.Drawing.Point(756, 3);
            this.btn_account.Name = "btn_account";
            this.btn_account.OnHoverImage = null;
            this.btn_account.OnHoverImageOffset = new System.Drawing.Point(0, 0);
            this.btn_account.Size = new System.Drawing.Size(37, 30);
            this.btn_account.TabIndex = 1;
            // 
            // btn_moreoptions
            // 
            this.gunaTransitionVertical.SetDecoration(this.btn_moreoptions, Guna.UI.Animation.DecorationType.None);
            this.btn_moreoptions.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_moreoptions.Image = global::MiRegistro.Properties.Resources.icon_slidedown_1;
            this.btn_moreoptions.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_moreoptions.Location = new System.Drawing.Point(966, 6);
            this.btn_moreoptions.Name = "btn_moreoptions";
            this.btn_moreoptions.OnHoverImage = null;
            this.btn_moreoptions.OnHoverImageOffset = new System.Drawing.Point(0, 0);
            this.btn_moreoptions.Size = new System.Drawing.Size(29, 26);
            this.btn_moreoptions.TabIndex = 2;
            // 
            // gunaElipse1
            // 
            this.gunaElipse1.Radius = 10;
            this.gunaElipse1.TargetControl = this;
            // 
            // pn_sidebar
            // 
            this.pn_sidebar.BackColor = System.Drawing.Color.White;
            this.pn_sidebar.Controls.Add(this.btn_configuracion);
            this.pn_sidebar.Controls.Add(this.btn_logout);
            this.pn_sidebar.Controls.Add(this.gunaSeparator2);
            this.pn_sidebar.Controls.Add(this.gunaSeparator1);
            this.pn_sidebar.Controls.Add(this.btn_estadisticas);
            this.pn_sidebar.Controls.Add(this.btn_empleados);
            this.pn_sidebar.Controls.Add(this.btn_formularios);
            this.pn_sidebar.Controls.Add(this.btn_tramites);
            this.pn_sidebar.Controls.Add(this.btn_dashboard);
            this.pn_sidebar.Controls.Add(this.label5);
            this.pn_sidebar.Controls.Add(this.label4);
            this.pn_sidebar.Controls.Add(this.label2);
            this.pn_sidebar.Controls.Add(this.label1);
            this.pn_sidebar.Controls.Add(this.lbl_lastacess);
            this.pn_sidebar.Controls.Add(this.label3);
            this.gunaTransitionVertical.SetDecoration(this.pn_sidebar, Guna.UI.Animation.DecorationType.None);
            this.pn_sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pn_sidebar.Location = new System.Drawing.Point(0, 0);
            this.pn_sidebar.Name = "pn_sidebar";
            this.pn_sidebar.Size = new System.Drawing.Size(195, 718);
            this.pn_sidebar.TabIndex = 13;
            // 
            // btn_configuracion
            // 
            this.btn_configuracion.AnimationHoverSpeed = 0.07F;
            this.btn_configuracion.AnimationSpeed = 0.03F;
            this.btn_configuracion.BackColor = System.Drawing.Color.Transparent;
            this.btn_configuracion.BaseColor = System.Drawing.Color.White;
            this.btn_configuracion.BorderColor = System.Drawing.Color.White;
            this.btn_configuracion.CheckedBaseColor = System.Drawing.Color.White;
            this.btn_configuracion.CheckedBorderColor = System.Drawing.Color.White;
            this.btn_configuracion.CheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_configuracion.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btn_configuracion.CheckedImage")));
            this.btn_configuracion.CheckedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.gunaTransitionVertical.SetDecoration(this.btn_configuracion, Guna.UI.Animation.DecorationType.None);
            this.btn_configuracion.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_configuracion.FocusedColor = System.Drawing.Color.Empty;
            this.btn_configuracion.Font = new System.Drawing.Font("Poppins SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_configuracion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.btn_configuracion.Image = ((System.Drawing.Image)(resources.GetObject("btn_configuracion.Image")));
            this.btn_configuracion.ImageOffsetX = 5;
            this.btn_configuracion.ImageSize = new System.Drawing.Size(20, 20);
            this.btn_configuracion.LineColor = System.Drawing.Color.White;
            this.btn_configuracion.LineRight = 4;
            this.btn_configuracion.Location = new System.Drawing.Point(0, 585);
            this.btn_configuracion.Name = "btn_configuracion";
            this.btn_configuracion.OnHoverBaseColor = System.Drawing.Color.White;
            this.btn_configuracion.OnHoverBorderColor = System.Drawing.Color.White;
            this.btn_configuracion.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_configuracion.OnHoverImage = null;
            this.btn_configuracion.OnHoverLineColor = System.Drawing.Color.White;
            this.btn_configuracion.OnPressedColor = System.Drawing.Color.White;
            this.btn_configuracion.Radius = 3;
            this.btn_configuracion.Size = new System.Drawing.Size(192, 42);
            this.btn_configuracion.TabIndex = 219;
            this.btn_configuracion.Text = "Configuraciones";
            this.btn_configuracion.TextOffsetX = 4;
            this.btn_configuracion.Click += new System.EventHandler(this.gunaAdvenceButton6_Click);
            // 
            // btn_logout
            // 
            this.btn_logout.AnimationHoverSpeed = 0.07F;
            this.btn_logout.AnimationSpeed = 0.03F;
            this.btn_logout.BackColor = System.Drawing.Color.Transparent;
            this.btn_logout.BaseColor = System.Drawing.Color.White;
            this.btn_logout.BorderColor = System.Drawing.Color.White;
            this.btn_logout.CheckedBaseColor = System.Drawing.Color.White;
            this.btn_logout.CheckedBorderColor = System.Drawing.Color.White;
            this.btn_logout.CheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_logout.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btn_logout.CheckedImage")));
            this.btn_logout.CheckedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.gunaTransitionVertical.SetDecoration(this.btn_logout, Guna.UI.Animation.DecorationType.None);
            this.btn_logout.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_logout.FocusedColor = System.Drawing.Color.Empty;
            this.btn_logout.Font = new System.Drawing.Font("Poppins SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_logout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.btn_logout.Image = ((System.Drawing.Image)(resources.GetObject("btn_logout.Image")));
            this.btn_logout.ImageOffsetX = 7;
            this.btn_logout.ImageSize = new System.Drawing.Size(14, 14);
            this.btn_logout.LineColor = System.Drawing.Color.White;
            this.btn_logout.LineRight = 4;
            this.btn_logout.Location = new System.Drawing.Point(0, 629);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.OnHoverBaseColor = System.Drawing.Color.White;
            this.btn_logout.OnHoverBorderColor = System.Drawing.Color.White;
            this.btn_logout.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_logout.OnHoverImage = null;
            this.btn_logout.OnHoverLineColor = System.Drawing.Color.White;
            this.btn_logout.OnPressedColor = System.Drawing.Color.White;
            this.btn_logout.Radius = 3;
            this.btn_logout.Size = new System.Drawing.Size(192, 42);
            this.btn_logout.TabIndex = 218;
            this.btn_logout.Text = "Cerrar sesion";
            this.btn_logout.TextOffsetX = 7;
            this.btn_logout.Click += new System.EventHandler(this.gunaAdvenceButton5_Click);
            // 
            // gunaSeparator2
            // 
            this.gunaTransitionVertical.SetDecoration(this.gunaSeparator2, Guna.UI.Animation.DecorationType.None);
            this.gunaSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.gunaSeparator2.Location = new System.Drawing.Point(0, 572);
            this.gunaSeparator2.Name = "gunaSeparator2";
            this.gunaSeparator2.Size = new System.Drawing.Size(195, 10);
            this.gunaSeparator2.TabIndex = 217;
            // 
            // gunaSeparator1
            // 
            this.gunaTransitionVertical.SetDecoration(this.gunaSeparator1, Guna.UI.Animation.DecorationType.None);
            this.gunaSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.gunaSeparator1.Location = new System.Drawing.Point(0, 294);
            this.gunaSeparator1.Name = "gunaSeparator1";
            this.gunaSeparator1.Size = new System.Drawing.Size(195, 10);
            this.gunaSeparator1.TabIndex = 14;
            // 
            // btn_estadisticas
            // 
            this.btn_estadisticas.AnimationHoverSpeed = 0.07F;
            this.btn_estadisticas.AnimationSpeed = 0.03F;
            this.btn_estadisticas.BackColor = System.Drawing.Color.Transparent;
            this.btn_estadisticas.BaseColor = System.Drawing.Color.White;
            this.btn_estadisticas.BorderColor = System.Drawing.Color.White;
            this.btn_estadisticas.CheckedBaseColor = System.Drawing.Color.White;
            this.btn_estadisticas.CheckedBorderColor = System.Drawing.Color.White;
            this.btn_estadisticas.CheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_estadisticas.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btn_estadisticas.CheckedImage")));
            this.btn_estadisticas.CheckedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.gunaTransitionVertical.SetDecoration(this.btn_estadisticas, Guna.UI.Animation.DecorationType.None);
            this.btn_estadisticas.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_estadisticas.FocusedColor = System.Drawing.Color.Empty;
            this.btn_estadisticas.Font = new System.Drawing.Font("Poppins SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_estadisticas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.btn_estadisticas.Image = ((System.Drawing.Image)(resources.GetObject("btn_estadisticas.Image")));
            this.btn_estadisticas.ImageOffsetX = 5;
            this.btn_estadisticas.ImageSize = new System.Drawing.Size(15, 15);
            this.btn_estadisticas.LineColor = System.Drawing.Color.White;
            this.btn_estadisticas.LineRight = 4;
            this.btn_estadisticas.Location = new System.Drawing.Point(3, 245);
            this.btn_estadisticas.Name = "btn_estadisticas";
            this.btn_estadisticas.OnHoverBaseColor = System.Drawing.Color.White;
            this.btn_estadisticas.OnHoverBorderColor = System.Drawing.Color.White;
            this.btn_estadisticas.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_estadisticas.OnHoverImage = null;
            this.btn_estadisticas.OnHoverLineColor = System.Drawing.Color.White;
            this.btn_estadisticas.OnPressedColor = System.Drawing.Color.White;
            this.btn_estadisticas.Radius = 3;
            this.btn_estadisticas.Size = new System.Drawing.Size(192, 42);
            this.btn_estadisticas.TabIndex = 216;
            this.btn_estadisticas.Text = "Estadisticas";
            this.btn_estadisticas.TextOffsetX = 6;
            this.btn_estadisticas.Click += new System.EventHandler(this.btn_estadisticas_Click);
            // 
            // btn_empleados
            // 
            this.btn_empleados.AnimationHoverSpeed = 0.07F;
            this.btn_empleados.AnimationSpeed = 0.03F;
            this.btn_empleados.BackColor = System.Drawing.Color.Transparent;
            this.btn_empleados.BaseColor = System.Drawing.Color.White;
            this.btn_empleados.BorderColor = System.Drawing.Color.White;
            this.btn_empleados.CheckedBaseColor = System.Drawing.Color.White;
            this.btn_empleados.CheckedBorderColor = System.Drawing.Color.White;
            this.btn_empleados.CheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_empleados.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btn_empleados.CheckedImage")));
            this.btn_empleados.CheckedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.gunaTransitionVertical.SetDecoration(this.btn_empleados, Guna.UI.Animation.DecorationType.None);
            this.btn_empleados.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_empleados.FocusedColor = System.Drawing.Color.Empty;
            this.btn_empleados.Font = new System.Drawing.Font("Poppins SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_empleados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.btn_empleados.Image = ((System.Drawing.Image)(resources.GetObject("btn_empleados.Image")));
            this.btn_empleados.ImageOffsetX = 5;
            this.btn_empleados.ImageSize = new System.Drawing.Size(17, 17);
            this.btn_empleados.LineColor = System.Drawing.Color.White;
            this.btn_empleados.LineRight = 4;
            this.btn_empleados.Location = new System.Drawing.Point(3, 197);
            this.btn_empleados.Name = "btn_empleados";
            this.btn_empleados.OnHoverBaseColor = System.Drawing.Color.White;
            this.btn_empleados.OnHoverBorderColor = System.Drawing.Color.White;
            this.btn_empleados.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_empleados.OnHoverImage = null;
            this.btn_empleados.OnHoverLineColor = System.Drawing.Color.White;
            this.btn_empleados.OnPressedColor = System.Drawing.Color.White;
            this.btn_empleados.Radius = 3;
            this.btn_empleados.Size = new System.Drawing.Size(192, 42);
            this.btn_empleados.TabIndex = 215;
            this.btn_empleados.Text = "Empleados";
            this.btn_empleados.TextOffsetX = 6;
            this.btn_empleados.Click += new System.EventHandler(this.btn_empleados_Click);
            // 
            // btn_formularios
            // 
            this.btn_formularios.AnimationHoverSpeed = 0.07F;
            this.btn_formularios.AnimationSpeed = 0.03F;
            this.btn_formularios.BackColor = System.Drawing.Color.Transparent;
            this.btn_formularios.BaseColor = System.Drawing.Color.White;
            this.btn_formularios.BorderColor = System.Drawing.Color.White;
            this.btn_formularios.CheckedBaseColor = System.Drawing.Color.White;
            this.btn_formularios.CheckedBorderColor = System.Drawing.Color.White;
            this.btn_formularios.CheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_formularios.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btn_formularios.CheckedImage")));
            this.btn_formularios.CheckedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.gunaTransitionVertical.SetDecoration(this.btn_formularios, Guna.UI.Animation.DecorationType.None);
            this.btn_formularios.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_formularios.FocusedColor = System.Drawing.Color.Empty;
            this.btn_formularios.Font = new System.Drawing.Font("Poppins SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_formularios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.btn_formularios.Image = ((System.Drawing.Image)(resources.GetObject("btn_formularios.Image")));
            this.btn_formularios.ImageOffsetX = 5;
            this.btn_formularios.ImageSize = new System.Drawing.Size(15, 15);
            this.btn_formularios.LineColor = System.Drawing.Color.White;
            this.btn_formularios.LineRight = 4;
            this.btn_formularios.Location = new System.Drawing.Point(3, 149);
            this.btn_formularios.Name = "btn_formularios";
            this.btn_formularios.OnHoverBaseColor = System.Drawing.Color.White;
            this.btn_formularios.OnHoverBorderColor = System.Drawing.Color.White;
            this.btn_formularios.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_formularios.OnHoverImage = null;
            this.btn_formularios.OnHoverLineColor = System.Drawing.Color.White;
            this.btn_formularios.OnPressedColor = System.Drawing.Color.White;
            this.btn_formularios.Radius = 3;
            this.btn_formularios.Size = new System.Drawing.Size(192, 42);
            this.btn_formularios.TabIndex = 214;
            this.btn_formularios.Text = "Formularios";
            this.btn_formularios.TextOffsetX = 6;
            this.btn_formularios.Click += new System.EventHandler(this.btn_formularios_Click);
            // 
            // btn_tramites
            // 
            this.btn_tramites.AnimationHoverSpeed = 0.07F;
            this.btn_tramites.AnimationSpeed = 0.03F;
            this.btn_tramites.BackColor = System.Drawing.Color.Transparent;
            this.btn_tramites.BaseColor = System.Drawing.Color.White;
            this.btn_tramites.BorderColor = System.Drawing.Color.White;
            this.btn_tramites.CheckedBaseColor = System.Drawing.Color.White;
            this.btn_tramites.CheckedBorderColor = System.Drawing.Color.White;
            this.btn_tramites.CheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_tramites.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btn_tramites.CheckedImage")));
            this.btn_tramites.CheckedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.gunaTransitionVertical.SetDecoration(this.btn_tramites, Guna.UI.Animation.DecorationType.None);
            this.btn_tramites.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_tramites.FocusedColor = System.Drawing.Color.Empty;
            this.btn_tramites.Font = new System.Drawing.Font("Poppins SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_tramites.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.btn_tramites.Image = ((System.Drawing.Image)(resources.GetObject("btn_tramites.Image")));
            this.btn_tramites.ImageOffsetX = 6;
            this.btn_tramites.ImageSize = new System.Drawing.Size(15, 15);
            this.btn_tramites.LineColor = System.Drawing.Color.White;
            this.btn_tramites.LineRight = 4;
            this.btn_tramites.Location = new System.Drawing.Point(3, 101);
            this.btn_tramites.Name = "btn_tramites";
            this.btn_tramites.OnHoverBaseColor = System.Drawing.Color.White;
            this.btn_tramites.OnHoverBorderColor = System.Drawing.Color.White;
            this.btn_tramites.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_tramites.OnHoverImage = null;
            this.btn_tramites.OnHoverLineColor = System.Drawing.Color.White;
            this.btn_tramites.OnPressedColor = System.Drawing.Color.White;
            this.btn_tramites.Radius = 3;
            this.btn_tramites.Size = new System.Drawing.Size(192, 42);
            this.btn_tramites.TabIndex = 213;
            this.btn_tramites.Text = "Tramites";
            this.btn_tramites.TextOffsetX = 6;
            this.btn_tramites.Click += new System.EventHandler(this.btn_tramites_Click);
            // 
            // btn_dashboard
            // 
            this.btn_dashboard.AnimationHoverSpeed = 0.07F;
            this.btn_dashboard.AnimationSpeed = 0.03F;
            this.btn_dashboard.BackColor = System.Drawing.Color.Transparent;
            this.btn_dashboard.BaseColor = System.Drawing.Color.White;
            this.btn_dashboard.BorderColor = System.Drawing.Color.White;
            this.btn_dashboard.CheckedBaseColor = System.Drawing.Color.White;
            this.btn_dashboard.CheckedBorderColor = System.Drawing.Color.White;
            this.btn_dashboard.CheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_dashboard.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btn_dashboard.CheckedImage")));
            this.btn_dashboard.CheckedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.gunaTransitionVertical.SetDecoration(this.btn_dashboard, Guna.UI.Animation.DecorationType.None);
            this.btn_dashboard.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_dashboard.FocusedColor = System.Drawing.Color.Empty;
            this.btn_dashboard.Font = new System.Drawing.Font("Poppins SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dashboard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.btn_dashboard.Image = ((System.Drawing.Image)(resources.GetObject("btn_dashboard.Image")));
            this.btn_dashboard.ImageOffsetX = 5;
            this.btn_dashboard.ImageSize = new System.Drawing.Size(19, 19);
            this.btn_dashboard.LineColor = System.Drawing.Color.White;
            this.btn_dashboard.LineRight = 4;
            this.btn_dashboard.Location = new System.Drawing.Point(3, 53);
            this.btn_dashboard.Name = "btn_dashboard";
            this.btn_dashboard.OnHoverBaseColor = System.Drawing.Color.White;
            this.btn_dashboard.OnHoverBorderColor = System.Drawing.Color.White;
            this.btn_dashboard.OnHoverForeColor = System.Drawing.Color.Black;
            this.btn_dashboard.OnHoverImage = null;
            this.btn_dashboard.OnHoverLineColor = System.Drawing.Color.White;
            this.btn_dashboard.OnPressedColor = System.Drawing.Color.White;
            this.btn_dashboard.Radius = 3;
            this.btn_dashboard.Size = new System.Drawing.Size(192, 42);
            this.btn_dashboard.TabIndex = 15;
            this.btn_dashboard.Text = "Escritorio";
            this.btn_dashboard.TextOffsetX = 6;
            this.btn_dashboard.Click += new System.EventHandler(this.btn_dashboard_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransitionVertical.SetDecoration(this.label5, Guna.UI.Animation.DecorationType.None);
            this.label5.Font = new System.Drawing.Font("Poppins SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label5.Location = new System.Drawing.Point(17, 314);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(58, 19);
            this.label5.TabIndex = 24;
            this.label5.Text = "PAGINAS";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransitionVertical.SetDecoration(this.label4, Guna.UI.Animation.DecorationType.None);
            this.label4.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(78)))), ((int)(((byte)(81)))));
            this.label4.Location = new System.Drawing.Point(53, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 28);
            this.label4.TabIndex = 211;
            this.label4.Text = "Registro";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransitionVertical.SetDecoration(this.label2, Guna.UI.Animation.DecorationType.None);
            this.label2.Font = new System.Drawing.Font("Poppins Thin", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(56, 673);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Version 2.0.0";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransitionVertical.SetDecoration(this.label1, Guna.UI.Animation.DecorationType.None);
            this.label1.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.label1.Location = new System.Drawing.Point(25, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 28);
            this.label1.TabIndex = 212;
            this.label1.Text = "Mi";
            // 
            // lbl_lastacess
            // 
            this.lbl_lastacess.AutoSize = true;
            this.lbl_lastacess.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransitionVertical.SetDecoration(this.lbl_lastacess, Guna.UI.Animation.DecorationType.None);
            this.lbl_lastacess.Font = new System.Drawing.Font("Poppins Light", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_lastacess.ForeColor = System.Drawing.Color.Silver;
            this.lbl_lastacess.Location = new System.Drawing.Point(101, 693);
            this.lbl_lastacess.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_lastacess.Name = "lbl_lastacess";
            this.lbl_lastacess.Size = new System.Drawing.Size(54, 16);
            this.lbl_lastacess.TabIndex = 2;
            this.lbl_lastacess.Text = "31/12/2020";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.gunaTransitionVertical.SetDecoration(this.label3, Guna.UI.Animation.DecorationType.None);
            this.label3.Font = new System.Drawing.Font("Poppins Light", 6.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(30, 693);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ultimo acceso:";
            // 
            // pn_contenedor
            // 
            this.pn_contenedor.AutoSize = true;
            this.pn_contenedor.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gunaTransitionVertical.SetDecoration(this.pn_contenedor, Guna.UI.Animation.DecorationType.None);
            this.pn_contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_contenedor.ForeColor = System.Drawing.Color.White;
            this.pn_contenedor.Location = new System.Drawing.Point(195, 39);
            this.pn_contenedor.Name = "pn_contenedor";
            this.pn_contenedor.Size = new System.Drawing.Size(1005, 679);
            this.pn_contenedor.TabIndex = 15;
            // 
            // pn_moreoptions
            // 
            this.pn_moreoptions.BackColor = System.Drawing.Color.Transparent;
            this.pn_moreoptions.BaseColor = System.Drawing.Color.White;
            this.pn_moreoptions.Controls.Add(this.gunaSeparator5);
            this.pn_moreoptions.Controls.Add(this.gunaSeparator4);
            this.pn_moreoptions.Controls.Add(this.gunaSeparator3);
            this.pn_moreoptions.Controls.Add(this.btn_more_closesystem);
            this.pn_moreoptions.Controls.Add(this.btn_more_configuracion);
            this.pn_moreoptions.Controls.Add(this.gunaAdvenceButton8);
            this.pn_moreoptions.Controls.Add(this.gunaAdvenceButton7);
            this.gunaTransitionVertical.SetDecoration(this.pn_moreoptions, Guna.UI.Animation.DecorationType.None);
            this.pn_moreoptions.Location = new System.Drawing.Point(1000, 45);
            this.pn_moreoptions.Name = "pn_moreoptions";
            this.pn_moreoptions.Radius = 5;
            this.pn_moreoptions.ShadowColor = System.Drawing.Color.Black;
            this.pn_moreoptions.ShadowDepth = 70;
            this.pn_moreoptions.ShadowShift = 2;
            this.pn_moreoptions.Size = new System.Drawing.Size(189, 155);
            this.pn_moreoptions.TabIndex = 0;
            this.pn_moreoptions.Visible = false;
            // 
            // gunaSeparator5
            // 
            this.gunaTransitionVertical.SetDecoration(this.gunaSeparator5, Guna.UI.Animation.DecorationType.None);
            this.gunaSeparator5.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.gunaSeparator5.Location = new System.Drawing.Point(0, 109);
            this.gunaSeparator5.Name = "gunaSeparator5";
            this.gunaSeparator5.Size = new System.Drawing.Size(189, 10);
            this.gunaSeparator5.TabIndex = 26;
            // 
            // gunaSeparator4
            // 
            this.gunaTransitionVertical.SetDecoration(this.gunaSeparator4, Guna.UI.Animation.DecorationType.None);
            this.gunaSeparator4.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.gunaSeparator4.Location = new System.Drawing.Point(0, 71);
            this.gunaSeparator4.Name = "gunaSeparator4";
            this.gunaSeparator4.Size = new System.Drawing.Size(189, 10);
            this.gunaSeparator4.TabIndex = 25;
            // 
            // gunaSeparator3
            // 
            this.gunaTransitionVertical.SetDecoration(this.gunaSeparator3, Guna.UI.Animation.DecorationType.None);
            this.gunaSeparator3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.gunaSeparator3.Location = new System.Drawing.Point(2, 35);
            this.gunaSeparator3.Name = "gunaSeparator3";
            this.gunaSeparator3.Size = new System.Drawing.Size(189, 10);
            this.gunaSeparator3.TabIndex = 24;
            // 
            // btn_more_closesystem
            // 
            this.btn_more_closesystem.AnimationHoverSpeed = 0.07F;
            this.btn_more_closesystem.AnimationSpeed = 0.03F;
            this.btn_more_closesystem.BackColor = System.Drawing.Color.Transparent;
            this.btn_more_closesystem.BaseColor = System.Drawing.Color.White;
            this.btn_more_closesystem.BorderColor = System.Drawing.Color.White;
            this.btn_more_closesystem.CheckedBaseColor = System.Drawing.Color.White;
            this.btn_more_closesystem.CheckedBorderColor = System.Drawing.Color.White;
            this.btn_more_closesystem.CheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_more_closesystem.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btn_more_closesystem.CheckedImage")));
            this.btn_more_closesystem.CheckedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.gunaTransitionVertical.SetDecoration(this.btn_more_closesystem, Guna.UI.Animation.DecorationType.None);
            this.btn_more_closesystem.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_more_closesystem.FocusedColor = System.Drawing.Color.Empty;
            this.btn_more_closesystem.Font = new System.Drawing.Font("Poppins SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_more_closesystem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.btn_more_closesystem.Image = null;
            this.btn_more_closesystem.ImageOffsetX = 5;
            this.btn_more_closesystem.ImageSize = new System.Drawing.Size(19, 19);
            this.btn_more_closesystem.LineColor = System.Drawing.Color.White;
            this.btn_more_closesystem.LineRight = 4;
            this.btn_more_closesystem.Location = new System.Drawing.Point(3, 117);
            this.btn_more_closesystem.Name = "btn_more_closesystem";
            this.btn_more_closesystem.OnHoverBaseColor = System.Drawing.Color.White;
            this.btn_more_closesystem.OnHoverBorderColor = System.Drawing.Color.White;
            this.btn_more_closesystem.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_more_closesystem.OnHoverImage = null;
            this.btn_more_closesystem.OnHoverLineColor = System.Drawing.Color.White;
            this.btn_more_closesystem.OnPressedColor = System.Drawing.Color.White;
            this.btn_more_closesystem.Size = new System.Drawing.Size(183, 31);
            this.btn_more_closesystem.TabIndex = 19;
            this.btn_more_closesystem.Text = "Salir del sistema";
            this.btn_more_closesystem.TextOffsetX = 12;
            // 
            // btn_more_configuracion
            // 
            this.btn_more_configuracion.AnimationHoverSpeed = 0.07F;
            this.btn_more_configuracion.AnimationSpeed = 0.03F;
            this.btn_more_configuracion.BackColor = System.Drawing.Color.Transparent;
            this.btn_more_configuracion.BaseColor = System.Drawing.Color.White;
            this.btn_more_configuracion.BorderColor = System.Drawing.Color.White;
            this.btn_more_configuracion.CheckedBaseColor = System.Drawing.Color.White;
            this.btn_more_configuracion.CheckedBorderColor = System.Drawing.Color.White;
            this.btn_more_configuracion.CheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_more_configuracion.CheckedImage = ((System.Drawing.Image)(resources.GetObject("btn_more_configuracion.CheckedImage")));
            this.btn_more_configuracion.CheckedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.gunaTransitionVertical.SetDecoration(this.btn_more_configuracion, Guna.UI.Animation.DecorationType.None);
            this.btn_more_configuracion.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btn_more_configuracion.FocusedColor = System.Drawing.Color.Empty;
            this.btn_more_configuracion.Font = new System.Drawing.Font("Poppins SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_more_configuracion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.btn_more_configuracion.Image = null;
            this.btn_more_configuracion.ImageOffsetX = 5;
            this.btn_more_configuracion.ImageSize = new System.Drawing.Size(19, 19);
            this.btn_more_configuracion.LineColor = System.Drawing.Color.White;
            this.btn_more_configuracion.LineRight = 4;
            this.btn_more_configuracion.Location = new System.Drawing.Point(3, 80);
            this.btn_more_configuracion.Name = "btn_more_configuracion";
            this.btn_more_configuracion.OnHoverBaseColor = System.Drawing.Color.White;
            this.btn_more_configuracion.OnHoverBorderColor = System.Drawing.Color.White;
            this.btn_more_configuracion.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_more_configuracion.OnHoverImage = null;
            this.btn_more_configuracion.OnHoverLineColor = System.Drawing.Color.White;
            this.btn_more_configuracion.OnPressedColor = System.Drawing.Color.White;
            this.btn_more_configuracion.Size = new System.Drawing.Size(183, 31);
            this.btn_more_configuracion.TabIndex = 18;
            this.btn_more_configuracion.Text = "Configuracion";
            this.btn_more_configuracion.TextOffsetX = 12;
            // 
            // gunaAdvenceButton8
            // 
            this.gunaAdvenceButton8.AnimationHoverSpeed = 0.07F;
            this.gunaAdvenceButton8.AnimationSpeed = 0.03F;
            this.gunaAdvenceButton8.BackColor = System.Drawing.Color.Transparent;
            this.gunaAdvenceButton8.BaseColor = System.Drawing.Color.White;
            this.gunaAdvenceButton8.BorderColor = System.Drawing.Color.White;
            this.gunaAdvenceButton8.CheckedBaseColor = System.Drawing.Color.White;
            this.gunaAdvenceButton8.CheckedBorderColor = System.Drawing.Color.White;
            this.gunaAdvenceButton8.CheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.gunaAdvenceButton8.CheckedImage = ((System.Drawing.Image)(resources.GetObject("gunaAdvenceButton8.CheckedImage")));
            this.gunaAdvenceButton8.CheckedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.gunaTransitionVertical.SetDecoration(this.gunaAdvenceButton8, Guna.UI.Animation.DecorationType.None);
            this.gunaAdvenceButton8.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaAdvenceButton8.FocusedColor = System.Drawing.Color.Empty;
            this.gunaAdvenceButton8.Font = new System.Drawing.Font("Poppins SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaAdvenceButton8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.gunaAdvenceButton8.Image = null;
            this.gunaAdvenceButton8.ImageOffsetX = 5;
            this.gunaAdvenceButton8.ImageSize = new System.Drawing.Size(19, 19);
            this.gunaAdvenceButton8.LineColor = System.Drawing.Color.White;
            this.gunaAdvenceButton8.LineRight = 4;
            this.gunaAdvenceButton8.Location = new System.Drawing.Point(3, 43);
            this.gunaAdvenceButton8.Name = "gunaAdvenceButton8";
            this.gunaAdvenceButton8.OnHoverBaseColor = System.Drawing.Color.White;
            this.gunaAdvenceButton8.OnHoverBorderColor = System.Drawing.Color.White;
            this.gunaAdvenceButton8.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.gunaAdvenceButton8.OnHoverImage = null;
            this.gunaAdvenceButton8.OnHoverLineColor = System.Drawing.Color.White;
            this.gunaAdvenceButton8.OnPressedColor = System.Drawing.Color.White;
            this.gunaAdvenceButton8.Size = new System.Drawing.Size(183, 31);
            this.gunaAdvenceButton8.TabIndex = 17;
            this.gunaAdvenceButton8.Text = "Cambiar contraseña";
            this.gunaAdvenceButton8.TextOffsetX = 12;
            // 
            // gunaAdvenceButton7
            // 
            this.gunaAdvenceButton7.AnimationHoverSpeed = 0.07F;
            this.gunaAdvenceButton7.AnimationSpeed = 0.03F;
            this.gunaAdvenceButton7.BackColor = System.Drawing.Color.Transparent;
            this.gunaAdvenceButton7.BaseColor = System.Drawing.Color.White;
            this.gunaAdvenceButton7.BorderColor = System.Drawing.Color.White;
            this.gunaAdvenceButton7.CheckedBaseColor = System.Drawing.Color.White;
            this.gunaAdvenceButton7.CheckedBorderColor = System.Drawing.Color.White;
            this.gunaAdvenceButton7.CheckedForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.gunaAdvenceButton7.CheckedImage = ((System.Drawing.Image)(resources.GetObject("gunaAdvenceButton7.CheckedImage")));
            this.gunaAdvenceButton7.CheckedLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.gunaTransitionVertical.SetDecoration(this.gunaAdvenceButton7, Guna.UI.Animation.DecorationType.None);
            this.gunaAdvenceButton7.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaAdvenceButton7.FocusedColor = System.Drawing.Color.Empty;
            this.gunaAdvenceButton7.Font = new System.Drawing.Font("Poppins SemiBold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaAdvenceButton7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.gunaAdvenceButton7.Image = null;
            this.gunaAdvenceButton7.ImageOffsetX = 5;
            this.gunaAdvenceButton7.ImageSize = new System.Drawing.Size(19, 19);
            this.gunaAdvenceButton7.LineColor = System.Drawing.Color.White;
            this.gunaAdvenceButton7.LineRight = 4;
            this.gunaAdvenceButton7.Location = new System.Drawing.Point(3, 6);
            this.gunaAdvenceButton7.Name = "gunaAdvenceButton7";
            this.gunaAdvenceButton7.OnHoverBaseColor = System.Drawing.Color.White;
            this.gunaAdvenceButton7.OnHoverBorderColor = System.Drawing.Color.White;
            this.gunaAdvenceButton7.OnHoverForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.gunaAdvenceButton7.OnHoverImage = null;
            this.gunaAdvenceButton7.OnHoverLineColor = System.Drawing.Color.White;
            this.gunaAdvenceButton7.OnPressedColor = System.Drawing.Color.White;
            this.gunaAdvenceButton7.Size = new System.Drawing.Size(183, 31);
            this.gunaAdvenceButton7.TabIndex = 16;
            this.gunaAdvenceButton7.Text = "Administra cuenta";
            this.gunaAdvenceButton7.TextOffsetX = 12;
            // 
            // gunaTransitionVertical
            // 
            this.gunaTransitionVertical.AnimationType = Guna.UI.Animation.AnimationType.VertSlide;
            this.gunaTransitionVertical.Cursor = null;
            animation3.AnimateOnlyDifferences = true;
            animation3.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.BlindCoeff")));
            animation3.LeafCoeff = 0F;
            animation3.MaxTime = 1F;
            animation3.MinTime = 0F;
            animation3.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicCoeff")));
            animation3.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicShift")));
            animation3.MosaicSize = 0;
            animation3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
            animation3.RotateCoeff = 0F;
            animation3.RotateLimit = 0F;
            animation3.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.ScaleCoeff")));
            animation3.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.SlideCoeff")));
            animation3.TimeCoeff = 0F;
            animation3.TransparencyCoeff = 0F;
            this.gunaTransitionVertical.DefaultAnimation = animation3;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 718);
            this.Controls.Add(this.pn_moreoptions);
            this.Controls.Add(this.pn_contenedor);
            this.Controls.Add(this.pn_tittle);
            this.Controls.Add(this.pn_sidebar);
            this.gunaTransitionVertical.SetDecoration(this, Guna.UI.Animation.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.pn_tittle.ResumeLayout(false);
            this.pn_sidebar.ResumeLayout(false);
            this.pn_sidebar.PerformLayout();
            this.pn_moreoptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
        private Guna.UI.WinForms.GunaElipse gunaElipse1;
        private System.Windows.Forms.Panel pn_sidebar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_lastacess;
        private System.Windows.Forms.Label label3;
        private Guna.UI.WinForms.GunaSeparator gunaSeparator1;
        private Guna.UI.WinForms.GunaSeparator gunaSeparator2;
        private System.Windows.Forms.Panel pn_tittle;
        private Guna.UI.WinForms.GunaSeparator gunaSeparator3;
        private Guna.UI.WinForms.GunaSeparator gunaSeparator5;
        private Guna.UI.WinForms.GunaSeparator gunaSeparator4;
        public System.Windows.Forms.Label lbl_nombre;
        public System.Windows.Forms.Label lbl_email;
        public Guna.UI.WinForms.GunaAdvenceButton btn_dashboard;
        public Guna.UI.WinForms.GunaAdvenceButton btn_empleados;
        public Guna.UI.WinForms.GunaAdvenceButton btn_formularios;
        public Guna.UI.WinForms.GunaAdvenceButton btn_tramites;
        public Guna.UI.WinForms.GunaAdvenceButton btn_estadisticas;
        public Guna.UI.WinForms.GunaAdvenceButton gunaAdvenceButton7;
        public Guna.UI.WinForms.GunaAdvenceButton btn_more_closesystem;
        public Guna.UI.WinForms.GunaAdvenceButton btn_more_configuracion;
        public Guna.UI.WinForms.GunaAdvenceButton gunaAdvenceButton8;
        public Guna.UI.WinForms.GunaAdvenceButton btn_configuracion;
        public Guna.UI.WinForms.GunaAdvenceButton btn_logout;
        public Guna.UI.WinForms.GunaImageButton btn_account;
        public Guna.UI.WinForms.GunaImageButton btn_moreoptions;
        public Guna.UI.WinForms.GunaShadowPanel pn_moreoptions;
        public System.Windows.Forms.Panel pn_contenedor;
        public Guna.UI.WinForms.GunaTransition gunaTransitionVertical;
    }
}