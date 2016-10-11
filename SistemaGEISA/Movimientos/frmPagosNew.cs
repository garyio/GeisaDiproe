using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GeisaBD;
using System.Data.Common;
using Reportes;
using Microsoft.Reporting.Common;
using Microsoft.Reporting.WinForms;
using System.Collections;
using DevExpress.XtraEditors.Controls;

namespace SistemaGEISA
{
    public partial class frmPagosNew : DevExpress.XtraEditors.XtraForm
    {
        private Controler controler { get; set; }
        public Pagos pagos { get; set; }

        public Obra obra;// Se la paso en ingresos
        public bool esTraspaso=false; // Se manda en ingresos para traspasar saldos
        public int idCliente=0;
        public string source = string.Empty;
        public int tipoMovimientoId;
        public double saldoFavor = 0; // Viene de ingresos cuando se hace un traspaso

        public bool tienePermisoAgregar, tienePermisoModificar, tienePermisoCancelar;
        DataTable dt2;

        public frmPagosNew(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;
        }

        private void frmPagosNew_Load(object sender, EventArgs e)
        {
            btnGuardar.Enabled = btnAgregar.Enabled = btnQuitar.Enabled = tienePermisoAgregar || tienePermisoModificar;
            btnCancelar.Enabled = tienePermisoCancelar;           
            llenaCombos();
            llenaGridP();

            btnCancelar.Visible = pagos != null;
            if (!(this.tipoMovimientoId == TipoMovimientoEnum.Pagos.Id))
            {
                rgOpcion.Visible = false;
            }
            

            if (pagos != null)
            {
                //Refresco Informacion del Pago
                controler.Model.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, controler.Model.Pagos.Where(P => P.Id == pagos.Id).ToList());
                List<int> pagosDetalle = this.pagos.PagosFactura.Select(I => I.FacturaId).ToList();
                List<int> pagosFact = this.pagos.PagosFactura.Select(I => I.Id).ToList();
                controler.Model.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, controler.Model.Factura.Where(F => pagosDetalle.Contains(F.Id)).ToList());
                controler.Model.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, controler.Model.PagosFactura.Where(F => pagosFact.Contains(F.Id)).ToList());
                //******************************

                txtFolio.Text = pagos.Folio.ToString();
                dtFechaPago.EditValue = pagos.FechaPago;
                if(rgOpcion.Visible)
                    rgOpcion.EditValue = pagos.Proveedor != null ? 2 : 1; 
                luProveedor.EditValue = pagos.ProveedorId.HasValue ? pagos.ProveedorId : pagos.ClienteId;
                luEmpresa.EditValue = pagos.EmpresaId;
                luTipoPago.EditValue = pagos.TipoPagoId;

                if (TipoPagoEnum.Cheque.Id == pagos.TipoPagoId || TipoPagoEnum.Transferencia.Id == pagos.TipoPagoId)
                {
                    luBanco.EditValue = pagos.EmpresaBancosId;
                    txtReferencia.Text = pagos.Consecutivo.ToString();
                }
                else if (TipoPagoEnum.NotaCredito.Id == pagos.TipoPagoId)
                    txtReferencia.Text = pagos.Referencia;
                else if (TipoPagoEnum.Periferica.Id == pagos.TipoPagoId)
                {
                    luBanco.EditValue = pagos.TarjetasCredito.Id;
                    txtReferencia.Text = pagos.Consecutivo.ToString();
                }

                if (pagos.FechaCancelacion.HasValue)
                {
                    btnCancelar.Visible = false;
                    lbCancelado.Visible = true;
                    btnGuardar.Enabled = btnAgregar.Enabled = btnQuitar.Enabled = false;
                }

