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
using System.Windows.Forms.DataVisualization.Charting;
using Label = System.Windows.Forms.Label;

namespace LayerPresentation.Clases
{
    public static class Statistics
    {
        public static LinkedList<Employee> tmp;

        // New

        /// <summary>
        /// Return total for this month and the percentage with respect the past month.
        /// Return total errores for this month and the percentage with respect the past month.
        /// </summary>
        public static float[] GetDashboardStatistic_MonthComplete()
        {
            DateTime fecha1 = Fechas.firstDayOfMonth;
            DateTime fecha2 = Fechas.lastDayOfMonth;

            DateTime fecha1_past = Fechas.firstDayOfMonth.AddMonths(-1);
            DateTime fecha2_past = Fechas.lastDayOfMonth.AddMonths(-1);

            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            DateTime dt1_past = new DateTime(fecha1_past.Year, fecha1_past.Month, fecha1_past.Day, 0, 0, 0);
            DateTime dt2_past = new DateTime(fecha2_past.Year, fecha2_past.Month, fecha2_past.Day, 0, 0, 0);
            dt2_past = dt2_past.AddDays(1);

            int procesado = 0;
            int procesado_past = 0;
            int errores = 0;
            int errores_past = 0;

            Tramites dt = Cn_HandlerTramites.data.tramitesCache.GetCurrentTramites(Cn_HandlerTramites.current);
            foreach (DataRow fila in dt.data.Rows)
            {
                DateTime date = (DateTime)fila[5];
                if (date >= dt1_past && date < dt2_past)
                {
                    procesado_past++;
                    if ((bool)fila[6] == true)
                    {
                        errores_past++;
                    }
                }
                if (date >= dt1 & date < dt2)
                {
                    procesado++;
                    if ((bool)fila[6] == true)
                    {
                        errores++;
                    }
                }
            }

            double percentage = UtilitiesCommon.CalculateDifferencePercentage(procesado, procesado_past);
            double percentage_errores = UtilitiesCommon.CalculateDifferencePercentage(errores, errores_past);

            float[] r = { procesado, (float)percentage, errores, (float)percentage_errores };
            return r;
        }
        /// <summary>
        /// Return total for this day and the percentage with respect the past day.
        /// Return total errores for this day and the percentage with respect the past day.
        /// </summary>
        public static float[] GetDashboardStatistic_DayComplete()
        {
            DateTime fecha1 = DateTime.Now;
            DateTime fecha2 = fecha1;

            DateTime fecha1_past = DateTime.Now.AddDays(-1);
            DateTime fecha2_past = fecha1_past;

            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            DateTime dt1_past = new DateTime(fecha1_past.Year, fecha1_past.Month, fecha1_past.Day, 0, 0, 0);
            DateTime dt2_past = new DateTime(fecha2_past.Year, fecha2_past.Month, fecha2_past.Day, 0, 0, 0);
            dt2_past = dt2_past.AddDays(1);

            int procesado = 0;
            int procesado_past = 0;
            int errores = 0;
            int errores_past = 0;

            Tramites dt = Cn_HandlerTramites.data.tramitesCache.GetCurrentTramites(Cn_HandlerTramites.current);
            foreach (DataRow fila in dt.data.Rows)
            {
                DateTime date = (DateTime)fila[5];
                if (date >= dt1_past && date < dt2_past)
                {
                    procesado_past++;
                    if ((bool)fila[6] == true)
                    {
                        errores_past++;
                    }
                }
                if (date >= dt1 & date < dt2)
                {
                    procesado++;
                    if ((bool)fila[6] == true)
                    {
                        errores++;
                    }
                }
            }

            double percentage = UtilitiesCommon.CalculateDifferencePercentage(procesado, procesado_past);
            double percentage_errores = UtilitiesCommon.CalculateDifferencePercentage(errores, errores_past);

            float[] r = { procesado, (float)percentage, errores, (float)percentage_errores };
            return r;
        }

