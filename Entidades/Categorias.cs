using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Categorias
    {
        [Key]
        public int CategoriaId { get; set; }
        public string NomnbreCategoria { get; set; }
        public Categorias()
        {
            CategoriaId = 0;
            NomnbreCategoria = string.Empty;

        }

        public Categorias(int categoriaId, string nomnbreCategoria)
        {
            CategoriaId = categoriaId;
            NomnbreCategoria = nomnbreCategoria;
        }
    }
}
