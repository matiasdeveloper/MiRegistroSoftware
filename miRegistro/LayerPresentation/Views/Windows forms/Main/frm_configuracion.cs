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
using LayerPresentation.Clases;
namespace LayerPresentation
{
    public partial class frm_configuracion : Form
    {
        public frm_configuracion()
        {
            InitializeComponent();
        }

        private Image check = LayerPresentation.Properties.Resources.r_right_arrow;
        private Image checkOff = LayerPresentation.Properties.Resources.r_right_arrow;

        private bool isGood = false;

        private void LoadUserInformation() 
        {
           /* if (UserLoginCacheOld.isRoot)
                txtBox_root.Text = "(Sistema root)";
            else
                txtBox_root.Text = "(Sistema delegado)";

            txtBox_usuario.Text = UserLoginCacheOld.Username;
            txtBox_nombre.Text = UserLoginCacheOld.Nombre;
            txtBox_apellido.Text = UserLoginCacheOld.Apellido;
            txtBox_nick.Text = UserLoginCacheOld.Nick;

            txtBox_correo.Text = UserLoginCacheOld.Email;

            //check_cumpleaños.Checked = Properties.Settings.Default.AlertaCumpleaños;
            //check_stock.Checked = Properties.Settings.Default.AlertaStock;
            //check_tramites.Checked = Properties.Settings.Default.AlertaTramites;*/
        }

        // Initialize data from new user
        private List<string>[] InitializeDataFromNewUser() 
        {
            List<List<string>> all = new List<List<string>>();

            List<string> login = new List<string>();
            List<string> info = new List<string>();
            List<string> empleado = new List<string>();
            List<string> result = new List<string>();

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

            if (isGood) 
            {
                result.Add("True");
            } else 
            {
                result.Add("False");
            }

            all.Add(login);
            all.Add(info);
            all.Add(empleado);
            all.Add(result);
            
            return all.ToArray();
        }
        
        // Clear fields for new user panel
        private void ClearFieldsNewUser()
        {
            isGood = false;
            txtBox_newUser_user.Text = "ingrese el usuario";
            txtBox_newUser_pass.Text = "Ingrese la contraseña";
            comboBox_privileges.SelectedIndex = -1;

            txtBox_newUser_nombre.Text = "Ingrese el nombre";
            txtBox_newUser_nombreCorto.Text = "Ingrese el nombre corto/apodo";
            txtBox_newUser_ciudad.Text = "Ingrese la ciudad natal";
            txtBox_newUser_email.Text = "Ingrese el email";

            txtBox_newUser_nombreEmpleado.Text = "Ingrese el nombre del sistema (Ej: Mati A.)";
        }

        private bool ValidateOlderPassword(string password)
        {
            return false;
            //return UtilitiesCommon.layerBusiness.cn_usuarios.verificarPassword(UserLoginCache.IdUser, password);
        }
    
        private void LoadAccessPrivileges()
        {
            /*if (UserLoginCache.Priveleges == Privileges.Administrador)
            {
                // Code here activate or desactive functions
                //panel_newTramite.Enabled = true;
                //panel_newFormulario.Enabled = true;
                if (UserLoginCache.isRoot == 1)
                {
                    panel_newUser.Enabled = true;
                }
            }*/
        }
                                
