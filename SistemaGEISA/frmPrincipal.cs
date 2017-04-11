using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Collections;
using GeisaBD;
using SistemaGEISA.Properties;
using Reportes;
using System.Deployment.Application;

namespace SistemaGEISA
{
    public partial class frmPrincipal : DevExpress.XtraEditors.XtraForm
    {
        private Hashtable instancias = new Hashtable();
        private static Controler controler { get; set; }
        public static Usuario UsuarioDelSistema { get; set; }
        public static Perfil PerfilUsuario { get; set; }
        public frmPrincipal()
        {
            InitializeComponent();
            setAdminConexion();
            controler = new Controler();
            limpiarMenu();
        }

        public static void setAdminConexion()
        {
            try
            {
                GEISAEntities.SetDbConnection(Settings.Default.Servidor,
                                                Settings.Default.Usuario,
                                                Settings.Default.Contraseña,
                                                Settings.Default.BaseDatos);
            }
            catch
            {
            }
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();
            lblHora.Text = DateTime.Now.ToShortTimeString();
            timer.Start();

            var form = new frmLogin();
            form.TopMost = true;
            Visible = false;
            if (form.ShowDialog() != DialogResult.OK)
            {
                form.Dispose();
                Application.Exit();
            }
            else
            {
                UsuarioDelSistema = form.Usuario;
                PerfilUsuario = UsuarioDelSistema.PerfilLoaded;
                lblUsuario.Text = UsuarioDelSistema.Login;
                form.Dispose();
                Visible = true;

                llenaMenu();
            }

            
            try
            {
                ApplicationDeployment deploy = ApplicationDeployment.CurrentDeployment;
                UpdateCheckInfo update = deploy.CheckForDetailedUpdate();
                if (deploy.CheckForUpdate())
                {
                    MessageBox.Show("Hay una nueva version Disponible:" + update.AvailableVersion.ToString());
                    deploy.Update();
                    Application.Restart();
                }
                else
                {
                    this.Text = this.Text + " - Version " + deploy.CurrentVersion;
                }
            }
            catch (Exception ex)
            {

            }
        }

        public Form AbrirVentana(Type tipo)
        {
            return AbrirVentana(tipo.FullName);
        }

        public Form AbrirVentana(string tipo)
        {
            try
            {
                var formulario = instancias[tipo] as XtraForm;
                if (formulario == null || formulario.IsDisposed)
                {
                    formulario = (XtraForm)Activator.CreateInstance(null, tipo).Unwrap();

                    instancias[tipo] = formulario;

                    formulario.MdiParent = this;

                    formulario.Show();
                }
                else
                {
                    TabControl.SelectedPage = TabControl.Pages[instancias[tipo] as Form];
                }


                return formulario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void limpiarMenu()
        {
            foreach (DevExpress.XtraNavBar.NavBarGroup group in BarMenu.Groups)
            {
                foreach (DevExpress.XtraNavBar.NavBarItemLink item in group.ItemLinks)
                {
                    item.Visible = false;
                }
                group.Visible = false;
            }
        }

        private void llenaMenu()
        {
            var numAdministracion = 0;
            var numCatalogos = 0;
            var numOperaciones = 0;

            var rolPermisos = PerfilUsuario.Load(PerfilUsuario.PerfilPermisos).ToList();

            foreach (PerfilPermisos rp in rolPermisos)
            {
                if (!rp.FormularioPermisosReference.IsLoaded)
                {
                    rp.FormularioPermisosReference.Load();
                }
                if (!rp.FormularioPermisos.FormularioReference.IsLoaded)
                {
                    rp.FormularioPermisos.FormularioReference.Load();
                }
                var f = rp.FormularioPermisos.Formulario;

                if (!f.ModuloReference.IsLoaded)
                {
                    f.ModuloReference.Load();
                }
                if (f.Modulo.Nombre == navAdministracion.Tag.ToString())
                {
                    if (enableMenu(f, navAdministracion))
                    {
                        numAdministracion++;
                    }
                }
                else
                {
                    if (f.Modulo.Nombre == navCatalogos.Tag.ToString())
                    {
                        if (enableMenu(f, navCatalogos))
                        {
                            numCatalogos++;
                        }
                    }
                    else
                    {
                        if (f.Modulo.Nombre == navOperaciones.Tag.ToString())
                        {
                            if (enableMenu(f, navOperaciones))
                            {
                                numOperaciones++;
                            }
                        }
                    }
                }
            }

            if (numAdministracion > 0)
            {
                navAdministracion.Visible = true;
            }
            if (numCatalogos > 0)
            {
                navCatalogos.Visible = true;
            }
            if (numOperaciones > 0)
            {
                navOperaciones.Visible = true;
            }

            foreach (DevExpress.XtraNavBar.NavBarItemLink link in navReportes.ItemLinks)
            {
                link.Visible = true;
                link.Item.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(NavBarItem_LinkClicked);
            }

            navReportes.Visible = true;
        }

        private bool enableMenu(Formulario form, DevExpress.XtraNavBar.NavBarGroup barGroup)
        {
            var result = false;

            foreach (DevExpress.XtraNavBar.NavBarItemLink link in barGroup.ItemLinks)
            {
                var tag = link.Item.Tag as string;
                if (tag != null)
                {
                    if (form.Forma == tag)
                    {
                        if (link.Visible == false)
                        {
                            link.Visible = result = true;
                            link.Item.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(NavBarItem_LinkClicked);
                            break;
                        }
                    }
                }
            }
            return result;
        }

        private void cerrarFormas()
        {
            Form FormToClose;
            int TotalOpenForms;

            TotalOpenForms = Application.OpenForms.Count;

            if (TotalOpenForms > 1)
            {
                for (var iFormChild = TotalOpenForms - 1; iFormChild > 0; iFormChild--)
                {
                    FormToClose = Application.OpenForms[iFormChild];
                    if (FormToClose.Name != Name)
                    {
                        FormToClose.Close();
                    }
                }
            }
        }

        private void NavBarItem_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var tag = e.Link.Item.Tag as string;
            if (tag != null)
            {
                AbrirVentana("SistemaGEISA." + tag);
            }
        }

        private void pictureUser_Click(object sender, EventArgs e)
        {
            cerrarFormas();
            Visible = false;

            var Login = new frmLogin();
            Login.TopMost = true;
            if (Login.ShowDialog() == DialogResult.OK)
            {
                limpiarMenu();
                UsuarioDelSistema = Login.Usuario;
                PerfilUsuario = UsuarioDelSistema.PerfilLoaded;
                lblUsuario.Text = UsuarioDelSistema.Login;
                llenaMenu();
            }

            Login.Dispose();
            Visible = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToShortDateString();
            lblHora.Text = DateTime.Now.ToShortTimeString();
        }

        private void itCuentaProveedores_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmEstadoCuentaProveedores form = instancias["SistemaGEISA.frmEstadoCuentaProveedores"] as frmEstadoCuentaProveedores;
            if (form == null || form.IsDisposed)
            {
                form = new frmEstadoCuentaProveedores();

                instancias["SistemaGEISA.frmEstadoCuentaProveedores"] = form;

                form.MdiParent = this;

                form.Show();
            }
        }

