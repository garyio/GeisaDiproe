using System;
using System.Collections.Generic;
using System.Linq;
using GeisaBD;

namespace SistemaGEISA
{
    public partial class frmUsuarios : DevExpress.XtraEditors.XtraForm
    {
        private Controler controler;
        private Usuario usuario;
        public frmUsuarios()
        {
            InitializeComponent();
            controler = new Controler();

            controler.PermisosEnFormulario(Name);
            btnNuevo.Enabled = controler.TienePermiso(PermisosEnum.Agregar);
            btnEditar.Enabled = controler.TienePermiso(PermisosEnum.Actualizar);
            btnActivo.Enabled = controler.TienePermiso(PermisosEnum.ActivarDesactivar);
        }

        private void llenaCombo()
        {
            lookupPerfil.Properties.DataSource = controler.Model.Perfil.ToList();
            lookupPerfil.Properties.DisplayMember = "Nombre";
            lookupPerfil.Properties.ValueMember = "Id";
        }

        private void llenaGrid()
        {
            grid.DataSource = controler.Model.Usuario.ToList();
        }

        private void botones(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    btnNuevo.Visible = true;
                    toolStripSeparator1.Visible = true;
                    btnGuardar.Visible = false;
                    toolStripSeparator2.Visible = false;
                    btnEditar.Visible = false;
                    toolStripSeparator3.Visible = false;
                    btnActivo.Visible = false;
                    toolStripSeparator4.Visible = false;
                    btnCancelar.Visible = false;
                    break;
                case 2:
                    btnNuevo.Visible = false;
                    toolStripSeparator1.Visible = false;
                    btnGuardar.Visible = true;
                    toolStripSeparator2.Visible = true;
                    btnEditar.Visible = false;
                    toolStripSeparator3.Visible = false;
                    btnActivo.Visible = false;
                    toolStripSeparator4.Visible = false;
                    btnCancelar.Visible = true;
                    break;
                case 3:
                    btnNuevo.Visible = true;
                    toolStripSeparator1.Visible = true;
                    btnGuardar.Visible = false;
                    toolStripSeparator2.Visible = false;
                    btnEditar.Visible = true;
                    toolStripSeparator3.Visible = true;
                    btnActivo.Visible = true;
                    toolStripSeparator4.Visible = true;
                    btnCancelar.Visible = false;
                    break;
            }
        }

        private void limpiar()
        {
            txtNombre.Text = string.Empty;
            txtContraseña.Text = string.Empty;
            txtMail.Text = string.Empty;
            lookupPerfil.EditValue = lookupPerfil.Properties.GetDataSourceValue("Id", -1);

            txtNombre.ReadOnly = true;
            txtContraseña.ReadOnly = true;
            txtMail.ReadOnly = true;
            lookupPerfil.Enabled = false;

            controler.SetError(txtNombre, string.Empty);
            controler.SetError(txtContraseña, string.Empty);
            controler.SetError(lookupPerfil, string.Empty);
            controler.SetError(txtMail, string.Empty);

            usuario = null;
        }

        private bool isValid()
        {
            var areValid = true;
            var isValid = true;

            areValid &= controler.CheckEmptyText(txtNombre, txtContraseña);
            areValid &= isValid = lookupPerfil.GetSelectedDataRow() != null;
            controler.SetError(lookupPerfil, isValid ? string.Empty : "Seleccione un Perfil");

            if (!string.IsNullOrEmpty(txtMail.Text))
            {
                areValid &= isValid = controler.IsValidEmail(txtMail.Text);
                controler.SetError(txtMail, isValid ? string.Empty : "Correo Invalido");
            }

            return areValid;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            botones(2);
            btnGuardar.Text = "Guardar";
            limpiar();
            txtContraseña.ReadOnly = txtNombre.ReadOnly = txtMail.ReadOnly = false;
            lookupPerfil.Enabled = true;
            txtNombre.Focus();

            usuario = new Usuario();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var error = string.Empty;
            var isNew = false;
            if (isValid())
            {
                usuario.Login = txtNombre.Text.Trim();

                if (usuario.Password != txtContraseña.Text.Trim())
                {
                    usuario.Password = controler.Hash(txtContraseña.Text.Trim());
                }
                usuario.Mail = txtMail.Text;
                usuario.Perfil = lookupPerfil.GetSelectedDataRow() as Perfil;

                if (!usuario.NoEsNuevo)
                {
                    usuario.Activo = true;
                    controler.Model.AddToUsuario(usuario);
                    isNew = true;
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
                        message = string.IsNullOrEmpty(error) ? string.Concat("El usuario ha sido actualizado exitosamente.") : string.Concat("No se pudo actualizar el usuario:\n", error);
                    }
                    else
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("El usuario ha sido generada exitosamente.") : string.Concat("Error al generar el usuario:\n", error);
                    }

                    new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();
                }

                if (string.IsNullOrEmpty(error))
                {
                    if (!isNew)
                    {
                        grid.RefreshDataSource();
                    }
                    else
                    {
                        llenaGrid();
                    }
                    gv_FocusedRowChanged(null, null);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            botones(1);
            limpiar();
            if (gv.DataRowCount > 0)
            {
                gv_FocusedRowChanged(null, null);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtNombre.ReadOnly = txtContraseña.ReadOnly = txtMail.ReadOnly = false;
            lookupPerfil.Enabled = true;
            txtNombre.Focus();
            botones(2);
        }

        private void btnActivo_Click(object sender, EventArgs e)
        {
            usuario.Activo = btnActivo.Text == "Activar" ? true : false;
            controler.Model.SaveChanges();
            grid.RefreshDataSource();
            gv_FocusedRowChanged(null, null);
        }

        private void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gv.DataRowCount > 0)
            {
                limpiar();
                usuario = gv.GetFocusedRow() as Usuario;

                if (usuario != null)
                {
                    txtNombre.Text = usuario.Login;
                    txtContraseña.Text = usuario.Password;
                    lookupPerfil.EditValue = lookupPerfil.Properties.GetDataSourceValue("Id", lookupPerfil.Properties.GetDataSourceRowIndex("Id", usuario.PerfilId));

                    botones(3);

                    if (usuario.Activo)
                    {
                        btnActivo.Text = "Desactivar";
                        btnActivo.Image = SistemaGEISA.Properties.Resources.Desactivar;
                    }
                    else
                    {
                        btnActivo.Text = "Activar";
                        btnActivo.Image = SistemaGEISA.Properties.Resources.Activo;
                    }

                    txtNombre.ReadOnly = txtContraseña.ReadOnly = true;
                    lookupPerfil.Enabled = false;
                }
            }
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            llenaCombo();
            limpiar();
            llenaGrid();

            if (gv.DataRowCount == 0)
            {
                botones(1);
            }
        }
    }
}
