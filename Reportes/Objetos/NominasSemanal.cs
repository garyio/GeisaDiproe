using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeisaBD;
using Microsoft.Reporting.WinForms;

namespace Reportes
{
    class NominasSemanal
    {
        public List<NominasSemanalItem> Items;
        List<ReportParameter> rptParams = new List<ReportParameter>();

        public NominasSemanal(string obras,string Empleados,DateTime fechaIni,DateTime fechaFin,int tipoNomina)
        {
            List<getNominaSemanal_Result> items = null;
            List<getNominaSemanal_Result> ItemsValidos = new List<getNominaSemanal_Result>();

            GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);

            //items = model.getReporteIngresosMensual(startDate, endDate, EmpresaId).ToList().Where(F => F.FolioNum=="625").ToList();
            items = model.getNominaSemanal(fechaIni, fechaFin, tipoNomina).ToList();

            string[] empleados= Empleados.Split(',');
            string[] Obras = obras.Split(',');

            if (empleados.Count() > 0 && Obras.Count() > 0)
            {
                foreach (getNominaSemanal_Result prov in items)
                {
                    Obra obra = model.Obra.FirstOrDefault(e => e.Id == prov.ObraId);
                    string idEmpleado = prov.EmpleadoId.ToString();
                    string idObra = obra.Id.ToString();
                    if (empleados.Where(p => p == idEmpleado).Count() > 0 && Obras.Where(p => p == idObra).Count() > 0)
                        ItemsValidos.Add(prov);
                }

            }
            else
            {
                ItemsValidos = items;
            }
            Items = new List<NominasSemanalItem>();
            NominasSemanalItem._Periodo = fechaIni.ToShortDateString() + " - " + fechaFin.ToShortDateString();
            NominasSemanalItem._TipoNomina = tipoNomina == 1 ? "SEMANAL" : (tipoNomina==2 ? "QUINCENAL" : (tipoNomina==3 ?"MENSUAL":"TODAS") );
            //NominasSemanalItem._TotalGeisa = items.Where(I => )
            ItemsValidos.ForEach(item => Items.Add(new NominasSemanalItem(item)));
        }
    }

    public class NominasSemanalItem
    {
        #region Miembros Privados
        private getNominaSemanal_Result Item { get; set; }
        GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);
        Nominas empleadoItem;
        #endregion

        #region Constructor
        public NominasSemanalItem(getNominaSemanal_Result item)
        {
            Item = item;
            empleadoItem = model.Nominas.Where(N => N.Id == Item.NominaId).SingleOrDefault();
        }
        #endregion

        #region Reporting Properties
        public static string _Periodo;
        public static string _TipoNomina;
        public static double _TotalGeisa;
        public static double _TotalDiproe;

        public int NominaId { get { return Item.NominaId; } }
        public int NominaDetalleId { get { return Item.NominaDetalleId.HasValue ? Item.NominaDetalleId.Value : Convert.ToInt32((int?)null); } }
        public int TipoNominaId { get { return Item.TipoPagoId.HasValue ? Item.TipoPagoId.Value : Convert.ToInt32((int?)null); } }
        public string Periodo { get { return _Periodo; } }
        public string TipoNominaNombre { get { return _TipoNomina; } }
        public string ObraNombre { get { return Item.ObraNombre; } }
        public string EmpleadoNombre { get  { return Item.EmpleadoNombre; } }
        public double SueldoReal { get { return Item.SueldoReal.HasValue ? Item.SueldoReal.Value : Convert.ToDouble((double?)null); } }
        public int EsPagoEfectivo { get { return Item.esPagoEfectivo.HasValue ?(Item.esPagoEfectivo.Value? 1 : 2) : 2 ;} }
        public DateTime? FechaInicio { get { return Item.PeriodoInicio.Value; } }
        public DateTime? FechaFin { get { return Item.PeriodoFin.Value; } }
        //public double Extras { get { return Item.Extras.HasValue ? Item.Extras.Value : Convert.ToDouble((double?)null); } }
        //public double PagosGeisa { get { return Item.PagosGeisa.HasValue ? Item.PagosGeisa.Value : Convert.ToDouble((double?)null); } }
        //public double Compensacion { get { return Item.Compensacion.HasValue ? Item.Compensacion.Value : Convert.ToDouble((double?)null); } }
        public double Extras { get { return empleadoItem.ExtrasCalc; } }
        public double Compensacion { get { return empleadoItem.CompensacionCalc; } }
        public double PagosGeisa { get { return empleadoItem.AdeudosPagosCalc - (empleadoItem.Infonavit.HasValue ? empleadoItem.Infonavit.Value : 0); } }
        public double Faltas { get { return empleadoItem.FaltasCalc; } }
        public double Viaticos { get { return empleadoItem.ViaticosCalc; } }
        
        //public double Viaticos { get { return Item.Viaticos.HasValue ? Item.Viaticos.Value : Convert.ToDouble((double?)null); } }
        public double TotalEmpleado { get { return (SueldoReal + Extras  + Compensacion + Viaticos); } }
        public double TotalEnEfectivoSemanal { get { return Item.TipoPagoId == 1 ? ((Item.esPagoEfectivo.HasValue ? Item.esPagoEfectivo.Value : false) ? this.TotalEmpleado : 0): 0; } }
        public double TotalEnEfectivoQuincenal { get { return Item.TipoPagoId == 2 ? ((Item.esPagoEfectivo.HasValue ? Item.esPagoEfectivo.Value : false) ? this.TotalEmpleado : 0) : 0; } }
        //public double TotalEmpleado { get { return empleadoItem.Total; } }
        public string Observaciones { get { return Item.Observaciones; } }        
        public double TotalDiproeSemanal { get { return  Item.TipoPagoId ==1 ? (Item.EmpresaId==1 ? TotalEmpleado : (Item.EmpresaId==-1 ? TotalEmpleado/2 : 0)) : 0; } }
        public double TotalGeisaSemanal { get { return Item.TipoPagoId == 1 ? (Item.EmpresaId == 2 ? TotalEmpleado : (Item.EmpresaId == -1 ? TotalEmpleado / 2 : 0)) : 0 ; } }
        public double TotalDiproeMensual { get { return Item.TipoPagoId == 2 || Item.TipoPagoId==3 ? (Item.EmpresaId == 1 ? TotalEmpleado : (Item.EmpresaId == -1 ? TotalEmpleado / 2 : 0)) : 0; } }
        public double TotalGeisaMensual { get { return Item.TipoPagoId == 2 || Item.TipoPagoId == 3 ? (Item.EmpresaId == 2 ? TotalEmpleado : (Item.EmpresaId == -1 ? TotalEmpleado / 2 : 0)): 0; } }

        #endregion Reporting Properties
    }
}
