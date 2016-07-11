using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeisaBD;

namespace Reportes
{
    public class EstadoCuentaCajaChica
    {
         #region Properties
        public List<EstadoCuentaCajaChicaItem> Items;
        #endregion Properties

        #region Constructors
        public EstadoCuentaCajaChica(int cajaChicaId, string NombreEmpleado)
        {
            List<CajaChicaDetalle> items = null;

            GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);

            items = model.CajaChicaDetalle.Where(D => D.CajaChicaId == cajaChicaId).ToList();

            Items = new List<EstadoCuentaCajaChicaItem>();

            EstadoCuentaCajaChicaItem._NombreEmpleado = NombreEmpleado;

            items.ForEach(item => Items.Add(new EstadoCuentaCajaChicaItem(item)));
        }
        #endregion Constructors
    }

    public class EstadoCuentaCajaChicaItem
    {
        #region Miembros Privados
        private CajaChicaDetalle Item { get; set; }
        #endregion

        #region Constructor
        public EstadoCuentaCajaChicaItem(CajaChicaDetalle item)
        {
            Item = item;
        }
        #endregion

        #region Reporting Properties
        public static string _NombreEmpleado;
        public string ItemNombreEmpleado { get { return _NombreEmpleado; } }
        public string Fecha { get { return Item.Fecha.ToShortDateString(); } }
        public string Obra { get { return Item.ObraLoaded.Nombre; } }
        public string Observaciones { get { return Item.Observaciones; } }
        public string NoReferencia { get { return Item.NoReferencia; } }
        public double Depositos { get { return Item.Deposito ?? 0; } }
        public double Nominas { get { return Item.Nominas ?? 0; } }
        public double Facturas { get { return Item.Facturas ?? 0; } }
        public double NoDeducibles { get { return Item.NoDeducibles ?? 0; } }
       
        #endregion Reporting Properties
    }
}
