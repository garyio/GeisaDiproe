using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GeisaBD;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.Common;
using System.IO;

namespace SistemaGEISA
{
    public partial class frmPrestamosEmpresas : DevExpress.XtraEditors.XtraForm
    {

        private Controler _controler = new Controler();

        private CajaChicaPrestamo CajaPrestamo { get; set; }

        private Controler Controler
        {
            get
            {
                return _controler;
            }
        }

        //bool tienePermisoAgregar, tienePermisoModificar, tienePermisoCancelar;
        //getTotalesPrestamos_Result Pago;

        public frmPrestamosEmpresas()
        {
            InitializeComponent();
        }

        private void frmPrestamosEmpresas_Load(object sender, EventArgs e)
        {
            llenaGrid();
        }

        private void llenaGrid()
        {

            //grid.DataSource = Controler.Model.getTotalesPrestamos().ToList();
            grid.DataSource = Controler.Model.CajaChicaPrestamo.ToList();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            abrirForm(true);
        }

        private void abrirForm(bool nuevo)
        {
            var form = new frmPrestamosEmpresasAcmNew(Controler);
            //var tipoObjeto = Convert.ToInt32(gv.GetRowCellValue(gv.FocusedRowHandle, "TipoObjeto"));
            //var Beneficiario = Convert.ToInt32(gv.GetRowCellValue(gv.FocusedRowHandle, "Beneficiario"));

            //if (tipoObjeto > 0 && Beneficiario>0)
            //{
            //    if(tipoObjeto== TipoCatalogo.EMPRESA)
            //        pagos = Controler.Model.Pagos.Where(p => p.Beneficiario == Beneficiario && p.TipoObjeto == tipoObjeto && (p.TipoMovimientoId == TipoMovimientoEnum.Prestamos.Id || p.TipoMovimientoId == TipoMovimientoEnum.Abonos.Id)).ToList();
            //}
            
            if (!nuevo && CajaPrestamo!=null) form.CajaPrestamo = CajaPrestamo;
            form.tipoMovimientoId = TipoMovimientoEnum.Prestamos.Id;
            form.ShowDialog();
            llenaGrid();
            grid.RefreshDataSource();

            //gv_FocusedRowChanged(null, null);
        }

        private void botones(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    btnNuevo.Visible = true;
                    btnEditar.Visible = false;
                    break;
                case 2:
                    btnNuevo.Visible = true;
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            var row = gv.GetFocusedRow();
            if (gv.SelectedRowsCount == 1 && row != null)
            {
                abrirForm(false);
            }
            else
            {
                new frmMessageBox(true) { Message = "Favor de seleccionar el elemento a editar.", Title = "Confirmación" }.ShowDialog();
            }
        }

        private void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gv.GetFocusedRow() != null && gv.DataRowCount > 0)
                CajaPrestamo = gv.GetFocusedRow() as CajaChicaPrestamo;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
             frmMessageBox msg = new frmMessageBox(false) { Message = "¿Estas seguro de eliminar este Prestamo?", Title = "Eliminar Registro" };
            msg.ShowDialog();

            if (msg.DialogResult == System.Windows.Forms.DialogResult.Yes && gv.SelectedRowsCount==1)
            {
                CajaChicaPrestamo cajachica = gv.GetFocusedRow() as CajaChicaPrestamo;

                if (cajachica != null)
                {
                    DbTransaction transaccion = null;

                    try
                    {
                        transaccion = Controler.Model.BeginTransaction();
                        List<Pagos> cargos = Controler.Model.Pagos.Where(V => V.CajaChicaPrestamoId == cajachica.Id).ToList();
                        if (cargos != null)
                        {
                            foreach (Pagos cargo in cargos)
                            {
                                Controler.Model.DeleteObject(cargo);
                            }
                        }

                        Controler.Model.DeleteObject(cajachica);

                        Controler.Model.SaveChanges();
                        transaccion.Commit();
                        new frmMessageBox(true) { Message = "El prestamo ha Sido Eliminado.", Title = "Aviso" }.ShowDialog();
                        gv.DeleteRow(gv.FocusedRowHandle);
                        llenaGrid();
                    }
                    catch (Exception ex)
                    {
                        new frmMessageBox(true) { Message = "Error al quitar el Prestamo: " + ex.InnerException.Message, Title = "Error" }.ShowDialog();
                        if (transaccion != null) transaccion.Rollback();
                    }
                    finally
                    {
                        Controler.Model.CloseConnection();
                    }
                }
                else
                {
                    new frmMessageBox(true) { Message = "No es posible eliminar este Prestamo.", Title = "Error" }.ShowDialog();
                }
            }
            else
            {
                new frmMessageBox(true) { Message = "Seleccione el Prestamo a Eliminar.", Title = "Aviso" }.ShowDialog();
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
    }
}
