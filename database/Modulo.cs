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
    
    public partial class Modulo
    {
        public Modulo()
        {
            this.Formulario = new HashSet<Formulario>();
        }
    
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Orden { get; set; }
    
        public virtual ICollection<Formulario> Formulario { get; set; }
    }
}