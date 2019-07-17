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
    public partial class rClientes : Form
    {
        public rClientes()
        {
            InitializeComponent();
        }
        public void Limpiar()
        {
            ClienteIdNumericUpDown.Value = 0;
            NombresTextBox.Text = string.Empty;
            MasculinoRadioButton.Checked = false;
            FemeninoRadioButton.Checked = false;
            DireccionTextBox.Text = string.Empty;
            NombresTextBox.Text = string.Empty;
            CedulaMaskedTextBox.Text = string.Empty;
            CedulaMaskedTextBox.Text = string.Empty;
            TelefonoMaskedTextBox.Text = string.Empty;
            NacimientoDateTime.Value = DateTime.Now;
            EmailTextBox.Text = string.Empty;


        }
        public Clientes LLenaCLase()
        {
            Clientes cl = new Clientes();
            string sexo;
            if (MasculinoRadioButton.Checked)
            {
                sexo = MasculinoRadioButton.Text;
            }
            else
            {
                sexo = FemeninoRadioButton.Text;
            }
            cl.CienteId = (int)ClienteIdNumericUpDown.Value;
            cl.Nombres = NombresTextBox.Text;
            cl.Sexo = sexo;
            cl.Direccion = DireccionTextBox.Text;
            cl.NumeroCedula = CedulaMaskedTextBox.Text;
            cl.Celular = CelulamaskedTextBox.Text;
            cl.Telefono = TelefonoMaskedTextBox.Text;
            cl.FechaNacimiento = NacimientoDateTime.Value;
            cl.Email = EmailTextBox.Text;
            return cl;
        }

        public void LLenaCampo(Clientes cl)
        {
            string sexo;
            if (MasculinoRadioButton.Checked)
            {
                sexo = MasculinoRadioButton.Text;
            }
            else
            {
                sexo = FemeninoRadioButton.Text;
            }
            ClienteIdNumericUpDown.Value = cl.CienteId;
            NombresTextBox.Text = cl.Nombres;
            sexo = cl.Sexo;
            DireccionTextBox.Text = cl.Direccion;
            CedulaMaskedTextBox.Text = cl.NumeroCedula;
            CelulamaskedTextBox.Text = cl.Celular;
            TelefonoMaskedTextBox.Text = cl.Telefono;
            NacimientoDateTime.Value = cl.FechaNacimiento;
            EmailTextBox.Text = cl.Email;
        }
        public bool Validar()
        {
            bool paso = true;
            ErrorProvider.Clear();
            if (NombresTextBox.Text == string.Empty)
            {
                ErrorProvider.SetError(NombresTextBox,"El campo no puede estar vacio");
                NombresTextBox.Focus();
                paso = false;
            }else if (DireccionTextBox.Text == string.Empty)
            {
                ErrorProvider.SetError(DireccionTextBox,"La direccion no puede esta vacia");
                DireccionTextBox.Focus();
                paso = false;
            }else if (EmailTextBox.Text == string.Empty)
            {
                ErrorProvider.SetError(EmailTextBox,"El Email no puede esta vacio");
                EmailTextBox.Focus();
                paso = false;
            }

            return paso;
        }
        public bool Existe()
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>(new Contexto());

            Clientes cl = repositorio.Buscar((int)ClienteIdNumericUpDown.Value);

                return (cl != null);
        }
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void NombresTextBox_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Clientes> BLL = new RepositorioBase<Clientes>(new Contexto());
            Clientes clientes = new Clientes();
            bool paso = false;
            if (!Validar())
                return;
            clientes = LLenaCLase();
            Limpiar();
            if (!Existe())
            {
                MessageBox.Show("No se puede modificar un cliente que no existe");
            }
            else
            {
                paso = BLL.Modificar(clientes);
            }
            if (paso)
            {
                MessageBox.Show("Guardado!!","Information",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se pudo Guardar","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>(new Contexto());
            ErrorProvider.Clear();
            int id = (int)ClienteIdNumericUpDown.Value;
            if (repositorio.Eliminar(id))
            {
                MessageBox.Show("Eliminado!!");

            }
            else{
                ErrorProvider.SetError(ClienteIdNumericUpDown,"No se puede eliminar un cleinte que no esiste");
            }

        }
    }
}
