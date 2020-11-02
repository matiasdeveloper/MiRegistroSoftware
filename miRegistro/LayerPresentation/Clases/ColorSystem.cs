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

    public static void ChangeColor(Color color) 
    {
        LayerPresentation.Properties.Settings.Default.Color = color;
        LayerPresentation.Properties.Settings.Default.Save();
        frm.cargarColor(color);
    }
}
