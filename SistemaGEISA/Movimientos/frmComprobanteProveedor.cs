using GeisaBD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaGEISA.Movimientos
{
    public partial class frmComprobanteProveedor : DevExpress.XtraEditors.XtraForm
    {
        public Controler controler { get; set; }
        public Proveedor proveedor { get; set; }


        public frmComprobanteProveedor(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;
        }

        private void frmComprobanteProveedor_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var error = string.Empty;

            if (isValid())
            {
                DbTransaction transaccion = null;
                try
                {
                    transaccion = controler.Model.BeginTransaction();
                    if (proveedor == null)
                    {
                        proveedor = new Proveedor();
                        proveedor.Activo = true;
                    }
                    proveedor.NombreFiscal = txtProveedor.Text.Trim().ToUpper();
                    proveedor.NombreComercial = txtProveedor.Text.Trim().ToUpper();
                    proveedor.RFC = "XAXX010101000";
                    if (!proveedor.NoEsNuevo) controler.Model.AddToProveedor(proveedor);

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
                    if (string.IsNullOrEmpty(error))
                    {
                        
                        var title = "Confirmación";
                        var message = "El Proveedor se Genero Exitosamente.";
                        new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();
                    }
                    else
                    {
                        
                        var title = "Error";
                        var message = string.Concat("Error al Crear el Proveedor:\n", error);
                        new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();
                    }

                }

                if (string.IsNullOrEmpty(error))
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
        }

        private bool isValid()
        {
            var areValid = true;
            var isValid = true;
            areValid &= isValid = controler.CheckEmptyText(txtProveedor);
            controler.SetError(txtProveedor, isValid ? string.Empty : "Favor de Ingresar un Proveedor.");

            var prov = controler.Model.Proveedor.Where(p => p.NombreFiscal == txtProveedor.Text.Trim() || p.NombreComercial == txtProveedor.Text.Trim()).Count();
            if (prov > 0)
                return areValid &= isValid = false;
            else
                return areValid &= isValid = true;
        }
    }
}
