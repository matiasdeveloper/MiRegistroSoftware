using Guna.UI.WinForms;
using MiRegistro.Models;
using MiRegistro.Views.Common;
using MiRegistro.Views.Main;
using MiRegistro.Views.TabPages;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controllers
{
    public class TramitesController
    {
        Tramites _view { get; set; }

        FormModel _formModel = new FormModel();
        TramitesViewModel _model = new TramitesViewModel(new MiRegistroEntity());

        public TramitesController(Tramites view)
        {
            this._view = view;

            _view.Load += new EventHandler(OnLoad);
            _view.btn_findfilter.Click += new EventHandler(OnClickFindFilter);

            _view.button_hoy.Click += new EventHandler(OnClickButtonQuickQuery);
            _view.button_ayer.Click += new EventHandler(OnClickButtonQuickQuery);
            _view.button_mes.Click += new EventHandler(OnClickButtonQuickQuery);

            _view.comboBox_rowPerPage.SelectedIndexChanged += new EventHandler(OnRowPerPageIndexChange);

            _view.btn_insertar.Click += new EventHandler(OnClickButtonInsertar);
            _view.btn_inscribir.Click += new EventHandler(OnClickButtonInscribir);

            _view.btn_refreshdata.Click += new EventHandler(OnClickUpdateData);

            _view.btn_previous.Click += new EventHandler(OnPreviousPage);
            _view.btn_next.Click += new EventHandler(OnNextPage);

            _view.button_acciones.Click += new EventHandler(OnClickAccionesPanel);
            _view.button_consultar.Click += new EventHandler(OnClickConsultarPanel);

            _view.btn_consultar.Click += new EventHandler(OnClickConsultar);
            _view.btn_cancelarconsulta.Click += new EventHandler(OnClickCancelarConsultar);

            _view.btn_inscribirsingle.Click += new EventHandler(OnClickInscribirSingle);
            _view.btn_error.Click += new EventHandler(OnClickMarcarError);
            _view.btn_editar.Click += new EventHandler(OnClickEditar);
            _view.btn_observar.Click += new EventHandler(OnClickObservar);
            _view.btn_eliminar.Click += new EventHandler(OnClickEliminar);

            _view.dg_tramites.CellFormatting += new DataGridViewCellFormattingEventHandler(TramitesCellFormating);

            _view.btn_editarsave.Click += new EventHandler(OnClickEditarSave);
            _view.btn_editarclose.Click += new EventHandler(OnClickEditarClose);

            _view.btn_savepdf.Click += new EventHandler(OnClickButtonSavePdf);
        }

        private void OnClickButtonSavePdf(object sender, EventArgs e)
        {
            if(PdfExporter.ExportDataGridViewInPdf(_view.dg_tramites, "ExportarPdf")) 
            {
                Dialog dialog = new Dialog(DialogResult.Sucess, "Pdf generado con exito. Tenes un total de " + _view.dg_tramites.Rows.Count + " filas exportadas.");
                dialog.Show();
            }
            else 
            {
                Dialog dialog = new Dialog(DialogResult.Fail, "Error: 22exporter. Por favor si el problema persiste comunicate con un profesional de MiRegistro");
                dialog.Show();
            }
        }

        private void OnClickEditarClose(object sender, EventArgs e)
        {
            _view.pn_editar.Visible = false;
        }
        private void OnClickEditarSave(object sender, EventArgs e)
        {
            _view.pn_editar.Visible = false;
            // Save changes
        }

        private void TramitesCellFormating(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_view.dg_tramites.Columns[e.ColumnIndex].Index == 3)  // Estado del tramite
            {
                var value = Convert.ToString(e.Value);
                switch (value) 
                {
                    case "Procesado":
                        e.CellStyle.ForeColor = Color.DarkBlue;
                        break;
                    case "Inscripto":
                        e.CellStyle.ForeColor = Color.Green;
                        break;
                    case "Observado":
                        e.CellStyle.ForeColor = Color.Orange;
                        break;
                }
            }

            if (_view.dg_tramites.Columns[e.ColumnIndex].Index == 6)  // Errores del tramite
            {
                var value = Convert.ToString(e.Value);
                if(value == "Sin errores")
                {
                    e.CellStyle.ForeColor = Color.Gray;
                } 
                else 
                {
                    e.CellStyle.ForeColor = Color.DarkRed;
                }
            }
        }

        private void OnClickEliminar(object sender, EventArgs e)
        {
            int id = _view.selectedIdDatagridview;

            if (_model.DeleteTramite(id) && _view.dg_tramites.SelectedRows.Count > 0) 
            {
                _view.dg_tramites.Rows.RemoveAt(_view.dg_tramites.SelectedRows[0].Index);

                Dialog dialog = new Dialog(DialogResult.Sucess, "Tramite eliminado con exito. Podra volver a restablecerlo en un futuro si lo desea.");
                dialog.Show();
            } 
        }
        private void OnClickInscribirSingle(object sender, EventArgs e)
        {
            // out
        }
        private void OnClickEditar(object sender, EventArgs e)
        {
            // here
            _view.pn_acciones.Visible = false;
            _view.currentPanelOpenOnFront = new GunaShadowPanel();

            _view.pn_editar.Visible = true;
        }
        private void OnClickObservar(object sender, EventArgs e)
        {
            // here
            TramitesObservar form = new TramitesObservar();
            form.Show();
        }
        private void OnClickMarcarError(object sender, EventArgs e)
        {
            // here
            TramitesError form = new TramitesError();
            form.Show();
        }

        private void OnClickCancelarConsultar(object sender, EventArgs e)
        {
            _view.pn_consulta.Visible = false;
        }
        private void OnClickConsultar(object sender, EventArgs e)
        {
            Tuple<DataTable,bool> result = _model.GetTramitesAdvanced(new ConsultaTableViewModel());

            if (result.Item2) 
            {
                if (result.Item1.Rows.Count > 0)
                {
                    _view.currentPanelOpenOnFront = new GunaShadowPanel();
                    _view.pn_consulta.Visible = false;
                }
                else
                {
                    _view.currentPanelOpenOnFront = new GunaShadowPanel();
                    _view.pn_consulta.Visible = false;
                }

                _view.DataSource = result.Item1;
                DataBind(_view.DataSource);

                Dialog dialog = new Dialog(DialogResult.Sucess, "Consulta realizada con exito. Tenes un total de " + result.Item1.Rows.Count + " filas de consulta.");
                dialog.Show();
            } 
            else 
            {
                Dialog dialog = new Dialog(DialogResult.Fail, "Error: 23fquery. Por favor si el problema persiste comunicate con un profesional de MiRegistro");
                dialog.Show();
            }
        }

        private void OnClickConsultarPanel(object sender, EventArgs e)
        {
            ShowMoreOptions(_view.pn_consulta);
        }
        private void OnClickAccionesPanel(object sender, EventArgs e)
        {
            ShowMoreOptions(_view.pn_acciones);
        }

        private void OnPreviousPage(object sender, EventArgs e)
        {
            if (_view.pageNumber == 1)
                return;

             _view.pageNumber -= 1;
             _view.dg_tramites.DataSource = ShowData(_view.pageNumber);        
        }
        private void OnNextPage(object sender, EventArgs e)
        {
            int lastPage = (_view.DataSource.Rows.Count / _view.pageSize);
            if (_view.pageNumber >= lastPage)
                return;

            _view.pageNumber += 1;
            _view.dg_tramites.DataSource = ShowData(_view.pageNumber);        
        }

        private void OnClickUpdateData(object sender, EventArgs e)
        {
            UpdateDataTramites();
        }
        private void OnClickButtonInscribir(object sender, EventArgs e)
        {
            TramitesInscribir form = new TramitesInscribir();
            form.Show();
        }
        private void OnClickButtonInsertar(object sender, EventArgs e)
        {
            TramitesInsertar form = new TramitesInsertar();
            form.Show();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            UpdateDataTramites();
            LoadAccessPrivileges();
        }
        private protected void UpdateDataTramites()
        {
            _view.DataSource = _model.GetTramitesQuickly().Item1;
            DisplayDataTramites();
        }

        private void LoadAccessPrivileges()
        {
            // Load privileges
        }

        private void OnRowPerPageIndexChange(object sender, EventArgs e)
        {
            DisplayDataTramites();
        }

        private void DisplayDataTramites()
        {
            // Find Data and Display
            DataBind(_view.DataSource);
        }
        private void DataBind(DataTable dataTable)
        {
            // Set data of datagridview
            _view.DataSource = dataTable;
            _view.dg_tramites.AutoGenerateColumns = false;
            _view.dg_tramites.DataSource = ShowData(1);
        }
        private DataTable ShowData(int pageNumber)
        {
            DataTable dt = new DataTable();
            int startIndex = _view.pageSize * (pageNumber - 1);
            int lastIndex = startIndex + _view.pageSize;

            var result = _view.DataSource
                                .AsEnumerable()
                                .Where((s, k) => (k >= startIndex && k < lastIndex));

            foreach (DataColumn colunm in _view.DataSource.Columns)
            {
                dt.Columns.Add(colunm.ColumnName);
            }

            foreach (var item in result)
            {
                dt.ImportRow(item);
            }

            _view.lbl_paging.Text = string.Format("Mostrando {0} - {1} de {2} resultados", pageNumber, (_view.DataSource.Rows.Count / _view.pageSize), _view.DataSource.Rows.Count);
            return dt;
        }

        private void OnClickFindFilter(object sender, EventArgs e)
        {
            ConsultaTableViewModel query = new ConsultaTableViewModel();
            Tuple<DataTable, bool> result = new Tuple<DataTable, bool>(new DataTable(), true);
            var valueToFind = _view.txtBox_domain.Text;

            if (valueToFind != "" && _view.txtBox_domain.Text != "Buscar por dominio") 
            {
                // Find filter here!
                query.Dominio = valueToFind.ToUpper();
                result = _model.GetTramitesSimple(query);
            }
        }

        private void OnClickButtonQuickQuery(object sender, EventArgs e)
        {
            if (SelectQueryButton((Label)sender)) 
            {
                Label obj = (Label)sender;
                ConsultaTableViewModel query = new ConsultaTableViewModel();
                Tuple<DataTable, bool> result;

                // Query
                switch (obj.Text)
                {
                    case "Hoy":
                        query.firstDate = FechaModel.dateNow;
                        query.lastDate = FechaModel.dateNow.AddDays(1);
                        result = _model.GetTramitesSimple(query);
                        break;
                    case "Ayer":
                        query.firstDate = FechaModel.dateNow.AddDays(-1);
                        query.lastDate = FechaModel.dateNow;
                        result = _model.GetTramitesSimple(query);
                        break;
                    case "Mes":
                        query.firstDate = FechaModel.firstDayOfMonth;
                        query.lastDate = FechaModel.lastDayOfMonth.AddDays(1);
                        result = _model.GetTramitesSimple(query);
                        break;
                    default:
                        result = new Tuple<DataTable, bool>(new DataTable(), true);
                        break;
                }


                _view.DataSource = result.Item1;
                DataBind(_view.DataSource);
            }
            else 
            {
                // Refresh query
            }
        }

        private bool SelectQueryButton(Label click)
        {
            if (click == _view.currentQuerySelected){ return false; }
            else
            {
                if (_view.currentQuerySelected != null)
                {
                     _view.currentQuerySelected.ForeColor = System.Drawing.Color.DarkGray;
                }
                _view.currentQuerySelected = click;
                click.ForeColor = System.Drawing.Color.FromArgb(58, 122, 252);
                return true;
            }
        }

        private void ShowMoreOptions(GunaShadowPanel panel)
        {
            if (panel == _view.currentPanelOpenOnFront || panel.Visible == true)
            {
                _view.currentPanelOpenOnFront = new GunaShadowPanel();
                panel.Visible = false;
            }
            else
            {
                // Open panel
                if (_view.currentPanelOpenOnFront != null)
                {
                    _view.currentPanelOpenOnFront.Visible = false;
                }
                _view.currentPanelOpenOnFront = panel;

                panel.Visible = false;
                _view.gunaTransition.Show(panel);
            }
        }
    }

    enum QuickQuery 
    {
        Hoy,
        Ayer,
        Mes
    }
}
