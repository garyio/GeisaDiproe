using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GeisaBD;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using System.Data.Common;

namespace SistemaGEISA
{
    public partial class frmIngresosHistorialTraspasos : DevExpress.XtraEditors.XtraForm
    {
        private Controler controler { get; set; }
        public Obra obra;
        public Cliente cliente;
        public Pagos pagos;

        private getTraspasos_Result item;

        public frmIngresosHistorialTraspasos(Controler _controler)
        {
            InitializeComponent();
            controler = _controler ?? new Controler();
        }

        private void frmIngresosHistorialTraspasos_Load(object sender, EventArgs e)
        {
            llenaInfo();
        }

        private void llenaInfo()
        {
            grid.DataSource = controler.Model.getTraspasos(obra.Id,cliente.Id,obra.EmpresaId);
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

        private void abrirForm(bool nuevo)
        {
            var form = new frmPagosNew(controler);
            form.Text = "Traspaso : Editar";
            if (!nuevo)
            {
                form.pagos = pagos;
            }
            form.tipoMovimientoId = TipoMovimientoEnum.Traspaso_Abono.Id;
            form.obra = this.obra;
            form.source = this.pagos != null ? (this.pagos.TipoMovimiento.Id == TipoMovimientoEnum.NotaCreditoFactura.Id ? "NC" : string.Empty) : string.Empty;
            form.esTraspaso = true;
            form.tienePermisoAgregar = true;
            form.tienePermisoModificar = true;
            form.tienePermisoCancelar = true;

            form.ShowDialog();
            llenaInfo();

            gv_FocusedRowChanged(null, null);
        }

        private void gv_DoubleClick(object sender, EventArgs e)
        {
            btnEditar_Click(null, null);
        }

        private void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gv.GetFocusedRow() != null)
            {
                item = gv.GetFocusedRow() as getTraspasos_Result;
                pagos = controler.Model.Pagos.FirstOrDefault(p => p.Id == item.IdPago);               
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmMessageBox msg = new frmMessageBox(false) { Message = "¿Estas seguro de eliminar este Registro?", Title = "Eliminar Registro" };
            msg.ShowDialog();

            if (msg.DialogResult == System.Windows.Forms.DialogResult.Yes && gv.SelectedRowsCount >= 1)
            {
                item = gv.GetFocusedRow() as getTraspasos_Result;
                Pagos item_Pago = controler.Model.Pagos.FirstOrDefault(p => p.Id == item.IdPago);

                if (item_Pago != null)
                {
                    DbTransaction transaccion = null;
                    try
                    {
                        transaccion = controler.Model.BeginTransaction();
                        List<PagosFactura> pagosFact = item_Pago.PagosFactura.ToList();
                        if (pagosFact.Count > 0)
                        {
                            foreach (PagosFactura f in pagosFact)
                            {
                                if (f.Factura != null) // quito referencia de la factura y recalculo el saldo
                                {
                                    //Recalculo el saldo de la factura cuando se eliminan los PagosFactura
                                    if (f.Factura != null && !f.Factura.FechaCancelacion.HasValue)
                                    {
                                        f.Factura.Saldo = f.Factura.Importe - controler.Model.getAbonosTotales(f.Factura.Id, f.Pagos.Id).Select(A => A.MontoPagar).DefaultIfEmpty(0).Sum().Value;
                                        f.Factura.Saldo = Math.Round(f.Factura.Saldo, 2);
                                    }
                                    f.Factura = null;
                                }
                                if (f.TraspasoSaldos != null)
                                    controler.Model.DeleteObject(f.TraspasoSaldos);
                                if (f.Pagos != null) //elimino el pago                                                                                      
                                    controler.Model.DeleteObject(f); //elimino el PagoFactura
                            }
                            controler.Model.DeleteObject(this.pagos);
                        }
                        else
                        {
                            controler.Model.DeleteObject(this.pagos);
                        }

                        controler.Model.SaveChanges();
                        transaccion.Commit();
                        new frmMessageBox(true) { Message = "El Traspaso ha sido Eliminado.", Title = "Aviso" }.ShowDialog();
                        llenaInfo();
                    }
                    catch (Exception ex)
                    {
                        new frmMessageBox(true) { Message = "Error al quitar el Traspaso: " + ex.InnerException.Message, Title = "Error" }.ShowDialog();
                        if (transaccion != null) transaccion.Rollback();
                    }
                    finally
                    {
                        controler.Model.CloseConnection();
                    }
                }
                else
                {
                    new frmMessageBox(true) { Message = "No es posible eliminar este Traspaso.", Title = "Error" }.ShowDialog();
                }
            }
            else
            {
                new frmMessageBox(true) { Message = "Seleccione un Traspaso a Eliminar.", Title = "Aviso" }.ShowDialog();
            }   
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmMessageBox msg = new frmMessageBox(false) { Message = "¿Desea Cancelar este Traspaso?", Title = "Eliminar Registro" };
            msg.ShowDialog();

            if (msg.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                if (item != null)
                {
                    if (item.Id != 0 && item.FechaCancelacion==null)
                    {
                            //TraspasoSaldos traspaso = controler.Model.TraspasoSaldos.FirstOrDefault(f => f.Id == item.Id);
                            //if (!traspaso.FechaCancelacion.HasValue) 
                            //    traspaso.FechaCancelacion = DateTime.Today;

                            //CANCELO PAGO ASOCIADO A EL TRASPASO PARA RECUPERAR EL SALDO DE LA FACTURA
                            List<PagosFactura> pagosfac = controler.Model.PagosFactura.Where(D => D.PagosId == pagos.Id).ToList();
                            foreach (PagosFactura facpagos in pagosfac)
                            {
                                Factura fac = facpagos.Factura;
                                fac.Saldo = fac.Saldo + facpagos.MontoPagar;

                                if (facpagos.TraspasoSaldos !=null)
                                    facpagos.TraspasoSaldos.FechaCancelacion = DateTime.Now;
                            }

                            pagos.FechaCancelacion = DateTime.Now;
                            pagos.UsuarioId = frmPrincipal.UsuarioDelSistema.Id;

                            try
                            {
                                controler.Model.SaveChanges();
                                new frmMessageBox(true) { Message = "Traspaso Cancelado Exitosamente. ", Title = "Aviso" }.ShowDialog();
                            }
                            catch (Exception ex)
                            {
                                new frmMessageBox(true) { Message = "Error al Cancelar el Traspaso: " + ex.InnerException.Message, Title = "Error" }.ShowDialog();
                            }
                        
                    }
                }
            }
        }

        private void gv_RowStyle(object sender, RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            var row = gv.GetRow(e.RowHandle);
            if (e.RowHandle >= 0 && row != null)
            {
                getTraspasos_Result item = (gv.GetRow(e.RowHandle) as getTraspasos_Result);

                //string category = View.GetRowCellValue(e.RowHandle, "FechaCancelacion").ToString();

                if (!string.IsNullOrEmpty(item.FechaCancelacion.HasValue ? item.FechaCancelacion.Value.ToShortDateString() : string.Empty))
                {
                    e.Appearance.ForeColor = Color.Red;

                }
            }
        }
    }
}
