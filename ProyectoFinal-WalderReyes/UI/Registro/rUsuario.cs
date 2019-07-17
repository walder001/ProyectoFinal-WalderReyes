using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using BLL;
using DAL;
using System.Security.Cryptography;

namespace ProyectoFinal.UI.Registro
{
    public partial class rUsuario : Form
    {
        public rUsuario()
        {
            InitializeComponent();
            //txtClave.Text = EnCryptDecrypt.CryptorEngine.Encrypt(txtClave.Text, true);

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        //Limpia
        //UsuarioId, Nombres, Email, NivelUsuario, Usuario, Clave, FechaIngreso
        private void Limpiar()
        {
            UsarioId.Value = 0;
            txtNombre.Text = string.Empty;
            txtEmail.Text = string.Empty;
            NivelUsuario.Value = 0;
            txtUsuario.Text = string.Empty;
            txtClave.Text = string.Empty;
            dateTime.Value = DateTime.Now;
            ErrorProvider.Clear();
        }

        //Eventos de los botones
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            
            Limpiar();

        }

        //UsuarioId, Nombres, Email, NivelUsuario, Usuario, Clave, FechaIngreso

        private Usuarios LlenarClase()
        {
            Usuarios us = new Usuarios();
            us.UsuarioId = Convert.ToInt32(UsarioId.Value);
            us.Nombre = txtNombre.Text;
            us.Email = txtEmail.Text;
            us.NivelUsuario = Convert.ToInt32(NivelUsuario.Value);
            us.Usuario = txtUsuario.Text;
            us.Clave = txtClave.Text;
            us.FehaIngreso = dateTime.Value;
            return us;
        }
        private void LlenaCampo(Usuarios usuarios)
        {
            UsarioId.Value = usuarios.UsuarioId;
            txtNombre.Text = usuarios.Nombre;
            txtEmail.Text = usuarios.Email;
            NivelUsuario.Value = usuarios.NivelUsuario;
            txtUsuario.Text = string.Empty;
            txtClave.Text = string.Empty;
            dateTime.Value = DateTime.Now;
        }

        private bool Validar()
        {
            bool paso = true;
            ErrorProvider.Clear();

            if (txtNombre.Text == string.Empty)
            {
                ErrorProvider.SetError(txtNombre, "El campo Nombre no puede estar vacio");
                txtNombre.Focus();
                paso = false;
            }

            //UsuarioId, Nombres, Email, NivelUsuario, Usuario, Clave, FechaIngreso

            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                ErrorProvider.SetError(txtUsuario, "El campo Direccion no puede estar vacio");
                txtUsuario.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(txtClave.Text))
            {
                ErrorProvider.SetError(txtClave, "El campo Direccion no puede estar vacio");
                txtClave.Focus();
                paso = false;
            }

            

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                ErrorProvider.SetError(txtEmail, "El campo Direccion no puede estar vacio");
                txtEmail.Focus();
                paso = false;
            }

            return paso;
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> UsuarioBLL = new RepositorioBase<Usuarios>(new Contexto());
            Usuarios usuarios = new Usuarios();

            bool paso = false;

            if (!Validar())
                return;

            usuarios = LlenarClase();
            Limpiar();

            //Determinar si es guardar o modificar
            if (UsarioId.Value == 0)
                paso = UsuarioBLL.Guardar(usuarios);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar una persona que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = UsuarioBLL.Modificar(usuarios);
            }

            //Informar el resultado
            if (paso)
                MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Usuarios> UsuarioBLL = new RepositorioBase<Usuarios>(new Contexto());

            Usuarios persona = UsuarioBLL.Buscar((int)UsarioId.Value);

            return (persona != null);


        }

 

        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> UsuarioBLL = new RepositorioBase<Usuarios>(new Contexto());

            int id;
            Usuarios persona = new Usuarios();
            int.TryParse(UsarioId.Text, out id);

            Limpiar();

            persona = UsuarioBLL.Buscar(id);

            if (persona != null)
            {
                MessageBox.Show("Persona Encontrada");
                LlenaCampo(persona);
            }
            else
            {
                MessageBox.Show("Persona no Encontada");
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> UsuarioBLL = new RepositorioBase<Usuarios>(new Contexto());

            ErrorProvider.Clear();
            int id;
            int.TryParse(UsarioId.Text, out id);
            Limpiar();
            if (UsuarioBLL.Eliminar(id))
                MessageBox.Show("Eliminado");
            else
                ErrorProvider.SetError(UsarioId, "No se puede eliminar una persona que no existe");
        }
    }
}
