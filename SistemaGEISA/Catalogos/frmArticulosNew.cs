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
using System.Globalization;

namespace SistemaGEISA
{
    public partial class frmArticulosNew : DevExpress.XtraEditors.XtraForm
    {
        private Controler controler { get; set; }
        public Articulos articulo { get; set; }
        public frmArticulosNew(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;
        }

        private void frmArticulosNew_Load(object sender, EventArgs e)
        {
            llenaCombos();
            if (articulo != null)
            {                
                luEmpresa.EditValue = articulo.EmpresaId;
                luProveedor.EditValue = articulo.ProveedorId;
                txtCodigo.Text = articulo.Codigo;
                txtDescripcion.Text = articulo.Descripcion;
                luSubcategoria.EditValue = articulo.SubcategoriaId;
                luUniad.EditValue = articulo.UnidadId;
                txtPrecioCompra.Text = articulo.PrecioCompra.Value.ToString("N2");
                txtPrecioVenta.Text = articulo.PrecioVenta.Value.ToString("N2");
                txtUtilidad.Text = (articulo.PrecioCompra.Value - articulo.PrecioVenta.Value).ToString("N2");
                spinExistecia.EditValue = articulo.Existencia;
                rgEstado.EditValue = articulo.Activo;
                
            }
            else
            {                                                                                                                            
                spinExistecia.EditValue = 1;
                rgEstado.EditValue = true;
            }
        }

        private void llenaCombos()
        {
            luEmpresa.Properties.DataSource = controler.Model.Empresa.Where(D => D.Activo == true).ToList();
            luEmpresa.Properties.DisplayMember = "NombreComercial";
            luEmpresa.Properties.ValueMember = "Id";

            luProveedor.Properties.DataSource = controler.Model.Proveedor.Where(D => D.Activo == true).OrderBy(O => O.NombreComercial).ToList();
            luProveedor.Properties.DisplayMember = "NombreComercial";
            luProveedor.Properties.ValueMember = "Id";

            luSubcategoria.Properties.DataSource = controler.Model.Subcategoria.Where(D => D.Activo == true).ToList();
            luSubcategoria.Properties.DisplayMember = "Nombre";
            luSubcategoria.Properties.ValueMember = "Id";

            luUniad.Properties.DataSource = controler.Model.UnidadMedida.Where(D => D.Activo == true).ToList();
            luUniad.Properties.DisplayMember = "Nombre";
            luUniad.Properties.ValueMember = "Id";
        }

