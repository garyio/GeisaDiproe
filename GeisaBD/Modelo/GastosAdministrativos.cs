using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GeisaBD
{
    public partial class GastosAdministrativos
    {
        public bool NoEsNuevo
        {
            get
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
            }
        }

        public string Concepto
        {
            get { return ConceptosLoaded.Nombre; }
        }

        #region Properties for EntityReference Load
        public Conceptos ConceptosLoaded { get { return this.Load(ConceptosReference); } }
        #endregion Properties for EntityReference Load

        #region Methods
        public override string ToString()
        {
            return this.Factura;
        }

        public override int GetHashCode()
        {
            return this._Id;
        }

        public override bool Equals(object obj)
        {
            GastosAdministrativos that = obj as GastosAdministrativos;
            return that != null && ((this.Id == that.Id && this._Id != 0) || (base.Equals(that)));
        }

        public static bool operator ==(GastosAdministrativos obj1, GastosAdministrativos obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(GastosAdministrativos obj1, GastosAdministrativos obj2)
        {
            return !(obj1 == obj2);
        }
        #endregion Methods
    }
}
