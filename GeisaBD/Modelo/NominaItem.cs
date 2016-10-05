using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeisaBD
{
    public class NominaItem
    {
        private int _Id;
        private int _NominasId;
        private int? _TipoCargoId;
        private int? _NumeroHoras;
        private int? _ObraId;
        private string _Observaciones;
        private DateTime? _FechaDetalle;
        private double? _Monto;
        private int? _CargoDeduccion;
        private int? _EsDiaHora;

        public int Id { get { return _Id; } set { _Id = value; } }
        public int NominasId { get { return _NominasId; } set { _NominasId = value; } }
        public int? TipoCargoId { get { return _TipoCargoId; } set { _TipoCargoId = value; } }
        public int? NumeroDiasHoras { get { return _NumeroHoras; } set { _NumeroHoras = value; } }
        public int? ObraId { get { return _ObraId; } set { _ObraId = value; } }
        public string Observaciones { get { return _Observaciones; } set { _Observaciones = value; } }
        public DateTime? FechaDetalle { get { return _FechaDetalle; } set { _FechaDetalle = value; } }
        public double? Monto { get { return _Monto; } set { _Monto = value; } }
        public int? CargoDeduccion { get { return _CargoDeduccion; } set { _CargoDeduccion = value; } }
        public int? EsDiaHora { get { return _EsDiaHora; } set { _EsDiaHora = value; } }
    }
}
