using LayerBusiness;
using LayerSoporte.Cache;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace LayerPresentation.Clases
{
    public static class Statistics
    {
        public static void DashboardStatisticHistory(Label[] labelStatistic) 
        {
            labelStatistic[0].Text = Cn_HandlerTramites.data.tramitesCache.totalTramites.ToString();
            labelStatistic[1].Text = Cn_HandlerTramites.data.tramitesCache.totalProcesados.ToString();
            labelStatistic[2].Text = Cn_HandlerTramites.data.tramitesCache.totalInscriptos.ToString();
            labelStatistic[3].Text = Cn_HandlerTramites.data.tramitesCache.totalErrores.ToString();
            labelStatistic[4].Text = Cn_HandlerTramites.data.tramitesCache.totalEmpleados.ToString();
            labelStatistic[5].Text = Cn_HandlerTramites.data.tramitesCache.totalTipos.ToString();
        }
        public static void DashboardStatisticAyer(Label[] Ayer) 
        {
            DateTime fecha1 = DateTime.Now.AddDays(-1);
            DateTime fecha2 = fecha1;

            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            int procesado = 0;
            int inscriptos = 0;

            Tramites dt = Cn_HandlerTramites.data.tramitesCache.GetCurrentTramites(Cn_HandlerTramites.current);
            foreach (DataRow fila in dt.data.Rows)
            {
                DateTime date = (DateTime)fila[5];
                if (date >= dt1  & date < dt2)
                {
                    procesado++;
                    if ((bool)fila[9] == true)
                    {
                        inscriptos++;
                    }
                }
            }

            Ayer[0].Text = procesado.ToString();
            Ayer[1].Text = inscriptos.ToString();
        }
        public static void DashboardStatisticHoy(Label[] Hoy) 
        {
            DateTime fecha1 = DateTime.Now;
            DateTime fecha2 = fecha1;

            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            int procesado = 0;
            int inscriptos = 0;

            Tramites dt = Cn_HandlerTramites.data.tramitesCache.GetCurrentTramites(Cn_HandlerTramites.current);
            foreach (DataRow fila in dt.data.Rows)
            {
                DateTime date = (DateTime)fila[5];
                if (date >= dt1 & date < dt2)
                {
                    procesado++;
                    if ((bool)fila[9] == true)
                    {
                        inscriptos++;
                    }
                }
            }

            Hoy[0].Text = procesado.ToString();
            Hoy[1].Text = inscriptos.ToString();
        }
        public static void DashboardStatisticMes(Label[] Mes)
        {
            DateTime fecha1 = Fechas.firstDayOfMonth;
            DateTime fecha2 = Fechas.lastDayOfMonth;

            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            int procesado = 0;
            int inscriptos = 0;

            Tramites dt = Cn_HandlerTramites.data.tramitesCache.GetCurrentTramites(Cn_HandlerTramites.current);
            foreach (DataRow fila in dt.data.Rows)
            {
                DateTime date = (DateTime)fila[5];
                if (date >= dt1 & date < dt2)
                {
                    procesado++;
                    if ((bool)fila[9] == true)
                    {
                        inscriptos++;
                    }
                }
            }

            Mes[0].Text = procesado.ToString();
            Mes[1].Text = inscriptos.ToString();
        }   
        public static void DashboardStatisticErrores(Label[] Hoy, Label[] Mes, Label[] Hist) 
        {
            StatisticErroresDia(Hoy);
            StatisticErroresMes(Mes);
            StatisticErroresHist(Hist);
        }
        
        public static void StatisticErroresDia(Label[] Hoy) 
        {
            DateTime fecha1 = DateTime.Now;
            DateTime fecha2 = fecha1;

            Tramites dt = Cn_HandlerTramites.data.tramitesCache.GetCurrentTramites(Cn_HandlerTramites.current);

            int[] e = FindErrores(dt.data, fecha1, fecha2);

            Hoy[0].Text = e[0].ToString();
            Hoy[1].Text = e[1].ToString();
            Hoy[2].Text = e[2].ToString();
        }
        public static void StatisticErroresMes(Label[] Mes)
        {
            DateTime fecha1 = Fechas.firstDayOfMonth;
            DateTime fecha2 = Fechas.lastDayOfMonth;

            Tramites dt = Cn_HandlerTramites.data.tramitesCache.GetCurrentTramites(Cn_HandlerTramites.current);

            int[] e = FindErrores(dt.data, fecha1, fecha2);

            Mes[0].Text = e[0].ToString();
            Mes[1].Text = e[1].ToString();
            Mes[2].Text = e[2].ToString();
        }
        public static void StatisticErroresHist(Label[] Hist)
        {
            DateTime fecha1 = new DateTime(1000, 1, 1, 0, 0, 0, 0);
            DateTime fecha2 = new DateTime(3000, 1, 1, 0, 0, 0, 0);

            Tramites dt = Cn_HandlerTramites.data.tramitesCache.GetCurrentTramites(Cn_HandlerTramites.current);

            int[] e = FindErrores(dt.data, fecha1, fecha2);

            Hist[0].Text = e[0].ToString();
            Hist[1].Text = e[1].ToString();
            Hist[2].Text = e[2].ToString();
        }

        public static void DisplayNames(Label[] labels, LinkedList<Employee> tmp)
        {
            LinkedListNode<Employee> employee = tmp.First;

            // Recorre la lista de empleados y los muestra en pantalla
            for (int i = 0; i < tmp.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        labels[0].Text = employee.Value.nombre;
                        labels[0].Enabled = true;
                        break;
                    case 1:
                        labels[1].Text = employee.Value.nombre;
                        labels[1].Enabled = true;
                        break;
                    case 2:
                        labels[2].Text = employee.Value.nombre;
                        labels[2].Enabled = true;
                        break;
                    case 3:
                        labels[3].Text = employee.Value.nombre;
                        labels[3].Enabled = true;
                        break;
                    case 4:
                        labels[4].Text = employee.Value.nombre;
                        labels[4].Enabled = true;
                        break;
                    case 5:
                        labels[5].Text = employee.Value.nombre;
                        labels[5].Enabled = true;
                        break;
                    case 6:
                        labels[6].Text = employee.Value.nombre;
                        labels[6].Enabled = true;
                        break;
                    case 7:
                        labels[7].Text = employee.Value.nombre;
                        labels[7].Enabled = true;
                        break;
                    case 8:
                        labels[8].Text = employee.Value.nombre;
                        labels[8].Enabled = true;
                        break;
                    case 9:
                        labels[9].Text = employee.Value.nombre;
                        labels[9].Enabled = true;
                        break;
                }
                employee = employee.Next;
            }
        }
        public static void DisplayEtapas(Label[] inscripto, Label[] procesados, LinkedList<Employee> tmp)
        {
            LinkedListNode<Employee> employee = tmp.First;
            int[] e;

            for (int i = 0; i < tmp.Count; i++)
            {
                e = FindEtapas(employee.Value.tramitesMes, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
                switch (i)
                {
                    case 0:
                        inscripto[0].Text = e[0].ToString();
                        procesados[0].Text = e[1].ToString();
                        inscripto[0].Enabled = true;
                        procesados[0].Enabled = true;
                        break;
                    case 1:
                        inscripto[1].Text = e[0].ToString();
                        procesados[1].Text = e[1].ToString();
                        inscripto[1].Enabled = true;
                        procesados[1].Enabled = true;
                        break;
                    case 2:
                        inscripto[2].Text = e[0].ToString();
                        procesados[2].Text = e[1].ToString();
                        inscripto[2].Enabled = true;
                        procesados[2].Enabled = true;
                        break;
                    case 3:
                        inscripto[3].Text = e[0].ToString();
                        procesados[3].Text = e[1].ToString();
                        inscripto[3].Enabled = true;
                        procesados[3].Enabled = true;
                        break;
                    case 4:
                        inscripto[4].Text = e[0].ToString();
                        procesados[4].Text = e[1].ToString();
                        inscripto[4].Enabled = true;
                        procesados[4].Enabled = true;
                        break;
                    case 5:
                        inscripto[5].Text = e[0].ToString();
                        procesados[5].Text = e[1].ToString();
                        inscripto[5].Enabled = true;
                        procesados[5].Enabled = true;
                        break;
                    case 6:
                        inscripto[6].Text = e[0].ToString();
                        procesados[6].Text = e[1].ToString();
                        inscripto[6].Enabled = true;
                        procesados[6].Enabled = true;
                        break;
                    case 7:
                        inscripto[7].Text = e[0].ToString();
                        procesados[7].Text = e[1].ToString();
                        inscripto[7].Enabled = true;
                        procesados[7].Enabled = true;
                        break;
                    case 8:
                        inscripto[8].Text = e[0].ToString();
                        procesados[8].Text = e[1].ToString();
                        inscripto[8].Enabled = true;
                        procesados[8].Enabled = true;
                        break;
                }
                employee = employee.Next;
            }
        }
        private static int[] FindEtapas(DataTable employee, DateTime fecha1, DateTime fecha2)
        {
            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            int procesados = 0;
            int inscriptos = 0;

            // 0 procesados, 1 inscriptos
            foreach (DataRow fila in employee.Rows)
            {
                DateTime date = (DateTime)fila[5];
                if (date >= dt1 & date < dt2)
                {
                    procesados++;
                    if ((bool)fila[9] == true)
                    {
                        inscriptos++;
                    }
                }
            }

            return new int[] { inscriptos, procesados };
        }
        
        public static void DisplayTopTramites(DataGridView dt, LinkedList<Employee> tmp)
        {
            LinkedListNode<Employee> employee = tmp.First;

            DataTable table = CreatorTables.TopEmployeesTable();

            int[] e;

            for (int i = 0; i < tmp.Count; i++)
            {
                e = FindTramites(employee.Value.tramitesMes, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
                CreatorTables.AddRowTopEmployeesTable(table, employee.Value.nombre, employee.Value.id, e[0], e[1], e[2]);
                employee = employee.Next;
            }

            dt.AutoGenerateColumns = false;
            dt.DataSource = table;
        }
        public static int[] FindTramites(DataTable employee, DateTime fecha1, DateTime fecha2)
        {
            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            int total = 0;
            int procesados = 0;
            int inscriptos = 0;

            // 1 parciales, 2 totales
            foreach (DataRow fila in employee.Rows)
            {
                DateTime date = (DateTime)fila[5];
                if (date >= dt1 & date < dt2)
                {
                    total++;
                    if ((string)fila[4] == "Procesado")
                    {
                        procesados++;
                    }
                    if ((bool)fila[9] == true)
                    {
                        inscriptos++;
                    }
                }
            }

            return new int[] { total, procesados, inscriptos };
        }

        public static void DisplayErrores(Label[] errores, Label[] erroresparciales, Label[] errorestotales, Panel[] panelErrores,LinkedList<Employee> tmp)
        {
            LinkedListNode<Employee> employee = tmp.First;
            int[] e;

            for (int i = 0; i < tmp.Count; i++)
            {
                e = FindErrores(employee.Value.tramitesMes, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
                switch (i)
                {
                    case 0:
                        panelErrores[0].Enabled = true;
                        errores[0].Text = e[0].ToString();
                        erroresparciales[0].Text = e[1].ToString();
                        errorestotales[0].Text = e[2].ToString();
                        break;
                    case 1:
                        panelErrores[1].Enabled = true;
                        errores[1].Text = e[0].ToString();
                        erroresparciales[1].Text = e[1].ToString();
                        errorestotales[1].Text = e[2].ToString();
                        break;
                    case 2:
                        panelErrores[2].Enabled = true;
                        errores[2].Text = e[0].ToString();
                        erroresparciales[2].Text = e[1].ToString();
                        errorestotales[2].Text = e[2].ToString();
                        break;
                    case 3:
                        panelErrores[3].Enabled = true;
                        errores[3].Text = e[0].ToString();
                        erroresparciales[3].Text = e[1].ToString();
                        errorestotales[3].Text = e[2].ToString();
                        break;
                    case 4:
                        panelErrores[4].Enabled = true;
                        errores[4].Text = e[0].ToString();
                        erroresparciales[4].Text = e[1].ToString();
                        errorestotales[4].Text = e[2].ToString();
                        break;
                    case 5:
                        panelErrores[5].Enabled = true;
                        errores[5].Text = e[0].ToString();
                        erroresparciales[5].Text = e[1].ToString();
                        errorestotales[5].Text = e[2].ToString();
                        break;
                    case 6:
                        panelErrores[6].Enabled = true;
                        errores[6].Text = e[0].ToString();
                        erroresparciales[6].Text = e[1].ToString();
                        errorestotales[6].Text = e[2].ToString();
                        break;
                    case 7:
                        panelErrores[7].Enabled = true;
                        errores[7].Text = e[0].ToString();
                        erroresparciales[7].Text = e[1].ToString();
                        errorestotales[7].Text = e[2].ToString();
                        break;
                    case 8:
                        panelErrores[8].Enabled = true;
                        errores[8].Text = e[0].ToString();
                        erroresparciales[8].Text = e[1].ToString();
                        errorestotales[8].Text = e[2].ToString();
                        break;
                }
                employee = employee.Next;
            }
        }
        public static void DisplayTopErrores(DataGridView dt, LinkedList<Employee> tmp)
        {
            LinkedListNode<Employee> employee = tmp.First;
            DataTable table = CreatorTables.TopEmployeesTable();

            int[] e;

            for (int i = 0; i < tmp.Count; i++)
            {
                e = FindErrores(employee.Value.tramitesMes, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
                CreatorTables.AddRowTopEmployeesTable(table, employee.Value.nombre, employee.Value.id, e[0], e[1], e[2]);
                employee = employee.Next;
            }

            dt.AutoGenerateColumns = false;
            dt.DataSource = table;
        }
        public static int[] FindErrores(DataTable employee, DateTime fecha1, DateTime fecha2)
        {
            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            int errores = 0;
            int parciales = 0;
            int totales = 0;

            // 1 parciales, 2 totales
            foreach (DataRow fila in employee.Rows)
            {
                DateTime date = (DateTime)fila[5];
                if (date >= dt1 & date < dt2)
                {
                    if ((bool)fila[6] == true)
                    {
                        errores++;
                        if ((string)fila[7] == "Error Total")
                        {
                            totales++;
                        }
                        else
                        {
                            parciales++;
                        }
                    }
                }
            }

            return new int[] { errores, parciales, totales };
        }
    }
}
