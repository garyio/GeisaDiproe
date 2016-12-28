using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GeisaBD;

namespace SistemaGEISA
{
    public partial class frmNominasExtras : DevExpress.XtraEditors.XtraForm
    {
        public int opcion;

        enum tipoCargo
        {
            Extras = 1,
            Pagos = 2,
            Viaticos = 3,
            Faltas = 4
        };

        public Obra obra;

        public Empleado empleado;

        public Nominas nominas;

        public NominaItem nominasDetalle;

        private EmpleadoNomina empleadoNomina;
        public Controler controler { get; set; }

        public List<NominaItem> detalleNominas = new List<NominaItem>();

        public frmNominasExtras(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;
        }

        private void frmNominasExtras_Load(object sender, EventArgs e)
        {
            luObra.Properties.DataSource = controler.Model.Obra.ToList();
            luObra.Properties.DisplayMember = "Nombre";
            luObra.Properties.ValueMember = "Id";

            if (nominasDetalle != null)
            {
                rgDiasHoras.EditValue = nominasDetalle.NumeroDiasHoras.HasValue ? nominasDetalle.NumeroDiasHoras.Value : 1;
                dtFecha.EditValue = nominasDetalle.FechaDetalle.Value;
                luObra.EditValue = nominasDetalle.ObraId.HasValue ? nominasDetalle.ObraId.Value : (int?)null;
                spinDiasHoras.EditValue = nominasDetalle.NumeroDiasHoras.HasValue ? nominasDetalle.NumeroDiasHoras.Value : (int?)null;
                txtMonto.Text = nominasDetalle.Monto.HasValue ? Math.Abs(nominasDetalle.Monto.Value).ToString("N2") : "0.00";
                txtObservaciones.Text = nominasDetalle.Observaciones;

            }
            else
            {
                rgDiasHoras.EditValue = 1;
                dtFecha.EditValue = DateTime.Today;
                txtMonto.Text = "0.00";
                txtObservaciones.Text = string.Empty;
                spinDiasHoras.EditValue = 1;
                luObra.EditValue = (this.obra != null ? this.obra.Id : (int?)null);
               
            }

            if (empleado != null)
            {
                empleadoNomina = controler.Model.EmpleadoNomina.FirstOrDefault(X => X.EmpleadoId == this.empleado.Id);
                rgDiasHoras_EditValueChanged(null, null);
                //lblDiaHoras.Text = Convert.ToInt32(rgDiasHoras.EditValue) == 1 ? (empleadoNomina.MontoHoraExtra.HasValue ? empleadoNomina.MontoHoraExtra.Value.ToString("c2") : "0.00") : (empleadoNomina.EmpleadoHistorial.FirstOrDefault(E => E.FechaFin == null) != null ? (empleadoNomina.EmpleadoHistorial.FirstOrDefault(E => E.FechaFin == null).Sueldo.Value / 7).ToString("c2") : "0.00");

            }
            else
            {
                lblDiaHoras.Text = "0.00";
                empleadoNomina = null;
            }

        }

        public void limpiar()
        {
            nominasDetalle = null;
            frmNominasExtras_Load(null, null);
        }

        private void rgDiasHoras_EditValueChanged(object sender, EventArgs e)
        {
            if(empleado!=null && empleadoNomina != null)
                lblDiaHoras.Text = Convert.ToInt32(rgDiasHoras.EditValue) == 1 
                    ? (empleadoNomina.MontoHoraExtra.HasValue ? empleadoNomina.MontoHoraExtra.Value.ToString("c2") : "0.00" ) 
                    : (empleadoNomina.EmpleadoHistorial.Where(E => E.FechaFin == null).Select(I => I.Sueldo).DefaultIfEmpty(0).SingleOrDefault().Value / 7).ToString("c2");
            else
                lblDiaHoras.Text = "$0.00";
            spinDiasHoras_EditValueChanged(null, null);
        }

