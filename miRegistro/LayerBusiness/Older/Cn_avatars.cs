using LayerSoporte.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerBusiness
{
    public class Cn_avatars
    {
        public BitmapAvatar avatarClass;
        public BitMap bm;

        public Cn_avatars() 
        {
            avatarClass = new BitmapAvatar();
        }

        public void chargeAvatarsCache()
        {
            this.bm = new BitMap();
            this.avatarClass.setAvatars();
        }

        public BitMap GetBitMap() 
        {
            this.bm = this.avatarClass.GetBitMap();
            return bm;
        }
    }
}
