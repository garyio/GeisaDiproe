namespace Reportes
{
    partial class frmNominaSemanal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNominaSemanal));
            this.source = new System.Windows.Forms.BindingSource(this.components);
            this.ckListObra = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.chkListEmpleados = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chkTodosObras = new System.Windows.Forms.CheckBox();
            this.chkGeisa = new System.Windows.Forms.CheckBox();
            this.chkDiproe = new System.Windows.Forms.CheckBox();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.rgOpcion = new DevExpress.XtraEditors.RadioGroup();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblNomina = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnReporte = new System.Windows.Forms.ToolStripButton();
            this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.viewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.chkTodosEmpleados = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSemana = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.source)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckListObra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkListEmpleados)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgOpcion.Properties)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // source
            // 
            this.source.DataSource = typeof(Reportes.NominasSemanalItem);
            // 
            // ckListObra
            // 
            this.ckListObra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckListObra.Location = new System.Drawing.Point(176, 188);
            this.ckListObra.Name = "ckListObra";
            this.ckListObra.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ckListObra.Size = new System.Drawing.Size(282, 79);
            this.ckListObra.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.ckListObra.TabIndex = 19;
            // 
            // chkListEmpleados
            // 
            this.chkListEmpleados.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkListEmpleados.Location = new System.Drawing.Point(565, 188);
            this.chkListEmpleados.Name = "chkListEmpleados";
            this.chkListEmpleados.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.chkListEmpleados.Size = new System.Drawing.Size(278, 79);
            this.chkListEmpleados.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.chkListEmpleados.TabIndex = 20;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.chkTodosObras, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkGeisa, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.chkDiproe, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(464, 188);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(95, 77);
            this.tableLayoutPanel2.TabIndex = 21;
            // 
            // chkTodosObras
            // 
            this.chkTodosObras.AutoSize = true;
            this.chkTodosObras.Location = new System.Drawing.Point(3, 3);
            this.chkTodosObras.Name = "chkTodosObras";
            this.chkTodosObras.Size = new System.Drawing.Size(55, 17);
            this.chkTodosObras.TabIndex = 17;
            this.chkTodosObras.Text = "Todos";
            this.chkTodosObras.UseVisualStyleBackColor = true;
            this.chkTodosObras.CheckedChanged += new System.EventHandler(this.chkTodosObras_CheckedChanged);
            // 
            // chkGeisa
            // 
            this.chkGeisa.AutoSize = true;
            this.chkGeisa.Location = new System.Drawing.Point(3, 26);
            this.chkGeisa.Name = "chkGeisa";
            this.chkGeisa.Size = new System.Drawing.Size(84, 17);
            this.chkGeisa.TabIndex = 18;
            this.chkGeisa.Text = "Obras Geisa";
            this.chkGeisa.UseVisualStyleBackColor = true;
            this.chkGeisa.CheckedChanged += new System.EventHandler(this.chkGeisa_CheckedChanged);
            // 
            // chkDiproe
            // 
            this.chkDiproe.AutoSize = true;
            this.chkDiproe.Location = new System.Drawing.Point(3, 49);
            this.chkDiproe.Name = "chkDiproe";
            this.chkDiproe.Size = new System.Drawing.Size(89, 17);
            this.chkDiproe.TabIndex = 19;
            this.chkDiproe.Text = "Obras Diproe";
            this.chkDiproe.UseVisualStyleBackColor = true;
            this.chkDiproe.CheckedChanged += new System.EventHandler(this.chkDiproe_CheckedChanged);
            // 
            // monthCalendar
            // 
            this.monthCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monthCalendar.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.monthCalendar.Location = new System.Drawing.Point(182, 14);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.ShowWeekNumbers = true;
            this.monthCalendar.TabIndex = 23;
            this.monthCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
            // 
            // rgOpcion
            // 
            this.rgOpcion.Location = new System.Drawing.Point(464, 8);
            this.rgOpcion.Name = "rgOpcion";
            this.rgOpcion.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(4, "TODOS"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "SEMANAL"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "QUINCENAL"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "MENSUAL")});
            this.rgOpcion.Size = new System.Drawing.Size(95, 168);
            this.rgOpcion.TabIndex = 85;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblNomina, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.viewer, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkTodosEmpleados, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkListEmpleados, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.monthCalendar, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.ckListObra, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.rgOpcion, 3, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(932, 733);
            this.tableLayoutPanel1.TabIndex = 86;
            // 
            // lblNomina
            // 
            this.lblNomina.AutoSize = true;
            this.lblNomina.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNomina.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomina.Location = new System.Drawing.Point(565, 5);
            this.lblNomina.Name = "lblNomina";
            this.lblNomina.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblNomina.Size = new System.Drawing.Size(278, 180);
            this.lblNomina.TabIndex = 90;
            this.lblNomina.Text = "-";
            this.lblNomina.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowItemReorder = true;
            this.toolStrip1.AllowMerge = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReporte,
            this.btnLimpiar});
            this.toolStrip1.Location = new System.Drawing.Point(562, 270);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5);
            this.toolStrip1.Size = new System.Drawing.Size(284, 49);
            this.toolStrip1.TabIndex = 89;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnReporte
            // 
            this.btnReporte.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnReporte.Image = global::Reportes.Properties.Resources.Si;
            this.btnReporte.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReporte.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(94, 36);
            this.btnReporte.Text = "Consultar";
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnLimpiar.Image = global::Reportes.Properties.Resources.Limpiar1;
            this.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(67, 36);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // viewer
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.viewer, 7);
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer.DocumentMapWidth = 12;
            reportDataSource1.Name = "dsNominaSemanal";
            reportDataSource1.Value = this.source;
            this.viewer.LocalReport.DataSources.Add(reportDataSource1);
            this.viewer.LocalReport.EnableExternalImages = true;
            this.viewer.LocalReport.ReportEmbeddedResource = "Reportes.Diseño.NominaSemanal.rdlc";
            this.viewer.Location = new System.Drawing.Point(8, 322);
            this.viewer.Name = "viewer";
            this.viewer.ShowBackButton = false;
            this.viewer.ShowContextMenu = false;
            this.viewer.ShowCredentialPrompts = false;
            this.viewer.ShowDocumentMapButton = false;
            this.viewer.ShowFindControls = false;
            this.viewer.ShowParameterPrompts = false;
            this.viewer.ShowPromptAreaButton = false;
            this.viewer.ShowRefreshButton = false;
            this.viewer.ShowStopButton = false;
            this.viewer.Size = new System.Drawing.Size(916, 403);
            this.viewer.TabIndex = 87;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 180);
            this.label1.TabIndex = 0;
            this.label1.Text = "Semana Nomina";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkTodosEmpleados
            // 
            this.chkTodosEmpleados.AutoSize = true;
            this.chkTodosEmpleados.Location = new System.Drawing.Point(849, 188);
            this.chkTodosEmpleados.Name = "chkTodosEmpleados";
            this.chkTodosEmpleados.Size = new System.Drawing.Size(55, 17);
            this.chkTodosEmpleados.TabIndex = 22;
            this.chkTodosEmpleados.Text = "Todos";
            this.chkTodosEmpleados.UseVisualStyleBackColor = true;
            this.chkTodosEmpleados.CheckedChanged += new System.EventHandler(this.chkTodosEmpleados_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(8, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 85);
            this.label2.TabIndex = 86;
            this.label2.Text = "Obra";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSemana
            // 
            this.lblSemana.AutoSize = true;
            this.lblSemana.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemana.Location = new System.Drawing.Point(100, 100);
            this.lblSemana.Name = "lblSemana";
            this.lblSemana.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblSemana.Size = new System.Drawing.Size(378, 180);
            this.lblSemana.TabIndex = 88;
            this.lblSemana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmNominaSemanal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 733);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmNominaSemanal";
            this.Text = "REPORTE NOMINA SEMANAL";
            this.Load += new System.EventHandler(this.frmNominaSemanal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.source)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckListObra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkListEmpleados)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgOpcion.Properties)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.CheckedListBoxControl ckListObra;
        private DevExpress.XtraEditors.CheckedListBoxControl chkListEmpleados;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox chkTodosObras;
        private System.Windows.Forms.CheckBox chkGeisa;
        private System.Windows.Forms.CheckBox chkDiproe;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private DevExpress.XtraEditors.RadioGroup rgOpcion;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Microsoft.Reporting.WinForms.ReportViewer viewer;
        private System.Windows.Forms.CheckBox chkTodosEmpleados;
        private System.Windows.Forms.Label lblSemana;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnReporte;
        private System.Windows.Forms.ToolStripButton btnLimpiar;
        private System.Windows.Forms.Label lblNomina;
        private System.Windows.Forms.BindingSource source;
    }
}