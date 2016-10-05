using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GeisaBD;
using Reportes;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Reporting.WinForms;
using System.Data.Common;
using System.IO;
using DevExpress.XtraEditors.Controls;

namespace SistemaGEISA
{
    public partial class frmPrestamosEmpresasAcmNew : DevExpress.XtraEditors.XtraForm
    {
        private Boolean isNew=true;
        public Boolean prestamo = false;
        public Boolean abono = false;
        public Controler controler { get; set; }
        public Pagos item { get; set; }
        public CajaChicaPrestamo CajaPrestamo { get; set; }
        private DataTable dt;
        public int tipoMovimientoId;
        public Pagos pagoSelected { get; set; }

        public frmPrestamosEmpresasAcmNew(Controler _controler)
        {
            InitializeComponent();
            controler = _controler ?? new Controler();
        }

        public void llenaGrid()
        {
            leEmpresa.DataSource = controler.Model.Empresa.Where(D => D.Activo == true).ToList();
            leEmpresa.DisplayMember = "NombreFiscal";
            leEmpresa.ValueMember = "Id";

            leTipoPago.DataSource = controler.Model.TipoPago.ToList();
            leTipoPago.DisplayMember = "Nombre";
            leTipoPago.ValueMember = "Id";

            //leBancos.DataSource = controler.Model.Bancos.ToList();
            //leBancos.DisplayMember = "Nombre";
            //leBancos.ValueMember = "Id";

            dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("FechaPago", typeof(DateTime));
            dt.Columns.Add("BeneficiarioNombre", typeof(string));
            dt.Columns.Add("EmpresaId", typeof(int));
            dt.Columns.Add("TipoPagoId", typeof(int));
            dt.Columns.Add("BancosNombre", typeof(string));
            dt.Columns.Add("Referencias", typeof(string));
            dt.Columns.Add("Cargo", typeof(double));
            dt.Columns.Add("Abono", typeof(double));
            dt.Columns.Add("TotalPrestamo", typeof(double));
            dt.Columns.Add("Folio", typeof(int));
            grid.DataSource = dt;

            List <Pagos> pagos = controler.Model.Pagos.Where(P => P.CajaChicaPrestamoId == CajaPrestamo.Id).ToList();
            if (pagos != null)
            {
                foreach (Pagos pago in pagos)
                {
                    gv.AddNewRow();
                    var rowHandle = gv.GetRowHandle(gv.DataRowCount);
                    if (gv.IsNewItemRow(rowHandle))
                    {
                        gv.SetRowCellValue(rowHandle, gv.Columns["Id"], pago.Id);
                        gv.SetRowCellValue(rowHandle, gv.Columns["FechaPago"], pago.FechaPago);
                        gv.SetRowCellValue(rowHandle, gv.Columns["BeneficiarioNombre"], CajaPrestamo.BeneficiarioNombre);
                        gv.SetRowCellValue(rowHandle, gv.Columns["EmpresaId"], CajaPrestamo.EmpresaId);
                        gv.SetRowCellValue(rowHandle, gv.Columns["TipoPagoId"], pago.TipoPagoId);
                        gv.SetRowCellValue(rowHandle, gv.Columns["BancosNombre"], pago.BancosNombre);
                        gv.SetRowCellValue(rowHandle, gv.Columns["Referencias"], pago.Consecutivo);
                        gv.SetRowCellValue(rowHandle, gv.Columns["Cargo"], pago.Cargo);
                        gv.SetRowCellValue(rowHandle, gv.Columns["Abono"], pago.Abono);
                        //gv.SetRowCellValue(rowHandle, gv.Columns["TotalPrestamo"], 0);
                        gv.SetRowCellValue(rowHandle, gv.Columns["Folio"], pago.Folio);
                        gv.UpdateCurrentRow();
                        gv.RefreshData();
                    }
                }
            }


            calculaTotales();

        }

        private void calculaTotales()
        {
            if (gv.DataRowCount > 0)
            {
                for (int i = 0; i < gv.RowCount; i++)
                {
                    //DataRow Currentrow = gv.GetDataRow(i);
                    var id = Convert.ToInt32(gv.GetDataRow(i)["Id"]);
                    Pagos row = controler.Model.Pagos.FirstOrDefault(P => P.Id == id);
                    if (row != null)
                    {

                        if (i == 0)
                            gv.SetRowCellValue(i, gv.Columns["TotalPrestamo"], row.Cargo > 0 ? row.Cargo : 0);
                        else
                        {
                            DataRow row_before = gv.GetDataRow(i - 1);
                            if (row.Cargo > 0)
                                gv.SetRowCellValue(i, gv.Columns["TotalPrestamo"], Convert.ToDouble(row_before["TotalPrestamo"]) + row.Cargo);
                            else
                                gv.SetRowCellValue(i, gv.Columns["TotalPrestamo"], Convert.ToDouble(row_before["TotalPrestamo"]) - row.Abono);
                        }
                    }
                }
                gv.UpdateCurrentRow();
                gv.RefreshData();
            }
        }

