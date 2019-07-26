using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DetalleCompras
    {
        public int DetalleCompraId { get; set; }
        public int CompraId { get; set; }
        public int ProductoId { get; set; }
        public decimal Catidad { get; set; }
        public decimal Costo { get; set; }
        public decimal TotalCompra { get; set; }
        public DetalleCompras()
        {
            DetalleCompraId = 0;
            CompraId = 0;
            ProductoId = 0;
            Catidad = 0;
            Costo = 0;
            TotalCompra = 0;


        }

    }
}
