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
        public List<VentasDetalle> Detalle { get; set; }
        public rCompras()
        {
            InitializeComponent();
            LLenarComboBox();
            Limpiar();
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
            CostoNumericUpDown1.Value = 0;
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
            compra.UsuarioId = Convert.ToInt32(UsuarioComboBox.SelectedValue);
            compra.FechaCompra = FechaDateTimePicker1.Value;
            compra.ProductoId = Convert.ToInt32(ProductoComboBox.SelectedValue);
            compra.ProveedorId = Convert.ToInt32(ProveedorComboBox1.SelectedValue);
            foreach (DataGridViewRow item in CompraDataGridView.Rows)
            {
                compra.AgregarDetalle(
                    ToInt(item.Cells["DetalleCompraId"].Value),
                    ToInt(item.Cells["CompraId"].Value),
                    ToInt(item.Cells["ProductoId"].Value),
                    ToInt(item.Cells["Catidad"].Value),
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
            UsuarioComboBox.SelectedItem = compra.UsuarioId;
            FechaDateTimePicker1.Value = compra.FechaCompra;
            ProductoComboBox.SelectedItem = compra.ProductoId;
            ProveedorComboBox1.SelectedIndex = compra.ProveedorId;
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
        public void LLenarCosto()
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>(new Contexto());
            List<Productos> productos = repositorio.GetList(a => a.Descripcion == ProductoComboBox.Text);
            decimal cantidad, precio;

            foreach (var item in productos)
            {
                cantidad = CantidadNumericUpDown.Value;
                precio = CostoNumericUpDown1.Value;
                ImporteTextBox.Text = BLL.OrdenCompraBLL.Calculo(cantidad,precio).ToString();

            }
        
        }
        public void LLenar()
        {
            List<DetalleCompras> p = new List<DetalleCompras>();
            if (CompraDataGridView.DataSource != null)
            {
                p = (List<DetalleCompras>) CompraDataGridView.DataSource;
            }
            decimal Total = 0;
            foreach (var item in p)
            {
                Total += item.Importe;
            }
            TotalTextBox.Text = Total.ToString();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                        costo: Convert.ToDecimal(CostoNumericUpDown1.Value),
                        importe: Convert.ToDecimal(ImporteTextBox.Text)
                        )
                    );
              
                CompraDataGridView.DataSource = null;
                CompraDataGridView.DataSource = detalle;
                LLenarCosto();
                LLenar();





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
        
        public void LLenarComboBox()
        {
            RepositorioBase<Usuarios> usuario = new RepositorioBase<Usuarios>(new Contexto());
            UsuarioComboBox.DataSource = usuario.GetList(u => true);
            UsuarioComboBox.ValueMember = "UsuarioId";
            UsuarioComboBox.DisplayMember = "Usuario";

            RepositorioBase<Productos> producto = new RepositorioBase<Productos>(new Contexto());
            ProductoComboBox.DataSource = producto.GetList(u => true);
            ProductoComboBox.ValueMember = "ProductoId";
            ProductoComboBox.DisplayMember = "Descripcion";

            RepositorioBase<Proveedores> proveedor = new RepositorioBase<Proveedores>(new Contexto());
            ProveedorComboBox1.DataSource = proveedor.GetList(u => true);
            ProveedorComboBox1.ValueMember = "ProveedorId";
            ProveedorComboBox1.DisplayMember = "NombreProveedor";
        }

        private void CantidadNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            LLenarCosto();
        }

        private void CostoNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            LLenarCosto();
        }
    }
}
