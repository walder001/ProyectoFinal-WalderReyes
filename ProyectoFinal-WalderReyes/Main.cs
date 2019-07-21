using ProyectoFinal.UI.Registro;
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

        private void UsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rUsuario r = new rUsuario();
            r.Show();
        }

        private void ClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rClientes c = new rClientes();
            c.Show();
        }

        private void ProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rProveedor p = new rProveedor();
            p.Show();
        }

        private void ProductoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rProductos p = new rProductos();
            p.Show();
        }

        private void VentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rVentas v = new rVentas();
            v.Show();
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
