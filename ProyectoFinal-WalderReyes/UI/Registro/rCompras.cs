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
    public partial class rCompras : Form
    {
        public rCompras()
        {
            InitializeComponent();
        }

        private void ProductoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Funcion encargade de limpiar el formulario
        /// </summary>

        public void Limpiar()
        {
            CompraIdNumericUpDown.Value = 0;
            UsuarioComboBox.Text = null;
            FechaDateTimePicker1.Value = DateTime.Now;
            ProductoComboBox.Text = null;
            ProveedorComboBox1.Text = null;
            CantidadNumericUpDown.Value = 0;
            CostoTextBox.Text = string.Empty;
            ImporteTextBox.Text = string.Empty;
            CompraDataGridView.DataSource = null;
            TotalTextBox.Text = string.Empty;
        }
        /// <summary>
        /// Implementacion del metodo del boton limpiar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
        public Compras LLenaClase()
        {
            Compras compra = new Compras();
            compra.CompraId = (int)CompraIdNumericUpDown.Value;
            compra.UsuarioId = Convert.ToInt32(UsuarioComboBox.Text);
            compra.FechaCompra = FechaDateTimePicker1.Value;
            compra.ProductoId = Convert.ToInt32(ProductoComboBox.Text);
            compra.ProveedorId = Convert.ToInt32(ProveedorComboBox1.Text);
            foreach (DataGridViewRow item in CompraDataGridView.Rows)
            {
                compra.AgregarDetalle(
                    ToInt(item.Cells["CompraDetalleId"].Value),
                    ToInt(item.Cells["VentaId"].Value),
                    ToInt(item.Cells["ProductoId"].Value),
                    ToInt(item.Cells["Cantidad"].Value),
                     ToInt(item.Cells["Costo"].Value),
                      ToInt(item.Cells["Importe"].Value)

                    );
            }



            return compra;
        }
        private int ToInt(object value)
        {
            int retorno = 0;

            int.TryParse(value.ToString(), out retorno);

            return retorno;
        }
        public void LLenaCampo(Compras compras)
        {
            Compras compra = new Compras();

            CompraIdNumericUpDown.Value = compra.CompraId;
            UsuarioComboBox.Text = compra.UsuarioId.ToString();
            FechaDateTimePicker1.Value = compra.FechaCompra;
            ProductoComboBox.Text = compra.ProductoId.ToString();
            ProveedorComboBox1.Text =  compra.ProveedorId.ToString();
            CompraDataGridView.DataSource = compra.Detalles;

        }
        public bool Validar()
        {
            bool paso = true;
            if (CantidadNumericUpDown.Value == 0)
            {
                ErrorProvider.SetError(CantidadNumericUpDown,"No pede estar en 0");
                CantidadNumericUpDown.Focus();
                paso = false;

            }
            return paso;
        }
        public bool Existe()
        {
            OrdenCompraBLL reposistorio = new OrdenCompraBLL();
            Contexto contexto = new Contexto();

            Ventas pro = VentasBLL.Buscar((int)CompraIdNumericUpDown.Value);
            return (pro != null);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Compras ventas;
            bool Paso = false;

            if (!Validar())
            {
                MessageBox.Show("Favor revisar todos los campos", "Validación",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ventas = LLenaClase();
            Limpiar();

            //Determinar si es Guardar o Modificar
            if (CompraIdNumericUpDown.Value == 0)
                Paso = BLL.OrdenCompraBLL.Guardar(ventas);
            else
                //todo: validar que exista.
                Paso = BLL.OrdenCompraBLL.Modificar(ventas);

            //Informar el resultado
            if (Paso)
            {
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            List<DetalleCompras> detalle = new List<DetalleCompras>();
            try
            {
                if (CompraDataGridView.DataSource != null)
                {
                    detalle = (List<DetalleCompras>)CompraDataGridView.DataSource;
                }

                detalle.Add(
                    new DetalleCompras(
                        detalleCompraId: 0,
                        compraId: (int) CompraIdNumericUpDown.Value,
                        productoId: (int)ProductoComboBox.SelectedValue,
                        catidad: Convert.ToDecimal(CantidadNumericUpDown.Value),
                        costo: Convert.ToDecimal(CostoTextBox.Text),
                        importe: Convert.ToDecimal(ImporteTextBox.Text)
                        )
                    );

                CompraDataGridView.DataSource = null;
                CompraDataGridView.DataSource = detalle;





            }
            catch (Exception)
            {
                MessageBox.Show("No puede haber campos vacio");

            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(CompraIdNumericUpDown.Value);

            //todo: validar que exista
            if (BLL.OrdenCompraBLL.Eliminar(id))
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(CompraIdNumericUpDown.Value);
            Compras ventas = BLL.OrdenCompraBLL.Buscar(id);

            if (ventas != null)
            {
                Limpiar();
                LLenaCampo(ventas);
            }
            else
                MessageBox.Show("No se encontro!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
