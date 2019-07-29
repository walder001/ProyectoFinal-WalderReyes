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
    public partial class ClienteReposte : Form
    {
        private List<Clientes> ListarCliente;
        public ClienteReposte(List<Clientes> clientes)
        {
            this.ListarCliente = clientes;
            InitializeComponent();
        }

        private void ClienteReposte_Load(object sender, EventArgs e)
        {
            ClientesCrystalReports us = new ClientesCrystalReports();
            us.SetDataSource(ListarCliente);

            crystalReportViewer1.ReportSource = us;
            crystalReportViewer1.Refresh();
        }

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {
            ClientesCrystalReports us = new ClientesCrystalReports();
            us.SetDataSource(ListarCliente);

            crystalReportViewer1.ReportSource = us;
            crystalReportViewer1.Refresh();

        }
    }
}
