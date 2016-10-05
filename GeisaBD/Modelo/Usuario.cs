using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;


namespace GeisaBD
{
    public partial class Usuario
    {
        public bool NoEsNuevo
        {
            get
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
            }
        }

        public string PerfilNombre
        {
            get { return PerfilLoaded.Nombre; }
        }

        public string EmpleadoNombre
        {
            get { return EmpleadoLoaded == null ? this.Login : EmpleadoLoaded.ToString(); }
        }

        #region Properties for EntityReference Load
        public Perfil PerfilLoaded { get { return this.Load(PerfilReference); } }
        public Empleado EmpleadoLoaded { get { return this.Load(EmpleadoReference); } }
        #endregion Properties for EntityReference Load

        #region Methods
        public override string ToString()
        {
            return this._Login;
        }

        public override int GetHashCode()
        {
            return this._Id;
        }

        public override bool Equals(object obj)
        {
            Usuario that = obj as Usuario;
            return that != null && ((this.Id == that.Id && this._Id != 0) || (base.Equals(that)));
        }

        public static bool operator ==(Usuario obj1, Usuario obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(Usuario obj1, Usuario obj2)
        {
            return !(obj1 == obj2);
        }
        #endregion Methods

    }
}
