namespace Reportes
{
    partial class frmVehiculosGasolina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVehiculosGasolina));
            this.source = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.viewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateIni = new DevExpress.XtraEditors.DateEdit();
            this.dateFin = new DevExpress.XtraEditors.DateEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnReporte = new System.Windows.Forms.ToolStripButton();
            this.btnLimpiar = new System.Windows.Forms.ToolStripButton();
            this.ckListObra = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ckTodos = new System.Windows.Forms.CheckBox();
            this.ckGeisa = new System.Windows.Forms.CheckBox();
            this.ckDiproe = new System.Windows.Forms.CheckBox();
            this.ckListEmpresas = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.ckListTipoDeposito = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.label5 = new System.Windows.Forms.Label();
            this.ckTodosDepositos = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ckListVehiculos = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.ckTodosVehiculos = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.source)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateIni.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckListObra)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckListEmpresas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckListTipoDeposito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckListVehiculos)).BeginInit();
            this.SuspendLayout();
            // 
            // source
            // 
            this.source.DataSource = typeof(Reportes.VehiculoDetalleGasolinaItems);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.viewer, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateIni, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dateFin, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.ckListObra, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.ckListEmpresas, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.ckListTipoDeposito, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.ckTodosDepositos, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.ckListVehiculos, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.ckTodosVehiculos, 5, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(889, 402);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // viewer
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.viewer, 6);
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer.DocumentMapWidth = 12;
            reportDataSource1.Name = "dsVehiculoGasolina";
            reportDataSource1.Value = this.source;
            this.viewer.LocalReport.DataSources.Add(reportDataSource1);
            this.viewer.LocalReport.ReportEmbeddedResource = "Reportes.Diseño.VehiculosGasolinaDetalle.rdlc";
            this.viewer.Location = new System.Drawing.Point(8, 292);
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
            this.viewer.Size = new System.Drawing.Size(876, 102);
            this.viewer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Inicio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(467, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha Fin:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(8, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 101);
            this.label4.TabIndex = 7;
            this.label4.Text = "Empresa";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dateIni
            // 
            this.dateIni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateIni.EditValue = null;
            this.dateIni.Location = new System.Drawing.Point(82, 8);
            this.dateIni.Name = "dateIni";
            this.dateIni.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateIni.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateIni.Size = new System.Drawing.Size(278, 20);
            this.dateIni.TabIndex = 10;
            // 
            // dateFin
            // 
            this.dateFin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateFin.EditValue = null;
            this.dateFin.Location = new System.Drawing.Point(545, 8);
            this.dateFin.Name = "dateFin";
            this.dateFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFin.Size = new System.Drawing.Size(278, 20);
            this.dateFin.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(8, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 108);
            this.label3.TabIndex = 4;
            this.label3.Text = "Obra";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowItemReorder = true;
            this.toolStrip1.AllowMerge = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReporte,
            this.btnLimpiar});
            this.toolStrip1.Location = new System.Drawing.Point(542, 240);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5);
            this.toolStrip1.Size = new System.Drawing.Size(284, 49);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnReporte
            // 
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
            this.btnLimpiar.Image = global::Reportes.Properties.Resources.Limpiar1;
            this.btnLimpiar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(67, 36);
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // ckListObra
            // 
            this.ckListObra.Location = new System.Drawing.Point(82, 135);
            this.ckListObra.Name = "ckListObra";
            this.ckListObra.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ckListObra.Size = new System.Drawing.Size(278, 102);
            this.ckListObra.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.ckListObra.TabIndex = 18;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.ckTodos, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.ckGeisa, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.ckDiproe, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(366, 135);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(95, 100);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // ckTodos
            // 
            this.ckTodos.AutoSize = true;
            this.ckTodos.Location = new System.Drawing.Point(3, 3);
            this.ckTodos.Name = "ckTodos";
            this.ckTodos.Size = new System.Drawing.Size(55, 17);
            this.ckTodos.TabIndex = 17;
            this.ckTodos.Text = "Todos";
            this.ckTodos.UseVisualStyleBackColor = true;
            this.ckTodos.CheckedChanged += new System.EventHandler(this.ckTodos_CheckedChanged);
            // 
            // ckGeisa
            // 
            this.ckGeisa.AutoSize = true;
            this.ckGeisa.Location = new System.Drawing.Point(3, 26);
            this.ckGeisa.Name = "ckGeisa";
            this.ckGeisa.Size = new System.Drawing.Size(84, 17);
            this.ckGeisa.TabIndex = 18;
            this.ckGeisa.Text = "Obras Geisa";
            this.ckGeisa.UseVisualStyleBackColor = true;
            this.ckGeisa.CheckedChanged += new System.EventHandler(this.ckGeisa_CheckedChanged);
            // 
            // ckDiproe
            // 
            this.ckDiproe.AutoSize = true;
            this.ckDiproe.Location = new System.Drawing.Point(3, 49);
            this.ckDiproe.Name = "ckDiproe";
            this.ckDiproe.Size = new System.Drawing.Size(89, 17);
            this.ckDiproe.TabIndex = 19;
            this.ckDiproe.Text = "Obras Diproe";
            this.ckDiproe.UseVisualStyleBackColor = true;
            this.ckDiproe.CheckedChanged += new System.EventHandler(this.ckDiproe_CheckedChanged);
            // 
            // ckListEmpresas
            // 
            this.ckListEmpresas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckListEmpresas.Location = new System.Drawing.Point(82, 34);
            this.ckListEmpresas.Name = "ckListEmpresas";
            this.ckListEmpresas.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ckListEmpresas.Size = new System.Drawing.Size(278, 95);
            this.ckListEmpresas.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.ckListEmpresas.TabIndex = 20;
            // 
            // ckListTipoDeposito
            // 
            this.ckListTipoDeposito.Location = new System.Drawing.Point(545, 135);
            this.ckListTipoDeposito.Name = "ckListTipoDeposito";
            this.ckListTipoDeposito.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ckListTipoDeposito.Size = new System.Drawing.Size(278, 102);
            this.ckListTipoDeposito.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.ckListTipoDeposito.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(467, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 108);
            this.label5.TabIndex = 12;
            this.label5.Text = "Tipo Deposito";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ckTodosDepositos
            // 
            this.ckTodosDepositos.AutoSize = true;
            this.ckTodosDepositos.Location = new System.Drawing.Point(829, 135);
            this.ckTodosDepositos.Name = "ckTodosDepositos";
            this.ckTodosDepositos.Size = new System.Drawing.Size(55, 17);
            this.ckTodosDepositos.TabIndex = 15;
            this.ckTodosDepositos.Text = "Todos";
            this.ckTodosDepositos.UseVisualStyleBackColor = true;
            this.ckTodosDepositos.CheckedChanged += new System.EventHandler(this.ckTodosDepositos_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(467, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 101);
            this.label6.TabIndex = 21;
            this.label6.Text = "Vehiculos";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ckListVehiculos
            // 
            this.ckListVehiculos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckListVehiculos.Location = new System.Drawing.Point(545, 34);
            this.ckListVehiculos.Name = "ckListVehiculos";
            this.ckListVehiculos.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ckListVehiculos.Size = new System.Drawing.Size(278, 95);
            this.ckListVehiculos.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.ckListVehiculos.TabIndex = 22;
            // 
            // ckTodosVehiculos
            // 
            this.ckTodosVehiculos.AutoSize = true;
            this.ckTodosVehiculos.Location = new System.Drawing.Point(829, 34);
            this.ckTodosVehiculos.Name = "ckTodosVehiculos";
            this.ckTodosVehiculos.Size = new System.Drawing.Size(55, 17);
            this.ckTodosVehiculos.TabIndex = 23;
            this.ckTodosVehiculos.Text = "Todos";
            this.ckTodosVehiculos.UseVisualStyleBackColor = true;
            this.ckTodosVehiculos.CheckedChanged += new System.EventHandler(this.ckTodosVehiculos_CheckedChanged);
            // 
            // frmVehiculosGasolina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 402);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmVehiculosGasolina";
            this.Text = "REPORTE CONSUMO DE GASOLINA";
            this.Load += new System.EventHandler(this.frmVehiculosGasolina_Load);
            ((System.ComponentModel.ISupportInitialize)(this.source)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateIni.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckListObra)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckListEmpresas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckListTipoDeposito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckListVehiculos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Microsoft.Reporting.WinForms.ReportViewer viewer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.DateEdit dateIni;
        private DevExpress.XtraEditors.DateEdit dateFin;
        private DevExpress.XtraEditors.CheckedListBoxControl ckListTipoDeposito;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox ckTodosDepositos;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnReporte;
        private System.Windows.Forms.ToolStripButton btnLimpiar;
        private DevExpress.XtraEditors.CheckedListBoxControl ckListObra;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox ckTodos;
        private System.Windows.Forms.CheckBox ckGeisa;
        private System.Windows.Forms.CheckBox ckDiproe;
        private DevExpress.XtraEditors.CheckedListBoxControl ckListEmpresas;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.CheckedListBoxControl ckListVehiculos;
        private System.Windows.Forms.CheckBox ckTodosVehiculos;
        private System.Windows.Forms.BindingSource source;
    }
}