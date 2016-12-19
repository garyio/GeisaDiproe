using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GeisaBD;
using System.IO;
using System.Data.Common;

namespace SistemaGEISA
{
    public partial class frmEmpleado : DevExpress.XtraEditors.XtraForm
    {
        private Controler _controler = new Controler();

        private Controler Controler
        {
            get
            {
                return _controler;
            }
        }

        bool tienePermisoAgregar, tienePermisoModificar, tienePermisoNomina,tienePermisoEliminar;

        private Empleado empleado { get; set; }
        public frmEmpleado()
        {
            InitializeComponent();
            Controler.PermisosEnFormulario(Name);
            btnNuevo.Enabled = tienePermisoAgregar = Controler.TienePermiso(PermisosEnum.Agregar);
            btnEditar.Enabled = tienePermisoModificar = Controler.TienePermiso(PermisosEnum.Actualizar);
            btnActivo.Enabled = Controler.TienePermiso(PermisosEnum.ActivarDesactivar);
            tienePermisoNomina = Controler.TienePermiso(PermisosEnum.Nominas);
            btnEliminar.Enabled = tienePermisoEliminar = Controler.TienePermiso(PermisosEnum.Eliminar);
        }

        private void llenaGrid()
        {
            grid.DataSource = Controler.Model.Empleado.ToList();
        }

        private void botones(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    btnNuevo.Visible = true;
                    toolStripSeparator1.Visible = false;
                    btnEditar.Visible = false;
                    toolStripSeparator2.Visible = false;
                    btnActivo.Visible = false;
                    break;
                case 2:
                    btnNuevo.Visible = true;
                    toolStripSeparator1.Visible = true;
                    btnEditar.Visible = true;
                    toolStripSeparator2.Visible = true;
                    btnActivo.Visible = true;
                    break;
            }
        }

        private void abrirForm(bool nuevo)
        {
            var form = new frmEmpleadoNew(Controler);
            form.Text = "Empleado : " + (nuevo ? "Nuevo" : "Editar");
            form.tienePermisoAgregar = tienePermisoAgregar;
            form.tienePermisoModificar = tienePermisoModificar;
            form.tienePermisoNominas = tienePermisoNomina;

            if (!nuevo)
            {
                form.empleado = empleado;
            }
            else
            {
                form.empleado = null;
            }
            form.ShowDialog();

            if (nuevo)
            {
                llenaGrid();
            }
            else
            {
                grid.RefreshDataSource();
            }

            gv_FocusedRowChanged(null, null);
        }

        private void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gv.DataRowCount > 0)
            {
                empleado = gv.GetFocusedRow() as Empleado;

                if (empleado != null)
                {
                    botones(2);
                    if (empleado.Activo == true)
                    {
                        btnActivo.Image = Properties.Resources.Desactivar;
                        btnActivo.Text = "Desactivar";
                    }
                    else
                    {
                        btnActivo.Image = Properties.Resources.Activo;
                        btnActivo.Text = "Activar";
                    }

                    btnActivo.ToolTipText = btnActivo.Text;
                }
            }
        }
        private void gv_DoubleClick(object sender, EventArgs e)
        {
            var view = (DevExpress.XtraGrid.Views.Grid.GridView)sender;
            var pt = view.GridControl.PointToClient(Control.MousePosition);
            var info = view.CalcHitInfo(pt);

            if (info.InRow || info.InRowCell)
            {
                btnEditar_Click(null, null);
            }
        }
        private void frmEmpleado_Load(object sender, EventArgs e)
        {
            llenaGrid();

            if (gv.DataRowCount == 0)
            {
                botones(1);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            abrirForm(true);
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (gv.SelectedRowsCount == 1)
            {
                abrirForm(false);
            }
            else
            {
                new frmMessageBox(true) { Message = "Favor de seleccionar el elemento a editar.", Title = "Confirmación" }.ShowDialog();
            }
        }
        private void btnActivo_Click(object sender, EventArgs e)
        {
            empleado.Activo = btnActivo.Text == "Activar" ? true : false;
            Controler.Model.SaveChanges();
            grid.RefreshDataSource();
            gv_FocusedRowChanged(null, null);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Excel (2003)(.xls)|*.xls|Excel (2010) (.xlsx)|*.xlsx |RichText File (.rtf)|*.rtf |Pdf File (.pdf)|*.pdf |Html File (.html)|*.html";
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {

                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;
                    switch (fileExtenstion)
                    {
                        case ".xls":
                            gv.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            gv.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            gv.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            gv.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            gv.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            gv.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }
                }
            } //
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            frmMessageBox msg = new frmMessageBox(false) { Message = "¿Estas seguro de eliminar este Empleado?", Title = "Eliminar Registro" };
            msg.ShowDialog();

            if (msg.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                if (empleado != null)
                {
                    DbTransaction transaccion = null;
                    try
                    {
                        transaccion = Controler.Model.BeginTransaction();

                        Controler.Model.DeleteObject(empleado);

                        Controler.Model.SaveChanges();
                        transaccion.Commit();
                        new frmMessageBox(true) { Message = "El Empleado ha sido Eliminado.", Title = "Aviso" }.ShowDialog();
                        gv.DeleteRow(gv.FocusedRowHandle);
                        gv.RefreshData();
                    }
                    catch (Exception ex)
                    {
                        if (transaccion != null) transaccion.Rollback();
                        new frmMessageBox(true) { Message = "El Empleado tiene Documentos Asociadas, no es posible Eliminar.\n" + (ex.GetBaseException().Message), Title = "Error" }.ShowDialog();
                    }
                }
                else
                {
                    new frmMessageBox(true) { Message = "El Empleado tiene Documentos Asociadas, no es posible Eliminar.", Title = "Aviso" }.ShowDialog();
                }
            }
            else
            {
                new frmMessageBox(true) { Message = "Seleccione un Empleado a Eliminar.", Title = "Aviso" }.ShowDialog();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Funciones.Print(grid);
        }
    }
}
