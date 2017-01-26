using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace GeisaBD
{
    public partial class PagosFactura
    {
        public bool NoEsNuevo
        {
            get
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
            }
        }
        
        public string NoFactura
        {
            get { return FacturaLoaded.NoFactura; }
        }

        public DateTime Fecha
        {
            get { return FacturaLoaded.Fecha; }
        }

        public string Observaciones
        {
            get { return FacturaLoaded.Observaciones; }
        }

        public double Importe
        {
            get { return FacturaLoaded.Importe; }
        }
        public double SaldoFinal
        {
            get {
                if (Factura.tipoComprobante != null)
                {
                    if (Factura.tipoComprobante.Value == 2) // es una NC desde comprobantes
                        return this.SaldoActual - Math.Abs(this.MontoPagar);
                    else
                        return this.SaldoActual - this.MontoPagar; 
                }
                return this.SaldoActual - this.MontoPagar; 
            }
        }
        public Proveedor Proveedor
        {
            get { return FacturaLoaded.Proveedor; }
        }

        #region Properties for EntityReference Load
        public Factura FacturaLoaded { get { return this.Load(FacturaReference); } }

        #endregion


        #region Methods
        public override string ToString()
        {
            return string.Concat(this._Id);
        }

        public override int GetHashCode()
        {
            return this._Id;
        }

        public override bool Equals(object obj)
        {
            PagosFactura that = obj as PagosFactura;
            return that != null && ((this.Id == that.Id && this._Id != 0) || (base.Equals(that)));
        }

        public static bool operator ==(PagosFactura obj1, PagosFactura obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(PagosFactura obj1, PagosFactura obj2)
        {
            return !(obj1 == obj2);
        }
        #endregion Methods
    }
}
