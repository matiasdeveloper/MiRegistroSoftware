using Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiRegistro
{
    public partial class Login : Form
    {
        protected LoginController oLoginController;
        public int dataToShow = 1;
        public int totalDataToShow = 3;

        public Login()
        {
            InitializeComponent();
            oLoginController = new LoginController(this);
        }

        private void txtBox_pass_Enter(object sender, EventArgs e)
        {
            if (txtBox_pass.Text == "8 caracteres o mas")
            {
                txtBox_pass.Text = "";
                txtBox_pass.PasswordChar = '*';
            } 
        }
        private void txtBox_pass_Leave(object sender, EventArgs e)
        {
            if (txtBox_pass.Text == "")
            {
                txtBox_pass.PasswordChar = (char)0;
                txtBox_pass.Text = "8 caracteres o mas";
            }
        }
    }
}
