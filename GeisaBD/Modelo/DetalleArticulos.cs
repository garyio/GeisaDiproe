﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace GeisaBD
{
    public partial class DetalleArticulos
    {
        public bool NoEsNuevo
        {
            get
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
            }
        }

        #region Methods

        public override int GetHashCode()
        {
            return this._Id;
        }

        public override bool Equals(object obj)
        {
            DetalleArticulos that = obj as DetalleArticulos;
            return that != null && ((this.Id == that.Id && this._Id != 0) || (base.Equals(that)));
        }

        public static bool operator ==(DetalleArticulos obj1, DetalleArticulos obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(DetalleArticulos obj1, DetalleArticulos obj2)
        {
            return !(obj1 == obj2);
        }
        #endregion Methods

    }
}
