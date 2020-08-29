using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using LayerBusiness;
using LayerSoporte.Cache;

namespace LayerPresentation
{
    public partial class frm_estadisticas : Form
    {
        Cn_Tramites _handlerTramites = new Cn_Tramites();
        Cn_Empleados _cnEmpleados = new Cn_Empleados();
        public frm_estadisticas()
        {
            InitializeComponent();
            dateNow = DateTime.Now;

            Fechas.firstDayOfMonth = new DateTime(dateNow.Year, dateNow.Month, 1);
            Fechas.lastDayOfMonth = Fechas.firstDayOfMonth.AddMonths(1).AddDays(-1);

            tmp = Cn_Employee.data.GetCache().GetUsers();
        }

        DateTime dateNow = DateTime.Now;
        public static LinkedList<Employee> tmp;
        bool isIncripto = true;
        
        private void refreshDashboard() 
        {
            chargeDataTabTramites();
            chargeDataTabErrores();
            //chargeDataTabFormularios();
        }
        private void refreshData() 
        {
            _cnEmpleados.GenerateEmployeesDataCache();
        }
        private void chargeDataTabFormularios()
        {
            throw new NotImplementedException();
        }
        private void chargeDataTabErrores()
        {
            #region ERRORES LABEL
            lbl_totalerrores_mes.Text = _handlerTramites.countByError(true, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth).ToString();
            lbl_totalerrores_parcial_mes.Text = _handlerTramites.countByTipoError(1, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth).ToString();
            lbl_totalerrores_total_mes.Text = _handlerTramites.countByTipoError(2, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth).ToString();

            lbl_totalerrores_dia.Text = _handlerTramites.countByError(true, dateNow, dateNow.AddDays(1)).ToString();
            lbl_totalerrores_parcial_dia.Text = _handlerTramites.countByTipoError(1, dateNow, dateNow.AddDays(1)).ToString();
            lbl_totalerrores_total_dia.Text = _handlerTramites.countByTipoError(2, dateNow, dateNow.AddDays(1)).ToString();

            lbl_totalerrores_hist.Text = _handlerTramites.countTramitesAllError().ToString();
            lbl_totalerrores_parcial_hist.Text = _handlerTramites.countTramitesAllError_PorTipo(1).ToString();
            lbl_totalerrores_total_hist.Text = _handlerTramites.countTramitesAllError_PorTipo(2).ToString();
            #endregion
            #region ERRORES SPECIFIC
            Label[] names = { lbl_name0, lbl_name1, lbl_name2, lbl_name3, lbl_name4, lbl_name5, lbl_name6, lbl_name7, lbl_name8 };
            Label[] errores = { lbl_countErrores0, lbl_countErrores1, lbl_countErrores2, lbl_countErrores3, lbl_countErrores4, lbl_countErrores5, lbl_countErrores6, lbl_countErrores7, lbl_countErrores8 };
            Label[] erroresparciales = { lbl_errorParcial_0, lbl_errorParcial_1, lbl_errorParcial_2, lbl_errorParcial_3, lbl_errorParcial_4, lbl_errorParcial_5, lbl_errorParcial_6, lbl_errorParcial_7, lbl_errorParcial_8 };
            Label[] errorestotales = { lbl_errorTotal_0, lbl_errorTotal_1, lbl_errorTotal_2, lbl_errorTotal_3, lbl_errorTotal_4, lbl_errorTotal_5, lbl_errorTotal_6, lbl_errorTotal_7, lbl_errorTotal_8 };

            ChargeNames(names);
            ChargeErrores(errores, erroresparciales, errorestotales);
            #endregion
            #region TOP ERRORES
            ChargeTopErrores(dg_topErrores);
            #endregion
            #region CHART
            chart_errores.Series["Empleados"].SetDefault(true);
            chart_errores.Series["Empleados"].Enabled = true;
            chart_errores.Visible = true;

            Random rnd = new Random();

            for (int q = 0; q < 10; q++)
            {
                int first = rnd.Next(0, 10);
                int second = rnd.Next(0, 15);
                chart_errores.Series["Empleados"].Points.AddXY(first, second);
            }
            chart_errores.Show();
            #endregion
        }

