using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VentasDetalle
    {
        public int VentaDetalleId { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public VentasDetalle()
        {
            VentaDetalleId = 0;
            VentaId = 0;
            ProductoId = 0;
        }
        public VentasDetalle(int ventaDetalleId, int ventaId, int productoId)
        {
            VentaDetalleId = ventaDetalleId;
            VentaId = ventaId;
            ProductoId = productoId;
        }
    }
}
