using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeisaBD;
using Microsoft.Reporting.WinForms;
using System.Windows.Forms;

namespace Reportes
{
    class IngresosMensualesPorEmpresa
    {
        public List<IngresosMensualesItem> Items;
        List<ReportParameter> rptParams = new List<ReportParameter>();
        ReportParameter param = new ReportParameter("Clientes");

        public IngresosMensualesPorEmpresa(string obras, DateTime startDate, DateTime endDate, string EmpresaId, string clientes)
        {
            List<getReporteIngresosMensual_Result> items = null;
            List<getReporteIngresosMensual_Result> ItemsValidos = new List<getReporteIngresosMensual_Result>();

            GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);

            //items = model.getReporteIngresosMensual(startDate, endDate, EmpresaId).ToList().Where(F => F.FolioNum=="625").ToList();
            items = model.getReporteIngresosMensual(startDate, endDate).ToList();

            string[] Cliente = clientes.Split(',');
            string[] Obras = obras.Split(',');
            string[] Empresas = EmpresaId.Split(',');

            if (Cliente.Count() > 0 && Obras.Count() > 0 && EmpresaId.Count() > 0)
            {
                foreach (getReporteIngresosMensual_Result prov in items)
                {
                    Obra obra = model.Obra.FirstOrDefault(e => e.Id == prov.ObraId);
                    string id = string.Empty;
                    try
                    {
                        id=string.IsNullOrEmpty(prov.ClienteId.ToString()) ? obra.ClienteId.ToString() : prov.ClienteId.ToString();
                    }
                    catch (Exception ex)
                    {
                        id = string.Empty;
                    }
                    string idObra = obra != null ?obra.Id.ToString(): string.Empty;
                    string idEmpresa = prov.EmpresaId != null ?prov.EmpresaId.Value.ToString() : string.Empty;
                    if (Cliente.Where(p => p == id).Count() > 0 && Obras.Where(p => p == idObra).Count() > 0 && Empresas.Where(E => E == idEmpresa).Count() > 0)
                        ItemsValidos.Add(prov);
                }

            }
            else
            {
                ItemsValidos = items;
            }
            Items = new List<IngresosMensualesItem>();
            IngresosMensualesItem._Periodo = startDate.ToShortDateString() + " - " + endDate.ToShortDateString();
            //IngresosMensualesItem._Obra = model.Obra.FirstOrDefault(o => o.Id == ObraId).ToString();
            //IngresosMensualesItem._Empresa = model.Empresa.FirstOrDefault(e => e.Id == (Empresas.Count() > 1 ? ).ToString();
            ItemsValidos.ForEach(item => Items.Add(new IngresosMensualesItem(item)));

        }
    }

    public class IngresosMensualesItem
    {
        #region Miembros Privados
        private getReporteIngresosMensual_Result Item { get; set; }
        GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);
        #endregion

        #region Constructor
        public IngresosMensualesItem(getReporteIngresosMensual_Result item)
        {
            
            Item = item;
        }
        #endregion

        #region Reporting Properties
        public static string _Periodo;
        public static string _Empresa;

        public string FechaCancelacionPago { get { return Item.FechaCancelacionPago.ToString(); } }
        public string FechaCancelacion { get { return Item.FechaCancelacion.ToString(); } }
        public string periodo { get { return _Periodo; } }
        public string empresa { get { return _Empresa; } }
        public DateTime? FechaIngreso { get { return Item.FechaIngreso; } }
        public DateTime? Fecha { get { return Item.Fecha; } }
        public string Facutura { get { return Item.FolioNum!=null ? Item.FolioNum.ToString(): string.Empty; } }
        public string Cliente { get { return Item.ClienteNombre; } }
        public double? SaldoActual { get { return Item.Saldo_Actual; } }
        public double? TotalFactura { get { return Item.TotalFactura; } }
        public double? Monto_Pago { get { return Item.Monto_Pago; } }
        public double? Diferencia { get { return Item.Diferencia; } }
        public string FechaPago { get { return (Item.FechaCancelacionPago!=null || Item.FechaCancelacion!=null) ? "CANCELADA" : (Item.FechaPago!=null ? Item.FechaPago.Value.ToShortDateString():string.Empty) ; } }
        public string ObraNombre { get { return model.Obra.FirstOrDefault( O => O.Id==Item.ObraId).Nombre; } }
        public string Capex_OC { get { return Item.Capex_OC; } }
        public double SaldoActualOriginal { get { return Item.FolioNum != null ? (Item.Saldo_ActualOriginal) : 0; } }
        public int empresaId { get { return Item.EmpresaId.Value; } }

        #endregion Reporting Properties
    }
}
