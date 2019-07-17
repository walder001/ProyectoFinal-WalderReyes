using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Productos
    {
        public int ProductoId { get; set; }
        public int ProveedoresId { get; set; }
        public string Descripcion { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
        public decimal Ganancia { get; set; }
        public decimal ITebis { get; set; }


        public Productos()
        {
            ProductoId = 0;
            ProveedoresId = 0;
            Descripcion = string.Empty;
            Cantidad = 0;
            Costo = 0;
            Precio = 0;
            Ganancia = 0;
        }
        public Productos(int productoId, int proveedores, string descripcion, decimal cantidad, decimal costo, decimal precio, decimal ganancia)
        {
            ProductoId = productoId;
            ProveedoresId = proveedores;
            Descripcion = descripcion;
            Cantidad = cantidad;
            Costo = costo;
            Precio = precio;
            Ganancia = ganancia;
        }
    }
}
