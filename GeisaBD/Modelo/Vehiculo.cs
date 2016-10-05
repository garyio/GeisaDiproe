using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace GeisaBD
{
    public partial class Vehiculo
    {
        public bool NoEsNuevo
        {
            get
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
            }
        }

        #region Methods

        public string NombreEmpresa
        {
            get
            {
                if (this.Empresa != null)
                    return this.Empresa.NombreFiscal;
                else
                    return string.Empty;
            }

        }

        public string Conductor
        {
            get
            {
                if (this.Empleado != null)
                    return this.Empleado.NombreCompleto;
                else
                    return string.Empty;
            }

        }

        public string MarcaSubMarca
        {
            get
            {
                return this.Marca + " " + this.SubMarca;
            }

        }

        public string VehiculoCompleto
        {
            get
            {
                return this.Marca + " " + this.SubMarca + " " + this.Modelo + " " + (this.Conductor);
            }

        }
        public override string ToString()
        {
            return string.Concat(this.Placas, this.Marca, this.Modelo);
        }

        public override int GetHashCode()
        {
            return this._Id;
        }

        public override bool Equals(object obj)
        {
            Vehiculo that = obj as Vehiculo;
            return that != null && ((this.Id == that.Id && this._Id != 0) || (base.Equals(that)));
        }

        public static bool operator ==(Vehiculo obj1, Vehiculo obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(Vehiculo obj1, Vehiculo obj2)
        {
            return !(obj1 == obj2);
        }
        #endregion Methods
    }
}
