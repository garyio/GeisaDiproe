using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GeisaBD
{
    public partial class CajaChicaDetalle
    {
        public bool NoEsNuevo
        {
            get
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
            }
        }
        public string checarReferenciaEmpresa()
        {
            if (EmpresaLoaded == null)
            {
                return "";
            }
            else 
            {
                return EmpresaLoaded.NombreComercial;
            }
        }

        public string checarReferenciaObra()
        {
            if (ObraLoaded == null)
            {
                return "";
            }
            else
            {
                return ObraLoaded.Nombre;
            }
        }
        public string checarRefTipoPago()
        {
            if (TipoPagoLoaded == null)
            {
                return "";
            }
            else
            {
                return TipoPagoLoaded.Nombre;
            }
        }

        public string EmpresaNombre
        {            
            get { return checarReferenciaEmpresa(); }
        }
        public string ObraNombre
        {
            get { return checarReferenciaObra(); }
        }
        public string TipoPagoNombre
        {
            get { return checarRefTipoPago(); }
        }
        #region Properties for EntityReference Load
        public Empresa EmpresaLoaded { get { return this.Load(EmpresaReference); } }
        public Obra ObraLoaded { get { return this.Load(ObraReference); } }
        public TipoPago TipoPagoLoaded { get { return this.Load(TipoPagoReference); } }

        #endregion Properties for EntityReference Load

        #region Methods
        public double Total {
            get {
                double deposito= this.Deposito.HasValue ? Convert.ToDouble(this.Deposito) : 0;
                double Nominas = this.Nominas.HasValue ? Convert.ToDouble(this.Nominas) : 0;
                double NoDeducibles = this.NoDeducibles.HasValue ? Convert.ToDouble(this.NoDeducibles) : 0;
                double Facturas = this.Facturas.HasValue ? Convert.ToDouble(this.Facturas) : 0;
                double viaticos = this.Biaticos.HasValue ? Convert.ToDouble(this.Biaticos) : 0;
                double devolucion = this.Devolucion.HasValue ? Convert.ToDouble(this.Devolucion) : 0;
                return (deposito + Nominas + NoDeducibles + Facturas+ viaticos) - devolucion; 
            }
        }

        public string ObservacionesConcatenadasCalc
        {
            get
            {
                if (string.IsNullOrEmpty(this.ObservacionesConcatenadas))
                {
                    string observacion = string.IsNullOrEmpty(this.Observaciones) ? string.Empty : this.Observaciones.ToUpper() ;
                    foreach (CajaChicaComprobante comprobante in this.CajaChicaComprobante.ToList())
                    {
                        if(!string.IsNullOrEmpty(comprobante.Observaciones))
                            observacion = observacion + (string.IsNullOrEmpty(observacion) ? "" : Environment.NewLine) + comprobante.Observaciones.ToUpper();
                    }
                    return observacion.Trim('\r').Trim('\n');
                }
                else
                {
                    return this.ObservacionesConcatenadas.Trim('\r').Trim('\n');
                }
            }
        }

        public override string ToString()
        {
            return this.CajaChica.Empleado.Nombre;
        }

        public override int GetHashCode()
        {
            return this._Id;
        }

        public override bool Equals(object obj)
        {
            CajaChicaDetalle that = obj as CajaChicaDetalle;
            return that != null && ((this.Id == that.Id && this._Id != 0) || (base.Equals(that)));
        }

        public static bool operator ==(CajaChicaDetalle obj1, CajaChicaDetalle obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(CajaChicaDetalle obj1, CajaChicaDetalle obj2)
        {
            return !(obj1 == obj2);
        }
        #endregion Methods
    }
}
