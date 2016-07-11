using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeisaBD;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.Common;
using System.IO;

namespace SistemaGEISA
{
    public partial class frmBancos : XtraForm
    {
        private int EmpresaId=0;
        private int BancoId=0;

        private double enTransito = 0;
        private CierresMes cierreMes_Anterior;
        private CierresMes CierreMes_Actual;
        
        getDetalleBancos_Result item { get; set; }

        private DataTable dt;

        private Controler _controler = new Controler();

        private Controler Controler
        {
            get
            {
                return _controler;
            }
        }

        bool tienePermisoModificar, tienePermisoAgregar, tienePermisoCancelar;
        public frmBancos()
        {
            InitializeComponent();
            Controler.PermisosEnFormulario(Name);
            btnAgregar.Enabled = btnCerrarMes.Enabled = tienePermisoAgregar = Controler.TienePermiso(PermisosEnum.Agregar);
            //tienePermisoModificar = Controler.TienePermiso(PermisosEnum.Actualizar);
            btnEliminar.Enabled = tienePermisoCancelar = Controler.TienePermiso(PermisosEnum.Cancelar);
        }

        private void frmBancos_Load(object sender, EventArgs e)
        {            
            llenaCbMeses();
            editAño.Value = DateTime.Now.Year;
            cbMeses.SelectedValue = DateTime.Now.Month;
            llenaCombos();
            inicializaValores();
            //calculaImportes();            
        }

        private void inicializaValores()
        {
            txtDif1.Text = "0";
            txtDif2.Text = "0";
            txtDif3.Text = "0";
            txtDifChTransito.Text = "0";
            txtRetiroBancos.Text = "0";
            txtSaldoBancos.Text = "0";
            txtSaldoCirculacion.Text = "0";
            txtSaldoCirculacionAnterior.Text = "0";
            txtSaldoEdoCta.Text = "0";
            txtTotAbonos.Text = "0";
            txtTotCargos.Text = "0";
            txtTotTransito.Text = "0";
            txtTransitoPeriodo.Text = "0";
            txtTransitoPeriodoAnt.Text = "0";
            txtChCobradosMesAnt.Text = "0";            
        }

        private void calculaImportes()
        {            

            txtTotCargos.Text = gv.Columns["Cargo"].SummaryItem.SummaryValue != null ? String.Format("{0:N2}",gv.Columns["Cargo"].SummaryItem.SummaryValue) : "0";
            txtTotAbonos.Text = String.Format("{0:N2}", (Convert.ToDouble(gv.Columns["Abono"].SummaryItem.SummaryValue != null ? gv.Columns["Abono"].SummaryItem.SummaryValue.ToString() : "0"))); 
            txtTotTransito.Text = enTransito.ToString("N2");
            txtTransitoPeriodo.Text = enTransito.ToString("N2");
            
            if (cierreMes_Anterior != null)
            {
                txtSaldoCirculacionAnterior.Text = String.Format("{0:N2}", string.IsNullOrEmpty(cierreMes_Anterior.TotTransito.ToString()) ? 0 : cierreMes_Anterior.TotTransito);
                txtTransitoPeriodoAnt.Text = String.Format("{0:N2}", string.IsNullOrEmpty(cierreMes_Anterior.TotTransito.ToString()) ? 0 : cierreMes_Anterior.TotTransito);                
                if (CierreMes_Actual != null)
                {
                    txtRetiroBancos.Text = String.Format("{0:N2}", string.IsNullOrEmpty(CierreMes_Actual.RetiroBanco.ToString()) ? 0 : CierreMes_Actual.RetiroBanco);
                    txtSaldoEdoCta.Text = String.Format("{0:N2}", string.IsNullOrEmpty(CierreMes_Actual.SaldoEdoCta.ToString()) ? 0 : CierreMes_Actual.SaldoEdoCta);
                    txtChCobradosMesAnt.Text = String.Format("{0:N2}", string.IsNullOrEmpty(CierreMes_Actual.ChCobradosMesAnt.ToString()) ? 0 : CierreMes_Actual.ChCobradosMesAnt);
                }
                else
                {
                    txtRetiroBancos.Text = "0";
                    txtSaldoEdoCta.Text = "0";
                    txtChCobradosMesAnt.Text = "0";
                }
            }
            else
            {
                txtSaldoCirculacionAnterior.Text = "0";
                txtTransitoPeriodoAnt.Text = "0";
                txtChCobradosMesAnt.Text = "0";
                txtRetiroBancos.Text = "0";
                txtSaldoEdoCta.Text = "0";
            }
            
            txtDif1.Text = String.Format("{0:N2}",(Convert.ToDouble(txtTotCargos.Text) - enTransito));
            txtDif2.Text = String.Format("{0:N2}",(Convert.ToDouble(txtDif1.Text) - (string.IsNullOrEmpty(txtRetiroBancos.Text) ? 0 : Convert.ToDouble(txtRetiroBancos.Text))));
            txtDif3.Text = String.Format("{0:N2}",(Convert.ToDouble(string.IsNullOrEmpty(txtTransitoPeriodoAnt.Text) ? "0" : txtTransitoPeriodoAnt.Text) - Convert.ToDouble(txtChCobradosMesAnt.Text)));
            txtSaldoCirculacion.Text = String.Format("{0:N2}", (Convert.ToDouble(txtDif2.Text) - Convert.ToDouble(txtSaldoCirculacionAnterior.Text)));
            txtSaldoBancos.Text = getSaldoBancos().ToString("N2");
            txtDifChTransito.Text = String.Format("{0:N2}",(Convert.ToDouble(string.IsNullOrEmpty(txtSaldoEdoCta.Text) ? "0" : txtSaldoEdoCta.Text) - Convert.ToDouble(txtSaldoBancos.Text)));            

        }

