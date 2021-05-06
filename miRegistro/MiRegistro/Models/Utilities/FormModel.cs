using MiRegistro.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace MiRegistro.Models
{
    public class FormModel
    {
        public Bitmap GetImageResource(string prefix, int num)
        {
            ResourceManager rm = Resources.ResourceManager;
            string routeImage = prefix + num;
            return (Bitmap)rm.GetObject(routeImage);
        }
    }
}
