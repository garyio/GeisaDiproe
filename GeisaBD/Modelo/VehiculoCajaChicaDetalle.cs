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
        public bool NoEsNuevo
        {
            get
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
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
    }
}
