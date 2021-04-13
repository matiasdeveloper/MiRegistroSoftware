using LayerBusiness;
using LayerPresentation.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayerPresentation
{
    public partial class frm_configuracion_empleado : Form
    {
        // Move form with mouse down in bar
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        public frm_configuracion_empleado(int id, List<string> user, List<string> info, List<string> empleado)
        {
            InitializeComponent();

            this.id = id;
            this.user = user;
            this.info = info;
            this.empleado = empleado;

            InitializeData();
        }

        private int id;
        List<string> user;
        List<string> info;
        List<string> empleado;

        private bool isGood = true;
        private Image check = LayerPresentation.Properties.Resources.r_negative;
        private Image checkOff = LayerPresentation.Properties.Resources.r_negative;

        private void InitializeData() 
        {
            txtBox_newUser_user.Text = user[0];
            txtBox_newUser_pass.Text = "sininformacion";

            comboBox_privileges.SelectedIndex = Convert.ToInt32(user[2]);

            txtBox_newUser_nombre.Text = info[0];
            txtBox_newUser_nombreCorto.Text = info[1];
            txtBox_newUser_ciudad.Text = info[2];
            txtBox_newUser_email.Text = info[3];

            txtBox_newUser_nombreEmpleado.Text = empleado[0];
            txtBox_newUser_salario.Text = empleado[1];
            txtBox_newUser_observaciones.Text = empleado[2];
        }
        private void ClearFields(int id) 
        {
            switch (id) 
            {
                case 0:
                    txtBox_newUser_user.Text = user[0];
                    txtBox_newUser_pass.Text = "sininformacion";
                    txtBox_newUser_pass.ForeColor = System.Drawing.Color.LightGray;
                    break;
                case 1:
                    txtBox_newUser_nombre.Text = info[0];
                    txtBox_newUser_nombreCorto.Text = info[1];
                    txtBox_newUser_ciudad.Text = info[2];
                    txtBox_newUser_email.Text = info[3];
                    break;
                case 2:
                    txtBox_newUser_nombreEmpleado.Text = empleado[0];
                    txtBox_newUser_salario.Text = empleado[1];
                    txtBox_newUser_observaciones.Text = empleado[2];
                    break;
                default:
                    InitializeData();
                    break;
            }
        }
        
        private string[] InitializeUser() 
        {
            List<string> data = new List<string>();
            data.Add(txtBox_newUser_user.Text);
            user[0] = txtBox_newUser_user.Text;

            data.Add(txtBox_newUser_pass.Text);

            if(comboBox_privileges.SelectedIndex == 1) 
            {
                data.Add("Estandar");
                user[2] = "1";

            }
            else 
            {
                data.Add("Administrador");
                user[2] = "0";

            }

            if (checkBox_privileges.Checked) 
            {
                data.Add("1");
            } else 
            {
                data.Add("0");
            }
            return data.ToArray();
        }
        private string[] InitializeInfo() 
        {
            List<string> data = new List<string>();
            data.Add(txtBox_newUser_nombre.Text);
            data.Add(txtBox_newUser_nombreCorto.Text);
            data.Add(txtBox_newUser_ciudad.Text);
            data.Add(txtBox_newUser_email.Text);
            data.Add(dtPick_newUser_fechaNacimiento.Value.ToString("MM/dd/yyyy"));

            info[0] = txtBox_newUser_nombre.Text;
            info[1] = txtBox_newUser_nombreCorto.Text;
            info[2] = txtBox_newUser_ciudad.Text;
            info[3] = txtBox_newUser_email.Text;

            return data.ToArray();
        }
        private string[] InitializeEmpleado() 
        {
            List<string> data = new List<string>();
            data.Add(dtPick_newUser_contratacion.Value.ToString("MM/dd/yyyy"));
            data.Add(txtBox_newUser_salario.Text);
            data.Add(txtBox_newUser_observaciones.Text);

            empleado[1] = txtBox_newUser_salario.Text;
            empleado[2] = txtBox_newUser_observaciones.Text;

            return data.ToArray();
        }
        
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        
        // Update click
        private void btn_updatauser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que deseas actualizar la informacion de sesion?" + "\nUsuario: " + txtBox_newUser_nombre.Text, "Atencion!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (isGood && txtBox_newUser_pass.Text != "sininformacion") 
                {
                    string[] data = InitializeUser();
                    // Update user sesion
<<<<<<< HEAD:miRegistro/LayerPresentation/Windows forms/Older/frm_configuracion_empleado.cs
                    //UtilitiesCommon.layerBusiness.cn_usuarios.UpdateUserData(id, data);
=======
                    Utilities_Common.layerBusiness.cn_usuarios.UpdateUserData(id, data);
>>>>>>> 53e7dd443230e3e11d0379924015b683904fdb8a:miRegistro/LayerPresentation/Form/Otros/frm_configuracion_empleado.cs
                    frm_successdialog frm = new frm_successdialog(8);
                    frm.Show();

                    ClearFields(0);
                }
                else
                {
                    MessageBox.Show("Ingrese correctamente los datos!", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btn_updateinfo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que deseas actualizar la informacion?" + "\nUsuario: " + txtBox_newUser_nombre.Text, "Atencion!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (isGood) 
                {
                    string[] data = InitializeInfo();
                    // Update user info
<<<<<<< HEAD:miRegistro/LayerPresentation/Windows forms/Older/frm_configuracion_empleado.cs
                    //UtilitiesCommon.layerBusiness.cn_usuarios.UpdateUserInfo(id, data);
=======
                    Utilities_Common.layerBusiness.cn_usuarios.UpdateUserInfo(id, data);
>>>>>>> 53e7dd443230e3e11d0379924015b683904fdb8a:miRegistro/LayerPresentation/Form/Otros/frm_configuracion_empleado.cs
                    frm_successdialog frm = new frm_successdialog(8);
                    frm.Show();

                    ClearFields(1);
                }
                else
                {
                    MessageBox.Show("Ingrese correctamente los datos!", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btn_updateempleado_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que deseas actualizar la informacion de empleado?" + "\nEmpleado: " + txtBox_newUser_nombreEmpleado.Text, "Atencion!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string[] data = InitializeEmpleado();
                // Update user empleado
<<<<<<< HEAD:miRegistro/LayerPresentation/Windows forms/Older/frm_configuracion_empleado.cs
                //UtilitiesCommon.layerBusiness.cn_usuarios.UpdateUserEmpleado(id, data);
=======
                Utilities_Common.layerBusiness.cn_usuarios.UpdateUserEmpleado(id, data);
>>>>>>> 53e7dd443230e3e11d0379924015b683904fdb8a:miRegistro/LayerPresentation/Form/Otros/frm_configuracion_empleado.cs
                frm_successdialog frm = new frm_successdialog(8);
                frm.Show();
            }
        }
        
        // Events enter & leave
        private void txtBox_newUser_user_Enter(object sender, EventArgs e)
        {
            if (txtBox_newUser_user.Text == user[0])
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
                txtBox_newUser_user.Text = user[0];

                isGood = false;
            }
            else
            {
                if (txtBox_newUser_user.Text.Length > 7)
                {
                    pic_0.Visible = true;
                    pic_0.BackgroundImage = check;

                    isGood = true;
                }
                else
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
            if (txtBox_newUser_pass.Text == "sininformacion")
            {
                txtBox_newUser_pass.ForeColor = System.Drawing.Color.Black;
                txtBox_newUser_pass.Text = "";
                txtBox_newUser_pass.UseSystemPasswordChar = true;

                pic_1.Visible = false;

                isGood = false;
            }
        }
        private void txtBox_newUser_pass_Leave(object sender, EventArgs e)
        {
            if (txtBox_newUser_pass.Text == "")
            {
                txtBox_newUser_pass.ForeColor = System.Drawing.Color.LightGray;
                txtBox_newUser_pass.Text = "sininformacion";
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

        private void comboBox_privileges_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_privileges.SelectedIndex == 0)
            {
                checkBox_privileges.Enabled = true;
                checkBox_privileges.Checked = false;
            }
            else
            {
                checkBox_privileges.Checked = false;
                checkBox_privileges.Enabled = false;
            }
        }

        private void txtBox_newUser_nombre_Enter(object sender, EventArgs e)
        {
            if (txtBox_newUser_nombre.Text == info[0])
            {
                txtBox_newUser_nombre.ForeColor = System.Drawing.Color.Black;
                txtBox_newUser_nombre.Text = "";

                isGood = true;
            }
        }
        private void txtBox_newUser_nombre_Leave(object sender, EventArgs e)
        {
            if (txtBox_newUser_nombre.Text == "")
            {
                txtBox_newUser_nombre.ForeColor = System.Drawing.Color.LightGray;
                txtBox_newUser_nombre.Text = info[0];

                isGood = true;
            }
            else
            {
                if (txtBox_newUser_nombre.Text == info[0])
                {
                    isGood = true;
                }
            }
        }
        private void txtBox_newUser_nombreCorto_Enter(object sender, EventArgs e)
        {
            if (txtBox_newUser_nombreCorto.Text == info[1])
            {
                txtBox_newUser_nombreCorto.ForeColor = System.Drawing.Color.Black;
                txtBox_newUser_nombreCorto.Text = "";

                isGood = true;
            }
        }
        private void txtBox_newUser_nombreCorto_Leave(object sender, EventArgs e)
        {
            if (txtBox_newUser_nombreCorto.Text == "")
            {
                txtBox_newUser_nombreCorto.ForeColor = System.Drawing.Color.LightGray;
                txtBox_newUser_nombreCorto.Text = info[1];

                isGood = true;
            }
            else
            {
                if (txtBox_newUser_nombreCorto.Text == info[1])
                {
                    isGood = true;
                }
            }
        }

        private void txtBox_newUser_ciudad_Enter(object sender, EventArgs e)
        {
            if (txtBox_newUser_ciudad.Text == info[2])
            {
                txtBox_newUser_ciudad.ForeColor = System.Drawing.Color.Black;
                txtBox_newUser_ciudad.Text = "";

                isGood = true;
            }
        }
        private void txtBox_newUser_ciudad_Leave(object sender, EventArgs e)
        {
            if (txtBox_newUser_ciudad.Text == "")
            {
                txtBox_newUser_ciudad.ForeColor = System.Drawing.Color.LightGray;
                txtBox_newUser_ciudad.Text = info[2];

                isGood = true;
            }
            else
            {
                if (txtBox_newUser_ciudad.Text == info[2])
                {
                    isGood = true;
                }
            }
        }

        private void txtBox_newUser_email_Enter(object sender, EventArgs e)
        {
            if (txtBox_newUser_email.Text == info[3])
            {
                txtBox_newUser_email.ForeColor = System.Drawing.Color.Black;
                txtBox_newUser_email.Text = "";

                pic_2.Visible = false;

                isGood = true;
            }
        }
        private void txtBox_newUser_email_Leave(object sender, EventArgs e)
        {
            if (txtBox_newUser_email.Text == "")
            {
                txtBox_newUser_email.ForeColor = System.Drawing.Color.LightGray;
                txtBox_newUser_email.Text = info[3];

                pic_2.Visible = false;
            }
            else
            {
                if (IsValidEmail(txtBox_newUser_email.Text))
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

        private void txtBox_newUser_observaciones_Enter(object sender, EventArgs e)
        {
            if (txtBox_newUser_observaciones.Text == empleado[2])
            {
                txtBox_newUser_observaciones.ForeColor = System.Drawing.Color.Black;
                txtBox_newUser_observaciones.Text = "";
            }
        }
        private void txtBox_newUser_observaciones_Leave(object sender, EventArgs e)
        {
            if (txtBox_newUser_observaciones.Text == "")
            {
                txtBox_newUser_observaciones.ForeColor = System.Drawing.Color.LightGray;
                txtBox_newUser_observaciones.Text = empleado[2];
            }
        }

        private void txtBox_newUser_salario_Enter(object sender, EventArgs e)
        {
            if (txtBox_newUser_salario.Text == empleado[1])
            {
                txtBox_newUser_salario.ForeColor = System.Drawing.Color.Black;
                txtBox_newUser_salario.Text = "";
            }
        }
        private void txtBox_newUser_salario_Leave(object sender, EventArgs e)
        {
            if (txtBox_newUser_salario.Text == "")
            {
                txtBox_newUser_salario.ForeColor = System.Drawing.Color.LightGray;
                txtBox_newUser_salario.Text = empleado[1];
            }
        }
        
        private void barra_titulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void label50_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
