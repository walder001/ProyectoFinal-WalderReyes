using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleCompras
    {
        [Key]
        public int DetalleCompraId { get; set; }
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public decimal Catidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Importe { get; set; }

        public DetalleCompras()
        {
            DetalleCompraId = 0;
            CompraId = 0;
            ProductoId = 0;
            Catidad = 0;
            Costo = 0;
            Importe = 0;


        }
        public DetalleCompras(int detalleCompraId, int compraId, int productoId, decimal catidad, decimal costo, decimal importe)
        {
            DetalleCompraId = detalleCompraId;
            CompraId = compraId;
            ProductoId = productoId;
            Catidad = catidad;
            Costo = costo;
            Importe = importe;
        }

    }
}
