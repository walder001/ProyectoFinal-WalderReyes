﻿using BLL;
using DAL;
using Entidades;
using ProyectoFinal.UI.Consulta;
using ProyectoFinal.UI.Registro;
using ProyectoFinal_WalderReyes.UI.Consulta;
using ProyectoFinal_WalderReyes.UI.Registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_WalderReyes
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        public static Main Mdiobj;

        private void UsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rUsuario usuario = new rUsuario();
            usuario.Show();
        }

        private void ClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rClientes clientes = new rClientes();
            clientes.Show();
        }

        private void ProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rProveedor proveedor = new rProveedor();
            proveedor.Show();
        }

        private void ProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rCategorias categorias = new rCategorias();
            categorias.Show();
        }

        private void VentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rProductos productos = new rProductos();
            productos.Show();
            

        }

        private void VentasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rVentas ventas = new rVentas();
            ventas.Show();
        }

        private void ComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rCompras compras = new rCompras();
            compras.Show();
                 
        }

        private void UsuariosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cUsuario usuario = new cUsuario();
            usuario.Show();
        }

        private void ClientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cCliente cliente = new cCliente();
            cliente.Show();
        }

        private void ProveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cProveedor proveedor = new cProveedor();
            proveedor.Show();
        }

        private void CategoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ProductosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CProducto producto = new CProducto();
            producto.Show();
        }

        private void VentasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            cVentas ventas = new cVentas();
            ventas.Show();
        }

        private void ComprasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }


       

        /*private void CargarUsuario()
        {
            UsuarioTextBox.DataBindings.Clear();
            var Usuario = UsuarioBLL.GetList(c => true);
            Binding doBinding = new Binding("Text", Usuario, "Nombres");
            UsuarioTextBox.DataBindings.Add(doBinding);
        }*/

        private void Main_Load(object sender, EventArgs e)
        {
            /* RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>(new Contexto());
             List<Usuarios> ListProductos = repositorio.GetList(c => true);

             foreach (var item in ListProductos)
             {
                 Usuarios u = new Usuarios();
                 Contexto con = new Contexto();

                     textBox1.Text = Convert.ToString(u.NivelUsuario);


                 if (item.NivelUsuario == 1)
                 {


                 }else if (item.NivelUsuario == 2)
                 {
                     registroToolStripMenuItem.Enabled = false;

                 }
                 else
                 {


                 }

             }*/

          




        }
    }
}
