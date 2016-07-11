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
using System.Data.Entity.Core.Objects;
using DevExpress.XtraGrid.Views.Grid;
using Microsoft.Reporting.WinForms;
using System.Data.Entity;
using System.Data.Common;
using System.Globalization;

namespace SistemaGEISA
{
    public partial class frmIngresos : DevExpress.XtraEditors.XtraForm
    {

        bool tienePermisoModificar, tienePermisoAgregar, tienePermisoCancelar;

        public Obra obra;

        public Cliente cliente;

        public Pagos pagos;

        public Iva iva;

        private Controler _controler = new Controler();

        private getDetalleIngresos_Result item;

        private Controler Controler
        {
            get
            {
                return _controler;
            }
        }
        public frmIngresos()
        {
            InitializeComponent();
            Controler.PermisosEnFormulario(Name);
            btnAgregar.Enabled = btnAgregarAbono.Enabled = tienePermisoAgregar = Controler.TienePermiso(PermisosEnum.Agregar);
            tienePermisoModificar = Controler.TienePermiso(PermisosEnum.Actualizar);
            btnCancelar.Enabled = btnEliminar.Enabled = tienePermisoCancelar = Controler.TienePermiso(PermisosEnum.Cancelar);           
        }

        private void frmIngresos_Load(object sender, EventArgs e)
        {
            iva = Controler.Model.Iva.FirstOrDefault(i => i.FechaFin == null);
            if (iva != null)
                txtIva.Text = (iva.Iva1 * 100).ToString();
            else
                new frmMessageBox(true) { Message = "Error al Obtener el Iva. ", Title = "Error" }.ShowDialog();
            
            llenaGrid();

        }

        private void llenaGrid()
        {            
            luObra.Properties.DataSource = Controler.Model.Obra.OrderBy(O => O.Nombre).ToList();
            luObra.Properties.DisplayMember = "Nombre";
            luObra.Properties.ValueMember = "Id";

            luClientes.Properties.DataSource = Controler.Model.Cliente.OrderBy(O => O.NombreFiscal).ToList();
            luClientes.Properties.DisplayMember = "NombreFiscal";
            luClientes.Properties.ValueMember = "Id";

            ckSaldo.Checked = false;
            ckCnceladas.Checked = true;

            //if(obra!=null)
            //    grid.DataSource = Controler.Model.getDetalleIngresos(this.obra.Id).ToList();
        }

        //private List<Cliente> getClientes(List<getDetalleIngresos_Result> facturas)
        //{

        //}

