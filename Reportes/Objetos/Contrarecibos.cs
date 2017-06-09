using System;
using System.Collections.Generic;
using System.Linq;
using GeisaBD;

namespace Reportes
{
    public class FacturaRegistros
    {
        public int Numero { get; set; }
        public DateTime? FechaFactura { get; set; }
        public string FolioFactura { get; set; }
        public double? Importe { get; set; }
    }
    public class Contrarecibos
    {
        #region Properties
        public List<ContrarecibosItem> Items;
        #endregion Properties

        #region Constructors
        public Contrarecibos(int contrareciboId)
        {
            List<Factura> items = null;

            GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);

            items = model.Factura.Include("Contrarecibo")
                                 .Include("Proveedor")
                                 .Include("Contrarecibo.Empresa")
                                 .Where(F => F.ContrareciboId == contrareciboId).ToList();

            Items = new List<ContrarecibosItem>();

            int num = 1;
            FacturaRegistros reg = null;
            foreach (Factura fact in items)
            {
                if (num <= 15)
                {
                    reg = new FacturaRegistros();
                    reg.Numero = num;
                    reg.FechaFactura = fact.Fecha;
                    reg.FolioFactura = fact.tipoComprobante.HasValue ? (fact.tipoComprobante.Value == 1 ? fact.NoFactura : (fact.tipoComprobante.Value == 3 ? "TDC " + fact.NoFactura : "NC " + fact.NoFactura)) : fact.NoFactura;
                    reg.Importe = fact.tipoComprobante.HasValue ? (fact.tipoComprobante.Value == 1 || fact.tipoComprobante.Value == 3 ? fact.Importe : (fact.Importe * -1)) : fact.Importe;

                    Items.Add(new ContrarecibosItem(reg));
                    num++;
                }
            }

            while (num <= 15)
            {
                reg = new FacturaRegistros();
                reg.Numero = num;
                Items.Add(new ContrarecibosItem(reg));
                num++;
            }
            
        }
        #endregion Constructors
    }

    public class ContrarecibosItem
    {
        #region Miembros Privados
        private FacturaRegistros Item { get; set; }
        #endregion

        #region Constructor
        public ContrarecibosItem(FacturaRegistros item)
        {
            Item = item;
        }
        #endregion

        #region Reporting Properties
        public int Numero { get { return Item.Numero; } }
        public DateTime? FechaFactura { get { return Item.FechaFactura; } }
        public string FolioFactura { get { return Item.FolioFactura; } }
        public double? Importe { get { return Item.Importe; } }
        #endregion Reporting Properties
    }
}
