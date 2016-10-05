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
    
    public partial class Factura
    {
        public Factura()
        {
            this.PagosFactura = new HashSet<PagosFactura>();
            this.ReposicionGastos = new HashSet<ReposicionGastos>();
        }
    
        public int Id { get; set; }
        public int NoFactura { get; set; }
        public System.DateTime Fecha { get; set; }
        public double Importe { get; set; }
        public double Saldo { get; set; }
        public string Observaciones { get; set; }
        public Nullable<int> ContrareciboId { get; set; }
        public Nullable<int> ProveedorId { get; set; }
        public Nullable<int> ObraId { get; set; }
        public string ProveedorOtro { get; set; }
    
        public virtual Contrarecibo Contrarecibo { get; set; }
        public virtual Obra Obra { get; set; }
        public virtual Proveedor Proveedor { get; set; }
        public virtual ICollection<PagosFactura> PagosFactura { get; set; }
        public virtual ICollection<ReposicionGastos> ReposicionGastos { get; set; }
    }
}
