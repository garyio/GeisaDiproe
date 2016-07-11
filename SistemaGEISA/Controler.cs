using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using GeisaBD;
using SistemaGEISA.Properties;


namespace SistemaGEISA
{
    public class Controler
    {
        private GEISAEntities _geisaModel;
        public GEISAEntities Model
        {
            get
            {
                return _geisaModel;
            }
        }

        private ErrorProvider _errorProvider = new ErrorProvider { RightToLeft = true };
        private Dictionary<int, Permisos> _moduloPermisos;

        public Controler()
            : this(GEISAEntities.DefaultConnectionString)
        {
        }
        public Controler(string connectionString)
        {
            InstanciateModel(connectionString);
        }
        public Controler(bool instanciateModel)
        {
            if (instanciateModel)
            {
                InstanciateModel(null);
            }
        }

        private void InstanciateModel(string connectionString)
        {
            _geisaModel = new GEISAEntities(connectionString ?? GEISAEntities.DefaultConnectionString);
        }

        public bool IsDbConnectionOK()
        {
            try
            {
                var server = Convert.ToString(Settings.Default.Servidor);
                var user = Convert.ToString(Settings.Default.Usuario);
                var password = Convert.ToString(Settings.Default.Contraseña);
                var database = Convert.ToString(Settings.Default.BaseDatos);

                var connectionString = string.Concat("server=", server, ";user=", user, ";password=", password, ";database=", string.IsNullOrEmpty(database) ? "' '" : database);
                var sqlQuery = "SELECT NAME FROM SYS.DATABASES where NAME='" + database + "'";

                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (var sqlCommand = new SqlCommand(sqlQuery, sqlConnection))
                    {
                        var sqlDataReader = sqlCommand.ExecuteReader();
                        return sqlDataReader != null || sqlDataReader.HasRows;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool CheckEmptyText(params Control[] controls)
        {
            var isOK = true;
            var ok = true;
            var controlFocus = (Control )null;
            foreach (Control control in controls)
            {
                isOK &= ok = !string.IsNullOrEmpty(control.Text.Trim());
                if (ok)
                {
                    _errorProvider.SetError(control, string.Empty);
                }
                else
                {
                    _errorProvider.SetError(controlFocus = control, "Campo Requerido");
                }
            }
            if (controlFocus != null)
            {
                Focus(controlFocus);
            }
            return isOK;
        }

        public bool CheckNumericText(params Control[] controls)
        {
            return CheckNumericText(false, controls);
        }

        public bool CheckNumericText(bool isNullable, params Control[] controls)
        {
            var isOK = true;
            var ok = true;
            var value = -1;
            double v = -1;
            var controlFocus = (Control )null;
            foreach (Control control in controls) 
            {
                isOK &= ok = (isNullable && (string.IsNullOrEmpty(control.Text))) || double.TryParse(control.Text, out v) ? true : false;
                if (ok)
                {
                    _errorProvider.SetError(control, string.Empty);
                }
                else
                {
                    _errorProvider.SetError(controlFocus = control, "Campo Requerido");
                }
            }
            if (controlFocus != null)
            {
                Focus(controlFocus);
            }
            return isOK;
        }

        public bool IsValidEmail(string strMailAddress)
        {
            return Regex.IsMatch(strMailAddress, @"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
        }

        public void SetError(Control control, string text)
        {
            _errorProvider.SetError(control, text);
            if (!string.IsNullOrEmpty(text))
            {
                Focus(control);
            }
        }

        public void Focus(Control control)
        {
            if (control == null)
            {
                return;
            }
            var tabPage = GetParentTabPage(control);
            if (tabPage != null && tabPage.Parent != null)
            {
                tabPage.Parent.Select();
                (tabPage.Parent as TabControl).SelectedTab = tabPage;
            }
            control.Select();
        }

        public TabPage GetParentTabPage(Control control)
        {
            TabPage tabPage = null;
            if (control == null)
            {
                return tabPage;
            }
            var controlParent = control;

            while (null != (controlParent = controlParent.Parent))
            {
                if (controlParent is TabPage)
                {
                    tabPage = controlParent as TabPage;
                    break;
                }
            }
            return tabPage;
        }

        public string Hash(string text)
        {
            var encoding = new UnicodeEncoding();
            var bCadena = encoding.GetBytes(text);
            var sha = new SHA1CryptoServiceProvider();
            var bHash = sha.ComputeHash(bCadena);
            return Convert.ToBase64String(bHash);
        }

        public void PermisosEnFormulario(string formulario)
        {
            _moduloPermisos = new Dictionary<int, Permisos>();

            var forma = Model.Formulario.FirstOrDefault(F => F.Forma == formulario);
            var RolId = frmPrincipal.PerfilUsuario.Id;

            var _rolPermiso = Model.PerfilPermisos.Include("Perfil")
                                                                   .Include("FormularioPermisos")
                                                                   .Where(rolPermiso => rolPermiso.PerfilId == RolId &&
                                                                                        rolPermiso.FormularioPermisos.FormularioId == forma.Id).ToList();

            foreach (PerfilPermisos rolPermiso in _rolPermiso)
            {
                if (!rolPermiso.FormularioPermisosReference.IsLoaded)
                {
                    rolPermiso.FormularioPermisosReference.Load();
                }
                if (rolPermiso.FormularioPermisos != null)
                {
                    if (!rolPermiso.FormularioPermisos.PermisosReference.IsLoaded)
                    {
                        rolPermiso.FormularioPermisos.PermisosReference.Load();
                    }
                    _moduloPermisos.Add(rolPermiso.FormularioPermisos.PermisosId, rolPermiso.FormularioPermisos.Permisos);
                }
            }
        }

        public bool TienePermiso(Permisos permiso)
        {
            return _moduloPermisos.ContainsKey(permiso.Id);
        }

        public T GetObjectFromContext<T>(T entity)
            where T: EntityObject
        {
            if (entity == null)
            {
                return null;
            }
            if (entity.EntityState == EntityState.Detached)
            {
                return entity;
            }
            T entityFromContext = null;
            var temp = (object )null;
            entityFromContext = Model.TryGetObjectByKey(entity.EntityKey, out temp) ? temp as T : null;
            return entityFromContext;
        }
        public void txtEnterMoney(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Text = Convert.ToString(tb.Tag);
        }
        private void txtLeaveMoney(object sender, EventArgs e)
        {

            TextBox tb = (TextBox)sender;

            decimal numero = default(decimal);
            bool bln = decimal.TryParse(tb.Text, out numero);

            if ((!(bln)))
            {
                tb.Clear();
                return;
            }
            tb.Tag = numero;
            tb.Text = string.Format("{0:C2}", numero);

        }
    }
}
