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
    public partial class frmOrdenes : DevExpress.XtraEditors.XtraForm
    {
        private Controler _controler = new Controler();

        private Controler Controler
        {
            get
            {
                return _controler;
            }
        }

        bool tienePermisoAgregar, tienePermisoModificar, tienePermisoCancelar;

        private Ordenes orden { get; set; }

        public frmOrdenes()
        {
            InitializeComponent();
            Controler.PermisosEnFormulario(Name);
            btnNuevo.Enabled = tienePermisoAgregar = Controler.TienePermiso(PermisosEnum.Agregar);
            btnEditar.Enabled = tienePermisoModificar = Controler.TienePermiso(PermisosEnum.Actualizar);
            tienePermisoCancelar = Controler.TienePermiso(PermisosEnum.Cancelar);
        }

        private void frmOrdenes_Load(object sender, EventArgs e)
        {            
            llenaGrid();
        }

        private void llenaGrid()
        {
            grid.DataSource = Controler.Model.Ordenes.ToList();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            abrirForm(true);
        }

        private void abrirForm(bool nuevo)
        {
            var form = new frmOrdenesDetalle(this.Controler);
            form.Text = "Orden : " + (nuevo ? "Nuevo" : "Editar");
            if (!nuevo) form.orden = this.orden;
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
                orden = gv.GetFocusedRow() as Ordenes;

                if (orden != null)
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

        private void gv_RowStyle(object sender, RowStyleEventArgs e)
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
            frmMessageBox msg = new frmMessageBox(false) { Message = "¿Estas seguro de eliminar esta Orden?", Title = "Eliminar Registro" };
            msg.ShowDialog();

            if (msg.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                Ordenes ordenEliminar = gv.GetFocusedRow() as Ordenes;

                if (ordenEliminar != null)
                {
                    DbTransaction transaccion = null;

                    try
                    {
                        transaccion = Controler.Model.BeginTransaction();
                        List<DetalleArticulos> fact = ordenEliminar.DetalleArticulos.ToList();
                        if (fact.Count > 0)
                        {
                            foreach (DetalleArticulos f in fact)
                            {
                                Controler.Model.DeleteObject(f);

                            }
                            Controler.Model.DeleteObject(ordenEliminar);
                        }
                        else
                        {
                            Controler.Model.DeleteObject(ordenEliminar);
                        }

                        Controler.Model.SaveChanges();
                        transaccion.Commit();
                        new frmMessageBox(true) { Message = "La Orden ha sido Eliminada.", Title = "Aviso" }.ShowDialog();
                        gv.DeleteRow(gv.FocusedRowHandle);
                        gv.RefreshData();
                    }
                    catch (Exception ex)
                    {
                        new frmMessageBox(true) { Message = "Error al quitar la Orden: " + ex.InnerException.Message, Title = "Error" }.ShowDialog();
                        if (transaccion != null) transaccion.Rollback();
                    }
                }
                else
                {
                    new frmMessageBox(true) { Message = "No es posible eliminar esta Orden.", Title = "Error" }.ShowDialog();
                }
            }
            else
            {
                new frmMessageBox(true) { Message = "Seleccione una Orden a Eliminar.", Title = "Aviso" }.ShowDialog();
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