        // Panel New User
        // Insert to database
        private void btn_newUser_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Estas seguro que deseas añadir un nuevo usuario al sistema?" + "\nUsuario nuevo: " + txtBox_newUser_nombre.Text, "Atencion!", MessageBoxButtons.YesNo) == DialogResult.Yes) 
            {
                if(MessageBox.Show("¿Acepta los terminos y condiciones de uso?" + "\n Sistemas MiRegistro desarrollado en infraestructuras de Microsoft Azure.", "MiRegistro", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK) 
                {
                    List<string>[] data = InitializeDataFromNewUser();
                    if (data[3][0] == "True")
                    {
                        // Add user
                        //UtilitiesCommon.layerBusiness.cn_usuarios.AddUser(data);
                        frm_successdialog frm = new frm_successdialog(7);
                        frm.Show();

                        ClearFieldsNewUser();
                    } else
                    {
                        MessageBox.Show("Verifique los datos ingresados y vuelva a intentarlo!", "Error 104!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        
        // Login info
        private void txtBox_newUser_user_Enter(object sender, EventArgs e)
        {
            if (txtBox_newUser_user.Text == "ingrese el usuario")
            {
                txtBox_newUser_user.ForeColor = System.Drawing.Color.Black;
                txtBox_newUser_user.Text = "";

                pic_0.Visible = false;
            } 
        }
        private void txtBox_newUser_user_Leave(object sender, EventArgs e)
        {
            if (txtBox_newUser_user.Text == "")
            {
                txtBox_newUser_user.ForeColor = System.Drawing.Color.LightGray;
                txtBox_newUser_user.Text = "ingrese el usuario";

                isGood = false;
            }
            else
            {
                if (txtBox_newUser_user.Text.Length > 7)
                {
                    pic_0.Visible = true;
                    pic_0.BackgroundImage = check;

                    isGood = true;
                } else 
                {
                    pic_0.Visible = true;
                    pic_0.BackgroundImage = checkOff;

                    isGood = false;
                    MessageBox.Show("El usuario debe ser mayor o igual a 8 caracteres y no debe contener espacios!", "Atencion!");
                }
            }
        }
        private void txtBox_newUser_user_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }
        private void txtBox_newUser_pass_Enter(object sender, EventArgs e)
        {
            if (txtBox_newUser_pass.Text == "Ingrese la contraseña")
            {
                txtBox_newUser_pass.ForeColor = System.Drawing.Color.Black;
                txtBox_newUser_pass.Text = "";
                txtBox_newUser_pass.UseSystemPasswordChar = true;
            }
        }
        private void txtBox_newUser_pass_Leave(object sender, EventArgs e)
        {
            if (txtBox_newUser_pass.Text == "")
            {
                txtBox_newUser_pass.ForeColor = System.Drawing.Color.LightGray;
                txtBox_newUser_pass.Text = "Ingrese la contraseña";
                txtBox_newUser_pass.UseSystemPasswordChar = false;

                pic_1.Visible = false;

                isGood = false;
            }
            else
            {
                if (txtBox_newUser_pass.Text.Length > 4)
                {
                    pic_1.Visible = true;
                    pic_1.BackgroundImage = check;

                    isGood = true;
                }
                else
                {
                    pic_1.Visible = true;
                    pic_1.BackgroundImage = checkOff;

                    isGood = false;
                    MessageBox.Show("La contraseña debe ser mayor que 5 (cinco) caracteres!", "Atencion!");
                }
            }
        }
        private void txtBox_newUser_pass_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }
        private void comboBox_privileges_Enter(object sender, EventArgs e)
        {
            if (comboBox_privileges.SelectedIndex < 0)
            {
                comboBox_privileges.ForeColor = System.Drawing.Color.Black;
                comboBox_privileges.SelectedIndex = 1;
            }
        }
        private void comboBox_privileges_Leave(object sender, EventArgs e)
        {
            if (comboBox_privileges.SelectedIndex < 0)
            {
                comboBox_privileges.ForeColor = System.Drawing.Color.LightGray;
                comboBox_privileges.SelectedIndex = 1;
            }
        }
        
        // Info user
        private void txtBox_newUser_nombre_Enter(object sender, EventArgs e)
        {
            if (txtBox_newUser_nombre.Text == "Ingrese el nombre")
            {
                txtBox_newUser_nombre.ForeColor = System.Drawing.Color.Black;
                txtBox_newUser_nombre.Text = "";
            }
        }
        private void txtBox_newUser_nombre_Leave(object sender, EventArgs e)
        {
            if (txtBox_newUser_nombre.Text == "")
            {
                txtBox_newUser_nombre.ForeColor = System.Drawing.Color.LightGray;
                txtBox_newUser_nombre.Text = "Ingrese el nombre";
            }
        }
        private void txtBox_newUser_nombreCorto_Enter(object sender, EventArgs e)
        {
            if (txtBox_newUser_nombreCorto.Text == "Ingrese el nombre corto/apodo")
            {
                txtBox_newUser_nombreCorto.ForeColor = System.Drawing.Color.Black;
                txtBox_newUser_nombreCorto.Text = "";
            }
        }
        private void txtBox_newUser_nombreCorto_Leave(object sender, EventArgs e)
        {
            if (txtBox_newUser_nombreCorto.Text == "")
            {
                txtBox_newUser_nombreCorto.ForeColor = System.Drawing.Color.LightGray;
                txtBox_newUser_nombreCorto.Text = "Ingrese el nombre corto/apodo";
            }
        }
        private void txtBox_newUser_ciudad_Enter(object sender, EventArgs e)
        {
            if (txtBox_newUser_ciudad.Text == "Ingrese la ciudad natal")
            {
                txtBox_newUser_ciudad.ForeColor = System.Drawing.Color.Black;
                txtBox_newUser_ciudad.Text = "";
            }
        }
        private void txtBox_newUser_ciudad_Leave(object sender, EventArgs e)
        {
            if (txtBox_newUser_ciudad.Text == "")
            {
                txtBox_newUser_ciudad.ForeColor = System.Drawing.Color.LightGray;
                txtBox_newUser_ciudad.Text = "Ingrese la ciudad natal";
            }
        }
        private void txtBox_newUser_email_Enter(object sender, EventArgs e)
        {
            if (txtBox_newUser_email.Text == "Ingrese el email")
            {
                txtBox_newUser_email.ForeColor = System.Drawing.Color.Black;
                txtBox_newUser_email.Text = "";

                pic_2.Visible = false;
            }
        }
        private void txtBox_newUser_email_Leave(object sender, EventArgs e)
        {
            if (txtBox_newUser_email.Text == "")
            {
                txtBox_newUser_email.ForeColor = System.Drawing.Color.LightGray;
                txtBox_newUser_email.Text = "Ingrese el email";

                pic_2.Visible = false;

                isGood = false;
            }
            else
            {
                if (UtilitiesCommon.IsValidEmail(txtBox_newUser_email.Text))
                {
                    pic_2.Visible = true;
                    pic_2.BackgroundImage = check;

                    isGood = true;
                }
                else
                {
                    pic_2.Visible = true;
                    pic_2.BackgroundImage = checkOff;

                    isGood = false;
                    MessageBox.Show("Introduce un email valido '@outlook @gmail @yahoo @hotmail' para continuar!", "Atencion!");
                }
            }
        }
        private void txtBox_newUser_nombreEmpleado_Enter(object sender, EventArgs e)
        {
            if (txtBox_newUser_nombreEmpleado.Text == "Ingrese el nombre del sistema (Ej: Mati A.)")
            {
                txtBox_newUser_nombreEmpleado.ForeColor = System.Drawing.Color.Black;
                txtBox_newUser_nombreEmpleado.Text = "";
            }
        }
        private void txtBox_newUser_nombreEmpleado_Leave(object sender, EventArgs e)
        {
            if (txtBox_newUser_nombreEmpleado.Text == "")
            {
                txtBox_newUser_nombreEmpleado.ForeColor = System.Drawing.Color.LightGray;
                txtBox_newUser_nombreEmpleado.Text = "Ingrese el nombre del sistema (Ej: Mati A.)";

                pic_3.Visible = false;

                isGood = false;
            }
            else
            {
                if (txtBox_newUser_nombreEmpleado.Text.Length > 4)
                {
                    pic_3.Visible = true;
                    pic_3.BackgroundImage = check;

                    isGood = true;
                }
                else
                {
                    pic_3.Visible = true;
                    pic_3.BackgroundImage = checkOff;

                    isGood = false;
                    MessageBox.Show("El nombre del empleado debe contener al menos 4 caracteres y con el siguiente formato: (Ej: Nombre S.)!", "Atencion!");
                }
            }
        }
        
          
        private void frm_configuracion_Load(object sender, EventArgs e)
        {
            LoadUserInformation();
            LoadAccessPrivileges();
        }

        private void txtBox_usuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }

        private void txtBox_nick_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }

        private void txtBox_correo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }
    }
}