                bool esDevolucion = false;
                foreach (PagosFactura serv in controler.Model.PagosFactura.Where(D => D.PagosId == pagos.Id).ToList())
                {
                    gv2.AddNewRow();

                    var rowHandle = gv2.GetRowHandle(gv2.DataRowCount);
                    gv2.SetRowCellValue(rowHandle, gv2.Columns["Id"], serv.FacturaLoaded.Id);
                    gv2.SetRowCellValue(rowHandle, gv2.Columns["NoFactura"], serv.NoFactura);
                    gv2.SetRowCellValue(rowHandle, gv2.Columns["Fecha"], serv.Fecha);
                    gv2.SetRowCellValue(rowHandle, gv2.Columns["SaldoActual"], serv.SaldoActual);
                    gv2.SetRowCellValue(rowHandle, gv2.Columns["Importe"], serv.Importe);
                    gv2.SetRowCellValue(rowHandle, gv2.Columns["MontoPagar"], serv.MontoPagar);
                    gv2.SetRowCellValue(rowHandle, gv2.Columns["SaldoFinal"], serv.SaldoFinal);
                    gv2.SetRowCellValue(rowHandle, gv2.Columns["Observaciones"], serv.Observaciones);
                    gv2.SetRowCellValue(rowHandle, gv2.Columns["ObraNombre"], serv.FacturaLoaded!= null ? serv.FacturaLoaded.ObraNombre: string.Empty);
                    gv2.SetRowCellValue(rowHandle, gv2.Columns["Compartido"], serv.Factura.Compartido == null || Convert.ToInt32(serv.Factura.Compartido) == 0 ? false : true);
                    gv2.SetRowCellValue(rowHandle, gv2.Columns["GastoAdm"], serv.Factura.GastoAdm == null || Convert.ToInt32(serv.Factura.GastoAdm) == 0 ? false : true);
                    gv2.SetRowCellValue(rowHandle, gv2.Columns["esDevolucion"], serv.Factura.esDevolucion == null || Convert.ToInt32(serv.Factura.esDevolucion) == 0 ? false : true);
                    gv2.SetRowCellValue(rowHandle, gv2.Columns["esPrestamo"], serv.Factura.esPrestamo == null || Convert.ToInt32(serv.Factura.esPrestamo) == 0 ? false : true);
                    if (esDevolucion == false)
                        esDevolucion = serv.Factura.esDevolucion.HasValue ? (serv.Factura.esDevolucion.Value) : false;

                    gv2.UpdateCurrentRow();
                    gv2.RefreshData();
                }
            }
            else
            {
                int? folio;
                if (obra != null) // Posibles folios para cuando viene de Ingresos
                {
                    if (this.tipoMovimientoId == TipoMovimientoEnum.NotaCreditoFactura.Id)
                        folio = controler.Model.Pagos.Where(P => P.TipoMovimientoId == TipoMovimientoEnum.NotaCreditoFactura.Id).Select(P => P.Folio).DefaultIfEmpty(0).Max();
                    else if(this.tipoMovimientoId == TipoMovimientoEnum.Traspaso_Abono.Id)
                        folio = controler.Model.Pagos.Where(P => P.TipoMovimientoId == TipoMovimientoEnum.Traspaso_Abono.Id).Select(P => P.Folio).DefaultIfEmpty(0).Max();
                    else if (this.tipoMovimientoId == TipoMovimientoEnum.Abonos.Id)
                        folio = controler.Model.Pagos.Where(P => P.TipoMovimientoId == TipoMovimientoEnum.Abonos.Id).Select(P => P.Folio).DefaultIfEmpty(0).Max();
                    else
                        folio = controler.Model.Pagos.Where(P => P.TipoMovimientoId == TipoMovimientoEnum.Ingresos.Id).Select(P => P.Folio).DefaultIfEmpty(0).Max();
                } // viene de Pagos
                else
                {
                    folio = controler.Model.Pagos.Where(P => P.TipoMovimientoId == TipoMovimientoEnum.Pagos.Id).Select(P => P.Folio).DefaultIfEmpty(0).Max();
                }
                txtFolio.Text = (folio.Value + 1).ToString();
                dtFechaPago.EditValue = DateTime.Now;
                if(rgOpcion.Visible) rgOpcion.EditValue = 2; // Proveedor por default
            }

            //si viene de un ingreso oculta GA y GC
            if (obra != null)
            {

                gv2.Columns.ColumnByFieldName("Compartido").Visible = false;
                gv2.Columns.ColumnByFieldName("GastoAdm").Visible = false;
                if (source != string.Empty)                                    
                    label7.Text = "No. Nota de Credito";

                if (pagos == null)
                {
                    luProveedor.EditValue = idCliente;
                    luProveedor.Enabled = esTraspaso; // si viene de un traspaso puede modificar
                    luEmpresa.EditValue = obra.EmpresaId;
                    luEmpresa.Enabled = esTraspaso; // si viene de un traspaso puede modificar
                    luObra.Visible = lblObra.Visible = lblSaldoFavor.Visible = esTraspaso;// solo se muestra en Traspasos
                    luObra.EditValue = obra.Id;
                    luObra.Enabled = esTraspaso; // si viene de un traspaso puede modificar
                    lblSaldoFavor.Text = esTraspaso ? ("Saldo Favor: " + this.saldoFavor.ToString("c2")): string.Empty;
                }
                else
                { // Entra cuando editas un abono o NC en los movimientos de ingresos
                    luProveedor.Enabled = false;
                    luEmpresa.Enabled = false;
                }
                if (source != string.Empty) luTipoPago.Enabled = false;
            }
            // Si es un Pago muestro Devolucion , si es Abono Muestro Prestamo
            colDevolucion.Visible = tipoMovimientoId == TipoMovimientoEnum.Pagos.Id ? true : false;
            colPrestamo.Visible = tipoMovimientoId == TipoMovimientoEnum.Traspaso_Abono.Id || tipoMovimientoId == TipoMovimientoEnum.Abonos.Id || tipoMovimientoId == TipoMovimientoEnum.Ingresos.Id || (pagos != null ? (pagos.TipoMovimientoId == TipoMovimientoEnum.Abonos.Id || pagos.TipoMovimientoId == TipoMovimientoEnum.Ingresos.Id) : false) ? true : false;

        }

        #region Funciones
        private void llenaCombos()
        {
            luEmpresa.Properties.DataSource = controler.Model.Empresa.Where(D => D.Activo == true).ToList();
            luEmpresa.Properties.DisplayMember = "NombreComercial";
            luEmpresa.Properties.ValueMember = "Id";

            if (obra != null)
            {// si entra viene del Modulo de Ingresos
                if (source != string.Empty)
                {
                    luTipoPago.Properties.DataSource = controler.Model.TipoPago.ToList();
                    luTipoPago.Properties.DisplayMember = "Nombre";
                    luTipoPago.Properties.ValueMember = "Id";
                    luTipoPago.EditValue = TipoPagoEnum.NotaCredito.Id;
                }
                else
                {
                    if (this.tipoMovimientoId == TipoMovimientoEnum.Abonos.Id || this.tipoMovimientoId == TipoMovimientoEnum.Traspaso_Abono.Id)
                        luTipoPago.Properties.DataSource = controler.Model.TipoPago.Where(I => I.Nombre != "NOTA CREDITO").ToList();
                    else
                        luTipoPago.Properties.DataSource = controler.Model.TipoPago.ToList();
                    luTipoPago.Properties.DisplayMember = "Nombre";
                    luTipoPago.Properties.ValueMember = "Id";
                }

                luProveedor.Properties.DataSource = controler.Model.Cliente.Where(D => D.Activo == true).ToList();
                luProveedor.Properties.DisplayMember = "NombreFiscal";
                luProveedor.Properties.ValueMember = "Id";
                lblProveedor.Text = "Cliente";

                luObra.Properties.DataSource = controler.Model.Obra.OrderBy(O => O.Nombre).ToList();
                luObra.Properties.DisplayMember = "Nombre";
                luObra.Properties.ValueMember = "Id";
            }// aqui entra siempre en pagos
            else
            {


                luProveedor.Properties.DataSource = controler.Model.Proveedor.Where(D => D.Activo == true).ToList();
                luProveedor.Properties.DisplayMember = "NombreComercial";
                luProveedor.Properties.ValueMember = "Id";

                luTipoPago.Properties.DataSource = controler.Model.TipoPago.ToList();
                luTipoPago.Properties.DisplayMember = "Nombre";
                luTipoPago.Properties.ValueMember = "Id";
            }

            
        }

        private void llenaGridP()
        {
            dt2 = new DataTable();
            dt2.Columns.Add("Id", typeof(int));
            dt2.Columns.Add("NoFactura", typeof(string));
            dt2.Columns.Add("Fecha", typeof(DateTime));
            dt2.Columns.Add("Importe", typeof(double));
            dt2.Columns.Add("SaldoActual", typeof(double));
            dt2.Columns.Add("MontoPagar", typeof(double));            
            dt2.Columns.Add("SaldoFinal", typeof(double));
            dt2.Columns.Add("Observaciones", typeof(string));
            dt2.Columns.Add("ObraNombre", typeof(string));
            dt2.Columns.Add("Compartido", typeof(Boolean)).DefaultValue = false;
            dt2.Columns.Add("GastoAdm", typeof(Boolean)).DefaultValue = false;
            dt2.Columns.Add("esDevolucion", typeof(Boolean)).DefaultValue = false;
            dt2.Columns.Add("esPrestamo", typeof(Boolean)).DefaultValue = false;
            
            grid2.DataSource = dt2;
        }

        private int? obtenerFolio()
        {
            int? folio = (int?)null;
            
            if (luTipoPago.EditValue != null && luEmpresa.EditValue != null)
            {
                int tipoid = (int)luTipoPago.EditValue;
                int empresaid = (int)luEmpresa.EditValue;
                DateTime fecha = (DateTime)dtFechaPago.EditValue;
                //int tipoMov = this.pagos != null ? this.pagos.TipoMovimientoId.Value : this.tipoMovimientoId;

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
                int? id = (luTipoPago.EditValue != null ? (int)luTipoPago.EditValue : (int?)null);
                if (TipoPagoEnum.Periferica.Id == id) {
                    if (luBanco.Properties.Columns.Count > 0)
                        luBanco.Properties.Columns.Clear();
                    luBanco.Properties.DataSource = controler.Model.TarjetasCredito.ToList();
                    luBanco.Properties.DisplayMember = "Nombre_y_Tarjeta";
                    luBanco.Properties.ValueMember = "Id";

                    LookUpColumnInfoCollection coll = luBanco.Properties.Columns;
                    coll.Add(new LookUpColumnInfo("Id", 0));
                    coll.Add(new LookUpColumnInfo("Nombre_y_Tarjeta", 0));
                    luBanco.Properties.Columns[0].Visible = false;                    
                }
                else
                {
                    if (luBanco.Properties.Columns.Count > 0)
                        luBanco.Properties.Columns.Clear();
                    luBanco.Properties.DataSource = controler.Model.EmpresaBancos.Where(D => D.EmpresaId == em.Id).ToList();
                    luBanco.Properties.DisplayMember = "NombreBanco";
                    luBanco.Properties.ValueMember = "Id";

                    LookUpColumnInfoCollection coll = luBanco.Properties.Columns;
                    coll.Add(new LookUpColumnInfo("Id", 0));
                    coll.Add(new LookUpColumnInfo("NombreBanco", 0));
                    luBanco.Properties.Columns[0].Visible = false;    

                    
                }
                
            }
        }

        private bool isValid()
        {
            var areValid = true;
            var isValid = true;

            areValid &= controler.CheckEmptyText(txtFolio);

            areValid &= isValid = luProveedor.GetSelectedDataRow() != null;
            controler.SetError(luProveedor, isValid ? string.Empty : "Seleccione un Proveedor");

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
                if (gv2.RowCount == 0)
                {
                    new frmMessageBox(true) { Message = "Favor de ingresar facturas para pagar.", Title = "Error" }.ShowDialog();
                    areValid &= false;
                }
            }

            if (areValid)
            {
                for (int i = 0; i < gv2.RowCount; i++)
                {
                    double valor = Convert.ToDouble(gv2.GetRowCellValue(i, "MontoPagar"));
                    if (valor <= 0)
                    {
                        new frmMessageBox(true) { Message = "El monto a pagar de la factura: " + gv2.GetRowCellValue(i, "NoFactura").ToString() + " debe ser mayor a 0.00", Title = "Error" }.ShowDialog();
                        areValid &= false;
                        break;
                    }
                }
            }

            return areValid;
        }

        private int CrearFolio()
        {
            int valor = Convert.ToInt32(txtFolio.Text);

            Pagos p = controler.Model.Pagos.FirstOrDefault(P => P.Folio == valor && P.TipoMovimientoId == TipoMovimientoEnum.Pagos.Id);

            while (p != null)
            {
                valor += 1;
                p = controler.Model.Pagos.FirstOrDefault(P => P.Folio == valor && P.TipoMovimientoId == TipoMovimientoEnum.Pagos.Id);
            }

            return valor;
        }

        private void imprimir()
        {
            if (pagos.TipoPagoId == TipoPagoEnum.Cheque.Id) imprimirCheque();
        }

        private void imprimirCheque()
        {
            List<ReportParameter> paramReport = new List<ReportParameter>();

            paramReport.Add(new ReportParameter("Empleado", pagos.Proveedor.NombreFiscal));
            paramReport.Add(new ReportParameter("Banco", pagos.BancosNombre));
            paramReport.Add(new ReportParameter("Fecha", pagos.Fecha.ToShortDateString()));
            paramReport.Add(new ReportParameter("Empresa", pagos.EmpresaNombre));
            paramReport.Add(new ReportParameter("Importe", pagos.Total.ToString()));
            paramReport.Add(new ReportParameter("ImporteLetra", Funciones.Num2Text(pagos.Total.ToString()) + " M.N."));
            paramReport.Add(new ReportParameter("NoCheque", "CH.No." + pagos.Consecutivo.ToString()));
            paramReport.Add(new ReportParameter("NoCuenta", "CTA." + pagos.EmpresaBancosLoaded.NoCuenta));
            paramReport.Add(new ReportParameter("Concepto", ""));

            new frmPrint("Cheque", null, paramReport).ShowDialog();
        }
        #endregion

        #region Controles
        private void luEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            llenaEmpresaBancos();
            txtReferencia.Text = obtenerFolio().ToString();
        }

        private void dtFechaPago_EditValueChanged(object sender, EventArgs e)
        {
            txtReferencia.Text = obtenerFolio().ToString();
        }

        private void luTipoPago_EditValueChanged(object sender, EventArgs e)
        {
            int id = (int)luTipoPago.EditValue;
            txtReferencia.Text = "";

            llenaEmpresaBancos();
            if (TipoPagoEnum.Cheque.Id == id || TipoPagoEnum.Transferencia.Id == id)
            {
                if (obra != null)
                    txtReferencia.Visible = false;
                else
                {
                    txtReferencia.Visible = true;
                    txtReferencia.Text = obtenerFolio().ToString();
                }
                lblBancoTarjeta.Text = "Banco";
                label7.Text = "Consecutivo";
                label7.Visible = true;
                lblBancoTarjeta.Visible = true;
                luBanco.Visible = true;
                
            }
            else if (TipoPagoEnum.NotaCredito.Id == id)
            {
                txtReferencia.Visible = true;
                lblBancoTarjeta.Text = "Banco";
                label7.Text = "No. Referencia";
                label7.Visible = true;
                lblBancoTarjeta.Visible = false;
                luBanco.Visible = false;
            }
            else if (TipoPagoEnum.Periferica.Id == id)
            {
                if (obra != null)
                    txtReferencia.Visible = false;
                else
                {
                    txtReferencia.Visible = true;
                    txtReferencia.Text = obtenerFolio().ToString();
                }
                label7.Text = "Consecutivo";
                lblBancoTarjeta.Text = "Tarjeta Empleado";
                label7.Visible = true;
                lblBancoTarjeta.Visible = true;
                luBanco.Visible = true;
            }
            else 
            { 
                txtReferencia.Visible = label7.Visible = luBanco.Visible = lblBancoTarjeta.Visible = false; 
            }
        }

        private void luBanco_EditValueChanged(object sender, EventArgs e)
        {
            if(obra==null)                            
                txtReferencia.Text = obtenerFolio().ToString();
        }

        private void luProveedor_EditValueChanged(object sender, EventArgs e)
        {
            //llenaGridP();
        }

        private void gv2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //DataRowView row = gv2.g(e.RowHandle) as DataRowView;

            //if ()
            if (e.Column.FieldName == "MontoPagar")
            {
                double montoPagar = 0;
                double saldoactual = 0;

                if (!string.IsNullOrEmpty(gv2.GetRowCellValue(e.RowHandle, "MontoPagar").ToString()))
                {
                    montoPagar = Convert.ToDouble(gv2.GetRowCellValue(e.RowHandle, "MontoPagar"));
                }
                if (!string.IsNullOrEmpty(gv2.GetRowCellValue(e.RowHandle, "SaldoActual").ToString()))
                {
                    saldoactual = Convert.ToDouble(gv2.GetRowCellValue(e.RowHandle, "SaldoActual"));
                }
                //if (montoPagar > saldoactual && (luTipoPago.EditValue!=null?Convert.ToInt32(luTipoPago.EditValue):0)!=TipoPagoEnum.NotaCredito.Id)
                //{
                //    new frmMessageBox(true)
                //    {
                //        Message = "No puede abonar un monto mayor que el saldo actual.",
                //        Title = "Error"
                //    }.ShowDialog();
                //    gv2.SetRowCellValue(e.RowHandle, gv2.Columns["MontoPagar"], saldoactual);
                //}
                //else
                //{
                //    gv2.SetRowCellValue(e.RowHandle, gv2.Columns["SaldoFinal"], saldoactual - montoPagar);
                //}
                gv2.SetRowCellValue(e.RowHandle, gv2.Columns["SaldoFinal"], saldoactual - montoPagar);

            }
        }
        #endregion

        private bool validoTraspaso()
        {
            if (this.esTraspaso)
            {
                Cliente provedor = luProveedor.GetSelectedDataRow() as Cliente;
                Empresa emp = luEmpresa.GetSelectedDataRow() as Empresa;
                Obra ob = luObra.GetSelectedDataRow() as Obra;

                if (provedor.Id == this.idCliente && emp.Id == this.obra.Empresa.Id && ob.Id == this.obra.Id){
                    new frmMessageBox(true) { Message = "No se puede traspasar al Mismo Cliente/Obra/Empresa. ", Title = "Aviso" }.ShowDialog();
                    return false;
                }                    
                else
                    return true;
            }else
                return true;
        }

        #region Botones
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (luProveedor.EditValue != null && validoTraspaso())
            {
                Cliente cliente=null;
                Proveedor prov=null;

                if (obra != null)
                    cliente = luProveedor.GetSelectedDataRow() as Cliente;
                else
                {
                    if((int)rgOpcion.EditValue==1)
                        cliente = luProveedor.GetSelectedDataRow() as Cliente;
                    else
                        prov = luProveedor.GetSelectedDataRow() as Proveedor;
                }

                frmFacturasPendientes form = new frmFacturasPendientes();
                form.proveedor = prov;
                form.obra = esTraspaso ? (luObra.GetSelectedDataRow() as Obra) : this.obra; // Si es traspaso traigo lo que hay en el lookup en otro caso la obra por default
                form.idCliente = esTraspaso ? (luProveedor.GetSelectedDataRow() as Cliente).Id : this.idCliente;
                form.cliente = cliente;
                form.source = this.source;                
                for (int i = 0; i < gv2.RowCount; i++)
                {
                    int id = Convert.ToInt32(gv2.GetRowCellValue(i, "Id"));
                    form.pagadas.Add(controler.Model.Factura.FirstOrDefault(F => F.Id == id));
                }

                form.ShowDialog();

                if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    for (var j = 0; j < form.rowSelected.Count; j++)
                    {
                        gv2.AddNewRow();

                        int id = Convert.ToInt32(form.rowSelected[j]["Id"].ToString());
                        Factura fact = controler.Model.Factura.FirstOrDefault(F => F.Id == id);

                        var rowHandle = gv2.GetRowHandle(gv2.DataRowCount);
                        gv2.SetRowCellValue(rowHandle, gv2.Columns["Id"], form.rowSelected[j]["Id"]);
                        gv2.SetRowCellValue(rowHandle, gv2.Columns["NoFactura"], form.rowSelected[j]["NoFactura"]);
                        gv2.SetRowCellValue(rowHandle, gv2.Columns["Fecha"], form.rowSelected[j]["Fecha"]);
                        gv2.SetRowCellValue(rowHandle, gv2.Columns["SaldoActual"], form.rowSelected[j]["Saldo"]);
                        gv2.SetRowCellValue(rowHandle, gv2.Columns["Importe"], form.rowSelected[j]["Importe"]);
                        gv2.SetRowCellValue(rowHandle, gv2.Columns["MontoPagar"], esTraspaso ? this.saldoFavor : form.rowSelected[j]["Saldo"]); // Si es Traspaso pone por default el monto traspasado
                        gv2.SetRowCellValue(rowHandle, gv2.Columns["SaldoFinal"], esTraspaso ? ((Convert.ToDouble(form.rowSelected[j]["Saldo"])) - this.saldoFavor) : 0);
                        gv2.SetRowCellValue(rowHandle, gv2.Columns["Observaciones"], form.rowSelected[j]["Observaciones"]);
                        gv2.SetRowCellValue(rowHandle, gv2.Columns["ObraNombre"], form.rowSelected[j]["Obra"]);
                        gv2.SetRowCellValue(rowHandle, gv2.Columns["Compartido"], fact.Compartido == null || Convert.ToInt32(fact.Compartido) == 0 ? false : true);
                        gv2.SetRowCellValue(rowHandle, gv2.Columns["GastoAdm"], fact.GastoAdm == null || Convert.ToInt32(fact.GastoAdm) == 0 ? false : true);
                        gv2.SetRowCellValue(rowHandle, gv2.Columns["esDevolucion"], fact.esDevolucion == null || Convert.ToInt32(fact.esDevolucion) == 0 ? false : true);
                        gv2.SetRowCellValue(rowHandle, gv2.Columns["esPrestamo"], fact.esPrestamo == null || Convert.ToInt32(fact.esPrestamo) == 0 ? false : true);

                        gv2.UpdateCurrentRow();
                        gv2.RefreshData();
                    }
                }
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            frmMessageBox msg = new frmMessageBox(false) { Message = "¿Estas seguro de eliminar esta factura?", Title = "Eliminar Registro" };
            msg.ShowDialog();

            if (msg.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                DataRow row = gv2.GetFocusedDataRow() as DataRow;

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

                    gv2.DeleteRow(gv2.FocusedRowHandle);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var error = string.Empty;
            var isNew = false;

            gv2.CloseEditor();
            
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
                    pagos.Folio = Convert.ToInt32(string.IsNullOrEmpty(txtFolio.Text) ? "0" : txtFolio.Text);
                    pagos.Fecha = DateTime.Now;
                    pagos.FechaPago = (DateTime)dtFechaPago.EditValue;
                    if (obra != null)
                    {
                        if (source != null && source!=string.Empty)
                        {
                            pagos.Cliente = controler.GetObjectFromContext(luProveedor.GetSelectedDataRow() as Cliente);
                            pagos.Proveedor = null; // no puede tener valor en proveedor y cliente a la ves, debe ser uno u otro
                            pagos.TipoMovimientoId = pagos.TipoMovimientoId == null ? TipoMovimientoEnum.NotaCreditoFactura.Id : pagos.TipoMovimientoId.Value; 
                            pagos.enTransito = pagos.enTransito.HasValue ? pagos.enTransito.Value :  true;
                        }
                        else
                        {
                            pagos.Cliente = controler.GetObjectFromContext(luProveedor.GetSelectedDataRow() as Cliente);
                            pagos.Proveedor = null; // no puede tener valor en proveedor y cliente a la ves, debe ser uno u otro
                            pagos.TipoMovimientoId = pagos.TipoMovimientoId == null ? TipoMovimientoEnum.Ingresos.Id : pagos.TipoMovimientoId.Value ;
                            pagos.enTransito = pagos.enTransito.HasValue ? pagos.enTransito.Value : true;
                        }
                    }
                    else
                    {
                        if (rgOpcion.Visible) // si no es un pago, siempre va a guardar Proveedor
                        {
                            if ((Int32)rgOpcion.EditValue == 1)
                            {
                                pagos.Cliente = controler.GetObjectFromContext(luProveedor.GetSelectedDataRow() as Cliente);
                                pagos.Proveedor = null; // no puede tener valor en proveedor y cliente a la ves, debe ser uno u otro
                            }
                            else
                            {
                                pagos.Proveedor = controler.GetObjectFromContext(luProveedor.GetSelectedDataRow() as Proveedor);
                                pagos.Cliente = null; // no puede tener valor en proveedor y cliente a la ves, debe ser uno u otro
                            }
                        }
                        else
                        {
                            pagos.Proveedor = controler.GetObjectFromContext(luProveedor.GetSelectedDataRow() as Proveedor);
                            pagos.Cliente = null; // no puede tener valor en proveedor y cliente a la ves, debe ser uno u otro
                        }

                        pagos.TipoMovimientoId = pagos.TipoMovimientoId == null ? TipoMovimientoEnum.Pagos.Id : pagos.TipoMovimientoId.Value;
                    }
                    //pagos.Proveedor = controler.GetObjectFromContext(luProveedor.GetSelectedDataRow() as Proveedor);
                    pagos.TipoPago = controler.GetObjectFromContext(luTipoPago.GetSelectedDataRow() as TipoPago);
                    pagos.Empresa = controler.GetObjectFromContext(luEmpresa.GetSelectedDataRow() as Empresa);
                    pagos.FacturasPagadas = getFacturasPagadas();
                    //pagos.TipoMovimientoId = obra!=null ? TipoMovimientoEnum.Ingresos.Id : TipoMovimientoEnum.Pagos.Id;
                    pagos.calcGA = getGA();
                    pagos.calcGC= getGC();
                    if (pagos.TipoPago == TipoPagoEnum.Transferencia)
                    {
                        pagos.EmpresaBancos = controler.GetObjectFromContext(luBanco.GetSelectedDataRow() as EmpresaBancos);                        
                        if(obra==null)
                            pagos.Consecutivo = Convert.ToInt32(txtReferencia.Text);
                    }
                    else if (pagos.TipoPago == TipoPagoEnum.Cheque)
                    {
                        EmpresaBancos banco = luBanco.GetSelectedDataRow() as EmpresaBancos;
                        pagos.EmpresaBancos = controler.GetObjectFromContext(luBanco.GetSelectedDataRow() as EmpresaBancos);
                        if (obra == null)
                        {
                            pagos.Consecutivo = Convert.ToInt32(txtReferencia.Text);
                            banco.FolioActual = banco.FolioActual + 1;
                        }                        
                    }
                    else if (pagos.TipoPago == TipoPagoEnum.NotaCredito)
                    {
                        pagos.EmpresaBancos = null;
                        pagos.Referencia = txtReferencia.Text.Trim();
                    }
                    else if (pagos.TipoPago == TipoPagoEnum.Periferica)
                    {
                        pagos.TarjetasCredito = controler.GetObjectFromContext(luBanco.GetSelectedDataRow() as TarjetasCredito);
                        if (obra == null)
                            pagos.Consecutivo = Convert.ToInt32(txtReferencia.Text);                        
                    }
                    else
                    {
                        pagos.EmpresaBancos = null;
                        pagos.Referencia = "";
                    }

                    if (!pagos.NoEsNuevo) controler.Model.AddToPagos(pagos);

                    PagosFactura detalle = null;
                    TraspasoSaldos detalleTraspaso = null;
                    

                    for (int i = 0; i < gv2.RowCount; i++)
                    {
                        DataRow row = gv2.GetDataRow(i);

                        if (row != null)
                        {
                            var id = Convert.ToInt32(row["Id"]);
                            Factura factura = controler.Model.Factura.FirstOrDefault(D => D.Id == id);
                            
                            factura.Saldo = factura.Importe - controler.Model.getAbonosTotales(factura.Id,pagos.Id).Select(A => A.MontoPagar).DefaultIfEmpty(0).Sum().Value;                            
                            factura.Saldo = Math.Round(factura.Saldo, 2);
                            if (!isNew)
                            {
                                detalle = controler.Model.PagosFactura.FirstOrDefault(P => P.FacturaId == id && P.PagosId == pagos.Id);
                                detalleTraspaso = detalle.TraspasoSaldos;
                            }
                            else
                            {
                                detalle = null;
                                detalleTraspaso = null;
                            }

                            if (detalle == null)
                            {
                                detalle = new PagosFactura();
                                detalleTraspaso = new TraspasoSaldos();
                            }
                            //else factura.Saldo = factura.Saldo - detalle.MontoPagar; 

                            detalle.FacturaId = Convert.ToInt32(row["Id"]);
                            detalle.Pagos = pagos;
                            detalle.SaldoActual = Convert.ToDouble(row["SaldoActual"]);
                            detalle.MontoPagar = Convert.ToDouble(row["MontoPagar"]);
                            if (esTraspaso)
                            {
                                detalleTraspaso.ObraIdOrigen = this.obra.Id;
                                detalleTraspaso.ClienteIdOrigen = this.idCliente;
                                detalleTraspaso.EmpresaIdOrigen = this.obra.EmpresaId;
                                detalleTraspaso.ObraIdDestino = controler.GetObjectFromContext(luObra.GetSelectedDataRow() as Obra).Id;
                                detalleTraspaso.ClienteIdDestino = controler.GetObjectFromContext(luProveedor.GetSelectedDataRow() as Cliente).Id;
                                detalleTraspaso.EmpresaIdDestino = controler.GetObjectFromContext(luEmpresa.GetSelectedDataRow() as Empresa).Id;
                                detalleTraspaso.Monto = Convert.ToDouble(row["MontoPagar"]);
                                detalleTraspaso.Fecha = detalleTraspaso.Fecha.HasValue ? detalleTraspaso.Fecha : DateTime.Now;
                                detalle.TraspasoSaldos = detalleTraspaso;
                                if (!detalleTraspaso.NoEsNuevo) controler.Model.AddToTraspasoSaldos(detalleTraspaso);
                            }

                            if (!detalle.NoEsNuevo) controler.Model.AddToPagosFactura(detalle);

                            factura.Observaciones = row["Observaciones"].ToString().ToUpper();
                            if(factura.Saldo>0)
                                factura.Saldo = factura.Saldo - detalle.MontoPagar;                            
                            factura.Compartido = Convert.ToBoolean(row["Compartido"]);
                            factura.GastoAdm = Convert.ToBoolean(row["GastoAdm"]);
                            factura.esDevolucion = Convert.ToBoolean(row["esDevolucion"]);
                            factura.esPrestamo = Convert.ToBoolean(row["esPrestamo"]);
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
                    if (pagos.TipoPago == TipoPagoEnum.Cheque)
                    //imprimir();
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }else
                    this.DialogResult = System.Windows.Forms.DialogResult.No;
            }
        }

        private bool? getGA()
        {
            bool GA = false;
            for (int i = 0; i < gv2.RowCount; i++)
            {
                DataRow row = gv2.GetDataRow(i);

                if (row != null)
                {                    
                    GA = Convert.ToBoolean(row["GastoAdm"]);
                    if (GA)
                        return true;
                }
            }
            return false;
        }

        private bool? getGC()
        {
            bool GC = false;
            for (int i = 0; i < gv2.RowCount; i++)
            {
                DataRow row = gv2.GetDataRow(i);

                if (row != null)
                {
                    GC = Convert.ToBoolean(row["Compartido"]);
                    if (GC)
                        return true;
                }
            }
            return false;
        }

        private string getFacturasPagadas()
        {
            try
            {
                string facturas = string.Empty;
                string[] obras = new string[gv2.RowCount];
                if (gv2.RowCount > 0)
                {
                    facturas = this.tipoMovimientoId == TipoMovimientoEnum.Abonos.Id ? "ABONO FACT. No." : "PGO. FACT. No. ";
                    //Obtengo Obras
                    for (int i = 0; i < gv2.RowCount; i++)
                    {
                        DataRow row = gv2.GetDataRow(i);

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
                    for (int i = 0; i < gv2.RowCount; i++)
                    {
                        DataRow row = gv2.GetDataRow(i);

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

        private void btnAgregarContrarecibos_Click(object sender, EventArgs e)
        {
            bool nuevo = true;
            var form = new frmContrareciboNew(this.controler);
            form.Text = "Contra-recibo : " + (nuevo ? "Nuevo" : "Editar");
            form.contrarecibo = null;
            form.ShowDialog();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            controler.Model.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, controler.Model.Pagos.ToList());
            controler.Model.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, controler.Model.Factura.ToList());
        }

        private void tableLayoutPanel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void rgOpcion_EditValueChanged(object sender, EventArgs e)
        {

            if (obra != null)
            {
                luProveedor.Properties.DataSource = controler.Model.Cliente.Where(D => D.Activo == true).ToList();
                luProveedor.Properties.DisplayMember = "NombreFiscal";
                luProveedor.Properties.ValueMember = "Id";
                lblProveedor.Text = "Cliente";
                luProveedor.EditValue = this.pagos!= null ? pagos.ClienteId : null;
            }
            else
            {
                if ((int)rgOpcion.EditValue == 1)
                {
                    luProveedor.Properties.DataSource = controler.Model.Cliente.Where(D => D.Activo == true).ToList();
                    luProveedor.Properties.DisplayMember = "NombreFiscal";
                    luProveedor.Properties.ValueMember = "Id";
                    lblProveedor.Text = "Cliente";
                    luProveedor.EditValue = this.pagos != null ? pagos.ClienteId : null;
                }
                else
                {
                    luProveedor.Properties.DataSource = controler.Model.Proveedor.Where(D => D.Activo == true).ToList();
                    luProveedor.Properties.DisplayMember = "NombreComercial";
                    luProveedor.Properties.ValueMember = "Id";
                    lblProveedor.Text = "Proveedor";
                    luProveedor.EditValue = this.pagos != null ? pagos.ProveedorId : null;
                }
            }
        }
    }
}

