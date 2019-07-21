using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ventas
    {
        public int VentasId { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public string TipoPago { get; set; }
        public decimal ItebisVenta { get; set; }
        public decimal SubTotalVenta { get; set; }
        public decimal CostoVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public virtual List<VentasDetalle> Detalle { get; set; }

        public Ventas()
        {
            VentasId = 0;
            ClienteId = 0;
            UsuarioId = 0;
            TipoPago = string.Empty;
            ItebisVenta = 0;
            SubTotalVenta = 0;
            CostoVenta = 0;
            FechaVenta = DateTime.Now;
     
            this.Detalle = new List<VentasDetalle>();


        }

        public Ventas(int ventasId, int clienteId, int usuarioId, string tipoPago, decimal itebisVenta, decimal subTotalVenta, decimal costoVenta, DateTime fechaVenta )
        {
            VentasId = ventasId;
            ClienteId = clienteId;
            UsuarioId = usuarioId;
            TipoPago = tipoPago;
            ItebisVenta = itebisVenta;
            SubTotalVenta = subTotalVenta;
            CostoVenta = costoVenta;
            FechaVenta = fechaVenta;
            this.Detalle = new List<VentasDetalle>();
        }
        public void AgregarDetalle(int ventaDetalleId, int ventaId, int productoId, decimal cantidad, decimal precio, decimal descuento)
        {
            this.Detalle.Add(new VentasDetalle(ventaDetalleId, ventaId, productoId, cantidad, precio, descuento));
        }
    }
}