        private double getSaldoBancos()
        {
            if (gv.DataRowCount > 0)
            {
                int max = gv.RowCount - 1;
                getDetalleBancos_Result row_before = gv.GetRow(max) as getDetalleBancos_Result;
                return row_before.Total.Value;
            }
            return 0;
        }

        private void llenaCombos()
        {
            luEmpresa.Properties.DataSource = Controler.Model.Empresa.Where(D => D.Activo == true).ToList();
            luEmpresa.Properties.DisplayMember = "NombreFiscal";
            luEmpresa.Properties.ValueMember = "Id";

            List<string> status = new List<string>();
            status.Add("EN TRANSITO");
            status.Add("COBRADA");
            luEstado.DataSource = status;      
        }

        private void llenaGrid()
        {
            dt = new DataTable();
            dt.Columns.Add("FechaCancelacion", typeof(DateTime));  
            dt.Columns.Add("PagosId", typeof(int));
            dt.Columns.Add("TipoMovimientoId", typeof(int));
            dt.Columns.Add("Empresa", typeof(string));
            dt.Columns.Add("FechaPago", typeof(DateTime));                        
            dt.Columns.Add("Folio", typeof(int));
            dt.Columns.Add("TipoPago", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("FacturasPagadas", typeof(string));
            dt.Columns.Add("Abono", typeof(double));
            dt.Columns.Add("Cargo", typeof(double));
            dt.Columns.Add("estadoFactura", typeof(string));
            dt.Columns.Add("Total", typeof(double));            
            grid.DataSource = dt;
            
        }
        public void llenaCbMeses()
        {
            DataTable ds = new DataTable();
            ds.Columns.Add("codigo", typeof(int));
            ds.Columns.Add("descripcion", typeof(string));
            ds.Rows.Add(1, "ENERO");
            ds.Rows.Add(2, "FEBRERO");
            ds.Rows.Add(3, "MARZO");
            ds.Rows.Add(4, "ABRIL");
            ds.Rows.Add(5, "MAYO");
            ds.Rows.Add(6, "JUNIO");
            ds.Rows.Add(7, "JULIO");
            ds.Rows.Add(8, "AGOSTO");
            ds.Rows.Add(9, "SEPTIEMBRE");
            ds.Rows.Add(10, "OCTUBRE");
            ds.Rows.Add(11, "NOVIEMBRE");
            ds.Rows.Add(12, "DICIEMBRE");
            ds.AcceptChanges();
            cbMeses.DataSource = ds;
            cbMeses.ValueMember = "codigo";
            cbMeses.DisplayMember = "descripcion";
        }

        private void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gv.GetFocusedRow() != null)
                item = gv.GetFocusedRow() as getDetalleBancos_Result;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmMessageBox msg = new frmMessageBox(false) { Message = "¿Desea cerra las transacciones del Mes?", Title = "Confimación." };
            msg.ShowDialog();

