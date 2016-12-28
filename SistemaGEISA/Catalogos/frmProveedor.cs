using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GeisaBD;
using System.Data;
using System.Data.Common;
using System.IO;

namespace SistemaGEISA
{
    public partial class frmProveedor : DevExpress.XtraEditors.XtraForm
    {
        private Controler _controler = new Controler();

        private Controler Controler
        {
            get
            {
                return _controler;
            }
        }

        private Proveedor proveedor { get; set; }
        public frmProveedor()
        {
            InitializeComponent();
            Controler.PermisosEnFormulario(Name);
            btnNuevo.Enabled = Controler.TienePermiso(PermisosEnum.Agregar);
            btnEditar.Enabled = Controler.TienePermiso(PermisosEnum.Actualizar);
            btnActivo.Enabled = Controler.TienePermiso(PermisosEnum.ActivarDesactivar);
            //btnEliminar.Enabled = Controler.TienePermiso(PermisosEnum.Eliminar);
        }

        private void llenaGrid()
        {
            grid.DataSource = Controler.Model.Proveedor.Where(P => P.RFC != "XAXX010101000").ToList();
            grid2.DataSource = Controler.Model.Proveedor.Where(P => P.RFC == "XAXX010101000").ToList();
        }

        private void botones(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    btnNuevo.Visible = true;
                    toolStripSeparator1.Visible = false;
                    btnEditar.Visible = false;
                    toolStripSeparator2.Visible = false;
                    btnActivo.Visible = false;
                    btnEliminar.Visible = false;
                    break;
                case 2:
                    btnNuevo.Visible = true;
                    toolStripSeparator1.Visible = true;
                    btnEditar.Visible = true;
                    toolStripSeparator2.Visible = true;
                    btnActivo.Visible = true;
                    btnEliminar.Visible = true;
                    break;
            }
        }

        private void abrirForm(bool nuevo)
        {

            var form = new frmProveedorNew(Controler);
            form.Text = "Proveedor : " + (nuevo ? "Nuevo" : "Editar");
            if (!nuevo)
            {
                form.proveedor = proveedor;
            }
            else
            {
                form.proveedor = null;
            }
            form.ShowDialog();

            if (nuevo)
            {
                llenaGrid();
            }
            else
            {
                if (proveedor != null)
                {
                    proveedor.AcualizaDomicilio();
                }
                grid.RefreshDataSource();
                grid2.RefreshDataSource();
            }

            //gv_FocusedRowChanged(null, null);
        }

