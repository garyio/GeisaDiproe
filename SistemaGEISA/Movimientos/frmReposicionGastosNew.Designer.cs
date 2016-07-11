namespace SistemaGEISA
{
    partial class frmReposicionGastosNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReposicionGastosNew));
            this.menu = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripProveedor = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grid2 = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFactura2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldoActual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontoPagar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldoFinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObservaciones2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProveedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luProveedor = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colObra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luObra = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colCompartido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ckCompartido = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colGastoAdm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ckGastoAdm = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.luEmpleado = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.luEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.dtFecha = new DevExpress.XtraEditors.DateEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.luTipoPago = new DevExpress.XtraEditors.LookUpEdit();
            this.lblBanco = new System.Windows.Forms.Label();
            this.luBanco = new DevExpress.XtraEditors.LookUpEdit();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.lbCancelado = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAgregar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotMov = new System.Windows.Forms.TextBox();
            this.txtDif = new System.Windows.Forms.TextBox();
            this.txtTot = new System.Windows.Forms.TextBox();
            this.menu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luObra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCompartido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckGastoAdm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpleado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luTipoPago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luBanco.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.toolStripProveedor,
            this.btnCancelar,
            this.btnImprimir});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(3);
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menu.Size = new System.Drawing.Size(925, 35);
            this.menu.TabIndex = 7;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 26);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // toolStripProveedor
            // 
            this.toolStripProveedor.Image = global::SistemaGEISA.Properties.Resources.AddProveedor;
            this.toolStripProveedor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripProveedor.Name = "toolStripProveedor";
            this.toolStripProveedor.Size = new System.Drawing.Size(132, 26);
            this.toolStripProveedor.Text = "Agregar Proveedor";
            this.toolStripProveedor.Click += new System.EventHandler(this.toolStripProveedor_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::SistemaGEISA.Properties.Resources.cancel1;
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 26);
            this.btnCancelar.Text = "Cancelar pago";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::SistemaGEISA.Properties.Resources.Imprimir;
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(79, 26);
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 10;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.grid2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtFolio, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.luEmpleado, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.luEmpresa, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtFecha, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.luTipoPago, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblBanco, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.luBanco, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblReferencia, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtReferencia, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbCancelado, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label8, 7, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTotMov, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDif, 8, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtTot, 8, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(925, 385);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // grid2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grid2, 10);
            this.grid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid2.Location = new System.Drawing.Point(3, 142);
            this.grid2.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.grid2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grid2.MainView = this.gv;
            this.grid2.Name = "grid2";
            this.grid2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.luProveedor,
            this.luObra,
            this.ckCompartido,
            this.ckGastoAdm});
            this.grid2.Size = new System.Drawing.Size(919, 240);
            this.grid2.TabIndex = 16;
            this.grid2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
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
            this.colId2,
            this.colFactura2,
            this.colFecha2,
            this.colImporte2,
            this.colSaldoActual,
            this.colMontoPagar,
            this.colSaldoFinal,
            this.colObservaciones2,
            this.colProveedor,
            this.colObra,
            this.colCompartido,
            this.colGastoAdm});
            this.gv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gv.GridControl = this.grid2;
            this.gv.GroupPanelText = "Facturas a pagar";
            this.gv.Name = "gv";
            this.gv.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv.OptionsView.EnableAppearanceEvenRow = true;
            this.gv.OptionsView.EnableAppearanceOddRow = true;
            this.gv.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gv.OptionsView.ShowFooter = true;
            this.gv.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gv_CellValueChanged);
            this.gv.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gv_InvalidRowException);
            this.gv.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gv_ValidateRow);
            this.gv.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gv_RowUpdated);
            this.gv.RowCountChanged += new System.EventHandler(this.gv_RowCountChanged);
            // 
            // colId2
            // 
            this.colId2.Caption = "Id";
            this.colId2.FieldName = "Id";
            this.colId2.Name = "colId2";
            this.colId2.OptionsColumn.FixedWidth = true;
            this.colId2.Width = 20;
            // 
            // colFactura2
            // 
            this.colFactura2.Caption = "Factura";
            this.colFactura2.FieldName = "NoFactura";
            this.colFactura2.Name = "colFactura2";
            this.colFactura2.OptionsColumn.FixedWidth = true;
            this.colFactura2.Visible = true;
            this.colFactura2.VisibleIndex = 0;
            this.colFactura2.Width = 70;
            // 
            // colFecha2
            // 
            this.colFecha2.Caption = "Fecha";
            this.colFecha2.DisplayFormat.FormatString = "d";
            this.colFecha2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFecha2.FieldName = "Fecha";
            this.colFecha2.Name = "colFecha2";
            this.colFecha2.OptionsColumn.FixedWidth = true;
            this.colFecha2.Visible = true;
            this.colFecha2.VisibleIndex = 1;
            this.colFecha2.Width = 70;
            // 
            // colImporte2
            // 
            this.colImporte2.Caption = "Importe";
            this.colImporte2.DisplayFormat.FormatString = "c2";
            this.colImporte2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporte2.FieldName = "Importe";
            this.colImporte2.Name = "colImporte2";
            this.colImporte2.OptionsColumn.FixedWidth = true;
            this.colImporte2.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Importe", "{0:C2}")});
            this.colImporte2.Visible = true;
            this.colImporte2.VisibleIndex = 2;
            this.colImporte2.Width = 80;
            // 
            // colSaldoActual
            // 
            this.colSaldoActual.Caption = "Saldo Actual";
            this.colSaldoActual.DisplayFormat.FormatString = "c2";
            this.colSaldoActual.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldoActual.FieldName = "SaldoActual";
            this.colSaldoActual.Name = "colSaldoActual";
            this.colSaldoActual.OptionsColumn.AllowEdit = false;
            this.colSaldoActual.OptionsColumn.FixedWidth = true;
            this.colSaldoActual.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SaldoActual", "{0:C2}")});
            this.colSaldoActual.Visible = true;
            this.colSaldoActual.VisibleIndex = 3;
            this.colSaldoActual.Width = 80;
            // 
            // colMontoPagar
            // 
            this.colMontoPagar.Caption = "Monto a pagar";
            this.colMontoPagar.DisplayFormat.FormatString = "c2";
            this.colMontoPagar.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMontoPagar.FieldName = "MontoPagar";
            this.colMontoPagar.Name = "colMontoPagar";
            this.colMontoPagar.OptionsColumn.AllowEdit = false;
            this.colMontoPagar.OptionsColumn.FixedWidth = true;
            this.colMontoPagar.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontoPagar", "{0:C2}")});
            this.colMontoPagar.Visible = true;
            this.colMontoPagar.VisibleIndex = 4;
            this.colMontoPagar.Width = 79;
            // 
            // colSaldoFinal
            // 
            this.colSaldoFinal.Caption = "Saldo Final";
            this.colSaldoFinal.DisplayFormat.FormatString = "c2";
            this.colSaldoFinal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldoFinal.FieldName = "SaldoFinal";
            this.colSaldoFinal.Name = "colSaldoFinal";
            this.colSaldoFinal.OptionsColumn.AllowEdit = false;
            this.colSaldoFinal.OptionsColumn.FixedWidth = true;
            this.colSaldoFinal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SaldoFinal", "{0:C2}")});
            this.colSaldoFinal.Visible = true;
            this.colSaldoFinal.VisibleIndex = 5;
            this.colSaldoFinal.Width = 61;
            // 
            // colObservaciones2
            // 
            this.colObservaciones2.Caption = "Observaciones";
            this.colObservaciones2.FieldName = "Observaciones";
            this.colObservaciones2.Name = "colObservaciones2";
            this.colObservaciones2.Visible = true;
            this.colObservaciones2.VisibleIndex = 8;
            this.colObservaciones2.Width = 178;
            // 
            // colProveedor
            // 
            this.colProveedor.Caption = "Proveedor";
            this.colProveedor.ColumnEdit = this.luProveedor;
            this.colProveedor.FieldName = "ProveedorId";
            this.colProveedor.Name = "colProveedor";
            this.colProveedor.OptionsColumn.FixedWidth = true;
            this.colProveedor.Visible = true;
            this.colProveedor.VisibleIndex = 9;
            this.colProveedor.Width = 110;
            // 
            // luProveedor
            // 
            this.luProveedor.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.luProveedor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luProveedor.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreFiscal", "Nombre")});
            this.luProveedor.Name = "luProveedor";
            this.luProveedor.NullText = "";
            // 
            // colObra
            // 
            this.colObra.Caption = "Obra";
            this.colObra.ColumnEdit = this.luObra;
            this.colObra.FieldName = "ObraId";
            this.colObra.Name = "colObra";
            this.colObra.OptionsColumn.FixedWidth = true;
            this.colObra.Visible = true;
            this.colObra.VisibleIndex = 10;
            this.colObra.Width = 110;
            // 
            // luObra
            // 
            this.luObra.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.luObra.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luObra.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.luObra.Name = "luObra";
            this.luObra.NullText = "";
            // 
            // colCompartido
            // 
            this.colCompartido.Caption = "GC";
            this.colCompartido.ColumnEdit = this.ckCompartido;
            this.colCompartido.FieldName = "Compartido";
            this.colCompartido.Name = "colCompartido";
            this.colCompartido.OptionsColumn.FixedWidth = true;
            this.colCompartido.Visible = true;
            this.colCompartido.VisibleIndex = 6;
            this.colCompartido.Width = 30;
            // 
            // ckCompartido
            // 
            this.ckCompartido.AutoHeight = false;
            this.ckCompartido.Caption = "Check";
            this.ckCompartido.Name = "ckCompartido";
            this.ckCompartido.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colGastoAdm
            // 
            this.colGastoAdm.Caption = "GA";
            this.colGastoAdm.ColumnEdit = this.ckGastoAdm;
            this.colGastoAdm.FieldName = "GastoAdm";
            this.colGastoAdm.Name = "colGastoAdm";
            this.colGastoAdm.OptionsColumn.FixedWidth = true;
            this.colGastoAdm.Visible = true;
            this.colGastoAdm.VisibleIndex = 7;
            this.colGastoAdm.Width = 30;
            // 
            // ckGastoAdm
            // 
            this.ckGastoAdm.AutoHeight = false;
            this.ckGastoAdm.Caption = "Check";
            this.ckGastoAdm.Name = "ckGastoAdm";
            this.ckGastoAdm.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folio";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFolio
            // 
            this.txtFolio.BackColor = System.Drawing.Color.White;
            this.txtFolio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFolio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFolio.Location = new System.Drawing.Point(62, 3);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.ReadOnly = true;
            this.txtFolio.Size = new System.Drawing.Size(100, 21);
            this.txtFolio.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Empleado";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // luEmpleado
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.luEmpleado, 2);
            this.luEmpleado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luEmpleado.Location = new System.Drawing.Point(62, 30);
            this.luEmpleado.Name = "luEmpleado";
            this.luEmpleado.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.luEmpleado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luEmpleado.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreCompleto", "Nombre")});
            this.luEmpleado.Properties.NullText = "";
            this.luEmpleado.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luEmpleado.Size = new System.Drawing.Size(200, 20);
            this.luEmpleado.TabIndex = 3;
            this.luEmpleado.EditValueChanged += new System.EventHandler(this.luEmpleado_EditValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 57);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Empresa";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // luEmpresa
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.luEmpresa, 2);
            this.luEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luEmpresa.Location = new System.Drawing.Point(62, 57);
            this.luEmpresa.Name = "luEmpresa";
            this.luEmpresa.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.luEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luEmpresa.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreComercial", "Nombre")});
            this.luEmpresa.Properties.NullText = "";
            this.luEmpresa.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luEmpresa.Size = new System.Drawing.Size(200, 20);
            this.luEmpresa.TabIndex = 5;
            this.luEmpresa.EditValueChanged += new System.EventHandler(this.luEmpresa_EditValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(288, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fecha";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtFecha
            // 
            this.dtFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtFecha.EditValue = new System.DateTime(2015, 1, 8, 11, 16, 49, 426);
            this.dtFecha.Location = new System.Drawing.Point(363, 3);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.dtFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFecha.Properties.DisplayFormat.FormatString = "D";
            this.dtFecha.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFecha.Properties.EditFormat.FormatString = "D";
            this.dtFecha.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFecha.Properties.Mask.EditMask = "D";
            this.dtFecha.Size = new System.Drawing.Size(268, 20);
            this.dtFecha.TabIndex = 7;
            this.dtFecha.EditValueChanged += new System.EventHandler(this.dtFecha_EditValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(288, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tipo de Pago";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // luTipoPago
            // 
            this.luTipoPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luTipoPago.Location = new System.Drawing.Point(363, 30);
            this.luTipoPago.Name = "luTipoPago";
            this.luTipoPago.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.luTipoPago.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luTipoPago.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.luTipoPago.Properties.NullText = "";
            this.luTipoPago.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luTipoPago.Size = new System.Drawing.Size(268, 20);
            this.luTipoPago.TabIndex = 9;
            this.luTipoPago.EditValueChanged += new System.EventHandler(this.luTipoPago_EditValueChanged);
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBanco.Location = new System.Drawing.Point(288, 57);
            this.lblBanco.Margin = new System.Windows.Forms.Padding(3);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(69, 21);
            this.lblBanco.TabIndex = 10;
            this.lblBanco.Text = "Banco";
            this.lblBanco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblBanco.Visible = false;
            // 
            // luBanco
            // 
            this.luBanco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luBanco.Location = new System.Drawing.Point(363, 57);
            this.luBanco.Name = "luBanco";
            this.luBanco.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.luBanco.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luBanco.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreBanco", "Nombre"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NoCuenta", "Cuenta")});
            this.luBanco.Properties.NullText = "";
            this.luBanco.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luBanco.Size = new System.Drawing.Size(268, 20);
            this.luBanco.TabIndex = 11;
            this.luBanco.Visible = false;
            this.luBanco.EditValueChanged += new System.EventHandler(this.luBanco_EditValueChanged);
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReferencia.Location = new System.Drawing.Point(288, 84);
            this.lblReferencia.Margin = new System.Windows.Forms.Padding(3);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(69, 21);
            this.lblReferencia.TabIndex = 12;
            this.lblReferencia.Text = "Referencia";
            this.lblReferencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblReferencia.Visible = false;
            // 
            // txtReferencia
            // 
            this.txtReferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReferencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReferencia.Location = new System.Drawing.Point(363, 84);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(268, 21);
            this.txtReferencia.TabIndex = 13;
            this.txtReferencia.Visible = false;
            // 
            // lbCancelado
            // 
            this.lbCancelado.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lbCancelado, 3);
            this.lbCancelado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCancelado.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lbCancelado.ForeColor = System.Drawing.Color.Red;
            this.lbCancelado.Location = new System.Drawing.Point(3, 84);
            this.lbCancelado.Margin = new System.Windows.Forms.Padding(3);
            this.lbCancelado.Name = "lbCancelado";
            this.lbCancelado.Size = new System.Drawing.Size(259, 21);
            this.lbCancelado.TabIndex = 14;
            this.lbCancelado.Text = "C A N C E L A D O";
            this.lbCancelado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbCancelado.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.toolStrip1, 6);
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregar,
            this.btnEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(3, 111);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(628, 25);
            this.toolStrip1.TabIndex = 15;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(113, 22);
            this.btnAgregar.Text = "Agregar Factura";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::SistemaGEISA.Properties.Resources.delete;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(104, 22);
            this.btnEliminar.Text = "Quitar Factura";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(657, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 27);
            this.label8.TabIndex = 19;
            this.label8.Text = "Total";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(657, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 27);
            this.label7.TabIndex = 18;
            this.label7.Text = "Diferencia";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(657, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 27);
            this.label6.TabIndex = 17;
            this.label6.Text = "Total Mov.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotMov
            // 
            this.txtTotMov.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotMov.Location = new System.Drawing.Point(721, 30);
            this.txtTotMov.Name = "txtTotMov";
            this.txtTotMov.Size = new System.Drawing.Size(181, 21);
            this.txtTotMov.TabIndex = 20;
            this.txtTotMov.TextChanged += new System.EventHandler(this.txtTotMov_TextChanged);
            this.txtTotMov.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTotMov_KeyPress);
            this.txtTotMov.Leave += new System.EventHandler(this.txtTotMov_Leave);
            // 
            // txtDif
            // 
            this.txtDif.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDif.Location = new System.Drawing.Point(721, 57);
            this.txtDif.Name = "txtDif";
            this.txtDif.ReadOnly = true;
            this.txtDif.Size = new System.Drawing.Size(181, 21);
            this.txtDif.TabIndex = 21;
            // 
            // txtTot
            // 
            this.txtTot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTot.Location = new System.Drawing.Point(721, 84);
            this.txtTot.Name = "txtTot";
            this.txtTot.ReadOnly = true;
            this.txtTot.Size = new System.Drawing.Size(181, 21);
            this.txtTot.TabIndex = 22;
            // 
            // frmReposicionGastosNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 420);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReposicionGastosNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reposición de Gastos : Nuevo";
            this.Load += new System.EventHandler(this.frmReposicionGastosNew_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luObra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCompartido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckGastoAdm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpleado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luTipoPago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luBanco.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFolio;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LookUpEdit luEmpleado;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit luEmpresa;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.DateEdit dtFecha;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.LookUpEdit luTipoPago;
        private System.Windows.Forms.Label lblBanco;
        private DevExpress.XtraEditors.LookUpEdit luBanco;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label lbCancelado;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.ToolStripButton btnAgregar;
        private DevExpress.XtraGrid.GridControl grid2;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraGrid.Columns.GridColumn colId2;
        private DevExpress.XtraGrid.Columns.GridColumn colFactura2;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha2;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte2;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldoActual;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoPagar;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldoFinal;
        private DevExpress.XtraGrid.Columns.GridColumn colObservaciones2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private DevExpress.XtraGrid.Columns.GridColumn colProveedor;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luProveedor;
        private DevExpress.XtraGrid.Columns.GridColumn colObra;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luObra;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotMov;
        private System.Windows.Forms.TextBox txtDif;
        private System.Windows.Forms.TextBox txtTot;
        private DevExpress.XtraGrid.Columns.GridColumn colCompartido;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ckCompartido;
        private DevExpress.XtraGrid.Columns.GridColumn colGastoAdm;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ckGastoAdm;
        private System.Windows.Forms.ToolStripButton toolStripProveedor;

    }
}