            if (msg.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                if(CierreMes_Actual==null)
                {
                    new frmMessageBox(true) { Message = "No es Posible cerrar el mes sin Antes guardar los Cambios. Favor de Guardar", Title = "Aviso." }.ShowDialog();
                    return;
                }
                var error = string.Empty;
                if (gv.DataRowCount > 0)
                {
                    DbTransaction transaccion = null;
                    try
                    {
                        transaccion = Controler.Model.BeginTransaction();
                        //pongo estatus como cerrado del mes
                        CierreMes_Actual.Estatus = false;                                                    
                        Controler.Model.SaveChanges();
                        transaccion.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (transaccion != null) transaccion.Rollback();
                        error = ex.InnerException.Message;
                    }
                    finally
                    {
                        Controler.Model.CloseConnection();
                        if (!string.IsNullOrEmpty(error))
                            new frmMessageBox(true) { Message = string.Concat("Erro al Guardar el Cierre:\n", error), Title = "Error" }.ShowDialog();
                        else
                            new frmMessageBox(true) { Message = "Cierre Guardado Exitosamente.", Title = "Confirmación." }.ShowDialog();
                    }
                }
            }
        }

        private void luEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            var em = Controler.GetObjectFromContext(luEmpresa.GetSelectedDataRow() as Empresa);
            EmpresaId = em.Id;

