using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string NomnbreCategoria { get; set; }
        public Categoria()
        {
            CategoriaId = 0;
            NomnbreCategoria = string.Empty;

        }

        public Categoria(int categoriaId, string nomnbreCategoria)
        {
            CategoriaId = categoriaId;
            NomnbreCategoria = nomnbreCategoria;
        }
    }
}
