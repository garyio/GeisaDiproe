using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace GeisaBD
{
    public partial class Empleado
    {
        public bool NoEsNuevo
        {
            get
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
            }
        }

        public string NombreCompleto
        {
            get { return string.Concat(this.Nombre, " ", this.ApPaterno, " ", this.ApMaterno); }
        }

        public string Residente 
        {
            get { return string.Concat(this._Nombre, " ", this._ApPaterno, " ", this._ApMaterno); }
        }

        public string CuentaClabe
        {
            get { return this.EmpleadoNomina.FirstOrDefault() != null ? (string.IsNullOrEmpty(this.EmpleadoNomina.FirstOrDefault().CuentaBanco)?this.EmpleadoNomina.FirstOrDefault().Cable:this.EmpleadoNomina.FirstOrDefault().CuentaBanco) : string.Empty ; }
        }

        public bool EsUsuario
        {
            get
            {
                GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);
                Usuario usuario = model.Usuario.Where(f => f.EmpleadoId == this.Id).FirstOrDefault();
                return usuario != null;
            }
        }

        #region Methods
        public override string ToString()
        {
            return string.Concat(this._Nombre, " ", this._ApPaterno, " ", this._ApMaterno);
        }

        public override int GetHashCode()
        {
            return this._Id;
        }

        public override bool Equals(object obj)
        {
            Empleado that = obj as Empleado;
            return that != null && ((this.Id == that.Id && this._Id != 0) || (base.Equals(that)));
        }

        public static bool operator ==(Empleado obj1, Empleado obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(Empleado obj1, Empleado obj2)
        {
            return !(obj1 == obj2);
        }
        #endregion Methods

    }
}
