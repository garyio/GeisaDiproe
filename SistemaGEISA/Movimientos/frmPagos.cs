﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GeisaBD;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using System.Data.Common;

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
                                 List<PagosFactura> fact= pago.PagosFactura.ToList();
                                 if (fact.Count > 0)
                                 {
                                     foreach (PagosFactura f in fact)
                                     {
                                         if (f.Factura != null)
                                         {
                                             Controler.Model.DeleteObject(f);
                                             //Controler.Model.DeleteObject(f.Factura);
                                         }
                                         //Controler.Model.DeleteObject(f);

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
    }
}
