//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ciudad
    {
        public Ciudad()
        {
            this.Domicilios = new HashSet<Domicilios>();
            this.Obra = new HashSet<Obra>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int EstadoId { get; set; }
    
        public virtual Estado Estado { get; set; }
        public virtual ICollection<Domicilios> Domicilios { get; set; }
        public virtual ICollection<Obra> Obra { get; set; }
    }
}
