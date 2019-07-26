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
        public List<VentasDetalle> Detalle { get; set; }
        public rVentas()
        {
            InitializeComponent();
            LLenarProducto();
            LLenarClientes();
            Limpiar();
        }
        /// <summary>
        /// Metodo encargado de limpiar el formulario
        /// </summary>
        public void Limpiar()
        {
            VentasIdNumericUpDown.Value = 0;
            ClienteComboBox.Text = null;
            TipoPagoTextBox.Text = string.Empty;
            ProductoComboBox.Text = null;
            CodigoTextBox.Text = string.Empty;
            CantidadNumericUpDown.Value = 0;
            PrecioTextBox.Clear();
            ImporteTextBox.Clear();
            InteresTextBox.Text = string.Empty;
            ItebisTextBox.Text = string.Empty;
            SubTotalTextBox.Text = string.Empty;
            TotalTextBox.Text = string.Empty;
            ErrorProvider.Clear();
            ventaDataGridView.DataSource = null;
        }
        /// <summary>
        /// Metodo encargado de llenar la clase y el detalle
        /// </summary>
        /// <returns></returns>
        private Ventas LLenaClase()
        {
            Ventas pro = new Ventas();
            pro.VentasId = (int)VentasIdNumericUpDown.Value;
            pro.ClienteId = Convert.ToInt32(ClienteComboBox.SelectedIndex);
            pro.TipoPago = TipoPagoTextBox.Text;
            pro.ItebisVenta = Convert.ToDecimal(ItebisTextBox.Text);
            pro.SubTotalVenta = Convert.ToDecimal(SubTotalTextBox.Text);
            pro.CostoVenta = Convert.ToDecimal(TotalTextBox.Text);
            foreach (DataGridViewRow item in ventaDataGridView.Rows)
            {
                   pro.AgregarDetalle(
                     ToInt(item.Cells["VentaDetalleId"].Value),
                     ToInt(item.Cells["VentaId"].Value),
                     ToInt(item.Cells["ProductoId"].Value),
                     ToInt(item.Cells["ClienteId"].Value),
                     ToInt(item.Cells["Cantidad"].Value),
                     ToInt(item.Cells["Precio"].Value),
                     ToInt(item.Cells["Descuento"].Value),
                     ToInt(item.Cells["Total"].Value));
                ventaDataGridView.Columns["VentaDetalleId"].Visible = false;
                ventaDataGridView.Columns["VentaId"].Visible = false;
                ventaDataGridView.Columns["ProductoId"].Visible = false;
                ventaDataGridView.Columns["ClienteId"].Visible = false;

            }
          
            return pro;
        }
        //Metodo auxiliar para el uso de ToInt

        private int ToInt(object value)
        {
            int retorno = 0;

            int.TryParse(value.ToString(), out retorno);

            return retorno;
        }
        /// <summary>
        /// Metodo encargado de llenar el formulario con los datos de la clase
        /// </summary>
        /// <param name="pro"></param>
        public void LLenaCampo(Ventas pro)
        {
            VentasIdNumericUpDown.Value = pro.VentasId;
            ClienteComboBox.SelectedIndex = pro.ClienteId;
            TipoPagoTextBox.Text = Convert.ToString(pro.TipoPago);
            ItebisTextBox.Text = Convert.ToString(pro.ItebisVenta);
            SubTotalTextBox.Text = pro.SubTotalVenta.ToString();
            TotalTextBox.Text = pro.CostoVenta.ToString();
            ventaDataGridView.DataSource = pro.Detalle; 
            ventaDataGridView.Columns["VentaDetalleId"].Visible = false;
            ventaDataGridView.Columns["VentaId"].Visible = false;
            ventaDataGridView.Columns["ProductoId"].Visible = false;
            ventaDataGridView.Columns["ClienteId"].Visible = false;

        }
        /// <summary>
        /// Metodo encargado de validar los campos del formulario
        /// </summary>
        /// <returns></returns>
        public bool Validar()
        {
            bool paso = true;
            ErrorProvider.Clear();
            if (string.IsNullOrWhiteSpace(CodigoTextBox.Text))
            {
                ErrorProvider.SetError(CodigoTextBox,"El codigo no puede estar vacio");
                CodigoTextBox.Focus();
                paso = false;
            }
            
            if (string.IsNullOrWhiteSpace(PrecioTextBox.Text))
            {
                ErrorProvider.SetError(PrecioTextBox, "El codigo no puede estar vacio");
                PrecioTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(ItebisTextBox.Text))
            {
                ErrorProvider.SetError(ItebisTextBox, "El codigo no puede estar vacio");
                ItebisTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(TotalTextBox.Text))
            {
                ErrorProvider.SetError(TotalTextBox, "El codigo no puede estar vacio");
                TotalTextBox.Focus();
                paso = false;
            }
            return paso;
        }
        /// <summary>
        /// Validar para que el campo solo reciba numeros
        /// </summary>
        /// <param name="e"></param>
        public void SoloNumeros(KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
            }
            
        }
        /// <summary>
        /// Metodo qeu compruba s
        /// </summary>
        /// <returns></returns>
        public bool Existe()
        {
            VentasBLL reposistorio = new VentasBLL();
            Contexto contexto = new Contexto();

            Ventas pro = VentasBLL.Buscar((int)VentasIdNumericUpDown.Value);
            return (pro != null);
        }
        /// <summary>
        /// Metodo encargado de cargar el grid
        /// </summary>
        public void CargarGrid()
        {
            ventaDataGridView.DataSource = null;
            ventaDataGridView.DataSource = Detalle;
        }

        /// <summary>
        /// Cargar el combobox producto
        /// </summary>
        private void LLenarProducto()
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>(new Contexto());
            ProductoComboBox.DataSource = repositorio.GetList(a => true);
            ProductoComboBox.ValueMember = "ProductoId";
            ProductoComboBox.DisplayMember = "Descripcion";

        }
        /// <summary>
        /// Cargar el combobox cleinte
        /// </summary>
        private void LLenarClientes()
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>(new Contexto());
            ClienteComboBox.DataSource = null;
            ClienteComboBox.DataSource = repositorio.GetList(c => true);
            ClienteComboBox.ValueMember = "ClienteId";
            ClienteComboBox.DisplayMember = "Nombres";
        }

        private void LlenarPrecio()
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>(new Contexto());
            List<Productos> ListProductos = repositorio.GetList(c => c.Descripcion == ProductoComboBox.Text);

            foreach (var item in ListProductos)
            {
                CodigoTextBox.Text = ProductoComboBox.SelectedValue.ToString();
                PrecioTextBox.Text = item.Precio.ToString();
                InteresTextBox.Text = item.Itebis.ToString();
                DisponibletextBox.Text = item.Cantidad.ToString();
            }
        }
        private void LLenarImporte()
        {

            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>(new Contexto());
            List<Productos> ListProductos = repositorio.GetList(c => c.Descripcion == ProductoComboBox.Text);

            decimal cantidad, precio;

            cantidad = Convert.ToDecimal(CantidadNumericUpDown.Value);
                foreach (var item in ListProductos)
                {
                    precio = item.Precio;

                    ImporteTextBox.Text = BLL.VentasBLL.Calculo(cantidad, precio).ToString();

                }

        }
        private void LlenarValores()
        {
            List<VentasDetalle> detalle = new List<VentasDetalle>();

            if (ventaDataGridView.DataSource != null)
            {
                detalle = (List<VentasDetalle>)ventaDataGridView.DataSource;
            }
            decimal Importe = 0;
            decimal Itbis = 0;
            decimal SubTotal = 0;
            foreach (var item in detalle)
            {
                Importe += item.Total;
            }
            Itbis = Importe * (decimal)0.18;
            SubTotal = Importe - Itbis;
            SubTotalTextBox.Text = SubTotal.ToString();
            ItebisTextBox.Text = Itbis.ToString();
            TotalTextBox.Text = Importe.ToString();
        }

        /// <summary>
        /// Boton Nuevo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();

        }
        /// <summary>
        /// Boton Guardar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            Ventas ventas;
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
            if (VentasIdNumericUpDown.Value == 0)
                Paso = BLL.VentasBLL.Guardar(ventas);
            else
                //todo: validar que exista.
                Paso = BLL.VentasBLL.Modificar(ventas);

            //Informar el resultado
            if (Paso)
            {
                MessageBox.Show("Guardado!!", "Exito",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo guardar!!", "Fallo",MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Boton Buscar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(VentasIdNumericUpDown.Value);
            Ventas ventas = BLL.VentasBLL.Buscar(id);

            if (ventas != null)
            {
                Limpiar();
                LLenaCampo(ventas);
            }
            else
                MessageBox.Show("No se encontro!", "Fallo",MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Boton Agregar al grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AgregarButton_Click(object sender, EventArgs e)
        {
            List<VentasDetalle> detalle = new List<VentasDetalle>();
            try
            {
                if (ventaDataGridView.DataSource != null)
                {
                    detalle = (List<VentasDetalle>)ventaDataGridView.DataSource;
                }

                RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>(new Contexto());
                List<Productos> ListProductos = repositorio.GetList(c => c.Descripcion == ProductoComboBox.Text);

                decimal cantidad, precio, importe ;

                cantidad = Convert.ToDecimal(CantidadNumericUpDown.Value);
                foreach (var item in ListProductos)
                {
                    precio = item.Precio;

                   ImporteTextBox.Text = BLL.VentasBLL.Calculo(cantidad, precio).ToString();

                }
                detalle.Add(
                        new VentasDetalle(
                            ventaDetalleId: 0,
                            productoId: (int)ProductoComboBox.SelectedValue,
                            ventaId: (int)VentasIdNumericUpDown.Value,
                            clienteId: (int)ClienteComboBox.SelectedValue,
                            cantidad: (decimal)Convert.ToDecimal(CantidadNumericUpDown.Value),
                            precio: 0,
                            descuento: 0,
                            total: (decimal)Convert.ToDecimal(ImporteTextBox.Text)
                            )
                        );
                    
                    ventaDataGridView.DataSource = null;
                    ventaDataGridView.DataSource = detalle;
                    LlenarValores();

                



            }
            catch (Exception)
            {
                MessageBox.Show("No puede haber campos vacio");

            }
        }
        /// <summary>
        /// Boton Eliminar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(VentasIdNumericUpDown.Value);

            //todo: validar que exista
            if (BLL.VentasBLL.Eliminar(id))
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        /// <summary>
        /// Metodo encargado de buscar los datos del producto
        /// </summary>
        /// <param name="id"></param>
        public void Cantidad(int id)
        {
            Contexto contexto = new Contexto();
            Productos p = new Productos();

           p = contexto.Productos.Find(id);

             if(p != null)
            {
                CodigoTextBox.Text = Convert.ToString(p.ProductoId);
                DisponibletextBox.Text = Convert.ToString(p.Cantidad);
                InteresTextBox.Text = Convert.ToString(p.Itebis);
                PrecioTextBox.Text = Convert.ToString(p.Precio);
            }


            if (CantidadNumericUpDown.Value != 0)
            {
                decimal subtotal, total,impuestos;    
                impuestos = ((Convert.ToDecimal(CantidadNumericUpDown.Value) * Convert.ToDecimal(PrecioTextBox.Text)) * (Convert.ToDecimal(InteresTextBox.Text) /100));
                subtotal = Convert.ToDecimal(CantidadNumericUpDown.Value) * Convert.ToDecimal(PrecioTextBox.Text);
                total = impuestos + subtotal;

                ItebisTextBox.Text = impuestos.ToString();
                DescuentoTextBox.Text = "0";
                SubTotalTextBox.Text = subtotal.ToString();
                TotalTextBox.Text = total.ToString();
            }
           

        }
        /// <summary>
        /// Cargar datos del producto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CantidadTextBox_TextChanged(object sender, EventArgs e)
        {
            LlenarPrecio();
            LLenarImporte();

        }

        private void ProductoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarPrecio();
            LLenarImporte();

        }

        private void VentaDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        /// <summary>
        /// Validar solo letras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CantidadTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void CantidadNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

            LlenarPrecio();
            LLenarImporte();
            LlenarValores();


        }

        private void ClienteComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarPrecio();
            LLenarImporte();

        }
    }
}
