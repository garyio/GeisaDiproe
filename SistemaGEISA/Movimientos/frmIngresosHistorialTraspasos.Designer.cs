namespace SistemaGEISA
{
    partial class frmIngresosHistorialTraspasos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngresosHistorialTraspasos));
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIdTraspaso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIdPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObraOrigen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClienteOrigen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpresaOrigen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObraDestino = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colClienteDestino = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpresaDestino = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFacturaFolio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoPago = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkActivo = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.luObraComprobante = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.luTipoComprobante = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.luProveedor = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.dtfecha = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.ckExtra = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luObraComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luTipoComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtfecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtfecha.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckExtra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.grid.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.grid.EmbeddedNavigator.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.grid.Location = new System.Drawing.Point(0, 49);
            this.grid.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.grid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grid.MainView = this.gv;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkActivo,
            this.luObraComprobante,
            this.luTipoComprobante,
            this.luProveedor,
            this.dtfecha,
            this.ckExtra});
            this.grid.Size = new System.Drawing.Size(832, 212);
            this.grid.TabIndex = 54;
            this.grid.UseEmbeddedNavigator = true;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv,
            this.gridView1});
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIdTraspaso,
            this.colIdPago,
            this.colObraOrigen,
            this.colClienteOrigen,
            this.colEmpresaOrigen,
            this.colObraDestino,
            this.colClienteDestino,
            this.colEmpresaDestino,
            this.colFecha,
            this.colFacturaFolio,
            this.colTipoPago,
            this.colMonto});
            this.gv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gv.GridControl = this.grid;
            this.gv.Name = "gv";
            this.gv.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gv.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv.OptionsView.EnableAppearanceEvenRow = true;
            this.gv.OptionsView.EnableAppearanceOddRow = true;
            this.gv.OptionsView.ShowFooter = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            this.gv.PaintStyleName = "Skin";
            this.gv.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gv_FocusedRowChanged);
            this.gv.DoubleClick += new System.EventHandler(this.gv_DoubleClick);
            // 
            // colIdTraspaso
            // 
            this.colIdTraspaso.FieldName = "Id";
            this.colIdTraspaso.Name = "colIdTraspaso";
            this.colIdTraspaso.OptionsColumn.AllowEdit = false;
            this.colIdTraspaso.OptionsColumn.ReadOnly = true;
            // 
            // colIdPago
            // 
            this.colIdPago.Caption = "Id Pago";
            this.colIdPago.FieldName = "IdPago";
            this.colIdPago.Name = "colIdPago";
            this.colIdPago.OptionsColumn.AllowEdit = false;
            this.colIdPago.OptionsColumn.FixedWidth = true;
            this.colIdPago.OptionsColumn.ReadOnly = true;
            // 
            // colObraOrigen
            // 
            this.colObraOrigen.Caption = "Obra Orien";
            this.colObraOrigen.FieldName = "ObraOrigen";
            this.colObraOrigen.Name = "colObraOrigen";
            this.colObraOrigen.OptionsColumn.AllowEdit = false;
            this.colObraOrigen.OptionsColumn.FixedWidth = true;
            this.colObraOrigen.OptionsColumn.ReadOnly = true;
            this.colObraOrigen.Visible = true;
            this.colObraOrigen.VisibleIndex = 1;
            // 
            // colClienteOrigen
            // 
            this.colClienteOrigen.Caption = "Cli. Origen";
            this.colClienteOrigen.FieldName = "ClienteOrigen";
            this.colClienteOrigen.Name = "colClienteOrigen";
            this.colClienteOrigen.OptionsColumn.AllowEdit = false;
            this.colClienteOrigen.OptionsColumn.FixedWidth = true;
            this.colClienteOrigen.OptionsColumn.ReadOnly = true;
            this.colClienteOrigen.Visible = true;
            this.colClienteOrigen.VisibleIndex = 2;
            // 
            // colEmpresaOrigen
            // 
            this.colEmpresaOrigen.Caption = "Emp. Origen";
            this.colEmpresaOrigen.FieldName = "EmpresaOrigen";
            this.colEmpresaOrigen.Name = "colEmpresaOrigen";
            this.colEmpresaOrigen.OptionsColumn.AllowEdit = false;
            this.colEmpresaOrigen.OptionsColumn.FixedWidth = true;
            this.colEmpresaOrigen.OptionsColumn.ReadOnly = true;
            this.colEmpresaOrigen.Visible = true;
            this.colEmpresaOrigen.VisibleIndex = 3;
            // 
            // colObraDestino
            // 
            this.colObraDestino.Caption = "Obra Dest.";
            this.colObraDestino.FieldName = "ObraDestino";
            this.colObraDestino.Name = "colObraDestino";
            this.colObraDestino.OptionsColumn.AllowEdit = false;
            this.colObraDestino.OptionsColumn.FixedWidth = true;
            this.colObraDestino.OptionsColumn.ReadOnly = true;
            this.colObraDestino.Visible = true;
            this.colObraDestino.VisibleIndex = 4;
            // 
            // colClienteDestino
            // 
            this.colClienteDestino.Caption = "Cli. Dest.";
            this.colClienteDestino.FieldName = "ClienteDestino";
            this.colClienteDestino.Name = "colClienteDestino";
            this.colClienteDestino.OptionsColumn.AllowEdit = false;
            this.colClienteDestino.OptionsColumn.FixedWidth = true;
            this.colClienteDestino.OptionsColumn.ReadOnly = true;
            this.colClienteDestino.Visible = true;
            this.colClienteDestino.VisibleIndex = 5;
            // 
            // colEmpresaDestino
            // 
            this.colEmpresaDestino.Caption = "Emp. Dest.";
            this.colEmpresaDestino.FieldName = "EmpresaDestino";
            this.colEmpresaDestino.Name = "colEmpresaDestino";
            this.colEmpresaDestino.OptionsColumn.AllowEdit = false;
            this.colEmpresaDestino.OptionsColumn.FixedWidth = true;
            this.colEmpresaDestino.OptionsColumn.ReadOnly = true;
            this.colEmpresaDestino.Visible = true;
            this.colEmpresaDestino.VisibleIndex = 6;
            // 
            // colFecha
            // 
            this.colFecha.Caption = "Fecha";
            this.colFecha.DisplayFormat.FormatString = "d";
            this.colFecha.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colFecha.FieldName = "Fecha";
            this.colFecha.Name = "colFecha";
            this.colFecha.OptionsColumn.AllowEdit = false;
            this.colFecha.OptionsColumn.FixedWidth = true;
            this.colFecha.OptionsColumn.ReadOnly = true;
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 0;
            // 
            // colFacturaFolio
            // 
            this.colFacturaFolio.Caption = "Fact. Folio";
            this.colFacturaFolio.FieldName = "FolioNum";
            this.colFacturaFolio.Name = "colFacturaFolio";
            this.colFacturaFolio.OptionsColumn.AllowEdit = false;
            this.colFacturaFolio.OptionsColumn.FixedWidth = true;
            this.colFacturaFolio.OptionsColumn.ReadOnly = true;
            this.colFacturaFolio.Visible = true;
            this.colFacturaFolio.VisibleIndex = 8;
            // 
            // colTipoPago
            // 
            this.colTipoPago.Caption = "Tipo Pago";
            this.colTipoPago.FieldName = "TipoPago_Nombre";
            this.colTipoPago.Name = "colTipoPago";
            this.colTipoPago.OptionsColumn.AllowEdit = false;
            this.colTipoPago.OptionsColumn.FixedWidth = true;
            this.colTipoPago.OptionsColumn.ReadOnly = true;
            this.colTipoPago.Visible = true;
            this.colTipoPago.VisibleIndex = 7;
            this.colTipoPago.Width = 106;
            // 
            // colMonto
            // 
            this.colMonto.Caption = "Monto";
            this.colMonto.DisplayFormat.FormatString = "c2";
            this.colMonto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMonto.FieldName = "Monto";
            this.colMonto.Name = "colMonto";
            this.colMonto.OptionsColumn.AllowEdit = false;
            this.colMonto.OptionsColumn.FixedWidth = true;
            this.colMonto.OptionsColumn.ReadOnly = true;
            this.colMonto.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Monto", "{0:C2}")});
            this.colMonto.Visible = true;
            this.colMonto.VisibleIndex = 9;
            this.colMonto.Width = 96;
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
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreFiscal", "Nombre Fiscal")});
            this.luProveedor.Name = "luProveedor";
            this.luProveedor.NullText = "";
            // 
            // dtfecha
            // 
            this.dtfecha.AutoHeight = false;
            this.dtfecha.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtfecha.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtfecha.Name = "dtfecha";
            // 
            // ckExtra
            // 
            this.ckExtra.Caption = "";
            this.ckExtra.Name = "ckExtra";
            this.ckExtra.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.grid;
            this.gridView1.Name = "gridView1";
            // 
            // btnEditar
            // 
            this.btnEditar.Image = global::SistemaGEISA.Properties.Resources.Editar;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Padding = new System.Windows.Forms.Padding(5);
            this.btnEditar.Size = new System.Drawing.Size(83, 46);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::SistemaGEISA.Properties.Resources.Eliminar;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(86, 46);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEditar,
            this.btnCancelar,
            this.btnEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Margin = new System.Windows.Forms.Padding(3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(832, 49);
            this.toolStrip1.TabIndex = 53;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::SistemaGEISA.Properties.Resources.cancel1;
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(138, 46);
            this.btnCancelar.Text = "Cancelar Traspaso";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // frmIngresosHistorialTraspasos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 261);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmIngresosHistorialTraspasos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial Traspasos";
            this.Load += new System.EventHandler(this.frmIngresosHistorialTraspasos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luObraComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luTipoComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtfecha.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtfecha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckExtra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraGrid.Columns.GridColumn colIdTraspaso;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoPago;
        private DevExpress.XtraGrid.Columns.GridColumn colMonto;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkActivo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luObraComprobante;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luTipoComprobante;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luProveedor;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dtfecha;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ckExtra;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private DevExpress.XtraGrid.Columns.GridColumn colObraOrigen;
        private DevExpress.XtraGrid.Columns.GridColumn colClienteOrigen;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresaOrigen;
        private DevExpress.XtraGrid.Columns.GridColumn colObraDestino;
        private DevExpress.XtraGrid.Columns.GridColumn colClienteDestino;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresaDestino;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colFacturaFolio;
        private DevExpress.XtraGrid.Columns.GridColumn colIdPago;
        private System.Windows.Forms.ToolStripButton btnCancelar;

    }
}