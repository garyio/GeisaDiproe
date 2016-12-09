namespace SistemaGEISA
{
    partial class frmBuscadorFacturas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBuscadorFacturas));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnReporte = new System.Windows.Forms.ToolStripButton();
            this.btnActualizar = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmpresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaCancelacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaFactura = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImporte = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProveedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCliente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoMovimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConsecutivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContrarecibo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTarjetaCredito = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConcepto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCompartido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ckCompartido = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colGastoAdm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ckGastoAdm = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colObservaciones = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.luEmpresa = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProveedorFiscal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCompartido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckGastoAdm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpresa)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReporte,
            this.btnActualizar,
            this.btnImprimir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1080, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnReporte
            // 
            this.btnReporte.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnReporte.Image = global::SistemaGEISA.Properties.Resources.Reportes;
            this.btnReporte.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnReporte.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(154, 36);
            this.btnReporte.Text = "Exportar Información";
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnActualizar.Image = global::SistemaGEISA.Properties.Resources.Actualizar;
            this.btnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(79, 36);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnImprimir.Image = global::SistemaGEISA.Properties.Resources.Imprimir;
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(73, 36);
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EmbeddedNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.grid.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.grid.Location = new System.Drawing.Point(0, 39);
            this.grid.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.grid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grid.MainView = this.gv;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ckCompartido,
            this.ckGastoAdm,
            this.luEmpresa});
            this.grid.Size = new System.Drawing.Size(1080, 222);
            this.grid.TabIndex = 1;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmpresa,
            this.colFechaCancelacion,
            this.colFactura,
            this.colFechaFactura,
            this.colImporte,
            this.colProveedor,
            this.colProveedorFiscal,
            this.colCliente,
            this.colObra,
            this.colTipoMovimiento,
            this.colConsecutivo,
            this.colTipoPago,
            this.colContrarecibo,
            this.colTarjetaCredito,
            this.colConcepto,
            this.colCompartido,
            this.colGastoAdm,
            this.colObservaciones,
            this.colFechaPago});
            this.gv.CustomizationFormBounds = new System.Drawing.Rectangle(920, 222, 216, 192);
            this.gv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gv.GridControl = this.grid;
            this.gv.Name = "gv";
            this.gv.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv.OptionsView.EnableAppearanceEvenRow = true;
            this.gv.OptionsView.EnableAppearanceOddRow = true;
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            this.gv.PaintStyleName = "Skin";
            // 
            // colEmpresa
            // 
            this.colEmpresa.Caption = "Empresa";
            this.colEmpresa.FieldName = "EmpresaNombre";
            this.colEmpresa.Name = "colEmpresa";
            this.colEmpresa.OptionsColumn.AllowEdit = false;
            this.colEmpresa.OptionsColumn.ReadOnly = true;
            this.colEmpresa.Visible = true;
            this.colEmpresa.VisibleIndex = 1;
            this.colEmpresa.Width = 55;
            // 
            // colFechaCancelacion
            // 
            this.colFechaCancelacion.Caption = "Cancelacion";
            this.colFechaCancelacion.FieldName = "FechaCancelacion";
            this.colFechaCancelacion.Name = "colFechaCancelacion";
            this.colFechaCancelacion.OptionsColumn.AllowEdit = false;
            this.colFechaCancelacion.OptionsColumn.ReadOnly = true;
            this.colFechaCancelacion.Visible = true;
            this.colFechaCancelacion.VisibleIndex = 0;
            this.colFechaCancelacion.Width = 60;
            // 
            // colFactura
            // 
            this.colFactura.Caption = "Factura";
            this.colFactura.FieldName = "Factura";
            this.colFactura.Name = "colFactura";
            this.colFactura.OptionsColumn.AllowEdit = false;
            this.colFactura.OptionsColumn.ReadOnly = true;
            this.colFactura.Visible = true;
            this.colFactura.VisibleIndex = 2;
            this.colFactura.Width = 42;
            // 
            // colFechaFactura
            // 
            this.colFechaFactura.Caption = "Fecha Fact.";
            this.colFechaFactura.FieldName = "FechaFactura";
            this.colFechaFactura.Name = "colFechaFactura";
            this.colFechaFactura.OptionsColumn.AllowEdit = false;
            this.colFechaFactura.OptionsColumn.ReadOnly = true;
            this.colFechaFactura.Visible = true;
            this.colFechaFactura.VisibleIndex = 3;
            this.colFechaFactura.Width = 62;
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
            this.colImporte.Visible = true;
            this.colImporte.VisibleIndex = 5;
            this.colImporte.Width = 50;
            // 
            // colProveedor
            // 
            this.colProveedor.Caption = "Proveedor Comercial";
            this.colProveedor.FieldName = "ProveedorComercial";
            this.colProveedor.Name = "colProveedor";
            this.colProveedor.OptionsColumn.AllowEdit = false;
            this.colProveedor.OptionsColumn.FixedWidth = true;
            this.colProveedor.OptionsColumn.ReadOnly = true;
            this.colProveedor.Visible = true;
            this.colProveedor.VisibleIndex = 6;
            this.colProveedor.Width = 100;
            // 
            // colCliente
            // 
            this.colCliente.Caption = "Cliente - Dev.";
            this.colCliente.FieldName = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.OptionsColumn.AllowEdit = false;
            this.colCliente.OptionsColumn.FixedWidth = true;
            this.colCliente.OptionsColumn.ReadOnly = true;
            this.colCliente.Visible = true;
            this.colCliente.VisibleIndex = 8;
            this.colCliente.Width = 90;
            // 
            // colObra
            // 
            this.colObra.Caption = "Obra";
            this.colObra.FieldName = "Obra_Nombre";
            this.colObra.Name = "colObra";
            this.colObra.OptionsColumn.AllowEdit = false;
            this.colObra.OptionsColumn.ReadOnly = true;
            this.colObra.Visible = true;
            this.colObra.VisibleIndex = 9;
            this.colObra.Width = 80;
            // 
            // colTipoMovimiento
            // 
            this.colTipoMovimiento.Caption = "Movimiento";
            this.colTipoMovimiento.FieldName = "TipoMovimiento_Nombre";
            this.colTipoMovimiento.Name = "colTipoMovimiento";
            this.colTipoMovimiento.OptionsColumn.AllowEdit = false;
            this.colTipoMovimiento.OptionsColumn.ReadOnly = true;
            this.colTipoMovimiento.Visible = true;
            this.colTipoMovimiento.VisibleIndex = 10;
            this.colTipoMovimiento.Width = 52;
            // 
            // colConsecutivo
            // 
            this.colConsecutivo.Caption = "Ref";
            this.colConsecutivo.FieldName = "Pago_Consecutivo";
            this.colConsecutivo.Name = "colConsecutivo";
            this.colConsecutivo.OptionsColumn.AllowEdit = false;
            this.colConsecutivo.OptionsColumn.ReadOnly = true;
            this.colConsecutivo.Visible = true;
            this.colConsecutivo.VisibleIndex = 11;
            this.colConsecutivo.Width = 24;
            // 
            // colTipoPago
            // 
            this.colTipoPago.Caption = "Tipo Pago";
            this.colTipoPago.FieldName = "TipoPago_Nombre";
            this.colTipoPago.Name = "colTipoPago";
            this.colTipoPago.OptionsColumn.AllowEdit = false;
            this.colTipoPago.OptionsColumn.ReadOnly = true;
            this.colTipoPago.Visible = true;
            this.colTipoPago.VisibleIndex = 12;
            this.colTipoPago.Width = 62;
            // 
            // colContrarecibo
            // 
            this.colContrarecibo.Caption = "Contr.";
            this.colContrarecibo.FieldName = "Contrarecibo_Folio";
            this.colContrarecibo.Name = "colContrarecibo";
            this.colContrarecibo.OptionsColumn.AllowEdit = false;
            this.colContrarecibo.OptionsColumn.ReadOnly = true;
            this.colContrarecibo.Visible = true;
            this.colContrarecibo.VisibleIndex = 13;
            this.colContrarecibo.Width = 45;
            // 
            // colTarjetaCredito
            // 
            this.colTarjetaCredito.Caption = "Tarjeta Credito";
            this.colTarjetaCredito.FieldName = "TarjetaEmpleado";
            this.colTarjetaCredito.Name = "colTarjetaCredito";
            this.colTarjetaCredito.OptionsColumn.AllowEdit = false;
            this.colTarjetaCredito.OptionsColumn.ReadOnly = true;
            this.colTarjetaCredito.Visible = true;
            this.colTarjetaCredito.VisibleIndex = 14;
            this.colTarjetaCredito.Width = 62;
            // 
            // colConcepto
            // 
            this.colConcepto.Caption = "Concepto";
            this.colConcepto.FieldName = "Concepto";
            this.colConcepto.Name = "colConcepto";
            this.colConcepto.OptionsColumn.AllowEdit = false;
            this.colConcepto.OptionsColumn.ReadOnly = true;
            this.colConcepto.Width = 60;
            // 
            // colCompartido
            // 
            this.colCompartido.Caption = "GC";
            this.colCompartido.ColumnEdit = this.ckCompartido;
            this.colCompartido.FieldName = "Compartido";
            this.colCompartido.Name = "colCompartido";
            this.colCompartido.OptionsColumn.AllowEdit = false;
            this.colCompartido.OptionsColumn.ReadOnly = true;
            this.colCompartido.Visible = true;
            this.colCompartido.VisibleIndex = 15;
            this.colCompartido.Width = 20;
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
            this.colGastoAdm.OptionsColumn.ReadOnly = true;
            this.colGastoAdm.Visible = true;
            this.colGastoAdm.VisibleIndex = 16;
            this.colGastoAdm.Width = 21;
            // 
            // ckGastoAdm
            // 
            this.ckGastoAdm.AutoHeight = false;
            this.ckGastoAdm.Caption = "Check";
            this.ckGastoAdm.Name = "ckGastoAdm";
            this.ckGastoAdm.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colObservaciones
            // 
            this.colObservaciones.Caption = "Observaciones";
            this.colObservaciones.FieldName = "Observaciones";
            this.colObservaciones.Name = "colObservaciones";
            this.colObservaciones.OptionsColumn.AllowEdit = false;
            this.colObservaciones.OptionsColumn.ReadOnly = true;
            this.colObservaciones.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;
            this.colObservaciones.Visible = true;
            this.colObservaciones.VisibleIndex = 17;
            this.colObservaciones.Width = 100;
            // 
            // colFechaPago
            // 
            this.colFechaPago.Caption = "Fecha Pago";
            this.colFechaPago.FieldName = "FechaPago";
            this.colFechaPago.Name = "colFechaPago";
            this.colFechaPago.OptionsColumn.AllowEdit = false;
            this.colFechaPago.OptionsColumn.ReadOnly = true;
            this.colFechaPago.Visible = true;
            this.colFechaPago.VisibleIndex = 4;
            this.colFechaPago.Width = 55;
            // 
            // luEmpresa
            // 
            this.luEmpresa.AutoHeight = false;
            this.luEmpresa.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.luEmpresa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luEmpresa.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreComercial", "Nombre Comercial")});
            this.luEmpresa.Name = "luEmpresa";
            this.luEmpresa.NullText = "";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Proveedor";
            this.gridColumn1.FieldName = "ProveedorComercial";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 6;
            this.gridColumn1.Width = 98;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Proveedor";
            this.gridColumn2.FieldName = "ProveedorComercial";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 6;
            this.gridColumn2.Width = 98;
            // 
            // colProveedorFiscal
            // 
            this.colProveedorFiscal.Caption = "Proveedor Fiscal";
            this.colProveedorFiscal.FieldName = "ProveedorFiscal";
            this.colProveedorFiscal.Name = "colProveedorFiscal";
            this.colProveedorFiscal.OptionsColumn.AllowEdit = false;
            this.colProveedorFiscal.OptionsColumn.FixedWidth = true;
            this.colProveedorFiscal.OptionsColumn.ReadOnly = true;
            this.colProveedorFiscal.Visible = true;
            this.colProveedorFiscal.VisibleIndex = 7;
            this.colProveedorFiscal.Width = 100;
            // 
            // frmBuscadorFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 261);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBuscadorFacturas";
            this.Text = "Buscador de Facturas";
            this.Load += new System.EventHandler(this.frmBuscadorFacturas_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckCompartido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckGastoAdm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpresa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnReporte;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaCancelacion;
        private DevExpress.XtraGrid.Columns.GridColumn colFactura;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaFactura;
        private DevExpress.XtraGrid.Columns.GridColumn colImporte;
        private DevExpress.XtraGrid.Columns.GridColumn colProveedor;
        private DevExpress.XtraGrid.Columns.GridColumn colObra;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoMovimiento;
        private DevExpress.XtraGrid.Columns.GridColumn colConsecutivo;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoPago;
        private DevExpress.XtraGrid.Columns.GridColumn colContrarecibo;
        private DevExpress.XtraGrid.Columns.GridColumn colTarjetaCredito;
        private DevExpress.XtraGrid.Columns.GridColumn colConcepto;
        private DevExpress.XtraGrid.Columns.GridColumn colCompartido;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ckCompartido;
        private DevExpress.XtraGrid.Columns.GridColumn colGastoAdm;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ckGastoAdm;
        private DevExpress.XtraGrid.Columns.GridColumn colObservaciones;
        private System.Windows.Forms.ToolStripButton btnActualizar;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresa;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luEmpresa;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaPago;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private DevExpress.XtraGrid.Columns.GridColumn colCliente;
        private DevExpress.XtraGrid.Columns.GridColumn colProveedorFiscal;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}