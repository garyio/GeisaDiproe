//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GeisaBD2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Obra
    {
        public Obra()
        {
            this.CajaChicaDetalle = new HashSet<CajaChicaDetalle>();
            this.Factura = new HashSet<Factura>();
            this.VehiculoCajaChicaDetalle = new HashSet<VehiculoCajaChicaDetalle>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Nullable<System.DateTime> FechaInicio { get; set; }
        public Nullable<System.DateTime> FechaFin { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public int CiudadId { get; set; }
        public int EmpleadoId { get; set; }
        public int EmpresaId { get; set; }
        public int ClienteId { get; set; }
    
        public virtual ICollection<CajaChicaDetalle> CajaChicaDetalle { get; set; }
        public virtual Ciudad Ciudad { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual ICollection<Factura> Factura { get; set; }
        public virtual ICollection<VehiculoCajaChicaDetalle> VehiculoCajaChicaDetalle { get; set; }
    }
}
