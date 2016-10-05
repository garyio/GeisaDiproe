namespace SistemaGEISA
{
    partial class frmArticulosNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArticulosNew));
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.luEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.luProveedor = new DevExpress.XtraEditors.LookUpEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.luSubcategoria = new DevExpress.XtraEditors.LookUpEdit();
            this.spinExistecia = new DevExpress.XtraEditors.SpinEdit();
            this.luUniad = new DevExpress.XtraEditors.LookUpEdit();
            this.txtPrecioCompra = new System.Windows.Forms.TextBox();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.txtUtilidad = new System.Windows.Forms.TextBox();
            this.rgEstado = new DevExpress.XtraEditors.RadioGroup();
            this.btnAgregarUnidad = new System.Windows.Forms.Button();
            this.btnAgregarSubcategoria = new System.Windows.Forms.Button();
            this.menu = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnGuardarNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnInfo = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProveedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luSubcategoria.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinExistecia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luUniad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgEstado.Properties)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.menu, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(712, 310);
            this.tableLayoutPanel2.TabIndex = 10;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.luEmpresa, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.luProveedor, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label8, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label11, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtCodigo, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDescripcion, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.luSubcategoria, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.spinExistecia, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.luUniad, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtPrecioCompra, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtPrecioVenta, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtUtilidad, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.rgEstado, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnAgregarUnidad, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnAgregarSubcategoria, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.tableLayoutPanel1.RowCount = 9;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(706, 269);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Empresa";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(368, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 26);
            this.label6.TabIndex = 5;
            this.label6.Text = "Proveedor";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // luEmpresa
            // 
            this.luEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luEmpresa.Location = new System.Drawing.Point(85, 8);
            this.luEmpresa.Name = "luEmpresa";
            this.luEmpresa.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.luEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luEmpresa.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreComercial", "Nombre")});
            this.luEmpresa.Properties.NullText = "";
            this.luEmpresa.Size = new System.Drawing.Size(245, 20);
            this.luEmpresa.TabIndex = 6;
            // 
            // luProveedor
            // 
            this.luProveedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luProveedor.Location = new System.Drawing.Point(441, 8);
            this.luProveedor.Name = "luProveedor";
            this.luProveedor.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.luProveedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luProveedor.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreComercial", "Nombre")});
            this.luProveedor.Properties.NullText = "";
            this.luProveedor.Size = new System.Drawing.Size(246, 20);
            this.luProveedor.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripción";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Subcategoria";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 30);
            this.label4.TabIndex = 3;
            this.label4.Text = "Unidad";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 27);
            this.label7.TabIndex = 8;
            this.label7.Text = "Precio Compra";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(368, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 27);
            this.label8.TabIndex = 9;
            this.label8.Text = "Precio Venta";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 225);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 44);
            this.label10.TabIndex = 11;
            this.label10.Text = "Estado";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 199);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 26);
            this.label9.TabIndex = 10;
            this.label9.Text = "Existencia";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(368, 172);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 27);
            this.label11.TabIndex = 12;
            this.label11.Text = "Utilidad";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(85, 34);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 21);
            this.txtCodigo.TabIndex = 13;
            // 
            // txtDescripcion
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtDescripcion, 4);
            this.txtDescripcion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDescripcion.Location = new System.Drawing.Point(85, 61);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(602, 21);
            this.txtDescripcion.TabIndex = 14;
            // 
            // luSubcategoria
            // 
            this.luSubcategoria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.luSubcategoria.Location = new System.Drawing.Point(85, 88);
            this.luSubcategoria.Name = "luSubcategoria";
            this.luSubcategoria.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.luSubcategoria.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luSubcategoria.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.luSubcategoria.Properties.NullText = "";
            this.luSubcategoria.Size = new System.Drawing.Size(245, 20);
            this.luSubcategoria.TabIndex = 15;
            // 
            // spinExistecia
            // 
            this.spinExistecia.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinExistecia.Location = new System.Drawing.Point(85, 202);
            this.spinExistecia.Name = "spinExistecia";
            this.spinExistecia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinExistecia.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinExistecia.Properties.IsFloatValue = false;
            this.spinExistecia.Properties.Mask.EditMask = "\\d+";
            this.spinExistecia.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.spinExistecia.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.spinExistecia.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinExistecia.Size = new System.Drawing.Size(100, 20);
            this.spinExistecia.TabIndex = 16;
            // 
            // luUniad
            // 
            this.luUniad.Location = new System.Drawing.Point(85, 118);
            this.luUniad.Name = "luUniad";
            this.luUniad.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.luUniad.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luUniad.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.luUniad.Properties.NullText = "";
            this.luUniad.Size = new System.Drawing.Size(100, 20);
            this.luUniad.TabIndex = 17;
            // 
            // txtPrecioCompra
            // 
            this.txtPrecioCompra.Location = new System.Drawing.Point(85, 148);
            this.txtPrecioCompra.Name = "txtPrecioCompra";
            this.txtPrecioCompra.Size = new System.Drawing.Size(100, 21);
            this.txtPrecioCompra.TabIndex = 18;
            this.txtPrecioCompra.TextChanged += new System.EventHandler(this.txtPrecioCompra_TextChanged);
            this.txtPrecioCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioCompra_KeyPress);
            this.txtPrecioCompra.Leave += new System.EventHandler(this.txtPrecioCompra_Leave);
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Location = new System.Drawing.Point(441, 148);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(100, 21);
            this.txtPrecioVenta.TabIndex = 19;
            this.txtPrecioVenta.TextChanged += new System.EventHandler(this.txtPrecioCompra_TextChanged);
            this.txtPrecioVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioVenta_KeyPress);
            this.txtPrecioVenta.Leave += new System.EventHandler(this.txtPrecioVenta_Leave);
            // 
            // txtUtilidad
            // 
            this.txtUtilidad.Location = new System.Drawing.Point(441, 175);
            this.txtUtilidad.Name = "txtUtilidad";
            this.txtUtilidad.ReadOnly = true;
            this.txtUtilidad.Size = new System.Drawing.Size(100, 21);
            this.txtUtilidad.TabIndex = 20;
            // 
            // rgEstado
            // 
            this.rgEstado.Location = new System.Drawing.Point(85, 228);
            this.rgEstado.Name = "rgEstado";
            this.rgEstado.Properties.Columns = 2;
            this.rgEstado.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(true, "Activo"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Inactivo")});
            this.rgEstado.Size = new System.Drawing.Size(245, 33);
            this.rgEstado.TabIndex = 35;
            // 
            // btnAgregarUnidad
            // 
            this.btnAgregarUnidad.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarUnidad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAgregarUnidad.FlatAppearance.BorderSize = 0;
            this.btnAgregarUnidad.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAgregarUnidad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAgregarUnidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarUnidad.ForeColor = System.Drawing.Color.Transparent;
            this.btnAgregarUnidad.Image = global::SistemaGEISA.Properties.Resources.agregar;
            this.btnAgregarUnidad.Location = new System.Drawing.Point(334, 116);
            this.btnAgregarUnidad.Margin = new System.Windows.Forms.Padding(1);
            this.btnAgregarUnidad.Name = "btnAgregarUnidad";
            this.btnAgregarUnidad.Size = new System.Drawing.Size(28, 28);
            this.btnAgregarUnidad.TabIndex = 36;
            this.btnAgregarUnidad.UseVisualStyleBackColor = true;
            this.btnAgregarUnidad.Click += new System.EventHandler(this.btnAgregarUnidad_Click);
            // 
            // btnAgregarSubcategoria
            // 
            this.btnAgregarSubcategoria.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarSubcategoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAgregarSubcategoria.FlatAppearance.BorderSize = 0;
            this.btnAgregarSubcategoria.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnAgregarSubcategoria.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnAgregarSubcategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarSubcategoria.ForeColor = System.Drawing.Color.Transparent;
            this.btnAgregarSubcategoria.Image = global::SistemaGEISA.Properties.Resources.agregar;
            this.btnAgregarSubcategoria.Location = new System.Drawing.Point(334, 86);
            this.btnAgregarSubcategoria.Margin = new System.Windows.Forms.Padding(1);
            this.btnAgregarSubcategoria.Name = "btnAgregarSubcategoria";
            this.btnAgregarSubcategoria.Size = new System.Drawing.Size(30, 28);
            this.btnAgregarSubcategoria.TabIndex = 37;
            this.btnAgregarSubcategoria.UseVisualStyleBackColor = true;
            this.btnAgregarSubcategoria.Click += new System.EventHandler(this.btnAgregarSubcategoria_Click);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.Dock = System.Windows.Forms.DockStyle.None;
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.btnGuardarNuevo,
            this.btnInfo});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(3);
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menu.Size = new System.Drawing.Size(228, 35);
            this.menu.TabIndex = 8;
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
            // btnGuardarNuevo
            // 
            this.btnGuardarNuevo.Image = global::SistemaGEISA.Properties.Resources.GuardarNuevo;
            this.btnGuardarNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardarNuevo.Name = "btnGuardarNuevo";
            this.btnGuardarNuevo.Size = new System.Drawing.Size(122, 26);
            this.btnGuardarNuevo.Text = "Guardar y Nuevo";
            this.btnGuardarNuevo.Click += new System.EventHandler(this.btnGuardarNuevo_Click);
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
            // frmArticulosNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 310);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmArticulosNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Articulos";
            this.Load += new System.EventHandler(this.frmArticulosNew_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProveedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luSubcategoria.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinExistecia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luUniad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgEstado.Properties)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.LookUpEdit luEmpresa;
        private DevExpress.XtraEditors.LookUpEdit luProveedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private DevExpress.XtraEditors.LookUpEdit luSubcategoria;
        private DevExpress.XtraEditors.SpinEdit spinExistecia;
        private DevExpress.XtraEditors.LookUpEdit luUniad;
        private System.Windows.Forms.TextBox txtPrecioCompra;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.TextBox txtUtilidad;
        private DevExpress.XtraEditors.RadioGroup rgEstado;
        private System.Windows.Forms.Button btnAgregarUnidad;
        private System.Windows.Forms.Button btnAgregarSubcategoria;
        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnInfo;
        private System.Windows.Forms.ToolStripButton btnGuardarNuevo;
    }
}