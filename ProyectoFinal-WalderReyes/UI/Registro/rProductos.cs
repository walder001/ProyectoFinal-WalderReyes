﻿using BLL;
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
            CalcularGanancia();

        }
        public void Limpiar()
        {
            ProductoIdNumericUpDown.Value = 0;
            DescripcionTextBox.Text = string.Empty;
            ProveedorComboBox1.Text = string.Empty;
            CantidadnumericUpDown.Value = 0;
            CostoNumericUpDown.Value = 0;
            PrecioNumericUpDown.Value = 0;
            ItebisNumericUpDown1.Value = 0;
            GananciaTextBox.Text = string.Empty;
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
            pro.Ganancia = Convert.ToDecimal(GananciaTextBox.Text);

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
             GananciaTextBox.Text =Convert.ToString(pro.Ganancia);

        }
        public bool Validar()
        {
            bool paso = true;
            ErrorProvider.Clear();
            if (string.IsNullOrWhiteSpace(DescripcionTextBox.Text))
            {
                ErrorProvider.SetError(DescripcionTextBox,"No puede esta en blanco");
                DescripcionTextBox.Focus();
                paso = false;


            }
            return paso;
        }
        public bool Existe()
        {
            RepositorioBase<Productos> reposistorio = new RepositorioBase<Productos>(new Contexto());
            Productos pro = reposistorio.Buscar((int)ProductoIdNumericUpDown.Value);
            return (pro != null);
        }
        public void SoloLetras(KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;

            }
           else if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;

            }else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
            }

        }
        public void CalcularGanancia()
        {
            decimal costo = CostoNumericUpDown.Value;
            decimal precio = PrecioNumericUpDown.Value;
            decimal cantidad = CantidadnumericUpDown.Value;
            decimal itebis = ItebisNumericUpDown1.Value;
            decimal ganancia = 0;
            decimal valor = 0;
            valor = ((cantidad*precio)*(itebis/100));
            ganancia = (((cantidad * precio) + valor) - (cantidad * costo));
            GananciaTextBox.Text = ganancia.ToString();


            if (CostoNumericUpDown.Value > 0 && CantidadnumericUpDown.Value == 0)
                GananciaTextBox.Text = "0";
            if (CostoNumericUpDown.Value ==  0 && CantidadnumericUpDown.Value> 0)
                GananciaTextBox.Text = "0";
            if (CostoNumericUpDown.Value == 0 && CantidadnumericUpDown.Value == 0)
                GananciaTextBox.Text = "0";
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
            reposistorio.Eliminar((int)ProductoIdNumericUpDown.Value);
        }

        private void RProductos_Load(object sender, EventArgs e)
        {

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void DescripcionTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }

        private void GananciaTextBox_TextChanged(object sender, EventArgs e)
        {
            CalcularGanancia();
        }

        private void CantidadnumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalcularGanancia();
        }

        private void CostoNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalcularGanancia();
        }

        private void PrecioNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            CalcularGanancia();
        }

        private void ItebisNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CalcularGanancia();
        }
    }
}
