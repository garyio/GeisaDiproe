using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GeisaBD;
using System.IO;

namespace SistemaGEISA
{
    public partial class frmEmpresa : DevExpress.XtraEditors.XtraForm
    {
        private Controler _controler = new Controler();

        private Controler Controler
        {
            get
            {
                return _controler;
            }
        }

        private Empresa empresa { get; set; }
        public frmEmpresa()
        {
            InitializeComponent();
            Controler.PermisosEnFormulario(Name);
            btnNuevo.Enabled = Controler.TienePermiso(PermisosEnum.Agregar);
            btnEditar.Enabled = Controler.TienePermiso(PermisosEnum.Actualizar);
            btnActivo.Enabled = Controler.TienePermiso(PermisosEnum.ActivarDesactivar);
        }

        private void llenaGrid()
        {
            grid.DataSource = Controler.Model.Empresa.ToList();
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
            var form = new frmEmpresaNew(Controler);
            form.Text = "Empresa : " + (nuevo ? "Nueva" : "Editar");
            if (!nuevo)
            {
                form.empresa = empresa;
            }
            else
            {
                form.empresa = null;
            }
            form.ShowDialog();

            if (nuevo)
            {
                llenaGrid();
            }
            else
            {
                empresa.AcualizaDomicilio();
                grid.RefreshDataSource();
            }

            gv_FocusedRowChanged(null, null);
        }

        private void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gv.RowCount > 0)
            {
                empresa = gv.GetFocusedRow() as Empresa;

                if (empresa != null)
                {
                    botones(2);
                    if (empresa.Activo == true)
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
        private void frmEmpresa_Load(object sender, EventArgs e)
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
            empresa.Activo = btnActivo.Text == "Activar" ? true : false;
            Controler.Model.SaveChanges();
            grid.RefreshDataSource();
            gv_FocusedRowChanged(null, null);
        }

        private void grid_Click(object sender, EventArgs e)
        {
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

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Funciones.Print(grid);
        }
    }
}
