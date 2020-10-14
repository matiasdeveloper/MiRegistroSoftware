using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LayerBusiness;
using LayerSoporte.Cache;

namespace LayerPresentation
{
    public partial class frm_configuracion : Form
    {
        public frm_configuracion()
        {
            InitializeComponent();
        }
        // Variables
        public BitMap myAvatars;

        // Function
        private void refreshUserInfo() 
        {
            //picBox_userImage.BackgroundImage = getAvatarUI(UserLoginCache.imageDefault);

            lbl_nombreUser.Text = UserLoginCache.Nombre;
            lbl_user.Text = UserLoginCache.Username;
            lbl_permission.Text = UserLoginCache.Priveleges;
            lbl_lastacess.Text = UserLoginCache.Fecha_UltimoAcceso.ToLongDateString();

            txtBox_usuario.Text = UserLoginCache.Username;
            txtBox_nombreUsuario.Text = UserLoginCache.Nombre;
            txtBox_nombreCorto.Text = UserLoginCache.Nombre_Corto;
            txtBox_correo.Text = UserLoginCache.Email;
            txtBox_ciudad.Text = UserLoginCache.City;
            dateTimePick_fechaC.Value = UserLoginCache.Fecha_nacimiento;
        }
        
        private void setAvatars()
        {
            myAvatars.Avatar0 = LayerPresentation.Properties.Resources._001;
            myAvatars.Avatar1 = LayerPresentation.Properties.Resources._002;
            myAvatars.Avatar2 = LayerPresentation.Properties.Resources._003;
            myAvatars.Avatar3 = LayerPresentation.Properties.Resources._004;
            myAvatars.Avatar4 = LayerPresentation.Properties.Resources._005;
            myAvatars.Avatar5 = LayerPresentation.Properties.Resources._006;
            myAvatars.Avatar6 = LayerPresentation.Properties.Resources._007;
            myAvatars.Avatar7 = LayerPresentation.Properties.Resources._008;
            myAvatars.Avatar8 = LayerPresentation.Properties.Resources._009;
            myAvatars.Avatar9 = LayerPresentation.Properties.Resources._010;
            /*myAvatars.Avatar10 = claseAvatar.GetBitMap().Avatar10;
            myAvatars.Avatar11 = claseAvatar.GetBitMap().Avatar11;
            myAvatars.Avatar12 = claseAvatar.GetBitMap().Avatar12;
            myAvatars.Avatar13 = claseAvatar.GetBitMap().Avatar13;
            myAvatars.Avatar14 = claseAvatar.GetBitMap().Avatar14;
            myAvatars.Avatar15 = claseAvatar.GetBitMap().Avatar15;
            myAvatars.Avatar16 = claseAvatar.GetBitMap().Avatar16;
            myAvatars.Avatar17 = claseAvatar.GetBitMap().Avatar17;
            myAvatars.Avatar18 = claseAvatar.GetBitMap().Avatar18;
            myAvatars.Avatar19 = claseAvatar.GetBitMap().Avatar19;
            myAvatars.Avatar20 = claseAvatar.GetBitMap().Avatar20;
            myAvatars.Avatar21 = claseAvatar.GetBitMap().Avatar21;
            myAvatars.Avatar22 = claseAvatar.GetBitMap().Avatar22;
            myAvatars.Avatar23 = claseAvatar.GetBitMap().Avatar23;
            myAvatars.Avatar24 = claseAvatar.GetBitMap().Avatar24;
            myAvatars.Avatar25 = claseAvatar.GetBitMap().Avatar25;
            myAvatars.Avatar26 = claseAvatar.GetBitMap().Avatar26;
            myAvatars.Avatar27 = claseAvatar.GetBitMap().Avatar27;
            myAvatars.Avatar28 = claseAvatar.GetBitMap().Avatar28;
            myAvatars.Avatar29 = claseAvatar.GetBitMap().Avatar29;
            myAvatars.Avatar30 = claseAvatar.GetBitMap().Avatar30;
            myAvatars.Avatar31 = claseAvatar.GetBitMap().Avatar31;
            myAvatars.Avatar32 = claseAvatar.GetBitMap().Avatar32;
            myAvatars.Avatar33 = claseAvatar.GetBitMap().Avatar33;
            myAvatars.Avatar34 = claseAvatar.GetBitMap().Avatar34;
            myAvatars.Avatar35 = claseAvatar.GetBitMap().Avatar35;
            myAvatars.Avatar36 = claseAvatar.GetBitMap().Avatar36;
            myAvatars.Avatar37 = claseAvatar.GetBitMap().Avatar37;
            myAvatars.Avatar38 = claseAvatar.GetBitMap().Avatar38;
            myAvatars.Avatar39 = claseAvatar.GetBitMap().Avatar39;
            myAvatars.Avatar40 = claseAvatar.GetBitMap().Avatar40;
            myAvatars.Avatar41 = claseAvatar.GetBitMap().Avatar41;
            myAvatars.Avatar42 = claseAvatar.GetBitMap().Avatar42;
            myAvatars.Avatar43 = claseAvatar.GetBitMap().Avatar43;
            myAvatars.Avatar44 = claseAvatar.GetBitMap().Avatar44;
            myAvatars.Avatar45 = claseAvatar.GetBitMap().Avatar45;
            myAvatars.Avatar46 = claseAvatar.GetBitMap().Avatar46;
            myAvatars.Avatar47 = claseAvatar.GetBitMap().Avatar47;
            myAvatars.Avatar48 = claseAvatar.GetBitMap().Avatar48;
            myAvatars.Avatar49 = claseAvatar.GetBitMap().Avatar49;*/
        }

