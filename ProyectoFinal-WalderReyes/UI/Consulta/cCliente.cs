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
    public partial class cCliente : Form
    {
        public cCliente()
        {
            InitializeComponent();
            cbFiltro.Text = "Todos";
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                var listar = new List<Clientes>();
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
                var listar = new List<Clientes>();
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
    }
}
