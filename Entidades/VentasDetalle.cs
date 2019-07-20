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
        public decimal ItebisVenta { get; set; }
        public decimal SubTotalVenta { get; set; }
        public decimal TotalVenta { get; set; }
        public VentasDetalle()
        {
            VentaDetalleId = 0;
            VentaId = 0;
            ProductoId = 0;
            ItebisVenta = 0;
            SubTotalVenta = 0;
            TotalVenta = 0;
        }
        public VentasDetalle(int ventaDetalleId, int ventaId, int productoId, decimal itebisVenta, decimal subTotalVenta, decimal totalVenta)
        {
            VentaDetalleId = ventaDetalleId;
            VentaId = ventaId;
            ProductoId = productoId;
            ItebisVenta = itebisVenta;
            SubTotalVenta = subTotalVenta;
            TotalVenta = totalVenta;
        }
    }
}
