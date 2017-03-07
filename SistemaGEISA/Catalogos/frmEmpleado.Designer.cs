namespace SistemaGEISA
{
    partial class frmEmpleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpleado));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.btnExportar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnActivo = new System.Windows.Forms.ToolStripButton();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApPaterno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colApMaterno = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkActivo = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colResidente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkResidente = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colUsuario = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkUsuario = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colObra = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkObra = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colOficina = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ckOficina = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colCtaClabe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContratista = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colContratistaPrincipal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ckContratista = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.ckContratistaPrincipal = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.tableLayoutPanel1.SuspendLayout();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkResidente)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUsuario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkObra)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckOficina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckContratista)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckContratistaPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.menu, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(792, 39);
            this.tableLayoutPanel1.TabIndex = 10;
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
            this.btnImprimir,
            this.btnExportar,
            this.btnEliminar,
            this.toolStripSeparator2,
            this.btnActivo});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(3);
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menu.Size = new System.Drawing.Size(517, 35);
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
            // btnEliminar
            // 
            this.btnEliminar.Image = global::SistemaGEISA.Properties.Resources.Eliminar;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(76, 26);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 29);
            // 
            // btnActivo
            // 
            this.btnActivo.Image = global::SistemaGEISA.Properties.Resources.Activo;
            this.btnActivo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActivo.Name = "btnActivo";
            this.btnActivo.Size = new System.Drawing.Size(67, 26);
            this.btnActivo.Text = "Activo";
            this.btnActivo.Click += new System.EventHandler(this.btnActivo_Click);
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
            this.grid.Location = new System.Drawing.Point(0, 39);
            this.grid.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.grid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grid.MainView = this.gv;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkActivo,
            this.chkResidente,
            this.chkUsuario,
            this.chkObra,
            this.ckOficina,
            this.ckContratista,
            this.ckContratistaPrincipal});
            this.grid.Size = new System.Drawing.Size(792, 222);
            this.grid.TabIndex = 11;
            this.grid.UseEmbeddedNavigator = true;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNombre,
            this.colApPaterno,
            this.colApMaterno,
            this.colActivo,
            this.colResidente,
            this.colUsuario,
            this.colObra,
            this.colOficina,
            this.colCtaClabe,
            this.colContratista,
            this.colContratistaPrincipal});
            this.gv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gv.GridControl = this.grid;
            this.gv.Name = "gv";
            this.gv.OptionsBehavior.Editable = false;
            this.gv.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv.OptionsView.EnableAppearanceEvenRow = true;
            this.gv.OptionsView.EnableAppearanceOddRow = true;
            this.gv.OptionsView.ShowAutoFilterRow = true;
            this.gv.OptionsView.ShowGroupPanel = false;
            this.gv.PaintStyleName = "Skin";
            this.gv.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gv_FocusedRowChanged);
            this.gv.DoubleClick += new System.EventHandler(this.gv_DoubleClick);
            // 
            // colNombre
            // 
            this.colNombre.Caption = "Nombre";
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 0;
            this.colNombre.Width = 105;
            // 
            // colApPaterno
            // 
            this.colApPaterno.Caption = "Apellido Paterno";
            this.colApPaterno.FieldName = "ApPaterno";
            this.colApPaterno.Name = "colApPaterno";
            this.colApPaterno.Visible = true;
            this.colApPaterno.VisibleIndex = 1;
            this.colApPaterno.Width = 105;
            // 
            // colApMaterno
            // 
            this.colApMaterno.Caption = "Apellido Materno";
            this.colApMaterno.FieldName = "ApMaterno";
            this.colApMaterno.Name = "colApMaterno";
            this.colApMaterno.Visible = true;
            this.colApMaterno.VisibleIndex = 2;
            this.colApMaterno.Width = 128;
            // 
            // colActivo
            // 
            this.colActivo.ColumnEdit = this.chkActivo;
            this.colActivo.FieldName = "Activo";
            this.colActivo.Name = "colActivo";
            this.colActivo.OptionsColumn.FixedWidth = true;
            this.colActivo.Visible = true;
            this.colActivo.VisibleIndex = 4;
            this.colActivo.Width = 50;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoHeight = false;
            this.chkActivo.Caption = "Check";
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colResidente
            // 
            this.colResidente.Caption = "Residente";
            this.colResidente.ColumnEdit = this.chkResidente;
            this.colResidente.FieldName = "EsResidente";
            this.colResidente.Name = "colResidente";
            this.colResidente.OptionsColumn.FixedWidth = true;
            this.colResidente.Visible = true;
            this.colResidente.VisibleIndex = 5;
            this.colResidente.Width = 60;
            // 
            // chkResidente
            // 
            this.chkResidente.AutoHeight = false;
            this.chkResidente.Caption = "Check";
            this.chkResidente.Name = "chkResidente";
            this.chkResidente.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colUsuario
            // 
            this.colUsuario.Caption = "Usuario";
            this.colUsuario.ColumnEdit = this.chkUsuario;
            this.colUsuario.FieldName = "EsUsuario";
            this.colUsuario.Name = "colUsuario";
            this.colUsuario.OptionsColumn.FixedWidth = true;
            this.colUsuario.Visible = true;
            this.colUsuario.VisibleIndex = 6;
            this.colUsuario.Width = 60;
            // 
            // chkUsuario
            // 
            this.chkUsuario.AutoHeight = false;
            this.chkUsuario.Caption = "Check";
            this.chkUsuario.Name = "chkUsuario";
            this.chkUsuario.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colObra
            // 
            this.colObra.Caption = "Obra";
            this.colObra.ColumnEdit = this.chkObra;
            this.colObra.FieldName = "EsObra";
            this.colObra.Name = "colObra";
            this.colObra.OptionsColumn.FixedWidth = true;
            this.colObra.Visible = true;
            this.colObra.VisibleIndex = 7;
            this.colObra.Width = 60;
            // 
            // chkObra
            // 
            this.chkObra.AutoHeight = false;
            this.chkObra.Caption = "Check";
            this.chkObra.Name = "chkObra";
            this.chkObra.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colOficina
            // 
            this.colOficina.Caption = "Oficina";
            this.colOficina.ColumnEdit = this.ckOficina;
            this.colOficina.FieldName = "EsOficina";
            this.colOficina.Name = "colOficina";
            this.colOficina.OptionsColumn.FixedWidth = true;
            this.colOficina.Visible = true;
            this.colOficina.VisibleIndex = 8;
            // 
            // ckOficina
            // 
            this.ckOficina.AutoHeight = false;
            this.ckOficina.Caption = "Check";
            this.ckOficina.Name = "ckOficina";
            this.ckOficina.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // colCtaClabe
            // 
            this.colCtaClabe.Caption = "Cuenta/Clabe";
            this.colCtaClabe.FieldName = "CuentaClabe";
            this.colCtaClabe.Name = "colCtaClabe";
            this.colCtaClabe.OptionsColumn.FixedWidth = true;
            this.colCtaClabe.Visible = true;
            this.colCtaClabe.VisibleIndex = 3;
            this.colCtaClabe.Width = 91;
            // 
            // colContratista
            // 
            this.colContratista.Caption = "Contratista";
            this.colContratista.ColumnEdit = this.ckContratista;
            this.colContratista.FieldName = "EsContratista";
            this.colContratista.Name = "colContratista";
            this.colContratista.OptionsColumn.FixedWidth = true;
            this.colContratista.Visible = true;
            this.colContratista.VisibleIndex = 9;
            // 
            // colContratistaPrincipal
            // 
            this.colContratistaPrincipal.Caption = "Contr. Princ.";
            this.colContratistaPrincipal.ColumnEdit = this.ckContratistaPrincipal;
            this.colContratistaPrincipal.FieldName = "EsContratistaPrincipal";
            this.colContratistaPrincipal.Name = "colContratistaPrincipal";
            this.colContratistaPrincipal.OptionsColumn.FixedWidth = true;
            this.colContratistaPrincipal.Visible = true;
            this.colContratistaPrincipal.VisibleIndex = 10;
            // 
            // ckContratista
            // 
            this.ckContratista.AutoHeight = false;
            this.ckContratista.Caption = "Check";
            this.ckContratista.Name = "ckContratista";
            this.ckContratista.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // ckContratistaPrincipal
            // 
            this.ckContratistaPrincipal.AutoHeight = false;
            this.ckContratistaPrincipal.Caption = "Check";
            this.ckContratistaPrincipal.Name = "ckContratistaPrincipal";
            this.ckContratistaPrincipal.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            // 
            // frmEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 261);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEmpleado";
            this.Text = "Empleado";
            this.Load += new System.EventHandler(this.frmEmpleado_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkResidente)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUsuario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkObra)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckOficina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckContratista)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckContratistaPrincipal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnActivo;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkActivo;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colApPaterno;
        private DevExpress.XtraGrid.Columns.GridColumn colApMaterno;
        private DevExpress.XtraGrid.Columns.GridColumn colActivo;
        private DevExpress.XtraGrid.Columns.GridColumn colResidente;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkResidente;
        private DevExpress.XtraGrid.Columns.GridColumn colUsuario;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkUsuario;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnExportar;
        private DevExpress.XtraGrid.Columns.GridColumn colObra;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkObra;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private DevExpress.XtraGrid.Columns.GridColumn colOficina;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ckOficina;
        private DevExpress.XtraGrid.Columns.GridColumn colCtaClabe;
        private System.Windows.Forms.ToolStripButton btnImprimir;
        private DevExpress.XtraGrid.Columns.GridColumn colContratista;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ckContratista;
        private DevExpress.XtraGrid.Columns.GridColumn colContratistaPrincipal;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ckContratistaPrincipal;
    }
}