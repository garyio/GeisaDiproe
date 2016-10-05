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
using DevExpress.XtraEditors;
using System.Data.Common;

namespace SistemaGEISA
{
    public partial class frmBancosIngresos : XtraForm
    {
        public int EmpresaId;
        public int BancoId;
        public Controler controler { get; set; }
        public int mes { get; set; }
        public int año { get; set; }
        public Pagos pagos { get; set; }

        public frmBancosIngresos(Controler _controler)
        {
            InitializeComponent();
            controler = _controler ?? new Controler();
        }

        private void frmBancosIngresos_Load(object sender, EventArgs e)
        {
            if (pagos != null)
            {
                dtFecha.EditValue = pagos.FechaPago;
                txtFolio.Text = pagos.Folio.ToString();
                if (pagos.ProveedorId.HasValue){
                    rbProveedor.Checked = true;
                    luNombre.EditValue = pagos.ProveedorId;
                }
                else{
                    rbCliente.Checked = true;
                    luNombre.EditValue = pagos.ClienteId;
                }
                txtConcepto.Text = pagos.Observaciones;
                txtImporte.Text = String.Format("{0:0,0.00}", pagos.MontoPagar);
                ckComision.Checked = pagos.TipoMovimientoId == TipoMovimientoEnum.Comisiones.Id ? true : false;
            }
            else
            {
                dtFecha.EditValue = new DateTime(año, mes, 1);
            }
        }

        private void rbProveedor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbProveedor.Checked == true)
            {
                luNombre.Properties.DataSource = controler.Model.Proveedor.Where(D => D.Activo == true).ToList();
                luNombre.Properties.DisplayMember = "NombreComercial";
                luNombre.Properties.ValueMember = "Id";

            }
        }

        private void rbCliente_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCliente.Checked == true)
            {
                luNombre.Properties.DataSource = controler.Model.Cliente.Where(D => D.Activo == true).ToList();
                luNombre.Properties.DisplayMember = "NombreComercial";
                luNombre.Properties.ValueMember = "Id";

            }
        }

        private Boolean isValid()
        {
            bool areValid = true;
            bool isValid = true;

            areValid &= isValid = string.IsNullOrEmpty(txtConcepto.Text) ? false : true;
            controler.SetError(txtConcepto, isValid ? string.Empty : "Valor Obligatorio, Favor de Seleccionar.");

            areValid &= isValid = luNombre.GetSelectedDataRow() == null ? false : true;
            controler.SetError(luNombre, isValid ? string.Empty : "Valor Obligatorio, Favor de Seleccionar.");

            areValid &= isValid = string.IsNullOrEmpty(txtImporte.Text) ? false : true;
            controler.SetError(txtImporte, isValid ? string.Empty : "Valor Obligatorio, Favor de Seleccionar.");

            double importe;
            areValid &= isValid = double.TryParse(txtImporte.Text,out importe) ? true : false;
            controler.SetError(txtImporte, isValid ? string.Empty : "Valor Obligatorio, Favor de Ingresar.");

            return areValid; 

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
                        isNew = true;
                    }
                    pagos.Fecha = DateTime.Now;
                    if(!string.IsNullOrEmpty(txtFolio.Text))
                        pagos.Folio = Convert.ToInt32(txtFolio.Text);
                    pagos.FechaPago = (DateTime)dtFecha.EditValue;
                    if (rbCliente.Checked)
                        pagos.ClienteId = (luNombre.GetSelectedDataRow() as Cliente).Id;
                    else
                        pagos.ProveedorId = (luNombre.GetSelectedDataRow() as Proveedor).Id;
                    pagos.Observaciones = txtConcepto.Text;
                    pagos.EmpresaId = EmpresaId;
                    pagos.EmpresaBancosId = BancoId;
                    pagos.MontoPagar = Convert.ToDouble(txtImporte.Text);
                    pagos.TipoMovimientoId = ckComision.Checked ? TipoMovimientoEnum.Comisiones.Id : TipoMovimientoEnum.OtrosIngresos.Id;
                    pagos.TipoPagoId = TipoPagoEnum.NoAplica.Id;
                    pagos.FacturasPagadas = ckComision.Checked ? "COMISIONES" : "OTROS INGRESOS";
                    pagos.enTransito = true;
                    if (!pagos.NoEsNuevo) controler.Model.AddToPagos(pagos);
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

                    if (!isNew)
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("El Ingreso ha sido actualizado exitosamente.") : string.Concat("No se pudo actualizar el Ingreso:\n", error);
                    }
                    else
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("El Ingreso ha sido generado exitosamente.") : string.Concat("No se pudo generar el Ingreso:\n", error);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (pagos != null)
            {
                try
                {
                    pagos.FechaCancelacion = DateTime.Today;
                    controler.Model.SaveChanges();
                    new frmMessageBox(true) { Message = "Ingreso Cancelado Exitosamente.", Title = "Confirmación." }.ShowDialog();
                    this.Close();
                }
                catch (Exception ex)
                {
                    new frmMessageBox(true) { Message = string.Concat("No es Posible Cancelar este Abono, Favor de Verificar\n",ex.InnerException.Message), Title = "Error." }.ShowDialog();
                    return;
                }
            }
            else
            {
                new frmMessageBox(true) { Message = "No es Posible Cancelar este Abono, Favor de Verificar", Title = "Error." }.ShowDialog();
                return;
            }
        }
    }
}