        private void chargeDataTabTramites()
        {
            #region HISTORICO
            lbl_totaltramites.Text = _handlerTramites.countAllTramites().ToString();
            lbl_totalerrores.Text = _handlerTramites.countTramitesAllError().ToString();
            lbl_totalempleados.Text = _handlerTramites.countEmpleados().ToString();
            lbl_totaltipos.Text = _handlerTramites.countAllTipoTramites().ToString();
            lbl_totalprocesados.Text = _handlerTramites.countTramitesAllProcesado().ToString();
            lbl_totalinscriptos.Text = _handlerTramites.countTramitesAllInscripto().ToString();
            #endregion
            #region FECHAS
            //lbl_parcialinscriptos_ayer.Text = _handlerTramites.countByInscripto(isIncripto, dateNow.ToUniversalTime(), dateNow.AddDays(1)).ToString();
            lbl_parcialinscriptos_dia.Text = _handlerTramites.countByInscripto(isIncripto, dateNow, dateNow.AddDays(1)).ToString();
            lbl_parcialinscriptos_mes.Text = _handlerTramites.countByInscripto(isIncripto, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth).ToString();
            
            //lbl_parcialprocesados_ayer.Text = _handlerTramites.countByDate(dateNow.ToUniversalTime(), dateNow.AddDays(1)).ToString();
            lbl_parcialprocesados_dia.Text = _handlerTramites.countByDate(dateNow, dateNow.AddDays(1)).ToString();
            lbl_parcialprocesados_mes.Text = _handlerTramites.countByDate(Fechas.firstDayOfMonth, Fechas.lastDayOfMonth).ToString();
            #endregion
            #region EMPLEADOS
            Label[] names_inscriptosMes = { lblnombreinscriptos_0 , lblnombreinscriptos_1, lblnombreinscriptos_2 , lblnombreinscriptos_3 , lblnombreinscriptos_4, lblnombreinscriptos_5, lblnombreinscriptos_6, lblnombreinscriptos_7, lblnombreinscriptos_8};
            Label[] names_procesadosMes = { lblnombre_0, lblnombre_1, lblnombre_2, lblnombre_3, lblnombre_4, lblnombre_5, lblnombre_6, lblnombre_7, lblnombre_8 };
            Label[] count_inscriptosMes = { lbl_countInscriptos_0, lbl_countInscriptos_1, lbl_countInscriptos_2, lbl_countInscriptos_3, lbl_countInscriptos_4, lbl_countInscriptos_5, lbl_countInscriptos_6, lbl_countInscriptos_7, lbl_countInscriptos_8 };
            Label[] count_procesadosMes = { lbl_countProcesados_0, lbl_countProcesados_1, lbl_countProcesados_2, lbl_countProcesados_3, lbl_countProcesados_4, lbl_countProcesados_5, lbl_countProcesados_6, lbl_countProcesados_7, lbl_countProcesados_8 };

            ChargeNames(names_inscriptosMes);
            ChargeNames(names_procesadosMes);
            ChargeEtapa(count_inscriptosMes, count_procesadosMes);
            #endregion
            #region TOP TRAMITES
            ChargeTopTramites(dg_topTramites);
            #endregion
            #region CHART
            chart_tramites.Series["Empleados"].SetDefault(true);
            chart_tramites.Series["Empleados"].Enabled = true;
            chart_tramites.Visible = true;

            Random rnd = new Random();
            for (int q = 0; q < 10; q++)
            {
                int first = rnd.Next(0, 10);
                int second = rnd.Next(0, 15);
                chart_tramites.Series["Empleados"].Points.AddXY(first, second);
            }
            chart_tramites.Show();
            #endregion
        }

