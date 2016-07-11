using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace GeisaBD
{
    public partial class Ordenes
    {
        GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);

        public bool NoEsNuevo
        {
            get
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
            }
        }

        public string EmpresaNombre
        {
            get { return this.Empresa != null ? Empresa.NombreComercial : ""; }
        }

        public string ProveedorNombre
        {
            get { return this.Proveedor != null ? Proveedor.NombreComercial : ""; }
        }

        public string EmpleadoSolicito
        {
            get { return this.Empleado != null ? Empleado.NombreCompleto : ""; }
        }

        public string CompradorNombre
        {
            get { return this.CompradorId != null ? model.Empleado.FirstOrDefault(E=>E.Id==CompradorId).NombreCompleto : ""; }
        }

        public string TipoMovimientoNombre
        {
            get {
                    if (this.TipoMovimientoId == TipoMovimientoEnum.OrdenCompra.Id)
                        return "ORDEN COMPRA";
                    else if (this.TipoMovimientoId == TipoMovimientoEnum.SalidaAlmacen.Id)
                        return "SALIDA ALMACEN";
                    else
                        return string.Empty;
            }
        }

        //public double Total
        //{
        //    get
        //    {
        //        return this.Load(DetalleArticulos).Sum(T => T.Costo * T.Cantidad);
        //    }
        //}

        public string ObraNombre
        {
            get { return this.Obra != null ? this.Obra.Nombre : ""; }
        }

        #region Methods

        public override int GetHashCode()
        {
            return this._Id;
        }

        public override bool Equals(object obj)
        {
            Ordenes that = obj as Ordenes;
            return that != null && ((this.Id == that.Id && this._Id != 0) || (base.Equals(that)));
        }

        public static bool operator ==(Ordenes obj1, Ordenes obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(Ordenes obj1, Ordenes obj2)
        {
            return !(obj1 == obj2);
        }
        #endregion Methods
    }
}
