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
            form.Text = "Abono : " + (nuevo ? "Nuevo" : "Editar");
            if (!nuevo)
            {
                form.pagos = pagos;
            }
            form.obra = this.obra;
            form.source = this.pagos != null ? (this.pagos.TipoMovimiento.Id == TipoMovimientoEnum.NotaCreditoFactura.Id ? "NC" : string.Empty) : string.Empty;
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
                        List<PagosFactura> fact = item_Pago.PagosFactura.ToList();
                        if (fact.Count > 0)
                        {
                            foreach (PagosFactura f in fact)
                            {
                                if (f.Factura != null)
                                    f.Factura = null;
                                //Controler.Model.DeleteObject(f.Factura);
                                if (f.Pagos != null)
                                    controler.Model.DeleteObject(f.Pagos);
                                if (f.TraspasoSaldos != null)
                                    controler.Model.DeleteObject(f.TraspasoSaldos);
                                controler.Model.DeleteObject(f);
                            }
                        }
                        else
                        {
                            controler.Model.DeleteObject(item_Pago);
                        }

                        controler.Model.SaveChanges();
                        transaccion.Commit();
                        new frmMessageBox(true) { Message = "El Pago ha sido Eliminado.", Title = "Aviso" }.ShowDialog();
                        llenaInfo();
                    }
                    catch (Exception ex)
                    {
                        new frmMessageBox(true) { Message = "Error al quitar el Pago: " + ex.InnerException.Message, Title = "Error" }.ShowDialog();
                        if (transaccion != null) transaccion.Rollback();
                    }
                    finally
                    {
                        controler.Model.CloseConnection();
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
        }
    }
}