        private void llenaEmpresas()
        {
            //List<int> datosCaja;

            //if (CajaPrestamo == null)
            //    datosCaja = controler.Model.CajaChicaPrestamo.Select(x => x.EmpresaId).ToList();
            //else
            //    datosCaja = controler.Model.CajaChicaPrestamo.Where(x => x.EmpresaId != CajaPrestamo.EmpresaId).Select(x => x.EmpresaId).ToList();

            //luPrestamista.Properties.DataSource = controler.Model.Empresa.Where(D => D.Activo == true && !datosCaja.Contains(D.Id)).ToList();
            luPrestamista.Properties.DataSource = controler.Model.Empresa.Where(D => D.Activo == true).ToList();
            luPrestamista.Properties.DisplayMember = "NombreFiscal";
            luPrestamista.Properties.ValueMember = "Id";

            //List<int> datosCajaBeneficiario;

            //if (CajaPrestamo == null)
            //    datosCajaBeneficiario = controler.Model.CajaChicaPrestamo.Select(x => x.BeneficiarioId).ToList();
            //else
            //    datosCajaBeneficiario = controler.Model.CajaChicaPrestamo.Where(x => x.BeneficiarioId != CajaPrestamo.BeneficiarioId).Select(x => x.BeneficiarioId).ToList();

            //luBeneficiario.Properties.DataSource = controler.Model.Empresa.Where(D => D.Activo == true && !datosCajaBeneficiario.Contains(D.Id)).ToList();
            luBeneficiario.Properties.DataSource = controler.Model.Empresa.Where(D => D.Activo == true).ToList();
            luBeneficiario.Properties.DisplayMember = "NombreFiscal";
            luBeneficiario.Properties.ValueMember = "Id";
        }

        private void frmPrestamosEmpresasAcmNew_Load(object sender, EventArgs e)
        {
            this.Text= CajaPrestamo != null ? "Empleado/Empresa : Editar" : "Empleado/Empresa : Nuevo";
            llenaEmpresas();
            if (CajaPrestamo != null)
            {
                luPrestamista.EditValue = CajaPrestamo.EmpresaId;
                luBeneficiario.EditValue = CajaPrestamo.BeneficiarioId;
                botones(false);
                llenaGrid();
            }
            else
            {                
                botones(true);
            }
            
        }

        private void botones(Boolean nuevo)
        {
            luBeneficiario.Properties.ReadOnly = true;

            if (nuevo)
            {
                btnGuardar.Visible = true;
                btnPrestamos.Visible = false;
                btnAbonos.Visible = false;
                btnEliminar.Enabled = false;
                btnExportar.Enabled = false;
                luPrestamista.Properties.ReadOnly = false;
                luBeneficiario.Properties.ReadOnly = false;
            }
            else
            {
                btnGuardar.Visible = false;
                btnPrestamos.Visible = true;
                btnAbonos.Visible = true;
                btnEliminar.Enabled = true;
                btnExportar.Enabled = true;
                luPrestamista.Properties.ReadOnly = true;
                luBeneficiario.Properties.ReadOnly = true;
            }
        }


