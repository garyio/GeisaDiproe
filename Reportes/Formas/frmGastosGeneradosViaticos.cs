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
using DevExpress.XtraEditors.Controls;
using System.Collections;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;

namespace Reportes
{
    public partial class frmGastosGeneradosViaticos : DevExpress.XtraEditors.XtraForm
    {
        public frmGastosGeneradosViaticos()
        {
            InitializeComponent();
        }

        private void llenaCombos()
        {
            //using (GEISAEntities obra = new GEISAEntities(GEISAEntities.DefaultConnectionString))
            //{
            //    luObra.Properties.DataSource = obra.Obra.ToList();
            //    luObra.Properties.DisplayMember = "Nombre";
            //    luObra.Properties.ValueMember = "Id";
            //    luObra.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            //}

            using (GEISAEntities empresa = new GEISAEntities(GEISAEntities.DefaultConnectionString))
            {
                luEmpresa.Properties.DataSource = empresa.Empresa.ToList().OrderBy(o=> o.NombreFiscal);
                luEmpresa.Properties.DisplayMember = "NombreFiscal";
                luEmpresa.Properties.ValueMember = "Id";
                luEmpresa.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            }

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
                ckListBox.DataSource = proveedor.Proveedor.ToList().OrderBy(o=>o.NombreFiscal);
                ckListBox.DisplayMember = "NombreFiscal";
                ckListBox.ValueMember = "Id";
                ckListBox.SortOrder = System.Windows.Forms.SortOrder.Ascending;
                ckListBox.IncrementalSearch = true;
                //ckListBox.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            }
        }

        private void frmGastosGeneradosViaticos_Load(object sender, EventArgs e)
        {
            dateIni.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dateFin.EditValue = ((DateTime)dateIni.EditValue).AddMonths(1).AddSeconds(-1);
            llenaCombos();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //luObra.EditValue = null;
            luEmpresa.EditValue = null;
            ckListObra.UnCheckAll();
            ckListBox.UnCheckAll();
            dateIni.EditValue = DateTime.Today;
            dateFin.EditValue = DateTime.Today;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            string proveedores=string.Empty;
            string obras = string.Empty;
            if (ckListBox.CheckedItems.Count>0)
            {
                foreach (Proveedor item in ckListBox.CheckedItems)
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
            
            if (ckListBox.ItemCount>0 && luEmpresa.EditValue != null)
            {
                List<ReportParameter> paramReport = new List<ReportParameter>();
                Empresa empresa = luEmpresa.GetSelectedDataRow() as Empresa;

                //this.viewer.LocalReport.Refresh();
                this.viewer.LocalReport.EnableExternalImages = true;
                if (empresa.Imagen != null)
                {
                    Image Logo = Funciones.ArrayAImage(empresa.Imagen);
                    string strPathAppUser = string.Concat(Application.UserAppDataPath + "\\Logo.jpg");
                    Logo.Save(strPathAppUser, System.Drawing.Imaging.ImageFormat.Jpeg);
                    paramReport.Add(new ReportParameter("PathLogo", strPathAppUser));


                    if (paramReport != null)
                        this.viewer.LocalReport.SetParameters(paramReport);
                }
                else
                {
                    paramReport.Add(new ReportParameter("PathLogo", string.Empty));
                    this.viewer.LocalReport.SetParameters(paramReport);
                }

                source.DataSource = new GastosGeneradosViaticos(obras, (DateTime)dateIni.EditValue, (DateTime)dateFin.EditValue, (Int32)luEmpresa.EditValue, proveedores).Items;
                System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
                pg.Margins.Top = 1;
                pg.Margins.Bottom = 1;
                pg.Margins.Left = 1;
                pg.Margins.Right = 1;
                //System.Drawing.Printing.PaperSize size = new PaperSize();
                //size.RawKind = (int)PaperKind.A4;
                //pg.PaperSize = size;
                ////pg.Landscape = true;                
                this.viewer.SetPageSettings(pg);
                this.viewer.ZoomPercent = 100;
                this.viewer.LocalReport.DisplayName = this.Text;
                this.viewer.RefreshReport();
                
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTodos.Checked == true)
                ckListBox.CheckAll();
            else
                ckListBox.UnCheckAll();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkObraTodos.Checked == true)
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
                    if (obra.EmpresaId== TipoEmpresa.GEISA.Id)
                        if(chkObraGeisa.Checked==false)
                            ckListObra.SetItemCheckState(i, CheckState.Unchecked);
                        else
                        ckListObra.SetItemCheckState(i, CheckState.Checked);
                    else
                        ckListObra.SetItemCheckState(i, CheckState.Unchecked);
                }            
        }

        private void ckDiproe_CheckedChanged(object sender, EventArgs e)
        {
            ckListObra.UnCheckAll();
                ckListObra.ForceInitialize();
                for (int i = 0; i < (ckListObra.DataSource as IList).Count; i++)
                {
                    Obra obra = ckListObra.GetItem(i) as Obra;
                    //Obra CurrentObra= obra.SelectedValue as Obra;
                    if (obra.EmpresaId == TipoEmpresa.DIPROE.Id)
                        if (chkObraDiproe.Checked == false)
                            ckListObra.SetItemCheckState(i, CheckState.Unchecked);
                        else
                            ckListObra.SetItemCheckState(i, CheckState.Checked);
                    else
                        ckListObra.SetItemCheckState(i, CheckState.Unchecked);

                }            
        }
    }
}
