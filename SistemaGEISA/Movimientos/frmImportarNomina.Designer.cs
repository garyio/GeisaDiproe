namespace SistemaGEISA
{
    partial class frmImportarNomina
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImportarNomina));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSemana = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.rgOpcion = new DevExpress.XtraEditors.RadioGroup();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkActual = new DevExpress.XtraEditors.CheckEdit();
            this.chkTodos = new DevExpress.XtraEditors.CheckEdit();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luObra = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colEmpleado = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luEmpleado = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSueldoFiscal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComplemento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSueldoReal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExtras = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompensacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdeudosPagos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaltas = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInfonavit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colViaticos = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAsimilados = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkActivo = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.luObraComprobante = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.luTipoComprobante = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.luUnidad = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.spinCantidad = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.luArticulos = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.luEstatus = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgOpcion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActual.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTodos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luObra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpleado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luObraComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luTipoComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luUnidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luArticulos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEstatus)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5);
            this.toolStrip1.Size = new System.Drawing.Size(1002, 39);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::SistemaGEISA.Properties.Resources.Guardar;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(125, 26);
            this.btnGuardar.Text = "Importar Nomina";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.monthCalendar, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblSemana, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.grid, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 39);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1002, 389);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // monthCalendar
            // 
            this.monthCalendar.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.monthCalendar.Location = new System.Drawing.Point(201, 14);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.ShowWeekNumbers = true;
            this.monthCalendar.TabIndex = 1;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateSelected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 180);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selecciona Dia de Semana a Calcular";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSemana
            // 
            this.lblSemana.AutoSize = true;
            this.lblSemana.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSemana.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSemana.Location = new System.Drawing.Point(689, 5);
            this.lblSemana.Name = "lblSemana";
            this.lblSemana.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.lblSemana.Size = new System.Drawing.Size(305, 180);
            this.lblSemana.TabIndex = 3;
            this.lblSemana.Text = "-";
            this.lblSemana.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.Controls.Add(this.rgOpcion, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.chkActual, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkTodos, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(483, 8);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 174);
            this.tableLayoutPanel2.TabIndex = 18;
            // 
            // rgOpcion
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.rgOpcion, 2);
            this.rgOpcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgOpcion.Enabled = false;
            this.rgOpcion.Location = new System.Drawing.Point(3, 28);
            this.rgOpcion.Name = "rgOpcion";
            this.rgOpcion.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "TODOS"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "SEMANAL"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "QUINCENAL"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(4, "MENSUAL")});
            this.rgOpcion.Size = new System.Drawing.Size(194, 118);
            this.rgOpcion.TabIndex = 84;
            this.rgOpcion.SelectedIndexChanged += new System.EventHandler(this.rgOpcion_EditValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Semana Seleccionada:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Todas las Semanas:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkActual
            // 
            this.chkActual.Location = new System.Drawing.Point(177, 3);
            this.chkActual.Name = "chkActual";
            this.chkActual.Properties.Caption = "";
            this.chkActual.Size = new System.Drawing.Size(20, 19);
            this.chkActual.TabIndex = 86;
            this.chkActual.CheckedChanged += new System.EventHandler(this.chkActual_CheckedChanged_1);
            // 
            // chkTodos
            // 
            this.chkTodos.Location = new System.Drawing.Point(177, 152);
            this.chkTodos.Name = "chkTodos";
            this.chkTodos.Properties.Caption = "";
            this.chkTodos.Size = new System.Drawing.Size(20, 19);
            this.chkTodos.TabIndex = 87;
            this.chkTodos.CheckedChanged += new System.EventHandler(this.chkTodasSemanas_CheckedChanged);
            // 
            // grid
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grid, 4);
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EmbeddedNavigator.Appearance.Font = new System.Drawing.Font("Tahoma", 7F);
            this.grid.EmbeddedNavigator.Appearance.Options.UseFont = true;
            this.grid.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grid.EmbeddedNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.grid.Location = new System.Drawing.Point(8, 188);
            this.grid.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.grid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grid.MainView = this.gv;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkActivo,
            this.luObraComprobante,
            this.luTipoComprobante,
            this.repositoryItemLookUpEdit1,
            this.luUnidad,
            this.spinCantidad,
            this.luArticulos,
            this.luEstatus,
            this.luEmpleado,
            this.luObra});
            this.grid.Size = new System.Drawing.Size(986, 193);
            this.grid.TabIndex = 17;
            this.grid.UseEmbeddedNavigator = true;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colObra,
            this.colEmpleado,
            this.colSueldoFiscal,
            this.colComplemento,
            this.colSueldoReal,
            this.colExtras,
            this.colCompensacion,
            this.colAdeudosPagos,
            this.colFaltas,
            this.colInfonavit,
            this.colViaticos,
            this.colTotal,
            this.colAsimilados});
            this.gv.GridControl = this.grid;
            this.gv.Name = "gv";
            this.gv.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gv.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gv.OptionsView.EnableAppearanceEvenRow = true;
            this.gv.OptionsView.EnableAppearanceOddRow = true;
            this.gv.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.OptionsView.ShowFooter = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            this.gv.PaintStyleName = "Skin";
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ReadOnly = true;
            // 
            // colObra
            // 
            this.colObra.Caption = "Obra";
            this.colObra.ColumnEdit = this.luObra;
            this.colObra.FieldName = "ObraId";
            this.colObra.Name = "colObra";
            this.colObra.OptionsColumn.AllowEdit = false;
            this.colObra.OptionsColumn.FixedWidth = true;
            this.colObra.OptionsColumn.ReadOnly = true;
            // 
            // luObra
            // 
            this.luObra.AutoHeight = false;
            this.luObra.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.luObra.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luObra.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.luObra.Name = "luObra";
            this.luObra.NullText = "";
            // 
            // colEmpleado
            // 
            this.colEmpleado.Caption = "Empleado";
            this.colEmpleado.ColumnEdit = this.luEmpleado;
            this.colEmpleado.FieldName = "EmpleadoId";
            this.colEmpleado.Name = "colEmpleado";
            this.colEmpleado.OptionsColumn.AllowEdit = false;
            this.colEmpleado.OptionsColumn.FixedWidth = true;
            this.colEmpleado.OptionsColumn.ReadOnly = true;
            this.colEmpleado.Visible = true;
            this.colEmpleado.VisibleIndex = 0;
            this.colEmpleado.Width = 81;
            // 
            // luEmpleado
            // 
            this.luEmpleado.AutoHeight = false;
            this.luEmpleado.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.luEmpleado.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luEmpleado.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreCompleto", "Nombre")});
            this.luEmpleado.Name = "luEmpleado";
            this.luEmpleado.NullText = "";
            // 
            // colSueldoFiscal
            // 
            this.colSueldoFiscal.Caption = "Sueldo Fiscal";
            this.colSueldoFiscal.DisplayFormat.FormatString = "c2";
            this.colSueldoFiscal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSueldoFiscal.FieldName = "SueldoFiscal";
            this.colSueldoFiscal.Name = "colSueldoFiscal";
            this.colSueldoFiscal.OptionsColumn.AllowEdit = false;
            this.colSueldoFiscal.OptionsColumn.FixedWidth = true;
            this.colSueldoFiscal.OptionsColumn.ReadOnly = true;
            this.colSueldoFiscal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SueldoFiscal", "{0:C2}")});
            this.colSueldoFiscal.Visible = true;
            this.colSueldoFiscal.VisibleIndex = 1;
            this.colSueldoFiscal.Width = 80;
            // 
            // colComplemento
            // 
            this.colComplemento.Caption = "Complemento";
            this.colComplemento.DisplayFormat.FormatString = "c2";
            this.colComplemento.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colComplemento.FieldName = "Complemento";
            this.colComplemento.Name = "colComplemento";
            this.colComplemento.OptionsColumn.AllowEdit = false;
            this.colComplemento.OptionsColumn.FixedWidth = true;
            this.colComplemento.OptionsColumn.ReadOnly = true;
            this.colComplemento.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Complemento", "{0:C2}")});
            this.colComplemento.Visible = true;
            this.colComplemento.VisibleIndex = 2;
            // 
            // colSueldoReal
            // 
            this.colSueldoReal.Caption = "Sueldo Real";
            this.colSueldoReal.DisplayFormat.FormatString = "c2";
            this.colSueldoReal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSueldoReal.FieldName = "SueldoReal";
            this.colSueldoReal.Name = "colSueldoReal";
            this.colSueldoReal.OptionsColumn.AllowEdit = false;
            this.colSueldoReal.OptionsColumn.FixedWidth = true;
            this.colSueldoReal.OptionsColumn.ReadOnly = true;
            this.colSueldoReal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SueldoReal", "{0:C2}")});
            this.colSueldoReal.Visible = true;
            this.colSueldoReal.VisibleIndex = 3;
            this.colSueldoReal.Width = 77;
            // 
            // colExtras
            // 
            this.colExtras.Caption = "Extras";
            this.colExtras.DisplayFormat.FormatString = "c2";
            this.colExtras.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colExtras.FieldName = "ExtrasCalc";
            this.colExtras.Name = "colExtras";
            this.colExtras.OptionsColumn.AllowEdit = false;
            this.colExtras.OptionsColumn.FixedWidth = true;
            this.colExtras.OptionsColumn.ReadOnly = true;
            this.colExtras.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Extras", "{0:C2}")});
            this.colExtras.Visible = true;
            this.colExtras.VisibleIndex = 4;
            this.colExtras.Width = 78;
            // 
            // colCompensacion
            // 
            this.colCompensacion.Caption = "Compensacion";
            this.colCompensacion.DisplayFormat.FormatString = "c2";
            this.colCompensacion.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colCompensacion.FieldName = "CompensacionCalc";
            this.colCompensacion.Name = "colCompensacion";
            this.colCompensacion.OptionsColumn.AllowEdit = false;
            this.colCompensacion.OptionsColumn.FixedWidth = true;
            this.colCompensacion.OptionsColumn.ReadOnly = true;
            this.colCompensacion.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "CompensacionCalculo", "{0:C2}")});
            this.colCompensacion.Visible = true;
            this.colCompensacion.VisibleIndex = 5;
            this.colCompensacion.Width = 76;
            // 
            // colAdeudosPagos
            // 
            this.colAdeudosPagos.Caption = "Adeudos/Pagos";
            this.colAdeudosPagos.DisplayFormat.FormatString = "c2";
            this.colAdeudosPagos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAdeudosPagos.FieldName = "AdeudosPagosCalc";
            this.colAdeudosPagos.Name = "colAdeudosPagos";
            this.colAdeudosPagos.OptionsColumn.AllowEdit = false;
            this.colAdeudosPagos.OptionsColumn.FixedWidth = true;
            this.colAdeudosPagos.OptionsColumn.ReadOnly = true;
            this.colAdeudosPagos.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AdeudosPagos", "{0:C2}")});
            this.colAdeudosPagos.Visible = true;
            this.colAdeudosPagos.VisibleIndex = 6;
            this.colAdeudosPagos.Width = 85;
            // 
            // colFaltas
            // 
            this.colFaltas.Caption = "Faltas";
            this.colFaltas.DisplayFormat.FormatString = "c2";
            this.colFaltas.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colFaltas.FieldName = "FaltasCalc";
            this.colFaltas.Name = "colFaltas";
            this.colFaltas.OptionsColumn.AllowEdit = false;
            this.colFaltas.OptionsColumn.FixedWidth = true;
            this.colFaltas.OptionsColumn.ReadOnly = true;
            this.colFaltas.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Faltas", "{0:C2}")});
            this.colFaltas.Visible = true;
            this.colFaltas.VisibleIndex = 7;
            this.colFaltas.Width = 69;
            // 
            // colInfonavit
            // 
            this.colInfonavit.Caption = "Infonavit";
            this.colInfonavit.DisplayFormat.FormatString = "c2";
            this.colInfonavit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colInfonavit.FieldName = "Infonavit";
            this.colInfonavit.Name = "colInfonavit";
            this.colInfonavit.OptionsColumn.AllowEdit = false;
            this.colInfonavit.OptionsColumn.FixedWidth = true;
            this.colInfonavit.OptionsColumn.ReadOnly = true;
            this.colInfonavit.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Infonavit", "{0:C2}")});
            this.colInfonavit.Visible = true;
            this.colInfonavit.VisibleIndex = 8;
            this.colInfonavit.Width = 70;
            // 
            // colViaticos
            // 
            this.colViaticos.Caption = "Viaticos";
            this.colViaticos.DisplayFormat.FormatString = "c2";
            this.colViaticos.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colViaticos.FieldName = "ViaticosCalc";
            this.colViaticos.Name = "colViaticos";
            this.colViaticos.OptionsColumn.AllowEdit = false;
            this.colViaticos.OptionsColumn.FixedWidth = true;
            this.colViaticos.OptionsColumn.ReadOnly = true;
            this.colViaticos.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ViaticosCalc", "{0:C2}")});
            this.colViaticos.Visible = true;
            this.colViaticos.VisibleIndex = 9;
            this.colViaticos.Width = 60;
            // 
            // colTotal
            // 
            this.colTotal.Caption = "Total";
            this.colTotal.DisplayFormat.FormatString = "c2";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.OptionsColumn.FixedWidth = true;
            this.colTotal.OptionsColumn.ReadOnly = true;
            this.colTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:C2}")});
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 10;
            this.colTotal.Width = 84;
            // 
            // colAsimilados
            // 
            this.colAsimilados.Caption = "Asimilados";
            this.colAsimilados.DisplayFormat.FormatString = "c2";
            this.colAsimilados.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAsimilados.FieldName = "calcAsimilados";
            this.colAsimilados.Name = "colAsimilados";
            this.colAsimilados.OptionsColumn.AllowEdit = false;
            this.colAsimilados.OptionsColumn.FixedWidth = true;
            this.colAsimilados.OptionsColumn.ReadOnly = true;
            this.colAsimilados.Visible = true;
            this.colAsimilados.VisibleIndex = 11;
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
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreFiscal", "Nombre Fiscal")});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            // 
            // luUnidad
            // 
            this.luUnidad.AutoHeight = false;
            this.luUnidad.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luUnidad.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.luUnidad.Name = "luUnidad";
            this.luUnidad.NullText = "";
            // 
            // spinCantidad
            // 
            this.spinCantidad.AutoHeight = false;
            this.spinCantidad.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinCantidad.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinCantidad.IsFloatValue = false;
            this.spinCantidad.Mask.EditMask = "N00.00";
            this.spinCantidad.MaxValue = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.spinCantidad.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinCantidad.Name = "spinCantidad";
            // 
            // luArticulos
            // 
            this.luArticulos.AutoHeight = false;
            this.luArticulos.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.luArticulos.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luArticulos.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Descripcion", "Descripcion")});
            this.luArticulos.Name = "luArticulos";
            this.luArticulos.NullText = "";
            this.luArticulos.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            // 
            // luEstatus
            // 
            this.luEstatus.AutoHeight = false;
            this.luEstatus.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.luEstatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luEstatus.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Estatus", "Estatus")});
            this.luEstatus.Name = "luEstatus";
            this.luEstatus.NullText = "";
            // 
            // frmImportarNomina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 428);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmImportarNomina";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Importar Nomina ";
            this.Load += new System.EventHandler(this.frmImportarNomina_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rgOpcion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActual.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTodos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luObra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpleado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luObraComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luTipoComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luUnidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luArticulos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEstatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSemana;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.RadioGroup rgOpcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.CheckEdit chkActual;
        private DevExpress.XtraEditors.CheckEdit chkTodos;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colObra;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luObra;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpleado;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luEmpleado;
        private DevExpress.XtraGrid.Columns.GridColumn colSueldoFiscal;
        private DevExpress.XtraGrid.Columns.GridColumn colComplemento;
        private DevExpress.XtraGrid.Columns.GridColumn colSueldoReal;
        private DevExpress.XtraGrid.Columns.GridColumn colExtras;
        private DevExpress.XtraGrid.Columns.GridColumn colCompensacion;
        private DevExpress.XtraGrid.Columns.GridColumn colAdeudosPagos;
        private DevExpress.XtraGrid.Columns.GridColumn colFaltas;
        private DevExpress.XtraGrid.Columns.GridColumn colInfonavit;
        private DevExpress.XtraGrid.Columns.GridColumn colViaticos;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colAsimilados;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkActivo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luObraComprobante;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luTipoComprobante;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luUnidad;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spinCantidad;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luArticulos;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luEstatus;
    }
}