using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace GeisaBD
{
    public partial class CajaChica
    {
        public bool NoEsNuevo
        {
            get
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
            }
        }

        public string NombreResidente
        {
            get { return EmpleadoLoaded.Nombre + " " + EmpleadoLoaded.ApPaterno + " " + EmpleadoLoaded.ApMaterno; }
        }

        #region Properties for EntityReference Load
        public Empleado EmpleadoLoaded { get { return this.Load(EmpleadoReference); } }
        #endregion Properties for EntityReference Load

        #region Methods
        public override string ToString()
        {
            return this.NombreResidente + " " + this.Fecha;
        }

        public override int GetHashCode()
        {
            return this._Id;
        }

        public override bool Equals(object obj)
        {
            CajaChica that = obj as CajaChica;
            return that != null && ((this.Id == that.Id && this._Id != 0) || (base.Equals(that)));
        }

        public static bool operator ==(CajaChica obj1, CajaChica obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(CajaChica obj1, CajaChica obj2)
        {
            return !(obj1 == obj2);
        }
        #endregion Methods
    }
}
