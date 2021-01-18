using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace LayerPresentation.Clases
{
    public static class Utilities
    {
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

        public static Label FindLabelInForm(Form s, string label) 
        {
            Control[] ctrl = s.Controls.Find(label, true);
            Label lbl = ctrl[0] as Label;
            return lbl;
        }

    }
}
