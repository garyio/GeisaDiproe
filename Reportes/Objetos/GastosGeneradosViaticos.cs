using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeisaBD;
using Microsoft.Reporting.WinForms;

namespace Reportes
{
    class GastosGeneradosViaticos
    {
        public List<gastoGeneradoItem> Items;
        List<ReportParameter> rptParams = new List<ReportParameter>();
        ReportParameter param = new ReportParameter("proveedores");

        public GastosGeneradosViaticos(string obras,DateTime startDate, DateTime endDate,int EmpresaId,string proveedores)
        {
            List<getReporteGastosViaticos_Result> items = null;
            List<getReporteGastosViaticos_Result> ItemsValidos = new List<getReporteGastosViaticos_Result>();

            GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);

            items = model.getReporteGastosViaticos(startDate, endDate, EmpresaId).ToList();

            string[] Provedor = proveedores.Split(',');
            string[] Obras = obras.Split(',');

            if (Provedor.Count()>0 && Obras.Count()>0)
            {
                //foreach (getReporteGastosViaticos1_Result prov in items)
                //{
                //    string id = prov.ProveedorId.ToString();
                //    if (proveedores.Contains(id) == true)
                //        ItemsValidos.Add(prov);
                //}
                foreach (getReporteGastosViaticos_Result prov in items)
                {
                    string id = prov.ProveedorId.ToString();
                    string idObra = prov.ObraId.ToString();
                    if (Provedor.Where(p => p == id).Count()>0 && Obras.Where(p => p == idObra).Count()>0)
                        ItemsValidos.Add(prov);
                }

            }
            else
            {
                ItemsValidos = items;
            }
            Items = new List<gastoGeneradoItem>();
            gastoGeneradoItem._Periodo = startDate.ToShortDateString() + " - " + endDate.ToShortDateString();
            //gastoGeneradoItem._Obra = model.Obra.FirstOrDefault(o => o.Id == ObraId).ToString();
            gastoGeneradoItem._Empresa = model.Empresa.FirstOrDefault(e => e.Id == EmpresaId).ToString();
            ItemsValidos.ForEach(item => Items.Add(new gastoGeneradoItem(item)));

        }
    }

    public class gastoGeneradoItem
    {
        #region Miembros Privados
        private getReporteGastosViaticos_Result Item { get; set; }
        #endregion

        #region Constructor
        public gastoGeneradoItem(getReporteGastosViaticos_Result item)
        {
            Item = item;
        }
        #endregion

        

        #region Reporting Properties
        public static string _Periodo;
        public static string _Empresa;
        public static string _Obra;

        public string periodo { get { return _Periodo;}}
        public string empresa{ get { return _Empresa;}}
        public string obra { get { return _Obra; } }
        public int? ProveedorId { get { return Item.ProveedorId; } }
        public int? Consecutivo { get { return Item.Consecutivo.HasValue ? Item.Consecutivo : (int?)null; } }
        public string Factura { get { return (( (Item.tipoComprobante.HasValue ? Item.tipoComprobante.Value : -1)  == 2 ? "NC " : "") + Item.Factura); } }
        public DateTime? FechaPago { get { return Item.FechaPago; } }
        public double Importe { get { return Item.Importe != null ? Item.Importe.Value :  0.00; } }
        public string Observaciones { get { return Item.Observaciones; } }
        public string Proveedor { get { return Item.Proveedor; } }
        public string ObraNombre { get { return Item.ObraNombre; } }
        public string TipoPago { get { return ((Item.tipoComprobante.HasValue ? Item.tipoComprobante.Value : -1) == 2 ? "NOTA CREDITO" : Item.TipoPago); } }
        public string TarjetaCredito { get { return Item.TarjetaCredito.ToString(); } }

        #endregion Reporting Properties
    }
}
