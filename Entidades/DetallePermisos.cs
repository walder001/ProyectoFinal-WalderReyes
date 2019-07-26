using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetallePermisos
    {
        public int DetallePermisoId { get; set; }
        public int UsuarioId { get; set; }
        public int PermisoId { get; set; }
        public DetallePermisos()
        {
            DetallePermisoId = 0;
            UsuarioId = 0;
            PermisoId = 0;
        }

        public DetallePermisos(int detallePermisoId, int usuarioId, int permisoId)
        {
            DetallePermisoId = detallePermisoId;
            UsuarioId = usuarioId;
            PermisoId = permisoId;
        }
    }
}
