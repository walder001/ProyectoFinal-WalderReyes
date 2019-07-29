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
    public partial class ProveedorReporte : Form
    {
        private List<Proveedores> ListarPrpveedor;
        public ProveedorReporte(List<Proveedores>proveedores)
        {
            ListarPrpveedor = proveedores;
            InitializeComponent();
        }

        private void ProveedorReporte_Load(object sender, EventArgs e)
        {

            ProveedoresCrystalReport1 us = new ProveedoresCrystalReport1();
            us.SetDataSource(ListarPrpveedor);

            crystalReportViewer.ReportSource = us;
            crystalReportViewer.Refresh();
        }

        private void CrystalReportViewer_Load(object sender, EventArgs e)
        {

        }
    }
}
