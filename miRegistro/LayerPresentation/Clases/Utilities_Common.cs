using LayerBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayerPresentation.Clases
{
    public static class Utilities_Common
    {
        public static Utilities_LayerBusiness layerBusiness;

        /// <summary>
        /// This method refresh all tmp files in cache
        /// </summary>
        public static void RefreshAllData() 
        {
            layerBusiness.cn_empleados.GenerateEmployeesDataCache();
            layerBusiness.cn_tramites.RefreshDataTramitesCache();
            layerBusiness.cn_tramites.RefreshDataDashboardCache();
            layerBusiness.cn_formularios.RefreshDataFormulariosCache();
            layerBusiness.cn_formularios.RefreshDataDashboardCache();

            Statistics.tmp = Cn_Employee.data.GetCache().GetUsers();
        }
        public static void RefreshStatisticData()
        {
            layerBusiness.cn_tramites.RefreshDataDashboardCache();
            layerBusiness.cn_empleados.GenerateEmployeesDataCache();

            Statistics.tmp = Cn_Employee.data.GetCache().GetUsers();
        }
        public static void RefreshTramitesData() 
        {
            layerBusiness.cn_tramites.RefreshDataTramitesCache();
            layerBusiness.cn_tramites.RefreshDataDashboardCache();
            layerBusiness.cn_empleados.GenerateEmployeesDataCache();
        }

        public static void RefreshFormulariosData()
        {
            layerBusiness.cn_formularios.RefreshDataFormulariosCache();
            layerBusiness.cn_formularios.RefreshDataCategoriasCache();
            layerBusiness.cn_formularios.RefreshDataDashboardCache();
        }

        public static void RefreshEmplooyeeDataTramites() 
        {
            layerBusiness.cn_tramites.RefreshDataDashboardCache();
            layerBusiness.cn_empleados.GenerateEmployeesDataCache();
        }
        /// <summary>
        /// In Textbox Prevent Only Numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void OnlyNumbers(object sender, KeyPressEventArgs e) 
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);

            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso
            {
                e.Handled = false;
            }
            else
            {
                //el resto de teclas pulsadas se desactivan
                e.Handled = true;
            }
        }

    }
}
