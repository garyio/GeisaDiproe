using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace GeisaBD
{
    public partial class Contrarecibo
    {
        public bool NoEsNuevo
        {
            get { return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached; }
        }

        public string ProveedorNombre
        {
            get { return ProveedorLoaded != null ? ProveedorLoaded.NombreFiscal : ""; }
        }

        public string ClienteNombre
        {
            get { return ClienteLoaded != null ? ClienteLoaded.NombreFiscal : ""; }
        }
        public string EmpresaNombre
        {
            get { return EmpresaLoaded != null ? EmpresaLoaded.NombreComercial : ""; }
        }

        public string UsuarioNombre
        {
            get { return ""; }
        }

        #region Properties for EntityReference Load
        public Proveedor ProveedorLoaded { get { return this.Load(ProveedorReference); } }
        public Cliente ClienteLoaded { get { return this.Load(ClienteReference); } }
        public Empresa EmpresaLoaded { get { return this.Load(EmpresaReference); } }
        public Usuario UsuarioLoaded { get { return this.Load(UsuarioReference); } }
        #endregion Properties for EntityReference Load

        public override string ToString()
        {
            return string.Concat(this._Folio);
        }

        public override int GetHashCode()
        {
            return this._Id;
        }

        public override bool Equals(object obj)
        {
            Contrarecibo that = obj as Contrarecibo;
            return that != null && ((this.Id == that.Id && this._Id != 0) || (base.Equals(that)));
        }

        public static bool operator ==(Contrarecibo obj1, Contrarecibo obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(Contrarecibo obj1, Contrarecibo obj2)
        {
            return !(obj1 == obj2);
        }
    }
}
