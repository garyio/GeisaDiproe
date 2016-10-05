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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using System.Data.Common;

namespace SistemaGEISA
{
    public partial class frmDeposito :XtraForm
    {
        public Controler controler { get; set; }

        public Empleado empleado { get; set; }

        public CajaChica cajaChica { get; set; }

        public CajaChicaDetalle cajaDetalle { get; set; }

        public frmDeposito(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;
        }

        private void frmDeposito_Load(object sender, EventArgs e)
        {
            llenaCombos();

            if (cajaDetalle != null)
            {
                luTipoDepo.EditValue = cajaDetalle.TipoPagoId;
                dateFecha.Value = cajaDetalle.Fecha;
                txtDeposito.Text = cajaDetalle.Deposito.Value.ToString("N2");
                txtObservaciones.Text = cajaDetalle.Observaciones;
                luObra.EditValue = cajaDetalle.ObraId;
                luEmpresa.EditValue = cajaDetalle.EmpresaId;
                luBancos.EditValue = cajaDetalle.EmpresaBancosId;
                txtReferencia.Text = cajaDetalle.NoReferencia;
            }

            btnEliminar.Visible = cajaDetalle != null;
        }

        #region Funciones
        public void llenaCombos()
        {
            luObra.Properties.DataSource = controler.Model.Obra.ToList();
            luObra.Properties.DisplayMember = "Nombre";
            luObra.Properties.ValueMember = "Id";

            luEmpresa.Properties.DataSource = controler.Model.Empresa.Where(D => D.Activo == true).ToList();
            luEmpresa.Properties.DisplayMember = "NombreComercial";
            luEmpresa.Properties.ValueMember = "Id";

            luTipoDepo.Properties.DataSource = controler.Model.TipoPago.ToList();
            luTipoDepo.Properties.DisplayMember = "Nombre";
            luTipoDepo.Properties.ValueMember = "Id";
        }

        private bool isValid()
        {
            var areValid = true;
            var isValid = true;


            if ((luTipoDepo.GetSelectedDataRow() as TipoPago).Nombre != "EFECTIVO")
            {
                areValid &= controler.CheckEmptyText(txtReferencia);
            }
            areValid &= isValid = luTipoDepo.GetSelectedDataRow() != null;
            
            areValid &= controler.CheckNumericText(txtDeposito);            
            controler.SetError(luTipoDepo, isValid ? string.Empty : "Seleccione un tipo de deposito");

            //areValid &= isValid = luEmpresa.GetSelectedDataRow() != null;
            //controler.SetError(luEmpresa, isValid ? string.Empty : "Seleccione una Empresa");

            //areValid &= isValid = luObra.GetSelectedDataRow() != null;
            //controler.SetError(luObra, isValid ? string.Empty : "Seleccione una Obra");

            return areValid;
        }
        #endregion

        #region Controles
        private void luTipoDepo_EditValueChanged(object sender, EventArgs e)
        {
            if ((luTipoDepo.GetSelectedDataRow() as TipoPago).Nombre != "EFECTIVO")
            {
                txtReferencia.Visible = true;
                label2.Text = "No. Referencia";
                label2.Visible = true;

                label7.Visible = true;
                luBancos.Visible = true;
            }
            else { txtReferencia.Visible = false; label2.Visible = false; luBancos.Visible = false; label7.Visible = false; }
        }

        private void luEmpresa_EditValueChanged(object sender, EventArgs e)
        {
            var em = controler.GetObjectFromContext(luEmpresa.GetSelectedDataRow() as Empresa);

            if (em != null)
            {
                luBancos.Properties.DataSource = controler.Model.EmpresaBancos.Where(D => D.EmpresaId == em.Id).ToList();
                luBancos.Properties.DisplayMember = "NombreBanco";
                luBancos.Properties.ValueMember = "Id";
            }
        }
        #endregion

        #region Botones
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var error = string.Empty;
            var isNew = false;

            if (isValid())
            {
                if (cajaDetalle == null)
                {
                    cajaDetalle = new CajaChicaDetalle();
                    cajaDetalle.CajaChica = controler.GetObjectFromContext(cajaChica);
                    isNew = true;
                }

                cajaDetalle.Obra = controler.GetObjectFromContext(luObra.GetSelectedDataRow() as Obra);
                cajaDetalle.Empresa = controler.GetObjectFromContext(luEmpresa.GetSelectedDataRow() as Empresa);
                cajaDetalle.TipoPago = controler.GetObjectFromContext(luTipoDepo.GetSelectedDataRow() as TipoPago);
                cajaDetalle.EmpresaBancos = controler.GetObjectFromContext(luBancos.GetSelectedDataRow() as EmpresaBancos);
                cajaDetalle.Fecha = dateFecha.Value;

                if (cajaDetalle.TipoPagoId != TipoPagoEnum.Efectivo.Id)
                    cajaDetalle.NoReferencia = txtReferencia.Text.Trim();
                else
                    cajaDetalle.NoReferencia = "";

                cajaDetalle.Deposito = Convert.ToDouble(txtDeposito.Text);
                cajaDetalle.Observaciones = txtObservaciones.Text.Trim().ToUpper();
                
                if (!cajaDetalle.NoEsNuevo) controler.Model.AddToCajaChicaDetalle(cajaDetalle);

                try
                {
                    controler.Model.SaveChanges();
                }
                catch (Exception ex)
                {
                    error = ex.InnerException.Message;
                }

                var title = string.IsNullOrEmpty(error) ? "Confirmación" : "Error";
                var message = string.Empty;
                message = string.IsNullOrEmpty(error) ? string.Concat("Deposito generado exitosamente.") : string.Concat("No se pudo generar el deposito:\n", error);
                new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();

                if (string.IsNullOrEmpty(error))
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmMessageBox msg = new frmMessageBox(false) { Message = "¿Estas seguro de eliminar este deposito?", Title = "Eliminar Registro" };
            msg.ShowDialog();

            if (msg.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                var error = string.Empty;

                try
                {
                    controler.Model.DeleteObject(cajaDetalle);
                    controler.Model.SaveChanges();
                }
                catch (Exception ex)
                {
                    error = ex.InnerException.Message;
                }

                var title = string.IsNullOrEmpty(error) ? "Confirmación" : "Error";
                var message = string.Empty;
                message = string.IsNullOrEmpty(error) ? string.Concat("Deposito eliminado.") : string.Concat("No se pudo eliminar el deposito:\n", error);
                new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();

                if (string.IsNullOrEmpty(error))
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    Close();
                }
            }
        }
        #endregion
    }
}