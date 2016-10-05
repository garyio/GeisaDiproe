using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace GeisaBD
{
    public partial class Nominas
    {
        public bool NoEsNuevo
        {
            get
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
            }
        }

        public double Complemento
        {
            get { return (this.SueldoReal.HasValue ? this.SueldoReal.Value : 0) - (this.SueldoFiscal.HasValue ? this.SueldoFiscal.Value : 0); }
        }

        public double CompensacionCalc
        {
            get { return (this.CompensacionActivo.HasValue ? (this.CompensacionActivo.Value? this.Compensacion.Value: 0): 0); }
        }

        public double ExtrasCalc
        {
            get { return this.NominasDetalle.Where(D => D.TipoCargoId == 1).Select(C => C.Monto).DefaultIfEmpty(0).Sum().Value; }
        }

        public double AdeudosPagosCalc
        {
            get { return this.NominasDetalle.Where(D => D.TipoCargoId == 2).Select(C => C.Monto).DefaultIfEmpty(0).Sum().Value; }
        }

        public double ViaticosCalc
        {
            get { return this.NominasDetalle.Where(D => D.TipoCargoId == 3).Select(C => C.Monto).DefaultIfEmpty(0).Sum().Value + (this.ViaticosActivo.Value ? this.Viaticos.Value : 0); }
        }

        public double FaltasCalc
        {
            get { return this.NominasDetalle.Where(D => D.TipoCargoId == 4).Select(C => C.Monto).DefaultIfEmpty(0).Sum().Value; }
        }

        public double Total
        {
            get { return (this.SueldoReal.HasValue ? this.SueldoReal.Value : 0) + this.ExtrasCalc + this.CompensacionCalc + this.AdeudosPagosCalc + this.FaltasCalc - (this.Infonavit.HasValue ? this.Infonavit.Value : 0) + this.ViaticosCalc; }
        }

        public double calcAsimilados
        {
            get { return (this.Total - this.SueldoFiscal.Value ); }
        }

        public string Banco
        {
            get { return (this.Empleado != null ? (this.Empleado.EmpleadoNomina != null ? this.Empleado.EmpleadoNomina.FirstOrDefault().Bancos.Nombre :  string.Empty) : string.Empty); }
        }

        public string Clabe
        {
            get { return (this.Empleado.EmpleadoNomina != null ? this.Empleado.EmpleadoNomina.FirstOrDefault().Cable : string.Empty); }
        }

        public string Cuenta
        {
            get { return (this.Empleado.EmpleadoNomina != null ? this.Empleado.EmpleadoNomina.FirstOrDefault().CuentaBanco : string.Empty); }
        }

        public string Curp
        {
            get { return (this.Empleado.EmpleadoNomina != null ? this.Empleado.EmpleadoNomina.FirstOrDefault().Curp : string.Empty); }
        }

        public string Rfc
        {
            get { return (this.Empleado.EmpleadoNomina != null ? this.Empleado.EmpleadoNomina.FirstOrDefault().Rfc : string.Empty); }
        }

        public string Puesto
        {
            get {
                try
                {
                    EmpleadoNomina nomina = (this.Empleado.EmpleadoNomina != null ? this.Empleado.EmpleadoNomina.FirstOrDefault() :  null);
                    EmpleadoHistorial historial = (nomina != null ? nomina.EmpleadoHistorial.Where(H => H.FechaFin == null).FirstOrDefault() : null);
                    using (GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString))
                    {
                        return (model.Dpto_Puesto.Where(D => D.Id == historial.Puesto.Value).FirstOrDefault().Nombre);
                    }
                }
                catch (Exception ex)
                {
                    return string.Empty;
                }
            }
        }
                
        public static bool operator ==(Nominas obj1, Nominas obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(Nominas obj1, Nominas obj2)
        {
            return !(obj1 == obj2);
        }
    }
}
