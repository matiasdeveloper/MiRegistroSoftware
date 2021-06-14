using MiRegistro.Views.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers
{
    public class DialogController
    {
        private Dialog _view;

        public DialogController(Dialog view)
        {
            this._view = view;

            _view.btn_success.Click += new EventHandler(OnClickSuccess);
            _view.btn_error.Click += new EventHandler(OnClickError);

            OnLoad();
        }

        private void OnClickError(object sender, EventArgs e)
        {
            // Exit and send information to database logs
            _view.Close();
        }

        private void OnClickSuccess(object sender, EventArgs e)
        {
            // Exit and send information to database logs
            _view.Close();
        }

        public void OnLoad()
        {
            if (_view.result == DialogResult.Sucess) 
            {
                _view.pn_success.Visible = true;
                _view.lbl_success_message.Text = _view.message;         
            } 
            if(_view.result == DialogResult.Fail) 
            {
                _view.pn_fail.Visible = true;
                _view.lbl_error_message.Text = _view.message;
            }
        }
    }
}
