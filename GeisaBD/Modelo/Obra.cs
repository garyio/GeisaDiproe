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
                    return (PresupuestoDetalle.PPIni_Obra_Civil.Value + PresupuestoDetalle.PPIni_Subcontratistas.Value + PresupuestoDetalle.PPIni_Suministros.Value + PresupuestoDetalle.PPIni_Extras.Value);
                else
                    return 0;
            }
        }

        public double PPFinal
        {
            get
            {
                if (PresupuestoDetalle != null)                        
                            return (PresupuestoDetalle.PPFin_ObraCivil.Value + PresupuestoDetalle.PPFin_Subcontratistas.Value + PresupuestoDetalle.PPFin_Suministros.Value + PresupuestoDetalle.PPFin_Extras.Value);                        
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
