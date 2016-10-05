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
        public EstadoCuentaCajaChica(int cajaChicaId, string NombreEmpleado,DateTime fechaInicio,DateTime fechaFin)
        {
            List<CajaChicaDetalle> items = null;

            GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);
            DateTime _fechaInicio = fechaInicio.Date;
            DateTime _fechaFin = fechaFin.Date;

            items = model.CajaChicaDetalle.Where(D => D.CajaChicaId == cajaChicaId && (D.Fecha >= _fechaInicio && D.Fecha <= _fechaFin)).ToList();

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
        public string Obra { get { return Item.ObraLoaded != null ? Item.ObraLoaded.Nombre : string.Empty; } }
        public string Observaciones { get { return Item.Observaciones; } }
        public string NoReferencia { get { return Item.NoReferencia; } }
        public double Depositos { get { return Item.Deposito ?? 0; } }
        public double Nominas { get { return Item.Nominas ?? 0; } }
        public double Facturas { get { return Item.Facturas ?? 0; } }
        public double Viaticos { get { return Item.Biaticos ?? 0; } }
        public double Devolucion { get { return Item.Devolucion ?? 0; } }
        public double NoDeducibles { get { return Item.NoDeducibles ?? 0; } }
       
        #endregion Reporting Properties
    }
}