            if (em != null)
            {
                luBanco.Properties.DataSource = Controler.Model.EmpresaBancos.Where(D => D.EmpresaId == em.Id).ToList();
                luBanco.Properties.DisplayMember = "NombreBanco";
                luBanco.Properties.ValueMember = "Id";
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                
                grid.DataSource= Controler.Model.getDetalleBancos(Convert.ToInt32(cbMeses.SelectedIndex + 1), Convert.ToInt32(editAño.Value),EmpresaId,BancoId).ToList();
                //llenaComisiones();
                int año_actual = Convert.ToInt32(editAño.Value);
                int mes_Actual = Convert.ToInt32(cbMeses.SelectedIndex + 1);                
                int mes_Anterior = Convert.ToInt32(cbMeses.SelectedIndex + 1) == 1 ? 12 : Convert.ToInt32(cbMeses.SelectedIndex + 1) - 1;
                int año_Anterior = Convert.ToInt32(cbMeses.SelectedIndex + 1) == 1  ? Convert.ToInt32(editAño.Value) - 1 : Convert.ToInt32(editAño.Value);
                cierreMes_Anterior = Controler.Model.CierresMes.FirstOrDefault(c => c.Año == año_Anterior && c.Mes == mes_Anterior && c.BancoId == BancoId && c.EmpresaId == EmpresaId && c.Estatus==false);
                CierreMes_Actual = Controler.Model.CierresMes.FirstOrDefault(c => c.Año == año_actual && c.Mes == mes_Actual && c.BancoId == BancoId && c.EmpresaId == EmpresaId);                
                if (cierreMes_Anterior == null)
                {
                    new frmMessageBox(true) { Message = "No se Detecto el Cierre del Mes Anterior, Favor de Verificar.", Title = "Aviso." }.ShowDialog();                
                }
                lblSaldoInicial.Text = "Saldo Inicial: " + String.Format("{0:c2}",(cierreMes_Anterior != null ? (cierreMes_Anterior.SaldoInicial!= null ? cierreMes_Anterior.SaldoFinal : 0) : 0));
                calculaTotales();// Calculo la columna Total              
                calculaImportes();
                if (CierreMes_Actual != null)                
                    btnCerrarMes.Enabled = btnGuardar.Enabled = btnAgregar.Enabled = CierreMes_Actual.Estatus;                
                else
                    btnCerrarMes.Enabled = btnGuardar.Enabled = btnAgregar.Enabled = true;
            }
            else
            {
                new frmMessageBox(true) { Message = "Favor de Llenar todos los Campos.", Title = "Aviso." }.ShowDialog();                
            }
        }

        private void llenaComisiones()
        {
            List<Pagos> comisiones = Controler.Model.Pagos.Where(C => C.TipoMovimientoId == TipoMovimientoEnum.Comisiones.Id).ToList();
            if (comisiones != null)
            {
                foreach (Pagos comision in comisiones)
                {
                    gv.AddNewRow();
                    var rowHandle = gv.GetRowHandle(gv.DataRowCount);
                    if (gv.IsNewItemRow(rowHandle))
                    {
                        gv.SetRowCellValue(rowHandle, gv.Columns["FechaCancelacion"], comision.Fecha);
                        gv.SetRowCellValue(rowHandle, gv.Columns["PagosId"], comision.Id);
                        gv.SetRowCellValue(rowHandle, gv.Columns["TipoMovimientoId"], comision.TipoMovimientoId);
                        gv.SetRowCellValue(rowHandle, gv.Columns["Empresa"], comision.Empresa.NombreComercial);
                        gv.SetRowCellValue(rowHandle, gv.Columns["FechaPago"], comision.FechaPago);
                        gv.SetRowCellValue(rowHandle, gv.Columns["Folio"], comision.Folio);
                        gv.SetRowCellValue(rowHandle, gv.Columns["TipoPago"], comision.TipoPagoId);
                        gv.SetRowCellValue(rowHandle, gv.Columns["Nombre"], comision.Proveedor.NombreComercial);
                        gv.SetRowCellValue(rowHandle, gv.Columns["FacturasPagadas"], comision.FacturasPagadas);
                        gv.SetRowCellValue(rowHandle, gv.Columns["Abono"], 0);
                        gv.SetRowCellValue(rowHandle, gv.Columns["Cargo"], comision.MontoPagar);
                        gv.SetRowCellValue(rowHandle, gv.Columns["estadocomision"], comision.enTransito.Value ? "EN TRANSITO" : "COBRADA");
                        //gv.SetRowCellValue(rowHandle, gv.Columns["Total"], );
                        gv.UpdateCurrentRow();
                        gv.RefreshData();
                    }
                }
            }
        }

        private void calculaTotales()
        {
            enTransito = 0;
            double? saldoInicial = cierreMes_Anterior != null ? (cierreMes_Anterior.SaldoFinal != null ? cierreMes_Anterior.SaldoFinal : 0) : 0;
            if (gv.DataRowCount > 0)
            {
               for (int i = 0; i < gv.RowCount; i++)
               {
                    getDetalleBancos_Result row = gv.GetRow(i) as getDetalleBancos_Result;
                    if (row != null)
                    {
                        if (i == 0)
                        {
                            if (string.IsNullOrEmpty(row.FechaCancelacion.ToString()))
                            {                               
                                gv.SetRowCellValue(i, gv.Columns["Total"], row.Cargo > 0 ? saldoInicial.Value - row.Cargo.Value : saldoInicial.Value + row.Abono.Value);
                                enTransito += row.estadoFactura == "EN TRANSITO" ? (row.Cargo > 0 ? row.Cargo.Value : row.Abono.Value ) : 0;                                
                            }
                            else
                                gv.SetRowCellValue(i, gv.Columns["Total"], saldoInicial.Value);                            
                        }
                        else
                        {
                            getDetalleBancos_Result row_before = gv.GetRow(i - 1) as getDetalleBancos_Result;
                            if (string.IsNullOrEmpty(row.FechaCancelacion.ToString()))
                            {
                                if (row.Cargo > 0)
                                    gv.SetRowCellValue(i, gv.Columns["Total"], row_before.Total - row.Cargo.Value);
                                else
                                    gv.SetRowCellValue(i, gv.Columns["Total"], row_before.Total + row.Abono.Value);
                                enTransito += row.estadoFactura == "EN TRANSITO" ? row.Cargo.Value > 0 ? row.Cargo.Value : row.Abono.Value : 0;
                            }
                            else
                            {
                                gv.SetRowCellValue(i, gv.Columns["Total"], row_before.Total );
                            }
                        }                        
                    }
                }
                gv.UpdateCurrentRow();
                gv.RefreshData();
            }
            //calculaImportes();
        }

        private Boolean isValid()
        {
            if (EmpresaId > 0 && BancoId > 0)
                return true;
            else
                return false;
        }

        private void luBanco_EditValueChanged(object sender, EventArgs e)
        {
            if (luBanco.GetSelectedDataRow() != null)
                BancoId = Convert.ToInt32(luBanco.EditValue);
            else
                BancoId = 0;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                frmBancosIngresos frm = new frmBancosIngresos(Controler);
                frm.EmpresaId = this.EmpresaId;
                frm.BancoId = this.BancoId;
                frm.año = Convert.ToInt32(editAño.Value);
                frm.mes = Convert.ToInt32(cbMeses.SelectedIndex + 1);
                frm.ShowDialog();
            }
            else
            {
                new frmMessageBox(true) { Message = "Favor de Llenar todos los Campos.", Title = "Aviso." }.ShowDialog();
            }
        }

        private void gv_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            var row = gv.GetRow(e.RowHandle);
            if (row != null)
            {
                if (e.Column.FieldName == "FechaPago" || e.Column.FieldName == "Folio" || e.Column.FieldName == "Nombre" || e.Column.FieldName == "FacturasPagadas")
                {
                    int category = Convert.ToInt32(View.GetRowCellDisplayText(e.RowHandle, View.Columns["TipoPago"]));
                    string abono = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Abono"]).ToString();
                    string FechaCancelacion = View.GetRowCellDisplayText(e.RowHandle, View.Columns["FechaCancelacion"]).ToString();
                    if (string.IsNullOrEmpty(FechaCancelacion) == false)
                    {
                        e.Appearance.ForeColor = Color.Red;
                    }
                    else if (category == TipoPagoEnum.Transferencia.Id)
                    {
                        e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
                    }
                    else if (abono != "$0.00")
                    {
                        e.Appearance.ForeColor = Color.Blue;
                    }
                }
                else if (e.Column.FieldName == "Cargo" || e.Column.FieldName == "Abono")
                {
                    string category = View.GetRowCellDisplayText(e.RowHandle, View.Columns["estadoFactura"]).ToString();
                    string cargo = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Cargo"]).ToString();
                    string abono = View.GetRowCellDisplayText(e.RowHandle, View.Columns["Abono"]).ToString();
                    if (category == "COBRADA")
                    {
                        if (e.Column.FieldName == "Cargo" && cargo !="$0.00")
                            e.Appearance.BackColor = Color.Gold;
                        if (e.Column.FieldName == "Abono" && abono != "$0.00")
                            e.Appearance.BackColor = Color.Gold;
                    }
                    else if (category == "EN TRANSITO")
                    {
                        if (e.Column.FieldName == "Cargo" && cargo != "$0.00")
                            e.Appearance.BackColor = Color.LightBlue;
                        if (e.Column.FieldName == "Abono" && abono != "$0.00")
                            e.Appearance.BackColor = Color.LightBlue;
                    }
                }
            }
          
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {            
            var error = string.Empty;
            if (gv.DataRowCount > 0)
            {
                DbTransaction transaccion = null;
                try
                {
                    transaccion = Controler.Model.BeginTransaction();
                    //Guargo Cantidades mes actual
                    if (CierreMes_Actual == null)
                    {
                        CierreMes_Actual = new CierresMes();
                    }
                    CierreMes_Actual.EmpresaId = this.EmpresaId;
                    CierreMes_Actual.BancoId = this.BancoId;
                    CierreMes_Actual.Mes = Convert.ToInt32(cbMeses.SelectedIndex + 1);
                    CierreMes_Actual.Año = Convert.ToInt32(editAño.Value);
                    CierreMes_Actual.Estatus = true;
                    CierreMes_Actual.TotTransito = Convert.ToDouble(txtTotTransito.Text);
                    CierreMes_Actual.TotCargos = Convert.ToDouble(txtTotCargos.Text);
                    CierreMes_Actual.TotAbonos = Convert.ToDouble(txtTotAbonos.Text);
                    CierreMes_Actual.ChCobradosMesAnt = Convert.ToDouble(txtChCobradosMesAnt.Text);
                    CierreMes_Actual.SaldoEdoCta = Convert.ToDouble(txtSaldoEdoCta.Text);
                    CierreMes_Actual.RetiroBanco = Convert.ToDouble(txtRetiroBancos.Text);
                    CierreMes_Actual.SaldoInicial = this.cierreMes_Anterior != null ? (this.cierreMes_Anterior.SaldoFinal!= null ? this.cierreMes_Anterior.SaldoFinal.Value : 0) : 0;

                    getDetalleBancos_Result lastRow = gv.GetRow(gv.DataRowCount-1) as getDetalleBancos_Result;
                    CierreMes_Actual.SaldoFinal = lastRow != null ? (lastRow.Total != null ? lastRow.Total.Value : 0) : 0;

                    if (!CierreMes_Actual.NoEsNuevo) Controler.Model.AddToCierresMes(CierreMes_Actual);

                    for (int i = 0; i < gv.RowCount; i++)
                    {                        
                        getDetalleBancos_Result row = gv.GetRow(i) as getDetalleBancos_Result;
                        if (row != null)
                        {
                            var id = row.Id == 0 ? 0 : Convert.ToInt32(row.Id);
                            Pagos pago = Controler.Model.Pagos.FirstOrDefault(p => p.Id == id);
                            if (pago != null)
                            {
                                pago.enTransito = row.estadoFactura == "EN TRANSITO" ? true : false;
                                pago.esFacturada = row.estadoFactura == "COBRADA" ? true : false;
                                if (!pago.NoEsNuevo) Controler.Model.AddToPagos(pago);
                            }
                            
                        }
                    }
                    Controler.Model.SaveChanges();
                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    if (transaccion != null) transaccion.Rollback();
                    error = ex.InnerException.Message;
                }
                finally
                {
                    Controler.Model.CloseConnection();
                    if(!string.IsNullOrEmpty(error))
                        new frmMessageBox(true) { Message = string.Concat("Erro al Actualizar los Datos:\n", error), Title = "Error" }.ShowDialog();
                    else
                        new frmMessageBox(true) { Message = "Datos Actualizados Exitosamente.", Title = "Confirmación." }.ShowDialog();
                }
            }
        }

        private void gv_DoubleClick(object sender, EventArgs e)
        {            
            if (item != null)
            {
                if (item.TipoMovimientoId == TipoMovimientoEnum.OtrosIngresos.Id || item.TipoMovimientoId == TipoMovimientoEnum.Comisiones.Id)
                {
                    var form = new frmBancosIngresos(Controler);
                    form.pagos = Controler.Model.Pagos.FirstOrDefault(p => p.Id == item.Id);
                    form.EmpresaId = this.EmpresaId;
                    form.BancoId = this.BancoId;
                    form.año = Convert.ToInt32(editAño.Value);
                    form.mes = Convert.ToInt32(cbMeses.SelectedIndex + 1);
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK)
                    {
                        gv_FocusedRowChanged(null, null);
                        btnConsultar_Click(null, null);
                    }
                    form.Dispose();
                    
                }
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            //agregoTotalesGrid();
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

  
       

        private void txtRetiroBancos_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.soloNumerosDec(sender, e);
            txtDif2.Text = (Convert.ToDouble(txtDif1.Text) - (string.IsNullOrEmpty(txtRetiroBancos.Text) ? 0 : Convert.ToDouble(txtRetiroBancos.Text))).ToString();
            //calculaImportes();
        }

        private void txtSaldoEdoCta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.soloNumerosDec(sender, e);
            txtDifChTransito.Text = (Convert.ToDouble(string.IsNullOrEmpty(txtSaldoEdoCta.Text) ? "0" : txtSaldoEdoCta.Text) - Convert.ToDouble(txtSaldoBancos.Text)).ToString(); 
            //calculaImportes();
        }

        private void txtChCobradosMesAnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.soloNumerosDec(sender, e);
            //calculaImportes();
            txtDif3.Text = (Convert.ToDouble(string.IsNullOrEmpty(txtTransitoPeriodoAnt.Text) ? "0" : txtTransitoPeriodoAnt.Text) - Convert.ToDouble(txtChCobradosMesAnt.Text)).ToString();
        }
    }
}
