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

namespace SistemaGEISA
{
    public partial class frmAsignarCredito : DevExpress.XtraEditors.XtraForm
    {
         private Controler controler { get; set; }
        public Bancos banco { get; set; }

        public VehiculoCajaChicaDetalle vehiculoCajaChicaDetalle { get; set; }

        public VehiculoCajaChica vehiculoCajaChica { get; set; }
        private bool isValid()
        {
            var areValid = true;
            areValid &= controler.CheckEmptyText(txtNombre);
            return areValid;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var error = string.Empty;
            var isNew = false;

            if (isValid())
            {
                if (vehiculoCajaChicaDetalle == null) 
                {
                    vehiculoCajaChicaDetalle = new VehiculoCajaChicaDetalle();
                    isNew = true;
                }
                if (banco == null)
                {
                    banco = new Bancos();
                    isNew = true;
                }

                //vehiculoCajaChicaDetalle.AsignacionCredito = Convert.ToDouble(txtNombre.Text.Trim());
                vehiculoCajaChicaDetalle.VehiculoCajaChica = vehiculoCajaChica;

                if (isNew) 
                {
                    controler.Model.AddToVehiculoCajaChicaDetalle(vehiculoCajaChicaDetalle);
                }
                try
                {
                    controler.Model.SaveChanges();
                }
                catch (Exception ex)
                {
                    error = ex.InnerException.Message;
                }
                finally
                {
                    var title = string.IsNullOrEmpty(error) ? "Confirmación" : "Error";
                    var message = string.Empty;

                    if (!isNew)
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("El Crédito ha sido actualizado exitosamente.") : string.Concat("No se pudo actualizar:\n", error);
                    }
                    else
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("El Crédito ha sido asignado exitosamente.") : string.Concat("No se pudo asignar el Crédito:\n", error);
                    }

                    new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();
                }

                if (string.IsNullOrEmpty(error))
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
        }

        public frmAsignarCredito(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;
        }
    }
}