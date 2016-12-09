using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace GeisaBD
{
    public partial class Factura
    {
        public bool NoEsNuevo
        {
            get 
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
            }
        }

        public string NombreProveedor
        {
            get { return ProveedorLoaded == null ? ProveedorOtro : ProveedorLoaded.NombreFiscal; }
        }

        public string ObraNombre
        {
            get { return ObraLoaded == null ? "" : ObraLoaded.Nombre; }
        }

        #region Properties for EntityReference Load
        public Proveedor ProveedorLoaded { get { return this.Load(ProveedorReference); } }
        public Contrarecibo ContrareciboLoaded { get { return this.Load(ContrareciboReference); } }
        public ReposicionGastos ReposicionLoaded { get { return this.Load(ReposicionGastosReference); } }

        public Obra ObraLoaded { get { return this.Load(ObraReference); } }
        #endregion Properties for EntityReference Load

        #region Methods
        public override string ToString()
        {
            return string.Concat(this.NoFactura);
        }

        public override int GetHashCode()
        {
            return this._Id;
        }

        public override bool Equals(object obj)
        {
            Factura that = obj as Factura;
            return that != null && ((this.Id == that.Id && this._Id != 0) || (base.Equals(that)));
        }

        public static bool operator ==(Factura obj1, Factura obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(Factura obj1, Factura obj2)
        {
            return !(obj1 == obj2);
        }
        #endregion Methods


    }
}
