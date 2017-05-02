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
    public partial class frmIngresosMensualesPorEmpresa : DevExpress.XtraEditors.XtraForm
    {
        public frmIngresosMensualesPorEmpresa()
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
                chkEmpresa.DataSource = empresa.Empresa.ToList().OrderBy(o => o.NombreFiscal);
                chkEmpresa.DisplayMember = "NombreFiscal";
                chkEmpresa.ValueMember = "Id";
            }

            using (GEISAEntities obra = new GEISAEntities(GEISAEntities.DefaultConnectionString))
            {
                ckListObra.DataSource = obra.Obra.OrderBy(o => o.Nombre).ToList();
                ckListObra.DisplayMember = "Nombre";
                ckListObra.ValueMember = "Id";
                ckListObra.IncrementalSearch = true;
                //ckListClientes.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            }

            using (GEISAEntities cliente = new GEISAEntities(GEISAEntities.DefaultConnectionString))
            {
                ckListClientes.DataSource = cliente.Cliente.ToList().OrderBy(o => o.NombreFiscal);
                ckListClientes.DisplayMember = "NombreFiscal";
                ckListClientes.ValueMember = "Id";
                ckListClientes.SortOrder = System.Windows.Forms.SortOrder.Ascending;
                ckListClientes.IncrementalSearch = true;
                //ckListClientes.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            }
        }

        private void frmIngresosMensualesPorEmpresa_Load(object sender, EventArgs e)
        {
            dateIni.EditValue = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dateFin.EditValue = ((DateTime)dateIni.EditValue).AddMonths(1).AddSeconds(-1);
            llenaCombos();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
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
                    if (ckGeisa.Checked == false)
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
                    if (ckDiproe.Checked == false)
                        ckListObra.SetItemCheckState(i, CheckState.Unchecked);
                    else
                        ckListObra.SetItemCheckState(i, CheckState.Checked);
                else
                    ckListObra.SetItemCheckState(i, CheckState.Unchecked);

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                ckListClientes.CheckAll();
            else
                ckListClientes.UnCheckAll();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            //luObra.EditValue = null;
            dateIni.EditValue = DateTime.Today;
            dateFin.EditValue = DateTime.Today;
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            string Clientees = string.Empty;
            string obras = string.Empty;
            string Empresas = string.Empty;

            if (chkEmpresa.CheckedItems.Count > 0)
            {
                foreach (Empresa item in chkEmpresa.CheckedItems)
                {
                    Empresas = Empresas + string.Concat(item.Id, ",");
                }
                Empresas = Empresas.TrimEnd(',');
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


            if (ckListClientes.CheckedItems.Count > 0)
            {
                foreach (Cliente item in ckListClientes.CheckedItems)
                {
                    Clientees = Clientees + string.Concat(item.Id, ",");
                }
                Clientees = Clientees.TrimEnd(',');
            }
            else
            {
                GEISAEntities Cliente = new GEISAEntities(GEISAEntities.DefaultConnectionString);
                foreach (Cliente item in Cliente.Cliente.ToList())
                {
                    Clientees = Clientees + string.Concat(item.Id, ",");
                }
                Clientees = Clientees.TrimEnd(',');
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

            if (ckListClientes.ItemCount > 0 && chkEmpresa.ItemCount > 0 && ckListObra.ItemCount > 0)
            {
                List<ReportParameter> paramReport = new List<ReportParameter>();

                ////Valido empresa seleccionada para resumen de facturas rpeorte.
                //bool geisa=false,diproe=false;
                //foreach (Empresa item in chkEmpresa.CheckedItems)
                //{
                //    if(item == TipoEmpresa.GEISA || item==TipoEmpresa.GEISA_PERIFERICA)
                //        geisa=true;
                //    if(item == TipoEmpresa.DIPROE)
                //        diproe = true;                                            
                //}

                //if(geisa && diproe)

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
                this.viewer.LocalReport.DataSources.Clear();
                this.viewer.LocalReport.DataSources.Add(new ReportDataSource { Name = "dsIngresosMensuales", Value = new BindingSource { DataSource = new IngresosMensualesPorEmpresa(obras, (DateTime)dateIni.EditValue, (DateTime)dateFin.EditValue, Empresas, Clientees).Items } });
                this.viewer.LocalReport.ReportEmbeddedResource = "Reportes.Diseño." + rgReporte.EditValue.ToString() + ".rdlc";

                //source.DataSource = new IngresosMensualesPorEmpresa(obras, (DateTime)dateIni.EditValue, (DateTime)dateFin.EditValue, Empresas, Clientees).Items;
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
    }

}
