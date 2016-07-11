using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using DevExpress.XtraEditors;
using GeisaBD;
using System.Data.Common;
using Reportes;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using System.Globalization;
using Microsoft.Reporting.WinForms;
using System.Collections;
using SistemaGEISA.Movimientos;

namespace SistemaGEISA
{
    public partial class frmReposicionGastosNew : XtraForm
    {
        private double totalMonto;
        public Controler controler { get; set; }
        //public ReposicionGastos reposicionGastos { get; set; }
        public Pagos pagos { get; set; }
        public int tipoMovimientoId;
        private DataTable dt;
        public bool tienePermisoAgregar, tienePermisoModificar, tienePermisoCancelar;        

        public frmReposicionGastosNew(Controler _controler)
        {
            InitializeComponent();
            controler = _controler ?? new Controler();
        }

        private bool gridValido()
        {

            bool isValid = true;
            for (int i = 0; i < gv.RowCount; i++)
            {
                DataRow row = gv.GetDataRow(i);
                if (row != null)
                {
                    isValid = gv.IsValidRowHandle(i);
                    if (!isValid) return isValid;
                }

            }
            return isValid;
        }

        private void calcula_Totales()
        {
            double diferencia = 0;
            double total = 0;

            for (int i = 0; i < gv.RowCount; i++)
            {
                DataRow row = gv.GetDataRow(i);

                if (row != null)
                {
                    total += Convert.ToDouble(row["Importe"].ToString());
                }
            }
            diferencia = totalMonto-total;
            txtDif.Text = diferencia.ToString("c2");
            if (diferencia < 0)
                txtDif.BackColor = System.Drawing.Color.Red;
            else
                txtDif.BackColor = System.Drawing.SystemColors.Control;

            txtTot.Text = total.ToString("c2");

        }

        private void frmReposicionGastosNew_Load(object sender, EventArgs e)
        {
            btnGuardar.Enabled = btnEliminar.Enabled = tienePermisoAgregar || tienePermisoModificar;
            llenaGrid();
            llenaCombos();
            

            if (pagos != null)
            {
                txtFolio.Text = pagos.Folio.ToString();
                dtFecha.EditValue = pagos.FechaPago;
                luEmpleado.EditValue = pagos.EmpleadoId;
                luEmpresa.EditValue = pagos.EmpresaId;
                luTipoPago.EditValue = pagos.TipoPagoId;
                txtTotMov.Text = pagos.MontoPagar == null ? String.Format("{0:C2}", "0") : String.Format("{0:C2}", pagos.MontoPagar);
                

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
                    btnGuardar.Enabled = btnAgregar.Enabled = btnEliminar.Enabled = false;
                }

                foreach (PagosFactura serv in controler.Model.PagosFactura.Where(D => D.PagosId == pagos.Id).ToList())
                {
                    gv.AddNewRow();

                    int rowHandle = gv.GetRowHandle(gv.DataRowCount);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Id"], serv.FacturaLoaded.Id);
                    gv.SetRowCellValue(rowHandle, gv.Columns["NoFactura"], serv.NoFactura);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Fecha"], serv.Fecha);
                    gv.SetRowCellValue(rowHandle, gv.Columns["SaldoActual"], serv.SaldoActual);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Importe"], serv.Importe);
                    gv.SetRowCellValue(rowHandle, gv.Columns["MontoPagar"], serv.MontoPagar);
                    gv.SetRowCellValue(rowHandle, gv.Columns["SaldoFinal"], serv.SaldoFinal);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Observaciones"], serv.Observaciones);
                    gv.SetRowCellValue(rowHandle, gv.Columns["ProveedorId"], serv.Proveedor != null ? serv.Proveedor.Id : (int?)null);
                    gv.SetRowCellValue(rowHandle, gv.Columns["ObraId"], serv.Factura.Obra != null ? serv.Factura.ObraId : (int?)null);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Compartido"], serv.Factura.Compartido==null || Convert.ToInt32(serv.Factura.Compartido)==0 ? false: true);
                    gv.SetRowCellValue(rowHandle, gv.Columns["GastoAdm"], serv.Factura.GastoAdm == null || Convert.ToInt32(serv.Factura.GastoAdm) == 0 ? false : true);

                    gv.UpdateCurrentRow();
                    gv.RefreshData();
                }
                
        
            }
            else
            {
                //int? folio = controler.Model.ReposicionGastos.Select(P => P.Folio).DefaultIfEmpty(0).Max();
                int? folio = controler.Model.Pagos.Where(P => P.TipoMovimientoId == TipoMovimientoEnum.Reposicion_Gastos.Id).Select(P => P.Folio).DefaultIfEmpty(0).Max();
                txtFolio.Text = (folio + 1).ToString();
                txtTotMov.Text = txtDif.Text = txtTot.Text = string.Empty;
                dtFecha.EditValue = DateTime.Now;
                //llenaGrid();
            }
            calcula_Totales();
        }

