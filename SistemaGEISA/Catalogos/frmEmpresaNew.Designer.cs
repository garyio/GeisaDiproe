﻿namespace SistemaGEISA
{
    partial class frmEmpresaNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpresaNew));
            this.menu = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtCodigoPostal = new System.Windows.Forms.MaskedTextBox();
            this.txtTelefono = new System.Windows.Forms.MaskedTextBox();
            this.txtCelular = new System.Windows.Forms.MaskedTextBox();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCiudad = new System.Windows.Forms.Button();
            this.lookupCiudad = new DevExpress.XtraEditors.LookUpEdit();
            this.btnEstado = new System.Windows.Forms.Button();
            this.lookupEstado = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomComercial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNomFiscal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtExterior = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInterior = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtColonia = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpresa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBanco = new DevExpress.XtraGrid.Columns.GridColumn();
            this.LookUpBancos = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colNoCuenta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCLABE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSucursal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFolioIni = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFolioActual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cbImagen = new System.Windows.Forms.PictureBox();
            this.dialog = new System.Windows.Forms.OpenFileDialog();
            this.menu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupCiudad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEstado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpBancos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(3);
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menu.Size = new System.Drawing.Size(602, 35);
            this.menu.TabIndex = 5;
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtCodigoPostal, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtTelefono, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtCelular, 3, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtRFC, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.btnCiudad, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.lookupCiudad, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnEstado, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.lookupEstado, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNomComercial, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtNomFiscal, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtCalle, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtExterior, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtInterior, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtColonia, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label12, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.txtMail, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.grid, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.cbImagen, 4, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 35);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 14;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(602, 421);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // txtCodigoPostal
            // 
            this.txtCodigoPostal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoPostal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCodigoPostal.Location = new System.Drawing.Point(102, 199);
            this.txtCodigoPostal.Mask = "00000";
            this.txtCodigoPostal.Name = "txtCodigoPostal";
            this.txtCodigoPostal.Size = new System.Drawing.Size(107, 21);
            this.txtCodigoPostal.TabIndex = 35;
            // 
            // txtTelefono
            // 
            this.txtTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelefono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTelefono.Location = new System.Drawing.Point(102, 226);
            this.txtTelefono.Mask = "(999)000-0000";
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(107, 21);
            this.txtTelefono.TabIndex = 34;
            // 
            // txtCelular
            // 
            this.txtCelular.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCelular.Location = new System.Drawing.Point(284, 226);
            this.txtCelular.Mask = "000-000-0000";
            this.txtCelular.Name = "txtCelular";
            this.txtCelular.Size = new System.Drawing.Size(119, 21);
            this.txtCelular.TabIndex = 33;
            // 
            // txtRFC
            // 
            this.txtRFC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRFC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRFC.Location = new System.Drawing.Point(102, 280);
            this.txtRFC.MaxLength = 13;
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Size = new System.Drawing.Size(107, 21);
            this.txtRFC.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 280);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 21);
            this.label1.TabIndex = 28;
            this.label1.Text = "RFC";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.btnCiudad.Location = new System.Drawing.Point(282, 166);
            this.btnCiudad.Margin = new System.Windows.Forms.Padding(1);
            this.btnCiudad.Name = "btnCiudad";
            this.btnCiudad.Size = new System.Drawing.Size(30, 29);
            this.btnCiudad.TabIndex = 19;
            this.btnCiudad.UseVisualStyleBackColor = true;
            this.btnCiudad.Click += new System.EventHandler(this.btnCiudad_Click);
            // 
            // lookupCiudad
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lookupCiudad, 2);
            this.lookupCiudad.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lookupCiudad.Location = new System.Drawing.Point(102, 173);
            this.lookupCiudad.Name = "lookupCiudad";
            this.lookupCiudad.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lookupCiudad.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupCiudad.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.lookupCiudad.Properties.NullText = "";
            this.lookupCiudad.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookupCiudad.Size = new System.Drawing.Size(176, 20);
            this.lookupCiudad.TabIndex = 18;
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
            this.btnEstado.Location = new System.Drawing.Point(282, 136);
            this.btnEstado.Margin = new System.Windows.Forms.Padding(1);
            this.btnEstado.Name = "btnEstado";
            this.btnEstado.Size = new System.Drawing.Size(30, 28);
            this.btnEstado.TabIndex = 16;
            this.btnEstado.UseVisualStyleBackColor = true;
            this.btnEstado.Click += new System.EventHandler(this.btnEstado_Click);
            // 
            // lookupEstado
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.lookupEstado, 2);
            this.lookupEstado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lookupEstado.Location = new System.Drawing.Point(102, 142);
            this.lookupEstado.Name = "lookupEstado";
            this.lookupEstado.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lookupEstado.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupEstado.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.lookupEstado.Properties.NullText = "";
            this.lookupEstado.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookupEstado.Size = new System.Drawing.Size(176, 20);
            this.lookupEstado.TabIndex = 15;
            this.lookupEstado.EditValueChanged += new System.EventHandler(this.lookupEstado_EditValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre Comercial";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNomComercial
            // 
            this.txtNomComercial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNomComercial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableLayoutPanel1.SetColumnSpan(this.txtNomComercial, 3);
            this.txtNomComercial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNomComercial.Location = new System.Drawing.Point(102, 3);
            this.txtNomComercial.MaxLength = 50;
            this.txtNomComercial.Name = "txtNomComercial";
            this.txtNomComercial.Size = new System.Drawing.Size(301, 21);
            this.txtNomComercial.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 30);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre Fiscal";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNomFiscal
            // 
            this.txtNomFiscal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNomFiscal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableLayoutPanel1.SetColumnSpan(this.txtNomFiscal, 3);
            this.txtNomFiscal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNomFiscal.Location = new System.Drawing.Point(102, 30);
            this.txtNomFiscal.MaxLength = 50;
            this.txtNomFiscal.Name = "txtNomFiscal";
            this.txtNomFiscal.Size = new System.Drawing.Size(301, 21);
            this.txtNomFiscal.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 21);
            this.label4.TabIndex = 6;
            this.label4.Text = "Calle";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCalle
            // 
            this.txtCalle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableLayoutPanel1.SetColumnSpan(this.txtCalle, 3);
            this.txtCalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCalle.Location = new System.Drawing.Point(102, 57);
            this.txtCalle.MaxLength = 200;
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(301, 21);
            this.txtCalle.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 84);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "No. Exterior";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtExterior
            // 
            this.txtExterior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExterior.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtExterior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExterior.Location = new System.Drawing.Point(102, 84);
            this.txtExterior.MaxLength = 50;
            this.txtExterior.Name = "txtExterior";
            this.txtExterior.Size = new System.Drawing.Size(107, 21);
            this.txtExterior.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(215, 84);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "No. Interior";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInterior
            // 
            this.txtInterior.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInterior.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtInterior.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInterior.Location = new System.Drawing.Point(284, 84);
            this.txtInterior.MaxLength = 50;
            this.txtInterior.Name = "txtInterior";
            this.txtInterior.Size = new System.Drawing.Size(119, 21);
            this.txtInterior.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 111);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 21);
            this.label7.TabIndex = 12;
            this.label7.Text = "Colonia";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtColonia
            // 
            this.txtColonia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtColonia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableLayoutPanel1.SetColumnSpan(this.txtColonia, 3);
            this.txtColonia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtColonia.Location = new System.Drawing.Point(102, 111);
            this.txtColonia.MaxLength = 200;
            this.txtColonia.Name = "txtColonia";
            this.txtColonia.Size = new System.Drawing.Size(301, 21);
            this.txtColonia.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 138);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 24);
            this.label8.TabIndex = 14;
            this.label8.Text = "Estado";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 168);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 25);
            this.label9.TabIndex = 17;
            this.label9.Text = "Ciudad";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 199);
            this.label10.Margin = new System.Windows.Forms.Padding(3);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 21);
            this.label10.TabIndex = 20;
            this.label10.Text = "Código Postal";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 226);
            this.label11.Margin = new System.Windows.Forms.Padding(3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 21);
            this.label11.TabIndex = 22;
            this.label11.Text = "Teléfono";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(215, 226);
            this.label12.Margin = new System.Windows.Forms.Padding(3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 21);
            this.label12.TabIndex = 24;
            this.label12.Text = "Celular";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Location = new System.Drawing.Point(3, 253);
            this.label13.Margin = new System.Windows.Forms.Padding(3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(93, 21);
            this.label13.TabIndex = 26;
            this.label13.Text = "E-Mail";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMail
            // 
            this.txtMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.txtMail, 3);
            this.txtMail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMail.Location = new System.Drawing.Point(102, 253);
            this.txtMail.MaxLength = 150;
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(301, 21);
            this.txtMail.TabIndex = 27;
            // 
            // grid
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grid, 5);
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(3, 307);
            this.grid.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.grid.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grid.MainView = this.gv;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.LookUpBancos});
            this.grid.Size = new System.Drawing.Size(596, 106);
            this.grid.TabIndex = 30;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gv});
            // 
            // gv
            // 
            this.gv.Appearance.GroupPanel.BackColor = System.Drawing.Color.Transparent;
            this.gv.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.Transparent;
            this.gv.Appearance.GroupPanel.BorderColor = System.Drawing.Color.Transparent;
            this.gv.Appearance.GroupPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gv.Appearance.GroupPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gv.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gv.Appearance.GroupPanel.Options.UseBorderColor = true;
            this.gv.Appearance.GroupPanel.Options.UseFont = true;
            this.gv.Appearance.GroupPanel.Options.UseForeColor = true;
            this.gv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colEmpresa,
            this.colBanco,
            this.colNoCuenta,
            this.colCLABE,
            this.colSucursal,
            this.colFolioIni,
            this.colFolioActual});
            this.gv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gv.GridControl = this.grid;
            this.gv.GroupPanelText = "Cuentas Bancarias";
            this.gv.Name = "gv";
            this.gv.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gv.OptionsView.EnableAppearanceEvenRow = true;
            this.gv.OptionsView.EnableAppearanceOddRow = true;
            this.gv.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.FixedWidth = true;
            this.colId.Width = 20;
            // 
            // colEmpresa
            // 
            this.colEmpresa.Caption = "Empresa";
            this.colEmpresa.FieldName = "EmpresaId";
            this.colEmpresa.Name = "colEmpresa";
            this.colEmpresa.OptionsColumn.FixedWidth = true;
            this.colEmpresa.Width = 20;
            // 
            // colBanco
            // 
            this.colBanco.Caption = "Banco";
            this.colBanco.ColumnEdit = this.LookUpBancos;
            this.colBanco.FieldName = "BancosId";
            this.colBanco.Name = "colBanco";
            this.colBanco.OptionsColumn.FixedWidth = true;
            this.colBanco.Visible = true;
            this.colBanco.VisibleIndex = 0;
            this.colBanco.Width = 120;
            // 
            // LookUpBancos
            // 
            this.LookUpBancos.AutoHeight = false;
            this.LookUpBancos.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LookUpBancos.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.LookUpBancos.Name = "LookUpBancos";
            this.LookUpBancos.NullText = "";
            this.LookUpBancos.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            // 
            // colNoCuenta
            // 
            this.colNoCuenta.Caption = "No. Cuenta";
            this.colNoCuenta.FieldName = "NoCuenta";
            this.colNoCuenta.Name = "colNoCuenta";
            this.colNoCuenta.OptionsColumn.FixedWidth = true;
            this.colNoCuenta.Visible = true;
            this.colNoCuenta.VisibleIndex = 1;
            this.colNoCuenta.Width = 90;
            // 
            // colCLABE
            // 
            this.colCLABE.Caption = "CLABE";
            this.colCLABE.FieldName = "CLABE";
            this.colCLABE.Name = "colCLABE";
            this.colCLABE.OptionsColumn.FixedWidth = true;
            this.colCLABE.Visible = true;
            this.colCLABE.VisibleIndex = 2;
            this.colCLABE.Width = 130;
            // 
            // colSucursal
            // 
            this.colSucursal.Caption = "Sucursal";
            this.colSucursal.FieldName = "Sucursal";
            this.colSucursal.Name = "colSucursal";
            this.colSucursal.OptionsColumn.FixedWidth = true;
            this.colSucursal.Visible = true;
            this.colSucursal.VisibleIndex = 3;
            this.colSucursal.Width = 150;
            // 
            // colFolioIni
            // 
            this.colFolioIni.Caption = "Folio Inicial";
            this.colFolioIni.FieldName = "FolioInicial";
            this.colFolioIni.Name = "colFolioIni";
            this.colFolioIni.OptionsColumn.FixedWidth = true;
            this.colFolioIni.Visible = true;
            this.colFolioIni.VisibleIndex = 4;
            this.colFolioIni.Width = 70;
            // 
            // colFolioActual
            // 
            this.colFolioActual.Caption = "Folio Actual";
            this.colFolioActual.FieldName = "FolioActual";
            this.colFolioActual.Name = "colFolioActual";
            this.colFolioActual.OptionsColumn.FixedWidth = true;
            this.colFolioActual.Visible = true;
            this.colFolioActual.VisibleIndex = 5;
            this.colFolioActual.Width = 70;
            // 
            // cbImagen
            // 
            this.cbImagen.BackColor = System.Drawing.Color.White;
            this.cbImagen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cbImagen.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbImagen.Location = new System.Drawing.Point(439, 3);
            this.cbImagen.Name = "cbImagen";
            this.tableLayoutPanel1.SetRowSpan(this.cbImagen, 6);
            this.cbImagen.Size = new System.Drawing.Size(160, 159);
            this.cbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cbImagen.TabIndex = 38;
            this.cbImagen.TabStop = false;
            this.cbImagen.Click += new System.EventHandler(this.cbImagen_Click);
            // 
            // frmEmpresaNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 456);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.Name = "frmEmpresaNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empresa : Nuevo";
            this.Load += new System.EventHandler(this.frmEmpresaNew_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupCiudad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupEstado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LookUpBancos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnCiudad;
        private DevExpress.XtraEditors.LookUpEdit lookupCiudad;
        private System.Windows.Forms.Button btnEstado;
        private DevExpress.XtraEditors.LookUpEdit lookupEstado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomComercial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNomFiscal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtExterior;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInterior;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtColonia;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gv;
        private DevExpress.XtraGrid.Columns.GridColumn colBanco;
        private DevExpress.XtraGrid.Columns.GridColumn colNoCuenta;
        private DevExpress.XtraGrid.Columns.GridColumn colCLABE;
        private DevExpress.XtraGrid.Columns.GridColumn colSucursal;
        private DevExpress.XtraGrid.Columns.GridColumn colFolioIni;
        private DevExpress.XtraGrid.Columns.GridColumn colFolioActual;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit LookUpBancos;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpresa;
        private System.Windows.Forms.MaskedTextBox txtCelular;
        private System.Windows.Forms.MaskedTextBox txtTelefono;
        private System.Windows.Forms.MaskedTextBox txtCodigoPostal;
        private System.Windows.Forms.PictureBox cbImagen;
        private System.Windows.Forms.OpenFileDialog dialog;
    }
}