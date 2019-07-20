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

namespace ProyectoFinal_WalderReyes.UI.Registro
{
    public partial class rVentas : Form
    {
        List<VentasDetalle> Detalle { get; set; }
        public rVentas()
        {
            InitializeComponent();
            Detalle = new List<VentasDetalle>();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void Limpiar()
        {
           
        }
        public Ventas LLenaClase()
        {
            Ventas pro = new Ventas();
           
            return pro;
        }
        public void LLenaCampo(Productos pro)
        {
           

        }
        public bool Validar()
        {
            bool paso = true;
            return paso;
        }
        public bool Existe()
        {
            RepositorioBase<Ventas> reposistorio = new RepositorioBase<Ventas>(new Contexto());
            Ventas pro = reposistorio.Buscar((int)VentasIdNumericUpDown.Value);
            return (pro != null);
        }

        public void CargarGrid()
        {
            dataGridView.DataSource = null;
            dataGridView.DataSource = Detalle;
        }


        private void BtnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (dataGridView.DataSource != null)
            {
                Detalle = (List<VentasDetalle>)dataGridView.DataSource;
            }
            Detalle.Add(
                new VentasDetalle(
                    ventaDetalleId:0,
                    productoId: (int)ProductoComboBox.SelectedValue,
                    ventaId:(int)VentasIdNumericUpDown.Value
                    
                    )
                );

            CargarGrid();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Guardado","Informacion",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
