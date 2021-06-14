using LayerPresentation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ColorSystem
{
    public static System.Drawing.Color positive;
    public static System.Drawing.Color negative;

    public static System.Drawing.Color GetPositive() 
    {
        positive = new System.Drawing.Color();
        positive = System.Drawing.Color.FromArgb(1, 21, 155, 18);
        return positive;
    }
    public static System.Drawing.Color GetNegative()
    {
        negative = new System.Drawing.Color();
        negative = System.Drawing.Color.FromArgb(1, 233, 64, 64);
        return negative;
    }
}
