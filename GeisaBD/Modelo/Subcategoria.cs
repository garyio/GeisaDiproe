﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace GeisaBD
{
    public partial class Subcategoria
    {
         public bool NoEsNuevo
        {
            get
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
            }
        }

        #region Methods
        public override string ToString()
        {
            return this._Nombre;
        }

        public override int GetHashCode()
        {
            return this._Id;
        }

        public override bool Equals(object obj)
        {
            Subcategoria that = obj as Subcategoria;
            return that != null && ((this.Id == that.Id && this._Id != 0) || (base.Equals(that)));
        }

        public static bool operator ==(Subcategoria obj1, Subcategoria obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(Subcategoria obj1, Subcategoria obj2)
        {
            return !(obj1 == obj2);
        }
        #endregion Methods
    }    
}
