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
    
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            this.VehiculoCajaChica = new HashSet<VehiculoCajaChica>();
        }
    
        public int Id { get; set; }
        public string Marca { get; set; }
        public string SubMarca { get; set; }
        public string Modelo { get; set; }
        public string Color { get; set; }
        public string Placas { get; set; }
    
        public virtual ICollection<VehiculoCajaChica> VehiculoCajaChica { get; set; }
    }
}
