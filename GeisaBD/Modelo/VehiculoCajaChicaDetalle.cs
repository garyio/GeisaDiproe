using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GeisaBD
{
    public partial class VehiculoCajaChicaDetalle
    {
        GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);
        public bool NoEsNuevo
        {
            get
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
            }
        }

        public double DiferenciaKm { 
            get {
                double ultimoKilometraje = model.VehiculoCajaChicaDetalle.Where(V => V.KilometrosRecorridos != null && V.KilometrosRecorridos > 0 && V.Fecha < this.Fecha).Select(S => S.KilometrosRecorridos).Max() != null ? model.VehiculoCajaChicaDetalle.Where(V => V.KilometrosRecorridos != null && V.KilometrosRecorridos > 0 && V.Fecha < this.Fecha).Select(S => S.KilometrosRecorridos).Max().Value : 0;
                //VehiculoCajaChicaDetalle ultimosKm = controler.Model.VehiculoCajaChicaDetalle.Where(D=> D.VehiculoCajaChicaId == VehiculoCajaChica.Id).OrderByDescending(O => O.Fecha).ToList();
                if (this.KilometrosRecorridos.HasValue)
                {
                    if (ultimoKilometraje == 0)
                        return 0;
                    return this.KilometrosRecorridos.Value - ultimoKilometraje;
                }
                else
                    return 0;               
            }
        }
        public string TipoDepositoNombre
        {
            get
            {
                if (this.TipoDeposito == 1)
                    return "EFECTIVO";
                else if (this.TipoDeposito == 2)
                    return "TICKET CAR";
                else if (this.TipoDeposito == 3)
                    return "VALES";
                else
                    return string.Empty;
                
            }
        }

        public string ObraNombre
        {
            get
            {
                if (this.Obra != null)
                    return this.Obra.Nombre;
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
                    return this.VehiculoCajaChica.Conductor;
            }

        }
    }
}