        /// <summary>
        /// Return total of procesados and inscriptos and optional the percentage difference between the month or day last
        /// In this order you can get procesados and inscriptos
        /// Or you get procesados, inscriptos, percentageProcesados, percentageInscriptos, procesados_past, inscriptos_past
        /// </summary>
        /// <param name="Ayer"></param>
        public static int[] GetStatisticTramites(DateTime fecha1, DateTime fecha2, bool GetPercentage = false)
        {
            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            int procesado = 0;
            int inscriptos = 0;

            int inscriptos_false = 0;

            Tramites dt = Cn_HandlerTramites.data.tramitesCache.GetCurrentTramites(Cn_HandlerTramites.current);
            foreach (DataRow fila in dt.data.Rows)
            {
                // Find total tramites procesados e inscriptos in current range
                DateTime date = (DateTime)fila[5];
                if (date >= dt1 & date < dt2)
                {
                    procesado++;
                    if ((bool)fila[9] == true)
                    {
                        inscriptos++;
                    } 
                    else 
                    {
                        inscriptos_false++;
                    }
                }
            }
            List<int> result = new List<int>();
            
            if (GetPercentage) 
            {
                int percentageInscriptos = (int)UtilitiesCommon.CalculatePercentage(procesado, inscriptos);

                result.Add(procesado);
                result.Add(inscriptos);
                result.Add(100);
                result.Add(percentageInscriptos);
                result.Add(procesado); // False
                result.Add(inscriptos_false);
            } 
            else 
            {
                result.Add(procesado);
                result.Add(inscriptos);
            }
            return result.ToArray();
        }

        /// <summary>
        /// Load the chart tramites for procesados or inscriptos or finished in specific range (Month, Daily, Year)
        /// </summary>
        /// <param name="ch"></param>
        /// <param name="series"></param>
        /// <param name="fecha1"></param>
        /// <param name="fecha2"></param>
        public static void LoadChartDetails(Chart ch, string range, string etapa, string series, DateTime fecha1, DateTime fecha2)
        {
            int[] details;

            switch (range) 
            {
                case "Mes":
                    details = FindDetailsInRange(range, etapa, fecha1, fecha2);
                    ch.Series[series].Points.AddXY("1er semana", details[0]);
                    ch.Series[series].Points.AddXY("2da semana", details[1]);
                    ch.Series[series].Points.AddXY("3era semana", details[2]);
                    ch.Series[series].Points.AddXY("4ta semana", details[3]);
                    break;
                case "Año":
                    details = FindDetailsInRange(range, etapa, fecha1, fecha2);
                    ch.Series[series].Points.AddXY("Enero", details[0]);
                    ch.Series[series].Points.AddXY("Febrero", details[1]);
                    ch.Series[series].Points.AddXY("Marzo", details[2]);
                    ch.Series[series].Points.AddXY("Abril", details[3]);
                    ch.Series[series].Points.AddXY("Mayo", details[4]);
                    ch.Series[series].Points.AddXY("Junio", details[5]);
                    ch.Series[series].Points.AddXY("Julio", details[6]);
                    ch.Series[series].Points.AddXY("Agosto", details[7]);
                    ch.Series[series].Points.AddXY("Septiembre", details[8]);
                    ch.Series[series].Points.AddXY("Octubre", details[9]);
                    ch.Series[series].Points.AddXY("Noviembre", details[10]);
                    ch.Series[series].Points.AddXY("Diciembre", details[11]);
                    break;
            }
        }
        private static int[] FindDetailsInRange(string range, string etapa, DateTime fecha1, DateTime fecha2) 
        {
            List<int> details = new List<int>();

            Tramites dt = Cn_HandlerTramites.data.tramitesCache.GetCurrentTramites(Cn_HandlerTramites.current);
            int i = 4;
            int daysToAdd = 8;

            switch (range) 
            {
                case "Mes":
                    i = 4;
                    daysToAdd = 8;
                    break;
                case "Año":
                    i = 12;
                    daysToAdd = 31;
                    break;
            }
            
            for(int a = 0; a < i; a++) 
            {
                DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
                DateTime dt2 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0).AddDays(daysToAdd);

                int detailsToAdd = 0;
                
                foreach (DataRow fila in dt.data.Rows)
                {
                    DateTime date = (DateTime)fila[5];
                    switch (etapa) 
                    {
                        case "Procesados":
                            if (date >= dt1 & date < dt2 & date < fecha2)
                            {
                                detailsToAdd++;
                            }
                            break;
                        case "Inscriptos":
                            if (date >= dt1 & date < dt2 & date < fecha2)
                            {
                                if ((bool)fila[9] == true)
                                {
                                    detailsToAdd++;
                                }
                            }
                            break;
                        case "Finalizados":
                            if (date >= dt1 & date < dt2 & date < fecha2)
                            {
                                if ((bool)fila[9] == true)
                                {
                                    detailsToAdd++;
                                }
                            }
                            break;
                    }
                }

                details.Add(detailsToAdd);
            }

