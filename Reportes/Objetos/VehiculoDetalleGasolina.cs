using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeisaBD;
using Microsoft.Reporting.WinForms;

namespace Reportes
{
    
    class VehiculoDetalleGasolina
    {
        #region Constructors
        public List<VehiculoDetalleGasolinaItems> Items;
        public VehiculoDetalleGasolina(DateTime startDate, DateTime endDate, string empresas, string vehiculos, string tipoDepositos, string obras)
        {
            List<getVehiculoDetalleGasolina_Result> items = null;
            List<getVehiculoDetalleGasolina_Result> ItemsValidos = new List<getVehiculoDetalleGasolina_Result>();

            GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);

            items = model.getVehiculoDetalleGasolina(startDate, endDate).ToList();

            string[] Empresas = empresas.Split(',');
            string[] Vehiculos = vehiculos.Split(',');
            string[] TipoDepositos = tipoDepositos.Split(',');
            string[] Obras = obras.Split(',');

            if (Empresas.Count() > 0 && Vehiculos.Count() > 0 && TipoDepositos.Count()>0 && Obras.Count()>0)
            {
                foreach (getVehiculoDetalleGasolina_Result prov in items)
                {                    
                    if (Empresas.Where(p => p == prov.EmpresaId.Value.ToString()).Count() > 0 
                        && Obras.Where(p => p == prov.ObraId.Value.ToString()).Count() > 0 
                        && Vehiculos.Where(p => p == prov.VehiculoId.ToString()).Count()>0
                        && TipoDepositos.Where(p => p == prov.TipoDepositoId.ToString()).Count() > 0)
                        ItemsValidos.Add(prov);
                }

            }
            else
            {
                ItemsValidos = items;
            }
            string nombreEmpresas=string.Empty;

            foreach (string e in Empresas)
            {
                nombreEmpresas += model.Empresa.FirstOrDefault(E => E.Id.ToString() == e).NombreFiscal + "\n";
            }

            Items = new List<VehiculoDetalleGasolinaItems>();
            VehiculoDetalleGasolinaItems._Periodo = startDate.ToShortDateString() + " - " + endDate.ToShortDateString();
            VehiculoDetalleGasolinaItems._Empresas = nombreEmpresas;
            ItemsValidos.ForEach(item => Items.Add(new VehiculoDetalleGasolinaItems(item)));
        }
        #endregion Constructors
    }

    public class VehiculoDetalleGasolinaItems
    {
        #region Miembros Privados
        private getVehiculoDetalleGasolina_Result Item { get; set; }
        #endregion

        #region Constructor
        public VehiculoDetalleGasolinaItems(getVehiculoDetalleGasolina_Result item)
        {
            Item = item;
        }
        #endregion

        #region Reporting Properties
        public static string _Periodo;
        public static string _Empresas;
        public string Empresas { get { return _Empresas; } }
        public string Periodo { get { return _Periodo; } }
        public string ObraNombre { get { return Item.ObraNombre; } }
        public string Fecha { get { return Item.Fecha.Value.ToShortDateString(); } }
        public string EmpresaNombre { get { return Item.EmpresaNombre; } }
        public string DatosVehiculo { get { return Item.DatosVehiculo; } }
        public string TipoDeposito { get { return Item.TipoDeposito; } }
        public double Importe { get { return Item.Importe ?? 0; } }
        public string Observaciones { get { return Item.Observaciones; } }
       
        #endregion Reporting Properties
    }
}
