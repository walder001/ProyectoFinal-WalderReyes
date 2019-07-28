using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Acceso
    {
        public bool Login(string user, string pass)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            var op = contexto.Ususarios.FirstOrDefault(a => a.Usuario == user && a.Clave == pass);
            Usuarios u = new Usuarios();
            int Nivel = u.NivelUsuario;
            
            
            if (op != null)
            {
                paso = true;

            }
            return paso;

        }
        public void Roles()
        {
            Usuarios u = new Usuarios();
            Permisos p = new Permisos();

            if (u.NivelUsuario == Accesos.Administrado)
            {

            }
            if (u.NivelUsuario == Accesos.Contador || u.NivelUsuario == Accesos.Cajero)
            {

            }
        }

    }
}
