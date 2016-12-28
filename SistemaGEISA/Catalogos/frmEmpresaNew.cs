using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using GeisaBD;
using System.Drawing;

namespace SistemaGEISA
{
    public partial class frmEmpresaNew : DevExpress.XtraEditors.XtraForm
    {
        private Controler controler { get; set; }

        public Empresa empresa { get; set; }

        private Domicilios domicilio { get; set; }

        private EmpresaBancos empresaBancos { get; set; }
        private DataTable dt;

        public frmEmpresaNew(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;
        }

        private void frmEmpresaNew_Load(object sender, EventArgs e)
        {
            llenaEstados();
            llenaGrid();
            if (empresa != null)
            {
                txtNomComercial.Text = empresa.NombreComercial;
                txtNomFiscal.Text = empresa.NombreFiscal;
                txtMail.Text = empresa.Email;
                txtRFC.Text = empresa.RFC;
                if (empresa.Imagen != null) cbImagen.Image = Funciones.ArrayAImage(empresa.Imagen);

                domicilio = controler.GetObjectFromContext(empresa.Domicilio);

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
                obtenerEmpresaBancos();
                llenaBancos();
            }
        }

        #region Funciones
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

            //Validando RFC
            areValid &= isValid = ValidaRFC();
            controler.SetError(txtRFC, isValid ? string.Empty : "El RFC ya existe, Favor de Verificar");

            return areValid;
        }

        private void llenaBancos()
        {
            LookUpBancos.DataSource = controler.Model.Bancos.ToList();
            LookUpBancos.DisplayMember = "Nombre";
            LookUpBancos.ValueMember = "Id";
        }

        private void obtenerEmpresaBancos()
        {
            if (dt.Rows.Count > 0)
            {
                dt.Rows.Clear();
            }
            foreach (EmpresaBancos serv in controler.Model.EmpresaBancos.Where(D => D.EmpresaId == empresa.Id).ToList())
            {
                gv.AddNewRow();
                var newRowHandle = gv.FocusedRowHandle;

                gv.SetRowCellValue(newRowHandle, "Id", serv.Id);
                gv.SetRowCellValue(newRowHandle, "EmpresaId", serv.EmpresaId);
                gv.SetRowCellValue(newRowHandle, "BancosId", serv.BancosId);
                gv.SetRowCellValue(newRowHandle, "NoCuenta", serv.NoCuenta);
                gv.SetRowCellValue(newRowHandle, "CLABE", serv.CLABE);
                gv.SetRowCellValue(newRowHandle, "Sucursal", serv.Sucursal);
                gv.SetRowCellValue(newRowHandle, "FolioInicial", serv.FolioInicial);
                gv.SetRowCellValue(newRowHandle, "FolioActual", serv.FolioActual);

                gv.UpdateCurrentRow();
                gv.RefreshData();
            }
        }

        private void llenaGrid()
        {
            dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("EmpresaId", typeof(int));
            dt.Columns.Add("BancosId", typeof(int));
            dt.Columns.Add("NoCuenta", typeof(string));
            dt.Columns.Add("CLABE", typeof(string));
            dt.Columns.Add("Sucursal", typeof(string));
            dt.Columns.Add("FolioInicial", typeof(int));
            dt.Columns.Add("FolioActual", typeof(int));

            grid.DataSource = dt;
        }
        #endregion

        #region Controles
        private void lookupEstado_EditValueChanged(object sender, EventArgs e)
        {
            llenaCiudad();
        }

        private void cbImagen_Click(object sender, EventArgs e)
        {
            dialog.Filter = "Todos los archivos de Imagen (*.gif;*.bmp;*.jpg;*.png)|*.gif;*.bmp;*.jpg;*.png";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                cbImagen.Image = Image.FromFile(dialog.FileName);
            }
        }
        #endregion

        #region Botones
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
            var error = string.Empty;
            var isNew = false;

            if (isValid())
            {
                if (empresa == null)
                {
                    empresa = new Empresa();
                    empresa.Activo = true;
                    isNew = true;
                }

                empresa.NombreComercial = txtNomComercial.Text.Trim();
                empresa.NombreFiscal = txtNomFiscal.Text.Trim();
                empresa.Email = txtMail.Text.Trim();
                empresa.RFC = txtRFC.Text.Trim();
                if (cbImagen.Image != null) empresa.Imagen = Funciones.ImageAArray(cbImagen.Image);

                if (!empresa.NoEsNuevo)
                {
                    controler.Model.AddToEmpresa(empresa);
                }
                try
                {
                    controler.Model.SaveChanges();

                    if (isNew)
                    {
                        domicilio = new Domicilios();
                        domicilio.Tipo = TipoCatalogo.EMPRESA;
                        domicilio.CatalogoId = empresa.Id;
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

                        if (gv.DataRowCount > 0)
                        {
                            for (var i = 0; i < gv.RowCount - 1; i++)
                            {
                                var row = gv.GetDataRow(i);
                                if (row != null)
                                {
                                    if (!Convert.IsDBNull(row["Id"]))
                                    {
                                        var id = Convert.ToInt32(row["Id"]);
                                        empresaBancos = controler.Model.EmpresaBancos.Where(D => D.Id == id).FirstOrDefault();
                                    }
                                    else
                                    {
                                        empresaBancos = new EmpresaBancos();
                                    }

                                    empresaBancos.Empresa = controler.GetObjectFromContext(empresa);
                                    empresaBancos.BancosId = row["BancosId"].ToString()!="" ? Convert.ToInt32(row["BancosId"]) : Convert.ToInt32((int?)null);
                                    empresaBancos.NoCuenta = row["NoCuenta"].ToString();
                                    empresaBancos.CLABE = row["CLABE"].ToString();
                                    empresaBancos.Sucursal = row["Sucursal"].ToString();
                                    empresaBancos.FolioInicial = row["FolioInicial"].ToString()!="" ? Convert.ToInt32(row["FolioInicial"]) : (int?)null;
                                    empresaBancos.FolioActual = row["FolioActual"].ToString() != "" ? Convert.ToInt32(row["FolioActual"]) : (int?)null;

                                    if (!empresaBancos.NoEsNuevo)
                                    {
                                        controler.Model.AddToEmpresaBancos(empresaBancos);
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
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
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
                        message = string.IsNullOrEmpty(error) ? string.Concat("La Empresa ha sido actualizada exitosamente.") : string.Concat("No se pudo actualizar la Empresa:\n", error);
                    }
                    else
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("La Empresa ha sido generada exitosamente.") : string.Concat("No se pudo generar la Empresa:\n", error);
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
        #endregion

        private void txtRFC_Leave(object sender, EventArgs e)
        {
            if (ValidaRFC() == false)
            {
                new frmMessageBox(true) { Message = "RFC En uso, Favor de Verificar.", Title = "Aviso" }.ShowDialog();
            }
        }
        private bool ValidaRFC()
        {
            if (this.empresa != null)
            {
                int rfcs = controler.Model.Empresa.Where(p => p.RFC == txtRFC.Text.Trim() && p.Id != empresa.Id).Count();
                if (rfcs == 0)
                    return true;
                else
                    return false;
            }
            else
            {
                int rfcs = controler.Model.Empresa.Where(p => p.RFC == txtRFC.Text.Trim()).Count();
                if (rfcs == 0)
                    return true;
                else
                    return false;
            }
        }

    }
}
