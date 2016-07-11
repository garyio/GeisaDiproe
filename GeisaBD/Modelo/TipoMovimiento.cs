using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace GeisaBD
{
    public partial class TipoMovimiento
    {
        public bool NoEsNuevo
        {
            get
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
            }
        }


        #region Methods
        public override string ToString()
        {
            return this._Movimiento;
        }

        public override int GetHashCode()
        {
            return this._Id;
        }

        public override bool Equals(object obj)
        {
            TipoMovimiento that = obj as TipoMovimiento;
            return that != null && ((this.Id == that.Id && this._Id != 0) || (base.Equals(that)));
        }

        public static bool operator ==(TipoMovimiento obj1, TipoMovimiento obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(TipoMovimiento obj1, TipoMovimiento obj2)
        {
            return !(obj1 == obj2);
        }
        #endregion Methods
    }
}
