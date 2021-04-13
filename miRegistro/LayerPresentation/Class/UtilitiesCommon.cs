using LayerBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayerPresentation.Clases
{
    public static class UtilitiesCommon
    {
        public static bool IsValidEmail(string email)
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
        /// <summary>
        /// In Textbox Prevent Only Numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void OnlyNumbers(object sender, KeyPressEventArgs e) 
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);

            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }
        public static double CalculatePercentage(int total, int value)
        {
            float percentage = 0;
            if (total > 0 & value > 0)
            {
                percentage = (value * 100) / total;
            }
            var vOut = Math.Round(percentage, 0);
            return vOut;
        }
        public static double CalculateDifferencePercentage(int val1, int val2)
        {
            float percentage = 0;
            if (val1 > 0 & val2 > 0)
            {
                double diff = val1 - val2;
                double val = (val1 + val2) / 2;
                percentage = (float)(diff / val) * 100;
            }
            return percentage;
        }
        public static Label FindLabelInForm(Form s, string label)
        {
            Control[] ctrl = s.Controls.Find(label, true);
            Label lbl = ctrl[0] as Label;
            return lbl;
        }
    }
}
