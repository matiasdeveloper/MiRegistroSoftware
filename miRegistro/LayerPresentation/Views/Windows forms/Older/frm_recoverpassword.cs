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
    public partial class frm_recoverpassword : Form
    {

        public frm_recoverpassword()
        {
            InitializeComponent();
        }

        #region Variables
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        #endregion

        private void btn_send_Click(object sender, EventArgs e)
        {
            if(txtUserRequest.Text != "Introduzca el usuario aqui" && textBox_userAnswer.Text != "Introduzca la respuesta aqui") 
            {
                if (VerificarRespuestaSeguridad())
                {
                    //var user = new Cn_Usuarios();
                    //var result = user.RecoverPassword(txtUserRequest.Text);
                    /*if (result.Item1)
                    {
                        frm_successdialog f = new frm_successdialog(4);
                        f.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error al enviar el email \nComuniquese con el usuario root o vuelva a intentarlo", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }*/
                }
                else
                {
                    MessageBox.Show("Usuario o respuesta de seguridad incorrectas! Verifique e intente nuevamente!");
                }
            } 
            else 
            {
                MessageBox.Show("Complete los datos para iniciar la recuperacion.", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool VerificarRespuestaSeguridad() 
        {
            bool r = true;

            return r;
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Punto 1: La recuperacion es mediante el correo electronico y la seguridad adiccional es la respuesta de seguridad." 
                            + "\nPunto 2: Si olvido la contraseña y no recuerda o el email/contraseña debera comunicarse con el usuario Root para la respectiva recuperacion." 
                            + "\nPunto 3: El usuario root es el unico capas de recuperar cualquier cuenta. Por seguridad se le sugiere comunicarse con esa persona para que mediante el acceso al sistema recupere la cuenta." 
                            , "Informacion adicional", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MessageBox.Show("Muchas gracias y sepa entender que son pasos de seguridad!", "miRegistro sistema", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        private void btn_close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void barra_titulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void Login_recoverPassword_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Login_recoverPassword_Load(object sender, EventArgs e)
        {

        }

        private void textBox_userAnswer_Enter(object sender, EventArgs e)
        {
            if (textBox_userAnswer.Text == "Introduzca la respuesta aqui")
            {
                textBox_userAnswer.Text = "";
                textBox_userAnswer.ForeColor = System.Drawing.Color.LightCyan;
            }
        }

        private void textBox_userAnswer_Leave(object sender, EventArgs e)
        {
            if (textBox_userAnswer.Text == "")
            {
                textBox_userAnswer.Text = "Introduzca la respuesta aqui";
                textBox_userAnswer.ForeColor = System.Drawing.Color.DarkGray;
            }
        }

        private void txtUserRequest_Enter(object sender, EventArgs e)
        {
            if (txtUserRequest.Text == "Introduzca el usuario aqui")
            {
                txtUserRequest.Text = "";
                txtUserRequest.ForeColor = System.Drawing.Color.LightCyan;
            }
        }
        private void txtUserRequest_Leave(object sender, EventArgs e)
        {
            if (txtUserRequest.Text == "")
            {
                txtUserRequest.Text = "Introduzca el usuario aqui";
                txtUserRequest.ForeColor = System.Drawing.Color.DarkGray;
            }
        }
    }
}
