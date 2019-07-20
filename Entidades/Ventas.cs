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
        public decimal Valor { get; set; }
        public decimal Devuelta { get; set; }
        public DateTime FechaVenta { get; set; }


        public virtual List<VentasDetalle> Detalle { get; set; }
        public Ventas()
        {
            VentasId = 0;
            ClienteId = 0;
            UsuarioId = 0;
            TipoPago = string.Empty;
            Valor = 0;
            Devuelta = 0;
            FechaVenta = DateTime.Now;
     
            this.Detalle = new List<VentasDetalle>();


        }

        public Ventas(int ventasId, string tipoPago, decimal valor, decimal devuelta, DateTime fechaVenta )
        {
            VentasId = ventasId;
            TipoPago = tipoPago;
            Valor = valor;
            Devuelta = devuelta;
            FechaVenta = fechaVenta;


           
            this.Detalle = new List<VentasDetalle>();

        }
        public void AgregarDetalle(int ventaDetalleId, int ventaId, int productoId)
        {
            this.Detalle.Add(new VentasDetalle(ventaDetalleId,ventaId,productoId));
        }
    }
}
