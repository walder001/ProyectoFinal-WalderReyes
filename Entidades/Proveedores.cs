using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Proveedores
    {
        public int ProveedorId { get; set; }
        public string NombreProveedor { get; set; }
        public string RNC { get; set; }
        public string TelefonoProveedor { get; set; }
        public string Email { get; set; }
        public string NombreRepresentante { get; set; }
        public string EstencionRepresentante { get; set; }
        public Proveedores()
        {
            ProveedorId = 0;
            NombreProveedor = string.Empty;
            RNC = string.Empty;
            TelefonoProveedor = string.Empty;
            Email = string.Empty;
            NombreRepresentante = string.Empty;
            EstencionRepresentante = string.Empty;

        }

        public Proveedores(int proveedorId, string nombreProveedor, string rNC, string telefonoProveedor, string email, string nombreRepresentante, string estencionRepresentante)
        {
            ProveedorId = proveedorId;
            NombreProveedor = nombreProveedor;
            RNC = rNC;
            TelefonoProveedor = telefonoProveedor;
            Email = email;
            NombreRepresentante = nombreRepresentante;
            EstencionRepresentante = estencionRepresentante;
        }
    }
}
