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
    public partial class rProductos : Form
    {
        public rProductos()
        {
            InitializeComponent();
        }
        public void Limpiar()
        {
            ProductoIdNumericUpDown.Value = 0;
            DescripcionTextBox.Text = string.Empty;
            ProveedorComboBox1.Text = string.Empty;
            Descripcion.Text = string.Empty;
            CantidadnumericUpDown.Value = 0;
            CostoNumericUpDown.Value = 0;
            PrecioNumericUpDown.Value = 0;
            ItebisNumericUpDown1.Value = 0;
            GananciaNumericUpDown.Value = 0;
            CategoriaComboBox.Text = string.Empty;

        }
        public Productos LLenaClase()
        {
            Productos pro = new Productos();
            pro.ProductoId = (int)ProductoIdNumericUpDown.Value;
            pro.Descripcion = DescripcionTextBox.Text;
            pro.Cantidad = (decimal)CantidadnumericUpDown.Value;
            pro.Costo = (decimal)CostoNumericUpDown.Value;
            pro.Precio = (decimal)PrecioNumericUpDown.Value;
            pro.Itebis = (decimal)PrecioNumericUpDown.Value;
            pro.Ganancia = (decimal)GananciaNumericUpDown.Value;

            return pro;
        } 
        public void LLenaCampo(Productos pro)
        {
            ProductoIdNumericUpDown.Value = pro.ProductoId;
            DescripcionTextBox.Text = pro.Descripcion;
            CantidadnumericUpDown.Value = pro.Cantidad;
            CostoNumericUpDown.Value = pro.Costo;
            PrecioNumericUpDown.Value = pro.Precio;
            ItebisNumericUpDown1.Value = pro.Itebis;
            GananciaNumericUpDown.Value = pro.Ganancia;


        }
        public bool Validar()
        {
            bool paso = true;
            return paso;
        }
        public bool Existe()
        {
            RepositorioBase<Productos> reposistorio = new RepositorioBase<Productos>(new Contexto());
            Productos pro = reposistorio.Buscar((int)ProductoIdNumericUpDown.Value);
            return (pro != null);
        }
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> reposistorio = new RepositorioBase<Productos>(new Contexto());
            Productos productos = new Productos();
            bool paso = false;
            if (!Validar())
                return;
            productos = LLenaClase();
            Limpiar();
            if (ProductoIdNumericUpDown.Value == 0)
            {
                paso = reposistorio.Guardar(productos);

            }
            else
            {
                if (Existe())
                {
                    MessageBox.Show("No se puede modificar un producto que no existe", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            if (paso)
            {
                MessageBox.Show("Guardo", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("No se pudu guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Productos> reposistorio = new RepositorioBase<Productos>(new Contexto());
            reposistorio.
        }
    }
}
