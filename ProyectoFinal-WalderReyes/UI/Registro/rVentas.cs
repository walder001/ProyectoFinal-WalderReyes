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
           this.Detalle = new List<VentasDetalle>();
        }

        public void Limpiar()
        {
            VentasIdNumericUpDown.Value = 0;
            ClienteComboBox.Text = string.Empty;
            TipoPagoTextBox.Text = string.Empty;
            ProductoComboBox.Text = string.Empty;
            CodigoTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            ItebisTextBox.Text = string.Empty;
            SubTotalTextBox.Text = string.Empty;
            TotalTextBox.Text = string.Empty;
            this.Detalle = new List<VentasDetalle>();
            CargarGrid();
        }

        private Ventas LLenaClase()
        {
            Ventas pro = new Ventas();
            pro.VentasId = (int)VentasIdNumericUpDown.Value;
            pro.ClienteId = Convert.ToInt32(ClienteComboBox.SelectedIndex);
            pro.TipoPago = TipoPagoTextBox.Text;
            pro.ItebisVenta = Convert.ToInt32(ItebisTextBox.Text);
            pro.SubTotalVenta = Convert.ToInt32(ItebisTextBox.Text);
            pro.CostoVenta = Convert.ToInt32(ItebisTextBox.Text);
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

            }
          
            return pro;
        }

        private int ToInt(object value)
        {
            int retorno = 0;

            int.TryParse(value.ToString(), out retorno);

            return retorno;
        }

        public void LLenaCampo(Ventas pro)
        {
            VentasIdNumericUpDown.Value = pro.VentasId;
           ClienteComboBox.SelectedItem = Convert.ToInt32(pro.ClienteId);
            TipoPagoTextBox.Text = Convert.ToString(pro.TipoPago);

            ItebisTextBox.Text = pro.TipoPago;
            SubTotalTextBox.Text = pro.SubTotalVenta.ToString();
            TotalTextBox.Text = pro.CostoVenta.ToString();
            ventaDataGridView.DataSource = pro.Detalle;
            
        }
        public bool Validar()
        {
            bool paso = true;
            return paso;
        }
        public bool Existe()
        {
            VentasBLL reposistorio = new VentasBLL();
            Contexto contexto = new Contexto();

            Ventas pro = VentasBLL.Buscar((int)VentasIdNumericUpDown.Value);
            return (pro != null);
        }


        public void CargarGrid()
        {
            ventaDataGridView.DataSource = null;
            ventaDataGridView.DataSource = Detalle;
        }

        public void C()
        {
            if (ventaDataGridView.DataSource != null)
            {
                Detalle = (List<VentasDetalle>)ventaDataGridView.DataSource;
            }
            Detalle.Add(
                new VentasDetalle(
                    ventaDetalleId: 0,
                    productoId: (int)ProductoComboBox.SelectedValue,
                    ventaId: (int)VentasIdNumericUpDown.Value,
                    clienteId: (int)ClienteComboBox.SelectedValue,
                    cantidad: Convert.ToDecimal(CantidadTextBox.Text),
                    precio: Convert.ToDecimal(PrecioTextBox.Text),
                    descuento: 0,
                    total: Convert.ToDecimal(TotalTextBox.Text)
                    )
                );

            CargarGrid();
        }

        public void LLenarProducto()
        {
            RepositorioBase<Productos> repositorio = new RepositorioBase<Productos>(new Contexto());
            ProductoComboBox.DataSource = repositorio.GetList(a => true);
            ProductoComboBox.ValueMember = "ProductoId";
            ProductoComboBox.DisplayMember = "Descripcion";

        }
        public void LLenarClientes()
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>(new Contexto());
            ClienteComboBox.DataSource = repositorio.GetList(c => true);
            ClienteComboBox.ValueMember = "ClienteId";
            ClienteComboBox.DisplayMember = "Nombres";
        }


        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();

        }

       

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

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(VentasIdNumericUpDown.Value);
            Ventas ventas = BLL.VentasBLL.Buscar(id);

            if (ventas != null)
            {
                LLenaCampo(ventas);
            }
            else
                MessageBox.Show("No se encontro!", "Fallo",
MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            List<VentasDetalle> detalle = new List<VentasDetalle>();

             if (ventaDataGridView.DataSource != null)
            {
                detalle = (List<VentasDetalle>)ventaDataGridView.DataSource;
            }
            detalle.Add(
                new VentasDetalle(
                    ventaDetalleId: 0,
                    productoId: (int)ProductoComboBox.SelectedValue,
                    ventaId: (int)VentasIdNumericUpDown.Value,
                    clienteId: (int)ClienteComboBox.SelectedValue,
                    cantidad: Convert.ToDecimal(CantidadTextBox.Text),
                    precio: Convert.ToDecimal(PrecioTextBox.Text),
                    descuento: 0,
                    total: Convert.ToDecimal(TotalTextBox.Text)
                    )
                );
           
            CargarGrid();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(VentasIdNumericUpDown.Value);

            //todo: validar que exista
            if (BLL.VentasBLL.Eliminar(id))
                MessageBox.Show("Eliminado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo eliminar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void Cantidad(int id)
        {
            Contexto contexto = new Contexto();
            Productos p = new Productos();

           p = contexto.Productos.Find(id);

             if(p != null)
            {
                CodigoTextBox.Text = Convert.ToString(p.ProductoId);
                DisponibletextBox.Text = Convert.ToString(p.Cantidad);
                PrecioTextBox.Text = Convert.ToString(p.Precio);
                
            }
    

        }
        private void CantidadTextBox_TextChanged(object sender, EventArgs e)
        {
            Cantidad(Convert.ToInt32(ProductoComboBox.SelectedIndex));

        }

        private void ProductoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cantidad(Convert.ToInt32(ProductoComboBox.SelectedIndex));

        }

        private void VentaDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
