namespace SistemaGEISA
{
    partial class frmFacturasPendientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFacturasPendientes));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSeleccion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.checkFactura = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colNoFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProveedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObservaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConceptoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luConceptos = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colTipoContrarecibo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rgOpciones = new DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luConceptos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgOpciones)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.grid, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(819, 461);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grid
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grid, 6);
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(3, 3);
            this.grid.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.grid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grid.MainView = this.gv;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.checkFactura,
            this.luConceptos,
            this.rgOpciones});
            this.grid.Size = new System.Drawing.Size(813, 404);
            this.grid.TabIndex = 8;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Appearance.GroupPanel.BackColor = System.Drawing.Color.Transparent;
            this.gv.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.Transparent;
            this.gv.Appearance.GroupPanel.BorderColor = System.Drawing.Color.Transparent;
            this.gv.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gv.Appearance.GroupPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gv.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gv.Appearance.GroupPanel.Options.UseBorderColor = true;
            this.gv.Appearance.GroupPanel.Options.UseFont = true;
            this.gv.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colSeleccion,
            this.colNoFactura,
            this.colFecha,
            this.colImporte,
            this.colSaldo,
            this.colProveedor,
            this.colObra,
            this.colObservaciones,
            this.colConceptoId,
            this.colTipoContrarecibo});
            this.gv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gv.GridControl = this.grid;
            this.gv.GroupPanelText = "Facturas pendientes";
            this.gv.Name = "gv";
            this.gv.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gv.OptionsSelection.UseIndicatorForSelection = false;
            this.gv.OptionsView.EnableAppearanceEvenRow = true;
            this.gv.OptionsView.EnableAppearanceOddRow = true;
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.OptionsView.ShowFooter = true;
            this.gv.OptionsView.ShowIndicator = false;
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.FixedWidth = true;
            this.colId.Width = 20;
            // 
            // colSeleccion
            // 
            this.colSeleccion.ColumnEdit = this.checkFactura;
            this.colSeleccion.FieldName = "Seleccion";
            this.colSeleccion.Name = "colSeleccion";
            this.colSeleccion.OptionsColumn.FixedWidth = true;
            this.colSeleccion.OptionsColumn.ShowCaption = false;
            this.colSeleccion.Visible = true;
            this.colSeleccion.VisibleIndex = 0;
            this.colSeleccion.Width = 20;
            // 
            // checkFactura
            // 
            this.checkFactura.AutoHeight = false;
            this.checkFactura.Caption = "Check";
            this.checkFactura.Name = "checkFactura";
            this.checkFactura.ValueGrayed = true;
            // 
            // colNoFactura
            // 
            this.colNoFactura.Caption = "Factura";
            this.colNoFactura.FieldName = "NoFactura";
            this.colNoFactura.Name = "colNoFactura";
            this.colNoFactura.OptionsColumn.AllowEdit = false;
            this.colNoFactura.OptionsColumn.FixedWidth = true;
            this.colNoFactura.OptionsColumn.ReadOnly = true;
            this.colNoFactura.Visible = true;
            this.colNoFactura.VisibleIndex = 1;
            this.colNoFactura.Width = 49;
            // 
            // colFecha
            // 
            this.colFecha.Caption = "Fecha";
            this.colFecha.DisplayFormat.FormatString = "d";
            this.colFecha.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.OptionsColumn.AllowEdit = false;
            this.colFecha.OptionsColumn.FixedWidth = true;
            this.colFecha.OptionsColumn.ReadOnly = true;
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 2;
            this.colFecha.Width = 73;
            // 
            // colImporte
            // 
            this.colImporte.Caption = "Importe";
            this.colImporte.DisplayFormat.FormatString = "C2";
            this.colImporte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.OptionsColumn.AllowEdit = false;
            this.colImporte.OptionsColumn.FixedWidth = true;
            this.colImporte.OptionsColumn.ReadOnly = true;
            this.colImporte.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Importe", "{0:C2}")});
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 3;
            this.colImporte.Width = 67;
            // 
            // colSaldo
            // 
            this.colSaldo.Caption = "Saldo";
            this.colSaldo.DisplayFormat.FormatString = "C2";
            this.colSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo.FieldName = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.OptionsColumn.AllowEdit = false;
            this.colSaldo.OptionsColumn.FixedWidth = true;
            this.colSaldo.OptionsColumn.ReadOnly = true;
            this.colSaldo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Saldo", "{0:C2}")});
            this.colSaldo.Visible = true;
            this.colSaldo.VisibleIndex = 4;
            this.colSaldo.Width = 62;
            // 
            // colProveedor
            // 
            this.colProveedor.Caption = "Proveedor";
            this.colProveedor.FieldName = "Proveedor";
            this.colProveedor.Name = "colProveedor";
            this.colProveedor.OptionsColumn.AllowEdit = false;
            this.colProveedor.OptionsColumn.ReadOnly = true;
            this.colProveedor.Visible = true;
            this.colProveedor.VisibleIndex = 5;
            this.colProveedor.Width = 135;
            // 
            // colObra
            // 
            this.colObra.Caption = "Obra";
            this.colObra.FieldName = "Obra";
            this.colObra.Name = "colObra";
            this.colObra.OptionsColumn.AllowEdit = false;
            this.colObra.OptionsColumn.ReadOnly = true;
            this.colObra.Visible = true;
            this.colObra.VisibleIndex = 6;
            this.colObra.Width = 96;
            // 
            // colObservaciones
            // 
            this.colObservaciones.Caption = "Observaciones";
            this.colObservaciones.FieldName = "Observaciones";
            this.colObservaciones.Name = "colObservaciones";
            this.colObservaciones.OptionsColumn.AllowEdit = false;
            this.colObservaciones.OptionsColumn.ReadOnly = true;
            this.colObservaciones.Visible = true;
            this.colObservaciones.VisibleIndex = 9;
            this.colObservaciones.Width = 115;
            // 
            // colConceptoId
            // 
            this.colConceptoId.Caption = "Concepto";
            this.colConceptoId.ColumnEdit = this.luConceptos;
            this.colConceptoId.FieldName = "ConceptosId";
            this.colConceptoId.Name = "colConceptoId";
            this.colConceptoId.OptionsColumn.AllowEdit = false;
            this.colConceptoId.OptionsColumn.FixedWidth = true;
            this.colConceptoId.OptionsColumn.ReadOnly = true;
            this.colConceptoId.Visible = true;
            this.colConceptoId.VisibleIndex = 7;
            this.colConceptoId.Width = 92;
            // 
            // luConceptos
            // 
            this.luConceptos.AutoHeight = false;
            this.luConceptos.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luConceptos.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.luConceptos.Name = "luConceptos";
            this.luConceptos.NullText = "";
            // 
            // colTipoContrarecibo
            // 
            this.colTipoContrarecibo.Caption = "Tipo";
            this.colTipoContrarecibo.ColumnEdit = this.rgOpciones;
            this.colTipoContrarecibo.FieldName = "TipoComprobante";
            this.colTipoContrarecibo.Name = "colTipoContrarecibo";
            this.colTipoContrarecibo.OptionsColumn.AllowEdit = false;
            this.colTipoContrarecibo.OptionsColumn.FixedWidth = true;
            this.colTipoContrarecibo.OptionsColumn.ReadOnly = true;
            this.colTipoContrarecibo.Visible = true;
            this.colTipoContrarecibo.VisibleIndex = 8;
            this.colTipoContrarecibo.Width = 102;
            // 
            // rgOpciones
            // 
            this.rgOpciones.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Fact."),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "NC.")});
            this.rgOpciones.Name = "rgOpciones";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.button1, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnAceptar, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 413);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(813, 45);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Image = global::SistemaGEISA.Properties.Resources.No;
            this.button1.Location = new System.Drawing.Point(720, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 39);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cancelar";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAceptar.Image = global::SistemaGEISA.Properties.Resources.Si;
            this.btnAceptar.Location = new System.Drawing.Point(624, 3);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 39);
            this.btnAceptar.TabIndex = 1;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // frmFacturasPendientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFacturasPendientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFacturasPendientes";
            this.Load += new System.EventHandler(this.frmFacturasPendientes_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luConceptos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgOpciones)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colSeleccion;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit checkFactura;
        private DevExpress.XtraGrid.Columns.GridColumn colNoFactura;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldo;
        private DevExpress.XtraGrid.Columns.GridColumn colObservaciones;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAceptar;
        private DevExpress.XtraGrid.Columns.GridColumn colProveedor;
        private DevExpress.XtraGrid.Columns.GridColumn colObra;
        private DevExpress.XtraGrid.Columns.GridColumn colConceptoId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luConceptos;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoContrarecibo;
        private DevExpress.XtraEditors.Repository.RepositoryItemRadioGroup rgOpciones;
    }
}