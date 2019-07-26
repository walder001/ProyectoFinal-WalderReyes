using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Permisos
    {
        public int PermisoId { get; set; }
        public string Descripcion { get; set; }
        public Permisos()
        {
            PermisoId = 0;
            Descripcion = string.Empty;
        }

        public Permisos(int permisoId, string descripcion)
        {
            PermisoId = permisoId;
            Descripcion = descripcion;
        }
    }
}
