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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinal_WalderReyes.UI.Registro
{
    public partial class rProveedor : Form
    {
        public rProveedor()
        {
            InitializeComponent();
        }
        public void Limpiar()
        {
            ProveedordNumericUpDown.Value = 0;
            NombreTextBox.Text = string.Empty;
            RNCMaskedTextBox.Text = string.Empty;
            TelefonoMaskedTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            NombreRepresentantetextBox.Text = string.Empty;
            ExtencionNumericUpDown.Value = 0;

        }
        public Proveedores LLenaClase()
        {
            Proveedores proveedores = new Proveedores();
            proveedores.ProveedorId = (int)ProveedordNumericUpDown.Value;
            proveedores.NombreProveedor = NombreTextBox.Text;
            proveedores.RNC = RNCMaskedTextBox.Text;
            proveedores.TelefonoProveedor = TelefonoMaskedTextBox.Text;
            proveedores.Email = EmailTextBox.Text;
            proveedores.NombreRepresentante = NombreRepresentantetextBox.Text;
            proveedores.ExtencionRepresentante = (int)ExtencionNumericUpDown.Value;
            return proveedores;
        }

        public void LLanaCampo(Proveedores proveedores)
        {
            ProveedordNumericUpDown.Value = proveedores.ProveedorId;
            NombreTextBox.Text = proveedores.NombreProveedor;
            RNCMaskedTextBox.Text = proveedores.RNC;
            TelefonoMaskedTextBox.Text = proveedores.TelefonoProveedor;
            EmailTextBox.Text = proveedores.Email;
            NombreRepresentantetextBox.Text = proveedores.NombreRepresentante;
            ExtencionNumericUpDown.Value = proveedores.ExtencionRepresentante;
        }
        //Metodo para ver si esiste el la base de tao
        public bool Existe()
        {
            RepositorioBase<Proveedores> repositorio = new RepositorioBase<Proveedores>(new Contexto());

            Proveedores cl = repositorio.Buscar((int)ProveedordNumericUpDown.Value);

            return (cl != null);
        }

        //Validar campo para que solo admitan letras
        public void SoloLetras(KeyPressEventArgs e)

        {
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;

            }
            else if (char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;

            }

        }
        public void SoloNumero(KeyPressEventArgs e)
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
        //Expresion regural para validar el Email
        private Boolean ValidarEmail(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        //Expresion regural para validar el Email
        private Boolean ValidarTelefono(String email)
        {
            String expresion;
            expresion = "^[0-9- +] + $";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Validar()
        {
            ErrorProvider.Clear();
            bool paso  = true;
            if (string.IsNullOrWhiteSpace(NombreTextBox.Text))
            {
                ErrorProvider.SetError(NombreTextBox,"No nombre no puedes esta en blanco");
                NombreTextBox.Focus();
                paso = false;
            }
            if (ValidarTelefono(TelefonoMaskedTextBox.Text) == false)
            {
                ErrorProvider.SetError(TelefonoMaskedTextBox, "EmailInvalido");
                TelefonoMaskedTextBox.Focus();
                paso = false;

            }
            if (ValidarEmail(EmailTextBox.Text) == false)
            {
                ErrorProvider.SetError(EmailTextBox,"EmailInvalido");
                EmailTextBox.Focus();
                paso = false;

            }
            return paso;
        }
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Proveedores> repositorio = new RepositorioBase<Proveedores>(new Contexto());
            Proveedores proveedores = repositorio.Buscar((int)ProveedordNumericUpDown.Value);
            if (proveedores != null)
            {
                LLanaCampo(proveedores);

            }
            else
            {
                MessageBox.Show("Proveedor no encontrado", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void NombreTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }

        private void RNCMaskedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumero(e);
        }

        private void NombreRepresentantetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Proveedores> repositorio = new RepositorioBase<Proveedores>(new Contexto());
            Proveedores proveedores = new Proveedores();
            bool paso = false;
            if (!Validar())
                return;
            proveedores = LLenaClase();
            Limpiar();
            if ((int)ProveedordNumericUpDown.Value == 0)
            {
                paso = repositorio.Guardar(proveedores);
            }
            else
            {
                if (!Existe())
                {
                    MessageBox.Show("No se puede modificar un proveedor que existe","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var opcion = MessageBox.Show("Decea real mente modificar", "Information", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if ( opcion == DialogResult.OK)
                    {
                        paso = repositorio.Modificar(proveedores);
                    }
                }
                if (paso)
                {
                    MessageBox.Show("Guardado!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo Guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Proveedores> repositorio = new RepositorioBase<Proveedores>(new Contexto());
            int id = (int)ProveedordNumericUpDown.Value;
            if (repositorio.Eliminar(id))
            {
                MessageBox.Show("Eliminado!!");

            }
            else
            {
                ErrorProvider.SetError(ProveedordNumericUpDown, "No se puede eliminar un cleinte que no esiste");
            }
        }
    }
}
