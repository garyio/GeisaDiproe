namespace SistemaGEISA
{
    partial class frmPerfiles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPerfiles));
            this.menu = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnActivo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.tlpPermisos = new System.Windows.Forms.TableLayoutPanel();
            this.groupOperaciones = new DevExpress.XtraEditors.GroupControl();
            this.tvOperaciones = new System.Windows.Forms.TreeView();
            this.groupCatalogos = new DevExpress.XtraEditors.GroupControl();
            this.tvCatalogos = new System.Windows.Forms.TreeView();
            this.groupAdministracion = new DevExpress.XtraEditors.GroupControl();
            this.tvAdministracion = new System.Windows.Forms.TreeView();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colActivo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.menu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tlpPermisos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupOperaciones)).BeginInit();
            this.groupOperaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupCatalogos)).BeginInit();
            this.groupCatalogos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupAdministracion)).BeginInit();
            this.groupAdministracion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.toolStripSeparator1,
            this.btnGuardar,
            this.toolStripSeparator2,
            this.btnEditar,
            this.toolStripSeparator3,
            this.btnActivo,
            this.toolStripSeparator4,
            this.btnEliminar,
            this.toolStripSeparator5,
            this.btnCancelar});
            this.menu.Location = new System.Drawing.Point(5, 5);
            this.menu.Name = "menu";
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menu.Size = new System.Drawing.Size(674, 31);
            this.menu.TabIndex = 0;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::SistemaGEISA.Properties.Resources.document_new1;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(70, 28);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::SistemaGEISA.Properties.Resources.document_save;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(77, 28);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = global::SistemaGEISA.Properties.Resources.Editar1;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(65, 28);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 31);
            // 
            // btnActivo
            // 
            this.btnActivo.Image = global::SistemaGEISA.Properties.Resources.Activo;
            this.btnActivo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActivo.Name = "btnActivo";
            this.btnActivo.Size = new System.Drawing.Size(69, 28);
            this.btnActivo.Text = "Activo";
            this.btnActivo.Click += new System.EventHandler(this.btnActivo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::SistemaGEISA.Properties.Resources.delete;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(78, 28);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 31);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::SistemaGEISA.Properties.Resources.cancel1;
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(81, 28);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtNombre, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDescripcion, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tlpPermisos, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.grid, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 36);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(674, 320);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNombre.Location = new System.Drawing.Point(70, 3);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(333, 21);
            this.txtNombre.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 30);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripción";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableLayoutPanel1.SetColumnSpan(this.txtDescripcion, 2);
            this.txtDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescripcion.Location = new System.Drawing.Point(70, 30);
            this.txtDescripcion.MaxLength = 200;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(601, 21);
            this.txtDescripcion.TabIndex = 3;
            // 
            // tlpPermisos
            // 
            this.tlpPermisos.ColumnCount = 4;
            this.tlpPermisos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpPermisos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpPermisos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpPermisos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpPermisos.Controls.Add(this.groupOperaciones, 2, 0);
            this.tlpPermisos.Controls.Add(this.groupCatalogos, 1, 0);
            this.tlpPermisos.Controls.Add(this.groupAdministracion, 0, 0);
            this.tlpPermisos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPermisos.Location = new System.Drawing.Point(409, 57);
            this.tlpPermisos.Name = "tlpPermisos";
            this.tlpPermisos.RowCount = 1;
            this.tlpPermisos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPermisos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 262F));
            this.tlpPermisos.Size = new System.Drawing.Size(262, 260);
            this.tlpPermisos.TabIndex = 5;
            // 
            // groupOperaciones
            // 
            this.groupOperaciones.CaptionImage = global::SistemaGEISA.Properties.Resources.Movimientos;
            this.groupOperaciones.Controls.Add(this.tvOperaciones);
            this.groupOperaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupOperaciones.Location = new System.Drawing.Point(133, 3);
            this.groupOperaciones.LookAndFeel.SkinName = "Whiteprint";
            this.groupOperaciones.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupOperaciones.Name = "groupOperaciones";
            this.groupOperaciones.Size = new System.Drawing.Size(59, 254);
            this.groupOperaciones.TabIndex = 2;
            this.groupOperaciones.Text = "Operaciones";
            // 
            // tvOperaciones
            // 
            this.tvOperaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvOperaciones.CheckBoxes = true;
            this.tvOperaciones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvOperaciones.Location = new System.Drawing.Point(2, 40);
            this.tvOperaciones.Name = "tvOperaciones";
            this.tvOperaciones.Size = new System.Drawing.Size(55, 212);
            this.tvOperaciones.TabIndex = 1;
            // 
            // groupCatalogos
            // 
            this.groupCatalogos.CaptionImage = global::SistemaGEISA.Properties.Resources.books;
            this.groupCatalogos.Controls.Add(this.tvCatalogos);
            this.groupCatalogos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupCatalogos.Location = new System.Drawing.Point(68, 3);
            this.groupCatalogos.LookAndFeel.SkinName = "Whiteprint";
            this.groupCatalogos.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupCatalogos.Name = "groupCatalogos";
            this.groupCatalogos.Size = new System.Drawing.Size(59, 254);
            this.groupCatalogos.TabIndex = 1;
            this.groupCatalogos.Text = "Catálogos";
            // 
            // tvCatalogos
            // 
            this.tvCatalogos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvCatalogos.CheckBoxes = true;
            this.tvCatalogos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvCatalogos.Location = new System.Drawing.Point(2, 40);
            this.tvCatalogos.Name = "tvCatalogos";
            this.tvCatalogos.Size = new System.Drawing.Size(55, 212);
            this.tvCatalogos.TabIndex = 1;
            // 
            // groupAdministracion
            // 
            this.groupAdministracion.CaptionImage = global::SistemaGEISA.Properties.Resources.settings;
            this.groupAdministracion.Controls.Add(this.tvAdministracion);
            this.groupAdministracion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupAdministracion.Location = new System.Drawing.Point(3, 3);
            this.groupAdministracion.LookAndFeel.SkinName = "Whiteprint";
            this.groupAdministracion.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupAdministracion.Name = "groupAdministracion";
            this.groupAdministracion.Size = new System.Drawing.Size(59, 254);
            this.groupAdministracion.TabIndex = 0;
            this.groupAdministracion.Text = "Administración";
            // 
            // tvAdministracion
            // 
            this.tvAdministracion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvAdministracion.CheckBoxes = true;
            this.tvAdministracion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvAdministracion.Location = new System.Drawing.Point(2, 40);
            this.tvAdministracion.Name = "tvAdministracion";
            this.tvAdministracion.Size = new System.Drawing.Size(55, 212);
            this.tvAdministracion.TabIndex = 1;
            // 
            // grid
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grid, 2);
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(3, 57);
            this.grid.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.grid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grid.MainView = this.gv;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grid.Size = new System.Drawing.Size(400, 260);
            this.grid.TabIndex = 0;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNombre,
            this.colDescripcion,
            this.colActivo});
            this.gv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gv.GridControl = this.grid;
            this.gv.Name = "gv";
            this.gv.OptionsBehavior.Editable = false;
            this.gv.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gv_FocusedRowChanged);
            // 
            // colNombre
            // 
            this.colNombre.Caption = "Nombre";
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 0;
            // 
            // colDescripcion
            // 
            this.colDescripcion.Caption = "Descripción";
            this.colDescripcion.FieldName = "Descripcion";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.Visible = true;
            this.colDescripcion.VisibleIndex = 1;
            // 
            // colActivo
            // 
            this.colActivo.Caption = "Activo";
            this.colActivo.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colActivo.FieldName = "Activo";
            this.colActivo.Name = "colActivo";
            this.colActivo.OptionsColumn.FixedWidth = true;
            this.colActivo.OptionsColumn.ShowCaption = false;
            this.colActivo.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
            this.colActivo.Visible = true;
            this.colActivo.VisibleIndex = 2;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Caption = "Check";
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // frmPerfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPerfiles";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Perfiles";
            this.Load += new System.EventHandler(this.frmPerfiles_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tlpPermisos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupOperaciones)).EndInit();
            this.groupOperaciones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupCatalogos)).EndInit();
            this.groupCatalogos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupAdministracion)).EndInit();
            this.groupAdministracion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnEditar;
        private System.Windows.Forms.ToolStripButton btnEliminar;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnActivo;
        private System.Windows.Forms.ToolStripButton btnCancelar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TableLayoutPanel tlpPermisos;
        private DevExpress.XtraEditors.GroupControl groupOperaciones;
        private System.Windows.Forms.TreeView tvOperaciones;
        private DevExpress.XtraEditors.GroupControl groupCatalogos;
        private System.Windows.Forms.TreeView tvCatalogos;
        private DevExpress.XtraEditors.GroupControl groupAdministracion;
        private System.Windows.Forms.TreeView tvAdministracion;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private DevExpress.XtraGrid.Columns.GridColumn colDescripcion;
        private DevExpress.XtraGrid.Columns.GridColumn colActivo;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;

    }
}