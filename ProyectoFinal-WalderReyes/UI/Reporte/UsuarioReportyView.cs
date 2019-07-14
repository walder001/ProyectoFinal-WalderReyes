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
    public partial class UsuarioReportyView : Form
    {
       private List<Usuarios> ListarUsuario;
        public UsuarioReportyView(List<Usuarios> usuarios)
        {
            this.ListarUsuario = usuarios;
            InitializeComponent();
        }

        private void CrystalReportViewer1_Load(object sender, EventArgs e)
        {
            UsuarioReporte us = new UsuarioReporte();
            us.SetDataSource(ListarUsuario);

            crystalReportViewer1.ReportSource = us;
            crystalReportViewer1.Refresh();
        }

        private void UsuarioReportyView_Load(object sender, EventArgs e)
        {
            UsuarioReporte us = new UsuarioReporte();
            us.SetDataSource(ListarUsuario);

            crystalReportViewer1.ReportSource = us;
            crystalReportViewer1.Refresh();

        }
    }
}
