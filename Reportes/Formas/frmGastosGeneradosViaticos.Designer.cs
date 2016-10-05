namespace Reportes
{
    partial class frmGastosGeneradosViaticos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGastosGeneradosViaticos));
            this.source = new System.Windows.Forms.BindingSource();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.viewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.luEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.dateIni = new DevExpress.XtraEditors.DateEdit();
            this.dateFin = new DevExpress.XtraEditors.DateEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ckListObra = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chkObraTodos = new System.Windows.Forms.CheckBox();
            this.chkObraGeisa = new System.Windows.Forms.CheckBox();
            this.chkObraDiproe = new System.Windows.Forms.CheckBox();
            this.ckListBox = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnReporte = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.chkTodos = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.source)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIni.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckListObra)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckListBox)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // source
            // 
            this.source.DataSource = typeof(Reportes.gastoGeneradoItem);
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.viewer, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.luEmpresa, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateIni, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dateFin, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.ckListObra, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.ckListBox, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.chkTodos, 4, 3);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(958, 408);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // viewer
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.viewer, 7);
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer.DocumentMapWidth = 12;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.source;
            this.viewer.LocalReport.DataSources.Add(reportDataSource1);
            this.viewer.LocalReport.ReportEmbeddedResource = "Reportes.Diseño.GastosGeneradosViaticos.rdlc";
            this.viewer.Location = new System.Drawing.Point(8, 191);
            this.viewer.Name = "viewer";
            this.viewer.ShowBackButton = false;
            this.viewer.ShowContextMenu = false;
            this.viewer.ShowCredentialPrompts = false;
            this.viewer.ShowDocumentMapButton = false;
            this.viewer.ShowFindControls = false;
            this.viewer.ShowParameterPrompts = false;
            this.viewer.ShowPromptAreaButton = false;
            this.viewer.ShowStopButton = false;
            this.viewer.Size = new System.Drawing.Size(942, 209);
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
            this.label2.Size = new System.Drawing.Size(57, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha Fin:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // luEmpresa
            // 
            this.luEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luEmpresa.Location = new System.Drawing.Point(82, 34);
            this.luEmpresa.Name = "luEmpresa";
            this.luEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luEmpresa.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreFiscal", "Nombre")});
            this.luEmpresa.Properties.NullText = "";
            this.luEmpresa.Size = new System.Drawing.Size(278, 20);
            this.luEmpresa.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(8, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Empresa";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.dateFin.Location = new System.Drawing.Point(530, 8);
            this.dateFin.Name = "dateFin";
            this.dateFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFin.Size = new System.Drawing.Size(278, 20);
            this.dateFin.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(467, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 108);
            this.label5.TabIndex = 12;
            this.label5.Text = "Proveedor";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(8, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 108);
            this.label3.TabIndex = 4;
            this.label3.Text = "Obra";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ckListObra
            // 
            this.ckListObra.CheckOnClick = true;
            this.ckListObra.Location = new System.Drawing.Point(82, 60);
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
            this.tableLayoutPanel2.Controls.Add(this.chkObraTodos, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkObraGeisa, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.chkObraDiproe, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(366, 60);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(95, 100);
            this.tableLayoutPanel2.TabIndex = 19;
            // 
            // chkObraTodos
            // 
            this.chkObraTodos.AutoSize = true;
            this.chkObraTodos.Location = new System.Drawing.Point(3, 3);
            this.chkObraTodos.Name = "chkObraTodos";
            this.chkObraTodos.Size = new System.Drawing.Size(55, 17);
            this.chkObraTodos.TabIndex = 17;
            this.chkObraTodos.Text = "Todos";
            this.chkObraTodos.UseVisualStyleBackColor = true;
            this.chkObraTodos.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // chkObraGeisa
            // 
            this.chkObraGeisa.AutoSize = true;
            this.chkObraGeisa.Location = new System.Drawing.Point(3, 26);
            this.chkObraGeisa.Name = "chkObraGeisa";
            this.chkObraGeisa.Size = new System.Drawing.Size(84, 17);
            this.chkObraGeisa.TabIndex = 18;
            this.chkObraGeisa.Text = "Obras Geisa";
            this.chkObraGeisa.UseVisualStyleBackColor = true;
            this.chkObraGeisa.CheckedChanged += new System.EventHandler(this.ckGeisa_CheckedChanged);
            // 
            // chkObraDiproe
            // 
            this.chkObraDiproe.AutoSize = true;
            this.chkObraDiproe.Location = new System.Drawing.Point(3, 49);
            this.chkObraDiproe.Name = "chkObraDiproe";
            this.chkObraDiproe.Size = new System.Drawing.Size(89, 17);
            this.chkObraDiproe.TabIndex = 19;
            this.chkObraDiproe.Text = "Obras Diproe";
            this.chkObraDiproe.UseVisualStyleBackColor = true;
            this.chkObraDiproe.CheckedChanged += new System.EventHandler(this.ckDiproe_CheckedChanged);
            // 
            // ckListBox
            // 
            this.ckListBox.CheckOnClick = true;
            this.ckListBox.Location = new System.Drawing.Point(530, 60);
            this.ckListBox.Name = "ckListBox";
            this.ckListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ckListBox.Size = new System.Drawing.Size(278, 102);
            this.ckListBox.SortOrder = System.Windows.Forms.SortOrder.Ascending;
            this.ckListBox.TabIndex = 13;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.btnReporte, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.btnLimpiar, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(814, 60);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(46, 102);
            this.tableLayoutPanel3.TabIndex = 21;
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
            // chkTodos
            // 
            this.chkTodos.AutoSize = true;
            this.chkTodos.Location = new System.Drawing.Point(530, 168);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Size = new System.Drawing.Size(55, 17);
            this.chkTodos.TabIndex = 15;
            this.chkTodos.Text = "Todos";
            this.chkTodos.UseVisualStyleBackColor = true;
            this.chkTodos.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // frmGastosGeneradosViaticos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 408);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGastosGeneradosViaticos";
            this.Text = "REPORTE DE GASTOS GENERADOS OBRA";
            this.Load += new System.EventHandler(this.frmGastosGeneradosViaticos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.source)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIni.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateIni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckListObra)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckListBox)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit luEmpresa;
        private System.Windows.Forms.Label label4;
        private Microsoft.Reporting.WinForms.ReportViewer viewer;
        private DevExpress.XtraEditors.DateEdit dateIni;
        private DevExpress.XtraEditors.DateEdit dateFin;
        private System.Windows.Forms.BindingSource source;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.CheckedListBoxControl ckListBox;
        private System.Windows.Forms.CheckBox chkTodos;
        private System.Windows.Forms.CheckBox chkObraTodos;
        private DevExpress.XtraEditors.CheckedListBoxControl ckListObra;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox chkObraGeisa;
        private System.Windows.Forms.CheckBox chkObraDiproe;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Button btnLimpiar;
    }
}