namespace SistemaGEISA
{
    partial class frmGastosAdministrativos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGastosAdministrativos));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMes = new System.Windows.Forms.Label();
            this.lblYear = new System.Windows.Forms.Label();
            this.cbMeses = new System.Windows.Forms.ComboBox();
            this.editAño = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtGastosDi = new System.Windows.Forms.TextBox();
            this.txtGastosGei = new System.Windows.Forms.TextBox();
            this.txtTotCompartidos = new System.Windows.Forms.TextBox();
            this.txtCompIguales = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtGcDiproe = new System.Windows.Forms.TextBox();
            this.txtGcGeisa = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSaldoPendiente = new System.Windows.Forms.TextBox();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.btnAgregarGasto = new System.Windows.Forms.ToolStripButton();
            this.btnEditarGasto = new System.Windows.Forms.ToolStripButton();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.grid2 = new DevExpress.XtraGrid.GridControl();
            this.gv2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IdPago2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompartido2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ckCompartido2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colGastoAdm2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ckGastoAdm2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colProveedor2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.grid1 = new DevExpress.XtraGrid.GridControl();
            this.gv1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IdPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReferencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConcepto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObservaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompartido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ckCompartido = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colGastoAdm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ckGastoAdm = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colProveedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luConceptos = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editAño)).BeginInit();
            this.menu.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCompartido2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckGastoAdm2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCompartido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckGastoAdm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luConceptos)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 11;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 11F));
            this.tableLayoutPanel1.Controls.Add(this.lblMes, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblYear, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbMeses, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.editAño, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtGastosDi, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtGastosGei, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTotCompartidos, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtCompIguales, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.label5, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtGcDiproe, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtGcGeisa, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.label8, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 8, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtSaldoPendiente, 9, 2);
            this.tableLayoutPanel1.Controls.Add(this.menu, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 7, 0, 0);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1130, 96);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMes.Location = new System.Drawing.Point(3, 7);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(33, 27);
            this.lblMes.TabIndex = 6;
            this.lblMes.Text = "MES:";
            this.lblMes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblYear.Location = new System.Drawing.Point(3, 34);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(33, 27);
            this.lblYear.TabIndex = 7;
            this.lblYear.Text = "AÑO:";
            this.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbMeses
            // 
            this.cbMeses.FormattingEnabled = true;
            this.cbMeses.Location = new System.Drawing.Point(42, 10);
            this.cbMeses.Name = "cbMeses";
            this.cbMeses.Size = new System.Drawing.Size(292, 21);
            this.cbMeses.TabIndex = 8;
            this.cbMeses.SelectedValueChanged += new System.EventHandler(this.cbMeses_SelectedValueChanged);
            // 
            // editAño
            // 
            this.editAño.Location = new System.Drawing.Point(42, 37);
            this.editAño.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.editAño.Name = "editAño";
            this.editAño.Size = new System.Drawing.Size(292, 21);
            this.editAño.TabIndex = 9;
            this.editAño.ValueChanged += new System.EventHandler(this.editAño_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(387, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 27);
            this.label3.TabIndex = 10;
            this.label3.Text = "TOTAL GASTOS DIPROE";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(645, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 27);
            this.label4.TabIndex = 11;
            this.label4.Text = "TOTAL GASTOS GEISA";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(645, 61);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.label6.Size = new System.Drawing.Size(128, 42);
            this.label6.TabIndex = 13;
            this.label6.Text = "GC PARTES IGUALES";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGastosDi
            // 
            this.txtGastosDi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGastosDi.Location = new System.Drawing.Point(529, 10);
            this.txtGastosDi.Name = "txtGastosDi";
            this.txtGastosDi.ReadOnly = true;
            this.txtGastosDi.Size = new System.Drawing.Size(100, 21);
            this.txtGastosDi.TabIndex = 14;
            // 
            // txtGastosGei
            // 
            this.txtGastosGei.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGastosGei.Location = new System.Drawing.Point(779, 10);
            this.txtGastosGei.Name = "txtGastosGei";
            this.txtGastosGei.ReadOnly = true;
            this.txtGastosGei.Size = new System.Drawing.Size(104, 21);
            this.txtGastosGei.TabIndex = 15;
            // 
            // txtTotCompartidos
            // 
            this.txtTotCompartidos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTotCompartidos.Location = new System.Drawing.Point(529, 64);
            this.txtTotCompartidos.Name = "txtTotCompartidos";
            this.txtTotCompartidos.ReadOnly = true;
            this.txtTotCompartidos.Size = new System.Drawing.Size(100, 21);
            this.txtTotCompartidos.TabIndex = 16;
            // 
            // txtCompIguales
            // 
            this.txtCompIguales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCompIguales.Location = new System.Drawing.Point(779, 64);
            this.txtCompIguales.Name = "txtCompIguales";
            this.txtCompIguales.ReadOnly = true;
            this.txtCompIguales.Size = new System.Drawing.Size(104, 21);
            this.txtCompIguales.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(387, 61);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 15);
            this.label5.Size = new System.Drawing.Size(136, 42);
            this.label5.TabIndex = 12;
            this.label5.Text = "TOTAL GC";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(387, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 27);
            this.label7.TabIndex = 18;
            this.label7.Text = "TOTAL GC DIPROE";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGcDiproe
            // 
            this.txtGcDiproe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGcDiproe.Location = new System.Drawing.Point(529, 37);
            this.txtGcDiproe.Name = "txtGcDiproe";
            this.txtGcDiproe.ReadOnly = true;
            this.txtGcDiproe.Size = new System.Drawing.Size(100, 21);
            this.txtGcDiproe.TabIndex = 19;
            // 
            // txtGcGeisa
            // 
            this.txtGcGeisa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGcGeisa.Location = new System.Drawing.Point(779, 37);
            this.txtGcGeisa.Name = "txtGcGeisa";
            this.txtGcGeisa.ReadOnly = true;
            this.txtGcGeisa.Size = new System.Drawing.Size(104, 21);
            this.txtGcGeisa.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(645, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 27);
            this.label8.TabIndex = 21;
            this.label8.Text = "TOTAL GC GEISA";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(889, 61);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 5, 0, 15);
            this.label9.Size = new System.Drawing.Size(172, 42);
            this.label9.TabIndex = 22;
            this.label9.Text = "SALDO PENDIENTE  FACTURAR";
            // 
            // txtSaldoPendiente
            // 
            this.txtSaldoPendiente.Location = new System.Drawing.Point(1067, 64);
            this.txtSaldoPendiente.Name = "txtSaldoPendiente";
            this.txtSaldoPendiente.ReadOnly = true;
            this.txtSaldoPendiente.Size = new System.Drawing.Size(104, 21);
            this.txtSaldoPendiente.TabIndex = 23;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.menu, 3);
            this.menu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregarGasto,
            this.btnEditarGasto,
            this.btnActualizar,
            this.toolStripButton1});
            this.menu.Location = new System.Drawing.Point(0, 61);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menu.Size = new System.Drawing.Size(384, 42);
            this.menu.TabIndex = 5;
            // 
            // btnAgregarGasto
            // 
            this.btnAgregarGasto.Image = global::SistemaGEISA.Properties.Resources.money1;
            this.btnAgregarGasto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarGasto.Name = "btnAgregarGasto";
            this.btnAgregarGasto.Size = new System.Drawing.Size(108, 26);
            this.btnAgregarGasto.Text = "Agregar Gasto";
            this.btnAgregarGasto.Click += new System.EventHandler(this.btnAgregarGasto_Click);
            // 
            // btnEditarGasto
            // 
            this.btnEditarGasto.Image = global::SistemaGEISA.Properties.Resources.Editar;
            this.btnEditarGasto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarGasto.Name = "btnEditarGasto";
            this.btnEditarGasto.Size = new System.Drawing.Size(63, 26);
            this.btnEditarGasto.Text = "Editar";
            this.btnEditarGasto.Click += new System.EventHandler(this.btnEditarGasto_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = global::SistemaGEISA.Properties.Resources.Actualizar;
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(85, 26);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::SistemaGEISA.Properties.Resources.Imprimir;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStripButton1.Size = new System.Drawing.Size(89, 26);
            this.toolStripButton1.Text = "Imprimir";
            this.toolStripButton1.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.grid2, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.grid1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 96);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 94.73684F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.263158F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1130, 456);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // grid2
            // 
            this.grid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid2.Location = new System.Drawing.Point(573, 26);
            this.grid2.MainView = this.gv2;
            this.grid2.Name = "grid2";
            this.grid2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.ckCompartido2,
            this.ckGastoAdm2});
            this.grid2.Size = new System.Drawing.Size(554, 404);
            this.grid2.TabIndex = 1;
            this.grid2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv2});
            // 
            // gv2
            // 
            this.gv2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.IdPago2,
            this.colCompartido2,
            this.colGastoAdm2,
            this.colProveedor2});
            this.gv2.GridControl = this.grid2;
            this.gv2.Name = "gv2";
            this.gv2.OptionsBehavior.ReadOnly = true;
            this.gv2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv2.OptionsView.ShowAutoFilterRow = true;
            this.gv2.OptionsView.ShowGroupPanel = false;
            this.gv2.PaintStyleName = "Skin";
            this.gv2.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gv2_SelectionChanged);
            this.gv2.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gv2_FocusedRowChanged);
            this.gv2.DoubleClick += new System.EventHandler(this.gv2_DoubleClick);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Id";
            this.gridColumn1.FieldName = "Id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Fecha";
            this.gridColumn2.FieldName = "Fecha";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 42;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Factura";
            this.gridColumn3.FieldName = "Factura";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            this.gridColumn3.Width = 47;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Importe";
            this.gridColumn4.DisplayFormat.FormatString = "c2";
            this.gridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn4.FieldName = "Importe";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 2;
            this.gridColumn4.Width = 62;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Ref";
            this.gridColumn5.FieldName = "NoReferencia";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.AllowEdit = false;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 31;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Concepto";
            this.gridColumn6.FieldName = "Concepto";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.OptionsColumn.AllowEdit = false;
            this.gridColumn6.OptionsColumn.FixedWidth = true;
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 4;
            this.gridColumn6.Width = 63;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Observaciones";
            this.gridColumn7.FieldName = "Observaciones";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 5;
            this.gridColumn7.Width = 78;
            // 
            // IdPago2
            // 
            this.IdPago2.Caption = "Id Pago";
            this.IdPago2.FieldName = "IdPago";
            this.IdPago2.Name = "IdPago2";
            this.IdPago2.OptionsColumn.AllowEdit = false;
            // 
            // colCompartido2
            // 
            this.colCompartido2.Caption = "GC";
            this.colCompartido2.ColumnEdit = this.ckCompartido2;
            this.colCompartido2.FieldName = "Compartido";
            this.colCompartido2.Name = "colCompartido2";
            this.colCompartido2.OptionsColumn.AllowEdit = false;
            this.colCompartido2.OptionsColumn.FixedWidth = true;
            this.colCompartido2.Visible = true;
            this.colCompartido2.VisibleIndex = 6;
            this.colCompartido2.Width = 28;
            // 
            // ckCompartido2
            // 
            this.ckCompartido2.AutoHeight = false;
            this.ckCompartido2.Caption = "Check";
            this.ckCompartido2.Name = "ckCompartido2";
            this.ckCompartido2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colGastoAdm2
            // 
            this.colGastoAdm2.Caption = "GA";
            this.colGastoAdm2.ColumnEdit = this.ckGastoAdm2;
            this.colGastoAdm2.FieldName = "GastoAdm";
            this.colGastoAdm2.Name = "colGastoAdm2";
            this.colGastoAdm2.OptionsColumn.AllowEdit = false;
            this.colGastoAdm2.OptionsColumn.FixedWidth = true;
            this.colGastoAdm2.Visible = true;
            this.colGastoAdm2.VisibleIndex = 7;
            this.colGastoAdm2.Width = 28;
            // 
            // ckGastoAdm2
            // 
            this.ckGastoAdm2.AutoHeight = false;
            this.ckGastoAdm2.Caption = "Check";
            this.ckGastoAdm2.Name = "ckGastoAdm2";
            this.ckGastoAdm2.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colProveedor2
            // 
            this.colProveedor2.Caption = "Proveedor";
            this.colProveedor2.FieldName = "Proveedor";
            this.colProveedor2.Name = "colProveedor2";
            this.colProveedor2.Visible = true;
            this.colProveedor2.VisibleIndex = 8;
            this.colProveedor2.Width = 81;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // grid1
            // 
            this.grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid1.Location = new System.Drawing.Point(3, 26);
            this.grid1.MainView = this.gv1;
            this.grid1.Name = "grid1";
            this.grid1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.luConceptos,
            this.ckCompartido,
            this.ckGastoAdm});
            this.grid1.Size = new System.Drawing.Size(554, 404);
            this.grid1.TabIndex = 0;
            this.grid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv1});
            // 
            // gv1
            // 
            this.gv1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IdPago,
            this.colId,
            this.colFecha,
            this.colFactura,
            this.colImporte,
            this.colReferencia,
            this.colConcepto,
            this.colObservaciones,
            this.colCompartido,
            this.colGastoAdm,
            this.colProveedor});
            this.gv1.GridControl = this.grid1;
            this.gv1.Name = "gv1";
            this.gv1.OptionsBehavior.ReadOnly = true;
            this.gv1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv1.OptionsView.ShowAutoFilterRow = true;
            this.gv1.OptionsView.ShowGroupPanel = false;
            this.gv1.PaintStyleName = "Skin";
            this.gv1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gv1_SelectionChanged);
            this.gv1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gv1_FocusedRowChanged);
            this.gv1.DoubleClick += new System.EventHandler(this.gv1_DoubleClick);
            // 
            // IdPago
            // 
            this.IdPago.Caption = "Id Pago";
            this.IdPago.FieldName = "IdPago";
            this.IdPago.Name = "IdPago";
            this.IdPago.OptionsColumn.AllowEdit = false;
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            // 
            // colFecha
            // 
            this.colFecha.Caption = "Fecha";
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.OptionsColumn.AllowEdit = false;
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 0;
            this.colFecha.Width = 40;
            // 
            // colFactura
            // 
            this.colFactura.Caption = "Factura";
            this.colFactura.FieldName = "Factura";
            this.colFactura.Name = "colFactura";
            this.colFactura.OptionsColumn.AllowEdit = false;
            this.colFactura.OptionsColumn.FixedWidth = true;
            this.colFactura.Visible = true;
            this.colFactura.VisibleIndex = 1;
            this.colFactura.Width = 50;
            // 
            // colImporte
            // 
            this.colImporte.Caption = "Importe";
            this.colImporte.DisplayFormat.FormatString = "c2";
            this.colImporte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.OptionsColumn.AllowEdit = false;
            this.colImporte.OptionsColumn.FixedWidth = true;
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 2;
            this.colImporte.Width = 66;
            // 
            // colReferencia
            // 
            this.colReferencia.Caption = "Ref";
            this.colReferencia.FieldName = "NoReferencia";
            this.colReferencia.Name = "colReferencia";
            this.colReferencia.OptionsColumn.AllowEdit = false;
            this.colReferencia.Visible = true;
            this.colReferencia.VisibleIndex = 3;
            this.colReferencia.Width = 28;
            // 
            // colConcepto
            // 
            this.colConcepto.Caption = "Concepto";
            this.colConcepto.FieldName = "Concepto";
            this.colConcepto.Name = "colConcepto";
            this.colConcepto.OptionsColumn.AllowEdit = false;
            this.colConcepto.OptionsColumn.FixedWidth = true;
            this.colConcepto.Visible = true;
            this.colConcepto.VisibleIndex = 4;
            this.colConcepto.Width = 59;
            // 
            // colObservaciones
            // 
            this.colObservaciones.Caption = "Observaciones";
            this.colObservaciones.FieldName = "Observaciones";
            this.colObservaciones.Name = "colObservaciones";
            this.colObservaciones.OptionsColumn.AllowEdit = false;
            this.colObservaciones.Visible = true;
            this.colObservaciones.VisibleIndex = 5;
            this.colObservaciones.Width = 79;
            // 
            // colCompartido
            // 
            this.colCompartido.Caption = "GC";
            this.colCompartido.ColumnEdit = this.ckCompartido;
            this.colCompartido.FieldName = "Compartido";
            this.colCompartido.Name = "colCompartido";
            this.colCompartido.OptionsColumn.AllowEdit = false;
            this.colCompartido.OptionsColumn.FixedWidth = true;
            this.colCompartido.Visible = true;
            this.colCompartido.VisibleIndex = 6;
            this.colCompartido.Width = 28;
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
            this.colGastoAdm.OptionsColumn.AllowEdit = false;
            this.colGastoAdm.OptionsColumn.FixedWidth = true;
            this.colGastoAdm.Visible = true;
            this.colGastoAdm.VisibleIndex = 7;
            this.colGastoAdm.Width = 28;
            // 
            // ckGastoAdm
            // 
            this.ckGastoAdm.AutoHeight = false;
            this.ckGastoAdm.Caption = "Check";
            this.ckGastoAdm.Name = "ckGastoAdm";
            this.ckGastoAdm.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colProveedor
            // 
            this.colProveedor.Caption = "Proveedor";
            this.colProveedor.FieldName = "Proveedor";
            this.colProveedor.Name = "colProveedor";
            this.colProveedor.Visible = true;
            this.colProveedor.VisibleIndex = 8;
            this.colProveedor.Width = 82;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "EMPRESA 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(573, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "EMPRESA 2";
            // 
            // frmGastosAdministrativos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 552);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmGastosAdministrativos";
            this.Text = "Gastos Administrativos";
            this.Load += new System.EventHandler(this.frmGastosAdministrativos_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.editAño)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCompartido2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckGastoAdm2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCompartido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckGastoAdm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luConceptos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton btnAgregarGasto;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraGrid.GridControl grid2;
        private DevExpress.XtraGrid.Views.Grid.GridView gv2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.GridControl grid1;
        private DevExpress.XtraGrid.Views.Grid.GridView gv1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colFactura;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colReferencia;
        private DevExpress.XtraGrid.Columns.GridColumn colConcepto;
        private DevExpress.XtraGrid.Columns.GridColumn colObservaciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.ComboBox cbMeses;
        private System.Windows.Forms.NumericUpDown editAño;
        private System.Windows.Forms.ToolStripButton btnEditarGasto;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtGastosDi;
        private System.Windows.Forms.TextBox txtGastosGei;
        private System.Windows.Forms.TextBox txtTotCompartidos;
        private System.Windows.Forms.TextBox txtCompIguales;
        private DevExpress.XtraGrid.Columns.GridColumn IdPago2;
        private DevExpress.XtraGrid.Columns.GridColumn IdPago;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luConceptos;
        private DevExpress.XtraGrid.Columns.GridColumn colCompartido2;
        private DevExpress.XtraGrid.Columns.GridColumn colCompartido;
        private DevExpress.XtraGrid.Columns.GridColumn colGastoAdm2;
        private DevExpress.XtraGrid.Columns.GridColumn colGastoAdm;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ckCompartido2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ckGastoAdm2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ckCompartido;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ckGastoAdm;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private DevExpress.XtraGrid.Columns.GridColumn colProveedor2;
        private DevExpress.XtraGrid.Columns.GridColumn colProveedor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtGcDiproe;
        private System.Windows.Forms.TextBox txtGcGeisa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSaldoPendiente;
    }
}