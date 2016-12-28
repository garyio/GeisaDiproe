namespace SistemaGEISA
{
    partial class frmPrincipal
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.pictureUser = new System.Windows.Forms.PictureBox();
            this.BarMenu = new DevExpress.XtraNavBar.NavBarControl();
            this.navOperaciones = new DevExpress.XtraNavBar.NavBarGroup();
            this.itObra = new DevExpress.XtraNavBar.NavBarItem();
            this.itContrarecibo = new DevExpress.XtraNavBar.NavBarItem();
            this.itPagos = new DevExpress.XtraNavBar.NavBarItem();
            this.itCajaChica = new DevExpress.XtraNavBar.NavBarItem();
            this.itGastosAdmin = new DevExpress.XtraNavBar.NavBarItem();
            this.itCajaChicaVehiculo = new DevExpress.XtraNavBar.NavBarItem();
            this.itReposicionGastos = new DevExpress.XtraNavBar.NavBarItem();
            this.itTarjetaCredito = new DevExpress.XtraNavBar.NavBarItem();
            this.itBuscarFactura = new DevExpress.XtraNavBar.NavBarItem();
            this.itPrestamoEmpresas = new DevExpress.XtraNavBar.NavBarItem();
            this.itIngresos = new DevExpress.XtraNavBar.NavBarItem();
            this.itBanco = new DevExpress.XtraNavBar.NavBarItem();
            this.itOrdenes = new DevExpress.XtraNavBar.NavBarItem();
            this.itNominas = new DevExpress.XtraNavBar.NavBarItem();
            this.navAdministracion = new DevExpress.XtraNavBar.NavBarGroup();
            this.itPerfiles = new DevExpress.XtraNavBar.NavBarItem();
            this.itUsuarios = new DevExpress.XtraNavBar.NavBarItem();
            this.itConexion = new DevExpress.XtraNavBar.NavBarItem();
            this.itParametros = new DevExpress.XtraNavBar.NavBarItem();
            this.navCatalogos = new DevExpress.XtraNavBar.NavBarGroup();
            this.itEmpresa = new DevExpress.XtraNavBar.NavBarItem();
            this.itEmpleado = new DevExpress.XtraNavBar.NavBarItem();
            this.itProveedor = new DevExpress.XtraNavBar.NavBarItem();
            this.itCliente = new DevExpress.XtraNavBar.NavBarItem();
            this.itBancos = new DevExpress.XtraNavBar.NavBarItem();
            this.itVehiculos = new DevExpress.XtraNavBar.NavBarItem();
            this.itConceptos = new DevExpress.XtraNavBar.NavBarItem();
            this.itTarjetasCredito = new DevExpress.XtraNavBar.NavBarItem();
            this.itArticulos = new DevExpress.XtraNavBar.NavBarItem();
            this.navReportes = new DevExpress.XtraNavBar.NavBarGroup();
            this.itCuentaProveedores = new DevExpress.XtraNavBar.NavBarItem();
            this.itGastosGenerados = new DevExpress.XtraNavBar.NavBarItem();
            this.itCuentasPorPagar = new DevExpress.XtraNavBar.NavBarItem();
            this.itIngresosMensuales = new DevExpress.XtraNavBar.NavBarItem();
            this.itVehiculosGasolina = new DevExpress.XtraNavBar.NavBarItem();
            this.itNominaSemanal = new DevExpress.XtraNavBar.NavBarItem();
            this.TabControl = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabControl)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.tableLayoutPanel1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 333);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(684, 28);
            this.panelControl1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblUsuario, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblHora, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFecha, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureUser, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(680, 24);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUsuario.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(27, 3);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(3);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(1, 18);
            this.lblUsuario.TabIndex = 3;
            this.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHora
            // 
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.Location = new System.Drawing.Point(597, 3);
            this.lblHora.Margin = new System.Windows.Forms.Padding(3);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(80, 16);
            this.lblHora.TabIndex = 0;
            this.lblHora.Text = "12:08 p.m.";
            this.lblHora.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFecha.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(507, 3);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(3);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(84, 18);
            this.lblFecha.TabIndex = 1;
            this.lblFecha.Text = "19/08/2014";
            this.lblFecha.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureUser
            // 
            this.pictureUser.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureUser.Image = global::SistemaGEISA.Properties.Resources.login_user;
            this.pictureUser.Location = new System.Drawing.Point(0, 0);
            this.pictureUser.Margin = new System.Windows.Forms.Padding(0);
            this.pictureUser.Name = "pictureUser";
            this.pictureUser.Size = new System.Drawing.Size(24, 24);
            this.pictureUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureUser.TabIndex = 2;
            this.pictureUser.TabStop = false;
            this.pictureUser.Click += new System.EventHandler(this.pictureUser_Click);
            // 
            // BarMenu
            // 
            this.BarMenu.ActiveGroup = this.navOperaciones;
            this.BarMenu.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.BarMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.BarMenu.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navAdministracion,
            this.navCatalogos,
            this.navOperaciones,
            this.navReportes});
            this.BarMenu.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.itPerfiles,
            this.itUsuarios,
            this.itConexion,
            this.itParametros,
            this.itEmpresa,
            this.itEmpleado,
            this.itProveedor,
            this.itCliente,
            this.itBancos,
            this.itObra,
            this.itContrarecibo,
            this.itPagos,
            this.itCajaChica,
            this.itVehiculos,
            this.itConceptos,
            this.itGastosAdmin,
            this.itCajaChicaVehiculo,
            this.itReposicionGastos,
            this.itCuentaProveedores,
            this.itTarjetasCredito,
            this.itTarjetaCredito,
            this.itGastosGenerados,
            this.itBuscarFactura,
            this.itCuentasPorPagar,
            this.itPrestamoEmpresas,
            this.itIngresos,
            this.itBanco,
            this.itIngresosMensuales,
            this.itArticulos,
            this.itOrdenes,
            this.itVehiculosGasolina,
            this.itNominas,
            this.itNominaSemanal});
            this.BarMenu.Location = new System.Drawing.Point(0, 0);
            this.BarMenu.LookAndFeel.SkinName = "Sharp";
            this.BarMenu.LookAndFeel.UseDefaultLookAndFeel = false;
            this.BarMenu.Name = "BarMenu";
            this.BarMenu.OptionsNavPane.ExpandedWidth = 220;
            this.BarMenu.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.BarMenu.Size = new System.Drawing.Size(220, 333);
            this.BarMenu.TabIndex = 1;
            // 
            // navOperaciones
            // 
            this.navOperaciones.Caption = "Operaciones";
            this.navOperaciones.Expanded = true;
            this.navOperaciones.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.itObra),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itContrarecibo),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itPagos),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itCajaChica),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itGastosAdmin),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itCajaChicaVehiculo),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itReposicionGastos),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itTarjetaCredito),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itBuscarFactura),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itPrestamoEmpresas),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itIngresos),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itBanco),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itOrdenes),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itNominas)});
            this.navOperaciones.LargeImage = global::SistemaGEISA.Properties.Resources.Movimientos;
            this.navOperaciones.Name = "navOperaciones";
            this.navOperaciones.Tag = "Operaciones";
            // 
            // itObra
            // 
            this.itObra.Caption = "Obras";
            this.itObra.Name = "itObra";
            this.itObra.SmallImage = global::SistemaGEISA.Properties.Resources.obra;
            this.itObra.Tag = "frmObras";
            // 
            // itContrarecibo
            // 
            this.itContrarecibo.Caption = "Contra-recibos";
            this.itContrarecibo.Name = "itContrarecibo";
            this.itContrarecibo.SmallImage = global::SistemaGEISA.Properties.Resources.archives;
            this.itContrarecibo.Tag = "frmContrarecibo";
            // 
            // itPagos
            // 
            this.itPagos.Caption = "Pagos";
            this.itPagos.Name = "itPagos";
            this.itPagos.SmallImage = global::SistemaGEISA.Properties.Resources.money2;
            this.itPagos.Tag = "frmPagos";
            // 
            // itCajaChica
            // 
            this.itCajaChica.Caption = "Caja Chica";
            this.itCajaChica.Name = "itCajaChica";
            this.itCajaChica.SmallImage = global::SistemaGEISA.Properties.Resources.caja;
            this.itCajaChica.Tag = "frmCajaChica";
            // 
            // itGastosAdmin
            // 
            this.itGastosAdmin.Caption = "Gastos Administrativos";
            this.itGastosAdmin.Name = "itGastosAdmin";
            this.itGastosAdmin.SmallImage = global::SistemaGEISA.Properties.Resources.Gastos_Adm1;
            this.itGastosAdmin.Tag = "frmGastosAdministrativos";
            // 
            // itCajaChicaVehiculo
            // 
            this.itCajaChicaVehiculo.Caption = "Vehículo Caja Chica";
            this.itCajaChicaVehiculo.Name = "itCajaChicaVehiculo";
            this.itCajaChicaVehiculo.SmallImage = global::SistemaGEISA.Properties.Resources.Caja_Chica;
            this.itCajaChicaVehiculo.Tag = "frmCajaChicaVehiculo";
            // 
            // itReposicionGastos
            // 
            this.itReposicionGastos.Caption = "Reposicion de Gastos";
            this.itReposicionGastos.Name = "itReposicionGastos";
            this.itReposicionGastos.SmallImage = global::SistemaGEISA.Properties.Resources.ReposicionGastos;
            this.itReposicionGastos.Tag = "frmReposicionGastos";
            // 
            // itTarjetaCredito
            // 
            this.itTarjetaCredito.Caption = "Pagos Tarjetas de Credito";
            this.itTarjetaCredito.Name = "itTarjetaCredito";
            this.itTarjetaCredito.SmallImage = global::SistemaGEISA.Properties.Resources.TarjetaDeCredito1;
            this.itTarjetaCredito.Tag = "frmTarjetasPagos";
            // 
            // itBuscarFactura
            // 
            this.itBuscarFactura.Caption = "Buscador de Facturas";
            this.itBuscarFactura.Name = "itBuscarFactura";
            this.itBuscarFactura.SmallImage = ((System.Drawing.Image)(resources.GetObject("itBuscarFactura.SmallImage")));
            this.itBuscarFactura.Tag = "frmBuscadorFacturas";
            // 
            // itPrestamoEmpresas
            // 
            this.itPrestamoEmpresas.Caption = "Prestamos Empresas";
            this.itPrestamoEmpresas.Name = "itPrestamoEmpresas";
            this.itPrestamoEmpresas.SmallImage = global::SistemaGEISA.Properties.Resources.Prestamos__2_;
            this.itPrestamoEmpresas.Tag = "frmPrestamosEmpresas";
            // 
            // itIngresos
            // 
            this.itIngresos.Caption = "Ingresos";
            this.itIngresos.Name = "itIngresos";
            this.itIngresos.SmallImage = ((System.Drawing.Image)(resources.GetObject("itIngresos.SmallImage")));
            this.itIngresos.Tag = "frmIngresos";
            // 
            // itBanco
            // 
            this.itBanco.Caption = "Banco";
            this.itBanco.Name = "itBanco";
            this.itBanco.SmallImage = ((System.Drawing.Image)(resources.GetObject("itBanco.SmallImage")));
            this.itBanco.Tag = "frmBancos";
            // 
            // itOrdenes
            // 
            this.itOrdenes.Caption = "Compras / Salidas Almacen";
            this.itOrdenes.Name = "itOrdenes";
            this.itOrdenes.SmallImage = global::SistemaGEISA.Properties.Resources.OrdenesCompra;
            this.itOrdenes.Tag = "frmOrdenes";
            // 
            // itNominas
            // 
            this.itNominas.Caption = "Nominas";
            this.itNominas.Name = "itNominas";
            this.itNominas.SmallImage = ((System.Drawing.Image)(resources.GetObject("itNominas.SmallImage")));
            this.itNominas.Tag = "frmNominas";
            // 
            // navAdministracion
            // 
            this.navAdministracion.Caption = "Administración";
            this.navAdministracion.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.itPerfiles),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itUsuarios),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itConexion),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itParametros)});
            this.navAdministracion.LargeImage = global::SistemaGEISA.Properties.Resources.settings;
            this.navAdministracion.Name = "navAdministracion";
            this.navAdministracion.Tag = "Administracion";
            // 
            // itPerfiles
            // 
            this.itPerfiles.Caption = "Perfiles";
            this.itPerfiles.Name = "itPerfiles";
            this.itPerfiles.SmallImage = global::SistemaGEISA.Properties.Resources.perfiles1;
            this.itPerfiles.Tag = "frmPerfiles";
            // 
            // itUsuarios
            // 
            this.itUsuarios.Caption = "Usuarios";
            this.itUsuarios.Name = "itUsuarios";
            this.itUsuarios.SmallImage = global::SistemaGEISA.Properties.Resources.user6;
            this.itUsuarios.Tag = "frmUsuarios";
            // 
            // itConexion
            // 
            this.itConexion.Caption = "Conexión";
            this.itConexion.Name = "itConexion";
            this.itConexion.SmallImage = global::SistemaGEISA.Properties.Resources.database;
            this.itConexion.Tag = "frmConexion";
            // 
            // itParametros
            // 
            this.itParametros.Caption = "Parámetros";
            this.itParametros.Name = "itParametros";
            this.itParametros.SmallImage = global::SistemaGEISA.Properties.Resources.settings1;
            this.itParametros.Tag = "frmParametros";
            // 
            // navCatalogos
            // 
            this.navCatalogos.Caption = "Catálogos";
            this.navCatalogos.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.itEmpresa),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itEmpleado),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itProveedor),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itCliente),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itBancos),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itVehiculos),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itConceptos),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itTarjetasCredito),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itArticulos)});
            this.navCatalogos.LargeImage = global::SistemaGEISA.Properties.Resources.books;
            this.navCatalogos.Name = "navCatalogos";
            this.navCatalogos.Tag = "Catalogos";
            this.navCatalogos.TopVisibleLinkIndex = 4;
            // 
            // itEmpresa
            // 
            this.itEmpresa.Caption = "Empresas";
            this.itEmpresa.Name = "itEmpresa";
            this.itEmpresa.SmallImage = global::SistemaGEISA.Properties.Resources.empresa;
            this.itEmpresa.Tag = "frmEmpresa";
            // 
            // itEmpleado
            // 
            this.itEmpleado.Caption = "Empleados";
            this.itEmpleado.Name = "itEmpleado";
            this.itEmpleado.SmallImage = global::SistemaGEISA.Properties.Resources.business_contact;
            this.itEmpleado.Tag = "frmEmpleado";
            // 
            // itProveedor
            // 
            this.itProveedor.Caption = "Proveedores";
            this.itProveedor.Name = "itProveedor";
            this.itProveedor.SmallImage = global::SistemaGEISA.Properties.Resources.user2;
            this.itProveedor.Tag = "frmProveedor";
            // 
            // itCliente
            // 
            this.itCliente.Caption = "Clientes";
            this.itCliente.Name = "itCliente";
            this.itCliente.SmallImage = global::SistemaGEISA.Properties.Resources.customers;
            this.itCliente.Tag = "frmCliente";
            // 
            // itBancos
            // 
            this.itBancos.Caption = "Bancos";
            this.itBancos.Name = "itBancos";
            this.itBancos.SmallImage = global::SistemaGEISA.Properties.Resources.library;
            this.itBancos.Tag = "frmBanco";
            // 
            // itVehiculos
            // 
            this.itVehiculos.Caption = "Vehículos";
            this.itVehiculos.Name = "itVehiculos";
            this.itVehiculos.SmallImage = global::SistemaGEISA.Properties.Resources.Vehiculos;
            this.itVehiculos.Tag = "frmVehiculos";
            // 
            // itConceptos
            // 
            this.itConceptos.Caption = "Conceptos";
            this.itConceptos.Name = "itConceptos";
            this.itConceptos.SmallImage = global::SistemaGEISA.Properties.Resources.Concepto;
            this.itConceptos.Tag = "frmConceptos";
            // 
            // itTarjetasCredito
            // 
            this.itTarjetasCredito.Caption = "Tarjetas Credito";
            this.itTarjetasCredito.Name = "itTarjetasCredito";
            this.itTarjetasCredito.SmallImage = global::SistemaGEISA.Properties.Resources.TarjetaDeCredito;
            this.itTarjetasCredito.Tag = "frmTarjetasCredito";
            // 
            // itArticulos
            // 
            this.itArticulos.Caption = "Articulos / Existencias";
            this.itArticulos.Name = "itArticulos";
            this.itArticulos.SmallImage = global::SistemaGEISA.Properties.Resources.articulos;
            this.itArticulos.Tag = "frmArticulos";
            // 
            // navReportes
            // 
            this.navReportes.Caption = "Reportes";
            this.navReportes.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.itCuentaProveedores),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itGastosGenerados),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itCuentasPorPagar),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itIngresosMensuales),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itVehiculosGasolina),
            new DevExpress.XtraNavBar.NavBarItemLink(this.itNominaSemanal)});
            this.navReportes.LargeImage = global::SistemaGEISA.Properties.Resources.Reportes;
            this.navReportes.Name = "navReportes";
            this.navReportes.Tag = "Reportes";
            this.navReportes.TopVisibleLinkIndex = 1;
            // 
            // itCuentaProveedores
            // 
            this.itCuentaProveedores.Caption = "Estado de Cuenta Proveedores";
            this.itCuentaProveedores.Name = "itCuentaProveedores";
            this.itCuentaProveedores.SmallImage = global::SistemaGEISA.Properties.Resources.Reporte;
            this.itCuentaProveedores.Tag = "frmEstadoCuentaProveedores";
            this.itCuentaProveedores.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.itCuentaProveedores_LinkClicked);
            // 
            // itGastosGenerados
            // 
            this.itGastosGenerados.Caption = "Gastos Generados Obra";
            this.itGastosGenerados.Name = "itGastosGenerados";
            this.itGastosGenerados.SmallImage = global::SistemaGEISA.Properties.Resources.Reporte;
            this.itGastosGenerados.Tag = "frmGastosGeneradosViaticos";
            this.itGastosGenerados.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.itGastosGenerados_LinkClicked);
            // 
            // itCuentasPorPagar
            // 
            this.itCuentasPorPagar.Caption = "Cuentas por Pagar";
            this.itCuentasPorPagar.Name = "itCuentasPorPagar";
            this.itCuentasPorPagar.SmallImage = global::SistemaGEISA.Properties.Resources.Reporte;
            this.itCuentasPorPagar.Tag = "frmCuentasPorPagar";
            this.itCuentasPorPagar.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.itCuentasPorPagar_LinkClicked);
            // 
            // itIngresosMensuales
            // 
            this.itIngresosMensuales.Caption = "Resumen Facturas Mensual";
            this.itIngresosMensuales.Name = "itIngresosMensuales";
            this.itIngresosMensuales.SmallImage = global::SistemaGEISA.Properties.Resources.Reporte;
            this.itIngresosMensuales.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.itIngresosMensuales_LinkClicked);
            // 
            // itVehiculosGasolina
            // 
            this.itVehiculosGasolina.Caption = "Vehiculos Gasolina";
            this.itVehiculosGasolina.Name = "itVehiculosGasolina";
            this.itVehiculosGasolina.SmallImage = global::SistemaGEISA.Properties.Resources.Reporte;
            this.itVehiculosGasolina.Tag = "frmVehiculosGasolina";
            this.itVehiculosGasolina.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.itVehiculosGasolina_LinkClicked);
            // 
            // itNominaSemanal
            // 
            this.itNominaSemanal.Caption = "Nomina Semanal";
            this.itNominaSemanal.Name = "itNominaSemanal";
            this.itNominaSemanal.SmallImage = global::SistemaGEISA.Properties.Resources.Reporte;
            this.itNominaSemanal.Tag = "frmNominaSemanal";
            this.itNominaSemanal.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.itNominaSemanal_LinkClicked);
            // 
            // TabControl
            // 
            this.TabControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.TabControl.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.TabControl.MdiParent = this;
            this.TabControl.UseFormIconAsPageImage = DevExpress.Utils.DefaultBoolean.True;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // frmPrincipal
            // 
            this.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.BarMenu);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.LookAndFeel.SkinName = "Visual Studio 2013 Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "frmPrincipal";
            this.Text = "Sistema Control Inmobiliario v1.0.3";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TabControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraNavBar.NavBarControl BarMenu;
        private DevExpress.XtraNavBar.NavBarGroup navAdministracion;
        private DevExpress.XtraNavBar.NavBarItem itPerfiles;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager TabControl;
        private DevExpress.XtraNavBar.NavBarGroup navCatalogos;
        private DevExpress.XtraNavBar.NavBarItem itUsuarios;
        private DevExpress.XtraNavBar.NavBarItem itConexion;
        private DevExpress.XtraNavBar.NavBarItem itParametros;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.PictureBox pictureUser;
        private System.Windows.Forms.Timer timer;
        private DevExpress.XtraNavBar.NavBarItem itEmpresa;
        private DevExpress.XtraNavBar.NavBarItem itEmpleado;
        private DevExpress.XtraNavBar.NavBarItem itProveedor;
        private DevExpress.XtraNavBar.NavBarItem itCliente;
        private DevExpress.XtraNavBar.NavBarItem itBancos;
        private DevExpress.XtraNavBar.NavBarGroup navOperaciones;
        private DevExpress.XtraNavBar.NavBarItem itObra;
        private DevExpress.XtraNavBar.NavBarItem itContrarecibo;
        private DevExpress.XtraNavBar.NavBarItem itPagos;
        private DevExpress.XtraNavBar.NavBarItem itCajaChica;
        private DevExpress.XtraNavBar.NavBarItem itVehiculos;
        private DevExpress.XtraNavBar.NavBarItem itConceptos;
        private DevExpress.XtraNavBar.NavBarItem itGastosAdmin;
        private DevExpress.XtraNavBar.NavBarItem itCajaChicaVehiculo;
        private DevExpress.XtraNavBar.NavBarItem itReposicionGastos;
        private DevExpress.XtraNavBar.NavBarGroup navReportes;
        private DevExpress.XtraNavBar.NavBarItem itCuentaProveedores;
        private DevExpress.XtraNavBar.NavBarItem itTarjetasCredito;
        private DevExpress.XtraNavBar.NavBarItem itTarjetaCredito;
        private DevExpress.XtraNavBar.NavBarItem itGastosGenerados;
        private DevExpress.XtraNavBar.NavBarItem itBuscarFactura;
        private DevExpress.XtraNavBar.NavBarItem itCuentasPorPagar;
        private DevExpress.XtraNavBar.NavBarItem itPrestamoEmpresas;
        private DevExpress.XtraNavBar.NavBarItem itIngresos;
        private DevExpress.XtraNavBar.NavBarItem itBanco;
        private DevExpress.XtraNavBar.NavBarItem itIngresosMensuales;
        private DevExpress.XtraNavBar.NavBarItem itArticulos;
        private DevExpress.XtraNavBar.NavBarItem itOrdenes;
        private DevExpress.XtraNavBar.NavBarItem itVehiculosGasolina;
        private DevExpress.XtraNavBar.NavBarItem itNominas;
        private DevExpress.XtraNavBar.NavBarItem itNominaSemanal;
    }
}