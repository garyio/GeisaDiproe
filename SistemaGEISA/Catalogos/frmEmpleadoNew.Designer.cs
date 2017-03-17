namespace SistemaGEISA
{
    partial class frmEmpleadoNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpleadoNew));
            this.menu = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnNomina = new System.Windows.Forms.ToolStripButton();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.tabEmpleado = new DevExpress.XtraTab.XtraTabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.chkObra = new DevExpress.XtraEditors.CheckEdit();
            this.txtApMaterno = new System.Windows.Forms.TextBox();
            this.txtApPaterno = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkUsuario = new DevExpress.XtraEditors.CheckEdit();
            this.chkResidente = new DevExpress.XtraEditors.CheckEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.chkOficina = new DevExpress.XtraEditors.CheckEdit();
            this.label12 = new System.Windows.Forms.Label();
            this.tabUsuario = new DevExpress.XtraTab.XtraTabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lookupPerfil = new DevExpress.XtraEditors.LookUpEdit();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassw = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.rgContratista = new DevExpress.XtraEditors.RadioGroup();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.tabEmpleado.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkObra.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkResidente.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOficina.Properties)).BeginInit();
            this.tabUsuario.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupPerfil.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgContratista.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.Transparent;
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.menu.ImageScalingSize = new System.Drawing.Size(22, 22);
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.btnNomina});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(3);
            this.menu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menu.Size = new System.Drawing.Size(489, 35);
            this.menu.TabIndex = 8;
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
            // btnNomina
            // 
            this.btnNomina.Image = ((System.Drawing.Image)(resources.GetObject("btnNomina.Image")));
            this.btnNomina.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNomina.Name = "btnNomina";
            this.btnNomina.Size = new System.Drawing.Size(96, 26);
            this.btnNomina.Text = "Inf. Nomina";
            this.btnNomina.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 35);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.tabEmpleado;
            this.xtraTabControl1.Size = new System.Drawing.Size(489, 228);
            this.xtraTabControl1.TabIndex = 9;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabEmpleado,
            this.tabUsuario});
            // 
            // tabEmpleado
            // 
            this.tabEmpleado.Controls.Add(this.tableLayoutPanel1);
            this.tabEmpleado.Name = "tabEmpleado";
            this.tabEmpleado.Size = new System.Drawing.Size(483, 200);
            this.tabEmpleado.Text = "Empleado";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.rgContratista, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtRFC, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkObra, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtApMaterno, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtApPaterno, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtNombre, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.chkUsuario, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.chkResidente, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label11, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.chkOficina, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(483, 200);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // txtRFC
            // 
            this.txtRFC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.txtRFC, 3);
            this.txtRFC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRFC.Location = new System.Drawing.Point(101, 8);
            this.txtRFC.MaxLength = 13;
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Size = new System.Drawing.Size(369, 21);
            this.txtRFC.TabIndex = 25;
            this.txtRFC.Leave += new System.EventHandler(this.txtRFC_Leave);
            // 
            // chkObra
            // 
            this.chkObra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkObra.Location = new System.Drawing.Point(101, 141);
            this.chkObra.Name = "chkObra";
            this.chkObra.Properties.Caption = "";
            this.chkObra.Size = new System.Drawing.Size(75, 19);
            this.chkObra.TabIndex = 16;
            // 
            // txtApMaterno
            // 
            this.txtApMaterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApMaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableLayoutPanel1.SetColumnSpan(this.txtApMaterno, 3);
            this.txtApMaterno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtApMaterno.Location = new System.Drawing.Point(101, 89);
            this.txtApMaterno.MaxLength = 50;
            this.txtApMaterno.Name = "txtApMaterno";
            this.txtApMaterno.Size = new System.Drawing.Size(369, 21);
            this.txtApMaterno.TabIndex = 8;
            // 
            // txtApPaterno
            // 
            this.txtApPaterno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApPaterno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableLayoutPanel1.SetColumnSpan(this.txtApPaterno, 3);
            this.txtApPaterno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtApPaterno.Location = new System.Drawing.Point(101, 62);
            this.txtApPaterno.MaxLength = 50;
            this.txtApPaterno.Name = "txtApPaterno";
            this.txtApPaterno.Size = new System.Drawing.Size(369, 21);
            this.txtApPaterno.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(8, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Apellido Materno";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(8, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Apellido Paterno";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.tableLayoutPanel1.SetColumnSpan(this.txtNombre, 3);
            this.txtNombre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNombre.Location = new System.Drawing.Point(101, 35);
            this.txtNombre.MaxLength = 90;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(369, 21);
            this.txtNombre.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(8, 35);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nombre";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(8, 116);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 19);
            this.label4.TabIndex = 11;
            this.label4.Text = "Residente";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(182, 116);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 19);
            this.label5.TabIndex = 12;
            this.label5.Text = "Usuario Sistema";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkUsuario
            // 
            this.chkUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkUsuario.Location = new System.Drawing.Point(271, 116);
            this.chkUsuario.Name = "chkUsuario";
            this.chkUsuario.Properties.Caption = "";
            this.chkUsuario.Size = new System.Drawing.Size(199, 19);
            this.chkUsuario.TabIndex = 13;
            this.chkUsuario.CheckedChanged += new System.EventHandler(this.chkUsuario_CheckedChanged);
            // 
            // chkResidente
            // 
            this.chkResidente.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkResidente.Location = new System.Drawing.Point(101, 116);
            this.chkResidente.Name = "chkResidente";
            this.chkResidente.Properties.Caption = "";
            this.chkResidente.Size = new System.Drawing.Size(75, 19);
            this.chkResidente.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(8, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 25);
            this.label10.TabIndex = 15;
            this.label10.Text = "Obra";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(182, 138);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 25);
            this.label11.TabIndex = 17;
            this.label11.Text = "Oficina";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkOficina
            // 
            this.chkOficina.Location = new System.Drawing.Point(271, 141);
            this.chkOficina.Name = "chkOficina";
            this.chkOficina.Properties.Caption = "";
            this.chkOficina.Size = new System.Drawing.Size(75, 19);
            this.chkOficina.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(8, 5);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 27);
            this.label12.TabIndex = 26;
            this.label12.Text = "RFC";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabUsuario
            // 
            this.tabUsuario.Controls.Add(this.tableLayoutPanel2);
            this.tabUsuario.Name = "tabUsuario";
            this.tabUsuario.PageVisible = false;
            this.tabUsuario.Size = new System.Drawing.Size(374, 200);
            this.tabUsuario.Text = "Usuario";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lookupPerfil, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtEmail, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtPassw, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label6, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtLogin, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(374, 200);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // lookupPerfil
            // 
            this.lookupPerfil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lookupPerfil.Location = new System.Drawing.Point(77, 62);
            this.lookupPerfil.Name = "lookupPerfil";
            this.lookupPerfil.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lookupPerfil.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupPerfil.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Id", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Nombre", "Nombre")});
            this.lookupPerfil.Properties.NullText = "";
            this.lookupPerfil.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            this.lookupPerfil.Size = new System.Drawing.Size(289, 20);
            this.lookupPerfil.TabIndex = 8;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.Location = new System.Drawing.Point(77, 88);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(289, 21);
            this.txtEmail.TabIndex = 10;
            // 
            // txtPassw
            // 
            this.txtPassw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassw.Location = new System.Drawing.Point(77, 35);
            this.txtPassw.MaxLength = 50;
            this.txtPassw.Name = "txtPassw";
            this.txtPassw.Size = new System.Drawing.Size(289, 21);
            this.txtPassw.TabIndex = 7;
            this.txtPassw.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(8, 62);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Perfil";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(8, 35);
            this.label7.Margin = new System.Windows.Forms.Padding(3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 21);
            this.label7.TabIndex = 5;
            this.label7.Text = "Contraseña";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtLogin
            // 
            this.txtLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLogin.Location = new System.Drawing.Point(77, 8);
            this.txtLogin.MaxLength = 50;
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(289, 21);
            this.txtLogin.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(8, 8);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 21);
            this.label8.TabIndex = 3;
            this.label8.Text = "Nombre";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(8, 88);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 21);
            this.label9.TabIndex = 9;
            this.label9.Text = "E-Mail";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rgContratista
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.rgContratista, 3);
            this.rgContratista.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rgContratista.EditValue = 3;
            this.rgContratista.Location = new System.Drawing.Point(101, 166);
            this.rgContratista.Name = "rgContratista";
            this.rgContratista.Properties.Columns = 3;
            this.rgContratista.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Contratista Principal"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Contratista"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(3, "N/A")});
            this.rgContratista.Size = new System.Drawing.Size(369, 21);
            this.rgContratista.TabIndex = 78;
            // 
            // frmEmpleadoNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 263);
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.MaximizeBox = false;
            this.Name = "frmEmpleadoNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empleado : Nuevo";
            this.Load += new System.EventHandler(this.frmEmpleadoNew_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.tabEmpleado.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkObra.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkResidente.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkOficina.Properties)).EndInit();
            this.tabUsuario.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupPerfil.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgContratista.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip menu;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage tabEmpleado;
        private DevExpress.XtraTab.XtraTabPage tabUsuario;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtApMaterno;
        private System.Windows.Forms.TextBox txtApPaterno;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.CheckEdit chkUsuario;
        private DevExpress.XtraEditors.CheckEdit chkResidente;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassw;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private DevExpress.XtraEditors.LookUpEdit lookupPerfil;
        private System.Windows.Forms.ToolStripButton btnNomina;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.Label label12;
        private DevExpress.XtraEditors.CheckEdit chkObra;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private DevExpress.XtraEditors.CheckEdit chkOficina;
        private DevExpress.XtraEditors.RadioGroup rgContratista;
    }
}