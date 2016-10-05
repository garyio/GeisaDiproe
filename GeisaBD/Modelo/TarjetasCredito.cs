using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace GeisaBD
{
    public partial class TarjetasCredito
    {
        public bool NoEsNuevo
        {
            get
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
            }
        }

        public string Nombre_y_Tarjeta
        {
            get
            {
                return this.Empleado.Nombre + " " + this.Empleado.ApPaterno + " - " + (this.NumeroCuenta.HasValue ? (NumeroCuenta.Value.ToString().Substring(NumeroCuenta.Value.ToString().Length - 4)) : (this.NumeroTarjeta.Value.ToString().Substring(this.NumeroTarjeta.Value.ToString().Length - 4)));
            }
        }

        #region Methods
        public override int GetHashCode()
        {
            return this._Id;
        }

        public override bool Equals(object obj)
        {
            TarjetasCredito that = obj as TarjetasCredito;
            return that != null && ((this.Id == that.Id && this._Id != 0) || (base.Equals(that)));
        }

        public static bool operator ==(TarjetasCredito obj1, TarjetasCredito obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(TarjetasCredito obj1, TarjetasCredito obj2)
        {
            return !(obj1 == obj2);
        }
        #endregion Methods
    }
    }

