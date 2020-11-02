using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LayerBusiness;
using LayerSoporte.Cache;

namespace LayerPresentation
{
    public partial class frm_configuracion : Form
    {
        public frm_configuracion()
        {
            InitializeComponent();
        }

        // Function
        Cn_Usuarios _cnObject = new Cn_Usuarios();
        Cn_Formularios _cnFormularios = new Cn_Formularios();
        Cn_Tramites _cnTramites = new Cn_Tramites();

        private bool validatePassword = false;

        private void refreshUserInfo() 
        {
            lbl_nombreUser.Text = UserLoginCache.Nombre;
            lbl_user.Text = UserLoginCache.Username;
            lbl_permission.Text = UserLoginCache.Priveleges;
            lbl_lastacess.Text = UserLoginCache.Fecha_UltimoAcceso.ToLongDateString();

            txtBox_usuario.Text = UserLoginCache.Username;
            txtBox_nombreUsuario.Text = UserLoginCache.Nombre;
            txtBox_nombreCorto.Text = UserLoginCache.Nombre_Corto;
            txtBox_correo.Text = UserLoginCache.Email;
            txtBox_ciudad.Text = UserLoginCache.City;

            check_cumpleaños.Checked = Properties.Settings.Default.AlertaCumpleaños;
            check_stock.Checked = Properties.Settings.Default.AlertaStock;
            check_tramites.Checked = Properties.Settings.Default.AlertaTramites;
        }

        private List<string>[] InitializeNewDataUser() 
        {
            List<List<string>> all = new List<List<string>>();

            List<string> login = new List<string>();
            List<string> info = new List<string>();
            List<string> empleado = new List<string>();

            login.Add(txtBox_newUser_user.Text);
            login.Add(txtBox_newUser_pass.Text);
            login.Add(comboBox_privileges.GetItemText(comboBox_privileges.SelectedItem));

            info.Add(txtBox_newUser_nombre.Text);
            info.Add(txtBox_newUser_nombreCorto.Text);
            info.Add(txtBox_newUser_ciudad.Text);
            info.Add(txtBox_newUser_email.Text);
            info.Add(dtPick_newUser_fechaNacimiento.Value.ToString());

            empleado.Add(txtBox_newUser_nombreEmpleado.Text);
            empleado.Add(dtPick_newUser_contratacion.Value.ToString());

            all.Add(login);
            all.Add(info);
            all.Add(empleado);

            return all.ToArray();
        }
       
        private void mostraPanelConfig(Panel pn, Button btn)
        {
            pn.Visible = true;
            btn.Enabled = false;
        }
        private void ocultarPanelConfig(Panel pn, Button btn)
        {
            pn.Visible = false;
            btn.Enabled = true;
        }
        // Method
        private void btn_cambiar1_Click(object sender, EventArgs e)
        {
            mostraPanelConfig(pn_expand_1, btn_cambiar1);
        }

        private void btn_cambiar2_Click(object sender, EventArgs e)
        {
            mostraPanelConfig(pn_expand_2, btn_cambiar2);
        }

        private void btn_cambiar3_Click(object sender, EventArgs e)
        {
            mostraPanelConfig(pn_expand_3, btn_cambiar3);
        }

        private void btn_cambiar4_Click(object sender, EventArgs e)
        {
            mostraPanelConfig(pn_expand_4, btn_cambiar4);
        }

        private void btn_cambiar5_Click(object sender, EventArgs e)
        {
            mostraPanelConfig(pn_expand_5, btn_cambiar5);
        }

        private void btn_cambiar6_Click(object sender, EventArgs e)
        {
            mostraPanelConfig(pn_expand_6, btn_cambiar6);
        }

