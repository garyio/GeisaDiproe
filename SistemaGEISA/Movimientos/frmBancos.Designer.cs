namespace SistemaGEISA
{
    partial class frmBancos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBancos));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnCerrarMes = new System.Windows.Forms.ToolStripButton();
            this.btnAgregar = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.btnExportar = new System.Windows.Forms.ToolStripButton();
            this.lblSaldoInicial = new System.Windows.Forms.ToolStripLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.luBanco = new DevExpress.XtraEditors.LookUpEdit();
            this.luEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.editAño = new System.Windows.Forms.NumericUpDown();
            this.cbMeses = new System.Windows.Forms.ComboBox();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFechaCancelacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPagosId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoMovimientoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFolio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConcepto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbono = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCargo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luEstado = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.chkActivo = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.luObraComprobante = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.luTipoComprobante = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.luProveedor = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnDetalle = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.dtFecha = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.cbTransito = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.cbPagada = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.txtTotCargos = new System.Windows.Forms.TextBox();
            this.txtTotAbonos = new System.Windows.Forms.TextBox();
            this.txtTotTransito = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDif1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRetiroBancos = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDif2 = new System.Windows.Forms.TextBox();
            this.txtSaldoCirculacionAnterior = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSaldoCirculacion = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTransitoPeriodo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtSaldoBancos = new System.Windows.Forms.TextBox();
            this.txtSaldoEdoCta = new System.Windows.Forms.TextBox();
            this.txtDifChTransito = new System.Windows.Forms.TextBox();
            this.txtTransitoPeriodoAnt = new System.Windows.Forms.TextBox();
            this.txtChCobradosMesAnt = new System.Windows.Forms.TextBox();
            this.txtDif3 = new System.Windows.Forms.TextBox();
            this.menu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luBanco.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAño)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEstado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luObraComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luTipoComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTransito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPagada)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEliminar,
            this.btnGuardar,
            this.btnCerrarMes,
            this.btnAgregar,
            this.btnImprimir,
            this.btnExportar,
            this.lblSaldoInicial});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(5);
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menu.Size = new System.Drawing.Size(1055, 37);
            this.menu.TabIndex = 9;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnEliminar.Image = global::SistemaGEISA.Properties.Resources.Eliminar;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(74, 24);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Visible = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::SistemaGEISA.Properties.Resources.Guardar;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(73, 24);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCerrarMes
            // 
            this.btnCerrarMes.Image = ((System.Drawing.Image)(resources.GetObject("btnCerrarMes.Image")));
            this.btnCerrarMes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCerrarMes.Name = "btnCerrarMes";
            this.btnCerrarMes.Size = new System.Drawing.Size(88, 24);
            this.btnCerrarMes.Text = "Cerrar Mes";
            this.btnCerrarMes.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(120, 24);
            this.btnAgregar.Text = "Agregar Ingresos";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(77, 24);
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Image = global::SistemaGEISA.Properties.Resources.Reportes;
            this.btnExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(142, 24);
            this.btnExportar.Text = "Exportar Informacion";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // lblSaldoInicial
            // 
            this.lblSaldoInicial.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblSaldoInicial.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSaldoInicial.ForeColor = System.Drawing.Color.Green;
            this.lblSaldoInicial.Name = "lblSaldoInicial";
            this.lblSaldoInicial.Size = new System.Drawing.Size(94, 24);
            this.lblSaldoInicial.Text = "Saldo Inicial:";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.luBanco, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.luEmpresa, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.editAño, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbMeses, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.grid, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnConsultar, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTotCargos, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtTotAbonos, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtTotTransito, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtDif1, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label11, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label8, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtRetiroBancos, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label9, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtDif2, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtSaldoCirculacionAnterior, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.txtSaldoCirculacion, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.label10, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtTransitoPeriodo, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.label12, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label13, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label14, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.label15, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.label16, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.label17, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.txtSaldoBancos, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtSaldoEdoCta, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtDifChTransito, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtTransitoPeriodoAnt, 4, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtChCobradosMesAnt, 4, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtDif3, 4, 10);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 37);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 12;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1055, 540);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // luBanco
            // 
            this.luBanco.Location = new System.Drawing.Point(134, 35);
            this.luBanco.Name = "luBanco";
            this.luBanco.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.luBanco.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luBanco.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreBanco", "Nombre"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NoCuenta", 30, "Cuenta")});
            this.luBanco.Properties.NullText = "";
            this.luBanco.Size = new System.Drawing.Size(243, 20);
            this.luBanco.TabIndex = 60;
            this.luBanco.EditValueChanged += new System.EventHandler(this.luBanco_EditValueChanged);
            // 
            // luEmpresa
            // 
            this.luEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luEmpresa.Location = new System.Drawing.Point(134, 8);
            this.luEmpresa.Name = "luEmpresa";
            this.luEmpresa.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.luEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luEmpresa.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreFiscal", "Nombre")});
            this.luEmpresa.Properties.NullText = "";
            this.luEmpresa.Size = new System.Drawing.Size(330, 20);
            this.luEmpresa.TabIndex = 59;
            this.luEmpresa.EditValueChanged += new System.EventHandler(this.luEmpresa_EditValueChanged);
            // 
            // editAño
            // 
            this.editAño.Location = new System.Drawing.Point(624, 35);
            this.editAño.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.editAño.Name = "editAño";
            this.editAño.Size = new System.Drawing.Size(330, 21);
            this.editAño.TabIndex = 57;
            // 
            // cbMeses
            // 
            this.cbMeses.FormattingEnabled = true;
            this.cbMeses.Location = new System.Drawing.Point(624, 8);
            this.cbMeses.Name = "cbMeses";
            this.cbMeses.Size = new System.Drawing.Size(330, 21);
            this.cbMeses.TabIndex = 56;
            // 
            // grid
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grid, 6);
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grid.EmbeddedNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.grid.Font = new System.Drawing.Font("Calibri", 8.25F);
            gridLevelNode1.RelationName = "Level1";
            this.grid.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grid.Location = new System.Drawing.Point(8, 62);
            this.grid.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.grid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grid.MainView = this.gv;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkActivo,
            this.luObraComprobante,
            this.luTipoComprobante,
            this.luProveedor,
            this.btnDetalle,
            this.dtFecha,
            this.cbTransito,
            this.cbPagada,
            this.luEstado});
            this.grid.Size = new System.Drawing.Size(1040, 281);
            this.grid.TabIndex = 53;
            this.grid.UseEmbeddedNavigator = true;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFechaCancelacion,
            this.colPagosId,
            this.colTipoMovimientoId,
            this.colEmpresa,
            this.colFecha,
            this.colFolio,
            this.colTipoPago,
            this.colNombre,
            this.colConcepto,
            this.colAbono,
            this.colCargo,
            this.colTotal,
            this.colEstado});
            this.gv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gv.GridControl = this.grid;
            this.gv.Name = "gv";
            this.gv.OptionsCustomization.AllowFilter = false;
            this.gv.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv.OptionsView.EnableAppearanceEvenRow = true;
            this.gv.OptionsView.EnableAppearanceOddRow = true;
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gv.OptionsView.ShowFooter = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            this.gv.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gv_RowCellStyle);
            this.gv.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gv_FocusedRowChanged);
            this.gv.DoubleClick += new System.EventHandler(this.gv_DoubleClick);
            // 
            // colFechaCancelacion
            // 
            this.colFechaCancelacion.Caption = "Fecha Cancelacion";
            this.colFechaCancelacion.FieldName = "FechaCancelacion";
            this.colFechaCancelacion.Name = "colFechaCancelacion";
            this.colFechaCancelacion.OptionsColumn.AllowEdit = false;
            this.colFechaCancelacion.OptionsColumn.ReadOnly = true;
            // 
            // colPagosId
            // 
            this.colPagosId.Caption = "PagosId";
            this.colPagosId.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPagosId.FieldName = "Id";
            this.colPagosId.Name = "colPagosId";
            this.colPagosId.OptionsColumn.AllowEdit = false;
            this.colPagosId.OptionsColumn.ReadOnly = true;
            // 
            // colTipoMovimientoId
            // 
            this.colTipoMovimientoId.Caption = "TipoMovimientoId";
            this.colTipoMovimientoId.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTipoMovimientoId.FieldName = "TipoMovimientoId";
            this.colTipoMovimientoId.Name = "colTipoMovimientoId";
            this.colTipoMovimientoId.OptionsColumn.AllowEdit = false;
            this.colTipoMovimientoId.OptionsColumn.ReadOnly = true;
            this.colTipoMovimientoId.Width = 63;
            // 
            // colEmpresa
            // 
            this.colEmpresa.Caption = "Empresa";
            this.colEmpresa.FieldName = "Empresa";
            this.colEmpresa.Name = "colEmpresa";
            this.colEmpresa.OptionsColumn.AllowEdit = false;
            this.colEmpresa.OptionsColumn.ReadOnly = true;
            // 
            // colFecha
            // 
            this.colFecha.Caption = "Fecha Pago";
            this.colFecha.DisplayFormat.FormatString = "d";
            this.colFecha.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFecha.FieldName = "FechaPago";
            this.colFecha.Name = "colFecha";
            this.colFecha.OptionsColumn.AllowEdit = false;
            this.colFecha.OptionsColumn.FixedWidth = true;
            this.colFecha.OptionsColumn.ReadOnly = true;
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 1;
            this.colFecha.Width = 76;
            // 
            // colFolio
            // 
            this.colFolio.Caption = "Consc.";
            this.colFolio.FieldName = "Folio";
            this.colFolio.Name = "colFolio";
            this.colFolio.OptionsColumn.AllowEdit = false;
            this.colFolio.OptionsColumn.FixedWidth = true;
            this.colFolio.OptionsColumn.ReadOnly = true;
            this.colFolio.Visible = true;
            this.colFolio.VisibleIndex = 2;
            this.colFolio.Width = 45;
            // 
            // colTipoPago
            // 
            this.colTipoPago.Caption = "Tipo Pago";
            this.colTipoPago.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTipoPago.FieldName = "TipoPago";
            this.colTipoPago.Name = "colTipoPago";
            this.colTipoPago.OptionsColumn.AllowEdit = false;
            this.colTipoPago.OptionsColumn.ReadOnly = true;
            // 
            // colNombre
            // 
            this.colNombre.Caption = "Nombre";
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.OptionsColumn.AllowEdit = false;
            this.colNombre.OptionsColumn.ReadOnly = true;
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 3;
            this.colNombre.Width = 142;
            // 
            // colConcepto
            // 
            this.colConcepto.Caption = "Concepto";
            this.colConcepto.FieldName = "Concepto";
            this.colConcepto.Name = "colConcepto";
            this.colConcepto.OptionsColumn.AllowEdit = false;
            this.colConcepto.OptionsColumn.ReadOnly = true;
            this.colConcepto.Visible = true;
            this.colConcepto.VisibleIndex = 4;
            this.colConcepto.Width = 235;
            // 
            // colAbono
            // 
            this.colAbono.Caption = "Abonos";
            this.colAbono.DisplayFormat.FormatString = "c2";
            this.colAbono.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAbono.FieldName = "Abono";
            this.colAbono.Name = "colAbono";
            this.colAbono.OptionsColumn.AllowEdit = false;
            this.colAbono.OptionsColumn.ReadOnly = true;
            this.colAbono.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Abono", "{0:c2}")});
            this.colAbono.Visible = true;
            this.colAbono.VisibleIndex = 6;
            this.colAbono.Width = 93;
            // 
            // colCargo
            // 
            this.colCargo.Caption = "Cargos";
            this.colCargo.DisplayFormat.FormatString = "c2";
            this.colCargo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCargo.FieldName = "Cargo";
            this.colCargo.Name = "colCargo";
            this.colCargo.OptionsColumn.AllowEdit = false;
            this.colCargo.OptionsColumn.ReadOnly = true;
            this.colCargo.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Cargo", "{0:c2}")});
            this.colCargo.Visible = true;
            this.colCargo.VisibleIndex = 5;
            this.colCargo.Width = 104;
            // 
            // colTotal
            // 
            this.colTotal.Caption = "Total";
            this.colTotal.DisplayFormat.FormatString = "c2";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.OptionsColumn.ReadOnly = true;
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 7;
            this.colTotal.Width = 175;
            // 
            // colEstado
            // 
            this.colEstado.Caption = "Estado";
            this.colEstado.ColumnEdit = this.luEstado;
            this.colEstado.FieldName = "estadoFactura";
            this.colEstado.Name = "colEstado";
            this.colEstado.OptionsColumn.FixedWidth = true;
            this.colEstado.Visible = true;
            this.colEstado.VisibleIndex = 0;
            this.colEstado.Width = 102;
            // 
            // luEstado
            // 
            this.luEstado.AutoHeight = false;
            this.luEstado.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.luEstado.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luEstado.Name = "luEstado";
            this.luEstado.NullText = "";
            // 
            // chkActivo
            // 
            this.chkActivo.AutoHeight = false;
            this.chkActivo.Caption = "Check";
            this.chkActivo.Name = "chkActivo";
            // 
            // luObraComprobante
            // 
            this.luObraComprobante.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luObraComprobante.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.luObraComprobante.Name = "luObraComprobante";
            this.luObraComprobante.NullText = "";
            // 
            // luTipoComprobante
            // 
            this.luTipoComprobante.AutoHeight = false;
            this.luTipoComprobante.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luTipoComprobante.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Comprobante", "Comprobante")});
            this.luTipoComprobante.Name = "luTipoComprobante";
            this.luTipoComprobante.NullText = "";
            // 
            // luProveedor
            // 
            this.luProveedor.AutoHeight = false;
            this.luProveedor.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luProveedor.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreFiscal", "Nombre Fiscal")});
            this.luProveedor.Name = "luProveedor";
            this.luProveedor.NullText = "";
            // 
            // btnDetalle
            // 
            this.btnDetalle.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // dtFecha
            // 
            this.dtFecha.AutoHeight = false;
            this.dtFecha.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFecha.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.NullDate = "";
            // 
            // cbTransito
            // 
            this.cbTransito.AutoHeight = false;
            this.cbTransito.Caption = "";
            this.cbTransito.Name = "cbTransito";
            this.cbTransito.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // cbPagada
            // 
            this.cbPagada.AutoHeight = false;
            this.cbPagada.Caption = "";
            this.cbPagada.Name = "cbPagada";
            this.cbPagada.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(490, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 27);
            this.label1.TabIndex = 54;
            this.label1.Text = "Mes";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(490, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 27);
            this.label2.TabIndex = 55;
            this.label2.Text = "Año";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(8, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 27);
            this.label3.TabIndex = 58;
            this.label3.Text = "Empresa";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(8, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 27);
            this.label4.TabIndex = 61;
            this.label4.Text = "Banco";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = global::SistemaGEISA.Properties.Resources.Si;
            this.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConsultar.Location = new System.Drawing.Point(960, 8);
            this.btnConsultar.Name = "btnConsultar";
            this.tableLayoutPanel1.SetRowSpan(this.btnConsultar, 2);
            this.btnConsultar.Size = new System.Drawing.Size(88, 48);
            this.btnConsultar.TabIndex = 62;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // txtTotCargos
            // 
            this.txtTotCargos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotCargos.Location = new System.Drawing.Point(8, 349);
            this.txtTotCargos.Name = "txtTotCargos";
            this.txtTotCargos.ReadOnly = true;
            this.txtTotCargos.Size = new System.Drawing.Size(120, 21);
            this.txtTotCargos.TabIndex = 66;
            this.txtTotCargos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotAbonos
            // 
            this.txtTotAbonos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotAbonos.Location = new System.Drawing.Point(134, 349);
            this.txtTotAbonos.Name = "txtTotAbonos";
            this.txtTotAbonos.ReadOnly = true;
            this.txtTotAbonos.Size = new System.Drawing.Size(120, 21);
            this.txtTotAbonos.TabIndex = 67;
            this.txtTotAbonos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTotTransito
            // 
            this.txtTotTransito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotTransito.Location = new System.Drawing.Point(8, 376);
            this.txtTotTransito.Name = "txtTotTransito";
            this.txtTotTransito.ReadOnly = true;
            this.txtTotTransito.Size = new System.Drawing.Size(120, 21);
            this.txtTotTransito.TabIndex = 69;
            this.txtTotTransito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(134, 373);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(330, 27);
            this.label7.TabIndex = 65;
            this.label7.Text = "En Transito";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(134, 481);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(330, 27);
            this.label5.TabIndex = 63;
            this.label5.Text = "Saldo Circulacion  Mes Anterior";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDif1
            // 
            this.txtDif1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDif1.Location = new System.Drawing.Point(8, 403);
            this.txtDif1.Name = "txtDif1";
            this.txtDif1.ReadOnly = true;
            this.txtDif1.Size = new System.Drawing.Size(120, 21);
            this.txtDif1.TabIndex = 74;
            this.txtDif1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(134, 400);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(330, 27);
            this.label11.TabIndex = 75;
            this.label11.Text = "Diferencia";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(134, 427);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(330, 27);
            this.label8.TabIndex = 70;
            this.label8.Text = "Retiro en Bancos";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRetiroBancos
            // 
            this.txtRetiroBancos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRetiroBancos.Location = new System.Drawing.Point(8, 430);
            this.txtRetiroBancos.Name = "txtRetiroBancos";
            this.txtRetiroBancos.Size = new System.Drawing.Size(120, 21);
            this.txtRetiroBancos.TabIndex = 72;
            this.txtRetiroBancos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtRetiroBancos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRetiroBancos_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(134, 454);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(330, 27);
            this.label9.TabIndex = 71;
            this.label9.Text = "Diferencia";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDif2
            // 
            this.txtDif2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDif2.Location = new System.Drawing.Point(8, 457);
            this.txtDif2.Name = "txtDif2";
            this.txtDif2.ReadOnly = true;
            this.txtDif2.Size = new System.Drawing.Size(120, 21);
            this.txtDif2.TabIndex = 68;
            this.txtDif2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSaldoCirculacionAnterior
            // 
            this.txtSaldoCirculacionAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoCirculacionAnterior.Location = new System.Drawing.Point(8, 484);
            this.txtSaldoCirculacionAnterior.Name = "txtSaldoCirculacionAnterior";
            this.txtSaldoCirculacionAnterior.ReadOnly = true;
            this.txtSaldoCirculacionAnterior.Size = new System.Drawing.Size(120, 21);
            this.txtSaldoCirculacionAnterior.TabIndex = 76;
            this.txtSaldoCirculacionAnterior.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(134, 508);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(330, 27);
            this.label6.TabIndex = 64;
            this.label6.Text = "Saldo en Circulación";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSaldoCirculacion
            // 
            this.txtSaldoCirculacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoCirculacion.Location = new System.Drawing.Point(8, 511);
            this.txtSaldoCirculacion.Name = "txtSaldoCirculacion";
            this.txtSaldoCirculacion.ReadOnly = true;
            this.txtSaldoCirculacion.Size = new System.Drawing.Size(120, 21);
            this.txtSaldoCirculacion.TabIndex = 77;
            this.txtSaldoCirculacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label10, 2);
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(470, 346);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(148, 27);
            this.label10.TabIndex = 73;
            this.label10.Text = "En Transito del Periodo";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTransitoPeriodo
            // 
            this.txtTransitoPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransitoPeriodo.Location = new System.Drawing.Point(624, 349);
            this.txtTransitoPeriodo.Name = "txtTransitoPeriodo";
            this.txtTransitoPeriodo.ReadOnly = true;
            this.txtTransitoPeriodo.Size = new System.Drawing.Size(120, 21);
            this.txtTransitoPeriodo.TabIndex = 78;
            this.txtTransitoPeriodo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label12, 2);
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(470, 373);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(148, 27);
            this.label12.TabIndex = 79;
            this.label12.Text = "Saldo en Bancos";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label13, 2);
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(470, 400);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(148, 27);
            this.label13.TabIndex = 80;
            this.label13.Text = "Saldo en Edo. De Cta.";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label14, 2);
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label14.Location = new System.Drawing.Point(470, 427);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(148, 27);
            this.label14.TabIndex = 81;
            this.label14.Text = "Diferencia ch. en transito";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label15, 2);
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Location = new System.Drawing.Point(470, 454);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(148, 27);
            this.label15.TabIndex = 82;
            this.label15.Text = "En transito periodo anterior";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label16, 2);
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(470, 481);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(148, 27);
            this.label16.TabIndex = 83;
            this.label16.Text = "Ch. Cobrados de mes ant.";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label17, 2);
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.label17.Location = new System.Drawing.Point(470, 508);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(148, 27);
            this.label17.TabIndex = 84;
            this.label17.Text = "Diferencia";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSaldoBancos
            // 
            this.txtSaldoBancos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoBancos.Location = new System.Drawing.Point(624, 376);
            this.txtSaldoBancos.Name = "txtSaldoBancos";
            this.txtSaldoBancos.ReadOnly = true;
            this.txtSaldoBancos.Size = new System.Drawing.Size(120, 21);
            this.txtSaldoBancos.TabIndex = 85;
            this.txtSaldoBancos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSaldoEdoCta
            // 
            this.txtSaldoEdoCta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoEdoCta.Location = new System.Drawing.Point(624, 403);
            this.txtSaldoEdoCta.Name = "txtSaldoEdoCta";
            this.txtSaldoEdoCta.Size = new System.Drawing.Size(120, 21);
            this.txtSaldoEdoCta.TabIndex = 86;
            this.txtSaldoEdoCta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSaldoEdoCta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSaldoEdoCta_KeyPress);
            // 
            // txtDifChTransito
            // 
            this.txtDifChTransito.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDifChTransito.Location = new System.Drawing.Point(624, 430);
            this.txtDifChTransito.Name = "txtDifChTransito";
            this.txtDifChTransito.ReadOnly = true;
            this.txtDifChTransito.Size = new System.Drawing.Size(120, 21);
            this.txtDifChTransito.TabIndex = 87;
            this.txtDifChTransito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTransitoPeriodoAnt
            // 
            this.txtTransitoPeriodoAnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransitoPeriodoAnt.Location = new System.Drawing.Point(624, 457);
            this.txtTransitoPeriodoAnt.Name = "txtTransitoPeriodoAnt";
            this.txtTransitoPeriodoAnt.ReadOnly = true;
            this.txtTransitoPeriodoAnt.Size = new System.Drawing.Size(120, 21);
            this.txtTransitoPeriodoAnt.TabIndex = 88;
            this.txtTransitoPeriodoAnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtChCobradosMesAnt
            // 
            this.txtChCobradosMesAnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChCobradosMesAnt.Location = new System.Drawing.Point(624, 484);
            this.txtChCobradosMesAnt.Name = "txtChCobradosMesAnt";
            this.txtChCobradosMesAnt.Size = new System.Drawing.Size(120, 21);
            this.txtChCobradosMesAnt.TabIndex = 89;
            this.txtChCobradosMesAnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtChCobradosMesAnt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtChCobradosMesAnt_KeyPress);
            // 
            // txtDif3
            // 
            this.txtDif3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDif3.Location = new System.Drawing.Point(624, 511);
            this.txtDif3.Name = "txtDif3";
            this.txtDif3.ReadOnly = true;
            this.txtDif3.Size = new System.Drawing.Size(120, 21);
            this.txtDif3.TabIndex = 90;
            this.txtDif3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmBancos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 577);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBancos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bancos";
            this.Load += new System.EventHandler(this.frmBancos_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luBanco.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editAño)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEstado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luObraComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luTipoComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTransito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPagada)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripButton btnExportar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraGrid.Columns.GridColumn colPagosId;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoMovimientoId;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresa;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoPago;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colFolio;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colConcepto;
        private DevExpress.XtraGrid.Columns.GridColumn colCargo;
        private DevExpress.XtraGrid.Columns.GridColumn colAbono;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colEstado;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit cbTransito;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit cbPagada;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkActivo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luObraComprobante;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luTipoComprobante;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luProveedor;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDetalle;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dtFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMeses;
        private System.Windows.Forms.NumericUpDown editAño;
        private System.Windows.Forms.ToolStripButton btnCerrarMes;
        private System.Windows.Forms.ToolStripButton btnAgregar;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit luEmpresa;
        private DevExpress.XtraEditors.LookUpEdit luBanco;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnConsultar;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luEstado;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaCancelacion;
        private System.Windows.Forms.TextBox txtDif2;
        private System.Windows.Forms.TextBox txtTotAbonos;
        private System.Windows.Forms.TextBox txtTotCargos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotTransito;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRetiroBancos;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDif1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSaldoCirculacionAnterior;
        private System.Windows.Forms.TextBox txtSaldoCirculacion;
        private System.Windows.Forms.TextBox txtTransitoPeriodo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtSaldoBancos;
        private System.Windows.Forms.TextBox txtSaldoEdoCta;
        private System.Windows.Forms.TextBox txtDifChTransito;
        private System.Windows.Forms.TextBox txtTransitoPeriodoAnt;
        private System.Windows.Forms.TextBox txtChCobradosMesAnt;
        private System.Windows.Forms.TextBox txtDif3;
        private System.Windows.Forms.ToolStripLabel lblSaldoInicial;
        private System.Windows.Forms.ToolStripButton btnImprimir;
    }
}