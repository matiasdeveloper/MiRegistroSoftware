using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LayerSoporte.Cache
{
    public struct BitMap
    {
        public Bitmap Avatar0;
        public Bitmap Avatar1;
        public Bitmap Avatar2;
        public Bitmap Avatar3;
        public Bitmap Avatar4;
        public Bitmap Avatar5;
        public Bitmap Avatar6;
        public Bitmap Avatar7;
        public Bitmap Avatar8;
        public Bitmap Avatar9;
        public Bitmap Avatar10;
        public Bitmap Avatar11;
        public Bitmap Avatar12;
        public Bitmap Avatar13;
        public Bitmap Avatar14;
        public Bitmap Avatar15;
        public Bitmap Avatar16;
        public Bitmap Avatar17;
        public Bitmap Avatar18;
        public Bitmap Avatar19;
        public Bitmap Avatar20;
        public Bitmap Avatar21;
        public Bitmap Avatar22;
        public Bitmap Avatar23;
        public Bitmap Avatar24;
        public Bitmap Avatar25;
        public Bitmap Avatar26;
        public Bitmap Avatar27;
        public Bitmap Avatar28;
        public Bitmap Avatar29;
        public Bitmap Avatar30;
        public Bitmap Avatar31;
        public Bitmap Avatar32;
        public Bitmap Avatar33;
        public Bitmap Avatar34;
        public Bitmap Avatar35;
        public Bitmap Avatar36;
        public Bitmap Avatar37;
        public Bitmap Avatar38;
        public Bitmap Avatar39;
        public Bitmap Avatar40;
        public Bitmap Avatar41;
        public Bitmap Avatar42;
        public Bitmap Avatar43;
        public Bitmap Avatar44;
        public Bitmap Avatar45;
        public Bitmap Avatar46;
        public Bitmap Avatar47;
        public Bitmap Avatar48;
        public Bitmap Avatar49;
    }

    public class BitmapAvatar
    {
        public BitMap myAvatars;

        /// <summary>
        /// Initialize the image avatars, get and set images
        /// </summary>
        
        public void setAvatars()
        {
            myAvatars = new BitMap();

            myAvatars.Avatar0 = LayerSoporte.Properties.Resources._001;
            myAvatars.Avatar1 = LayerSoporte.Properties.Resources._002;
            myAvatars.Avatar2 = LayerSoporte.Properties.Resources._003;
            myAvatars.Avatar3 = LayerSoporte.Properties.Resources._004;
            myAvatars.Avatar4 = LayerSoporte.Properties.Resources._005;
            myAvatars.Avatar5 = LayerSoporte.Properties.Resources._006;
            myAvatars.Avatar6 = LayerSoporte.Properties.Resources._007;
            myAvatars.Avatar7 = LayerSoporte.Properties.Resources._008;
            myAvatars.Avatar8 = LayerSoporte.Properties.Resources._009;
            myAvatars.Avatar9 = LayerSoporte.Properties.Resources._010;
            myAvatars.Avatar10 = LayerSoporte.Properties.Resources._011;
            myAvatars.Avatar11 = LayerSoporte.Properties.Resources._012;
            myAvatars.Avatar12 = LayerSoporte.Properties.Resources._013;
            myAvatars.Avatar13 = LayerSoporte.Properties.Resources._014;
            myAvatars.Avatar14 = LayerSoporte.Properties.Resources._015;
            myAvatars.Avatar15 = LayerSoporte.Properties.Resources._016;
            myAvatars.Avatar16 = LayerSoporte.Properties.Resources._017;
            myAvatars.Avatar17 = LayerSoporte.Properties.Resources._018;
            myAvatars.Avatar18 = LayerSoporte.Properties.Resources._019;
            myAvatars.Avatar19 = LayerSoporte.Properties.Resources._020;
            myAvatars.Avatar20 = LayerSoporte.Properties.Resources._021;
            myAvatars.Avatar21 = LayerSoporte.Properties.Resources._022;
            myAvatars.Avatar22 = LayerSoporte.Properties.Resources._023;
            myAvatars.Avatar23 = LayerSoporte.Properties.Resources._024;
            myAvatars.Avatar24 = LayerSoporte.Properties.Resources._025;
            myAvatars.Avatar25 = LayerSoporte.Properties.Resources._026;
            myAvatars.Avatar26 = LayerSoporte.Properties.Resources._027;
            myAvatars.Avatar27 = LayerSoporte.Properties.Resources._028;
            myAvatars.Avatar28 = LayerSoporte.Properties.Resources._029;
            myAvatars.Avatar29 = LayerSoporte.Properties.Resources._030;
            myAvatars.Avatar30 = LayerSoporte.Properties.Resources._031;
            myAvatars.Avatar31 = LayerSoporte.Properties.Resources._032;
            myAvatars.Avatar32 = LayerSoporte.Properties.Resources._033;
            myAvatars.Avatar33 = LayerSoporte.Properties.Resources._034;
            myAvatars.Avatar34 = LayerSoporte.Properties.Resources._035;
            myAvatars.Avatar35 = LayerSoporte.Properties.Resources._036;
            myAvatars.Avatar36 = LayerSoporte.Properties.Resources._037;
            myAvatars.Avatar37 = LayerSoporte.Properties.Resources._038;
            myAvatars.Avatar38 = LayerSoporte.Properties.Resources._039;
            myAvatars.Avatar39 = LayerSoporte.Properties.Resources._040;
            myAvatars.Avatar40 = LayerSoporte.Properties.Resources._041;
            myAvatars.Avatar41 = LayerSoporte.Properties.Resources._042;
            myAvatars.Avatar42 = LayerSoporte.Properties.Resources._043;
            myAvatars.Avatar43 = LayerSoporte.Properties.Resources._044;
            myAvatars.Avatar44 = LayerSoporte.Properties.Resources._045;
            myAvatars.Avatar45 = LayerSoporte.Properties.Resources._046;
            myAvatars.Avatar46 = LayerSoporte.Properties.Resources._047;
            myAvatars.Avatar47 = LayerSoporte.Properties.Resources._048;
            myAvatars.Avatar48 = LayerSoporte.Properties.Resources._049;
            myAvatars.Avatar49 = LayerSoporte.Properties.Resources._050;
        }
           
        public BitMap GetBitMap() 
        {
            BitMap bm = this.myAvatars;
            return bm;
        }
    }
}
