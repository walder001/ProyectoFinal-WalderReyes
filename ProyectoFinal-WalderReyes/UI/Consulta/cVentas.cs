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
    public partial class cVentas : Form
    {
        List<Ventas> listar = new List<Ventas>();
        public cVentas()
        {
            InitializeComponent();
            cbFiltro.Text = "Todos";
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                RepositorioBase<Ventas> BLL = new RepositorioBase<Ventas>(new Contexto());
                if (txtCriterio.Text.Trim().Length > 0)
                {
                    switch (cbFiltro.Text)
                    {

                        case "Todos":
                            listar = BLL.GetList(p => true);
                           
                            break;
                        case "ClienteId":
                            int cliente = Convert.ToInt32(txtCriterio.Text);
                            listar = BLL.GetList(p => p.ClienteId == cliente);

                            break;

                        case "UsuarioId":
                            int id = Convert.ToInt32(txtCriterio.Text);
                            listar = BLL.GetList(p => p.UsuarioId == id);
                            break;

                     

                        case "TipoPago":
                            listar = BLL.GetList(p => p.TipoPago.Contains(txtCriterio.Text));
                            break;

                        case "ItebisVenta":
                            int itebis = Convert.ToInt32(txtCriterio.Text);
                            listar = BLL.GetList(p => p.UsuarioId == itebis);
                            break;

                        case "SubTotalVenta":
                            int sub = Convert.ToInt32(txtCriterio.Text);
                            listar = BLL.GetList(p => p.SubTotalVenta == sub);
                            break;
                        case "CostoVenta":
                            int cos = Convert.ToInt32(txtCriterio.Text);
                            listar = BLL.GetList(p => p.SubTotalVenta == cos);
                            break;


                    }
                    listar = listar.Where(c => c.FechaVenta.Date >= DesdedateTimePicker.Value.Date && c.FechaVenta.Date <= HastaDateTimePicker.Value.Date).ToList();

                }
                else
                {
                    listar = BLL.GetList(i => true);
                }
                dgvConsulta.DataSource = null;
                dgvConsulta.DataSource = listar;
            }
            else
            {
                RepositorioBase<Ventas> BLL = new RepositorioBase<Ventas>(new Contexto());
                if (txtCriterio.Text.Trim().Length > 0)
                {
                    switch (cbFiltro.Text)
                    {
                        case "Todos":
                            listar = BLL.GetList(p => true);

                            break;
                        case "ClienteId":
                            int cliente = Convert.ToInt32(txtCriterio.Text);
                            listar = BLL.GetList(p => p.ClienteId == cliente);

                            break;

                        case "UsuarioId":
                            int id = Convert.ToInt32(txtCriterio.Text);
                            listar = BLL.GetList(p => p.UsuarioId == id);
                            break;



                        case "TipoPago":
                            listar = BLL.GetList(p => p.TipoPago.Contains(txtCriterio.Text));
                            break;

                        case "ItebisVenta":
                            int itebis = Convert.ToInt32(txtCriterio.Text);
                            listar = BLL.GetList(p => p.UsuarioId == itebis);
                            break;

                        case "SubTotalVenta":
                            int sub = Convert.ToInt32(txtCriterio.Text);
                            listar = BLL.GetList(p => p.SubTotalVenta == sub);
                            break;
                        case "CostoVenta":
                            int cos = Convert.ToInt32(txtCriterio.Text);
                            listar = BLL.GetList(p => p.SubTotalVenta == cos);
                            break;


                    }
                }
                else
                {
                    listar = BLL.GetList(i => true);
                }
                dgvConsulta.DataSource = null;
                dgvConsulta.DataSource = listar;
            }

        }

        private void Imprimir_Click(object sender, EventArgs e)
        {
            if (listar.Count == 0)
            {
                MessageBox.Show("No hay datos para imprimir");
                return;
            }

            VentasReporte r = new VentasReporte(listar);
            r.ShowDialog();


        }
    }
    }

