using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using Microsoft.Reporting.WinForms;

namespace Reportes
{
    public partial class frmPrint : XtraForm
    {
        #region Properties
        string Reporte;
        ReportDataSource Source;
        List<ReportParameter> Parametros = new List<ReportParameter>();
        #endregion Properties

        public frmPrint(string reporte, ReportDataSource source, List<ReportParameter> parametros)
        {
            InitializeComponent();

            this.Reporte = reporte;
            this.Source = source;
            this.Parametros = parametros;
        }

        private void frmPrint_Load(object sender, EventArgs e)
        {
            if (Source != null) this.viewer.LocalReport.DataSources.Add(Source);

            this.viewer.LocalReport.ReportEmbeddedResource = "Reportes.Diseño." + Reporte + ".rdlc";

            this.viewer.LocalReport.EnableExternalImages = true;

            if (Parametros != null)
                this.viewer.LocalReport.SetParameters(Parametros);

            this.viewer.LocalReport.DisplayName = this.Text;
            this.viewer.ZoomMode = ZoomMode.Percent;
            this.viewer.ZoomPercent = 100;
            this.viewer.RefreshReport();
        }
    }
}