        #region Funciones
        private void llenaCombos()
        {
            luEmpresa.Properties.DataSource = controler.Model.Empresa.Where(D => D.Activo == true).ToList();
            luEmpresa.Properties.DisplayMember = "NombreComercial";
            luEmpresa.Properties.ValueMember = "Id";

            luEmpleado.Properties.DataSource = controler.Model.Empleado.Where(D => D.Activo == true).ToList();
            luEmpleado.Properties.DisplayMember = "NombreCompleto";
            luEmpleado.Properties.ValueMember = "Id";

            luTipoPago.Properties.DataSource = controler.Model.TipoPago.ToList();
            luTipoPago.Properties.DisplayMember = "Nombre";
            luTipoPago.Properties.ValueMember = "Id";

            luProveedor.DataSource = controler.Model.Proveedor.OrderBy(P => P.NombreFiscal).ToList();
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
            dt.Columns.Add("Compartido", typeof(Boolean)).DefaultValue=false;
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

            //areValid &= isValid = luEmpleado.GetSelectedDataRow() != null;
            //controler.SetError(luEmpleado, isValid ? string.Empty : "Seleccione un Empleado");

            areValid &= isValid = luEmpresa.GetSelectedDataRow() != null;
            controler.SetError(luEmpresa, isValid ? string.Empty : "Seleccione una Empresa");

            areValid &= isValid = luTipoPago.GetSelectedDataRow() != null;
            controler.SetError(luTipoPago, isValid ? string.Empty : "Seleccione un Tipo de pago");

            //double val;
            //areValid &= isValid = double.TryParse(txtTotMov.Text, out val);
            //controler.SetError(txtTotMov, isValid ? string.Empty : "Ingresa un Valor Valido para el Monto Total");

            //if (areValid)
            //{
            //    int id = (int)luTipoPago.EditValue;
            //    if (TipoPagoEnum.Cheque.Id == id || TipoPagoEnum.Transferencia.Id == id)
            //    {
            //        areValid &= isValid = luBanco.GetSelectedDataRow() != null;
            //        controler.SetError(luBanco, isValid ? string.Empty : "Seleccione un Banco");
            //    }
            //}

            //if (areValid)
            //{
            //    if (gv.RowCount == 0)
            //    {
            //        new frmMessageBox(true) { Message = "Favor de ingresar facturas.", Title = "Error" }.ShowDialog();
            //        areValid &= false;
            //    }
            //}

            if (areValid)
            {
                for (int i = 0; i < gv.RowCount; i++)
                {
                    DataRow row = gv.GetDataRow(i);

                    if (row != null)
                    {
                        double valor = Convert.ToDouble(gv.GetRowCellValue(i, "MontoPagar"));
                        if (valor <= 0)
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

            Pagos p = controler.Model.Pagos.FirstOrDefault(P => P.Folio == valor && P.TipoMovimientoId == TipoMovimientoEnum.Reposicion_Gastos.Id);

            while (p != null)
            {
                valor += 1;
                p = controler.Model.Pagos.FirstOrDefault(P => P.Folio == valor && P.TipoMovimientoId == TipoMovimientoEnum.Reposicion_Gastos.Id);
            }

            return valor;
        }

        private void imprimir()
        {
            if (pagos.TipoPagoId == TipoPagoEnum.Cheque.Id) imprimirCheque();
        }

        private void imprimirCheque()
        {
            if (pagos.Empleado != null)
            {
                List<ReportParameter> paramReport = new List<ReportParameter>();

                paramReport.Add(new ReportParameter("Empleado",pagos.Empleado.NombreCompleto));
                paramReport.Add(new ReportParameter("Banco", pagos.BancosNombre));
                paramReport.Add(new ReportParameter("Fecha", pagos.Fecha.ToShortDateString()));
                paramReport.Add(new ReportParameter("Empresa", pagos.EmpresaNombre));
                paramReport.Add(new ReportParameter("Importe", pagos.MontoPagar.ToString()));
                paramReport.Add(new ReportParameter("ImporteLetra", Funciones.Num2Text(pagos.MontoPagar.ToString()) + " M.N."));
                paramReport.Add(new ReportParameter("NoCheque", "CH.No." + pagos.Consecutivo.ToString()));
                paramReport.Add(new ReportParameter("NoCuenta", "CTA." + pagos.EmpresaBancosLoaded.NoCuenta));
                paramReport.Add(new ReportParameter("Concepto", "CONCEPTO: PGO. REPOSICION DE GASTOS"));

                new frmPrint("Cheque", null, paramReport).ShowDialog();
            }
        }
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

            if (TipoPagoEnum.Cheque.Id == id || TipoPagoEnum.Transferencia.Id == id)
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

        //private void gv2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        //{
        //    if (e.Column.FieldName == "MontoPagar")
        //    {
        //        double montoPagar = 0;
        //        double saldoactual = 0;
        //        if (!string.IsNullOrEmpty(gv.GetRowCellValue(e.RowHandle, "MontoPagar").ToString()))
        //        {
        //            montoPagar = Convert.ToDouble(gv.GetRowCellValue(e.RowHandle, "MontoPagar"));
        //        }
        //        if (!string.IsNullOrEmpty(gv.GetRowCellValue(e.RowHandle, "SaldoActual").ToString()))
        //        {
        //            saldoactual = Convert.ToDouble(gv.GetRowCellValue(e.RowHandle, "SaldoActual"));
        //        }
        //        if (montoPagar > saldoactual)
        //        {
        //            new frmMessageBox(true)
        //            {
        //                Message = "No puede abonar un monto mayor que el saldo actual.",
        //                Title = "Error"
        //            }.ShowDialog();
        //            gv.SetRowCellValue(e.RowHandle, gv.Columns["MontoPagar"], saldoactual);
        //        }
        //        else
        //        {
        //            gv.SetRowCellValue(e.RowHandle, gv.Columns["SaldoFinal"], saldoactual - montoPagar);
        //        }
        //    }
        //}
        #endregion

        #region Botones
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var error = string.Empty;
            var isNew = false;

            gv.CloseEditor();

            if (isValid() && gridValido())
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
                    pagos.Empleado = controler.GetObjectFromContext(luEmpleado.GetSelectedDataRow() as Empleado);
                    pagos.TipoPago = controler.GetObjectFromContext(luTipoPago.GetSelectedDataRow() as TipoPago);
                    pagos.Empresa = controler.GetObjectFromContext(luEmpresa.GetSelectedDataRow() as Empresa);
                    pagos.TipoMovimientoId = TipoMovimientoEnum.Reposicion_Gastos.Id;
                    pagos.MontoPagar = totalMonto;
                    pagos.FacturasPagadas = getFacturasPagadas();

                    if (pagos.TipoPago == TipoPagoEnum.Transferencia)
                    {
                        pagos.EmpresaBancos = controler.GetObjectFromContext(luBanco.GetSelectedDataRow() as EmpresaBancos);
                        pagos.Consecutivo = string.IsNullOrEmpty(txtReferencia.Text) == false ? Convert.ToInt32(txtReferencia.Text) : (int?)null;
                    }
                    else if (pagos.TipoPago == TipoPagoEnum.Cheque)
                    {
                        EmpresaBancos banco = luBanco.GetSelectedDataRow() as EmpresaBancos;
                        pagos.EmpresaBancos = controler.GetObjectFromContext(luBanco.GetSelectedDataRow() as EmpresaBancos);
                        pagos.Consecutivo = string.IsNullOrEmpty(txtReferencia.Text)==false? Convert.ToInt32(txtReferencia.Text): (int?)null;
                        banco.FolioActual = banco!=null ? banco.FolioActual + 1: (int?)null;
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

                    if (!pagos.NoEsNuevo)
                    {
                        controler.Model.AddToPagos(pagos);
                    }
                    

                    PagosFactura detalle = null;
                    Factura factura;
                    for (int i = 0; i < gv.RowCount; i++)
                    {
                        DataRow row = gv.GetDataRow(i);

                        if (row != null)
                        {
                            
                            var id = string.IsNullOrEmpty(row["Id"].ToString()) ? 0 : Convert.ToInt32(row["Id"]);
                            if (id != 0)
                            {
                                factura = controler.Model.Factura.FirstOrDefault(D => D.Id == id);
                                //Console.WriteLine(factura.PagosFactura.Count());
                                if (!isNew && id != 0)
                                    detalle = controler.Model.PagosFactura.FirstOrDefault(P => P.FacturaId == id && P.PagosId == pagos.Id);
                                else  
                                    detalle = null;
                            }
                            else
                            {
                                factura = new Factura();
                                detalle = null;
                            }


                            factura.NoFactura = row["NoFactura"].ToString();
                            factura.Fecha = Convert.ToDateTime(row["Fecha"].ToString());
                            factura.Importe = Convert.ToDouble(row["Importe"].ToString());
                            factura.Observaciones = row["Observaciones"].ToString().ToUpper();
                            factura.ProveedorId = string.IsNullOrEmpty(row["ProveedorId"].ToString()) ? (int?)null : Convert.ToInt32(row["ProveedorId"].ToString());
                            factura.ObraId = string.IsNullOrEmpty(row["ObraId"].ToString()) ? (int?)null : Convert.ToInt32(row["ObraId"].ToString());
                            factura.Saldo = Convert.ToDouble(row["SaldoFinal"].ToString());
                            factura.Compartido = Convert.ToBoolean(row["Compartido"]);
                            factura.GastoAdm = Convert.ToBoolean(row["GastoAdm"]);

                            if (!factura.NoEsNuevo) controler.Model.AddToFactura(factura);

                            if (detalle == null) detalle = new PagosFactura();
                            //else factura.Saldo = factura.Saldo + detalle.MontoPagar;
                            detalle.Factura = factura;//isNew ? factura : controler.Model.Factura.Where(f => f.Id == id).SingleOrDefault();
                            detalle.Pagos = pagos;
                            detalle.SaldoActual = Convert.ToDouble(row["SaldoActual"]);
                            detalle.MontoPagar = Convert.ToDouble(row["MontoPagar"]);

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

        private string getFacturasPagadas()
        {
            try
            {
                string facturas = string.Empty;
                string[] obras = new string[gv.DataRowCount];
                if (gv.DataRowCount > 0)
                {
                    facturas = "PGO. FACT. No. ";
                    //Obtengo Obras
                    for (int i = 0; i < gv.RowCount; i++)
                    {
                        DataRow row = gv.GetDataRow(i);

                        if (row != null)
                        {
                            var id = Convert.ToInt32(row["Id"]);
                            Factura factura = controler.Model.Factura.FirstOrDefault(D => D.Id == id);
                            if (!obras.Contains(factura.Obra.Nombre))
                            {
                                obras[i] = factura.Obra.Nombre;
                            }
                        }

                    }

                    Hashtable obras_Facturas = new Hashtable();
                    for (int i = 0; i < gv.RowCount; i++)
                    {
                        DataRow row = gv.GetDataRow(i);

                        if (row != null)
                        {
                            var id = Convert.ToInt32(row["Id"]);
                            Factura factura = controler.Model.Factura.FirstOrDefault(D => D.Id == id);
                            for (int x = 0; x < obras.Length; x++)
                            {
                                if (obras[x] == factura.Obra.Nombre)
                                {
                                    //

                                    obras_Facturas[x] = obras_Facturas[x] + (obras_Facturas[x] == null ? " " : ",") + factura.NoFactura;
                                }

                            }

                        }

                    }

                    for (int i = 0; i < obras.Length; i++)
                    {
                        if (obras_Facturas[i] != null)
                            facturas = facturas + " " + obras_Facturas[i].ToString() + " " + obras[i].ToString();
                    }
                    return facturas;
                }
                else
                    return facturas;
            }
            catch (Exception ex)
            {
                return string.Empty;
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
                    if (pagos != null && (gv.GetRowCellValue(gv.FocusedRowHandle, "Id")!=null && string.IsNullOrEmpty(gv.GetRowCellValue(gv.FocusedRowHandle, "Id").ToString())==false))
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (luEmpleado.EditValue != null)
            {
                Empleado prov = luEmpleado.GetSelectedDataRow() as Empleado;
                frmFacturasPendientes form = new frmFacturasPendientes();
                form.empleado = prov;

                for (int i = 0; i < gv.RowCount; i++)
                {
                    DataRow row = gv.GetDataRow(i);
                    if (row != null)
                    {
                        if (string.IsNullOrEmpty(gv.GetRowCellValue(i, "Id").ToString())==false)
                        {
                            int id = Convert.ToInt32(gv.GetRowCellValue(i, "Id"));
                            form.pagadas.Add(controler.Model.Factura.FirstOrDefault(F => F.Id == id));
                        }
                    }
                }

                form.ShowDialog();

                if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    for (var j = 0; j < form.rowSelected.Count; j++)
                    {
                        gv.AddNewRow();

                        var rowHandle = gv.GetRowHandle(gv.DataRowCount);

                        int id = Convert.ToInt32(form.rowSelected[j]["Id"].ToString());
                        Factura fact = controler.Model.Factura.FirstOrDefault(F => F.Id == id);

                        gv.SetRowCellValue(rowHandle, gv.Columns["Id"], id);
                        gv.SetRowCellValue(rowHandle, gv.Columns["NoFactura"], form.rowSelected[j]["NoFactura"]);
                        gv.SetRowCellValue(rowHandle, gv.Columns["Fecha"], form.rowSelected[j]["Fecha"]);
                        gv.SetRowCellValue(rowHandle, gv.Columns["SaldoActual"], form.rowSelected[j]["Saldo"]);
                        gv.SetRowCellValue(rowHandle, gv.Columns["Importe"], form.rowSelected[j]["Importe"]);
                        gv.SetRowCellValue(rowHandle, gv.Columns["MontoPagar"], form.rowSelected[j]["Saldo"]);
                        gv.SetRowCellValue(rowHandle, gv.Columns["SaldoFinal"], 0);
                        gv.SetRowCellValue(rowHandle, gv.Columns["ProveedorId"], fact.ProveedorId);
                        gv.SetRowCellValue(rowHandle, gv.Columns["ObraId"], fact.ObraId);
                        gv.SetRowCellValue(rowHandle, gv.Columns["Observaciones"], form.rowSelected[j]["Observaciones"]);
                        gv.SetRowCellValue(rowHandle, gv.Columns["Compartido"], fact.Compartido == null || Convert.ToInt32(fact.Compartido) == 0 ? false : true);
                        gv.SetRowCellValue(rowHandle, gv.Columns["GastoAdm"], fact.GastoAdm == null || Convert.ToInt32(fact.GastoAdm) == 0 ? false : true);

                        gv.UpdateCurrentRow();
                        gv.RefreshData();
                    }
                }
            }
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

                if (pagos == null)
                    btnGuardar_Click(null, null);

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

        private void gv_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Caption == "Importe")
            {
                //if (string.IsNullOrEmpty(gv.GetRowCellValue(gv.FocusedRowHandle, "Id").ToString()))
                //{
                    gv.SetRowCellValue(e.RowHandle, gv.Columns["SaldoActual"], Convert.ToDouble(gv.GetRowCellValue(gv.FocusedRowHandle, "Importe")));
                    gv.SetRowCellValue(e.RowHandle, gv.Columns["MontoPagar"], Convert.ToDouble(gv.GetRowCellValue(gv.FocusedRowHandle, "Importe")));
                    gv.SetRowCellValue(e.RowHandle, gv.Columns["SaldoFinal"], 0);
                //}
            }
        }

        private void gv_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {
            GridView view = sender as GridView;
            DataRow row = gv.GetDataRow(gv.FocusedRowHandle);
            if (row != null)
            {
                if (view.FocusedColumn.FieldName == "Importe" && !string.IsNullOrEmpty(gv.GetRowCellValue(gv.FocusedRowHandle, "Id").ToString()))
                {
                    e.Cancel = true;
                }
            }
        }

        private void txtTotMov_TextChanged(object sender, EventArgs e)
        {
            double val;
            try
            {
                val = double.Parse(txtTotMov.Text, NumberStyles.Currency);
            }
            catch (Exception ex)
            {
                val = 0;
            }

            if (val != 0)
            {
                controler.SetError(txtTotMov, string.Empty);
                totalMonto = val;
                calcula_Totales();
            }
            else
            {
                totalMonto = 0;
                calcula_Totales();
            }
        }

        private void gv_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            calcula_Totales();
        }

        private void gv_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //GridView view = sender as GridView;
            //GridColumn colTipoComprobante = view.Columns["NoFactura"];
            //GridColumn colFolio = view.Columns["Fecha"];
            //GridColumn colFecha = view.Columns["Importe"];

            //if (string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, colFactura2).ToString()))
            //{ e.Valid = false; view.SetColumnError(colFactura2, "Campo Factura no es Valido"); return; }

            //DateTime t_Fecha = string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, colFecha2).ToString()) ? DateTime.MinValue : Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, colFecha2));
            //if (t_Fecha == null || string.IsNullOrEmpty(t_Fecha.ToString()) || t_Fecha == DateTime.MinValue)
            //{ e.Valid = false; view.SetColumnError(colFecha2, "Campo Fecha no es Valido"); return; }

            //double importe;
            //double.TryParse(view.GetRowCellValue(e.RowHandle, colImporte2).ToString(), out importe);
            //if (importe == 0)
            //{ e.Valid = false; view.SetColumnError(colImporte2, "Campo Importe no es Valido"); return; }

            GridView view = sender as GridView;
            GridColumn colFactura = view.Columns["NoFactura"];
            GridColumn colFecha = view.Columns["Fecha"];
            GridColumn colImporte = view.Columns["Importe"];

            if (string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, colFactura).ToString()))
            { e.Valid = false; view.SetColumnError(colFactura, "Campo Factura no es Valido"); return; }

            DateTime t_Fecha = string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, colFecha).ToString()) ? DateTime.MinValue : Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, colFecha2));
            if (t_Fecha == null || string.IsNullOrEmpty(t_Fecha.ToString()) || t_Fecha == DateTime.MinValue)
            { e.Valid = false; view.SetColumnError(colFecha, "Campo Fecha no es Valido"); return; }

            double importe;
            double.TryParse(view.GetRowCellValue(e.RowHandle, colImporte).ToString(), out importe);
            if (importe == 0)
            { e.Valid = false; view.SetColumnError(colImporte, "Campo Importe no es Valido"); return; }
        }

        private void gv_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void gv_RowCountChanged(object sender, EventArgs e)
        {
            calcula_Totales();
        }

        private void txtTotMov_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            //Funciones.soloNumerosDec(sender, e);
        }

        private void txtTotMov_Leave(object sender, EventArgs e)
        {
            txtTotMov.Text = totalMonto.ToString("c2");
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