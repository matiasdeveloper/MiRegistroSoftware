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
using Controllers;

public enum DialogResult
{
    Sucess,
    Fail,
    None
}

namespace MiRegistro.Views.Common
{
    public partial class Dialog : Form
    {
        private DialogController oDialogController;
        public DialogResult result = global::DialogResult.Sucess;
        public string message;

        public Dialog(DialogResult result, string message)
        {
            InitializeComponent();

            this.result = result;
            this.message = message;

            oDialogController = new DialogController(this);
        }
    }
}
