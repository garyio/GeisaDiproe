using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeisaBD
{
    public partial class GastoCompartido
    {
        private int _IdPago;
        private int _Id;
        private DateTime _Fecha;
        private string _Factura;
        private double _Importe;
        private string _NoReferencia;
        private string _Concepto;
        private string _Observaciones;
        public int IdPago { get { return _IdPago; } set { _IdPago = value; } }
        public int Id { get { return _Id; } set { _Id = value; } }
        public DateTime Fecha { get { return _Fecha; } set { _Fecha = value; } }
        public string Factura { get { return _Factura; } set { _Factura = value; } }
        public double Importe { get { return _Importe; } set { _Importe = value; } }
        public string NoReferencia { get { return _NoReferencia; } set { _NoReferencia = value; } }
        public string Concepto { get { return _Concepto; } set { _Concepto = value; } }
        public string Observaciones { get { return _Observaciones; } set { _Observaciones = value; } }

    }
}
