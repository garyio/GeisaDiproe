using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GeisaBD;

namespace SistemaGEISA
{
    public partial class frmPerfiles : DevExpress.XtraEditors.XtraForm
    {
        private Controler controler;

        private Perfil perfil;
        private List<TreeView> ControlesTreeView = new List<TreeView>();
        public frmPerfiles()
        {
            InitializeComponent();
            controler = new Controler();

            controler.PermisosEnFormulario(Name);
            btnNuevo.Enabled = controler.TienePermiso(PermisosEnum.Agregar);
            btnEditar.Enabled = controler.TienePermiso(PermisosEnum.Actualizar);
            btnActivo.Enabled = controler.TienePermiso(PermisosEnum.ActivarDesactivar);
            btnEliminar.Enabled = controler.TienePermiso(PermisosEnum.Eliminar);
        }

        private void llenaGrid()
        {
            grid.DataSource = controler.Model.Perfil.ToList();
        }

        private void botones(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    btnNuevo.Visible = true;
                    toolStripSeparator1.Visible = false;
                    btnGuardar.Visible = false;
                    toolStripSeparator2.Visible = false;
                    btnEditar.Visible = false;
                    toolStripSeparator3.Visible = false;
                    btnActivo.Visible = false;
                    toolStripSeparator4.Visible = false;
                    btnEliminar.Visible = false;
                    toolStripSeparator5.Visible = false;
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
                    btnEliminar.Visible = false;
                    toolStripSeparator5.Visible = false;
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
                    btnEliminar.Visible = true;
                    toolStripSeparator5.Visible = false;
                    btnCancelar.Visible = false;
                    break;
                case 4:
                    btnNuevo.Visible = false;
                    toolStripSeparator1.Visible = false;
                    btnGuardar.Visible = true;
                    toolStripSeparator2.Visible = true;
                    btnEditar.Visible = false;
                    toolStripSeparator3.Visible = false;
                    btnActivo.Visible = false;
                    ;
                    toolStripSeparator4.Visible = false;
                    btnEliminar.Visible = false;
                    toolStripSeparator5.Visible = false;
                    btnCancelar.Visible = true;
                    break;
            }
        }

        private void limpiar()
        {
            txtNombre.Text = txtDescripcion.Text = string.Empty;
            txtNombre.ReadOnly = txtDescripcion.ReadOnly = true;

            controler.SetError(txtNombre, string.Empty);

            foreach (TreeView treeview in ControlesTreeView)
            {
                foreach (TreeNode nodeParent in treeview.Nodes)
                {
                    nodeParent.Checked = false;
                }
            }

            tlpPermisos.Enabled = false;
        }

        private void llenaPermisos()
        {
            ControlesTreeView.Add(tvAdministracion);
            ControlesTreeView.Add(tvCatalogos);
            ControlesTreeView.Add(tvOperaciones);

            TreeNode parentNode = null;
            var FormsToAddTree = new List<Formulario>();

            var forms = controler.Model.Formulario.OrderBy(F => F.ModuloId).ThenBy(F => F.Orden).ToList();

            if (forms != null)
            {
                FormsToAddTree = forms.ToList();
            }
            FormsToAddTree.ForEach(form =>
            {
                parentNode = new TreeNode(form.Nombre);
                parentNode.Name = form.Id.ToString();

                foreach (FormularioPermisos formPermiso in form.Load(form.FormularioPermisos))
                {
                    var childNode = new TreeNode(formPermiso.Permisos.Nombre);
                    childNode.Name = formPermiso.Id.ToString();

                    parentNode.Nodes.Add(childNode);
                }

                parentNode.Expand();

                if (form.Load(form.ModuloReference).Id == ModuloEnum.Administracion.Id)
                {
                    tvAdministracion.Nodes.Add(parentNode);
                }
                else
                {
                    if (form.Load(form.ModuloReference).Id == ModuloEnum.Catalogo.Id)
                    {
                        tvCatalogos.Nodes.Add(parentNode);
                    }
                    else
                    {
                        if (form.Load(form.ModuloReference).Id == ModuloEnum.Operaciones.Id)
                        {
                            tvOperaciones.Nodes.Add(parentNode);
                        }
                    }
                }
            });
        }

        private bool isValid()
        {
            var isValid = true;
            isValid &= controler.CheckEmptyText(txtNombre);

            if (isValid)
            {
                var countToCheck = 0;

                foreach (TreeView treeview in ControlesTreeView)
                {
                    foreach (TreeNode nodeParent in treeview.Nodes)
                    {
                        if (nodeParent.Nodes.Count > 0)
                        {
                            foreach (TreeNode nodeChild in nodeParent.Nodes)
                            {
                                if (nodeChild.Checked)
                                {
                                    countToCheck++;
                                }
                            }
                        }
                    }
                }

                if (countToCheck == 0)
                {
                    new frmMessageBox(true) { Message = "Este perfil no tiene permisos asignados.", Title = "Advertencia" }.ShowDialog();
                    isValid &= false;
                }
            }

            return isValid;
        }

