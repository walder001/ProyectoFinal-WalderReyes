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

        public string TipoPago { get; set; }
        public decimal Valor { get; set; }
        public decimal Devuelta { get; set; }
        public decimal ItebisVenta { get; set; }
        public decimal SubTotalVenta { get; set; }
        public decimal TotalVenta { get; set; }
        VentasDetalle Detalle = new VentasDetalle();
        public Ventas()
        {
            VentasId = 0;
            TipoPago = string.Empty;
            Valor = 0;
            Devuelta = 0;
            ItebisVenta = 0;
            SubTotalVenta = 0;
            TotalVenta = 0;
            Detalle = new VentasDetalle();

        }

        public Ventas(int ventasId, string tipoPago, decimal valor, decimal devuelta, decimal itebisVenta, decimal subTotalVenta, decimal totalVenta)
        {
            VentasId = ventasId;
            TipoPago = tipoPago;
            Valor = valor;
            Devuelta = devuelta;
            ItebisVenta = itebisVenta;
            SubTotalVenta = subTotalVenta;
            TotalVenta = totalVenta;
            Detalle = new VentasDetalle();

        }
    }
}
