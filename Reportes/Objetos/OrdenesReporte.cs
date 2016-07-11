using System;
using System.Collections.Generic;
using System.Linq;
using GeisaBD;

namespace Reportes
{
    
    public class OrdenesReporte
    {
        public List<OrdenesItem> items;

        public OrdenesReporte(int OrdenId)
        {
            List<DetalleArticulos> detalleArticulos = new List<DetalleArticulos>();

            GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);
            detalleArticulos = model.DetalleArticulos.Where(D => D.OrdenId == OrdenId).ToList();

            items = new List<OrdenesItem>();
            detalleArticulos.ForEach(item => items.Add(new OrdenesItem(item)));
        }
    }

    public class OrdenesItem
    {
        #region Miembros Privados
        private DetalleArticulos Item { get; set; }
        #endregion

        #region Constructor
        public OrdenesItem(DetalleArticulos item)
        {
            Item = item;
        }
        #endregion

        public string Concepto { get { return Item.Articulos.Descripcion; } }
        public string Unidad { get { return Item.UnidadMedida.Nombre; } }
        public double Cantidad { get { return Item.Cantidad!=null ? Item.Cantidad.Value : Convert.ToDouble((double?)null); } }
        public double Costo { get { return Item.Costo; } }
        public double Importe { get { return Costo*Cantidad; } }
        public double Total { get { return Item.Ordenes.Total!=null ? Item.Ordenes.Total.Value: 0; } }

        
    }
}