        private void btn_cancelar1_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_1, btn_cambiar1);
        }

        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_2, btn_cambiar2);
        }

        private void btn_cancelar3_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_3, btn_cambiar3);
        }

        private void btn_cancelar4_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_4, btn_cambiar4);
        }

        private void btn_cancelar5_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_5, btn_cambiar5);
        }

        private void btn_cancelar6_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_6, btn_cambiar6);
        }
        private bool ValidateOldPassword(string password) 
        {
            return _cnObject.verificarPassword(UserLoginCache.IdUser, password);
        }
        // Events click in save config user
        private void btn_save_user_Click(object sender, EventArgs e)
        {
            if(txtBox_usuario.Text != UserLoginCache.Username) 
            {
                // Save new user
                _cnObject.UpdateUser(UserLoginCache.IdUser, txtBox_usuario.Text);
                UserLoginCache.Username = txtBox_usuario.Text;
                frm_successdialog f = new frm_successdialog(2);
                f.Show();

                txtBox_usuario.Text = UserLoginCache.Username;
            }
        }
        private void btn_save_pass_Click(object sender, EventArgs e)
        {
            if(txtBox_passAntigua.Text != "Contraseña antigua") 
            {
                // Validate old password
                if(validatePassword) 
                {
                    if (txtBox_passNueva.Text == txtBox_passNueva1.Text)
                    {
                        if (txtBox_passNueva.Text != txtBox_passAntigua.Text) 
                        {
                            // Save new password
                            _cnObject.UpdatePassword(UserLoginCache.IdUser, txtBox_passNueva.Text);
                            UserLoginCache.Password = txtBox_passNueva.Text;
                            frm_successdialog f = new frm_successdialog(2);
                            f.Show();

                            txtBox_passAntigua.Text = "Contraseña antigua";
                            txtBox_passAntigua.UseSystemPasswordChar = false;
                            txtBox_passAntigua.ForeColor = Color.DarkGray;
                            pictureBox_newPassword.Visible = false;

                            txtBox_passNueva.Text = "Nueva contraseña";
                            txtBox_passNueva.UseSystemPasswordChar = false;
                            txtBox_passNueva.ForeColor = Color.DarkGray;
                            pictureBox_oldPassword.Visible = false;

                            txtBox_passNueva1.Text = "Volver a introducir la contraseña";
                            txtBox_passNueva1.UseSystemPasswordChar = false;
                            txtBox_passNueva1.ForeColor = Color.DarkGray;
                            pictureBox_newPassword1.Visible = false;

                            validatePassword = false;
                        } 
                        else 
                        {
                            MessageBox.Show("La contraseña nueva no puede ser igual a la antigua!", "Atencion!");
                        }
                    } 
                    else 
                    {
                        MessageBox.Show("Las contraseñas no coinciden", "Atencion!");
                    }
                }
            } 
        }
        private void btn_save_nombre_Click(object sender, EventArgs e)
        {
            if(txtBox_nombreUsuario.Text != UserLoginCache.Nombre) 
            {
                // Save name
                _cnObject.UpdateName(UserLoginCache.IdUser, txtBox_nombreUsuario.Text);

                UserLoginCache.Nombre = txtBox_nombreUsuario.Text;
                frm_successdialog f = new frm_successdialog(2);
                f.Show();

                txtBox_nombreUsuario.Text = UserLoginCache.Nombre;
            }
        }
        private void btn_save_nombrecorto_Click(object sender, EventArgs e)
        {
            if (txtBox_nombreCorto.Text != UserLoginCache.Nombre_Corto)
            {
                // Save name short
                _cnObject.UpdateShortName(UserLoginCache.IdUser, txtBox_nombreCorto.Text);

                UserLoginCache.Nombre_Corto = txtBox_nombreCorto.Text;
                frm_successdialog f = new frm_successdialog(2);
                f.Show();

                txtBox_nombreCorto.Text = UserLoginCache.Nombre_Corto;
            }
        }
        private void btn_save_email_Click(object sender, EventArgs e)
        {
            if (txtBox_correo.Text != UserLoginCache.Email)
            {
                // Save email 
                _cnObject.UpdateEmail(UserLoginCache.IdUser, txtBox_correo.Text);

                UserLoginCache.Email = txtBox_correo.Text;
                frm_successdialog f = new frm_successdialog(2);
                f.Show();

                txtBox_correo.Text = UserLoginCache.Email;
            }
        }
        private void btn_save_ciudad_Click(object sender, EventArgs e)
        {
            if (txtBox_ciudad.Text != UserLoginCache.City)
            {
                // Save city 
                _cnObject.UpdateCity(UserLoginCache.IdUser, txtBox_ciudad.Text);

                UserLoginCache.City = txtBox_ciudad.Text;
                frm_successdialog f = new frm_successdialog(2);
                f.Show();

                txtBox_ciudad.Text = UserLoginCache.City;
            }
        }

        private void txtBox_passAntigua_Enter(object sender, EventArgs e)
        {
            if (txtBox_passAntigua.Text == "Contraseña antigua")
            {
                txtBox_passAntigua.Text = "";
                txtBox_passAntigua.ForeColor = Color.Black;
                txtBox_passAntigua.UseSystemPasswordChar = true;
            }
        }
        private void txtBox_passAntigua_Leave(object sender, EventArgs e)
        {
            if (txtBox_passAntigua.Text == "")
            {
                txtBox_passAntigua.Text = "Contraseña antigua";
                txtBox_passAntigua.ForeColor = Color.DimGray;
                txtBox_passAntigua.UseSystemPasswordChar = false;
            } else 
            {
                if (ValidateOldPassword(txtBox_passAntigua.Text)) 
                {
                    pictureBox_oldPassword.BackgroundImage = LayerPresentation.Properties.Resources.check;
                    pictureBox_oldPassword.Visible = true;
                    validatePassword = true;
                }
                else
                {
                    pictureBox_oldPassword.BackgroundImage = LayerPresentation.Properties.Resources.status_red;
                    pictureBox_oldPassword.Visible = true;
                    MessageBox.Show("Contraseña antigua incorrecta", "Atencion!");
                }
            }
        }

        private void txtBox_passNueva_Enter(object sender, EventArgs e)
        {
            if (txtBox_passNueva.Text == "Nueva contraseña")
            {
                txtBox_passNueva.Text = "";
                txtBox_passNueva.ForeColor = Color.Black;
                txtBox_passNueva.UseSystemPasswordChar = true;
            }
        }
        private void txtBox_passNueva_Leave(object sender, EventArgs e)
        {
            if (txtBox_passNueva.Text == "")
            {
                txtBox_passNueva.Text = "Nueva contraseña";
                txtBox_passNueva.ForeColor = Color.DimGray;
                txtBox_passNueva.UseSystemPasswordChar = false;
            }
            else
            {
                if(txtBox_passNueva.Text != txtBox_passAntigua.Text) 
                {
                    pictureBox_newPassword.Visible = true;
                    pictureBox_newPassword.BackgroundImage = LayerPresentation.Properties.Resources.check;
                } else 
                {
                    pictureBox_newPassword.Visible = true;
                    pictureBox_newPassword.BackgroundImage = LayerPresentation.Properties.Resources.status_red;
                    MessageBox.Show("La contraeña nueva no puede ser igual a la antigua!", "Atencion!");
                }
            }
        }

        private void txtBox_passNueva1_Enter(object sender, EventArgs e)
        {
            if (txtBox_passNueva1.Text == "Volver a introducir la contraseña")
            {
                txtBox_passNueva1.Text = "";
                txtBox_passNueva1.ForeColor = Color.Black;
                txtBox_passNueva1.UseSystemPasswordChar = true;
            }
        }
        private void txtBox_passNueva1_Leave(object sender, EventArgs e)
        {
            if (txtBox_passNueva1.Text == "")
            {
                txtBox_passNueva1.Text = "Volver a introducir la contraseña";
                txtBox_passNueva1.ForeColor = Color.DimGray;
                txtBox_passNueva1.UseSystemPasswordChar = false;
            }
            else
            {
                if(txtBox_passNueva.Text == txtBox_passNueva1.Text) 
                {
                    pictureBox_newPassword1.Visible = true;
                    pictureBox_newPassword1.BackgroundImage = LayerPresentation.Properties.Resources.check;
                } 
                else 
                {
                    pictureBox_newPassword1.Visible = true;
                    pictureBox_newPassword1.BackgroundImage = LayerPresentation.Properties.Resources.status_red;
                    MessageBox.Show("Las contraseñas no coinciden!", "Atencion!");
                }
            }
        }
        private void check_tramites_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AlertaTramites = check_tramites.Checked;
            Properties.Settings.Default.Save();
        }
        private void check_stock_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AlertaStock = check_stock.Checked;
            Properties.Settings.Default.Save();
        }
        private void check_cumpleaños_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AlertaCumpleaños = check_cumpleaños.Checked;
            Properties.Settings.Default.Save();
        }
        // New category
        private void textBox_newCategoria_Enter(object sender, EventArgs e)
        {
            if (textBox_newCategoria.Text == "INGRESE UNA NUEVA CATEGORIA (EJ: 31A)")
            {
                textBox_newCategoria.ForeColor = Color.Black;
                textBox_newCategoria.Text = "";
            }
        }
        private void textBox_newCategoria_Leave(object sender, EventArgs e)
        {
            if (textBox_newCategoria.Text == "")
            {
                textBox_newCategoria.ForeColor = Color.DarkGray;
                textBox_newCategoria.Text = "INGRESE UNA NUEVA CATEGORIA (EJ: 31A)";
            }
        }
        private void btn_newCategoria_Click(object sender, EventArgs e)
        {
            if(textBox_newCategoria.Text != "" && textBox_newCategoria.Text != "INGRESE UNA NUEVA CATEGORIA (EJ: 31A)" && comboBox_objeto.SelectedIndex >= 0) 
            {
                string objeto = comboBox_objeto.GetItemText(comboBox_objeto.SelectedItem);
                _cnFormularios.InsertarCategoriaFormularios(objeto, textBox_newCategoria.Text);
                frm_successdialog f = new frm_successdialog(0);
                f.Show();
                _cnFormularios.RefreshDataCategoriasCache();
            }
            else 
            {
                MessageBox.Show("Los campos obligatorios estan vacios", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void comboBox_objeto_Enter(object sender, EventArgs e)
        {
            comboBox_objeto.ForeColor = Color.Black;
        }
        private void comboBox_objeto_Leave(object sender, EventArgs e)
        {
            comboBox_objeto.ForeColor = Color.DarkGray;
        }
        // New tipo tramite
        private void btn_newCategoriaTramite_Click(object sender, EventArgs e)
        {
            if(textBox_tipoTramite.Text != "") 
            {
                _cnTramites.InsertarCategoria(textBox_tipoTramite.Text);
                frm_successdialog f = new frm_successdialog(0);
                f.Show();
            }
        }
        private void textBox_tipoTramite_Enter(object sender, EventArgs e)
        {
            if(textBox_tipoTramite.Text == "Ingrese un nuevo tipo de tramite (Ej: Cedula)") 
            {
                textBox_tipoTramite.Text = "";
                textBox_tipoTramite.ForeColor = Color.Black;
            }
        }
        private void textBox_tipoTramite_Leave(object sender, EventArgs e)
        {
            if(textBox_tipoTramite.Text == "") 
            {
                textBox_tipoTramite.Text = "Ingrese un nuevo tipo de tramite (Ej: Cedula)";
                textBox_tipoTramite.ForeColor = Color.DarkGray;
            }
        }
        // Color
        private void btn_color1_Click(object sender, EventArgs e)
        {
            ColorSystem.ChangeColor(btn_color1.BackColor);
        }
        private void btn_color2_Click(object sender, EventArgs e)
        {
            ColorSystem.ChangeColor(btn_color2.BackColor);
        }
        private void btn_color3_Click(object sender, EventArgs e)
        {
            ColorSystem.ChangeColor(btn_color3.BackColor);
        }
        private void btn_color4_Click(object sender, EventArgs e)
        {
            ColorSystem.ChangeColor(btn_color4.BackColor);
        }
        private void btn_color5_Click(object sender, EventArgs e)
        {
            ColorSystem.ChangeColor(btn_color5.BackColor);
        }
        private void btn_color6_Click(object sender, EventArgs e)
        {
            ColorSystem.ChangeColor(btn_color6.BackColor);
        }
        private void btn_color7_Click(object sender, EventArgs e)
        {
            ColorSystem.ChangeColor(btn_color7.BackColor);
        }
        private void btn_color8_Click(object sender, EventArgs e)
        {
            ColorSystem.ChangeColor(btn_color8.BackColor);
        }
        private void btn_color9_Click(object sender, EventArgs e)
        {
            ColorSystem.ChangeColor(btn_color9.BackColor);
        }
        private void btn_color10_Click(object sender, EventArgs e)
        {
            ColorSystem.ChangeColor(btn_color10.BackColor);
        }
        // New user
        // Insert to database
        private void btn_newUser_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Estas seguro que deseas añadir un nuevo usuario al sistema? " + "\nUsuario nuevo: " + txtBox_newUser_nombre.Text, "Atencion!", MessageBoxButtons.YesNo) == DialogResult.Yes) 
            {
                if(MessageBox.Show("Acepta los terminos y condiciones de uso?", "MiRegistro", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK) 
                {
                    List<string>[] data = InitializeNewDataUser();
                }
            }
        }
        // Login info
        private void txtBox_newUser_user_Enter(object sender, EventArgs e)
        {
            if (txtBox_newUser_user.Text == "Ingrese el usuario")
            {
                txtBox_newUser_user.ForeColor = Color.Black;
                txtBox_newUser_user.Text = "";
            }
        }
        private void txtBox_newUser_user_Leave(object sender, EventArgs e)
        {
            if (txtBox_newUser_user.Text == "")
            {
                txtBox_newUser_user.ForeColor = Color.LightGray;
                txtBox_newUser_user.Text = "Ingrese el usuario";
            }
        }
        private void txtBox_newUser_pass_Enter(object sender, EventArgs e)
        {
            if (txtBox_newUser_pass.Text == "Ingrese la contraseña")
            {
                txtBox_newUser_pass.ForeColor = Color.Black;
                txtBox_newUser_pass.Text = "";
                txtBox_newUser_pass.UseSystemPasswordChar = true;
            }
        }
        private void txtBox_newUser_pass_Leave(object sender, EventArgs e)
        {
            if (txtBox_newUser_pass.Text == "")
            {
                txtBox_newUser_pass.ForeColor = Color.LightGray;
                txtBox_newUser_pass.Text = "Ingrese la contraseña";
                txtBox_newUser_pass.UseSystemPasswordChar = false;
            }
        }
        private void comboBox_privileges_Enter(object sender, EventArgs e)
        {
            if (comboBox_privileges.SelectedIndex < 0)
            {
                comboBox_privileges.ForeColor = Color.Black;
                comboBox_privileges.SelectedIndex = 1;
            }
        }
        private void comboBox_privileges_Leave(object sender, EventArgs e)
        {
            if (comboBox_privileges.SelectedIndex < 0)
            {
                comboBox_privileges.ForeColor = Color.LightGray;
                comboBox_privileges.SelectedIndex = 1;
            }
        }
        // Info user
        private void txtBox_newUser_nombre_Enter(object sender, EventArgs e)
        {
            if (txtBox_newUser_nombre.Text == "Ingrese el nombre")
            {
                txtBox_newUser_nombre.ForeColor = Color.Black;
                txtBox_newUser_nombre.Text = "";
            }
        }
        private void txtBox_newUser_nombre_Leave(object sender, EventArgs e)
        {
            if (txtBox_newUser_nombre.Text == "")
            {
                txtBox_newUser_nombre.ForeColor = Color.LightGray;
                txtBox_newUser_nombre.Text = "Ingrese el nombre";
            }
        }

        private void txtBox_newUser_nombreCorto_Enter(object sender, EventArgs e)
        {
            if (txtBox_newUser_nombreCorto.Text == "Ingrese el nombre corto/apodo")
            {
                txtBox_newUser_nombreCorto.ForeColor = Color.Black;
                txtBox_newUser_nombreCorto.Text = "";
            }
        }
        private void txtBox_newUser_nombreCorto_Leave(object sender, EventArgs e)
        {
            if (txtBox_newUser_nombreCorto.Text == "")
            {
                txtBox_newUser_nombreCorto.ForeColor = Color.LightGray;
                txtBox_newUser_nombreCorto.Text = "Ingrese el nombre corto/apodo";
            }
        }

        private void txtBox_newUser_ciudad_Enter(object sender, EventArgs e)
        {
            if (txtBox_newUser_ciudad.Text == "Ingrese la ciudad natal")
            {
                txtBox_newUser_ciudad.ForeColor = Color.Black;
                txtBox_newUser_ciudad.Text = "";
            }
        }
        private void txtBox_newUser_ciudad_Leave(object sender, EventArgs e)
        {
            if (txtBox_newUser_ciudad.Text == "")
            {
                txtBox_newUser_ciudad.ForeColor = Color.LightGray;
                txtBox_newUser_ciudad.Text = "Ingrese la ciudad natal";
            }
        }

        private void txtBox_newUser_email_Enter(object sender, EventArgs e)
        {
            if (txtBox_newUser_email.Text == "Ingrese el email")
            {
                txtBox_newUser_email.ForeColor = Color.Black;
                txtBox_newUser_email.Text = "";
            }
        }
        private void txtBox_newUser_email_Leave(object sender, EventArgs e)
        {
            if (txtBox_newUser_email.Text == "")
            {
                txtBox_newUser_email.ForeColor = Color.LightGray;
                txtBox_newUser_email.Text = "Ingrese el email";
            }
        }

        private void txtBox_newUser_nombreEmpleado_Enter(object sender, EventArgs e)
        {
            if (txtBox_newUser_nombreEmpleado.Text == "Ingrese el nombre del sistema (Ej: Mati A.)")
            {
                txtBox_newUser_nombreEmpleado.ForeColor = Color.Black;
                txtBox_newUser_nombreEmpleado.Text = "";
            }
        }
        private void txtBox_newUser_nombreEmpleado_Leave(object sender, EventArgs e)
        {
            if (txtBox_newUser_nombreEmpleado.Text == "")
            {
                txtBox_newUser_nombreEmpleado.ForeColor = Color.LightGray;
                txtBox_newUser_nombreEmpleado.Text = "Ingrese el nombre del sistema (Ej: Mati A.)";
            }
        }
        private void cargarPrivilegios()
        {
            if (UserLoginCache.Priveleges == Privileges.Administrador)
            {
                // Code here activate or desactive functions
                panel_newTramite.Enabled = true;
                panel_newFormulario.Enabled = true;
                if (UserLoginCache.isRoot == 1) 
                {
                    panel_newUser.Enabled = true;
                }
            }
        }
        private void frm_configuracion_Load(object sender, EventArgs e)
        {
            refreshUserInfo();
            cargarPrivilegios();
        }
    }
}
