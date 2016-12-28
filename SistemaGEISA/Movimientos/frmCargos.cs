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
    public partial class frmCargos : DevExpress.XtraEditors.XtraForm
    {
        public Controler controler { get; set; }
        public VehiculoCajaChica cajaChica { get; set; }
        public VehiculoCajaChicaDetalle cargo { get; set; }

        DataTable dt;
        public frmCargos(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;
        }        

        public void limpiar()
        {
            deFecha.EditValue = DateTime.Today;
            lookupTipoDeposito.EditValue = null;
            txtImporte.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            lookupObra.EditValue = null;
            listObras.Items.Clear();
            cargo = null;
        }       

        public void llenaObra()
        {
            List<int> obrasSelected = new List<int>();
            foreach (Obra obra in listObras.Items)
            {
                obrasSelected.Add(obra.Id);
            }
            lookupObra.Properties.DataSource = controler.Model.Obra.Where(I => !obrasSelected.Contains(I.Id)).ToList();
            lookupObra.Properties.DisplayMember = "Nombre";
            lookupObra.Properties.ValueMember = "Id";
        }
        
        private bool isValid()
        {
            var areValid = true;
            var isValid = true;

            areValid &= isValid = lookupTipoDeposito.GetSelectedDataRow() != null;
            controler.SetError(lookupTipoDeposito, isValid ? string.Empty : "Valor Obligatorio.");

            areValid &= isValid = string.IsNullOrEmpty(txtImporte.Text) ? false:true;
            controler.SetError(txtImporte, isValid ? string.Empty : "Valor Obligatorio.");

            if (cargo == null)
            {
                areValid &= isValid = listObras.Items.Count > 0 ? true : false;
                controler.SetError(listObras, isValid ? string.Empty : "Favor de Ingresar al Menos una Obra.");
            }
            else
            {
                areValid &= isValid = lookupObra.GetSelectedDataRow() !=null;
                controler.SetError(lookupObra, isValid ? string.Empty : "Favor de Seleccionar una Obra");
            }

            return areValid;
    
        }

        private void frmCargos_Load(object sender, EventArgs e)
        {
            llenaForm();
            if (cargo != null)
            {
                btnAgregarObra.Visible = btnEliminarObra.Visible = listObras.Visible = lblDesglose.Visible = false;
                deFecha.EditValue = cargo.Fecha;
                lookupTipoDeposito.EditValue = cargo.TipoDeposito;
                txtImporte.Text = cargo.Importe.Value.ToString("N2");
                lookupObra.EditValue = cargo.ObraId;
                txtObservaciones.Text = cargo.Observaciones;

            }
            else
            {
                btnAgregarObra.Visible = btnEliminarObra.Visible = listObras.Visible = lblDesglose.Visible = true;
                deFecha.EditValue = DateTime.Today;
            }
        }

        private void llenaForm()
        {
            DataTable dtTipos = new DataTable();
            dtTipos.Columns.Add("Id", typeof(int));
            dtTipos.Columns.Add("Text");
            dtTipos.Rows.Add(new object[] { 1, "EFECTIVO" });
            dtTipos.Rows.Add(new object[] { 2, "TICKET CAR"});
            dtTipos.Rows.Add(new object[] { 3, "VALES" });
            lookupTipoDeposito.Properties.DataSource = dtTipos.DefaultView;
            lookupTipoDeposito.Properties.ValueMember = "Id";
            lookupTipoDeposito.Properties.DisplayMember = "Text";

            lookupObra.Properties.DataSource = controler.Model.Obra.ToList();
            lookupObra.Properties.DisplayMember = "Nombre";
            lookupObra.Properties.ValueMember = "Id";
        }
       

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var error = string.Empty;
            var isNew = cargo==null?true:false;
            var SaveAndNew = sender.ToString() == "Guardar y Nuevo" ? true : false;

            if (isValid())
            {
                if(!isNew){                        
                    cargo.VehiculoCajaChica = cajaChica;
                    cargo.Fecha = Convert.ToDateTime(deFecha.EditValue);
                    cargo.TipoDeposito = (int)lookupTipoDeposito.EditValue;
                    cargo.Importe = Convert.ToDouble(txtImporte.Text);
                    cargo.Observaciones = txtObservaciones.Text;
                    cargo.ObraId = (int)lookupObra.EditValue;
                    if (!cargo.NoEsNuevo) controler.Model.AddToVehiculoCajaChicaDetalle(cargo);           
                }else{                
                    foreach (Obra obra in listObras.Items)
                    {
                        cargo = new VehiculoCajaChicaDetalle(); 
                        cargo.VehiculoCajaChica = cajaChica;
                        cargo.Fecha = Convert.ToDateTime(deFecha.EditValue);
                        cargo.TipoDeposito = (int)lookupTipoDeposito.EditValue;
                        cargo.Importe = Convert.ToDouble(txtImporte.Text) / listObras.Items.Count;
                        cargo.Observaciones = txtObservaciones.Text;
                        cargo.Obra = obra;
                        if (!cargo.NoEsNuevo) controler.Model.AddToVehiculoCajaChicaDetalle(cargo); 
                    }
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

                    message = string.IsNullOrEmpty(error) ? (isNew ? string.Concat("Cargo generado exitosamente.") : string.Concat("Cargo Actualizado Exitosamente.")) : string.Concat("No se pudo generar:\n", error);
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
                    frmCargos_Load(null, null);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            Funciones.soloNumerosDec(sender, e);
        }

        private void btnAgregarObra_Click_1(object sender, EventArgs e)
        {
            Obra obra= lookupObra.GetSelectedDataRow() as Obra;
            if (obra != null)
            {
                listObras.Items.Add(obra);
            }
            llenaObra();
        }

        private void btnEliminarObra_Click(object sender, EventArgs e)
        {
            if (listObras.SelectedItem != null)
                listObras.Items.Remove(listObras.SelectedItem);
            llenaObra();
        }

        private void btnGuardarNuevo_Click(object sender, EventArgs e)
        {
            btnGuardar_Click(sender, e);
        }        
    }
}