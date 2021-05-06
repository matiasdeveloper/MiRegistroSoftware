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
        private ObjectCache cacheUser = MemoryCache.Default;

        public void SetTermConditionStatus(bool status)
        {
            MiRegistro.Properties.Settings.Default.termsandconditions = status;
            MiRegistro.Properties.Settings.Default.Save();
        }
        public bool GetTermConditionStatus()
        {
            return MiRegistro.Properties.Settings.Default.termsandconditions;
        }
        public void SetCacheUser(UserTableViewModel usuario) 
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            // Indicamos la prioridad de la politica.
            policy.Priority = CacheItemPriority.Default;

            cacheUser.Set("DataUser", usuario, policy);
        }
    }
}
