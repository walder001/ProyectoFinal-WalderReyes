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
    public class UsuariosTests
    {
        [TestMethod()]
        public void Guardar()
        {
            RepositorioBase<Usuarios> repositorio;

            repositorio = new RepositorioBase<Usuarios>(new Contexto());

            Assert.IsTrue(repositorio.Guardar(new Usuarios()));
        }
        [TestMethod()]
        public void GetList()
        {
            RepositorioBase<Usuarios> repositorio;
            repositorio = new RepositorioBase<Usuarios>(new Contexto());
            Assert.IsNotNull(repositorio.GetList(a => true));

        }

        [TestMethod()]
        public void Modificar()
        {
            RepositorioBase<Usuarios> repositorio;
            repositorio = new RepositorioBase<Usuarios>(new Contexto());
            Usuarios usuarios = new Usuarios();
            usuarios.UsuarioId = 2;
            usuarios.Nombre = "walder";
            usuarios.Email = "Walderreyes34@gmail.com";
            usuarios.NivelUsuario = 0;
            usuarios.Usuario = "walder001";
            usuarios.Clave = "1234567";
            usuarios.FehaIngreso = DateTime.Now;
            Assert.IsTrue(repositorio.Modificar(usuarios));
        }
        [TestMethod()]
        public void Buscar()
        {
            RepositorioBase<Usuarios> repositorio;
            repositorio = new RepositorioBase<Usuarios>(new Contexto());
            Assert.IsNotNull(repositorio.Buscar(3));
        }
        [TestMethod()]
        public void Eliminar()
        {
            RepositorioBase<Usuarios> repositorio;
            repositorio = new RepositorioBase<Usuarios>(new Contexto());
            Assert.IsNotNull(repositorio.Eliminar(1));
        }

    }
}