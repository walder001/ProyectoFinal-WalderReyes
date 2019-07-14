using BLL;
using DAL;
using Entidades;
using ProyectoFinal_WalderReyes;
using ProyectoFinal_WalderReyes.UI.Reporte;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal.UI.Consulta
{
    public partial class cUsuario : Form
    {
        private List<Usuarios> ListarUsuarios;
        public cUsuario()
        {
            InitializeComponent();
        }

        private void DgvConsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> repositorio = new RepositorioBase<Usuarios>(new Contexto());

            var Listar = new List<Usuarios>();
            if (txtCriterio.Text.Trim().Length > 0)
            {
                switch (cbFiltro.SelectedItem)
                {
                    case 0:
                        Listar = repositorio.GetList(u => true);
                        break;
                    case 1:
                        int id;
                        id = Convert.ToInt32(txtCriterio.Text);
                        Listar = repositorio.GetList(u => u.UsuarioId == id);
                        break;
                    case 2:
                        Listar = repositorio.GetList(u => u.Email.Contains(txtCriterio.Text));
                        break;
                    case 3:
                        int nivel;
                        nivel = Convert.ToInt32(txtCriterio.Text);
                        Listar = repositorio.GetList(u => u.NivelUsuario == nivel);
                        break;
                    case 4:
                        Listar = repositorio.GetList(u => u.Nombre.Contains(txtCriterio.Text));
                        break;
                    case 5:
                        Listar = repositorio.GetList(u => u.Usuario.Contains(txtCriterio.Text));
                        break;




                }
               
 

            }
            else
            {
                Listar = repositorio.GetList(i => true);
            }
            dgvConsulta.DataSource = null;
            dgvConsulta.DataSource = Listar;

        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
           /* if(ListarUsuarios.Count == 0)
            {
                MessageBox.Show("No hay datos para imprimir");
                return;
            }*/
            ReporteUsuario r = new ReporteUsuario(ListarUsuarios);
            r.ShowDialog();
            


        }
    }
}
