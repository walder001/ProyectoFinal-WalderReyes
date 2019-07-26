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
    public partial class rCategorias : Form
    {
        public rCategorias()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Metodo que limpia los campos
        /// </summary>
        public void Limpiar()
        {
            CategoriaIdNumericUpDown.Value = 0;
            NombreCategoriaTextBox.Text = string.Empty;
        }

        /// <summary>
        /// Boton Nuevo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        ///
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();

        }
        /// <summary>
        /// Metodo Para asignale el datos a la entidad
        /// </summary>
        /// <returns></returns>
        public Categorias LLenaClase()
        {
            Categorias categoria = new Categorias();
            categoria.CategoriaId =(int)CategoriaIdNumericUpDown.Value;
            categoria.NomnbreCategoria = NombreCategoriaTextBox.Text;
            return categoria;

        }
        /// <summary>
        /// LLenar los campos 
        /// </summary>
        /// <param name="categoria"></param>
        public void LLenarCampo(Categorias categoria)
        {
            CategoriaIdNumericUpDown.Value = categoria.CategoriaId;
            NombreCategoriaTextBox.Text = categoria.NomnbreCategoria;

        }
        /// <summary>
        /// Validacion de los datos
        /// </summary>
        /// <returns></returns>
        public bool Validar()
        {
            bool paso = true;
            if (string.IsNullOrWhiteSpace(NombreCategoriaTextBox.Text))
            {
                ErrorProvider.SetError(NombreCategoriaTextBox,"La categira no puede estar vacia");
                NombreCategoriaTextBox.Focus();
                paso = false;

            }
            return paso;
        }

        /// <summary>
        /// Comprobar si existe 
        /// </summary>
        /// <returns></returns>
        public bool Existe()
        {
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>(new Contexto());
            Categorias categoria = repositorio.Buscar((int)CategoriaIdNumericUpDown.Value);
            return (categoria != null);


        }
        /// <summary>
        /// Boton para guardar los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>(new Contexto());
            bool paso = false;

            if (!Validar())
                return;
            Categorias categorias = LLenaClase();
            if (CategoriaIdNumericUpDown.Value == 0)
            {
                paso = repositorio.Guardar(categorias);
            }
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No se pueda modificar un usuario que no esiste","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    var opcion = MessageBox.Show("Desea modifcar el usuario", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (DialogResult.OK == opcion)
                    {
                        repositorio.Modificar(categorias);

                    }

                }
            }
            if (paso)
            {
                MessageBox.Show("Guardado!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Error al guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        /// <summary>
        /// Boton que elimina los datos de una entidad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>(new Contexto());
            try
            {
                var opcion = MessageBox.Show("Desea eliminar el usuario", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (DialogResult.OK == opcion)
                {
                    repositorio.Eliminar((int)CategoriaIdNumericUpDown.Value);
                }

            }
            catch (Exception)
            {
             MessageBox.Show("Errores al eliminar", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Metodo para buscar los datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Categorias> repositorio = new RepositorioBase<Categorias>(new Contexto());
            try
            {   
                   Categorias categorias = repositorio.Buscar((int)CategoriaIdNumericUpDown.Value);
                if (categorias != null)
                {
                    LLenarCampo(categorias);

                }
                else
                {
                    MessageBox.Show("Categoria no encontrada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }


            }
            catch (Exception)
            {
                MessageBox.Show("Errores al eliminar", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

        }
    }
}
