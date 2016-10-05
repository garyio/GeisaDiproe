using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GeisaBD;
using System.Data;
using System.IO;

namespace SistemaGEISA
{
    public partial class frmTarjetasCredito : DevExpress.XtraEditors.XtraForm
    {
       private Controler _controler = new Controler();

        private Controler Controler
        {
            get
            {
                return _controler;
            }
        }

        private TarjetasCredito tarjetaCredito { get; set; }
        public frmTarjetasCredito()
        {
            InitializeComponent();
            Controler.PermisosEnFormulario(Name);
            btnNuevo.Enabled = Controler.TienePermiso(PermisosEnum.Agregar);
            btnEditar.Enabled = Controler.TienePermiso(PermisosEnum.Actualizar);
        }

        private void llenaGrid()
        {
            luBanco.DataSource = _controler.Model.Bancos.ToList();
            luBanco.DisplayMember = "Nombre";
            luBanco.ValueMember = "Id";

            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("NombreEmpleado", typeof(String));

            foreach (Empleado e in _controler.Model.Empleado.ToList())
            {
                dt.Rows.Add(e.Id, e.NombreCompleto);
            }

            luEmpleado.DataSource = dt;
            luEmpleado.DisplayMember = "NombreEmpleado";
            luEmpleado.ValueMember = "Id";

            grid.DataSource = Controler.Model.TarjetasCredito.ToList();
        }

        private void botones(int opcion)
        {
            switch (opcion)
            {
                case 1:
                    btnNuevo.Visible = true;
                    toolStripSeparator1.Visible = false;
                    btnEditar.Visible = false;
                    break;
                case 2:
                    btnNuevo.Visible = true;
                    toolStripSeparator1.Visible = true;
                    btnEditar.Visible = true;
                    break;
            }
        }

        private void abrirForm(bool nuevo)
        {
            var form = new frmTarjetasCreditoNew(Controler);
            form.Text = "Tarjeta de Credito : " + (nuevo ? "Nuevo" : "Editar");
            if (!nuevo)
            {
                form.tarjetaCredito = tarjetaCredito;
            }
            else
            {
                form.tarjetaCredito = null;
            }

            form.ShowDialog();

            if (form.DialogResult == DialogResult.OK)
            {
                llenaGrid();
            }

            gv_FocusedRowChanged(null, null);
        }

        private void gv_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gv.DataRowCount > 0)
            {
                tarjetaCredito = gv.GetFocusedRow() as TarjetasCredito;

                if (tarjetaCredito != null)
                {
                    botones(2);
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
        private void frmTarjetasCredito_Load(object sender, EventArgs e)
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

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            abrirForm(true);
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            //Console.WriteLine(gv.GetRowCellValue(gv.FocusedRowHandle, "Id").ToString());
            if (gv.SelectedRowsCount == 1 && string.IsNullOrEmpty(gv.GetRowCellValue(gv.FocusedRowHandle, "Id").ToString())==false)
            {
                abrirForm(false);
            }
            else
            {
                new frmMessageBox(true) { Message = "Favor de seleccionar el elemento a editar.", Title = "Confirmación" }.ShowDialog();
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
            } //
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Funciones.Print(grid);
        }
    }
}
