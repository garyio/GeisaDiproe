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
using System.Data.Common;

namespace SistemaGEISA
{
    public partial class frmNominasOtrosExtras : DevExpress.XtraEditors.XtraForm
    {

        public int opcion;

        enum tipoCargo
        {
            Extras = 1,
            Pagos = 2,
            Viaticos = 3,
            Faltas = 4,
            Vacaciones = 5
        };

        public Nominas nominas;

        public NominaItem nominasDetalle;
        public Controler controler { get; set; }

        public List<NominaItem> detalleNominas = new List<NominaItem>();

        public Obra obra;

        public frmNominasOtrosExtras(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;
        }

        private void frmNominasOtrosExtras_Load(object sender, EventArgs e)
        {
            if (nominasDetalle != null)
            {
                if (nominasDetalle.CargoDeduccion.HasValue)
                    rgTipoNomina.EditValue = nominasDetalle.CargoDeduccion.Value;
                dtFecha.EditValue = nominasDetalle.FechaDetalle.Value;
                txtMonto.Text = nominasDetalle.Monto.HasValue ? Math.Abs(nominasDetalle.Monto.Value).ToString("N2") : "0.00";
                txtObservaciones.Text = nominasDetalle.Observaciones;

            }
            else
            {

                rgTipoNomina.EditValue = 1;
                dtFecha.EditValue= DateTime.Today;
                txtMonto.Text = "0.00";
            }
            
        }

        public void limpiar()
        {
            dtFecha.EditValue = DateTime.Today;
            rgTipoNomina.EditValue = 1;
            txtMonto.Text = "0.00";
            txtObservaciones.Text = string.Empty;
            nominasDetalle = null;
        }

        private bool isValid()
        {
            var areValid = true;
            var isValid = true;

            if(opcion==Convert.ToInt32(tipoCargo.Pagos))
            {
                areValid &= isValid = rgTipoNomina.EditValue != null? true : false;
                controler.SetError(rgTipoNomina, isValid ? string.Empty : "Valor Obligatorio.");
            }

            areValid &= isValid = dtFecha.EditValue != null ? true : false;
            controler.SetError(dtFecha, isValid ? string.Empty : "Valor Obligatorio.");

            double monto;
            if (opcion != Convert.ToInt32(tipoCargo.Vacaciones))
            {
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
            }

            //areValid &= isValid = string.IsNullOrEmpty(txtObservaciones.Text) ? false : true;
            //controler.SetError(txtObservaciones, isValid ? string.Empty : "Valor Obligatorio.");                     

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
                    if (rgTipoNomina.Visible)
                        nominasDetalle.Monto = Convert.ToInt32(rgTipoNomina.EditValue) == 1 ? (Convert.ToDouble(txtMonto.Text) * -1) : Convert.ToDouble(txtMonto.Text);
                    else
                    {
                        if (opcion == Convert.ToInt32(tipoCargo.Faltas))
                            nominasDetalle.Monto = Convert.ToDouble(txtMonto.Text) * -1;
                        else
                            nominasDetalle.Monto = Convert.ToDouble(txtMonto.Text);
                    }

                    nominasDetalle.Observaciones = txtObservaciones.Text.ToUpper();
                    if (opcion == Convert.ToInt32(tipoCargo.Pagos))
                        nominasDetalle.CargoDeduccion = Convert.ToInt32(rgTipoNomina.EditValue);

                    detalleNominas.Add(nominasDetalle);

                }
                catch (Exception ex)
                {
                    new frmMessageBox(true) { Message = "Error al guardar el Registro: \n" + ex.InnerException, Title = "Error" }.ShowDialog();
                    error = ex.InnerException.Message;
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
                    frmNominasOtrosExtras_Load(null, null);
                }
            }
        }

        private void btnGuardarNuevo_Click_1(object sender, EventArgs e)
        {
            btnGuardar_Click(sender, e);
        }
    }
}
