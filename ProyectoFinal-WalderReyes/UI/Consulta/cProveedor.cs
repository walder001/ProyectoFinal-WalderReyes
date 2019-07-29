using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using BLL;
using DAL;
using Entidades;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinal_WalderReyes.UI.Reporte;

namespace ProyectoFinal_WalderReyes.UI.Consulta
{
    public partial class cProveedor : Form
    {
        List<Proveedores> lista = new List<Proveedores>();
        public cProveedor()
        {
            InitializeComponent();
            cbFiltro.Text = "Todos";
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {

            RepositorioBase<Proveedores> repositorio = new RepositorioBase<Proveedores>(new Contexto());
            if (txtCriterio.Text.Trim().Length > 0)
            {
                switch (cbFiltro.Text)
                {
                    case "Todos":
                        lista = repositorio.GetList(a => true);
                        break;
                    case "ProveedorId":
                        int id = Convert.ToInt32(txtCriterio.Text);
                        lista = repositorio.GetList(p => p.ProveedorId == id);
                        break;
                    case "RNC":
                        lista = repositorio.GetList(p => p.RNC.Contains(txtCriterio.Text));
                        break;

                    case "NombreProveedor":
                        lista = repositorio.GetList(p => p.NombreProveedor.Contains(txtCriterio.Text));

                        break;
                    case "Email":
                        lista = repositorio.GetList(p => p.Email.Contains(txtCriterio.Text));
                        break;

                    case "NombreRepresentante":
                        lista = repositorio.GetList(p => p.NombreRepresentante.Contains(txtCriterio.Text));
                        break;
                    case "ExtencioRepreasentante":
                        int ad = Convert.ToInt32(txtCriterio.Text);
                        lista = repositorio.GetList(p => p.ExtencionRepresentante == ad);
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

        private void Imprimir_Click_1(object sender, EventArgs e)
        {
            if (lista.Count == 0)
            {
                MessageBox.Show("No hay datos para imprimir");
                return;
            }

            ProveedorReporte r = new ProveedorReporte(lista);
            r.ShowDialog();
        }

        
    }
 }

