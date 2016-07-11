using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GeisaBD;
using System.Data.Common;

namespace SistemaGEISA
{
    public partial class frmContrarecibo : DevExpress.XtraEditors.XtraForm
    {
        private Controler _controler = new Controler();

        private Controler Controler
        {
            get
            {
                return _controler;
            }
        }

        private Contrarecibo contrarecibo { get; set; }
        public frmContrarecibo()
        {
            InitializeComponent();
            Controler.PermisosEnFormulario(Name);
            btnNuevo.Enabled = Controler.TienePermiso(PermisosEnum.Agregar);
            btnEditar.Enabled = Controler.TienePermiso(PermisosEnum.Actualizar);
        }

        private void llenaGrid()
        {
            grid.DataSource = Controler.Model.Contrarecibo.ToList();
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

        private void abrirForm(bool nuevo)
        {
            var form = new frmContrareciboNew(Controler);
            form.Text = "Contra-recibo : " + (nuevo ? "Nuevo" : "Editar");
            if (!nuevo)
            {
                form.contrarecibo = contrarecibo;
            }
            else
            {
                form.contrarecibo = null;
            }
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
                contrarecibo = gv.GetFocusedRow() as Contrarecibo;

                if (contrarecibo != null)
                {
                    botones(2);
                }
            }
        }
        private void gv_DoubleClick(object sender, EventArgs e)
        {
            var view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            var pt = view.GridControl.PointToClient(Control.MousePosition);
            var info = view.CalcHitInfo(pt);

            if (info.InRow || info.InRowCell)
            {
                if (btnEditar.Enabled) btnEditar_Click(null, null);
            }
        }

        private void frmContrarecibo_Load(object sender, EventArgs e)
        {
            llenaGrid();

            if (gv.DataRowCount == 0)
            {
                botones(1);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            abrirForm(true);
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
            frmMessageBox msg = new frmMessageBox(false) { Message = "¿Estas seguro de eliminar este Comprobante?", Title = "Eliminar Registro" };
            msg.ShowDialog();

            if (msg.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Contrarecibo recibo = gv.GetFocusedRow() as Contrarecibo;

                if (recibo != null)
                {
                    DbTransaction transaccion = null;

                    try
                    {
                        transaccion = Controler.Model.BeginTransaction();
                        List<Factura> fact = recibo.Factura.ToList();
                                 if (fact.Count > 0)
                                 {
                                     foreach (Factura f in fact)
                                     {
                                         if (f.PagosFactura.Count() > 0)
                                         {
                                             string pagos = String.Empty;
                                             foreach (PagosFactura pago in f.PagosFactura)
                                             {
                                                 pagos += string.Concat(pago.Pagos.Folio, ",");
                                             }
                                             pagos = pagos.TrimEnd(',');
                                             new frmMessageBox(true) { Message = "La Factura " + f.NoFactura + " con los pagos (" + pagos + ") No es posible eliminar.", Title = "Aviso" }.ShowDialog();
                                             if (transaccion != null) transaccion.Rollback();
                                             return;

                                         }
                                         else { Controler.Model.DeleteObject(f); }
                                        
                                     }
                                     Controler.Model.DeleteObject(recibo);
                                 }
                                 else
                                 {
                                     Controler.Model.DeleteObject(recibo);
                                 }
                            
                            Controler.Model.SaveChanges();
                            transaccion.Commit();
                            new frmMessageBox(true) { Message = "El Comprobante ha sido Eliminado.", Title = "Aviso" }.ShowDialog();
                            gv.DeleteRow(gv.FocusedRowHandle);
                            gv.RefreshData();
                        }
                        catch (Exception ex)
                        {
                            new frmMessageBox(true) { Message = "Error al quitar el Comprobante: " + ex.InnerException.Message, Title = "Error" }.ShowDialog();
                            if (transaccion != null) transaccion.Rollback();
                        }
                    }
                    else
                    {
                        new frmMessageBox(true) { Message = "No es posible eliminar este Comprobante.", Title = "Error" }.ShowDialog();
                    }
                }
                else
                {
                    new frmMessageBox(true) { Message = "Seleccione un Comprobante a Eliminar.", Title = "Aviso" }.ShowDialog();
                }
            Controler.Model.CloseConnection();
        }
    }
}
