namespace SistemaGEISA
{
    partial class frmAgregarGastosAd
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.luEmpresaId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.luConceptos = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.luTipoPagoId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.luEmpBan = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.luProveedorId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbCancelado = new System.Windows.Forms.Label();
            this.dtFecha = new DevExpress.XtraEditors.DateEdit();
            this.luProveedor = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Factura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Fecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Importe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ConceptoId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Compartido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ckCompartido = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.Proveedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Obra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luObra = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.Observaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckedComboBoxEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.luEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFolio = new System.Windows.Forms.TextBox();
            this.lblBanco = new System.Windows.Forms.Label();
            this.lblReferencia = new System.Windows.Forms.Label();
            this.luBancos = new DevExpress.XtraEditors.LookUpEdit();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.luTipoPago = new DevExpress.XtraEditors.LookUpEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAgregar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpresaId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luConceptos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luTipoPagoId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProveedorId)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.menu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProveedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCompartido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luObra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luBancos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luTipoPago.Properties)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // luEmpresaId
            // 
            this.luEmpresaId.AutoHeight = false;
            this.luEmpresaId.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.luEmpresaId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luEmpresaId.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreComercial", "Nombre Comercial")});
            this.luEmpresaId.Name = "luEmpresaId";
            this.luEmpresaId.NullText = "";
            // 
            // luConceptos
            // 
            this.luConceptos.AutoHeight = false;
            this.luConceptos.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.luConceptos.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luConceptos.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.luConceptos.Name = "luConceptos";
            this.luConceptos.NullText = "";
            // 
            // luTipoPagoId
            // 
            this.luTipoPagoId.AutoHeight = false;
            this.luTipoPagoId.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.luTipoPagoId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luTipoPagoId.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.luTipoPagoId.Name = "luTipoPagoId";
            this.luTipoPagoId.NullText = "";
            // 
            // luEmpBan
            // 
            this.luEmpBan.AutoHeight = false;
            this.luEmpBan.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.luEmpBan.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luEmpBan.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreBanco", "Nombre Banco")});
            this.luEmpBan.Name = "luEmpBan";
            this.luEmpBan.NullText = "";
            // 
            // luProveedorId
            // 
            this.luProveedorId.AutoHeight = false;
            this.luProveedorId.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.luProveedorId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luProveedorId.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreFiscal", "Nombre")});
            this.luProveedorId.Name = "luProveedorId";
            this.luProveedorId.NullText = "";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.menu, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(884, 34);
            this.tableLayoutPanel2.TabIndex = 13;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.toolStripSeparator1,
            this.btnCancelar});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(3);
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menu.Size = new System.Drawing.Size(199, 34);
            this.menu.TabIndex = 6;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::SistemaGEISA.Properties.Resources.document_save;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 25);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::SistemaGEISA.Properties.Resources.cancel1;
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 25);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.80965F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.19035F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 438F));
            this.tableLayoutPanel1.Controls.Add(this.lbCancelado, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtFecha, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.luProveedor, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.grid, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.luEmpresa, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtFolio, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblBanco, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblReferencia, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.luBancos, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtReferencia, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.luTipoPago, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 34);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 527);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // lbCancelado
            // 
            this.lbCancelado.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lbCancelado, 2);
            this.lbCancelado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCancelado.Font = new System.Drawing.Font("Tahoma", 11F);
            this.lbCancelado.ForeColor = System.Drawing.Color.Red;
            this.lbCancelado.Location = new System.Drawing.Point(3, 82);
            this.lbCancelado.Margin = new System.Windows.Forms.Padding(3);
            this.lbCancelado.Name = "lbCancelado";
            this.lbCancelado.Size = new System.Drawing.Size(359, 21);
            this.lbCancelado.TabIndex = 32;
            this.lbCancelado.Text = "C A N C E L A D O";
            this.lbCancelado.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbCancelado.Visible = false;
            // 
            // dtFecha
            // 
            this.dtFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtFecha.EditValue = new System.DateTime(2015, 1, 8, 11, 16, 49, 426);
            this.dtFecha.Location = new System.Drawing.Point(448, 3);
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
            this.dtFecha.Size = new System.Drawing.Size(433, 20);
            this.dtFecha.TabIndex = 31;
            this.dtFecha.EditValueChanged += new System.EventHandler(this.dtFecha_EditValueChanged);
            // 
            // luProveedor
            // 
            this.luProveedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luProveedor.Location = new System.Drawing.Point(101, 30);
            this.luProveedor.Name = "luProveedor";
            this.luProveedor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.luProveedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luProveedor.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreFiscal", "Nombre")});
            this.luProveedor.Properties.NullText = "";
            this.luProveedor.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.luProveedor.Size = new System.Drawing.Size(261, 20);
            this.luProveedor.TabIndex = 28;
            this.luProveedor.EditValueChanged += new System.EventHandler(this.luProveedor_EditValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "Proveedor";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            gridLevelNode1.RelationName = "Level1";
            this.grid.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.grid.Location = new System.Drawing.Point(3, 134);
            this.grid.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.grid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grid.MainView = this.gv;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.luObra,
            this.ckCompartido,
            this.repositoryItemCheckedComboBoxEdit1,
            this.repositoryItemButtonEdit1,
            this.repositoryItemTextEdit1});
            this.grid.Size = new System.Drawing.Size(878, 366);
            this.grid.TabIndex = 26;
            this.grid.UseEmbeddedNavigator = true;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.Factura,
            this.Fecha,
            this.Importe,
            this.ConceptoId,
            this.Compartido,
            this.Proveedor,
            this.Obra,
            this.Observaciones});
            this.gv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gv.GridControl = this.grid;
            this.gv.Name = "gv";
            this.gv.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv.OptionsView.EnableAppearanceEvenRow = true;
            this.gv.OptionsView.EnableAppearanceOddRow = true;
            this.gv.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gv.OptionsView.ShowFooter = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            this.gv.PaintStyleName = "Skin";
            this.gv.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gv_InvalidRowException);
            this.gv.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gv_ValidateRow);
            // 
            // Id
            // 
            this.Id.Caption = "Id";
            this.Id.FieldName = "Id";
            this.Id.Name = "Id";
            // 
            // Factura
            // 
            this.Factura.Caption = "Factura";
            this.Factura.FieldName = "NoFactura";
            this.Factura.Name = "Factura";
            this.Factura.Visible = true;
            this.Factura.VisibleIndex = 0;
            this.Factura.Width = 88;
            // 
            // Fecha
            // 
            this.Fecha.Caption = "Fecha";
            this.Fecha.DisplayFormat.FormatString = "d";
            this.Fecha.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.Fecha.FieldName = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Visible = true;
            this.Fecha.VisibleIndex = 1;
            this.Fecha.Width = 99;
            // 
            // Importe
            // 
            this.Importe.Caption = "Importe";
            this.Importe.DisplayFormat.FormatString = "c2";
            this.Importe.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Importe.FieldName = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Importe", "{0:C2}")});
            this.Importe.Visible = true;
            this.Importe.VisibleIndex = 2;
            this.Importe.Width = 88;
            // 
            // ConceptoId
            // 
            this.ConceptoId.Caption = "Concepto";
            this.ConceptoId.ColumnEdit = this.luConceptos;
            this.ConceptoId.FieldName = "ConceptoId";
            this.ConceptoId.Name = "ConceptoId";
            this.ConceptoId.Visible = true;
            this.ConceptoId.VisibleIndex = 3;
            this.ConceptoId.Width = 99;
            // 
            // Compartido
            // 
            this.Compartido.Caption = "Compartido";
            this.Compartido.ColumnEdit = this.ckCompartido;
            this.Compartido.FieldName = "Compartido";
            this.Compartido.Name = "Compartido";
            this.Compartido.Visible = true;
            this.Compartido.VisibleIndex = 4;
            this.Compartido.Width = 70;
            // 
            // ckCompartido
            // 
            this.ckCompartido.AutoHeight = false;
            this.ckCompartido.Caption = "Check";
            this.ckCompartido.Name = "ckCompartido";
            this.ckCompartido.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // Proveedor
            // 
            this.Proveedor.Caption = "Proveedor";
            this.Proveedor.ColumnEdit = this.luProveedorId;
            this.Proveedor.FieldName = "ProveedorId";
            this.Proveedor.Name = "Proveedor";
            this.Proveedor.Visible = true;
            this.Proveedor.VisibleIndex = 5;
            this.Proveedor.Width = 114;
            // 
            // Obra
            // 
            this.Obra.Caption = "Obra";
            this.Obra.ColumnEdit = this.luObra;
            this.Obra.FieldName = "ObraId";
            this.Obra.Name = "Obra";
            this.Obra.Visible = true;
            this.Obra.VisibleIndex = 6;
            this.Obra.Width = 109;
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
            // Observaciones
            // 
            this.Observaciones.Caption = "Observaciones";
            this.Observaciones.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.Observaciones.FieldName = "Observaciones";
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.Visible = true;
            this.Observaciones.VisibleIndex = 7;
            this.Observaciones.Width = 190;
            // 
            // repositoryItemCheckedComboBoxEdit1
            // 
            this.repositoryItemCheckedComboBoxEdit1.AutoHeight = false;
            this.repositoryItemCheckedComboBoxEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCheckedComboBoxEdit1.Name = "repositoryItemCheckedComboBoxEdit1";
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(368, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo Pago";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 26);
            this.label4.TabIndex = 3;
            this.label4.Text = "Empresa";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // luEmpresa
            // 
            this.luEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luEmpresa.Location = new System.Drawing.Point(101, 56);
            this.luEmpresa.Name = "luEmpresa";
            this.luEmpresa.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.luEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luEmpresa.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreComercial", "Nombre")});
            this.luEmpresa.Properties.NullText = "";
            this.luEmpresa.Size = new System.Drawing.Size(261, 20);
            this.luEmpresa.TabIndex = 22;
            this.luEmpresa.EditValueChanged += new System.EventHandler(this.luEmpresa_EditValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 27);
            this.label5.TabIndex = 15;
            this.label5.Text = "Folio";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFolio
            // 
            this.txtFolio.Location = new System.Drawing.Point(101, 3);
            this.txtFolio.Name = "txtFolio";
            this.txtFolio.Size = new System.Drawing.Size(184, 21);
            this.txtFolio.TabIndex = 17;
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBanco.Location = new System.Drawing.Point(368, 53);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(74, 26);
            this.lblBanco.TabIndex = 14;
            this.lblBanco.Text = "Banco";
            this.lblBanco.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblBanco.Visible = false;
            // 
            // lblReferencia
            // 
            this.lblReferencia.AutoSize = true;
            this.lblReferencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReferencia.Location = new System.Drawing.Point(368, 79);
            this.lblReferencia.Name = "lblReferencia";
            this.lblReferencia.Size = new System.Drawing.Size(74, 27);
            this.lblReferencia.TabIndex = 1;
            this.lblReferencia.Text = "Referencia";
            this.lblReferencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblReferencia.Visible = false;
            // 
            // luBancos
            // 
            this.luBancos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luBancos.Location = new System.Drawing.Point(448, 56);
            this.luBancos.Name = "luBancos";
            this.luBancos.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.luBancos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luBancos.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreBanco", "Nombre"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NoCuenta", "Cuenta")});
            this.luBancos.Properties.NullText = "";
            this.luBancos.Size = new System.Drawing.Size(433, 20);
            this.luBancos.TabIndex = 24;
            this.luBancos.Visible = false;
            this.luBancos.EditValueChanged += new System.EventHandler(this.luBancos_EditValueChanged);
            // 
            // txtReferencia
            // 
            this.txtReferencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReferencia.Location = new System.Drawing.Point(448, 82);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(433, 21);
            this.txtReferencia.TabIndex = 25;
            this.txtReferencia.Visible = false;
            // 
            // luTipoPago
            // 
            this.luTipoPago.Location = new System.Drawing.Point(448, 30);
            this.luTipoPago.Name = "luTipoPago";
            this.luTipoPago.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.luTipoPago.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luTipoPago.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.luTipoPago.Properties.NullText = "";
            this.luTipoPago.Size = new System.Drawing.Size(184, 20);
            this.luTipoPago.TabIndex = 23;
            this.luTipoPago.EditValueChanged += new System.EventHandler(this.luTipoPago_EditValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(368, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 27);
            this.label8.TabIndex = 29;
            this.label8.Text = "Fecha";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.toolStrip1, 2);
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregar,
            this.btnEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 106);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(365, 25);
            this.toolStrip1.TabIndex = 30;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::SistemaGEISA.Properties.Resources.Nuevo;
            this.btnAgregar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(111, 22);
            this.btnAgregar.Text = "Agregar Factura";
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::SistemaGEISA.Properties.Resources.delete;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(102, 22);
            this.btnEliminar.Text = "Quitar Factura";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // frmAgregarGastosAd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "frmAgregarGastosAd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar gastos";
            this.Load += new System.EventHandler(this.frmAgregarGastosAd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.luEmpresaId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luConceptos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luTipoPagoId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProveedorId)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProveedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCompartido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luObra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luBancos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luTipoPago.Properties)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LookUpEdit luBancos;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraGrid.Columns.GridColumn Fecha;
        private DevExpress.XtraGrid.Columns.GridColumn Importe;
        private DevExpress.XtraGrid.Columns.GridColumn Observaciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblReferencia;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.LookUpEdit luTipoPago;
        private System.Windows.Forms.TextBox txtReferencia;
        private DevExpress.XtraEditors.LookUpEdit luEmpresa;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFolio;
        private DevExpress.XtraGrid.Columns.GridColumn Factura;
        private DevExpress.XtraGrid.Columns.GridColumn ConceptoId;
        private DevExpress.XtraGrid.Columns.GridColumn Compartido;
        private DevExpress.XtraGrid.Columns.GridColumn Proveedor;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luEmpresaId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luConceptos;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luTipoPagoId;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luEmpBan;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luProveedorId;
        private DevExpress.XtraGrid.Columns.GridColumn Obra;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luObra;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.LookUpEdit luProveedor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ckCompartido;
        private DevExpress.XtraEditors.DateEdit dtFecha;
        private System.Windows.Forms.Label lbCancelado;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private System.Windows.Forms.ToolStripButton btnAgregar;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit repositoryItemCheckedComboBoxEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
    }
}