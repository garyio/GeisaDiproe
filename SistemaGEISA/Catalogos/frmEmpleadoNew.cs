﻿using System;
using System.Collections.Generic;
using System.Linq;
using GeisaBD;

namespace SistemaGEISA
{
    public partial class frmEmpleadoNew : DevExpress.XtraEditors.XtraForm
    {
        private Controler controler { get; set; }
        public Empleado empleado { get; set; }
        Usuario usuario { get; set; }

        public bool tienePermisoAgregar, tienePermisoModificar,tienePermisoNominas;

        public frmEmpleadoNew(Controler _controler)
        {
            InitializeComponent();
            controler = _controler;
        }

        private void frmEmpleadoNew_Load(object sender, EventArgs e)
        {
            btnGuardar.Enabled = tienePermisoAgregar || tienePermisoModificar;
            //btnNomina.Enabled = tienePermisoNominas && (frmPrincipal.UsuarioDelSistema.ToString().ToUpper() == "ANA" || frmPrincipal.UsuarioDelSistema.ToString().ToUpper() == "CONTABILIDAD");

            llenaPerfil();

            if (empleado != null)
            {
                txtNombre.Text = empleado.Nombre;
                txtApPaterno.Text = empleado.ApPaterno;
                txtApMaterno.Text = empleado.ApMaterno;
                chkResidente.Checked = empleado.EsResidente;
                chkObra.Checked = empleado.EsObra.HasValue ? empleado.EsObra.Value : false;
                chkOficina.Checked = empleado.EsOficina.HasValue ? empleado.EsOficina.Value : false;

                usuario = controler.Model.Usuario.Where(f => f.EmpleadoId == empleado.Id).FirstOrDefault();

                if (usuario != null)
                {
                    chkUsuario.Checked = true;
                }
            }
        }

        #region Funciones
        private void llenaPerfil()
        {
            lookupPerfil.Properties.DataSource = controler.Model.Perfil.ToList();
            lookupPerfil.Properties.DisplayMember = "Nombre";
            lookupPerfil.Properties.ValueMember = "Id";
        }

        private bool isValid()
        {
            bool areValid = true;
            bool isValid = true;

            areValid &= isValid = controler.CheckEmptyText(txtNombre, txtApPaterno, txtApMaterno);

            if (chkUsuario.Checked)
            {
                areValid &= isValid = this.controler.CheckEmptyText(txtLogin, txtPassw);
                areValid &= isValid = lookupPerfil.EditValue != null ? true : false;
                controler.SetError(lookupPerfil, isValid ? string.Empty : "Seleccione un Perfil");
            }

            return areValid;
        }
        #endregion

        #region Controles
        private void chkUsuario_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUsuario.Checked)
            {
                tabUsuario.PageVisible = true;
                if (usuario != null)
                {
                    txtLogin.Text = usuario.Login;
                    txtPassw.Text = usuario.Password.Substring(0, 10);
                    lookupPerfil.EditValue = usuario.PerfilId;
                    txtEmail.Text = usuario.Mail;
                }
            }
            else
            {
                tabUsuario.PageVisible = false;
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
                if (empleado == null)
                {
                    empleado = new Empleado();
                    empleado.Activo = true;
                    isNew = true;
                }

                empleado.Nombre = txtNombre.Text.Trim();
                empleado.ApPaterno = txtApPaterno.Text.Trim();
                empleado.ApMaterno = txtApMaterno.Text.Trim();
                empleado.EsResidente = chkResidente.Checked;
                empleado.EsObra = chkObra.Checked;
                empleado.EsOficina = chkOficina.Checked;

                if (!empleado.NoEsNuevo) controler.Model.AddToEmpleado(empleado);

                if (chkUsuario.Checked)
                {
                    if (usuario == null)
                    {
                        usuario = new Usuario();
                        usuario.Login = txtLogin.Text.Trim();
                        usuario.Password = controler.Hash(txtPassw.Text.Trim());
                        usuario.Perfil = controler.GetObjectFromContext(lookupPerfil.GetSelectedDataRow() as Perfil);
                        usuario.Mail = txtEmail.Text.Trim();
                        usuario.Empleado = empleado;
                        usuario.Activo = true;
                    }
                    else
                    {
                        if (!usuario.Login.Equals(txtLogin.Text)) usuario.Login = txtLogin.Text.Trim();
                        if (!usuario.Password.Substring(0, 10).Equals(txtPassw.Text)) usuario.Password = controler.Hash(txtPassw.Text.Trim());
                        if (usuario.PerfilId != (Convert.ToInt32(lookupPerfil.EditValue))) usuario.Perfil = controler.GetObjectFromContext(lookupPerfil.GetSelectedDataRow() as Perfil);
                    }

                    if (!usuario.NoEsNuevo) controler.Model.AddToUsuario(usuario);
                }
                else
                {
                    if (usuario != null) usuario.Activo = false;
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
                        message = string.IsNullOrEmpty(error) ? string.Concat("El Empleado ha sido actualizado exitosamente.") : string.Concat("No se pudo actualizar el Empleado:\n", error);
                    }
                    else
                    {
                        message = string.IsNullOrEmpty(error) ? string.Concat("El Empleado ha sido generado exitosamente.") : string.Concat("No se pudo generar el Empleado:\n", error);
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (this.empleado != null)
                abrirForm(true);
            else
                new frmMessageBox(true) { Message = "Favor de Guardar los Cmabios del Empleado, antes de Capturar la Nomina.", Title = "Aviso" }.ShowDialog();
        }

        private void abrirForm(bool nuevo)
        {
            var form = new frmEmpleadoNewNomina(controler);
            form.Text = "Nomina " + this.empleado.NombreCompleto + " - " + (nuevo ? "Nuevo" : "Editar");
            form.empleado = this.empleado;

            form.ShowDialog();
        }
    }
}
