using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GeisaBD;
using System.Data;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;
using System.IO;

namespace SistemaGEISA
{
    public partial class frmTarjetasPagos : XtraForm
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

        private Pagos pagos { get; set; }
        public frmTarjetasPagos()
        {
            InitializeComponent();
            Controler.PermisosEnFormulario(Name);
            btnNuevo.Enabled = tienePermisoAgregar = Controler.TienePermiso(PermisosEnum.Agregar);
            btnEditar.Enabled = tienePermisoModificar = Controler.TienePermiso(PermisosEnum.Actualizar);
            tienePermisoCancelar = Controler.TienePermiso(PermisosEnum.Cancelar);
        }

        private void llenaGrid()
        {
            grid.DataSource = Controler.Model.Pagos.Include("TarjetasCredito").Where(P => P.TarjetaCreditoId != null && P.TipoMovimientoId == TipoMovimientoEnum.TarjetaCredito.Id).ToList();
            
            //DataTable dt = new DataTable();
            //dt.Columns.Add("Id", typeof(int));
            //dt.Columns.Add("Folio", typeof(int));
            //dt.Columns.Add("FechaPago", typeof(DateTime));
            //dt.Columns.Add("Nombre_y_Tarjeta", typeof(string));
            //dt.Columns.Add("EmpresaNombre", typeof(string));
            //dt.Columns.Add("TipoPagoNombre", typeof(string));
            //dt.Columns.Add("BancosNombre", typeof(string));
            //dt.Columns.Add("Referencias", typeof(string));
            //dt.Columns.Add("Total", typeof(double));
            //dt.Columns.Add("FechaCancelacion", typeof(DateTime));
            //dt.Columns.Add("Periodo", typeof(string));
            
            //grid.DataSource = dt;

            //foreach (Pagos t in Controler.Model.Pagos.Where(P => P.TarjetaCreditoId != null && P.TipoMovimientoId == TipoMovimientoEnum.TarjetaCredito.Id).ToList())
            //{
            //    gv.AddNewRow();

            //    int rowHandle = gv.GetRowHandle(gv.DataRowCount);
            //    gv.SetRowCellValue(rowHandle, gv.Columns["Id"], t.Id);
            //    gv.SetRowCellValue(rowHandle, gv.Columns["Folio"], t.Folio);
            //    gv.SetRowCellValue(rowHandle, gv.Columns["FechaPago"], t.FechaPago);
            //    gv.SetRowCellValue(rowHandle, gv.Columns["Nombre_y_Tarjeta"], t.TarjetasCredito != null ? t.TarjetasCredito.Nombre_y_Tarjeta : string.Empty);
            //    gv.SetRowCellValue(rowHandle, gv.Columns["EmpresaNombre"], t.EmpresaNombre);
            //    gv.SetRowCellValue(rowHandle, gv.Columns["TipoPagoNombre"], t.TipoPagoNombre);
            //    gv.SetRowCellValue(rowHandle, gv.Columns["BancosNombre"], t.BancosNombre);
            //    gv.SetRowCellValue(rowHandle, gv.Columns["Referencias"], t.Referencias);
            //    gv.SetRowCellValue(rowHandle, gv.Columns["Total"], t.Total);
            //    gv.SetRowCellValue(rowHandle, gv.Columns["FechaCancelacion"], t.FechaCancelacion);
            //    gv.SetRowCellValue(rowHandle, gv.Columns["Periodo"], t.Periodo);

            //    gv.UpdateCurrentRow();
            //    gv.RefreshData();

            //}           
        }

        private void abrirForm(bool nuevo)
        {
            var form = new frmTarjetasPagosNew(Controler);
            form.Text = "Pagos Tarjeta Credito : " + (nuevo ? "Nuevo" : "Editar");
            form.tienePermisoAgregar = tienePermisoAgregar;
            form.tienePermisoModificar = tienePermisoModificar;
            form.tienePermisoCancelar = tienePermisoCancelar;
            var Identificador= Convert.ToInt32(gv.GetRowCellValue(gv.FocusedRowHandle, "Id"));
            if (!nuevo) form.pagos = Controler.Model.Pagos.FirstOrDefault(p => p.Id == Identificador);
            form.tipoMovimientoId = TipoMovimientoEnum.TarjetaCredito.Id;

            form.ShowDialog();
            //Actualizo registro abierto
            Controler.Model.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, Controler.Model.Pagos.Where(P => P.TarjetaCreditoId != null).ToList());
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
            if (gv.DataRowCount > 0)
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

        private void frmTarjetasPagos_Load(object sender, EventArgs e)
        {
            llenaGrid();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            abrirForm(true);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gv.SelectedRowsCount == 1 && pagos!=null)
            {
                abrirForm(false);
            }
            else
            {
                new frmMessageBox(true) { Message = "Favor de seleccionar el elemento a editar.", Title = "Confirmación" }.ShowDialog();
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


    }
}
