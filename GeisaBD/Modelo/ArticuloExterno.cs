using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeisaBD
{
    public class ArticuloExterno
    {
        private string Nombre;
        private string Unidad;
        private string Volumen;
        private string CostoUnitario;

        public string _Nombre { get { return Nombre; } set { Nombre = value; } }
        public string _Unidad { get { return Unidad; } set { Unidad = value; } }
        public string _Volumen { get { return Volumen; } set { Volumen = value; } }
        public string _CostoUnitario { get { return CostoUnitario; } set { CostoUnitario = value; } }
    }
}
