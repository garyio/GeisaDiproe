namespace SistemaGEISA
{
    partial class frmVehiculosNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVehiculosNew));
            this.menu = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnInfo = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lookupEmpresa = new DevExpress.XtraEditors.LookUpEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.deFecha = new DevExpress.XtraEditors.DateEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.txtPlacas = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSubMarca = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.spinModelo = new DevExpress.XtraEditors.SpinEdit();
            this.lookupTipo = new DevExpress.XtraEditors.LookUpEdit();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.deVigIni = new DevExpress.XtraEditors.DateEdit();
            this.deVigFin = new DevExpress.XtraEditors.DateEdit();
            this.label13 = new System.Windows.Forms.Label();
            this.lookupEmpleado = new DevExpress.XtraEditors.LookUpEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.txtCompañia = new System.Windows.Forms.TextBox();
            this.txtPoliza = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lookupTransmision = new DevExpress.XtraEditors.LookUpEdit();
            this.label15 = new System.Windows.Forms.Label();
            this.spinNeumaticos = new DevExpress.XtraEditors.SpinEdit();
            this.spinRefacciones = new DevExpress.XtraEditors.SpinEdit();
            this.label16 = new System.Windows.Forms.Label();
            this.rgEstatus = new DevExpress.XtraEditors.RadioGroup();
            this.label17 = new System.Windows.Forms.Label();
            this.menu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEmpresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinModelo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupTipo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deVigIni.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deVigIni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deVigFin.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deVigFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEmpleado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupTransmision.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinNeumaticos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinRefacciones.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgEstatus.Properties)).BeginInit();
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
            this.menu.Size = new System.Drawing.Size(760, 35);
            this.menu.TabIndex = 10;
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
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tableLayoutPanel1.Controls.Add(this.lookupEmpresa, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.deFecha, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtColor, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtPlacas, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtSubMarca, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtMarca, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.spinModelo, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lookupTipo, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label12, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.deVigIni, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.deVigFin, 4, 7);
            this.tableLayoutPanel1.Controls.Add(this.label13, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.lookupEmpleado, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label10, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtCompañia, 4, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtPoliza, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.label9, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label14, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lookupTransmision, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.label15, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.spinNeumaticos, 4, 5);
            this.tableLayoutPanel1.Controls.Add(this.spinRefacciones, 4, 6);
            this.tableLayoutPanel1.Controls.Add(this.label16, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.rgEstatus, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.label17, 0, 8);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(760, 284);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // lookupEmpresa
            // 
            this.lookupEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lookupEmpresa.Location = new System.Drawing.Point(88, 34);
            this.lookupEmpresa.Name = "lookupEmpresa";
            this.lookupEmpresa.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lookupEmpresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupEmpresa.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreComercial", "Nombre")});
            this.lookupEmpresa.Properties.NullText = "";
            this.lookupEmpresa.Size = new System.Drawing.Size(269, 20);
            this.lookupEmpresa.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(8, 5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 26);
            this.label6.TabIndex = 10;
            this.label6.Text = "Fecha";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // deFecha
            // 
            this.deFecha.EditValue = null;
            this.deFecha.Location = new System.Drawing.Point(88, 8);
            this.deFecha.Name = "deFecha";
            this.deFecha.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deFecha.Size = new System.Drawing.Size(111, 20);
            this.deFecha.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(383, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 26);
            this.label8.TabIndex = 13;
            this.label8.Text = "Tipo Vehiculo";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtColor
            // 
            this.txtColor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtColor.Location = new System.Drawing.Point(88, 141);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(269, 21);
            this.txtColor.TabIndex = 3;
            // 
            // txtPlacas
            // 
            this.txtPlacas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPlacas.Location = new System.Drawing.Point(88, 168);
            this.txtPlacas.Name = "txtPlacas";
            this.txtPlacas.Size = new System.Drawing.Size(269, 21);
            this.txtPlacas.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(8, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 27);
            this.label5.TabIndex = 9;
            this.label5.Text = "Placas";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(8, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 27);
            this.label4.TabIndex = 8;
            this.label4.Text = "Color";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSubMarca
            // 
            this.txtSubMarca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSubMarca.Location = new System.Drawing.Point(88, 87);
            this.txtSubMarca.Name = "txtSubMarca";
            this.txtSubMarca.Size = new System.Drawing.Size(269, 21);
            this.txtSubMarca.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(8, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 27);
            this.label3.TabIndex = 7;
            this.label3.Text = "Modelo";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMarca
            // 
            this.txtMarca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMarca.Location = new System.Drawing.Point(88, 60);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(269, 21);
            this.txtMarca.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(8, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 27);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sub Marca";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(8, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 27);
            this.label1.TabIndex = 5;
            this.label1.Text = "Marca";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(8, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 26);
            this.label7.TabIndex = 12;
            this.label7.Text = "Empresa";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // spinModelo
            // 
            this.spinModelo.EditValue = new decimal(new int[] {
            2015,
            0,
            0,
            0});
            this.spinModelo.Location = new System.Drawing.Point(88, 114);
            this.spinModelo.Name = "spinModelo";
            this.spinModelo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinModelo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.spinModelo.Properties.IsFloatValue = false;
            this.spinModelo.Properties.Mask.EditMask = "\\d+";
            this.spinModelo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.spinModelo.Properties.MaxValue = new decimal(new int[] {
            2999,
            0,
            0,
            0});
            this.spinModelo.Properties.MinValue = new decimal(new int[] {
            1950,
            0,
            0,
            0});
            this.spinModelo.Size = new System.Drawing.Size(100, 20);
            this.spinModelo.TabIndex = 15;
            // 
            // lookupTipo
            // 
            this.lookupTipo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lookupTipo.Location = new System.Drawing.Point(465, 34);
            this.lookupTipo.Name = "lookupTipo";
            this.lookupTipo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupTipo.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Categoria")});
            this.lookupTipo.Properties.NullText = "";
            this.lookupTipo.Size = new System.Drawing.Size(269, 20);
            this.lookupTipo.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(8, 192);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 26);
            this.label11.TabIndex = 21;
            this.label11.Text = "Vig. Pol. Inicio";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(383, 192);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 26);
            this.label12.TabIndex = 22;
            this.label12.Text = "Vig. Pol. Fin";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // deVigIni
            // 
            this.deVigIni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deVigIni.EditValue = null;
            this.deVigIni.Location = new System.Drawing.Point(88, 195);
            this.deVigIni.Name = "deVigIni";
            this.deVigIni.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deVigIni.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deVigIni.Size = new System.Drawing.Size(269, 20);
            this.deVigIni.TabIndex = 23;
            // 
            // deVigFin
            // 
            this.deVigFin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deVigFin.EditValue = null;
            this.deVigFin.Location = new System.Drawing.Point(465, 195);
            this.deVigFin.Name = "deVigFin";
            this.deVigFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deVigFin.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deVigFin.Size = new System.Drawing.Size(269, 20);
            this.deVigFin.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(383, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 26);
            this.label13.TabIndex = 25;
            this.label13.Text = "Conductor";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lookupEmpleado
            // 
            this.lookupEmpleado.Location = new System.Drawing.Point(465, 8);
            this.lookupEmpleado.Name = "lookupEmpleado";
            this.lookupEmpleado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupEmpleado.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NombreCompleto", "Nombre")});
            this.lookupEmpleado.Properties.NullText = "";
            this.lookupEmpleado.Size = new System.Drawing.Size(269, 20);
            this.lookupEmpleado.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(383, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 27);
            this.label10.TabIndex = 19;
            this.label10.Text = "Compañia";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCompañia
            // 
            this.txtCompañia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCompañia.Location = new System.Drawing.Point(465, 114);
            this.txtCompañia.Name = "txtCompañia";
            this.txtCompañia.Size = new System.Drawing.Size(269, 21);
            this.txtCompañia.TabIndex = 20;
            // 
            // txtPoliza
            // 
            this.txtPoliza.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPoliza.Location = new System.Drawing.Point(465, 87);
            this.txtPoliza.Name = "txtPoliza";
            this.txtPoliza.Size = new System.Drawing.Size(269, 21);
            this.txtPoliza.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(383, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 27);
            this.label9.TabIndex = 17;
            this.label9.Text = "Poliza";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Location = new System.Drawing.Point(383, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 27);
            this.label14.TabIndex = 27;
            this.label14.Text = "Transmisión";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lookupTransmision
            // 
            this.lookupTransmision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lookupTransmision.Location = new System.Drawing.Point(465, 60);
            this.lookupTransmision.Name = "lookupTransmision";
            this.lookupTransmision.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupTransmision.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Transmisión")});
            this.lookupTransmision.Properties.NullText = "";
            this.lookupTransmision.Size = new System.Drawing.Size(269, 20);
            this.lookupTransmision.TabIndex = 28;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label15.Location = new System.Drawing.Point(383, 138);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(76, 27);
            this.label15.TabIndex = 29;
            this.label15.Text = "# Neumaticos";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // spinNeumaticos
            // 
            this.spinNeumaticos.EditValue = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.spinNeumaticos.Location = new System.Drawing.Point(465, 141);
            this.spinNeumaticos.Name = "spinNeumaticos";
            this.spinNeumaticos.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinNeumaticos.Properties.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spinNeumaticos.Size = new System.Drawing.Size(100, 20);
            this.spinNeumaticos.TabIndex = 30;
            // 
            // spinRefacciones
            // 
            this.spinRefacciones.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinRefacciones.Location = new System.Drawing.Point(465, 168);
            this.spinRefacciones.Name = "spinRefacciones";
            this.spinRefacciones.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinRefacciones.Properties.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spinRefacciones.Size = new System.Drawing.Size(100, 20);
            this.spinRefacciones.TabIndex = 31;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label16.Location = new System.Drawing.Point(383, 165);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(76, 27);
            this.label16.TabIndex = 32;
            this.label16.Text = "# Refacciones";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rgEstatus
            // 
            this.rgEstatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgEstatus.Location = new System.Drawing.Point(88, 221);
            this.rgEstatus.Name = "rgEstatus";
            this.rgEstatus.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "ACTIVO"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "INACTIVO")});
            this.rgEstatus.Size = new System.Drawing.Size(269, 55);
            this.rgEstatus.TabIndex = 33;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Location = new System.Drawing.Point(8, 218);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 61);
            this.label17.TabIndex = 34;
            this.label17.Text = "Estatus";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmVehiculosNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 319);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmVehiculosNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vehículos : Nuevo";
            this.Load += new System.EventHandler(this.frmVehiculosNew_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEmpresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deFecha.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinModelo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupTipo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deVigIni.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deVigIni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deVigFin.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deVigFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEmpleado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupTransmision.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinNeumaticos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinRefacciones.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgEstatus.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton btnInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.TextBox txtSubMarca;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.TextBox txtPlacas;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraEditors.DateEdit deFecha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.LookUpEdit lookupEmpresa;
        private DevExpress.XtraEditors.SpinEdit spinModelo;
        private DevExpress.XtraEditors.LookUpEdit lookupTipo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPoliza;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtCompañia;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.DateEdit deVigIni;
        private DevExpress.XtraEditors.DateEdit deVigFin;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.LookUpEdit lookupEmpleado;
        private System.Windows.Forms.Label label14;
        private DevExpress.XtraEditors.LookUpEdit lookupTransmision;
        private System.Windows.Forms.Label label15;
        private DevExpress.XtraEditors.SpinEdit spinNeumaticos;
        private DevExpress.XtraEditors.SpinEdit spinRefacciones;
        private System.Windows.Forms.Label label16;
        private DevExpress.XtraEditors.RadioGroup rgEstatus;
        private System.Windows.Forms.Label label17;
    }
}