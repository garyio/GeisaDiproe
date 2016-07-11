using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace GeisaBD
{
    public partial class CajaChicaPrestamo
    {
        GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);  
        public bool NoEsNuevo
        {
            get
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
            }
        }

        public string BeneficiarioNombre
        {
            get{
                return model.Empresa.Where(E => E.Id == this.BeneficiarioId).FirstOrDefault().NombreFiscal;
                //return this.Empresa1.NombreFiscal;
            }
        }

        public double Abono
        {
            get
            {
                return this.Load(Pagos).Where(P => P.TipoMovimientoId == TipoMovimientoEnum.Abonos.Id).Sum(T => T.MontoPagar).Value;
            }
        }

        public double Prestamo
        {
            get
            {
                return this.Load(Pagos).Where(P => P.TipoMovimientoId == TipoMovimientoEnum.Prestamos.Id).Sum(T => T.MontoPagar).Value;
            }
        }

        public double Total
        {
            get
            {
                return (this.Prestamo - this.Abono);
            }
        }

        public string EmpresaNombre
        {
            get
            {
                return model.Empresa.Where(E => E.Id == this.EmpresaId).FirstOrDefault().NombreComercial;
                //return this.Empresa.NombreComercial;
            }
        }



        #region Methods

        public override int GetHashCode()
        {
            return this._Id;
        }

        public override bool Equals(object obj)
        {
            CajaChicaPrestamo that = obj as CajaChicaPrestamo;
            return that != null && ((this.Id == that.Id && this._Id != 0) || (base.Equals(that)));
        }

        public static bool operator ==(CajaChicaPrestamo obj1, CajaChicaPrestamo obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(CajaChicaPrestamo obj1, CajaChicaPrestamo obj2)
        {
            return !(obj1 == obj2);
        }
        #endregion Methods
    }
    }
