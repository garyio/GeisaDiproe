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
    public partial class frmConceptosNew : DevExpress.XtraEditors.XtraForm
    {
        private Controler controler { get; set; }
        public Conceptos conceptos { get; set; }
        public frmConceptosNew(Controler _controler)
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
                if (conceptos == null)
                {
                    conceptos = new Conceptos();
                    isNew = true;
                }

                conceptos.Nombre = txtNombre.Text.Trim();
                if (!conceptos.NoEsNuevo)
                {
                    controler.Model.AddToConceptos(conceptos);
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
                        message = string.IsNullOrEmpty(error) ? string.Concat("El Concepto ha sido actualizado exitosamente.") : string.Concat("No se pudo actualizar el Concepto:\n", error);
                    }
                    else
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("El Concepto ha sido generado exitosamente.") : string.Concat("No se pudo generar el Concepto:\n", error);
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

        private void frmConceptosNew_Load(object sender, EventArgs e)
        {
            if (conceptos != null)
            {
                txtNombre.Text = conceptos.Nombre;
            }
        }
    }
}