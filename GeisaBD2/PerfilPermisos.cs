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
    
    public partial class PerfilPermisos
    {
        public int Id { get; set; }
        public int PerfilId { get; set; }
        public int FormularioPermisosId { get; set; }
    
        public virtual FormularioPermisos FormularioPermisos { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}
