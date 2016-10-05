using System;
using System.Collections.Generic;
using System.Linq;
using GeisaBD;

namespace SistemaGEISA
{
    public partial class frmObrasNew : DevExpress.XtraEditors.XtraForm
    {
        private Controler controler { get; set; }

        public Obra obra { get; set; }

        List<string> obrasNombres;

        public frmObrasNew(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;
        }
        private void llenaEstados()
        {
            luEstado.Properties.DataSource = controler.Model.Estado.ToList();
            luEstado.Properties.DisplayMember = "Nombre";
            luEstado.Properties.ValueMember = "Id";
        }
        private void llenaCiudad()
        {
            var estado = luEstado.GetSelectedDataRow() as Estado;

            if (estado != null)
            {
                luCiudad.Properties.DataSource = controler.Model.Ciudad.Where(C => C.EstadoId == estado.Id).ToList();
                luCiudad.Properties.DisplayMember = "Nombre";
                luCiudad.Properties.ValueMember = "Id";
            }
        }

        private void llenaCliente()
        {
            luCliente.Properties.DataSource = controler.Model.Cliente.Where(D => D.Activo == true).ToList();
            luCliente.Properties.DisplayMember = "NombreComercial";
            luCliente.Properties.ValueMember = "Id";
        }

        private void llenaEmpresa()
        {
            luEmpresa.Properties.DataSource = controler.Model.Empresa.Where(D => D.Activo == true).ToList();
            luEmpresa.Properties.DisplayMember = "NombreComercial";
            luEmpresa.Properties.ValueMember = "Id";
        }

        private bool isValid()
        {
            var areValid = true;
            var isValid = true;

            areValid &= controler.CheckEmptyText(txtNombre, dtFechaIni, dtFechaFin);

            areValid &= isValid = luEstado.GetSelectedDataRow() != null;
            controler.SetError(luEstado, isValid ? string.Empty : "Seleccione un Estado");

            areValid &= isValid = luCiudad.GetSelectedDataRow() != null;
            controler.SetError(luCiudad, isValid ? string.Empty : "Seleccione un Ciudad");

            areValid &= isValid = luCliente.GetSelectedDataRow() != null;
            controler.SetError(luCliente, isValid ? string.Empty : "Seleccione un Cliente");

            areValid &= isValid = luEmpresa.GetSelectedDataRow() != null;
            controler.SetError(luEmpresa, isValid ? string.Empty : "Seleccione una Empresa");

            return areValid;
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            var form = new frmEstado();
            form.ShowDialog();

            if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                luCiudad.EditValue = null;
                luEstado.EditValue = null;

                llenaEstados();
            }

            form.Dispose();
        }
        private void btnCiudad_Click(object sender, EventArgs e)
        {
            var edo = luEstado.GetSelectedDataRow() as Estado;
            var form = new frmCiudad();
            form.edo = edo;
            form.ShowDialog();
            if (form.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                luCiudad.EditValue = null;
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
                if (obra == null)
                {
                    obra = new Obra();
                    isNew = true;
                }

                obra.Nombre = txtNombre.Text.Trim().ToUpper();
                obra.FechaInicio = Convert.ToDateTime(dtFechaIni.Value);
                obra.FechaFin = Convert.ToDateTime(dtFechaFin.Value);
                obra.FechaRegistro = DateTime.Now;
                obra.Ciudad = controler.GetObjectFromContext(luCiudad.GetSelectedDataRow() as Ciudad);
                obra.Cliente = controler.GetObjectFromContext(luCliente.GetSelectedDataRow() as Cliente);
                obra.Empresa = controler.GetObjectFromContext(luEmpresa.GetSelectedDataRow() as Empresa);
                //obra.PPInicial = string.IsNullOrEmpty(txtPPinicial.Text) ? 0 : Convert.ToDouble(txtPPinicial.Text);
                //obra.PPFinal = string.IsNullOrEmpty(txtPPFinal.Text) ? 0 : Convert.ToDouble(txtPPFinal.Text);

                if (!obra.NoEsNuevo)
                {
                    controler.Model.AddToObra(obra);
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
                        message = string.IsNullOrEmpty(error) ? string.Concat("La Obra ha sido actualizada exitosamente.") : string.Concat("No se pudo actualizar la Obra:\n", error);
                    }
                    else
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("La Obra ha sido generada exitosamente.") : string.Concat("No se pudo generar la Obra:\n", error);
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

        private void luEstado_EditValueChanged(object sender, EventArgs e)
        {
            llenaCiudad();
        }
        private void frmEmpresaNew_Load(object sender, EventArgs e)
        {
            obrasNombres = controler.Model.Obra.Select(O => O.Nombre).ToList();
            llenaEstados();
            llenaCliente();
            llenaEmpresa();
            if (obra != null)
            {
                txtNombre.Text = obra.Nombre;
                dtFechaIni.Value = Convert.ToDateTime(obra.FechaInicio);
                dtFechaFin.Value = Convert.ToDateTime(obra.FechaFin);
                luEstado.EditValue = obra.Ciudad != null ? obra.Ciudad.EstadoId : Convert.ToInt32((int?)null);
                luCiudad.EditValue = obra.CiudadId;
                luEmpresa.EditValue = obra.EmpresaId;
                luCliente.EditValue = obra.ClienteId;
                //txtPPinicial.Text = obra.PPInicial.HasValue ? obra.PPInicial.Value.ToString("N2"): "0";
                //txtPPFinal.Text =  obra.PPFinal.HasValue ? obra.PPFinal.Value.ToString("N2") : "0";
            }
        }

        private void txtPPinicial_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            Funciones.soloNumeros(sender, e);
        }

        private void txtPPFinal_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            Funciones.soloNumeros(sender, e);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {            
            grid.DataSource = controler.Model.Obra.Where(O => O.Nombre.Contains(txtNombre.Text.Trim())).ToList();
        }
    }
}
