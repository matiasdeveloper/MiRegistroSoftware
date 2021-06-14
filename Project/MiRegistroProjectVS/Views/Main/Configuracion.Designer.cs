
namespace MiRegistro.Views.Main
{
    partial class Configuracion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gunaDragControl1 = new Guna.UI.WinForms.GunaDragControl(this.components);
            this.lbl_totaltramites = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gunaDragControl1
            // 
            this.gunaDragControl1.TargetControl = null;
            // 
            // lbl_totaltramites
            // 
            this.lbl_totaltramites.BackColor = System.Drawing.Color.Transparent;
            this.lbl_totaltramites.Font = new System.Drawing.Font("Poppins ExtraLight", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_totaltramites.ForeColor = System.Drawing.Color.Gray;
            this.lbl_totaltramites.Location = new System.Drawing.Point(161, 21);
            this.lbl_totaltramites.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_totaltramites.Name = "lbl_totaltramites";
            this.lbl_totaltramites.Size = new System.Drawing.Size(186, 16);
            this.lbl_totaltramites.TabIndex = 256;
            this.lbl_totaltramites.Text = "( Sistema en linea )";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(107)))), ((int)(((byte)(107)))));
            this.label23.Location = new System.Drawing.Point(12, 18);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(151, 28);
            this.label23.TabIndex = 255;
            this.label23.Text = "Configuraciones";
            // 
            // Configuracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1004, 681);
            this.Controls.Add(this.lbl_totaltramites);
            this.Controls.Add(this.label23);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Configuracion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuracion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaDragControl gunaDragControl1;
        private System.Windows.Forms.Label lbl_totaltramites;
        private System.Windows.Forms.Label label23;
    }
}