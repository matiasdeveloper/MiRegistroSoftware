using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers;
using Guna.UI.WinForms;

namespace MiRegistro.Views.Main
{
    public partial class Tramites : Form
    {
        private protected TramitesController oTramitesController;

        public int pageNumber = 1;
        public int pageSize = 10;

        public GunaShadowPanel currentPanelOpenOnFront;

        public DataTable DataSource { get; set; }

        public int selectedIdDatagridview = 0;

        public int y = 164;

        public Label currentQuerySelected;


        public Tramites()
        {
            InitializeComponent();
            oTramitesController = new TramitesController(this);

            currentQuerySelected = button_hoy;
        }

        private void dg_tramites_SelectionChanged(object sender, EventArgs e)
        {
            if(dg_tramites.SelectedRows.Count >= 1 && dg_tramites.SelectedColumns.Count == 0) 
            {
                selectedIdDatagridview = Convert.ToInt32(dg_tramites.CurrentRow.Cells["ColumnId"].Value);
            }
        }

        private void comboBox_rowPerPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            int current = Convert.ToInt32((string)comboBox_rowPerPage.SelectedItem);
            pageSize = current;
        }
    }
}
