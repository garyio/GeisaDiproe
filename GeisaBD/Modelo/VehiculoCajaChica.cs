using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GeisaBD
{
    public partial class VehiculoCajaChica
    {
        public bool NoEsNuevo
        {
            get
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
            }
        }

        public string NombreEmpresa
        {
            get
            {
                return VehiculoLoaded.NombreEmpresa;
            }

        }

        public string Conductor
        {
            get
            {
                return VehiculoLoaded.Conductor;
            }

        }

        public double Total
        {
            get
            {
                return this.Load(VehiculoCajaChicaDetalle).Sum(T => T.Importe.Value);
            }
        }

        public string MarcaSubMarca
        {
            get
            {
                return VehiculoLoaded.MarcaSubMarca;
            }

        }
        

        public string Placas
        {
            get { return VehiculoLoaded.Placas; }
        }

        public string Marca
        {
            get { return VehiculoLoaded.Marca; }
        }

        public string Modelo
        {
            get { return VehiculoLoaded.Modelo; }
        }
        #region Properties for EntityReference Load
        public Vehiculo VehiculoLoaded { get { return this.Load(VehiculoReference); } }
        

        #endregion Properties for EntityReference Load

        #region Methods
        public override string ToString()
        {
            return this.Vehiculo.Placas;
        }

        public override int GetHashCode()
        {
            return this._Id;
        }

        public override bool Equals(object obj)
        {
            VehiculoCajaChica that = obj as VehiculoCajaChica;
            return that != null && ((this.Id == that.Id && this._Id != 0) || (base.Equals(that)));
        }

        public static bool operator ==(VehiculoCajaChica obj1, VehiculoCajaChica obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(VehiculoCajaChica obj1, VehiculoCajaChica obj2)
        {
            return !(obj1 == obj2);
        }
        #endregion Methods
    }
}
