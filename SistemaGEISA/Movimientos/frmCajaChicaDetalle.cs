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


namespace SistemaGEISA
{
    public partial class frmCajaChicaDetalle : DevExpress.XtraEditors.XtraForm
    {
        DataTable dt;
        private Controler controler { get; set; }
        public CajaChica cajaChica { get; set; }

        public Empleado empleado { get; set; }

        public bool nuevo { get; set; }
        public frmCajaChicaDetalle(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;
        }

        public void llenaGrid()
        {            
            grid.DataSource = controler.Model.CajaChicaDetalle.Where(D => D.CajaChicaId == cajaChica.Id).OrderByDescending(O => O.Id).ToList();
            var Datos = controler.Model.CajaChicaDetalle.Where(D => D.CajaChicaId == cajaChica.Id).ToList();
            double tipoComprobantes = 0;
            double saldo = 0;
            double deposito = 0;
            double devolucion = 0;
            
            foreach(CajaChicaDetalle CajaDetalle in Datos){
                tipoComprobantes += Convert.ToDouble(CajaDetalle.Biaticos);
                tipoComprobantes += Convert.ToDouble(CajaDetalle.Nominas);
                tipoComprobantes += Convert.ToDouble(CajaDetalle.Facturas);
                tipoComprobantes += Convert.ToDouble(CajaDetalle.NoDeducibles);              
                deposito += Convert.ToDouble(CajaDetalle.Deposito);
                devolucion += Convert.ToDouble(CajaDetalle.Devolucion);
            }
            saldo = (deposito + devolucion) - tipoComprobantes;
            txtSaldo.Text = saldo.ToString("c2");
        }

        public void llenaResidente()
        {
            //Obtengo empleados que no tenga creada aun una caja chica.
            List<int> datosCaja;

            if (cajaChica == null)
                datosCaja = controler.Model.CajaChica.Select(x => x.EmpleadoId).ToList();
            else 
                datosCaja = controler.Model.CajaChica.Where(x => x.EmpleadoId != cajaChica.EmpleadoId).Select(x => x.EmpleadoId).ToList();
            
            luResidente.Properties.DataSource = controler.Model.Empleado.Where(D => D.Activo == true && !datosCaja.Contains(D.Id)).ToList();
            luResidente.Properties.DisplayMember = "Residente";
            luResidente.Properties.ValueMember = "Id";
        }

        public void llenaObra()
        {
            var empleado = luResidente.GetSelectedDataRow() as Empleado;

            if (empleado != null)
            {
                luObra.Properties.DataSource = controler.Model.Obra.Where(C => C.EmpleadoId == empleado.Id).ToList();
                luObra.Properties.DisplayMember = "Nombre";
                luObra.Properties.ValueMember = "Id";
                Obra obr = controler.Model.Obra.Where(C => (C.EmpleadoId == empleado.Id)).OrderByDescending(C => C.FechaRegistro).FirstOrDefault();
                if (obr != null)
                {
                    luObra.EditValue = obr.Id;
                }
            }
        }

        private bool isValid()
        {
            var areValid = true;
            var isValid = true;

            areValid &= isValid = luResidente.GetSelectedDataRow() != null;
            controler.SetError(luResidente, isValid ? string.Empty : "Seleccione un Residente");
            controler.SetError(luResidente, empleadoValido() ? string.Empty : "El empleado proporcionado se encuentra en uso con otra Caja.");

            //areValid &= isValid = luObra.GetSelectedDataRow() != null;
            //controler.SetError(luObra, isValid ? string.Empty : "Seleccione una Obra");

            return areValid;
        }

        private void llenaObras() 
        {
            luObra.Properties.DataSource = controler.Model.Obra.ToList();
            luObra.Properties.DisplayMember = "Nombre";
            luObra.Properties.ValueMember = "Id";
        }

        private void frmCajaChicaDetalle_Load(object sender, EventArgs e)
        {
            llenaResidente();
            if (!nuevo)
            {
                luResidente.EditValue = cajaChica.EmpleadoId;
                luObra.Visible = false;
                label2.Visible = false;
                btnComprobante.Visible = true;
                btnDepositar.Visible = true;
                btnGuardar.Visible = false;
                txtSaldo.Visible = true;
                label3.Visible = true;
                llenaGrid();
            }
            else
            {
                
                btnGuardar.Visible = true;
                btnComprobante.Visible = false;
                btnDepositar.Visible = false;
                luResidente.Enabled = true;
                luObra.Enabled = true;
                txtSaldo.Visible = false;
                label3.Visible = false;
                btnReporte.Visible = false;
            }
        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            var form = new frmDeposito(controler);
            form.cajaChica = cajaChica;
            form.empleado = luResidente.GetSelectedDataRow() as Empleado;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK) 
            {
                llenaGrid();
            }
        }

