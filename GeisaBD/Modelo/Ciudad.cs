using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace GeisaBD
{
    public partial class Ciudad
    {
        public bool NoEsNuevo
        {
            get
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
            }
        }

        public string EstadoNombre
        {
            get { return EstadoLoaded.Nombre; }
        }

        #region Properties for EntityReference Load
        public Estado EstadoLoaded { get { return this.Load(EstadoReference); } }
        #endregion Properties for EntityReference Load

        #region Methods
        public override string ToString()
        {
            return this._Nombre;
        }

        public override int GetHashCode()
        {
            return this._Id;
        }

        public override bool Equals(object obj)
        {
            Ciudad that = obj as Ciudad;
            return that != null && ((this.Id == that.Id && this._Id != 0) || (base.Equals(that)));
        }

        public static bool operator ==(Ciudad obj1, Ciudad obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(Ciudad obj1, Ciudad obj2)
        {
            return !(obj1 == obj2);
        }
        #endregion Methods
    }
}
