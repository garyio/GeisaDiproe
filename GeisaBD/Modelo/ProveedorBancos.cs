﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace GeisaBD
{
    public partial class ProveedorBancos
    {
        public bool NoEsNuevo
        {
            get
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
            }
        }

        public string NombreProveedor
        {
            get { return ProveedorLoaded.NombreComercial; }
        }
        public string NombreBanco
        {
            get { return BancosLoaded.Nombre; }
        }

        #region Properties for EntityReference Load
        public Proveedor ProveedorLoaded { get { return this.Load(ProveedorReference); } }
        public Bancos BancosLoaded { get { return this.Load(BancosReference); } }
        #endregion Properties for EntityReference Load

        #region Methods
        public override string ToString()
        {
            return string.Concat(this.NombreProveedor, " - ", this.NombreBanco);
        }

        public override int GetHashCode()
        {
            return this._Id;
        }

        public override bool Equals(object obj)
        {
            ProveedorBancos that = obj as ProveedorBancos;
            return that != null && ((this.Id == that.Id && this._Id != 0) || (base.Equals(that)));
        }

        public static bool operator ==(ProveedorBancos obj1, ProveedorBancos obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(ProveedorBancos obj1, ProveedorBancos obj2)
        {
            return !(obj1 == obj2);
        }
        #endregion Methods
    }
}
