using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeisaBD;

namespace SistemaGEISA
{
    public class ReporteCaja
    {
        public string Empleado;
        public DateTime Fecha;
        public string Obra;
        public string Empresa;
        public string Referencia;
        public double? Deposito;
        public double? Nominas;
        public double? Facturas;
        public double? NoDeducibles;
        public string Observaciones;
    }
    public class ReporteCajaChica
    {
        #region Miembros Privados
        public List<ReporteCajaChicaItem> Items;
        #endregion

        #region Constructor
        public ReporteCajaChica(int cajaChica)
        {
            List<CajaChicaDetalle> items = null;
            ReporteCaja rc = null;

            using (GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString))
            {
                items = model.CajaChicaDetalle.Include("Empresa")
                                               .Include("Obra")
                                               .Include("TipoPago")
                                               .Where(D => D.CajaChicaId == cajaChica).ToList();
            }
            Items = new List<ReporteCajaChicaItem>();

            foreach (CajaChicaDetalle i in items)
            {
                rc = new ReporteCaja();
                rc.Empleado = i.CajaChica.Empleado.Nombre + " " + i.CajaChica.Empleado.ApPaterno + " " + i.CajaChica.Empleado.ApMaterno;
                rc.Fecha = i.Fecha;
                rc.Obra = i.ObraNombre;
                rc.Empresa = i.EmpresaNombre;
                rc.Referencia = i.NoReferencia;
                rc.Deposito = i.Deposito;
                rc.Nominas = i.Nominas;
                rc.Facturas = i.Facturas;
                rc.NoDeducibles = i.NoDeducibles;
                rc.Observaciones = i.Observaciones;
            }
        }
        #endregion

        public class ReporteCajaChicaItem
        {
            ReporteCajaChica Item { get; set; }
            public ReporteCajaChicaItem(ReporteCajaChica item)
            {
                Item = item;
            }
            //public string Empleado { get { return Item. ; } }
        }
    }
}
