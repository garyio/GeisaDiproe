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
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;
using System.Collections;

namespace Reportes
{
    public partial class frmCuentasPorPagar : DevExpress.XtraEditors.XtraForm
    {
        public frmCuentasPorPagar()
        {
            InitializeComponent();
        }

        private void llenaCombos()
        {

            using (GEISAEntities empresa = new GEISAEntities(GEISAEntities.DefaultConnectionString))
            {
                chkEmpresa.DataSource = empresa.Empresa.ToList().OrderBy(o => o.NombreFiscal);
                chkEmpresa.DisplayMember = "NombreFiscal";
                chkEmpresa.ValueMember = "Id";
            }

            using (GEISAEntities proveedor = new GEISAEntities(GEISAEntities.DefaultConnectionString))
            {
                ckListBox.DataSource = proveedor.Proveedor.ToList().OrderBy(o => o.NombreFiscal);
                ckListBox.DisplayMember = "NombreFiscal";
                ckListBox.ValueMember = "Id";
                ckListBox.IncrementalSearch = true;
                //ckListBox.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            }

            using (GEISAEntities obra = new GEISAEntities(GEISAEntities.DefaultConnectionString))
            {
                ckListObra.DataSource = obra.Obra.OrderBy(o => o.Nombre).ToList();
                ckListObra.DisplayMember = "Nombre";
                ckListObra.ValueMember = "Id";
                ckListObra.IncrementalSearch = true;
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
            chkEmpresa.UnCheckAll();
            ckListBox.UnCheckAll();
            dateIni.EditValue = DateTime.Today;
            dateFin.EditValue = DateTime.Today;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {

            string proveedores=string.Empty;
            string Empresas = string.Empty;
            string EmpresasNombre = string.Empty;
            string obras = string.Empty;

            if (chkEmpresa.CheckedItems.Count > 0)
            {
                foreach (Empresa item in chkEmpresa.CheckedItems)
                {
                    Empresas = Empresas + string.Concat(item.Id, ",");
                    EmpresasNombre = EmpresasNombre + string.Concat(item.NombreComercial, ",");

                }
                Empresas = Empresas.TrimEnd(',');
                EmpresasNombre = EmpresasNombre.TrimEnd(',');
            }
            else
            {
                GEISAEntities Cliente = new GEISAEntities(GEISAEntities.DefaultConnectionString);
                foreach (Empresa item in Cliente.Empresa.ToList())
                {
                    Empresas = Empresas + string.Concat(item.Id, ",");
                }
                Empresas = Empresas.TrimEnd(',');
            }

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

            if (chkEmpresa.ItemCount > 0 && ckListBox.ItemCount > 0)
            {
                List<ReportParameter> paramReport = new List<ReportParameter>();
                //Empresa empresa = luEmpresa.GetSelectedDataRow() as Empresa;

                //this.viewer.LocalReport.Refresh();
                this.viewer.LocalReport.EnableExternalImages = true;
                //if (empresa.Imagen != null)
                //{
                //    Image Logo = Funciones.ArrayAImage(empresa.Imagen);
                //    string strPathAppUser = string.Concat(Application.UserAppDataPath + "\\Logo.jpg");
                //    Logo.Save(strPathAppUser, System.Drawing.Imaging.ImageFormat.Jpeg);
                //    paramReport.Add(new ReportParameter("PathLogo", strPathAppUser));

                    
                //    if (paramReport != null)
                //        this.viewer.LocalReport.SetParameters(paramReport);
                //}
                //else
                //{
                //    paramReport.Add(new ReportParameter("PathLogo", string.Empty));
                //    this.viewer.LocalReport.SetParameters(paramReport);
                //}

                //source.DataSource = new CuentasPorPagar((DateTime)dateIni.EditValue, (DateTime)dateFin.EditValue, Empresas, proveedores,obras).Items;
                this.viewer.LocalReport.DataSources.Clear();
                this.viewer.LocalReport.DataSources.Add(new ReportDataSource { Name = "DataSet1", Value = new BindingSource { DataSource = new CuentasPorPagar((DateTime)dateIni.EditValue, (DateTime)dateFin.EditValue, Empresas, proveedores, obras,EmpresasNombre).Items } });
                this.viewer.LocalReport.ReportEmbeddedResource = "Reportes.Diseño." + rgReporte.EditValue.ToString() + ".rdlc";
                System.Drawing.Printing.PageSettings pg = new System.Drawing.Printing.PageSettings();
                pg.Margins.Top = 1;
                pg.Margins.Bottom = 1;
                pg.Margins.Left = 1;
                pg.Margins.Right = 1;
                //System.Drawing.Printing.PaperSize size = new PaperSize();
                //size.RawKind = (int)PaperKind.Letter;
                //pg.PaperSize = size;
                pg.Landscape = true;
                this.viewer.SetPageSettings(pg);                       
                this.viewer.ZoomPercent = 100;
                this.viewer.LocalReport.DisplayName = this.Text;
                this.viewer.RefreshReport();
                
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                ckListBox.CheckAll();
            else
                ckListBox.UnCheckAll();
        }

        private void chkObraTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkObraTodos.Checked == true)
                ckListObra.CheckAll();
            else
                ckListObra.UnCheckAll();
        }

        private void chkObraGeisa_CheckedChanged(object sender, EventArgs e)
        {
            ckListObra.UnCheckAll();
            ckListObra.ForceInitialize();
            for (int i = 0; i < (ckListObra.DataSource as IList).Count; i++)
            {
                Obra obra = ckListObra.GetItem(i) as Obra;
                //Obra CurrentObra= obra.SelectedValue as Obra;
                if (obra.EmpresaId == TipoEmpresa.GEISA.Id)
                    if (chkObraGeisa.Checked == false)
                        ckListObra.SetItemCheckState(i, CheckState.Unchecked);
                    else
                        ckListObra.SetItemCheckState(i, CheckState.Checked);
                else
                    ckListObra.SetItemCheckState(i, CheckState.Unchecked);
            }    
        }

        private void chkObraDiproe_CheckedChanged(object sender, EventArgs e)
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
