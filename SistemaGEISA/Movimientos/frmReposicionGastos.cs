using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GeisaBD;
using System.Data;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.Common;
using System.IO;

namespace SistemaGEISA
{
    public partial class frmReposicionGastos : XtraForm
    {
        private Controler _controler = new Controler();

        private Controler Controler
        {
            get
            {
                return _controler;
            }
        }

        private Pagos pagos { get; set; }

        private DataTable dt;

        bool tienePermisoAgregar, tienePermisoModificar, tienePermisoCancelar;

        public frmReposicionGastos()
        {
            InitializeComponent();
            Controler.PermisosEnFormulario(Name);
            btnNuevo.Enabled = tienePermisoAgregar = Controler.TienePermiso(PermisosEnum.Agregar);
            btnEditar.Enabled = tienePermisoModificar = Controler.TienePermiso(PermisosEnum.Actualizar);
            tienePermisoCancelar = Controler.TienePermiso(PermisosEnum.Cancelar);
        }

        private void llenaGrid()
        {
            grid.DataSource = Controler.Model.Pagos.Where(P => P.TipoMovimientoId == TipoMovimientoEnum.Reposicion_Gastos.Id).ToList();
            //dt = new DataTable();
            //dt.Columns.Add("Id", typeof(int));
            //dt.Columns.Add("Folio", typeof(string));
            //dt.Columns.Add("Fecha", typeof(DateTime));
            //dt.Columns.Add("EmpleadoNombre", typeof(string));
            //dt.Columns.Add("EmpresaNombre", typeof(string));
            //dt.Columns.Add("TipoPagoNombre", typeof(string));
            //dt.Columns.Add("BancosNombre", typeof(string));
            //dt.Columns.Add("Referencias", typeof(string));
            //dt.Columns.Add("Total", typeof(double));
            //dt.Columns.Add("MontoPagar", typeof(double));
            //dt.Columns.Add("Diferencia", typeof(double));
            //grid.DataSource = dt;
            //foreach (Pagos pagos in Controler.Model.Pagos.Where(P => P.TipoMovimientoId == TipoMovimientoEnum.Reposicion_Gastos.Id).ToList())
            //{
            //    gv.AddNewRow();

            //    int rowHandle = gv.GetRowHandle(gv.DataRowCount);
            //    gv.SetRowCellValue(rowHandle, gv.Columns["Id"], pagos.Id);
            //    gv.SetRowCellValue(rowHandle, gv.Columns["Folio"], pagos.Folio);
            //    gv.SetRowCellValue(rowHandle, gv.Columns["Fecha"], pagos.Fecha);
            //    gv.SetRowCellValue(rowHandle, gv.Columns["EmpleadoNombre"], pagos.EmpleadoNombre);
            //    gv.SetRowCellValue(rowHandle, gv.Columns["EmpresaNombre"], pagos.EmpleadoNombre);
            //    gv.SetRowCellValue(rowHandle, gv.Columns["TipoPagoNombre"], pagos.TipoPagoNombre);
            //    gv.SetRowCellValue(rowHandle, gv.Columns["BancosNombre"], pagos.BancosNombre);
            //    gv.SetRowCellValue(rowHandle, gv.Columns["Referencias"], pagos.Referencia);
            //    gv.SetRowCellValue(rowHandle, gv.Columns["Total"], pagos.Total == null ? 0 : pagos.Total);
            //    gv.SetRowCellValue(rowHandle, gv.Columns["MontoPagar"], pagos.MontoPagar == null ? 0 : pagos.MontoPagar);
            //    gv.SetRowCellValue(rowHandle, gv.Columns["Diferencia"], (pagos.MontoPagar == null ? 0 : pagos.MontoPagar) - pagos.Total);

            //    gv.UpdateCurrentRow();
            //    gv.RefreshData();
            //}
            ////grid.DataSource = Controler.Model.Pagos.Where(P => P.TipoMovimientoId == TipoMovimientoEnum.Reposicion_Gastos.Id).ToList();
            
            ////grid.DataSource = Controler.Model.ReposicionGastos.Where(P => P.TipoMovimientoId == TipoMovimientoEnum.Reposicion_Gastos.Id).ToList();
        }

