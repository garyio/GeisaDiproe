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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using System.Data.Common;
using System.Collections;

namespace SistemaGEISA
{
    public partial class frmAgregarGastosAd : DevExpress.XtraEditors.XtraForm
    {
        public Pagos pagos { get; set; }
        public Controler controler { get; set; }

        private DataTable dt;
        public int tipoMovimientoId;

        public bool tienePermisoAgregar , tienePermisoModificar , tienePermisoCancelar;        
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
            return isValid = gv.DataRowCount> 0 ? true : false;
        }
        public frmAgregarGastosAd(Controler _controler)
        {
            InitializeComponent();
            controler = _controler ?? new Controler();
        }
        public void limpiar()
        {
            txtFolio.Text = "";
            luProveedor.EditValue = null;
            luEmpresa.EditValue = null;
            luTipoPago.EditValue = null;
            dtFecha.EditValue = DateTime.Today;

            if (luBancos.Visible == true)
                luBancos.EditValue = null;
            if (txtReferencia.Visible == true)
                txtReferencia.Text = "";

        }

        private void frmAgregarGastosAd_Load(object sender, EventArgs e)
        {
            btnGuardar.Enabled =btnAgregar.Enabled= btnEliminar.Enabled = tienePermisoAgregar || tienePermisoModificar;
            llenaGrid();
            llenaCombos();

            if (pagos != null)
            {
                txtFolio.Text = pagos.Folio.ToString();
                dtFecha.EditValue = Convert.ToDateTime(pagos.FechaPago);
                luProveedor.EditValue = pagos.ProveedorId;
                luEmpresa.EditValue = pagos.EmpresaId;
                luTipoPago.EditValue = pagos.TipoPagoId;

                if (TipoPagoEnum.Cheque.Id == pagos.TipoPagoId || TipoPagoEnum.Transferencia.Id == pagos.TipoPagoId)
                {
                    luBancos.EditValue = pagos.EmpresaBancosId;
                    txtReferencia.Text = pagos.Consecutivo.ToString();
                }
                else if (TipoPagoEnum.NotaCredito.Id == pagos.TipoPagoId)
                    txtReferencia.Text = pagos.Referencia;

                if (pagos.FechaCancelacion.HasValue)
                {
                    btnCancelar.Visible = false;
                    lbCancelado.Visible = true;
                    btnGuardar.Enabled = btnEliminar.Enabled = false;
                }

                foreach (PagosFactura serv in controler.Model.PagosFactura.Where(D => D.PagosId == pagos.Id).ToList())
                {
                    gv.AddNewRow();
                    int rowHandle = gv.GetRowHandle(gv.DataRowCount);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Id"], serv.Factura.Id);
                    gv.SetRowCellValue(rowHandle, gv.Columns["NoFactura"], serv.NoFactura);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Fecha"], serv.Fecha);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Importe"], serv.Importe);
                    gv.SetRowCellValue(rowHandle, gv.Columns["ConceptoId"], serv.Factura != null ? serv.Factura.ConceptosId : (int?)null);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Compartido"], serv.Factura != null ? (serv.Factura.Compartido==null || Convert.ToInt32(serv.Factura.Compartido)==0 ? false: true) : false);
                    gv.SetRowCellValue(rowHandle, gv.Columns["ProveedorId"], serv.Proveedor != null ? serv.Proveedor.Id : (int?)null);
                    gv.SetRowCellValue(rowHandle, gv.Columns["ObraId"], serv.Factura.Obra != null ? serv.Factura.ObraId : (int?)null);
                    gv.SetRowCellValue(rowHandle, gv.Columns["Observaciones"], serv.Observaciones);
                    gv.UpdateCurrentRow();
                    gv.RefreshData();
                }

            }
            else
            {
                //int? folio = controler.Model.ReposicionGastos.Select(P => P.Folio).DefaultIfEmpty(0).Max();
                int? folio = controler.Model.Pagos.Where(P => P.TipoMovimientoId == TipoMovimientoEnum.GastosAdministrativos.Id).Select(P => P.Folio).DefaultIfEmpty(0).Max();
                txtFolio.Text = (folio + 1).ToString();
                dtFecha.EditValue = DateTime.Now;
                //llenaGrid();
            }


        }

        private void llenaCombos()
        {
            luEmpresa.Properties.DataSource = controler.Model.Empresa.Where(D => D.Activo == true).ToList();
            luEmpresa.Properties.DisplayMember = "NombreComercial";
            luEmpresa.Properties.ValueMember = "Id";

            luProveedor.Properties.DataSource = controler.Model.Proveedor.OrderBy(P => P.NombreFiscal).ToList();
            luProveedor.Properties.DisplayMember = "NombreFiscal";
            luProveedor.Properties.ValueMember = "Id";

            luTipoPago.Properties.DataSource = controler.Model.TipoPago.ToList();
            luTipoPago.Properties.DisplayMember = "Nombre";
            luTipoPago.Properties.ValueMember = "Id";

            luObra.DataSource = controler.Model.Obra.ToList();
            luObra.DisplayMember = "Nombre";
            luObra.ValueMember = "Id";

            luProveedorId.DataSource = controler.Model.Proveedor.OrderBy(P => P.NombreFiscal).ToList();
            luProveedorId.DisplayMember = "NombreFiscal";
            luProveedorId.ValueMember = "Id";

            luConceptos.DataSource = controler.Model.Conceptos.ToList();
            luConceptos.DisplayMember = "Nombre";
            luConceptos.ValueMember = "Id";
            
        }

        private void llenaGrid()
        {
            dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("NoFactura", typeof(string));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Importe", typeof(double));
            dt.Columns.Add("ConceptoId", typeof(int));
            dt.Columns.Add("Compartido", typeof(Boolean)).DefaultValue=false;
            dt.Columns.Add("Observaciones", typeof(string));
            dt.Columns.Add("ProveedorId", typeof(int));
            dt.Columns.Add("ObraId", typeof(int));
            grid.DataSource = dt;
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
                    if (luBancos.EditValue != null)
                    {
                        int bancoid = (int)luBancos.EditValue;
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
                luBancos.Properties.DataSource = controler.Model.EmpresaBancos.Where(D => D.EmpresaId == em.Id).ToList();
                luBancos.Properties.DisplayMember = "NombreBanco";
                luBancos.Properties.ValueMember = "Id";
            }
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
                luBancos.Visible = true;
                txtReferencia.Text = obtenerFolio().ToString();
            }
            else if (TipoPagoEnum.NotaCredito.Id == id)
            {
                txtReferencia.Visible = true;
                lblReferencia.Text = "No. Referencia";
                lblReferencia.Visible = true;
                lblBanco.Visible = false;
                luBancos.Visible = false;
            }
            else
            {
                txtReferencia.Visible = lblReferencia.Visible = luBancos.Visible = lblBanco.Visible = false;
            }
        }

        private bool isValid()
        {
            var areValid = true;
            var isValid = true;

            areValid &= controler.CheckEmptyText(txtFolio);

            areValid &= isValid = luProveedor.GetSelectedDataRow() != null;
            controler.SetError(luProveedor, isValid ? string.Empty : "Seleccione un Empleado");

            areValid &= isValid = luEmpresa.GetSelectedDataRow() != null;
            controler.SetError(luEmpresa, isValid ? string.Empty : "Seleccione una Empresa");

            areValid &= isValid = luTipoPago.GetSelectedDataRow() != null;
            controler.SetError(luTipoPago, isValid ? string.Empty : "Seleccione un Tipo de pago");

            if (areValid)
            {
                int id = (int)luTipoPago.EditValue;
                if (TipoPagoEnum.Cheque.Id == id || TipoPagoEnum.Transferencia.Id == id)
                {
                    areValid &= isValid = luBancos.GetSelectedDataRow() != null;
                    controler.SetError(luBancos, isValid ? string.Empty : "Seleccione un Banco");
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
                            new frmMessageBox(true) { Message = "El Importe a pagar de la factura: " + gv.GetRowCellValue(i, "NoFactura").ToString() + " debe ser mayor o igual a 0.00", Title = "Error" }.ShowDialog();
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

            Pagos p = controler.Model.Pagos.FirstOrDefault(P => P.Folio == valor && P.TipoMovimientoId == TipoMovimientoEnum.GastosAdministrativos.Id);

            while (p != null)
            {
                valor += 1;
                p = controler.Model.Pagos.FirstOrDefault(P => P.Folio == valor && P.TipoMovimientoId == TipoMovimientoEnum.GastosAdministrativos.Id);
            }

            return valor;
        }

        private void luProveedor_EditValueChanged(object sender, EventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var error = string.Empty;
            var isNew = false;

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
                    pagos.Proveedor= controler.GetObjectFromContext(luProveedor.GetSelectedDataRow() as Proveedor);
                    pagos.TipoPago = controler.GetObjectFromContext(luTipoPago.GetSelectedDataRow() as TipoPago);
                    pagos.Empresa = controler.GetObjectFromContext(luEmpresa.GetSelectedDataRow() as Empresa);
                    pagos.TipoMovimientoId = TipoMovimientoEnum.GastosAdministrativos.Id;
                    pagos.FacturasPagadas = getFacturasPagadas();
                    if (pagos.TipoPago == TipoPagoEnum.Transferencia)
                    {
                        pagos.EmpresaBancos = controler.GetObjectFromContext(luBancos.GetSelectedDataRow() as EmpresaBancos);
                        pagos.Consecutivo = Convert.ToInt32(txtReferencia.Text);
                    }
                    else if (pagos.TipoPago == TipoPagoEnum.Cheque)
                    {
                        EmpresaBancos banco = luBancos.GetSelectedDataRow() as EmpresaBancos;
                        pagos.EmpresaBancos = controler.GetObjectFromContext(luBancos.GetSelectedDataRow() as EmpresaBancos);
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
                            {
                                factura = controler.Model.Factura.FirstOrDefault(D => D.Id == id);
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
                            factura.ConceptosId = string.IsNullOrEmpty(row["ConceptoId"].ToString()) ? (int?)null : Convert.ToInt32(row["ConceptoId"].ToString()); 
                            factura.Observaciones = row["Observaciones"].ToString().ToUpper();
                            factura.ProveedorId = string.IsNullOrEmpty(row["ProveedorId"].ToString()) ? (int?)null : Convert.ToInt32(row["ProveedorId"].ToString());
                            factura.ObraId = string.IsNullOrEmpty(row["ObraId"].ToString()) ? (int?)null : Convert.ToInt32(row["ObraId"].ToString());
                            factura.Compartido = Convert.ToBoolean(row["Compartido"]);

                            if (!factura.NoEsNuevo) controler.Model.AddToFactura(factura);

                            if (detalle == null) detalle = new PagosFactura();
                            //else factura.Saldo = factura.Saldo + detalle.MontoPagar;
                            detalle.Factura = factura;//isNew ? factura : controler.Model.Factura.Where(f => f.Id == id).SingleOrDefault();
                            detalle.Pagos = pagos;
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
                            var id = Convert.ToInt32(row["ObraId"]);
                            Obra obra = controler.Model.Obra.FirstOrDefault(D => D.Id == id);
                            if (!obras.Contains(obra.Nombre))
                            {
                                obras[i] = obra.Nombre;
                            }
                        }

                    }

                    Hashtable obras_Facturas = new Hashtable();
                    for (int i = 0; i < gv.RowCount; i++)
                    {
                        DataRow row = gv.GetDataRow(i);

                        if (row != null)
                        {
                            var id = Convert.ToInt32(row["ObraId"]);
                            Obra obra = controler.Model.Obra.FirstOrDefault(D => D.Id == id);
                            for (int x = 0; x < obras.Length; x++)
                            {
                                if (obras[x] == obra.Nombre)
                                {
                                    obras_Facturas[x] = obras_Facturas[x] + (obras_Facturas[x] == null ? " " : ",") + row["NoFactura"].ToString();
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

        private void luBancos_EditValueChanged(object sender, EventArgs e)
        {
            txtReferencia.Text = obtenerFolio().ToString();
        }

        private void gv_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }

        private void gv_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            GridColumn colFactura = view.Columns["NoFactura"];
            GridColumn colFecha = view.Columns["Fecha"];
            GridColumn colImporte = view.Columns["Importe"];

            //if (string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, colFactura).ToString()))
            //{ e.Valid = false; view.SetColumnError(colFactura, "Campo Factura no es Valido"); return; }

            DateTime t_Fecha = string.IsNullOrEmpty(view.GetRowCellValue(e.RowHandle, colFecha).ToString()) ? DateTime.MinValue : Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, Fecha));
            if (t_Fecha == null || string.IsNullOrEmpty(t_Fecha.ToString()) || t_Fecha == DateTime.MinValue)
            { e.Valid = false; view.SetColumnError(colFecha, "Campo Fecha no es Valido"); return; }

            double importe;
            double.TryParse(view.GetRowCellValue(e.RowHandle, colImporte).ToString(), out importe);
            if (importe == 0)
            { e.Valid = false; view.SetColumnError(colImporte, "Campo Importe no es Valido"); return; }
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
                    if (pagos != null && (gv.GetRowCellValue(gv.FocusedRowHandle, "Id") != null && string.IsNullOrEmpty(gv.GetRowCellValue(gv.FocusedRowHandle, "Id").ToString()) == false))
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (luProveedor.EditValue != null)
            {
                Proveedor prov = luProveedor.GetSelectedDataRow() as Proveedor;
                frmFacturasPendientes form = new frmFacturasPendientes();
                form.proveedor = prov;
                form.isGastoAdm = true;

                for (int i = 0; i < gv.RowCount; i++)
                {
                     DataRow row = gv.GetDataRow(i);
                     if (row != null)
                     {
                         if (string.IsNullOrEmpty(gv.GetRowCellValue(i, "Id").ToString()) == false)
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

                        Factura factura;
                        int id= Convert.ToInt32( form.rowSelected[j]["Id"]);
                        try
                        {
                             factura = controler.Model.Factura.FirstOrDefault(f => f.Id == id);
                        }
                        catch (Exception ex)
                        {
                            factura = null;
                        }

                        var rowHandle = gv.GetRowHandle(gv.DataRowCount);
                        gv.SetRowCellValue(rowHandle, gv.Columns["Id"], form.rowSelected[j]["Id"]);
                        gv.SetRowCellValue(rowHandle, gv.Columns["NoFactura"], form.rowSelected[j]["NoFactura"]);
                        gv.SetRowCellValue(rowHandle, gv.Columns["Fecha"], form.rowSelected[j]["Fecha"]);
                        gv.SetRowCellValue(rowHandle, gv.Columns["Importe"], form.rowSelected[j]["Importe"]);
                        gv.SetRowCellValue(rowHandle, gv.Columns["ConceptoId"], factura != null ? factura.ConceptosId : (int?)null);
                        gv.SetRowCellValue(rowHandle, gv.Columns["Compartido"], factura.Compartido == null || Convert.ToInt32(factura.Compartido) == 0 ? false : true);
                        gv.SetRowCellValue(rowHandle, gv.Columns["ProveedorId"], factura != null ? factura.ProveedorId : (int?)null);
                        gv.SetRowCellValue(rowHandle, gv.Columns["ObraId"], factura != null ? factura.ObraId : (int?)null);
                        gv.SetRowCellValue(rowHandle, gv.Columns["Observaciones"], form.rowSelected[j]["Observaciones"]);

                        gv.UpdateCurrentRow();
                        gv.RefreshData();
                    }
                }
            }
        }
    }
}