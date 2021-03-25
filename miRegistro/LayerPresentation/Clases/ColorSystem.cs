using LayerPresentation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ColorSystem
{
    public static frm_principal frm;
    public static Color positive;
    public static Color negative;

    public static void ChangeColor(Color color) 
    {
        LayerPresentation.Properties.Settings.Default.Color = color;
        LayerPresentation.Properties.Settings.Default.Save();
       // frm.LoadUserColor(color);
    }

    public static Color GetPositive() 
    {
        positive = new Color();
        positive = Color.FromArgb(1, 21, 155, 18);
        return positive;
    }
    public static Color GetNegative()
    {
        negative = new Color();
        negative = Color.FromArgb(1, 233, 64, 64);
        return negative;
    }
}
