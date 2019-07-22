using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class VentasDetalle
    {
        [Key]
        public int VentaDetalleId { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int ClienteId { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }
        public decimal Total { get; set; }

        public VentasDetalle()
        {
            VentaDetalleId = 0;
            VentaId = 0;
            ProductoId = 0;
            ClienteId = 0;
            Cantidad = 0;
            Precio = 0;
            Descuento = 0;
            Total = 0;
        }
        public VentasDetalle(int ventaDetalleId, int ventaId, int productoId, int clienteId, decimal cantidad, decimal precio, decimal descuento, decimal total)
        {
            this.VentaDetalleId = ventaDetalleId;
            this.VentaId = ventaId;
            this.ProductoId = productoId;
            this.ClienteId = clienteId;
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.Descuento = descuento;
            this.Total = total;
        
        }
    }
}