        private void ChargeNames(Label[] labels)
        {
            LinkedListNode<Employee> employee = tmp.First;

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
        private void ChargeErrores(Label[] errores, Label[] erroresparciales, Label[] errorestotales)
        {
            LinkedListNode<Employee> employee = tmp.First;
            int[] e;

            for (int i = 0; i < tmp.Count; i++)
            {
                e = FindErrores(employee.Value.tramitesMes, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
                switch (i)
                {
                    case 0:
                        panelError_user_0.Enabled = true;
                        errores[0].Text = e[0].ToString();
                        erroresparciales[0].Text = e[1].ToString();
                        errorestotales[0].Text = e[2].ToString();
                        break;
                    case 1:
                        panelError_user_1.Enabled = true;
                        errores[1].Text = e[0].ToString();
                        erroresparciales[1].Text = e[1].ToString();
                        errorestotales[1].Text = e[2].ToString();
                        break;
                    case 2:
                        panelError_user_2.Enabled = true;
                        errores[2].Text = e[0].ToString();
                        erroresparciales[2].Text = e[1].ToString();
                        errorestotales[2].Text = e[2].ToString();
                        break;
                    case 3:
                        panelError_user_3.Enabled = true;
                        errores[3].Text = e[0].ToString();
                        erroresparciales[3].Text = e[1].ToString();
                        errorestotales[3].Text = e[2].ToString();
                        break;
                    case 4:
                        panelError_user_4.Enabled = true;
                        errores[4].Text = e[0].ToString();
                        erroresparciales[4].Text = e[1].ToString();
                        errorestotales[4].Text = e[2].ToString();
                        break;
                    case 5:
                        panelError_user_5.Enabled = true;
                        errores[5].Text = e[0].ToString();
                        erroresparciales[5].Text = e[1].ToString();
                        errorestotales[5].Text = e[2].ToString();
                        break;
                    case 6:
                        panelError_user_6.Enabled = true;
                        errores[6].Text = e[0].ToString();
                        erroresparciales[6].Text = e[1].ToString();
                        errorestotales[6].Text = e[2].ToString();
                        break;
                    case 7:
                        panelError_user_7.Enabled = true;
                        errores[7].Text = e[0].ToString();
                        erroresparciales[7].Text = e[1].ToString();
                        errorestotales[7].Text = e[2].ToString();
                        break;
                    case 8:
                        panelError_user_8.Enabled = true;
                        errores[8].Text = e[0].ToString();
                        erroresparciales[8].Text = e[1].ToString();
                        errorestotales[8].Text = e[2].ToString();
                        break;
                }
                employee = employee.Next;
            }
        }
        private void ChargeEtapa(Label[] inscripto, Label[] procesados)
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
        private void ChargeTopErrores(DataGridView dt)
        {
            LinkedListNode<Employee> employee = tmp.First;

            DataTable table = CreateNewTopTable();

            int[] e;

            for (int i = 0; i < tmp.Count; i++)
            {
                e = FindErrores(employee.Value.tramitesMes, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
                AddRowDataForTheTOP(table, employee.Value.nombre, employee.Value.id, e[0], e[1], e[2]);
                employee = employee.Next;
            }

            dt.AutoGenerateColumns = false;
            dt.DataSource = table;
        }
        private void ChargeTopTramites(DataGridView dt)
        {
            LinkedListNode<Employee> employee = tmp.First;

            DataTable table = CreateNewTopTable();

            int[] e;

            for (int i = 0; i < tmp.Count; i++)
            {
                e = FindTramites(employee.Value.tramitesMes, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
                AddRowDataForTheTOP(table, employee.Value.nombre, employee.Value.id, e[0], e[1], e[2]);
                employee = employee.Next;
            }

            dt.AutoGenerateColumns = false;
            dt.DataSource = table;
        }

        private int[] FindErrores(DataTable employee, DateTime fecha1, DateTime fecha2) 
        {
            DateTime dt1 = new DateTime(fecha1.Year, fecha1.Month, fecha1.Day, 0, 0, 0);
            DateTime dt2 = new DateTime(fecha2.Year, fecha2.Month, fecha2.Day, 0, 0, 0);
            dt2 = dt2.AddDays(1);

            int errores = 0;
            int parciales = 0;
            int totales = 0;

            // 1 parciales, 2 totales
            foreach(DataRow fila in employee.Rows) 
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
        private int[] FindEtapas(DataTable employee, DateTime fecha1, DateTime fecha2)
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
        private int[] FindTramites(DataTable employee, DateTime fecha1, DateTime fecha2)
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
        private void AddRowDataForTheTOP(DataTable table, string empleado, int top, int total, int erroresP, int erroresT) 
        {
            DataRow row;

            row = table.NewRow();
            row["Id"] = top;
            row["Empleado"] = empleado;
            row["Total"] = total;
            row["Data1"] = erroresP;
            row["Data2"] = erroresT;

            table.Rows.Add(row);
        }

        private DataTable CreateNewTopTable()
        {
            DataTable table = new DataTable();
            DataColumn column;
            // Create new DataColumn, set DataType, ColumnName and add to DataTable.
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "Id";
            table.Columns.Add(column);

            // Create a first column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Empleado";
            table.Columns.Add(column);

            // Create second column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Total";
            table.Columns.Add(column);

            // Create third column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Data1";
            table.Columns.Add(column);

            // Create four column.
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Data2";
            table.Columns.Add(column);

            return table;
        }
        public static DateTime FirstDayOfWeek(DateTime dt)
        {
            var culture = System.Threading.Thread.CurrentThread.CurrentCulture;
            var diff = dt.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if (diff < 0)
                diff += 7;
            return dt.AddDays(-diff).Date;
        }
        private DataTable GetDataTramitesTableWithID(int id)
        {
            LinkedList<Employee> tmp = Cn_Employee.data.GetCache().GetUsers();
            LinkedListNode<Employee> employee = tmp.First;

            DataTable table = new DataTable();

            for (int i = 0; i < tmp.Count; i++)
            {
                if(employee.Value.id == id) 
                {
                    table = employee.Value.tramitesMes;
                    break;
                }
                employee = employee.Next;
            }

            return table;
        }
        private void btn_top_Click(object sender, EventArgs e)
        {
            int id = (int)dg_topTramites.SelectedRows[0].Cells[0].Value;
            string empleado = (string)dg_topTramites.SelectedRows[0].Cells[1].Value.ToString();
            string mes = dateNow.Month.ToString();
            DataTable dt = null;
            dt = GetDataTramitesTableWithID(id);
            int[] tramites = FindTramites(dt, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
            int[] errores = FindErrores(dt, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
            
            frm_tramites_pantallaCompleta mv = new frm_tramites_pantallaCompleta(id, empleado, mes, dt, errores, tramites);
            mv.Show();
        }
        private void btn_toperror_Click_1(object sender, EventArgs e)
        {
            int id = (int)dg_topErrores.SelectedRows[0].Cells[0].Value;
            string empleado = (string)dg_topErrores.SelectedRows[0].Cells[1].Value.ToString();
            string mes = dateNow.Month.ToString();

            DataTable dt = null;
            dt = GetDataTramitesTableWithID(id);
            int[] tramites = FindTramites(dt, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);
            int[] errores = FindErrores(dt, Fechas.firstDayOfMonth, Fechas.lastDayOfMonth);

            frm_tramites_pantallaCompleta mv = new frm_tramites_pantallaCompleta(id, empleado, mes, dt, errores, tramites);
            mv.Show();
        }

        private void dg_topErrores_CellFormatting_1(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dg_topErrores.Columns[e.ColumnIndex].Name == "Total")
            {
                if (Convert.ToInt32(e.Value) >= 3)
                {
                    // Rojo
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(192, 25, 28);
                }
                else
                {
                    // Verde
                    e.CellStyle.ForeColor = Color.White;
                    e.CellStyle.BackColor = Color.FromArgb(81, 189, 51);
                }
            }
        }
        private void dg_topTramites_SelectionChanged(object sender, EventArgs e)
        {
            if(dg_topTramites.SelectedRows.Count != 0) 
            {
                txtBox_empleado.Text = this.dg_topTramites.SelectedRows[0].Cells["Empleado1"].Value.ToString();
            }
        }
        private void dg_topErrores_SelectionChanged(object sender, EventArgs e)
        {
            if (dg_topErrores.SelectedRows.Count != 0)
            {
                textBox1.Text = this.dg_topErrores.SelectedRows[0].Cells["Empleado"].Value.ToString();
            }
        }       
        private void timer1_Tick(object sender, EventArgs e)
        {
            txtBox_fecha.Text = DateTime.Now.ToString();
        }
        private void btn_refreshdata_Click(object sender, EventArgs e)
        {
            refreshData();
            refreshDashboard();
        }

        private void frm_estadisticas_Load(object sender, EventArgs e)
        {
            refreshDashboard();
        }

    }
}
