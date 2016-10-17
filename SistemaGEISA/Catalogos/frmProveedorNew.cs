using System;
using System.Collections.Generic;
using System.Linq;
using GeisaBD;
using System.Data;

namespace SistemaGEISA
{
    public partial class frmProveedorNew : DevExpress.XtraEditors.XtraForm
    {
        private Controler controler { get; set; }
        public Proveedor proveedor { get; set; }
        public ProveedorBancos proveedorBancos { get; set; }
        private Domicilios domicilio { get; set; }
        DataTable dt;
        public frmProveedorNew(Controler _controler)
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

            areValid &= controler.CheckEmptyText(txtRFC,txtNomComercial, txtNomFiscal, txtCalle, txtExterior, txtColonia, txtCodigoPostal);

            areValid &= isValid = lookupEstado.GetSelectedDataRow() != null;
            controler.SetError(lookupEstado, isValid ? string.Empty : "Seleccione un Estado");

            areValid &= isValid = lookupCiudad.GetSelectedDataRow() != null;
            controler.SetError(lookupCiudad, isValid ? string.Empty : "Seleccione un Ciudad");
            //Validando RFC
            areValid &= isValid = ValidaRFC();
            controler.SetError(txtRFC, isValid ? string.Empty : "El RFC ya existe, Favor de Verificar");

            areValid &= isValid = rgRazonSocial.EditValue != null;
            controler.SetError(rgRazonSocial, isValid ? string.Empty : "Seleccione una Razon Socia");

            return areValid;
        }

        private bool ValidaRFC()
        {
            if (this.proveedor != null)
            {
                int rfcs = controler.Model.Proveedor.Where(p => p.RFC == txtRFC.Text.Trim() && p.Id != proveedor.Id).Count();
                if (rfcs == 0)
                    return true;
                else
                    return false;
            }
            else
            {
                int rfcs = controler.Model.Proveedor.Where(p => p.RFC == txtRFC.Text.Trim()).Count();
                if (rfcs == 0)
                    return true;
                else
                    return false;
            }
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
            gv.CloseEditor();
            gv.UpdateCurrentRow();

            var error = string.Empty;
            var isNew = false;

            if (isValid())
            {
                if (proveedor == null)
                {
                    proveedor = new Proveedor();
                    proveedor.Activo = true;
                    isNew = true;
                }

                proveedor.NombreComercial = txtNomComercial.Text.Trim();
                proveedor.NombreFiscal = txtNomFiscal.Text.Trim();
                proveedor.Email = txtMail.Text.Trim();
                proveedor.RFC = txtRFC.Text.Trim();
                proveedor.RazonSocial = Convert.ToInt32(rgRazonSocial.EditValue);
                proveedor.PlazoCredito = Convert.ToInt32(spinPlazoCredito.EditValue);

                if (!proveedor.NoEsNuevo)
                {
                    controler.Model.AddToProveedor(proveedor);
                }
                try
                {
                    controler.Model.SaveChanges();

                    if (proveedor.Domicilio==null)
                    {
                        domicilio = new Domicilios();
                        domicilio.Tipo = TipoCatalogo.PROVEEDOR;
                        domicilio.CatalogoId = proveedor.Id;
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
                        if (gv.DataRowCount > 0)
                        {
                            for (var i = 0; i < gv.RowCount - 1; i++)
                            {
                                var row = gv.GetDataRow(i);

                                if (!Convert.IsDBNull(row["Id"]))
                                {
                                    var id = Convert.ToInt32(row["Id"]);
                                    proveedorBancos = controler.Model.ProveedorBancos.Where(D => D.Id == id).FirstOrDefault();
                                }
                                else
                                {
                                    proveedorBancos = new ProveedorBancos();
                                }

                                proveedorBancos.Proveedor = controler.GetObjectFromContext(proveedor);
                                proveedorBancos.BancosId = Convert.ToInt32(row["BancosId"]);
                                proveedorBancos.NoCuenta = row["NoCuenta"].ToString();
                                proveedorBancos.CLABE = row["CLABE"].ToString();


                                if (!proveedorBancos.NoEsNuevo)
                                {
                                    controler.Model.AddToProveedorBancos(proveedorBancos);
                                }
                            }
                        }

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
                        message = string.IsNullOrEmpty(error) ? string.Concat("El Proveedor ha sido actualizado exitosamente.") : string.Concat("No se pudo actualizar el Proveedor:\n", error);
                    }
                    else
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("El Proveedor ha sido generado exitosamente.") : string.Concat("No se pudo generar el Proveedor:\n", error);
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
        private void frmEmpresaNew_Load(object sender, EventArgs e)
        {
            llenaEstados();
            llenaGrid();
            llenaBancos();
            if (proveedor != null)
            {
                txtNomComercial.Text = proveedor.NombreComercial;
                txtNomFiscal.Text = proveedor.NombreFiscal;
                txtMail.Text = proveedor.Email;
                txtRFC.Text = proveedor.RFC;
                rgRazonSocial.EditValue = proveedor.RazonSocial;
                domicilio = controler.GetObjectFromContext(proveedor.Domicilio);
                spinPlazoCredito.EditValue = proveedor.PlazoCredito.HasValue ? proveedor.PlazoCredito.Value : 7;                  

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
                obtenerProveedorBancos();
                llenaBancos();
            }
        }
        private void llenaBancos()
        {
            LookUpBancos.DataSource = controler.Model.Bancos.ToList();
            LookUpBancos.DisplayMember = "Nombre";
            LookUpBancos.ValueMember = "Id";
        }
        private void obtenerProveedorBancos()
        {
            if (dt.Rows.Count > 0)
            {
                dt.Rows.Clear();
            }
            foreach (ProveedorBancos serv in controler.Model.ProveedorBancos.Where(D => D.ProveedorId  == proveedor.Id).ToList())
            {
                gv.AddNewRow();
                var newRowHandle = gv.FocusedRowHandle;

                gv.SetRowCellValue(newRowHandle, "Id", serv.Id);
                gv.SetRowCellValue(newRowHandle, "ProveedorId", serv.ProveedorId);
                gv.SetRowCellValue(newRowHandle, "BancosId", serv.BancosId);
                gv.SetRowCellValue(newRowHandle, "NoCuenta", serv.NoCuenta);
                gv.SetRowCellValue(newRowHandle, "CLABE", serv.CLABE);
                gv.UpdateCurrentRow();
                gv.RefreshData();
            }
        }
        private void llenaGrid()
        {
            dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("ProveedorId", typeof(int));
            dt.Columns.Add("BancosId", typeof(int));
            dt.Columns.Add("NoCuenta", typeof(string));
            dt.Columns.Add("CLABE", typeof(string));
            
            grid.DataSource = dt;
        }

        private void txtCodigoPostal_TabIndexChanged(object sender, EventArgs e)
        {
            txtCodigoPostal.Select(0, 0);
        }

        private void txtTelefono_TabIndexChanged(object sender, EventArgs e)
        {
            txtTelefono.Select(0, 0);
        }

        private void txtCelular_TabIndexChanged(object sender, EventArgs e)
        {
            txtCelular.Select(0, 0);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtRFC_Leave(object sender, EventArgs e)
        {
            if (ValidaRFC() == false)
            {
                new frmMessageBox(true) { Message = "RFC En uso, Favor de Verificar.", Title = "Aviso" }.ShowDialog();
            }
        }
    }
}
