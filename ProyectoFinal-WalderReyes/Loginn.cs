using BLL;
using DAL;
using Entidades;
using ProyectoFinal.UI.Consulta;
using ProyectoFinal.UI.Registro;
using ProyectoFinal_WalderReyes.UI.Registro;
using ProyectoFinal_WalderReyes.UI.Reporte;
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
    public partial class Loginn : Form
    {
        public Loginn()
        {
            InitializeComponent();
        }

        private void UsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rUsuario us = new rUsuario();
            us.Show();
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UsuarioReporte re = new UsuarioReporte();
        }

        private void UsuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cUsuario us = new cUsuario();
            us.Show();
        }

        private void RepositorioToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void ClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rClientes rcl = new rClientes();
            rcl.Show();
        }

        private void VentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rVentas ven = new rVentas();
            ven.Show();
        }

        private void ProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rProductos p = new rProductos();
            p.Show();
        }

        private void Acceder_Click(object sender, EventArgs e)
        {
            Main m = new Main();
            m.Show();
        }

        private void BtnEntrer_Click(object sender, EventArgs e)
        {
            Contexto con = new Contexto();
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>(new Contexto());
            Usuarios usuarios = new Usuarios();
             var usuario = repositorio.Buscar(usuarios.UsuarioId);
            /* if (txtUse.Text.Equals("admin") && txtPassword.Text.Equals("vivo"))
             {
                 Main m = new Main();
                 m.Show();

             }
             else
             {
                 MessageBox.Show("Usuario No enciantrado");
             }*/
            Main m = new Main();
            m.Show();

        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