            // Return si es mensual {1er semana, 2da, 3era, 4ta}
            // Return si es anual {1er mes, ...}
            return details.ToArray();
        }

        /// <summary>
        /// Load the chart tramites for simple (procesados o inscriptos) or Load the chart tramites for complex (procesados & inscriptos & finished)
        /// </summary>
        /// <param name="ch"></param>
        /// <param name="series"></param>
        /// <param name="fecha1"></param>
        /// <param name="fecha2"></param>
        /// <param name="isSimple"></param>
        public static void LoadChartEmployee(Chart ch, string[] series, DateTime fecha1, DateTime fecha2, bool isSimple = true)
        {
            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);

            LinkedListNode<Employee> employee = tmp.First;

            int[] etapasMes;

            // Display stastic for all of employees into the chart series1
            for (int i = 0; i < tmp.Count; i++)
            {
                if (employee.Value.nombre != "Admin S.")
                {
                    if (isSimple)
                    {
                        // By month and simple chart
                        etapasMes = FindEtapas(employee.Value.nombre, employee.Value.tramitesMes, dt1, dt2);
                        int total = etapasMes[1] + etapasMes[0];

                        ch.Series[series[0]].Points.AddXY(employee.Value.nombre, total);
                    }
                    else
                    {
                        // By month and all the chart
                        etapasMes = FindEtapas(employee.Value.nombre, employee.Value.tramitesMes, dt1, dt2);
                        int total = etapasMes[1] + etapasMes[0];

                        ch.Series[series[0]].Points.AddXY(employee.Value.nombre, total);
                        ch.Series[series[1]].Points.AddXY("Procesados", etapasMes[1]);
                        ch.Series[series[2]].Points.AddXY("Inscriptos", etapasMes[0]);
                    }
                }
                employee = employee.Next;
            }
        }

        #region Old Methods
        // Old 
        public static void DashboardChartEmployeesErrores(Chart ch, string[] series, DateTime fecha1, DateTime fecha2)
        {
            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);

            LinkedListNode<Employee> employee = tmp.First;

            int[] erroresMes;
            // Display stastic for all of employees into the chart series1
            for (int i = 0; i < tmp.Count; i++)
            {
                if (employee.Value.nombre != "Admin S.")
                {
                    // By month and all the chart
                    erroresMes = FindErrores(employee.Value.nombre, employee.Value.tramitesMes, dt1, dt2);

                    ch.Series[series[0]].Points.AddXY(employee.Value.nombre, erroresMes[0]);
                    ch.Series[series[1]].Points.AddXY("Parciales", erroresMes[1]);
                    ch.Series[series[2]].Points.AddXY("Totales", erroresMes[2]);
                }
                employee = employee.Next;
            }
        }

        public static void DashboardStatisticHistory(Label[] labelStatistic) 
        {
            labelStatistic[0].Text = Cn_HandlerTramites.data.tramitesCache.totalTramites.ToString();
            labelStatistic[1].Text = Cn_HandlerTramites.data.tramitesCache.totalProcesados.ToString();
            labelStatistic[2].Text = Cn_HandlerTramites.data.tramitesCache.totalInscriptos.ToString();
            labelStatistic[3].Text = Cn_HandlerTramites.data.tramitesCache.totalErrores.ToString();
            labelStatistic[4].Text = Cn_HandlerTramites.data.tramitesCache.totalEmpleados.ToString();
            labelStatistic[5].Text = Cn_HandlerTramites.data.tramitesCache.totalTipos.ToString();
        }
        // Carga el total de: procesados e inscriptos (AYER,HOY,MES)
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
        
        // Carga el total de: errores, parciales y totales (AYER, HOY, MES)
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

            int[] e = FindErroresAll(dt.data, fecha1, fecha2);

            Hoy[0].Text = e[0].ToString();
            Hoy[1].Text = e[1].ToString();
            Hoy[2].Text = e[2].ToString();
        }
        public static void StatisticErroresMes(Label[] Mes)
        {
            DateTime fecha1 = Fechas.firstDayOfMonth;
            DateTime fecha2 = Fechas.lastDayOfMonth;

            Tramites dt = Cn_HandlerTramites.data.tramitesCache.GetCurrentTramites(Cn_HandlerTramites.current);

            int[] e = FindErroresAll(dt.data, fecha1, fecha2);

            Mes[0].Text = e[0].ToString();
            Mes[1].Text = e[1].ToString();
            Mes[2].Text = e[2].ToString();
        }
        public static void StatisticErroresHist(Label[] Hist)
        {
            DateTime fecha1 = new DateTime(1000, 1, 1, 0, 0, 0, 0);
            DateTime fecha2 = new DateTime(3000, 1, 1, 0, 0, 0, 0);

            Tramites dt = Cn_HandlerTramites.data.tramitesCache.GetCurrentTramites(Cn_HandlerTramites.current);

            int[] e = FindErroresAll(dt.data, fecha1, fecha2);

            Hist[0].Text = e[0].ToString();
            Hist[1].Text = e[1].ToString();
            Hist[2].Text = e[2].ToString();
        }

        public static void DisplayNames(Label[] labels)
        {
            LinkedListNode<Employee> employee = tmp.First;

            // Recorre la lista de empleados y los muestra en pantalla
            for (int i = 0; i < tmp.Count; i++)
            {
                if (employee.Value.nombre != "Admin S.") 
                {
                    switch (i)
                    {
                        case 1:
                            labels[0].Text = employee.Value.nombre;
                            labels[0].Enabled = true;
                            break;
                        case 2:
                            labels[1].Text = employee.Value.nombre;
                            labels[1].Enabled = true;
                            break;
                        case 3:
                            labels[2].Text = employee.Value.nombre;
                            labels[2].Enabled = true;
                            break;
                        case 4:
                            labels[3].Text = employee.Value.nombre;
                            labels[3].Enabled = true;
                            break;
                        case 5:
                            labels[4].Text = employee.Value.nombre;
                            labels[4].Enabled = true;
                            break;
                        case 6:
                            labels[5].Text = employee.Value.nombre;
                            labels[5].Enabled = true;
                            break;
                        case 7:
                            labels[6].Text = employee.Value.nombre;
                            labels[6].Enabled = true;
                            break;
                        case 8:
                            labels[7].Text = employee.Value.nombre;
                            labels[7].Enabled = true;
                            break;
                        case 9:
                            labels[8].Text = employee.Value.nombre;
                            labels[8].Enabled = true;
                            break;
                        case 10:
                            labels[9].Text = employee.Value.nombre;
                            labels[9].Enabled = true;
                            break;
                    }

                }
                employee = employee.Next;
            }
        }
        public static void DisplayInfo(Panel[] panels ,Label[][] info) 
        {
            LinkedListNode<Employee> employee = tmp.First;

            // Recorre la lista de empleados y muestra en pantalla su informacion principal
            // First: Actiavate panel
            // Second: Display info empleado X > Permisos, Email, Acceso 
            for (int i = 0; i < tmp.Count; i++)
            {
                if (employee.Value.nombre != "Admin S.") 
                {
                    switch (i)
                    {
                        case 1:
                            panels[0].Enabled = true;
                            info[0][0].Text = employee.Value.privilegios;
                            info[0][1].Text = employee.Value.email;
                            info[0][2].Text = employee.Value.fechaAcceso.ToShortDateString();
                            info[0][3].Text = employee.Value.id.ToString();
                            info[0][4].Text = employee.Value.usuario.ToString();
                            break;
                        case 2:
                            panels[1].Enabled = true;
                            info[1][0].Text = employee.Value.privilegios;
                            info[1][1].Text = employee.Value.email;
                            info[1][2].Text = employee.Value.fechaAcceso.ToShortDateString();
                            info[1][3].Text = employee.Value.id.ToString();
                            info[1][4].Text = employee.Value.usuario.ToString();
                            break;
                        case 3:
                            panels[2].Enabled = true;
                            info[2][0].Text = employee.Value.privilegios;
                            info[2][1].Text = employee.Value.email;
                            info[2][2].Text = employee.Value.fechaAcceso.ToShortDateString();
                            info[2][3].Text = employee.Value.id.ToString();
                            info[2][4].Text = employee.Value.usuario.ToString();
                            break;
                        case 4:
                            panels[3].Enabled = true;
                            info[3][0].Text = employee.Value.privilegios;
                            info[3][1].Text = employee.Value.email;
                            info[3][2].Text = employee.Value.fechaAcceso.ToShortDateString();
                            info[3][3].Text = employee.Value.id.ToString();
                            info[3][4].Text = employee.Value.usuario.ToString();
                            break;
                        case 5:
                            panels[4].Enabled = true;
                            info[4][0].Text = employee.Value.privilegios;
                            info[4][1].Text = employee.Value.email;
                            info[4][2].Text = employee.Value.fechaAcceso.ToShortDateString();
                            info[4][3].Text = employee.Value.id.ToString();
                            info[4][4].Text = employee.Value.usuario.ToString();
                            break;
                        case 6:
                            panels[5].Enabled = true;
                            info[5][0].Text = employee.Value.privilegios;
                            info[5][1].Text = employee.Value.email;
                            info[5][2].Text = employee.Value.fechaAcceso.ToShortDateString();
                            info[5][3].Text = employee.Value.id.ToString();
                            info[5][4].Text = employee.Value.usuario.ToString();
                            break;
                        case 7:
                            panels[6].Enabled = true;
                            info[6][0].Text = employee.Value.privilegios;
                            info[6][1].Text = employee.Value.email;
                            info[6][2].Text = employee.Value.fechaAcceso.ToShortDateString();
                            info[6][3].Text = employee.Value.id.ToString();
                            info[6][4].Text = employee.Value.usuario.ToString();
                            break;
                        case 8:
                            panels[7].Enabled = true;
                            info[7][0].Text = employee.Value.privilegios;
                            info[7][1].Text = employee.Value.email;
                            info[7][2].Text = employee.Value.fechaAcceso.ToShortDateString();
                            info[7][3].Text = employee.Value.id.ToString();
                            info[7][4].Text = employee.Value.usuario.ToString();
                            break;
                    }
                }
                employee = employee.Next;
            }
        }
        public static void DisplayEmployeeData(Label[][] statisticEmployee) 
        {
            LinkedListNode<Employee> employee = tmp.First;
            int[] etapasDia;
            int[] etapasMes;
            int[] errores;
            // Display stastic for all of employees
            // In this order: 
            // - inscriptos dia[employe index][0]
            // - procesados dia[employee index][1]
            // - inscriptos mes[employee index][2]
            // - procesados mes[employee index][3]
            // - errores mes[employee index][4]
            for (int i = 0; i < tmp.Count; i++)
            {
                if (employee.Value.nombre != "Admin S.") 
                {
                    // Dia
                    etapasDia = FindEtapas(employee.Value.nombre, employee.Value.tramitesMes, Fechas.firstDayOfWeek, Fechas.lastDayOfWeek);
                    // Mes
                    etapasMes = FindEtapas(employee.Value.nombre, employee.Value.tramitesMes, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
                    errores = FindErrores(employee.Value.nombre, employee.Value.tramitesMes, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);

                    switch (i)
                    {
                        case 1:
                            statisticEmployee[0][0].Text = etapasDia[0].ToString();
                            statisticEmployee[0][1].Text = etapasDia[1].ToString();
                            statisticEmployee[0][2].Text = etapasMes[0].ToString();
                            statisticEmployee[0][3].Text = etapasMes[1].ToString();
                            statisticEmployee[0][4].Text = errores[0].ToString();
                            break;
                        case 2:
                            statisticEmployee[1][0].Text = etapasDia[0].ToString();
                            statisticEmployee[1][1].Text = etapasDia[1].ToString();
                            statisticEmployee[1][2].Text = etapasMes[0].ToString();
                            statisticEmployee[1][3].Text = etapasMes[1].ToString();
                            statisticEmployee[1][4].Text = errores[0].ToString();
                            break;
                        case 3:
                            statisticEmployee[2][0].Text = etapasDia[0].ToString();
                            statisticEmployee[2][1].Text = etapasDia[1].ToString();
                            statisticEmployee[2][2].Text = etapasMes[0].ToString();
                            statisticEmployee[2][3].Text = etapasMes[1].ToString();
                            statisticEmployee[2][4].Text = errores[0].ToString();
                            break;
                        case 4:
                            statisticEmployee[3][0].Text = etapasDia[0].ToString();
                            statisticEmployee[3][1].Text = etapasDia[1].ToString();
                            statisticEmployee[3][2].Text = etapasMes[0].ToString();
                            statisticEmployee[3][3].Text = etapasMes[1].ToString();
                            statisticEmployee[3][4].Text = errores[0].ToString();
                            break;
                        case 5:
                            statisticEmployee[4][0].Text = etapasDia[0].ToString();
                            statisticEmployee[4][1].Text = etapasDia[1].ToString();
                            statisticEmployee[4][2].Text = etapasMes[0].ToString();
                            statisticEmployee[4][3].Text = etapasMes[1].ToString();
                            statisticEmployee[4][4].Text = errores[0].ToString();
                            break;
                        case 6:
                            statisticEmployee[5][0].Text = etapasDia[0].ToString();
                            statisticEmployee[5][1].Text = etapasDia[1].ToString();
                            statisticEmployee[5][2].Text = etapasMes[0].ToString();
                            statisticEmployee[5][3].Text = etapasMes[1].ToString();
                            statisticEmployee[5][4].Text = errores[0].ToString();
                            break;
                        case 7:
                            statisticEmployee[6][0].Text = etapasDia[0].ToString();
                            statisticEmployee[6][1].Text = etapasDia[1].ToString();
                            statisticEmployee[6][2].Text = etapasMes[0].ToString();
                            statisticEmployee[6][3].Text = etapasMes[1].ToString();
                            statisticEmployee[6][4].Text = errores[0].ToString(); break;
                        case 8:
                            statisticEmployee[7][0].Text = etapasDia[0].ToString();
                            statisticEmployee[7][1].Text = etapasDia[1].ToString();
                            statisticEmployee[7][2].Text = etapasMes[0].ToString();
                            statisticEmployee[7][3].Text = etapasMes[1].ToString();
                            statisticEmployee[7][4].Text = errores[0].ToString();
                            break;
                        case 9:
                            statisticEmployee[8][0].Text = etapasDia[0].ToString();
                            statisticEmployee[8][1].Text = etapasDia[1].ToString();
                            statisticEmployee[8][2].Text = etapasMes[0].ToString();
                            statisticEmployee[8][3].Text = etapasMes[1].ToString();
                            statisticEmployee[8][4].Text = errores[0].ToString();
                            break;
                    }
                }
                employee = employee.Next;
            }
        }
        public static void DisplayEtapas(Label[] inscripto, Label[] procesados)
        {
            LinkedListNode<Employee> employee = tmp.First;
            int[] e;

            for (int i = 0; i < tmp.Count; i++)
            {
                if (employee.Value.nombre != "Admin S.") 
                {
                    e = FindEtapas(employee.Value.nombre, employee.Value.tramitesMes, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
                    switch (i)
                    {
                        case 1:
                            inscripto[0].Text = e[0].ToString();
                            procesados[0].Text = e[1].ToString();
                            inscripto[0].Enabled = true;
                            procesados[0].Enabled = true;
                            break;
                        case 2:
                            inscripto[1].Text = e[0].ToString();
                            procesados[1].Text = e[1].ToString();
                            inscripto[1].Enabled = true;
                            procesados[1].Enabled = true;
                            break;
                        case 3:
                            inscripto[2].Text = e[0].ToString();
                            procesados[2].Text = e[1].ToString();
                            inscripto[2].Enabled = true;
                            procesados[2].Enabled = true;
                            break;
                        case 4:
                            inscripto[3].Text = e[0].ToString();
                            procesados[3].Text = e[1].ToString();
                            inscripto[3].Enabled = true;
                            procesados[3].Enabled = true;
                            break;
                        case 5:
                            inscripto[4].Text = e[0].ToString();
                            procesados[4].Text = e[1].ToString();
                            inscripto[4].Enabled = true;
                            procesados[4].Enabled = true;
                            break;
                        case 6:
                            inscripto[5].Text = e[0].ToString();
                            procesados[5].Text = e[1].ToString();
                            inscripto[5].Enabled = true;
                            procesados[5].Enabled = true;
                            break;
                        case 7:
                            inscripto[6].Text = e[0].ToString();
                            procesados[6].Text = e[1].ToString();
                            inscripto[6].Enabled = true;
                            procesados[6].Enabled = true;
                            break;
                        case 8:
                            inscripto[7].Text = e[0].ToString();
                            procesados[7].Text = e[1].ToString();
                            inscripto[7].Enabled = true;
                            procesados[7].Enabled = true;
                            break;
                        case 9:
                            inscripto[8].Text = e[0].ToString();
                            procesados[8].Text = e[1].ToString();
                            inscripto[8].Enabled = true;
                            procesados[8].Enabled = true;
                            break;
                    }
                }
                employee = employee.Next;
            }
        }
        private static int[] FindEtapas(string nameEmployee, DataTable employee, DateTime fecha1, DateTime fecha2)
        {
            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            int procesados = 0;
            int inscriptos = 0;

            // 0 inscriptos, 1 procesados
            foreach (DataRow fila in employee.Rows)
            {
                DateTime date = (DateTime)fila[5];
                if (date >= dt1 & date < dt2 && (string)fila[2] == nameEmployee)
                {
                    procesados++;
                }
                if (date >= dt1 & date < dt2 && (bool)fila[9] == true)
                {
                    if ((string)fila[10] == nameEmployee)
                    {
                        inscriptos++;
                    }
                }
            }

            return new int[] { inscriptos, procesados };
        }
        
        public static void DisplayTopTramites(DataGridView dt)
        {
            LinkedListNode<Employee> employee = tmp.First;

            DataTable table = CreatorTables.TopEmployeesTable();

            int[] e;

            for (int i = 0; i < tmp.Count; i++)
            {
                if (employee.Value.nombre != "Admin S.") 
                {
                    e = FindTramites(employee.Value.nombre, employee.Value.tramitesMes, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
                    CreatorTables.AddRowTopEmployeesTable(table, employee.Value.nombre, employee.Value.id, e[0], e[1], e[2]);
                }
                employee = employee.Next;
            }

            dt.AutoGenerateColumns = false;
            dt.DataSource = table;
        }
        public static int[] FindTramites(string nameEmployee, DataTable employee, DateTime fecha1, DateTime fecha2)
        {
            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            int total = 0;
            int procesados = 0;
            int inscriptos = 0;

            // 1 procesados, 2 inscriptos
            foreach (DataRow fila in employee.Rows)
            {
                DateTime date = (DateTime)fila[5];
                if (date >= dt1 & date < dt2 && (string)fila[2] == nameEmployee)
                {
                    if ((string)fila[4] == "Procesado")
                    {
                        total++;
                        procesados++;
                    }
                }
                if (date >= dt1 & date < dt2 && (bool)fila[9] == true)
                {
                    if ((string)fila[10] == nameEmployee)
                    {
                        total++;
                        inscriptos++;
                    }
                }
            }

            return new int[] { total, procesados, inscriptos };
        }

        public static void DisplayErrores(Label[] errores, Label[] erroresparciales, Label[] errorestotales, Panel[] panelErrores)
        {
            LinkedListNode<Employee> employee = tmp.First;
            int[] e;

            for (int i = 0; i < tmp.Count; i++)
            {
                if (employee.Value.nombre != "Admin S.") 
                {
                    e = FindErrores(employee.Value.nombre, employee.Value.tramitesMes, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
                    switch (i)
                    {
                        case 1:
                            panelErrores[0].Enabled = true;
                            errores[0].Text = e[0].ToString();
                            erroresparciales[0].Text = e[1].ToString();
                            errorestotales[0].Text = e[2].ToString();
                            break;
                        case 2:
                            panelErrores[1].Enabled = true;
                            errores[1].Text = e[0].ToString();
                            erroresparciales[1].Text = e[1].ToString();
                            errorestotales[1].Text = e[2].ToString();
                            break;
                        case 3:
                            panelErrores[2].Enabled = true;
                            errores[2].Text = e[0].ToString();
                            erroresparciales[2].Text = e[1].ToString();
                            errorestotales[2].Text = e[2].ToString();
                            break;
                        case 4:
                            panelErrores[3].Enabled = true;
                            errores[3].Text = e[0].ToString();
                            erroresparciales[3].Text = e[1].ToString();
                            errorestotales[3].Text = e[2].ToString();
                            break;
                        case 5:
                            panelErrores[4].Enabled = true;
                            errores[4].Text = e[0].ToString();
                            erroresparciales[4].Text = e[1].ToString();
                            errorestotales[4].Text = e[2].ToString();
                            break;
                        case 6:
                            panelErrores[5].Enabled = true;
                            errores[5].Text = e[0].ToString();
                            erroresparciales[5].Text = e[1].ToString();
                            errorestotales[5].Text = e[2].ToString();
                            break;
                        case 7:
                            panelErrores[6].Enabled = true;
                            errores[6].Text = e[0].ToString();
                            erroresparciales[6].Text = e[1].ToString();
                            errorestotales[6].Text = e[2].ToString();
                            break;
                        case 8:
                            panelErrores[7].Enabled = true;
                            errores[7].Text = e[0].ToString();
                            erroresparciales[7].Text = e[1].ToString();
                            errorestotales[7].Text = e[2].ToString();
                            break;
                        case 9:
                            panelErrores[8].Enabled = true;
                            errores[8].Text = e[0].ToString();
                            erroresparciales[8].Text = e[1].ToString();
                            errorestotales[8].Text = e[2].ToString();
                            break;
                    }
                }
                employee = employee.Next;
            }
        }
        public static void DisplayTopErrores(DataGridView dt, DateTime fecha1, DateTime fecha2)
        {
            LinkedListNode<Employee> employee = tmp.First;
            DataTable table = CreatorTables.TopEmployeesTable();

            int[] e;

            for (int i = 0; i < tmp.Count; i++)
            {
                if (employee.Value.nombre != "Admin S.") 
                {
                    e = FindErrores(employee.Value.nombre, employee.Value.tramitesMes, fecha1, fecha2);
                    CreatorTables.AddRowTopEmployeesTable(table, employee.Value.nombre, employee.Value.id, e[0], e[1], e[2]);
                }
                employee = employee.Next;
            }

            dt.AutoGenerateColumns = false;
            dt.DataSource = table;
        }
        public static int[] FindErrores(string empleado, DataTable employee, DateTime fecha1, DateTime fecha2)
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
                    if ((bool)fila[6] == true && (string)fila[2] == empleado)
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

        public static int[] FindErroresAll(DataTable employee, DateTime fecha1, DateTime fecha2)
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

        public static int[] FindTramitesAll(DataTable tramites, DateTime fecha1, DateTime fecha2) 
        {
            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            int total = 0;
            int procesados = 0;
            int inscriptos = 0;

            // 0 total, 1 procesados, 2 inscriptos
            foreach (DataRow fila in tramites.Rows)
            {
                DateTime date = (DateTime)fila[5];
                if (date >= dt1 & date < dt2)
                {
                    if ((string)fila[4] == "Procesado")
                    {
                        total++;
                        procesados++;
                    }
                    if((bool)fila[9] == true) 
                    {
                        inscriptos++;
                    }
                }
            }

            return new int[] { total, procesados, inscriptos };
        }

        public static string FindCumpleaños() 
        {
            LinkedListNode<Employee> employee = tmp.First;
            string c = "";

            for (int i = 0; i < tmp.Count; i++)
            {
                if (employee.Value.nombre != "Admin S." && employee.Value.fechaNacimiento == DateTime.Now)
                {
                    c = employee.Value.nombre;
                    break;
                }
                employee = employee.Next;
            }

            return c;
        }
        #endregion
    }
}