        private void luObra_EditValueChanged(object sender, EventArgs e)
        {
            if (luObra.IsLoading == false && luObra.GetSelectedDataRow() !=null && luClientes.GetSelectedDataRow() !=null)
            {                
                txtCobrar.Text = txtFacturar.Text = txtTotal1.Text = txtTotal2.Text= "";
                obra = luObra.GetSelectedDataRow() as Obra;
                cliente = luClientes.GetSelectedDataRow() as Cliente;
                grid.DataSource = Controler.Model.getDetalleIngresos(this.obra.Id,this.cliente.Id).ToList();
                txtEmpresa.Text = obra.Empresa.NombreFiscal;
                if (obra.PresupuestoDetalle != null)
                {
                    txtObraCivil1.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPIni_Obra_Civil);
                    txtObraCivil2.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPFin_ObraCivil);
                    txtSuministros1.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPIni_Suministros);
                    txtSuministros2.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPFin_Suministros);
                    txtSubcontratistas1.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPIni_Subcontratistas);
                    txtSubcontratistas2.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPFin_Subcontratistas);
                    txtExtras1.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPIni_Extras);
                    txtExtras2.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPFin_Extras);
                    txtTotal1.Text = obra.PPInicial.ToString("c2");
                    txtTotal2.Text = obra.PPFinal.ToString("c2");
                    //X Cobrar
                    // Obra Civil
                    //if (Convert.ToDouble(colNc.SummaryItem.SummaryValue) > 0 && Convert.ToDouble(colSaldo.SummaryItem.SummaryValue) < 0)
                    //    txtSubcontratistas3.Text = obra.PresupuestoDetalle.PPFin_Subcontratistas.Value > 0 
                    //        ? (obra.PresupuestoDetalle.PPFin_Subcontratistas.Value - (Convert.ToDouble(colSubcontratistas.SummaryItem.SummaryValue))).ToString("c2") 
                    //        : txtObraCivil3.Text = txtSubcontratistas3.Text = txtSuministros3.Text = txtExtras3.Text = txtTotal3.Text = "0.00";
                    //else
                    //{
                        txtObraCivil3.Text = obra.PresupuestoDetalle.PPFin_ObraCivil.HasValue 
                            ? (obra.PresupuestoDetalle.PPFin_ObraCivil.Value - (Convert.ToDouble(colObraCivil.SummaryItem.SummaryValue))).ToString("c2") :
                            (obra.PresupuestoDetalle.PPIni_Obra_Civil.Value > 0 ?
                                (obra.PresupuestoDetalle.PPIni_Obra_Civil.Value - (Convert.ToDouble(colObraCivil.SummaryItem.SummaryValue))).ToString("c2") : String.Format("{0:c2}", colObraCivil.SummaryItem.SummaryValue));
                        // Subcontratistas
                        txtSubcontratistas3.Text = obra.PresupuestoDetalle.PPFin_Subcontratistas.HasValue 
                            ? (obra.PresupuestoDetalle.PPFin_Subcontratistas.Value - (Convert.ToDouble(colSubcontratistas.SummaryItem.SummaryValue))).ToString("c2") 
                            :(obra.PresupuestoDetalle.PPIni_Subcontratistas.Value > 0 ?
                               (obra.PresupuestoDetalle.PPIni_Subcontratistas.Value - (Convert.ToDouble(colSubcontratistas.SummaryItem.SummaryValue))).ToString("c2") : String.Format("{0:c2}", colSubcontratistas.SummaryItem.SummaryValue));
                        // suministros
                        txtSuministros3.Text = obra.PresupuestoDetalle.PPFin_Suministros.HasValue ? (obra.PresupuestoDetalle.PPFin_Suministros.Value - (Convert.ToDouble(colSuministros.SummaryItem.SummaryValue))).ToString("c2") :
                           (obra.PresupuestoDetalle.PPIni_Suministros.Value > 0 ?
                               (obra.PresupuestoDetalle.PPIni_Suministros.Value - (Convert.ToDouble(colSuministros.SummaryItem.SummaryValue))).ToString("c2") : String.Format("{0:c2}", colSuministros.SummaryItem.SummaryValue));
                        // Extras
                        txtExtras3.Text = obra.PresupuestoDetalle.PPFin_Extras.HasValue 
                            ? (obra.PresupuestoDetalle.PPFin_Extras.Value - (Convert.ToDouble(colExtras.SummaryItem.SummaryValue))).ToString("c2") 
                            :(obra.PresupuestoDetalle.PPIni_Extras.Value > 0 
                                ?(obra.PresupuestoDetalle.PPIni_Extras.Value - (Convert.ToDouble(colExtras.SummaryItem.SummaryValue))).ToString("c2") 
                                : String.Format("{0:c2}", colExtras.SummaryItem.SummaryValue));                        
                        // SI son Negativos, la seccion por cobrar debe de salir cero.
                        txtObraCivil3.Text = convertirDouble(txtObraCivil3.Text).ToString("c2");
                        txtSubcontratistas3.Text = convertirDouble(txtSubcontratistas3.Text).ToString("c2");
                        txtSuministros3.Text = convertirDouble(txtSuministros3.Text).ToString("c2");
                        txtExtras3.Text = convertirDouble(txtExtras3.Text).ToString("c2");
                        txtTotal3.Text = ((string.IsNullOrEmpty(txtObraCivil3.Text) ? 0 : getValue(txtObraCivil3.Text)) + (string.IsNullOrEmpty(txtSubcontratistas3.Text) ? 0 : getValue(txtSubcontratistas3.Text)) + (string.IsNullOrEmpty(txtSuministros3.Text) ? 0 : getValue(txtSuministros3.Text)) + (string.IsNullOrEmpty(txtExtras3.Text) ? 0 : getValue(txtExtras3.Text))).ToString("c2");
                    //}
                }
                else
                {
                    txtObraCivil3.Text = txtSuministros3.Text = txtSubcontratistas3.Text = txtExtras3.Text = txtTotal3.Text = txtObraCivil1.Text = txtObraCivil2.Text = txtSuministros1.Text = txtSuministros2.Text = txtSubcontratistas1.Text = txtSubcontratistas2.Text = txtExtras1.Text = txtExtras2.Text = txtTotal1.Text = txtTotal2.Text = "0";
                }
                // ****************************

                double totPPfinal = obra.PPFinal;// obra.PPFinal.HasValue ? obra.PPFinal.Value : 0;
                double totFactura = gv.Columns["Total"].SummaryItem.SummaryValue!=null? Convert.ToDouble(gv.Columns["Total"].SummaryItem.SummaryValue):0;
                double totExtra = gv.Columns["Extras"].SummaryItem.SummaryValue != null ? Convert.ToDouble(gv.Columns["Extras"].SummaryItem.SummaryValue) : 0;
                double totNotaCredito = gv.Columns["NotaCredito"].SummaryItem.SummaryValue!=null?Convert.ToDouble(gv.Columns["NotaCredito"].SummaryItem.SummaryValue):0;
                double totPagos = gv.Columns["Pagos"].SummaryItem.SummaryValue!=null?Convert.ToDouble(gv.Columns["Pagos"].SummaryItem.SummaryValue):0;
                double porFacturar = ((totPPfinal > 0 ? totPPfinal : obra.PPInicial) - (totFactura - totNotaCredito));
                double porCobrar = ((totPPfinal > 0 ? totPPfinal : obra.PPInicial) - (totPagos));
                txtFacturar.Text = porFacturar >= 0 ? porFacturar.ToString("c2") : "0.00";
                txtCobrar.Text = porCobrar >= 0 ? porCobrar.ToString("c2") : "0.00";
                //txtSaldoFavor.Text = Convert.ToDouble(colSaldo.SummaryItem.SummaryValue) < 0 ? Math.Abs(Convert.ToDouble(colSaldo.SummaryItem.SummaryValue)).ToString("c2") : "$0.00";
                if (obra.PresupuestoDetalle != null)
                {
                    double saldoFavor = (totPagos - (totPPfinal > 0 ? totPPfinal : obra.PPInicial));
                    txtSaldoFavor.Text = saldoFavor >= 0 ? saldoFavor.ToString("c2") : "0.00";
                }
                else
                    txtSaldoFavor.Text = "0.00";
                //txtSaldoFavor.Text = "TOTAL PAGOS - PREPUPUESTO FINAL"
            }
        }

        private double convertirDouble(string value)
        {
            double val;
            try
            {
                val = double.Parse(value, NumberStyles.Currency);
                if (val < 0)
                    val = 0;
            }
            catch (Exception ex)
            {
                val = 0;
            }

            return val;
        }

        private void ckSaldo_CheckedChanged(object sender, EventArgs e)
        {
            if (ckSaldo.Checked)
            {
                if (obra != null && cliente!=null)
                    grid.DataSource = Controler.Model.getDetalleIngresos(this.obra.Id,this.cliente.Id).ToList().Where(d => d.Saldo > 0);
            }
            else
            {
                if (obra != null && cliente!=null)
                    grid.DataSource = Controler.Model.getDetalleIngresos(this.obra.Id,this.cliente.Id).ToList();
            }

            if (obra != null && cliente!=null)
            {
                txtCobrar.Text = txtFacturar.Text = txtTotal1.Text = txtTotal2.Text = "";
                obra = luObra.GetSelectedDataRow() as Obra;
                //txtPPinicial.Text = obra.PPInicial.ToString("c2");//obra.PPInicial.HasValue ? obra.PPInicial.Value.ToString("c2") : "0";
                //txtPPfinal.Text = obra.PPFinal.ToString("c2");//obra.PPFinal.HasValue ? obra.PPFinal.Value.ToString("c2") : "0";

                // PRUEBA
                //txtPPinicial.Text = obra.PPInicial.ToString("c2");
                //txtPPfinal.Text = obra.PPFinal.ToString("c2");
                if (obra.PresupuestoDetalle != null)
                {
                    txtObraCivil1.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPIni_Obra_Civil);
                    txtObraCivil2.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPFin_ObraCivil);
                    txtSuministros1.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPIni_Suministros);
                    txtSuministros2.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPFin_Suministros);
                    txtSubcontratistas1.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPIni_Subcontratistas);
                    txtSubcontratistas2.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPFin_Subcontratistas);
                    txtExtras1.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPIni_Extras);
                    txtExtras2.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPFin_Extras);
                    txtTotal1.Text = obra.PPInicial.ToString("c2");
                    txtTotal2.Text = obra.PPFinal.ToString("c2");

                    // Obra Civil
                    //if (Convert.ToDouble(colNc.SummaryItem.SummaryValue) > 0 && Convert.ToDouble(colSaldo.SummaryItem.SummaryValue) < 0)
                    //    txtSubcontratistas3.Text = obra.PresupuestoDetalle.PPFin_Subcontratistas.Value > 0 ? (obra.PresupuestoDetalle.PPFin_Subcontratistas.Value - (Convert.ToDouble(colSubcontratistas.SummaryItem.SummaryValue))).ToString("c2") :
                    //        txtObraCivil3.Text = txtSubcontratistas3.Text = txtSuministros3.Text = txtExtras3.Text = txtTotal3.Text = "0.00";
                    //else
                    //{                       
                    txtObraCivil3.Text = obra.PresupuestoDetalle.PPFin_ObraCivil.HasValue
                          ? (obra.PresupuestoDetalle.PPFin_ObraCivil.Value - (Convert.ToDouble(colObraCivil.SummaryItem.SummaryValue))).ToString("c2") :
                          (obra.PresupuestoDetalle.PPIni_Obra_Civil.Value > 0 ?
                              (obra.PresupuestoDetalle.PPIni_Obra_Civil.Value - (Convert.ToDouble(colObraCivil.SummaryItem.SummaryValue))).ToString("c2") : String.Format("{0:c2}", colObraCivil.SummaryItem.SummaryValue));
                    // Subcontratistas
                    txtSubcontratistas3.Text = obra.PresupuestoDetalle.PPFin_Subcontratistas.HasValue
                        ? (obra.PresupuestoDetalle.PPFin_Subcontratistas.Value - (Convert.ToDouble(colSubcontratistas.SummaryItem.SummaryValue))).ToString("c2")
                        : (obra.PresupuestoDetalle.PPIni_Subcontratistas.Value > 0 ?
                           (obra.PresupuestoDetalle.PPIni_Subcontratistas.Value - (Convert.ToDouble(colSubcontratistas.SummaryItem.SummaryValue))).ToString("c2") : String.Format("{0:c2}", colSubcontratistas.SummaryItem.SummaryValue));
                    // suministros
                    txtSuministros3.Text = obra.PresupuestoDetalle.PPFin_Suministros.HasValue ? (obra.PresupuestoDetalle.PPFin_Suministros.Value - (Convert.ToDouble(colSuministros.SummaryItem.SummaryValue))).ToString("c2") :
                       (obra.PresupuestoDetalle.PPIni_Suministros.Value > 0 ?
                           (obra.PresupuestoDetalle.PPIni_Suministros.Value - (Convert.ToDouble(colSuministros.SummaryItem.SummaryValue))).ToString("c2") : String.Format("{0:c2}", colSuministros.SummaryItem.SummaryValue));
                    // Extras
                    txtExtras3.Text = obra.PresupuestoDetalle.PPFin_Extras.HasValue
                        ? (obra.PresupuestoDetalle.PPFin_Extras.Value - (Convert.ToDouble(colExtras.SummaryItem.SummaryValue))).ToString("c2")
                        : (obra.PresupuestoDetalle.PPIni_Extras.Value > 0
                            ? (obra.PresupuestoDetalle.PPIni_Extras.Value - (Convert.ToDouble(colExtras.SummaryItem.SummaryValue))).ToString("c2")
                            : String.Format("{0:c2}", colExtras.SummaryItem.SummaryValue));                        
                        
                        txtObraCivil3.Text = convertirDouble(txtObraCivil3.Text).ToString("c2");
                        txtSubcontratistas3.Text = convertirDouble(txtSubcontratistas3.Text).ToString("c2");
                        txtSuministros3.Text = convertirDouble(txtSuministros3.Text).ToString("c2");
                        txtExtras3.Text = convertirDouble(txtExtras3.Text).ToString("c2");
                        txtTotal3.Text = ((string.IsNullOrEmpty(txtObraCivil3.Text) ? 0 : getValue(txtObraCivil3.Text)) + (string.IsNullOrEmpty(txtSubcontratistas3.Text) ? 0 : getValue(txtSubcontratistas3.Text)) + (string.IsNullOrEmpty(txtSuministros3.Text) ? 0 : getValue(txtSuministros3.Text)) + (string.IsNullOrEmpty(txtExtras3.Text) ? 0 : getValue(txtExtras3.Text))).ToString("c2");
                    //}
                }
                else
                {
                    txtObraCivil3.Text = txtSuministros3.Text = txtSubcontratistas3.Text = txtExtras3.Text = txtTotal3.Text = txtObraCivil1.Text = txtObraCivil2.Text = txtSuministros1.Text = txtSuministros2.Text = txtSubcontratistas1.Text = txtSubcontratistas2.Text = txtExtras1.Text = txtExtras2.Text = txtTotal1.Text = txtTotal2.Text = "0";
                }
                // ****************************

                double totPPfinal = obra.PPFinal;// obra.PPFinal.HasValue ? obra.PPFinal.Value : 0;
                double totFactura = gv.Columns["Total"].SummaryItem.SummaryValue != null ? Convert.ToDouble(gv.Columns["Total"].SummaryItem.SummaryValue) : 0;
                double totExtra = gv.Columns["Extras"].SummaryItem.SummaryValue != null ? Convert.ToDouble(gv.Columns["Extras"].SummaryItem.SummaryValue) : 0;
                double totNotaCredito = gv.Columns["NotaCredito"].SummaryItem.SummaryValue != null ? Convert.ToDouble(gv.Columns["NotaCredito"].SummaryItem.SummaryValue) : 0;
                double totPagos = gv.Columns["Pagos"].SummaryItem.SummaryValue != null ? Convert.ToDouble(gv.Columns["Pagos"].SummaryItem.SummaryValue) : 0;
                double porFacturar = ((totPPfinal > 0 ? totPPfinal : obra.PPInicial) - (totFactura - totNotaCredito));
                double porCobrar = ((totPPfinal > 0 ? totPPfinal : obra.PPInicial) - (totPagos));
                txtFacturar.Text = porFacturar >= 0 ? porFacturar.ToString("c2") : "0.00";
                txtCobrar.Text = porCobrar >= 0 ? porCobrar.ToString("c2") : "0.00";
                //txtSaldoFavor.Text = Convert.ToDouble(colSaldo.SummaryItem.SummaryValue) < 0 ? Math.Abs(Convert.ToDouble(colSaldo.SummaryItem.SummaryValue)).ToString("c2") : "$0.00";
                if (obra.PresupuestoDetalle != null)
                {
                    double saldoFavor = (totPagos - (totPPfinal > 0 ? totPPfinal : obra.PPInicial));
                    txtSaldoFavor.Text = saldoFavor >= 0 ? saldoFavor.ToString("c2") : "0.00";
                }
                else
                    txtSaldoFavor.Text = "0.00";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (obra != null)
            {
                var form = new frmIngresosFactura(Controler);
                form.obra = this.obra;
                form.empresa = this.obra.Empresa;
                form.cliente = this.cliente;
                form.ShowDialog();
                if (form.DialogResult == DialogResult.OK)
                {
                    frmIngresos_Load(null, null);
                    luObra_EditValueChanged(null, null);
                }
                form.Dispose();
            }
            else
            {

                new frmMessageBox(true) { Message = "Seleccione una Obra.", Title = "Aviso" }.ShowDialog();
            }
        }

        private void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gv.GetFocusedRow() != null)
            {
                item = gv.GetFocusedRow() as getDetalleIngresos_Result;
                
            }
                
        }

        private void txtPPfinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.soloNumeros(sender, e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            frmMessageBox msg = new frmMessageBox(false) { Message = "¿Desea Cancelar esta factura?", Title = "Eliminar Registro" };
            msg.ShowDialog();

            if (msg.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                if (item != null)
                {                        
                        if (item.Id != 0) {
                            if (Controler.Model.PagosFactura.Where(P => P.FacturaId == item.Id).Count()>0)
                            {
                                new frmMessageBox(true) { Message = "La Factura tiene Pagos Asociados, No es posible eliminar. ", Title = "Error" }.ShowDialog();
                                return;
                            }
                            else
                            {
                                Factura factura = Controler.Model.Factura.First(f => f.Id == item.Id);
                                if (factura.FechaCancelacion.HasValue) return;
                                factura.FechaCancelacion = DateTime.Today;
                                try
                                {
                                    Controler.Model.SaveChanges();
                                    new frmMessageBox(true) { Message = "Factura Cancelada Exitosamente. ", Title = "Aviso" }.ShowDialog();
                                }
                                catch (Exception ex)
                                {
                                    new frmMessageBox(true) { Message = "Error al Cancelar la factura: " + ex.InnerException.Message, Title = "Error" }.ShowDialog();
                                }
                            }
                        }
                        if (obra != null && cliente!=null)
                            grid.DataSource = Controler.Model.getDetalleIngresos(this.obra.Id,this.cliente.Id).ToList();  
                }
            }
        }

        private void grid_Click(object sender, EventArgs e)
        {
            if (gv.FocusedColumn.FieldName == "Detalle")
            {
                if (item != null)
                {
                    var form = new frmIngresosDetalle(Controler);
                    form.Text = "Detalle Transacciones";
                    form.obra = this.obra;
                    form.factura = Controler.Model.Factura.FirstOrDefault(f => f.Id == item.Id);
                    form.ShowDialog();
                    frmIngresos_Load(null, null);
                    luObra_EditValueChanged(null, null);
                    gv_FocusedRowChanged(null, null);
                }          
            }
        }

        private void btnAgregarAbono_Click(object sender, EventArgs e)
        {
            if (obra != null & gv.DataRowCount > 0)
            {
                abrirForm(true);
            }
            else
            {
                new frmMessageBox(true) { Message = "Seleccione una Obra.", Title = "Aviso" }.ShowDialog();
            }            
        }

        private void 
            
            abrirForm(bool nuevo)
            {
            var form = new frmPagosNew(Controler);
            form.Text = "Abono : " + (nuevo ? "Nuevo" : "Editar");
            if (!nuevo) form.pagos = pagos;
            form.tipoMovimientoId = TipoMovimientoEnum.Abonos.Id;
            form.obra = this.obra;
            form.idCliente = this.cliente.Id;   
            form.tienePermisoAgregar = tienePermisoAgregar;
            form.tienePermisoModificar = tienePermisoModificar;
            form.tienePermisoCancelar = tienePermisoCancelar;
            form.ShowDialog();

            if (nuevo)
            {
                frmIngresos_Load(null, null);
                luObra_EditValueChanged(null, null);
            }
            else
            {
                grid.RefreshDataSource();
            }

            gv_FocusedRowChanged(null, null);
        }

        private void abrirFormNC(bool nuevo)
        {
            var form = new frmPagosNew(Controler);
            form.Text = "Nota de Credito : " + (nuevo ? "Nuevo" : "Editar");
            if (!nuevo) form.pagos = pagos;
            form.tipoMovimientoId = TipoMovimientoEnum.NotaCreditoFactura.Id;
            form.obra = this.obra;
            form.source = "NC";
            form.idCliente = this.cliente.Id;
            form.tienePermisoAgregar = tienePermisoAgregar;
            form.tienePermisoModificar = tienePermisoModificar;
            form.tienePermisoCancelar = tienePermisoCancelar;

            form.ShowDialog();

            if (nuevo)
            {
                frmIngresos_Load(null, null);
                luObra_EditValueChanged(null, null);
            }
            else
            {
                grid.RefreshDataSource();
            }

            gv_FocusedRowChanged(null, null);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            double IVA;
            double.TryParse(txtIva.Text, out IVA);
            if (IVA > 0)
            {
                try
                {
                    Iva newIva = new Iva();
                    this.iva.FechaFin = DateTime.Today;
                    newIva.Iva1=IVA/100;
                    newIva.FechaInicio=DateTime.Today;
                    newIva.FechaFin=null;
                    if(!(newIva.EntityState != EntityState.Added && newIva.EntityState != EntityState.Detached)) Controler.Model.AddToIva(newIva);
                    Controler.Model.SaveChanges();                    
                    new frmMessageBox(true) { Message = "Iva Guardado Exitosamente. ", Title = "Aviso" }.ShowDialog();
                    frmIngresos_Load(null, null);
                    luObra_EditValueChanged(null, null);
                }
                catch (Exception ex)
                {
                    new frmMessageBox(true) { Message = "Error al Giardar el Iva: " + ex.InnerException.Message, Title = "Error" }.ShowDialog();
                }
            }
        }

        private void gv_RowStyle(object sender, RowStyleEventArgs e)
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

        private void ckCnceladas_CheckedChanged(object sender, EventArgs e)
        {
            if (ckCnceladas.Checked)
            {
                if (obra != null && cliente!=null)
                    grid.DataSource = Controler.Model.getDetalleIngresos(this.obra.Id,this.cliente.Id).ToList();
            }
            else
            {
                if (obra != null && cliente!=null)
                    grid.DataSource = Controler.Model.getDetalleIngresos(this.obra.Id,this.cliente.Id).ToList().Where(c=>c.FechaCancelacion==null);
            }

            if (obra != null)
            {
                txtCobrar.Text = txtFacturar.Text = txtTotal1.Text = txtTotal2.Text = "";
                obra = luObra.GetSelectedDataRow() as Obra;
                //txtPPinicial.Text = obra.PPInicial.ToString("c2");//obra.PPInicial.HasValue ? obra.PPInicial.Value.ToString("c2") : "0";
                //txtPPfinal.Text = obra.PPFinal.ToString("c2");//obra.PPFinal.HasValue ? obra.PPFinal.Value.ToString("c2") : "0";

                // PRUEBA
                //txtPPinicial.Text = obra.PPInicial.ToString("c2");
                //txtPPfinal.Text = obra.PPFinal.ToString("c2");
                if (obra.PresupuestoDetalle != null)
                {
                    txtObraCivil1.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPIni_Obra_Civil);
                    txtObraCivil2.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPFin_ObraCivil);
                    txtSuministros1.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPIni_Suministros);
                    txtSuministros2.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPFin_Suministros);
                    txtSubcontratistas1.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPIni_Subcontratistas);
                    txtSubcontratistas2.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPFin_Subcontratistas);
                    txtExtras1.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPIni_Extras);
                    txtExtras2.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPFin_Extras);
                    txtTotal1.Text = obra.PPInicial.ToString("c2");
                    txtTotal2.Text = obra.PPFinal.ToString("c2");
                    // Obra Civil
                    //if (Convert.ToDouble(colNc.SummaryItem.SummaryValue) > 0 && Convert.ToDouble(colSaldo.SummaryItem.SummaryValue) < 0)
                    //    txtSubcontratistas3.Text = obra.PresupuestoDetalle.PPFin_Subcontratistas.Value > 0 ? (obra.PresupuestoDetalle.PPFin_Subcontratistas.Value - (Convert.ToDouble(colSubcontratistas.SummaryItem.SummaryValue))).ToString("c2") :
                    //        txtObraCivil3.Text = txtSubcontratistas3.Text = txtSuministros3.Text = txtExtras3.Text = txtTotal3.Text = "0.00";
                    //else
                    //{
                    txtObraCivil3.Text = obra.PresupuestoDetalle.PPFin_ObraCivil.HasValue
                            ? (obra.PresupuestoDetalle.PPFin_ObraCivil.Value - (Convert.ToDouble(colObraCivil.SummaryItem.SummaryValue))).ToString("c2") :
                            (obra.PresupuestoDetalle.PPIni_Obra_Civil.Value > 0 ?
                                (obra.PresupuestoDetalle.PPIni_Obra_Civil.Value - (Convert.ToDouble(colObraCivil.SummaryItem.SummaryValue))).ToString("c2") : String.Format("{0:c2}", colObraCivil.SummaryItem.SummaryValue));
                    // Subcontratistas
                    txtSubcontratistas3.Text = obra.PresupuestoDetalle.PPFin_Subcontratistas.HasValue
                        ? (obra.PresupuestoDetalle.PPFin_Subcontratistas.Value - (Convert.ToDouble(colSubcontratistas.SummaryItem.SummaryValue))).ToString("c2")
                        : (obra.PresupuestoDetalle.PPIni_Subcontratistas.Value > 0 ?
                           (obra.PresupuestoDetalle.PPIni_Subcontratistas.Value - (Convert.ToDouble(colSubcontratistas.SummaryItem.SummaryValue))).ToString("c2") : String.Format("{0:c2}", colSubcontratistas.SummaryItem.SummaryValue));
                    // suministros
                    txtSuministros3.Text = obra.PresupuestoDetalle.PPFin_Suministros.HasValue ? (obra.PresupuestoDetalle.PPFin_Suministros.Value - (Convert.ToDouble(colSuministros.SummaryItem.SummaryValue))).ToString("c2") :
                       (obra.PresupuestoDetalle.PPIni_Suministros.Value > 0 ?
                           (obra.PresupuestoDetalle.PPIni_Suministros.Value - (Convert.ToDouble(colSuministros.SummaryItem.SummaryValue))).ToString("c2") : String.Format("{0:c2}", colSuministros.SummaryItem.SummaryValue));
                    // Extras
                    txtExtras3.Text = obra.PresupuestoDetalle.PPFin_Extras.HasValue
                        ? (obra.PresupuestoDetalle.PPFin_Extras.Value - (Convert.ToDouble(colExtras.SummaryItem.SummaryValue))).ToString("c2")
                        : (obra.PresupuestoDetalle.PPIni_Extras.Value > 0
                            ? (obra.PresupuestoDetalle.PPIni_Extras.Value - (Convert.ToDouble(colExtras.SummaryItem.SummaryValue))).ToString("c2")
                            : String.Format("{0:c2}", colExtras.SummaryItem.SummaryValue));                        
                        
                        txtObraCivil3.Text = convertirDouble(txtObraCivil3.Text).ToString("c2");
                        txtSubcontratistas3.Text = convertirDouble(txtSubcontratistas3.Text).ToString("c2");
                        txtSuministros3.Text = convertirDouble(txtSuministros3.Text).ToString("c2");
                        txtExtras3.Text = convertirDouble(txtExtras3.Text).ToString("c2");                        
                        txtTotal3.Text = ((string.IsNullOrEmpty(txtObraCivil3.Text) ? 0 : getValue(txtObraCivil3.Text)) + (string.IsNullOrEmpty(txtSubcontratistas3.Text) ? 0 : getValue(txtSubcontratistas3.Text)) + (string.IsNullOrEmpty(txtSuministros3.Text) ? 0 : getValue(txtSuministros3.Text)) + (string.IsNullOrEmpty(txtExtras3.Text) ? 0 : getValue(txtExtras3.Text))).ToString("c2");
                    //}
                }
                else
                {
                    txtObraCivil3.Text = txtSuministros3.Text = txtSubcontratistas3.Text = txtExtras3.Text = txtTotal3.Text = txtObraCivil1.Text = txtObraCivil2.Text = txtSuministros1.Text = txtSuministros2.Text = txtSubcontratistas1.Text = txtSubcontratistas2.Text = txtExtras1.Text = txtExtras2.Text = txtTotal1.Text = txtTotal2.Text = "0";
                }
                // ****************************

                double totPPfinal = obra.PPFinal;// obra.PPFinal.HasValue ? obra.PPFinal.Value : 0;
                double totFactura = gv.Columns["Total"].SummaryItem.SummaryValue != null ? Convert.ToDouble(gv.Columns["Total"].SummaryItem.SummaryValue) : 0;
                double totExtra = gv.Columns["Extras"].SummaryItem.SummaryValue != null ? Convert.ToDouble(gv.Columns["Extras"].SummaryItem.SummaryValue) : 0;
                double totNotaCredito = gv.Columns["NotaCredito"].SummaryItem.SummaryValue != null ? Convert.ToDouble(gv.Columns["NotaCredito"].SummaryItem.SummaryValue) : 0;
                double totPagos = gv.Columns["Pagos"].SummaryItem.SummaryValue != null ? Convert.ToDouble(gv.Columns["Pagos"].SummaryItem.SummaryValue) : 0;
                double porFacturar = ((totPPfinal > 0 ? totPPfinal : obra.PPInicial) - (totFactura - totNotaCredito));
                double porCobrar = ((totPPfinal > 0 ? totPPfinal : obra.PPInicial) - (totPagos));
                txtFacturar.Text = porFacturar >= 0 ? porFacturar.ToString("c2") : "0.00";
                txtCobrar.Text = porCobrar >= 0 ? porCobrar.ToString("c2") : "0.00";
                //txtSaldoFavor.Text = Convert.ToDouble(colSaldo.SummaryItem.SummaryValue) < 0 ? Math.Abs(Convert.ToDouble(colSaldo.SummaryItem.SummaryValue)).ToString("c2") : "$0.00";
                if (obra.PresupuestoDetalle != null)
                {
                    double saldoFavor = (totPagos - (totPPfinal > 0 ? totPPfinal : obra.PPInicial));
                    txtSaldoFavor.Text = saldoFavor >= 0 ? saldoFavor.ToString("c2") : "0.00";
                }
                else
                    txtSaldoFavor.Text = "0.00";
            }

        }


        private double getValue(string value)
        {
            double val;
            try
            {

                val = double.Parse(value, NumberStyles.Currency);
            }
            catch (Exception ex)
            {
                val = 0;
            }

            return val;
        
        }

        private void txtIva_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.soloNumeros(sender, e);
        }

        private void gv_DoubleClick(object sender, EventArgs e)
        {
            btnEditar_Click(null, null);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gv.SelectedRowsCount == 1 && item != null)
            {
                var form = new frmIngresosFactura(Controler);
                form.Text = "Facturas : Editar";
                form.factura = Controler.Model.Factura.FirstOrDefault(f=> f.Id==item.Id);              
                form.obra = this.obra;

                form.ShowDialog();
                frmIngresos_Load(null, null);
                luObra_EditValueChanged(null, null);
                gv_FocusedRowChanged(null, null);
            }
            else
            {
                new frmMessageBox(true) { Message = "Favor de seleccionar el elemento a editar.", Title = "Confirmación" }.ShowDialog();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmMessageBox msg = new frmMessageBox(false) { Message = "¿Desea Eliminar la Factura?", Title = "Eliminar" };
            msg.ShowDialog();

            if (msg.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                getDetalleIngresos_Result registro = gv.GetFocusedRow() as getDetalleIngresos_Result;

                if (registro != null)
                {
                    DbTransaction transaccion = null;

                    try
                    {
                        transaccion = Controler.Model.BeginTransaction();
                        Factura item = Controler.Model.Factura.FirstOrDefault(F => F.Id == registro.Id);
                        Controler.Model.DeleteObject(item);
                        Controler.Model.SaveChanges();
                        transaccion.Commit();
                        new frmMessageBox(true) { Message = "La Factura ha sido Eliminada.", Title = "Aviso" }.ShowDialog();
                        gv.DeleteRow(gv.FocusedRowHandle);
                        luObra_EditValueChanged(null, null);
                        gv.RefreshData();
                    }
                    catch (Exception ex)
                    {
                        new frmMessageBox(true) { Message = "Error al quitar la Factura, La Factura tiene Documentos Asociados.", Title = "Error" }.ShowDialog();
                        if (transaccion != null) transaccion.Rollback();
                    }
                }
            }
            else
            {
                new frmMessageBox(true) { Message = "Seleccione una Factura a Eliminar.", Title = "Aviso" }.ShowDialog();
            }
            Controler.Model.CloseConnection();
        }

        private void btnGuardarPresupuestos_Click(object sender, EventArgs e)
        {
            frmMessageBox msg = new frmMessageBox(false) { Message = "¿Desea Guardar el Presupuesto?", Title = "Guardar" };
            msg.ShowDialog();

            if (msg.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {

                if (this.obra != null)
                {
                    DbTransaction transaccion = null;
                    PresupuestoDetalle presupuesto;
                    try
                    {
                        transaccion = Controler.Model.BeginTransaction();

                        if (obra.PresupuestoDetalle == null)
                            presupuesto = new PresupuestoDetalle();
                        else
                            presupuesto = obra.PresupuestoDetalle;
                        //PPInicial
                        presupuesto.PPIni_Obra_Civil = string.IsNullOrEmpty(txtObraCivil1.Text) ? 0 : Convert.ToDouble(txtObraCivil1.Text);
                        presupuesto.PPIni_Subcontratistas = string.IsNullOrEmpty(txtSubcontratistas1.Text) ? 0 : Convert.ToDouble(txtSubcontratistas1.Text);
                        presupuesto.PPIni_Suministros = string.IsNullOrEmpty(txtSuministros1.Text) ? 0 : Convert.ToDouble(txtSuministros1.Text);
                        presupuesto.PPIni_Extras = string.IsNullOrEmpty(txtExtras1.Text) ? 0 : Convert.ToDouble(txtExtras1.Text);
                        //PPFinal
                        presupuesto.PPFin_ObraCivil= string.IsNullOrEmpty(txtObraCivil2.Text) ? 0 : Convert.ToDouble(txtObraCivil2.Text);
                        presupuesto.PPFin_Subcontratistas = string.IsNullOrEmpty(txtSubcontratistas2.Text) ? 0 : Convert.ToDouble(txtSubcontratistas2.Text);
                        presupuesto.PPFin_Suministros = string.IsNullOrEmpty(txtSuministros2.Text) ? 0 : Convert.ToDouble(txtSuministros2.Text);
                        presupuesto.PPFin_Extras = string.IsNullOrEmpty(txtExtras2.Text) ? 0 : Convert.ToDouble(txtExtras2.Text);
                        obra.PresupuestoDetalle = presupuesto;
                        if (!presupuesto.NoEsNuevo) Controler.Model.AddToPresupuestoDetalle(presupuesto);
                      
                        Controler.Model.SaveChanges();
                        transaccion.Commit();
                        new frmMessageBox(true) { Message = "El Presupuesto ha sido Guardado Exitosamente.", Title = "Aviso" }.ShowDialog();
                        luObra_EditValueChanged(null, null);
                    }
                    catch (Exception ex)
                    {
                        new frmMessageBox(true) { Message = "Error al Guardar el Presupuesto", Title = "Error" }.ShowDialog();
                        if (transaccion != null) transaccion.Rollback();
                    }
                }
            }
            else
            {
                new frmMessageBox(true) { Message = "Seleccione una Obra para Asignar Presupuesto.", Title = "Aviso" }.ShowDialog();
            }
            Controler.Model.CloseConnection();
        }

        private void txtObraCivil1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.soloNumerosDec(sender, e);
        }

        private void luClientes_EditValueChanged(object sender, EventArgs e)
        {
            luObra_EditValueChanged(null, null);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            frmBuscarIngresos form = new frmBuscarIngresos(Controler);
            form.Show();
        }

        private void btnAgregarNC_Click(object sender, EventArgs e)
        {
            if (obra != null & gv.DataRowCount > 0)
            {
                abrirFormNC(true);
            }
            else
            {
                new frmMessageBox(true) { Message = "Seleccione una Obra.", Title = "Aviso" }.ShowDialog();
            } 
        }

        private void btnSaldoFavor_Click(object sender, EventArgs e)
        {
            double saldoFavor = convertirDouble(txtSaldoFavor.Text);
            if (saldoFavor > 0)
            {
                if (obra != null & gv.DataRowCount > 0)
                {
                    var form = new frmPagosNew(Controler);
                    form.Text = "Abono : " + (true ? "Nuevo" : "Editar");
                    if (!true) form.pagos = pagos;
                    form.tipoMovimientoId = TipoMovimientoEnum.Abonos.Id;
                    form.obra = this.obra;
                    form.idCliente = this.cliente.Id;
                    form.tienePermisoAgregar = tienePermisoAgregar;
                    form.tienePermisoModificar = tienePermisoModificar;
                    form.tienePermisoCancelar = tienePermisoCancelar;

                    //cancelo botones ya que no se podra hacer otro movimiento
                    form.ShowDialog();

                    //if (nuevo)
                    //{
                    //    frmIngresos_Load(null, null);
                    //    luObra_EditValueChanged(null, null);
                    //}
                    //else
                    //{
                    //    grid.RefreshDataSource();
                    //}

                    //gv_FocusedRowChanged(null, null);
                }
                else
                {
                    new frmMessageBox(true) { Message = "Seleccione una Obra.", Title = "Aviso" }.ShowDialog();
                } 
            }
            else
            {

            }
        }
    }
}
