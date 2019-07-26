using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Compras
    {
        public int CompraId { get; set; }
        public int UsuarioId { get; set; }
        public int ProductoId { get; set; }
        public int ProveedorId { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal TotalCompra { get; set; }
        public Compras()
        {
            CompraId = 0;
            UsuarioId = 0;
            ProductoId = 0;
            ProveedorId = 0;
            FechaCompra = DateTime.Now;
            TotalCompra = 0;
        }

        public Compras(int compraId, int usuarioId, int productoId, int proveedorId, DateTime fechaCompra, decimal totalCompra)
        {
            CompraId = compraId;
            UsuarioId = usuarioId;
            ProductoId = productoId;
            ProveedorId = proveedorId;
            FechaCompra = fechaCompra;
            TotalCompra = totalCompra;
        }
    }
}
