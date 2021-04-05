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
