namespace SistemaGEISA
{
    partial class frmObrasNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmObrasNew));
            this.menu = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnInfo = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.luEstado = new DevExpress.XtraEditors.LookUpEdit();
            this.luEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.luCliente = new DevExpress.XtraEditors.LookUpEdit();
            this.btnEstado = new System.Windows.Forms.Button();
            this.btnCiudad = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.luCiudad = new DevExpress.XtraEditors.LookUpEdit();
            this.dtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtFechaIni = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNombre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.chkActivo = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.luObraComprobante = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.luTipoComprobante = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.luProveedor = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.btnDetalle = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.dtFecha = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luEstado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luCliente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luCiudad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luObraComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luTipoComprobante)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProveedor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.btnInfo});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(3);
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menu.Size = new System.Drawing.Size(720, 35);
            this.menu.TabIndex = 6;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::SistemaGEISA.Properties.Resources.document_save;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 26);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(23, 26);
            this.btnInfo.Text = "Ver Log";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtNombre, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.luEstado, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.luEmpresa, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.luCliente, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnEstado, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnCiudad, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.luCiudad, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dtFechaFin, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.dtFechaIni, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.grid, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(720, 152);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(364, 120);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Cliente";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 120);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Empresa";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNombre.Location = new System.Drawing.Point(73, 3);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(285, 21);
            this.txtNombre.TabIndex = 0;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // luEstado
            // 
            this.luEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luEstado.Location = new System.Drawing.Point(73, 62);
            this.luEstado.Name = "luEstado";
            this.luEstado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luEstado.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.luEstado.Properties.NullText = "";
            this.luEstado.Size = new System.Drawing.Size(285, 20);
            this.luEstado.TabIndex = 3;
            this.luEstado.EditValueChanged += new System.EventHandler(this.luEstado_EditValueChanged);
            // 
            // luEmpresa
            // 
            this.luEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luEmpresa.Location = new System.Drawing.Point(73, 120);
            this.luEmpresa.Name = "luEmpresa";
            this.luEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luEmpresa.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreComercial", "Nombre")});
            this.luEmpresa.Properties.NullText = "";
            this.luEmpresa.Size = new System.Drawing.Size(285, 20);
            this.luEmpresa.TabIndex = 5;
            // 
            // luCliente
            // 
            this.luCliente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luCliente.Location = new System.Drawing.Point(423, 120);
            this.luCliente.Name = "luCliente";
            this.luCliente.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luCliente.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreComercial", "Nombre")});
            this.luCliente.Properties.NullText = "";
            this.luCliente.Size = new System.Drawing.Size(294, 20);
            this.luCliente.TabIndex = 6;
            // 
            // btnEstado
            // 
            this.btnEstado.BackColor = System.Drawing.Color.Transparent;
            this.btnEstado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnEstado.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnEstado.FlatAppearance.BorderSize = 0;
            this.btnEstado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnEstado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstado.ForeColor = System.Drawing.Color.Transparent;
            this.btnEstado.Image = global::SistemaGEISA.Properties.Resources.agregar;
            this.btnEstado.Location = new System.Drawing.Point(362, 28);
            this.btnEstado.Margin = new System.Windows.Forms.Padding(1);
            this.btnEstado.Name = "btnEstado";
            this.btnEstado.Size = new System.Drawing.Size(30, 30);
            this.btnEstado.TabIndex = 21;
            this.btnEstado.UseVisualStyleBackColor = true;
            this.btnEstado.Click += new System.EventHandler(this.btnEstado_Click);
            // 
            // btnCiudad
            // 
            this.btnCiudad.BackColor = System.Drawing.Color.Transparent;
            this.btnCiudad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCiudad.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCiudad.FlatAppearance.BorderSize = 0;
            this.btnCiudad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCiudad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCiudad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCiudad.ForeColor = System.Drawing.Color.Transparent;
            this.btnCiudad.Image = global::SistemaGEISA.Properties.Resources.agregar;
            this.btnCiudad.Location = new System.Drawing.Point(362, 60);
            this.btnCiudad.Margin = new System.Windows.Forms.Padding(1);
            this.btnCiudad.Name = "btnCiudad";
            this.btnCiudad.Size = new System.Drawing.Size(30, 29);
            this.btnCiudad.TabIndex = 22;
            this.btnCiudad.UseVisualStyleBackColor = true;
            this.btnCiudad.Click += new System.EventHandler(this.btnCiudad_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 93);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Fecha Inicio";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 26);
            this.label5.TabIndex = 10;
            this.label5.Text = "Ciudad";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // luCiudad
            // 
            this.luCiudad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luCiudad.Location = new System.Drawing.Point(73, 30);
            this.luCiudad.Name = "luCiudad";
            this.luCiudad.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luCiudad.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.luCiudad.Properties.NullText = "";
            this.luCiudad.Size = new System.Drawing.Size(285, 20);
            this.luCiudad.TabIndex = 4;
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtFechaFin.Location = new System.Drawing.Point(73, 93);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(285, 21);
            this.dtFechaFin.TabIndex = 2;
            // 
            // dtFechaIni
            // 
            this.dtFechaIni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtFechaIni.Location = new System.Drawing.Point(423, 93);
            this.dtFechaIni.Name = "dtFechaIni";
            this.dtFechaIni.Size = new System.Drawing.Size(294, 21);
            this.dtFechaIni.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(364, 93);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Fecha Fin";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.grid.Location = new System.Drawing.Point(423, 3);
            this.grid.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.grid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grid.MainView = this.gv;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.chkActivo,
            this.luObraComprobante,
            this.luTipoComprobante,
            this.luProveedor,
            this.btnDetalle,
            this.dtFecha});
            this.tableLayoutPanel1.SetRowSpan(this.grid, 3);
            this.grid.Size = new System.Drawing.Size(294, 84);
            this.grid.TabIndex = 54;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colNombre});
            this.gv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gv.GridControl = this.grid;
            this.gv.Name = "gv";
            this.gv.OptionsBehavior.Editable = false;
            this.gv.OptionsBehavior.ReadOnly = true;
            this.gv.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv.OptionsView.EnableAppearanceEvenRow = true;
            this.gv.OptionsView.EnableAppearanceOddRow = true;
            this.gv.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
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
            // colNombre
            // 
            this.colNombre.Caption = "Nombre";
            this.colNombre.FieldName = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.Visible = true;
            this.colNombre.VisibleIndex = 0;
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
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreFiscal", "Nombre Fiscal")});
            this.luProveedor.Name = "luProveedor";
            this.luProveedor.NullText = "";
            // 
            // btnDetalle
            // 
            this.btnDetalle.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // dtFecha
            // 
            this.dtFecha.AutoHeight = false;
            this.dtFecha.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFecha.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.NullDate = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 151);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Estado";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(364, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 27);
            this.label8.TabIndex = 55;
            this.label8.Text = "<=>";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmObrasNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 187);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmObrasNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Obras : Nuevo";
            this.Load += new System.EventHandler(this.frmEmpresaNew_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luEstado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luCliente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luCiudad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkActivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luObraComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luTipoComprobante)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProveedor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFecha)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.DateTimePicker dtFechaIni;
        private System.Windows.Forms.DateTimePicker dtFechaFin;
        private DevExpress.XtraEditors.LookUpEdit luEstado;
        private DevExpress.XtraEditors.LookUpEdit luCiudad;
        private DevExpress.XtraEditors.LookUpEdit luEmpresa;
        private DevExpress.XtraEditors.LookUpEdit luCliente;
        private System.Windows.Forms.Button btnEstado;
        private System.Windows.Forms.Button btnCiudad;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit chkActivo;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luObraComprobante;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luTipoComprobante;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit luProveedor;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnDetalle;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dtFecha;
        private DevExpress.XtraGrid.Columns.GridColumn colNombre;
        private System.Windows.Forms.Label label8;
    }
}