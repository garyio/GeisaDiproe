using System;
using System.Collections.Generic;
using System.Linq;

namespace GeisaBD
{
    public partial class TipoComprobante
    {
        #region Properties
        public static TipoComprobante Deducible { get; internal set; }
        public static TipoComprobante Nomina { get; internal set; }
        public static TipoComprobante NoDeducibles { get; internal set; }
        public static TipoComprobante Biaticos { get; internal set; }
        public static TipoComprobante Aguinaldo { get; internal set; }
        public static TipoComprobante Finiquito { get; internal set; }

        #endregion Properties

        #region Constructors
        static TipoComprobante()
        {
            GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);
            List<TipoComprobante> tipo = model.TipoComprobante.OrderBy(T => T.Id).ToList();
            Deducible = tipo[0];
            Nomina = tipo[1];
            NoDeducibles = tipo[2];
            Biaticos = tipo[3];
            Aguinaldo = tipo[4];
            Finiquito = tipo[5];
        }
        #endregion Constructors
    }
}
