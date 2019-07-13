using Parcial1_WalderReyes.BLL;
using Parcial1_WalderReyes.DAL;
using Parcial1_WalderReyes.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial1_WalderReyes.UI.Registro
{
    public partial class rProductos : Form
    {
        public List<Precio>Precios { get; set; }
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public rProductos()
        {
            InitializeComponent();
            Metodo();
            Listar();
            this.Precios = new List<Precio>();
        }

        /// <summary>
        /// Metodo utilizado para limpiar el formulario
        /// </summary>
        public void limpiar()
        {
            ProductoIdnumericUpDown1.Value = 0;
            DescripciontextBox1.Text = string.Empty;
            CostonumericUpDown2.Value = 0;
            ExisencianumericUpDown3.Value = 0;
            InventariotextBox4.Text = string.Empty;
            this.Precios = new List<Precio>();
            CargarGrid();

        }

        /// <summary>
        /// Metodo utilizado para llenar la clase, se lecciona los valores en los campos para pasarlos a la clase Producto. 
        /// </summary>
        /// <returns></returns>
        
        public Productos LlenarClase()
        {
            Productos pro = new Productos();
            pro.ProductoId = Convert.ToInt32(ProductoIdnumericUpDown1.Value);
            pro.Descripcion = DescripciontextBox1.Text.Trim();
            pro.Costo = Convert.ToSingle(CostonumericUpDown2.Value);
            pro.Existencia = Convert.ToInt32(ExisencianumericUpDown3.Value);
            pro.ValorInventario = Convert.ToSingle(InventariotextBox4.Text);
            pro.Precios = this.Precios;
            return pro;

        }

        /// <summary>
        /// Metodo para seleccional los valores que se encuentra en la clase
        /// </summary>
        /// <param name="pro">Es la variable de instaciacion</param>
        private void LLenarCampo(Productos pro)
        {
            ProductoIdnumericUpDown1.Value = pro.ProductoId;
            DescripciontextBox1.Text = pro.Descripcion;
            CostonumericUpDown2.Value = Convert.ToDecimal(pro.Costo);
            ExisencianumericUpDown3.Value = Convert.ToDecimal(pro.Existencia);
            InventariotextBox4.Text = Convert.ToString(pro.ValorInventario);
            this.Precios = pro.Precios;
            CargarGrid();

        }
        /// <summary>
        /// Metodos para que el campo Dewscripcion solo reciba letras
        /// </summary>
        /// <param name="e"></param>
        public void SoloLetras(KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsLetter(e.KeyChar))
                {

                    e.Handled = false;

                }
               else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;

                }else if(Char.IsSeparator(e.KeyChar)){

                    e.Handled = false;

                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        
        /// <summary>
        /// Metodo que valida que no se ingrese valores nulos o campos vacios en otras palabras.
        /// </summary>
        /// <returns></returns>
        private bool Validar()
        {
            bool paso = true;
            ErrorProvider.Clear();

            
            if (string.IsNullOrWhiteSpace(DescripciontextBox1.Text))
            {
                ErrorProvider.SetError(DescripciontextBox1, "El campo no puede estar vacio");
                DescripciontextBox1.Focus();
                paso = false;

            }
            if (CostonumericUpDown2.Value == 0)
            {
                ErrorProvider.SetError(CostonumericUpDown2, "El costo no puede ser 0");
                CostonumericUpDown2.Focus();
                paso = false;

            }
            if (ExisencianumericUpDown3.Value == 0)
            {
                ErrorProvider.SetError(ExisencianumericUpDown3,"La existencia no puede se 0");
                ExisencianumericUpDown3.Focus();
                paso = false;
            }

            if (this.Precios.Count == 0)
            {
                ErrorProvider.SetError(ExisencianumericUpDown3, "debe agregar un telefono");
                PrecionumericUpDown2.Focus();


            }
            return paso;

        }

        private bool Existe()
        {
            Productos pro = ProductoBLL.Buscar((int)ProductoIdnumericUpDown1.Value);
            return (pro != null);
        }

        /// <summary>
        /// Metodo para realizar el calculo de la UI
        /// </summary>
        public void Metodo()
        {
            float cos, exi;
            cos = Convert.ToSingle(CostonumericUpDown2.Value);
            exi = Convert.ToInt32(ExisencianumericUpDown3.Value);

            float recibir = (cos * exi);

            InventariotextBox4.Text = recibir.ToString();

            if (CostonumericUpDown2.Value > 0 && ExisencianumericUpDown3.Value == 0)
                InventariotextBox4.Text = "0";

            if (CostonumericUpDown2.Value == 0 && ExisencianumericUpDown3.Value > 0)
                InventariotextBox4.Text = "0";

            if (CostonumericUpDown2.Value == 0 && ExisencianumericUpDown3.Value == 0)
                InventariotextBox4.Text = "0";
        }

        private void Limpiar_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        
       
     
        /// <summary>
        /// Llamado al metodo para realizar el calculo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExisencianumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            Metodo();
        }

        /// <summary>
        /// Llamado al metodo para el calculo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       
        private void CostonumericUpDown2_ValueChanged_1(object sender, EventArgs e)
        {
            Metodo();

        }

        private void ExisencianumericUpDown3_ValueChanged_1(object sender, EventArgs e)
        {
            Metodo();
        }

        /// <summary>
        /// Metodos para buscar en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Buscar_Click_1(object sender, EventArgs e)
        {
            Productos producto = new Productos();
            int id;
            id = Convert.ToInt32(ProductoIdnumericUpDown1.Value);
            limpiar();
            producto = ProductoBLL.Buscar(id);
            if (producto != null)
            {
                MessageBox.Show("Persona encontrada");
                LLenarCampo(producto);
            }
            else
            {
                MessageBox.Show("Persona no enctrada");
            }
        }


        /// <summary>
        /// Metodo para guardar en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Guardar_Click_1(object sender, EventArgs e)
        {

            Productos producto;
            bool paso = false;
            if (!Validar())
                return;
            producto = LlenarClase();
            limpiar();

            if (ProductoIdnumericUpDown1.Value == 0)
            {
                paso = ProductoBLL.Guardar(producto);

            }
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No se puede modificar un producto que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                    MessageBox.Show("Desea modificar", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    paso = ProductoBLL.Modificar(producto);

            }
            if (paso)
            {
                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No fue posible guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Metodo para eliminar un producto
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
       
        private void Eliminar_Click_1(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
            int id;
            id = (int)ProductoIdnumericUpDown1.Value;
            limpiar();
            try
            {
                if (ProductoBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado");
                }
                else
                {
                    ErrorProvider.SetError(ProductoIdnumericUpDown1, "No se puedes eliminar una persona que no existe");
                }
            }
            catch
            {
                MessageBox.Show("No puede eliminar un producto que no existe");
            }
            



        }


        private void InventariotextBox4_TextChanged(object sender, EventArgs e)
        {
            Metodo();
        }

        /// <summary>
        /// Validacion del campo Descripcion para que no permita numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DescripciontextBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            rUbicacion ubicacion = new rUbicacion();
            ubicacion.Show();
        }
        Contexto contexto = new Contexto();

        public List<Ubicacion> DataSource { get; private set; }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Listar();
        }
        public void Listar()
        {
            //var lista = contexto.Ubicacion.ToList();
           /* if (lista.Count > 0)
            {
                comboBox1.DataSource = lista;
                comboBox1.DisplayMember = "No categoria";
                comboBox1.ValueMember = "Id";
                comboBox1.ValueMember = "Descripcion";

                if (comboBox1.Items.Count > 1)
                    comboBox1.SelectedIndex = -1;
                

            }*/
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(PreciosdataGridView1.DataSource != null)
            {
                this.Precios = (List<Precio>)PreciosdataGridView1.DataSource;


                this.Precios.Add(
                     new Precio(
                    idprecio: 0, precio: (float)PrecionumericUpDown2.Value, tipoPrecio: TipotextBox1.Text));

                CargarGrid();


            }
        }

        private void Remover_Click(object sender, EventArgs e)
        {
            if (PreciosdataGridView1.Rows.Count > 0 && PreciosdataGridView1.CurrentRow != null)
            {
                Precios.RemoveAt(PreciosdataGridView1.CurrentRow.Index);
                CargarGrid();

            }
        }

        private void CargarGrid()
        {
            PreciosdataGridView1.DataSource = null;
            PreciosdataGridView1.DataSource = this.Precios;
        }


    }

       
    
}

    

