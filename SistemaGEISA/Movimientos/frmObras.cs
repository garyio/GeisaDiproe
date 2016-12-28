using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GeisaBD;
using System.IO;
using System.Data.Common;

namespace SistemaGEISA
{
    public partial class frmObras : DevExpress.XtraEditors.XtraForm
    {
        private Controler _controler = new Controler();

        private Controler Controler
        {
            get
            {
                return _controler;
            }
        }

        private Obra obra { get; set; }
        public frmObras()
        {
            InitializeComponent();
            Controler.PermisosEnFormulario(Name);
            btnNuevo.Enabled = Controler.TienePermiso(PermisosEnum.Agregar);
            btnEditar.Enabled = Controler.TienePermiso(PermisosEnum.Actualizar);
            btnEliminar.Enabled = Controler.TienePermiso(PermisosEnum.Eliminar);
        }

        private void llenaGrid()
        {
            grid.DataSource = Controler.Model.Obra.ToList();
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
            var form = new frmObrasNew(Controler);
            form.Text = "Obra : " + (nuevo ? "Nueva" : "Editar");
            if (!nuevo)
            {
                form.obra = obra;
            }
            else
            {
                form.obra = null;
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
                obra = gv.GetFocusedRow() as Obra;

                if (obra != null)
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
                btnEditar_Click(null, null);
            }
        }
        private void frmObras_Load(object sender, EventArgs e)
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmMessageBox msg = new frmMessageBox(false) { Message = "¿Estas seguro de eliminar esta Obra?", Title = "Eliminar Registro" };
            msg.ShowDialog();

            if (msg.DialogResult == System.Windows.Forms.DialogResult.Yes && gv.SelectedRowsCount == 1)
            {
                Obra obra = gv.GetFocusedRow() as Obra;

                if (obra != null)
                {
                    DbTransaction transaccion = null;

                    try
                    {
                        transaccion = Controler.Model.BeginTransaction();
                        Controler.Model.DeleteObject(obra);
                        Controler.Model.SaveChanges();
                        transaccion.Commit();
                        new frmMessageBox(true) { Message = "La Obra ha sido Eliminada.", Title = "Aviso" }.ShowDialog();
                        gv.DeleteRow(gv.FocusedRowHandle);
                        llenaGrid();
                    }
                    catch (Exception ex)
                    {
                        new frmMessageBox(true) { Message = "Error al quitar la Obra: " + ex.GetBaseException().Message, Title = "Error" }.ShowDialog();
                        if (transaccion != null) transaccion.Rollback();
                    }
                    finally
                    {
                        Controler.Model.CloseConnection();
                    }
                }
                else
                {
                    new frmMessageBox(true) { Message = "No es posible eliminar esta Obra.", Title = "Error" }.ShowDialog();
                }
            }
            else
            {
                new frmMessageBox(true) { Message = "Seleccione al menos una Obra a Eliminar.", Title = "Aviso" }.ShowDialog();
            }
            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Funciones.Print(grid);
        }
    }
}
