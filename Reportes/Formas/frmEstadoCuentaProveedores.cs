using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeisaBD;
using System.Drawing.Printing;
using System.Collections;

namespace Reportes
{
    public partial class frmEstadoCuentaProveedores : XtraForm
    {
        public frmEstadoCuentaProveedores()
        {
            InitializeComponent();
            llenaCombos();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            string proveedores = string.Empty;
            string obras = string.Empty;

            if (chkListProveedor.CheckedItems.Count > 0)
            {
                foreach (Proveedor item in chkListProveedor.CheckedItems)
                {
                    proveedores = proveedores + string.Concat(item.Id, ",");
                }
                proveedores = proveedores.TrimEnd(',');
            }
            else
            {
                GEISAEntities proveedor = new GEISAEntities(GEISAEntities.DefaultConnectionString);
                foreach (Proveedor item in proveedor.Proveedor.ToList())
                {
                    proveedores = proveedores + string.Concat(item.Id, ",");
                }
                proveedores = proveedores.TrimEnd(',');
            }

            if (ckListObra.CheckedItems.Count > 0)
            {
                foreach (Obra item in ckListObra.CheckedItems)
                {
                    obras = obras + string.Concat(item.Id, ",");
                }
                obras = obras.TrimEnd(',');
            }
            else
            {
                GEISAEntities obra = new GEISAEntities(GEISAEntities.DefaultConnectionString);
                foreach (Obra item in obra.Obra.ToList())
                {
                    obras = obras + string.Concat(item.Id, ",");
                }
                obras = obras.TrimEnd(',');
            }

            //Proveedor proveedor = lookupProveedor.GetSelectedDataRow() as Proveedor;
            //Obra obra = lookupObra.GetSelectedDataRow() as Obra;

            source.DataSource = new EstadoCuentaProveedores((DateTime)dateIni.EditValue, (DateTime)dateFin.EditValue,proveedores,obras,(bool)chboxConSaldo.EditValue).Items;

            System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
            pg.Margins.Top = 1;
            pg.Margins.Bottom = 1;
            pg.Margins.Left = 1;
            pg.Margins.Right = 1;
            //System.Drawing.Printing.PaperSize size = new PaperSize();
            //size.RawKind = (int)PaperKind.Letter;
            //pg.PaperSize = size;
            pg.Landscape = false;
            this.viewer.SetPageSettings(pg);            
            this.viewer.ZoomPercent = 100;
            this.viewer.LocalReport.DisplayName = this.Text;
            this.viewer.RefreshReport();
        }

        private void llenaCombos()
        {
            using (GEISAEntities obra = new GEISAEntities(GEISAEntities.DefaultConnectionString))
            {
                ckListObra.DataSource = obra.Obra.OrderBy(o => o.Nombre).ToList();
                ckListObra.DisplayMember = "Nombre";
                ckListObra.ValueMember = "Id";
                ckListObra.IncrementalSearch = true;
                //ckListBox.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            }

            using (GEISAEntities proveedor = new GEISAEntities(GEISAEntities.DefaultConnectionString))
            {
                chkListProveedor.DataSource = proveedor.Proveedor.Where(P => P.Activo == true).ToList().OrderBy(o => o.NombreFiscal);
                chkListProveedor.DisplayMember = "NombreFiscal";
                chkListProveedor.ValueMember = "Id";
                chkListProveedor.IncrementalSearch = true;
                chkListProveedor.SortOrder = System.Windows.Forms.SortOrder.Ascending;

            }
        }

        private void frmEstadoCuentaProveedores_Load(object sender, EventArgs e)
        {
            dateIni.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dateFin.EditValue = ((DateTime)dateIni.EditValue).AddMonths(1).AddSeconds(-1);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            chkListProveedor.UnCheckAll();
            ckListObra.UnCheckAll();
            dateIni.EditValue = DateTime.Today;
            dateFin.EditValue = DateTime.Today;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkObrasTodos.Checked == true)
                ckListObra.CheckAll();
            else
                ckListObra.UnCheckAll();
        }

        private void ckGeisa_CheckedChanged(object sender, EventArgs e)
        {
            ckListObra.UnCheckAll();
            ckListObra.ForceInitialize();
            for (int i = 0; i < (ckListObra.DataSource as IList).Count; i++)
            {
                Obra obra = ckListObra.GetItem(i) as Obra;
                //Obra CurrentObra= obra.SelectedValue as Obra;
                if (obra.EmpresaId == TipoEmpresa.GEISA.Id)
                    if (chkObrasGeisa.Checked == false)
                        ckListObra.SetItemCheckState(i, CheckState.Unchecked);
                    else
                        ckListObra.SetItemCheckState(i, CheckState.Checked);
                else
                    ckListObra.SetItemCheckState(i, CheckState.Unchecked);
            }    
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked == true)
                chkListProveedor.CheckAll();
            else
                chkListProveedor.UnCheckAll();
        }

        private void chkObrasDiproe_CheckedChanged(object sender, EventArgs e)
        {
            ckListObra.UnCheckAll();
            ckListObra.ForceInitialize();
            for (int i = 0; i < (ckListObra.DataSource as IList).Count; i++)
            {
                Obra obra = ckListObra.GetItem(i) as Obra;
                //Obra CurrentObra= obra.SelectedValue as Obra;
                if (obra.EmpresaId == TipoEmpresa.DIPROE.Id)
                    if (chkObrasDiproe.Checked == false)
                        ckListObra.SetItemCheckState(i, CheckState.Unchecked);
                    else
                        ckListObra.SetItemCheckState(i, CheckState.Checked);
                else
                    ckListObra.SetItemCheckState(i, CheckState.Unchecked);

            }   
        }
    }
}
