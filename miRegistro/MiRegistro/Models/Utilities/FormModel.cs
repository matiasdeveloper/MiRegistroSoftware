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
    public class FormModel
    {
        private ObjectCache cacheUser = MemoryCache.Default;

        public Bitmap GetImageResource(string prefix, int num)
        {
            ResourceManager rm = Resources.ResourceManager;
            string routeImage = prefix + num;
            return (Bitmap)rm.GetObject(routeImage);
        }

        public void SetCacheUser(UserTableViewModel usuario)
        {
            CacheItemPolicy policy = new CacheItemPolicy();
            // Indicamos la prioridad de la politica.
            policy.Priority = CacheItemPriority.Default;

            cacheUser.Set("DataUser", usuario, policy);
        }

        public UserTableViewModel GetCacheUser() 
        {
            // Obtenemos los datos de la cache.
            UserTableViewModel user = cacheUser["DataUser"] as UserTableViewModel;
            // Si lo que obtenemos es nulo, es porque 
            // no hay datos cargamos en la cache.
            if (user != null)
            {
                return user;
            }
            return null;
        }
    }
}
