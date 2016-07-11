using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeisaBD;

namespace Reportes
{
    public class GastosCompartidos
    {
        #region Properties
        public List<GastosCompartidosItem> Items;
        #endregion Properties

        #region Constructors
        public GastosCompartidos(int mes, string nombreMes, int year)
        {
            double totalGastosCompartidos = 0;
            double totalGastosDiproe= 0;
            double totalGastosGeisa = 0;
            double totalGastosCompartidosDiproe = 0;
            double totalGastosCompartidosGeisa = 0;
            double totalGastosCompartidosDivididos = 0;
            string mensajeGastosCompartidos = "";

            List<getFacturasCompartidas_Result1> itemsGeisa = null;
            List<getFacturasCompartidas_Result1> itemsDiproe = null;

            GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);

            itemsDiproe = model.getFacturasCompartidas(TipoMovimientoEnum.GastosAdministrativos.Id, mes, year, TipoEmpresa.DIPROE.Id).ToList();
            itemsGeisa = model.getFacturasCompartidas(TipoMovimientoEnum.GastosAdministrativos.Id, mes, year, TipoEmpresa.GEISA.Id).ToList();
            //items = model.GastosAdministrativos.Where(D => D.Fecha.Year == year && D.Fecha.Month == mes).OrderBy(D => D.Fecha).ToList();
            var items = itemsDiproe.Union(itemsGeisa).ToList();

            Items = new List<GastosCompartidosItem>();

            foreach (getFacturasCompartidas_Result1 ga in items)
            {
                totalGastosDiproe += (ga.EmpresaId == TipoEmpresa.DIPROE.Id) ? ga.Importe : 0;

                totalGastosGeisa += (ga.EmpresaId == TipoEmpresa.GEISA.Id) ? ga.Importe : 0;

                totalGastosCompartidos += (ga.Compartido == true) ? ga.Importe : 0;

                totalGastosCompartidosDiproe += (ga.EmpresaId == TipoEmpresa.DIPROE.Id && ga.Compartido == true) ? ga.Importe : 0;

                totalGastosCompartidosGeisa += (ga.EmpresaId == TipoEmpresa.GEISA.Id && ga.Compartido == true) ? ga.Importe : 0;
            }

            totalGastosCompartidosDivididos = totalGastosCompartidos / 2;

            if(totalGastosCompartidos > 0)
            {
                if (totalGastosCompartidosDiproe > totalGastosCompartidosGeisa)
                    mensajeGastosCompartidos = "GEISA debe a DIPROE " + (totalGastosCompartidosDivididos - totalGastosCompartidosGeisa).ToString("c2");
                else if (totalGastosCompartidosDiproe < totalGastosCompartidosGeisa)
                    mensajeGastosCompartidos = "DIPROE debe a GEISA " + (totalGastosCompartidosDivididos - totalGastosCompartidosDiproe).ToString("c2");
                else
                    mensajeGastosCompartidos = "Gastos compartidos han sido dividos de manera equitativa"; 
            }

            GastosCompartidosItem._Mes = mes.ToString();
            GastosCompartidosItem._NombreMes = nombreMes;
            GastosCompartidosItem._Year = year.ToString();
            GastosCompartidosItem._totalGastosCompartidos = totalGastosCompartidos;
            GastosCompartidosItem._totalGastosDiproe = totalGastosDiproe;
            GastosCompartidosItem._totalGastosGeisa = totalGastosGeisa;
            GastosCompartidosItem._totalGastosCompartidosDiproe = totalGastosCompartidosDiproe;
            GastosCompartidosItem._totalGastosCompartidosGeisa = totalGastosCompartidosGeisa;
            GastosCompartidosItem._totalGastosCompartidosDivididos = totalGastosCompartidosDivididos;
            GastosCompartidosItem._mensajeGastosCompartidos = mensajeGastosCompartidos;           
            items.ForEach(item => Items.Add(new GastosCompartidosItem(item)));
        }               
        #endregion Constructors
    }

    public class GastosCompartidosItem
    {
        //public int ID_EMPRESA_GEISA = TipoEmpresa.GEISA.Id;
        //public int ID_EMPRESA_DIPROE = TipoEmpresa.DIPROE.Id;

        #region Miembros Privados
        private getFacturasCompartidas_Result1 Item { get; set; }
        #endregion

        #region Constructor
        public GastosCompartidosItem(getFacturasCompartidas_Result1 item)
        {
            Item = item;
        }
        #endregion

        #region Reporting Properties
        public static string _Mes;
        public static string _NombreMes;
        public static string _Year;
        public static double _totalGastosCompartidos = 0;
        public static double _totalGastosDiproe = 0;
        public static double _totalGastosGeisa = 0;
        public static double _totalGastosCompartidosDiproe = 0;
        public static double _totalGastosCompartidosGeisa = 0;
        public static double _totalGastosCompartidosDivididos = 0;
        public static string _mensajeGastosCompartidos;

        public string ItemMes { get { return _Mes; } }
        public string ItemNombreMes { get { return _NombreMes; } }
        public string ItemYear { get { return _Year; } }
        public int ItemIdGeisa { get { return TipoEmpresa.GEISA.Id; } }
        public int ItemIdDiproe { get { return TipoEmpresa.DIPROE.Id; } }
        public double ItemTotalGastosCompartidos { get { return _totalGastosCompartidos; } }
        public double ItemTotalGastosDiproe { get { return _totalGastosDiproe; } }
        public double ItemTotalGastosGeisa { get { return _totalGastosGeisa; } }
        public double ItemTotalGastosCompartidosDiproe { get { return _totalGastosCompartidosDiproe; } }
        public double ItemTotalGastosCompartidosGeisa { get { return _totalGastosCompartidosGeisa; } }
        public double ItemTotalGastosCompartidosDividos { get { return _totalGastosCompartidosDivididos; } }
        public string ItemMensajeGastosCompartidos { get { return _mensajeGastosCompartidos; } }
        public string Concepto { get { return Item.Concepto; } }
        public double Importe { get { return Item.Importe; } }
        public string Referencia { get { return Item.NoReferencia; } }
        public string Observaciones { get { return Item.Observaciones; } }
        public int Empresa { get { return Item.EmpresaId; } }

        #endregion Reporting Properties
    }
}
