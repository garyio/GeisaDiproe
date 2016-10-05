using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DevExpress.XtraEditors;
using GeisaBD;
using System.Data.Common;
using Reportes;
using DevExpress.XtraGrid.Views.Grid;
using SistemaGEISA.Movimientos;

namespace SistemaGEISA
{
    public partial class frmTarjetasPagosNew : XtraForm
    { 
        public Controler controler { get; set; }
        //public ReposicionGastos reposicionGastos { get; set; }
        public Pagos pagos { get; set; }

        DataTable dt;
        public bool tienePermisoAgregar, tienePermisoModificar, tienePermisoCancelar;
        public int tipoMovimientoId;
        public frmTarjetasPagosNew(Controler _controler)
        {
            InitializeComponent();
            controler = _controler ?? new Controler();
        }

        private void frmTarjetasPagosNew_Load(object sender, EventArgs e)
        {
            btnGuardar.Enabled = btnEliminar.Enabled = tienePermisoAgregar || tienePermisoModificar;
            llenaGrid();
            llenaCombos();


            if (pagos != null)
            {
                txtFolio.Text = pagos.Folio.ToString();
                dtFecha.EditValue = pagos.FechaPago;
                luTarjetas.EditValue = pagos.TarjetaCreditoId;
                luEmpresa.EditValue = pagos.EmpresaId;
                luTipoPago.EditValue = pagos.TipoPagoId;
                txtPeriodo.Text = pagos.Periodo;
                lookupProveedor.EditValue = pagos.ProveedorId;

                if (TipoPagoEnum.Cheque.Id == pagos.TipoPagoId || TipoPagoEnum.Transferencia.Id == pagos.TipoPagoId)
                {
                    luBanco.EditValue = pagos.EmpresaBancosId;
                    txtReferencia.Text = pagos.Consecutivo.ToString();
                }
                else if (TipoPagoEnum.NotaCredito.Id == pagos.TipoPagoId)
                    txtReferencia.Text = pagos.Referencia;

                if (pagos.FechaCancelacion.HasValue)
                {
                    btnCancelar.Visible = false;
                    lbCancelado.Visible = true;
                    btnGuardar.Enabled  = btnEliminar.Enabled = false;
                }

                foreach (PagosFactura serv in controler.Model.PagosFactura.Where(D => D.PagosId == pagos.Id).ToList())
                {
                    gv.AddNewRow();

                    int rowHandle = gv.GetRowHandle(gv.DataRowCount);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Id"], serv.FacturaLoaded.Id);
                    gv.SetRowCellValue(rowHandle, gv.Columns["NoFactura"], serv.NoFactura);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Fecha"], serv.Fecha);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Importe"], serv.Importe);
                    gv.SetRowCellValue(rowHandle, gv.Columns["SaldoActual"], serv.SaldoActual);
                    gv.SetRowCellValue(rowHandle, gv.Columns["MontoPagar"], serv.MontoPagar);
                    gv.SetRowCellValue(rowHandle, gv.Columns["SaldoFinal"], serv.SaldoFinal);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Observaciones"], serv.Observaciones);
                    gv.SetRowCellValue(rowHandle, gv.Columns["ProveedorId"], serv.Proveedor.Id);
                    gv.SetRowCellValue(rowHandle, gv.Columns["ObraId"], serv.Factura.ObraId);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Compartido"], serv.Factura.Compartido == null || Convert.ToInt32(serv.Factura.Compartido) == 0 ? false : true);
                    gv.SetRowCellValue(rowHandle, gv.Columns["GastoAdm"], serv.Factura.GastoAdm == null || Convert.ToInt32(serv.Factura.GastoAdm) == 0 ? false : true);

                    gv.UpdateCurrentRow();
                    gv.RefreshData();
                }
            }
            else
            {
                //int? folio = controler.Model.ReposicionGastos.Select(P => P.Folio).DefaultIfEmpty(0).Max();
                int? folio = controler.Model.Pagos.Where(P => P.TipoMovimientoId == TipoMovimientoEnum.TarjetaCredito.Id).Select(P => P.Folio).DefaultIfEmpty(0).Max();
                txtFolio.Text = (folio + 1).ToString();
                dtFecha.EditValue = DateTime.Now;
                //llenaGrid();
            }
        }


        #region Funciones
        private void llenaCombos()
        {
            luEmpresa.Properties.DataSource = controler.Model.Empresa.Where(D => D.Activo == true).ToList();
            luEmpresa.Properties.DisplayMember = "NombreComercial";
            luEmpresa.Properties.ValueMember = "Id";

            luTarjetas.Properties.DataSource = controler.Model.TarjetasCredito.ToList();
            luTarjetas.Properties.DisplayMember = "Nombre_y_Tarjeta";
            luTarjetas.Properties.ValueMember = "Id";

            luTipoPago.Properties.DataSource = controler.Model.TipoPago.ToList();
            luTipoPago.Properties.DisplayMember = "Nombre";
            luTipoPago.Properties.ValueMember = "Id";

            lookupProveedor.Properties.DataSource = controler.Model.Proveedor.Where(D => D.Activo == true).ToList();
            lookupProveedor.Properties.DisplayMember = "NombreFiscal";
            lookupProveedor.Properties.ValueMember = "Id";

            luProveedor.DataSource = controler.Model.Proveedor.ToList();
            luProveedor.DisplayMember = "NombreFiscal";
            luProveedor.ValueMember = "Id";

            luObra.DataSource = controler.Model.Obra.ToList();
            luObra.DisplayMember = "Nombre";
            luObra.ValueMember = "Id";
        }

        private void llenaGrid()
        {
            dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("NoFactura", typeof(string));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Importe", typeof(double));
            dt.Columns.Add("SaldoActual", typeof(double));
            dt.Columns.Add("MontoPagar", typeof(double));
            dt.Columns.Add("SaldoFinal", typeof(double));
            dt.Columns.Add("Observaciones", typeof(string));
            dt.Columns.Add("ProveedorId", typeof(int));
            dt.Columns.Add("ObraId", typeof(int));
            dt.Columns.Add("Compartido", typeof(Boolean)).DefaultValue = false;
            dt.Columns.Add("GastoAdm", typeof(Boolean)).DefaultValue = false;
            grid2.DataSource = dt;
        }

        private int? obtenerFolio()
        {
            int? folio = (int?)null;

            if (luTipoPago.EditValue != null && luEmpresa.EditValue != null)
            {
                int tipoid = (int)luTipoPago.EditValue;
                int empresaid = (int)luEmpresa.EditValue;
                DateTime fecha = (DateTime)dtFecha.EditValue;
                int tipoMov = this.pagos != null ? this.pagos.TipoMovimientoId.Value : this.tipoMovimientoId;

                if (TipoPagoEnum.Transferencia.Id == tipoid)
                {
                    folio = controler.Model.Pagos.Where(P => P.EmpresaId == empresaid &&
                                                             P.TipoPagoId == tipoid &&
                                                             P.FechaPago.Value.Year == fecha.Year &&
                                                             P.FechaPago.Value.Month == fecha.Month /*&&
                                                             P.TipoMovimientoId == tipoMov */).Select(P => P.Consecutivo).DefaultIfEmpty(0).Max();

                    folio = folio.HasValue ? folio + 1 : 1;
                }
                else if (TipoPagoEnum.Cheque.Id == tipoid)
                {
                    if (luBanco.EditValue != null)
                    {
                        int bancoid = (int)luBanco.EditValue;
                        EmpresaBancos banco = controler.Model.EmpresaBancos.FirstOrDefault(B => B.Id == bancoid);

                        if (banco != null) folio = banco.FolioActual;
                    }
                }
            }

            return folio;
        }
        private void llenaEmpresaBancos()
        {
            var em = controler.GetObjectFromContext(luEmpresa.GetSelectedDataRow() as Empresa);

            if (em != null)
            {
                luBanco.Properties.DataSource = controler.Model.EmpresaBancos.Where(D => D.EmpresaId == em.Id).ToList();
                luBanco.Properties.DisplayMember = "NombreBanco";
                luBanco.Properties.ValueMember = "Id";
            }
        }

        private bool isValid()
        {
            var areValid = true;
            var isValid = true;

            areValid &= controler.CheckEmptyText(txtFolio);

            areValid &= isValid = luTarjetas.GetSelectedDataRow() != null;
            controler.SetError(luTarjetas, isValid ? string.Empty : "Seleccione un Numero de Cuenta");

            areValid &= isValid = lookupProveedor.GetSelectedDataRow() != null;
            controler.SetError(lookupProveedor, isValid ? string.Empty : "Seleccione un Proveedor");

            areValid &= isValid = luEmpresa.GetSelectedDataRow() != null;
            controler.SetError(luEmpresa, isValid ? string.Empty : "Seleccione una Empresa");

            areValid &= isValid = luTipoPago.GetSelectedDataRow() != null;
            controler.SetError(luTipoPago, isValid ? string.Empty : "Seleccione un Tipo de pago");

            if (areValid)
            {
                int id = (int)luTipoPago.EditValue;
                if (TipoPagoEnum.Cheque.Id == id || TipoPagoEnum.Transferencia.Id == id)
                {
                    areValid &= isValid = luBanco.GetSelectedDataRow() != null;
                    controler.SetError(luBanco, isValid ? string.Empty : "Seleccione un Banco");
                }
            }

            if (areValid)
            {
                if (gv.DataRowCount == 0)
                {
                    new frmMessageBox(true) { Message = "Favor de ingresar facturas.", Title = "Error" }.ShowDialog();
                    areValid &= false;
                }
            }

            if (areValid)
            {
                for (int i = 0; i < gv.RowCount; i++)
                {
                    DataRow row = gv.GetDataRow(i);

                    if (row != null)
                    {
                        double valor = Convert.ToDouble(gv.GetRowCellValue(i, "Importe"));
                        if (valor < 0)
                        {
                            new frmMessageBox(true) { Message = "El monto a pagar de la factura: " + gv.GetRowCellValue(i, "NoFactura").ToString() + " debe ser mayor a 0.00", Title = "Error" }.ShowDialog();
                            areValid &= false;
                            break;
                        }
                    }
                }
            }

            return areValid;
        }

        private int CrearFolio()
        {
            int valor = Convert.ToInt32(txtFolio.Text);

            Pagos p = controler.Model.Pagos.FirstOrDefault(P => P.Folio == valor && P.TipoMovimientoId == TipoMovimientoEnum.TarjetaCredito.Id);

            while (p != null)
            {
                valor += 1;
                p = controler.Model.Pagos.FirstOrDefault(P => P.Folio == valor && P.TipoMovimientoId == TipoMovimientoEnum.TarjetaCredito.Id);
            }

            return valor;
        }

        private void imprimir()
        {
            //if (pagos.TipoPagoId == TipoPagoEnum.Cheque.Id) imprimirCheque();
        }

        //private void imprimirCheque()
        //{
        //    List<ReportParameter> paramReport = new List<ReportParameter>();

        //    paramReport.Add(new ReportParameter("Empleado", pagos.Empleado.NombreCompleto));
        //    paramReport.Add(new ReportParameter("Banco", pagos.BancosNombre));
        //    paramReport.Add(new ReportParameter("Fecha", pagos.Fecha.ToShortDateString()));
        //    paramReport.Add(new ReportParameter("Empresa", pagos.EmpresaNombre));
        //    paramReport.Add(new ReportParameter("Importe", pagos.Total.ToString()));
        //    paramReport.Add(new ReportParameter("ImporteLetra", Funciones.Num2Text(pagos.Total.ToString()) + " M.N."));
        //    paramReport.Add(new ReportParameter("NoCheque", "CH.No." + pagos.Consecutivo.ToString()));
        //    paramReport.Add(new ReportParameter("NoCuenta", "CTA." + pagos.EmpresaBancosLoaded.NoCuenta));
        //    paramReport.Add(new ReportParameter("Concepto", "CONCEPTO: PGO. REPOSICION DE GASTOS"));

        //    new frmPrint("Cheque", null, paramReport).ShowDialog();
        //}
        #endregion

        #region Controles
        private void luEmpleado_EditValueChanged(object sender, EventArgs e)
        {
            llenaGrid();
        }

        private void luEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            llenaEmpresaBancos();
            txtReferencia.Text = obtenerFolio().ToString();
        }

        private void dtFecha_EditValueChanged(object sender, EventArgs e)
        {
            txtReferencia.Text = obtenerFolio().ToString();
        }

        private void luTipoPago_EditValueChanged(object sender, EventArgs e)
        {
            int id = (int)luTipoPago.EditValue;
            txtReferencia.Text = "";

            if (TipoPagoEnum.Cheque.Id == id || TipoPagoEnum.Transferencia.Id == id || TipoPagoEnum.Periferica.Id == id)
            {
                txtReferencia.Visible = true;
                lblReferencia.Text = "Consecutivo";
                lblReferencia.Visible = true;
                lblBanco.Visible = true;
                luBanco.Visible = true;
                txtReferencia.Text = obtenerFolio().ToString();
            }
            else if (TipoPagoEnum.NotaCredito.Id == id)
            {
                txtReferencia.Visible = true;
                lblReferencia.Text = "No. Referencia";
                lblReferencia.Visible = true;
                lblBanco.Visible = false;
                luBanco.Visible = false;
            }
            else
            {
                txtReferencia.Visible = lblReferencia.Visible = luBanco.Visible = lblBanco.Visible = false;
            }
        }

        private void luBanco_EditValueChanged(object sender, EventArgs e)
        {
            txtReferencia.Text = obtenerFolio().ToString();
        }

        private void gv2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "MontoPagar")
            {
                double montoPagar = 0;
                double saldoactual = 0;
                if (!string.IsNullOrEmpty(gv.GetRowCellValue(e.RowHandle, "MontoPagar").ToString()))
                {
                    montoPagar = Convert.ToDouble(gv.GetRowCellValue(e.RowHandle, "MontoPagar"));
                }
                if (!string.IsNullOrEmpty(gv.GetRowCellValue(e.RowHandle, "SaldoActual").ToString()))
                {
                    saldoactual = Convert.ToDouble(gv.GetRowCellValue(e.RowHandle, "SaldoActual"));
                }
                if (montoPagar > saldoactual)
                {
                    new frmMessageBox(true)
                    {
                        Message = "No puede abonar un monto mayor que el saldo actual.",
                        Title = "Error"
                    }.ShowDialog();
                    gv.SetRowCellValue(e.RowHandle, gv.Columns["MontoPagar"], saldoactual);
                }
                else
                {
                    gv.SetRowCellValue(e.RowHandle, gv.Columns["SaldoFinal"], saldoactual - montoPagar);
                }
            }
        }
        #endregion

        #region Botones
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var error = string.Empty;
            var isNew = false;

            if (isValid())
            {
                DbTransaction transaccion = null;

                try
                {
                    transaccion = controler.Model.BeginTransaction();

                    if (pagos == null)
                    {
                        pagos = new Pagos();
                        pagos.Folio = CrearFolio();
                        isNew = true;
                    }

                    pagos.Fecha = DateTime.Now;
                    pagos.FechaPago = (DateTime)dtFecha.EditValue;
                    pagos.TipoPago = controler.GetObjectFromContext(luTipoPago.GetSelectedDataRow() as TipoPago);
                    pagos.Empresa = controler.GetObjectFromContext(luEmpresa.GetSelectedDataRow() as Empresa);
                    pagos.TarjetaCreditoId = controler.GetObjectFromContext(luTarjetas.GetSelectedDataRow() as TarjetasCredito).Id;
                    pagos.TipoMovimientoId = TipoMovimientoEnum.TarjetaCredito.Id;
                    pagos.Periodo = txtPeriodo.Text.ToUpper();
                    pagos.Proveedor = controler.GetObjectFromContext(lookupProveedor.GetSelectedDataRow() as Proveedor);

                    if (pagos.TipoPago == TipoPagoEnum.Transferencia)
                    {
                        pagos.EmpresaBancos = controler.GetObjectFromContext(luBanco.GetSelectedDataRow() as EmpresaBancos);
                        pagos.Consecutivo = Convert.ToInt32(txtReferencia.Text);
                    }
                    else if (pagos.TipoPago == TipoPagoEnum.Cheque)
                    {
                        EmpresaBancos banco = luBanco.GetSelectedDataRow() as EmpresaBancos;
                        pagos.EmpresaBancos = controler.GetObjectFromContext(luBanco.GetSelectedDataRow() as EmpresaBancos);
                        pagos.Consecutivo = Convert.ToInt32(txtReferencia.Text);
                        banco.FolioActual = banco.FolioActual + 1;
                    }
                    else if (pagos.TipoPago == TipoPagoEnum.NotaCredito)
                    {
                        pagos.EmpresaBancos = null;
                        pagos.Referencia = txtReferencia.Text.Trim();
                    }
                    else
                    {
                        pagos.EmpresaBancos = null;
                        pagos.Referencia = "";
                    }

                    if (!pagos.NoEsNuevo) controler.Model.AddToPagos(pagos);

                    PagosFactura detalle = null;
                    Factura factura;
                    for (int i = 0; i < gv.RowCount; i++)
                    {
                        DataRow row = gv.GetDataRow(i);

                        if (row != null)
                        {
                            var id = string.IsNullOrEmpty(row["Id"].ToString()) ? 0 : Convert.ToInt32(row["Id"]);
                            if (id != 0)
                                factura = controler.Model.Factura.FirstOrDefault(D => D.Id == id);
                            else
                                factura = new Factura();

                            factura.NoFactura = row["NoFactura"].ToString();
                            factura.Fecha = Convert.ToDateTime(row["Fecha"].ToString());
                            factura.Importe = Convert.ToDouble(row["Importe"].ToString());
                            factura.Observaciones = row["Observaciones"].ToString().ToUpper();
                            factura.ProveedorId = string.IsNullOrEmpty(row["ProveedorId"].ToString()) ? (int?)null : Convert.ToInt32(row["ProveedorId"].ToString());
                            factura.ObraId = string.IsNullOrEmpty(row["ObraId"].ToString()) ? (int?)null : Convert.ToInt32(row["ObraId"].ToString());
                            factura.Saldo = 0;
                            factura.Compartido = Convert.ToBoolean(row["Compartido"]);
                            factura.GastoAdm = Convert.ToBoolean(row["GastoAdm"]);

                            if (!factura.NoEsNuevo) controler.Model.AddToFactura(factura);

                            if (!isNew && id!=0)
                                detalle = controler.Model.PagosFactura.FirstOrDefault(P => P.FacturaId == id && P.PagosId == pagos.Id);
                            else detalle = null;

                            if (detalle == null)
                            {
                                detalle = new PagosFactura();
                                detalle.Factura = factura;//isNew ? factura : controler.Model.Factura.Where(f => f.Id == id).SingleOrDefault();
                                detalle.Pagos = pagos;
                            }
                            //else factura.Saldo = 0;

                            detalle.SaldoActual = Convert.ToDouble(row["Importe"]);
                            detalle.MontoPagar = Convert.ToDouble(row["Importe"]);

                            if (!detalle.NoEsNuevo) controler.Model.AddToPagosFactura(detalle);
                        }
                    }

                    controler.Model.SaveChanges();
                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    if (isNew) pagos = null;
                    if (transaccion != null) transaccion.Rollback();
                    error = ex.InnerException.Message;
                }
                finally
                {
                    controler.Model.CloseConnection();

                    var title = string.IsNullOrEmpty(error) ? "Confirmación" : "Error";
                    var message = string.Empty;

                    if (!isNew)
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("El Pago ha sido actualizado exitosamente.") : string.Concat("No se pudo actualizar el Pago:\n", error);
                    }
                    else
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("El Pago ha sido generado exitosamente.") : string.Concat("No se pudo generar el Pago:\n", error);
                    }

                    new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();
                }

                if (string.IsNullOrEmpty(error))
                {
                    imprimir();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmMessageBox msg = new frmMessageBox(false) { Message = "¿Estas seguro de eliminar esta factura?", Title = "Eliminar Registro" };
            msg.ShowDialog();

            if (msg.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                DataRow row = gv.GetFocusedDataRow() as DataRow;

                if (row != null)
                {
                    if (pagos != null)
                    {
                        var id = Convert.ToInt32(row["Id"]);
                        PagosFactura detalle = controler.Model.PagosFactura.FirstOrDefault(P => P.FacturaId == id);

                        if (detalle != null)
                        {
                            Factura factura = detalle.Factura;

                            factura.Saldo = factura.Saldo + detalle.MontoPagar;
                            controler.Model.DeleteObject(detalle);

                            try
                            {
                                controler.Model.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                new frmMessageBox(true) { Message = "Error al quitar la factura: " + ex.InnerException.Message, Title = "Error" }.ShowDialog();
                            }
                        }
                    }

                    gv.DeleteRow(gv.FocusedRowHandle);
                }
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            imprimir();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmMessageBox confirm = new frmMessageBox(false);
            confirm.Title = "Confirmación";
            confirm.Message = "¿Desea cancelar el pago?";
            confirm.ShowDialog();
            if (confirm.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                string error = string.Empty;

                DbTransaction transaccion = null;

                try
                {
                    transaccion = controler.Model.BeginTransaction();

                    List<PagosFactura> pagosfac = controler.Model.PagosFactura.Where(D => D.PagosId == pagos.Id).ToList();
                    foreach (PagosFactura facpagos in pagosfac)
                    {
                        Factura fac = facpagos.Factura;
                        fac.Saldo = fac.Saldo + facpagos.MontoPagar;
                    }

                    pagos.FechaCancelacion = DateTime.Now;
                    pagos.UsuarioId = frmPrincipal.UsuarioDelSistema.Id;

                    controler.Model.SaveChanges();
                    transaccion.Commit();
                }
                catch (Exception ex)
                {
                    if (transaccion != null) transaccion.Rollback();
                    error = ex.InnerException.Message;
                }
                finally
                {
                    controler.Model.CloseConnection();

                    var title = string.IsNullOrEmpty(error) ? "Confirmación" : "Error";
                    var message = string.Empty;

                    message = string.IsNullOrEmpty(error) ? string.Concat("El Pago ha sido cancelado exitosamente.") : string.Concat("No se pudo cancelar el Pago:\n", error);
                    new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();
                }

                if (string.IsNullOrEmpty(error))
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }
        #endregion

        //Con este metodo prohibo que puedan editar en el campo de Importe
        private void gv_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            frmMessageBox msg = new frmMessageBox(false) { Message = "¿Estas seguro de eliminar esta factura?", Title = "Eliminar Registro" };
            msg.ShowDialog();

            if (msg.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                DataRow row = gv.GetFocusedDataRow() as DataRow;

                if (row != null)
                {
                    if (pagos != null)
                    {
                        var id = Convert.ToInt32(row["Id"]);
                        PagosFactura detalle = controler.Model.PagosFactura.FirstOrDefault(P => P.FacturaId == id);

                        if (detalle != null)
                        {
                            Factura factura = detalle.Factura;

                            factura.Saldo = factura.Saldo + detalle.MontoPagar;
                            controler.Model.DeleteObject(detalle);

                            try
                            {
                                controler.Model.SaveChanges();
                            }
                            catch (Exception ex)
                            {
                                new frmMessageBox(true) { Message = "Error al quitar la factura: " + ex.InnerException.Message, Title = "Error" }.ShowDialog();
                            }
                        }
                    }

                    gv.DeleteRow(gv.FocusedRowHandle);
                }
            }
        }

        private void toolStripProveedor_Click(object sender, EventArgs e)
        {
            new frmComprobanteProveedor(controler).ShowDialog();
            luProveedor.DataSource = controler.Model.Proveedor.ToList();
            luProveedor.DisplayMember = "NombreFiscal";
            luProveedor.ValueMember = "Id";
            gv.RefreshData();
        }
    }
}