        private bool isValid()
        {
            var areValid = true;
            var isValid = true;

            areValid &= isValid = luBeneficiario.GetSelectedDataRow() == luPrestamista.GetSelectedDataRow()? false : true;
            controler.SetError(luBeneficiario, isValid ? string.Empty : "No se permiten prestamos a la misma Empresa.");
            controler.SetError(luPrestamista, isValid ? string.Empty : "No se permiten prestamos a la misma Empresa.");


            areValid &= isValid = luBeneficiario.GetSelectedDataRow() != null;
            controler.SetError(luBeneficiario, isValid ? string.Empty : "Seleccione Beneficiario.");

            areValid &= isValid = luPrestamista.GetSelectedDataRow() != null;
            controler.SetError(luPrestamista, isValid ? string.Empty : "Seleccione Prestamista.");

            return areValid;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var error = string.Empty;
            var isNew = false;

            if (isValid())
            {
                if (CajaPrestamo == null)
                {
                    CajaPrestamo = new CajaChicaPrestamo();
                    isNew = true;
                }

                CajaPrestamo.EmpresaId = (luPrestamista.GetSelectedDataRow() as Empresa).Id;
                CajaPrestamo.BeneficiarioId = (luBeneficiario.GetSelectedDataRow() as Empresa).Id;

                CajaPrestamo.Fecha = DateTime.Now;
                if (!CajaPrestamo.NoEsNuevo)
                    controler.Model.AddToCajaChicaPrestamo(CajaPrestamo);

                try
                {
                    controler.Model.SaveChanges();
                    botones(false);
                }
                catch (Exception ex)
                {
                    error = ex.InnerException.Message;
                }
                finally
                {
                    var title = string.IsNullOrEmpty(error) ? "Confirmación" : "Error";
                    var message = string.Empty;
                    message = string.IsNullOrEmpty(error) ? string.Concat("La caja chica generada exitosamente.") : string.Concat("No se pudo generar:\n", error);
                    new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();
                }

                if (string.IsNullOrEmpty(error))
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
        }

        private void btnPrestamos_Click(object sender, EventArgs e)
        {
            ToolStripButton boton = sender as ToolStripButton;
            var form = new frmPrestamosEmpresasNew(controler);
            form.CajaPrestamo = this.CajaPrestamo;
            if (!isNew)
            {
                form.pagos = item;                
                form.source = item.TipoMovimientoId == TipoMovimientoEnum.Prestamos.Id ? "PRESTAMO" : "ABONO";
            }
            else
            {
                form.pagos = null;
                form.source = boton.Text == "Prestamos" ? "PRESTAMO" : "ABONO";
            }
            form.tipoMovimientoId = form.source == "PRESTAMO" ? TipoMovimientoEnum.Prestamos.Id : TipoMovimientoEnum.Abonos.Id;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                llenaGrid();
            }
        }

        private void gv_DoubleClick(object sender, EventArgs e)
        {
            if (item != null)
            {
                    isNew = false;
                    btnPrestamos_Click(null, null);                
            }
            isNew = true;
        }

        private void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gv.DataRowCount > 0)
            {
                try
                {
                    int id = Convert.ToInt32(gv.GetRowCellValue(gv.FocusedRowHandle, "Id"));
                    item = controler.Model.Pagos.FirstOrDefault(P => P.Id == id);
                }
                catch (Exception ex)
                {
                    item = null;
                }
            }
            //if ()            
            //    {
            //        int id = Convert.ToInt32(gv.GetRowCellValue(gv.FocusedRowHandle, "Id"));
            //        item = controler.Model.Pagos.FirstOrDefault(P => P.Id == id);
            //    }                        
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
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmMessageBox msg = new frmMessageBox(false) { Message = "¿Desea Eliminar el Pago?", Title = "Eliminar Pago" };
            msg.ShowDialog();

            if (msg.DialogResult == System.Windows.Forms.DialogResult.Yes && gv.SelectedRowsCount==1)
            {
                int? registro = gv.GetFocusedDataRow()["Id"] != null ? Convert.ToInt32(gv.GetFocusedDataRow()["Id"]) : (int?)null;
                //Pagos registro=null;
                //if(index!=null)
                //    registro = controler.Model.Pagos.FirstOrDefault(P=>P.Id==index.Value);

                if (registro != null)
                {
                    DbTransaction transaccion = null;

                    try
                    {
                        Pagos item = controler.Model.Pagos.FirstOrDefault(P => P.Id == registro);
                        List<PrestamosDetalle> detalle = controler.Model.PrestamosDetalle.Where(P => P.PagoId == item.Id).ToList();
                        List<PrestamosDetalle> detalle2 = item.PrestamosDetalle.Where(X => X.PagoId == item.Id).ToList();
                        transaccion = controler.Model.BeginTransaction();
                        
                        foreach(PrestamosDetalle detail in detalle)
                        {
                            controler.Model.DeleteObject(detail);
                        }
                        controler.Model.DeleteObject(item);
                        controler.Model.SaveChanges();
                        transaccion.Commit();
                        new frmMessageBox(true) { Message = "El Prestamo ha sido Eliminado.", Title = "Aviso" }.ShowDialog();
                        gv.DeleteRow(gv.FocusedRowHandle);
                        gv.RefreshData();
                        calculaTotales();
                    }
                    catch (Exception ex)
                    {
                        new frmMessageBox(true) { Message = "Error al quitar el Prestamo: " + ex.InnerException.Message, Title = "Error" }.ShowDialog();
                        if (transaccion != null) transaccion.Rollback();
                    }
                }
            }
            else
            {
                new frmMessageBox(true) { Message = "Seleccione un Pago a Eliminar.", Title = "Aviso" }.ShowDialog();
            }
            controler.Model.CloseConnection();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Funciones.Print(grid);
        }
    }
}
