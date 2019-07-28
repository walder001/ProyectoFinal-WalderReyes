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
    public partial class rClientes : Form
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public rClientes()
        {
            InitializeComponent();
        }

        //Metodo encargado de limpiar los campos del formualario
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
            BalanceTextBox.Text = string.Empty;

        }
        //Metodo encargado de pasar los datos del formulario a la clase
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
            cl.ClienteId = (int)ClienteIdNumericUpDown.Value;
            cl.Nombres = NombresTextBox.Text.TrimStart();
            cl.Sexo = sexo;
            cl.Direccion = DireccionTextBox.Text.TrimStart();
            cl.NumeroCedula = CedulaMaskedTextBox.Text;
            cl.Celular = CelulamaskedTextBox.Text;
            cl.Telefono = TelefonoMaskedTextBox.Text;
            cl.FechaNacimiento = NacimientoDateTime.Value;
            cl.Email = EmailTextBox.Text.TrimStart();
            cl.Balance = 0;
            return cl;
        }

        //Metodo encargado de la buscar los datos de la clase y llenar el formulario
        public void LLenaCampo(Clientes cl)
        {
            
            if (cl.Sexo == "Masculino")
            {
                MasculinoRadioButton.Checked = true;
            }
            else
            {
                FemeninoRadioButton.Checked = true;
            }
            ClienteIdNumericUpDown.Value = cl.ClienteId;
            NombresTextBox.Text = cl.Nombres;
            DireccionTextBox.Text = cl.Direccion;
            CedulaMaskedTextBox.Text = cl.NumeroCedula;
            CelulamaskedTextBox.Text = cl.Celular;
            TelefonoMaskedTextBox.Text = cl.Telefono;
            NacimientoDateTime.Value = cl.FechaNacimiento;
            EmailTextBox.Text = cl.Email;
            BalanceTextBox.Text = cl.Balance.ToString();
        }
        //Validacion de los campos de la clase
        public bool Validar()
        {
            bool paso = true;
            ErrorProvider.Clear();
            if (NombresTextBox.Text == string.Empty)
            {
                ErrorProvider.SetError(NombresTextBox,"El campo no puede estar vacio");
                NombresTextBox.Focus();
                paso = false;
            }
            if (DireccionTextBox.Text == string.Empty)
            {
                ErrorProvider.SetError(DireccionTextBox,"La direccion no puede esta vacia");
                DireccionTextBox.Focus();
                paso = false;
            }
            if (EmailTextBox.Text == string.Empty)
            {
                ErrorProvider.SetError(EmailTextBox,"El Email no puede esta vacio");
                EmailTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(NombresTextBox.Text))
            {
                ErrorProvider.SetError(NombresTextBox, "El campo no puede estar vacio");
                NombresTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                ErrorProvider.SetError(DireccionTextBox, "La direccion no puede esta vacia");
                DireccionTextBox.Focus();
                paso = false;
            }
            if (string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                ErrorProvider.SetError(EmailTextBox, "El Email no puede esta vacio");
                EmailTextBox.Focus();
                paso = false;
            }
            if (CedulaMaskedTextBox.MaskFull == false)
            {
                ErrorProvider.SetError(CedulaMaskedTextBox,"No puede haber espacios en blanco");
                CedulaMaskedTextBox.Focus();
                paso = false;
            }
            if (TelefonoMaskedTextBox.MaskFull == false)
            {
                ErrorProvider.SetError(TelefonoMaskedTextBox,"No puede haber espacios en blanco");
                TelefonoMaskedTextBox.Focus();
                paso = false;
            }
            if (ValidarEmail(EmailTextBox.Text) == false)
            {
                ErrorProvider.SetError(EmailTextBox, "Correo invalido");
                EmailTextBox.Focus();
                paso = false;
            }
            if (MasculinoRadioButton.Checked == false && FemeninoRadioButton.Checked == false)
            {
                ErrorProvider.SetError(FemeninoRadioButton, "Es campo sexo no puede esta vacio");
                FemeninoRadioButton.Focus();
                paso = false;
            }
          
            return paso;
        }
        //Metodo para ver si esiste el la base de tao
        public bool Existe()
        {
            RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>(new Contexto());

            Clientes cl = repositorio.Buscar((int)ClienteIdNumericUpDown.Value);

                return (cl != null);
        }

        //Validar campo para que solo admitan letras
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
        
        //Programacion del boton buevo
        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void NombresTextBox_TextChanged(object sender, EventArgs e)
        {

            
        }
        //Programacion del boton guardar
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                RepositorioBase<Clientes> BLL = new RepositorioBase<Clientes>(new Contexto());
                Clientes clientes = new Clientes();
                bool paso = false;
                if (!Validar())
                    return;
                clientes = LLenaCLase();
                if (ClienteIdNumericUpDown.Value == 0)
                {
                    Contexto contexto = new Contexto();
                    var op = contexto.Clientes.FirstOrDefault(c => c.Nombres == NombresTextBox.Text);
                    if (op != null)
                    {
                        ErrorProvider.SetError(NombresTextBox,"Cliente existente en la base de datos");
                        NombresTextBox.Focus();
                        paso = false;
                    }
                    else
                    {
                        paso = BLL.Guardar(clientes);

                    }


                }
                else
                {
                    if (!Existe())
                    {
                        MessageBox.Show("No se puede modificar un cliente que no existe","Informamtion",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
                    }
                    else
                    {
                        var opcion = MessageBox.Show("Decea Modificar el Usuario", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (DialogResult.OK == opcion)
                        {
                            paso = BLL.Modificar(clientes);
                        }
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
            catch (Exception)
            {
                MessageBox.Show("Error al guardar","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            } 

        }
        //Implementacion del boton eliminar
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>(new Contexto());
                ErrorProvider.Clear();
                int id = (int)ClienteIdNumericUpDown.Value;
                if (repositorio.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!!");
                    Limpiar();
                }
                else
                {
                    ErrorProvider.SetError(ClienteIdNumericUpDown, "No se puede eliminar un cleinte que no esiste");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo eliminar","Information",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        //Implementacion dell boton buscar
        private void BtnBuscar_Click(object sender, EventArgs e)
        {   
                RepositorioBase<Clientes> repositorio = new RepositorioBase<Clientes>(new Contexto());
                Clientes clientes = new Clientes();
             
               clientes = repositorio.Buscar((int)ClienteIdNumericUpDown.Value);
                if (clientes != null)
                {
                    Limpiar();   
                    LLenaCampo(clientes);
                }
                else
                {
                    MessageBox.Show("Cliente no encontrado","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Limpiar();

                }
           

        }
        //Implementacion del metodo para que solo accepte lentras
        private void NombresTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloLetras(e);
        }
        //Implementacion de la la validacion para el email
        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {
            ValidarEmail(EmailTextBox.Text);
           
        }

        //Implementacion de la validacion para la cedula
        private void CedulaMaskedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumero(e);
        }
    }
}
