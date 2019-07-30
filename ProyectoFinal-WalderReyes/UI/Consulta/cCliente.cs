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
    public partial class cCliente : Form
    {
        private List<Clientes> listar = new List<Clientes>();

        public cCliente()
        {
            InitializeComponent();
            cbFiltro.Text = "Todos";
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                listar = listar.Where(c => c.FechaNacimiento.Date == DesdedateTimePicker.Value.Date && c.FechaNacimiento.Date <= HastaDateTimePicker.Value.Date).ToList();

            }
            if (checkBox1.Checked == true)
            {
                RepositorioBase<Clientes> BLL = new RepositorioBase<Clientes>(new Contexto());
                if (txtCriterio.Text.Trim().Length > 0)
                {
                    switch (cbFiltro.Text)
                    {

                        case "Todos":
                            listar = BLL.GetList(p => true);
                            break;
                        case "ClienteId":
                            int id = Convert.ToInt32(txtCriterio.Text);
                            listar = BLL.GetList(p => p.ClienteId == id);
                            break;
                        case "Nombre":
                            listar = BLL.GetList(p => p.Nombres.Contains(txtCriterio.Text));
                            break;
                        case "Sexo":
                            listar = BLL.GetList(p => p.Sexo.Contains(txtCriterio.Text));
                            break;
                        case "Direcion":
                            listar = BLL.GetList(p => p.Direccion.Contains(txtCriterio.Text));
                            break;
                        case "NumeroCedula":
                            listar = BLL.GetList(p => p.NumeroCedula.Contains(txtCriterio.Text));
                            break;
                        case "Celular":
                            listar = BLL.GetList(p => p.Celular.Contains(txtCriterio.Text));
                            break;
                        case "Telefono":
                            listar = BLL.GetList(p => p.Telefono.Contains(txtCriterio.Text));
                            break;
                        case "Email":
                            listar = BLL.GetList(p => p.Email.Contains(txtCriterio.Text));
                            break;
                        case "Balance":
                            decimal balance;
                            balance = Convert.ToDecimal(txtCriterio.Text);
                            listar = BLL.GetList(p => p.Balance == balance);
                            break;


                    }
                    listar = listar.Where(c => c.FechaNacimiento.Date >= DesdedateTimePicker.Value.Date && c.FechaNacimiento.Date <=  HastaDateTimePicker.Value.Date).ToList();

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
                RepositorioBase<Clientes> BLL = new RepositorioBase<Clientes>(new Contexto());
                if (txtCriterio.Text.Trim().Length > 0)
                {
                    switch (cbFiltro.Text)
                    {

                        case "Todos":
                            listar = BLL.GetList(p => true);
                            break;

                        case "UsuarioId":
                            int id = Convert.ToInt32(txtCriterio.Text);
                            listar = BLL.GetList(p => p.ClienteId == id);
                            break;

                        case "Nombre":
                            listar = BLL.GetList(p => p.Nombres.Contains(txtCriterio.Text));
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

            ClienteReposte r = new ClienteReposte(listar);
            r.ShowDialog();
        }
    }
}
