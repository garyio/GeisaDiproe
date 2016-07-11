using System;
using System.Collections.Generic;
using System.Linq;

namespace GeisaBD
{
    public partial class TipoPagoEnum
    {
        #region Properties
        public static TipoPago Efectivo { get; internal set; }
        public static TipoPago Cheque { get; internal set; }
        public static TipoPago Transferencia { get; internal set; }
        public static TipoPago NotaCredito { get; internal set; }
        public static TipoPago NoAplica { get; internal set; }
        public static TipoPago Periferica { get; internal set; }

        #endregion Properties

        #region Constructors
        static TipoPagoEnum()
        {
            GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);
            List<TipoPago> tipo = model.TipoPago.OrderBy(T => T.Id).ToList();
            Efectivo = tipo[0];
            Cheque = tipo[1];
            Transferencia = tipo[2];
            NotaCredito = tipo[3];
            NoAplica = tipo[4];
            Periferica = tipo[5];
        }
        #endregion Constructors
    }
}
