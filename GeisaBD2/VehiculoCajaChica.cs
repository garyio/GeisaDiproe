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
    
    public partial class VehiculoCajaChica
    {
        public VehiculoCajaChica()
        {
            this.VehiculoCajaChicaDetalle = new HashSet<VehiculoCajaChicaDetalle>();
        }
    
        public int Id { get; set; }
        public System.DateTime Fecha { get; set; }
        public int VehiculoId { get; set; }
    
        public virtual Vehiculo Vehiculo { get; set; }
        public virtual ICollection<VehiculoCajaChicaDetalle> VehiculoCajaChicaDetalle { get; set; }
    }
}