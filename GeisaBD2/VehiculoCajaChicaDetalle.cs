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
    
    public partial class VehiculoCajaChicaDetalle
    {
        public int Id { get; set; }
        public string Combustible { get; set; }
        public string LecturaAnterior { get; set; }
        public Nullable<double> Cargos { get; set; }
        public Nullable<double> AsignacionCredito { get; set; }
        public Nullable<double> Litros { get; set; }
        public Nullable<double> Recorrido { get; set; }
        public Nullable<double> Rendimiento { get; set; }
        public Nullable<int> ObraId { get; set; }
        public Nullable<int> EmpleadoId { get; set; }
        public Nullable<int> VehiculoCajaChicaId { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
    
        public virtual Empleado Empleado { get; set; }
        public virtual Obra Obra { get; set; }
        public virtual VehiculoCajaChica VehiculoCajaChica { get; set; }
    }
}
