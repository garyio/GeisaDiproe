using System;
using System.Collections.Generic;
using System.Linq;

namespace GeisaBD
{
    public partial class TipoMovimientoEnum
    {
        #region Properties
        public static TipoMovimiento Pagos { get; internal set; }
        public static TipoMovimiento Reposicion_Gastos { get; internal set; }
        public static TipoMovimiento TarjetaCredito { get; internal set; }
        public static TipoMovimiento GastosAdministrativos { get; internal set; }
        public static TipoMovimiento Prestamos { get; internal set; }
        public static TipoMovimiento Abonos { get; internal set; }
        public static TipoMovimiento Ingresos { get; internal set; }
        public static TipoMovimiento OtrosIngresos { get; internal set; }
        public static TipoMovimiento Comisiones { get; internal set; }

        public static TipoMovimiento OrdenCompra { get; internal set; }
        public static TipoMovimiento SalidaAlmacen { get; internal set; }
        public static TipoMovimiento NotaCreditoFactura { get; internal set; }
        public static TipoMovimiento Traspaso_Abono { get; internal set; }


        #endregion Properties

        #region Constructors
        static TipoMovimientoEnum()
        {
            GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);
            List<TipoMovimiento> tipo = model.TipoMovimiento.OrderBy(T => T.Id).ToList();
            Pagos = tipo[0];
            Reposicion_Gastos = tipo[1];
            TarjetaCredito = tipo[2];
            GastosAdministrativos = tipo[3];
            Prestamos = tipo[4];
            Abonos = tipo[5];
            Ingresos = tipo[6];
            OtrosIngresos = tipo[7];
            Comisiones = tipo[8];
            OrdenCompra = tipo[9];
            SalidaAlmacen = tipo[10];
            NotaCreditoFactura = tipo[11];
            Traspaso_Abono = tipo[12];

        }
        #endregion Constructors
    }
}

