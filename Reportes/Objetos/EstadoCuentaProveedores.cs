using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeisaBD;

namespace Reportes
{
    class EstadoCuentaProveedores
    {
         #region Properties
        public List<EstadoCuentaProveedoresItem> Items;
        #endregion Properties

        #region Constructors
        public EstadoCuentaProveedores(DateTime fechaIni, DateTime fechaFin, string proveedor, string obra, bool conSaldo)
        {
            List<getEstadoCuentaProveedores_Result> items = null;

            GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);

            items = model.getEstadoCuentaProveedores(fechaIni, fechaFin, proveedor, obra, conSaldo).ToList();
            
            Items = new List<EstadoCuentaProveedoresItem>();

            EstadoCuentaProveedoresItem._Periodo = fechaIni.ToShortDateString() + " - " + fechaFin.ToShortDateString();
            //EstadoCuentaProveedoresItem._Proveedor = proveedor == null ? "" : proveedor.NombreComercial;
            //EstadoCuentaProveedoresItem._Obra = obra == null ? "" : obra.Nombre;
            EstadoCuentaProveedoresItem._ConSaldo = conSaldo.ToString();
            items.ForEach(item => Items.Add(new EstadoCuentaProveedoresItem(item)));
        }
        #endregion Constructors
    }

    public class EstadoCuentaProveedoresItem
    {
        #region Miembros Privados
        private getEstadoCuentaProveedores_Result Item { get; set; }
        #endregion

        #region Constructor
        public EstadoCuentaProveedoresItem(getEstadoCuentaProveedores_Result item)
        {
            Item = item;
        }
        #endregion

        #region Reporting Properties
        public static string _Periodo;
        public static string _Proveedor;
        public static string _Obra;
        public static string _ConSaldo;
        public string ItemPeriodo { get { return _Periodo; } }
        public string ItemProveedor { get { return _Proveedor; } }
        public string ItemObra { get { return _Obra; } }
        public string ItemConSaldo { get { return _ConSaldo; } }

        public string Fecha { get { return Item.Fecha.ToShortDateString(); } }
        public string NoFactura { get { return Item.NoFactura.ToString(); } }
        public double Importe { get { return Item.Importe; } }
        public double MontoPagar { get { return Item.MontoPagar; } }
        public string Referencia { get { return Item.Referencia; } }
        public string FechaPago { get { return Item.FechaPago.ToShortDateString(); } }
        public double Saldo { get { return Item.Saldo; } }
        public int ObraId { get { return Item.Id; } }
        public string ObraNombre { get { return Item.Nombre.ToString(); } }
        public int ProveedorId { get { return Item.ProveedorId; } }
        public string Proveedor { get { return Item.NombreComercial; } }
        public int FacturaId { get { return Item.FacturaId; } }
        public string EmpresaNombre { get { return Item.EmpresaNombre; } }
       
        #endregion Reporting Properties
    }
}