        private void btnComprobar_Click(object sender, EventArgs e)
        {
            var form = new frmComprobante(controler);
            form.cajaChica = cajaChica;
            form.empleado = luResidente.GetSelectedDataRow() as Empleado;
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                llenaGrid();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var error = string.Empty;
            var isNew = false;

            if (isValid())
            {
                if (cajaChica == null)
                {
                    cajaChica = new CajaChica();
                    isNew = true;
                }
                
                cajaChica.Empleado = luResidente.GetSelectedDataRow() as Empleado;
                cajaChica.Fecha = DateTime.Now;
                if(nuevo)
                controler.Model.AddToCajaChica(cajaChica);

                try
                {
                    controler.Model.SaveChanges();
                    btnComprobante.Visible = true;
                    btnDepositar.Visible = true;
                    btnGuardar.Visible = false;
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

        private bool empleadoValido()
        {
            Empleado emp =  luResidente.GetSelectedDataRow() as Empleado;
            var allEmp = controler.Model.CajaChica.Where(C => C.EmpleadoId == emp.Id).ToList();
            if (allEmp.Count > 1)
                return false;
            else
                return true;

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (!layoutFechasReporte.Visible)
                layoutFechasReporte.Visible = true;
            else
                layoutFechasReporte.Visible = false;
        }

        private void luResidente_EditValueChanged(object sender, EventArgs e)
        {
            llenaObra();
            if (!nuevo && luResidente.EditValue!=null)
            {
                btnGuardar.Visible = true;
            }

        }

        private void gv_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(gv.GetRowCellValue(gv.FocusedRowHandle, "Id").ToString()))
            {
                int id = Convert.ToInt32(gv.GetRowCellValue(gv.FocusedRowHandle, "Id"));

                CajaChicaDetalle detalle = controler.Model.CajaChicaDetalle.FirstOrDefault(c => c.Id == id);

                if (detalle.Deposito.HasValue)
                {
                    var form = new frmDeposito(controler);
                    form.cajaChica = cajaChica;
                    form.cajaDetalle = detalle;
                    form.empleado = luResidente.GetSelectedDataRow() as Empleado;
                    form.ShowDialog();

                    if (form.DialogResult == DialogResult.OK)
                        llenaGrid();

                    form.Dispose();
                }
                else
                {
                    var form = new frmComprobante(controler);
                    form.cajaComprobante = controler.Model.CajaChicaComprobante.FirstOrDefault(c => c.CajaChicaDetalleId == id);
                    form.cajaChica = cajaChica;
                    form.empleado = luResidente.GetSelectedDataRow() as Empleado;
                    form.cajaDetalle = detalle;
                    form.ShowDialog();

                    if (form.DialogResult == DialogResult.OK)
                        llenaGrid();

                    form.Dispose();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            frmMessageBox msg = new frmMessageBox(false) { Message = "¿Estas seguro de eliminar este Pago?", Title = "Eliminar Registro" };
            msg.ShowDialog();

            if (msg.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                CajaChicaDetalle cajachica = gv.GetFocusedRow() as CajaChicaDetalle;

                if (cajachica != null)
                {
                    DbTransaction transaccion = null;

                    try
                    {
                    transaccion = controler.Model.BeginTransaction();
                    if (cajachica.Deposito.HasValue)
                    {
                        controler.Model.DeleteObject(cajachica);
                    }else{
                        List<CajaChicaComprobante> comprobantes= cajachica.CajaChicaComprobante.ToList();

                        foreach(CajaChicaComprobante comprobante in comprobantes){
                            if (comprobante.TipoComprobanteId == TipoComprobante.Deducible.Id || comprobante.Factura.Count()>0){
                                 List<Factura> fact= comprobante.Factura.ToList();
                                foreach(Factura f in fact){
                                    if (f.PagosFactura.Count() > 0)
                                    {
                                        string pagos=String.Empty;
                                        foreach(PagosFactura pago in f.PagosFactura){
                                            pagos+=string.Concat(pago.Pagos.Folio,",");
                                        }
                                        pagos=pagos.TrimEnd(',');
                                        new frmMessageBox(true) { Message = "La Factura " + f.NoFactura + " con los pagos("+pagos+") No es posible eliminar.", Title = "Aviso" }.ShowDialog();
                                        if (transaccion != null) transaccion.Rollback();
                                        return;

                                    }
                                    controler.Model.DeleteObject(f);
                                }
                                 controler.Model.DeleteObject(comprobante);
                            }else{
                                controler.Model.DeleteObject(comprobante);
                            }
                            
                        }
                        controler.Model.DeleteObject(cajachica);
                    }
                        
                            controler.Model.SaveChanges();
                            transaccion.Commit();
                            new frmMessageBox(true) { Message = "El Pago ha sido Eliminado.", Title = "Aviso" }.ShowDialog();
                            gv.DeleteRow(gv.FocusedRowHandle);
                            llenaGrid();
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
            controler.Model.CloseConnection();
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

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            new frmPrint("EstadoCuentaCajaChica", new ReportDataSource { Name = "EstadoCuentaCajaChica", Value = new BindingSource { DataSource = new EstadoCuentaCajaChica(cajaChica.Id, string.Concat(cajaChica.Empleado.Nombre, " ", cajaChica.Empleado.ApPaterno, " ", cajaChica.Empleado.ApMaterno), (DateTime)dtInicio.EditValue, (DateTime)dtFin.EditValue).Items } }, null).Show();
            this.Cursor = Cursors.Default;
        }
    }
}