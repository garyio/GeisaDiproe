using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace GeisaBD
{
    public partial class Obra
    {
        public bool NoEsNuevo
        {
            get { return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached; }
        }

        public double PPInicial
        {
            get
            {
                if (PresupuestoDetalle != null)
                    return ( (PresupuestoDetalle.PPIni_Obra_Civil!= null ? PresupuestoDetalle.PPIni_Obra_Civil.Value : 0) 
                        + (PresupuestoDetalle.PPIni_Subcontratistas != null ? PresupuestoDetalle.PPIni_Subcontratistas.Value : 0) 
                        + (PresupuestoDetalle.PPIni_Suministros!=null ? PresupuestoDetalle.PPIni_Suministros.Value : 0)
                        + (PresupuestoDetalle.PPIni_Extras!= null ? PresupuestoDetalle.PPIni_Extras.Value : 0)
                        + (PresupuestoDetalle.PPIni_Mantenimiento!=null ? PresupuestoDetalle.PPIni_Mantenimiento.Value : 0)
                        + (PresupuestoDetalle.PPIni_NA!= null ? PresupuestoDetalle.PPIni_NA.Value : 0)
                        - (PresupuestoDetalle.PPIni_Descuento!= null ? PresupuestoDetalle.PPIni_Descuento.Value : 0)
                        );
                else
                    return 0;
            }
        }

        public double PPFinal
        {
            get
            {
                if (PresupuestoDetalle != null)
                    return ( (PresupuestoDetalle.PPFin_ObraCivil!= null ? PresupuestoDetalle.PPFin_ObraCivil.Value : 0)
                        + (PresupuestoDetalle.PPFin_Subcontratistas!=null ? PresupuestoDetalle.PPFin_Subcontratistas.Value : 0)
                        + (PresupuestoDetalle.PPFin_Suministros!= null ? PresupuestoDetalle.PPFin_Suministros.Value : 0)
                        + (PresupuestoDetalle.PPFin_Extras!= null ? PresupuestoDetalle.PPFin_Extras.Value : 0)
                        + (PresupuestoDetalle.PPFin_Mantenimiento != null ? PresupuestoDetalle.PPFin_Mantenimiento.Value : 0)
                        + (PresupuestoDetalle.PPFin_NA!=null ? PresupuestoDetalle.PPFin_NA.Value : 0)
                        - (PresupuestoDetalle.PPFin_Descuento!=null ? PresupuestoDetalle.PPFin_Descuento.Value : 0)
                        );                        
                else
                    return 0;
            }
        }


        public override string ToString()
        {
            return string.Concat(this._Nombre);
        }

        public override int GetHashCode()
        {
            return this._Id;
        }

        public override bool Equals(object obj)
        {
            Obra that = obj as Obra;
            return that != null && ((this.Id == that.Id && this._Id != 0) || (base.Equals(that)));
        }

        public static bool operator ==(Obra obj1, Obra obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(Obra obj1, Obra obj2)
        {
            return !(obj1 == obj2);
        }
    }
}
