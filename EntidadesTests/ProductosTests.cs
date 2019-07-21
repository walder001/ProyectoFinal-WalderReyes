using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using DAL;

namespace Entidades.Tests
{
    [TestClass()]
    public class ProductosTests
    {
        [TestMethod()]
        public void Guardar()
        {
            RepositorioBase<Productos> reposistorio = new RepositorioBase<Productos>(new Contexto());
            Assert.IsTrue(reposistorio.Guardar(new Productos()));
        }

        [TestMethod()]
        public void Buscar()
        {
            RepositorioBase<Productos> reposistorio = new RepositorioBase<Productos>(new Contexto());
            Assert.IsNotNull(reposistorio.Buscar(1));
        }

        [TestMethod()]
        public void GetList()
        {
            RepositorioBase<Productos> reposistorio = new RepositorioBase<Productos>(new Contexto());
            Assert.IsNotNull(reposistorio.GetList(a => true));
        }


        [TestMethod()]
        public void Modificar()
        {
            RepositorioBase<Productos> reposistorio = new RepositorioBase<Productos>(new Contexto());
            Productos producto = new Productos();
            producto.ProductoId = 1;
            producto.Descripcion = "Azucar";
            producto.ProveedoresId = 1;
            producto.Cantidad = 1;
            producto.Costo = 1;
            producto.Precio = 1;
            producto.Itebis = 1;
            producto.Ganancia = 10;
            producto.CategoriaId = 1;

            Assert.IsTrue(reposistorio.Modificar(producto));
        }

        [TestMethod()]
        public void Eliminar()
        {
            RepositorioBase<Productos> reposistorio = new RepositorioBase<Productos>(new Contexto());
            Assert.IsNotNull(reposistorio.Eliminar(1));
        }

    }
}