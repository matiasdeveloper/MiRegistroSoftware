using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayerPresentation.Clases
{
    public static class UtilitiesPdf
    {
        public static bool ExportDataTableInPdf(DataTable dt, string name)
        {
            string dia = DateTime.Now.Day + "-" + DateTime.Now.Month;
            string user = name + "_" + dia;

            bool result = DataSave.ExportDataTablePDF(dt, user);

            return result;
        }
        public static bool ExportDataGridViewInPdf(DataGridView dt, string name)
        {
            Random r = new Random();
            string dia = DateTime.Now.Day + "-" + DateTime.Now.Month;
            string user = name + "_" + dia;

            bool result = DataSave.ExportDataGridViewPDF(dt, user);

            return result;
        }
    }
}
