using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace GeisaBD
{
    public partial class Pagos
    {
        public bool NoEsNuevo
        {
            get
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
            }
        }

        public string ProveedorNombre
        {
            get {           
                if(ProveedorLoaded != null)
                    return ProveedorLoaded.NombreComercial; 
                else
                    return ClienteLoaded != null ? ClienteLoaded.NombreComercial : ""; 
            }
        }

        public string ProveedorNombreFiscal
        {
            

            get {
                if (ProveedorLoaded != null)
                    return ProveedorLoaded.NombreFiscal;
                else
                    return ClienteLoaded != null ? ClienteLoaded.NombreFiscal : ""; 
            }
        }

        public string EmpresaNombre
        {
            get { return EmpresaLoaded != null ? EmpresaLoaded.NombreComercial : ""; }
        }

        public string BeneficiarioNombre
        {
            get
            {
                if (this.CajaChicaPrestamo!=null)
                    return this.CajaChicaPrestamo.BeneficiarioNombre;
                else
                    return string.Empty;
            }
        }

        public double Cargo
        {
            get
            {
                if (this.TipoMovimientoId == TipoMovimientoEnum.Prestamos.Id)
                    return this.MontoPagar.Value;
                else
                    return 0;
            }
        }

        public double Abono
        {
            get
            {
                if (this.TipoMovimientoId == TipoMovimientoEnum.Abonos.Id)
                    return this.MontoPagar.Value;
                else
                    return 0;
            }
        }

        public double Total
        {
            get
            {
                    return this.Load(PagosFactura).Sum(T => T.MontoPagar);
            }
        }

        //public double Total
        //{
        //    get
        //    {
        //        return (this.Cargo - this.Abono);
        //    }
        //}

        public bool calculaGA
        {
            
            get{
                if (!this.calcGA.HasValue)
                {
                    foreach (PagosFactura fact in this.PagosFactura.ToList())
                    {
                        if (fact.Factura.GastoAdm.HasValue)
                        {
                            if (fact.Factura.GastoAdm.Value)
                                return true;
                        }
                    }
                    return false;
                }
                else
                {
                    return this.calcGA.Value;
                }
            }
        }

        public bool calculaGC
        {
            get
            {
                if (!this.calcGC.HasValue)
                {
                    foreach (PagosFactura fact in this.PagosFactura.ToList())
                    {
                        if (fact.Factura.Compartido.HasValue)
                        {
                            if (fact.Factura.Compartido.Value)
                                return true;
                        }
                    }
                    return false;
                }
                else
                {
                    return this.calcGC.Value;
                }
            }
        }

        public string TipoPagoNombre
        {
            get { return TipoPagoLoaded!=null? TipoPagoLoaded.Nombre: string.Empty; }
        }

        public string BancosNombre
        {
            get { return EmpresaBancosLoaded != null ? EmpresaBancosLoaded.NombreBanco : ""; }
        }

        public string Referencias
        {
            get { return Consecutivo.HasValue ? Consecutivo.Value.ToString() :  Referencia; }
        }

        public double Diferencia
        {
            get
            {
                return this.MontoPagar.HasValue ? Math.Round((this.MontoPagar.Value - Total),2) : Math.Round(0 - Total,2);
            }
        }
        public string EmpleadoNombre
        {
            get { return EmpleadoLoaded!=null? EmpleadoLoaded.NombreCompleto:string.Empty; }
        }

        #region Properties for EntityReference Load
        public Proveedor ProveedorLoaded { get { return this.Load(ProveedorReference); } }
        public Cliente ClienteLoaded { get { return this.Load(ClienteReference); } }
        public Empresa EmpresaLoaded { get { return this.Load(EmpresaReference); } }
        public TipoPago TipoPagoLoaded { get { return this.Load(TipoPagoReference); } }
        public EmpresaBancos EmpresaBancosLoaded { get { return this.Load(EmpresaBancosReference); } }
        public Usuario UsuarioLoaded { get { return this.Load(UsuarioReference); } }
        public Empleado EmpleadoLoaded { get { return this.Load(EmpleadoReference); } }
        #endregion Properties for EntityReference Load

        #region Methods
        public override string ToString()
        {
            return string.Concat(this._Folio, " ", this.Empresa.NombreComercial);
        }

        public override int GetHashCode()
        {
            return this._Id;
        }

        public override bool Equals(object obj)
        {
            Pagos that = obj as Pagos;
            return that != null && ((this.Id == that.Id && this._Id != 0) || (base.Equals(that)));
        }

        public static bool operator ==(Pagos obj1, Pagos obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(Pagos obj1, Pagos obj2)
        {
            return !(obj1 == obj2);
        }
        #endregion Methods
    }
}
