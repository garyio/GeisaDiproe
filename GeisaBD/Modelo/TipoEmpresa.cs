using System;
using System.Collections.Generic;
using System.Linq;

namespace GeisaBD
{
    public class TipoEmpresa
    {
        public static Empresa DIPROE { get; internal set; }
        public static Empresa GEISA { get; internal set; }
        public static Empresa FRANCISCO_RUBIO { get; internal set; }
        public static Empresa GEISA_PERIFERICA { get; internal set; }


        static TipoEmpresa()
        {
            GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);
            List<Empresa> tipo = model.Empresa.ToList();
            DIPROE = tipo[0];
            GEISA = tipo[1];
            FRANCISCO_RUBIO = tipo[2];
            GEISA_PERIFERICA = tipo[3];

        }
    }
}
