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
                        List<PagosFactura> pagosFact = pago.PagosFactura.ToList();
                        if (pagosFact.Count > 0)
                        {
                            foreach (PagosFactura f in pagosFact)
                            {
                                if (f.Factura != null) // quito referencia de la factura y recalculo el saldo
                                {
                                    //Recalculo el saldo de la factura cuando se eliminan los PagosFactura
                                    if (f.Factura != null && !f.Factura.FechaCancelacion.HasValue)
                                    {
                                        f.Factura.Saldo = f.Factura.Importe - Controler.Model.getAbonosTotales(f.Factura.Id, f.Pagos.Id).Select(A => A.MontoPagar).DefaultIfEmpty(0).Sum().Value;
                                        f.Factura.Saldo = Math.Round(f.Factura.Saldo, 2);
                                    }
                                    f.Factura = null;
                                }
                                if (f.TraspasoSaldos != null) //Quito referencia del Traspaso                                                                                  
                                    f.TraspasoSaldos = null; 
                                if (f.Pagos != null) //elimino el pago                                                                                      
                                    Controler.Model.DeleteObject(f); //elimino el PagoFactura
                                
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
                    finally
                    {
                        Controler.Model.CloseConnection();
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

        private void btnRecalcular_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            recalculaSaldos();
            this.Cursor = Cursors.Default;
        }

        private void recalculaSaldos()
        {
            var error = string.Empty;
            DbTransaction transaccion = null;

            try
            {
                transaccion = Controler.Model.BeginTransaction();
                //PagosFactura detalle = null;
                TraspasoSaldos detalleTraspaso = null;


                foreach (PagosFactura detalle in Controler.Model.PagosFactura.Where(P => P.Pagos.TipoMovimientoId == TipoMovimientoEnum.Reposicion_Gastos.Id).ToList())
                {

                    //if (detalle != null && detalle.FacturaId == 3432)
                    //{

                    Factura factura = Controler.Model.Factura.FirstOrDefault(D => D.Id == detalle.FacturaId);

                    factura.Saldo = factura.Importe - Controler.Model.getAbonosTotales(factura.Id, null).Select(A => A.MontoPagar).DefaultIfEmpty(0).Sum().Value;
                    factura.Saldo = Math.Round(factura.Saldo, 2);

                    //detalle = controler.Model.PagosFactura.FirstOrDefault(P => P.FacturaId == id && P.PagosId == pagos.Id);
                    detalleTraspaso = detalle.TraspasoSaldos;
                    //}
                }

                Controler.Model.SaveChanges();
                transaccion.Commit();
            }
            catch (Exception ex)
            {
                if (transaccion != null) transaccion.Rollback();
                error = ex.InnerException.Message;
            }
            finally
            {
                Controler.Model.CloseConnection();

                var title = string.IsNullOrEmpty(error) ? "Confirmación" : "Error";
                var message = string.Empty;
                message = string.IsNullOrEmpty(error) ? string.Concat("Los Saldos han sido actualizados exitosamente.") : string.Concat("Error al actualizar los Saldos:\n", error);
                new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();
            }
        }
    }
}