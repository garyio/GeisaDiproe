using System;
using System.Collections.Generic;
using System.Linq;
using GeisaBD;

namespace SistemaGEISA
{
    public partial class frmBancoNew : DevExpress.XtraEditors.XtraForm
    {
        private Controler controler { get; set; }
        public Bancos banco { get; set; }
        public frmBancoNew(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;
        }

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
                if (banco == null)
                {
                    banco = new Bancos();
                    isNew = true;
                }

                banco.Nombre = txtNombre.Text.Trim();
                if (!banco.NoEsNuevo)
                {
                    controler.Model.AddToBancos(banco);
                }
                try
                {
                    controler.Model.SaveChanges();
                }
                catch (Exception ex)
                {
                    error = ex.GetBaseException().Message;
                }
                finally
                {
                    var title = string.IsNullOrEmpty(error) ? "Confirmación" : "Error";
                    var message = string.Empty;

                    if (!isNew)
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("El Banco ha sido actualizado exitosamente.") : string.Concat("No se pudo actualizar el Banco:\n", error);
                    }
                    else
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("El Banco ha sido generado exitosamente.") : string.Concat("No se pudo generar el Banco:\n", error);
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

        private void frmBancoNew_Load(object sender, EventArgs e)
        {
            if (banco != null)
            {
                txtNombre.Text = banco.Nombre;
            }
        }
    }
}
