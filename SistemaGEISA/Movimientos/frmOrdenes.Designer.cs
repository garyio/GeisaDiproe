namespace SistemaGEISA
{
    partial class frmOrdenes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOrdenes));
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFechaCancelacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFecha = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFolioCompleto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProveedor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSolicitadoPor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colComprador = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTipoMovimiento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colObra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEstadoOrden = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkActivo = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.btnExportar = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivo)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.menu.SuspendLayout();
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
            this.grid.Font = new System.Drawing.Font("Calibri", 8.25F);
            this.grid.Location = new System.Drawing.Point(0, 38);
            this.grid.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.grid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grid.MainView = this.gv;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkActivo});
            this.grid.Size = new System.Drawing.Size(964, 223);
            this.grid.TabIndex = 12;
            this.grid.UseEmbeddedNavigator = true;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colFechaCancelacion,
            this.colFecha,
            this.colFolioCompleto,
            this.colEmpresa,
            this.colProveedor,
            this.colSolicitadoPor,
            this.colComprador,
            this.colTipoMovimiento,
            this.colObra,
            this.colTotal,
            this.colEstadoOrden});
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
            this.gv.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gv_RowStyle);
            this.gv.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gv_FocusedRowChanged);
            this.gv.DoubleClick += new System.EventHandler(this.gv_DoubleClick);
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colFechaCancelacion
            // 
            this.colFechaCancelacion.Caption = "Cancelacion";
            this.colFechaCancelacion.FieldName = "FechaCancelacion";
            this.colFechaCancelacion.Name = "colFechaCancelacion";
            this.colFechaCancelacion.Visible = true;
            this.colFechaCancelacion.VisibleIndex = 0;
            this.colFechaCancelacion.Width = 69;
            // 
            // colFecha
            // 
            this.colFecha.Caption = "Fecha";
            this.colFecha.FieldName = "FechaRegistro";
            this.colFecha.Name = "colFecha";
            this.colFecha.Visible = true;
            this.colFecha.VisibleIndex = 1;
            this.colFecha.Width = 49;
            // 
            // colFolioCompleto
            // 
            this.colFolioCompleto.Caption = "Folio";
            this.colFolioCompleto.FieldName = "FolioCompleto";
            this.colFolioCompleto.Name = "colFolioCompleto";
            this.colFolioCompleto.Visible = true;
            this.colFolioCompleto.VisibleIndex = 2;
            this.colFolioCompleto.Width = 52;
            // 
            // colEmpresa
            // 
            this.colEmpresa.Caption = "Empresa";
            this.colEmpresa.FieldName = "EmpresaNombre";
            this.colEmpresa.Name = "colEmpresa";
            this.colEmpresa.Visible = true;
            this.colEmpresa.VisibleIndex = 5;
            this.colEmpresa.Width = 72;
            // 
            // colProveedor
            // 
            this.colProveedor.Caption = "Proveedor";
            this.colProveedor.FieldName = "ProveedorNombre";
            this.colProveedor.Name = "colProveedor";
            this.colProveedor.Visible = true;
            this.colProveedor.VisibleIndex = 6;
            this.colProveedor.Width = 130;
            // 
            // colSolicitadoPor
            // 
            this.colSolicitadoPor.Caption = "Solicitado Por";
            this.colSolicitadoPor.FieldName = "EmpleadoSolicito";
            this.colSolicitadoPor.Name = "colSolicitadoPor";
            this.colSolicitadoPor.Visible = true;
            this.colSolicitadoPor.VisibleIndex = 7;
            this.colSolicitadoPor.Width = 98;
            // 
            // colComprador
            // 
            this.colComprador.Caption = "Comprador";
            this.colComprador.FieldName = "CompradorNombre";
            this.colComprador.Name = "colComprador";
            this.colComprador.Visible = true;
            this.colComprador.VisibleIndex = 8;
            this.colComprador.Width = 87;
            // 
            // colTipoMovimiento
            // 
            this.colTipoMovimiento.Caption = "Tipo Movimiento";
            this.colTipoMovimiento.FieldName = "TipoMovimientoNombre";
            this.colTipoMovimiento.Name = "colTipoMovimiento";
            this.colTipoMovimiento.Visible = true;
            this.colTipoMovimiento.VisibleIndex = 3;
            this.colTipoMovimiento.Width = 90;
            // 
            // colObra
            // 
            this.colObra.Caption = "Obra";
            this.colObra.FieldName = "ObraNombre";
            this.colObra.Name = "colObra";
            this.colObra.Visible = true;
            this.colObra.VisibleIndex = 4;
            this.colObra.Width = 97;
            // 
            // colTotal
            // 
            this.colTotal.Caption = "Total";
            this.colTotal.DisplayFormat.FormatString = "c2";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:C2}")});
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 10;
            this.colTotal.Width = 121;
            // 
            // colEstadoOrden
            // 
            this.colEstadoOrden.Caption = "Estado";
            this.colEstadoOrden.FieldName = "EstadoOrden";
            this.colEstadoOrden.Name = "colEstadoOrden";
            this.colEstadoOrden.Visible = true;
            this.colEstadoOrden.VisibleIndex = 9;
            this.colEstadoOrden.Width = 78;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoHeight = false;
            this.chkActivo.Caption = "Check";
            this.chkActivo.Name = "chkActivo";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 743F));
            this.tableLayoutPanel1.Controls.Add(this.menu, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(964, 38);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.toolStripSeparator1,
            this.btnEditar,
            this.btnEliminar,
            this.btnImprimir,
            this.btnExportar});
            this.menu.Location = new System.Drawing.Point(3, 3);
            this.menu.Margin = new System.Windows.Forms.Padding(3);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(0);
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menu.Size = new System.Drawing.Size(438, 29);
            this.menu.TabIndex = 5;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::SistemaGEISA.Properties.Resources.document_new1;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(68, 26);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = global::SistemaGEISA.Properties.Resources.Editar;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(63, 26);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
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
            // btnImprimir
            // 
            this.btnImprimir.Image = global::SistemaGEISA.Properties.Resources.Imprimir;
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(79, 26);
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Image = global::SistemaGEISA.Properties.Resources.Reportes;
            this.btnExportar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(144, 26);
            this.btnExportar.Text = "Exportar Informacion";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // frmOrdenes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 261);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOrdenes";
            this.Text = "Ordenes Compra/Salidas Almacen";
            this.Load += new System.EventHandler(this.frmOrdenes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivo)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkActivo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colFechaCancelacion;
        private DevExpress.XtraGrid.Columns.GridColumn colFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colFolioCompleto;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresa;
        private DevExpress.XtraGrid.Columns.GridColumn colProveedor;
        private DevExpress.XtraGrid.Columns.GridColumn colSolicitadoPor;
        private DevExpress.XtraGrid.Columns.GridColumn colComprador;
        private DevExpress.XtraGrid.Columns.GridColumn colTipoMovimiento;
        private DevExpress.XtraGrid.Columns.GridColumn colObra;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private System.Windows.Forms.ToolStripButton btnExportar;
        private DevExpress.XtraGrid.Columns.GridColumn colEstadoOrden;
        private System.Windows.Forms.ToolStripButton btnImprimir;
    }
}