        private bool guardaPermisos()
        {
            var result = true;
            PerfilPermisos rolPermisoToCheck;
            int formularioPermisoId;

            try
            {
                foreach (TreeView treeview in ControlesTreeView)
                {
                    foreach (TreeNode nodeParent in treeview.Nodes)
                    {
                        if (nodeParent.Nodes.Count > 0)
                        {
                            foreach (TreeNode nodeChild in nodeParent.Nodes)
                            {
                                formularioPermisoId = Convert.ToInt32(nodeChild.Name);

                                rolPermisoToCheck = controler.Model.PerfilPermisos.FirstOrDefault(rolPermiso => rolPermiso.PerfilId == perfil.Id && rolPermiso.FormularioPermisosId == formularioPermisoId);

                                if (rolPermisoToCheck == null && nodeChild.Checked)
                                {
                                    rolPermisoToCheck = new PerfilPermisos();
                                    rolPermisoToCheck.Perfil = perfil;
                                    rolPermisoToCheck.FormularioPermisos = controler.Model.FormularioPermisos.FirstOrDefault(formPermiso => formPermiso.Id == formularioPermisoId);
                                    controler.Model.AddToPerfilPermisos(rolPermisoToCheck);
                                }
                                else
                                {
                                    if (rolPermisoToCheck != null && nodeChild.Checked == false)
                                    {
                                        controler.Model.DeleteObject(rolPermisoToCheck);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                new frmMessageBox(true) { Message = exception.Message.ToString(), Title = "Error" }.ShowDialog();
                result = false;
            }

            return result;
        }

        private void obtenerPermisos()
        {
            int formularioPermisoId;
            int count;
            PerfilPermisos rolPermisoToCheck;

            foreach (TreeView treeview in ControlesTreeView)
            {
                foreach (TreeNode nodeParent in treeview.Nodes)
                {
                    count = 0;

                    if (nodeParent.Nodes.Count > 0)
                    {
                        foreach (TreeNode nodeChild in nodeParent.Nodes)
                        {
                            formularioPermisoId = Convert.ToInt32(nodeChild.Name);

                            rolPermisoToCheck = controler.Model.PerfilPermisos.FirstOrDefault(rolPermiso => rolPermiso.PerfilId == perfil.Id && rolPermiso.FormularioPermisosId == formularioPermisoId);

                            nodeChild.Checked = rolPermisoToCheck != null;

                            if (rolPermisoToCheck != null)
                            {
                                count++;
                            }
                        }
                    }

                    if (nodeParent.Nodes.Count == count)
                    {
                        nodeParent.Checked = true;
                    }
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var error = string.Empty;
            var isNew = false;

            if (isValid())
            {
                if (perfil == null)
                {
                    perfil = new Perfil();
                }
                perfil.Nombre = txtNombre.Text.Trim();
                perfil.Descripcion = txtDescripcion.Text.Trim();
                if (guardaPermisos())
                {
                    if (!perfil.NoEsNuevo)
                    {
                        perfil.Activo = true;
                        controler.Model.AddToPerfil(perfil);
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
                            message = string.IsNullOrEmpty(error) ? string.Concat("El perfil ha sido actualizado exitosamente.") : string.Concat("No se pudo actualizar el perfil:\n", error);
                        }
                        else
                        {
                            message = string.IsNullOrEmpty(error) ? string.Concat("El perfil ha sido generado exitosamente.") : string.Concat("No se pudo generar el perfil:\n", error);
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
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            botones(2);
            btnGuardar.Text = "Guardar";
            limpiar();
            txtNombre.ReadOnly = txtDescripcion.ReadOnly = false;
            tlpPermisos.Enabled = true;
            txtNombre.Focus();

            perfil = new Perfil();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            txtNombre.ReadOnly = txtDescripcion.ReadOnly = false;
            txtNombre.Focus();
            tlpPermisos.Enabled = true;
            botones(4);
        }

        private void btnActivo_Click(object sender, EventArgs e)
        {
            perfil.Activo = btnActivo.Text == "Activar" ? true : false;
            controler.Model.SaveChanges();
            grid.RefreshDataSource();
            gv_FocusedRowChanged(null, null);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var error = string.Empty;

            if (perfil != null)
            {
                if (perfil.Usuario.Count == 0)
                {
                    try
                    {
                        foreach (PerfilPermisos permisos in perfil.PerfilPermisos.ToList())
                        {
                            controler.Model.DeleteObject(permisos);
                        }
                        controler.Model.DeleteObject(perfil);
                        controler.Model.SaveChanges();

                        llenaGrid();
                    }
                    catch (Exception ex)
                    {
                        error = ex.InnerException.Message;
                    }
                    finally
                    {
                        var title = string.IsNullOrEmpty(error) ? "Confirmación" : "Error";

                        var message = string.IsNullOrEmpty(error) ? string.Concat("El perfil ha sido eliminado.") : string.Concat("No se pudo eliminar el perfil:\n", error);

                        new frmMessageBox(true) { Message = message, Title = title }.ShowDialog();
                    }
                }
                else
                {
                    new frmMessageBox(true) { Message = "No se puede eliminar el perfil. Tiene usuarios asignados.", Title = "Advertencia" }.ShowDialog();
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


        private void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gv.DataRowCount > 0)
            {
                limpiar();
                perfil = gv.GetFocusedRow() as Perfil;

                if (perfil != null)
                {
                    txtNombre.Text = perfil.Nombre;
                    txtDescripcion.Text = perfil.Descripcion;
                    botones(3);
                    btnGuardar.Text = "Actualizar";
                    btnActivo.Text = perfil.Activo ? "Desactivar" : "Activar";
                    btnActivo.Image = perfil.Activo ? SistemaGEISA.Properties.Resources.Desactivar : SistemaGEISA.Properties.Resources.Activo;
                    btnEliminar.Visible = perfil.Usuario.Count == 0;
                    txtNombre.ReadOnly = txtDescripcion.ReadOnly = true;
                    obtenerPermisos();
                }
            }
        }

        private void frmPerfiles_Load(object sender, EventArgs e)
        {
            llenaPermisos();
            limpiar();
            llenaGrid();

            if (gv.DataRowCount == 0)
            {
                botones(1);
            }
        }
    }
}
