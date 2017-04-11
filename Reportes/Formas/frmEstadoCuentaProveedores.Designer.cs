namespace Reportes
{
    partial class frmEstadoCuentaProveedores
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstadoCuentaProveedores));
            this.source = new System.Windows.Forms.BindingSource();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ckListObra = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.chkListProveedor = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.viewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dateIni = new DevExpress.XtraEditors.DateEdit();
            this.dateFin = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.chkObrasTodos = new System.Windows.Forms.CheckBox();
            this.chkObrasGeisa = new System.Windows.Forms.CheckBox();
            this.chkObrasDiproe = new System.Windows.Forms.CheckBox();
            this.chkTodos = new System.Windows.Forms.CheckBox();
            this.chboxConSaldo = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.source)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckListObra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkListProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIni.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chboxConSaldo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // source
            // 
            this.source.DataSource = typeof(Reportes.EstadoCuentaProveedoresItem);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ckListObra, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkListProveedor, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.viewer, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dateIni, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dateFin, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkTodos, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.chboxConSaldo, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelControl5, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(846, 425);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ckListObra
            // 
            this.ckListObra.CheckOnClick = true;
            this.ckListObra.Location = new System.Drawing.Point(409, 34);
            this.ckListObra.Name = "ckListObra";
            this.ckListObra.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ckListObra.Size = new System.Drawing.Size(278, 102);
            this.ckListObra.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.ckListObra.TabIndex = 19;
            // 
            // chkListProveedor
            // 
            this.chkListProveedor.CheckOnClick = true;
            this.chkListProveedor.Location = new System.Drawing.Point(71, 34);
            this.chkListProveedor.Name = "chkListProveedor";
            this.chkListProveedor.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.chkListProveedor.Size = new System.Drawing.Size(278, 102);
            this.chkListProveedor.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.chkListProveedor.TabIndex = 14;
            // 
            // viewer
            // 
            this.viewer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tableLayoutPanel1.SetColumnSpan(this.viewer, 10);
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "EstadoCuentaProveedores";
            reportDataSource1.Value = this.source;
            this.viewer.LocalReport.DataSources.Add(reportDataSource1);
            this.viewer.LocalReport.ReportEmbeddedResource = "Reportes.Diseño.EstadoCuentaProveedores.rdlc";
            this.viewer.Location = new System.Drawing.Point(8, 167);
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
            this.viewer.Size = new System.Drawing.Size(830, 250);
            this.viewer.TabIndex = 12;
            // 
            // dateIni
            // 
            this.dateIni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateIni.EditValue = null;
            this.dateIni.Location = new System.Drawing.Point(71, 8);
            this.dateIni.Name = "dateIni";
            this.dateIni.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateIni.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateIni.Size = new System.Drawing.Size(278, 20);
            this.dateIni.TabIndex = 2;
            // 
            // dateFin
            // 
            this.dateFin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateFin.EditValue = null;
            this.dateFin.Location = new System.Drawing.Point(409, 8);
            this.dateFin.Name = "dateFin";
            this.dateFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFin.Size = new System.Drawing.Size(278, 20);
            this.dateFin.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.Location = new System.Drawing.Point(8, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(50, 13);
            this.labelControl1.TabIndex = 4;
            this.labelControl1.Text = "Proveedor";
            // 
            // labelControl2
            // 
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl2.Location = new System.Drawing.Point(355, 34);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(24, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Obra";
            // 
            // labelControl3
            // 
            this.labelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl3.Location = new System.Drawing.Point(8, 8);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(57, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Fecha Inicio";
            // 
            // labelControl4
            // 
            this.labelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl4.Location = new System.Drawing.Point(355, 8);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(46, 13);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Fecha Fin";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btnReporte, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btnLimpiar, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(794, 34);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(44, 102);
            this.tableLayoutPanel2.TabIndex = 20;
            // 
            // btnReporte
            // 
            this.btnReporte.Image = global::Reportes.Properties.Resources.Si;
            this.btnReporte.Location = new System.Drawing.Point(3, 54);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(37, 36);
            this.btnReporte.TabIndex = 13;
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Image = global::Reportes.Properties.Resources.Limpiar1;
            this.btnLimpiar.Location = new System.Drawing.Point(3, 3);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(37, 36);
            this.btnLimpiar.TabIndex = 12;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.chkObrasTodos, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.chkObrasGeisa, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.chkObrasDiproe, 0, 2);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(693, 34);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(95, 100);
            this.tableLayoutPanel3.TabIndex = 21;
            // 
            // chkObrasTodos
            // 
            this.chkObrasTodos.AutoSize = true;
            this.chkObrasTodos.Location = new System.Drawing.Point(3, 3);
            this.chkObrasTodos.Name = "chkObrasTodos";
            this.chkObrasTodos.Size = new System.Drawing.Size(55, 17);
            this.chkObrasTodos.TabIndex = 17;
            this.chkObrasTodos.Text = "Todos";
            this.chkObrasTodos.UseVisualStyleBackColor = true;
            this.chkObrasTodos.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // chkObrasGeisa
            // 
            this.chkObrasGeisa.AutoSize = true;
            this.chkObrasGeisa.Location = new System.Drawing.Point(3, 26);
            this.chkObrasGeisa.Name = "chkObrasGeisa";
            this.chkObrasGeisa.Size = new System.Drawing.Size(84, 17);
            this.chkObrasGeisa.TabIndex = 18;
            this.chkObrasGeisa.Text = "Obras Geisa";
            this.chkObrasGeisa.UseVisualStyleBackColor = true;
            this.chkObrasGeisa.CheckedChanged += new System.EventHandler(this.ckGeisa_CheckedChanged);
            // 
            // chkObrasDiproe
            // 
            this.chkObrasDiproe.AutoSize = true;
            this.chkObrasDiproe.Location = new System.Drawing.Point(3, 49);
            this.chkObrasDiproe.Name = "chkObrasDiproe";
            this.chkObrasDiproe.Size = new System.Drawing.Size(89, 17);
            this.chkObrasDiproe.TabIndex = 19;
            this.chkObrasDiproe.Text = "Obras Diproe";
            this.chkObrasDiproe.UseVisualStyleBackColor = true;
            this.chkObrasDiproe.CheckedChanged += new System.EventHandler(this.chkObrasDiproe_CheckedChanged);
            // 
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Location = new System.Drawing.Point(71, 142);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(55, 17);
            this.chkTodos.TabIndex = 22;
            this.chkTodos.Text = "Todos";
            this.chkTodos.UseVisualStyleBackColor = true;
            this.chkTodos.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // chboxConSaldo
            // 
            this.chboxConSaldo.Location = new System.Drawing.Point(409, 142);
            this.chboxConSaldo.Name = "chboxConSaldo";
            this.chboxConSaldo.Properties.Caption = "";
            this.chboxConSaldo.Size = new System.Drawing.Size(20, 19);
            this.chboxConSaldo.TabIndex = 10;
            this.chboxConSaldo.Visible = false;
            // 
            // labelControl5
            // 
            this.labelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl5.Location = new System.Drawing.Point(355, 142);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(48, 13);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "Con Saldo";
            this.labelControl5.Visible = false;
            // 
            // frmEstadoCuentaProveedores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 425);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEstadoCuentaProveedores";
            this.Text = "Estado de Cuenta Proveedores";
            this.Load += new System.EventHandler(this.frmEstadoCuentaProveedores_Load);
            ((System.ComponentModel.ISupportInitialize)(this.source)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckListObra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkListProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIni.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chboxConSaldo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.DateEdit dateIni;
        private DevExpress.XtraEditors.DateEdit dateFin;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.CheckEdit chboxConSaldo;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.Button btnLimpiar;
        private Microsoft.Reporting.WinForms.ReportViewer viewer;
        private System.Windows.Forms.BindingSource source;
        private DevExpress.XtraEditors.CheckedListBoxControl chkListProveedor;
        private DevExpress.XtraEditors.CheckedListBoxControl ckListObra;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.CheckBox chkObrasTodos;
        private System.Windows.Forms.CheckBox chkObrasGeisa;
        private System.Windows.Forms.CheckBox chkObrasDiproe;
        private System.Windows.Forms.CheckBox chkTodos;
    }
}