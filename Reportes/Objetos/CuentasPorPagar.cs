using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeisaBD;
using Microsoft.Reporting.WinForms;

namespace Reportes
{
    class CuentasPorPagar
    {
        public List<CuentasPorPagarItem> Items;

        public CuentasPorPagar(DateTime startDate, DateTime endDate,string EmpresaId,string proveedores, string obras, string EmpresasNombres)
        {
            List<getReporteCuentasPagar_Result> items = null;
            List<getReporteCuentasPagar_Result> ItemsValidos = new List<getReporteCuentasPagar_Result>();

            GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);

            items = model.getReporteCuentasPagar(startDate, endDate, EmpresaId, proveedores, obras).ToList();

            //string[] Provedor = proveedores.Split(',');

            //if (Provedor.Count()>0)
            //{
            //    //foreach (getReporteGastosViaticos1_Result prov in items)
            //    //{
            //    //    string id = prov.ProveedorId.ToString();
            //    //    if (proveedores.Contains(id) == true)
            //    //        ItemsValidos.Add(prov);
            //    //}
            //    foreach (getReporteCuentasPagar_Result prov in items)
            //    {
            //        string id = prov.ProveedorId.ToString();
            //        if (Provedor.Where(p => p == id).Count()>0)
            //            ItemsValidos.Add(prov);
            //    }
            //}
            //else
            //{
            //    ItemsValidos = items;
            //}
            Items = new List<CuentasPorPagarItem>();
            CuentasPorPagarItem._Periodo = startDate.ToShortDateString() + " - " + endDate.ToShortDateString();
            CuentasPorPagarItem._Empresa = EmpresasNombres;
            items.ForEach(item => Items.Add(new CuentasPorPagarItem(item)));

        }
        }

    public class CuentasPorPagarItem
    {
        #region Miembros Privados

        GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);
        private getReporteCuentasPagar_Result Item { get; set; }
        #endregion

        #region Constructor
        public CuentasPorPagarItem(getReporteCuentasPagar_Result item)
        {
            Item = item;
        }
        #endregion

        #region Reporting Properties
        public static string _Periodo;
        public static string _Empresa;

        public string periodo { get { return _Periodo;}}
        public string empresa{ get { return _Empresa;}}
        public int? ProveedorId { get { return Item.ProveedorId; } }
        public int RazonSocial { get { return model.Proveedor.FirstOrDefault(O => O.Id == Item.ProveedorId).RazonSocial!=null ?model.Proveedor.FirstOrDefault(O => O.Id == Item.ProveedorId).RazonSocial.Value : Convert.ToInt32((int?)null) ; } }
        public string Proveedor { get { return Item.Proveedor; } }
        public DateTime? FechaFactura { get { return Item.FechaFactura; } }
        public DateTime? FechaContraRecibo { get { return Item.FechaContraRecibo; } }
        public DateTime? FechaPago { get { return Item.FechaPago; } }
        public string Factura { get { return Item.Factura; } }

        public double? SaldoFinal { get { return Item.SaldoFinal; } }
        public string Observaciones { get { return Item.Observaciones; } }
        public string Obra { get { return Item.Obra; } }
        #endregion Reporting Properties
    }
}
