using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Login
    {
        public int LoginId { get; set; }
        public string Nombre { get; set; }
        public string Constraseña { get; set; }

        public Login()
        {
            LoginId = 0;
            Nombre = string.Empty;
            Constraseña = string.Empty;

        }
        public Login(int logingId, string nombre, string constraseña)
        {
            LoginId = logingId;
            Nombre = nombre;
            Constraseña = constraseña;
        }
    }
}