        private void btnAgregarSubcategoria_Click(object sender, EventArgs e)
        {
            var form = new frmSubcategorias();
            form.ShowDialog();

            if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                luSubcategoria.EditValue = null;
                controler.Model.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, controler.Model.Subcategoria.ToList());
                luSubcategoria.Properties.DataSource = controler.Model.Subcategoria.Where(D => D.Activo == true).ToList();
                luSubcategoria.Properties.DisplayMember = "Nombre";
                luSubcategoria.Properties.ValueMember = "Id";
            }
            form.Dispose();
        }

        private void btnAgregarUnidad_Click(object sender, EventArgs e)
        {
            var form = new frmUnidadMedidas();
            form.ShowDialog();

            if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                luUniad.EditValue = null;
                controler.Model.Refresh(System.Data.Entity.Core.Objects.RefreshMode.StoreWins, controler.Model.UnidadMedida.ToList());
                luUniad.Properties.DataSource = controler.Model.UnidadMedida.Where(D => D.Activo == true).ToList();
                luUniad.Properties.DisplayMember = "Nombre";
                luUniad.Properties.ValueMember = "Id";
            }

            form.Dispose();
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.soloNumerosDec(sender, e);
        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.soloNumerosDec(sender, e);
        }

        private void txtPrecioCompra_TextChanged(object sender, EventArgs e)
        {
            double val;
            try
            {
                val = double.Parse(txtPrecioVenta.Text, NumberStyles.Number) - double.Parse(txtPrecioCompra.Text, NumberStyles.Number);
            }
            catch (Exception ex)
            {
                val = 0;
            }
             txtUtilidad.Text = val.ToString("c2");                            
        }

        private void txtPrecioCompra_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPrecioCompra.Text = Convert.ToDouble(txtPrecioCompra.Text).ToString("N2");
            }
            catch (Exception ex)
            {
                
            }
        }

        private void txtPrecioVenta_Leave(object sender, EventArgs e)
        {
            try
            {
                txtPrecioVenta.Text = Convert.ToDouble(txtPrecioVenta.Text).ToString("N2");
            }
            catch (Exception ex)
            {

            }
        }

        private void btnGuardarNuevo_Click(object sender, EventArgs e)
        {
            btnGuardar_Click(sender, e);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var error = string.Empty;
            var isNew = false;
            var SaveAndNew = sender.ToString() == "Guardar y Nuevo" ? true : false;

            if (isValid())
            {
                if (articulo == null)
                {
                    articulo = new Articulos();
                    isNew = true;
                }

                articulo.Codigo = txtCodigo.Text.ToUpper();
                articulo.Subcategoria = luSubcategoria.GetSelectedDataRow() as Subcategoria;
                articulo.Descripcion = txtDescripcion.Text.ToUpper();
                articulo.PrecioCompra = string.IsNullOrEmpty(txtPrecioCompra.Text) ? 0 : Convert.ToDouble(txtPrecioCompra.Text);
                articulo.PrecioVenta = string.IsNullOrEmpty(txtPrecioVenta.Text) ? 0 : Convert.ToDouble(txtPrecioVenta.Text);
                articulo.Existencia = spinExistecia.EditValue == null ? 0 : Convert.ToDouble(spinExistecia.EditValue);
                articulo.FechaAlta = DateTime.Today;
                articulo.Activo = Convert.ToBoolean(rgEstado.EditValue);
                articulo.UnidadMedida = luUniad.GetSelectedDataRow() as UnidadMedida;
                articulo.Proveedor = luProveedor.GetSelectedDataRow() as Proveedor;
                articulo.Empresa = luEmpresa.GetSelectedDataRow() as Empresa;

                if (!articulo.NoEsNuevo)    controler.Model.AddToArticulos(articulo);                
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
                        message = string.IsNullOrEmpty(error) ? string.Concat("El Articulo ha sido actualizado exitosamente.") : string.Concat("No se pudo actualizar el Articulo:\n", error);
                    }
                    else
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("El Articulo ha sido generado exitosamente.") : string.Concat("No se pudo generar el Articulo:\n", error);
                    }

                    new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();
                }

                if (string.IsNullOrEmpty(error) && !SaveAndNew)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
                else
                {
                    limpiar();
                    frmArticulosNew_Load(null, null);
                }
            }
        }

        private void limpiar()
        {
            luEmpresa.EditValue = null;
            luProveedor.EditValue = null;
            txtCodigo.Text = "";
            txtDescripcion.Text = "";
            luSubcategoria.EditValue = null;
            luUniad.EditValue = null;
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtUtilidad.Text = "";
            spinExistecia.EditValue = 1;
            rgEstado.EditValue = true;
            this.articulo = null;
        }

        private bool isValid()
        {
            bool areValid = true;
            bool isValid = true;

            areValid &= isValid = luEmpresa.EditValue == null ? false : true;
            controler.SetError(luEmpresa, isValid ? string.Empty : "Valor Obligatorio, Favor de Seleccionar.");

            areValid &= isValid = luProveedor.EditValue == null ? false : true;
            controler.SetError(luProveedor, isValid ? string.Empty : "Valor Obligatorio, Favor de Seleccionar.");

            areValid &= isValid = string.IsNullOrEmpty(txtDescripcion.Text) ? false : true;
            controler.SetError(txtDescripcion, isValid ? string.Empty : "Valor Obligatorio, Favor de Ingresar.");

            areValid &= isValid = rgEstado.EditValue == null ? false : true;
            controler.SetError(rgEstado, isValid ? string.Empty : "Valor Obligatorio, Favor de Seleccionar.");

            areValid &= isValid = spinExistecia.EditValue==null ? false : true;
            controler.SetError(spinExistecia, isValid ? string.Empty : "Valor Obligatorio, Favor de Ingresar.");

            return areValid;
        }
    }
}