        private void itGastosGenerados_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmGastosGeneradosViaticos form = instancias["SistemaGEISA.frmGastosGeneradosViaticos"] as frmGastosGeneradosViaticos;
            if (form == null || form.IsDisposed)
            {
                form = new frmGastosGeneradosViaticos();

                instancias["SistemaGEISA.frmGastosGeneradosViaticos"] = form;

                form.MdiParent = this;

                form.Show();
            }
        }

        private void itCuentasPorPagar_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmCuentasPorPagar form = instancias["SistemaGEISA.frmCuentasPorPagar"] as frmCuentasPorPagar;
            if (form == null || form.IsDisposed)
            {
                form = new frmCuentasPorPagar();

                instancias["SistemaGEISA.frmCuentasPorPagar"] = form;

                form.MdiParent = this;

                form.Show();
            }
        }

        private void itBanco_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmBancos form = instancias["SistemaGEISA.frmBancos"] as frmBancos;
            if (form == null || form.IsDisposed)
            {
                form = new frmBancos();

                instancias["SistemaGEISA.frmBancos"] = form;

                form.MdiParent = this;

                form.Show();
            }
        }

        private void itIngresosMensuales_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmIngresosMensualesPorEmpresa form = instancias["SistemaGEISA.frmIngresosMensualesPorEmpresa"] as frmIngresosMensualesPorEmpresa;
            if (form == null || form.IsDisposed)
            {
                form = new frmIngresosMensualesPorEmpresa();

                instancias["SistemaGEISA.frmIngresosMensualesPorEmpresa"] = form;

                form.MdiParent = this;

                form.Show();
            }
        }

        private void itVehiculosGasolina_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmVehiculosGasolina form = instancias["SistemaGEISA.frmVehiculosGasolina"] as frmVehiculosGasolina;
            if (form == null || form.IsDisposed)
            {
                form = new frmVehiculosGasolina();

                instancias["SistemaGEISA.frmVehiculosGasolina"] = form;

                form.MdiParent = this;

                form.Show();
            }
        }

        private void itNominaSemanal_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmNominaSemanal form = instancias["SistemaGEISA.frmNominaSemanal"] as frmNominaSemanal;
            if (form == null || form.IsDisposed)
            {
                form = new frmNominaSemanal();

                instancias["SistemaGEISA.frmNominaSemanal"] = form;

                form.MdiParent = this;

                form.Show();
            }
        }

        private void itPrimaVacacional_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            frmReportePrimaVacacional form = instancias["SistemaGEISA.frmReportePrimaVacacional"] as frmReportePrimaVacacional;
            if (form == null || form.IsDisposed)
            {
                form = new frmReportePrimaVacacional();

                instancias["SistemaGEISA.frmReportePrimaVacacional"] = form;

                form.MdiParent = this;

                form.Show();
            }
        }
    }
}
