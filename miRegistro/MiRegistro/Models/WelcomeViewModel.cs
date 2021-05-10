using MiRegistro.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MiRegistro.Models
{
    public class WelcomeViewModel
    {
        public void SetTermConditionStatus(bool status)
        {
            MiRegistro.Properties.Settings.Default.termsandconditions = status;
            MiRegistro.Properties.Settings.Default.Save();
        }
        public bool GetTermConditionStatus()
        {
            return MiRegistro.Properties.Settings.Default.termsandconditions;
        }
    }
}
