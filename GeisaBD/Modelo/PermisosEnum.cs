using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeisaBD
{
    public class PermisosEnum
    {
        #region Properties
        public static Permisos Consultar { get; internal set; }
        public static Permisos ActivarDesactivar { get; internal set; }
        public static Permisos Agregar { get; internal set; }
        public static Permisos Actualizar { get; internal set; }
        public static Permisos Eliminar { get; internal set; }
        public static Permisos Cancelar { get; internal set; }
        public static Permisos Nominas { get; internal set; }
        #endregion Properties

        #region Constructors
        static PermisosEnum()
        {
            GEISAEntities model = new GEISAEntities(GEISAEntities.DefaultConnectionString);
            List<Permisos> permisos = model.Permisos.OrderBy(p => p.Id).ToList();
            Consultar = permisos[0];
            ActivarDesactivar = permisos[1];
            Agregar = permisos[2];
            Actualizar = permisos[3];
            Eliminar = permisos[4];
            Cancelar = permisos[5];
            Nominas = permisos[6];
        }
        #endregion Constructors
    }
}
