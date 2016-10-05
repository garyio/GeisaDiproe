namespace SistemaGEISA
{
    partial class frmTarjetasPagosNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTarjetasPagosNew));
            this.menu = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripProveedor = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lookupProveedor = new DevExpress.XtraEditors.LookUpEdit();
            this.grid2 = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luObra = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colProveedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luProveedor = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colObservaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompartido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ckCompartido = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colGastoAdm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ckGastoAdm = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.luTarjetas = new DevExpress.XtraEditors.LookUpEdit();
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
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPeriodo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupProveedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luObra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCompartido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckGastoAdm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luTarjetas.Properties)).BeginInit();
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
            this.menu.Size = new System.Drawing.Size(816, 35);
            this.menu.TabIndex = 8;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::SistemaGEISA.Properties.Resources.document_save;
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
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lookupProveedor, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.grid2, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtFolio, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.luTarjetas, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.luEmpresa, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.dtFecha, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.luTipoPago, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblBanco, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.luBanco, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblReferencia, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtReferencia, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbCancelado, 5, 4);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtPeriodo, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(816, 353);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // lookupProveedor
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lookupProveedor, 2);
            this.lookupProveedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lookupProveedor.Location = new System.Drawing.Point(66, 30);
            this.lookupProveedor.Name = "lookupProveedor";
            this.lookupProveedor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lookupProveedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupProveedor.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreFiscal", "Nombre")});
            this.lookupProveedor.Properties.NullText = "";
            this.lookupProveedor.Size = new System.Drawing.Size(223, 20);
            this.lookupProveedor.TabIndex = 20;
            // 
            // grid2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grid2, 6);
            this.grid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid2.Location = new System.Drawing.Point(3, 166);
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
            this.grid2.Size = new System.Drawing.Size(791, 184);
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
            this.colId,
            this.colFactura,
            this.colFecha,
            this.colImporte,
            this.colObra,
            this.colProveedor,
            this.colObservaciones,
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
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.FixedWidth = true;
            this.colId.Width = 20;
            // 
            // colFactura
            // 
            this.colFactura.Caption = "Factura";
            this.colFactura.FieldName = "NoFactura";
            this.colFactura.Name = "colFactura";
            this.colFactura.OptionsColumn.FixedWidth = true;
            this.colFactura.Visible = true;
            this.colFactura.VisibleIndex = 0;
            this.colFactura.Width = 70;
            // 
            // colFecha
            // 
            this.colFecha.Caption = "Fecha";
            this.colFecha.DisplayFormat.FormatString = "d";
            this.colFecha.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.OptionsColumn.FixedWidth = true;
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 1;
            this.colFecha.Width = 80;
            // 
            // colImporte
            // 
            this.colImporte.Caption = "Importe";
            this.colImporte.DisplayFormat.FormatString = "c2";
            this.colImporte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.OptionsColumn.FixedWidth = true;
            this.colImporte.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Importe", "{0:C2}")});
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 2;
            this.colImporte.Width = 80;
            // 
            // colObra
            // 
            this.colObra.Caption = "Obra";
            this.colObra.ColumnEdit = this.luObra;
            this.colObra.FieldName = "ObraId";
            this.colObra.Name = "colObra";
            this.colObra.OptionsColumn.FixedWidth = true;
            this.colObra.Visible = true;
            this.colObra.VisibleIndex = 4;
            this.colObra.Width = 150;
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
            // colProveedor
            // 
            this.colProveedor.Caption = "Proveedor";
            this.colProveedor.ColumnEdit = this.luProveedor;
            this.colProveedor.FieldName = "ProveedorId";
            this.colProveedor.Name = "colProveedor";
            this.colProveedor.OptionsColumn.FixedWidth = true;
            this.colProveedor.Visible = true;
            this.colProveedor.VisibleIndex = 3;
            this.colProveedor.Width = 150;
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
            // colObservaciones
            // 
            this.colObservaciones.Caption = "Observaciones";
            this.colObservaciones.FieldName = "Observaciones";
            this.colObservaciones.Name = "colObservaciones";
            this.colObservaciones.Visible = true;
            this.colObservaciones.VisibleIndex = 7;
            this.colObservaciones.Width = 148;
            // 
            // colCompartido
            // 
            this.colCompartido.Caption = "GC";
            this.colCompartido.ColumnEdit = this.ckCompartido;
            this.colCompartido.FieldName = "Compartido";
            this.colCompartido.Name = "colCompartido";
            this.colCompartido.OptionsColumn.FixedWidth = true;
            this.colCompartido.Visible = true;
            this.colCompartido.VisibleIndex = 5;
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
            this.colGastoAdm.VisibleIndex = 6;
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
            this.label1.Size = new System.Drawing.Size(57, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Folio";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFolio
            // 
            this.txtFolio.BackColor = System.Drawing.Color.White;
            this.txtFolio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFolio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFolio.Location = new System.Drawing.Point(66, 3);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.ReadOnly = true;
            this.txtFolio.Size = new System.Drawing.Size(100, 21);
            this.txtFolio.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 56);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tarjeta";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // luTarjetas
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.luTarjetas, 2);
            this.luTarjetas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luTarjetas.Location = new System.Drawing.Point(66, 56);
            this.luTarjetas.Name = "luTarjetas";
            this.luTarjetas.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.luTarjetas.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luTarjetas.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre_y_Tarjeta", "Nombre - #Cuenta")});
            this.luTarjetas.Properties.NullText = "";
            this.luTarjetas.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luTarjetas.Size = new System.Drawing.Size(223, 20);
            this.luTarjetas.TabIndex = 3;
            this.luTarjetas.EditValueChanged += new System.EventHandler(this.luEmpleado_EditValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Empresa";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // luEmpresa
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.luEmpresa, 2);
            this.luEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luEmpresa.Location = new System.Drawing.Point(66, 82);
            this.luEmpresa.Name = "luEmpresa";
            this.luEmpresa.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.luEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luEmpresa.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreComercial", "Nombre")});
            this.luEmpresa.Properties.NullText = "";
            this.luEmpresa.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luEmpresa.Size = new System.Drawing.Size(223, 20);
            this.luEmpresa.TabIndex = 5;
            this.luEmpresa.EditValueChanged += new System.EventHandler(this.luEmpresa_EditValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(315, 3);
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
            this.dtFecha.Location = new System.Drawing.Point(390, 3);
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
            this.dtFecha.Size = new System.Drawing.Size(404, 20);
            this.dtFecha.TabIndex = 7;
            this.dtFecha.EditValueChanged += new System.EventHandler(this.dtFecha_EditValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(315, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tipo de Pago";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // luTipoPago
            // 
            this.luTipoPago.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luTipoPago.Location = new System.Drawing.Point(390, 30);
            this.luTipoPago.Name = "luTipoPago";
            this.luTipoPago.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.luTipoPago.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luTipoPago.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.luTipoPago.Properties.NullText = "";
            this.luTipoPago.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luTipoPago.Size = new System.Drawing.Size(404, 20);
            this.luTipoPago.TabIndex = 9;
            this.luTipoPago.EditValueChanged += new System.EventHandler(this.luTipoPago_EditValueChanged);
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBanco.Location = new System.Drawing.Point(315, 56);
            this.lblBanco.Margin = new System.Windows.Forms.Padding(3);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(69, 20);
            this.lblBanco.TabIndex = 10;
            this.lblBanco.Text = "Banco";
            this.lblBanco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblBanco.Visible = false;
            // 
            // luBanco
            // 
            this.luBanco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luBanco.Location = new System.Drawing.Point(390, 56);
            this.luBanco.Name = "luBanco";
            this.luBanco.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.luBanco.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luBanco.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreBanco", "Nombre Banco")});
            this.luBanco.Properties.NullText = "";
            this.luBanco.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luBanco.Size = new System.Drawing.Size(404, 20);
            this.luBanco.TabIndex = 11;
            this.luBanco.Visible = false;
            this.luBanco.EditValueChanged += new System.EventHandler(this.luBanco_EditValueChanged);
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReferencia.Location = new System.Drawing.Point(315, 82);
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
            this.txtReferencia.Location = new System.Drawing.Point(390, 82);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(404, 21);
            this.txtReferencia.TabIndex = 13;
            this.txtReferencia.Visible = false;
            // 
            // lbCancelado
            // 
            this.lbCancelado.AutoSize = true;
            this.lbCancelado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCancelado.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lbCancelado.ForeColor = System.Drawing.Color.Red;
            this.lbCancelado.Location = new System.Drawing.Point(390, 109);
            this.lbCancelado.Margin = new System.Windows.Forms.Padding(3);
            this.lbCancelado.Name = "lbCancelado";
            this.lbCancelado.Size = new System.Drawing.Size(404, 21);
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
            this.btnEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(3, 136);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(791, 24);
            this.toolStrip1.TabIndex = 15;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::SistemaGEISA.Properties.Resources.delete;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(104, 21);
            this.btnEliminar.Text = "Quitar Factura";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 27);
            this.label6.TabIndex = 17;
            this.label6.Text = "Periodo";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPeriodo
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtPeriodo, 2);
            this.txtPeriodo.Location = new System.Drawing.Point(66, 109);
            this.txtPeriodo.MaxLength = 100;
            this.txtPeriodo.Name = "txtPeriodo";
            this.txtPeriodo.Size = new System.Drawing.Size(200, 21);
            this.txtPeriodo.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 26);
            this.label7.TabIndex = 19;
            this.label7.Text = "Proveedor";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmTarjetasPagosNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(816, 388);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmTarjetasPagosNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pago Tarjeta Nuevo";
            this.Load += new System.EventHandler(this.frmTarjetasPagosNew_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupProveedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luObra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCompartido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckGastoAdm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luTarjetas.Properties)).EndInit();
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
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl grid2;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFactura;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colProveedor;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luProveedor;
        private DevExpress.XtraGrid.Columns.GridColumn colObra;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luObra;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFolio;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LookUpEdit luTarjetas;
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
        private DevExpress.XtraGrid.Columns.GridColumn colObservaciones;
        private DevExpress.XtraGrid.Columns.GridColumn colCompartido;
        private DevExpress.XtraGrid.Columns.GridColumn colGastoAdm;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ckCompartido;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ckGastoAdm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPeriodo;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.LookUpEdit lookupProveedor;
        private System.Windows.Forms.ToolStripButton toolStripProveedor;
    }
}