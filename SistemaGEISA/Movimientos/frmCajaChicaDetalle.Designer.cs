namespace SistemaGEISA
{
    partial class frmCajaChicaDetalle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCajaChicaDetalle));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnDepositar = new System.Windows.Forms.ToolStripButton();
            this.btnComprobante = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.btnReporte = new System.Windows.Forms.ToolStripButton();
            this.layoutFechasReporte = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtInicio = new DevExpress.XtraEditors.DateEdit();
            this.dtFin = new DevExpress.XtraEditors.DateEdit();
            this.btnEjecutar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoReferencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepositos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNominas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFacturas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoDeducibles = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBiaticos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDevoluciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObservaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkActivo = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.luResidente = new DevExpress.XtraEditors.LookUpEdit();
            this.luObra = new DevExpress.XtraEditors.LookUpEdit();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2.SuspendLayout();
            this.menu.SuspendLayout();
            this.layoutFechasReporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luResidente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luObra.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.menu, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.layoutFechasReporte, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1041, 39);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.btnDepositar,
            this.btnComprobante,
            this.btnEliminar,
            this.btnImprimir,
            this.btnReporte});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(3);
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menu.Size = new System.Drawing.Size(582, 39);
            this.menu.TabIndex = 3;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 30);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnDepositar
            // 
            this.btnDepositar.Image = global::SistemaGEISA.Properties.Resources.money;
            this.btnDepositar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDepositar.Name = "btnDepositar";
            this.btnDepositar.Size = new System.Drawing.Size(83, 30);
            this.btnDepositar.Text = "Depositar";
            this.btnDepositar.Click += new System.EventHandler(this.btnDepositar_Click);
            // 
            // btnComprobante
            // 
            this.btnComprobante.Image = global::SistemaGEISA.Properties.Resources.Client_Account_Template_32;
            this.btnComprobante.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnComprobante.Name = "btnComprobante";
            this.btnComprobante.Size = new System.Drawing.Size(107, 30);
            this.btnComprobante.Text = "Comprobante";
            this.btnComprobante.Click += new System.EventHandler(this.btnComprobar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::SistemaGEISA.Properties.Resources.Eliminar;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(76, 30);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("btnImprimir.Image")));
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(79, 30);
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnReporte.Image = global::SistemaGEISA.Properties.Resources.Reportes;
            this.btnReporte.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReporte.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(154, 30);
            this.btnReporte.Text = "Exportar Información";
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // layoutFechasReporte
            // 
            this.layoutFechasReporte.ColumnCount = 5;
            this.layoutFechasReporte.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutFechasReporte.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutFechasReporte.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutFechasReporte.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutFechasReporte.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.layoutFechasReporte.Controls.Add(this.label4, 0, 0);
            this.layoutFechasReporte.Controls.Add(this.label5, 2, 0);
            this.layoutFechasReporte.Controls.Add(this.dtInicio, 1, 0);
            this.layoutFechasReporte.Controls.Add(this.dtFin, 3, 0);
            this.layoutFechasReporte.Controls.Add(this.btnEjecutar, 4, 0);
            this.layoutFechasReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutFechasReporte.Location = new System.Drawing.Point(585, 3);
            this.layoutFechasReporte.Name = "layoutFechasReporte";
            this.layoutFechasReporte.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.layoutFechasReporte.RowCount = 1;
            this.layoutFechasReporte.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layoutFechasReporte.Size = new System.Drawing.Size(453, 33);
            this.layoutFechasReporte.TabIndex = 4;
            this.layoutFechasReporte.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 28);
            this.label4.TabIndex = 0;
            this.label4.Text = "Fecha Inicio";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(179, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 28);
            this.label5.TabIndex = 1;
            this.label5.Text = "Fecha Fin";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtInicio
            // 
            this.dtInicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtInicio.EditValue = new System.DateTime(2016, 9, 1, 21, 40, 0, 0);
            this.dtInicio.Location = new System.Drawing.Point(73, 8);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInicio.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtInicio.Size = new System.Drawing.Size(100, 20);
            this.dtInicio.TabIndex = 2;
            // 
            // dtFin
            // 
            this.dtFin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtFin.EditValue = new System.DateTime(2016, 9, 1, 21, 40, 0, 0);
            this.dtFin.Location = new System.Drawing.Point(238, 8);
            this.dtFin.Name = "dtFin";
            this.dtFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFin.Size = new System.Drawing.Size(100, 20);
            this.dtFin.TabIndex = 3;
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Location = new System.Drawing.Point(344, 8);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(75, 22);
            this.btnEjecutar.TabIndex = 4;
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.24008F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.75992F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 326F));
            this.tableLayoutPanel1.Controls.Add(this.grid, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.luResidente, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.luObra, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSaldo, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 39);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 342F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1041, 404);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // grid
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grid, 4);
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grid.EmbeddedNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.grid.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.grid.Location = new System.Drawing.Point(3, 56);
            this.grid.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.grid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grid.MainView = this.gv;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkActivo});
            this.grid.Size = new System.Drawing.Size(1035, 345);
            this.grid.TabIndex = 2;
            this.grid.UseEmbeddedNavigator = true;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colObra,
            this.colEmpresa,
            this.colFecha,
            this.colTipoPago,
            this.colNoReferencia,
            this.colDepositos,
            this.colNominas,
            this.colFacturas,
            this.colNoDeducibles,
            this.colBiaticos,
            this.colDevoluciones,
            this.colObservaciones,
            this.colTotal});
            this.gv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gv.GridControl = this.grid;
            this.gv.Name = "gv";
            this.gv.OptionsBehavior.Editable = false;
            this.gv.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv.OptionsView.EnableAppearanceEvenRow = true;
            this.gv.OptionsView.EnableAppearanceOddRow = true;
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.OptionsView.ShowFooter = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            this.gv.PaintStyleName = "Skin";
            this.gv.DoubleClick += new System.EventHandler(this.gv_DoubleClick);
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colObra
            // 
            this.colObra.Caption = "Obra";
            this.colObra.FieldName = "ObraNombre";
            this.colObra.Name = "colObra";
            this.colObra.Visible = true;
            this.colObra.VisibleIndex = 0;
            this.colObra.Width = 78;
            // 
            // colEmpresa
            // 
            this.colEmpresa.Caption = "Empresa";
            this.colEmpresa.FieldName = "EmpresaNombre";
            this.colEmpresa.Name = "colEmpresa";
            this.colEmpresa.Visible = true;
            this.colEmpresa.VisibleIndex = 1;
            this.colEmpresa.Width = 78;
            // 
            // colFecha
            // 
            this.colFecha.Caption = "Fecha";
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 2;
            this.colFecha.Width = 78;
            // 
            // colTipoPago
            // 
            this.colTipoPago.Caption = "Tipo de pago";
            this.colTipoPago.FieldName = "TipoPagoNombre";
            this.colTipoPago.Name = "colTipoPago";
            this.colTipoPago.Visible = true;
            this.colTipoPago.VisibleIndex = 3;
            this.colTipoPago.Width = 78;
            // 
            // colNoReferencia
            // 
            this.colNoReferencia.Caption = "Referencia";
            this.colNoReferencia.FieldName = "NoReferencia";
            this.colNoReferencia.Name = "colNoReferencia";
            this.colNoReferencia.Visible = true;
            this.colNoReferencia.VisibleIndex = 4;
            this.colNoReferencia.Width = 78;
            // 
            // colDepositos
            // 
            this.colDepositos.Caption = "Depositos";
            this.colDepositos.DisplayFormat.FormatString = "c2";
            this.colDepositos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDepositos.FieldName = "Deposito";
            this.colDepositos.Name = "colDepositos";
            this.colDepositos.OptionsColumn.FixedWidth = true;
            this.colDepositos.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Deposito", "{0:c2}")});
            this.colDepositos.Visible = true;
            this.colDepositos.VisibleIndex = 5;
            this.colDepositos.Width = 78;
            // 
            // colNominas
            // 
            this.colNominas.Caption = "Nominas";
            this.colNominas.DisplayFormat.FormatString = "c2";
            this.colNominas.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNominas.FieldName = "Nominas";
            this.colNominas.Name = "colNominas";
            this.colNominas.OptionsColumn.FixedWidth = true;
            this.colNominas.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Nominas", "{0:c2}")});
            this.colNominas.Visible = true;
            this.colNominas.VisibleIndex = 6;
            this.colNominas.Width = 62;
            // 
            // colFacturas
            // 
            this.colFacturas.Caption = "Facturas";
            this.colFacturas.DisplayFormat.FormatString = "c2";
            this.colFacturas.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFacturas.FieldName = "Facturas";
            this.colFacturas.Name = "colFacturas";
            this.colFacturas.OptionsColumn.FixedWidth = true;
            this.colFacturas.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Facturas", "{0:c2}")});
            this.colFacturas.Visible = true;
            this.colFacturas.VisibleIndex = 7;
            this.colFacturas.Width = 64;
            // 
            // colNoDeducibles
            // 
            this.colNoDeducibles.Caption = "No deducibles";
            this.colNoDeducibles.DisplayFormat.FormatString = "c2";
            this.colNoDeducibles.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNoDeducibles.FieldName = "NoDeducibles";
            this.colNoDeducibles.Name = "colNoDeducibles";
            this.colNoDeducibles.OptionsColumn.FixedWidth = true;
            this.colNoDeducibles.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "NoDeducibles", "{0:c2}")});
            this.colNoDeducibles.Visible = true;
            this.colNoDeducibles.VisibleIndex = 10;
            this.colNoDeducibles.Width = 83;
            // 
            // colBiaticos
            // 
            this.colBiaticos.Caption = "Viaticos";
            this.colBiaticos.DisplayFormat.FormatString = "c2";
            this.colBiaticos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBiaticos.FieldName = "Biaticos";
            this.colBiaticos.Name = "colBiaticos";
            this.colBiaticos.OptionsColumn.FixedWidth = true;
            this.colBiaticos.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Biaticos", "{0:c2}")});
            this.colBiaticos.Visible = true;
            this.colBiaticos.VisibleIndex = 8;
            this.colBiaticos.Width = 64;
            // 
            // colDevoluciones
            // 
            this.colDevoluciones.Caption = "Devolución";
            this.colDevoluciones.DisplayFormat.FormatString = "C2";
            this.colDevoluciones.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDevoluciones.FieldName = "Devolucion";
            this.colDevoluciones.Name = "colDevoluciones";
            this.colDevoluciones.OptionsColumn.FixedWidth = true;
            this.colDevoluciones.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Devolucion", "{0:c2}")});
            this.colDevoluciones.Visible = true;
            this.colDevoluciones.VisibleIndex = 9;
            // 
            // colObservaciones
            // 
            this.colObservaciones.Caption = "Observaciones";
            this.colObservaciones.FieldName = "ObservacionesConcatenadasCalc";
            this.colObservaciones.Name = "colObservaciones";
            this.colObservaciones.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colObservaciones.Visible = true;
            this.colObservaciones.VisibleIndex = 11;
            this.colObservaciones.Width = 96;
            // 
            // colTotal
            // 
            this.colTotal.Caption = "Total";
            this.colTotal.DisplayFormat.FormatString = "c2";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:c2}")});
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 12;
            this.colTotal.Width = 102;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoHeight = false;
            this.chkActivo.Caption = "Check";
            this.chkActivo.Name = "chkActivo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empleado";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Obra Actual";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // luResidente
            // 
            this.luResidente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luResidente.EditValue = "";
            this.luResidente.Location = new System.Drawing.Point(80, 3);
            this.luResidente.Name = "luResidente";
            this.luResidente.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luResidente.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Residente", "Nombre")});
            this.luResidente.Properties.NullText = "";
            this.luResidente.Size = new System.Drawing.Size(426, 20);
            this.luResidente.TabIndex = 0;
            this.luResidente.EditValueChanged += new System.EventHandler(this.luResidente_EditValueChanged);
            // 
            // luObra
            // 
            this.luObra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luObra.Location = new System.Drawing.Point(80, 29);
            this.luObra.Name = "luObra";
            this.luObra.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luObra.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.luObra.Properties.NullText = "";
            this.luObra.Size = new System.Drawing.Size(426, 20);
            this.luObra.TabIndex = 1;
            // 
            // txtSaldo
            // 
            this.txtSaldo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSaldo.Location = new System.Drawing.Point(717, 29);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(321, 21);
            this.txtSaldo.TabIndex = 3;
            this.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(512, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "Saldo Actual:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmCajaChicaDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 443);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCajaChicaDetalle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caja Chica Detalle";
            this.Load += new System.EventHandler(this.frmCajaChicaDetalle_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.layoutFechasReporte.ResumeLayout(false);
            this.layoutFechasReporte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtInicio.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luResidente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luObra.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton btnDepositar;
        private System.Windows.Forms.ToolStripButton btnComprobante;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraGrid.Columns.GridColumn colObra;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresa;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoPago;
        private DevExpress.XtraGrid.Columns.GridColumn colNoReferencia;
        private DevExpress.XtraGrid.Columns.GridColumn colDepositos;
        private DevExpress.XtraGrid.Columns.GridColumn colNominas;
        private DevExpress.XtraGrid.Columns.GridColumn colFacturas;
        private DevExpress.XtraGrid.Columns.GridColumn colNoDeducibles;
        private DevExpress.XtraGrid.Columns.GridColumn colBiaticos;
        private DevExpress.XtraGrid.Columns.GridColumn colObservaciones;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkActivo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LookUpEdit luResidente;
        private DevExpress.XtraEditors.LookUpEdit luObra;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripButton btnReporte;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colDevoluciones;
        private System.Windows.Forms.TableLayoutPanel layoutFechasReporte;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.DateEdit dtInicio;
        private DevExpress.XtraEditors.DateEdit dtFin;
        private System.Windows.Forms.Button btnEjecutar;
    }
}