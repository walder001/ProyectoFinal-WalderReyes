using BLL;
using DAL;
using Entidades;
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

namespace ProyectoFinal_WalderReyes.UI.Consulta
{
    public partial class CProducto : Form
    {
        List<Productos> lista = new List<Productos>();
        public CProducto()
        {
            InitializeComponent();
            cbFiltro.Text = "Todos";
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
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
                    case "CategoriaId":
                        int categoria = Convert.ToInt32(txtCriterio.Text);
                        lista = repositorio.GetList(p => p.CategoriaId == categoria);
                        break;
                    case "Descripcion":

                        lista = repositorio.GetList(a => a.Descripcion.Contains(txtCriterio.Text));
                        break;
                    case "Cantidad":
                        decimal cantidad = Convert.ToDecimal(txtCriterio.Text);
                        lista = repositorio.GetList(p => p.Cantidad == cantidad);
                        break;
                    case "Costo":
                        decimal costo = Convert.ToDecimal(txtCriterio.Text);
                        lista = repositorio.GetList(p => p.Costo == costo);
                        break;
                    case "Precio":
                        decimal precio = Convert.ToDecimal(txtCriterio.Text);
                        lista = repositorio.GetList(p => p.Costo == precio);
                        break;
                    case "Ganancia":
                        decimal ganancia = Convert.ToDecimal(txtCriterio.Text);
                        lista = repositorio.GetList(p => p.Ganancia == ganancia);
                        break;
                    case "Itebis":
                        decimal itebis = Convert.ToDecimal(txtCriterio.Text);
                        lista = repositorio.GetList(p => p.Itebis == itebis);
                        break;
                    case "DescuetoProducto":
                        decimal decuento = Convert.ToDecimal(txtCriterio.Text);
                        lista = repositorio.GetList(p => p.DescuentoProducto == decuento);
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

      

      
        private void Imprimir_Click(object sender, EventArgs e)
        {

            if (lista.Count == 0)
            {
                MessageBox.Show("No hay datos para imprimir");
                return;
            }

            ReporteProductos r = new ReporteProductos(lista);
            r.ShowDialog();


        }
    }
}
