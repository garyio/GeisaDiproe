using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GeisaBD;

namespace SistemaGEISA
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        private Controler controler;
        private Usuario _usuario;
        public Usuario Usuario
        {
            get
            {
                return _usuario;
            }
            internal set
            {
                if (value != _usuario)
                {
                    _usuario = value;
                    if (OnUsuarioLogged != null)
                    {
                        OnUsuarioLogged(Usuario, EventArgs.Empty);
                    }
                }
            }
        }
        private event EventHandler OnUsuarioLogged;
        public event EventHandler UsuarioLogged
        {
            add
            {
                OnUsuarioLogged += value;
            }
            remove
            {
                OnUsuarioLogged -= value;
            }
        }
        public frmLogin()
        {
            InitializeComponent();
            controler = new Controler();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            if (btnParametros.Visible = !(btnEntrar.Enabled = txtUsuario.Enabled = txtContraseña.Enabled = controler.IsDbConnectionOK()))
            {
                new frmMessageBox(true) { Message = "Es necesario configurar los parametros de conexión antes de continuar", Title = "Advertencia" }.ShowDialog();
            }
            else
            {
                txtUsuario.Focus();
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            if (txtUsuario.Text.Trim() != string.Empty && txtContraseña.Text.Trim() != string.Empty)
            {
                var usuarioText = txtUsuario.Text;
                var usuario = controler.Model.Usuario.FirstOrDefault<Usuario>(usuarios => usuarios.Login == usuarioText);

                if (usuario == null)
                {
                    lblError.Text = "Login Inválido";
                }
                else
                {
                    var passw = controler.Hash(txtContraseña.Text);
                    if (usuario.Password.Equals(passw))
                    {
                        if (usuario.Activo)
                        {
                            Usuario = usuario;
                            DialogResult = DialogResult.OK;
                            Close();
                        }
                        else
                        {
                            lblError.Text = "El usuario se encuentra inactivo.";
                        }
                    }
                    else
                    {
                        lblError.Text = "Clave Inválida.";
                    }
                }
            }
            else
            {
                lblError.Text = "Favor de ingresar el Usuario o la contraseña.";
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnParametros_Click(object sender, EventArgs e)
        {
            frmConexion form = new frmConexion();
            form.TopMost = true;
            form.ShowDialog();

            frmPrincipal.setAdminConexion();
            controler = new Controler(GEISAEntities.RefreshDbConnection());
            this.frmLogin_Load(null, null);
        }
    }
}
