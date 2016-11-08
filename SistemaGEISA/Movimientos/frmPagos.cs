using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GeisaBD;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using System.Data.Common;
using System.IO;

namespace SistemaGEISA
{
    public partial class frmPagos : DevExpress.XtraEditors.XtraForm
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

        bool tienePermisoAgregar, tienePermisoModificar, tienePermisoCancelar;


        #region re-calcula saldo en todas las facturas
        private void recalculaSaldos()
        {
            var error = string.Empty;
            DbTransaction transaccion = null;

            try
            {
                transaccion = Controler.Model.BeginTransaction();
                //PagosFactura detalle = null;
                TraspasoSaldos detalleTraspaso = null;


                foreach (PagosFactura detalle in Controler.Model.PagosFactura.Where(P => P.Pagos.TipoMovimientoId == TipoMovimientoEnum.Pagos.Id).ToList())
                {

                    //if (detalle != null && detalle.FacturaId == 45038)
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
        #endregion

        public frmPagos()
        {
            InitializeComponent();
            Controler.PermisosEnFormulario(Name);
            btnNuevo.Enabled = tienePermisoAgregar = Controler.TienePermiso(PermisosEnum.Agregar);
            btnEditar.Enabled = tienePermisoModificar = Controler.TienePermiso(PermisosEnum.Actualizar);
            tienePermisoCancelar = Controler.TienePermiso(PermisosEnum.Cancelar);
        }

        private void llenaGrid()
        {
            //grid.DataSource = Controler.Model.Pagos.ToList();
            grid.DataSource = Controler.Model.Pagos.Where(P => P.TipoMovimientoId == TipoMovimientoEnum.Pagos.Id).OrderByDescending(O => O.Id).ToList();
        }

        private void abrirForm(bool nuevo)
        {
            var form = new frmPagosNew (Controler);
            form.Text = "Pagos : " + (nuevo ? "Nuevo" : "Editar");
            if (!nuevo) form.pagos = pagos;
            form.tipoMovimientoId = TipoMovimientoEnum.Pagos.Id;
            form.tienePermisoAgregar = tienePermisoAgregar;
            form.tienePermisoModificar = tienePermisoModificar;
            form.tienePermisoCancelar = tienePermisoCancelar;
            form.mostrarNC_Ingreso = true;

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
                pagos = gv.GetFocusedRow() as Pagos;

                if (pagos != null)
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            abrirForm(true);
        }

        private void frmPagos_Load(object sender, EventArgs e)
        {
            llenaGrid();
        }

        private void gv_DoubleClick_1(object sender, EventArgs e)
        {
            var view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            var pt = view.GridControl.PointToClient(Control.MousePosition);
            var info = view.CalcHitInfo(pt);

            if (info.InRow || info.InRowCell)
            {
                btnEditar_Click(null, null);
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
            frmMessageBox msg = new frmMessageBox(false) { Message = "¿Estas seguro de eliminar este Pago?", Title = "Eliminar Registro" };
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
                                 List<PagosFactura> pagosFact= pago.PagosFactura.ToList();
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
                                         if (f.Pagos !=null) //elimino el pago                                                                                      
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
                            new frmMessageBox(true) { Message = "El Pago ha sido Eliminado.", Title = "Aviso" }.ShowDialog();
                            gv.DeleteRow(gv.FocusedRowHandle);
                            gv.RefreshData();
                        }
                        catch (Exception ex)
                        {
                            new frmMessageBox(true) { Message = "Error al quitar el Pago: " + ex.InnerException.Message, Title = "Error" }.ShowDialog();
                            if (transaccion != null) transaccion.Rollback();
                        }
                    }
                    else
                    {
                        new frmMessageBox(true) { Message = "No es posible eliminar este Pago.", Title = "Error" }.ShowDialog();
                    }
                }
                else
                {
                    new frmMessageBox(true) { Message = "Seleccione un Pago a Eliminar.", Title = "Aviso" }.ShowDialog();
                }
            Controler.Model.CloseConnection();
        }

        private void grid_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Funciones.Print(grid);
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

        private void btnRecalcular_Click(object sender, EventArgs e)
        {            
            recalculaSaldos();
        }
    }
}
