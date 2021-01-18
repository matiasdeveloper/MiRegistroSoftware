using LayerBusiness;
using LayerPresentation.Properties;
using LayerSoporte.Cache;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LayerPresentation.Clases
{
    public static class Alertas
    {
        /// <summary>
        /// Find and print query quickly for specific alert (bajo || medio || alto)
        /// </summary>
        /// <param name="name"></param>
        public static void BuscarRapido(string name) 
        {
            int num = 0;
            switch (name) 
            {
                case "bajo":
                    num = Cn_HandlerFormularios.data.formularioCache.totalBajos;
                    break;
                case "medio":
                    num = Cn_HandlerFormularios.data.formularioCache.totalMedios;
                    break;
                case "alto":
                    num = Cn_HandlerFormularios.data.formularioCache.totalAltos;
                    break;
            }
            MessageBox.Show("Tenes " + num + " formularios que cuentan con stock " + name, "Consultas rapidas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void BuscarAlertas()
        {
            int stockBajo = Settings.Default.StockBajo;
            BuscarAlertaStock(stockBajo);
            BuscarAlertasTramites();
            BuscarAlertasCumpleaños();
        }
        private static void BuscarAlertaStock(int StockMenorQue)
        {
            if (Settings.Default.AlertaStock)
            {
                DataTable nuevaAlerta = Utilities_Common.layerBusiness.cn_alertas.buscarNuevasAlertas(StockMenorQue);
                if (!(nuevaAlerta.Rows.Count == 0))
                {
                    DateTime now = new DateTime();
                    now = DateTime.Now;
                    int id = Utilities_Common.layerBusiness.cn_alertas.insertarNuevaAlerta(UserLoginCache.Username);
                    foreach (DataRow fila in nuevaAlerta.Rows)
                    {
                        string valor = fila[0].ToString();
                        Utilities_Common.layerBusiness.cn_alertas.insertarDetallesAlerta(id, Convert.ToInt32(valor), "Alerta de stock");
                    }
                    if (MessageBox.Show("Alerta de stock bajo de formularios" + "\nDesea ver la alerta?", "Atencion!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        // Mostrar los formularios de la alerta con bajo stock.
                        frm_formularios_alerta mv = new frm_formularios_alerta(true, id, UserLoginCache.Fecha_UltimoAcceso.ToString(), UserLoginCache.Username);
                        mv.TopMost = true;
                        mv.Show();
                    }
                }
            }
        }
        private static void BuscarAlertasTramites()
        {
            if (Settings.Default.AlertaTramites == true)
            {
                Tramites dt = Cn_HandlerTramites.data.tramitesCache.GetCurrentTramites(Cn_HandlerTramites.current);
                int[] tramites = Statistics.FindTramitesAll(dt.data, DateTime.Now, DateTime.Now);
                if (tramites[0] <= 0)
                {
                    MessageBox.Show("Alerta de tramites" + "\nNo hay tramites cargados hoy.", "Atencion!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private static void BuscarAlertasCumpleaños()
        {
            if (Settings.Default.AlertaCumpleaños)
            {
                string c = Statistics.FindCumpleaños();
                if (!String.IsNullOrEmpty(c))
                {
                    if (c == UserLoginCache.Nombre)
                    {
                        MessageBox.Show("Felicidades!" + "\nQue pases un lindo dia " + c + "!" + "\n", "Alerta Cumpleaños!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Alerta de cumpleaños" + "\nHoy cumple años: " + c + "\n", "Alerta Cumpleaños!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}
