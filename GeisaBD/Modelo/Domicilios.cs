using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace GeisaBD
{
    public partial class Domicilios
    {
        public bool NoEsNuevo
        {
            get
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
            }
        }

        public string CiudadNombre
        {
            get { return CiudadLoaded.Nombre; }
        }

        public string EstadoNombre
        {
            get { return CiudadLoaded.Nombre; }
        }

        #region Properties for EntityReference Load
        public Ciudad CiudadLoaded { get { return this.Load(CiudadReference); } }
        #endregion Properties for EntityReference Load

        #region Methods
        public override string ToString()
        {
            return string.Concat(this._Calle, " ", this._Exterior, string.IsNullOrEmpty(this._Interior) ? "" : " " + this._Interior);
        }

        public override int GetHashCode()
        {
            return this._Id;
        }

        public override bool Equals(object obj)
        {
            Domicilios that = obj as Domicilios;
            return that != null && ((this.Id == that.Id && this._Id != 0) || (base.Equals(that)));
        }

        public static bool operator ==(Domicilios obj1, Domicilios obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(Domicilios obj1, Domicilios obj2)
        {
            return !(obj1 == obj2);
        }
        #endregion Methods
    }
}
