﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace GeisaBD
{
    public partial class Empresa
    {
        public bool NoEsNuevo
        {
            get
            {
                return this.EntityState != EntityState.Added && this.EntityState != EntityState.Detached;
            }
        }


        Domicilios _domicilio { get; set; }
        public Domicilios Domicilio
        {
            get
            {
                if (_domicilio != null) return _domicilio;
                using (GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString))
                {
                    return _domicilio = model.Domicilios.Include("Ciudad")
                                                        .Include("Ciudad.Estado")
                                                        .FirstOrDefault(D => D.Tipo == TipoCatalogo.EMPRESA &&
                                                                             D.CatalogoId == this.Id);
                }
            }
        }

        //Domicilios _banco { get; set; }

        //public Domicilios Banco
        //{
        //    get
        //    {
        //        if (_banco != null) return _banco;
        //        using (GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString))
        //        {
        //            return _domicilio = model.Domicilios.FirstOrDefault(D => D.Tipo == TipoCatalogo.EMPRESA 
        //                                                                && D.CatalogoId == this.Id);
        //        }
        //    }
        //}

        public string Direccion
        {
            get
            {
                return Domicilio != null ? string.Concat(Domicilio.Calle, " ", Domicilio.Exterior, (string.IsNullOrEmpty(Domicilio.Interior) ? "" : " " + Domicilio.Interior), " ", Domicilio.Colonia) : "";
            }
        }

        public string Ciudad
        {
            get { return Domicilio != null ? Domicilio.CiudadNombre : ""; }
        }

        public string Estado
        {
            get { return Domicilio != null ? Domicilio.EstadoNombre : ""; }
        }

        public string CodigoPostal
        {
            get { return Domicilio != null ? Domicilio.CodigoPostal : ""; }
        }

        public string Telefono
        {
            get { return Domicilio != null ? Domicilio.Telefono : ""; }
        }

        public string Celular
        {
            get { return Domicilio != null ? Domicilio.Celular : ""; }
        }

        public void AcualizaDomicilio()
        {
            _domicilio = null;
        }

        #region Methods
        public override string ToString()
        {
            return string.Concat(this._NombreComercial );
        }

        public override int GetHashCode()
        {
            return this._Id;
        }

        public override bool Equals(object obj)
        {
            Empresa that = obj as Empresa;
            return that != null && ((this.Id == that.Id && this._Id != 0) || (base.Equals(that)));
        }

        public static bool operator ==(Empresa obj1, Empresa obj2)
        {
            return ((object)obj1 == null && (object)obj2 == null) || ((object)obj1 != null && obj1.Equals(obj2));
        }

        public static bool operator !=(Empresa obj1, Empresa obj2)
        {
            return !(obj1 == obj2);
        }
        #endregion Methods
    }
}
