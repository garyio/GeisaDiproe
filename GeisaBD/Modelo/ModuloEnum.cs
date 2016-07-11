using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeisaBD
{
    public partial class ModuloEnum
    {
        #region Properties
        public static Modulo Administracion { get; internal set; }
        public static Modulo Catalogo { get; internal set; }
        public static Modulo Operaciones { get; internal set; }
        #endregion Properties

        #region Constructors
        static ModuloEnum()
        {
            GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);
            List<Modulo> modulo = model.Modulo.OrderBy(modulos => modulos.Id).ToList();
            Administracion = modulo[0];
            Catalogo = modulo[1];
            Operaciones = modulo[2];
        }
        #endregion Constructors
    }
}
