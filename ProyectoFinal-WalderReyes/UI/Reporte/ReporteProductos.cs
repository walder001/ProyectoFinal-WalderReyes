using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_WalderReyes.UI.Reporte
{
    public partial class ReporteProductos : Form
    {
        List<Productos> ListarProducto;
        public ReporteProductos(List<Productos> productos)
        {
            ListarProducto = productos;
            InitializeComponent();
        }

        private void ReporteProductos_Load(object sender, EventArgs e)
        {

            ProductosCrystalReport us = new ProductosCrystalReport();
            us.SetDataSource(ListarProducto);

            crystalReportViewer1.ReportSource = us;
            crystalReportViewer1.Refresh();

        }
    }
}
