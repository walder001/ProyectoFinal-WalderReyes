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

        //Limpia
        //UsuarioId, Nombres, Email, NivelUsuario, Usuario, Clave, FechaIngreso
        private void Limpiar()
        {
            UsarioId.Value = 0;
            txtNombre.Text = string.Empty;
            txtEmail.Text = string.Empty;
            NiverUsuarioComboBox.Text = null;
            txtUsuario.Text = string.Empty;
            ClaveTexBox.Text = string.Empty;
            ConfirmarTextbox.Text = string.Empty;
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
            us.Nombres = txtNombre.Text.TrimStart();
            us.Email = txtEmail.Text.TrimStart();
            us.NivelUsuario = Convert.ToInt32(NiverUsuarioComboBox.SelectedIndex);
            us.Usuario = txtUsuario.Text.TrimStart();
            us.Clave = EnCryptDecrypt.CryptorEngine.Encrypt(ClaveTexBox.Text,true) ;
            us.FehaIngreso = dateTime.Value;
            return us;
        }
        private void LlenaCampo(Usuarios usuarios)
        {
            UsarioId.Value = usuarios.UsuarioId;
            txtNombre.Text = usuarios.Nombres;
            txtEmail.Text = usuarios.Email;
            NiverUsuarioComboBox.SelectedIndex = usuarios.NivelUsuario;
            txtUsuario.Text = usuarios.Usuario;
            ClaveTexBox.Text = EnCryptDecrypt.CryptorEngine.Decrypt(usuarios.Clave, true);
            ConfirmarTextbox.Text = EnCryptDecrypt.CryptorEngine.Decrypt(usuarios.Clave, true); ;
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
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                ErrorProvider.SetError(txtNombre, "El campo Nombre no puede estar vacio");
                txtNombre.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                ErrorProvider.SetError(txtUsuario, "El campo Direccion no puede estar vacio");
                txtUsuario.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(ClaveTexBox.Text))
            {
                ErrorProvider.SetError(ClaveTexBox, "El campo Direccion no puede estar vacio");
                ClaveTexBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                ErrorProvider.SetError(txtEmail, "El campo Direccion no puede estar vacio");
                txtEmail.Focus();
                paso = false;
            }
            if (ClaveTexBox.Text != ConfirmarTextbox.Text)
            {
                ErrorProvider.SetError(ClaveTexBox,"La clave no coinciden");
                ClaveTexBox.Focus();
                paso = false;
            }
            if (NiverUsuarioComboBox.SelectedValue != null)
            {
                ErrorProvider.SetError(NiverUsuarioComboBox, "El nive no puede esta vacio");
                NiverUsuarioComboBox.Focus();
                paso = false;
            }
            
            return paso;
        }
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                RepositorioBase<Usuarios> UsuarioBLL = new RepositorioBase<Usuarios>(new Contexto());
                Usuarios usuarios = new Usuarios();

                bool paso = false;

                if (!Validar())
                    return;

                usuarios = LlenarClase();
                //Determinar si es guardar o modificar
                if (UsarioId.Value == 0)
                {
                    Contexto contexto = new Contexto();
                    var op = contexto.Ususarios.FirstOrDefault(a => a.Usuario == txtUsuario.Text);
                    if (op != null)
                    {
                        ErrorProvider.SetError(txtUsuario, "Usuario Existente");
                        NiverUsuarioComboBox.Focus();
                        paso = false;

                    }
                    else
                    {
                        paso = UsuarioBLL.Guardar(usuarios);
                        Limpiar();

                    }
                   

                }  
                else
                {
                    if (!ExisteEnLaBaseDeDatos())
                    {
                        MessageBox.Show("No se puede modificar una persona que no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var opcion = MessageBox.Show("Decea Modificar el Usuario","Question",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
                    if (DialogResult.OK == opcion)
                    {
                        paso = UsuarioBLL.Modificar(usuarios);
                    }
                    
                }

                //Informar el resultado
                if (paso)
                    MessageBox.Show("Guardado!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo guardar","Information",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
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

            try
            {
                Limpiar();

                persona = UsuarioBLL.Buscar(id);

                if (persona != null)
                {
                    LlenaCampo(persona);
                }
                else
                {
                    MessageBox.Show("Persona no Encontada");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No fue posible buscarlo");
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Usuarios> UsuarioBLL = new RepositorioBase<Usuarios>(new Contexto());

            try
            {
                ErrorProvider.Clear();
                int id;
                int.TryParse(UsarioId.Text, out id);
                Limpiar();
                if (UsuarioBLL.Eliminar(id))
                    MessageBox.Show("Eliminado");
                else
                    ErrorProvider.SetError(UsarioId, "No se puede eliminar una persona que no existe");

            }
            catch (Exception)
            {
                MessageBox.Show("No fue posible eliminar","Imformation",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
          }

        
        public void SoloLetras(KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }else if (char.IsLetter(e.KeyChar))
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

      public void LetrasNumeros(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;

            }else if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;

            }
            else
            {
                e.Handled = true;
            }
        }

        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }

        private void TxtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            LetrasNumeros(e);
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                ClaveTexBox.UseSystemPasswordChar = false;
                ConfirmarTextbox.UseSystemPasswordChar = false;


            }
            else
            {
                ClaveTexBox.UseSystemPasswordChar = true;
                ConfirmarTextbox.UseSystemPasswordChar = true;

            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ClaveTexBox.UseSystemPasswordChar = true;
        }

        
    }
}
