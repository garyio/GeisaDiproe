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
    
    public partial class CajaChicaDetalle
    {
        public int Id { get; set; }
        public System.DateTime Fecha { get; set; }
        public Nullable<double> Deposito { get; set; }
        public Nullable<double> Nominas { get; set; }
        public Nullable<double> Facturas { get; set; }
        public Nullable<double> NoDeducibles { get; set; }
        public string Observaciones { get; set; }
        public int CajaChicaId { get; set; }
        public int ObraId { get; set; }
        public Nullable<int> EmpresaId { get; set; }
        public Nullable<int> EmpresaBancosId { get; set; }
        public Nullable<int> TipoPagoId { get; set; }
        public string NoReferencia { get; set; }
    
        public virtual CajaChica CajaChica { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual EmpresaBancos EmpresaBancos { get; set; }
        public virtual Obra Obra { get; set; }
        public virtual TipoPago TipoPago { get; set; }
    }
}
