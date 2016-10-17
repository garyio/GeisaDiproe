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

        private List<getDetalleIngresos_Result> ingresos;

        private getDetalleIngresos_Result item;
        private double saldoFavor = 0;

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
        private void getTotalesPorCobrar(List<getDetalleIngresos_Result> ingresosPorCObrar)
        {
            double Obracivil=0, subcontratistas=0, suministros=0, Extras=0, Mantenimiento=0, NoAplica=0;
            Obracivil = ingresosPorCObrar.Where(I => I.ObraCivil.Value> 0).Select(F => F.Pagos.Value).DefaultIfEmpty(0).Sum();
            subcontratistas = ingresosPorCObrar.Where(I => I.Subcontratistas.Value> 0).Select(F => F.Pagos.Value).DefaultIfEmpty(0).Sum();
            suministros = ingresosPorCObrar.Where(I => I.Suministros.Value > 0).Select(F => F.Pagos.Value).DefaultIfEmpty(0).Sum();
            Extras = ingresosPorCObrar.Where(I => I.Extras.Value > 0).Select(F => F.Pagos.Value).DefaultIfEmpty(0).Sum();
            Mantenimiento = ingresosPorCObrar.Where(I => I.Mantenimiento.Value > 0).Select(F => F.Pagos.Value).DefaultIfEmpty(0).Sum();
            NoAplica = ingresosPorCObrar.Where(I => I.No_Aplica.Value > 0).Select(F => F.Pagos.Value).DefaultIfEmpty(0).Sum();

            txtObraCivil4.Text = obra.PresupuestoDetalle.PPFin_ObraCivil.HasValue
                        ? (obra.PresupuestoDetalle.PPFin_ObraCivil.Value - (Obracivil)).ToString("c2") :
                        ((obra.PresupuestoDetalle.PPIni_Obra_Civil.HasValue ? obra.PresupuestoDetalle.PPIni_Obra_Civil.Value : 0) > 0 ?
                            (obra.PresupuestoDetalle.PPIni_Obra_Civil.Value - (Obracivil)).ToString("c2") : String.Format("{0:c2}", Obracivil));
            // Subcontratistas
            txtSubcontratistas4.Text = obra.PresupuestoDetalle.PPFin_Subcontratistas.HasValue
                ? (obra.PresupuestoDetalle.PPFin_Subcontratistas.Value - (Convert.ToDouble(subcontratistas))).ToString("c2")
                : (obra.PresupuestoDetalle.PPIni_Subcontratistas.HasValue ? obra.PresupuestoDetalle.PPIni_Subcontratistas.Value : 0) > 0 ?
                   (obra.PresupuestoDetalle.PPIni_Subcontratistas.Value - (Convert.ToDouble(subcontratistas))).ToString("c2") : String.Format("{0:c2}", subcontratistas);
            // suministros
            txtSuministros4.Text = obra.PresupuestoDetalle.PPFin_Suministros.HasValue ? (obra.PresupuestoDetalle.PPFin_Suministros.Value - (Convert.ToDouble(suministros))).ToString("c2")
                : ((obra.PresupuestoDetalle.PPIni_Suministros.HasValue ? obra.PresupuestoDetalle.PPIni_Suministros.Value : 0) > 0 ?
                   (obra.PresupuestoDetalle.PPIni_Suministros.Value - (Convert.ToDouble(suministros))).ToString("c2") : String.Format("{0:c2}", suministros));
            // Extras
            txtExtras4.Text = obra.PresupuestoDetalle.PPFin_Extras.HasValue
                ? (obra.PresupuestoDetalle.PPFin_Extras.Value - (Convert.ToDouble(Extras))).ToString("c2")
                : ((obra.PresupuestoDetalle.PPIni_Extras.HasValue ? obra.PresupuestoDetalle.PPIni_Extras.Value : 0) > 0
                    ? (obra.PresupuestoDetalle.PPIni_Extras.Value - (Convert.ToDouble(Extras))).ToString("c2")
                    : String.Format("{0:c2}", Extras));
            //Mantenimiento
            txtMantenimiento4.Text = obra.PresupuestoDetalle.PPFin_Mantenimiento.HasValue
                ? (obra.PresupuestoDetalle.PPFin_Mantenimiento.Value - (Convert.ToDouble(Mantenimiento))).ToString("c2")
                : (obra.PresupuestoDetalle.PPIni_Mantenimiento.HasValue ? obra.PresupuestoDetalle.PPIni_Mantenimiento.Value : 0) > 0
                    ? (obra.PresupuestoDetalle.PPIni_Mantenimiento.Value - (Convert.ToDouble(Mantenimiento))).ToString("c2")
                    : String.Format("{0:c2}", Mantenimiento);
            //No Aplica
            txtNA4.Text = obra.PresupuestoDetalle.PPFin_NA.HasValue
                ? (obra.PresupuestoDetalle.PPFin_NA.Value - (Convert.ToDouble(NoAplica))).ToString("c2")
                : ((obra.PresupuestoDetalle.PPIni_NA.HasValue ? obra.PresupuestoDetalle.PPIni_NA.Value : 0) > 0
                    ? (obra.PresupuestoDetalle.PPIni_NA.Value - (Convert.ToDouble(NoAplica))).ToString("c2")
                    : String.Format("{0:c2}", NoAplica));
            //Descuento
            txtDescuentos4.Text = obra.PresupuestoDetalle.PPFin_Descuento.HasValue
                ? (obra.PresupuestoDetalle.PPFin_Descuento.Value - (obra.PresupuestoDetalle.PPIni_Descuento.Value > 0 ? obra.PresupuestoDetalle.PPIni_Descuento.Value : 0)).ToString("c2")
                : ((obra.PresupuestoDetalle.PPIni_Descuento.HasValue ? obra.PresupuestoDetalle.PPIni_Descuento.Value : 0) > 0 ? obra.PresupuestoDetalle.PPIni_Descuento.Value : 0).ToString("c2");

                            // SI son Negativos, la seccion por Cobrar debe de salir cero.
            txtObraCivil4.Text = convertirDouble(txtObraCivil4.Text).ToString("c2");
            txtSubcontratistas4.Text = convertirDouble(txtSubcontratistas4.Text).ToString("c2");
            txtSuministros4.Text = convertirDouble(txtSuministros4.Text).ToString("c2");
            txtExtras4.Text = convertirDouble(txtExtras4.Text).ToString("c2");
            txtMantenimiento4.Text = convertirDouble(txtMantenimiento4.Text).ToString("c2");
            txtNA4.Text = convertirDouble(txtNA4.Text).ToString("c2");
            txtDescuentos4.Text = convertirDouble(txtDescuentos4.Text).ToString("c2");
            txtTotal4.Text = ((string.IsNullOrEmpty(txtObraCivil4.Text) ? 0 : getValue(txtObraCivil4.Text)) + (string.IsNullOrEmpty(txtSubcontratistas4.Text) ? 0 : getValue(txtSubcontratistas4.Text)) + (string.IsNullOrEmpty(txtSuministros4.Text) ? 0 : getValue(txtSuministros4.Text)) + (string.IsNullOrEmpty(txtExtras4.Text) ? 0 : getValue(txtExtras4.Text)) + (string.IsNullOrEmpty(txtMantenimiento4.Text) ? 0 : getValue(txtMantenimiento4.Text)) + (string.IsNullOrEmpty(txtNA4.Text) ? 0 : getValue(txtNA4.Text)) - (string.IsNullOrEmpty(txtDescuentos4.Text) ? 0 : getValue(txtDescuentos4.Text))).ToString("c2");              

        }

        private void luObra_EditValueChanged(object sender, EventArgs e)
        {
            obra = luObra.GetSelectedDataRow() as Obra;
            LookUpEdit lookup = (sender != null ? sender : (LookUpEdit)null) as LookUpEdit;

            //Pongo automaticamente el cliente de la obra.
            if (lookup != null ? (lookup.Name == "luObra") : false)
                luClientes.EditValue = obra != null ? obra.ClienteId : (int?)null;

            if (luObra.IsLoading == false && luObra.GetSelectedDataRow() != null && luClientes.GetSelectedDataRow() != null)
            {
                txtCobrar.Text = txtFacturar.Text = txtTotal1.Text = txtTotal2.Text = "";
                //obra = luObra.GetSelectedDataRow() as Obra;
                cliente = luClientes.GetSelectedDataRow() as Cliente;
                grid.DataSource = ingresos = Controler.Model.getDetalleIngresos(this.obra.Id, this.cliente.Id, false).ToList();                
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
                    txtMantenimiento1.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPIni_Mantenimiento);
                    txtMantenimiento2.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPFin_Mantenimiento);
                    txtNA1.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPIni_NA);
                    txtNA2.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPFin_NA);
                    txtDescuentos1.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPIni_Descuento);
                    txtDescuentos2.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPFin_Descuento);
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
                        ((obra.PresupuestoDetalle.PPIni_Obra_Civil.HasValue ? obra.PresupuestoDetalle.PPIni_Obra_Civil.Value : 0) > 0 ?
                            (obra.PresupuestoDetalle.PPIni_Obra_Civil.Value - (Convert.ToDouble(colObraCivil.SummaryItem.SummaryValue))).ToString("c2") : String.Format("{0:c2}", colObraCivil.SummaryItem.SummaryValue));
                    // Subcontratistas
                    txtSubcontratistas3.Text = obra.PresupuestoDetalle.PPFin_Subcontratistas.HasValue
                        ? (obra.PresupuestoDetalle.PPFin_Subcontratistas.Value - (Convert.ToDouble(colSubcontratistas.SummaryItem.SummaryValue))).ToString("c2")
                        : (obra.PresupuestoDetalle.PPIni_Subcontratistas.HasValue ? obra.PresupuestoDetalle.PPIni_Subcontratistas.Value : 0) > 0 ?
                           (obra.PresupuestoDetalle.PPIni_Subcontratistas.Value - (Convert.ToDouble(colSubcontratistas.SummaryItem.SummaryValue))).ToString("c2") : String.Format("{0:c2}", colSubcontratistas.SummaryItem.SummaryValue);
                    // suministros
                    txtSuministros3.Text = obra.PresupuestoDetalle.PPFin_Suministros.HasValue ? (obra.PresupuestoDetalle.PPFin_Suministros.Value - (Convert.ToDouble(colSuministros.SummaryItem.SummaryValue))).ToString("c2")
                        : ((obra.PresupuestoDetalle.PPIni_Suministros.HasValue ? obra.PresupuestoDetalle.PPIni_Suministros.Value : 0) > 0 ?
                           (obra.PresupuestoDetalle.PPIni_Suministros.Value - (Convert.ToDouble(colSuministros.SummaryItem.SummaryValue))).ToString("c2") : String.Format("{0:c2}", colSuministros.SummaryItem.SummaryValue));
                    // Extras
                    txtExtras3.Text = obra.PresupuestoDetalle.PPFin_Extras.HasValue
                        ? (obra.PresupuestoDetalle.PPFin_Extras.Value - (Convert.ToDouble(colExtras.SummaryItem.SummaryValue))).ToString("c2")
                        : ((obra.PresupuestoDetalle.PPIni_Extras.HasValue ? obra.PresupuestoDetalle.PPIni_Extras.Value : 0) > 0
                            ? (obra.PresupuestoDetalle.PPIni_Extras.Value - (Convert.ToDouble(colExtras.SummaryItem.SummaryValue))).ToString("c2")
                            : String.Format("{0:c2}", colExtras.SummaryItem.SummaryValue));
                    //Mantenimiento
                    txtMantenimiento3.Text = obra.PresupuestoDetalle.PPFin_Mantenimiento.HasValue
                        ? (obra.PresupuestoDetalle.PPFin_Mantenimiento.Value - (Convert.ToDouble(colMantenimiento.SummaryItem.SummaryValue))).ToString("c2")
                        : (obra.PresupuestoDetalle.PPIni_Mantenimiento.HasValue ? obra.PresupuestoDetalle.PPIni_Mantenimiento.Value : 0) > 0
                            ? (obra.PresupuestoDetalle.PPIni_Mantenimiento.Value - (Convert.ToDouble(colMantenimiento.SummaryItem.SummaryValue))).ToString("c2")
                            : String.Format("{0:c2}", colMantenimiento.SummaryItem.SummaryValue);
                    //No Aplica
                    txtNA3.Text = obra.PresupuestoDetalle.PPFin_NA.HasValue
                        ? (obra.PresupuestoDetalle.PPFin_NA.Value - (Convert.ToDouble(colNA.SummaryItem.SummaryValue))).ToString("c2")
                        : ((obra.PresupuestoDetalle.PPIni_NA.HasValue ? obra.PresupuestoDetalle.PPIni_NA.Value : 0) > 0
                            ? (obra.PresupuestoDetalle.PPIni_NA.Value - (Convert.ToDouble(colNA.SummaryItem.SummaryValue))).ToString("c2")
                            : String.Format("{0:c2}", colNA.SummaryItem.SummaryValue));
                    //Descuento
                    txtDescuentos3.Text = obra.PresupuestoDetalle.PPFin_Descuento.HasValue
                        ? (obra.PresupuestoDetalle.PPFin_Descuento.Value - (obra.PresupuestoDetalle.PPIni_Descuento.Value > 0 ? obra.PresupuestoDetalle.PPIni_Descuento.Value : 0)).ToString("c2")
                        : ((obra.PresupuestoDetalle.PPIni_Descuento.HasValue ? obra.PresupuestoDetalle.PPIni_Descuento.Value : 0) > 0 ? obra.PresupuestoDetalle.PPIni_Descuento.Value : 0).ToString("c2");

                    // SI son Negativos, la seccion por Facturar debe de salir cero.
                    txtObraCivil3.Text = convertirDouble(txtObraCivil3.Text).ToString("c2");
                    txtSubcontratistas3.Text = convertirDouble(txtSubcontratistas3.Text).ToString("c2");
                    txtSuministros3.Text = convertirDouble(txtSuministros3.Text).ToString("c2");
                    txtExtras3.Text = convertirDouble(txtExtras3.Text).ToString("c2");
                    txtMantenimiento3.Text = convertirDouble(txtMantenimiento3.Text).ToString("c2");
                    txtNA3.Text = convertirDouble(txtNA3.Text).ToString("c2");
                    txtDescuentos3.Text = convertirDouble(txtDescuentos3.Text).ToString("c2");
                    txtTotal3.Text = ((string.IsNullOrEmpty(txtObraCivil3.Text) ? 0 : getValue(txtObraCivil3.Text)) + (string.IsNullOrEmpty(txtSubcontratistas3.Text) ? 0 : getValue(txtSubcontratistas3.Text)) + (string.IsNullOrEmpty(txtSuministros3.Text) ? 0 : getValue(txtSuministros3.Text)) + (string.IsNullOrEmpty(txtExtras3.Text) ? 0 : getValue(txtExtras3.Text)) + (string.IsNullOrEmpty(txtMantenimiento3.Text) ? 0 : getValue(txtMantenimiento3.Text)) + (string.IsNullOrEmpty(txtNA3.Text) ? 0 : getValue(txtNA3.Text)) - (string.IsNullOrEmpty(txtDescuentos3.Text) ? 0 : getValue(txtDescuentos3.Text))).ToString("c2");
                    getTotalesPorCobrar(ingresos); // lleno seccion Por Cobrar
                    //}
                }
                else
                {
                    txtObraCivil4.Text = txtSuministros4.Text = txtSubcontratistas4.Text = txtExtras4.Text = txtMantenimiento4.Text = txtNA4.Text = txtDescuentos4.Text = txtTotal4.Text = txtObraCivil3.Text = txtSuministros3.Text = txtSubcontratistas3.Text = txtExtras3.Text = txtMantenimiento3.Text = txtNA3.Text = txtDescuentos3.Text = txtTotal3.Text = txtObraCivil1.Text = txtObraCivil2.Text = txtSuministros1.Text = txtSuministros2.Text = txtSubcontratistas1.Text = txtSubcontratistas2.Text = txtExtras1.Text = txtExtras2.Text = txtMantenimiento1.Text = txtMantenimiento2.Text = txtNA1.Text = txtNA2.Text = txtDescuentos1.Text = txtDescuentos2.Text = txtTotal1.Text = txtTotal2.Text = "0";
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
                    double saldoFavor = (totPagos - (totPPfinal > 0 ? totPPfinal : obra.PPInicial) - getTraspasos(obra.Id, cliente.Id, obra.Empresa.Id));
                    txtSaldoFavor.Text = saldoFavor >= 0 ? saldoFavor.ToString("c2") : "0.00";
                }
                else
                    txtSaldoFavor.Text = "0.00";
                //txtSaldoFavor.Text = "TOTAL PAGOS - PREPUPUESTO FINAL"
                
            }
        }

        private double getTraspasos(int obraId, int clienteId, int empresaId)
        {
            try
            {
                //controler.Model.get(factura.Id, pagos.Id).Select(A => A.MontoPagar).DefaultIfEmpty(0).Sum().Value; 
                Console.WriteLine(Controler.Model.getDetalleTraspasos(obraId, clienteId, empresaId).Sum().Value);
                return Controler.Model.getDetalleTraspasos(obraId, clienteId, empresaId).Sum().Value;
            }
            catch (Exception ex)
            {
                return 0;
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
            List<getDetalleIngresos_Result> ingresos = Controler.Model.getDetalleIngresos(this.obra.Id, this.cliente.Id, false).ToList();
            grid.DataSource = ingresos;
            if (ckSaldo.Checked)
            {
                if (obra != null && cliente != null)
                    grid.DataSource = ingresos = Controler.Model.getDetalleIngresos(this.obra.Id, this.cliente.Id, false).Where(d => d.Saldo > 0).ToList();  
                    //grid.DataSource = Controler.Model.getDetalleIngresos(this.obra.Id, this.cliente.Id,false).ToList().Where(d => d.Saldo > 0);
            }
            else
            {
                if (obra != null && cliente != null)
                    grid.DataSource = ingresos = Controler.Model.getDetalleIngresos(this.obra.Id, this.cliente.Id, false).ToList();  
                    //grid.DataSource = Controler.Model.getDetalleIngresos(this.obra.Id, this.cliente.Id,false).ToList();
            }

            if (obra != null && cliente != null)
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
                    txtMantenimiento1.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPIni_Mantenimiento);
                    txtMantenimiento2.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPFin_Mantenimiento);
                    txtNA1.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPIni_NA);
                    txtNA2.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPFin_NA);
                    txtDescuentos1.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPIni_Descuento);
                    txtDescuentos2.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPFin_Descuento);

                    // Obra Civil
                    //if (Convert.ToDouble(colNc.SummaryItem.SummaryValue) > 0 && Convert.ToDouble(colSaldo.SummaryItem.SummaryValue) < 0)
                    //    txtSubcontratistas3.Text = obra.PresupuestoDetalle.PPFin_Subcontratistas.Value > 0 ? (obra.PresupuestoDetalle.PPFin_Subcontratistas.Value - (Convert.ToDouble(colSubcontratistas.SummaryItem.SummaryValue))).ToString("c2") :
                    //        txtObraCivil3.Text = txtSubcontratistas3.Text = txtSuministros3.Text = txtExtras3.Text = txtTotal3.Text = "0.00";
                    //else
                    //{                       
                    txtObraCivil3.Text = obra.PresupuestoDetalle.PPFin_ObraCivil.HasValue
                            ? (obra.PresupuestoDetalle.PPFin_ObraCivil.Value - (Convert.ToDouble(colObraCivil.SummaryItem.SummaryValue))).ToString("c2") :
                            ((obra.PresupuestoDetalle.PPIni_Obra_Civil.HasValue ? obra.PresupuestoDetalle.PPIni_Obra_Civil.Value : 0) > 0 ?
                                (obra.PresupuestoDetalle.PPIni_Obra_Civil.Value - (Convert.ToDouble(colObraCivil.SummaryItem.SummaryValue))).ToString("c2") : String.Format("{0:c2}", colObraCivil.SummaryItem.SummaryValue));
                    // Subcontratistas
                    txtSubcontratistas3.Text = obra.PresupuestoDetalle.PPFin_Subcontratistas.HasValue
                        ? (obra.PresupuestoDetalle.PPFin_Subcontratistas.Value - (Convert.ToDouble(colSubcontratistas.SummaryItem.SummaryValue))).ToString("c2")
                        : (obra.PresupuestoDetalle.PPIni_Subcontratistas.HasValue ? obra.PresupuestoDetalle.PPIni_Subcontratistas.Value : 0) > 0 ?
                           (obra.PresupuestoDetalle.PPIni_Subcontratistas.Value - (Convert.ToDouble(colSubcontratistas.SummaryItem.SummaryValue))).ToString("c2") : String.Format("{0:c2}", colSubcontratistas.SummaryItem.SummaryValue);
                    // suministros
                    txtSuministros3.Text = obra.PresupuestoDetalle.PPFin_Suministros.HasValue ? (obra.PresupuestoDetalle.PPFin_Suministros.Value - (Convert.ToDouble(colSuministros.SummaryItem.SummaryValue))).ToString("c2")
                        : ((obra.PresupuestoDetalle.PPIni_Suministros.HasValue ? obra.PresupuestoDetalle.PPIni_Suministros.Value : 0) > 0 ?
                           (obra.PresupuestoDetalle.PPIni_Suministros.Value - (Convert.ToDouble(colSuministros.SummaryItem.SummaryValue))).ToString("c2") : String.Format("{0:c2}", colSuministros.SummaryItem.SummaryValue));
                    // Extras
                    txtExtras3.Text = obra.PresupuestoDetalle.PPFin_Extras.HasValue
                        ? (obra.PresupuestoDetalle.PPFin_Extras.Value - (Convert.ToDouble(colExtras.SummaryItem.SummaryValue))).ToString("c2")
                        : ((obra.PresupuestoDetalle.PPIni_Extras.HasValue ? obra.PresupuestoDetalle.PPIni_Extras.Value : 0) > 0
                            ? (obra.PresupuestoDetalle.PPIni_Extras.Value - (Convert.ToDouble(colExtras.SummaryItem.SummaryValue))).ToString("c2")
                            : String.Format("{0:c2}", colExtras.SummaryItem.SummaryValue));
                    //Mantenimiento
                    txtMantenimiento3.Text = obra.PresupuestoDetalle.PPFin_Mantenimiento.HasValue
                        ? (obra.PresupuestoDetalle.PPFin_Mantenimiento.Value - (Convert.ToDouble(colMantenimiento.SummaryItem.SummaryValue))).ToString("c2")
                        : (obra.PresupuestoDetalle.PPIni_Mantenimiento.HasValue ? obra.PresupuestoDetalle.PPIni_Mantenimiento.Value : 0) > 0
                            ? (obra.PresupuestoDetalle.PPIni_Mantenimiento.Value - (Convert.ToDouble(colMantenimiento.SummaryItem.SummaryValue))).ToString("c2")
                            : String.Format("{0:c2}", colMantenimiento.SummaryItem.SummaryValue);
                    //No Aplica
                    txtNA3.Text = obra.PresupuestoDetalle.PPFin_NA.HasValue
                        ? (obra.PresupuestoDetalle.PPFin_NA.Value - (Convert.ToDouble(colNA.SummaryItem.SummaryValue))).ToString("c2")
                        : ((obra.PresupuestoDetalle.PPIni_NA.HasValue ? obra.PresupuestoDetalle.PPIni_NA.Value : 0) > 0
                            ? (obra.PresupuestoDetalle.PPIni_NA.Value - (Convert.ToDouble(colNA.SummaryItem.SummaryValue))).ToString("c2")
                            : String.Format("{0:c2}", colNA.SummaryItem.SummaryValue));
                    //Descuento
                    txtDescuentos3.Text = obra.PresupuestoDetalle.PPFin_Descuento.HasValue
                           ? (obra.PresupuestoDetalle.PPFin_Descuento.Value - (obra.PresupuestoDetalle.PPIni_Descuento.Value > 0 ? obra.PresupuestoDetalle.PPIni_Descuento.Value : 0)).ToString("c2")
                           : ((obra.PresupuestoDetalle.PPIni_Descuento.HasValue ? obra.PresupuestoDetalle.PPIni_Descuento.Value : 0) > 0 ? obra.PresupuestoDetalle.PPIni_Descuento.Value : 0).ToString("c2");

                    txtObraCivil3.Text = convertirDouble(txtObraCivil3.Text).ToString("c2");
                    txtSubcontratistas3.Text = convertirDouble(txtSubcontratistas3.Text).ToString("c2");
                    txtSuministros3.Text = convertirDouble(txtSuministros3.Text).ToString("c2");
                    txtExtras3.Text = convertirDouble(txtExtras3.Text).ToString("c2");
                    txtMantenimiento3.Text = convertirDouble(txtMantenimiento3.Text).ToString("c2");
                    txtNA3.Text = convertirDouble(txtNA3.Text).ToString("c2");
                    txtDescuentos3.Text = convertirDouble(txtDescuentos3.Text).ToString("c2");
                    txtTotal3.Text = ((string.IsNullOrEmpty(txtObraCivil3.Text) ? 0 : getValue(txtObraCivil3.Text)) + (string.IsNullOrEmpty(txtSubcontratistas3.Text) ? 0 : getValue(txtSubcontratistas3.Text)) + (string.IsNullOrEmpty(txtSuministros3.Text) ? 0 : getValue(txtSuministros3.Text)) + (string.IsNullOrEmpty(txtExtras3.Text) ? 0 : getValue(txtExtras3.Text)) + (string.IsNullOrEmpty(txtMantenimiento3.Text) ? 0 : getValue(txtMantenimiento3.Text)) + (string.IsNullOrEmpty(txtNA3.Text) ? 0 : getValue(txtNA3.Text)) - (string.IsNullOrEmpty(txtDescuentos3.Text) ? 0 : getValue(txtDescuentos3.Text))).ToString("c2");
                    getTotalesPorCobrar(ingresos); // lleno seccion Por Cobrar

                    //}
                }
                else
                {
                    txtObraCivil4.Text = txtSuministros4.Text = txtSubcontratistas4.Text = txtExtras4.Text = txtMantenimiento4.Text = txtNA4.Text = txtDescuentos4.Text = txtTotal4.Text = txtObraCivil3.Text = txtSuministros3.Text = txtSubcontratistas3.Text = txtExtras3.Text = txtMantenimiento3.Text = txtNA3.Text = txtDescuentos3.Text = txtTotal3.Text = txtObraCivil1.Text = txtObraCivil2.Text = txtSuministros1.Text = txtSuministros2.Text = txtSubcontratistas1.Text = txtSubcontratistas2.Text = txtExtras1.Text = txtExtras2.Text = txtMantenimiento1.Text = txtMantenimiento2.Text = txtNA1.Text = txtNA2.Text = txtDescuentos1.Text = txtDescuentos2.Text = txtTotal1.Text = txtTotal2.Text = "0";
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
                    double saldoFavor = (totPagos - (totPPfinal > 0 ? totPPfinal : obra.PPInicial) - getTraspasos(obra.Id, cliente.Id, obra.Empresa.Id));
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
                    luObra_EditValueChanged(sender, null);
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
                    if (item.Id != 0)
                    {
                        if (Controler.Model.PagosFactura.Where(P => P.FacturaId == item.Id).Count() > 0)
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
                    if (obra != null && cliente != null)
                        grid.DataSource = Controler.Model.getDetalleIngresos(this.obra.Id, this.cliente.Id,false).ToList();
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
                    luObra_EditValueChanged(sender, null);
                    gv_FocusedRowChanged(null, null);
                }
            }
        }

        private void btnAgregarAbono_Click(object sender, EventArgs e)
        {
            if (obra != null & gv.DataRowCount > 0)
            {
                abrirForm(true, false);
            }
            else
            {
                new frmMessageBox(true) { Message = "Seleccione una Obra.", Title = "Aviso" }.ShowDialog();
            }
        }

        private void abrirForm(bool nuevo, bool esTraspaso)
        {
            var form = new frmPagosNew(Controler);
            form.Text = esTraspaso ? ("Traspaso : Nuevo") : ("Abono : " + (nuevo ? "Nuevo" : "Editar"));
            if (!nuevo) form.pagos = pagos;
            form.tipoMovimientoId = esTraspaso ? TipoMovimientoEnum.Traspaso_Abono.Id : TipoMovimientoEnum.Abonos.Id;
            form.obra = this.obra;
            form.idCliente = this.cliente.Id;
            form.esTraspaso = esTraspaso;
            form.saldoFavor = this.saldoFavor;
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
                    newIva.Iva1 = IVA / 100;
                    newIva.FechaInicio = DateTime.Today;
                    newIva.FechaFin = null;
                    if (!(newIva.EntityState != EntityState.Added && newIva.EntityState != EntityState.Detached)) Controler.Model.AddToIva(newIva);
                    Controler.Model.SaveChanges();
                    new frmMessageBox(true) { Message = "Iva Guardado Exitosamente. ", Title = "Aviso" }.ShowDialog();
                    frmIngresos_Load(null, null);
                    luObra_EditValueChanged(sender, null);
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
                if (obra != null && cliente != null)
                    grid.DataSource = ingresos = Controler.Model.getDetalleIngresos(this.obra.Id, this.cliente.Id,false).ToList();
            }
            else
            {
                if (obra != null && cliente != null)
                    grid.DataSource = ingresos = Controler.Model.getDetalleIngresos(this.obra.Id, this.cliente.Id,false).Where(c => c.FechaCancelacion == null).ToList();
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
                    txtMantenimiento1.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPIni_Mantenimiento);
                    txtMantenimiento2.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPFin_Mantenimiento);
                    txtNA1.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPIni_NA);
                    txtNA2.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPFin_NA);
                    txtDescuentos1.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPIni_Descuento);
                    txtDescuentos2.Text = String.Format("{0:N2}", obra.PresupuestoDetalle.PPFin_Descuento);
                    // Obra Civil
                    //if (Convert.ToDouble(colNc.SummaryItem.SummaryValue) > 0 && Convert.ToDouble(colSaldo.SummaryItem.SummaryValue) < 0)
                    //    txtSubcontratistas3.Text = obra.PresupuestoDetalle.PPFin_Subcontratistas.Value > 0 ? (obra.PresupuestoDetalle.PPFin_Subcontratistas.Value - (Convert.ToDouble(colSubcontratistas.SummaryItem.SummaryValue))).ToString("c2") :
                    //        txtObraCivil3.Text = txtSubcontratistas3.Text = txtSuministros3.Text = txtExtras3.Text = txtTotal3.Text = "0.00";
                    //else
                    //{
                    txtObraCivil3.Text = obra.PresupuestoDetalle.PPFin_ObraCivil.HasValue
                            ? (obra.PresupuestoDetalle.PPFin_ObraCivil.Value - (Convert.ToDouble(colObraCivil.SummaryItem.SummaryValue))).ToString("c2") :
                            ((obra.PresupuestoDetalle.PPIni_Obra_Civil.HasValue ? obra.PresupuestoDetalle.PPIni_Obra_Civil.Value : 0) > 0 ?
                                (obra.PresupuestoDetalle.PPIni_Obra_Civil.Value - (Convert.ToDouble(colObraCivil.SummaryItem.SummaryValue))).ToString("c2") : String.Format("{0:c2}", colObraCivil.SummaryItem.SummaryValue));
                    // Subcontratistas
                    txtSubcontratistas3.Text = obra.PresupuestoDetalle.PPFin_Subcontratistas.HasValue
                        ? (obra.PresupuestoDetalle.PPFin_Subcontratistas.Value - (Convert.ToDouble(colSubcontratistas.SummaryItem.SummaryValue))).ToString("c2")
                        : (obra.PresupuestoDetalle.PPIni_Subcontratistas.HasValue ? obra.PresupuestoDetalle.PPIni_Subcontratistas.Value : 0) > 0 ?
                           (obra.PresupuestoDetalle.PPIni_Subcontratistas.Value - (Convert.ToDouble(colSubcontratistas.SummaryItem.SummaryValue))).ToString("c2") : String.Format("{0:c2}", colSubcontratistas.SummaryItem.SummaryValue);
                    // suministros
                    txtSuministros3.Text = obra.PresupuestoDetalle.PPFin_Suministros.HasValue ? (obra.PresupuestoDetalle.PPFin_Suministros.Value - (Convert.ToDouble(colSuministros.SummaryItem.SummaryValue))).ToString("c2")
                        : ((obra.PresupuestoDetalle.PPIni_Suministros.HasValue ? obra.PresupuestoDetalle.PPIni_Suministros.Value : 0) > 0 ?
                           (obra.PresupuestoDetalle.PPIni_Suministros.Value - (Convert.ToDouble(colSuministros.SummaryItem.SummaryValue))).ToString("c2") : String.Format("{0:c2}", colSuministros.SummaryItem.SummaryValue));
                    // Extras
                    txtExtras3.Text = obra.PresupuestoDetalle.PPFin_Extras.HasValue
                        ? (obra.PresupuestoDetalle.PPFin_Extras.Value - (Convert.ToDouble(colExtras.SummaryItem.SummaryValue))).ToString("c2")
                        : ((obra.PresupuestoDetalle.PPIni_Extras.HasValue ? obra.PresupuestoDetalle.PPIni_Extras.Value : 0) > 0
                            ? (obra.PresupuestoDetalle.PPIni_Extras.Value - (Convert.ToDouble(colExtras.SummaryItem.SummaryValue))).ToString("c2")
                            : String.Format("{0:c2}", colExtras.SummaryItem.SummaryValue));
                    //Mantenimiento
                    txtMantenimiento3.Text = obra.PresupuestoDetalle.PPFin_Mantenimiento.HasValue
                        ? (obra.PresupuestoDetalle.PPFin_Mantenimiento.Value - (Convert.ToDouble(colMantenimiento.SummaryItem.SummaryValue))).ToString("c2")
                        : (obra.PresupuestoDetalle.PPIni_Mantenimiento.HasValue ? obra.PresupuestoDetalle.PPIni_Mantenimiento.Value : 0) > 0
                            ? (obra.PresupuestoDetalle.PPIni_Mantenimiento.Value - (Convert.ToDouble(colMantenimiento.SummaryItem.SummaryValue))).ToString("c2")
                            : String.Format("{0:c2}", colMantenimiento.SummaryItem.SummaryValue);
                    //No Aplica
                    txtNA3.Text = obra.PresupuestoDetalle.PPFin_NA.HasValue
                        ? (obra.PresupuestoDetalle.PPFin_NA.Value - (Convert.ToDouble(colNA.SummaryItem.SummaryValue))).ToString("c2")
                        : ((obra.PresupuestoDetalle.PPIni_NA.HasValue ? obra.PresupuestoDetalle.PPIni_NA.Value : 0) > 0
                            ? (obra.PresupuestoDetalle.PPIni_NA.Value - (Convert.ToDouble(colNA.SummaryItem.SummaryValue))).ToString("c2")
                            : String.Format("{0:c2}", colNA.SummaryItem.SummaryValue));
                    //Descuento
                    txtDescuentos3.Text = obra.PresupuestoDetalle.PPFin_Descuento.HasValue
                           ? (obra.PresupuestoDetalle.PPFin_Descuento.Value - (obra.PresupuestoDetalle.PPIni_Descuento.Value > 0 ? obra.PresupuestoDetalle.PPIni_Descuento.Value : 0)).ToString("c2")
                           : ((obra.PresupuestoDetalle.PPIni_Descuento.HasValue ? obra.PresupuestoDetalle.PPIni_Descuento.Value : 0) > 0 ? obra.PresupuestoDetalle.PPIni_Descuento.Value : 0).ToString("c2");

                    txtObraCivil3.Text = convertirDouble(txtObraCivil3.Text).ToString("c2");
                    txtSubcontratistas3.Text = convertirDouble(txtSubcontratistas3.Text).ToString("c2");
                    txtSuministros3.Text = convertirDouble(txtSuministros3.Text).ToString("c2");
                    txtExtras3.Text = convertirDouble(txtExtras3.Text).ToString("c2");
                    txtMantenimiento3.Text = convertirDouble(txtMantenimiento3.Text).ToString("c2");
                    txtNA3.Text = convertirDouble(txtNA3.Text).ToString("c2");
                    txtDescuentos3.Text = convertirDouble(txtDescuentos3.Text).ToString("c2");
                    txtTotal3.Text = ((string.IsNullOrEmpty(txtObraCivil3.Text) ? 0 : getValue(txtObraCivil3.Text)) + (string.IsNullOrEmpty(txtSubcontratistas3.Text) ? 0 : getValue(txtSubcontratistas3.Text)) + (string.IsNullOrEmpty(txtSuministros3.Text) ? 0 : getValue(txtSuministros3.Text)) + (string.IsNullOrEmpty(txtExtras3.Text) ? 0 : getValue(txtExtras3.Text)) + (string.IsNullOrEmpty(txtMantenimiento3.Text) ? 0 : getValue(txtMantenimiento3.Text)) + (string.IsNullOrEmpty(txtNA3.Text) ? 0 : getValue(txtNA3.Text)) - (string.IsNullOrEmpty(txtDescuentos3.Text) ? 0 : getValue(txtDescuentos3.Text))).ToString("c2");
                    getTotalesPorCobrar(ingresos); // lleno seccion Por Cobrar
                    //}
                }
                else
                {
                    txtObraCivil4.Text = txtSuministros4.Text = txtSubcontratistas4.Text = txtExtras4.Text = txtMantenimiento4.Text = txtNA4.Text = txtDescuentos4.Text = txtTotal4.Text = txtObraCivil3.Text = txtSuministros3.Text = txtSubcontratistas3.Text = txtExtras3.Text = txtMantenimiento3.Text = txtNA3.Text = txtDescuentos3.Text = txtTotal3.Text = txtObraCivil1.Text = txtObraCivil2.Text = txtSuministros1.Text = txtSuministros2.Text = txtSubcontratistas1.Text = txtSubcontratistas2.Text = txtExtras1.Text = txtExtras2.Text = txtMantenimiento1.Text = txtMantenimiento2.Text = txtNA1.Text = txtNA2.Text = txtDescuentos1.Text = txtDescuentos2.Text = txtTotal1.Text = txtTotal2.Text = "0";
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
                    double saldoFavor = (totPagos - (totPPfinal > 0 ? totPPfinal : obra.PPInicial) - getTraspasos(obra.Id, cliente.Id, obra.Empresa.Id));
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
                form.factura = Controler.Model.Factura.FirstOrDefault(f => f.Id == item.Id);
                form.obra = this.obra;

                form.ShowDialog();
                frmIngresos_Load(null, null);
                luObra_EditValueChanged(sender, null);
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
                        luObra_EditValueChanged(sender, null);
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
                        presupuesto.PPIni_Mantenimiento = string.IsNullOrEmpty(txtMantenimiento1.Text) ? 0 : Convert.ToDouble(txtMantenimiento1.Text);
                        presupuesto.PPIni_NA = string.IsNullOrEmpty(txtNA1.Text) ? 0 : Convert.ToDouble(txtNA1.Text);
                        presupuesto.PPIni_Descuento = string.IsNullOrEmpty(txtDescuentos1.Text) ? 0 : Convert.ToDouble(txtDescuentos1.Text);
                        //PPFinal
                        presupuesto.PPFin_ObraCivil = string.IsNullOrEmpty(txtObraCivil2.Text) ? 0 : Convert.ToDouble(txtObraCivil2.Text);
                        presupuesto.PPFin_Subcontratistas = string.IsNullOrEmpty(txtSubcontratistas2.Text) ? 0 : Convert.ToDouble(txtSubcontratistas2.Text);
                        presupuesto.PPFin_Suministros = string.IsNullOrEmpty(txtSuministros2.Text) ? 0 : Convert.ToDouble(txtSuministros2.Text);
                        presupuesto.PPFin_Extras = string.IsNullOrEmpty(txtExtras2.Text) ? 0 : Convert.ToDouble(txtExtras2.Text);
                        presupuesto.PPFin_Mantenimiento = string.IsNullOrEmpty(txtMantenimiento2.Text) ? 0 : Convert.ToDouble(txtMantenimiento2.Text);
                        presupuesto.PPFin_NA = string.IsNullOrEmpty(txtNA2.Text) ? 0 : Convert.ToDouble(txtNA2.Text);
                        presupuesto.PPFin_Descuento = string.IsNullOrEmpty(txtDescuentos2.Text) ? 0 : Convert.ToDouble(txtDescuentos2.Text);
                        obra.PresupuestoDetalle = presupuesto;
                        if (!presupuesto.NoEsNuevo) Controler.Model.AddToPresupuestoDetalle(presupuesto);

                        Controler.Model.SaveChanges();
                        transaccion.Commit();
                        new frmMessageBox(true) { Message = "El Presupuesto ha sido Guardado Exitosamente.", Title = "Aviso" }.ShowDialog();
                        luObra_EditValueChanged(sender, null);
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
            luObra_EditValueChanged(sender, null);
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
            saldoFavor = convertirDouble(txtSaldoFavor.Text);
            if (saldoFavor > 0)
            {
                if (obra != null & gv.DataRowCount > 0)
                {
                    abrirForm(true, true);
                }
                else
                {
                    new frmMessageBox(true) { Message = "Seleccione una Obra.", Title = "Aviso" }.ShowDialog();
                }
            }
            else
            {
                new frmMessageBox(true) { Message = "El saldo debe ser mayor a 0 para poder Trasferir.", Title = "Aviso" }.ShowDialog();
            }
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            if (this.obra != null && this.cliente != null)
            {
                var form = new frmIngresosHistorialTraspasos(Controler);
                form.obra = this.obra;
                form.cliente = this.cliente;
                form.ShowDialog();

                frmIngresos_Load(null, null);
                luObra_EditValueChanged(null, null);
                gv_FocusedRowChanged(null, null);
            }


        }
    }
}
