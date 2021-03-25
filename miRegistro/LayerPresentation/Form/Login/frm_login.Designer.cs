namespace LayerPresentation
{
    partial class frm_login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_login));
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.btn_login = new Bunifu.Framework.UI.BunifuFlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label11 = new System.Windows.Forms.Label();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.btn_singup = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_registro = new System.Windows.Forms.Label();
            this.btn_minimize = new System.Windows.Forms.PictureBox();
            this.btn_close = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox_guardar = new Bunifu.Framework.UI.BunifuCheckbox();
            this.btn_saveinfo = new System.Windows.Forms.Label();
            this.bunifuImageButton2 = new Bunifu.Framework.UI.BunifuImageButton();
            this.btn_showpassword = new Bunifu.Framework.UI.BunifuImageButton();
            this.txtBox_user = new Guna.UI.WinForms.GunaTextBox();
            this.txtBox_pass = new Guna.UI.WinForms.GunaTextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_showpassword)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins ExtraBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(28, 94);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "Iniciar sesion";
            // 
            // linkLabel
            // 
            this.linkLabel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.linkLabel.AutoSize = true;
            this.linkLabel.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.linkLabel.Location = new System.Drawing.Point(77, 396);
            this.linkLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(162, 19);
            this.linkLabel.TabIndex = 4;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "Ha olvidado su contraseña?";
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // btn_login
            // 
            this.btn_login.Activecolor = System.Drawing.Color.Transparent;
            this.btn_login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_login.BorderRadius = 7;
            this.btn_login.ButtonText = "Acceder al sistema";
            this.btn_login.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_login.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.btn_login.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_login.Iconimage = null;
            this.btn_login.Iconimage_right = null;
            this.btn_login.Iconimage_right_Selected = null;
            this.btn_login.Iconimage_Selected = null;
            this.btn_login.IconMarginLeft = 0;
            this.btn_login.IconMarginRight = 0;
            this.btn_login.IconRightVisible = true;
            this.btn_login.IconRightZoom = 0D;
            this.btn_login.IconVisible = true;
            this.btn_login.IconZoom = 0D;
            this.btn_login.IsTab = false;
            this.btn_login.Location = new System.Drawing.Point(34, 300);
            this.btn_login.Name = "btn_login";
            this.btn_login.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_login.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_login.OnHoverTextColor = System.Drawing.Color.LightGray;
            this.btn_login.selected = false;
            this.btn_login.Size = new System.Drawing.Size(271, 40);
            this.btn_login.TabIndex = 12;
            this.btn_login.Text = "Acceder al sistema";
            this.btn_login.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_login.Textcolor = System.Drawing.Color.White;
            this.btn_login.TextFont = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(242)))), ((int)(((byte)(254)))));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.bunifuSeparator2);
            this.panel1.Controls.Add(this.btn_singup);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.lbl_registro);
            this.panel1.Controls.Add(this.btn_minimize);
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(340, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 474);
            this.panel1.TabIndex = 2;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Poppins ExtraLight", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.Color.Silver;
            this.linkLabel1.Location = new System.Drawing.Point(90, 424);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(321, 19);
            this.linkLabel1.TabIndex = 227;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Comunicarse con un representante del sistema MiRegistro";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Poppins Thin", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label11.Location = new System.Drawing.Point(74, 352);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(359, 57);
            this.label11.TabIndex = 226;
            this.label11.Text = "Al generar un nuevo usuario debera contar con la habilitacion\r\ndel encargado del " +
    "registro y con la licencia del sistema MiRegistro.\r\nPara mas informacion click e" +
    "n el siguiente link:";
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(50, 129);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(406, 14);
            this.bunifuSeparator2.TabIndex = 225;
            this.bunifuSeparator2.Transparency = 70;
            this.bunifuSeparator2.Vertical = false;
            // 
            // btn_singup
            // 
            this.btn_singup.ActiveBorderThickness = 1;
            this.btn_singup.ActiveCornerRadius = 35;
            this.btn_singup.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_singup.ActiveForecolor = System.Drawing.Color.White;
            this.btn_singup.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_singup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(242)))), ((int)(((byte)(254)))));
            this.btn_singup.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_singup.BackgroundImage")));
            this.btn_singup.ButtonText = "Registrarse";
            this.btn_singup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_singup.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_singup.ForeColor = System.Drawing.Color.SeaGreen;
            this.btn_singup.IdleBorderThickness = 1;
            this.btn_singup.IdleCornerRadius = 35;
            this.btn_singup.IdleFillColor = System.Drawing.Color.Transparent;
            this.btn_singup.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_singup.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.btn_singup.Location = new System.Drawing.Point(160, 288);
            this.btn_singup.Margin = new System.Windows.Forms.Padding(5);
            this.btn_singup.Name = "btn_singup";
            this.btn_singup.Size = new System.Drawing.Size(187, 48);
            this.btn_singup.TabIndex = 223;
            this.btn_singup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Poppins", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.label10.Location = new System.Drawing.Point(143, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(220, 126);
            this.label10.TabIndex = 216;
            this.label10.Text = "TODAVIA NO \r\nSOS MIEMBRO\r\nDE UN REGISTRO?";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Poppins ExtraBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.label9.Location = new System.Drawing.Point(96, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(315, 48);
            this.label9.TabIndex = 215;
            this.label9.Text = "Bienvenido de vuelta";
            // 
            // lbl_registro
            // 
            this.lbl_registro.BackColor = System.Drawing.Color.Transparent;
            this.lbl_registro.Font = new System.Drawing.Font("Poppins", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_registro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(78)))), ((int)(((byte)(81)))));
            this.lbl_registro.Location = new System.Drawing.Point(157, 52);
            this.lbl_registro.Name = "lbl_registro";
            this.lbl_registro.Size = new System.Drawing.Size(192, 28);
            this.lbl_registro.TabIndex = 214;
            this.lbl_registro.Text = "Registro del Calafate";
            // 
            // btn_minimize
            // 
            this.btn_minimize.BackgroundImage = global::LayerPresentation.Properties.Resources.subtract_30px;
            this.btn_minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_minimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_minimize.Location = new System.Drawing.Point(442, 9);
            this.btn_minimize.Margin = new System.Windows.Forms.Padding(2);
            this.btn_minimize.Name = "btn_minimize";
            this.btn_minimize.Size = new System.Drawing.Size(22, 22);
            this.btn_minimize.TabIndex = 11;
            this.btn_minimize.TabStop = false;
            this.btn_minimize.Click += new System.EventHandler(this.btn_minimize_Click);
            // 
            // btn_close
            // 
            this.btn_close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_close.BackgroundImage")));
            this.btn_close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_close.Location = new System.Drawing.Point(468, 9);
            this.btn_close.Margin = new System.Windows.Forms.Padding(2);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(22, 22);
            this.btn_close.TabIndex = 10;
            this.btn_close.TabStop = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Poppins", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(78)))), ((int)(((byte)(81)))));
            this.label4.Location = new System.Drawing.Point(106, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 37);
            this.label4.TabIndex = 213;
            this.label4.Text = "Registro";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Poppins ExtraBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.label2.Location = new System.Drawing.Point(66, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 34);
            this.label2.TabIndex = 214;
            this.label2.Text = "Mi";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 15;
            this.bunifuElipse1.TargetControl = this;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(31, 145);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 23);
            this.label5.TabIndex = 217;
            this.label5.Text = "Ingrese el usuario";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Poppins SemiBold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(31, 217);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 23);
            this.label6.TabIndex = 219;
            this.label6.Text = "Ingrese la contraseña";
            // 
            // checkBox_guardar
            // 
            this.checkBox_guardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.checkBox_guardar.ChechedOffColor = System.Drawing.Color.LightGray;
            this.checkBox_guardar.Checked = true;
            this.checkBox_guardar.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(122)))), ((int)(((byte)(252)))));
            this.checkBox_guardar.ForeColor = System.Drawing.Color.White;
            this.checkBox_guardar.Location = new System.Drawing.Point(52, 363);
            this.checkBox_guardar.Name = "checkBox_guardar";
            this.checkBox_guardar.Size = new System.Drawing.Size(20, 20);
            this.checkBox_guardar.TabIndex = 221;
            // 
            // btn_saveinfo
            // 
            this.btn_saveinfo.AutoSize = true;
            this.btn_saveinfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_saveinfo.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_saveinfo.ForeColor = System.Drawing.Color.Gray;
            this.btn_saveinfo.Location = new System.Drawing.Point(73, 362);
            this.btn_saveinfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.btn_saveinfo.Name = "btn_saveinfo";
            this.btn_saveinfo.Size = new System.Drawing.Size(204, 23);
            this.btn_saveinfo.TabIndex = 222;
            this.btn_saveinfo.Text = "Guardar informacion de inicio";
            this.btn_saveinfo.Click += new System.EventHandler(this.btn_saveinfo_Click);
            // 
            // bunifuImageButton2
            // 
            this.bunifuImageButton2.BackColor = System.Drawing.Color.White;
            this.bunifuImageButton2.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton2.Image")));
            this.bunifuImageButton2.ImageActive = null;
            this.bunifuImageButton2.Location = new System.Drawing.Point(35, 27);
            this.bunifuImageButton2.Name = "bunifuImageButton2";
            this.bunifuImageButton2.Size = new System.Drawing.Size(36, 28);
            this.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton2.TabIndex = 223;
            this.bunifuImageButton2.TabStop = false;
            this.bunifuImageButton2.Zoom = 9;
            // 
            // btn_showpassword
            // 
            this.btn_showpassword.BackColor = System.Drawing.Color.Transparent;
            this.btn_showpassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_showpassword.Image = global::LayerPresentation.Properties.Resources.eye_64px;
            this.btn_showpassword.ImageActive = null;
            this.btn_showpassword.Location = new System.Drawing.Point(282, 250);
            this.btn_showpassword.Name = "btn_showpassword";
            this.btn_showpassword.Size = new System.Drawing.Size(23, 21);
            this.btn_showpassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_showpassword.TabIndex = 220;
            this.btn_showpassword.TabStop = false;
            this.btn_showpassword.Zoom = 9;
            this.btn_showpassword.MouseEnter += new System.EventHandler(this.btn_showpassword_MouseEnter);
            this.btn_showpassword.MouseLeave += new System.EventHandler(this.btn_showpassword_MouseLeave);
            // 
            // txtBox_user
            // 
            this.txtBox_user.BackColor = System.Drawing.Color.Transparent;
            this.txtBox_user.BaseColor = System.Drawing.Color.White;
            this.txtBox_user.BorderColor = System.Drawing.Color.Silver;
            this.txtBox_user.BorderSize = 1;
            this.txtBox_user.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBox_user.FocusedBaseColor = System.Drawing.Color.White;
            this.txtBox_user.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtBox_user.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtBox_user.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_user.ForeColor = System.Drawing.Color.Silver;
            this.txtBox_user.Location = new System.Drawing.Point(31, 173);
            this.txtBox_user.Name = "txtBox_user";
            this.txtBox_user.PasswordChar = '\0';
            this.txtBox_user.Radius = 7;
            this.txtBox_user.Size = new System.Drawing.Size(275, 28);
            this.txtBox_user.TabIndex = 239;
            this.txtBox_user.Text = "usuarioejemplo";
            this.txtBox_user.Enter += new System.EventHandler(this.textboxUsuario_Enter);
            this.txtBox_user.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxUsuario_KeyPress);
            this.txtBox_user.Leave += new System.EventHandler(this.textboxUsuario_Leave);
            // 
            // txtBox_pass
            // 
            this.txtBox_pass.BackColor = System.Drawing.Color.Transparent;
            this.txtBox_pass.BaseColor = System.Drawing.Color.White;
            this.txtBox_pass.BorderColor = System.Drawing.Color.Silver;
            this.txtBox_pass.BorderSize = 1;
            this.txtBox_pass.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBox_pass.FocusedBaseColor = System.Drawing.Color.White;
            this.txtBox_pass.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.txtBox_pass.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.txtBox_pass.Font = new System.Drawing.Font("Poppins", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_pass.ForeColor = System.Drawing.Color.Silver;
            this.txtBox_pass.Location = new System.Drawing.Point(31, 246);
            this.txtBox_pass.Name = "txtBox_pass";
            this.txtBox_pass.PasswordChar = '\0';
            this.txtBox_pass.Radius = 7;
            this.txtBox_pass.Size = new System.Drawing.Size(275, 28);
            this.txtBox_pass.TabIndex = 240;
            this.txtBox_pass.Text = "8 caracteres o mas";
            this.txtBox_pass.Enter += new System.EventHandler(this.textboxContraseña_Enter);
            this.txtBox_pass.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textboxContraseña_KeyPress);
            this.txtBox_pass.Leave += new System.EventHandler(this.textboxContraseña_Leave);
            // 
            // frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(840, 474);
            this.Controls.Add(this.txtBox_user);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.bunifuImageButton2);
            this.Controls.Add(this.btn_saveinfo);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.checkBox_guardar);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.btn_showpassword);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtBox_pass);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frm_login";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar sesion";
            this.Load += new System.EventHandler(this.Login_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_minimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_close)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_showpassword)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.PictureBox btn_close;
        private System.Windows.Forms.PictureBox btn_minimize;
        private Bunifu.Framework.UI.BunifuFlatButton btn_login;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label btn_saveinfo;
        private Bunifu.Framework.UI.BunifuCheckbox checkBox_guardar;
        private Bunifu.Framework.UI.BunifuImageButton btn_showpassword;
        private Bunifu.Framework.UI.BunifuThinButton2 btn_singup;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_registro;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label11;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private System.Windows.Forms.Label label10;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton2;
        private Guna.UI.WinForms.GunaTextBox txtBox_user;
        private Guna.UI.WinForms.GunaTextBox txtBox_pass;
    }
}