        private void abrirForm(bool nuevo)
        {
            var form = new frmReposicionGastosNew(Controler);
            form.Text = "Reposición de Gastos : " + (nuevo ? "Nuevo" : "Editar");
            form.tienePermisoAgregar = tienePermisoAgregar;
            form.tienePermisoModificar = tienePermisoModificar;
            form.tienePermisoCancelar = tienePermisoCancelar;
            if (!nuevo) form.pagos = pagos;
            form.tipoMovimientoId = TipoMovimientoEnum.Reposicion_Gastos.Id;
            form.ShowDialog();

            if (nuevo) llenaGrid();
            else grid.RefreshDataSource();

            gv_FocusedRowChanged(null, null);
        }

        private void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            if (gv.DataRowCount > 0)
            {
                try
                {
                    int id = Convert.ToInt32(gv.GetRowCellValue(gv.FocusedRowHandle, "Id"));
                    pagos = Controler.Model.Pagos.FirstOrDefault(p => p.Id == id);
                    botones(2);
                }
                catch (Exception ex)
                {
                    pagos = null;
                }
            }
        }

        private void botones(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    btnNuevo.Visible = true;
                    toolStripSeparator1.Visible = false;
                    btnEditar.Visible = false;
                    break;
                case 2:
                    btnNuevo.Visible = true;
                    toolStripSeparator1.Visible = true;
                    btnEditar.Visible = true;
                    break;
            }
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

        private void frmReposicionGastos_Load(object sender, EventArgs e)
        {
            llenaGrid();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            abrirForm(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var row = gv.GetFocusedRow();
            if (gv.SelectedRowsCount == 1 && row!=null)
            {
                abrirForm(false);
            }
            else
            {
                new frmMessageBox(true) { Message = "Favor de seleccionar el elemento a editar.", Title = "Confirmación" }.ShowDialog();
            }
        }

        private void gv_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            GridView View = sender as GridView;
            if(e.RowHandle>0)          
            if (e.Column.FieldName == "Diferencia" && string.IsNullOrEmpty(gv.GetRowCellValue(e.RowHandle, "Diferencia").ToString()) == false && gv.GetRowCellValue(e.RowHandle, "FechaCancelacion") == null)
            {
                double dif = Convert.ToDouble(gv.GetRowCellValue(e.RowHandle, "Diferencia"));
                if (dif < 0)
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
        }

        private void gv_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                var category = View.GetRowCellValue(e.RowHandle, "FechaCancelacion");
                if (category != null)
                {
                    if (!string.IsNullOrEmpty(category.ToString()))
                    {
                        e.Appearance.ForeColor = Color.Red;

                    }
                }

            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmMessageBox msg = new frmMessageBox(false) { Message = "¿Estas seguro de eliminar la Reposición?", Title = "Eliminar Registro" };
            msg.ShowDialog();

            if (msg.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Pagos pago = gv.GetFocusedRow() as Pagos;

                if (pago != null)
                {
                    DbTransaction transaccion = null;

                    try
                    {
                        transaccion = Controler.Model.BeginTransaction();
                        List<PagosFactura> fact = pago.PagosFactura.ToList();
                        if (fact.Count > 0)
                        {
                            foreach (PagosFactura f in fact)
                            {
                                if (f.Factura != null)
                                {
                                    //Controler.Model.DeleteObject(f);
                                    Controler.Model.DeleteObject(f.Factura);
                                }
                                Controler.Model.DeleteObject(f);

                            }
                            Controler.Model.DeleteObject(pago);
                        }
                        else
                        {
                            Controler.Model.DeleteObject(pago);
                        }

                        Controler.Model.SaveChanges();
                        transaccion.Commit();
                        new frmMessageBox(true) { Message = "La Reposición ha sido Eliminada.", Title = "Aviso" }.ShowDialog();
                        gv.DeleteRow(gv.FocusedRowHandle);
                        gv.RefreshData();
                    }
                    catch (Exception ex)
                    {
                        new frmMessageBox(true) { Message = "Error al quitar la Reposición: " + ex.InnerException.Message, Title = "Error" }.ShowDialog();
                        if (transaccion != null) transaccion.Rollback();
                    }
                }
                else
                {
                    new frmMessageBox(true) { Message = "No es posible eliminar esta Reposición.", Title = "Error" }.ShowDialog();
                }
            }
            else
            {
                new frmMessageBox(true) { Message = "Seleccione una Reposición a Eliminar.", Title = "Aviso" }.ShowDialog();
            }
            Controler.Model.CloseConnection();
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Funciones.Print(grid);
        }
    }
}