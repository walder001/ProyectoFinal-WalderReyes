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
    public partial class VentasReporte : Form
    {
        List<Ventas> ListaVenta;
             
        public VentasReporte(List<Ventas> ventas)
        {
            InitializeComponent();
            ListaVenta = ventas;
        }

        private void CrystalReportViewer2_Load(object sender, EventArgs e)
        {

        }

        private void VentasReporte_Load(object sender, EventArgs e)
        {

            VentasCrystalReport us = new VentasCrystalReport();
            us.SetDataSource(ListaVenta);

            crystalReportViewer1.ReportSource = us;
            crystalReportViewer1.Refresh();


        }
    }
}