        private bool isValid()
        {
            var areValid = true;
            var isValid = true;

            areValid &= isValid = rgDiasHoras.EditValue != null ? true : false;
            controler.SetError(rgDiasHoras, isValid ? string.Empty : "Valor Obligatorio.");

            areValid &= isValid = dtFecha.EditValue != null ? true : false;
            controler.SetError(dtFecha, isValid ? string.Empty : "Valor Obligatorio.");

            double monto;
            if (double.TryParse(txtMonto.Text, out monto))
            {
                if (monto > 0)
                    areValid &= isValid = true;
                else
                    areValid &= isValid = false;

            }
            else
                areValid &= isValid = false;

            controler.SetError(txtMonto, isValid ? string.Empty : "Valor Obligatorio.");

            areValid &= isValid = string.IsNullOrEmpty(txtMonto.Text) ? false : true;
            controler.SetError(txtMonto, isValid ? string.Empty : "Valor Obligatorio.");

            //areValid &= isValid = string.IsNullOrEmpty(txtObservaciones.Text) ? false : true;
            //controler.SetError(txtObservaciones, isValid ? string.Empty : "Valor Obligatorio.");

            areValid &= isValid = luObra.EditValue ==null ? false : true;
            controler.SetError(luObra, isValid ? string.Empty : "Valor Obligatorio.");

            return areValid;

        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.soloNumerosDec(sender, e);
        }

        private void txtMonto_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMonto.Text))
                txtMonto.Text = Convert.ToDouble(txtMonto.Text).ToString("N2"); 
        }

        private void btnGuardarNuevo_Click(object sender, EventArgs e)
        {
            btnGuardar_Click(sender, e);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var error = string.Empty;
            var isNew = nominasDetalle == null ? true : false;
            var SaveAndNew = sender.ToString() == "Guardar y Nuevo" ? true : false;

            if (isValid())
            {
                try
                {
                    if (nominasDetalle == null)
                    {
                        nominasDetalle = new NominaItem();
                        isNew = true;
                    }
                    nominasDetalle.TipoCargoId = opcion;
                    nominasDetalle.FechaDetalle = (DateTime)dtFecha.EditValue;
                    nominasDetalle.Monto = Convert.ToDouble(txtMonto.Text);
                    nominasDetalle.ObraId = Convert.ToInt32(luObra.EditValue);
                    nominasDetalle.NumeroDiasHoras = Convert.ToInt32(spinDiasHoras.EditValue);
                    nominasDetalle.Observaciones = txtObservaciones.Text.ToUpper();
                    nominasDetalle.EsDiaHora = Convert.ToInt32(rgDiasHoras.EditValue);// 1 hora, 2 dia
                    detalleNominas.Add(nominasDetalle);

                }
                catch (Exception ex)
                {
                    new frmMessageBox(true) { Message = "Error al guardar el Registro: \n" + ex.InnerException, Title = "Error" }.ShowDialog();
                    error = ex.GetBaseException().Message;
                }
                finally
                {
                    var title = string.IsNullOrEmpty(error) ? "Confirmación" : "Error";
                    var message = string.Empty;

                    message = string.IsNullOrEmpty(error) ? (isNew ? string.Concat("Registro generado exitosamente.") : string.Concat("Registro Actualizado Exitosamente.")) : string.Concat("No se pudo generar:\n", error);
                    new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();
                }


                if (string.IsNullOrEmpty(error) && !SaveAndNew)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Hide();
                }
                else
                {
                    limpiar();
                }
            }
        }

        private void spinDiasHoras_EditValueChanged(object sender, EventArgs e)
        {
            if (empleadoNomina != null)
            {
                int diasHoras = Convert.ToInt32(spinDiasHoras.EditValue);
                double cobroDiasHoras=0;
                if (empleado != null && empleadoNomina != null)
                {                    
                        cobroDiasHoras = Convert.ToInt32(rgDiasHoras.EditValue) == 1
                            ? (empleadoNomina.MontoHoraExtra.HasValue ? empleadoNomina.MontoHoraExtra.Value : 0)
                            : (empleadoNomina.EmpleadoHistorial.Where(E => E.FechaFin == null).Select(I => I.Sueldo).DefaultIfEmpty(0).SingleOrDefault().Value / 7);
                }else
                    cobroDiasHoras = 0;

                txtMonto.Text = (diasHoras * cobroDiasHoras).ToString("N2");
            }

        }
    }
}
