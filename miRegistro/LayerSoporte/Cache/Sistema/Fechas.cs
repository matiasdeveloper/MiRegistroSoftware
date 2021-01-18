using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayerSoporte.Cache
{
    public static class Fechas
    {
        public static DateTime dateNow 
        {
            get { return DateTime.Now; }
            set { dateNow = value; }
        }
        public static DateTime firstDayOfMonth { get; set; }
        public static DateTime lastDayOfMonth { get; set; }
        public static DateTime firstDayOfWeek { get; set; }
        public static DateTime lastDayOfWeek { get; set; }

        /// <summary>
        /// Check the date range
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public static Tuple<bool, bool> checkCorrectDate(DateTimePicker date1, DateTimePicker date2)
        {
            bool isOk = false;
            bool isOne = true;
            if (date1.Checked && date2.Checked)
            {
                if (date1.Value < date2.Value)
                {
                    isOne = false;
                    isOk = true;
                }
                else
                {
                    isOk = false;
                    MessageBox.Show("El valor de la segunda fecha no puede ser menor o igual que la primera", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (date1.Checked)
            {
                isOne = true;
                isOk = true;
            }
            else
            {
                MessageBox.Show("Seleccione al menos una fecha para iniciar la busquedad", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return Tuple.Create(isOk, isOne);
        }
    }
}
