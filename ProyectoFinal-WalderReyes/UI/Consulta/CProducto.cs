using BLL;
using DAL;
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

namespace ProyectoFinal_WalderReyes.UI.Consulta
{
    public partial class CProducto : Form
    {
        public CProducto()
        {
            InitializeComponent();
            cbFiltro.Text = "Todos";
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            var lista = new List<Productos>();
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>(new Contexto());
            if (txtCriterio.Text.Trim().Length > 0)
            {
                switch(cbFiltro.Text){
                    case "Todos":
                        lista = repositorio.GetList(a => true); 
                        break;
                    case "ProductoId":
                        int id = Convert.ToInt32(txtCriterio.Text);
                        lista = repositorio.GetList(p => p.ProductoId == id);
                        break;
                    case "Descripcion":
                        lista = repositorio.GetList(p => p.Descripcion.Contains(txtCriterio.Text));
                        break;

                }


            }
            else
            {
                lista = repositorio.GetList(i => true);
            }
            dgvConsulta.DataSource = null;
            dgvConsulta.DataSource = lista;


        }
    }
}
