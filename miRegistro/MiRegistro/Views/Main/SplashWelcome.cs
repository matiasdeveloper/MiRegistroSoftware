using MiRegistro.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiRegistro.Views.Main
{
    public partial class SplashWelcome : Form
    {
        protected WelcomeController oWelcomeController;
        public SplashWelcome(string user)
        {
            InitializeComponent();
            oWelcomeController = new WelcomeController(this);
        }

        public int countTimer = 0;
        public int imageToSplash = 0;
        public int totalImageToSplash = 2;
    }
}
