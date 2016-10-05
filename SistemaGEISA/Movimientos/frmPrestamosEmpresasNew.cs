using DevExpress.XtraEditors.Controls;
using GeisaBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGEISA
{
    public partial class frmPrestamosEmpresasNew : DevExpress.XtraEditors.XtraForm
    {
        public string source="";
        public Controler controler { get; set; }
        public Pagos pagos { get; set; }
        public int tipoMovimientoId;
        public CajaChicaPrestamo CajaPrestamo { get; set; }

        private PrestamosDetalle Item_Cargo { get; set; }
        private PrestamosDetalle Item_Abono { get; set; }

        DataTable dt;
        public bool tienePermisoAgregar, tienePermisoModificar, tienePermisoCancelar;
        public frmPrestamosEmpresasNew(Controler _controler)
        {
            InitializeComponent();
            controler = _controler ?? new Controler();
        }
        private int CrearFolio()
        {
            int valor = Convert.ToInt32(txtFolio.Text);

            Pagos p = controler.Model.Pagos.FirstOrDefault(P => P.Folio == valor && P.TipoMovimientoId == TipoMovimientoEnum.Prestamos.Id);

            while (p != null)
            {
                valor += 1;
                p = controler.Model.Pagos.FirstOrDefault(P => P.Folio == valor && P.TipoMovimientoId == TipoMovimientoEnum.Prestamos.Id);
            }

            return valor;
        }

        private void frmPrestamosEmpresasNew_Load(object sender, EventArgs e)
        {
            //btnGuardar.Enabled =  tienePermisoAgregar || tienePermisoModificar;
            llenaCombos();

            if (pagos != null)
            {
                txtFolio.Text = pagos.Folio.ToString();
                dtFechaPago.EditValue = pagos.FechaPago;
                if (pagos.TipoMovimientoId == TipoMovimientoEnum.Prestamos.Id)
                {
                    luEmpresa.EditValue = pagos.EmpresaId;
                    luBeneficiario.EditValue = pagos.Beneficiario;
                }
                else
                {
                    luEmpresa.EditValue = pagos.Beneficiario;
                    luBeneficiario.EditValue = pagos.EmpresaId;
                }

                luTipoPago.EditValue = pagos.TipoPagoId;
                txtObservaciones.Text = pagos.Observaciones;
                if (pagos.TipoObjeto == TipoCatalogo.EMPLEADO)                
                    rbEmpleado.Checked = true;                                    
                else                
                    rbEmpresa.Checked = true;                

                txtImporte.Text = string.Format("{0:N2}", pagos.MontoPagar);

                if (TipoPagoEnum.Cheque.Id == pagos.TipoPagoId || TipoPagoEnum.Transferencia.Id == pagos.TipoPagoId)
                {
                    luBanco.EditValue = pagos.EmpresaBancosId;
                    txtReferencia.Text = pagos.Consecutivo.ToString();
                }
                else if (TipoPagoEnum.NotaCredito.Id == pagos.TipoPagoId)
                    txtReferencia.Text = pagos.Referencia;

                if (pagos.FechaCancelacion.HasValue)
                {
                    btnGuardar.Enabled =  false;
                }
            }
            else
            {
                int? folio = source == "PRESTAMO" ? controler.Model.Pagos.Where(P => P.TipoMovimientoId == TipoMovimientoEnum.Prestamos.Id).Select(P => P.Folio).DefaultIfEmpty(0).Max() : controler.Model.Pagos.Where(P => P.TipoMovimientoId == TipoMovimientoEnum.Abonos.Id).Select(P => P.Folio).DefaultIfEmpty(0).Max();
                txtFolio.Text = (folio + 1).ToString();
                dtFechaPago.EditValue = DateTime.Now;
                if (pagos != null)
                {
                    if (pagos.TipoObjeto == TipoCatalogo.EMPLEADO)                    
                        rbEmpleado.Checked = true;                                     
                    else                    
                        rbEmpresa.Checked = true;                                                            
                    //luBeneficiario.EditValue = pagos.Beneficiario;
                    luBeneficiario.Properties.ReadOnly = true;
                    rbEmpleado.Enabled = false;
                    rbEmpresa.Enabled = false;
                }
                luBeneficiario.EditValue = CajaPrestamo.BeneficiarioId;
                luEmpresa.EditValue = CajaPrestamo.EmpresaId;
            }
        }

        private void llenaCombos()
        {
            if (this.source == "ABONO")
            {
                TableLayoutPanelCellPosition pointTipo = new TableLayoutPanelCellPosition(0,3);
                TableLayoutPanelCellPosition pointGroupBox = new TableLayoutPanelCellPosition(1,3);
                TableLayoutPanelCellPosition pointBeneficiariolbl = new TableLayoutPanelCellPosition(0, 4);
                TableLayoutPanelCellPosition pointBeneficiariotxt = new TableLayoutPanelCellPosition(1, 4);
                TableLayoutPanelCellPosition pointEmpresalbl = new TableLayoutPanelCellPosition(3, 4);
                TableLayoutPanelCellPosition pointEmpresatxt = new TableLayoutPanelCellPosition(4, 4);

                this.Text = "ABONOS";
                lblDe.Text = "Abono De:";
                lblA.Text = "A:";
                lblBeneficiario.Text = "Prestamista";
                tableLayoutPanel1.SetCellPosition(label7, pointTipo);
                tableLayoutPanel1.SetCellPosition(groupBox1, pointGroupBox);

                //tableLayoutPanel1.SetCellPosition(lblBeneficiario, pointBeneficiariolbl);
                tableLayoutPanel1.SetCellPosition(luBeneficiario, pointBeneficiariotxt);
                //tableLayoutPanel1.SetCellPosition(lblEmpresa, pointEmpresalbl);
                tableLayoutPanel1.SetCellPosition(luEmpresa, pointEmpresatxt);

            }
            else
            {
                this.Text = "PRESTAMOS";                
            }
            luEmpresa.Properties.DataSource = controler.Model.Empresa.Where(D => D.Activo == true).ToList();
            luEmpresa.Properties.DisplayMember = "NombreFiscal";
            luEmpresa.Properties.ValueMember = "Id";

            luTipoPago.Properties.DataSource = controler.Model.TipoPago.ToList();
            luTipoPago.Properties.DisplayMember = "Nombre";
            luTipoPago.Properties.ValueMember = "Id";

            if (luBeneficiario.Properties.Columns.Count > 0)
                luBeneficiario.Properties.Columns.Clear();
            luBeneficiario.Properties.DataSource = controler.Model.Empresa.Where(D => D.Activo == true).ToList();
            luBeneficiario.Properties.DisplayMember = "NombreFiscal";
            luBeneficiario.Properties.ValueMember = "Id";

            LookUpColumnInfoCollection coll = luBeneficiario.Properties.Columns;
            coll.Add(new LookUpColumnInfo("Id", 0));
            coll.Add(new LookUpColumnInfo("NombreFiscal", 0));
            luBeneficiario.Properties.Columns[0].Visible = false;

            dtFechaPago.EditValue = DateTime.Today;
        }

        private void llenaEmpresaBancos()
        {
            Empresa em;
            if(source=="PRESTAMO")
                em = controler.GetObjectFromContext(luEmpresa.GetSelectedDataRow() as Empresa);
            else
                em = controler.GetObjectFromContext(luBeneficiario.GetSelectedDataRow() as Empresa);

            if (em != null)
            {
                luBanco.Properties.DataSource = controler.Model.EmpresaBancos.Where(D => D.EmpresaId == em.Id).ToList();
                luBanco.Properties.DisplayMember = "NombreBanco";
                luBanco.Properties.ValueMember = "Id";
            }
        }

        private void luEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            if (source == "PRESTAMO" || pagos==null){
                llenaEmpresaBancos();
                txtReferencia.Text = obtenerFolio().ToString();
            }          
                
        }

        private int? obtenerFolio()
        {
            int? folio = (int?)null;

            if (luTipoPago.EditValue != null && luEmpresa.EditValue != null && luBeneficiario.EditValue!=null)
            {
                int tipoid = (int)luTipoPago.EditValue;
                int empresaid = source=="PRESTAMO" ? (int)luEmpresa.EditValue: (int)luBeneficiario.EditValue;
                DateTime fecha = (DateTime)dtFechaPago.EditValue;
                int tipoMov = this.pagos != null ? this.pagos.TipoMovimientoId.Value : this.tipoMovimientoId;

                if (TipoPagoEnum.Transferencia.Id == tipoid)
                {
                    //if (source == "PRESTAMO")
                    //{
                        folio = controler.Model.Pagos.Where(P => P.EmpresaId == empresaid &&
                                                                 P.TipoPagoId == tipoid &&
                                                                 P.FechaPago.Value.Year == fecha.Year &&
                                                                 P.FechaPago.Value.Month == fecha.Month /*&&
                                                                 P.TipoMovimientoId == tipoMov */).Select(P => P.Consecutivo).DefaultIfEmpty(0).Max();
                    //}
                    //else
                    //{
                    //    folio = controler.Model.Pagos.Where(P => P.EmpleadoId == empresaid &&
                    //                                             P.TipoPagoId == tipoid &&
                    //                                             P.FechaPago.Value.Year == fecha.Year &&
                    //                                             P.FechaPago.Value.Month == fecha.Month).Select(P => P.Consecutivo).DefaultIfEmpty(0).Max();
                    //}

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

        private bool isValid()
        {
            var areValid = true;
            var isValid = true;

            areValid &= controler.CheckEmptyText(txtFolio);

            areValid &= isValid = luEmpresa.GetSelectedDataRow() != null;
            controler.SetError(luEmpresa, isValid ? string.Empty : "Seleccione una Empresa");

            areValid &= isValid = luTipoPago.GetSelectedDataRow() != null;
            controler.SetError(luTipoPago, isValid ? string.Empty : "Seleccione un Tipo de pago");

            areValid &= isValid = luBeneficiario.GetSelectedDataRow() != null;
            controler.SetError(luBeneficiario, isValid ? string.Empty : "Seleccione un Beneficiario");

            areValid &= isValid = string.IsNullOrEmpty(txtImporte.Text) ? false : true;
            controler.SetError(txtImporte, isValid ? string.Empty : "Ingrese un Importe Valido.");

            if (areValid)
            {
                int id = (int)luTipoPago.EditValue;
                if (TipoPagoEnum.Cheque.Id == id || TipoPagoEnum.Transferencia.Id == id)
                {
                    areValid &= isValid = luBanco.GetSelectedDataRow() != null;
                    controler.SetError(luBanco, isValid ? string.Empty : "Seleccione un Banco");
                }
            }

            return areValid;
        }

        private void luTipoPago_EditValueChanged(object sender, EventArgs e)
        {
            int id = (int)luTipoPago.EditValue;
            txtReferencia.Text = "";

            if (TipoPagoEnum.Cheque.Id == id || TipoPagoEnum.Transferencia.Id == id)
            {
                txtReferencia.Visible = true;
                lbReferencia.Text = "Consecutivo";
                lbReferencia.Visible = true;
                lbBanco.Visible = true;
                luBanco.Visible = true;
                txtReferencia.Text = obtenerFolio().ToString();
            }
            else if (TipoPagoEnum.NotaCredito.Id == id)
            {
                txtReferencia.Visible = true;
                lbReferencia.Text = "No. Referencia";
                lbReferencia.Visible = true;
                lbBanco.Visible = false;
                luBanco.Visible = false;
            }
            else
            {
                txtReferencia.Visible = lbReferencia.Visible = luBanco.Visible = lbBanco.Visible = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEmpresa.Checked == true)
            {
                if (luBeneficiario.Properties.Columns.Count > 0)
                    luBeneficiario.Properties.Columns.Clear();
                luBeneficiario.Properties.DataSource = controler.Model.Empresa.Where(D => D.Activo == true).ToList();
                luBeneficiario.Properties.DisplayMember = "NombreFiscal";
                luBeneficiario.Properties.ValueMember = "Id";

                LookUpColumnInfoCollection coll = luBeneficiario.Properties.Columns;
                coll.Add(new LookUpColumnInfo("Id", 0));
                coll.Add(new LookUpColumnInfo("NombreFiscal", 0));
                luBeneficiario.Properties.Columns[0].Visible = false;
                
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rbEmpleado.Checked == true)
            {
                if(luBeneficiario.Properties.Columns.Count>0)
                    luBeneficiario.Properties.Columns.Clear();
                luBeneficiario.Properties.DataSource = controler.Model.Empleado.Where(D => D.Activo == true).ToList();
                luBeneficiario.Properties.DisplayMember = "NombreCompleto";
                luBeneficiario.Properties.ValueMember = "Id";

                LookUpColumnInfoCollection coll = luBeneficiario.Properties.Columns;
                coll.Add(new LookUpColumnInfo("Id", 0));
                coll.Add(new LookUpColumnInfo("NombreCompleto", 0));
                luBeneficiario.Properties.Columns[0].Visible = false;
            }

        }

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
                    if (source == "PRESTAMO")
                    {
                        pagos.TipoMovimientoId = TipoMovimientoEnum.Prestamos.Id;
                        pagos.Empresa = controler.GetObjectFromContext(luEmpresa.GetSelectedDataRow() as Empresa);   
                    }
                    else
                    {
                        pagos.TipoMovimientoId = TipoMovimientoEnum.Abonos.Id;
                        pagos.Empresa = controler.GetObjectFromContext(luBeneficiario.GetSelectedDataRow() as Empresa); 
                    }

                    pagos.Fecha = DateTime.Now;
                    pagos.FechaPago = (DateTime)dtFechaPago.EditValue;
                    pagos.TipoPago = controler.GetObjectFromContext(luTipoPago.GetSelectedDataRow() as TipoPago);                    
                    pagos.MontoPagar = Convert.ToDouble(txtImporte.Text);
                    pagos.Observaciones = txtObservaciones.Text.Trim().ToUpper();
                    
                    if (rbEmpresa.Checked)
                    {
                        if (source == "PRESTAMO")                        
                            pagos.Beneficiario = (int)luBeneficiario.EditValue;                        
                        else
                            pagos.Beneficiario = (int)luEmpresa.EditValue;                                                                             
                        pagos.TipoObjeto = TipoCatalogo.EMPRESA;
                    }
                    else{
                        if (source == "PRESTAMO")
                            pagos.Beneficiario = (int)luBeneficiario.EditValue;
                        else
                            pagos.Beneficiario = (int)luEmpresa.EditValue; 
                        pagos.TipoObjeto = TipoCatalogo.EMPLEADO;
                        }

                    if (pagos.TipoPago == TipoPagoEnum.Transferencia)
                    {
                        pagos.EmpresaBancos = controler.GetObjectFromContext(luBanco.GetSelectedDataRow() as EmpresaBancos);
                        pagos.Consecutivo = string.IsNullOrEmpty(txtReferencia.Text) ? 0 : Convert.ToInt32(txtReferencia.Text);
                    }
                    else if (pagos.TipoPago == TipoPagoEnum.Cheque)
                    {
                        EmpresaBancos banco = luBanco.GetSelectedDataRow() as EmpresaBancos;
                        pagos.EmpresaBancos = controler.GetObjectFromContext(luBanco.GetSelectedDataRow() as EmpresaBancos);
                        pagos.Consecutivo = string.IsNullOrEmpty(txtReferencia.Text) ? 0 : Convert.ToInt32(txtReferencia.Text);
                        banco.FolioActual = banco.FolioActual + 1;
                    }
                    else if (pagos.TipoPago == TipoPagoEnum.NotaCredito)
                    {
                        pagos.EmpresaBancos = null;
                        pagos.Referencia = string.IsNullOrEmpty(txtReferencia.Text) ? string.Empty : txtReferencia.Text.Trim();
                    }
                    else
                    {
                        pagos.EmpresaBancos = null;
                        pagos.Referencia = "";
                    }
                    pagos.FacturasPagadas = pagos.Observaciones;
                    pagos.CajaChicaPrestamoId = this.CajaPrestamo.Id;

                    if (!pagos.NoEsNuevo) controler.Model.AddToPagos(pagos);

                    controler.Model.SaveChanges();
                    //transaccion.Commit();

                    //Agrego Detalles 
                    if (pagos.TipoPago == TipoPagoEnum.Transferencia || pagos.TipoPago == TipoPagoEnum.Cheque)
                    {

                        if (pagos != null)
                        {
                            Item_Abono = controler.Model.PrestamosDetalle.FirstOrDefault(I => I.Tipo == TipoMovimientoEnum.Abonos.Id && I.PagoId == pagos.Id) != null ? controler.Model.PrestamosDetalle.FirstOrDefault(I => I.Tipo == TipoMovimientoEnum.Abonos.Id && I.PagoId == pagos.Id) : new PrestamosDetalle();
                            Item_Cargo = controler.Model.PrestamosDetalle.FirstOrDefault(I => I.Tipo == TipoMovimientoEnum.Prestamos.Id && I.PagoId == pagos.Id) != null ? controler.Model.PrestamosDetalle.FirstOrDefault(I => I.Tipo == TipoMovimientoEnum.Prestamos.Id && I.PagoId == pagos.Id) : new PrestamosDetalle();
                        }
                        else
                        {
                            Item_Abono = new PrestamosDetalle();
                            Item_Cargo = new PrestamosDetalle();
                        }

                        Item_Abono.PagoId = Item_Cargo.PagoId = pagos.Id;
                        Item_Cargo.EmpresaId = pagos.EmpresaId;
                        Item_Cargo.BancoId = controler.Model.EmpresaBancos.FirstOrDefault(E => E.EmpresaId == pagos.EmpresaId).Id;
                        Item_Cargo.Importe = pagos.MontoPagar;
                        Item_Cargo.Tipo = TipoMovimientoEnum.Prestamos.Id;
                        if (!Item_Cargo.NoEsNuevo) controler.Model.AddToPrestamosDetalle(Item_Cargo);

                        Item_Abono.EmpresaId = pagos.Beneficiario;
                        Item_Abono.BancoId = controler.Model.EmpresaBancos.FirstOrDefault(E => E.EmpresaId == pagos.Beneficiario).Id;
                        Item_Abono.Importe = pagos.MontoPagar;
                        Item_Abono.Tipo = TipoMovimientoEnum.Abonos.Id;
                        if (!Item_Abono.NoEsNuevo) controler.Model.AddToPrestamosDetalle(Item_Abono);
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
                        message = string.IsNullOrEmpty(error) ? string.Concat("El Prestamo ha sido actualizado exitosamente.") : string.Concat("No se pudo actualizar el Prestamo:\n", error);                        
                    }
                    else
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("El Prestamo ha sido generado exitosamente.") : string.Concat("No se pudo generar el Prestamo:\n", error);
                    }

                    new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();
                }

                if (string.IsNullOrEmpty(error))
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    //this.Close();
                }
            }
        }

        private void luBeneficiario_EditValueChanged(object sender, EventArgs e)
        {
            if (source == "ABONO" || pagos==null)
            {
                llenaEmpresaBancos();
            } 
        }
    }
}
