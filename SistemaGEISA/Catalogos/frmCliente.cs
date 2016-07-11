using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GeisaBD;
using System.Data.Common;
using System.IO;

namespace SistemaGEISA
{
    public partial class frmCliente : DevExpress.XtraEditors.XtraForm
    {
        private Controler _controler = new Controler();

        private Controler Controler
        {
            get
            {
                return _controler;
            }
        }

        private Cliente cliente { get; set; }
        public frmCliente()
        {
            InitializeComponent();
            Controler.PermisosEnFormulario(Name);
            btnNuevo.Enabled = Controler.TienePermiso(PermisosEnum.Agregar);
            btnEditar.Enabled = Controler.TienePermiso(PermisosEnum.Actualizar);
            btnActivo.Enabled = Controler.TienePermiso(PermisosEnum.ActivarDesactivar);
            //btnEliminar.Enabled = Controler.TienePermiso(PermisosEnum.Eliminar);
        }

        private void llenaGrid()
        {
            grid.DataSource = Controler.Model.Cliente.ToList();
        }

        private void botones(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    btnNuevo.Visible = true;

                    btnEditar.Visible = false;

                    btnActivo.Visible = false;
                    btnEliminar.Visible = false;
                    break;
                case 2:
                    btnNuevo.Visible = true;

                    btnEditar.Visible = true;

                    btnActivo.Visible = true;
                    btnEliminar.Visible = true;
                    break;
            }
        }

        private void abrirForm(bool nuevo)
        {
            var form = new frmClienteNew(Controler);
            form.Text = "Cliente : " + (nuevo ? "Nuevo" : "Editar");
            if (!nuevo)
            {
                form.cliente = cliente;
            }
            else
            {
                form.cliente = null;
            }
            form.ShowDialog();

            if (nuevo)
            {
                 llenaGrid();
            }
            else
            {
                cliente.AcualizaDomicilio();
                grid.RefreshDataSource();
            }

            gv_FocusedRowChanged(null, null);
        }

        private void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gv.DataRowCount > 0)
            {
                cliente = gv.GetFocusedRow() as Cliente;

                if (cliente != null)
                {
                    botones(2);
                    if (cliente.Activo == true)
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
        private void frmCliente_Load(object sender, EventArgs e)
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
            cliente.Activo = btnActivo.Text == "Activar" ? true : false;
            Controler.Model.SaveChanges();
            grid.RefreshDataSource();
            gv_FocusedRowChanged(null, null);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Domicilios domicilio;
            frmMessageBox msg = new frmMessageBox(false) { Message = "¿Estas seguro de eliminar este Cliente?", Title = "Eliminar Registro" };
            msg.ShowDialog();

            if (msg.DialogResult == System.Windows.Forms.DialogResult.Yes)
            {
                if (cliente != null)
                {
                    DbTransaction transaccion = null;
                    try
                    {
                    transaccion = Controler.Model.BeginTransaction();
                    int obrasCount = Controler.Model.Obra.Where(b => b.ClienteId == cliente.Id).Count();
                        if(obrasCount>0){
                            new frmMessageBox(true) { Message = "El Cliente tiene obras asociadas, No es posible Eliminar.", Title = "Aviso" }.ShowDialog();
                            if(transaccion!=null) transaccion.Rollback();
                            return;
                        }
                        
                        
                        if (cliente.Domicilio != null)
                            domicilio = cliente.Domicilio;
                        else
                            domicilio = null;

                        if (domicilio != null)
                        {
                            Controler.Model.DeleteObject(domicilio);
                            Controler.Model.DeleteObject(cliente);
                        }
                        else{
                            Controler.Model.DeleteObject(cliente);
                        }
                           
                            Controler.Model.SaveChanges();
                            transaccion.Commit();
                            new frmMessageBox(true) { Message = "El Cliente ha sido Eliminado.", Title = "Aviso" }.ShowDialog();
                            gv.DeleteRow(gv.FocusedRowHandle);
                     
                    }   
                        catch (Exception ex)
                        {
                            new frmMessageBox(true) { Message = "Error al quitar el Cliente: " + ex.InnerException.Message, Title = "Error" }.ShowDialog();
                            if(transaccion!=null) transaccion.Rollback();
                        }
                    }
                    else
                    {
                        new frmMessageBox(true) { Message = "El Cliente tiene Obras Asociadas.", Title = "Error" }.ShowDialog();
                    }
                    }
                    else
                    {
                        new frmMessageBox(true) { Message = "Seleccione un Cliente a Eliminar.", Title = "Aviso" }.ShowDialog();
                    }
                
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
            }
        }

        private void btnExportar_Click_1(object sender, EventArgs e)
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
            }
        }
        }
    }
