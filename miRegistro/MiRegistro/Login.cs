﻿using Controllers;
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

        public Login()
        {
            InitializeComponent();
            oLoginController = new LoginController(this);
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            
        }
    }
}
