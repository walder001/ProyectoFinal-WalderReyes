using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Clientes
    {
        [Key]
        public int CienteId { get; set; }
        public string Nombres { get; set; }
        public string Sexo { get; set; }
        public string Direccion { get; set; }
        public string NumeroCedula { get; set; }
        public string Celular { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public Clientes()
        {
            CienteId = 0;
            Nombres = string.Empty;
            Sexo = string.Empty;
            Direccion = string.Empty;
            NumeroCedula = string.Empty;
            Celular = string.Empty;
            Telefono = string.Empty;
            FechaNacimiento = DateTime.Now;
            Email = string.Empty;

        }

        public Clientes(int cienteId, string nombres, string sexo, string direccion, string numeroCedula, string celular, string telefono, DateTime fechaNacimiento, string email)
        {
            CienteId = cienteId;
            Nombres = nombres;
            Sexo = sexo;
            Direccion = direccion;
            NumeroCedula = numeroCedula;
            Celular = celular;
            Telefono = telefono;
            FechaNacimiento = fechaNacimiento;
            Email = email;
        }
    }
}

