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
    public partial class ReporteUsuario : Form
    {
        private List<Usuarios> ListarUsuarios;
        public ReporteUsuario(List<Usuarios> usuarios)
        {
            this.ListarUsuarios = usuarios;
            InitializeComponent();
        }

        private void CrystalReportViewer6_Load(object sender, EventArgs e)
        {
            

        }

        private void UsuarioReporte1_InitReport(object sender, EventArgs e)
        {
            UsuarioReporte us = new UsuarioReporte();
            us.SetDataSource(ListarUsuarios);

            Reporte.ReportSource = us;
            Reporte.Refresh();

        }
    }
}