        private Bitmap getAvatarUI(int select)
        {
            Bitmap image = new Bitmap(this.myAvatars.Avatar0);
            PropertyInfo[] info = this.myAvatars.GetType().GetProperties();
            for (int i = 0; i < info.Length; i++)
            {
                if (select == i)
                {
                    image = ((Bitmap)info[i].GetValue(myAvatars));
                    Properties.Settings.Default.UserImage = i;
                    return image;
                }
            }
            return image;
        }

        private void mostraPanelConfig(Panel pn, Button btn)
        {
            pn.Visible = true;
            btn.Enabled = false;
        }
        private void ocultarPanelConfig(Panel pn, Button btn)
        {
            pn.Visible = false;
            btn.Enabled = true;
        }
        // Method
        private void btn_cambiar1_Click(object sender, EventArgs e)
        {
            mostraPanelConfig(pn_expand_1, btn_cambiar1);
        }

        private void btn_cambiar2_Click(object sender, EventArgs e)
        {
            mostraPanelConfig(pn_expand_2, btn_cambiar2);
        }

        private void btn_cambiar3_Click(object sender, EventArgs e)
        {
            mostraPanelConfig(pn_expand_3, btn_cambiar3);
        }

        private void btn_cambiar4_Click(object sender, EventArgs e)
        {
            mostraPanelConfig(pn_expand_4, btn_cambiar4);
        }

        private void btn_cambiar5_Click(object sender, EventArgs e)
        {
            mostraPanelConfig(pn_expand_5, btn_cambiar5);
        }

        private void btn_cambiar6_Click(object sender, EventArgs e)
        {
            mostraPanelConfig(pn_expand_6, btn_cambiar6);
        }

        private void btn_cambiar7_Click(object sender, EventArgs e)
        {
            mostraPanelConfig(pn_expand_7, btn_cambiar7);
        }

        private void btn_cancelar1_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_1, btn_cambiar1);
        }

        private void btn_cancelar2_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_2, btn_cambiar2);
        }

        private void btn_cancelar3_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_3, btn_cambiar3);
        }

        private void btn_cancelar4_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_4, btn_cambiar4);
        }

        private void btn_cancelar5_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_5, btn_cambiar5);
        }

        private void btn_cancelar6_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_6, btn_cambiar6);
        }

        private void btn_cancelar7_Click(object sender, EventArgs e)
        {
            ocultarPanelConfig(pn_expand_7, btn_cambiar7);
        }

        private void frm_configuracion_Load(object sender, EventArgs e)
        {
            refreshUserInfo();
            setAvatars();
        }
    }
}
