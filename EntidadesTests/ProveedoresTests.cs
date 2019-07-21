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
    public class ProveedoresTests
    {
        [TestMethod()]
       public void Guardar()
        {
            RepositorioBase<Proveedores> repositorio = new RepositorioBase<Proveedores>(new Contexto());
            Assert.IsTrue(repositorio.Guardar(new Proveedores()));

        }
        [TestMethod()]
        public void Buscar()
        {
            RepositorioBase<Proveedores> repositorio = new RepositorioBase<Proveedores>(new Contexto());
            Assert.IsNotNull(repositorio.Buscar(2));
        }
        [TestMethod()]
        public void Modificar()
        {
            RepositorioBase<Proveedores> repositorio = new RepositorioBase<Proveedores>(new Contexto());
            Proveedores proveedores = new Proveedores();
            proveedores.ProveedorId = 1;
            proveedores.NombreProveedor = "Walder";
            proveedores.RNC = "1111111111";
            proveedores.TelefonoProveedor = "1111111111";
            proveedores.Email = "walder@walder.com";
            proveedores.NombreRepresentante = "Maria";
            proveedores.ExtencionRepresentante = 001;
            Assert.IsTrue(repositorio.Modificar(proveedores));

        }
        [TestMethod()]
        public void GetList()
        {
            RepositorioBase<Proveedores> repositorio = new RepositorioBase<Proveedores>(new Contexto());
            Assert.IsNotNull(repositorio.GetList(a => true));

        }
        [TestMethod()]
        public void Eliminar()
        {
            RepositorioBase<Proveedores> repositorio = new RepositorioBase<Proveedores>(new Contexto());
            Assert.IsNotNull(repositorio.Eliminar(1));

        }
    }
}