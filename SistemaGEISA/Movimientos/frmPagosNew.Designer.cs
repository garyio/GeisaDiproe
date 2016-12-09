namespace SistemaGEISA
{
    partial class frmPagosNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPagosNew));
            this.ckCompartido = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ckGastoAdm = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ckDevolucion = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ckPrestamo = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.dateEditFecha = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnAgregarContrarecibos = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.lblSaldoFavor = new System.Windows.Forms.ToolStripLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.luObra = new DevExpress.XtraEditors.LookUpEdit();
            this.grid2 = new DevExpress.XtraGrid.GridControl();
            this.gv2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFactura2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldoActual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMontoPagar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldoFinal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObservaciones2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompartido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGastoAdm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevolucion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPrestamo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoCombronate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luBanco = new DevExpress.XtraEditors.LookUpEdit();
            this.lblBancoTarjeta = new System.Windows.Forms.Label();
            this.luEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.luProveedor = new DevExpress.XtraEditors.LookUpEdit();
            this.luTipoPago = new DevExpress.XtraEditors.LookUpEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.lbCancelado = new System.Windows.Forms.Label();
            this.dtFechaPago = new DevExpress.XtraEditors.DateEdit();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAgregar = new System.Windows.Forms.ToolStripButton();
            this.btnAgregarNC = new System.Windows.Forms.ToolStripButton();
            this.btnQuitar = new System.Windows.Forms.ToolStripButton();
            this.rgOpcion = new DevExpress.XtraEditors.RadioGroup();
            this.lblObra = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ckCompartido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckGastoAdm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckDevolucion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckPrestamo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFecha.CalendarTimeProperties)).BeginInit();
            this.menu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luObra.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luBanco.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProveedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luTipoPago.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaPago.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaPago.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgOpcion.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ckCompartido
            // 
            this.ckCompartido.Caption = "Check";
            this.ckCompartido.Name = "ckCompartido";
            this.ckCompartido.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // ckGastoAdm
            // 
            this.ckGastoAdm.Caption = "GA";
            this.ckGastoAdm.Name = "ckGastoAdm";
            this.ckGastoAdm.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // ckDevolucion
            // 
            this.ckDevolucion.Caption = "Check";
            this.ckDevolucion.Name = "ckDevolucion";
            this.ckDevolucion.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // ckPrestamo
            // 
            this.ckPrestamo.Caption = "Check";
            this.ckPrestamo.Name = "ckPrestamo";
            this.ckPrestamo.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // dateEditFecha
            // 
            this.dateEditFecha.AutoHeight = false;
            this.dateEditFecha.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFecha.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFecha.Name = "dateEditFecha";
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.btnAgregarContrarecibos,
            this.toolStripSeparator1,
            this.btnActualizar,
            this.btnCancelar,
            this.lblSaldoFavor});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(3);
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menu.Size = new System.Drawing.Size(836, 35);
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
            // btnAgregarContrarecibos
            // 
            this.btnAgregarContrarecibos.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarContrarecibos.Image")));
            this.btnAgregarContrarecibos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarContrarecibos.Name = "btnAgregarContrarecibos";
            this.btnAgregarContrarecibos.Size = new System.Drawing.Size(152, 26);
            this.btnAgregarContrarecibos.Text = "Agregar Contrarecibos";
            this.btnAgregarContrarecibos.Click += new System.EventHandler(this.btnAgregarContrarecibos_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(153, 26);
            this.btnActualizar.Text = "Actualizar Información";
            this.btnActualizar.Visible = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(109, 26);
            this.btnCancelar.Text = "Cancelar pago";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblSaldoFavor
            // 
            this.lblSaldoFavor.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblSaldoFavor.Name = "lblSaldoFavor";
            this.lblSaldoFavor.Size = new System.Drawing.Size(71, 26);
            this.lblSaldoFavor.Text = "Saldo Favor:";
            this.lblSaldoFavor.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.luObra, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.grid2, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.luBanco, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblBancoTarjeta, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.luEmpresa, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblProveedor, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtFolio, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.luProveedor, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.luTipoPago, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtReferencia, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbCancelado, 6, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtFechaPago, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.rgOpcion, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblObra, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(836, 426);
            this.tableLayoutPanel1.TabIndex = 8;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // luObra
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.luObra, 2);
            this.luObra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luObra.Location = new System.Drawing.Point(66, 112);
            this.luObra.Name = "luObra";
            this.luObra.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.luObra.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luObra.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.luObra.Properties.NullText = "";
            this.luObra.Size = new System.Drawing.Size(223, 20);
            this.luObra.TabIndex = 51;
            this.luObra.Visible = false;
            // 
            // grid2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grid2, 7);
            this.grid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid2.Location = new System.Drawing.Point(3, 169);
            this.grid2.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.grid2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grid2.MainView = this.gv2;
            this.grid2.Name = "grid2";
            this.grid2.Size = new System.Drawing.Size(830, 254);
            this.grid2.TabIndex = 10;
            this.grid2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv2});
            // 
            // gv2
            // 
            this.gv2.Appearance.GroupPanel.BackColor = System.Drawing.Color.Transparent;
            this.gv2.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.Transparent;
            this.gv2.Appearance.GroupPanel.BorderColor = System.Drawing.Color.Transparent;
            this.gv2.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gv2.Appearance.GroupPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gv2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gv2.Appearance.GroupPanel.Options.UseBorderColor = true;
            this.gv2.Appearance.GroupPanel.Options.UseFont = true;
            this.gv2.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gv2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId2,
            this.colFactura2,
            this.colFecha2,
            this.colImporte2,
            this.colSaldoActual,
            this.colMontoPagar,
            this.colSaldoFinal,
            this.colObservaciones2,
            this.colCompartido,
            this.colGastoAdm,
            this.colObra,
            this.colDevolucion,
            this.colPrestamo,
            this.colTipoCombronate});
            this.gv2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gv2.GridControl = this.grid2;
            this.gv2.GroupPanelText = "Facturas a pagar";
            this.gv2.Name = "gv2";
            this.gv2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv2.OptionsView.EnableAppearanceEvenRow = true;
            this.gv2.OptionsView.EnableAppearanceOddRow = true;
            this.gv2.OptionsView.ShowFooter = true;
            this.gv2.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gv2_CellValueChanged);
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
            this.colFactura2.OptionsColumn.AllowEdit = false;
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
            this.colFecha2.OptionsColumn.AllowEdit = false;
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
            this.colImporte2.OptionsColumn.AllowEdit = false;
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
            this.colMontoPagar.OptionsColumn.FixedWidth = true;
            this.colMontoPagar.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "MontoPagar", "{0:C2}")});
            this.colMontoPagar.Visible = true;
            this.colMontoPagar.VisibleIndex = 4;
            this.colMontoPagar.Width = 80;
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
            this.colSaldoFinal.Width = 80;
            // 
            // colObservaciones2
            // 
            this.colObservaciones2.Caption = "Observaciones";
            this.colObservaciones2.FieldName = "Observaciones";
            this.colObservaciones2.Name = "colObservaciones2";
            this.colObservaciones2.Visible = true;
            this.colObservaciones2.VisibleIndex = 11;
            this.colObservaciones2.Width = 126;
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
            this.colCompartido.Width = 25;
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
            this.colGastoAdm.Width = 25;
            // 
            // colObra
            // 
            this.colObra.Caption = "Obra";
            this.colObra.FieldName = "ObraNombre";
            this.colObra.Name = "colObra";
            this.colObra.OptionsColumn.AllowEdit = false;
            this.colObra.OptionsColumn.ReadOnly = true;
            this.colObra.Visible = true;
            this.colObra.VisibleIndex = 10;
            this.colObra.Width = 58;
            // 
            // colDevolucion
            // 
            this.colDevolucion.Caption = "Devol.";
            this.colDevolucion.ColumnEdit = this.ckDevolucion;
            this.colDevolucion.FieldName = "esDevolucion";
            this.colDevolucion.Name = "colDevolucion";
            this.colDevolucion.OptionsColumn.FixedWidth = true;
            this.colDevolucion.Visible = true;
            this.colDevolucion.VisibleIndex = 8;
            this.colDevolucion.Width = 40;
            // 
            // colPrestamo
            // 
            this.colPrestamo.Caption = "Ptmo.";
            this.colPrestamo.ColumnEdit = this.ckPrestamo;
            this.colPrestamo.FieldName = "esPrestamo";
            this.colPrestamo.Name = "colPrestamo";
            this.colPrestamo.OptionsColumn.FixedWidth = true;
            this.colPrestamo.Visible = true;
            this.colPrestamo.VisibleIndex = 9;
            this.colPrestamo.Width = 40;
            // 
            // colTipoCombronate
            // 
            this.colTipoCombronate.FieldName = "TipoComprobante";
            this.colTipoCombronate.Name = "colTipoCombronate";
            // 
            // luBanco
            // 
            this.luBanco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luBanco.Location = new System.Drawing.Point(399, 59);
            this.luBanco.Name = "luBanco";
            this.luBanco.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.luBanco.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luBanco.Properties.NullText = "";
            this.luBanco.Size = new System.Drawing.Size(243, 20);
            this.luBanco.TabIndex = 5;
            this.luBanco.Visible = false;
            this.luBanco.EditValueChanged += new System.EventHandler(this.luBanco_EditValueChanged);
            // 
            // lblBancoTarjeta
            // 
            this.lblBancoTarjeta.AutoSize = true;
            this.lblBancoTarjeta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBancoTarjeta.Location = new System.Drawing.Point(315, 56);
            this.lblBancoTarjeta.Name = "lblBancoTarjeta";
            this.lblBancoTarjeta.Size = new System.Drawing.Size(78, 26);
            this.lblBancoTarjeta.TabIndex = 40;
            this.lblBancoTarjeta.Text = "Banco";
            this.lblBancoTarjeta.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblBancoTarjeta.Visible = false;
            // 
            // luEmpresa
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.luEmpresa, 2);
            this.luEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luEmpresa.Location = new System.Drawing.Point(66, 85);
            this.luEmpresa.Name = "luEmpresa";
            this.luEmpresa.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.luEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luEmpresa.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreComercial", "Nombre")});
            this.luEmpresa.Properties.NullText = "";
            this.luEmpresa.Size = new System.Drawing.Size(223, 20);
            this.luEmpresa.TabIndex = 4;
            this.luEmpresa.EditValueChanged += new System.EventHandler(this.luEmpresa_EditValueChanged);
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProveedor.Location = new System.Drawing.Point(3, 59);
            this.lblProveedor.Margin = new System.Windows.Forms.Padding(3);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(57, 20);
            this.lblProveedor.TabIndex = 35;
            this.lblProveedor.Text = "Proveedor";
            this.lblProveedor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(315, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 21);
            this.label3.TabIndex = 33;
            this.label3.Text = "Fecha de pago";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(315, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 23);
            this.label1.TabIndex = 31;
            this.label1.Text = "Tipo de pago";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Folio";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFolio
            // 
            this.txtFolio.BackColor = System.Drawing.Color.White;
            this.txtFolio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFolio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFolio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFolio.Location = new System.Drawing.Point(66, 3);
            this.txtFolio.MaxLength = 50;
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.ReadOnly = true;
            this.txtFolio.Size = new System.Drawing.Size(106, 21);
            this.txtFolio.TabIndex = 0;
            // 
            // luProveedor
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.luProveedor, 2);
            this.luProveedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luProveedor.Location = new System.Drawing.Point(66, 59);
            this.luProveedor.Name = "luProveedor";
            this.luProveedor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.luProveedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luProveedor.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreFiscal", "Nombre")});
            this.luProveedor.Properties.NullText = "";
            this.luProveedor.Size = new System.Drawing.Size(223, 20);
            this.luProveedor.TabIndex = 2;
            this.luProveedor.EditValueChanged += new System.EventHandler(this.luProveedor_EditValueChanged);
            // 
            // luTipoPago
            // 
            this.luTipoPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luTipoPago.Location = new System.Drawing.Point(399, 30);
            this.luTipoPago.Name = "luTipoPago";
            this.luTipoPago.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.luTipoPago.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luTipoPago.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.luTipoPago.Properties.NullText = "";
            this.luTipoPago.Size = new System.Drawing.Size(243, 20);
            this.luTipoPago.TabIndex = 3;
            this.luTipoPago.EditValueChanged += new System.EventHandler(this.luTipoPago_EditValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 27);
            this.label5.TabIndex = 38;
            this.label5.Text = "Empresa";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(315, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 27);
            this.label7.TabIndex = 46;
            this.label7.Text = "Referencia";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Visible = false;
            // 
            // txtReferencia
            // 
            this.txtReferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReferencia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReferencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReferencia.Location = new System.Drawing.Point(399, 85);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(243, 21);
            this.txtReferencia.TabIndex = 6;
            this.txtReferencia.Visible = false;
            // 
            // lbCancelado
            // 
            this.lbCancelado.AutoSize = true;
            this.lbCancelado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCancelado.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lbCancelado.ForeColor = System.Drawing.Color.Red;
            this.lbCancelado.Location = new System.Drawing.Point(648, 85);
            this.lbCancelado.Margin = new System.Windows.Forms.Padding(3);
            this.lbCancelado.Name = "lbCancelado";
            this.lbCancelado.Size = new System.Drawing.Size(185, 21);
            this.lbCancelado.TabIndex = 47;
            this.lbCancelado.Text = "PAGO CANCELADO";
            this.lbCancelado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbCancelado.Visible = false;
            // 
            // dtFechaPago
            // 
            this.dtFechaPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtFechaPago.EditValue = new System.DateTime(2015, 1, 6, 17, 39, 33, 236);
            this.dtFechaPago.Location = new System.Drawing.Point(399, 3);
            this.dtFechaPago.Name = "dtFechaPago";
            this.dtFechaPago.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.dtFechaPago.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFechaPago.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFechaPago.Properties.DisplayFormat.FormatString = "D";
            this.dtFechaPago.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFechaPago.Properties.EditFormat.FormatString = "D";
            this.dtFechaPago.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtFechaPago.Properties.Mask.EditMask = "D";
            this.dtFechaPago.Size = new System.Drawing.Size(243, 20);
            this.dtFechaPago.TabIndex = 48;
            this.dtFechaPago.EditValueChanged += new System.EventHandler(this.dtFechaPago_EditValueChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.toolStrip1, 7);
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregar,
            this.btnAgregarNC,
            this.btnQuitar});
            this.toolStrip1.Location = new System.Drawing.Point(3, 138);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(830, 25);
            this.toolStrip1.TabIndex = 49;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(135, 22);
            this.btnAgregar.Text = "Agregar Factura/NC";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnAgregarNC
            // 
            this.btnAgregarNC.Image = global::SistemaGEISA.Properties.Resources.NotasDeCredito;
            this.btnAgregarNC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarNC.Name = "btnAgregarNC";
            this.btnAgregarNC.Size = new System.Drawing.Size(138, 22);
            this.btnAgregarNC.Text = "Agregar NC Ingresos";
            this.btnAgregarNC.Visible = false;
            this.btnAgregarNC.Click += new System.EventHandler(this.btnAgregarNC_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitar.Image")));
            this.btnQuitar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(111, 22);
            this.btnQuitar.Text = "Eliminar Abono";
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // rgOpcion
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.rgOpcion, 2);
            this.rgOpcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgOpcion.EditValue = 2;
            this.rgOpcion.Location = new System.Drawing.Point(66, 30);
            this.rgOpcion.Name = "rgOpcion";
            this.rgOpcion.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Cliente"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Proveedor")});
            this.rgOpcion.Size = new System.Drawing.Size(223, 23);
            this.rgOpcion.TabIndex = 50;
            this.rgOpcion.EditValueChanged += new System.EventHandler(this.rgOpcion_EditValueChanged);
            // 
            // lblObra
            // 
            this.lblObra.AutoSize = true;
            this.lblObra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblObra.Location = new System.Drawing.Point(3, 109);
            this.lblObra.Name = "lblObra";
            this.lblObra.Size = new System.Drawing.Size(57, 26);
            this.lblObra.TabIndex = 52;
            this.lblObra.Text = "Obra";
            this.lblObra.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblObra.Visible = false;
            // 
            // frmPagosNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 461);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.Name = "frmPagosNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pagos : Nuevo";
            this.Load += new System.EventHandler(this.frmPagosNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ckCompartido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckGastoAdm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckDevolucion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckPrestamo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFecha.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFecha)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luObra.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luBanco.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProveedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luTipoPago.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaPago.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFechaPago.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgOpcion.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFolio;
        private DevExpress.XtraEditors.LookUpEdit luProveedor;
        private DevExpress.XtraEditors.LookUpEdit luTipoPago;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.LookUpEdit luBanco;
        private System.Windows.Forms.Label lblBancoTarjeta;
        private DevExpress.XtraEditors.LookUpEdit luEmpresa;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dateEditFecha;
        private DevExpress.XtraGrid.GridControl grid2;
        private DevExpress.XtraGrid.Views.Grid.GridView gv2;
        private DevExpress.XtraGrid.Columns.GridColumn colId2;
        private DevExpress.XtraGrid.Columns.GridColumn colFactura2;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha2;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte2;
        private DevExpress.XtraGrid.Columns.GridColumn colObservaciones2;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldoActual;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldoFinal;
        private DevExpress.XtraGrid.Columns.GridColumn colMontoPagar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.Label lbCancelado;
        private DevExpress.XtraEditors.DateEdit dtFechaPago;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private DevExpress.XtraGrid.Columns.GridColumn colCompartido;
        private DevExpress.XtraGrid.Columns.GridColumn colGastoAdm;
        private DevExpress.XtraGrid.Columns.GridColumn colObra;
        private System.Windows.Forms.ToolStripButton btnAgregarContrarecibos;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private System.Windows.Forms.ToolStripButton btnAgregar;
        private System.Windows.Forms.ToolStripButton btnQuitar;
        private DevExpress.XtraGrid.Columns.GridColumn colDevolucion;
        private DevExpress.XtraGrid.Columns.GridColumn colPrestamo;
        private DevExpress.XtraEditors.RadioGroup rgOpcion;
        private DevExpress.XtraEditors.LookUpEdit luObra;
        private System.Windows.Forms.Label lblObra;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ckCompartido;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ckGastoAdm;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ckDevolucion;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ckPrestamo;
        private System.Windows.Forms.ToolStripLabel lblSaldoFavor;
        private System.Windows.Forms.ToolStripButton btnAgregarNC;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoCombronate;
    }
}