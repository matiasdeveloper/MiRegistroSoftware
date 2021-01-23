namespace LayerPresentation
{
    partial class frm_principal
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
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_principal));
            this.pn_tittle = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ElipseForm = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.TransitionSidebar = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.pn_contenedor = new System.Windows.Forms.Panel();
            this.ElipseBrand = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.Tittle_Drag = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pn_sidebar = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.lbl_lastacess = new System.Windows.Forms.Label();
            this.btn_logout = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lbl_permisos = new System.Windows.Forms.Label();
            this.pn_brand = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_electronico = new System.Windows.Forms.Label();
            this.btn_config = new Bunifu.Framework.UI.BunifuFlatButton();
            this.lbl_nombre = new System.Windows.Forms.Label();
            this.btn_statistics = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_employees = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_formularios = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btn_tramites = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.btn_dashboard = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pn_tittle_bar = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label41 = new System.Windows.Forms.Label();
            this.txtBox_fecha = new System.Windows.Forms.Label();
            this.btn_minimize = new System.Windows.Forms.PictureBox();
            this.btn_close = new System.Windows.Forms.PictureBox();
            this.pn_buttons = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.ElipseSidebar = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pn_infouser = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.ElipseInfoUser = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.bunifuSeparator3 = new Bunifu.Framework.UI.BunifuSeparator();
            this.pn_tittle.SuspendLayout();
            this.pn_sidebar.SuspendLayout();
            this.pn_brand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.pn_tittle_bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).BeginInit();
            this.pn_buttons.SuspendLayout();
            this.pn_infouser.SuspendLayout();
            this.SuspendLayout();
            // 
            // pn_tittle
            // 
            this.pn_tittle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(77)))));
            this.pn_tittle.Controls.Add(this.pn_tittle_bar);
            this.TransitionSidebar.SetDecoration(this.pn_tittle, BunifuAnimatorNS.DecorationType.None);
            this.pn_tittle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pn_tittle.Location = new System.Drawing.Point(0, 0);
            this.pn_tittle.Margin = new System.Windows.Forms.Padding(2);
            this.pn_tittle.Name = "pn_tittle";
            this.pn_tittle.Size = new System.Drawing.Size(1200, 29);
            this.pn_tittle.TabIndex = 1;
            this.pn_tittle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.barra_titulo_MouseDown);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ElipseForm
            // 
            this.ElipseForm.ElipseRadius = 10;
            this.ElipseForm.TargetControl = this;
            // 
            // TransitionSidebar
            // 
            this.TransitionSidebar.AnimationType = BunifuAnimatorNS.AnimationType.HorizSlide;
            this.TransitionSidebar.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.TransitionSidebar.DefaultAnimation = animation1;
            // 
            // pn_contenedor
            // 
            this.pn_contenedor.BackColor = System.Drawing.Color.White;
            this.TransitionSidebar.SetDecoration(this.pn_contenedor, BunifuAnimatorNS.DecorationType.None);
            this.pn_contenedor.ForeColor = System.Drawing.Color.White;
            this.pn_contenedor.Location = new System.Drawing.Point(195, 29);
            this.pn_contenedor.Name = "pn_contenedor";
            this.pn_contenedor.Size = new System.Drawing.Size(1005, 689);
            this.pn_contenedor.TabIndex = 11;
            // 
            // ElipseBrand
            // 
            this.ElipseBrand.ElipseRadius = 20;
            this.ElipseBrand.TargetControl = this.pn_brand;
            // 
            // Tittle_Drag
            // 
            this.Tittle_Drag.Fixed = true;
            this.Tittle_Drag.Horizontal = true;
            this.Tittle_Drag.TargetControl = this.pn_tittle_bar;
            this.Tittle_Drag.Vertical = true;
            // 
            // pn_sidebar
            // 
            this.pn_sidebar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pn_sidebar.BackgroundImage")));
            this.pn_sidebar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pn_sidebar.Controls.Add(this.pn_infouser);
            this.pn_sidebar.Controls.Add(this.pn_buttons);
            this.pn_sidebar.Controls.Add(this.bunifuSeparator2);
            this.pn_sidebar.Controls.Add(this.pn_brand);
            this.pn_sidebar.Controls.Add(this.bunifuSeparator1);
            this.TransitionSidebar.SetDecoration(this.pn_sidebar, BunifuAnimatorNS.DecorationType.None);
            this.pn_sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pn_sidebar.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(77)))));
            this.pn_sidebar.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(77)))));
            this.pn_sidebar.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(77)))));
            this.pn_sidebar.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(77)))));
            this.pn_sidebar.Location = new System.Drawing.Point(0, 29);
            this.pn_sidebar.Name = "pn_sidebar";
            this.pn_sidebar.Quality = 10;
            this.pn_sidebar.Size = new System.Drawing.Size(195, 689);
            this.pn_sidebar.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.TransitionSidebar.SetDecoration(this.label3, BunifuAnimatorNS.DecorationType.None);
            this.label3.Font = new System.Drawing.Font("Poppins Light", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label3.Location = new System.Drawing.Point(40, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ultimo acceso:";
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.TransitionSidebar.SetDecoration(this.bunifuSeparator2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuSeparator2.LineColor = System.Drawing.Color.Silver;
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(4, 610);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(186, 14);
            this.bunifuSeparator2.TabIndex = 17;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // lbl_lastacess
            // 
            this.lbl_lastacess.AutoSize = true;
            this.lbl_lastacess.BackColor = System.Drawing.Color.Transparent;
            this.TransitionSidebar.SetDecoration(this.lbl_lastacess, BunifuAnimatorNS.DecorationType.None);
            this.lbl_lastacess.Font = new System.Drawing.Font("Poppins Light", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_lastacess.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.lbl_lastacess.Location = new System.Drawing.Point(125, 91);
            this.lbl_lastacess.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_lastacess.Name = "lbl_lastacess";
            this.lbl_lastacess.Size = new System.Drawing.Size(63, 19);
            this.lbl_lastacess.TabIndex = 2;
            this.lbl_lastacess.Text = "31/12/2020";
            // 
            // btn_logout
            // 
            this.btn_logout.Activecolor = System.Drawing.Color.Black;
            this.btn_logout.BackColor = System.Drawing.Color.Transparent;
            this.btn_logout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_logout.BorderRadius = 7;
            this.btn_logout.ButtonText = "      Cerrar Sesion";
            this.btn_logout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransitionSidebar.SetDecoration(this.btn_logout, BunifuAnimatorNS.DecorationType.None);
            this.btn_logout.DisabledColor = System.Drawing.Color.Gray;
            this.btn_logout.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_logout.Iconimage = global::LayerPresentation.Properties.Resources.status_green;
            this.btn_logout.Iconimage_right = null;
            this.btn_logout.Iconimage_right_Selected = null;
            this.btn_logout.Iconimage_Selected = null;
            this.btn_logout.IconMarginLeft = 0;
            this.btn_logout.IconMarginRight = 0;
            this.btn_logout.IconRightVisible = true;
            this.btn_logout.IconRightZoom = 0D;
            this.btn_logout.IconVisible = true;
            this.btn_logout.IconZoom = 30D;
            this.btn_logout.IsTab = false;
            this.btn_logout.Location = new System.Drawing.Point(0, 428);
            this.btn_logout.Name = "btn_logout";
            this.btn_logout.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_logout.OnHovercolor = System.Drawing.Color.Silver;
            this.btn_logout.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_logout.selected = false;
            this.btn_logout.Size = new System.Drawing.Size(188, 48);
            this.btn_logout.TabIndex = 16;
            this.btn_logout.Text = "      Cerrar Sesion";
            this.btn_logout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_logout.Textcolor = System.Drawing.Color.White;
            this.btn_logout.TextFont = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_logout.Click += new System.EventHandler(this.btn_logout_Click);
            // 
            // lbl_permisos
            // 
            this.lbl_permisos.AutoSize = true;
            this.lbl_permisos.BackColor = System.Drawing.Color.Transparent;
            this.TransitionSidebar.SetDecoration(this.lbl_permisos, BunifuAnimatorNS.DecorationType.None);
            this.lbl_permisos.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_permisos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_permisos.Location = new System.Drawing.Point(10, 37);
            this.lbl_permisos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_permisos.Name = "lbl_permisos";
            this.lbl_permisos.Size = new System.Drawing.Size(59, 19);
            this.lbl_permisos.TabIndex = 1;
            this.lbl_permisos.Text = "Permisos";
            // 
            // pn_brand
            // 
            this.pn_brand.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pn_brand.BackgroundImage")));
            this.pn_brand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pn_brand.Controls.Add(this.pictureBox3);
            this.pn_brand.Controls.Add(this.label2);
            this.pn_brand.Controls.Add(this.label1);
            this.TransitionSidebar.SetDecoration(this.pn_brand, BunifuAnimatorNS.DecorationType.None);
            this.pn_brand.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pn_brand.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pn_brand.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(77)))));
            this.pn_brand.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(77)))));
            this.pn_brand.Location = new System.Drawing.Point(1, 621);
            this.pn_brand.Name = "pn_brand";
            this.pn_brand.Quality = 10;
            this.pn_brand.Size = new System.Drawing.Size(191, 65);
            this.pn_brand.TabIndex = 10;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.BackgroundImage = global::LayerPresentation.Properties.Resources.Main_Logo_Mesa_de_trabajo_1;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TransitionSidebar.SetDecoration(this.pictureBox3, BunifuAnimatorNS.DecorationType.None);
            this.pictureBox3.Location = new System.Drawing.Point(7, 16);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.TransitionSidebar.SetDecoration(this.label2, BunifuAnimatorNS.DecorationType.None);
            this.label2.Font = new System.Drawing.Font("Poppins Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label2.Location = new System.Drawing.Point(73, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "Version 1.1.0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.TransitionSidebar.SetDecoration(this.label1, BunifuAnimatorNS.DecorationType.None);
            this.label1.Font = new System.Drawing.Font("Poppins Medium", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(39, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Mi Registro Software";
            // 
            // lbl_electronico
            // 
            this.lbl_electronico.AutoSize = true;
            this.lbl_electronico.BackColor = System.Drawing.Color.Transparent;
            this.TransitionSidebar.SetDecoration(this.lbl_electronico, BunifuAnimatorNS.DecorationType.None);
            this.lbl_electronico.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_electronico.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbl_electronico.Location = new System.Drawing.Point(10, 56);
            this.lbl_electronico.Name = "lbl_electronico";
            this.lbl_electronico.Size = new System.Drawing.Size(46, 19);
            this.lbl_electronico.TabIndex = 3;
            this.lbl_electronico.Text = "Correo";
            // 
            // btn_config
            // 
            this.btn_config.Activecolor = System.Drawing.Color.Black;
            this.btn_config.BackColor = System.Drawing.Color.Transparent;
            this.btn_config.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_config.BorderRadius = 7;
            this.btn_config.ButtonText = "      Configuraciones";
            this.btn_config.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransitionSidebar.SetDecoration(this.btn_config, BunifuAnimatorNS.DecorationType.None);
            this.btn_config.DisabledColor = System.Drawing.Color.Gray;
            this.btn_config.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_config.Iconimage = global::LayerPresentation.Properties.Resources.r_settings;
            this.btn_config.Iconimage_right = null;
            this.btn_config.Iconimage_right_Selected = null;
            this.btn_config.Iconimage_Selected = null;
            this.btn_config.IconMarginLeft = 0;
            this.btn_config.IconMarginRight = 0;
            this.btn_config.IconRightVisible = true;
            this.btn_config.IconRightZoom = 0D;
            this.btn_config.IconVisible = true;
            this.btn_config.IconZoom = 40D;
            this.btn_config.IsTab = false;
            this.btn_config.Location = new System.Drawing.Point(0, 259);
            this.btn_config.Name = "btn_config";
            this.btn_config.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_config.OnHovercolor = System.Drawing.Color.Silver;
            this.btn_config.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_config.selected = false;
            this.btn_config.Size = new System.Drawing.Size(188, 46);
            this.btn_config.TabIndex = 15;
            this.btn_config.Text = "      Configuraciones";
            this.btn_config.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_config.Textcolor = System.Drawing.Color.White;
            this.btn_config.TextFont = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_config.Click += new System.EventHandler(this.btn_config_Click);
            // 
            // lbl_nombre
            // 
            this.lbl_nombre.AutoSize = true;
            this.lbl_nombre.BackColor = System.Drawing.Color.Transparent;
            this.TransitionSidebar.SetDecoration(this.lbl_nombre, BunifuAnimatorNS.DecorationType.None);
            this.lbl_nombre.Font = new System.Drawing.Font("Poppins", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_nombre.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_nombre.Location = new System.Drawing.Point(3, 7);
            this.lbl_nombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_nombre.Name = "lbl_nombre";
            this.lbl_nombre.Size = new System.Drawing.Size(186, 30);
            this.lbl_nombre.TabIndex = 0;
            this.lbl_nombre.Text = "Nombre y apellido";
            // 
            // btn_statistics
            // 
            this.btn_statistics.Activecolor = System.Drawing.Color.Black;
            this.btn_statistics.BackColor = System.Drawing.Color.Transparent;
            this.btn_statistics.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_statistics.BorderRadius = 7;
            this.btn_statistics.ButtonText = "      Estadisticas";
            this.btn_statistics.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransitionSidebar.SetDecoration(this.btn_statistics, BunifuAnimatorNS.DecorationType.None);
            this.btn_statistics.DisabledColor = System.Drawing.Color.Gray;
            this.btn_statistics.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_statistics.Iconimage = global::LayerPresentation.Properties.Resources.User_Groups_48px;
            this.btn_statistics.Iconimage_right = null;
            this.btn_statistics.Iconimage_right_Selected = null;
            this.btn_statistics.Iconimage_Selected = null;
            this.btn_statistics.IconMarginLeft = 0;
            this.btn_statistics.IconMarginRight = 0;
            this.btn_statistics.IconRightVisible = true;
            this.btn_statistics.IconRightZoom = 0D;
            this.btn_statistics.IconVisible = true;
            this.btn_statistics.IconZoom = 40D;
            this.btn_statistics.IsTab = false;
            this.btn_statistics.Location = new System.Drawing.Point(0, 210);
            this.btn_statistics.Name = "btn_statistics";
            this.btn_statistics.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_statistics.OnHovercolor = System.Drawing.Color.Silver;
            this.btn_statistics.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_statistics.selected = false;
            this.btn_statistics.Size = new System.Drawing.Size(188, 48);
            this.btn_statistics.TabIndex = 14;
            this.btn_statistics.Text = "      Estadisticas";
            this.btn_statistics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_statistics.Textcolor = System.Drawing.Color.White;
            this.btn_statistics.TextFont = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_statistics.Click += new System.EventHandler(this.btn_statistics_Click);
            // 
            // btn_employees
            // 
            this.btn_employees.Activecolor = System.Drawing.Color.Black;
            this.btn_employees.BackColor = System.Drawing.Color.Transparent;
            this.btn_employees.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_employees.BorderRadius = 7;
            this.btn_employees.ButtonText = "      Empleados";
            this.btn_employees.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransitionSidebar.SetDecoration(this.btn_employees, BunifuAnimatorNS.DecorationType.None);
            this.btn_employees.DisabledColor = System.Drawing.Color.Gray;
            this.btn_employees.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_employees.Iconimage = global::LayerPresentation.Properties.Resources.Businessman_48px;
            this.btn_employees.Iconimage_right = null;
            this.btn_employees.Iconimage_right_Selected = null;
            this.btn_employees.Iconimage_Selected = null;
            this.btn_employees.IconMarginLeft = 0;
            this.btn_employees.IconMarginRight = 0;
            this.btn_employees.IconRightVisible = true;
            this.btn_employees.IconRightZoom = 0D;
            this.btn_employees.IconVisible = true;
            this.btn_employees.IconZoom = 40D;
            this.btn_employees.IsTab = false;
            this.btn_employees.Location = new System.Drawing.Point(0, 161);
            this.btn_employees.Name = "btn_employees";
            this.btn_employees.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_employees.OnHovercolor = System.Drawing.Color.Silver;
            this.btn_employees.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_employees.selected = false;
            this.btn_employees.Size = new System.Drawing.Size(188, 48);
            this.btn_employees.TabIndex = 13;
            this.btn_employees.Text = "      Empleados";
            this.btn_employees.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_employees.Textcolor = System.Drawing.Color.White;
            this.btn_employees.TextFont = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_employees.Click += new System.EventHandler(this.btn_employees_Click);
            // 
            // btn_formularios
            // 
            this.btn_formularios.Activecolor = System.Drawing.Color.Black;
            this.btn_formularios.BackColor = System.Drawing.Color.Transparent;
            this.btn_formularios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_formularios.BorderRadius = 7;
            this.btn_formularios.ButtonText = "      Formularios";
            this.btn_formularios.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransitionSidebar.SetDecoration(this.btn_formularios, BunifuAnimatorNS.DecorationType.None);
            this.btn_formularios.DisabledColor = System.Drawing.Color.Gray;
            this.btn_formularios.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_formularios.Iconimage = global::LayerPresentation.Properties.Resources.compras_48px;
            this.btn_formularios.Iconimage_right = null;
            this.btn_formularios.Iconimage_right_Selected = null;
            this.btn_formularios.Iconimage_Selected = null;
            this.btn_formularios.IconMarginLeft = 0;
            this.btn_formularios.IconMarginRight = 0;
            this.btn_formularios.IconRightVisible = true;
            this.btn_formularios.IconRightZoom = 0D;
            this.btn_formularios.IconVisible = true;
            this.btn_formularios.IconZoom = 40D;
            this.btn_formularios.IsTab = false;
            this.btn_formularios.Location = new System.Drawing.Point(0, 112);
            this.btn_formularios.Name = "btn_formularios";
            this.btn_formularios.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_formularios.OnHovercolor = System.Drawing.Color.Silver;
            this.btn_formularios.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_formularios.selected = false;
            this.btn_formularios.Size = new System.Drawing.Size(188, 48);
            this.btn_formularios.TabIndex = 12;
            this.btn_formularios.Text = "      Formularios";
            this.btn_formularios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_formularios.Textcolor = System.Drawing.Color.White;
            this.btn_formularios.TextFont = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_formularios.Click += new System.EventHandler(this.btn_formularios_Click);
            // 
            // btn_tramites
            // 
            this.btn_tramites.Activecolor = System.Drawing.Color.Black;
            this.btn_tramites.BackColor = System.Drawing.Color.Transparent;
            this.btn_tramites.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_tramites.BorderRadius = 7;
            this.btn_tramites.ButtonText = "      Tramites";
            this.btn_tramites.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransitionSidebar.SetDecoration(this.btn_tramites, BunifuAnimatorNS.DecorationType.None);
            this.btn_tramites.DisabledColor = System.Drawing.Color.Gray;
            this.btn_tramites.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_tramites.Iconimage = global::LayerPresentation.Properties.Resources.Producto_48px;
            this.btn_tramites.Iconimage_right = null;
            this.btn_tramites.Iconimage_right_Selected = null;
            this.btn_tramites.Iconimage_Selected = null;
            this.btn_tramites.IconMarginLeft = 0;
            this.btn_tramites.IconMarginRight = 0;
            this.btn_tramites.IconRightVisible = true;
            this.btn_tramites.IconRightZoom = 0D;
            this.btn_tramites.IconVisible = true;
            this.btn_tramites.IconZoom = 40D;
            this.btn_tramites.IsTab = false;
            this.btn_tramites.Location = new System.Drawing.Point(0, 63);
            this.btn_tramites.Name = "btn_tramites";
            this.btn_tramites.Normalcolor = System.Drawing.Color.Transparent;
            this.btn_tramites.OnHovercolor = System.Drawing.Color.Silver;
            this.btn_tramites.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_tramites.selected = false;
            this.btn_tramites.Size = new System.Drawing.Size(188, 48);
            this.btn_tramites.TabIndex = 11;
            this.btn_tramites.Text = "      Tramites";
            this.btn_tramites.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_tramites.Textcolor = System.Drawing.Color.White;
            this.btn_tramites.TextFont = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_tramites.Click += new System.EventHandler(this.btn_tramites_Click_1);
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.TransitionSidebar.SetDecoration(this.bunifuSeparator1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuSeparator1.LineColor = System.Drawing.Color.Silver;
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(5, 114);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(188, 14);
            this.bunifuSeparator1.TabIndex = 0;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // btn_dashboard
            // 
            this.btn_dashboard.Activecolor = System.Drawing.Color.Black;
            this.btn_dashboard.BackColor = System.Drawing.Color.Black;
            this.btn_dashboard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_dashboard.BorderRadius = 7;
            this.btn_dashboard.ButtonText = "      Escritorio";
            this.btn_dashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransitionSidebar.SetDecoration(this.btn_dashboard, BunifuAnimatorNS.DecorationType.None);
            this.btn_dashboard.DisabledColor = System.Drawing.Color.Gray;
            this.btn_dashboard.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_dashboard.Iconimage = global::LayerPresentation.Properties.Resources.Combo_Chart_64px;
            this.btn_dashboard.Iconimage_right = null;
            this.btn_dashboard.Iconimage_right_Selected = null;
            this.btn_dashboard.Iconimage_Selected = null;
            this.btn_dashboard.IconMarginLeft = 0;
            this.btn_dashboard.IconMarginRight = 0;
            this.btn_dashboard.IconRightVisible = true;
            this.btn_dashboard.IconRightZoom = 0D;
            this.btn_dashboard.IconVisible = true;
            this.btn_dashboard.IconZoom = 40D;
            this.btn_dashboard.IsTab = false;
            this.btn_dashboard.Location = new System.Drawing.Point(0, 14);
            this.btn_dashboard.Name = "btn_dashboard";
            this.btn_dashboard.Normalcolor = System.Drawing.Color.Black;
            this.btn_dashboard.OnHovercolor = System.Drawing.Color.Silver;
            this.btn_dashboard.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_dashboard.selected = false;
            this.btn_dashboard.Size = new System.Drawing.Size(188, 48);
            this.btn_dashboard.TabIndex = 1;
            this.btn_dashboard.Text = "      Escritorio";
            this.btn_dashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_dashboard.Textcolor = System.Drawing.Color.White;
            this.btn_dashboard.TextFont = new System.Drawing.Font("Poppins Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_dashboard.Click += new System.EventHandler(this.btn_dashboard_Click);
            // 
            // pn_tittle_bar
            // 
            this.pn_tittle_bar.BackColor = System.Drawing.Color.Transparent;
            this.pn_tittle_bar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pn_tittle_bar.BackgroundImage")));
            this.pn_tittle_bar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pn_tittle_bar.Controls.Add(this.bunifuSeparator3);
            this.pn_tittle_bar.Controls.Add(this.pictureBox1);
            this.pn_tittle_bar.Controls.Add(this.label41);
            this.pn_tittle_bar.Controls.Add(this.txtBox_fecha);
            this.pn_tittle_bar.Controls.Add(this.btn_minimize);
            this.pn_tittle_bar.Controls.Add(this.btn_close);
            this.TransitionSidebar.SetDecoration(this.pn_tittle_bar, BunifuAnimatorNS.DecorationType.None);
            this.pn_tittle_bar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pn_tittle_bar.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pn_tittle_bar.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(77)))));
            this.pn_tittle_bar.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(77)))));
            this.pn_tittle_bar.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pn_tittle_bar.Location = new System.Drawing.Point(0, 0);
            this.pn_tittle_bar.Name = "pn_tittle_bar";
            this.pn_tittle_bar.Quality = 10;
            this.pn_tittle_bar.Size = new System.Drawing.Size(1200, 29);
            this.pn_tittle_bar.TabIndex = 9;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::LayerPresentation.Properties.Resources.r_info;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TransitionSidebar.SetDecoration(this.pictureBox1, BunifuAnimatorNS.DecorationType.None);
            this.pictureBox1.Location = new System.Drawing.Point(7, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 15);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.BackColor = System.Drawing.Color.Transparent;
            this.TransitionSidebar.SetDecoration(this.label41, BunifuAnimatorNS.DecorationType.None);
            this.label41.Font = new System.Drawing.Font("Poppins ExtraLight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label41.ForeColor = System.Drawing.Color.White;
            this.label41.Location = new System.Drawing.Point(26, 5);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(145, 19);
            this.label41.TabIndex = 20;
            this.label41.Text = "Fecha y hora del servidor:";
            // 
            // txtBox_fecha
            // 
            this.txtBox_fecha.AutoSize = true;
            this.txtBox_fecha.BackColor = System.Drawing.Color.Transparent;
            this.TransitionSidebar.SetDecoration(this.txtBox_fecha, BunifuAnimatorNS.DecorationType.None);
            this.txtBox_fecha.Font = new System.Drawing.Font("Poppins ExtraLight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_fecha.ForeColor = System.Drawing.Color.White;
            this.txtBox_fecha.Location = new System.Drawing.Point(169, 5);
            this.txtBox_fecha.Name = "txtBox_fecha";
            this.txtBox_fecha.Size = new System.Drawing.Size(134, 19);
            this.txtBox_fecha.TabIndex = 21;
            this.txtBox_fecha.Text = "dd/mm/aaaa hh:mm:ss";
            // 
            // btn_minimize
            // 
            this.btn_minimize.BackColor = System.Drawing.Color.Transparent;
            this.btn_minimize.BackgroundImage = global::LayerPresentation.Properties.Resources.r_minimize;
            this.btn_minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransitionSidebar.SetDecoration(this.btn_minimize, BunifuAnimatorNS.DecorationType.None);
            this.btn_minimize.Location = new System.Drawing.Point(1150, 5);
            this.btn_minimize.Margin = new System.Windows.Forms.Padding(2);
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(20, 20);
            this.btn_minimize.TabIndex = 2;
            this.btn_minimize.TabStop = false;
            this.btn_minimize.Click += new System.EventHandler(this.btn_minimize_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.Transparent;
            this.btn_close.BackgroundImage = global::LayerPresentation.Properties.Resources.r_close;
            this.btn_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransitionSidebar.SetDecoration(this.btn_close, BunifuAnimatorNS.DecorationType.None);
            this.btn_close.Location = new System.Drawing.Point(1174, 5);
            this.btn_close.Margin = new System.Windows.Forms.Padding(2);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(20, 21);
            this.btn_close.TabIndex = 0;
            this.btn_close.TabStop = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // pn_buttons
            // 
            this.pn_buttons.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pn_buttons.BackgroundImage")));
            this.pn_buttons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pn_buttons.Controls.Add(this.btn_dashboard);
            this.pn_buttons.Controls.Add(this.btn_tramites);
            this.pn_buttons.Controls.Add(this.btn_formularios);
            this.pn_buttons.Controls.Add(this.btn_logout);
            this.pn_buttons.Controls.Add(this.btn_employees);
            this.pn_buttons.Controls.Add(this.btn_statistics);
            this.pn_buttons.Controls.Add(this.btn_config);
            this.TransitionSidebar.SetDecoration(this.pn_buttons, BunifuAnimatorNS.DecorationType.None);
            this.pn_buttons.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pn_buttons.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pn_buttons.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(77)))));
            this.pn_buttons.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(77)))));
            this.pn_buttons.Location = new System.Drawing.Point(4, 129);
            this.pn_buttons.Name = "pn_buttons";
            this.pn_buttons.Quality = 10;
            this.pn_buttons.Size = new System.Drawing.Size(189, 486);
            this.pn_buttons.TabIndex = 18;
            // 
            // ElipseSidebar
            // 
            this.ElipseSidebar.ElipseRadius = 25;
            this.ElipseSidebar.TargetControl = this.pn_buttons;
            // 
            // pn_infouser
            // 
            this.pn_infouser.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pn_infouser.BackgroundImage")));
            this.pn_infouser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pn_infouser.Controls.Add(this.lbl_lastacess);
            this.pn_infouser.Controls.Add(this.label3);
            this.pn_infouser.Controls.Add(this.lbl_nombre);
            this.pn_infouser.Controls.Add(this.lbl_electronico);
            this.pn_infouser.Controls.Add(this.lbl_permisos);
            this.TransitionSidebar.SetDecoration(this.pn_infouser, BunifuAnimatorNS.DecorationType.None);
            this.pn_infouser.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pn_infouser.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pn_infouser.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(77)))));
            this.pn_infouser.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(54)))), ((int)(((byte)(77)))));
            this.pn_infouser.Location = new System.Drawing.Point(4, 3);
            this.pn_infouser.Name = "pn_infouser";
            this.pn_infouser.Quality = 10;
            this.pn_infouser.Size = new System.Drawing.Size(188, 111);
            this.pn_infouser.TabIndex = 19;
            // 
            // ElipseInfoUser
            // 
            this.ElipseInfoUser.ElipseRadius = 25;
            this.ElipseInfoUser.TargetControl = this.pn_infouser;
            // 
            // bunifuSeparator3
            // 
            this.bunifuSeparator3.BackColor = System.Drawing.Color.Transparent;
            this.TransitionSidebar.SetDecoration(this.bunifuSeparator3, BunifuAnimatorNS.DecorationType.None);
            this.bunifuSeparator3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bunifuSeparator3.LineThickness = 1;
            this.bunifuSeparator3.Location = new System.Drawing.Point(5, 20);
            this.bunifuSeparator3.Name = "bunifuSeparator3";
            this.bunifuSeparator3.Size = new System.Drawing.Size(188, 14);
            this.bunifuSeparator3.TabIndex = 20;
            this.bunifuSeparator3.Transparency = 255;
            this.bunifuSeparator3.Vertical = false;
            // 
            // frm_principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 718);
            this.Controls.Add(this.pn_sidebar);
            this.Controls.Add(this.pn_contenedor);
            this.Controls.Add(this.pn_tittle);
            this.TransitionSidebar.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.Frm_principal_Load);
            this.pn_tittle.ResumeLayout(false);
            this.pn_sidebar.ResumeLayout(false);
            this.pn_brand.ResumeLayout(false);
            this.pn_brand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.pn_tittle_bar.ResumeLayout(false);
            this.pn_tittle_bar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).EndInit();
            this.pn_buttons.ResumeLayout(false);
            this.pn_infouser.ResumeLayout(false);
            this.pn_infouser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pn_tittle;
        private System.Windows.Forms.PictureBox btn_close;
        private System.Windows.Forms.PictureBox btn_minimize;
        private System.Windows.Forms.Label txtBox_fecha;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Timer timer1;
        private Bunifu.Framework.UI.BunifuElipse ElipseForm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_nombre;
        private System.Windows.Forms.Label lbl_electronico;
        private System.Windows.Forms.Label lbl_permisos;
        private System.Windows.Forms.Label lbl_lastacess;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuGradientPanel pn_sidebar;
        private Bunifu.Framework.UI.BunifuGradientPanel pn_brand;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuFlatButton btn_dashboard;
        private Bunifu.Framework.UI.BunifuFlatButton btn_tramites;
        private Bunifu.Framework.UI.BunifuFlatButton btn_config;
        private Bunifu.Framework.UI.BunifuFlatButton btn_statistics;
        private Bunifu.Framework.UI.BunifuFlatButton btn_employees;
        private Bunifu.Framework.UI.BunifuFlatButton btn_formularios;
        private BunifuAnimatorNS.BunifuTransition TransitionSidebar;
        private System.Windows.Forms.Panel pn_contenedor;
        private Bunifu.Framework.UI.BunifuGradientPanel pn_tittle_bar;
        private Bunifu.Framework.UI.BunifuElipse ElipseBrand;
        private Bunifu.Framework.UI.BunifuFlatButton btn_logout;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private Bunifu.Framework.UI.BunifuDragControl Tittle_Drag;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.Framework.UI.BunifuGradientPanel pn_buttons;
        private Bunifu.Framework.UI.BunifuElipse ElipseSidebar;
        private Bunifu.Framework.UI.BunifuGradientPanel pn_infouser;
        private Bunifu.Framework.UI.BunifuElipse ElipseInfoUser;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator3;
    }
}