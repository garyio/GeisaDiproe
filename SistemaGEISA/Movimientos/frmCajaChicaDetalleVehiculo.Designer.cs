namespace SistemaGEISA
{
    partial class frmCajaChicaDetalleVehiculo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCajaChicaDetalleVehiculo));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCargos = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoDeposito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKilometros = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiferenciaKm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObservaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConductor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkActivo = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.luVehiculo = new DevExpress.XtraEditors.LookUpEdit();
            this.tableLayoutPanel2.SuspendLayout();
            this.menu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luVehiculo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.menu, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(893, 39);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.toolStripSeparator1,
            this.btnCargos,
            this.btnEliminar});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(3);
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menu.Size = new System.Drawing.Size(893, 35);
            this.menu.TabIndex = 3;
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // btnCargos
            // 
            this.btnCargos.Image = global::SistemaGEISA.Properties.Resources.Client_Account_Template_32;
            this.btnCargos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCargos.Name = "btnCargos";
            this.btnCargos.Size = new System.Drawing.Size(70, 26);
            this.btnCargos.Text = "Cargos";
            this.btnCargos.Click += new System.EventHandler(this.btnCargos_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::SistemaGEISA.Properties.Resources.Eliminar;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(76, 26);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.24008F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.75992F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 205F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLayoutPanel1.Controls.Add(this.grid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.luVehiculo, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 39);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 342F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(893, 395);
            this.tableLayoutPanel1.TabIndex = 11;
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
            this.grid.Location = new System.Drawing.Point(8, 34);
            this.grid.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.grid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grid.MainView = this.gv;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkActivo});
            this.grid.Size = new System.Drawing.Size(877, 353);
            this.grid.TabIndex = 2;
            this.grid.UseEmbeddedNavigator = true;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFecha,
            this.colTipoDeposito,
            this.colImporte,
            this.colObra,
            this.colKilometros,
            this.colDiferenciaKm,
            this.colObservaciones,
            this.colConductor});
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
            this.gv.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gv_FocusedRowChanged);
            this.gv.DoubleClick += new System.EventHandler(this.gv_DoubleClick);
            // 
            // colFecha
            // 
            this.colFecha.Caption = "Fecha";
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.OptionsColumn.AllowEdit = false;
            this.colFecha.OptionsColumn.ReadOnly = true;
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 0;
            this.colFecha.Width = 74;
            // 
            // colTipoDeposito
            // 
            this.colTipoDeposito.Caption = "Tipo Deposito";
            this.colTipoDeposito.FieldName = "TipoDepositoNombre";
            this.colTipoDeposito.Name = "colTipoDeposito";
            this.colTipoDeposito.OptionsColumn.AllowEdit = false;
            this.colTipoDeposito.OptionsColumn.ReadOnly = true;
            this.colTipoDeposito.Visible = true;
            this.colTipoDeposito.VisibleIndex = 1;
            this.colTipoDeposito.Width = 85;
            // 
            // colImporte
            // 
            this.colImporte.Caption = "Importe";
            this.colImporte.DisplayFormat.FormatString = "c2";
            this.colImporte.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colImporte.FieldName = "Importe";
            this.colImporte.Name = "colImporte";
            this.colImporte.OptionsColumn.AllowEdit = false;
            this.colImporte.OptionsColumn.ReadOnly = true;
            this.colImporte.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Importe", "{0:C2}")});
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 2;
            this.colImporte.Width = 74;
            // 
            // colObra
            // 
            this.colObra.Caption = "Obra";
            this.colObra.FieldName = "ObraNombre";
            this.colObra.Name = "colObra";
            this.colObra.OptionsColumn.AllowEdit = false;
            this.colObra.OptionsColumn.ReadOnly = true;
            this.colObra.Visible = true;
            this.colObra.VisibleIndex = 3;
            this.colObra.Width = 143;
            // 
            // colKilometros
            // 
            this.colKilometros.Caption = "Km Recorridos";
            this.colKilometros.DisplayFormat.FormatString = "N2";
            this.colKilometros.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKilometros.FieldName = "KilometrosRecorridos";
            this.colKilometros.Name = "colKilometros";
            this.colKilometros.OptionsColumn.AllowEdit = false;
            this.colKilometros.OptionsColumn.FixedWidth = true;
            this.colKilometros.OptionsColumn.ReadOnly = true;
            this.colKilometros.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Max)});
            this.colKilometros.Visible = true;
            this.colKilometros.VisibleIndex = 4;
            // 
            // colDiferenciaKm
            // 
            this.colDiferenciaKm.Caption = "Diferencia Km.";
            this.colDiferenciaKm.DisplayFormat.FormatString = "N2";
            this.colDiferenciaKm.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDiferenciaKm.FieldName = "DiferenciaKm";
            this.colDiferenciaKm.Name = "colDiferenciaKm";
            this.colDiferenciaKm.OptionsColumn.AllowEdit = false;
            this.colDiferenciaKm.OptionsColumn.FixedWidth = true;
            this.colDiferenciaKm.OptionsColumn.ReadOnly = true;
            this.colDiferenciaKm.Visible = true;
            this.colDiferenciaKm.VisibleIndex = 5;
            this.colDiferenciaKm.Width = 84;
            // 
            // colObservaciones
            // 
            this.colObservaciones.Caption = "Observaciones";
            this.colObservaciones.FieldName = "Observaciones";
            this.colObservaciones.Name = "colObservaciones";
            this.colObservaciones.OptionsColumn.AllowEdit = false;
            this.colObservaciones.OptionsColumn.ReadOnly = true;
            this.colObservaciones.Visible = true;
            this.colObservaciones.VisibleIndex = 7;
            this.colObservaciones.Width = 216;
            // 
            // colConductor
            // 
            this.colConductor.Caption = "Conductor";
            this.colConductor.FieldName = "Conductor";
            this.colConductor.Name = "colConductor";
            this.colConductor.OptionsColumn.AllowEdit = false;
            this.colConductor.OptionsColumn.ReadOnly = true;
            this.colConductor.Visible = true;
            this.colConductor.VisibleIndex = 6;
            this.colConductor.Width = 105;
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
            this.label1.Location = new System.Drawing.Point(8, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vehíchulo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // luVehiculo
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.luVehiculo, 2);
            this.luVehiculo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luVehiculo.Location = new System.Drawing.Point(74, 8);
            this.luVehiculo.Name = "luVehiculo";
            this.luVehiculo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luVehiculo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("VehiculoCompleto", "Vehiculo")});
            this.luVehiculo.Properties.NullText = "";
            this.luVehiculo.Size = new System.Drawing.Size(570, 20);
            this.luVehiculo.TabIndex = 0;
            this.luVehiculo.EditValueChanged += new System.EventHandler(this.luVehiculo_EditValueChanged);
            // 
            // frmCajaChicaDetalleVehiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 434);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCajaChicaDetalleVehiculo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Caja Chica Detalle Vehículo";
            this.Load += new System.EventHandler(this.frmCajaChicaDetalleVehiculo_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luVehiculo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnCargos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LookUpEdit luVehiculo;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoDeposito;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colObra;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkActivo;
        private DevExpress.XtraGrid.Columns.GridColumn colObservaciones;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private DevExpress.XtraGrid.Columns.GridColumn colKilometros;
        private DevExpress.XtraGrid.Columns.GridColumn colDiferenciaKm;
        private DevExpress.XtraGrid.Columns.GridColumn colConductor;
    }
}