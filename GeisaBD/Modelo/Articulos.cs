using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace GeisaBD
{
    public partial class Articulos
    {
        public bool NoEsNuevo
        {
            get
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
            }
        }

        public double? existenciaTotal
        {
            get
            {
                    GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);
                    return model.getExistencia(this.Id).FirstOrDefault().Value;
            }
        }

        public string EmpresaNombre
        {
            get
            {
                if (this.Empresa != null)
                    return this.Empresa.NombreComercial;
                else
                    return string.Empty;
            }
        }

        public string SubcategoriaNombre
        {
            get
            {
                if (this.Subcategoria != null)
                    return this.Subcategoria.Nombre;
                else
                    return string.Empty;
            }
        }

        public string ProveedorNombre
        {
            get
            {
                if (this.Proveedor != null)
                    return this.Proveedor.NombreComercial;
                else
                    return string.Empty;
            }
        }

        public string UnidadNombre
        {
            get
            {
                if (this.UnidadMedida != null)
                    return this.UnidadMedida.Nombre;
                else
                    return string.Empty;
            }
        }



        #region Methods
        public override string ToString()
        {
            return this._Descripcion;
        }

        public override int GetHashCode()
        {
            return this._Id;
        }

        public override bool Equals(object obj)
        {
            Articulos that = obj as Articulos;
            return that != null && ((this.Id == that.Id && this._Id != 0) || (base.Equals(that)));
        }

        public static bool operator ==(Articulos obj1, Articulos obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(Articulos obj1, Articulos obj2)
        {
            return !(obj1 == obj2);
        }
        #endregion Methods
    }
}
