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
    
    public partial class Domicilios
    {
        public int Id { get; set; }
        public int Tipo { get; set; }
        public int CatalogoId { get; set; }
        public string Calle { get; set; }
        public string Exterior { get; set; }
        public string Interior { get; set; }
        public string Colonia { get; set; }
        public string CodigoPostal { get; set; }
        public int CiudadId { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public bool Activo { get; set; }
    
        public virtual Ciudad Ciudad { get; set; }
    }
}