using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGEISA
{
    public partial class frmBuscadorFacturas : XtraForm
    {
        private DataTable dt;

        private Controler _controler = new Controler();

        private Controler Controler
        {
            get
            {
                return _controler;
            }
        }
        public frmBuscadorFacturas()
        {
            InitializeComponent();
        }

        private void frmBuscadorFacturas_Load(object sender, EventArgs e)
        {
            llenaGrid();
        }

        private void llenaGrid()
        {
            grid.DataSource = Controler.Model.getFacturasDetalle().ToList();
            //dt = new DataTable();
            //dt.Columns.Add("FechaCancelacion", typeof(DateTime));
            //dt.Columns.Add("Factura", typeof(string));
            //dt.Columns.Add("FechaFactura", typeof(DateTime));
            //dt.Columns.Add("Importe", typeof(double));
            //dt.Columns.Add("Proveedor", typeof(string));
            //dt.Columns.Add("Obra_Nombre", typeof(string));
            //dt.Columns.Add("TipoMovimiento_Nombre", typeof(string));
            //dt.Columns.Add("Pago_Consecutivo", typeof(string));
            //dt.Columns.Add("TipoPago_Nombre", typeof(string));
            //dt.Columns.Add("Contrarecibo_Folio", typeof(string));
            //dt.Columns.Add("TarjetaCredito", typeof(string));
            //dt.Columns.Add("Concepto", typeof(string));
            //dt.Columns.Add("Compartido", typeof(Boolean)).DefaultValue = false;
            //dt.Columns.Add("GastoAdm",typeof(Boolean)).DefaultValue = false;
            //dt.Columns.Add("Observaciones", typeof(string));
            //dt.Columns.Add("EmpresaNombre", typeof(string));
            //grid.DataSource = dt;

            ////luEmpresa.DataSource = Controler.Model.Empresa.ToList();
            ////luEmpresa.DisplayMember = "NombreComercial";
            ////luEmpresa.ValueMember = "Id";

            //var datos = Controler.Model.getFacturasDetalle().ToList();
            //foreach (var f in datos)
            //{
            //    gv.AddNewRow();
            //    //int rowHandle = gv.GetRowHandle(gv.DataRowCount);
            //    //gv.SetRowCellValue(rowHandle, gv.Columns["EmpresaId"], Controler.Model.Empresa.FirstOrDefault(C=>C.Id==f.EmpresaId).NombreComercial);
            //    gv.SetRowCellValue(gv.FocusedRowHandle, gv.Columns["EmpresaNombre"], f.EmpresaNombre);
            //    gv.SetRowCellValue(gv.FocusedRowHandle, gv.Columns["FechaCancelacion"], f.FechaCancelacion);
            //    gv.SetRowCellValue(gv.FocusedRowHandle, gv.Columns["Factura"], f.Factura);
            //    gv.SetRowCellValue(gv.FocusedRowHandle, gv.Columns["FechaFactura"], f.FechaFactura);
            //    gv.SetRowCellValue(gv.FocusedRowHandle, gv.Columns["Importe"], f.Importe);
            //    gv.SetRowCellValue(gv.FocusedRowHandle, gv.Columns["Proveedor"], f.Proveedor);
            //    gv.SetRowCellValue(gv.FocusedRowHandle, gv.Columns["Obra_Nombre"], f.Obra_Nombre);
            //    gv.SetRowCellValue(gv.FocusedRowHandle, gv.Columns["TipoMovimiento_Nombre"], f.TipoMovimiento_Nombre);
            //    gv.SetRowCellValue(gv.FocusedRowHandle, gv.Columns["Pago_Consecutivo"], f.Pago_Consecutivo);
            //    gv.SetRowCellValue(gv.FocusedRowHandle, gv.Columns["TipoPago_Nombre"], f.TipoPago_Nombre);
            //    gv.SetRowCellValue(gv.FocusedRowHandle, gv.Columns["Contrarecibo_Folio"], f.Contrarecibo_Folio);
            //    //gv.SetRowCellValue(rowHandle, gv.Columns["TarjetaCredito"], f.TarjetaCredito + " - " + (Controler.Model.Empleado.FirstOrDefault(E => E.Id == f.EmpleadoId) == null ? string.Empty : Controler.Model.Empleado.FirstOrDefault(E => E.Id == f.EmpleadoId).Nombre));
            //    gv.SetRowCellValue(gv.FocusedRowHandle, gv.Columns["TarjetaCredito"], f.TarjetaCredito + " - " + f.EmpleadoId);
            //    gv.SetRowCellValue(gv.FocusedRowHandle, gv.Columns["Concepto"], f.Concepto);                
            //    gv.SetRowCellValue(gv.FocusedRowHandle, gv.Columns["Compartido"], f.Compartido == null || Convert.ToInt32(f.Compartido) == 0 ? false : true);
            //    gv.SetRowCellValue(gv.FocusedRowHandle, gv.Columns["GastoAdm"], f.GastoAdm == null || Convert.ToInt32(f.GastoAdm) == 0 ? false : true);
            //    gv.SetRowCellValue(gv.FocusedRowHandle, gv.Columns["Observaciones"], f.Observaciones);
            //    gv.UpdateCurrentRow();                
            //}
            //grid.RefreshDataSource();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            llenaGrid();
        }

        private void btnReporte_Click(object sender, EventArgs e)
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
            }
        }
    }
}
