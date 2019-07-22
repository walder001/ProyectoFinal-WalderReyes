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
    public partial class rVenta : Form
    {
        public rVenta()
        {
            InitializeComponent();
        }

       /* public Ventas LLenaClase()
        {
            Ventas pro = new Ventas();
            pro.VentasId = (int)Ven;
            pro.ClienteId = Convert.ToInt32(ClienteComboBox.ValueMember);
            pro.TipoPago = TipoPagoTextBox.Text;
            pro.ItebisVenta = Convert.ToInt32(ItebisTextBox.Text);
            pro.SubTotalVenta = Convert.ToInt32(ItebisTextBox.Text);
            pro.CostoVenta = Convert.ToInt32(ItebisTextBox.Text);

            foreach (DataGridView item in dataGridView1.Rows)
            {
                pro.AgregarDetalle(
                     ToInt(item.Cells["VentaDetalleId"].Value),
                     ToInt(item.Cells["VentaId"].Value),
                     ToInt(item.Cells["ProductoId"].Value),
                     ToInt(item.Cells["ClienteId"].Value),
                     ToInt(item.Cells["Cantidad"].Value),
                     ToInt(item.Cells["Precio"].Value),
                     ToInt(item.Cells["Descuento"].Value),
                     ToInt(item.Cells["Total"].Value),
                     ToInt(item.Cells["Balance"].Value)
                )

            }

            return pro;
        }*/

        private object ToInt(object value)
        {
            throw new NotImplementedException();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           /* if (ventaDataGridView.DataSource != null)
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
            */

        }
    }
}
