using DevExpress.XtraPrinting.Export;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;

using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using GeisaBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGEISA
{
    public partial class frmNominas : DevExpress.XtraEditors.XtraForm
    {
        private Nominas nomina { get; set; }

        private Controler _controler = new Controler();
        private Controler Controler
        {
            get
            {
                return _controler;
            }
        }

        bool tienePermisoAgregar, tienePermisoModificar, tienePermisoEliminar;

        private DateTime fechaIni, fechaFin;

        public frmNominas()
        {
            InitializeComponent();
            //DevExpress.XtraPrinting.Export
            //DevExpress.XtraExport ExportSettings.DefaultExportType = ExportType.WYSIWYG;
            Controler.PermisosEnFormulario(Name);
            btnAgregar.Enabled = tienePermisoAgregar = Controler.TienePermiso(PermisosEnum.Agregar);
            btnEditar.Enabled = tienePermisoModificar = Controler.TienePermiso(PermisosEnum.Actualizar);
            btnEliminar.Enabled = tienePermisoEliminar = Controler.TienePermiso(PermisosEnum.Eliminar);
        }

        private bool usuarioValido()
        {
            if (frmPrincipal.UsuarioDelSistema.ToString().ToUpper() == "ANA" || frmPrincipal.UsuarioDelSistema.ToString().ToUpper() == "CONTABILIDAD")
                return true;
            else
            {
                foreach (Control c in Controls)
                {
                    c.Enabled = false;
                }
                return false;
            }            
        }
        private void frmNominas_Load(object sender, EventArgs e)
        {
            //if (usuarioValido())
            //{
                llenaCombos();
                monthCalendar_DateSelected(null, null);
            //}
        }

        private void llenaCombos()
        {
            luObra.DataSource = Controler.Model.Obra.ToList();
            luObra.DisplayMember = "Nombre";
            luObra.ValueMember = "Id";

            luEmpleado.DataSource = Controler.Model.Empleado.Where(D => D.Activo == true).ToList();
            luEmpleado.DisplayMember = "NombreCompleto";
            luEmpleado.ValueMember = "Id";

            //DataTable dtEstatus = new DataTable();
            //dtEstatus.Columns.Add("Id", typeof(int));
            //dtEstatus.Columns.Add("Nombre", typeof(string));
            //dtEstatus.Rows.Add(new object[] { 1, "EXTRAS" });
            //dtEstatus.Rows.Add(new object[] { 2, "PAGOS" });
            //dtEstatus.Rows.Add(new object[] { 3, "VIATICOS" });
            //dtEstatus.Rows.Add(new object[] { 4, "FALTAS" });
            //luTipo.DataSource = dtEstatus.DefaultView;
            //luTipo.ValueMember = "Id";
            //luTipo.DisplayMember = "Nombre";
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            
            if (monthCalendar.SelectionRange.Start.DayOfWeek == DayOfWeek.Sunday)
            {
                fechaIni = FirstDayOfWeek(monthCalendar.SelectionRange.Start.AddDays(-1)).AddDays(1);
                fechaFin = LastDayOfWeek(monthCalendar.SelectionRange.Start.AddDays(-1)).AddDays(1);
            }
            else
            {
                fechaIni = FirstDayOfWeek(monthCalendar.SelectionRange.Start).AddDays(1);
                fechaFin = LastDayOfWeek(monthCalendar.SelectionRange.Start).AddDays(1);
            }
            lblSemana.Text = "Nomina Del \n" + fechaIni.ToShortDateString() + " al " + fechaFin.ToShortDateString();
            llenaGrid();
            //grid.DataSource = Controler.Model.Nominas.Where(N => N.PeriodoInicio >= fechaIni && N.PeriodoFin <= fechaFin).ToList();
        }

        private void llenaGrid()
        {
            if (chkActual.Checked)
            {
                if (rgOpcion.EditValue != null)
                {

                    if (Convert.ToInt32(rgOpcion.EditValue) == 1)
                    {
                        grid.DataSource = Controler.Model.Nominas.Where(N => N.PeriodoInicio >= fechaIni && N.PeriodoFin <= fechaFin).ToList();
                    }
                    else if (Convert.ToInt32(rgOpcion.EditValue) == 2) //semanal
                    {
                        List<Nominas> items = Controler.Model.Nominas.Where(N => N.PeriodoInicio >= fechaIni && N.PeriodoFin <= fechaFin).ToList();
                        List<Nominas> itemsOk=new List<Nominas>();
                        foreach (Nominas item in items)
                        {
                            EmpleadoNomina empleadoNomina = item.Empleado.EmpleadoNomina.FirstOrDefault();
                            if(empleadoNomina!=null){

                                int? tipoNomina = empleadoNomina.TipoNomina.HasValue ? Convert.ToInt32(empleadoNomina.TipoNomina) : (int?)null;
                                if ((tipoNomina.HasValue ? tipoNomina.Value : 0) == 1)
                                    itemsOk.Add(item);
                            }
                        }
                        grid.DataSource = itemsOk.ToList();
                    }
                    else if (Convert.ToInt32(rgOpcion.EditValue) == 3) // quincenal
                    {
                        List<Nominas> items = Controler.Model.Nominas.Where(N => N.PeriodoInicio >= fechaIni && N.PeriodoFin <= fechaFin).ToList();
                        List<Nominas> itemsOk = new List<Nominas>();
                        foreach (Nominas item in items)
                        {
                            EmpleadoNomina empleadoNomina = item.Empleado.EmpleadoNomina.FirstOrDefault();
                            if (empleadoNomina != null)
                            {

                                int? tipoNomina = empleadoNomina.TipoNomina.HasValue ? Convert.ToInt32(empleadoNomina.TipoNomina) : (int?)null;
                                if ((tipoNomina.HasValue ? tipoNomina.Value : 0) == 2)
                                    itemsOk.Add(item);
                            }
                        }
                        grid.DataSource = itemsOk.ToList();
                    }
                    else // mensual
                    {
                        List<Nominas> items = Controler.Model.Nominas.Where(N => N.PeriodoInicio >= fechaIni && N.PeriodoFin <= fechaFin).ToList();
                        List<Nominas> itemsOk = new List<Nominas>();
                        foreach (Nominas item in items)
                        {
                            EmpleadoNomina empleadoNomina = item.Empleado.EmpleadoNomina.FirstOrDefault();
                            if (empleadoNomina != null)
                            {

                                int? tipoNomina = empleadoNomina.TipoNomina.HasValue ? Convert.ToInt32(empleadoNomina.TipoNomina) : (int?)null;
                                if ((tipoNomina.HasValue ? tipoNomina.Value : 0) == 3)
                                    itemsOk.Add(item);
                            }
                        }
                        grid.DataSource = itemsOk.ToList();
                    }
                }

            }
            else if(chkTodos.Checked)
            {
                grid.DataSource = Controler.Model.Nominas.ToList();
            }
            else
            {
                return;
            }
            
            //if(this.fechaIni !=null && this.fechaFin!=null)
            //    grid.DataSource = Controler.Model.Nominas.Where(N => N.PeriodoInicio >= fechaIni && N.PeriodoFin <= fechaFin).ToList();
        }

        public static DateTime FirstDayOfWeek(DateTime date)
        {
            DayOfWeek fdow = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
            int offset = fdow - date.DayOfWeek;
            DateTime fdowDate = date.AddDays(offset);
            return fdowDate;
        }

        public static DateTime LastDayOfWeek(DateTime date)
        {
            DateTime ldowDate = FirstDayOfWeek(date).AddDays(6);
            return ldowDate;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            abrirForm(true);
        }

        private void abrirForm(bool nuevo)
        {
            var form = new frmNominasAgregar(this.Controler);
            form.Text = "Nomina : " + (nuevo ? "Nuevo" : "Editar");
            form.lblPeriodo.Text = "Nomina Del " + (this.nomina != null ? this.nomina.PeriodoInicio.Value.ToShortDateString() : fechaIni.ToShortDateString()) + " al " + (this.nomina != null ? this.nomina.PeriodoFin.Value.ToShortDateString() : fechaFin.ToShortDateString());
            if (!nuevo) form.nominas = this.nomina;
            else form.nominas = null;
            form.FechaIni = this.fechaIni;
            form.FechaFin = this.fechaFin;

            form.ShowDialog();

            if (nuevo)
            {
                llenaGrid();
            }
            else
            {
                grid.RefreshDataSource();
            }

            gv_FocusedRowChanged(null, null);
        }

        private void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gv.RowCount > 0)
            {
                nomina = gv.GetFocusedRow() as Nominas;

                if (nomina != null)
                {
                    botones(2);
                }
            }
        }

        private void botones(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    btnAgregar.Visible = true;
                    btnEditar.Visible = false;
                    btnEliminar.Visible = false;
                    break;
                case 2:
                    btnAgregar.Visible = true;
                    btnEditar.Visible = true;
                    btnEliminar.Visible = true;
                    break;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gv.SelectedRowsCount == 1)
            {
                abrirForm(false);
            }
            else
            {
                new frmMessageBox(true) { Message = "Favor de seleccionar el elemento a editar.", Title = "Confirmación" }.ShowDialog();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmMessageBox msg = new frmMessageBox(false) { Message = "¿Estas seguro de eliminar esta Nomina?", Title = "Eliminar Registro" };
            msg.ShowDialog();

            if (msg.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Nominas nominaEliminar = gv.GetFocusedRow() as Nominas;

                if (nominaEliminar != null)
                {
                    DbTransaction transaccion = null;

                    try
                    {
                        transaccion = Controler.Model.BeginTransaction();
                        List<NominasDetalle> detalle = nominaEliminar.NominasDetalle.ToList();
                        if (detalle.Count > 0)
                        {
                            foreach (NominasDetalle f in detalle)
                            {
                                Controler.Model.DeleteObject(f);

                            }
                            Controler.Model.DeleteObject(nominaEliminar);
                        }
                        else
                        {
                            Controler.Model.DeleteObject(nominaEliminar);
                        }

                        Controler.Model.SaveChanges();
                        transaccion.Commit();
                        new frmMessageBox(true) { Message = "La Nomina ha sido Eliminada.", Title = "Aviso" }.ShowDialog();
                        gv.DeleteRow(gv.FocusedRowHandle);
                        gv.RefreshData();
                    }
                    catch (Exception ex)
                    {
                        new frmMessageBox(true) { Message = "Error al quitar la Nomina: " + ex.InnerException.Message, Title = "Error" }.ShowDialog();
                        if (transaccion != null) transaccion.Rollback();
                    }
                    finally
                    {
                        Controler.Model.CloseConnection();
                    }
                }
                else
                {
                    new frmMessageBox(true) { Message = "No es posible eliminar esta Nomina.", Title = "Error" }.ShowDialog();
                }
            }
            else
            {
                new frmMessageBox(true) { Message = "Seleccione una Orden a Eliminar.", Title = "Aviso" }.ShowDialog();
            }
            
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                                
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {

                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;
                    switch (fileExtenstion)
                    {
                        case ".xls":
                            gv.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            gv.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            gv.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            gv.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            gv.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            gv.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }
                }
            } //
        }

        private void gv_DoubleClick(object sender, EventArgs e)
        {
            var view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            var pt = view.GridControl.PointToClient(Control.MousePosition);
            var info = view.CalcHitInfo(pt);

            if (info.InRow || info.InRowCell)
            {
                btnEditar_Click(null, null);
            }
        }

        private void chkActual_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkActual.Checked)
            {
                chkTodos.Checked = false;
                rgOpcion.Enabled = true;
            }
            else
            {
                grid.DataSource = null;
                rgOpcion.EditValue = null;
                rgOpcion.Enabled = false;
            }
        }

        private void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked)
            {
                chkActual.Checked = false;
                llenaGrid();
            }
            else
            {
                grid.DataSource = null;
            }
        }

        private void rgOpcion_EditValueChanged(object sender, EventArgs e)
        {
            llenaGrid();
        }

        private void chkTodasSemanas_CheckedChanged(object sender, EventArgs e)
        {
            llenaGrid();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (fechaIni != null && fechaFin != null)
            {
                if (Controler.Model.Nominas.Where(N => N.PeriodoInicio >= fechaIni && N.PeriodoFin <= fechaFin).Count() == 0)
                {
                    var form = new frmImportarNomina(this.Controler);
                    form.fechaIniSource = this.fechaIni;
                    form.fechaFinSource = this.fechaFin;
                    form.ShowDialog();

                    //if (nuevo)
                    //{
                    //    llenaGrid();
                    //}
                    //else
                    //{
                    grid.RefreshDataSource();
                    //}

                    gv_FocusedRowChanged(null, null);
                }
                else
                {
                    new frmMessageBox(true) { Message = "No es posible Importar a esta semana, ya que se encontraron nominas Creada.", Title = "Aviso" }.ShowDialog();
                }
            }
            else
            {
                new frmMessageBox(true) { Message = "Seleccione una Semana a Importar.", Title = "Aviso" }.ShowDialog();
            }
        }
        private void gv_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

             GridView View = sender as GridView;
            var row = gv.GetRow(e.RowHandle);
            if (row != null)
            {
                 if( e.Column.FieldName.In("ExtrasCalc","CompensacionCalc","AdeudosPagosCalc","FaltasCalc","Infonavit","ViaticosCalc")){ 
                string c1 = View.GetRowCellDisplayText(e.RowHandle, View.Columns["ExtrasCalc"]).ToString();
                string c2 = View.GetRowCellDisplayText(e.RowHandle, View.Columns["CompensacionCalc"]).ToString();
                string c3 = View.GetRowCellDisplayText(e.RowHandle, View.Columns["AdeudosPagosCalc"]).ToString();
                string c4 = View.GetRowCellDisplayText(e.RowHandle, View.Columns["FaltasCalc"]).ToString();
                string c5 = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Infonavit"]).ToString();
                string c6 = View.GetRowCellDisplayText(e.RowHandle, View.Columns["ViaticosCalc"]).ToString();

                if (e.Column.FieldName == "ExtrasCalc" && !c1.In("$0.00",string.Empty))                
                    e.Appearance.ForeColor = Color.Red;
                else if (e.Column.FieldName == "CompensacionCalc" && !c2.In("$0.00", string.Empty))
                    e.Appearance.ForeColor = Color.Red;
                else if (e.Column.FieldName == "AdeudosPagosCalc" && !c3.In("$0.00", string.Empty)) 
                    e.Appearance.ForeColor = Color.Red;
                else if (e.Column.FieldName == "FaltasCalc" && !c4.In("$0.00", string.Empty))
                    e.Appearance.ForeColor = Color.Red;
                else if (e.Column.FieldName == "Infonavit" && !c5.In("$0.00", string.Empty))
                    e.Appearance.ForeColor = Color.Red;
                else if (e.Column.FieldName == "ViaticosCalc" && !c6.In("$0.00", string.Empty))
                    e.Appearance.ForeColor = Color.Red;
                else
                    e.Appearance.ForeColor = Color.Black;
                 }
                }            
        }
    }
}
