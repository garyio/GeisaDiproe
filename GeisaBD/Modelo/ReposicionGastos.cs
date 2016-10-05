using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GeisaBD
{
    public partial class ReposicionGastos
    {
        public bool NoEsNuevo
        {
            get
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
            }
        }

        public string EmpleadoNombre
        {
            get { return EmpleadoLoaded.NombreCompleto; }
        }

        public string EmpresaNombre
        {
            get { return EmpresaLoaded.NombreComercial; }
        }

        public string TipoPagoNombre
        {
            get { return TipoPagoLoaded.Nombre; }
        }

        public string BancosNombre
        {
            get { return EmpresaBancosLoaded != null ? EmpresaBancosLoaded.NombreBanco : ""; }
        }

        public string Referencias
        {
            get { return Consecutivo.HasValue ? Consecutivo.ToString() : Referencia; }
        }

        public double Total
        {
            get
            {
                return this.Load(Factura).Sum(F => F.Importe);
            }
        }

        #region Properties for EntityReference Load
        public Empleado EmpleadoLoaded { get { return this.Load(EmpleadoReference); } }
        public Empresa EmpresaLoaded { get { return this.Load(EmpresaReference); } }
        public TipoPago TipoPagoLoaded { get { return this.Load(TipoPagoReference); } }
        public EmpresaBancos EmpresaBancosLoaded { get { return this.Load(EmpresaBancosReference); } }
        public Usuario UsuarioLoaded { get { return this.Load(UsuarioReference); } }
        #endregion Properties for EntityReference Load

        #region Methods
        public override string ToString()
        {
            return this._Folio.ToString();
        }

        public override int GetHashCode()
        {
            return this._Id;
        }

        public override bool Equals(object obj)
        {
            ReposicionGastos that = obj as ReposicionGastos;
            return that != null && ((this.Id == that.Id && this._Id != 0) || (base.Equals(that)));
        }

        public static bool operator ==(ReposicionGastos obj1, ReposicionGastos obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(ReposicionGastos obj1, ReposicionGastos obj2)
        {
            return !(obj1 == obj2);
        }
        #endregion Methods
    }
}
