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
    public class ClientesTests
    {
       [TestMethod()]
       public void Guardar()
        {
            RepositorioBase<Clientes> repositorio;
            repositorio = new RepositorioBase<Clientes>(new Contexto());
            
            Assert.IsTrue(repositorio.Guardar(new Clientes()));
        }
        [TestMethod()]

        public void GetList()
        {
            RepositorioBase<Usuarios> repositorio;
            repositorio = new RepositorioBase<Usuarios>(new Contexto());
            Assert.IsNotNull(repositorio.GetList(a => true));
        }
        [TestMethod()]

        public void Buscar()
        {
            RepositorioBase<Usuarios> repositorio;
            repositorio = new RepositorioBase<Usuarios>(new Contexto());
            Assert.IsNotNull(repositorio.Buscar(2));
        }
        [TestMethod()]

        public void Modificar()
        {
            RepositorioBase<Clientes> repositorio; 
            repositorio = new RepositorioBase<Clientes>(new Contexto());
            Clientes clientes = new Clientes();
            clientes.ClienteId = 1;
            clientes.Nombres = "Walder";
            clientes.Sexo = "Masculino";
            clientes.Direccion = "Libertad";
            clientes.NumeroCedula = "11111111111";
            clientes.Celular = "1231211";
            clientes.Telefono = "112222";
            clientes.FechaNacimiento = DateTime.Now;
            clientes.Email = "walder@gmail.com";
            Assert.IsTrue(repositorio.Modificar(clientes));
        }
        [TestMethod()]

        public void Eliminar()
        {
            RepositorioBase<Usuarios> repositorio;
            repositorio = new RepositorioBase<Usuarios>(new Contexto());
            Assert.IsNotNull(repositorio.Eliminar(2));
        }
    }
}