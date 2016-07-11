using System;
using System.Collections.Generic;
using System.Linq;
using GeisaBD;
using System.Data;

namespace SistemaGEISA
{
    public partial class frmClienteNew : DevExpress.XtraEditors.XtraForm
    {
        private Controler controler { get; set; }
        public Cliente cliente { get; set; }
        private Domicilios domicilio { get; set; }
        public frmClienteNew(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;
        }
        private void llenaEstados()
        {
            lookupEstado.Properties.DataSource = controler.Model.Estado.ToList();
            lookupEstado.Properties.DisplayMember = "Nombre";
            lookupEstado.Properties.ValueMember = "Id";
        }
        private void llenaCiudad()
        {
            var estado = lookupEstado.GetSelectedDataRow() as Estado;

            if (estado != null)
            {
                lookupCiudad.Properties.DataSource = controler.Model.Ciudad.Where(C => C.EstadoId == estado.Id).ToList();
                lookupCiudad.Properties.DisplayMember = "Nombre";
                lookupCiudad.Properties.ValueMember = "Id";
            }
        }
        private bool isValid()
        {
            var areValid = true;
            var isValid = true;

            areValid &= controler.CheckEmptyText(txtNomComercial, txtNomFiscal, txtCalle, txtExterior, txtColonia, txtCodigoPostal);

            areValid &= isValid = lookupEstado.GetSelectedDataRow() != null;
            controler.SetError(lookupEstado, isValid ? string.Empty : "Seleccione un Estado");

            areValid &= isValid = lookupCiudad.GetSelectedDataRow() != null;
            controler.SetError(lookupCiudad, isValid ? string.Empty : "Seleccione un Ciudad");

            areValid &= isValid = rgRazonSocial.EditValue != null;
            controler.SetError(rgRazonSocial, isValid ? string.Empty : "Seleccione una Razon Socia");

            return areValid;
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            var form = new frmEstado();
            form.ShowDialog();

            if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                lookupCiudad.EditValue = null;
                lookupEstado.EditValue = null;
                llenaEstados();
            }

            form.Dispose();
        }
        private void btnCiudad_Click(object sender, EventArgs e)
        {
            var edo = lookupEstado.GetSelectedDataRow() as Estado;
            var form = new frmCiudad();
            form.edo = edo;
            form.ShowDialog();
            if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                lookupCiudad.EditValue = null;
                llenaCiudad();
            }

            form.Dispose();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string a = txtTelefono.Text;
            var error = string.Empty;
            var isNew = false;

            if (isValid())
            {
                if (cliente == null)
                {
                    cliente = new Cliente();
                    cliente.Activo = true;
                    isNew = true;
                }

                cliente.NombreComercial = txtNomComercial.Text.Trim();
                cliente.NombreFiscal = txtNomFiscal.Text.Trim();
                cliente.Email = txtMail.Text.Trim();
                cliente.RFC = txtRFC.Text.Trim();
                cliente.RazonSocial = Convert.ToInt32(rgRazonSocial.EditValue);               

                if (!cliente.NoEsNuevo)
                {
                    controler.Model.AddToCliente(cliente);
                }
                try
                {
                    controler.Model.SaveChanges();

                    if (cliente.Domicilio==null)
                    {
                        domicilio = new Domicilios();
                        domicilio.Tipo = TipoCatalogo.CLIENTE;
                        domicilio.CatalogoId = cliente.Id;
                        domicilio.Activo = true;
                    }

                    domicilio.Calle = txtCalle.Text.Trim();
                    domicilio.Exterior = txtExterior.Text.Trim();
                    domicilio.Interior = txtInterior.Text.Trim();
                    domicilio.Colonia = txtColonia.Text.Trim();
                    domicilio.Ciudad = controler.GetObjectFromContext(lookupCiudad.GetSelectedDataRow() as Ciudad);
                    domicilio.CodigoPostal = txtCodigoPostal.Text.Trim();
                    domicilio.Telefono = txtTelefono.Text.Trim();
                    domicilio.Celular = txtCelular.Text.Trim();

                    if (!domicilio.NoEsNuevo)
                    {
                        controler.Model.AddToDomicilios(domicilio);
                    }
                    try
                    {
                        controler.Model.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
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
                        message = string.IsNullOrEmpty(error) ? string.Concat("El Cliente ha sido actualizado exitosamente.") : string.Concat("No se pudo actualizar el Cliente:\n", error);
                    }
                    else
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("El Cliente ha sido generado exitosamente.") : string.Concat("No se pudo generar el Cliente:\n", error);
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

        private void lookupEstado_EditValueChanged(object sender, EventArgs e)
        {
            llenaCiudad();
        }
        private void frmClienteNew_Load(object sender, EventArgs e)
        {
            llenaEstados();

            if (cliente != null)
            {
                txtNomComercial.Text = cliente.NombreComercial;
                txtNomFiscal.Text = cliente.NombreFiscal;
                txtMail.Text = cliente.Email;
                txtRFC.Text = cliente.RFC;
                rgRazonSocial.EditValue = cliente.RazonSocial;
                domicilio = controler.GetObjectFromContext(cliente.Domicilio);

                if (domicilio != null)
                {
                    txtCalle.Text = domicilio.Calle;
                    txtExterior.Text = domicilio.Exterior;
                    txtInterior.Text = domicilio.Interior;
                    txtColonia.Text = domicilio.Colonia;
                    lookupEstado.SelectedText = domicilio.CiudadLoaded.EstadoNombre;
                    lookupCiudad.SelectedText = domicilio.CiudadNombre;
                    txtCodigoPostal.Text = domicilio.CodigoPostal;
                    txtTelefono.Text = domicilio.Telefono;
                    txtCelular.Text = domicilio.Celular;
                }
            }
        }
    }
}