        private void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            var view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            if (view != null)
                if (view.RowCount > 0)
                {
                    proveedor = view.GetFocusedRow() as Proveedor;

                    if (proveedor != null)
                    {
                        botones(2);
                        if (proveedor.Activo == true)
                        {
                            btnActivo.Image = Properties.Resources.Desactivar;
                            btnActivo.Text = "Desactivar";
                        }
                        else
                        {
                            btnActivo.Image = Properties.Resources.Activo;
                            btnActivo.Text = "Activar";
                        }

                        btnActivo.ToolTipText = btnActivo.Text;
                    }
                }
        }
        private void gv_DoubleClick(object sender, EventArgs e)
        {
            var view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            gv_FocusedRowChanged(sender, null);
            //var pt = view.GridControl.PointToClient(Control.MousePosition);
            //var info = view.CalcHitInfo(pt);

            if (view != null && this.proveedor != null)
            {
                btnEditar_Click(sender, e);
            }
        }
        private void frmProveedor_Load(object sender, EventArgs e)
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
            var view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            if (view.SelectedRowsCount == 1)
            {
                abrirForm(false);
            }
            else
            {
                new frmMessageBox(true) { Message = "Favor de seleccionar el elemento a editar.", Title = "Confirmación" }.ShowDialog();
            }
        }
        private void btnActivo_Click(object sender, EventArgs e)
        {
            proveedor.Activo = btnActivo.Text == "Activar" ? true : false;
            Controler.Model.SaveChanges();
            grid.RefreshDataSource();
            gv_FocusedRowChanged(null, null);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmMessageBox msg = new frmMessageBox(false) { Message = "¿Estas seguro de eliminar este Proveedor?", Title = "Eliminar Registro" };
            msg.ShowDialog();

            if (msg.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                if (gv.IsFocusedView)
                    proveedor = gv.GetFocusedRow() as Proveedor;
                else
                    proveedor = gv2.GetFocusedRow() as Proveedor;

                if (proveedor != null)
                {
                    DbTransaction transaccion = null;
                    try
                    {
                        transaccion = Controler.Model.BeginTransaction();                  

                        if (Controler.Model.Factura.Where(f => f.ProveedorId == proveedor.Id).Count() > 0)
                        {
                            new frmMessageBox(true) { Message = "El Proveedor tiene Facturas asociadas, No es posible Eliminar.", Title = "Aviso" }.ShowDialog();
                            if (transaccion != null) transaccion.Rollback();
                            return;
                        }
                        if (Controler.Model.Pagos.Where(p => p.ProveedorId == proveedor.Id).Count() > 0)
                        {
                            new frmMessageBox(true) { Message = "El Proveedor tiene Pagos asociadas, No es posible Eliminar.", Title = "Aviso" }.ShowDialog();
                            if (transaccion != null) transaccion.Rollback();
                            return;
                        }
                        if (Controler.Model.GastosAdministrativos.Where(p => p.ProveedorId == proveedor.Id).Count() > 0)
                        {
                            new frmMessageBox(true) { Message = "El Proveedor tiene Gastos Administrativos asociados, No es posible Eliminar.", Title = "Aviso" }.ShowDialog();
                            if (transaccion != null) transaccion.Rollback();
                            return;
                        }
                        if (Controler.Model.CajaChicaComprobante.Where(p => p.ProveedorId == proveedor.Id).Count() > 0)
                        {
                            new frmMessageBox(true) { Message = "El Proveedor tiene Comprobantes asociados, No es posible Eliminar.", Title = "Aviso" }.ShowDialog();
                            if (transaccion != null) transaccion.Rollback();
                            return;
                        }
                        if (Controler.Model.Contrarecibo.Where(p => p.ProveedorId == proveedor.Id).Count() > 0)
                        {
                            new frmMessageBox(true) { Message = "El Proveedor tiene Contrarecibos asociados, No es posible Eliminar.", Title = "Aviso" }.ShowDialog();
                            if (transaccion != null) transaccion.Rollback();
                            return;
                        }

                        foreach (ProveedorBancos cuenta in proveedor.ProveedorBancos.ToList())
                        {
                            Controler.Model.DeleteObject(cuenta);
                        }

                        if (proveedor.Domicilio != null)
                        {
                            //Domicilios
                            Controler.Model.DeleteObject(Controler.GetObjectFromContext(proveedor.Domicilio));
                        }

                        Controler.Model.DeleteObject(proveedor);
                        Controler.Model.SaveChanges();
                        transaccion.Commit();
                        new frmMessageBox(true) { Message = "El Proveedor ha sido Eliminado.", Title = "Aviso" }.ShowDialog();
                        if (gv.IsFocusedView)
                        {
                            gv.DeleteRow(gv.FocusedRowHandle);
                            gv.RefreshData();
                        }
                        else
                        {
                            gv2.DeleteRow(gv2.FocusedRowHandle);
                            gv2.RefreshData();
                        }

                    }
                    catch (Exception ex)
                    {
                        if (transaccion != null) transaccion.Rollback();
                        new frmMessageBox(true) { Message = "Error al quitar el Proveedor: " + ex.GetBaseException().Message, Title = "Error" }.ShowDialog();
                    }
                }
                else
                {
                    new frmMessageBox(true) { Message = "El Proveedor tiene facturas Asociadas.", Title = "Aviso" }.ShowDialog();
                }
            }
            else
            {
                new frmMessageBox(true) { Message = "Seleccione un Proveedor a Eliminar.", Title = "Aviso" }.ShowDialog();
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            var view = sender.ToString() == "Proveedores Completos" ? gv : gv2;
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
                            view.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            view.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            view.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            view.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            view.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            view.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }
                }
            } //
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Funciones.Print(grid);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Funciones.Print(grid2);
        }
    }

}

